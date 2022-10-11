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
    public partial class UpdateClient : System.Web.UI.Page
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


            // Make sure a parameter has been passed via the url and can be cast as an integer
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {
                Client client = new Client(); // Create a client object from the Client class
                _ = new List<string>(4); // Create a new List object of type string
                List<string> ClientData = client.GetClient(Client_ID); // Place data returned by method into a list named clientdata
                bool isEmpty = AppUtilities.IsEmpty(ClientData); // Check whether or not the clientdata list is empty or not

                // Write customised header above form
                this.LblAddNewStaffMember.Text = "Update Details for " + ClientData[1];

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no client details were returned"); // If Clientdata list is null or empty, inform user
                }
                else
                {  // If clientdata list contains data, place into the appropriate form locations

                    // Write client details to matching target controls in form
                    this.CtrlClientID.Value = ClientData[0].ToString();
                    this.CtrlCompName.Text = ClientData[1];
                    this.CtrlAddress1.Text = ClientData[2];
                    this.CtrlAddress2.Text = ClientData[3];
                    this.CtrlLocation.Text = ClientData[4];
                    this.CtrlPostcode.Text = ClientData[5];
                    this.CtrlContactFirstName.Text = ClientData[6];
                    this.CtrlContactLastName.Text = ClientData[7];
                    this.CtrlContactEmail.Text = ClientData[8];
                    this.CtrlContactMobile.Text = ClientData[9];

                    // Get values for the drop down lists on the form
                    string billTo = ClientData[10].Replace(" ", String.Empty);
                    string status = ClientData[11].Replace(" ", String.Empty);

                    // Configure the display of the drop for bill to
                    string dlbillTo;
                    if (billTo == "Company")
                    {
                        dlbillTo = "<select class='tbinput' name='CtrlBillTo' id='CtrlBillTo'>";
                        dlbillTo += "<option value='Company' selected='selected'>Company</option>";
                        dlbillTo += "<option value='Client'>Client</option>";
                        dlbillTo += "</select>";
                    }
                    else
                    {
                        dlbillTo = "<select class='tbinput' name='CtrlBillTo' id='CtrlBillTo'>";
                        dlbillTo += "<option value='Company'>Company</option>";
                        dlbillTo += "<option value='Client' selected='selected'>Client</option>";
                        dlbillTo += "</select>";
                    }

                    BillToPH.Text = dlbillTo;

                    // Configure the display of the drop list for client status
                    string dlclientstatus;
                    if (status == "Good")
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlClientStatus' id='CtrlClientStatus'>";
                        dlclientstatus += "<option value='Good' selected='selected'>Good</option>";
                        dlclientstatus += "<option value='In Arrears'>In Arrears</option>";
                        dlclientstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlclientstatus += "</select>";
                    }
                    else if(status == "Discontinued")
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlClientStatus' id='CtrlClientStatus'>";
                        dlclientstatus += "<option value='Good'>Good</option>";
                        dlclientstatus += "<option value='In Arrears'>In Arrears</option>";
                        dlclientstatus += "<option value='Discontinued' selected='selected'>Discontinued</option>";
                        dlclientstatus += "</select>";
                    }
                    else
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlClientStatus' id='CtrlClientStatus'>";
                        dlclientstatus += "<option value='Good'>Good</option>";
                        dlclientstatus += "<option value='In Arrears' selected='selected'>In Arrears</option>";
                        dlclientstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlclientstatus += "</select>";
                    }

                    ClientStatusPH.Text = dlclientstatus;
                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }

        }

        protected void BtnUpdateClient_Click(object sender, EventArgs e)
        {
            // If form data is submitted via button press
            if (IsPostBack)
            {
                // Create a new object and populate it with the form data
                NameValueCollection UpdateClientData = Request.Form;
                Client UpdateClient = new Client();
                // Complete the query and get a message back
                string Result = UpdateClient.UpdateClient(UpdateClientData);
                // Print appropriate output to user
                if (Result == "Query Succeeded")
                {
                    this.frmcontClient.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='success'>Client details updated successfully.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }
                else
                {
                    this.frmcontClient.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='error'>Update failed, client details have not been changed.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }

            }
        }
    }
}