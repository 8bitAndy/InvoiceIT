using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace InvoiceIT
{
    public partial class AddStaffMember : System.Web.UI.Page
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
        }

        protected void BtnAddNewStaffMember_Click(object sender, EventArgs e)
        {
            // Check if button is pressed and data has been sent
            if (IsPostBack)
            {
                // Create a new name value collection with the populated fields in the form
                NameValueCollection NewStaffData = Request.Form;
                // Create a new staff object
                Staff NewStaffMember = new Staff();
                // Saves values in form to database
                string Result = NewStaffMember.AddStaffMember(NewStaffData);
                // Print the result of the query to the user
                Response.Write(Result);
                // Clear the form so another entry can happen
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }
}