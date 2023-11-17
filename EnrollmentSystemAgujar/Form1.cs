using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystemAgujar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginB_Click(object sender, EventArgs e)
        {
            string user = userN.Text;
            string pass = passW.Text;

            if (user == "admin" && pass == "admin")
            {
                
            }
        }

        private void clear(object sender, EventArgs e)
        {
            passW.Text = " ";
            userN.Text = " ";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
