<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLineItem.aspx.cs" Inherits="InvoiceIT.AddLineItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add new line item</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="AddNewLineItem" runat="server">
        <div class="page-header">
            <asp:Label ID="LblAddNewClientHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body-add-client">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text="Add new line item"></asp:Label>
            <div class="add-line-item-page-content">
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblInvoiceList" runat="server" Text="Choose an invoice ID*"></asp:Label>
                        <br />
                        <asp:Literal ID="InvoiceListPH" runat="server"></asp:Literal>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblWorkItemList" runat="server" Text="Choose a work item*"></asp:Label>
                        <br />
                        <asp:Literal ID="WorkItemListPH" runat="server"></asp:Literal>
                    </div>
                </div>
                

                <div class="add-line-item-button-container">
                    <div class="button-two-row">
                        <asp:Button ID="BtnAddLineItem" class="submit-button" runat="server" OnClick="BtnAddLineItem_Click" Text="Add new line item" />
                    </div>
                    <div class="button-one-row">
                        <asp:LinkButton ID="BtnBackToMenu" class="back-button" href="InvoicePortal.aspx" runat="server">Back to menu</asp:LinkButton>
                    </div>
                    <asp:Literal ID="LblValidatorList" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
