<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPortal.aspx.cs" Inherits="InvoiceIT.StaffPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff management portal</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="StaffManagementPortal" runat="server">
        <div class="page-header">
            <asp:Label ID="LblMainHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblStaffManagementPortal" class="body-title" runat="server" Text="Staff management portal"></asp:Label>

            <div class="staff-management-page-content">
                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblViewAllStaff" class="main-button-label" runat="server" Height="50" Text="View all Staff"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnViewAllStaffMembers" class="submit-button" runat="server" href="ViewStaffList.aspx">View all</asp:LinkButton>
                    </div>
                    <div class="button-with-text-above">
                        <asp:Label ID="LblAddNewStaff" class="main-button-label" runat="server" Height="50" Text="Add new staff"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnAddNewStaff" class="submit-button" runat="server" href="AddStaffMember.aspx">Add Staff</asp:LinkButton>
                    </div>
                </div>
                <div class="text-information">
                    <p class="p-information-text">- A staff member can have their data changed from within the view all staff tab</p>
                    <p class="p-information-text">- A staff member can be removed from within the view all staff tab</p>
                </div>
                <div class="button-one-row">
                    <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="index.aspx" runat="server">Back to menu</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
