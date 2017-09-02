/*
 * Taylor Earl
 * CS3280
 * 9/2/17
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult MyResult;

            MyResult = MessageBox.Show("You typed: " + textBox1.Text, "This Caption", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            result.Text = "You clicked the " + MyResult.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult MyResult;

            MyResult = MessageBox.Show("You typed: " + textBox2.Text, "This Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            result.Text = "You clicked the " + MyResult.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult MyResult;

            MyResult = MessageBox.Show("You typed: " + textBox3.Text, "This Caption", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            result.Text = "You clicked the " + MyResult.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
