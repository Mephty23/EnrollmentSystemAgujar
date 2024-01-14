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
    public partial class cor : Form
    {

        private string userId;
        DataClasses1DataContext db = new DataClasses1DataContext();
        public cor()
        {
            InitializeComponent();
            this.userId = userId;
        }
        public void SetUserId(string userId)
        {
            this.userId = userId;
        }

        private void cor_Load(object sender, EventArgs e)
        {
            if (int.TryParse(userId, out int userid))
            {
                var info = db.getStudentWA(userid);
                foreach (var s in info)
                {
                    string idstud = s.stud_id.ToString();
                    var studId = db.getStudent(int.Parse(idstud));

                    foreach (var l in studId)
                    {
                        string f = l.enrollment_idCode.ToString();
                        textBox1.Text = f;

                        var result = db.getEnrolleeInfo(int.Parse(textBox1.Text));
                        foreach (var i in result)
                        {
                            string name = i.fname;
                            string lname = i.midname;
                            string mname = i.lname;
                            string section = i.section;
                            string yr = i.yr.ToString();
                            string sem = i.sem.ToString();
                            string program = i.program;
                            string sy = i.sy;
                            textBox2.Text = userId.ToString();
                            textBox7.Text = "Semester " + sem.ToString() + "  S.Y. " + sy.ToString();
                            textBox3.Text = mname.ToString() + ", " + name.ToString() + " " + lname.ToString();
                            textBox4.Text = program.ToString() + " " + yr.ToString();
                            textBox6.Text = section.ToString();
                        }
                        dataGridView2.DataSource = db.displayCOR(int.Parse(textBox1.Text));
                    }
                }
            }
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
