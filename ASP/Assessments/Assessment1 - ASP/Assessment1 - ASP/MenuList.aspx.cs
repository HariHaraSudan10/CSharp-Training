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
    public partial class MenuList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadMenuItems();
            }

        }

        void LoadMenuItems()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems", con);
            SqlDataReader reader = cmd.ExecuteReader();
            gvMenuItems.DataSource = reader;
            gvMenuItems.DataBind();
            con.Close();
        }

        protected void gvMenu_RowDeleting(object sender,
            System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(
                gvMenuItems.DataKeys[e.RowIndex].Value);

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM MenuItems WHERE MenuId=@MenuId", con);

            cmd.Parameters.AddWithValue("@MenuId", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadMenuItems();
        }
    }
}