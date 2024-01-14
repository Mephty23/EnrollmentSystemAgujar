using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUPER
{
    public partial class homestud : Form
    {
        public homestud()
        {
            InitializeComponent();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            homestud hstuden = new homestud();
            hstuden.Show();
            hstuden.Location = new Point(400, 160);
            this.Hide();
        }

        private void pROFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eNROLLMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studenroll studen = new studenroll();
            studen.Show();
            studen.Location = new Point(400, 160);
            this.Hide();
        }

        private void cORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cor viewcor = new cor();
            viewcor.Show();
            viewcor.Location = new Point(400, 160);
            this.Hide();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            logout.Location = new Point(400, 160);
            this.Hide();
        }
    }
}
