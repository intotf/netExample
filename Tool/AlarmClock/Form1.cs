using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var data = new List<Clock>();
            for (var i = 0; i < 5; i++)
            {
                var id = Guid.NewGuid().ToString();
                data.Add(new Clock(
                     DateTime.Now.AddSeconds((i + 1) * 5),
                     id,
                     Ring
                    ));
            }

            this.dataGrid.DataSource = (from s in data
                                        select new
                                        {
                                            time = s.RingTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                            id = s.Id
                                        }).ToList();
            dataGrid.Columns[0].Width = 150;
            dataGrid.Columns[0].HeaderCell.Value = "提醒时间";
        }

        private void dataGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void Ring(string id)
        {
            for (int i = 0; i <= dataGrid.Rows.Count - 1; i++)
            {
                var rowId = dataGrid.Rows[i].Cells["id"].Value.ToString();
                if (id == rowId)
                {
                    var list = (IList)dataGrid.DataSource;
                    list.RemoveAt(dataGrid.CurrentRow.Index);
                    dataGrid.DataSource = null;
                    dataGrid.DataSource = list;
                }
            }
        }
    }

    /// <summary>
    /// 闹钟
    /// </summary>
    public class Clock
    {

        /// <summary>
        /// 定时器
        /// </summary>
        private System.Threading.Timer timer;

        /// <summary>
        /// 响铃时间
        /// </summary>
        public DateTime RingTime { get; set; }

        public string Id { get; set; }

        private Action<string> CallBackAction { get; set; }

        /// <summary>
        /// 响铃时间
        /// </summary>
        /// <param name="ringTime"></param>
        public Clock(DateTime ringTime, string id, Action<string> action)
        {
            this.Id = id;
            this.CallBackAction = action;
            this.RingTime = ringTime;
            var spanTime = ringTime.Subtract(DateTime.Now);
            if (spanTime.Milliseconds > 0)
            {
                this.timer = new System.Threading.Timer(TimerCallBack, null, spanTime, Timeout.InfiniteTimeSpan);
            }
        }

        public void TimerCallBack(object state)
        {
            this.timer.Dispose();
            this.CallBackAction.Invoke(this.Id);
            Console.WriteLine(DateTime.Now);
        }
    }
}
