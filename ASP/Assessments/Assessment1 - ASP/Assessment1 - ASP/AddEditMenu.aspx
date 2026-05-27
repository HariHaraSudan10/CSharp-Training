<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditMenu.aspx.cs" Inherits="Assessment1___ASP.AddEditMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

            <table>

                <tr>
                    <td>Item Name</td>
                    <td>
                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator
                            ID="rfvItem"
                            runat="server"
                            ControlToValidate="txtItemName"
                            ErrorMessage="Item Name Required"
                            ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>Price</td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

                        <asp:RangeValidator
                            ID="rvPrice"
                            runat="server"
                            ControlToValidate="txtPrice"
                            MinimumValue="100"
                            MaximumValue="10000"
                            Type="Double"
                            ErrorMessage="Invalid Price"
                            ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>Food Type</td>
                    <td>
                        <asp:DropDownList ID="ddlFoodType" runat="server">
                            <asp:ListItem>Veg</asp:ListItem>
                            <asp:ListItem>Non-Veg</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>Quantity</td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>

                        <asp:CompareValidator
                            ID="cvQuantity"
                            runat="server"
                            ControlToValidate="txtQuantity"
                            Operator="DataTypeCheck"
                            Type="Integer"
                            ErrorMessage="Quantity is must"
                            ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>Category</td>
                    <td>
                        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>

                        <asp:RegularExpressionValidator
                            ID="revCategory"
                            runat="server"
                            ControlToValidate="txtCategory"
                            ValidationExpression="^[a-zA-Z ]+$"
                            ErrorMessage="Please enter a valid category name"
                            ForeColor="Red" />
                    </td>
                </tr>

                <tr>
                    <td>IsAvailable</td>
                    <td>
                        <asp:DropDownList ID="ddlIsAvailable" runat="server">
                            <asp:ListItem>Availble</asp:ListItem>
                            <asp:ListItem>Not Available</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave"
                            runat="server"
                            Text="Save"
                            OnClick="btnSave_Click" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
