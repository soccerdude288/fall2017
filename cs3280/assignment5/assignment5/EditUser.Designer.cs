namespace assignment5
{
    partial class EditUser
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
            this.b_createUser = new System.Windows.Forms.Button();
            this.l_age = new System.Windows.Forms.Label();
            this.l_firstName = new System.Windows.Forms.Label();
            this.i_age = new System.Windows.Forms.TextBox();
            this.i_firstName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_createUser
            // 
            this.b_createUser.Location = new System.Drawing.Point(77, 158);
            this.b_createUser.Name = "b_createUser";
            this.b_createUser.Size = new System.Drawing.Size(75, 23);
            this.b_createUser.TabIndex = 8;
            this.b_createUser.Text = "Submit";
            this.b_createUser.UseVisualStyleBackColor = true;
            this.b_createUser.Click += new System.EventHandler(this.b_createUser_Click);
            // 
            // l_age
            // 
            this.l_age.AutoSize = true;
            this.l_age.Location = new System.Drawing.Point(42, 121);
            this.l_age.Name = "l_age";
            this.l_age.Size = new System.Drawing.Size(29, 13);
            this.l_age.TabIndex = 6;
            this.l_age.Text = "Age:";
            // 
            // l_firstName
            // 
            this.l_firstName.AutoSize = true;
            this.l_firstName.Location = new System.Drawing.Point(11, 95);
            this.l_firstName.Name = "l_firstName";
            this.l_firstName.Size = new System.Drawing.Size(60, 13);
            this.l_firstName.TabIndex = 7;
            this.l_firstName.Text = "First Name:";
            // 
            // i_age
            // 
            this.i_age.Location = new System.Drawing.Point(77, 118);
            this.i_age.Name = "i_age";
            this.i_age.Size = new System.Drawing.Size(53, 20);
            this.i_age.TabIndex = 4;
            this.i_age.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // i_firstName
            // 
            this.i_firstName.Location = new System.Drawing.Point(77, 92);
            this.i_firstName.Name = "i_firstName";
            this.i_firstName.Size = new System.Drawing.Size(205, 20);
            this.i_firstName.TabIndex = 5;
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.b_createUser);
            this.Controls.Add(this.l_age);
            this.Controls.Add(this.l_firstName);
            this.Controls.Add(this.i_age);
            this.Controls.Add(this.i_firstName);
            this.Name = "EditUser";
            this.Text = "EditUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_createUser;
        private System.Windows.Forms.Label l_age;
        private System.Windows.Forms.Label l_firstName;
        private System.Windows.Forms.TextBox i_age;
        private System.Windows.Forms.TextBox i_firstName;
    }
}