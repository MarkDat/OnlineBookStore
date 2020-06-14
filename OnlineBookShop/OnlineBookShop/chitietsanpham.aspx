<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="chitietsanpham.aspx.cs" Inherits="OnlineBookShop.chitietsanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <div class="prod_box_big">
        <div class="top_prod_box_big"></div>
        <div class="center_prod_box_big">
          <div class="product_img_big"> 
              <a href="javascript:popImage('images/big_pic.jpg','Some Title')" title="header=[Zoom] body=[&nbsp;] fade=[on]">
                  <asp:Image ID="Image1" ImageUrl='<%# "images/"+Eval("Hinh") %>' runat="server" Width="115" Height="150" />
               </a>
        </div>
          <div class="details_big_box">
            <div class="product_title_big" style="text-align:center">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSach") %>'></asp:Label>
            </div>
            <div class="specifications"> Tên sách: <asp:Label ID="Label2" class="blue" runat="server" Text='<%# Eval("TenSach") %>'></asp:Label><br />
                Loại:<asp:Label ID="Label3" class="blue" runat="server" Text='<%# Eval("TenLoai") %>'></asp:Label><br />
                Nhà xuất bản: <asp:Label ID="Label4" class="blue" runat="server" Text='<%# Eval("NhaXB") %>'></asp:Label><br />  
                Số lượng: <asp:TextBox ID="txtInput" runat="server" Width="50px"></asp:TextBox>
            </div>
              <div class="prod_price_big"><asp:Label ID="Label5" class="price" runat="server" Text='<%# Eval("DonGia")+" VND" %>'></asp:Label></div>
              <asp:LinkButton ID="lBThemVaoGio" runat="server" class="addtocart" CommandArgument='<%# Eval("MaSach") %>' OnClick="lBThemVaoGio_Click" Text="Thêm vào giỏ"></asp:LinkButton>
              <a href="http://all-free-download.com/free-website-templates/" class="compare">Xem giỏ hàng</a> </div>
        </div>
        <div class="bottom_prod_box_big"></div>
      </div>
    <div class="center_title_bar">Mô tả</div>
    <div class="prod_box_big">
        <div class="top_prod_box_big"></div>
        <div style="padding: inherit; background-color: rgb(247, 243, 243)">
            <asp:Label ID="Label6" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
        </div> 
        <div class="bottom_prod_box_big"></div>
    </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
