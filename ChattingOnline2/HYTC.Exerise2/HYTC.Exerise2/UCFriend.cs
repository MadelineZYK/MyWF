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


    }
}
