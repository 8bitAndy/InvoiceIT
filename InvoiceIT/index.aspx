<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="InvoiceIT.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InvoiceIT</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="MainMenu" class="page-no-scroll" runat="server">
        <div class="page-header">
            <asp:Label ID="LblMainHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblMainMenu" class="body-title" runat="server" Text="Main Menu"></asp:Label>

            <div class="main-page-content">
                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblClientManagement" class="main-button-label" runat="server" Height="50" Text="Client management"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnClientManagement" class="submit-button" runat="server" href="ClientPortal.aspx">Client portal</asp:LinkButton>
                    </div>
                    <div class="button-with-text-above">
                        <asp:Label ID="LblTaskManagement" class="main-button-label" runat="server" Height="50" Text="Task management"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnTaskManagement" class="submit-button" runat="server" href="TaskPortal.aspx">Task portal</asp:LinkButton>
                    </div>
                </div>

                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="Label1" class="main-button-label" runat="server" Height="50" Text="Work Item management"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnWorkItemManagement" class="submit-button" runat="server" href="WorkItemPortal.aspx">Work item portal</asp:LinkButton>
                    </div>
                    <div class="button-with-text-above">
                    <asp:Label ID="LblStaffManagement" class="main-button-label" runat="server" Height="50" Text="Staff management"></asp:Label>
                    <br />
                    <asp:LinkButton ID="LinkBtnStaffManagement" class="submit-button" runat="server" href="StaffPortal.aspx">Staff portal</asp:LinkButton>
                    </div>
                </div>

                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblInvoiceManagement" class="main-button-label" runat="server" Height="50" Text="Invoice management"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnInvoiceManagement" class="submit-button" runat="server" href="InvoicePortal.aspx">Invoice portal</asp:LinkButton>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
