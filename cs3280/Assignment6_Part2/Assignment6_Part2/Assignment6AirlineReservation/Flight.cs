using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class Flight
    {
        /// <summary>
        /// Flight ID
        /// </summary>
        public String Flight_ID { get; set; }
        /// <summary>
        /// Flight Number
        /// </summary>
        public String Flight_Number { get; set; }
        /// <summary>
        /// Aircraft Type
        /// </summary>
        public String Aircraft_Type { get; set; }
        /// <summary>
        /// Flight Number + Aircraft Type
        /// (NOT STORED IN DB)
        /// </summary>
        public String Flight_Number_Aircraft_Type { get; set; }

        /// <summary>
        /// Override the ToString method so that this string is displayed in the combo box.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Flight_Number_Aircraft_Type;
        }
    }
}
