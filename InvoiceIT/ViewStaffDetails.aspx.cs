using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewStaffDetails : System.Web.UI.Page
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

            // Code that generates details of current staff
            // Test if page loaded with an ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID))
            {
                // Create a new staff object
                Staff staff = new Staff();
                // New list without a name yet
                _ = new List<string>(9);
                List<string> StaffData = staff.GetStaff(Staff_ID);

                // Check if list is empty or not
                bool isEmpty = AppUtilities.IsEmpty(StaffData);

                if (isEmpty)
                {
                    // If list is empty
                    Response.Write("There was an unexpected error - no staff details were returned.");
                }
                else
                {
                    // Display details from the query here
                    Response.Write("<br/>");
                    Response.Write("<h3>Details for staff member " + StaffData[1] + " " + StaffData[1] + "</h3>");
                    Response.Write("<br/>");
                    Response.Write("Staff ID: " + StaffData[0] + "<br/>");
                    Response.Write("First name: " + StaffData[1] + "<br/>");
                    Response.Write("Last name: " + StaffData[2] + "<br/>");
                    Response.Write("Email: " + StaffData[3] + "<br/>");
                    Response.Write("Mobile: " + StaffData[4] + "<br/>");
                    Response.Write("Access Level: " + StaffData[5] + "<br/>");
                    Response.Write("Status: " + StaffData[6] + "<br/>");
                    Response.Write("Username: " + StaffData[7] + "<br/>");
                    Response.Write("Password: " + StaffData[8] + "<br/>");
                    Response.Write("<br/>");
                    Response.Write("<a href='UpdateStaff.aspx?ID=" + StaffData[0] + "'>Update Staff Details</a>");
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
    }
}