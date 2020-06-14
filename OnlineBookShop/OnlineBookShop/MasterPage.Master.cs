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


                q = "SELECT TOP 1 * FROM SACH ORDER BY MASACH DESC";
                da = new SqlDataAdapter(q, con);
                dt = new DataTable();
                da.Fill(dt);
                this.DataList2.DataSource = dt;
                this.DataList2.DataBind();
                con.Close();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            //Set items
            if (Session["cart"] == null)
            {
                lbNumItems.Text = "0 items";
            }
            else lbNumItems.Text = ((DataTable)Session["cart"]).Rows.Count.ToString() + " items";
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string ten = this.Login1.UserName;
            string matkhau = this.Login1.Password;
            string sql = "select * from KHACHHANG where TenDN='" + ten + "' and MatKhau ='" + matkhau + "'";
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, stcn);
                da.Fill(table);

            }
            catch (SqlException ex)
            {
                Response.Write("<b>Error</b>" + ex.Message);
            }
            if (table.Rows.Count != 0)
            {
                Response.Cookies["tendangnhap"].Value = ten;
                //Server.Transfer("sanpham.aspx");
                Response.Write("<b>Dang nhap thanh cong</b>");
            }
            else 
            this.Login1.FailureText = "Ten dang nhap hay mk khong dung";

           
         }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Context.Items["maLoai"] = ((LinkButton)sender).CommandArgument.ToString();
            Server.Transfer("SanPhamTheoLoai.aspx");
        }
    }
}