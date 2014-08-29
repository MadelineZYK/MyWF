using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HYTC.Exerise2
{
    public partial class UCFriend : UserControl
    {
        public delegate void deldoubleclick(object o, EventArgs e);
        public event deldoubleclick myDBClick;
        private FrmMain frm;

        public FrmMain Frm
        {
            get { return frm; }
            set { frm = value; }
        }

        private Friend curFriend;

        public Friend CurFriend 
        {
            get { return curFriend; }
            set
            {
                curFriend = value;
                this.lblNickName.Text = value.NickName;
                this.lblShuoshuo.Text = value.Shuoshuo;
                this.picHeadImage.Image = this.frm.ilHeadImages.Images[value.HeadImageIndex];
            }
        }

        public UCFriend()
        {
            InitializeComponent();
        }

        private void UCFriend_Load(object sender, EventArgs e)
        {

        }

        private void picHeadImage_DoubleClick(object sender, EventArgs e)
        {
            this.myDBClick(this, e);
        }

        private void lblNickName_DoubleClick(object sender, EventArgs e)
        {
            this.myDBClick(this, e);
        }

        private void lblShuoshuo_DoubleClick(object sender, EventArgs e)
        {
            this.myDBClick(this, e);
        }

        private void UCFriend_DoubleClick(object sender, EventArgs e)
        {
            this.myDBClick(sender, e);
        }


    }
}
