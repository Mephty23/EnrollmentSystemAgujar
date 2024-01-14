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
    public partial class student : Form
    {

        int id;
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void student_Load(object sender, EventArgs e)
        {
            populatecb();
            populateSY();
            dataGridView1.DataSource = db.displayStudents(comboBox1.Text);
        }
        private void populateSY()
        {
            int currentYear = DateTime.Now.Year;
            int nextYear = currentYear + 1;
            comboBox1.Text = currentYear.ToString() + "-" + nextYear.ToString();
        }
        private void populatecb()
        {
            var programs = db.checkPrograms();

            cbprogram.Items.Clear();

            foreach (var i in programs)
            {
                string program = i.prog_name.ToString();
                cbprogram.Items.Add(program);
            }
            cbprogram.Refresh();
        }
        private void ClearText()
        {
            txtfirstname.Text = "";
            txtmiddlename.Text = "";
            txtlastname.Text = "";
            dtbirthday.Value = DateTime.Now;
            txtaddress.Text = "";
            txtphonenumber.Text = "";
            txtlastname.Text = "";
            rbfemale.Checked = false;
            dbmale.Checked = false;
            populateSY();

        }
        //save button
        private void button12_Click(object sender, EventArgs e)
        {
            string sex = "";

            if (dbmale.Checked)
            {

                sex = dbmale.Text;

            }
            else if (rbfemale.Checked)
            {

                sex = rbfemale.Text;

            }
            string program = cbprogram.Text;
            string semester = cbsemester.Text;
            string yearlvl = cbyearlvl.Text;

            string firstname = txtfirstname.Text;
            string middlename = txtlastname.Text;
            string lastname = txtmiddlename.Text;
            string phonenumber = txtphonenumber.Text;
            DateTime bday = dtbirthday.Value;
            string email = txtemail.Text;
            string address = txtaddress.Text;
            string sy = comboBox1.Text;

            if (ValidateFields())
            {
                int sem = int.Parse(cbsemester.Text);
                int yr = int.Parse(cbyearlvl.Text);
                int? account = null;
                db.saveStudent(firstname, middlename, lastname, bday, sex, address, phonenumber, email, sy, sem, program, yr, account);

                MessageBox.Show("Succesfully Save!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView1.DataSource = db.displayStudents(comboBox1.Text);
            }
            else
            {
                validation();

            }
        }
        // validations
        private void validation()
        {
            StringBuilder errorMessage = new StringBuilder("Please review required information:\n");

            if (!ValidateProgram(cbprogram.Text))
            {
                errorMessage.AppendLine("- Program");
            }

            if (!ValidateSemester(cbsemester.Text))
            {
                errorMessage.AppendLine("- Semester");
            }

            if (!ValidateYearLevel(cbyearlvl.Text))
            {
                errorMessage.AppendLine("- Year Level");
            }

            if (!ValidateFirstName(txtfirstname.Text))
            {
                errorMessage.AppendLine("- First Name");
            }

            if (!ValidateMiddleName(txtlastname.Text))
            {
                errorMessage.AppendLine("- Middle Name");
            }

            if (!ValidateLastName(txtmiddlename.Text))
            {
                errorMessage.AppendLine("- Last Name");
            }
            if (!ValidateSex())
            {
                errorMessage.AppendLine("- Sex");
            }
            if (!ValidatePhoneNumber(txtphonenumber.Text))
            {
                errorMessage.AppendLine("- Phone Number");
            }

            if (!ValidateBirthday(dtbirthday.Value))
            {
                errorMessage.AppendLine("- Birthday");
            }

            if (!ValidateEmail(txtemail.Text))
            {
                errorMessage.AppendLine("- Email");
            }

            if (!ValidateAddress(txtaddress.Text))
            {
                errorMessage.AppendLine("- Address");
            }

            MessageBox.Show(errorMessage.ToString(), "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private bool ValidateSex()
        {
            if (dbmale.Checked || rbfemale.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateProgram(string program)
        {
            return !string.IsNullOrWhiteSpace(program);
        }

        private bool ValidateSemester(string semester)
        {
            if (string.IsNullOrWhiteSpace(semester))
            {
                return false;
            }
            return int.TryParse(semester, out _);
        }


        private bool ValidateYearLevel(string yearlevel)
        {
            if (int.TryParse(yearlevel, out int yearLevelValue))
            {
                return yearLevelValue >= 1 && yearLevelValue <= 4;
            }
            else return false;
        }

        private bool ValidateFirstName(string firstname)
        {
            string namePattern = @"^[A-Za-z\s'-]+$";
            return !string.IsNullOrWhiteSpace(firstname) && System.Text.RegularExpressions.Regex.IsMatch(firstname, namePattern);
        }

        private bool ValidateMiddleName(string middlename)
        {
            string namePattern = @"^[A-Za-z\s'-]+$";
            return !string.IsNullOrWhiteSpace(middlename) && System.Text.RegularExpressions.Regex.IsMatch(middlename, namePattern);
        }

        private bool ValidateLastName(string lastname)
        {
            string namePattern = @"^[A-Za-z\s'-]+$";
            return !string.IsNullOrWhiteSpace(lastname) && System.Text.RegularExpressions.Regex.IsMatch(lastname, namePattern);
        }

        private bool ValidatePhoneNumber(string phonenumber)
        {
            if (phonenumber.Length == 11 && System.Text.RegularExpressions.Regex.IsMatch(phonenumber, @"^\d{11}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateBirthday(DateTime bday)
        {
            if (bday > DateTime.Now.Date)
                return false;
            else
                return true;
        }

        private bool ValidateEmail(string email)
        {
            string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
                return false;
            else
                return true;
        }

        private bool ValidateAddress(string address)
        {
            return !string.IsNullOrWhiteSpace(address);
        }
        private bool ValidateFields()
        {
            bool isSexValid = ValidateSex();
            bool isProgramValid = ValidateProgram(cbprogram.Text);
            bool isSemesterValid = ValidateSemester(cbsemester.Text);
            bool isYearLevelValid = ValidateYearLevel(cbyearlvl.Text);
            bool isFirstNameValid = ValidateFirstName(txtfirstname.Text);
            bool isMiddleNameValid = ValidateMiddleName(txtlastname.Text);
            bool isLastNameValid = ValidateLastName(txtmiddlename.Text);
            bool isPhoneNumberValid = ValidatePhoneNumber(txtphonenumber.Text);
            bool isBirthdayValid = ValidateBirthday(dtbirthday.Value);
            bool isEmailValid = ValidateEmail(txtemail.Text);
            bool isAddressValid = ValidateAddress(txtaddress.Text);

            return isProgramValid && isSemesterValid && isYearLevelValid && isSexValid &&
                             isFirstNameValid && isMiddleNameValid && isLastNameValid && isPhoneNumberValid &&
                             isBirthdayValid && isEmailValid && isAddressValid;
        }
        // update button
        private void button13_Click(object sender, EventArgs e)
        {
            string sex = "";

            if (dbmale.Checked)
            {

                sex = dbmale.Text;

            }
            else if (rbfemale.Checked)
            {

                sex = rbfemale.Text;

            }
            string program = cbprogram.Text;
            string semester = cbsemester.Text;
            string yearlvl = cbyearlvl.Text;

            string firstname = txtfirstname.Text;
            string middlename = txtlastname.Text;
            string lastname = txtmiddlename.Text;
            string phonenumber = txtphonenumber.Text;
            DateTime bday = dtbirthday.Value;
            string email = txtemail.Text;
            string address = txtaddress.Text;
            string sy = comboBox1.Text;

            if (ValidateFields())
            {
                int sem = int.Parse(cbsemester.Text);
                int yr = int.Parse(cbyearlvl.Text);
                db.UpdateStudent(id, firstname, middlename, lastname, bday, sex, address, phonenumber, email, sy, sem, program, yr);
                MessageBox.Show("Succesfully Update!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView1.DataSource = db.displayStudents(comboBox1.Text);
            }
            else
            {
                validation();
            }
        }
        //delete button
        private void button14_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                db.DeleteStudent(id);
                MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView1.DataSource = db.displayStudents(comboBox1.Text);
            }
            MessageBox.Show("No Student Found");
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

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.searchStudents(txtSearchBar.Text);
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            homeed home1 = new homeed();
            home1.Show();
            home1.Location = new Point(400, 160);
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            txtfirstname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtmiddlename.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtlastname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dtbirthday.Value = DateTime.TryParse(dataGridView1.CurrentRow.Cells[5].Value.ToString(), out DateTime parsedDate) ? parsedDate : dtbirthday.Value;
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == rbfemale.Text)
            {
                rbfemale.Checked = true;
            }
            else
            {
                dbmale.Checked = true;
            }
            var student = db.checkStudbday(id).SingleOrDefault();

            if (student != null)
            {
                dtbirthday.Value = student.stud_bday ?? DateTime.Now;
                cbsemester.Text = student.stud_sem.ToString();
                txtaddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtphonenumber.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtemail.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                cbprogram.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                cbyearlvl.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            }
        }
    }
}
