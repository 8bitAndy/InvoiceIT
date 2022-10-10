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

        // This method returns the data of a specific user once they have entered their login details.
        // This is used to create a session 
        public List<string> GetStaff(string Username, string Password)
        {
            // Assign the arguments to the object fields
            this.Username = Username;
            this.Password = Password;

            // Create a list to hold the firstname and access level of a staff member
            List<string> details = new List<string>(2);

            // Create a connection to the database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command to retrive a specific staff members details
            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT FirstName, AccessLevel FROM [STAFF] WHERE Username = '" + Username+ "' AND Password = '" +Password + "'",
                CommandType = CommandType.Text,
                Connection = connection
            };


            // Read all results from the database
            SqlDataReader reader = GetStaffDetails.ExecuteReader();

            // Check that results are not null, if so then do
            if (reader.HasRows)
            {
                // Loop over results and read
                while (reader.Read())
                {
                    // Add each line to a single dimensional list that contains the result data
                    details.Add(reader["FirstName"].ToString());
                    details.Add(reader["AccessLevel"].ToString());
                }
                // Close the reader to prevent any errors
                reader.Close();
            }
            else
            {
                // If no results then set return value to null
                details = null;
            }

            // Close datbase connection
            DBConnect.DropConnection(connection);

            // Return the data read from the database
            return details;

        }


        // Display details of a specific staff member
        public List<string> GetStaff(int StaffID)
        {
            // Set object field to parameter
            this.Staff_ID = StaffID;
            List<string> details = new List<string>(9);

            // Make new connection to database
            SqlConnection connection = DBConnect.CreateConnection();

            // SQL sequence to get the specific staff member
            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM STAFF WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Create new data reader and execute query
            SqlDataReader reader = GetStaffDetails.ExecuteReader();

            // Test if something has gone wrong
            if (!reader.HasRows)
            {
                details = null;
            }
            else
            {
                // Code here exectues if everything happened successfully
                while (reader.Read())
                {
                    details.Add(reader["Staff_ID"].ToString()); // Add staff ID to list index position 0
                    details.Add(reader["FirstName"].ToString()); // Add first name to list index position 1
                    details.Add(reader["Surname"].ToString()); // Add surname to list index position 2
                    details.Add(reader["Email"].ToString()); // Add email to list index position 3
                    details.Add(reader["Mobile"].ToString()); // Add mobile to list index position 4
                    details.Add(reader["AccessLevel"].ToString()); // Add access to list index position 5
                    details.Add(reader["Status"].ToString()); // Add status to list index position 6
                    details.Add(reader["Username"].ToString()); // Add username to list index position 7
                    details.Add(reader["Password"].ToString()); // Add password to list index position 8
                }
            }

            // Close the database connection
            DBConnect.DropConnection(connection);

            // Return the details list 
            return details;
        }

        // This method is used to update the STAFF database table
        public string UpdateStaff(NameValueCollection UpdateStaffData)
        {
            // Get values from the form and assign to the fields of this object
            this.Staff_ID = Convert.ToInt32(UpdateStaffData["CtrlStaffID"]);
            this.FirstName = UpdateStaffData["CtrlFirstName"];
            this.Surname = UpdateStaffData["CtrlSurname"];
            this.Email = UpdateStaffData["CtrlStaffEmail"];
            this.Mobile = UpdateStaffData["CtrlStaffMobile"];
            this.AccessLevel = UpdateStaffData["CtrlAccessLevel"];
            this.Status = UpdateStaffData["CtrlStaffStatus"];
            this.Username = UpdateStaffData["CtrlUsername"];
            this.Password = UpdateStaffData["CtrlPassword"];

            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command for updating the table with the new information
            SqlCommand UpdateCourse = new SqlCommand
            {
                CommandText = "UPDATE STAFF SET FirstName = '" + FirstName + "', Surname = '" + Surname +
                "', Email = '" + Email + "', Mobile = '" + Mobile + "', AccessLevel = '" +
                AccessLevel + "', Status = '" + Status + "', Username = '" + Username +
                "', Password = '" + Password + "' WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Defensive programming to check the connection to the database and present a meaningful message
            if (connection.State == ConnectionState.Open)
            {
                int a = UpdateCourse.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }
            }
            else
            {
                this.Message = "SQL DB Connect failed";
            }

            // Remove the current database connection
            DBConnect.DropConnection(connection);
            return Message;
        }

        // This method deletes the a staff member from the STAFF table when an id number is given as input
        public string DeleteStaff(int StaffID)
        {
            // Get id to be used to delete the current client from database
            this.Staff_ID = StaffID;

            SqlConnection connection = DBConnect.CreateConnection();

            // SQL command for delete the current client record from the table
            SqlCommand DeleteStaff = new SqlCommand
            {
                CommandText = "DELETE FROM STAFF WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = connection
            };

            // Defensive programming to check the connection to the database and present a meaningful message
            if (connection.State == ConnectionState.Open)
            {
                int a = DeleteStaff.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }
            }
            else
            {
                this.Message = "SQL DB Connect failed";
            }

            // Remove the current database connection
            DBConnect.DropConnection(connection);
            return Message;
        }
    }
}