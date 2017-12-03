using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Add Passenger Window
        /// </summary>
        wndAddPassenger wndAddPass;
        /// <summary>
        /// List of current passengers
        /// </summary>
        List<Passenger> passengers;
        /// <summary>
        /// List of flights
        /// </summary>
        List<Flight> flights;

        /// <summary>
        /// Constructor that initializes default values and lists
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                DBhelp dbhelper = new DBhelp();
                flights = dbhelper.getAllFlights();
                Canvas767.IsEnabled = false;
                foreach (var flight in flights)
                {
                    cbChooseFlight.Items.Add(flight);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Event for when a selected flight changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                String selection = cbChooseFlight.SelectedItem.ToString();
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;

                if (selection == "412 Boeing 767")
                {
                    CanvasA380.Visibility = Visibility.Hidden;
                    Canvas767.Visibility = Visibility.Visible;
                    Canvas767.IsEnabled = true;
                }
                else
                {
                    Canvas767.Visibility = Visibility.Hidden;
                    CanvasA380.Visibility = Visibility.Visible;
                }


                refreshPassengerList();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the passenger list for the selected flight
        /// </summary>
        private void refreshPassengerList()
        {
            DBhelp dbhelper = new DBhelp();
            Flight selFlight = (Flight)cbChooseFlight.SelectedItem;
            passengers = dbhelper.getFlightPassenger(selFlight.Flight_ID);
            cbChoosePassenger.Items.Clear();
            clearSeats(cbChooseFlight.SelectedItem.ToString());
            cmdChangeSeat.IsEnabled = false;
            cmdDeletePassenger.IsEnabled = false;
            selectUserSeats();
        }

        /// <summary>
        /// Adds passengers to the combo box and paints seat red
        /// </summary>
        private void selectUserSeats()
        {
            foreach (var passenger in passengers)
            {
                colorSeat(passenger.Seat_Number, Brushes.Red);
                cbChoosePassenger.Items.Add(passenger);
            }
        }

        /// <summary>
        /// Redraws the colors of selected seats
        /// </summary>
        private void resetColors()
        {
            foreach(var passenger in passengers)
            {
                colorSeat(passenger.Seat_Number, Brushes.Red);
                
            }
        }

        /// <summary>
        /// Disables certain form elements
        /// </summary>
        /// <param name="isDisabled"></param>
        private void isFormDisabled(bool isDisabled)
        {
            gbPassengerInformation.IsEnabled = !isDisabled;
            cmdDeletePassenger.IsEnabled = !isDisabled;
            cmdAddPassenger.IsEnabled = !isDisabled;
        }

        /// <summary>
        /// Event for when selected passenger changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                resetColors();
                cmdChangeSeat.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;
                if (cbChoosePassenger.SelectedItem != null)
                {
                    cmdChangeSeat.IsEnabled = true;
                    cmdDeletePassenger.IsEnabled = true;
                    string selection = cbChoosePassenger.SelectedItem.ToString();
                    Passenger selPassenger = (Passenger)cbChoosePassenger.SelectedItem;
                    if (selPassenger.Seat_Number != null)
                    {
                        lblPassengersSeatNumber.Content = selPassenger.Seat_Number.ToString();
                        colorSeat(selPassenger.Seat_Number, Brushes.LimeGreen);
                    }
                    else
                    {
                        isFormDisabled(true);
                    }
                }

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Returns selected passenger object
        /// </summary>
        /// <returns></returns>
        private Passenger getSelectedPassenger(){
            return (Passenger)cbChoosePassenger.SelectedItem;
        }

        /// <summary>
        /// Listener for when a seat is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SeatClick(object sender, EventArgs e)
        {
            try
            {
                cbChoosePassenger.SelectedValue = null;
                lblPassengersSeatNumber.Content = "";
                Label clicked = (Label)sender;
                foreach (var passenger in passengers)
                {   
                    if (clicked.Content.Equals(passenger.Seat_Number))
                    {
                        cbChoosePassenger.SelectedValue = passenger;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Color a seat on the canvas
        /// </summary>
        /// <param name="seat_Number"></param>
        /// <param name="color"></param>
        private void colorSeat(string seat_Number, SolidColorBrush color)
        {
            String flight = cbChooseFlight.SelectedItem.ToString();
            if (flight == "412 Boeing 767")
            {
                String controlID = "Seat" + seat_Number;
                foreach (var l in c767_Seats.Children)
                {
                    if (l.GetType() == typeof(Label))
                    {
                        Label label = (Label)l;
                        if (label.Name == controlID)
                        {
                            label.Background = color;
                        }
                    }
                }
            }
            else
            {
                String controlID = "SeatA" + seat_Number;
                foreach (var l in cA380_Seats.Children)
                {
                    if (l.GetType() == typeof(Label))
                    {
                        Label label = (Label)l;
                        if (label.Name == controlID)
                        {
                            label.Background = color;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// On click for add passenger button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger();
                wndAddPass.passengerAdded += new EventHandler(passengerAdded);
                wndAddPass.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Listener that is triggered by add passenger window for when a passenger has been added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void passengerAdded(object sender, EventArgs e)
        {
            wndAddPassenger window = (wndAddPassenger)sender;
            cbChoosePassenger.Items.Add(window.NewPass);
            cbChoosePassenger.SelectedValue = window.NewPass;
            //refreshPassengerList();
        }

        /// <summary>
        /// Generic error handler
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Set all seats to blue
        /// </summary>
        /// <param name="flight"></param>
        private void clearSeats(String flight)
        {
            if (flight == "412 Boeing 767")
            {
                foreach(var l in c767_Seats.Children)
                {
                    if(l.GetType() == typeof(Label)){
                        Label label = (Label)l;
                        label.Background = Brushes.Blue;
                    }
                    
                }
            }
            else
            {
                foreach (var l in cA380_Seats.Children)
                {
                    if (l.GetType() == typeof(Label)){
                        Label label = (Label)l;
                        label.Background = Brushes.Blue;
                    }

                }
            }
        }

        /// <summary>
        /// On click for delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            DBhelp dbhelper = new DBhelp();
            Passenger selPass = getSelectedPassenger();
            dbhelper.deletePassenger(selPass);
            refreshPassengerList();
        }

        /// <summary>
        /// On click for change seat button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            setOnClickListener();
        }

        /// <summary>
        /// Temporarily sets an onclick listener for labels when changing seat
        /// </summary>
        private void setOnClickListener()
        {
            String flight = cbChooseFlight.SelectedItem.ToString();
            if (flight == "412 Boeing 767")
            {
                foreach (var l in c767_Seats.Children)
                {
                    if (l.GetType() == typeof(Label))
                    {
                        Label label = (Label)l;
                        label.MouseLeftButtonDown += SeatChange;
                    }
                }
            }
            else
            {
                foreach (var l in cA380_Seats.Children)
                {
                    if (l.GetType() == typeof(Label))
                    {
                        Label label = (Label)l;
                        label.MouseLeftButtonDown += SeatChange;
                    }
                }
            }
        }

        /// <summary>
        /// Removes temporary onclicklistener
        /// </summary>
        private void removeOnClickListener()
        {
            foreach (var l in c767_Seats.Children)
            {
                if (l.GetType() == typeof(Label))
                {
                    Label label = (Label)l;
                    label.MouseLeftButtonDown -= SeatChange;
                }
            }
            foreach (var l in cA380_Seats.Children)
            {
                if (l.GetType() == typeof(Label))
                {
                    Label label = (Label)l;
                    label.MouseLeftButtonDown -= SeatChange;
                }
            }
        }

        /// <summary>
        /// Event handler for when seat is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeatChange(object sender, MouseButtonEventArgs e)
        {
            Label clicked = (Label)sender;
            if (clicked.Background == Brushes.Blue)
            {
                DBhelp dbhelper = new DBhelp();
                Passenger p = getSelectedPassenger();
                Flight flight = (Flight)cbChooseFlight.SelectedItem;
                if (p.Seat_Number != null)
                {
                    dbhelper.updateSeat(p, clicked.Content.ToString());
                    
                }
                else
                {
                    dbhelper.insertSeat(p, flight.Flight_ID, clicked.Content.ToString());
                    isFormDisabled(false);
                }
                //update selected seat
                //remove listener
                removeOnClickListener();
                //redraw seat display
                refreshPassengerList();

            }
            else
            {
                MessageBox.Show("Seat Already Occupied", "Occupied Seat", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
