using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment6
{
    class clsDBHelper
    {
        /// <summary>
        /// used for db connection
        /// </summary>
        clsDataAccess db = new clsDataAccess();
        /// <summary>
        /// data set to be returned
        /// </summary>
        DataSet ds;
        /// <summary>
        /// number of return records
        /// </summary>
        public int iRet;
        /// <summary>
        /// gets all flights
        /// </summary>
        /// <returns></returns>
        public DataSet getFlights()
        {
            try
            {
                //Get all the values from the Authors table
                ds = db.ExecuteSQLStatement("SELECT * FROM Flight", ref iRet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return ds;
        }
        /// <summary>
        /// gets all passengers for a given plane index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataSet getPassengers(int index)
        {
            try
            {
                //Get all the values from the Authors table
                ds = db.ExecuteSQLStatement("SELECT * FROM Passenger pa INNER JOIN Flight_Passenger_Link fpl ON pa.Passenger_ID = fpl.Passenger_ID WHERE fpl.Flight_ID = " + index, ref iRet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return ds;
        }

    }
}
