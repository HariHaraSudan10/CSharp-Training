using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assessment1___ASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "food@123")
            {
                Session["username"] = username;
                Session["Role"] = "Admin";

                Response.Redirect("MenuList.aspx");

            }
            else
            {
                lblMessage.Text = "Invalid login. You are not authorized.";
            }
        }
    }
}