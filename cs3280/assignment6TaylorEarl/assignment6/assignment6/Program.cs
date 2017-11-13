using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment6
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //load flights from db and populate select field
            //disable all controlls
        //when flight is selected
            //display flight number above seat selection
            //activate choose passenger select field from db based on selected flight
            //activate other buttons
        //on click add passenger
            //show add passenger form
                //First Name
                //Last Name
                //Save
                //Cancel
            

    }
}
