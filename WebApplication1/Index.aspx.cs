using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Heleper;
using WebApplication1.View;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        private string _saveFolder = "~/FileDownload/";
        protected void Page_Load(object sender, EventArgs e)
        {
            var helper = new SELECTHelper();
            this.Repeater1.DataSource = helper.GetOpenTeam(this.txtSeach.Text);
            this.Repeater1.DataBind();
        }
        protected void repList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var model = e.Item.DataItem as TeamViewModel;
                var img = e.Item.FindControl("img") as Image;

                if (!string.IsNullOrWhiteSpace(model.Img))
                {
                    img.ImageUrl = this._saveFolder + model.Img;
                    img.Visible = true;
                }

            }
        }

        protected void btn_Sumit_Click(object sender, EventArgs e)
        {

        }
    }
}