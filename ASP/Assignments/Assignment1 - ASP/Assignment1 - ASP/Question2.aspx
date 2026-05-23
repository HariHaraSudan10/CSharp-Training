<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Assignment1___ASP.Question2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Select a product</h2>

            <asp:DropDownList 
                ID="ddlProducts" 
                runat="server" 
                AutoPostBack="True" 
                OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                <asp:ListItem Text="--Select a product--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Play Station 5" Value="50000"></asp:ListItem>
                <asp:ListItem Text="Messi 2006 ARG Jersey" Value="12999"></asp:ListItem>
                <asp:ListItem Text="Katana Shusui" Value="1500"></asp:ListItem>
                <asp:ListItem Text="MoYu WeiLong WR M 3x3" Value="2200"></asp:ListItem>
                <asp:ListItem Text="Molten V5M5000" Value="9999"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Image ID="imgProduct" runat="server" Width="250px" Height="200px"/>
            <br />
            <br />
            <asp:Button ID="btnPrice" runat="server" Text="Get Price" OnClick="btnPrice_Click" />

            <br />
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="" Font-Bold="true" ForeColor="blue"></asp:Label>

        </div>
    </form>
</body>
</html>
