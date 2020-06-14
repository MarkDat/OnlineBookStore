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
    public partial class chitietsanpham : System.Web.UI.Page
    {
        string stcn = ConfigurationManager.ConnectionStrings["conect"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            ((Label)Master.FindControl("lbTitleBar")).Text = "Chi tiết sách";
           
            string q;
            if (Context.Items["maSach"] == null)
                return;
            else
            {
                string mahang = Context.Items["maSach"].ToString();
                q = "select * from SACH s, LOAISACH l where MaSach = '" + mahang + "' and s.MaLoai=l.MaLoai";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, stcn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void lBThemVaoGio_Click(object sender, EventArgs e)
        {
            LinkButton mua = (LinkButton)sender;
            string maSach = mua.CommandArgument.ToString(); // Lay bien Agrument o button
           
            DataTable cart;
            if (Session["cart"] == null)
            {
                cart = new DataTable();
                cart.Columns.Add("MaSach");
                cart.Columns.Add("TenSach");
                cart.Columns.Add("DonGia");
                cart.Columns.Add("SoLuong");
                cart.Columns.Add("ThanhTien");
            }
            else { cart = (DataTable)Session["cart"]; }

            DataTable dt = new DataTable();
            try
            {
                string q = "select MaSach,TenSach,DonGia from SACH where  MaSach='" + maSach + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, stcn);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            string ms = dt.Rows[0]["MaSach"].ToString();
            TextBox soLuong = DataList1.Items[0].FindControl("txtInput") as TextBox;
            bool isExisted = false;

            foreach (DataRow dr in cart.Rows)
            {

                if (dr["MaSach"].ToString().Equals(ms))
                {
                    dr["SoLuong"] = soLuong.Text;//Cần sửa
                    dr["ThanhTien"] = int.Parse(dr["DonGia"].ToString()) * int.Parse(dr["SoLuong"].ToString());
                    isExisted = true;
                    break;
                }
            }
            if (!isExisted)
            {
                DataRow row = cart.NewRow();
                row["MaSach"] = ms;
                row["TenSach"] = dt.Rows[0]["TenSach"];
                row["DonGia"] = dt.Rows[0]["DonGia"];
                row["SoLuong"] = soLuong.Text;//Cần sửa
                row["ThanhTien"] = int.Parse(row["DonGia"].ToString()) * int.Parse(row["SoLuong"].ToString());
                cart.Rows.Add(row);
            }
            Session["cart"] = cart;
            changerNumItemsAndPrice();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
        }
        void changerNumItemsAndPrice()
        {
            
            if (Session["cart"] == null)
            {
                ((Label)Master.FindControl("lbNumItems")).Text = "0 items";
            }
            else
            {
                
                int sum = 0;
                DataTable cart = (DataTable)Session["cart"];
                ((Label)Master.FindControl("lbNumItems")).Text = ((DataTable)Session["cart"]).Rows.Count.ToString() + " items";
                foreach (DataRow dr in cart.Rows)
                {
                    sum += int.Parse(dr["ThanhTien"].ToString());
                }
                ((Label)Master.FindControl("lbTongTien")).Text = sum.ToString() + " VND";
                Context.Items["tongTien"] = sum;
            }
        }
    }
}