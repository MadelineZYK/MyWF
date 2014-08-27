using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HYTC.Exerise2
{
    public partial class FrmChat : Form
    {
        UCFriend ucf = new UCFriend();

        public FrmChat()
        {
            InitializeComponent();
        }

        public FrmChat(Friend f)
        {
            InitializeComponent();
            ucf.CurFriend = f;
        }

        private void FrmChat_Load(object sender, EventArgs e)
        {
            this.Text = "与" + ucf.CurFriend.NickName + "火热聊天中……";
        }
    }
}
