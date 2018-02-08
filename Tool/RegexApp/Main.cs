using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexApp
{
    public partial class Main : Form
    {
        /// <summary>
        /// 获取正则标准
        /// </summary>
        private IEnumerable<RegexModel> RegexList = XmlHelper.GetList<RegexModel>();

        /// <summary>
        /// 获取常用的正则
        /// </summary>
        private IEnumerable<CommonModel> CommonList = XmlHelper.GetList<CommonModel>();

        /// <summary>
        /// 文本路径
        /// </summary>
        private readonly string textPath = @"data\text.txt";

        public Main()
        {
            InitializeComponent();
            this.Load += Main_Load;
        }

        /// <summary>
        /// 初始化页面内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Main_Load(object sender, EventArgs e)
        {
            this.cbRegex.DataSource = RegexList.ToArray();
            this.cbRegex.DisplayMember = "CharTxt";
            if (RegexList.Count() > 0)
            {
                this.cbRegex.SelectedIndex = RegexList.Count() > 0 ? 0 : -1;
                this.rtbRegex.Text = RegexList.FirstOrDefault().Describe;
            }

            this.cbCommon.DataSource = CommonList.ToArray();
            this.cbCommon.DisplayMember = "Describe";
            if (CommonList.Count() > 0)
            {
                this.cbCommon.SelectedIndex = CommonList.Count() > 0 ? 0 : -1;
            }

            if (File.Exists(textPath))
            {
                this.tbText.Text = File.ReadAllText(textPath);
            }
        }

        /// <summary>
        /// 选择正则显示描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRegex_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = (RegexModel)((ComboBox)sender).SelectedItem;
            this.rtbRegex.Text = model.Describe;
        }

        /// <summary>
        /// 保存正则学习备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveRegex_Click(object sender, EventArgs e)
        {
            var model = (RegexModel)this.cbRegex.SelectedItem;
            var newList = RegexList.ToList();
            for (int i = 0; i < newList.Count(); i++)
            {
                if (newList[i].CharTxt.Equals(model.CharTxt, StringComparison.Ordinal))
                {
                    newList[i].Describe = this.rtbRegex.Text;
                }
            }
            XmlHelper.Save<RegexModel>(newList);
            MessageBox.Show("保存成功.");
        }

        /// <summary>
        /// 缩放窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbZoom_Click(object sender, EventArgs e)
        {
            if (this.Width > 700)
            {
                this.Width = 540;
                this.lbZoom.Text = ">";
            }
            else
            {
                this.Width = 781;
                this.lbZoom.Text = "<";
            }
        }

        /// <summary>
        /// 输出匹配结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbRegex_TextChanged(object sender, EventArgs e)
        {
            var text = this.tbText.Text;
            var regText = this.tbRegex.Text;
            try
            {
                var result = new List<ResultModel>();
                if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(regText))
                {
                    var reg = new Regex(regText);
                    var matches = reg.Matches(text);
                    var i = 0;
                    foreach (Match item in matches)
                    {
                        result.Add(new ResultModel(++i, item.Value));
                    }
                }
                this.dgvResult.DataSource = result.ToArray();
                this.geResult.Text = string.Format("结果({0})", result.Count());
            }
            catch
            {
                this.geResult.Text = "结果(0)";
                var defaultList = new ResultModel[1] { new ResultModel(0, regText) };
                this.dgvResult.DataSource = defaultList;
            }
        }

        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveCommon_Click(object sender, EventArgs e)
        {
            var describe = this.cbCommon.Text;
            var regexTxt = this.tbRegex.Text;
            if (string.IsNullOrEmpty(describe) || string.IsNullOrEmpty(regexTxt))
            {
                MessageBox.Show("正则或内容不能为空");
                return;
            }
            var newList = CommonList.ToList();
            if (newList.Count(item => item.Describe == describe) > 0)
            {
                for (int i = 0; i < newList.Count(); i++)
                {
                    if (newList[i].Describe.Equals(describe, StringComparison.Ordinal))
                    {
                        newList[i].Describe = describe;
                        newList[i].RegexTxt = regexTxt;
                    }
                }
            }
            else
            {
                newList.Add(new CommonModel() { RegexTxt = regexTxt, Describe = describe });
            }
            //this.cbCommon.Items.Clear();
            this.cbCommon.DataSource = newList.ToArray();
            this.cbCommon.DisplayMember = "Describe";
            CommonList = newList;
            XmlHelper.Save<CommonModel>(newList);
            MessageBox.Show("保存成功.");
        }

        /// <summary>
        /// 删除指定常规正则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteCommon_Click(object sender, EventArgs e)
        {
            var describe = this.cbCommon.Text;
            if (CommonList.Count(item => item.Describe == describe) <= 0)
            {
                MessageBox.Show("删除失败");
                return;
            }
            var newList = new List<CommonModel>();
            foreach (var item in CommonList)
            {
                if (!item.Describe.Equals(describe, StringComparison.Ordinal))
                {
                    newList.Add(new CommonModel() { Describe = item.Describe, RegexTxt = item.RegexTxt });
                }
            }
            this.cbCommon.DataSource = newList.ToArray();
            this.cbCommon.DisplayMember = "Describe";
            CommonList = newList;
            XmlHelper.Save<CommonModel>(newList);

            MessageBox.Show("保存成功.");
        }

        /// <summary>
        /// 常规正则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCommon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = (CommonModel)((ComboBox)sender).SelectedItem;
            this.tbRegex.Text = model.RegexTxt;
        }

        /// <summary>
        /// 保存文本区内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveText_Click(object sender, EventArgs e)
        {
            File.WriteAllText(textPath, this.tbText.Text, Encoding.UTF8);
            MessageBox.Show("保存文本内容成功.");
        }
    }
}
