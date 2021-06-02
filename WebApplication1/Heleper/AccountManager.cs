using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Heleper
{
    public class AccountManager:DBBase
    {
        public Account GetAccount(string Account)
        {
            string connectionString = GetConnectionString();
            string queryString =
                $@" SELECT * FROM Account
                    WHERE Ac_Account = @Ac_Account;
                ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Ac_Account", Account);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Account model = null;

                    while (reader.Read())
                    {
                        model = new Account();
                        model.Ac_ID = (int)reader["Ac_ID"];
                        model.Ac_Account = (string)reader["Ac_Account"];
                        model.Password = (string)reader["Password"];
                        model.Ac_Level = (int)reader["Ac_Level"];
                        model.Ac_Pic = (string)reader["Ac_Pic"];

                    }

                    reader.Close();

                    return model;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static DataTable GetUserAccount(string account)
        {
            string connectionstring =
                GetConnectionString();

            string queryString =
                $@" SELECT *
                    FROM Account 
                    WHERE Ac_Account = @account;";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@account", account);



                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }


        }
}