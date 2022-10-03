<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStaffMember.aspx.cs" Inherits="InvoiceIT.AddStaffMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add new staff member</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-header">
            <asp:Label ID="LblAddNewStaffMemberHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text="Add a new staff member"></asp:Label>

            <div class="main-page-content">
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblFirstName" runat="server" Text="First Name*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlFirstName" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblAccessLevel" runat="server" Text="Access Level*"></asp:Label>
                        <br />
                        <asp:DropDownList ID="CtrlAccessLevel" class="dropdown-list" runat="server">
                            <asp:ListItem>Staff</asp:ListItem>
                            <asp:ListItem>Administrator</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlFirstName"
                        ID="rfvFirstName"
                        Display="Static"
                        ErrorMessage="A first name is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlAccessLevel"
                        ID="rfvAccessLevel"
                        Display="Static"
                        ErrorMessage="An access level is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblSurname" runat="server" Text="Surname*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlSurname" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblStaffStatus" runat="server" Text="Status*"></asp:Label>
                        <br />
                        <asp:DropDownList ID="CtrlStaffStatus" class="dropdown-list" runat="server">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Inactive</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlSurname"
                        ID="rfvSurname"
                        Display="Static"
                        ErrorMessage="A surname is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlStaffStatus"
                        ID="rfvStatus"
                        Display="Static"
                        ErrorMessage="A status is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblStaffEmail" runat="server" Text="Email*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlStaffEmail" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblUsername" runat="server" Text="Username*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlUsername" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlStaffEmail"
                        ID="rfvEmail"
                        Display="Static"
                        ErrorMessage="An email is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlUsername"
                        ID="rfvUsername"
                        Display="Static"
                        ErrorMessage="A username is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblStaffMobile" runat="server" Text="Mobile*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlStaffMobile" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblPassword" runat="server" Text="Password*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlPassword" runat="server" TextMode="Password" ></asp:TextBox>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlStaffMobile"
                        ID="rfvMobile"
                        Display="Static"
                        ErrorMessage="A mobile number is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlPassword"
                        ID="rfvPassword"
                        Display="Static"
                        ErrorMessage="A password is required"
                        runat="server"/>
                </div>
                <div class="add-button-container">
                    <div class="button-two-row">
                        <asp:Button ID="BtnAddNewStaffMember" class="submit-button" runat="server" OnClick="BtnAddNewStaffMember_Click" Text="Add staff member" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="StaffPortal.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
