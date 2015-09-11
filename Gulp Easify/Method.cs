using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gulp_Easify
{
    public partial class Method : Form
    {
        public Method()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FTSU f1 = new FTSU();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GulpFile f2 = new GulpFile();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Watch f3 = new Watch();
            f3.Show();
        }

        private void Method_Load(object sender, EventArgs e)
        {

        }
    }
}
