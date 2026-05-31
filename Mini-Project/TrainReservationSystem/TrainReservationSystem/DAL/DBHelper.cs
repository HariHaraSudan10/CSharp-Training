using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.DAL
{
    internal class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            string connect = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MiniProjectDB;Integrated Security=True";
            return new SqlConnection(connect);
        }
    }
}
