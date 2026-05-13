using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment1_ADO
{
    internal class Question2
    {
        public static SqlConnection conn = null;
        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;
        static void Main(string[] args)
        {
            DisplayData();
            UpdateSalary();
            DisplayData();
        }

        //update salary of an employee using stored procedure
        static void UpdateSalary()
        {
            conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Employeemanagement;" +
                "Integrated Security = true ;");
            conn.Open();

            cmd = new SqlCommand("sp_updateSalbyId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Enter Employee no to update :");
            int EmployeeNo = int.Parse(Console.ReadLine());

            cmd.Parameters.AddWithValue("@Empno", EmployeeNo);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Salary updated successfully.");

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
