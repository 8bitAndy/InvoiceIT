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
    public partial class AddInvoice : System.Web.UI.Page
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
            }

            /*
             CODE FOR GENERATING CLIENT DROP DOWN LIST
             */

            // Create a variable to hold the generated drop list for clients
            string dlclient;

            // Create a new client object
            Client AllClients = new Client();

            List<List<string>> allclients = AllClients.GetClient();

            // Check to see if allclients is empty
            if (allclients == null)
            {
                BusinessListPH.Text = "Error - no clients found";
            }
            else
            {
                // Get the count of how many records there are for clients
                int clientCount = allclients.Count;

                // Create the courses droplist

                dlclient = "<select class='dllist' name='CtrlClientList'>";
                dlclient += "<option value='0'>--Please make a selection--</option>";

                // Add all the clients to the client drop down list
                for (int i = 0; i <= clientCount - 1; i++)
                {
                    dlclient += "<option value='" + allclients[i][0] + "'>" + allclients[i][1] + " (ID " + allclients[i][0] + ")" + "</option>";
                }

                dlclient += "</select>";
                // Add the course droplist to the placeholder on the aspx page
                BusinessListPH.Text = dlclient;
            }
        }

        protected void BtnAddInvoice_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // Check to see if all date pickers are filled out otherwise an error will be printed to screen
                if ((Request.Form["CtrlInvoiceStartDate"] == null || string.IsNullOrWhiteSpace(Request.Form["CtrlInvoiceStartDate"]) ||
                    (Request.Form["CtrlInvoiceEndDate"] == null || string.IsNullOrWhiteSpace(Request.Form["CtrlInvoiceEndDate"]) ||
                    (Request.Form["CtrlInvoiceChangeDate"] == null || string.IsNullOrWhiteSpace(Request.Form["CtrlInvoiceChangeDate"]) ||
                    (Request.Form["CtrlInvoiceSentDate"] == null || string.IsNullOrWhiteSpace(Request.Form["CtrlInvoiceSentDate"]) ||
                    (Request.Form["CtrlInvoicePaymentDueDate"] == null || string.IsNullOrWhiteSpace(Request.Form["CtrlInvoicePaymentDueDate"])))))))
                {
                    LblValidatorList.Text = "<p class='error-text'>One of the date fields was not entered, please fill out all date fields</p>";
                }
                else
                {
                    // If all dates have been entered then continue with normal operation
                    LblValidatorList.Text = "";

                    // Create a new name value collection with the populated fields in the form
                    NameValueCollection NewInvoiceData = Request.Form;
                    // Create a invoice object
                    Invoice NewInvoice = new Invoice();
                    // Saves values in form to database
                    string Result = NewInvoice.AddInvoice(NewInvoiceData);
                    // Print the result of the query to the user
                    Response.Write("<br/>" + Result);
                    // Clear the form so another entry can happen
                    AppUtilities.ClearForm(Form.Controls);
                }


            }
        }
    }
}