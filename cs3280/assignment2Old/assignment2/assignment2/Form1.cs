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

namespace assignment2
{
    public partial class Form1 : Form
    {
        //Initialize all variables to be used
        //Should probably be changed to 3 arrays instead of all of the variables
        //Would be much cleaner...
        int oneGuessed;
        int twoGuessed;
        int threeGuessed;
        int fourGuessed;
        int fiveGuessed;
        int sixGuessed;
        int oneGenerated;
        int twoGenerated;
        int threeGenerated;
        int fourGenerated;
        int fiveGenerated;
        int sixGenerated;
        int numTimesPlayed = 0;
        float oneFreq;
        float twoFreq;
        float threeFreq;
        float fourFreq;
        float fiveFreq;
        float sixFreq;
        public Form1()
        {
            InitializeComponent();
            timesWon.Text = "0";
            timesPlayed.Text = "0";
            timesLost.Text = "0";
            oneGuessed = 0;
            twoGuessed = 0;
            threeGuessed = 0;
            fourGuessed = 0;
            fiveGuessed = 0;
            sixGuessed = 0;
            oneGenerated = 0;
            twoGenerated = 0;
            threeGenerated = 0;
            fourGenerated = 0;
            fiveGenerated = 0;
            sixGenerated = 0;
            oneFreq = 0;
            twoFreq = 0;
            threeFreq = 0;
            fourFreq = 0;
            fiveFreq = 0;
            sixFreq = 0;
            updateDisplay();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The Roll function.
        /// Does logic for making sure the entry is valid.
        /// Initializes the image and randomly changes it.
        /// Displays error if input is invalid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            int iNumber;
            bool result = Int32.TryParse(textBox1.Text, out iNumber);

            if (!(iNumber > 6 || iNumber < 1))
            {
                int rNum = randomNum();
                timesPlayed.Text = (int.Parse(timesPlayed.Text) + 1).ToString();
                if (iNumber == rNum)
                {
                    timesWon.Text = (int.Parse(timesWon.Text) + 1).ToString();
                }
                else
                {
                    timesLost.Text = (int.Parse(timesLost.Text) + 1).ToString();
                }

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                for (int i = 1; i < 7; i++)
                {
                    pictureBox1.Image = Image.FromFile("die" + randomNum().ToString() + ".gif");
                    pictureBox1.Refresh();
                    Thread.Sleep(300);
                }
                pictureBox1.Image = Image.FromFile("die" + rNum.ToString() + ".gif");
                calculations(rNum, iNumber);

                updatePercentages();
                updateDisplay();
            }
            else
            {
                MessageBox.Show("You must enter a number 1 - 6.", "Error");
            }
        }

        /// <summary>
        /// Generates Random Number
        /// </summary>
        /// <returns></returns>
        private int randomNum()
        {
            Random rndNum = new Random();
            int num = rndNum.Next(1, 7);
            return num;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Resets all calculations
        /// Refreshes the display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            timesWon.Text = "0";
            timesPlayed.Text = "0";
            timesLost.Text = "0";
            oneGuessed = 0;
            twoGuessed = 0;
            threeGuessed = 0;
            fourGuessed = 0;
            fiveGuessed = 0;
            sixGuessed = 0;
            oneGenerated = 0;
            twoGenerated = 0;
            threeGenerated = 0;
            fourGenerated = 0;
            fiveGenerated = 0;
            sixGenerated = 0;
            updatePercentages();
            updateDisplay();
        }

        /// <summary>
        /// Calculates the percentages of guesses.
        /// </summary>
        private void updatePercentages()
        {
            numTimesPlayed = oneGuessed + twoGuessed + threeGuessed + fourGuessed + fiveGuessed + sixGuessed;
            oneFreq = ((float)oneGuessed / (float)numTimesPlayed) * 100;
            twoFreq = ((float)twoGuessed / (float)numTimesPlayed) * 100;
            threeFreq = ((float)threeGuessed / (float)numTimesPlayed) * 100;
            fourFreq = ((float)fourGuessed / (float)numTimesPlayed) * 100;
            fiveFreq = ((float)fiveGuessed / (float)numTimesPlayed) * 100;
            sixFreq = ((float)sixGuessed / (float)numTimesPlayed) * 100;
        }

        /// <summary>
        /// Updates the display with updated values
        /// </summary>
        private void updateDisplay()
        {
            String output = "";
            output += "Face \t Frequency \t Percent \t Number of Times Guessed\n";
            output += "1 \t" + oneGenerated + "\t\t "+ oneFreq +"% \t" + oneGuessed + "\n";
            output += "2 \t" + twoGenerated + "\t\t " + twoFreq +"% \t" + twoGuessed + "\n";
            output += "3 \t" + threeGenerated + "\t\t " + threeFreq + "% \t" + threeGuessed + "\n";
            output += "4 \t" + fourGenerated + "\t\t " + fourFreq + "% \t" + fourGuessed + "\n";
            output += "5 \t" + oneGenerated + "\t\t " + fiveFreq + "% \t" + fiveGuessed + "\n";
            output += "6 \t" + fiveGenerated + "\t\t " + sixFreq + "% \t" + sixGuessed + "\n";
            outputBox.Text = output;
        }
        
        /// <summary>
        /// Tracks the input and computer guesses
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="user"></param>
        private void calculations(int computer, int user)
        {
            switch (computer)
            {
                case 1:
                    oneGenerated++;
                    break;
                case 2:
                    twoGenerated++;
                    break;
                case 3:
                    threeGenerated++;
                    break;
                case 4:
                    fourGenerated++;
                    break;
                case 5:
                    fiveGenerated++;
                    break;
                case 6:
                    sixGenerated++;
                    break;
            }
            switch (user)
            {
                case 1:
                    oneGuessed++;
                    break;
                case 2:
                    twoGuessed++;
                    break;
                case 3:
                    threeGuessed++;
                    break;
                case 4:
                    fourGuessed++;
                    break;
                case 5:
                    fiveGuessed++;
                    break;
                case 6:
                    sixGuessed++;
                    break;
            }
        }

        private void outputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
