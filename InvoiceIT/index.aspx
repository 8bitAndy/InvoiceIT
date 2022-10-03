<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="InvoiceIT.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InvoiceIT</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
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
                    <asp:Button ID="BtnTaskManagement" class="submit-button" runat="server" Text="Task portal" />
                    </div>
                </div>

                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="Label1" class="main-button-label" runat="server" Height="50" Text="Work Item management"></asp:Label>
                        <br />
                        <asp:Button ID="Button1" class="submit-button" runat="server" Text="Work Item portal" />
                    </div>
                    <div class="button-with-text-above">
                    <asp:Label ID="LblStaffManagement" class="main-button-label" runat="server" Height="50" Text="Staff management"></asp:Label>
                    <br />
                    <asp:Button ID="BtnStaffManagement" class="submit-button" runat="server" OnClick="BtnStaffManagement_Click" Text="Staff portal" />
                    </div>
                </div>

                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="Label3" class="main-button-label" runat="server" Height="50" Text="Invoice management"></asp:Label>
                        <br />
                        <asp:Button ID="Button3" class="submit-button" runat="server" Text="Invoice portal" />
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
