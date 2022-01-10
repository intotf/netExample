using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MazePhoto
{
    public partial class Form1 : Form
    {
        private Random rand = new Random(); //随机数对象的实例化。不要再方法中实例化多个Random，原因见msdn
        private PictureBox[,] map;  //存放pictureBox，迷宫格子
        private int[,] numMap;  //保存迷宫格子的数字状态
        private int[,] path;    //保存寻路的数组
        private int pointX = 0; // 当前所在的位置-行，用于玩游戏时保存玩家所在的位置
        private int pointY = 0; // 当前所在的位置-列
        private List<Image> PathImageList = new List<Image>();  //橘黄色的背景图片
        private List<Image> ImageList = new List<Image>();      //白色背景的个图片
        private int width;    //迷宫的宽度-列数
        private int height;   //迷宫的高度-行数

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //白色图片
            ImageList.Add(global::MazePhoto.Properties.Resources._0);
            ImageList.Add(global::MazePhoto.Properties.Resources._1);
            ImageList.Add(global::MazePhoto.Properties.Resources._2);
            ImageList.Add(global::MazePhoto.Properties.Resources._3);
            ImageList.Add(global::MazePhoto.Properties.Resources._4);
            ImageList.Add(global::MazePhoto.Properties.Resources._5);
            ImageList.Add(global::MazePhoto.Properties.Resources._6);
            ImageList.Add(global::MazePhoto.Properties.Resources._7);
            ImageList.Add(global::MazePhoto.Properties.Resources._8);
            ImageList.Add(global::MazePhoto.Properties.Resources._9);
            ImageList.Add(global::MazePhoto.Properties.Resources._10);
            ImageList.Add(global::MazePhoto.Properties.Resources._11);
            ImageList.Add(global::MazePhoto.Properties.Resources._12);
            ImageList.Add(global::MazePhoto.Properties.Resources._13);
            ImageList.Add(global::MazePhoto.Properties.Resources._14);
            ImageList.Add(global::MazePhoto.Properties.Resources._15);
            //橘黄色背景的图片
            PathImageList.Add(global::MazePhoto.Properties.Resources.p0);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p1);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p2);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p3);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p4);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p5);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p6);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p7);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p8);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p9);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p10);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p11);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p12);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p13);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p14);
            PathImageList.Add(global::MazePhoto.Properties.Resources.p15);
        }

        /// <summary>
        /// 绘制pictureBox，数组数据初始化
        /// </summary>
        public void drawCheckerboar()
        {
            int currentPoint = 0;
            int chessLength = 30;
            int initX = 0;
            int initY = 0;
            int _x = initX;
            int _y = initY;
            for (int x = 0; x < height * width; x++)
            {
                if (currentPoint % width == 0)
                {
                    _x = initX;
                    _y = ((int)currentPoint / width) * chessLength + initY;
                }
                else
                {
                    _x += chessLength;
                }
                var tmpBox = new PictureBox();
                tmpBox.Left = _x;
                tmpBox.Top = _y;
                tmpBox.Width = chessLength;
                tmpBox.Height = chessLength;
                map[(int)currentPoint / width, currentPoint % width] = tmpBox;
                numMap[(int)currentPoint / width, currentPoint % width] = -1;   //-1表示未遍历过
                this.mazePanel.Controls.Add(tmpBox);
                tmpBox = null;
                currentPoint++;
            }
        }

        //创建迷宫状态数据
        private void CreateNumMap(int m, int n, int o)
        {
            List<int> directs = new List<int> { 0, 1, 2, 3 };   //存储未用的方向。0123分别表示上-右-下-左
            int last = 0;
            switch (o)
            {
                case 1:
                    last = 4;
                    break;
                case 2:
                    last = 8;
                    break;
                case 4:
                    last = 1;
                    break;
                case 8:
                    last = 2;
                    break;
            }
            numMap[m, n] = last;
            //test-begin
            string s = "";
            for (int f = 0; f < height; f++)
            {
                for (int g = 0; g < width; g++) s += numMap[f, g].ToString() + ",";
                s += "\r\n";
            }
            //txt_str.Text = s;
            //test-end
            while (directs.Count > 0)
            {
                int x = m;
                int y = n;
                int d = rand.Next(directs.Count);
                int t = 0;
                switch (directs[d])
                {
                    case 0:
                        x--;
                        t = 8;
                        break;
                    case 1:
                        y++;
                        t = 4;
                        break;
                    case 2:
                        x++;
                        t = 2;
                        break;
                    case 3:
                        y--;
                        t = 1;
                        break;
                }
                directs.RemoveAt(d);    //删除使用过的方向
                if (x < height && y < width && x >= 0 && y >= 0 && numMap[x, y] == -1)//没有超出数组边界，格子未被遍历过，则为true
                {
                    last = t ^ last;    //异或操作
                    numMap[m, n] = last;
                    //test-begin
                    string ss = "";
                    for (int f = 0; f < height; f++)
                    {
                        for (int g = 0; g < width; g++) ss += numMap[f, g].ToString() + ",";
                        ss += "\r\n";
                    }
                    //txt_str.Text = ss;
                    //test-end
                    CreateNumMap(x, y, t);  //递归操作
                }
            }
        }

        //生成迷宫
        private void CreateMap()
        {
            numMap[0, 0] = numMap[0, 0] ^ 8;//打开一个缺口，作为进入口。
            numMap[height - 1, width - 1] = numMap[height - 1, width - 1] ^ 2;//打开一个缺口作为出去口。
            for (int m = 0; m < height; m++)
            {
                for (int n = 0; n < width; n++)
                {
                    int x = numMap[m, n];
                    map[m, n].Image = ImageList[x];
                }
            }
            map[0, 0].Image = PathImageList[numMap[0, 0]]; //给第一格子换成橘黄色的背景
        }

        /// <summary>
        /// 创建迷宫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createBtn_Click(object sender, EventArgs e)
        {
            pointX = 0;
            pointY = 0;
            height = int.Parse(this.rowBox.Text);
            width = int.Parse(this.columnBox.Text);
            this.mazePanel.Controls.Clear();
            path = new int[height, width];
            map = new PictureBox[height, width];
            numMap = new int[height, width];
            drawCheckerboar();
            CreateNumMap(height / 2, width / 2, 0);//在迷宫的中间开始遍历
            //CreateNumMap(0, 0, 0);
            CreateMap();
        }

        /// <summary>
        /// 自动寻路
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Pathfinding(int x, int y)
        {
            if (x == height - 1 && y == width - 1)
            {
                for (int f = 0; f < height; f++)
                {
                    for (int g = 0; g < width; g++)
                    {
                        if (path[f, g] != 0)
                        {
                            map[f, g].Image = PathImageList[numMap[f, g]];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 3; i++)
                {
                    int m = x;
                    int n = y;
                    int direct = 0;
                    switch (i)
                    {
                        case 0:
                            m--;
                            direct = 8;
                            break;
                        case 1:
                            n++;
                            direct = 4;
                            break;
                        case 2:
                            m++;
                            direct = 2;
                            break;
                        case 3:
                            n--;
                            direct = 1;
                            break;
                    }
                    if (m < height && n < width && m >= 0 && n >= 0 && (numMap[x, y] & direct) != 0 && path[m, n] == 0)
                    {
                        path[x, y] = 1;
                        Pathfinding(m, n);
                        path[x, y] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 自动寻路
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pathfindBtn_Click(object sender, EventArgs e)
        {
            Pathfinding(0, 0);
        }

        /// <summary>
        /// 限制输入非数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //重写键盘事件,用于走迷宫
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (numMap != null)
            {
                int m = pointX;
                int n = pointY;
                int direct = 0;
                switch (keyData)
                {
                    case Keys.Up:
                        m--;
                        direct = 8;
                        break;
                    case Keys.Down:
                        m++;
                        direct = 2;
                        break;
                    case Keys.Left:
                        n--;
                        direct = 1;
                        break;
                    case Keys.Right:
                        n++;
                        direct = 4;
                        break;
                }
                if (m < height && n < width && m >= 0 && n >= 0 && (numMap[pointX, pointY] & direct) != 0)
                {
                    map[pointX, pointY].Image = ImageList[numMap[pointX, pointY]];
                    map[m, n].Image = PathImageList[numMap[m, n]];
                    //lb_x.Text = m.ToString();
                    //lb_y.Text = n.ToString();
                    pointX = m;
                    pointY = n;
                    if (m == height - 1 && n == width - 1)
                        MessageBox.Show("顺利过关");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var mazeImg = new Bitmap(mazePanel.Width, mazePanel.Height);
            mazePanel.DrawToBitmap(mazeImg, new Rectangle(0, 0, mazeImg.Width, mazeImg.Height));
            e.Graphics.DrawImage(mazeImg, 0, 0, mazeImg.Width, mazeImg.Height);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = printDocument1;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch
                {   //停止打印
                    printDocument1.PrintController.OnEndPrint(printDocument1, new System.Drawing.Printing.PrintEventArgs());
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "图片（*.png）|*.png";
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var mazeImg = new Bitmap(mazePanel.Width, mazePanel.Height);
                mazePanel.DrawToBitmap(mazeImg, new Rectangle(0, 0, mazeImg.Width, mazeImg.Height));
                mazeImg.Save(sfd.FileName);
            }
        }
    }
}
