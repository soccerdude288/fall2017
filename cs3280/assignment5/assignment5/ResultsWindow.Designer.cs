namespace assignment5
{
    partial class ResultsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsWindow));
            this.btn_MainMenu = new System.Windows.Forms.Button();
            this.l_time = new System.Windows.Forms.Label();
            this.l_score = new System.Windows.Forms.Label();
            this.v_time = new System.Windows.Forms.Label();
            this.v_score = new System.Windows.Forms.Label();
            this.p_victory = new System.Windows.Forms.PictureBox();
            this.p_defeat = new System.Windows.Forms.PictureBox();
            this.l_resultMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p_victory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_defeat)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_MainMenu
            // 
            this.btn_MainMenu.Location = new System.Drawing.Point(420, 150);
            this.btn_MainMenu.Name = "btn_MainMenu";
            this.btn_MainMenu.Size = new System.Drawing.Size(75, 23);
            this.btn_MainMenu.TabIndex = 0;
            this.btn_MainMenu.Text = "Main Menu";
            this.btn_MainMenu.UseVisualStyleBackColor = true;
            this.btn_MainMenu.Click += new System.EventHandler(this.btn_MainMenu_Click);
            // 
            // l_time
            // 
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(417, 117);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(60, 13);
            this.l_time.TabIndex = 1;
            this.l_time.Text = "Total Time:";
            // 
            // l_score
            // 
            this.l_score.AutoSize = true;
            this.l_score.Location = new System.Drawing.Point(420, 134);
            this.l_score.Name = "l_score";
            this.l_score.Size = new System.Drawing.Size(41, 13);
            this.l_score.TabIndex = 2;
            this.l_score.Text = "Score: ";
            this.l_score.Click += new System.EventHandler(this.l_correctCount_Click);
            // 
            // v_time
            // 
            this.v_time.AutoSize = true;
            this.v_time.Location = new System.Drawing.Point(484, 117);
            this.v_time.Name = "v_time";
            this.v_time.Size = new System.Drawing.Size(0, 13);
            this.v_time.TabIndex = 3;
            this.v_time.Click += new System.EventHandler(this.v_time_Click);
            // 
            // v_score
            // 
            this.v_score.AutoSize = true;
            this.v_score.Location = new System.Drawing.Point(484, 134);
            this.v_score.Name = "v_score";
            this.v_score.Size = new System.Drawing.Size(0, 13);
            this.v_score.TabIndex = 4;
            // 
            // p_victory
            // 
            this.p_victory.Image = ((System.Drawing.Image)(resources.GetObject("p_victory.Image")));
            this.p_victory.Location = new System.Drawing.Point(29, 12);
            this.p_victory.Name = "p_victory";
            this.p_victory.Size = new System.Drawing.Size(281, 391);
            this.p_victory.TabIndex = 5;
            this.p_victory.TabStop = false;
            // 
            // p_defeat
            // 
            this.p_defeat.Image = ((System.Drawing.Image)(resources.GetObject("p_defeat.Image")));
            this.p_defeat.Location = new System.Drawing.Point(12, 9);
            this.p_defeat.Name = "p_defeat";
            this.p_defeat.Size = new System.Drawing.Size(373, 338);
            this.p_defeat.TabIndex = 6;
            this.p_defeat.TabStop = false;
            // 
            // l_resultMessage
            // 
            this.l_resultMessage.AutoSize = true;
            this.l_resultMessage.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_resultMessage.Location = new System.Drawing.Point(420, 53);
            this.l_resultMessage.Name = "l_resultMessage";
            this.l_resultMessage.Size = new System.Drawing.Size(64, 28);
            this.l_resultMessage.TabIndex = 7;
            this.l_resultMessage.Text = "label1";
            // 
            // ResultsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 417);
            this.Controls.Add(this.l_resultMessage);
            this.Controls.Add(this.p_defeat);
            this.Controls.Add(this.p_victory);
            this.Controls.Add(this.v_score);
            this.Controls.Add(this.v_time);
            this.Controls.Add(this.l_score);
            this.Controls.Add(this.l_time);
            this.Controls.Add(this.btn_MainMenu);
            this.Name = "ResultsWindow";
            ((System.ComponentModel.ISupportInitialize)(this.p_victory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_defeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_MainMenu;
        private System.Windows.Forms.Label l_time;
        private System.Windows.Forms.Label l_score;
        private System.Windows.Forms.Label v_time;
        private System.Windows.Forms.Label v_score;
        private System.Windows.Forms.PictureBox p_victory;
        private System.Windows.Forms.PictureBox p_defeat;
        private System.Windows.Forms.Label l_resultMessage;
    }
}