using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

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
                
                if (datas[0] == "LOGIN")
                {
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
                }
                if (datas[0] == "LOGOUT")
                {
                    foreach (UCFriend imgs in _frm.pnFriendsList.Controls)
                    {
                        if (imgs.CurFriend.IP.ToString() == iip.ToString())
                        {
                            object[] pars = new object[1];
                            pars[0] = imgs;
                            _frm.Invoke(new delRemoveFriend(_frm.RemoveUcf), pars);
                        }
                    }
                    //for (int i = 0; i < _frm.pnFriendsList.Controls.Count; i++)
                    //{
                    //    Friend f = new Friend();
                    //    UCFriend ucf = new UCFriend();
                    //    ucf.Frm = _frm;
                    //    ucf.CurFriend = f;
                    //    ucf.Top = _frm.pnFriendsList.Controls.Count * ucf.Height;
                    //}
                    foreach (UCFriend image in _frm.pnFriendsList.Controls)
                    {
                        image.Top = _frm.pnFriendsList.Controls.Count * image.Height;
                    }
                }
            }
        }

        
    }
}
