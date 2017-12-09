namespace assignment7
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
            this.countsBox = new System.Windows.Forms.GroupBox();
            this.l_numberOfAssignments = new System.Windows.Forms.Label();
            this.i_numberOfAssignments = new System.Windows.Forms.TextBox();
            this.l_numberOfStudents = new System.Windows.Forms.Label();
            this.i_numberOfStudents = new System.Windows.Forms.TextBox();
            this.b_submitCounts = new System.Windows.Forms.Button();
            this.b_resetScore = new System.Windows.Forms.Button();
            this.navigateBox = new System.Windows.Forms.GroupBox();
            this.b_lastStudent = new System.Windows.Forms.Button();
            this.b_nextStudent = new System.Windows.Forms.Button();
            this.b_prevStudent = new System.Windows.Forms.Button();
            this.b_firstStudents = new System.Windows.Forms.Button();
            this.sInfoBox1 = new System.Windows.Forms.GroupBox();
            this.b_saveName = new System.Windows.Forms.Button();
            this.i_studentNum = new System.Windows.Forms.TextBox();
            this.l_studentNum = new System.Windows.Forms.Label();
            this.sInfoBox2 = new System.Windows.Forms.GroupBox();
            this.b_saveScore = new System.Windows.Forms.Button();
            this.i_assignmentScore = new System.Windows.Forms.TextBox();
            this.i_enterAssignmentNumber = new System.Windows.Forms.TextBox();
            this.l_assignmentScore = new System.Windows.Forms.Label();
            this.l_enterAssignmentNum = new System.Windows.Forms.Label();
            this.b_displayScore = new System.Windows.Forms.Button();
            this.scoresDisplay = new System.Windows.Forms.RichTextBox();
            this.btn_fileOutput = new System.Windows.Forms.Button();
            this.v_PathToFile = new System.Windows.Forms.TextBox();
            this.l_pathToFile = new System.Windows.Forms.Label();
            this.l_outputStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.countsBox.SuspendLayout();
            this.navigateBox.SuspendLayout();
            this.sInfoBox1.SuspendLayout();
            this.sInfoBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // countsBox
            // 
            this.countsBox.Controls.Add(this.l_numberOfAssignments);
            this.countsBox.Controls.Add(this.i_numberOfAssignments);
            this.countsBox.Controls.Add(this.l_numberOfStudents);
            this.countsBox.Controls.Add(this.i_numberOfStudents);
            this.countsBox.Controls.Add(this.b_submitCounts);
            this.countsBox.Location = new System.Drawing.Point(13, 13);
            this.countsBox.Name = "countsBox";
            this.countsBox.Size = new System.Drawing.Size(335, 100);
            this.countsBox.TabIndex = 0;
            this.countsBox.TabStop = false;
            this.countsBox.Text = "Counts";
            // 
            // l_numberOfAssignments
            // 
            this.l_numberOfAssignments.AutoSize = true;
            this.l_numberOfAssignments.Location = new System.Drawing.Point(9, 54);
            this.l_numberOfAssignments.Name = "l_numberOfAssignments";
            this.l_numberOfAssignments.Size = new System.Drawing.Size(121, 13);
            this.l_numberOfAssignments.TabIndex = 4;
            this.l_numberOfAssignments.Text = "Number of Assignments:";
            // 
            // i_numberOfAssignments
            // 
            this.i_numberOfAssignments.Location = new System.Drawing.Point(136, 54);
            this.i_numberOfAssignments.Name = "i_numberOfAssignments";
            this.i_numberOfAssignments.Size = new System.Drawing.Size(100, 20);
            this.i_numberOfAssignments.TabIndex = 3;
            // 
            // l_numberOfStudents
            // 
            this.l_numberOfStudents.AutoSize = true;
            this.l_numberOfStudents.Location = new System.Drawing.Point(26, 26);
            this.l_numberOfStudents.Name = "l_numberOfStudents";
            this.l_numberOfStudents.Size = new System.Drawing.Size(104, 13);
            this.l_numberOfStudents.TabIndex = 2;
            this.l_numberOfStudents.Text = "Number of Students:";
            // 
            // i_numberOfStudents
            // 
            this.i_numberOfStudents.Location = new System.Drawing.Point(136, 26);
            this.i_numberOfStudents.Name = "i_numberOfStudents";
            this.i_numberOfStudents.Size = new System.Drawing.Size(100, 20);
            this.i_numberOfStudents.TabIndex = 1;
            // 
            // b_submitCounts
            // 
            this.b_submitCounts.Location = new System.Drawing.Point(242, 37);
            this.b_submitCounts.Name = "b_submitCounts";
            this.b_submitCounts.Size = new System.Drawing.Size(84, 23);
            this.b_submitCounts.TabIndex = 0;
            this.b_submitCounts.Text = "Submit Counts";
            this.b_submitCounts.UseVisualStyleBackColor = true;
            this.b_submitCounts.Click += new System.EventHandler(this.b_submitCounts_Click);
            // 
            // b_resetScore
            // 
            this.b_resetScore.Location = new System.Drawing.Point(412, 35);
            this.b_resetScore.Name = "b_resetScore";
            this.b_resetScore.Size = new System.Drawing.Size(101, 38);
            this.b_resetScore.TabIndex = 1;
            this.b_resetScore.Text = "Reset Score";
            this.b_resetScore.UseVisualStyleBackColor = true;
            this.b_resetScore.Click += new System.EventHandler(this.b_resetScore_Click);
            // 
            // navigateBox
            // 
            this.navigateBox.Controls.Add(this.b_lastStudent);
            this.navigateBox.Controls.Add(this.b_nextStudent);
            this.navigateBox.Controls.Add(this.b_prevStudent);
            this.navigateBox.Controls.Add(this.b_firstStudents);
            this.navigateBox.Location = new System.Drawing.Point(13, 123);
            this.navigateBox.Name = "navigateBox";
            this.navigateBox.Size = new System.Drawing.Size(500, 83);
            this.navigateBox.TabIndex = 2;
            this.navigateBox.TabStop = false;
            this.navigateBox.Text = "Navigate";
            // 
            // b_lastStudent
            // 
            this.b_lastStudent.Location = new System.Drawing.Point(382, 26);
            this.b_lastStudent.Name = "b_lastStudent";
            this.b_lastStudent.Size = new System.Drawing.Size(97, 37);
            this.b_lastStudent.TabIndex = 3;
            this.b_lastStudent.Text = ">> Last Student";
            this.b_lastStudent.UseVisualStyleBackColor = true;
            this.b_lastStudent.Click += new System.EventHandler(this.b_lastStudent_Click);
            // 
            // b_nextStudent
            // 
            this.b_nextStudent.Location = new System.Drawing.Point(267, 26);
            this.b_nextStudent.Name = "b_nextStudent";
            this.b_nextStudent.Size = new System.Drawing.Size(93, 37);
            this.b_nextStudent.TabIndex = 2;
            this.b_nextStudent.Text = "> Next Student";
            this.b_nextStudent.UseVisualStyleBackColor = true;
            this.b_nextStudent.Click += new System.EventHandler(this.b_nextStudent_Click_1);
            // 
            // b_prevStudent
            // 
            this.b_prevStudent.Location = new System.Drawing.Point(145, 26);
            this.b_prevStudent.Name = "b_prevStudent";
            this.b_prevStudent.Size = new System.Drawing.Size(101, 37);
            this.b_prevStudent.TabIndex = 1;
            this.b_prevStudent.Text = "< Prev Student";
            this.b_prevStudent.UseVisualStyleBackColor = true;
            this.b_prevStudent.Click += new System.EventHandler(this.b_prevStudent_Click);
            // 
            // b_firstStudents
            // 
            this.b_firstStudents.Location = new System.Drawing.Point(25, 26);
            this.b_firstStudents.Name = "b_firstStudents";
            this.b_firstStudents.Size = new System.Drawing.Size(100, 37);
            this.b_firstStudents.TabIndex = 0;
            this.b_firstStudents.Text = "<< First Student";
            this.b_firstStudents.UseVisualStyleBackColor = true;
            this.b_firstStudents.Click += new System.EventHandler(this.b_firstStudents_Click);
            // 
            // sInfoBox1
            // 
            this.sInfoBox1.Controls.Add(this.b_saveName);
            this.sInfoBox1.Controls.Add(this.i_studentNum);
            this.sInfoBox1.Controls.Add(this.l_studentNum);
            this.sInfoBox1.Location = new System.Drawing.Point(13, 216);
            this.sInfoBox1.Name = "sInfoBox1";
            this.sInfoBox1.Size = new System.Drawing.Size(500, 78);
            this.sInfoBox1.TabIndex = 3;
            this.sInfoBox1.TabStop = false;
            this.sInfoBox1.Text = "Student Info";
            // 
            // b_saveName
            // 
            this.b_saveName.Location = new System.Drawing.Point(382, 32);
            this.b_saveName.Name = "b_saveName";
            this.b_saveName.Size = new System.Drawing.Size(75, 23);
            this.b_saveName.TabIndex = 2;
            this.b_saveName.Text = "Save Name";
            this.b_saveName.UseVisualStyleBackColor = true;
            this.b_saveName.Click += new System.EventHandler(this.b_saveName_Click);
            // 
            // i_studentNum
            // 
            this.i_studentNum.Location = new System.Drawing.Point(89, 36);
            this.i_studentNum.Name = "i_studentNum";
            this.i_studentNum.Size = new System.Drawing.Size(271, 20);
            this.i_studentNum.TabIndex = 1;
            // 
            // l_studentNum
            // 
            this.l_studentNum.AutoSize = true;
            this.l_studentNum.Location = new System.Drawing.Point(25, 38);
            this.l_studentNum.Name = "l_studentNum";
            this.l_studentNum.Size = new System.Drawing.Size(57, 13);
            this.l_studentNum.TabIndex = 0;
            this.l_studentNum.Text = "Student #:";
            // 
            // sInfoBox2
            // 
            this.sInfoBox2.Controls.Add(this.b_saveScore);
            this.sInfoBox2.Controls.Add(this.i_assignmentScore);
            this.sInfoBox2.Controls.Add(this.i_enterAssignmentNumber);
            this.sInfoBox2.Controls.Add(this.l_assignmentScore);
            this.sInfoBox2.Controls.Add(this.l_enterAssignmentNum);
            this.sInfoBox2.Location = new System.Drawing.Point(13, 305);
            this.sInfoBox2.Name = "sInfoBox2";
            this.sInfoBox2.Size = new System.Drawing.Size(500, 87);
            this.sInfoBox2.TabIndex = 4;
            this.sInfoBox2.TabStop = false;
            this.sInfoBox2.Text = "Student Info";
            // 
            // b_saveScore
            // 
            this.b_saveScore.Location = new System.Drawing.Point(267, 32);
            this.b_saveScore.Name = "b_saveScore";
            this.b_saveScore.Size = new System.Drawing.Size(75, 23);
            this.b_saveScore.TabIndex = 4;
            this.b_saveScore.Text = "Save Score";
            this.b_saveScore.UseVisualStyleBackColor = true;
            this.b_saveScore.Click += new System.EventHandler(this.b_saveScore_Click);
            // 
            // i_assignmentScore
            // 
            this.i_assignmentScore.Location = new System.Drawing.Point(191, 47);
            this.i_assignmentScore.Name = "i_assignmentScore";
            this.i_assignmentScore.Size = new System.Drawing.Size(55, 20);
            this.i_assignmentScore.TabIndex = 3;
            // 
            // i_enterAssignmentNumber
            // 
            this.i_enterAssignmentNumber.Location = new System.Drawing.Point(191, 20);
            this.i_enterAssignmentNumber.Name = "i_enterAssignmentNumber";
            this.i_enterAssignmentNumber.Size = new System.Drawing.Size(55, 20);
            this.i_enterAssignmentNumber.TabIndex = 2;
            // 
            // l_assignmentScore
            // 
            this.l_assignmentScore.AutoSize = true;
            this.l_assignmentScore.Location = new System.Drawing.Point(89, 45);
            this.l_assignmentScore.Name = "l_assignmentScore";
            this.l_assignmentScore.Size = new System.Drawing.Size(95, 13);
            this.l_assignmentScore.TabIndex = 1;
            this.l_assignmentScore.Text = "Assignment Score:";
            // 
            // l_enterAssignmentNum
            // 
            this.l_enterAssignmentNum.AutoSize = true;
            this.l_enterAssignmentNum.Location = new System.Drawing.Point(28, 20);
            this.l_enterAssignmentNum.Name = "l_enterAssignmentNum";
            this.l_enterAssignmentNum.Size = new System.Drawing.Size(132, 13);
            this.l_enterAssignmentNum.TabIndex = 0;
            this.l_enterAssignmentNum.Text = "Enter Assignment Number:";
            // 
            // b_displayScore
            // 
            this.b_displayScore.Location = new System.Drawing.Point(14, 416);
            this.b_displayScore.Name = "b_displayScore";
            this.b_displayScore.Size = new System.Drawing.Size(108, 23);
            this.b_displayScore.TabIndex = 5;
            this.b_displayScore.Text = "Display Score";
            this.b_displayScore.UseVisualStyleBackColor = true;
            this.b_displayScore.Click += new System.EventHandler(this.b_displayScore_Click);
            // 
            // scoresDisplay
            // 
            this.scoresDisplay.Location = new System.Drawing.Point(13, 448);
            this.scoresDisplay.Name = "scoresDisplay";
            this.scoresDisplay.Size = new System.Drawing.Size(546, 96);
            this.scoresDisplay.TabIndex = 6;
            this.scoresDisplay.Text = "";
            // 
            // btn_fileOutput
            // 
            this.btn_fileOutput.Location = new System.Drawing.Point(137, 416);
            this.btn_fileOutput.Name = "btn_fileOutput";
            this.btn_fileOutput.Size = new System.Drawing.Size(108, 23);
            this.btn_fileOutput.TabIndex = 7;
            this.btn_fileOutput.Text = "Output To File";
            this.btn_fileOutput.UseVisualStyleBackColor = true;
            this.btn_fileOutput.Click += new System.EventHandler(this.btn_fileOutput_Click);
            // 
            // v_PathToFile
            // 
            this.v_PathToFile.Location = new System.Drawing.Point(363, 417);
            this.v_PathToFile.Name = "v_PathToFile";
            this.v_PathToFile.Size = new System.Drawing.Size(146, 20);
            this.v_PathToFile.TabIndex = 8;
            // 
            // l_pathToFile
            // 
            this.l_pathToFile.AutoSize = true;
            this.l_pathToFile.Location = new System.Drawing.Point(363, 398);
            this.l_pathToFile.Name = "l_pathToFile";
            this.l_pathToFile.Size = new System.Drawing.Size(146, 13);
            this.l_pathToFile.TabIndex = 9;
            this.l_pathToFile.Text = "Path To File: C:\\Users\\Public";
            // 
            // l_outputStatus
            // 
            this.l_outputStatus.AutoSize = true;
            this.l_outputStatus.Location = new System.Drawing.Point(137, 397);
            this.l_outputStatus.Name = "l_outputStatus";
            this.l_outputStatus.Size = new System.Drawing.Size(0, 13);
            this.l_outputStatus.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "File Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 548);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_outputStatus);
            this.Controls.Add(this.l_pathToFile);
            this.Controls.Add(this.v_PathToFile);
            this.Controls.Add(this.btn_fileOutput);
            this.Controls.Add(this.scoresDisplay);
            this.Controls.Add(this.b_displayScore);
            this.Controls.Add(this.sInfoBox2);
            this.Controls.Add(this.sInfoBox1);
            this.Controls.Add(this.navigateBox);
            this.Controls.Add(this.b_resetScore);
            this.Controls.Add(this.countsBox);
            this.Name = "Form1";
            this.Text = "s";
            this.countsBox.ResumeLayout(false);
            this.countsBox.PerformLayout();
            this.navigateBox.ResumeLayout(false);
            this.sInfoBox1.ResumeLayout(false);
            this.sInfoBox1.PerformLayout();
            this.sInfoBox2.ResumeLayout(false);
            this.sInfoBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Grouping for Counts
        /// </summary>
        private System.Windows.Forms.GroupBox countsBox;
        /// <summary>
        /// Label for number of Assignments
        /// </summary>
        private System.Windows.Forms.Label l_numberOfAssignments;
        /// <summary>
        /// Input for number of assignments
        /// </summary>
        private System.Windows.Forms.TextBox i_numberOfAssignments;
        /// <summary>
        /// Label for number of students
        /// </summary>
        private System.Windows.Forms.Label l_numberOfStudents;
        /// <summary>
        /// Input for number of students
        /// </summary>
        private System.Windows.Forms.TextBox i_numberOfStudents;
        /// <summary>
        /// Button for submit courses
        /// </summary>
        private System.Windows.Forms.Button b_submitCounts;
        /// <summary>
        /// Button for reset scores
        /// </summary>
        private System.Windows.Forms.Button b_resetScore;
        /// <summary>
        /// Grouping for navigation
        /// </summary>
        private System.Windows.Forms.GroupBox navigateBox;
        /// <summary>
        /// Button for next student
        /// </summary>
        private System.Windows.Forms.Button b_nextStudent;
        /// <summary>
        /// Button for previous student
        /// </summary>
        private System.Windows.Forms.Button b_prevStudent;
        /// <summary>
        /// Button for first student
        /// </summary>
        private System.Windows.Forms.Button b_firstStudents;
        /// <summary>
        /// Button for last studetn
        /// </summary>
        private System.Windows.Forms.Button b_lastStudent;
        /// <summary>
        /// Grouping for first student info section
        /// </summary>
        private System.Windows.Forms.GroupBox sInfoBox1;
        /// <summary>
        /// Button for save name
        /// </summary>
        private System.Windows.Forms.Button b_saveName;
        /// <summary>
        /// Input student number
        /// </summary>
        private System.Windows.Forms.TextBox i_studentNum;
        /// <summary>
        /// Label student number
        /// </summary>
        private System.Windows.Forms.Label l_studentNum;
        /// <summary>
        /// Grouping for second student info section
        /// </summary>
        private System.Windows.Forms.GroupBox sInfoBox2;
        /// <summary>
        /// Button for save score
        /// </summary>
        private System.Windows.Forms.Button b_saveScore;
        /// <summary>
        /// Input assignment score
        /// </summary>
        private System.Windows.Forms.TextBox i_assignmentScore;
        /// <summary>
        /// Input enter assignment number
        /// </summary>
        private System.Windows.Forms.TextBox i_enterAssignmentNumber;
        /// <summary>
        /// Label for assignment score
        /// </summary>
        private System.Windows.Forms.Label l_assignmentScore;
        /// <summary>
        /// Label for enter assignment number
        /// </summary>
        private System.Windows.Forms.Label l_enterAssignmentNum;
        /// <summary>
        /// Button for display score
        /// </summary>
        private System.Windows.Forms.Button b_displayScore;
        /// <summary>
        /// Text box to display scoress
        /// </summary>
        private System.Windows.Forms.RichTextBox scoresDisplay;
        private System.Windows.Forms.Button btn_fileOutput;
        private System.Windows.Forms.TextBox v_PathToFile;
        private System.Windows.Forms.Label l_pathToFile;
        private System.Windows.Forms.Label l_outputStatus;
        private System.Windows.Forms.Label label1;
    }
}

