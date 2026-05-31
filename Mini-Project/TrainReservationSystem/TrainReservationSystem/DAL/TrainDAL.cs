using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.DAL
{
    internal class TrainDAL
    {
        public void AddTrain(Train train)
        {
            SqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO TrainDetails
                            VALUES
                            (@No,@Name,@From,@To,@Class,@Avail,@Charges,0)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@No", train.TrainNo);
            cmd.Parameters.AddWithValue("@Name", train.TrainName);
            cmd.Parameters.AddWithValue("@From", train.FromStation);
            cmd.Parameters.AddWithValue("@To", train.ToStation);
            cmd.Parameters.AddWithValue("@Class", train.TrainClass);
            cmd.Parameters.AddWithValue("@Avail", train.Availability);
            cmd.Parameters.AddWithValue("@Charges", train.Charges);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Train Added Successfully");
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

        public void ViewTrains()
        {
            SqlConnection con = DBHelper.GetConnection();

            string query = @"SELECT * FROM TrainDetails WHERE IsDeleted = 0";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine();
               
                Console.WriteLine("TRAIN DETAILS");
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                Console.WriteLine(string.Format("{0,-8} {1,-20} {2,-15} {3,-15} {4,-13} {5,-10} {6,-10}",
                    "No", "Train Name", "From", "To", "Class", "Available", "Charges")
                );

                Console.WriteLine("----------------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                   

                    Console.WriteLine(
                        string.Format("{0,-8} {1,-20} {2,-15} {3,-15} {4,-13} {5,-10} {6,-10}",
                        reader["TrainNo"],
                        reader["TrainName"],
                        reader["FromStation"],
                        reader["ToStation"],
                        reader["TrainClass"],
                        reader["Availability"],
                        reader["Charges"])
                    );
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

        public void UpdateTrain(int trainNo, int availability, decimal charges)
        {
            SqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE TrainDetails
                     SET Availability = @Availability,
                         Charges = @Charges
                     WHERE TrainNo = @TrainNo
                     AND IsDeleted = 0";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Availability", availability);
            cmd.Parameters.AddWithValue("@Charges", charges);
            cmd.Parameters.AddWithValue("@TrainNo", trainNo);

            try
            {
                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    Console.WriteLine("Train Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Train Not Found");
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

        public void DeleteTrain(int trainNo)
        {
            SqlConnection con = DBHelper.GetConnection();

            try
            {
                con.Open();
                                
                string checkQuery = @"SELECT COUNT(*)
                FROM BookingDetails
                WHERE TrainNo = @TrainNo";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);

                checkCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine("Cannot Delete Train. Bookings Exist.");
                    return;
                }
                               
                string deleteQuery = @"UPDATE TrainDetails
                SET IsDeleted = 1
                WHERE TrainNo = @TrainNo";

                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);

                deleteCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                int rows = deleteCmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    Console.WriteLine("Train Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Train Not Found");
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

        public void RestoreTrain(int trainNo)
        {
            SqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE TrainDetails
                         SET IsDeleted = 0
                         WHERE TrainNo = @TrainNo";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TrainNo", trainNo);

            try
            {
                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Train Restored Successfully");
                else
                    Console.WriteLine("Train Not Found");
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

        public void ViewInactiveTrains()
        {
            SqlConnection con = DBHelper.GetConnection();

            string query =
                @"SELECT *
            FROM TrainDetails
            WHERE IsDeleted = 1";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine();
                Console.WriteLine("INACTIVE TRAIN DETAILS");
                Console.WriteLine("--------------------------------------------------------------------------------");

                Console.WriteLine("TrainNo\tTrainName\tFrom\tTo\tClass\tAvailability\tCharges");

                while (reader.Read())
                {
                    Console.WriteLine(
                        reader["TrainNo"] + "\t" +
                        reader["TrainName"] + "\t" +
                        reader["FromStation"] + "\t" +
                        reader["ToStation"] + "\t" +
                        reader["TrainClass"] + "\t" +
                        reader["Availability"] + "\t\t" +
                        reader["Charges"]);
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
