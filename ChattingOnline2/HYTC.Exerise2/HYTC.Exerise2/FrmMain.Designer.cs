namespace HYTC.Exerise2
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pbHeadImage = new System.Windows.Forms.PictureBox();
            this.pnFriendsList = new System.Windows.Forms.Panel();
            this.lblNickName = new System.Windows.Forms.Label();
            this.lblShuoshuo = new System.Windows.Forms.Label();
            this.ilHeadImages = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHeadImage
            // 
            this.pbHeadImage.Location = new System.Drawing.Point(5, 5);
            this.pbHeadImage.Name = "pbHeadImage";
            this.pbHeadImage.Size = new System.Drawing.Size(60, 60);
            this.pbHeadImage.TabIndex = 0;
            this.pbHeadImage.TabStop = false;
            // 
            // pnFriendsList
            // 
            this.pnFriendsList.AutoScroll = true;
            this.pnFriendsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnFriendsList.Location = new System.Drawing.Point(5, 82);
            this.pnFriendsList.Name = "pnFriendsList";
            this.pnFriendsList.Size = new System.Drawing.Size(300, 356);
            this.pnFriendsList.TabIndex = 3;
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(85, 5);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(41, 12);
            this.lblNickName.TabIndex = 4;
            this.lblNickName.Text = "label1";
            // 
            // lblShuoshuo
            // 
            this.lblShuoshuo.AutoSize = true;
            this.lblShuoshuo.Location = new System.Drawing.Point(85, 36);
            this.lblShuoshuo.Name = "lblShuoshuo";
            this.lblShuoshuo.Size = new System.Drawing.Size(41, 12);
            this.lblShuoshuo.TabIndex = 5;
            this.lblShuoshuo.Text = "label2";
            // 
            // ilHeadImages
            // 
            this.ilHeadImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilHeadImages.ImageStream")));
            this.ilHeadImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilHeadImages.Images.SetKeyName(0, "head.jpg");
            this.ilHeadImages.Images.SetKeyName(1, "h2.jpg");
            this.ilHeadImages.Images.SetKeyName(2, "h3.jpg");
            this.ilHeadImages.Images.SetKeyName(3, "h4.jpg");
            this.ilHeadImages.Images.SetKeyName(4, "h5.jpg");
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.lblShuoshuo);
            this.Controls.Add(this.lblNickName);
            this.Controls.Add(this.pnFriendsList);
            this.Controls.Add(this.pbHeadImage);
            this.Name = "FrmMain";
            this.Text = "聊天……";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHeadImage;
        public System.Windows.Forms.Panel pnFriendsList;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.Label lblShuoshuo;
        public System.Windows.Forms.ImageList ilHeadImages;
    }
}

