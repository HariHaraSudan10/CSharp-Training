using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.DAL;
using TrainReservationSystem.Models;

namespace TrainReservationSystem
{
    internal class Program
    {
        static UserDAL userDAL = new UserDAL();
        static TrainDAL trainDAL = new TrainDAL();
        static BookingDAL bookingDAL = new BookingDAL();
        static CancellationDAL cancellationDAL = new CancellationDAL();

        static void Main(string[] args)
        {
            Login();
        }

        // login
        static void Login()
        {
            Console.WriteLine("===== TRAIN RESERVATION SYSTEM =====");
            Console.WriteLine();

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            string role = userDAL.Login(username, password);

            if (role == null)
            {
                Console.WriteLine("Invalid Credentials");
                return;
            }

            Console.WriteLine("\nLogin Successful. Role: " + role);

            if (role == "Admin")
                AdminMenu();
            else
                CustomerMenu();
        }

        // admin menu
        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== ADMIN MENU =====");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. View Trains");
                Console.WriteLine("3. Update Train");
                Console.WriteLine("4. Delete Train");
                Console.WriteLine("5. View Inactive Trains");
                Console.WriteLine("6. Restore Train");
                Console.WriteLine("7. Logout");
                Console.Write("Enter Choice Number: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTrain();
                        break;

                    case 2:
                        trainDAL.ViewTrains();
                        break;

                    case 3:
                        UpdateTrain();
                        break;

                    case 4:
                        DeleteTrain();
                        break;

                    case 5:
                        trainDAL.ViewInactiveTrains();
                        break;          

                    case 6:
                        Console.Write("Enter Train Number to Restore: ");
                        int trainNo = Convert.ToInt32(Console.ReadLine());
                        trainDAL.RestoreTrain(trainNo);
                        break;

                    case 7:
                        Login();
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        // customer menu
        static void CustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== CUSTOMER MENU =====");
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. View Bookings");
                Console.WriteLine("5. View Ticket");
                Console.WriteLine("6. Logout");
                Console.Write("Enter Choice Number: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        trainDAL.ViewTrains();
                        break;

                    case 2:
                        BookTicket();
                        break;

                    case 3:
                        CancelTicket();
                        break;

                    case 4:
                        bookingDAL.ViewBookings();
                        break;

                    case 5:
                        Console.Write("Enter Booking Id: ");
                        int bookingId = Convert.ToInt32(Console.ReadLine());
                        bookingDAL.ViewTicket(bookingId);
                        break; 

                    case 6:
                        Login();
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        // train methods for admin
        static void AddTrain()
        {
            Train train = new Train();

            Console.Write("Train No: ");
            train.TrainNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Train Name: ");
            train.TrainName = Console.ReadLine();

            Console.Write("From Station: ");
            train.FromStation = Console.ReadLine();

            Console.Write("To Station: ");
            train.ToStation = Console.ReadLine();

            Console.Write("Class: ");
            train.TrainClass = Console.ReadLine();

            Console.Write("Availability: ");
            train.Availability = Convert.ToInt32(Console.ReadLine());

            Console.Write("Charges: ");
            train.Charges = Convert.ToDecimal(Console.ReadLine());

            trainDAL.AddTrain(train);
        }

        static void UpdateTrain()
        {
            Console.Write("Train No: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Availability: ");
            int availability = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Charges: ");
            decimal charges = Convert.ToDecimal(Console.ReadLine());

            trainDAL.UpdateTrain(trainNo, availability, charges);
        }

        static void DeleteTrain()
        {
            Console.Write("Train No to Delete: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            trainDAL.DeleteTrain(trainNo);
        }

        // booking methods for customer
        static void BookTicket()
        {
            Booking booking = new Booking();

            booking.BookDate = DateTime.Now;

            Console.Write("Travel Date (yyyy-mm-dd): ");
            booking.TravelDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Train No: ");
            booking.TrainNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Travel Class: ");
            booking.TravelClass = Console.ReadLine();

            Console.Write("Passenger Count (Max 3): ");
            booking.PassengerCount = Convert.ToInt32(Console.ReadLine());

            bookingDAL.BookTicket(booking);
        }

        // cancellation method for customer
        static void CancelTicket()
        {
            Console.Write("Enter Booking Id: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());

            cancellationDAL.CancelTicket(bookingId);
        }
    }
}
