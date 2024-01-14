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
    public partial class classadd : Form
    {
        bool firstClick = true;
        string newText = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        public classadd()
        {
            InitializeComponent();
        }

        private void classadd_Load(object sender, EventArgs e)
        {
            pnlAddSec.Visible = false;
            populatePrograms();
            populateSection();
            populateRooms();
            panel5.Visible = false;
            panel2.Visible = false;
            dataGridView3.DataSource = db.displayRooms();
            dataGridView4.DataSource = db.displaySections();
            dataGridView2.DataSource = db.displayClass();
            dataGridView1.DataSource = db.displayInstructors();
        }
        private void ClearText()
        {
            cbSec.Items.Clear();
            cbroom.Items.Clear();
            richTextBox1.Text = "";
            cbprogram.Items.Clear();
            cbyearlvl.Items.Clear();
        }
        //save
        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            string schedDays = " ";
            string schedTimes = " ";

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    schedDays += parts[0] + ", ";
                    schedTimes += parts[1] + ", ";
                }
            }
            schedDays = schedDays.TrimEnd(',', ' ');
            schedTimes = schedTimes.TrimEnd(',', ' ');

            string className = cbSec.Text;
            string schedRoom = cbroom.Text;
            string programName = cbprogram.Text;

            if (ValidateClassFields())
            {
                int sem = int.Parse(cbSem.Text);
                string crs = cbcourse.Text;
                int progYearlevel = Convert.ToInt32(cbyearlvl.Text);
                int insId = Convert.ToInt32(txtinsId.Text);

                db.saveClass(className, sem, crs, schedDays, schedTimes, schedRoom, programName, progYearlevel, insId);
                MessageBox.Show("Class successfully saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataGridView2.DataSource = db.displayClass();
                ClearText();
            }
            else validation();
        }
        //update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            string schedDays = " ";
            string schedTimes = " ";

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    schedDays += parts[0] + ", ";
                    schedTimes += parts[1] + ", ";
                }
            }
            schedDays = schedDays.TrimEnd(',', ' ');
            schedTimes = schedTimes.TrimEnd(',', ' ');

            string className = cbSec.Text;
            string schedRoom = cbroom.Text;
            string programName = cbprogram.Text;
            string clscode = textBox1.Text;

            if (ValidateClassFields())
            {
                int sem = int.Parse(cbSem.Text);
                string crs = cbcourse.Text;
                int progYearlevel = Convert.ToInt32(cbyearlvl.Text);
                int insId = Convert.ToInt32(txtinsId.Text);

                db.updateClass(clscode, className, sem, crs, schedDays, schedTimes, schedRoom, programName, progYearlevel, insId);
                MessageBox.Show("Class successfully updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataGridView2.DataSource = db.displayClass();
                ClearText();
            }
            else validation();
        }
        //delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                db.deleteClass(textBox1.Text);
                MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dataGridView2.DataSource = db.displayClass();
                ClearText();
            }
            catch
            {
                MessageBox.Show("Cannot Delete, Some Students are already enrolled in this class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //validation
        private void validation()
        {
            StringBuilder errorMessage = new StringBuilder("Invalid Class Fields:\n");

            if (!ValidateInstructorID(txtinsId.Text))
            {
                errorMessage.AppendLine("- Instructor ID");
            }

            if (!ValidateProgram(cbprogram.Text))
            {
                errorMessage.AppendLine("- Program");
            }

            if (!ValidateYearLevel(cbyearlvl.Text))
            {
                errorMessage.AppendLine("- Year Level");
            }

            if (!ValidateClassName(cbSec.Text))
            {
                errorMessage.AppendLine("- Class Name");
            }

            if (!ValidateRoom(cbroom.Text))
            {
                errorMessage.AppendLine("- Room");
            }


            if (!ValidateSemester(cbSem.Text))
            {
                errorMessage.AppendLine("- Semester");
            }

            MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void populatePrograms()
        {
            var programNames = db.checkPrograms();

            cbprogram.Items.Clear();

            foreach (var programName in programNames)
            {
                string name = programName.prog_name;

                cbprogram.Items.Add(name);
            }
            cbprogram.Refresh();
        }
        private void populateCourses()
        {

            var courseNames = db.getCourses(cbprogram.Text, int.Parse(cbyearlvl.Text), int.Parse(cbSem.Text));

            cbcourse.Items.Clear();

            foreach (var courseName in courseNames)
            {
                string name = courseName.course_name.ToString();
                cbcourse.Items.Add(name);
            }
            cbcourse.Refresh();

        }

        private void populateSection()
        {
            var classNames = db.getSections();

            cbSec.Items.Clear();

            foreach (var cls in classNames)
            {
                string name = cls.class_name;

                cbSec.Items.Add(name);
            }
            cbSec.Refresh();
        }
        private void populateRooms()
        {
            var Rooms = db.displayRooms();

            cbroom.Items.Clear();

            foreach (var cls in Rooms)
            {
                string name = cls.Room;

                cbroom.Items.Add(name);
            }
            cbroom.Refresh();
        }

        private bool ValidateProgram(string program)
        {
            return !string.IsNullOrWhiteSpace(program);
        }

        private bool ValidateYearLevel(string yearlevel)
        {
            if (int.TryParse(yearlevel, out int yearLevelValue))
            {
                return yearLevelValue >= 1 && yearLevelValue <= 4;
            }
            else return false;
        }

        private bool ValidateClassName(string section)
        {
            if (string.IsNullOrWhiteSpace(section))
            {
                return false;
            }
            return true;
        }

        private bool ValidateRoom(string room)
        {
            return !string.IsNullOrWhiteSpace(room);
        }

        private bool ValidateInstructorID(string instructorId)
        {
            return !string.IsNullOrWhiteSpace(instructorId);
        }

        private bool ValidateSemester(string semester)
        {
            if (string.IsNullOrWhiteSpace(semester))
            {
                return false;
            }
            return int.TryParse(semester, out _);
        }

        private bool ValidateClassFields()
        {
            bool isProgramValid = ValidateProgram(cbprogram.Text);
            bool isYearLevelValid = ValidateYearLevel(cbyearlvl.Text);
            bool isNameValid = ValidateClassName(cbSec.Text);
            bool isRoomValid = ValidateRoom(cbroom.Text);
            bool isInstructorIDValid = ValidateInstructorID(txtinsId.Text);
            bool isSemValid = ValidateSemester(cbSem.Text);

            return isProgramValid && isYearLevelValid && isNameValid && isRoomValid && isInstructorIDValid && isSemValid;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pnlAddSec.Visible)
            {
                pnlAddSec.Visible = false;
            }
            else
            {
                pnlAddSec.Visible = true;
            }   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel5.Visible)
            {
                panel5.Visible = false;
            }
            else
            {
                panel5.Visible = true;
                this.panel5.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtinsId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClearText();
                string existingText = richTextBox1.Text;

                richTextBox1.Text = string.IsNullOrEmpty(existingText) ? newText : $"{existingText}\n{newText}";
                textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                cbSec.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                cbcourse.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                cbprogram.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                cbyearlvl.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                cbSem.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                cbroom.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                txtinsId.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                string selectedDay = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                string selectedTimes = dataGridView2.CurrentRow.Cells[3].Value.ToString();

                string[] day = selectedDay.Split(',');
                string[] time = selectedTimes.Split(',');

                if (day.Length == time.Length)
                {
                    for (int i = 0; i < day.Length; i++)
                    {
                        string d = day[i];
                        string t = time[i];
                        richTextBox1.AppendText($"{d}, {t}");
                        richTextBox1.AppendText(Environment.NewLine);
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Schedule");
                }
                panel5.Visible = true;
            }
            catch
            {
                MessageBox.Show("Cannot Delete. This class still has student");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            txtSec.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.searchStudents(txtSearchBar.Text);
        }
        //save section
        private void btnSavesection_Click(object sender, EventArgs e)
        {
            db.saveSection(txtSec.Text);
            MessageBox.Show("Successfully Saved Section");
            populateSection();
            dataGridView4.DataSource = db.displaySections();
        }

        private void btndeletesection_Click(object sender, EventArgs e)
        {
            db.deleteSection(txtSec.Text);
            MessageBox.Show("Successfully Saved Section");
            populateSection();
            dataGridView4.DataSource = db.displaySections();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSec.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
        }
        // schedule
        private void btnaddSched_Click(object sender, EventArgs e)
        {
            string selectedDay = cbday.SelectedItem.ToString();
            string selectedStartTime = cbtime1.SelectedItem.ToString();
            string selectedEndTime = cbtime2.SelectedItem.ToString();

            newText = $"{selectedDay}, {selectedStartTime} - {selectedEndTime}";

            if (firstClick)
            {
                richTextBox1.Text = newText;
                firstClick = false;
            }
            else
            {
                richTextBox1.Text += Environment.NewLine + newText;
            }
        }

        private void btnSaveroom_Click(object sender, EventArgs e)
        {
            db.saveRoom(txtroom.Text);
            MessageBox.Show("Successfully Saved Section");
            db.displayRooms();
        }

        private void btnDeleteroom_Click(object sender, EventArgs e)
        {
            db.deleteRoom(txtroom.Text);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtroom.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aDDSTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aDDPROFESSORToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pROGRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}   
