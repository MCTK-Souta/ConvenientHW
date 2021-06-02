using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Heleper
{
    public class UserManager
    {
        public static void CreateTeam(Team teammodel)
        {
            string connectionstring = DBBase.GetConnectionString();

            string queryString =
                $@"
                INSERT INTO Team
                    (TeamName,Img, Ac_ID, Shop_ID, State)
                VALUES
                    (@TeamName,@Img, @Ac_ID, @Shop_ID, @State);
                ";



            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@TeamName", teammodel.TeamName);
                command.Parameters.AddWithValue("@Img", teammodel.Img);
                command.Parameters.AddWithValue("@Ac_ID", teammodel.Ac_ID);
                command.Parameters.AddWithValue("@Shop_ID", teammodel.Shop_ID);
                command.Parameters.AddWithValue("@State", "0");


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex.Message);
                }
            }
        }

    }
}