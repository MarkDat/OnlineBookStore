using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        string stcn = ConfigurationManager.ConnectionStrings["conect"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            SqlConnection con = new SqlConnection(stcn);
            try
            {
                con.Open();
                string q = "select * from LOAISACH";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
                con.Close();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}