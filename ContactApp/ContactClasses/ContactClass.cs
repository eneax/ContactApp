using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.ContactClasses
{
    class ContactClass
    {
        // Getter Setter Properties (act as data carrier in our app)
        public int ContactID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        // Static method for connecting to our db
        static string myconnstrng = ConfigurationManager.ConnectionStrings["cnnstrng"].ConnectionString;

        // Method for selecting data from the database
        public DataTable Select()
        {
            // 1. Database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            // Create obj for DataTable
            DataTable dt = new DataTable();

            try
            {
                // 2. Run SQL query to select data from db
                string sql = "SELECT * FROM tbl_contact";

                // Create cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                // Create SqlDataAdapter suing cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                // Open connection and fill adapter using the obj of our table
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                // Close connection
                conn.Close();
            }
            return dt;
        }

        // Method for inserting data into database
        public bool Insert(ContactClass c)
        {
            // Create default type and set its value to false
            bool isSuccess = false;

            // 1. Connect to db
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // 2. Create Sql query to insert data into db
                string sql = "INSERT INTO tbl_contact (FirsName, LastName, ContactNo, Address, Gender) VALUES (@FirsName, @LastName, @ContactNo, @Address, @Gender)";

                // Create cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Create Parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactID);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                // Open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                // If the query runs successfuly then the value of rows will be > 0, else it will be = 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}

/*
- DataTable is a temporary table that store data from our db
*/
