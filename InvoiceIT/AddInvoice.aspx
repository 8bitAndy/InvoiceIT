<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInvoice.aspx.cs" Inherits="InvoiceIT.AddInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate new invoice</title>
    <link rel="stylesheet" href="styles.css" />
    <link rel="stylesheet" href="jqrui/jquery-ui.min.css" />
    <script src="jqrui/external/jquery/jquery.js"></script>
    <script src="jqrui/jquery-ui.min.js"></script>
    <script>
        $(function () {
            $("#CtrlInvoiceStartDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
        $(function () {
            $("#CtrlInvoiceEndDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
        $(function () {
            $("#CtrlInvoiceChangeDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
        $(function () {
            $("#CtrlInvoiceSentDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
        $(function () {
            $("#CtrlInvoicePaymentDueDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
    </script>
</head>
<body>
    <form id="AddNewInvoice" runat="server">
        <div class="page-header">
            <asp:Label ID="LblAddNewClientHeader" class="main-title" runat="server" Text="InvoiceIT"></asp:Label>
        </div>
        <hr class="main-hr" />
        <div class="page-body-add-client">
            <asp:Label ID="LblAddNewStaffMember" class="body-title" runat="server" Text="Generate a new invoice"></asp:Label>

            <div class="add-work-item-page-content">
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblWorkItemDate" runat="server" Text="Invoice start date*"></asp:Label>
                        <br />
                        <input type="text" id="CtrlInvoiceStartDate" runat="server" />
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblClientList" runat="server" Text="Invoice end date*"></asp:Label>
                        <br />
                        <input type="text" id="CtrlInvoiceEndDate" runat="server" />
                    </div>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblInvoiceGenerateDate" runat="server" Text="Invoice generate/update date*"></asp:Label>
                        <br />
                        <input type="text" id="CtrlInvoiceChangeDate" runat="server" />
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblInvoiceSentDate" runat="server" Text="Invoice sent date*"></asp:Label>
                        <br />
                        <input type="text" id="CtrlInvoiceSentDate" runat="server" />
                    </div>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblPaymentDueDate" runat="server" Text="Payment due date*"></asp:Label>
                        <br />
                        <input type="text" id="CtrlInvoicePaymentDueDate" runat="server" />   
                    </div>
                </div>
                <div class="row-with-textboxes">
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblInvoiceStatus" runat="server" Text="Status*"></asp:Label>
                        <br />
                        <asp:DropDownList ID="CtrlInvoiceStatus" class="dropdown-list" runat="server">
                            <asp:ListItem>Generated</asp:ListItem>
                            <asp:ListItem>Sent</asp:ListItem>
                            <asp:ListItem>Overdue</asp:ListItem>
                            <asp:ListItem>Paid</asp:ListItem>
                            <asp:ListItem>Withdrawn</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="textbox-label-general-purpose">
                        <asp:Label ID="LblBusinessList" runat="server" Text="Business name*"></asp:Label>
                        <br />
                        <asp:Literal ID="BusinessListPH" runat="server"></asp:Literal>
                    </div>
                </div>
                

                <div class="add-work-item-button-container">
                    <div class="button-two-row">
                        <asp:Button ID="BtnAddInvoice" class="submit-button" runat="server" OnClick="BtnAddInvoice_Click" Text="Add new work item" />
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
