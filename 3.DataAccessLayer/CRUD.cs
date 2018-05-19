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

        /// <summary>
        /// Read a row from the database
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataSet Read(string fields, string tableName, string condition = "")
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            DataSet data = new DataSet();
            string query = string.Format("SELECT {0} FROM {1} {2}", fields, tableName, condition);
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.FillSchema(data, SchemaType.Source, tableName);
                    adapter.Fill(data, tableName);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return data;
        }

        /// <summary>
        /// Insert a row into the database
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        public bool Insert(string tableName, string fields, string values)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string query = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, fields, values);
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    int hasChanges = command.ExecuteNonQuery();
                    if (hasChanges == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Delete a row from the database
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        public bool Delete(string tableName, string condition)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            try
            {
                conn.Open();
                string query = string.Format("DELETE FROM {0} WHERE {1}", tableName, condition);
                SqlCommand command = new SqlCommand(query, conn);
                int hasChanges = command.ExecuteNonQuery();
                if (hasChanges == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Update a table in the DB
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="newData"></param>
        /// <param name="condition"></param>

        public bool Update(string tableName, string newData, string condition = "")
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            try
            {
                conn.Open();
                string query = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, newData, condition);
                SqlCommand command = new SqlCommand(query, conn);
                int hasChanges = command.ExecuteNonQuery();
                if (hasChanges == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
