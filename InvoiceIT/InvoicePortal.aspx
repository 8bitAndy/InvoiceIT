<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoicePortal.aspx.cs" Inherits="InvoiceIT.InvoicePortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice Management Portal</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="InvoiceManagementPortal" class="page-no-scroll" runat="server">
        <div class="page-header">
            <asp:Label ID="LblMainHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body">
            <asp:Label ID="LblInvoiceManagementPortal" class="body-title" runat="server" Text="Invoice management portal"></asp:Label>

            <div class="invoice-management-page-content">
                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblViewAllInvoices" class="main-button-label" runat="server" Height="50" Text="View all Invoices"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnViewAllInvoices" class="submit-button" runat="server" href="ViewInvoiceList.aspx">View Invoices</asp:LinkButton>
                    </div>
                    <div class="button-with-text-above">
                        <asp:Label ID="LblAddNewInvoice" class="main-button-label" runat="server" Height="50" Text="Generate new Invoice"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnAddNewInvoice" class="submit-button" runat="server" href="AddInvoice.aspx">Add Invoice</asp:LinkButton>
                    </div>
                </div>
                <div class="row-with-buttons">
                    <div class="button-with-text-above">
                        <asp:Label ID="LblAddLineItem" class="main-button-label" runat="server" Height="50" Text="Add line items to invoice"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkBtnAddNewLineItem" class="submit-button" runat="server" href="AddLineItem.aspx">Add line item</asp:LinkButton>
                    </div>
                </div>
                <div class="text-information-invoice">
                    <p class="p-information-text">- A line item can be added to an invoice by using the button above</p>
                    <p class="p-information-text">- An invoice can have its data changed from within the view all invoices tab</p>
                    <p class="p-information-text">- An invoice can be deleted from within the view all invoices tab</p>
                </div>
                <div class="button-one-row">
                    <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="index.aspx" runat="server">Back to menu</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
