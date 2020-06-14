using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop
{
    public partial class GioHang : System.Web.UI.Page
    {
        DataTable cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lbTitleBar")).Text = "Giỏ hàng của bạn";
            if (!IsPostBack)
            {
                fillDataToGV();
            }
          
        }

        protected void gvGioHang_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            cart = (DataTable)Session["cart"];
            Label maSach = gvGioHang.Rows[e.RowIndex].FindControl("lbMaSach") as Label;
            cart.Select("MaSach='"+maSach.Text+"'").ToList().ForEach(x => x.Delete());
            cart.AcceptChanges();
            Session["cart"] = cart;
            fillDataToGV();
        }

        void fillDataToGV()
        {
            cart = new DataTable();
            cart = (DataTable)Session["cart"];
            gvGioHang.DataSource = cart;
            gvGioHang.DataBind();
            //if (Session["cart"] == null) { ((Label)Master.FindControl("lbNumItems")).Text = "0 items"; return; }
            //((Label)Master.FindControl("lbNumItems")).Text = ((DataTable)Session["cart"]).Rows.Count.ToString() + " items";
            changerNumItemsAndPrice();
        }

        protected void gvGioHang_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGioHang.EditIndex = e.NewEditIndex;
            fillDataToGV();
        }

        protected void gvGioHang_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
          Label maSach = gvGioHang.Rows[e.RowIndex].FindControl("lbMaSach") as Label;
            TextBox soLuong = gvGioHang.Rows[e.RowIndex].FindControl("txtSoLuong") as TextBox;
            cart = (DataTable)Session["cart"];
            foreach (DataRow dr in cart.Rows)
            {
                if (dr["MaSach"].ToString().Trim().Equals(maSach.Text.ToString().Trim()))
                {
                    dr["SoLuong"] = soLuong.Text.Trim();
                    dr["ThanhTien"] = int.Parse(dr["DonGia"].ToString()) * int.Parse(dr["SoLuong"].ToString());
                    break;
                }
            }
            Session["cart"] = cart;
            gvGioHang.EditIndex = -1;
            fillDataToGV();
        }

        protected void gvGioHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvGioHang_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvGioHang.EditIndex = -1;
            fillDataToGV();
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
                lbTongTien.Text = Context.Items["tongTien"].ToString() + " VND";
            }
        }
        }
}