namespace SUPER
{
    partial class homestud
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hOMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eNROLLMENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOGOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hOMEToolStripMenuItem,
            this.pROFILEToolStripMenuItem,
            this.eNROLLMENTToolStripMenuItem,
            this.cORToolStripMenuItem,
            this.lOGOUTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(490, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hOMEToolStripMenuItem
            // 
            this.hOMEToolStripMenuItem.Name = "hOMEToolStripMenuItem";
            this.hOMEToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.hOMEToolStripMenuItem.Text = "HOME";
            this.hOMEToolStripMenuItem.Click += new System.EventHandler(this.hOMEToolStripMenuItem_Click);
            // 
            // pROFILEToolStripMenuItem
            // 
            this.pROFILEToolStripMenuItem.Name = "pROFILEToolStripMenuItem";
            this.pROFILEToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.pROFILEToolStripMenuItem.Text = "PROFILE";
            this.pROFILEToolStripMenuItem.Click += new System.EventHandler(this.pROFILEToolStripMenuItem_Click);
            // 
            // eNROLLMENTToolStripMenuItem
            // 
            this.eNROLLMENTToolStripMenuItem.Name = "eNROLLMENTToolStripMenuItem";
            this.eNROLLMENTToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.eNROLLMENTToolStripMenuItem.Text = "ENROLLMENT";
            this.eNROLLMENTToolStripMenuItem.Click += new System.EventHandler(this.eNROLLMENTToolStripMenuItem_Click);
            // 
            // cORToolStripMenuItem
            // 
            this.cORToolStripMenuItem.Name = "cORToolStripMenuItem";
            this.cORToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.cORToolStripMenuItem.Text = "COR";
            this.cORToolStripMenuItem.Click += new System.EventHandler(this.cORToolStripMenuItem_Click);
            // 
            // lOGOUTToolStripMenuItem
            // 
            this.lOGOUTToolStripMenuItem.Name = "lOGOUTToolStripMenuItem";
            this.lOGOUTToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.lOGOUTToolStripMenuItem.Text = "LOGOUT";
            this.lOGOUTToolStripMenuItem.Click += new System.EventHandler(this.lOGOUTToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 48);
            this.label2.TabIndex = 3;
            this.label2.Text = "WELCOME TO ENROLLMENT SYSTEM \r\nYOU CAN TRY IT OUT HEHE";
            // 
            // homestud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(490, 195);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "homestud";
            this.Text = "ENROLLMENT SYSTEM";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hOMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROFILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eNROLLMENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOGOUTToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}