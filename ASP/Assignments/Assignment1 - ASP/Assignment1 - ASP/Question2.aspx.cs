using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1___ASP
{
    public partial class Question2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            lblPrice.Text = "Price : ₹ " + ddlProducts.SelectedValue;
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedItem.Text == "Play Station 5")
            {
                imgProduct.ImageUrl = "Images/ps5.jpg";
            }
            else if (ddlProducts.SelectedItem.Text == "Messi 2006 ARG Jersey")
            {
                imgProduct.ImageUrl = "Images/2006ARG.jpg";
            }
            else if (ddlProducts.SelectedItem.Text == "Katana Shusui")
            {
                imgProduct.ImageUrl = "Images/Shusui.jpg";
            }
            else if (ddlProducts.SelectedItem.Text == "MoYu WeiLong WR M 3x3")
            {
                imgProduct.ImageUrl = "Images/wrm 3x3.jpg";
            }
            else if (ddlProducts.SelectedItem.Text == "Molten V5M5000")
            {
                imgProduct.ImageUrl = "Images/Molten.jpg";
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }

        }
    }
}