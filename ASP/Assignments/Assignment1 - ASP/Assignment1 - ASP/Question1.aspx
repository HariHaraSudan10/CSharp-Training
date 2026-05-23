<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question1.aspx.cs" Inherits="Assignment1___ASP.Question1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Insert Your Details :</h4>

            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvName" 
                runat="server" 
                ControlToValidate="txtName" 
                ErrorMessage="Name is required" 
                ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblFamilyName" runat="server" Text="Family Name"></asp:Label>
            <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvFamilyName" 
                runat="server"
                ControlToValidate="txtFamilyName"
                ErrorMessage="Family Name is required"
                ForeColor="Red">*</asp:RequiredFieldValidator>

            <asp:CompareValidator
                ID="cvFamilyName"
                runat="server"
                ControlToValidate="txtFamilyName"
                ControlToCompare="txtName"
                Operator="NotEqual"
                Type="String"
                ErrorMessage="Name and Family Name must be different"
                ForeColor="Red">
            </asp:CompareValidator>
            <br />
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvAddress" 
                runat="server"
                ControlToValidate="txtAddress"
                ErrorMessage="Address is required"
                ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="revAddress"
                runat="server"
                ControlToValidate="txtAddress"
                ValidationExpression="^.{2,}$"
                ErrorMessage="Address must contain at least 2 characters"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvCity" 
                runat="server"
                ControlToValidate="txtCity"
                ErrorMessage="City is required"
                ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="revCity"
                runat="server"
                ControlToValidate="txtCity"
                ValidationExpression="^.{2,}$"
                ErrorMessage="City must contain at least 2 characters"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblZipCode" runat="server" Text="Zip Code"></asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvZip" 
                runat="server"
                ControlToValidate="txtZipCode"
                ErrorMessage="Zip Code is required"
                ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="revZip"
                runat="server"
                ControlToValidate="txtZipCode"
                ValidationExpression="^\d{5}$"
                ErrorMessage="Zip Code must be 5 digits"
                ForeColor="Red">
            </asp:RegularExpressionValidator>

            <br />
            <br />
            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvPhone" 
                runat="server"
                ControlToValidate="txtPhone"
                ErrorMessage="Phone number is required"
                ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="revPhone"
                runat="server"
                ControlToValidate="txtPhone"
                ValidationExpression="^\d{2,3}-\d{7}$"
                ErrorMessage="Phone format must be XX-XXXXXXX or XXX-XXXXXXX"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="E-Mail"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvEmail" 
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Email is required"
                ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="revEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^\w+([\-+.'']\w+)*@\w+([\-]\w+)*\.\w+([\-]\w+)*$"
                ErrorMessage="Invalid email address"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
            <br />
            <br /> 
            <asp:ValidationSummary 
                ID="vs" 
                runat="server" 
                HeaderText="Please correct the following errors:"
                ForeColor="Red"/>
        </div>
    </form>
</body>
</html>
