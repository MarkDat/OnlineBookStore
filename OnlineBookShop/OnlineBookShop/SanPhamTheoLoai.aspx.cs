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
    public partial class SanPhamTheoLoai : System.Web.UI.Page
    {
        string stcn = ConfigurationManager.ConnectionStrings["conect"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Session["maLoai"] == null)
                return;
            else
            {
                string maLoai = Session["maLoai"].ToString();
                q = "select * from SACH where MaLoai = '" + maLoai + "'";
            }
            SqlConnection con = new SqlConnection(stcn);
            try
            {
                con.Open();
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
            CollectionPager2.PageSize = 9;// Số items muốn hiển thị trên 1 trang. 
            CollectionPager2.DataSource = dataTable.DefaultView;
            CollectionPager2.BindToControl = DataList1;
            DataList1.DataSource = CollectionPager2.DataSourcePaged;
        }
        protected void lbDetails_Click(object sender, EventArgs e)
        {
            Context.Items["maSach"] = ((LinkButton)sender).CommandArgument.ToString();
            Server.Transfer("chitietsanpham.aspx");
        }
    }
}