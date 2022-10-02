using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Testing the database connection
            SqlConnection con = DBConnect.CreateConnection();

            //Check if connection works, print message if it does
            if(con.State == System.Data.ConnectionState.Open)
            {
                Response.Write("The database connection is open and ready");
            }
            else
            {
                Response.Write("The database connection failed");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Write("username is " + Request.Form["CtrlUsername"] + " password is " + Request.Form["CtrlUserPassword"]);
        }
    }
}