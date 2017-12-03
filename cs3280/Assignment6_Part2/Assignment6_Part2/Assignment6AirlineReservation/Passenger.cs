using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class Passenger
    {
        /// <summary>
        /// Passenger ID
        /// </summary>
        public String Passenger_ID { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public String First_Name { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public String Last_Name { get; set; }
        /// <summary>
        /// Full Name (NOT STORED IN DB)
        /// </summary>
        public String Full_Name { get; set; }
        /// <summary>
        /// Seat Number for passenger
        /// (NOT STORED IN PASSENGER TABLE. KEPT HERE FOR SIMPLICITY)
        /// </summary>
        public String Seat_Number { get; set; }

        /// <summary>
        /// Override the ToString method so that this string is displayed in the combo box.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Full_Name;
        }
    }
}
