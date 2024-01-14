using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SUPER
{

    DataClasses1DataContext db = new DataClasses1DataContext("your_connection_string");
    public partial class addprogram : Form
    {
        public addprogram()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void addprogram_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.displayPrograms();
        }

        private void ClearText()
        {
            progName.Text = "";
            progdescript.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string programName = progName.Text;
            string programDesc = progdescript.Text;

            if (ValidateProgramFields())
            {
                db.saveProgram(programName, programDesc);
                MessageBox.Show("Successfully Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView1.DataSource = db.displayPrograms();
            }
            else validation();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string programName = progName.Text;
            string programDesc = progdescript.Text;

            if (ValidateProgramFields())
            {
                db.updatePrograms(programName, programDesc);
                MessageBox.Show("Succesfully Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView1.DataSource = db.displayPrograms();
            }
            else validation();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string programName = progName.Text;

                db.deleteProgram(programName);
                MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView1.DataSource = db.displayPrograms();
            }
            catch
            {
                MessageBox.Show("Cannot Delete, Some Students are already enrolled in this Program for this Semester.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validation()
        {
            StringBuilder errorMessage = new StringBuilder("Please review required information: \n");

            if (!ValidateProgramName(progName.Text))
            {
                errorMessage.AppendLine("- Program Name");
            }

            if (!ValidateProgramDescription(progdescript.Text))
            {
                errorMessage.AppendLine("- Program Description");
            }

            MessageBox.Show(errorMessage.ToString(), "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private bool ValidateProgramName(string programName)
        {
            string namePattern = @"^[A-Za-z0-9\s]+$";
            return !string.IsNullOrWhiteSpace(programName) && System.Text.RegularExpressions.Regex.IsMatch(programName, namePattern);
        }

        private bool ValidateProgramDescription(string programDesc)
        {
            return !string.IsNullOrWhiteSpace(programDesc);
        }

        private bool ValidateProgramFields()
        {
            bool isNameValid = ValidateProgramName(progName.Text);
            bool isDescValid = ValidateProgramDescription(progdescript.Text);

            return isNameValid && isDescValid;
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            progName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            progdescript.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = db.displayPrograms();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            homeed home1 = new homeed();
            home1.Show();
            home1.Location = new Point(400, 160);
            this.Hide();
        }

        private void pROFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aDMISSIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aDDSTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            student forst = new student();
            forst.Show();
            forst.Location = new Point(400, 160);
            this.Hide();
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
            enroll enroll1 = new enroll();
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
    }
}
