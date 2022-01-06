
namespace MazePhoto
{
    partial class Form1
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
            this.createBtn = new System.Windows.Forms.Button();
            this.pathfindBtn = new System.Windows.Forms.Button();
            this.mazePanel = new System.Windows.Forms.Panel();
            this.rowBox = new System.Windows.Forms.TextBox();
            this.columnBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mazePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(179, 17);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 0;
            this.createBtn.Text = "创建迷宫";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // pathfindBtn
            // 
            this.pathfindBtn.Location = new System.Drawing.Point(279, 17);
            this.pathfindBtn.Name = "pathfindBtn";
            this.pathfindBtn.Size = new System.Drawing.Size(75, 23);
            this.pathfindBtn.TabIndex = 1;
            this.pathfindBtn.Text = "自动寻路";
            this.pathfindBtn.UseVisualStyleBackColor = true;
            this.pathfindBtn.Click += new System.EventHandler(this.pathfindBtn_Click);
            // 
            // mazePanel
            // 
            this.mazePanel.AutoScroll = true;
            this.mazePanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mazePanel.Controls.Add(this.pictureBox1);
            this.mazePanel.Location = new System.Drawing.Point(12, 59);
            this.mazePanel.Name = "mazePanel";
            this.mazePanel.Padding = new System.Windows.Forms.Padding(2);
            this.mazePanel.Size = new System.Drawing.Size(611, 490);
            this.mazePanel.TabIndex = 2;
            // 
            // rowBox
            // 
            this.rowBox.Location = new System.Drawing.Point(33, 18);
            this.rowBox.MaxLength = 3;
            this.rowBox.Name = "rowBox";
            this.rowBox.Size = new System.Drawing.Size(40, 21);
            this.rowBox.TabIndex = 3;
            this.rowBox.Text = "20";
            this.rowBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intBox_KeyPress);
            // 
            // columnBox
            // 
            this.columnBox.Location = new System.Drawing.Point(109, 18);
            this.columnBox.MaxLength = 3;
            this.columnBox.Name = "columnBox";
            this.columnBox.Size = new System.Drawing.Size(40, 21);
            this.columnBox.TabIndex = 4;
            this.columnBox.Text = "20";
            this.columnBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "行";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "列";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(607, 486);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(635, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.columnBox);
            this.Controls.Add(this.rowBox);
            this.Controls.Add(this.mazePanel);
            this.Controls.Add(this.pathfindBtn);
            this.Controls.Add(this.createBtn);
            this.Name = "Form1";
            this.Text = "迷宫生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mazePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button pathfindBtn;
        private System.Windows.Forms.Panel mazePanel;
        private System.Windows.Forms.TextBox rowBox;
        private System.Windows.Forms.TextBox columnBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

