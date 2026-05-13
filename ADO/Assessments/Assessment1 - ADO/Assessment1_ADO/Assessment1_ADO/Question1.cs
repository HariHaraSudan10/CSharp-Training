using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment1_ADO
{
    internal class Question1
    {
        public static SqlConnection conn = null;
        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;
        static void Main(string[] args)
        {
            InsertData();
            DisplayData();
        }

        //insert data into the database using stored procedure
        static void InsertData()
        {
            conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Employeemanagement;" +
                "Integrated Security = true ;");
            conn.Open();

            cmd = new SqlCommand("sp_AddEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Enter Employee Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary(>25000) :");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Employee Type 'F' or 'P' (FullTime or PartTime) :");
            string type = Console.ReadLine();

            cmd.Parameters.AddWithValue("@EmpName", name);
            cmd.Parameters.AddWithValue("@Empsal", salary);
            cmd.Parameters.AddWithValue("@Emptype", type);

            cmd.ExecuteNonQuery();

        }

        //display data from the table
        static void DisplayData()
        {
            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("Employee Details :");
            Console.WriteLine("-------------------------------------------------");

            try
            {
                conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Employeemanagement;" +
                "Integrated Security = true ;");
                conn.Open();
                cmd = new SqlCommand("select * from Employee_Details");
                cmd.Connection = conn;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["Empno"] + " " + dataReader["EmpName"] + "  " + dataReader["Empsal"] + " " + dataReader["Emptype"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
