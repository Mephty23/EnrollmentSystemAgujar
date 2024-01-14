using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SUPER
{
    public partial class studenroll : Form
    {
        private string userId;
        DataClasses1DataContext db = new DataClasses1DataContext();
        public studenroll()
        {
            InitializeComponent();
            this.userId = userId;
        }
        private void studenroll_Load(object sender, EventArgs e)
        {
            supplyInfo();
            populatecb();
            populateSY();
        }
        public void SetUserId(string userId)
        {
            this.userId = userId;
        }
        private void UserEnroll_Load(object sender, EventArgs e)
        {
            supplyInfo();
            populatecb();
            populateSY();
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
        //validations
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
        private void populateSY()
        {
            int currentYear = DateTime.Now.Year;
            int nextYear = currentYear + 1;
            comboBox1.Text = currentYear.ToString() + "-" + nextYear.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = textBox6.Text;

            string[] nameParts = fullName.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string lastName = "";
            string firstName = "";
            string middleName = "";

            if (nameParts.Length >= 3)
            {
                lastName = nameParts[0];
                firstName = nameParts[1];
                middleName = nameParts[2];
            }
            var info = db.getId(firstName, middleName, lastName, comboBox2.Text, int.Parse(comboBox3.Text), comboBox5.Text, int.Parse(comboBox4.Text));

            panel1.Visible = false;
            panel3.Visible = true;

            foreach (var i in info)
            {
                string idno = i.stud_id.ToString();
                string studno = i.stud_no.ToString();
                string fname = i.stud_fname.ToString();
                string lname = i.stud_lname.ToString();
                string midname = i.stud_middlename.ToString(); ;
                string emailAd = i.stud_email.ToString();
                string contact = i.stud_phone.ToString();
                string gender = i.stud_sex.ToString();
                string schoolyr = i.stud_syear.ToString();
                string Sem = i.stud_sem.ToString();
                string prog = i.prog_name.ToString();
                string Yrlvl = i.prog_yearlevel.ToString();
                DateTime bday = i.stud_bday.Value;
                string email = i.stud_email.ToString();

                textBox7.Text = idno;
                textBox3.Text = studno;

                txtfirstname.Text = fname;
                txtlastname.Text = midname;
                txtmiddlename.Text = lname;
                dtbirthday.Value = bday;

                txtaddress.Text = emailAd;
                txtemail.Text = email;
                if (gender == "Male")
                {
                    dbmale.Checked = true;
                }
                else
                {
                    rbfemale.Checked = true;
                }
                txtphonenumber.Text = contact;
                comboBox1.Text = schoolyr;
                cbprogram.Text = prog;

            }


        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void supplyInfo()
        {
            if (string.IsNullOrEmpty(userId))
            {
                panel1.Visible = false;
                panel3.Visible = true;
            }
            else
            {
                if (int.TryParse(userId, out int userid))
                {
                    var info = db.getStudentWA(userid);

                    foreach (var i in info)
                    {
                        string status = i.stud_status.ToString();
                        if (status == "enrolled")
                        {
                            panel1.Visible = true;
                            panel3.Visible = false;
                            string idno = i.stud_id.ToString();
                            string studno = i.stud_no.ToString();
                            string studname = $"{i.stud_lname}, {i.stud_fname} {i.stud_middlename}";
                            string emailAd = i.stud_email.ToString();
                            string contact = i.stud_phone.ToString();
                            string gender = i.stud_sex.ToString();
                            string schoolyr = i.stud_syear.ToString();
                            string Sem = i.stud_sem.ToString();
                            string prog = i.prog_name.ToString();
                            string Yrlvl = i.prog_yearlevel.ToString();

                            textBox7.Text = idno;
                            textBox6.Text = studname;
                            textBox1.Text = studno;
                            textBox5.Text = emailAd;
                            textBox2.Text = gender;
                            textBox4.Text = contact;
                            comboBox2.Text = schoolyr;
                            comboBox5.Text = prog;
                            comboBox4.Text = Yrlvl;
                            comboBox3.Text = Sem;
                        }
                        else
                        {
                            MessageBox.Show("Enrollment Pending");

                            string stud = i.stud_no.ToString();
                            string studn = i.stud_lname;
                            string studl = i.stud_fname;
                            string studm = i.stud_middlename;
                            string emailA = i.stud_email.ToString();
                            string add = i.stud_address.ToString();
                            string cont = i.stud_phone.ToString();
                            string gen = i.stud_sex.ToString();
                            string sy = i.stud_syear.ToString();
                            string Sm = i.stud_sem.ToString();
                            string pr = i.prog_name.ToString();
                            string Yr = i.prog_yearlevel.ToString();

                            txtaddress.Text = add;
                            txtfirstname.Text = studl;
                            txtlastname.Text = studn;
                            txtmiddlename.Text = studm;
                            txtemail.Text = emailA;
                            if (gen == "Male")
                            {
                                dbmale.Checked = true;
                            }
                            else
                            {
                                rbfemale.Checked = true;
                            }

                            txtphonenumber.Text = cont;
                            comboBox1.Text = sy;
                            cbprogram.Text = pr;
                            cbyearlvl.Text = Yr;
                            cbsemester.Text = Sm;
                            button12.Visible = false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Application not found");
                }
            }
        
        
        }

        private void button12_Click_1(object sender, EventArgs e)
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
                if (int.TryParse(userId, out int account))
                {
                    int sem = int.Parse(cbsemester.Text);
                    int yr = int.Parse(cbyearlvl.Text);

                    db.saveStudent(firstname, middlename, lastname, bday, sex, address, phonenumber, email, sy, sem, program, yr, account);
                    MessageBox.Show("Succesfully Save!", "Save");
                    ClearText();
                    panel1.Visible = true;
                    var info = db.getId(firstname, middlename, lastname, sy, sem, program, yr);

                    foreach (var i in info)
                    {
                        string idno = i.stud_id.ToString();
                        string studno = i.stud_no.ToString();
                        string studname = i.stud_lname.ToString() + ", " + i.stud_fname.ToString() + " " + i.stud_middlename.ToString();
                        string emailAd = i.stud_email.ToString();
                        string contact = i.stud_phone.ToString();
                        string gender = i.stud_sex.ToString();
                        string schoolyr = i.stud_syear.ToString();
                        string Sem = i.stud_sem.ToString();
                        string prog = i.prog_name.ToString();
                        string Yrlvl = i.prog_yearlevel.ToString();

                        textBox7.Text = idno;
                        textBox6.Text = studname;
                        textBox1.Text = studno;
                        textBox5.Text = emailAd;
                        textBox2.Text = gender;
                        textBox4.Text = contact;
                        comboBox2.Text = schoolyr;
                        comboBox5.Text = prog;
                        comboBox4.Text = Yrlvl;
                        comboBox3.Text = Sem;

                    }
                }
                else
                {
                    MessageBox.Show("Cannot retrieve user account");

                }
            }
            else
            {
                validation();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string fullName = textBox6.Text;

            string[] nameParts = fullName.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string lastName = "";
            string firstName = "";
            string middleName = "";

            if (nameParts.Length >= 3)
            {
                lastName = nameParts[0];
                firstName = nameParts[1];
                middleName = nameParts[2];
            }
            var info = db.getId(firstName, middleName, lastName, comboBox2.Text, int.Parse(comboBox3.Text), comboBox5.Text, int.Parse(comboBox4.Text));

            panel1.Visible = false;
            panel3.Visible = true;

            foreach (var i in info)
            {
                string idno = i.stud_id.ToString();
                string studno = i.stud_no.ToString();
                string fname = i.stud_fname.ToString();
                string lname = i.stud_lname.ToString();
                string midname = i.stud_middlename.ToString(); ;
                string emailAd = i.stud_email.ToString();
                string contact = i.stud_phone.ToString();
                string gender = i.stud_sex.ToString();
                string schoolyr = i.stud_syear.ToString();
                string Sem = i.stud_sem.ToString();
                string prog = i.prog_name.ToString();
                string Yrlvl = i.prog_yearlevel.ToString();
                DateTime bday = i.stud_bday.Value;
                string email = i.stud_email.ToString();

                textBox7.Text = idno;
                textBox3.Text = studno;

                txtfirstname.Text = fname;
                txtlastname.Text = midname;
                txtmiddlename.Text = lname;
                dtbirthday.Value = bday;

                txtaddress.Text = emailAd;
                txtemail.Text = email;
                if (gender == "Male")
                {
                    dbmale.Checked = true;
                }
                else
                {
                    rbfemale.Checked = true;
                }
                txtphonenumber.Text = contact;
                comboBox1.Text = schoolyr;
                cbprogram.Text = prog;

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
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
