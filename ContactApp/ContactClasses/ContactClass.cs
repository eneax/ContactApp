using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.contactClasses
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
    }
}

/*
- DataTable is a temporary table that store data from our db
*/
