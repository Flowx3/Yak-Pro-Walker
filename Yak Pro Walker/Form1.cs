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

namespace Yak_Pro_Walker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool projectSelected = false;

        public bool deobfuscatorSelected = false;

        public bool phpSelected = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!projectSelected || !deobfuscatorSelected || !phpSelected)
            {
                MessageBox.Show("Please select Your Project Folder or Deobfuscator or your PHP.exe");
                return;
            }
            List<String> files = new List<string>();
            files = Directory.GetFiles(textBox1.Text, "*.php", SearchOption.AllDirectories).Where(s => !s.Contains("vendor")).ToList();
            foreach (string fileName in files)
            {
                System.Diagnostics.Process.Start(textBox3.Text, $"{textBox2.Text} {fileName}");
                listBox1.Items.Add(fileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    textBox1.Text = folderBrowserDialog.SelectedPath;
                    projectSelected = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Deobfuscator(*.php)|*.php";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    textBox2.Text = openFileDialog.FileName;
                    deobfuscatorSelected = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PHP file (php.exe)|php.exe";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    textBox3.Text = openFileDialog.FileName;
                    phpSelected = true;
                }
            }
        }
    }
}
