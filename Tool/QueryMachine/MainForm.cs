using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QueryMachine
{
    public partial class MainForm : BastForm
    {
        private HashSet<SearchModel> SeachList = new HashSet<SearchModel>(new SearchModel());
        private static readonly string[] AreaKey = ConfigurationManager.AppSettings["AreaKey"].ToString().Split(',');
        private static readonly string[] Keyboard = ConfigurationManager.AppSettings["Keyboard"].ToString().Split(',');
        private static readonly int ExceedMinutes = int.Parse(ConfigurationManager.AppSettings["ExceedMinutes"]);
        private static readonly int CostHour = int.Parse(ConfigurationManager.AppSettings["CostHour"]);
        private static Point imgPoint = new Point(0, 0);

        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            imgPoint = this.imgCur.Location;
            //获取系统分辨率
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            if (SH > 768 || SW > 1024)
            {
                this.WindowState = FormWindowState.Normal;
                this.pictureBox3.MouseMove += pictureBox3_MouseMove;
                this.pictureBox3.MouseUp += pictureBox3_MouseUp;
                this.pictureBox3.MouseDown += pictureBox3_MouseDown;
                this.pictureBox3.Cursor = Cursors.Hand;
            }
        }



        /// <summary>
        /// 设置地区文本框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTbArea_Click(object sender, EventArgs e)
        {
            var but = (Button)sender;
            this.lbArea.Text = but.Text;
            this.tbNo.Text = string.Empty;
            lodingKeyboard_MouseClick(null, null);
        }


        /// <summary>
        /// 设置车牌文本框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTbCarNo_Click(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var carNo = this.tbNo.Text;
            if (carNo.Length < 6)
            {
                this.tbNo.Text = carNo + but.Text;
            }
        }

        private void btBackspace_Click(object sender, EventArgs e)
        {
            var carNo = this.tbNo.Text;
            if (carNo.Length > 0)
            {
                this.tbNo.Text = carNo.Substring(0, carNo.Length - 1);
            }
            this.panelSeach.Visible = false;
        }


        private IEnumerable<Button> KeyButtons;
        private Panel keyPanel;
        private IEnumerable<Button> areaButtons;
        private Panel areaPanel;

        /// <summary>
        /// 加载全键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lodingKeyboard_MouseClick(object sender, EventArgs e)
        {
            if (keyPanel == null)
            {
                keyPanel = new Panel
                {
                    Width = panJP.Width,
                    Height = panJP.Height,
                    Location = panJP.Location,
                    BorderStyle = panJP.BorderStyle,
                    BackColor = panJP.BackColor,
                    Padding = panJP.Padding,
                    Visible = true
                };

                if (KeyButtons == null)
                {
                    KeyButtons = base.GetButtons(Keyboard, new Size(113, 87), keyPanel.Width, 0, new EventHandler(setTbCarNo_Click));
                }
                foreach (var item in KeyButtons)
                {
                    keyPanel.Controls.Add(item);
                }
                this.Controls.Add(keyPanel);
            }
            this.panelSeach.Visible = false;
            keyPanel.Visible = true;
            if (areaPanel != null)
            {
                areaPanel.Visible = false;
            }
        }

        /// <summary>
        /// 加载地区键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lodingAreaKey_TextChanged(object sender, EventArgs e)
        {
            if (areaPanel == null)
            {
                areaPanel = new Panel
                {
                    Width = panJP.Width,
                    Height = panJP.Height,
                    Location = panJP.Location,
                    BorderStyle = panJP.BorderStyle,
                    BackColor = panJP.BackColor,
                    Padding = panJP.Padding
                };

                if (areaButtons == null)
                {
                    areaButtons = base.GetButtons(AreaKey, new Size(113, 87), areaPanel.Width, 0, new EventHandler(setTbArea_Click));
                }
                foreach (var item in areaButtons)
                {
                    areaPanel.Controls.Add(item);
                }
                this.Controls.Add(areaPanel);
            }
            this.panelSeach.Visible = false;
            areaPanel.Visible = true;
            if (keyPanel != null)
            {
                keyPanel.Visible = false;
            }
        }

        /// <summary>
        /// 查询车牌号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeach_Click(object sender, EventArgs e)
        {
            var Reg = new Regex(@"^[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$");
            if (!Reg.IsMatch(this.tbNo.Text))
            {
                MessageBox.Show("车牌号输入有误,第位必需为字母.");
                return;
            }

            keyPanel.Visible = false;
            panelSeach.Visible = true;
            var carNo = this.lbArea.Text + this.tbNo.Text;
            this.lbCarNo.Text = carNo;
            var randTime = GetRandom();
            var inTime = DateTime.Now.AddMinutes(-randTime);
            SeachList.Add(new SearchModel(carNo, inTime));
            var model = SeachList.Where(item => item.carNo == carNo).FirstOrDefault();

            var timeNow = DateTime.Now;
            var timeSpan = timeNow.Subtract(model.inTime);
            var stopHours = timeSpan.Minutes > 15 ? timeSpan.Hours + 1 : timeSpan.Hours;
            this.lbStopTime.Text = string.Format("{0} 小时 {1} 分钟", timeSpan.Hours, timeSpan.Minutes);
            this.lbMoney.Text = (CostHour * stopHours).ToString();
            this.lbInTime.Text = model.inTime.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// 获取随机数在库分钟数
        /// </summary>
        /// <returns></returns>
        private int GetRandom()
        {
            Random ro = new Random();
            return ro.Next(1, 200);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void tbNo_TextChanged(object sender, EventArgs e)
        {
            Func<int, string> getTbNo = (i) =>
            {
                return this.tbNo.Text.Length > i ? this.tbNo.Text[i].ToString() : string.Empty;
            };

            this.lbNum1.Text = getTbNo(0);
            this.lbNum2.Text = getTbNo(1);
            this.lbNum3.Text = getTbNo(2);
            this.lbNum4.Text = getTbNo(3);
            this.lbNum5.Text = getTbNo(4);
            this.lbNum6.Text = getTbNo(5);

            var addY = 0;
            if (this.tbNo.Text.Length == 6)
            {
                this.imgCur.Visible = false;
            }
            else
            {
                this.imgCur.Visible = true;
                addY = this.tbNo.Text.Length * 83;
            }
            var imgNewPoint = new Point(imgPoint.X + addY, imgPoint.Y);
            this.imgCur.Location = imgNewPoint;
        }

        private string GetTbNo(int i)
        {
            return this.tbNo.Text.Length > i ? this.tbNo.Text[i].ToString() : string.Empty;
        }


        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void lbArea_MouseDown(object sender, MouseEventArgs e)
        {
            this.panelSeach.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.panelSeach.Hide();
        }
    }
}
