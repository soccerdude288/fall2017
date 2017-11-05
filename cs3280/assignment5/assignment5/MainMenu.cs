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
    public partial class MainMenu : Form
    {
        /// <summary>
        /// User Object
        /// </summary>
        public static clsUser user;

        /// <summary>
        /// Main Menu Constructor
        /// </summary>
        /// <param name="u"></param>
        public MainMenu(clsUser u)
        {
            InitializeComponent();
            user = u;
            updateUserInfo();
        }

        /// <summary>
        /// Updates User Info Display
        /// </summary>
        public void updateUserInfo()
        {
            v_name.Text = user.uName;
            v_age.Text = user.age.ToString();
        }

        /// <summary>
        /// On Click for Division Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_division_Click(object sender, EventArgs e)
        {
            clsGame game = new clsGame(clsGame.gameType.DIV);
            GamePage gp = new GamePage(game);
            gp.ShowDialog();
            this.Hide();
        }

        /// <summary>
        /// On Click for Multiplication Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_multiplication_Click(object sender, EventArgs e)
        {
            clsGame game = new clsGame(clsGame.gameType.MUL);
            GamePage gp = new GamePage(game);
            gp.ShowDialog();
            this.Hide();
        }

        /// <summary>
        /// On Click for Edit User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_editUser_Click(object sender, EventArgs e)
        {
            EditUser eu = new EditUser(user, this);
            eu.Show();
        }

        /// <summary>
        /// On Click for Addition Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_addition_Click(object sender, EventArgs e)
        {
            clsGame game = new clsGame(clsGame.gameType.ADD);
            GamePage gp = new GamePage(game);
            gp.ShowDialog();
            this.Hide();
        }

        /// <summary>
        /// On Click for Subtraction Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_subtraction_Click(object sender, EventArgs e)
        {
            clsGame game = new clsGame(clsGame.gameType.SUB);
            GamePage gp = new GamePage(game);
            gp.ShowDialog();
            this.Hide();
        }
        /// <summary>
        /// Override so that hitting the X actually closes the program rather than that window.
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
