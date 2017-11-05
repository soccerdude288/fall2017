namespace assignment5
{
    partial class GamePage
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
            this.l_numOne = new System.Windows.Forms.Label();
            this.l_sign = new System.Windows.Forms.Label();
            this.l_numTwo = new System.Windows.Forms.Label();
            this.v_answer = new System.Windows.Forms.TextBox();
            this.btn_NextQuestion = new System.Windows.Forms.Button();
            this.l_timer = new System.Windows.Forms.Label();
            this.l_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_numOne
            // 
            this.l_numOne.AutoSize = true;
            this.l_numOne.Location = new System.Drawing.Point(46, 65);
            this.l_numOne.Name = "l_numOne";
            this.l_numOne.Size = new System.Drawing.Size(35, 13);
            this.l_numOne.TabIndex = 0;
            this.l_numOne.Text = "label1";
            // 
            // l_sign
            // 
            this.l_sign.AutoSize = true;
            this.l_sign.Location = new System.Drawing.Point(88, 65);
            this.l_sign.Name = "l_sign";
            this.l_sign.Size = new System.Drawing.Size(35, 13);
            this.l_sign.TabIndex = 1;
            this.l_sign.Text = "label1";
            // 
            // l_numTwo
            // 
            this.l_numTwo.AutoSize = true;
            this.l_numTwo.Location = new System.Drawing.Point(130, 64);
            this.l_numTwo.Name = "l_numTwo";
            this.l_numTwo.Size = new System.Drawing.Size(35, 13);
            this.l_numTwo.TabIndex = 2;
            this.l_numTwo.Text = "label1";
            // 
            // v_answer
            // 
            this.v_answer.Location = new System.Drawing.Point(49, 94);
            this.v_answer.Name = "v_answer";
            this.v_answer.Size = new System.Drawing.Size(100, 20);
            this.v_answer.TabIndex = 3;
            // 
            // btn_NextQuestion
            // 
            this.btn_NextQuestion.Location = new System.Drawing.Point(155, 92);
            this.btn_NextQuestion.Name = "btn_NextQuestion";
            this.btn_NextQuestion.Size = new System.Drawing.Size(92, 23);
            this.btn_NextQuestion.TabIndex = 4;
            this.btn_NextQuestion.Text = "Next Question";
            this.btn_NextQuestion.UseVisualStyleBackColor = true;
            this.btn_NextQuestion.Click += new System.EventHandler(this.btn_NextQuestion_Click);
            // 
            // l_timer
            // 
            this.l_timer.AutoSize = true;
            this.l_timer.Location = new System.Drawing.Point(49, 176);
            this.l_timer.Name = "l_timer";
            this.l_timer.Size = new System.Drawing.Size(33, 13);
            this.l_timer.TabIndex = 5;
            this.l_timer.Text = "Timer";
            // 
            // l_result
            // 
            this.l_result.AutoSize = true;
            this.l_result.Location = new System.Drawing.Point(49, 135);
            this.l_result.Name = "l_result";
            this.l_result.Size = new System.Drawing.Size(0, 13);
            this.l_result.TabIndex = 6;
            // 
            // GamePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.l_result);
            this.Controls.Add(this.l_timer);
            this.Controls.Add(this.btn_NextQuestion);
            this.Controls.Add(this.v_answer);
            this.Controls.Add(this.l_numTwo);
            this.Controls.Add(this.l_sign);
            this.Controls.Add(this.l_numOne);
            this.Name = "GamePage";
            this.Text = "GamePage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_numOne;
        private System.Windows.Forms.Label l_sign;
        private System.Windows.Forms.Label l_numTwo;
        private System.Windows.Forms.TextBox v_answer;
        private System.Windows.Forms.Button btn_NextQuestion;
        private System.Windows.Forms.Label l_timer;
        private System.Windows.Forms.Label l_result;
    }
}