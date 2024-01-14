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
    public partial class homeed : Form
    {
        public homeed()
        {
            InitializeComponent();
        }

        private void homeed_Load(object sender, EventArgs e)
        {

        }

        private void aDDPROFESSORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            professor form1 = new professor();
            form1.Show();
            form1.Location = new Point(400, 160);
            this.Hide();
        }

        private void pROGRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addprogram program1 = new addprogram();
            program1.Show();
            program1.Location = new Point(400, 160);
            this.Hide();

        }

        private void eNROLLMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewenroll enroll1 = new viewenroll();
            enroll1.Show();
            enroll1.Location = new Point(400, 160);
            this.Hide();
        }

        private void cLASSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classadd classadd1 = new classadd();
            classadd1.Show();
            classadd1.Location = new Point(400, 160);
            this.Hide();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            logout.Location = new Point(400, 160);
            this.Hide();
        }

        private void aDDSTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            student forst = new student();
            forst.Show();
            forst.Location = new Point(400, 160);
            this.Hide();
        }
    }
}
