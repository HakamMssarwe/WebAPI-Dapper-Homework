using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperDemo
{

    public abstract class DataAccess
    {

        public static List<User> GetUsers()
        {

            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetServerConnectionString("SQLExpress")))
            {
                try
                {
                    return connection.Query<User>("dbo.GetUsers").ToList();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

        }


        public static bool UserIsValid(string username, string password)
        {

           using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetServerConnectionString("SQLExpress")))
           {
                return connection.Query<User>("dbo.UserIsValid @Username, @Password", new { Username = username.ToLower() , Password = password }).ToList().Count != 0;
           }
        }


        public static bool CreateUser(string username, string password)
        {

            try
            {
                using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetServerConnectionString("SQLExpress")))
                {
                    List<User> users = new List<User>();
                    users.Add(new User { Username = username , Password = password });
                    connection.Execute("dbo.CreateUser @Username, @Password", users);
                }

            }
            catch
            {
                return false;
            }

            return true;
        }


        public static bool DeleteUser(string username,string password)
        {
            if (UserIsValid(username,password))
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetServerConnectionString("SQLExpress")))
            {
                connection.Execute("dbo.DeleteUser @Username", new { Username = username});
                return true;
            }

            return false;
        }

        public static bool ChangePassword(string username, string newPassword)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetServerConnectionString("SQLExpress")))
                {
                    connection.Execute("dbo.ChangePassword @Username, @NewPassword", new { Username = username , NewPassword = newPassword });
                    return true;
                }


            }
            catch { return false; }

        }


        public static bool UsernameIsValid(string username)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetServerConnectionString("SQLExpress")))
            {

                try { return connection.Query<User>("dbo.GetUsername @Username", new {Username = username.ToLower()}).ToList().Count != 0; }
                
                catch { return false; }

            }


        }



    }
}
