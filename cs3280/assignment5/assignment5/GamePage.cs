using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment5
{
    public partial class GamePage : Form
    {
        /// <summary>
        /// Game Object
        /// </summary>
        clsGame game;
        /// <summary>
        /// First Number
        /// </summary>
        int firstNum;
        /// <summary>
        /// Second Number
        /// </summary>
        int secondNum;
        /// <summary>
        /// Answer
        /// </summary>
        int answer;
        /// <summary>
        /// Sign of game
        /// </summary>
        String sign;
        /// <summary>
        /// Timer Object
        /// </summary>
        public Timer myTimer;
        /// <summary>
        /// Duration counter
        /// </summary>
        public int duration { set; get; }
        /// <summary>
        /// Constructor that sets sign, display, and timer
        /// </summary>
        /// <param name="g"></param>
        public GamePage(clsGame g)
        {
            InitializeComponent();
            game = g;
            switch(g.gt){
                case (clsGame.gameType.ADD):
                    sign = "+";
                    break;
                case (clsGame.gameType.SUB):
                    sign = "-";
                    break;
                case (clsGame.gameType.MUL):
                    sign = "x";
                    break;
                default:
                    sign = "/";
                    break;
            }
            duration = 0;
            myTimer = new Timer();
            myTimer.Interval = 1000;
            myTimer.Tick += myTimer_Tick;
            myTimer.Start();
            generateQuesiton();
        }
        /// <summary>
        /// Handle the timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myTimer_Tick(object sender, EventArgs e)
        {
            duration++;
            l_timer.Text = duration.ToString();
        }
        /// <summary>
        /// generates full question and updates display
        /// </summary>
        private void generateQuesiton()
        {
            game.generateQuestion();
            firstNum = game.firstNum;
            secondNum = game.secondNum;
            updateWindow();
        }
        /// <summary>
        /// updates display
        /// </summary>
        private void updateWindow()
        {
            l_numOne.Text = firstNum.ToString();
            l_numTwo.Text = secondNum.ToString();
            l_sign.Text = sign;
            v_answer.Text = null;
            l_result.BackColor = Color.Transparent;
            l_result.Text = null;
        }
        /// <summary>
        /// Validates input and checks question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NextQuestion_Click(object sender, EventArgs e)
        {
            int userVal;
            if (int.TryParse(v_answer.Text, out userVal))
            {
                answer = userVal;
                game.answer = answer;
                if (game.checkUserAnswer())
                {
                    l_result.BackColor = Color.Green;
                    l_result.Text = "Correct Answer!";
                }
                else
                {
                    l_result.BackColor = Color.Red;
                    l_result.Text = "Incorrect Answer...";
                }
                l_result.Refresh();
                System.Threading.Thread.Sleep(1500);
                if (game.qNum <= 10)
                {
                    generateQuesiton();
                }
                else
                {
                    ResultsWindow rw = new ResultsWindow(game, duration);
                    rw.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Answer Must Be a Number.");
            }
        }
    }
}
