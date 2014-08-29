using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HYTC.Exerise2
{
    public class Operation
    {
        public delegate void delAddFriend(Friend friend);
        public delegate void delRemoveFriend(UCFriend ucf);

        private FrmMain _frm;
        public Operation(FrmMain frm)
        {
            _frm = frm;
        }

        public static IPAddress getMyIP()
        {
            IPAddress myip=null;
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myip= ip;
                    break;
                }
            }
            return myip;
        }

        public void listen()
        {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                byte[] bmsg = uc.Receive(ref ipep);
                IPAddress iip = ipep.Address;
                string msg = Encoding.Default.GetString(bmsg);
                string[] datas = msg.Split('|');
                string msgHead = datas[0];
                switch (msgHead)
                {
                    case "LOGIN":
                        if (datas.Length != 4)
                        {
                            continue;
                        }

                        if (getMyIP().ToString()==ipep.Address.ToString())
                        {
                            continue;
                        }

                        Friend friend = new Friend();

                        int curIndex = Convert.ToInt32(datas[2]);

                        if (curIndex < 0 || curIndex >= _frm.ilHeadImages.Images.Count)
                        {
                            curIndex = 0;
                        }
                        friend.HeadImageIndex = curIndex;
                        friend.NickName = datas[1];
                        friend.Shuoshuo = datas[3];
                        friend.IP = ipep.Address;
                        object[] pars = new object[1];
                        pars[0] = friend;
                        _frm.Invoke(new delAddFriend(_frm.addUcf), pars);

                        //回发，告诉对方我也在，ALSOON|昵称|头像|说说
                        UdpClient ucAlsoon = new UdpClient();
                        string alsoonMsg = "ALSOON|" + getMyIP() + "|3|这个人很懒";
                        byte[] bAlsoonMsg = Encoding.Default.GetBytes(alsoonMsg);
                        ucAlsoon.Send(bAlsoonMsg, bAlsoonMsg.Length, new IPEndPoint(ipep.Address,9527));
                        
                        break;

                    case "ALSOON":
                        if (datas.Length != 4)
                        {
                            continue;
                        }

                        if (getMyIP().ToString()==ipep.Address.ToString())
                        {
                            continue;
                        }

                        Friend alsoFriend = new Friend();

                        int alsoCurIndex = Convert.ToInt32(datas[2]);

                        if (alsoCurIndex < 0 || alsoCurIndex >= _frm.ilHeadImages.Images.Count)
                        {
                            alsoCurIndex = 0;
                        }
                        alsoFriend.HeadImageIndex = alsoCurIndex;
                        alsoFriend.NickName = datas[1];
                        alsoFriend.Shuoshuo = datas[3];
                        alsoFriend.IP = ipep.Address;
                        object[] alsoPars = new object[1];
                        alsoPars[0] = alsoFriend;
                        _frm.Invoke(new delAddFriend(_frm.addUcf), alsoPars);
                    break;

                    case "LOGOUT":
                        Panel pnlist = _frm.getPanel();
                        int deleIndex = 0;
                        //根据当前下线人的IP地址，找到pn中对应的用户控件对象，删除。
                        foreach (UCFriend ItUcf in pnlist.Controls)
                        {
                            if (ItUcf.CurFriend.IP.ToString()==ipep.Address.ToString())
                            {
                                pnlist.Controls.Remove(ItUcf);
                                break;
                            }
                            deleIndex++;
                        }

                        //让其下面的每一个用户控件对象依次上移
                        for (int i = deleIndex + 1; i < pnlist.Controls.Count; i++)
                        {
                            pnlist.Controls[i].Top = i * pnlist.Controls[0].Height;
                        }

                        break;

                    default:
                    break;
                }
                
            }
        }

        
    }
}
