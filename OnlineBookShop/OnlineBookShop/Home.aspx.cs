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
    public partial class Home : System.Web.UI.Page
    {
        string stcn = ConfigurationManager.ConnectionStrings["conect"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            SqlConnection con = new SqlConnection(stcn);
            try
            {
                con.Open();
                string q = "select * from SACH";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //this.DataList1.DataSource = dt;
                //this.DataList1.DataBind();
                fillDataList(dt);
                con.Close();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        void fillDataList(DataTable dataTable)
        {
            CollectionPager1.PageSize = 9;// Số items muốn hiển thị trên 1 trang. 
            CollectionPager1.DataSource = dataTable.DefaultView;
            CollectionPager1.BindToControl = DataList1;
            DataList1.DataSource = CollectionPager1.DataSourcePaged;
        }
    }
}