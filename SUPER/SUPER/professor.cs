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
    public partial class professor : Form
    {
        int id;
        DataClasses1DataContext db = new DataClasses1DataContext();
        public professor()
        {
            InitializeComponent();
        }

        private void professor_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.displayInstructors();
        }
        // validations
        private void ClearText()
        {
            txtfirstname.Text = "";
            txtmiddlename.Text = "";
            txtlastname.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtaddress.Text = "";
            txtphoneno.Text = "";
            txtemail.Text = "";
            rbfemale.Checked = false;
            rbmale.Checked = false;

        }
        private void validation()
        {
            StringBuilder errorMessage = new StringBuilder("Please review required information: \n");

            if (!ValidateFirstName(txtfirstname.Text))
            {
                errorMessage.AppendLine("- First Name");
            }

            if (!ValidateMiddleName(txtmiddlename.Text))
            {
                errorMessage.AppendLine("- Middle Name");
            }

            if (!ValidateLastName(txtlastname.Text))
            {
                errorMessage.AppendLine("- Last Name");
            }
            if (!ValidateSex())
            {
                errorMessage.AppendLine("- Sex");
            }
            if (!ValidatePhoneNumber(txtphoneno.Text))
            {
                errorMessage.AppendLine("- Phone Number");
            }

            if (!ValidateBirthday(dateTimePicker1.Value))
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
            if (rbmale.Checked || rbfemale.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            bool isFirstNameValid = ValidateFirstName(txtfirstname.Text);
            bool isMiddleNameValid = ValidateMiddleName(txtlastname.Text);
            bool isLastNameValid = ValidateLastName(txtmiddlename.Text);
            bool isPhoneNumberValid = ValidatePhoneNumber(txtphoneno.Text);
            bool isBirthdayValid = ValidateBirthday(dateTimePicker1.Value);
            bool isEmailValid = ValidateEmail(txtemail.Text);
            bool isAddressValid = ValidateAddress(txtaddress.Text);

            return isSexValid && isFirstNameValid && isMiddleNameValid && isLastNameValid && isPhoneNumberValid &&
                             isBirthdayValid && isEmailValid && isAddressValid;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sex = "";

            if (rbmale.Checked)
            {

                sex = rbmale.Text;

            }
            else if (rbfemale.Checked)
            {

                sex = rbfemale.Text;

            }

            string firstname = txtfirstname.Text;
            string lastname = txtlastname.Text;
            string middlename = txtmiddlename.Text;
            string phonenumber = txtphoneno.Text;
            DateTime birthday = dateTimePicker1.Value;
            string email = txtemail.Text;
            string address = txtaddress.Text;

            if (ValidateFields())
            {
                db.saveInstructor(firstname, middlename, lastname, birthday, sex, address, phonenumber, email);
                MessageBox.Show("Succesfully Save!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView2.DataSource = db.displayInstructors();
            }
            else validation();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sex = "";

            if (rbmale.Checked)
            {

                sex = rbmale.Text;

            }
            else if (rbfemale.Checked)
            {

                sex = rbfemale.Text;

            }

            string firstname = txtfirstname.Text;
            string lastname = txtlastname.Text;
            string middlename = txtmiddlename.Text;
            string phonenumber = txtphoneno.Text;
            DateTime birthday = dateTimePicker1.Value;
            string email = txtemail.Text;
            string address = txtaddress.Text;

            if (ValidateFields())
            {
                db.updateInstructor(id, firstname, middlename, lastname, birthday, sex, address, phonenumber, email);
                MessageBox.Show("Succesfully Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearText();
                dataGridView2.DataSource = db.displayInstructors();
            }
            else validation();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                db.deleteInstructor(id);
                MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataGridView2.DataSource = db.displayInstructors();
                ClearText();
            }
            else
            {
                MessageBox.Show("No Instructor Found");
            }
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            homeed home1 = new homeed();
            home1.Show();
            home1.Location = new Point(400, 160);
            this.Hide();
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = db.SearchInstructor(txtSearchInstructor.Text);
        }

        private void txtSearchInstructor_TextChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            txtfirstname.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtlastname.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtmiddlename.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Value = DateTime.TryParse(dataGridView2.CurrentRow.Cells[6].Value.ToString(), out DateTime parsedDate) ? parsedDate : dateTimePicker1.Value;
            if (dataGridView2.CurrentRow.Cells[5].Value.ToString() == rbfemale.Text)
            {
                rbfemale.Checked = true;
            }
            else
            {
                rbmale.Checked = true;
            }
            txtemail.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            txtaddress.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            txtphoneno.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
        }
    }
}
