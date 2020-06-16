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
            else {
                int sum = 0;
                DataTable cart = (DataTable)Session["cart"];
                lbNumItems.Text = ((DataTable)Session["cart"]).Rows.Count.ToString() + " items";
                foreach (DataRow dr in cart.Rows)
                {
                    sum += int.Parse(dr["ThanhTien"].ToString());
                }
                lbTongTien.Text = sum.ToString()+" VND";
            }

            if (Session["tendangnhap"] != null)
            {
                Login1.Visible = false;
                lbLogOut.Visible = true;
                titleLogin.Text = "Chào " + Session["tenkhachhang"].ToString();
            }
            else
            {
                Login1.Visible = true;
                lbLogOut.Visible = false;
                titleLogin.Text = "Login";
            }
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
                Session["tendangnhap"] = ten;
                Session["tenkhachhang"] = table.Rows[0]["TenKH"];
                Server.Transfer("Home.aspx");
            }
            else
            {
                this.Login1.FailureText = "Ten dang nhap hay mk khong dung";
                Server.Transfer("Home.aspx");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["maLoai"] = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("SanPhamTheoLoai.aspx");
        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Session["tendangnhap"] = null;
            Session["tenkhachhang"] = null;
            Login1.Visible = true;
            lbLogOut.Visible = false;
            titleLogin.Text = "Login";
        }
    }
}