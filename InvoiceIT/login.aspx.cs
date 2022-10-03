using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace InvoiceIT
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
/*            // Testing the database connection
            SqlConnection con = DBConnect.CreateConnection();*/

/*            //Check if connection works, print message if it does
            if(con.State == System.Data.ConnectionState.Open)
            {
                Response.Write("The database connection is open and ready");
            }
            else
            {
                Response.Write("The database connection failed");
            }*/
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            // Create a new staff object to get confirm login details
            Staff staff = new Staff();
            // Create a new list to hold users first name and access level
            _ = new List<string>(2);
            // Get login details from the form
            List<string> StaffDetails = staff.GetStaff(Request.Form["CtrlUsername"], Request.Form["CtrlUserPassword"]);

            // Check to see if staff details are empty or not when returned
            bool isEmpty = AppUtilities.IsEmpty(StaffDetails);

            // Inform user of failure to login or continue with operation
            if (isEmpty)
            {
                Response.Write("No user found with these details. Return to login page <a href='login.aspx'>Login page</a>");
            }
            else
            {
                ArrayList UserSession = new ArrayList
                {
                    // Users first name
                    StaffDetails[0],
                    // Users access level
                    StaffDetails[1]
                };
                // Create a new session
                Session["CurrentUser"] = UserSession;

                // Redirect the user to the main menu upon successful login
                Response.Redirect("index.aspx");



            }

        }
    }
}