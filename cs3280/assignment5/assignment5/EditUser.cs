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
    public partial class EditUser : Form
    {
        /// <summary>
        /// User Object passed in
        /// </summary>
        clsUser user;
        /// <summary>
        /// Main Menu object passed in
        /// </summary>
        MainMenu mm;
        /// <summary>
        /// Constructor that sets display and main menu
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="mm"></param>
        public EditUser(clsUser usr, MainMenu mm)
        {
            InitializeComponent();
            user = usr;
            this.mm = mm;
            i_age.Text = usr.age.ToString();
            i_firstName.Text = usr.uName;
        }
        /// <summary>
        /// On click validates input as well as updates parent MM window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_createUser_Click(object sender, EventArgs e)
        {
            int userVal;
            if (int.TryParse(i_age.Text, out userVal))
            {             
                user.uName = i_firstName.Text;
                user.age = userVal;
                mm.updateUserInfo();
                this.Close();
            }
            else
            {
                MessageBox.Show("Age Must Be a Number.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
