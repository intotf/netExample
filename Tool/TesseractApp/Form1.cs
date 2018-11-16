using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TesseractApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.tbFile.Text = fileDialog.FileName;
                ReadText();
            }
        }

        private void ReadText()
        {
            var selLang = this.cbLanguage.SelectedItem;
            var language = selLang == null ? "eng" : selLang.ToString();
            var ocr = new Emgu.CV.OCR.Tesseract(@"D:\Program Files\Tesseract-OCR\", language, Emgu.CV.OCR.OcrEngineMode.Default);
            Bgr drawColor = new Bgr(Color.Blue);
            try
            {
                Image<Bgr, Byte> image = new Image<Bgr, byte>(this.tbFile.Text);

                ocr.Recognize();
                ocr.SetImage(new Pix(image.Mat));
                richTextBox1.Text = ocr.GetUTF8Text();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            //var text = ocr.GetUTF8Text();
            //try
            //{
            //    using (var _ocr = new TesseractEngine(, language, EngineMode.Default))
            //    {

            //    }
            //}
            //catch (TesseractException te)
            //{

            //}

            ////指定参数实例化tessdata 类。
            //_ocr.Recognize();
            ////识别图像。
            //Tesseract.Character[] characters = _ocr.GetCharacters();//这句报错“System.AccessViolationException”类型的未经处理的异常在 Emgu.CV.World.dll 中发生 。其他信息: 尝试读取或写入受保护的内存。这通常指示其他内存已损坏。
            ////获取识别数据
            //Bgr drawColor = new Bgr(Color.Blue);
            ////创建Bgr 为蓝色。
            //foreach (Tesseract.Character c in characters)//遍历每个识别数据。
            //{
            //    image.Draw(c.Region, drawColor, 1);//绘制检测到的区域。
            //}
            //imageBox1.Image = image;//显示绘制矩形区域的图像
            //String text = _ocr.GetUTF8Text();//得到识别字符串。
            //richTextBox1.Text = text;//显示获取的字符串。
            ////MessageBox.Show(ex.Message);
            //// MessageBox.Show("检查运行目录是否有语言包");
        }
    }
}
