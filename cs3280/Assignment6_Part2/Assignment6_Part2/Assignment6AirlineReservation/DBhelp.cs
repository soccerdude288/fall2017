using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    class DBhelp
    {
        /// <summary>
        /// global object for database help
        /// </summary>
        clsDataAccess clsData;

        public DBhelp()
        {
            clsData = new clsDataAccess();
        }

        /// <summary>
        /// Returns all flights
        /// </summary>
        /// <returns></returns>
        public List<Flight> getAllFlights()
        {
            DataSet ds = new DataSet();
            string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
            int iRet = 0;
            ds = clsData.ExecuteSQLStatement(sSQL, ref iRet);
            List<Flight> flights = new List<Flight>();
            for (int i = 0; i < iRet; i++)
            {
                Flight flight = new Flight();
                flight.Flight_ID = ds.Tables[0].Rows[i][0].ToString();
                flight.Flight_Number = ds.Tables[0].Rows[i][1].ToString();
                flight.Aircraft_Type = ds.Tables[0].Rows[i][2].ToString();
                flight.Flight_Number_Aircraft_Type = flight.Flight_Number + " " + flight.Aircraft_Type;
                flights.Add(flight);
            }
            return flights;
        }

        /// <summary>
        /// Returns all passengers for a given flight
        /// </summary>
        /// <param name="flight_ID"></param>
        /// <returns></returns>
        public List<Passenger> getFlightPassenger(String flight_ID)
        {
            List<Passenger> passengers = new List<Passenger>();
            DataSet ds = new DataSet();
            int iRet = 0;
            string sSQL = "SELECT Passenger.Passenger_ID, First_Name, Last_Name, FPL.Seat_Number " +
                              "FROM Passenger, Flight_Passenger_Link FPL " +
                              "WHERE Passenger.Passenger_ID = FPL.Passenger_ID AND " +
                              "Flight_ID = " + flight_ID;
            ds = clsData.ExecuteSQLStatement(sSQL, ref iRet);
            for (int i = 0; i < iRet; i++)
            {
                Passenger passenger = new Passenger();
                passenger.Passenger_ID = ds.Tables[0].Rows[i][0].ToString();
                passenger.First_Name = ds.Tables[0].Rows[i][1].ToString();
                passenger.Last_Name = ds.Tables[0].Rows[i][2].ToString();
                passenger.Seat_Number = ds.Tables[0].Rows[i][3].ToString();
                passenger.Full_Name = passenger.First_Name + " " + passenger.Last_Name;
                passengers.Add(passenger);
            }
                return passengers;
        }

        /// <summary>
        /// Insert a passenger
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public String insertPassenger(Passenger pass)
        {
            String FirstName = pass.First_Name;
            String LastName = pass.Last_Name;
            String newPassengerID = getNextPassengerID();
            String sSql = String.Format("INSERT INTO Passenger VALUES('{0}', '{1}', '{2}');",newPassengerID, FirstName, LastName);
            clsData.ExecuteNonQuery(sSql);
            return newPassengerID;
        }

        /// <summary>
        /// Helper method to get the next passenger ID
        /// </summary>
        /// <returns></returns>
        private String getNextPassengerID()
        {
            String sSql = "SELECT MAX(Passenger_ID) FROM Passenger";
            DataSet ds = new DataSet();
            int iRet = 0;
            ds = clsData.ExecuteSQLStatement(sSql, ref iRet);
            int passengerID;
            Int32.TryParse(ds.Tables[0].Rows[0][0].ToString(), out passengerID);
            passengerID++;
            return passengerID.ToString();
        }

        /// <summary>
        /// Assign a new passenger to a flight and seat
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="Flight_ID"></param>
        /// <param name="seatNum"></param>
        public void insertSeat(Passenger pass, String Flight_ID, String seatNum)
        {
            String PassengerID = pass.Passenger_ID;
            String sSql = String.Format("INSERT INTO Flight_Passenger_Link VALUES({0}, {1}, '{2}');", Flight_ID, PassengerID, seatNum);
            clsData.ExecuteNonQuery(sSql);
        }

        /// <summary>
        /// Update a passengers flight
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="seatNum"></param>
        public void updateSeat(Passenger pass, String seatNum)
        {
            String PassengerID = pass.Passenger_ID;
            String sSql = String.Format("UPDATE Flight_Passenger_Link SET Seat_Number = {0} WHERE Passenger_ID = {1};", seatNum, PassengerID);
            clsData.ExecuteNonQuery(sSql);
        }

        /// <summary>
        /// Delete a passenger and associated seat/flight
        /// </summary>
        /// <param name="pass"></param>
        public void deletePassenger(Passenger pass)
        {
            String Passenger_ID = pass.Passenger_ID;
            string sSQL = "DELETE FROM Flight_Passenger_Link " +
                   "WHERE Passenger_ID =" + Passenger_ID;
            clsData.ExecuteNonQuery(sSQL);

           sSQL = "DELETE FROM Passenger " +
                          "WHERE Passenger_ID =" + Passenger_ID;
            clsData.ExecuteNonQuery(sSQL);
            
        }
    }
}
