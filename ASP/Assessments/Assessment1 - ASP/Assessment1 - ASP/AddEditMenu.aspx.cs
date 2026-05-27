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
    public partial class AddEditMenu : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["MenuId"] != null)
                {
                    LoadMenu();
                }
            }
        }

        void LoadMenu()
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@MenuId", con);

            cmd.Parameters.AddWithValue("@MenuId", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtItemName.Text = dr["ItemName"].ToString();
                txtCategory.Text = dr["Category"].ToString();
                ddlFoodType.SelectedValue = dr["FoodType"].ToString();
                txtPrice.Text = dr["Price"].ToString();
                txtQuantity.Text = dr["AvailableQuantity"].ToString();
                bool available = Convert.ToBoolean(dr["IsAvailable"]);
                if (available)
                {
                    ddlIsAvailable.SelectedValue = "Availble";
                }
                else
                {
                    ddlIsAvailable.SelectedValue = "Not Available";
                }
            }

            con.Close();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            bool isAvailable = false;

            if (ddlIsAvailable.SelectedItem.Text == "Availble")
            {
                isAvailable = true;
            }

            if (Request.QueryString["MenuId"] == null)
            {               

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MenuItems(ItemName, Category, FoodType, Price, AvailableQuantity, IsAvailable, CreatedDate) " +
                    "VALUES(@ItemName, @Category, @FoodType, @Price, @AvailableQuantity, @IsAvailable, @CreatedDate)", con);

                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@FoodType", ddlFoodType.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@AvailableQuantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
             
                int id = Convert.ToInt32(Request.QueryString["MenuId"]);

                SqlCommand cmd = new SqlCommand(
                    "UPDATE MenuItems SET " +
                    "ItemName=@ItemName, " +
                    "Category=@Category, " +
                    "FoodType=@FoodType, " +
                    "Price=@Price, " +
                    "AvailableQuantity=@AvailableQuantity, " +
                    "IsAvailable=@IsAvailable " +
                    "WHERE MenuId=@MenuId", con);

                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@FoodType", ddlFoodType.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@AvailableQuantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                cmd.Parameters.AddWithValue("@MenuId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            Response.Redirect("MenuList.aspx");
        }
    
    }
}