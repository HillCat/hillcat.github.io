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

namespace AutoMapperGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var allText = textBox1.Text;
           var collections= Regex.Matches(allText, @"public (.*) (.*?) { get; set; }", RegexOptions.None);
           var sb = new StringBuilder();
            for (var i = 0; i < collections.Count; i++)
            {
                var property= collections[i].Groups[2].ToString();
                var newStr = ".ForMember(f => f." + property + ", n => n.MapFrom(d => d." + property + "))";
                sb.AppendLine(newStr);
            }
            textBox2.Text = sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "";
        }
    }
}
