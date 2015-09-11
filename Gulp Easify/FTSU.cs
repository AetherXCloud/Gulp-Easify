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
using System.Management;
using System.Threading;

namespace Gulp_Easify
{
    public partial class FTSU : Form
    {
        public FTSU()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) {
                textBox1.ReadOnly = false;
            } else if(!checkBox2.Checked) {
                textBox1.Text = "";
                textBox1.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to do this?"+ "\n" + "It will tak aproximately 40 seconds." + "\n" + "During this time several windows will appear.", "Are You Sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Do you have node.js installed?" , "Node.js?", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes) {
                    if (checkBox2.Checked)
                    {
                        Process.Start("cmd", "/K npm config set proxy " + textBox1.Text);
                        Process.Start("cmd", "/K npm config rm https-proxy" + textBox1.Text);
                    }
                    else
                    {
                        Process.Start("cmd", "npm config rm proxy");
                        Process.Start("cmd", "npm config rm https-proxy");
                    }
                    Thread.Sleep(4000);
                    Array.ForEach(Process.GetProcessesByName("cmd"), x => x.Kill());
                    if (checkBox4.Checked)
                    {
                        Process.Start("cmd", "/K npm install --global gulp");
                    }
                    Process.Start("cmd", "/K npm install --save-dev gulp");
                    Thread.Sleep(20000);
                    Array.ForEach(Process.GetProcessesByName("cmd"), x => x.Kill());
                    if (checkBox3.Checked)
                    {
                        Process.Start("cmd", "/K npm install --save-dev gulp-sass");
                        Thread.Sleep(10000);
                    }
                    if (checkBox1.Checked)
                    {
                        Process.Start("cmd", "/K npm install --save-dev gulp-jade");
                        Thread.Sleep(10000);
                    }
                    if (checkBox5.Checked)
                    {
                        Process.Start("cmd", "/K npm install --save-dev gulp-uglify");
                        Thread.Sleep(10000);
                    }
                    Thread.Sleep(5000);
                    Array.ForEach(Process.GetProcessesByName("cmd"), x => x.Kill());
                }
                else if (dialogResult2 == DialogResult.No)
                {
                    Process.Start("https://nodejs.org/");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }
    }
}
