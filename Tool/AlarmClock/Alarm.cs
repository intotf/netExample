using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    /// <summary>
    /// 响铃提示窗口
    /// </summary>
    public partial class Alarm : Form
    {

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果


        private Point mPoint;

        /// <summary>
        /// 闹钟信息
        /// </summary>
        private readonly Clock _Clock;

        /// <summary>
        /// 定时器
        /// </summary>
        private System.Threading.Timer timer;

        /// <summary>
        /// 响铃提示窗口
        /// </summary>
        /// <param name="clock"></param>
        public Alarm(Clock clock) :
            base()
        {
            if (clock == null)
            {
                this.Close();
                return;
            }
            _Clock = clock;
            InitializeComponent();
            this.Load += Alarm_Load;
        }

        /// <summary>
        /// 窗口加载后定时关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Alarm_Load(object sender, EventArgs e)
        {
            this.TopMost = Program.topMost;
            cbTopMost.Checked = Program.topMost;
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);

            this.lbTime.Text = _Clock.RingTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (_Clock.IsCycle)
            {
                this.lbTime.Text = "下次提醒时间:" + DateTime.Now.AddSeconds(_Clock.IntervalSpan).ToString("yyyy-MM-dd HH:mm:ss");
            }

            this.alarmManage.Text = _Clock.Note;
            this.timer = new System.Threading.Timer(CloseForm, null, TimeSpan.FromSeconds(Program.AlarmShowTime), Timeout.InfiniteTimeSpan);
        }

        /// <summary>
        /// 定时关闭窗口
        /// </summary>
        private delegate void CloseAction();
        private void CloseForm(object state)
        {
            Invoke(new CloseAction(this.Close));
        }

        private void Alarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.timer.Dispose();
            this.Close();
        }

        private void cbTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = cbTopMost.Checked;
            Program.topMost = cbTopMost.Checked;
        }
    }
}
