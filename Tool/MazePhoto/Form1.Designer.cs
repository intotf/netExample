
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.createBtn = new System.Windows.Forms.Button();
            this.pathfindBtn = new System.Windows.Forms.Button();
            this.rowBox = new System.Windows.Forms.TextBox();
            this.columnBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printBtn = new System.Windows.Forms.Button();
            this.mazePanel = new System.Windows.Forms.Panel();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.saveBtn);
            this.splitContainer1.Panel1.Controls.Add(this.printBtn);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mazePanel);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(614, 666);
            this.splitContainer1.SplitterIncrement = 256;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 7;
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(179, 14);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 0;
            this.createBtn.Text = "创建迷宫";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // pathfindBtn
            // 
            this.pathfindBtn.Location = new System.Drawing.Point(279, 14);
            this.pathfindBtn.Name = "pathfindBtn";
            this.pathfindBtn.Size = new System.Drawing.Size(75, 23);
            this.pathfindBtn.TabIndex = 1;
            this.pathfindBtn.Text = "自动寻路";
            this.pathfindBtn.UseVisualStyleBackColor = true;
            this.pathfindBtn.Click += new System.EventHandler(this.pathfindBtn_Click);
            // 
            // rowBox
            // 
            this.rowBox.Location = new System.Drawing.Point(33, 15);
            this.rowBox.MaxLength = 3;
            this.rowBox.Name = "rowBox";
            this.rowBox.Size = new System.Drawing.Size(40, 21);
            this.rowBox.TabIndex = 3;
            this.rowBox.Text = "20";
            this.rowBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intBox_KeyPress);
            // 
            // columnBox
            // 
            this.columnBox.Location = new System.Drawing.Point(109, 15);
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
            this.label1.Location = new System.Drawing.Point(12, 19);
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
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(376, 15);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 0;
            this.printBtn.Text = "打   印";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // mazePanel
            // 
            this.mazePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazePanel.Location = new System.Drawing.Point(5, 5);
            this.mazePanel.Name = "mazePanel";
            this.mazePanel.Size = new System.Drawing.Size(604, 605);
            this.mazePanel.TabIndex = 0;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            this.pageSetupDialog1.EnableMetric = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(473, 14);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "保存为图片";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(614, 666);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.columnBox);
            this.Controls.Add(this.rowBox);
            this.Controls.Add(this.pathfindBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "迷宫生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button pathfindBtn;
        private System.Windows.Forms.TextBox rowBox;
        private System.Windows.Forms.TextBox columnBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Panel mazePanel;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button saveBtn;
    }
}

