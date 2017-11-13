using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment6
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// db access
        /// </summary>
        clsDataAccess db = new clsDataAccess();
        /// <summary>
        /// list for plane 1 arrangement 
        /// </summary>
        List<Label> plane1;
        /// <summary>
        /// list for plane 2 arrangement
        /// </summary>
        List<Label> plane2;
        public Form1()
        {
            InitializeComponent();
            plane1 = new List<Label>();
            plane2 = new List<Label>();
            planeInit();
            hidePlane(plane1);
            hidePlane(plane2);
            //Create a DataSet to hold the data
            DataSet ds;
            disableControls();
            try
            {
                clsDBHelper dbHelp = new clsDBHelper();
                ds = dbHelp.getFlights();
            for (int i = 0; i < dbHelp.iRet; i++)
            {
                    //Add the first and last name to the list box
                    flightSelect.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// wire up all of the labels to their approrpite plane list
        /// </summary>
        private void planeInit()
        {
            plane1.Add(flight1_1);
            plane1.Add(flight1_2);
            plane1.Add(flight1_3);
            plane1.Add(flight1_4);
            plane1.Add(flight1_5);
            plane1.Add(flight1_6);
            plane1.Add(flight1_7);
            plane1.Add(flight1_8);
            plane1.Add(flight1_9);
            plane1.Add(flight1_10);
            plane1.Add(flight1_11);
            plane1.Add(flight1_12);
            plane1.Add(flight1_13);
            plane1.Add(flight1_14);
            plane1.Add(flight1_15);
            plane1.Add(flight1_16);
            plane1.Add(flight1_17);
            plane1.Add(flight1_18);
            plane1.Add(flight1_19);
            plane1.Add(flight1_20);
            plane1.Add(flight1_21);
            plane1.Add(flight1_22);
            plane1.Add(flight1_23);
            plane1.Add(flight1_24);

            plane2.Add(flight2_1);
            plane2.Add(flight2_2);
            plane2.Add(flight2_3);
            plane2.Add(flight2_4);
            plane2.Add(flight2_5);
            plane2.Add(flight2_6);
            plane2.Add(flight2_7);
            plane2.Add(flight2_8);
            plane2.Add(flight2_9);
            plane2.Add(flight2_10);
            plane2.Add(flight2_11);
            plane2.Add(flight2_12);
            plane2.Add(flight2_13);
            plane2.Add(flight2_14);
            plane2.Add(flight2_15);
            plane2.Add(flight2_16);
            plane2.Add(flight2_17);
            plane2.Add(flight2_18);
            plane2.Add(flight2_19);
            plane2.Add(flight2_20);
            plane2.Add(flight2_21);
            plane2.Add(flight2_22);
            plane2.Add(flight2_23);
            plane2.Add(flight2_24);
        }

        /// <summary>
        /// hide a given plane arrangement
        /// </summary>
        /// <param name="plane"></param>
        private void hidePlane(List<Label> plane)
        {
            for(int i = 0; i<plane1.Count; i++)
            {
                plane[i].Visible = false;
            }
        }
        /// <summary>
        /// show a given plane arrangement
        /// </summary>
        /// <param name="plane"></param>
        private void showPlane(List<Label> plane)
        {
            for (int i = 0; i < plane1.Count; i++)
            {
                plane[i].Visible = true;
            }
        }
        /// <summary>
        /// hide/show the appropriate plane arrangement
        /// </summary>
        /// <param name="index"></param>
        private void planeDisplay(int index)
        {
            switch (index)
            {
                case 1:
                    showPlane(plane1);
                    hidePlane(plane2);
                    break;
                case 2:
                    showPlane(plane2);
                    hidePlane(plane1);
                    break;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// disables controls
        /// </summary>
        private void disableControls()
        {
            passengerSelect.Enabled = false;
            seatSelect.Enabled = false;
            btn_addPassenger.Enabled = false;
            btn_changeSeat.Enabled = false;
            btn_deletePassenger.Enabled = false;
        }
        /// <summary>
        /// enables controls
        /// </summary>
        private void enableControls()
        {
            passengerSelect.Enabled = true;
            seatSelect.Enabled = true;
            btn_addPassenger.Enabled = true;
            btn_changeSeat.Enabled = true;
            btn_deletePassenger.Enabled = true;
        }
        /// <summary>
        /// Add Passenger Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            AddPassenger addP = new AddPassenger();
            addP.ShowDialog();
        }
        /// <summary>
        /// Handles the selection of a plane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flightSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableControls();
            int index = flightSelect.SelectedIndex + 1;
            DataSet ds;
            planeDisplay(index);
            flightName.Text = flightSelect.Text;
            try
            {
                //Number of return values
                clsDBHelper dbHelp = new clsDBHelper();
                //Get all the values from the Authors table
                ds = dbHelp.getPassengers(index);
                for (int i = 0; i < dbHelp.iRet; i++)
                {
                    //Add the first and last name to the list box
                    passengerSelect.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
