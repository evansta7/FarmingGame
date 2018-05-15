using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


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
    }
}
