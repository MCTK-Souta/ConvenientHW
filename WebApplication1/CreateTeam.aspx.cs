using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Heleper;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CreateTeam : System.Web.UI.Page
    {
        //接受檔案類型
        private string[] _allowExts = { ".jpg", ".png", ".bmp", ".gif" };
        //存檔路徑
        private string _saveFolder = "~/FileDownload/";
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

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SELECTHelper sELECT = new SELECTHelper();
                sELECT.GetShoplList(ref ShopList);
            }
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            Team teammodel = new Team();
            if (this.txtTeamName.Text != string.Empty &&
                this.ShopList.SelectedIndex != 0 &&
                this.FileUpload1.FileName != string.Empty)
            {
                teammodel.TeamName = this.txtTeamName.Text;
                teammodel.Shop_ID = Convert.ToInt32(this.ShopList.SelectedItem.Value);
                teammodel.Ac_ID = (int)Session["Ac_ID"];
                var img = this.GetNewFileName(this.FileUpload1);
                if (img == string.Empty)
                {
                    this.Label1.Text = "僅接受圖片檔：'.jpg', '.png', '.bmp', '.gif'";
                    this.Label1.Visible = true;
                    return;
                }
                teammodel.Img = img;

                UserManager.CreateTeam(teammodel);
                this.Label1.Text = "開團成功";
                this.Label1.Visible = true;
            }
            else
            {
                this.Label1.Text = "各欄位及圖片不可為空";
                this.Label1.Visible = true;
            }
        }

        private string GetNewFileName(FileUpload fu)
        {
            //如無檔案則回傳空字串
            if (!fu.HasFile)
                return string.Empty;

            //取得檔案
            var uFile = fu.PostedFile;
            //取得檔案名稱
            var fileName = uFile.FileName;
            //取得副檔名(檔案類型)
            string fileExt = System.IO.Path.GetExtension(fileName);
            //判別檔案類型
            if (!_allowExts.Contains(fileExt.ToLower()))
                return string.Empty;

            //存檔路徑
            string path = Server.MapPath(_saveFolder);
            //取名為GUID
            string newFileName = Guid.NewGuid().ToString() + fileExt;
            //路徑+檔名
            string fullPath = System.IO.Path.Combine(path, newFileName);
            //存檔
            uFile.SaveAs(fullPath);
            return newFileName;
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            this.txtTeamName.Text = string.Empty;
            this.ShopList.SelectedIndex = 0;
            this.FileUpload1 = null;
        }
    }
}