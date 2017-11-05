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
    public partial class Form1 : Form
    {
        /// <summary>
        /// Static MainMenu Object
        /// </summary>
        public static MainMenu mm;
        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// On click submit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_createUser_Click(object sender, EventArgs e)
        {
            int userVal;
            if(Int32.TryParse(i_age.Text, out userVal))
            {
                clsUser user = new clsUser();
                user.uName = i_firstName.Text;
                user.age = userVal;
                mm = new MainMenu(user);
                mm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Age Must Be a Number.");
            }
            
        }
    }
}
