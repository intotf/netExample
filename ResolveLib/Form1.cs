using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResolveLib
{
    public partial class Form1 : Form
    {
        private readonly JsonSerializerSettings jsonSettions = new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd HH:mm:ss" };
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JsonConvert.DefaultSettings = () =>
            {
                return jsonSettions;
            };

            var json = JsonConvert.SerializeObject(new TestModel());
            this.textBox1.Text = json;
        }
    }

    public class TestModel
    {
        public string Title { get; set; } = "标题";

        public int Count { get; set; } = 99;

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
