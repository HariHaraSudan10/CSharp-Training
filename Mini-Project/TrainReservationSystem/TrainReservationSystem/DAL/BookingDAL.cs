using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.DAL
{
    internal class BookingDAL
    {
        public void BookTicket(Booking booking)
        {
            SqlConnection con = DBHelper.GetConnection();

            string trainName = "";
            string from = "";
            string to = "";
            int bookingId = 0;

            try
            {
                con.Open();

                //Check availability
                string availabilityQuery = @"SELECT Availability, Charges
                FROM TrainDetails
                WHERE TrainNo = @TrainNo
                AND IsDeleted = 0";

                SqlCommand availabilityCmd = new SqlCommand(availabilityQuery, con);

                availabilityCmd.Parameters.AddWithValue("@TrainNo", booking.TrainNo);

                SqlDataReader reader = availabilityCmd.ExecuteReader();

                int availableSeats = 0;
                decimal charges = 0;

                if (reader.Read())
                {
                    availableSeats = Convert.ToInt32(reader["Availability"]);
                    charges = Convert.ToDecimal(reader["Charges"]);
                }
                else
                {
                    reader.Close();
                    Console.WriteLine("Train Not Found");
                    return;
                }

                reader.Close();

                //Validate passengers
                if (booking.PassengerCount > 3)
                {
                    Console.WriteLine("Maximum 3 Passengers Allowed");
                    return;
                }

                //Check seats
                if (booking.PassengerCount > availableSeats)
                {
                    Console.WriteLine("Insufficient Seats Available");
                    return;
                }

                //Calculate amount
                booking.Amount = booking.PassengerCount * charges;

                //Insert into database
                string insertQuery = @"INSERT INTO BookingDetails
                (BookDate, TravelDate, TrainNo, TravelClass, PassengerCount, Amount, Status)
                VALUES
                (@BookDate, @TravelDate, @TrainNo, @TravelClass, @PassengerCount, @Amount, 'Booked');

                SELECT SCOPE_IDENTITY();";

                SqlCommand insertCmd = new SqlCommand(insertQuery, con);

                insertCmd.Parameters.AddWithValue("@BookDate", booking.BookDate);
                insertCmd.Parameters.AddWithValue("@TravelDate", booking.TravelDate);
                insertCmd.Parameters.AddWithValue("@TrainNo", booking.TrainNo);
                insertCmd.Parameters.AddWithValue("@TravelClass", booking.TravelClass);
                insertCmd.Parameters.AddWithValue("@PassengerCount", booking.PassengerCount);
                insertCmd.Parameters.AddWithValue("@Amount", booking.Amount);

                bookingId = Convert.ToInt32(insertCmd.ExecuteScalar());

                //Get train details
                string trainQuery = @"SELECT TrainName, FromStation, ToStation
                FROM TrainDetails
                WHERE TrainNo = @TrainNo";

                SqlCommand trainCmd = new SqlCommand(trainQuery, con);
                trainCmd.Parameters.AddWithValue("@TrainNo", booking.TrainNo);

                SqlDataReader tReader = trainCmd.ExecuteReader();

                if (tReader.Read())
                {
                    trainName = tReader["TrainName"].ToString();
                    from = tReader["FromStation"].ToString();
                    to = tReader["ToStation"].ToString();
                }

                tReader.Close();

                //Update availability
                string updateQuery = @"UPDATE TrainDetails
                SET Availability = Availability - @PassengerCount
                WHERE TrainNo = @TrainNo";

                SqlCommand updateCmd = new SqlCommand(updateQuery, con);

                updateCmd.Parameters.AddWithValue("@PassengerCount", booking.PassengerCount);
                updateCmd.Parameters.AddWithValue("@TrainNo", booking.TrainNo);

                updateCmd.ExecuteNonQuery();

                Console.WriteLine("\nTicket Booked Successfully");
                Console.WriteLine("Total Amount : " + booking.Amount);

                //Print ticket
                Console.WriteLine("\n================ TICKET CONFIRMATION ================");
                Console.WriteLine("Booking ID : " + bookingId);
                Console.WriteLine("Train No   : " + booking.TrainNo);
                Console.WriteLine("Train Name : " + trainName);
                Console.WriteLine("From       : " + from);
                Console.WriteLine("To         : " + to);
                Console.WriteLine("Travel Date: " + booking.TravelDate.ToShortDateString());
                Console.WriteLine("Class      : " + booking.TravelClass);
                Console.WriteLine("Passengers : " + booking.PassengerCount);
                Console.WriteLine("Total Amt  : " + booking.Amount);
                Console.WriteLine("=====================================================\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void ViewBookings()
        {
            SqlConnection con = DBHelper.GetConnection();

            string query = @"SELECT * FROM BookingDetails";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine();
                Console.WriteLine("BOOKING DETAILS");
                Console.WriteLine("---------------------------------------------------------------------");

                Console.WriteLine("Id\tBookDate\tTravelDate\tTrainNo\tClass\tPassengers\tAmount");

                while (reader.Read())
                {
                    Console.WriteLine(
                        reader["BookingId"] + "\t" +
                        Convert.ToDateTime(reader["BookDate"]).ToShortDateString() + "\t" +
                        Convert.ToDateTime(reader["TravelDate"]).ToShortDateString() + "\t" +
                        reader["TrainNo"] + "\t" +
                        reader["TravelClass"] + "\t" +
                        reader["PassengerCount"] + "\t" +
                        reader["Amount"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void ViewTicket(int bookingId)
        {
            SqlConnection con = DBHelper.GetConnection();

            string query = @"
        SELECT
            b.BookingId,
            b.BookDate,
            b.TravelDate,
            b.TrainNo,
            t.TrainName,
            t.FromStation,
            t.ToStation,
            b.TravelClass,
            b.PassengerCount,
            b.Amount,
            b.status
        FROM BookingDetails b
        INNER JOIN TrainDetails t
            ON b.TrainNo = t.TrainNo
        WHERE b.BookingId = @BookingId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BookingId", bookingId);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine("\n================ TICKET DETAILS ================");

                    Console.WriteLine("Booking ID : " + reader["BookingId"]);
                    Console.WriteLine("Train No   : " + reader["TrainNo"]);
                    Console.WriteLine("Train Name : " + reader["TrainName"]);
                    Console.WriteLine("From       : " + reader["FromStation"]);
                    Console.WriteLine("To         : " + reader["ToStation"]);
                    Console.WriteLine("Book Date  : " + Convert.ToDateTime(reader["BookDate"]).ToShortDateString());
                    Console.WriteLine("Travel Date: " + Convert.ToDateTime(reader["TravelDate"]).ToShortDateString());
                    Console.WriteLine("Class      : " + reader["TravelClass"]);
                    Console.WriteLine("Passengers : " + reader["PassengerCount"]);
                    Console.WriteLine("Total Amt  : " + reader["Amount"]);
                    Console.WriteLine("Status : " + reader["Status"]); 
                    if (reader["Status"].ToString() == "Cancelled") 
                    { 
                        Console.WriteLine(); Console.WriteLine("*** THIS TICKET HAS BEEN CANCELLED ***"); 
                    }

                    Console.WriteLine("================================================");
                }
                else
                {
                    Console.WriteLine("Booking ID Not Found");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
