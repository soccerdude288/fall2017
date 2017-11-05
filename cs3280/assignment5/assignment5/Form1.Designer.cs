namespace assignment5
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
            this.i_firstName = new System.Windows.Forms.TextBox();
            this.i_age = new System.Windows.Forms.TextBox();
            this.l_firstName = new System.Windows.Forms.Label();
            this.l_age = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.b_createUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // i_firstName
            // 
            this.i_firstName.Location = new System.Drawing.Point(123, 90);
            this.i_firstName.Name = "i_firstName";
            this.i_firstName.Size = new System.Drawing.Size(205, 20);
            this.i_firstName.TabIndex = 0;
            // 
            // i_age
            // 
            this.i_age.Location = new System.Drawing.Point(123, 116);
            this.i_age.Name = "i_age";
            this.i_age.Size = new System.Drawing.Size(53, 20);
            this.i_age.TabIndex = 0;
            // 
            // l_firstName
            // 
            this.l_firstName.AutoSize = true;
            this.l_firstName.Location = new System.Drawing.Point(57, 93);
            this.l_firstName.Name = "l_firstName";
            this.l_firstName.Size = new System.Drawing.Size(60, 13);
            this.l_firstName.TabIndex = 1;
            this.l_firstName.Text = "First Name:";
            this.l_firstName.Click += new System.EventHandler(this.label1_Click);
            // 
            // l_age
            // 
            this.l_age.AutoSize = true;
            this.l_age.Location = new System.Drawing.Point(88, 119);
            this.l_age.Name = "l_age";
            this.l_age.Size = new System.Drawing.Size(29, 13);
            this.l_age.TabIndex = 1;
            this.l_age.Text = "Age:";
            this.l_age.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Enter Your Information To Play";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // b_createUser
            // 
            this.b_createUser.Location = new System.Drawing.Point(123, 156);
            this.b_createUser.Name = "b_createUser";
            this.b_createUser.Size = new System.Drawing.Size(75, 23);
            this.b_createUser.TabIndex = 3;
            this.b_createUser.Text = "Submit";
            this.b_createUser.UseVisualStyleBackColor = true;
            this.b_createUser.Click += new System.EventHandler(this.b_createUser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 249);
            this.Controls.Add(this.b_createUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_age);
            this.Controls.Add(this.l_firstName);
            this.Controls.Add(this.i_age);
            this.Controls.Add(this.i_firstName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox i_firstName;
        private System.Windows.Forms.TextBox i_age;
        private System.Windows.Forms.Label l_firstName;
        private System.Windows.Forms.Label l_age;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_createUser;
    }
}

