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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamWriter sw;
        string dosyaadi, dosyayolu;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            dosyaadi = textBox2.Text;
            sw = File.CreateText(dosyayolu + "\\" + dosyaadi + ".txt");
            sw.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string satır = sr.ReadLine();
                while (satır != null)
                {
                    listBox1.Items.Add(satır);
                    satır = sr.ReadLine();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Metin Dosyalar |*.txt";
            saveFileDialog1.Title = "Metin Belgesi Kayıt";
            saveFileDialog1.ShowDialog();

            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
            MessageBox.Show("Başarıyla Kaydedildi","Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog ()==DialogResult.OK)
            {
                dosyayolu = folderBrowserDialog1.SelectedPath.ToString();
                textBox1.Text = dosyayolu;
            }
        }
    }
}
