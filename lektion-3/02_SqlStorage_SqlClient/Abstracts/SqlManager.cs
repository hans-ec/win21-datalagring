using _02_SqlStorage_SqlClient.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_SqlClient.Abstracts
{
    public abstract class SqlManager
    {
        protected string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-3\02_SqlStorage_SqlClient\Data\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        protected virtual object ExecuteScalar(string sqlQuery, Dictionary<string, object> parameters)
        {
            using (var _conn = new SqlConnection(_connectionString))
            {
                _conn.Open();
                using var cmd = new SqlCommand(sqlQuery, _conn);

                foreach (var parameter in parameters)
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);

                var result = cmd.ExecuteScalar();
                _conn.Close();

                return result;
            }

        }

        protected abstract IEnumerable<object> ExecuteReader(string sqlQuery);
    }
}
