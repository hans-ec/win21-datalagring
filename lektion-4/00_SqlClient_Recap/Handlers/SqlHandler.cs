using _00_SqlClient_Recap.Entitites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_SqlClient_Recap.Handlers
{
    //cmd.ExecuteNonQuery();  Ger ingenting tillbaka
    //cmd.ExecuteScalar();    Ger ett värde tillbaka såsom Id:t
    //cmd.ExecuteReader();    Ger en hel lista av objekt tillbaka med antalet kolumner som man valt i SELECT


    internal class SqlHandler
    {
        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-4\00_SqlClient_Recap\Data\sql_client_recap.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn))
                {
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        users.Add(new User()
                        {
                            Id = (int)result.GetValue(0),
                            FirstName = (string)result.GetValue(1),
                            LastName = (string)result.GetValue(2),
                            Email = (string)result.GetValue(3)
                        });
                    }

                }
            }

            return users;
        }


        public User GetUserByEmail(string email)
        {
            var users = new List<User>();

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-4\00_SqlClient_Recap\Data\sql_client_recap.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    var result = cmd.ExecuteReader();

                    while(result.Read())
                    {
                        users.Add(new User()
                        {
                            Id = (int)result.GetValue(0),
                            FirstName = (string)result.GetValue(1),
                            LastName = (string)result.GetValue(2),
                            Email = (string)result.GetValue(3)
                        });
                    }

                }
            }

            return users.FirstOrDefault();
        }

        public User GetUser(int id)
        {
            var users = new List<User>();

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-4\00_SqlClient_Recap\Data\sql_client_recap.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Id= @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        users.Add(new User()
                        {
                            Id = (int)result.GetValue(0),
                            FirstName = (string)result.GetValue(1),
                            LastName = (string)result.GetValue(2),
                            Email = (string)result.GetValue(3)
                        });
                    }

                }
            }

            return users.FirstOrDefault();
        }


        public User CreateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-4\00_SqlClient_Recap\Data\sql_client_recap.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email)", conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Email", user.Email);

                        user.Id = (int)cmd.ExecuteScalar();
                        
                    }
                    catch {}
                }
            }

            return user;
        }
    }
}
