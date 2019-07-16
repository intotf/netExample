namespace ArcSoftFace
{
    partial class FaceForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceForm));
            this.lblImageList = new System.Windows.Forms.Label();
            this.chooseMultiImgBtn = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.chooseImgBtn = new System.Windows.Forms.Button();
            this.imageLists = new System.Windows.Forms.ImageList(this.components);
            this.imageList = new System.Windows.Forms.ListView();
            this.matchBtn = new System.Windows.Forms.Button();
            this.btnClearFaceList = new System.Windows.Forms.Button();
            this.lblCompareImage = new System.Windows.Forms.Label();
            this.lblCompareInfo = new System.Windows.Forms.Label();
            this.picImageCompare = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImageCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImageList
            // 
            this.lblImageList.AutoSize = true;
            this.lblImageList.Location = new System.Drawing.Point(12, 11);
            this.lblImageList.Name = "lblImageList";
            this.lblImageList.Size = new System.Drawing.Size(47, 12);
            this.lblImageList.TabIndex = 7;
            this.lblImageList.Text = "人脸库:";
            // 
            // chooseMultiImgBtn
            // 
            this.chooseMultiImgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseMultiImgBtn.Location = new System.Drawing.Point(14, 431);
            this.chooseMultiImgBtn.Name = "chooseMultiImgBtn";
            this.chooseMultiImgBtn.Size = new System.Drawing.Size(133, 26);
            this.chooseMultiImgBtn.TabIndex = 32;
            this.chooseMultiImgBtn.Text = "注册人脸";
            this.chooseMultiImgBtn.UseVisualStyleBackColor = true;
            this.chooseMultiImgBtn.Click += new System.EventHandler(this.ChooseMultiImg);
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.White;
            this.logBox.Location = new System.Drawing.Point(14, 682);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(895, 135);
            this.logBox.TabIndex = 31;
            // 
            // chooseImgBtn
            // 
            this.chooseImgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseImgBtn.Location = new System.Drawing.Point(603, 431);
            this.chooseImgBtn.Name = "chooseImgBtn";
            this.chooseImgBtn.Size = new System.Drawing.Size(120, 26);
            this.chooseImgBtn.TabIndex = 30;
            this.chooseImgBtn.Text = "选择识别图";
            this.chooseImgBtn.UseVisualStyleBackColor = true;
            this.chooseImgBtn.Click += new System.EventHandler(this.ChooseImg);
            // 
            // imageLists
            // 
            this.imageLists.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageLists.ImageStream")));
            this.imageLists.TransparentColor = System.Drawing.Color.Transparent;
            this.imageLists.Images.SetKeyName(0, "alai_152784032385984494.jpg");
            // 
            // imageList
            // 
            this.imageList.LargeImageList = this.imageLists;
            this.imageList.Location = new System.Drawing.Point(14, 37);
            this.imageList.Name = "imageList";
            this.imageList.Size = new System.Drawing.Size(527, 362);
            this.imageList.TabIndex = 33;
            this.imageList.UseCompatibleStateImageBehavior = false;
            // 
            // matchBtn
            // 
            this.matchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.matchBtn.Location = new System.Drawing.Point(781, 431);
            this.matchBtn.Name = "matchBtn";
            this.matchBtn.Size = new System.Drawing.Size(128, 26);
            this.matchBtn.TabIndex = 34;
            this.matchBtn.Text = "开始匹配";
            this.matchBtn.UseVisualStyleBackColor = true;
            this.matchBtn.Click += new System.EventHandler(this.matchBtn_Click);
            // 
            // btnClearFaceList
            // 
            this.btnClearFaceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFaceList.Location = new System.Drawing.Point(416, 431);
            this.btnClearFaceList.Name = "btnClearFaceList";
            this.btnClearFaceList.Size = new System.Drawing.Size(125, 26);
            this.btnClearFaceList.TabIndex = 35;
            this.btnClearFaceList.Text = "清空人脸库";
            this.btnClearFaceList.UseVisualStyleBackColor = true;
            this.btnClearFaceList.Click += new System.EventHandler(this.btnClearFaceList_Click);
            // 
            // lblCompareImage
            // 
            this.lblCompareImage.AutoSize = true;
            this.lblCompareImage.Location = new System.Drawing.Point(601, 11);
            this.lblCompareImage.Name = "lblCompareImage";
            this.lblCompareImage.Size = new System.Drawing.Size(59, 12);
            this.lblCompareImage.TabIndex = 36;
            this.lblCompareImage.Text = "比对人脸:";
            // 
            // lblCompareInfo
            // 
            this.lblCompareInfo.AutoSize = true;
            this.lblCompareInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompareInfo.Location = new System.Drawing.Point(667, 11);
            this.lblCompareInfo.Name = "lblCompareInfo";
            this.lblCompareInfo.Size = new System.Drawing.Size(0, 16);
            this.lblCompareInfo.TabIndex = 37;
            // 
            // picImageCompare
            // 
            this.picImageCompare.BackColor = System.Drawing.Color.Transparent;
            this.picImageCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImageCompare.Location = new System.Drawing.Point(0, 0);
            this.picImageCompare.Name = "picImageCompare";
            this.picImageCompare.Size = new System.Drawing.Size(1005, 588);
            this.picImageCompare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImageCompare.TabIndex = 1;
            this.picImageCompare.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ArcSoftFace.Properties.Resources.bg;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1005, 588);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // FaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1005, 588);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picImageCompare);
            this.Controls.Add(this.lblCompareInfo);
            this.Controls.Add(this.lblCompareImage);
            this.Controls.Add(this.btnClearFaceList);
            this.Controls.Add(this.matchBtn);
            this.Controls.Add(this.imageList);
            this.Controls.Add(this.chooseMultiImgBtn);
            this.Controls.Add(this.chooseImgBtn);
            this.Controls.Add(this.lblImageList);
            this.Controls.Add(this.logBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArcSoftFace C# demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FaceForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picImageCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblImageList;
        private System.Windows.Forms.Button chooseMultiImgBtn;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button chooseImgBtn;
        private System.Windows.Forms.ImageList imageLists;
        private System.Windows.Forms.ListView imageList;
        private System.Windows.Forms.Button matchBtn;
        private System.Windows.Forms.Button btnClearFaceList;
        private System.Windows.Forms.Label lblCompareImage;
        private System.Windows.Forms.Label lblCompareInfo;
        private System.Windows.Forms.PictureBox picImageCompare;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

