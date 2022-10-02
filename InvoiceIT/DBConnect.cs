using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class DBConnect
    {

        // Makes a connection to the local database of the application for reading and writing data
        public static SqlConnection CreateConnection()
        {
            // Creating a string to hold the connection details specified in web.config file
            string str = ConfigurationManager.ConnectionStrings["invitdbcon"].ConnectionString;

            // Giving the connection a name
            SqlConnection con = new SqlConnection(str);

            // Open the database connection
            con.Open();

            // Returning the database connection
            return con;
        }

        // Closes the database connection if one is already open
        public static void DropConnection(SqlConnection con)
        {
            // Check to see connection is active, if it is then remove the connection and dispose of any data
            if(con.State == System.Data.ConnectionState.Open)
            {
                // Close the database connection and records currently in use
                con.Close();
                con.Dispose();
            }
        }
    }
}