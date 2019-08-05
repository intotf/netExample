﻿using Jiguang.JPush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    static class Program
    {
        public static int AlarmShowTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["AlarmShowTime"]);



        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("已有有一个在运行中", "提示信息");
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}
