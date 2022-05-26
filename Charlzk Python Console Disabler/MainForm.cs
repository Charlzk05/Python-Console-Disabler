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

namespace Charliezkie_Python_Console_Disabler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Python File (*.py)|*.py";
                ofd.ShowDialog();
                string path = Path.GetFullPath(ofd.FileName);
                textBox1.Text = path;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please insert a python file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please choose a file destination.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please insert a python file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string pythonFile = textBox2.Text;
                    string pythonFileName = textBox3.Text;
                    string createPythonServerOFF = "@echo off\n" + "python " + pythonFileName;
            
                    File.Copy(pythonFile, $@"{textBox2.Text}\{textBox3.Text}.py");
                    File.WriteAllText($@"{textBox2.Text}\PythonServerOFF.bat", createPythonServerOFF);
            
                    char character = '"';
                    string startVBS = "CreateObject(" + character + "WScript.Shell" + character + ").Run" + " " + character + "PythonServerOFF.bat" + character + ", 0, True";
            
                    File.WriteAllText($@"{textBox2.Text}\Start.vbs", startVBS);
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            textBox2.Text = folderBrowserDialog.SelectedPath;
        }
    }
}
