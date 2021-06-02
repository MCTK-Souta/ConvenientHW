using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Heleper;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        private string _goToManager = "Managers/ManagerMainPage.aspx";
        private string _goToIndex = "Index.aspx";
        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                Session.RemoveAll();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string acc = this.txtAccount.Text;
            string pwd = this.txtPassword.Text;


            bool isSuccess = LoginHelper.TryLogin(acc, pwd);



            SqlConnection conn = new SqlConnection(DBBase.GetConnectionString());
            conn.Open();
            SqlCommand Typecheck = new SqlCommand("Select * From Account Where Ac_Level=1 AND Ac_Account='" + txtAccount.Text + "'", conn);
            SqlDataReader Typechk = Typecheck.ExecuteReader();
            AccountManager manager = new AccountManager();
            if (isSuccess)
            {
                this.ltMessage.Text = "Success";

                //將帳號存入Session
                Session["Ac_Level"] = txtAccount.Text;
                Session["IsLogined"] = true;
                Session["Ac_ID"] = manager.GetAccount(txtAccount.Text).Ac_ID;

                if (Typechk.Read())
                {
                    Session["Ac_Level"] = 1;
                    Response.Redirect(this._goToManager);
                }
                else
                {
                    Session["Ac_Level"] = 0;
                    Response.Redirect(this._goToIndex);
                }


            }
            else
            {

                this.ltMessage.Text = "帳號或密碼錯誤，請重新輸入!";
                this.ltMessage.Visible = true;
            }
        }
    }
}