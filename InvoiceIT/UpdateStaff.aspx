<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStaff.aspx.cs" Inherits="InvoiceIT.UpdateStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update staff member</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <div id="frmcontStaff" runat="server">
    <form id="form1" class="page-no-scroll" runat="server">
        <asp:HiddenField ID="CtrlStaffID" runat="server" Value=""></asp:HiddenField>
        <div class="page-header">
            <asp:Label ID="LblAddNewStaffMemberHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text=""></asp:Label>

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
                        <asp:Literal ID="AccessLevelPH" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlFirstName"
                        ID="rfvFirstName"
                        Display="Static"
                        ErrorMessage="A first name is required"
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
                        <asp:Literal ID="StatusPH" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlSurname"
                        ID="rfvSurname"
                        Display="Static"
                        ErrorMessage="A surname is required"
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
                        <asp:TextBox ID="CtrlStaffMobile" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblPassword" runat="server" Text="Password*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlPassword" runat="server"></asp:TextBox>
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
                        <asp:Button ID="BtnUpdateStaffMember" class="submit-button" runat="server" OnClick="BtnUpdateStaffMember_Click" Text="Update staff" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="ViewStaffList.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
    </div>
</body>
</html>
