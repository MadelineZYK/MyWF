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

namespace HYTC.Exercise
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string ip = this.txtIP.Text;
            UdpClient uc = new UdpClient();
            string msg = "PUBLIC|"+this.txtMsg.Text+"|zyk";
            Byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            uc.Send(bmsg, bmsg.Length, ipep);//字符串用length，数组用count
            this.txtMsg.Text = null;
        }

        private void listen()
        {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                byte[] bmsg = uc.Receive(ref ipep);
                string msg = Encoding.Default.GetString(bmsg);
                string[] sp = msg.Split('|'); 
                if (sp[0] == "INROOM")
                {
                    this.txtHistory.Text += sp[1] +"上线了！"+ "\r\n";
                }
                if (sp[0] == "PUBLIC")
                {
                    this.txtHistory.Text += sp[2] + "说：" + sp[1] + "\r\n";
                }
                if (sp[0] == "OUTROOM")
                {
                    this.txtHistory.Text += sp[1] + "离线了！" + "\r\n";
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string ip = this.txtIP.Text;
            UdpClient uc = new UdpClient();
            string msg = "INROOM|"+"zyk";
            Byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            uc.Send(bmsg, bmsg.Length, ipep);//字符串用length，数组用count

            FrmMain.CheckForIllegalCrossThreadCalls = false;
            Thread th = new Thread(new ThreadStart(listen));
            th.IsBackground = true;
            th.Start();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ip = this.txtIP.Text;
            UdpClient uc = new UdpClient();
            string msg = "OUTROOM|" + "zyk";
            Byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            uc.Send(bmsg, bmsg.Length, ipep);
        }

    }
}
