using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryMachine
{
    public partial class BastForm : Form
    {
        /// <summary>
        /// 向指定 Panel 对象中增中多按钮
        /// </summary>
        /// <param name="keys">按钮名称列表</param>
        /// <param name="panel">Panel 对象</param>
        /// <param name="size">按钮大小</param>
        /// <param name="interval">间隙</param>
        public void Openkeyboard(IEnumerable<string> keys, Panel panel, Size size, int interval, EventHandler eh)
        {
            int x = 0;//起始位置的坐标的x的值
            int y = 0;//起始位置的坐标的y的值
            foreach (var item in keys)
            {
                AddButton(x, y, item, panel, size, eh); //x,y是声明button起始位置的坐标i是button动态添加数量for的i值
                x += interval + size.Width;//每装载下一个button使其x坐标增加40
                if ((x + interval + size.Width) > panel.Width) //当窗体控件不足够容纳其button的时候使其换行
                {
                    y += interval + size.Height;//使其y坐标+40
                    x = 0;//使其x+坐标赋值为0
                }
            }
        }

        /// <summary>
        /// 增加按钮
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="val"></param>
        /// <param name="panel"></param>
        /// <param name="size"></param>
        private void AddButton(int x, int y, string val, Panel panel, Size size, EventHandler eh)
        {
            var buttons = new Button(); //声明一个button
            //样式设计
            buttons.BackColor = System.Drawing.Color.Transparent;
            buttons.BackgroundImage = global::QueryMachine.Properties.Resources.keystroke;
            buttons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttons.FlatAppearance.BorderSize = 0;
            buttons.FlatStyle = FlatStyle.Flat;
            buttons.ForeColor = Color.Black;
            buttons.Cursor = Cursors.Hand;
            buttons.Font = new System.Drawing.Font("微软雅黑", size.Height / 5F);
            buttons.Name = string.Format("btn{0}{1}", x, y);    //button的命名
            buttons.Location = new System.Drawing.Point(x, y);  //button起始位置的坐标
            buttons.Size = size;//button的长度和宽度
            buttons.Text = val;//button中text所显示的内容
            buttons.Click += eh;//添加点击事件
            buttons.MouseHover += buttons_MouseHover;
            buttons.MouseLeave += buttons_MouseLeave;
            panel.Controls.Add(buttons);//添加button控件
        }

        /// <summary>
        /// 向指定 Panel 对象中增中多按钮
        /// </summary>
        /// <param name="keys">按钮名称列表</param>
        /// <param name="panel">Panel 对象</param>
        /// <param name="size">按钮大小</param>
        /// <param name="interval">间隙</param>
        /// <param name="eh">按钮事件</param>
        public IEnumerable<Button> GetButtons(IEnumerable<string> keys, Size size, int maxWidth, int interval, EventHandler eh)
        {

            int x = 0;//起始位置的坐标的x的值
            int y = 0;//起始位置的坐标的y的值
            foreach (var item in keys)
            {
                //AddButton(x, y, item, panel, size, eh); //x,y是声明button起始位置的坐标i是button动态添加数量for的i值

                var buttons = new Button(); //声明一个button
                //样式设计
                buttons.BackColor = System.Drawing.Color.Transparent;
                buttons.BackgroundImage = global::QueryMachine.Properties.Resources.keystroke;
                buttons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                buttons.FlatAppearance.BorderSize = 0;
                buttons.FlatStyle = FlatStyle.Flat;
                buttons.ForeColor = Color.Black;
                buttons.Cursor = Cursors.Hand;
                buttons.Font = new System.Drawing.Font("微软雅黑", size.Height / 5F);
                buttons.Name = string.Format("btn{0}{1}", x, y);    //button的命名
                buttons.Location = new System.Drawing.Point(x, y);  //button起始位置的坐标
                buttons.Size = size;//button的长度和宽度
                buttons.Text = item;//button中text所显示的内容
                buttons.Click += eh;//添加点击事件
                buttons.MouseHover += buttons_MouseHover;
                buttons.MouseLeave += buttons_MouseLeave;
                yield return buttons;
                x += interval + size.Width;//每装载下一个button使其x坐标增加40
                if ((x + interval + size.Width) > maxWidth) //当窗体控件不足够容纳其button的时候使其换行
                {
                    y += interval + size.Height;//使其y坐标+40
                    x = 0;//使其x+坐标赋值为0
                }
            }
        }



        /// <summary>
        /// 鼠标离开后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttons_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = global::QueryMachine.Properties.Resources.keystroke;
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn.ForeColor = Color.Black;
        }

        /// <summary>
        /// 鼠标在上面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttons_MouseHover(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = global::QueryMachine.Properties.Resources.keystroke_press;
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn.ForeColor = Color.White;
            btn.BackColor = System.Drawing.Color.Transparent;
        }

    }
}
