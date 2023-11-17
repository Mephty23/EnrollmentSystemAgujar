namespace EnrollmentSystemAgujar
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userN = new System.Windows.Forms.TextBox();
            this.passW = new System.Windows.Forms.TextBox();
            this.loginB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userN
            // 
            this.userN.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.userN.Location = new System.Drawing.Point(93, 74);
            this.userN.Name = "userN";
            this.userN.Size = new System.Drawing.Size(153, 20);
            this.userN.TabIndex = 0;
            // 
            // passW
            // 
            this.passW.Location = new System.Drawing.Point(93, 126);
            this.passW.Name = "passW";
            this.passW.Size = new System.Drawing.Size(153, 20);
            this.passW.TabIndex = 1;
            this.passW.UseSystemPasswordChar = true;
            // 
            // loginB
            // 
            this.loginB.BackColor = System.Drawing.Color.White;
            this.loginB.ForeColor = System.Drawing.Color.Black;
            this.loginB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loginB.Location = new System.Drawing.Point(141, 162);
            this.loginB.Name = "loginB";
            this.loginB.Size = new System.Drawing.Size(53, 29);
            this.loginB.TabIndex = 2;
            this.loginB.Text = "login";
            this.loginB.UseVisualStyleBackColor = false;
            this.loginB.Click += new System.EventHandler(this.loginB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "USERNAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "PASSWORD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "WELCOME!";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(343, 234);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginB);
            this.Controls.Add(this.passW);
            this.Controls.Add(this.userN);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "ENROLLMENT SYSTEM";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userN;
        private System.Windows.Forms.TextBox passW;
        private System.Windows.Forms.Button loginB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

