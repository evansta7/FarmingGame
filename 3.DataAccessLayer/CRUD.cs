using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace _3.DataAccessLayer
{
    public class CRUD
    {
        SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

        public CRUD()
        {
            

            //Still need to figure this part out... Is it the same for all computers or how are we going to make it work
            connection.DataSource = @"";
            connection.InitialCatalog = "";
            connection.IntegratedSecurity = true;
        }

        //Method to extract data from the database
        // query format: SELECT (fields) FROM (tableName) (WHERE condition)
        public DataSet ReadFromDatabase(string fields, string tableName, string condition = "")
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            DataSet data = new DataSet();
            string query = string.Format("SELECT {0} FROM {1} {2}", fields, tableName, condition);
            using (conn)
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.FillSchema(data, SchemaType.Source, tableName);
                adapter.Fill(data, tableName);
            }
            
            conn.Close();
            return data;
        }

        public void InsertIntoDatabase(string tableName, string fields, string values)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());

            string query = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, fields, values);
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                conn.Close();
            }
        }

        public void DeleteFromDatabase(string tableName, string condition)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());

            try
            {
                conn.Open();
                string query = string.Format("DELETE FROM {0} WHERE {1}", tableName, condition);
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Item was deleted");
            }
            //going to put a custom exception here
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateDatabase(string tableName, string newData, string condition)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());

            conn.Open();
            string query = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, newData, condition);
            SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
