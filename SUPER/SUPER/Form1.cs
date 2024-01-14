using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;

namespace SUPER
{
    public partial class Form1 : Form
    {
        public int type;
        FaceRec faceRec = new FaceRec();
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }
        public string UserName
        {
            get { return textBox4.Text; }
        }

        private void check()
        {
            faceRec.isTrained = true;
            faceRec.getPersonName(txtname);
        }

        private void ClearText()
        {
            textBox5.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
        }
        private void ClearTextLogin()
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            signup form2 = new signup();
            form2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Password";
            textBox2.Text = "Username";
            textBox2.ForeColor = System.Drawing.Color.Gray;
            textBox1.ForeColor = System.Drawing.Color.Gray;
            pnlcreatestudent.Visible = false;
            pnlfacerecog.Visible = false;
            pnlAccounttype.Visible = false;
            panel5.Visible = true;
            this.Location = new Point(400, 160);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //create account
        private void button10_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                var existingUser = db.getUser(textBox4.Text);

                if (existingUser.Any())
                {
                    MessageBox.Show("Username already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox6.Text == textBox8.Text)
                    {
                        string acctype = (type == 0) ? "user" : "admin";
                        db.createAccount(textBox5.Text, textBox9.Text, textBox3.Text, textBox7.Text, textBox4.Text, textBox6.Text, acctype);
                        MessageBox.Show("Account created Successfully", "Account Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ClearText();
                    }
                    else
                    {
                        MessageBox.Show("Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

            if (!ValidateFirstName(textBox5.Text))
            {
                errorMessage.AppendLine("- First Name");
            }

            if (!ValidateMiddleName(textBox9.Text))
            {
                errorMessage.AppendLine("- Middle Name");
            }

            if (!ValidateLastName(textBox3.Text))
            {
                errorMessage.AppendLine("- Last Name");
            }

            if (!ValidateEmail(textBox7.Text))
            {
                errorMessage.AppendLine("- Email");
            }

            if (!ValidatePassword(textBox4.Text))
            {
                errorMessage.AppendLine("- Username");
            }

            if (!ValidatePassword(textBox6.Text))
            {
                errorMessage.AppendLine("- Password");
            }

            MessageBox.Show(errorMessage.ToString(), "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private bool ValidateUserName(string username)
        {

            return !string.IsNullOrWhiteSpace(username);
        }

        private bool ValidateEmail(string email)
        {
            string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
                return false;
            else
                return true;
        }

        private bool ValidatePassword(string password)
        {

            return !string.IsNullOrWhiteSpace(password);
        }

        private bool ValidateFields()
        {

            bool isFirstNameValid = ValidateFirstName(textBox5.Text);
            bool isMiddleNameValid = ValidateMiddleName(textBox9.Text);
            bool isLastNameValid = ValidateLastName(textBox3.Text);
            bool isUserNameValid = ValidateUserName(textBox4.Text);
            bool isEmailValid = ValidateEmail(textBox7.Text);
            bool isPasswordValid = ValidatePassword(textBox6.Text);

            return isFirstNameValid && isMiddleNameValid && isLastNameValid && isUserNameValid &&
                              isEmailValid && isPasswordValid;
        }
        //login method
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox1.Text;


            var result = db.checkUser(username, password).FirstOrDefault();

            if (result != null)
            {
                string userType = result.acc_type;

                if (userType == "user")
                {
                    homestud form = new homestud();
                    form.Show();
                    form.Location = new Point(400, 160);
                    this.Hide();
                }
                else if (userType == "admin")
                {
                    homeed form = new homeed();
                    form.Show();
                    form.Location = new Point(400, 160);
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextLogin();
            }
        }
        // user exist method
        private bool UserExists(string username)
        {
            var existingUser = db.getUser(username);
            return existingUser != null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // redirect to admin/student
        private void btnstudent_Click(object sender, EventArgs e)
        {
            pnlAccounttype.Visible = false;
            pnlcreatestudent.Visible = true;
            label20.Visible = false;
            type = 0;
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            pnlAccounttype.Visible = false;
            pnlcreatestudent.Visible = true;
            label20.Visible = true;
            type = 1;
        }
        //face recog camera
        private void button2_Click_1(object sender, EventArgs e)
        {
            pnlAccounttype.Visible = !pnlAccounttype.Visible;
        }
        //face recognition
        private void button6_Click(object sender, EventArgs e)
        {
            check();
            pnlfacerecog.Visible = true;
            panel4.Visible = false;
            panel3.Visible = true;
            panel5.Visible = false;
        }
        //face recog create
        private void button5_Click(object sender, EventArgs e)
        {
            faceRec.isTrained = false;
            pnlfacerecog.Visible = true;
            panel4.Visible = true;
            panel3.Visible = false;
            pnlcreatestudent.Visible = false;
            txtname.Visible = false;
        }
        // camera open face recog
        private void button3_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1, pictureBox2);
        }
        // face recog login
        private void button7_Click(object sender, EventArgs e)
        {
            textBox10.Text = txtname.Text;
            if (!string.IsNullOrEmpty(textBox10.Text))
            {
                var existingUser = db.getUser(textBox10.Text);
                if (UserExists(textBox10.Text))
                {
                    foreach (var s in existingUser)
                    {
                        string user = s.acc_username;
                        string pass = s.acc_password;
                        textBox2.Text = user;
                        textBox1.Text = pass;

                        button10_Click(null, EventArgs.Empty);
                    }
                }
                else
                    MessageBox.Show("Face ID not registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("No face detected or Face ID not registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // face recog registration
        private void button8_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                faceRec.Save_IMAGE(textBox4.Text);
                MessageBox.Show("Face ID Registered", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button9_Click(null, EventArgs.Empty);

            }
        }
        // back button
        private void button9_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                pnlfacerecog.Visible = false;
                pnlcreatestudent.Visible = true;

            }
            else
            {
                pnlfacerecog.Visible = false;
                panel5.Visible = true;
            }
        }
    }
}
