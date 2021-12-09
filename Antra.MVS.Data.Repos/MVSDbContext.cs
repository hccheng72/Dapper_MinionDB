using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //add
using System.Data.SqlClient; //add

namespace Antra.MVS.Data.Repos
{
    class MVSDbContext
    {
        public int Execute(string cmd, Dictionary<string, object> parameters)
        {
            //View->Other windows->server explore->add database->(right click)properties->connection string
            string connection = @"Data Source=localhost;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = cmd;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                sqlCommand.Connection = sqlConnection;

                int noOfEffectedRows = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return noOfEffectedRows;
            };
        }

        public DataTable Query(string cmd, Dictionary<string, object> parameters)
        {
            string connection = @"Data Source=localhost;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = cmd;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                sqlCommand.Connection = sqlConnection;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                sqlConnection.Close();
                return dt;
            }
        }
    }
}
