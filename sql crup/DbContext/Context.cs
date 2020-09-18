using sql_crup.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace sql_crup.DbContext
{
    public class Context : IContext
    {
        
        public void Delete(int? Id)
        {
            string connectionString = "Initial Catalog=sqlCrud; Data Source=DESKTOP-JQU1FL7;Integrated Security=true;";

            string query = $"DELETE FROM Persons WHERE PersonID = {Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteReader();
                connection.Close();
            }
        }

        public List<Persons> Get()
        {
            string connectionString = "Initial Catalog=sqlCrud; Data Source=DESKTOP-JQU1FL7;Integrated Security=true;";
            string query = "Select * From Persons";
            List<Persons> resurt = new List<Persons>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var i = 0;
                    while (reader.Read())
                    {
                        resurt.Add(
                            new Persons
                            {
                                PersonID = (int)reader[0],
                                LastName = (string)reader[1],
                                FirstName = (string)reader[2],
                                Address = (string)reader[3],
                                City = (string)reader[4],
                            }

                            );
                        i++;
                    }
                    connection.Close();
                }
                catch
                {
                    return null;
                }
            }

            return resurt;
        }

        public Persons GetById(int id)
        {
            string connectionString = "Initial Catalog=sqlCrud; Data Source=DESKTOP-JQU1FL7;Integrated Security=true;";
            string query = $"Select * From Persons where PersonID = {id}";
            List<Persons> resurt = new List<Persons>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var i = 0;
                    while (reader.Read())
                    {
                        resurt.Add(
                            new Persons
                            {
                                PersonID = (int)reader[0],
                                LastName = (string)reader[1],
                                FirstName = (string)reader[2],
                                Address = (string)reader[3],
                                City = (string)reader[4],
                            }

                            );
                        i++;
                    }
                    connection.Close();
                }
                catch
                {
                    return null;
                }
            }

            return resurt[0];
        }

        public void Insert(Persons New)
        {
            string connectionString = "Initial Catalog=sqlCrud; Data Source=DESKTOP-JQU1FL7;Integrated Security=true;";

            string query = $"insert into Persons (LastName, FirstName, Address, City) " +
                           $"values('{New.LastName}', '{New.FirstName}', '{New.Address}', '{New.City}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteReader();
                connection.Close();
            }

        }

        public void Update(Persons Up, int Id)
        {
            string connectionString = "Initial Catalog=sqlCrud; Data Source=DESKTOP-JQU1FL7;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Persons SET" +
                                         $" LastName = @LastName, FirstName = @FirstName," +
                                         $"Address = @Address, City = @City" +
                                         $" Where PersonID = @PersonID";


                command.Parameters.AddWithValue("@LastName", Up.LastName);
                command.Parameters.AddWithValue("@FirstName", Up.FirstName);
                command.Parameters.AddWithValue("@Address", Up.Address);
                command.Parameters.AddWithValue("@City", Up.City);
                command.Parameters.AddWithValue("@PersonID", Id);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
