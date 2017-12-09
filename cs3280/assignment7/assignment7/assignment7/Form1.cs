using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using assignment7;

namespace assignment7
{
    public partial class Form1 : Form
    {
        String[] studentArray;
        int[,] assignmentArray;
        int studentIter;
        int totalStudents;
        int totalAssignments;

        public Form1()
        {
            InitializeComponent();
            toggleSections(false);
            studentIter = 0;
            scoresDisplay.WordWrap = false;
        }

        /// <summary>
        /// On Click Submit Count Button
        /// Checks for valid input
        /// Bugs user appropriatley if input is wrong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_submitCounts_Click(object sender, EventArgs e)
        {
            bool students;
            bool assignment;
            int studentsVal;
            int assignmentsVal;

            students = Int32.TryParse(i_numberOfStudents.Text, out studentsVal);
            assignment = Int32.TryParse(i_numberOfAssignments.Text, out assignmentsVal);

            //If valid int input, check that it's in proper bounds
            if(students == true)
            {
                if(studentsVal > 10 || studentsVal < 1)
                    students = false;
            }
            //If valid int input, check that it's in proper bounds
            if (assignment == true)
            {
                if(assignmentsVal > 99 || assignmentsVal < 1)
                    students = false;
            }
            
            //If input has passed both checks, unlock the remainder of the form
            //and instanciate the arrays
            if(students == true && assignment == true)
            {
                totalStudents = studentsVal;
                totalAssignments = assignmentsVal;
                toggleSections(true);
                initStudents(studentsVal);
                initAssignments(studentsVal, assignmentsVal);
                l_enterAssignmentNum.Text = "Enter Assignment Number: (1-" + assignmentsVal + ")";
                updateStudentDisplay();
            }
            //Display an error and clear the input fields
            else
            {
                MessageBox.Show("Invalid Input", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                i_numberOfAssignments.Text = "";
                i_numberOfStudents.Text = "";
            }
            
        }

        /// <summary>
        /// If true, locks majority of form.
        /// If false, unlocks majority of form.
        /// </summary>
        /// <param name="isLock"></param>
        private void toggleSections(bool isUnlocked)
        {
            sInfoBox1.Enabled = isUnlocked;
            navigateBox.Enabled = isUnlocked;
            sInfoBox2.Enabled = isUnlocked;
            b_displayScore.Enabled = isUnlocked;
            b_resetScore.Enabled = isUnlocked;
            countsBox.Enabled = !isUnlocked;
            btn_fileOutput.Enabled = isUnlocked;
            v_PathToFile.Enabled = isUnlocked;
        }

        /// <summary>
        /// Instanciate the student array
        /// </summary>
        /// <param name="students"></param>
        private void initStudents(int students)
        {
            studentArray = new String[students];
            for (int i = 0; i < students; i++) 
            {
                studentArray[i] = "Student #" + (i + 1);
            }
        }

        /// <summary>
        /// Instanciate the assignment array
        /// </summary>
        /// <param name="students"></param>
        /// <param name="assignments"></param>
        private void initAssignments(int students, int assignments)
        {
            assignmentArray = new int[students, assignments];
            for(int i = 0; i < students; i++)
            {
                for(int j = 0; j < assignments; j++)
                {
                    assignmentArray[i, j] = 0;
                }
            }
        }

        private void updateStudentDisplay()
        {
            l_studentNum.Text = studentArray[studentIter];
            i_studentNum.Text = "";
        }

        /// <summary>
        /// Set student iterator to 0
        /// Update Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_firstStudents_Click(object sender, EventArgs e)
        {
            studentIter = 0;
            updateStudentDisplay();
        }

        /// <summary>
        /// Set student iterator back one, if not already 0
        /// Update Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_prevStudent_Click(object sender, EventArgs e)
        {
            if(studentIter != 0)
            {
                studentIter--;
                updateStudentDisplay();
            }
        }

        /// <summary>
        /// Set student iterator to max
        /// Update Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_lastStudent_Click(object sender, EventArgs e)
        {
            studentIter = totalStudents -1;
            updateStudentDisplay();
        }

        /// <summary>
        /// Set student iterator forward if not already max
        /// Update Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_nextStudent_Click_1(object sender, EventArgs e)
        {
            if (studentIter != totalStudents -1)
            {
                studentIter++;
                updateStudentDisplay();
            }
        }

        /// <summary>
        /// Updates the name of the student in student array
        /// Updates display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_saveName_Click(object sender, EventArgs e)
        {
            studentArray[studentIter] = i_studentNum.Text;
            updateStudentDisplay();
        }

        /// <summary>
        /// Validates score input
        /// on good input, puts score into array
        /// else displays message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_saveScore_Click(object sender, EventArgs e)
        {
            bool assignment;
            int assignmentVal;
            bool score;
            int scoreVal;
            assignment = Int32.TryParse(i_enterAssignmentNumber.Text, out assignmentVal);
            score = Int32.TryParse(i_assignmentScore.Text, out scoreVal);
            if(assignmentVal > totalAssignments)
            {
                assignment = false;
            }
            if(assignment && score)
            {
                assignmentArray[studentIter, assignmentVal -1] = scoreVal;
            }
            else
            {
                MessageBox.Show("Invalid Input", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                i_enterAssignmentNumber.Text = "";
                i_assignmentScore.Text = "";
            }
        }

        private void b_displayScore_Click(object sender, EventArgs e)
        {
            StringBuilder outVar = new StringBuilder();
            outVar.Append("STUDENT\t\t\t");
            for(int i = 0; i < totalAssignments; i++)
            {
                outVar.Append("#" + (i + 1) + "\t");
            }
            outVar.Append("AVG\tGrade\n");

            for(int i = 0; i < totalStudents; i++)
            {
                int totalScore = 0;
                outVar.Append(studentArray[i]+"\t\t\t");
                for(int j = 0; j < totalAssignments; j++)
                {
                    totalScore += assignmentArray[i, j];
                    outVar.Append(assignmentArray[i, j] + "\t");
                }
                float avgScore = (float)totalScore / (float)totalAssignments;
                float gradeP = (float)totalScore / ((float)totalAssignments * 100);
                string letterGrade = calcGrade(gradeP);
                
                outVar.Append(avgScore + "\t");
                outVar.Append(letterGrade + "\n");
            }

            scoresDisplay.Text = outVar.ToString();
        }

        /// <summary>
        /// Calculates the letter grade of a float < 1
        /// </summary>
        /// <param name="gradeP"></param>
        /// <returns></returns>
        private string calcGrade(float gradeP)
        {
            String letterGrade = "";

            if (gradeP < .6)
            {
                letterGrade = "E";
            }
            else if (gradeP < .629)
            {
                letterGrade = "D-";
            }
            else if (gradeP < .669)
            {
                letterGrade = "D";
            }
            else if (gradeP < .699)
            {
                letterGrade = "D+";
            }
            else if (gradeP < .729)
            {
                letterGrade = "C-";
            }
            else if (gradeP < .769)
            {
                letterGrade = "C-";
            }
            else if (gradeP < .799)
            {
                letterGrade = "C+";
            }
            else if (gradeP < .829)
            {
                letterGrade = "B-";
            }
            else if (gradeP < .869)
            {
                letterGrade = "B";
            }
            else if (gradeP < .899)
            {
                letterGrade = "B+";
            }
            else if (gradeP < .929)
            {
                letterGrade = "A-";
            }
            else
            {
                letterGrade = "A";
            }
            return letterGrade;
        }

        /// <summary>
        /// Resets program to initial state
        /// </summary>
        /// <param name="sender"></param>eeee
        /// <param name="e"></param>
        private void b_resetScore_Click(object sender, EventArgs e)
        {
            scoresDisplay.Text = "";
            toggleSections(false);
            studentIter = 0;
        }

        private String getFileOutput()
        {
            StringBuilder outVar = new StringBuilder();
            outVar.Append("STUDENT\t\t\t");
            for (int i = 0; i < totalAssignments; i++)
            {
                outVar.Append("#" + (i + 1) + "\t");
            }
            outVar.Append("AVG\tGrade\n");

            for (int i = 0; i < totalStudents; i++)
            {
                int totalScore = 0;
                outVar.Append(studentArray[i] + "\t\t\t");
                for (int j = 0; j < totalAssignments; j++)
                {
                    totalScore += assignmentArray[i, j];
                    outVar.Append(assignmentArray[i, j] + "\t");
                }
                float avgScore = (float)totalScore / (float)totalAssignments;
                float gradeP = (float)totalScore / ((float)totalAssignments * 100);
                string letterGrade = calcGrade(gradeP);

                outVar.Append(avgScore + "\t");
                outVar.Append(letterGrade + "\n");
            }
            return outVar.ToString();
        }

        private void btn_fileOutput_Click(object sender, EventArgs e)
        {

            l_outputStatus.Text = "Writing to file";
            btn_fileOutput.Enabled = false;

            String output = getFileOutput();
            String fileName = v_PathToFile.Text;

            ThreadHelper th = new ThreadHelper(output, fileName);
            Thread myThread = new Thread(th.fileOutput);
            myThread.Priority = ThreadPriority.Normal;
            myThread.Start();

            Thread.Sleep(2000);
            l_outputStatus.Text = "File written";
            btn_fileOutput.Enabled = true;
        }
    }
}
