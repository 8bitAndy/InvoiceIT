using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Staff
    {
        // Fields for the staff object, linked to the database table of the same name
        public int Staff_ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AccessLevel { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // Used to give meaningful data about the database connection
        public string Message { get; set; }


        // Adding a new staff member
        public string AddStaffMember(NameValueCollection NewStaffData)
        {
            this.FirstName = NewStaffData["CtrlFirstName"];
            this.Surname = NewStaffData["CtrlSurname"];
            this.Email = NewStaffData["CtrlStaffEmail"];
            this.Mobile = NewStaffData["CtrlStaffMobile"];
            this.AccessLevel = NewStaffData["CtrlAccessLevel"];
            this.Status = NewStaffData["CtrlStaffStatus"];
            this.Username = NewStaffData["CtrlUsername"];
            this.Password = NewStaffData["CtrlPassword"];

            // Creating a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // Creating the SQL command to add data to the staff table
            SqlCommand AddStaffMember = new SqlCommand
            {
                // Add the actual SQL command and fields to be added into a table here
                CommandText = "INSERT STAFF (FirstName, Surname, Email, Mobile, AccessLevel, Status, Username, Password) VALUES ('" +FirstName+ "', '" +Surname+ "', '" +Email+ "', '" +Mobile+ "', '" +AccessLevel+ "', '" +Status+ "', '" +Username+ "','" +Password+ "')",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Check to see if connection is active, defensive programming
            if(connection.State == ConnectionState.Open)
            {
                // Execute the insert query and get a value to see if the query succeeded
                int connectionCheck = AddStaffMember.ExecuteNonQuery();

                // Check to see if the above query succeeded or not. Give appropriate message
                if(connectionCheck == 0)
                {
                    this.Message = "Query has failed";
                }
                else
                {
                    this.Message = "Query has succeeded!";
                }
            }
            else
            {
                // Send failure message if there is an error
                this.Message = "SQL DB connection failed";
            }

            // Remove the current database connection and cleanup data
            DBConnect.DropConnection(connection);

            // Returning the message string to caller
            return Message;
        }

        // This method lists all staff members
        public List<List<string>> GetStaff()
        {
            // Create a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command to retrive all staff from the STAFF database table
            SqlCommand GetAllStaff = new SqlCommand
            {
                CommandText = "SELECT * FROM STAFF",
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Create a multi dimensional list that will hold all of the data from the query
            List<List<string>> AllStaff = new List<List<string>>();

            // Read all results from the database
            SqlDataReader reader = GetAllStaff.ExecuteReader();

            // Check that results are not null, if so then do
            if (reader.HasRows)
            {
                // Loop over results and read
                while (reader.Read())
                {
                    // Add each line to a single dimensional list that contains the result data
                    AllStaff.Add(new List<string> {reader["Staff_ID"].ToString(), reader["FirstName"].ToString(),
                        reader["SurName"].ToString(), reader["Email"].ToString(), reader["Mobile"].ToString(),
                        reader["AccessLevel"].ToString(), reader["Status"].ToString(), reader["Username"].ToString(),
                        reader["Password"].ToString() });
                }
                // Close the reader to prevent any errors
                reader.Close();
            }
            else
            {
                // If no results then set return value to null
                AllStaff = null;
            }

            // Close datbase connection
            DBConnect.DropConnection(connection);

            // Return the data read from the database
            return AllStaff;

        }
    }
}