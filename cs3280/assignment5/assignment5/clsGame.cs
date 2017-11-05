using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace assignment5
{
    public class clsGame
    {
        /// <summary>
        /// An enum of possible game types
        /// </summary>
        public enum gameType { ADD, SUB, MUL, DIV};
        /// <summary>
        /// First number in equation
        /// </summary>
        public int firstNum { set; get; }
        /// <summary>
        /// Second number in equation
        /// </summary>
        public int secondNum { set; get; }
        /// <summary>
        /// Keeps track of which question we are on
        /// </summary>
        public int qNum { set; get; }
        /// <summary>
        /// Answer from user we are validating
        /// </summary>
        public int answer { set; get; }
        /// <summary>
        /// Current games type
        /// </summary>
        public gameType gt { set; get; }
        /// <summary>
        /// Tracks the current number of correct answers
        /// </summary>
        public int correctCount { set; get; }
        /// <summary>
        /// Used to generate random Numbers
        /// </summary>
        Random rnd;

        /// <summary>
        /// Constructor that takes in gametype
        /// </summary>
        /// <param name="i_gt"></param>
        public clsGame(gameType i_gt)
        {
            firstNum = 0;
            secondNum = 0;
            qNum = 1;
            answer = 0;
            gt = i_gt;
            correctCount = 0;
            rnd = new Random();
        }
        /// <summary>
        /// Generates new numbers
        /// </summary>
        public void generateQuestion()
        {
            qNum++;
            genFirstNum(gt);
            genSecondNum(gt);
        }
        

        /// <summary>
        /// Generates first number based on game type
        /// </summary>
        /// <param name="gt"></param>
        /// <returns></returns>
        private void genFirstNum(gameType gt)
        {
            if (gt.Equals(gameType.ADD))
            {
                firstNum = rnd.Next(1, 21);
            }
            else if (gt.Equals(gameType.SUB))
            {
                firstNum = rnd.Next(1, 21);
            }
            else if (gt.Equals(gameType.MUL))
            {
                firstNum = rnd.Next(1, 11);
            }
            else
            {
                int[] possible = { 4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20 };
                int index = rnd.Next(0, 11);
                firstNum = possible[index];
            }
        }

        /// <summary>
        /// Generates second number based on game type and first number
        /// </summary>
        /// <param name="gt"></param>
        /// <param name="firstNum"></param>
        /// <returns></returns>
        private void genSecondNum(gameType gt)
        {
            
            if (gt.Equals(gameType.ADD))
            {
                secondNum = rnd.Next(1, 21);
            }
            //Generate second number smaller than first number
            else if (gt.Equals(gameType.SUB))
            {
                secondNum = rnd.Next(1, firstNum);
            }
            else if (gt.Equals(gameType.MUL))
            {
                secondNum = rnd.Next(1, 11);
            }
            //use mod to find appropriate numbers to divide by
            else
            {
                if(firstNum%10 == 0)
                {
                    int[] possible = {1, 2, 10 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];                    
                }
                else if(firstNum%9 == 0)
                {
                    int[] possible = {1, 3, 9 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else if(firstNum%8 == 0)
                {
                    int[] possible = {1, 2, 4, 8 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else if(firstNum%7 == 0)
                {
                    int[] possible = { 1, 7 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else if (firstNum%6 == 0)
                {
                    int[] possible = {1, 2, 3, 6 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else if(firstNum%5 == 0)
                {
                    int[] possible = {1, 5 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else if(firstNum%4 == 0)
                {
                    int[] possible = {1, 2, 4 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else if(firstNum%3 == 0)
                {
                    int[] possible = {1, 3 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else if(firstNum%2 == 0)
                {
                    int[] possible = { 1, 2 };
                    int index = rnd.Next(1, possible.Length);
                    secondNum = possible[index];
                }
                else
                {
                    secondNum = 1;
                }
            }
        }
        /// <summary>
        /// Checks answer, increments counter, and returns true/false
        /// </summary>
        /// <returns></returns>
        public bool checkUserAnswer()
        {
            if (checkAnswer())
            {
                correctCount++;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// uses global variables to check answer to question
        /// </summary>
        /// <returns></returns>
        private bool checkAnswer()
        {
            int fNum = firstNum;
            int sNum = secondNum;
            int ans = answer;
            switch (gt)
            {
                case (gameType.ADD):
                    if(fNum + sNum == ans)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case (gameType.SUB):
                    if (fNum - sNum == ans)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case (gameType.MUL):
                    if(fNum * sNum == ans)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case (gameType.DIV):
                    if(fNum / sNum == ans)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }


    }
}
