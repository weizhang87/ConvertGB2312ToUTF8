using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConvertGS2312ToUTF8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"C:\Users\w.zhang\Downloads\benbenla", "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (file.Contains(".htm") || file.Contains(".html"))
                {
                    string newFile = file.Replace("benbenla", "bbl");
                    if (!Directory.Exists(Path.GetDirectoryName(newFile)))
                        Directory.CreateDirectory(Path.GetDirectoryName(newFile));

                    using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("GB2312")))
                    {
                        using (StreamWriter sw = new StreamWriter(newFile, false, Encoding.UTF8))
                        {
                            sw.Write(sr.ReadToEnd());
                            sw.Close();
                        }
                        sr.Close();
                    }
                    Console.WriteLine("file done: " + newFile);
                }
                else
                {
                    string newFile = file.Replace("benbenla", "bbl");
                    if (!Directory.Exists(Path.GetDirectoryName(newFile)))
                        Directory.CreateDirectory(Path.GetDirectoryName(newFile));
                    File.Copy(file, newFile, true);
                    Console.WriteLine("file done: " + newFile);
                }
            }
            MessageBox.Show("Done");
        }
    }
}
