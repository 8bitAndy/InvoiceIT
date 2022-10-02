using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public partial class AddStaffMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNewStaffMember_Click(object sender, EventArgs e)
        {
            // Check if button is pressed and data has been sent
            if (IsPostBack)
            {
                // Saves values in form to database
                // FIX COMMENTS HERE
                NameValueCollection NewStaffData = Request.Form;
                Staff NewStaffMember = new Staff();
                string Result = NewStaffMember.AddStaffMember(NewStaffData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }
}