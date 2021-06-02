using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Heleper;
using WebApplication1.Models;
using WebApplication1.View;

namespace WebApplication1
{
    public partial class TeamDetail : System.Web.UI.Page
    {
        private string _saveFolder = "~/FileDownload/";
        private string _MenuPicFolder = "~/MenuImg/";

        protected void Page_Init(object sender, EventArgs e)
        {
            int Type = 1;
            if (Session["Ac_Level"] != null)
            {
                Type = (int)Session["Ac_Level"];
            }


            if (Type != 0)
            {
                HttpContext.Current.Session.RemoveAll();
                Response.Redirect("~/Login.aspx");
            }

            if (!LoginHelper.HasLogined())
            {
                Response.Redirect("~/Login.aspx");
            }
            var helper = new SELECTHelper();
            string Team_ID = Request.QueryString["Team_ID"];
            this.Repeater1.DataSource = helper.GetOpenTeamOne(Team_ID);
            this.Repeater1.DataBind();
            string Shop_ID = Request.QueryString["Shop_ID"];
            this.Repeater2.DataSource = helper.GetMenu(Shop_ID);
            this.Repeater2.DataBind();



        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void repList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            SELECTHelper helper = new SELECTHelper();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var model = e.Item.DataItem as TeamViewModel;
                var img = e.Item.FindControl("img") as Image;

                Literal ltgender = e.Item.FindControl("State") as Literal;
                string val = helper.GetStateName(model.State);
                ltgender.Text = "狀態："+val;

                

                if (!string.IsNullOrWhiteSpace(model.Img))
                {
                    img.ImageUrl = this._saveFolder + model.Img;
                    img.Visible = true;
                }

            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var model = e.Item.DataItem as MenuModel;
                var img = e.Item.FindControl("Menu_img") as Image;




                if (!string.IsNullOrWhiteSpace(model.Menu_Pic))
                {
                    img.ImageUrl = this._saveFolder + model.Menu_Pic;
                    img.Visible = true;
                }

            }
        }
    }
}