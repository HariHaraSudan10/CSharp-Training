using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assessment1___ASP
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@MenuId", con);

            cmd.Parameters.AddWithValue("@MenuId", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Response.Write("<h2>Food Details</h2>");
                Response.Write("Item Name : " + dr["ItemName"] + "<br/>");
                Response.Write("Category : " + dr["Category"] + "<br/>");
                Response.Write("Food Type : " + dr["FoodType"] + "<br/>");
                Response.Write("Price : " + dr["Price"] + "<br/>");
                Response.Write("Quantity : " + dr["AvailableQuantity"] + "<br/>");
                Response.Write("Availability : " + (Convert.ToBoolean(dr["IsAvailable"]) ? "Available" : "Not Available") + "<br/>");
            }

            con.Close();
        }
    }
}