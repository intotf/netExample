namespace RegexApp
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btSaveCommon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCommon = new System.Windows.Forms.ComboBox();
            this.tbRegex = new System.Windows.Forms.TextBox();
            this.geResult = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbRegex = new System.Windows.Forms.ComboBox();
            this.btSaveRegex = new System.Windows.Forms.Button();
            this.rtbRegex = new System.Windows.Forms.RichTextBox();
            this.lbZoom = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btDeleteCommon = new System.Windows.Forms.Button();
            this.btSaveText = new System.Windows.Forms.Button();
            this.cbIsCase = new System.Windows.Forms.CheckBox();
            this.cbIsMultiple = new System.Windows.Forms.CheckBox();
            this.cbIsSingle = new System.Windows.Forms.CheckBox();
            this.cbIsAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.geResult.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIsAll);
            this.groupBox1.Controls.Add(this.cbIsMultiple);
            this.groupBox1.Controls.Add(this.cbIsSingle);
            this.groupBox1.Controls.Add(this.cbIsCase);
            this.groupBox1.Controls.Add(this.btSaveText);
            this.groupBox1.Controls.Add(this.tbText);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文本内容区";
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(6, 20);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbText.Size = new System.Drawing.Size(483, 142);
            this.tbText.TabIndex = 0;
            this.tbText.TextChanged += new System.EventHandler(this.tbRegex_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btDeleteCommon);
            this.groupBox2.Controls.Add(this.btSaveCommon);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbCommon);
            this.groupBox2.Controls.Add(this.tbRegex);
            this.groupBox2.Location = new System.Drawing.Point(12, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "正则表达式";
            // 
            // btSaveCommon
            // 
            this.btSaveCommon.Location = new System.Drawing.Point(360, 22);
            this.btSaveCommon.Name = "btSaveCommon";
            this.btSaveCommon.Size = new System.Drawing.Size(71, 23);
            this.btSaveCommon.TabIndex = 4;
            this.btSaveCommon.Text = "保存/添加";
            this.btSaveCommon.UseVisualStyleBackColor = true;
            this.btSaveCommon.Click += new System.EventHandler(this.btSaveCommon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "正则内容：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "常用规则：";
            // 
            // cbCommon
            // 
            this.cbCommon.FormattingEnabled = true;
            this.cbCommon.Items.AddRange(new object[] {
            "1.",
            "2",
            "3",
            "4"});
            this.cbCommon.Location = new System.Drawing.Point(75, 24);
            this.cbCommon.Name = "cbCommon";
            this.cbCommon.Size = new System.Drawing.Size(274, 20);
            this.cbCommon.TabIndex = 1;
            this.cbCommon.SelectedIndexChanged += new System.EventHandler(this.cbCommon_SelectedIndexChanged);
            // 
            // tbRegex
            // 
            this.tbRegex.Location = new System.Drawing.Point(75, 50);
            this.tbRegex.Name = "tbRegex";
            this.tbRegex.Size = new System.Drawing.Size(414, 21);
            this.tbRegex.TabIndex = 0;
            this.tbRegex.TextChanged += new System.EventHandler(this.tbRegex_TextChanged);
            // 
            // geResult
            // 
            this.geResult.Controls.Add(this.dgvResult);
            this.geResult.Location = new System.Drawing.Point(12, 301);
            this.geResult.Name = "geResult";
            this.geResult.Size = new System.Drawing.Size(495, 172);
            this.geResult.TabIndex = 3;
            this.geResult.TabStop = false;
            this.geResult.Text = "结果";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbRegex);
            this.groupBox4.Controls.Add(this.btSaveRegex);
            this.groupBox4.Controls.Add(this.rtbRegex);
            this.groupBox4.Location = new System.Drawing.Point(525, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 428);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "正则说明";
            // 
            // cbRegex
            // 
            this.cbRegex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegex.FormattingEnabled = true;
            this.cbRegex.Items.AddRange(new object[] {
            "1.",
            "2",
            "3",
            "4"});
            this.cbRegex.Location = new System.Drawing.Point(7, 20);
            this.cbRegex.Name = "cbRegex";
            this.cbRegex.Size = new System.Drawing.Size(215, 20);
            this.cbRegex.TabIndex = 2;
            this.cbRegex.SelectedIndexChanged += new System.EventHandler(this.cbRegex_SelectedIndexChanged);
            // 
            // btSaveRegex
            // 
            this.btSaveRegex.Location = new System.Drawing.Point(147, 399);
            this.btSaveRegex.Name = "btSaveRegex";
            this.btSaveRegex.Size = new System.Drawing.Size(75, 23);
            this.btSaveRegex.TabIndex = 1;
            this.btSaveRegex.Text = "保存说明";
            this.btSaveRegex.UseVisualStyleBackColor = true;
            this.btSaveRegex.Click += new System.EventHandler(this.btSaveRegex_Click);
            // 
            // rtbRegex
            // 
            this.rtbRegex.Location = new System.Drawing.Point(7, 53);
            this.rtbRegex.Name = "rtbRegex";
            this.rtbRegex.Size = new System.Drawing.Size(215, 341);
            this.rtbRegex.TabIndex = 0;
            this.rtbRegex.Text = "";
            // 
            // lbZoom
            // 
            this.lbZoom.BackColor = System.Drawing.Color.Linen;
            this.lbZoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbZoom.Font = new System.Drawing.Font("微软雅黑", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbZoom.ForeColor = System.Drawing.Color.Black;
            this.lbZoom.Location = new System.Drawing.Point(513, 0);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(7, 452);
            this.lbZoom.TabIndex = 6;
            this.lbZoom.Text = ">";
            this.lbZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbZoom.Click += new System.EventHandler(this.lbZoom_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.Location = new System.Drawing.Point(9, 16);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(480, 150);
            this.dgvResult.TabIndex = 0;
            // 
            // btDeleteCommon
            // 
            this.btDeleteCommon.Location = new System.Drawing.Point(437, 21);
            this.btDeleteCommon.Name = "btDeleteCommon";
            this.btDeleteCommon.Size = new System.Drawing.Size(52, 23);
            this.btDeleteCommon.TabIndex = 5;
            this.btDeleteCommon.Text = "删除";
            this.btDeleteCommon.UseVisualStyleBackColor = true;
            this.btDeleteCommon.Click += new System.EventHandler(this.btDeleteCommon_Click);
            // 
            // btSaveText
            // 
            this.btSaveText.Location = new System.Drawing.Point(420, 168);
            this.btSaveText.Name = "btSaveText";
            this.btSaveText.Size = new System.Drawing.Size(69, 23);
            this.btSaveText.TabIndex = 1;
            this.btSaveText.Text = "保存文本";
            this.btSaveText.UseVisualStyleBackColor = true;
            this.btSaveText.Click += new System.EventHandler(this.btSaveText_Click);
            // 
            // cbIsCase
            // 
            this.cbIsCase.AutoSize = true;
            this.cbIsCase.Checked = true;
            this.cbIsCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsCase.Location = new System.Drawing.Point(71, 173);
            this.cbIsCase.Name = "cbIsCase";
            this.cbIsCase.Size = new System.Drawing.Size(96, 16);
            this.cbIsCase.TabIndex = 2;
            this.cbIsCase.Text = "不区分大小写";
            this.cbIsCase.UseVisualStyleBackColor = true;
            // 
            // cbIsMultiple
            // 
            this.cbIsMultiple.AutoSize = true;
            this.cbIsMultiple.Location = new System.Drawing.Point(181, 173);
            this.cbIsMultiple.Name = "cbIsMultiple";
            this.cbIsMultiple.Size = new System.Drawing.Size(48, 16);
            this.cbIsMultiple.TabIndex = 3;
            this.cbIsMultiple.Text = "多行";
            this.cbIsMultiple.UseVisualStyleBackColor = true;
            // 
            // cbIsSingle
            // 
            this.cbIsSingle.AutoSize = true;
            this.cbIsSingle.Location = new System.Drawing.Point(243, 173);
            this.cbIsSingle.Name = "cbIsSingle";
            this.cbIsSingle.Size = new System.Drawing.Size(48, 16);
            this.cbIsSingle.TabIndex = 3;
            this.cbIsSingle.Text = "单行";
            this.cbIsSingle.UseVisualStyleBackColor = true;
            // 
            // cbIsAll
            // 
            this.cbIsAll.AutoSize = true;
            this.cbIsAll.Checked = true;
            this.cbIsAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsAll.Location = new System.Drawing.Point(9, 173);
            this.cbIsAll.Name = "cbIsAll";
            this.cbIsAll.Size = new System.Drawing.Size(48, 16);
            this.cbIsAll.TabIndex = 4;
            this.cbIsAll.Text = "全部";
            this.cbIsAll.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(765, 481);
            this.Controls.Add(this.lbZoom);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.geResult);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "正则表达式学习 QQ:42309073";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.geResult.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox geResult;
        private System.Windows.Forms.TextBox tbRegex;
        private System.Windows.Forms.ComboBox cbCommon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtbRegex;
        private System.Windows.Forms.Button btSaveRegex;
        private System.Windows.Forms.ComboBox cbRegex;
        private System.Windows.Forms.Button btSaveCommon;
        private System.Windows.Forms.Label lbZoom;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btDeleteCommon;
        private System.Windows.Forms.Button btSaveText;
        private System.Windows.Forms.CheckBox cbIsCase;
        private System.Windows.Forms.CheckBox cbIsMultiple;
        private System.Windows.Forms.CheckBox cbIsSingle;
        private System.Windows.Forms.CheckBox cbIsAll;
    }
}

