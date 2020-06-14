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
            if (Context.Items["maLoai"] == null)
                return;
            else
            {
                string maLoai = Context.Items["maLoai"].ToString();
                q = "select * from SACH where MaLoai = '" + maLoai + "'";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, stcn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //this.DataList1.DataSource = dt;
                //this.DataList1.DataBind();
                fillDataList(dt);
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
        protected void lbDetails_Click(object sender, EventArgs e)
        {
            Context.Items["maSach"] = ((LinkButton)sender).CommandArgument.ToString();
            Server.Transfer("chitietsanpham.aspx");
        }
    }
}