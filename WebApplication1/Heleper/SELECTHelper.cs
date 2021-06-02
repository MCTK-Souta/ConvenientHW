using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using WebApplication1.View;

namespace WebApplication1.Heleper
{
    public class SELECTHelper
    {
        public void GetShoplList(ref DropDownList shop)
        {
            string connectionstring = DBBase.GetConnectionString();
            string queryString = $@"SELECT * FROM Shop;";

            SqlConnection connection = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                shop.DataSource = dt;
                shop.DataTextField = "Shop_Name";
                shop.DataValueField = "Shop_ID";
                shop.DataBind();

                shop.Items.Insert(0, "請選擇");
                shop.SelectedIndex = 0;
            }
            connection.Close();

        }

        public void Get(ref DropDownList shop)
        {
            string connectionstring = DBBase.GetConnectionString();
            string queryString = $@"SELECT * FROM Team;";

            SqlConnection connection = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                shop.DataSource = dt;
                shop.DataTextField = "Shop_Name";
                shop.DataValueField = "Shop_ID";
                shop.DataBind();

                shop.Items.Insert(0, "請選擇");
                shop.SelectedIndex = 0;
            }
            connection.Close();

        }

        public List<TeamViewModel> GetOpenTeam(string shop_name)

        {
            List<SqlParameter> dbParameters = new List<SqlParameter>();

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(shop_name))
            {
                conditions.Add(" Shop.Shop_Name LIKE '%' + @Shop_Name + '%'");
                dbParameters.Add(new SqlParameter("@Shop_Name", shop_name));
            }
            string filterConditions =
                 (conditions.Count > 0)
                 ? (" AND " + string.Join(" AND ", conditions))
        :           string.Empty;

            string queryString =
                $@" 
                    SELECT 
                        Team.Team_ID,
                        Team.TeamName,
                        Team.Img,
                        Team.Shop_ID,
                        Team.State,
                        Team.Ac_ID,
                        Shop.Shop_Name,
						Account.Ac_Account
                    FROM Team
                    JOIN Shop
                        ON Team.Shop_ID = Shop.Shop_ID
					LEFT JOIN Account
					ON Account.Ac_ID=Team.Ac_ID
                    WHERE Team.State = '0' OR Team.State='1' {filterConditions}";

            DBBase dB = new DBBase();
            var dt = dB.GetDataTable(queryString, dbParameters);

            List<TeamViewModel> list = new List<TeamViewModel>();

            foreach (DataRow dr in dt.Rows)
            {
                TeamViewModel model = new TeamViewModel();

                model.Team_ID = (int)dr["Team_ID"];
                model.TeamName = (string)dr["TeamName"];
                model.Img = (string)dr["Img"];
                model.Shop_ID = (int)dr["Shop_ID"];
                model.State = (string)dr["State"];
                model.Shop_Name = (string)dr["Shop_Name"];
                model.Ac_Account = (string)dr["Ac_Account"];


                list.Add(model);

            }
            return list;
        }

        public List<TeamViewModel> GetOpenTeamOne(string Team_ID)

        {
            List<SqlParameter> dbParameters = new List<SqlParameter>();



            string queryString =
                $@" 
                    SELECT 
                        Team.Team_ID,
                        Team.TeamName,
                        Team.Img,
                        Team.Shop_ID,
                        Team.State,
                        Team.Ac_ID,
                        Shop.Shop_Name,
						Account.Ac_Account
                    FROM Team
                    JOIN Shop
                        ON Team.Shop_ID = Shop.Shop_ID
					LEFT JOIN Account
					ON Account.Ac_ID=Team.Ac_ID
                    WHERE Team.Team_ID = {Team_ID}";

            DBBase dB = new DBBase();
            var dt = dB.GetDataTable(queryString, dbParameters);
            List<TeamViewModel> list = new List<TeamViewModel>();

            foreach (DataRow dr in dt.Rows)
            {
                TeamViewModel model = new TeamViewModel();

                model.Team_ID = (int)dr["Team_ID"];
                model.TeamName = (string)dr["TeamName"];
                model.Img = (string)dr["Img"];
                model.Shop_ID = (int)dr["Shop_ID"];
                model.State = (string)dr["State"];
                model.Shop_Name = (string)dr["Shop_Name"];
                model.Ac_Account = (string)dr["Ac_Account"];


                list.Add(model);

            }
            return list;
        }

        public string GetStateName(string state)
        {
            switch (state)
            {
                case "0":
                    return "未結團";
                case "1":
                    return "已結團";
                case "2":
                    return "已到";
                default:
                    return "";
            }
        }

        public List<MenuModel> GetMenu(string shop_id)

        {
            List<SqlParameter> dbParameters = new List<SqlParameter>();



            string queryString =
                $@" 
                    SELECT * FROM Menu
                    JOIN Shop
                        ON Menu.Shop_ID = Shop.Shop_ID
                    WHERE Menu.Shop_ID = {shop_id}";

            DBBase dB = new DBBase();
            var dt = dB.GetDataTable(queryString, dbParameters);

            List<MenuModel> list = new List<MenuModel>();

            foreach (DataRow dr in dt.Rows)
            {
                MenuModel model = new MenuModel();

                model.Menu_ID = (int)dr["Menu_ID"];
                model.Menu_Name = (string)dr["Menu_Name"];
                model.Meny_Price = (Decimal)dr["Meny_Price"];
                model.Shop_ID = (int)dr["Shop_ID"];
                model.Menu_Pic = (string)dr["Menu_Pic"];

                list.Add(model);

            }
            return list;
        }


    }
}