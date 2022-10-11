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
    public partial class UpdateStaff : System.Web.UI.Page
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
                    // Defensive programming, return back to login if not a valid user
                    Response.Redirect("index.aspx");
                }
                else
                {
                    // Defensive programming, return back to login if not a valid user
                    Response.Redirect("login.aspx");
                }
            }


            // Make sure a parameter has been passed via the url and can be cast as an integer
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID))
            {
                Staff staff = new Staff(); // Create a client object from the Client class
                _ = new List<string>(9); // Create a new List object of type string
                List<string> StaffData = staff.GetStaff(Staff_ID); // Place data returned by method into a list named clientdata
                bool isEmpty = AppUtilities.IsEmpty(StaffData); // Check whether or not the clientdata list is empty or not

                // Write customised header above form
                this.LblAddNewStaffMember.Text = "Update Details for " + StaffData[1] + " " + StaffData[2];

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no staff details were returned"); // If Clientdata list is null or empty, inform user
                }
                else
                {  // If staff data list contains data, place into the appropriate form locations

                    // Write staff details to matching target controls in form
                    this.CtrlStaffID.Value = StaffData[0].ToString();
                    this.CtrlFirstName.Text = StaffData[1];
                    this.CtrlSurname.Text = StaffData[2];
                    this.CtrlStaffEmail.Text = StaffData[3];
                    this.CtrlStaffMobile.Text = StaffData[4];
                    this.CtrlUsername.Text = StaffData[7];
                    this.CtrlPassword.Text = StaffData[8];

                    // Get values for the drop down lists on the form
                    string accessLevel = StaffData[5].Replace(" ", String.Empty);
                    string status = StaffData[6].Replace(" ", String.Empty);

                    // Configure the display of the drop for bill to
                    string dlaccesslevel;
                    if (accessLevel == "Staff")
                    {
                        dlaccesslevel = "<select class='tbinput' name='CtrlAccessLevel' id='CtrlAccessLevel'>";
                        dlaccesslevel += "<option value='Staff' selected='selected'>Staff</option>";
                        dlaccesslevel += "<option value='Administrator'>Administrator</option>";
                        dlaccesslevel += "</select>";
                    }
                    else
                    {
                        dlaccesslevel = "<select class='tbinput' name='CtrlAccessLevel' id='CtrlAccessLevel'>";
                        dlaccesslevel += "<option value='Staff' >Staff</option>";
                        dlaccesslevel += "<option value='Administrator' selected='selected'>Administrator</option>";
                        dlaccesslevel += "</select>";
                    }

                    AccessLevelPH.Text = dlaccesslevel;

                    // Configure the display of the drop list for client status
                    string dlstaffstatus;
                    if (status == "Active")
                    {
                        dlstaffstatus = "<select class='tbinput' name='CtrlStaffStatus' id='CtrlStaffStatus'>";
                        dlstaffstatus += "<option value='Active' selected='selected'>Active</option>";
                        dlstaffstatus += "<option value='Inactive'>Inactive</option>";
                        dlstaffstatus += "<option value='Terminated'>Terminated</option>";
                        dlstaffstatus += "</select>";
                    }
                    else if (status == "Inactive")
                    {
                        dlstaffstatus = "<select class='tbinput' name='CtrlStaffStatus' id='CtrlStaffStatus'>";
                        dlstaffstatus += "<option value='Active' >Active</option>";
                        dlstaffstatus += "<option value='Inactive' selected='selected'>Inactive</option>";
                        dlstaffstatus += "<option value='Terminated'>Terminated</option>";
                        dlstaffstatus += "</select>";
                    }
                    else
                    {
                        dlstaffstatus = "<select class='tbinput' name='CtrlStaffStatus' id='CtrlStaffStatus'>";
                        dlstaffstatus += "<option value='Active' >Active</option>";
                        dlstaffstatus += "<option value='Inactive' >Inactive</option>";
                        dlstaffstatus += "<option value='Terminated' selected='selected'>Terminated</option>";
                        dlstaffstatus += "</select>";
                    }

                    StatusPH.Text = dlstaffstatus;
                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }
        }

        protected void BtnUpdateStaffMember_Click(object sender, EventArgs e)
        {
            // If form data is submitted via button press
            if (IsPostBack)
            {
                // Create a new object and populate it with the form data
                NameValueCollection UpdateStaffData = Request.Form;
                Staff UpdateStaff = new Staff();
                // Complete the query and get a message back
                string Result = UpdateStaff.UpdateStaff(UpdateStaffData);
                // Print appropriate output to user
                if (Result == "Query Succeeded")
                {
                    this.frmcontStaff.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='success'>Staff details updated successfully.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>");
                }
                else
                {
                    this.frmcontStaff.Visible = false;
                    Response.Write("<br/>");
                    Response.Write("<span class='error'>Update failed, staff details have not been changed.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>");
                }

            }
        }
    }
}