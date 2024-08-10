using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe_ass
{
    public partial class GameHUB : Form
    {
        public GameHUB()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tictacbtn_Click(object sender, EventArgs e)
        {
            Form1 tictactoe = new Form1();
            tictactoe.ShowDialog();
        }

        private void picpuzbtn_Click(object sender, EventArgs e)
        {
            Image_Sliding_Puzzle picpuz = new Image_Sliding_Puzzle();
            picpuz.ShowDialog();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void snakebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string exepath = @"C:\Users\HP\Desktop\Abdullah.exe";
                var psi = new ProcessStartInfo
                {
                    FileName = exepath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (var process = Process.Start(psi))
                {
                    //string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    //MessageBox.Show("Output: " + output);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void cntfourbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string exepath = @"C:\Users\HP\Desktop\AI.exe";
                var psi = new ProcessStartInfo
                {
                    FileName = exepath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (var process = Process.Start(psi))
                {
                    //string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    //MessageBox.Show("Output: " + output);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}
