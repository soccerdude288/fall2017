namespace assignment5
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.b_addition = new System.Windows.Forms.Button();
            this.b_subtraction = new System.Windows.Forms.Button();
            this.b_multiplication = new System.Windows.Forms.Button();
            this.b_division = new System.Windows.Forms.Button();
            this.b_editUser = new System.Windows.Forms.Button();
            this.l_name = new System.Windows.Forms.Label();
            this.l_age = new System.Windows.Forms.Label();
            this.v_name = new System.Windows.Forms.Label();
            this.v_age = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // b_addition
            // 
            this.b_addition.Location = new System.Drawing.Point(30, 269);
            this.b_addition.Name = "b_addition";
            this.b_addition.Size = new System.Drawing.Size(75, 23);
            this.b_addition.TabIndex = 0;
            this.b_addition.Text = "Addition";
            this.b_addition.UseVisualStyleBackColor = true;
            this.b_addition.Click += new System.EventHandler(this.b_addition_Click);
            // 
            // b_subtraction
            // 
            this.b_subtraction.Location = new System.Drawing.Point(111, 268);
            this.b_subtraction.Name = "b_subtraction";
            this.b_subtraction.Size = new System.Drawing.Size(75, 23);
            this.b_subtraction.TabIndex = 1;
            this.b_subtraction.Text = "Subtraction";
            this.b_subtraction.UseVisualStyleBackColor = true;
            this.b_subtraction.Click += new System.EventHandler(this.b_subtraction_Click);
            // 
            // b_multiplication
            // 
            this.b_multiplication.Location = new System.Drawing.Point(192, 269);
            this.b_multiplication.Name = "b_multiplication";
            this.b_multiplication.Size = new System.Drawing.Size(81, 23);
            this.b_multiplication.TabIndex = 2;
            this.b_multiplication.Text = "Multiplication";
            this.b_multiplication.UseVisualStyleBackColor = true;
            this.b_multiplication.Click += new System.EventHandler(this.b_multiplication_Click);
            // 
            // b_division
            // 
            this.b_division.Location = new System.Drawing.Point(279, 269);
            this.b_division.Name = "b_division";
            this.b_division.Size = new System.Drawing.Size(75, 23);
            this.b_division.TabIndex = 3;
            this.b_division.Text = "Division";
            this.b_division.UseVisualStyleBackColor = true;
            this.b_division.Click += new System.EventHandler(this.b_division_Click);
            // 
            // b_editUser
            // 
            this.b_editUser.Location = new System.Drawing.Point(30, 187);
            this.b_editUser.Name = "b_editUser";
            this.b_editUser.Size = new System.Drawing.Size(75, 23);
            this.b_editUser.TabIndex = 4;
            this.b_editUser.Text = "Edit User";
            this.b_editUser.UseVisualStyleBackColor = true;
            this.b_editUser.Click += new System.EventHandler(this.b_editUser_Click);
            // 
            // l_name
            // 
            this.l_name.AutoSize = true;
            this.l_name.Location = new System.Drawing.Point(37, 213);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(38, 13);
            this.l_name.TabIndex = 5;
            this.l_name.Text = "Name:";
            // 
            // l_age
            // 
            this.l_age.AutoSize = true;
            this.l_age.Location = new System.Drawing.Point(40, 230);
            this.l_age.Name = "l_age";
            this.l_age.Size = new System.Drawing.Size(29, 13);
            this.l_age.TabIndex = 6;
            this.l_age.Text = "Age:";
            // 
            // v_name
            // 
            this.v_name.AutoSize = true;
            this.v_name.Location = new System.Drawing.Point(82, 213);
            this.v_name.Name = "v_name";
            this.v_name.Size = new System.Drawing.Size(0, 13);
            this.v_name.TabIndex = 7;
            // 
            // v_age
            // 
            this.v_age.AutoSize = true;
            this.v_age.Location = new System.Drawing.Point(76, 230);
            this.v_age.Name = "v_age";
            this.v_age.Size = new System.Drawing.Size(0, 13);
            this.v_age.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(131, -48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 196);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 46);
            this.label1.TabIndex = 10;
            this.label1.Text = "Math Game";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.v_age);
            this.Controls.Add(this.v_name);
            this.Controls.Add(this.l_age);
            this.Controls.Add(this.l_name);
            this.Controls.Add(this.b_editUser);
            this.Controls.Add(this.b_division);
            this.Controls.Add(this.b_multiplication);
            this.Controls.Add(this.b_subtraction);
            this.Controls.Add(this.b_addition);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_addition;
        private System.Windows.Forms.Button b_subtraction;
        private System.Windows.Forms.Button b_multiplication;
        private System.Windows.Forms.Button b_division;
        private System.Windows.Forms.Button b_editUser;
        private System.Windows.Forms.Label l_name;
        private System.Windows.Forms.Label l_age;
        private System.Windows.Forms.Label v_name;
        private System.Windows.Forms.Label v_age;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}