using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.DAL
{
    internal class UserDAL
    {
        public string Login(string username, string password)
        {
            SqlConnection con = DBHelper.GetConnection();

            string query = @"SELECT UserType
                             FROM Users
                             WHERE Username = @Username
                             AND Password = @Password";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
