using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment6
{
    public partial class AddPassenger : Form
    {
        public AddPassenger()
        {
            InitializeComponent();
        }
        /// <summary>
        /// to be removed...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flightBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.flightBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.reservationSystemDataSet);

        }
        /// <summary>
        /// to be removed...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPassenger_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reservationSystemDataSet.Passenger' table. You can move, or remove it, as needed.
            this.passengerTableAdapter.Fill(this.reservationSystemDataSet.Passenger);
            // TODO: This line of code loads data into the 'reservationSystemDataSet.Flight_Passenger_Link' table. You can move, or remove it, as needed.
            this.flight_Passenger_LinkTableAdapter.Fill(this.reservationSystemDataSet.Flight_Passenger_Link);
            // TODO: This line of code loads data into the 'reservationSystemDataSet.Flight' table. You can move, or remove it, as needed.
            this.flightTableAdapter.Fill(this.reservationSystemDataSet.Flight);

        }
        /// <summary>
        /// temp close on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// temp close on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
