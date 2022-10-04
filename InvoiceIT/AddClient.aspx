<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="InvoiceIT.AddClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a new client</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="AddNewClient" class="page-no-scroll" runat="server">
        <div class="page-header">
            <asp:Label ID="LblAddNewClientHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body-add-client">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text="Add a new client"></asp:Label>

            <div class="add-client-page-content">
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblCompName" runat="server" Text="Company name*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlCompName" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblAccessLevel" runat="server" Text="Contact first name*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlContactFirstName" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlCompName"
                        ID="rfvCompName"
                        Display="Static"
                        ErrorMessage="A company name is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlContactFirstName"
                        ID="rfvFirstName"
                        Display="Static"
                        ErrorMessage="A contact first name is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblAddress1" runat="server" Text="Address 1*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlAddress1" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblContactLastName" runat="server" Text="Contact last name*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlContactLastName" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlAddress1"
                        ID="rfvAddress1"
                        Display="Static"
                        ErrorMessage="An address is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlContactLastName"
                        ID="rfvContactLastName"
                        Display="Static"
                        ErrorMessage="A contact last name is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblAddress2" runat="server" Text="Address 2"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlAddress2" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblContactEmail" runat="server" Text="Contact email*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlContactEmail" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlContactEmail"
                        ID="rfvContactEmail"
                        Display="Static"
                        ErrorMessage="A contact email is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblLocation" runat="server" Text="Location*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlLocation" runat="server"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblContactMobile" runat="server" Text="Contact Mobile*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlContactMobile" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlLocation"
                        ID="rfvMobile"
                        Display="Static"
                        ErrorMessage="A business location is required"
                        runat="server"/>
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlContactMobile"
                        ID="rfvPassword"
                        Display="Static"
                        ErrorMessage="A contact mobile is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblPostcode" runat="server" Text="Postcode*"></asp:Label>
                        <br />
                        <asp:TextBox ID="CtrlPostcode" runat="server" MaxLength="4"></asp:TextBox>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblBillTo" runat="server" Text="Bill To*"></asp:Label>
                        <br />
                            <asp:DropDownList ID="CtrlBillToDropList" class="dropdown-list" runat="server">
                            <asp:ListItem>Company</asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlPostcode"
                        ID="rfvPostcode"
                        Display="Static"
                        ErrorMessage="A postcode is required"
                        runat="server"/>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblStatus" runat="server" Text="Status*"></asp:Label>
                        <br />
                        <asp:DropDownList ID="CtrlStatus" class="dropdown-list" runat="server">
                            <asp:ListItem>Good</asp:ListItem>
                            <asp:ListItem>In Arrears</asp:ListItem>
                            <asp:ListItem>Discontinued</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="field-validator">
                    <asp:RequiredFieldValidator 
                        ControlToValidate="CtrlStatus"
                        ID="rfvStatus"
                        Display="Static"
                        ErrorMessage="A business status is required"
                        runat="server"/>
                </div>
                <div class="add-client-button-container">
                    <div class="button-two-row">
                        <asp:Button ID="BtnAddNewClient" class="submit-button" runat="server" OnClick="BtnAddNewClient_Click" Text="Add new client" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="ClientPortal.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
