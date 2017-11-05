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
    public partial class ResultsWindow : Form
    {
        /// <summary>
        /// Constructor that checks score and shows appropriate message and picture
        /// </summary>
        /// <param name="g"></param>
        /// <param name="duration"></param>
        public ResultsWindow(clsGame g, int duration)
        {
            InitializeComponent();
            if(g.correctCount > 7)
            {
                p_defeat.Hide();
                l_resultMessage.Text = "Good Job!";
            }
            else
            {
                p_victory.Hide();
                l_resultMessage.Text = "Try again for a better score!";
            }
            v_score.Text = g.correctCount.ToString();
            v_time.Text = duration.ToString();
        }

        /// <summary>
        /// Back to Main menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            Form1.mm.Show();
            this.Hide();
        }

        private void l_correctCount_Click(object sender, EventArgs e)
        {

        }

        private void v_time_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Override so that this will actually close program
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }
    }
}
