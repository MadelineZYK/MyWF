using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace HYTC.Exerise2
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }

        private Thread th;
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            IPAddress myIP = Operation.getMyIP();
            if (myIP == null)
            {
                MessageBox.Show("对不起，未找到能工作的网卡，请检查!");
                Application.Exit();
            }
            FrmMain.CheckForIllegalCrossThreadCalls = false;

            Operation ope = new Operation(this);
            //侦听
            th = new Thread(new ThreadStart(ope.listen));
            th.IsBackground = true;
            th.Start();
            
            Thread.Sleep(100);

            //发广播
            UdpClient uc = new UdpClient();
            string myNickName = myIP.ToString();
            string msg = "LOGIN|" + myNickName + "|12|独我无二";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            uc.Send(bmsg, bmsg.Length, new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527));
        }

        public void addUcf(Friend f)
        {
            UCFriend ucf = new UCFriend();
            ucf.Frm = this;
            ucf.CurFriend = f;
            ucf.Top = this.pnFriendsList.Controls.Count * ucf.Height;
            ucf.Width = ucf.Width - 30;
            ucf.DoubleClick += ucf_DoubleClick;
            this.pnFriendsList.Controls.Add(ucf);
        }

        void ucf_DoubleClick(object sender, EventArgs e)
        {
            //获取当前被双击的这个用户控件对象的curFriend属性
            UCFriend ucf = (UCFriend)sender;
            FrmChat frm = new FrmChat(ucf.CurFriend);
            frm.Show();
        }

        public void RemoveUcf(UCFriend ucf)
        {
            
            this.pnFriendsList.Controls.Remove(ucf);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            IPAddress myIP = Operation.getMyIP();
            UdpClient uc = new UdpClient();
            string myNickName = myIP.ToString();
            string msg = "LOGOUT|";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            uc.Send(bmsg, bmsg.Length, new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527));
            th.Abort();
        }

    }
}
