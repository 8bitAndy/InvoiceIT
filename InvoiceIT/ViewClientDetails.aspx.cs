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
    public partial class ViewClientDetails : System.Web.UI.Page
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

            // Code that generates details of current client
            // Test if page loaded with an ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {
                // Create a new course object
                Client client = new Client();
                // New list without a name yet
                _ = new List<string>(12);
                List<string> ClientData = client.GetClient(Client_ID);

                // Check if list is empty or not
                bool isEmpty = AppUtilities.IsEmpty(ClientData);

                if (isEmpty)
                {
                    // If list is empty
                    Response.Write("There was an unexpected error - no client details were returned.");
                }
                else
                {
                    // Display details from the query here
                    Response.Write("<br/>");
                    Response.Write("<h3>Details for client " + ClientData[1] + "</h3>");
                    Response.Write("<br/>");
                    Response.Write("Client ID: " + ClientData[0] + "<br/>");
                    Response.Write("Company name: " + ClientData[1] + "<br/>");
                    Response.Write("Company address 1: " + ClientData[2] + "<br/>");
                    Response.Write("Company address 2: " + ClientData[3] + "<br/>");
                    Response.Write("Company Location: " + ClientData[4] + "<br/>");
                    Response.Write("Company Postcode: " + ClientData[5] + "<br/>");
                    Response.Write("<br/>");
                    Response.Write("<h3>Contact details</h3>");
                    Response.Write("Contact First Name: " + ClientData[6] + "<br/>");
                    Response.Write("Contact Last Name: " + ClientData[7] + "<br/>");
                    Response.Write("Contact Email: " + ClientData[8] + "<br/>");
                    Response.Write("Contact Mobile: " + ClientData[9] + "<br/>");
                    Response.Write("BillTo: " + ClientData[10] + "<br/>");
                    Response.Write("Status: " + ClientData[11] + "<br/>");

                    Response.Write("<br/>");
                    Response.Write("<a href='UpdateClient.aspx?ID=" + ClientData[0] + "'>Update Client Details</a>");
                    Response.Write("<br/>");
                    Response.Write("<br/>");
                }
            }
            else
            {
                // Something went wrong code here
                Response.Write("No ID in url or couldn't parse to an int");
            }
        }

        // Delete the current client from the database
        protected void BtnDeleteCurrentClient_Click(object sender, EventArgs e)
        {
            // If form data is submitted via button press
            if (IsPostBack)
            {
                // Get the current forms client ID from the parameters
                int ClientID = Convert.ToInt32(Request.Params["ID"]);

                // Check invoices to see if client is there

                // Code here to check if client id is in use elsewhere. IF so then cannot be deleted.
                // Check work item to see if client is there
                WorkItem CheckWorkItem = new WorkItem();
                // Get a list of every work item
                List<List<string>> allworkitems = CheckWorkItem.GetWorkItem();

                // Check invoices to see if client is there
                Invoice CheckInvoice = new Invoice();
                // Get a list of every invoice
                List<List<string>> allinvoices = CheckInvoice.GetInvoice();

                // Count of how many work items or invoices the client appears in
                int mentions = 0;

                // If results are not null then make a count
                if (allworkitems != null || allinvoices != null)
                {
                    // Number of results returned from query
                    int results1 = allworkitems.Count;

                    // Loop through results and check to see if client is mentioned in any work items
                    for(int i = 0; i <= results1 - 1; i++)
                    {
                        // See if client id matches the current client ID
                        if(Convert.ToInt32(allworkitems[i][5]) == ClientID)
                        {
                            mentions += 1;
                        }
                    }
                    // Check if client id appears in any invoices and add to count if they do
                    // Number of results returned from query
                    int results2 = allinvoices.Count;

                    // Loop through results and check to see if client is mentioned in any invoices
                    for (int j = 0; j <= results2 - 1; j++)
                    {
                        // See if client id matches the invoice id
                        if (Convert.ToInt32(allinvoices[j][7]) == ClientID)
                        {
                            mentions += 1;
                        }
                    }
                }
                if (mentions >= 1)
                {
                    // Print to screen if client is mentioned in
                    ErrorMessagePH.Text = "The current client is used in other parts of the application, cannot be deleted until other references are deleted";
                }
                else
                {
                    // No error message since client can be deleted
                    ErrorMessagePH.Text = "";

                    // Carry on with deletion since it is allowed
                    // Create a new client object to send ID to
                    Client DeleteClient = new Client();

                    // Get the result of the delete query
                    string Result = DeleteClient.DeleteClient(ClientID);
                    if (Result == "Query Succeeded")
                    {
                        this.frmcontClientDelete.Visible = false;
                        Response.Write("<br/>");
                        Response.Write("<span class='success'>Client details deleted successfully.</span><br />");
                        Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                    }
                    else
                    {
                        this.frmcontClientDelete.Visible = false;
                        Response.Write("<br/>");
                        Response.Write("<span class='error'>Deletion failed, client details have not been changed.</span><br />");
                        Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                    }
                }
            }
        }
    }
}