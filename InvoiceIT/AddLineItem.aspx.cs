using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class AddLineItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check to see if a user should be permitted onto this page
            if (System.Web.HttpContext.Current.Session["CurrentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                // Create new array list to hold details of current user
                _ = new ArrayList();
                ArrayList userDetails = (ArrayList)Session["CurrentUser"];
                // Get the access level of a user and store for later
                string AccessLevel = (string)userDetails[1];
                // Trim all leading or trailing white space
                AccessLevel = AccessLevel.Trim();

                // Give the user a tailored message depending on login credentials
                if (AccessLevel == "Administrator")
                {
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
                }
                else if (AccessLevel == "Staff")
                {
                    // Defensive programming, return back to main page if staff
                    Response.Redirect("index.aspx");
                }
                else
                {
                    // Defensive programming, return back to login if not a valid user
                    Response.Redirect("login.aspx");
                }

                /*
                CODE FOR GENERATING Invoice ID DROP DOWN LIST
                */

                // Create a variable to hold the generated drop list for invoice
                string dlinvoice;

            // Create a new invoice object
            Invoice AllInvoices = new Invoice();

            List<List<string>> allinvoices = AllInvoices.GetInvoice();

            // Check to see if alltasks is empty
            if (allinvoices == null)
            {
                InvoiceListPH.Text = "Error - no invoices found";
            }
            else
            {
                // Get the count of how many records there are for tasks
                int invoiceCount = allinvoices.Count;

                // Create the tasks droplist

                dlinvoice = "<select class='dllist' name='CtrlInvoiceList'>";
                dlinvoice += "<option value='0'>--Please make a selection--</option>";

                // Add all the tasks to the task drop down list
                for (int j = 0; j <= invoiceCount - 1; j++)
                {
                    // Only add invoices to the list if they havent been paid per the business rule or if they have been sent
                    if (allinvoices[j][6].Trim() != "Paid" && allinvoices[j][6].Trim() != "Sent")
                    {
                        dlinvoice += "<option value='" + allinvoices[j][0] + "'>" + " (ID " + allinvoices[j][0] + ") " + allinvoices[j][1].Substring(0, 10) + "</option>";
                    }
                }

                dlinvoice += "</select>";
                // Add the course droplist to the placeholder on the aspx page
                InvoiceListPH.Text = dlinvoice;
                }
            }


            /*
            CODE FOR GENERATING work item  DROP DOWN LIST
            */

            // Create a variable to hold the generated drop list for work items
            string dlworkitems;

            // Create a new invoice object
            WorkItem AllWorkItems = new WorkItem();
            List<List<string>> allworkitems = AllWorkItems.GetWorkItem();

            // Create a new task object to get task names
            Task TaskList = new Task();
            List<List<string>> tasknames = TaskList.GetTask();

            // Check to see if alltasks is empty
            if (allworkitems == null)
            {
                WorkItemListPH.Text = "Error - no work items found";
            }
            else
            {
                // Get the count of how many records there are for tasks
                int workitemCount = allworkitems.Count;

                // Create the tasks droplist
                dlworkitems = "<select class='dllist' name='CtrlWorkItemList'>";
                dlworkitems += "<option value='0'>--Please make a selection--</option>";

                // Add all the tasks to the task drop down list
                for (int j = 0; j <= workitemCount - 1; j++)
                {
                    dlworkitems += "<option value='" + allworkitems[j][0] + "'>" + " (ID " + allworkitems[j][0] + ") " + "</option>";
                }

                dlworkitems += "</select>";
                // Add the course droplist to the placeholder on the aspx page
                WorkItemListPH.Text = dlworkitems;
            }
    }

        protected void BtnAddLineItem_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LblValidatorList.Text = "";
                // Create a new name value collection with the populated fields in the form
                NameValueCollection NewLineItemData = Request.Form;
                // Create a new work item object
                LineItem NewLineItem = new LineItem();
                // Saves values in form to database
                string Result = NewLineItem.AddLineItem(NewLineItemData);
                // Print the result of the query to the user
                Response.Write("<br/>" + Result);
                // Clear the form so another entry can happen
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }
}