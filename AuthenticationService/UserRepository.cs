using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace AuthenticationService
{
    public class UserRepository
    {
        private static SqlConnection OpenConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString);
        }

        public User Get(string username, string password)
        {
            User user;
            using (IDbConnection connection = OpenConnection())
            {
                user = connection.Query<User>("Select * from Users where username=@username and password=@password",
                    new {username, password}).SingleOrDefault();
            }

            return user;
        }

        public User GetById(Guid id)
        {
            User user;
            using (IDbConnection connection = OpenConnection())
            {
                user = connection.Query<User>("Select * from Users where id=@id", new { id }).SingleOrDefault();
            }

            return user;
        }
    }
}