using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// object 缓存
        /// ConcurrentDictionary 线程缓存，只要程序进程存在缓存就会一直存在。
        /// </summary>
        private ConcurrentDictionary<string, Clock> ClockCaches = new ConcurrentDictionary<string, Clock>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var datas = XmlHelper.GetList<Clock>();
            foreach (var item in datas.Where(item => item.RingTime > DateTime.Now || item.IsCycle))
            {
                var model = new Clock(TimeSpan.FromSeconds(item.IntervalSpan), Ring, item.IsCycle, item.Note);
                ClockCaches.AddOrUpdate(model.Id, model, (k, m) => model);
            }
            BindDataSource();
            this.cbHours.DataSource = Enumerable.Range(0, 24).ToArray();
            this.cbHours.SelectedIndex = 0;
            this.cbSeconds.DataSource = Enumerable.Range(0, 60).ToArray();
            this.cbSeconds.SelectedIndex = 0;
            this.cbMinutes.DataSource = Enumerable.Range(0, 60).ToArray();
            this.cbMinutes.SelectedIndex = 0;
            this.tabPageFast.Controls.AddRange(GetButtons());
            if (Program.AlarmShowTime > 0)
            {
                NotShowToolStripMenuItem.Text = "√ 闹钟提示";
            }
        }

        private Button[] GetButtons()
        {
            var listButtons = new List<Button>();
            int x = 80;//起始位置的坐标的x的值
            int y = 41;//起始位置的坐标的y的值
            var addNum = new int[] { 1, 5, 10, 20, 30 };
            var size = new Size(58, 23);
            var interval = 5;
            foreach (var num in addNum)
            {
                var buttons = new Button(); //声明一个button
                //样式设计
                buttons.BackColor = System.Drawing.Color.Transparent;
                buttons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                buttons.Cursor = Cursors.Hand;
                buttons.Name = string.Format("btn{0}{1}", x, y);    //button的命名
                buttons.Location = new System.Drawing.Point(x, y);  //button起始位置的坐标
                buttons.Size = size;   //button的长度和宽度
                buttons.Text = "+" + num + "分钟";//button中text所显示的内容
                buttons.Click += Buttons_Click; ;//添加点击事件
                buttons.Tag = num;
                listButtons.Add(buttons);
                x += interval + size.Width;//每装载下一个button使其x坐标增加40
            }
            return listButtons.ToArray();
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            SetCbTime(int.Parse(btn.Tag.ToString()));
        }

        /// <summary>
        /// 增加分钟数
        /// </summary>
        /// <param name="minutes">分钟数</param>
        private void SetCbTime(int minutes)
        {
            var setTime = GetCbTime();
            setTime = setTime.AddMinutes(minutes);
            var tp = (setTime - DateTime.Now);
            if (tp.Days > 0)
            {
                this.cbHours.SelectedIndex = 23;
                this.cbMinutes.SelectedIndex = 59;
                return;
            }
            this.cbHours.SelectedIndex = tp.Hours > 0 ? tp.Hours : 0;
            this.cbMinutes.SelectedIndex = tp.Minutes > 0 ? tp.Minutes : 0;
        }

        /// <summary>
        /// 获取设置的时间
        /// </summary>
        /// <returns></returns>
        private DateTime GetCbTime()
        {
            return DateTime.Now
                    .AddHours(int.Parse(this.cbHours.SelectedItem.ToString()))
                    .AddMinutes(int.Parse(this.cbMinutes.SelectedItem.ToString()))
                    .AddSeconds(int.Parse(this.cbSeconds.SelectedItem.ToString()));
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataSource()
        {
            this.dataGrid.Rows.Clear();
            this.dataGrid.DataSource = new BindingList<GridMode>(ClockCaches.Select(item => new GridMode
            {
                Id = item.Value.Id,
                RingTime = item.Value.RingTime,
                Note = item.Value.Note
            }).OrderBy(item => item.RingTime).ToList());
        }

        /// <summary>
        /// 增加DataGriDView 序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }


        /// <summary>
        /// 响应提不回调
        /// </summary>
        /// <param name="id"></param>
        private void Ring(string id)
        {
            var newAct = new Action<string>(RemoveClock);
            Invoke(newAct, id);
        }

        /// <summary>
        /// 删除闹钟
        /// </summary>
        /// <param name="id">闹钟Id</param>
        /// <param name="isCycle">是否按原闹钟重复</param>
        private void RemoveClock(string id)
        {
            try
            {
                if (ClockCaches.TryRemove(id, out var clock))
                {
                    clock.Dispose();
                    if (clock.IsCycle)
                    {
                        var model = new Clock(TimeSpan.FromSeconds(clock.IntervalSpan), clock.CallBackAction, true, clock.Note);
                        ClockCaches.AddOrUpdate(model.Id, model, (k, m) => model);
                    }
                }
                BindDataSource();
                if (Program.AlarmShowTime > 0)
                {
                    try
                    {
                        var clockWindow = new Alarm(clock);
                        if (clockWindow != null)
                        {
                            clockWindow.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("RemoveAlarmWindow" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("RemoveClock" + ex.Message);
            }
        }

        /// <summary>
        /// 添加或更新闹钟
        /// </summary>
        /// <param name="input"></param>
        private void AddOrUpdateClock(Clock input)
        {
            try
            {
                ClockCaches.AddOrUpdate(input.Id, input, (k, m) => input);
                BindDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddOrUpdateClock" + ex.Message);
            }
        }

        /// <summary>
        /// 按日期时间添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("选择的时间已过期");
                return;
            }
            AddOrUpdateClock(new Clock(this.dateTimePicker1.Value, Ring, false, this.tbNote.Text));
        }

        /// <summary>
        /// 快捷闹钟添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var alarmTime = GetCbTime();
            if (alarmTime <= DateTime.Now)
            {
                MessageBox.Show("请设置倒计时");
                return;
            }

            var isCycle = this.cbCycle.Checked;
            var clock = new Clock(GetCbTime(), Ring, isCycle, this.tbFaseNote.Text);
            AddOrUpdateClock(clock);
        }


        /// <summary>
        /// 系统栏图标双击显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// 窗口关闭只隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// 系统栏右键菜单-显示主窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示定时任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// 系统栏右键菜单-退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NotShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.AlarmShowTime > 0)
            {
                Program.AlarmShowTime = 0;
                NotShowToolStripMenuItem.Text = "√ 闹钟提示";
            }
            else
            {
                Program.AlarmShowTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["AlarmShowTime"]);
                NotShowToolStripMenuItem.Text = "× 闹钟提示";
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlHelper.Save<Clock>(ClockCaches.Select(item => item.Value));
            MessageBox.Show("保存成功");
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)//按钮列坐标
            {
                string id = this.dataGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                ClockCaches.TryRemove(id, out var clock);
                clock.Dispose();

                this.dataGrid.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
