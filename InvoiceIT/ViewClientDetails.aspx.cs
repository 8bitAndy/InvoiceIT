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
                if (AccessLevel == "Staff")
                {
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
                }
                else if (AccessLevel == "Administrator")
                {
                    Response.Write("Hello " + userDetails[0] + " you are logged in as " + AccessLevel + " | <a href='Logout.aspx'>Log out</a>");
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
                // Create a new client object to send ID to
                Client DeleteClient = new Client();

                // Get the result of the delete query
                string Result = DeleteClient.DeleteClient(ClientID);
                if (Result == "Query Succeeded")
                {
                    this.frmcontClientDelete.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='success'>Client details deleted successfully.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Course List</a>");
                }
                else
                {
                    this.frmcontClientDelete.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='error'>Deletion failed, client details have not been changed.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Course List</a>");
                }

            }
        }
    }
}