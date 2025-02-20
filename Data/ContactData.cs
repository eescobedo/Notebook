using CrudNotebook.Models;
using System.Data;
using System.Data.SqlClient;

namespace CrudNotebook.Data
{
    public class ContactData
    {
        public List<ModelContact> ListContacts()
        {
            var lstContacts = new List<ModelContact>();

            var connection = new Connection();

            using (var sqlConnection = new SqlConnection(connection.getConnectionString()))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SP_LIST", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                using (var data = command.ExecuteReader())
                {
                    while (data.Read())
                    {
                        lstContacts.Add(new ModelContact()
                        {
                            IdContact = Convert.ToInt32(data["IdContact"]),
                            Name = data["Name"].ToString(),
                            Phone = data["Phone"].ToString(),
                            Email = data["Email"].ToString()
                        });
                    }
                }
            }
            return lstContacts;
        }

        public ModelContact GetContact(int IdContact)
        {
            ModelContact contact = new ModelContact();
            var connection = new Connection();

            using (var sqlConnection = new SqlConnection(connection.getConnectionString()))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SP_GET", sqlConnection);
                command.Parameters.AddWithValue("@IdContact", IdContact);
                command.CommandType = CommandType.StoredProcedure;

                using (var data = command.ExecuteReader())
                {
                    while (data.Read())
                    {
                        contact.IdContact = Convert.ToInt32(data["IdContact"]);
                        contact.Name = data["Name"].ToString();
                        contact.Phone = data["Phone"].ToString();
                        contact.Email = data["Email"].ToString();
                    }
                }
            }
            return contact;
        }

        public bool Save(ModelContact contact)
        {
            bool response;

            try
            {
                var connection = new Connection();

                using(var sqlConnection = new SqlConnection(connection.getConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SP_SAVE", sqlConnection);
                    command.Parameters.AddWithValue("@Name", contact.Name);
                    command.Parameters.AddWithValue("@Phone", contact.Phone);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();                    
                }
                response = true;
            } catch (Exception ex)
            {
                string errorMesssage = ex.Message;
                response = false;
            }

            return response;
        }

        public bool Edit(ModelContact contact)
        {
            bool response;

            try
            {
                var connection = new Connection();

                using (var sqlConnection = new SqlConnection(connection.getConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SP_EDIT", sqlConnection);
                    command.Parameters.AddWithValue("@IdContact", contact.IdContact);
                    command.Parameters.AddWithValue("@Name", contact.Name);
                    command.Parameters.AddWithValue("@Phone", contact.Phone);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                response = true;
            } catch (Exception ex)
            {
                string errorMesssage = ex.Message;
                response = false;
            }

            return response;
        }

        public bool Delete(int IdContact)
        {
            bool response;

            try
            {
                var connection = new Connection();

                using (var sqlConnection = new SqlConnection(connection.getConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SP_DELETE", sqlConnection);
                    command.Parameters.AddWithValue("@IdContact", IdContact);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception ex)
            {
                string errorMesssage = ex.Message;
                response = false;
            }

            return response;
        }
    }
}
