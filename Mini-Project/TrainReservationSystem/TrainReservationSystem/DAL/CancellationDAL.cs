using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.DAL
{
    internal class CancellationDAL
    {
        public void CancelTicket(int bookingId)
        {
            SqlConnection con = DBHelper.GetConnection();
            
            try
            {
                con.Open();

                //Get booking details

                string bookingQuery = @"SELECT TrainNo, PassengerCount, Status
                FROM BookingDetails
                WHERE BookingId = @BookingId";

                SqlCommand bookingCmd = new SqlCommand(bookingQuery, con);

                bookingCmd.Parameters.AddWithValue("@BookingId", bookingId);

                SqlDataReader reader = bookingCmd.ExecuteReader();

                int trainNo = 0;
                int bookedTickets = 0;
                string status = "";

                if (reader.Read())
                {
                    trainNo = Convert.ToInt32(reader["TrainNo"]);

                    bookedTickets = Convert.ToInt32(reader["PassengerCount"]);

                    status = reader["Status"].ToString();
                }
                else
                {
                    Console.WriteLine("Booking not found");
                    reader.Close();
                    return;
                }

                reader.Close();

                // Prevent cancelling already cancelled ticket

                if (status == "Cancelled")
                {
                    Console.WriteLine("This booking is already cancelled.");
                    return;
                }

                //Ask tickets to cancel

                Console.Write("Enter number of tickets to cancel (Max " + bookedTickets + "): ");

                int cancelTickets = Convert.ToInt32(Console.ReadLine());

                if (cancelTickets <= 0 || cancelTickets > bookedTickets)
                {
                    Console.WriteLine("Invalid ticket count");
                    return;
                }

                // Get ticket price

                string priceQuery = @" SELECT Charges
                FROM TrainDetails
                WHERE TrainNo = @TrainNo";

                SqlCommand priceCmd = new SqlCommand(priceQuery, con);

                priceCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                decimal ticketPrice = Convert.ToDecimal( priceCmd.ExecuteScalar());

                //Calculate refund

                decimal refund = (cancelTickets * ticketPrice) - 100;

                if (refund < 0)
                { 
                    refund = 0;
                }

                //Insert cancellation record

                string insertQuery = @"INSERT INTO CancellationDetails
                (BookingId, NoTickets, RefundAmount)
                VALUES
                (@BookingId, @NoTickets, @Refund)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, con);

                insertCmd.Parameters.AddWithValue("@BookingId", bookingId);

                insertCmd.Parameters.AddWithValue("@NoTickets", cancelTickets);

                insertCmd.Parameters.AddWithValue("@Refund", refund);
                    
                insertCmd.ExecuteNonQuery();

                //Update booking passengers

                string updateBooking = @"UPDATE BookingDetails
                SET PassengerCount =
                PassengerCount - @CancelTickets
                WHERE BookingId = @BookingId";

                SqlCommand updateBookingCmd = new SqlCommand(updateBooking, con);

                updateBookingCmd.Parameters.AddWithValue("@CancelTickets", cancelTickets);

                updateBookingCmd.Parameters.AddWithValue("@BookingId", bookingId);

                updateBookingCmd.ExecuteNonQuery();

                //Check remaining passengers

                int remainingPassengers =
                    bookedTickets - cancelTickets;

                // If all passengers cancelled, update booking status

                if (remainingPassengers == 0)
                {
                    string statusQuery = @"UPDATE BookingDetails
                    SET Status = 'Cancelled'
                    WHERE BookingId = @BookingId";

                    SqlCommand statusCmd = new SqlCommand(statusQuery, con);

                    statusCmd.Parameters.AddWithValue("@BookingId", bookingId);

                    statusCmd.ExecuteNonQuery();
                }

                // Update train availability

                string updateTrain = @"UPDATE TrainDetails
                SET Availability =
                Availability + @CancelTickets
                WHERE TrainNo = @TrainNo";

                SqlCommand updateTrainCmd = new SqlCommand(updateTrain, con);

                updateTrainCmd.Parameters.AddWithValue("@CancelTickets", cancelTickets);

                updateTrainCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                updateTrainCmd.ExecuteNonQuery();

                Console.WriteLine("\nCancellation Successful");
                Console.WriteLine("Tickets Cancelled : " + cancelTickets);

                Console.WriteLine("Refund Amount     : " + refund);

                if (remainingPassengers == 0)
                {
                    Console.WriteLine("Booking Status    : Cancelled");
                }
                else
                {
                    Console.WriteLine("Remaining Tickets : " + remainingPassengers);
                }
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
