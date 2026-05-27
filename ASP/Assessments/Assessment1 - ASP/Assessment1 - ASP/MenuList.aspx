<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="Assessment1___ASP.MenuList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Menu List&nbsp; </h2>
            &nbsp;&nbsp;

            <asp:Button ID="btnAddFood" runat="server" Text="Add New Food" PostBackUrl="~/AddEditMenu.aspx" />

            <br />

            <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="false" DataKeyNames="MenuId"
                onRowDeleting="gvMenu_RowDeleting">
                <Columns>
                     <asp:HyperLinkField
                        HeaderText="View"
                        Text="View"
                        DataNavigateUrlFields="MenuId"
                        DataNavigateUrlFormatString="MenuDetails.aspx?MenuId={0}" />

                    <asp:HyperLinkField
                        HeaderText="Edit"
                        Text="Edit"
                        DataNavigateUrlFields="MenuId"
                        DataNavigateUrlFormatString="AddEditMenu.aspx?MenuId={0}" />

                    <asp:BoundField DataField="MenuId" HeaderText="Menu ID" ReadOnly="true" />
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="FoodType" HeaderText="Food Type" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="AvailableQuantity" HeaderText="Available Quantity" />
                    <asp:BoundField DataField="IsAvailable" HeaderText="Is Available" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:dd-MM-yyyy}" />
        
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            

        </div>
    </form>
</body>
</html>
