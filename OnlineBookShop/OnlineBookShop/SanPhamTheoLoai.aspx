<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SanPhamTheoLoai.aspx.cs" Inherits="OnlineBookShop.SanPhamTheoLoai" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" class="prod_box" runat="server" RepeatColumns="3" >
        <ItemTemplate>
            <div class="prod_box">
            <div class="top_prod_box"></div>
            <div class="center_prod_box">
                  <div class="product_title">
                      <asp:HyperLink ID="hplTitle" runat="server" Text='<%# Eval("TenSach") %>'></asp:HyperLink>
                  </div>
                  <div class="product_img">
                      <asp:HyperLink ID="hplImgProduct" runat="server" NavigateUrl="#">
                          <asp:Image ID="Image1" runat="server" ImageUrl='<%# "images/"+Eval("Hinh") %>' alt="" border="0" Width="115px" Height="150px"/>
                      </asp:HyperLink>  
                  </div>
                  <div class="prod_price">
                      <asp:Label ID="Label1" class="price" runat="server" Text='<%# Eval("DonGia")+" VND" %>'></asp:Label>
                  </div>
            </div>
            <div class="bottom_prod_box"></div>
            <div class="prod_details_tab"> 
                <asp:HyperLink ID="HyperLink1" runat="server">
                    <asp:Image ID="Image2" runat="server" ImageUrl="images/cart.gif" alt="" border="0" class="left_bt"/>
                </asp:HyperLink>
                <asp:LinkButton ID="lbDetails" CommandArgument='<%# Eval("MaSach") %>' runat="server" class="prod_details" Text="details" OnClick="lbDetails_Click"></asp:LinkButton>
            </div>
                </div>
        </ItemTemplate>
    </asp:DataList>
    <cc1:CollectionPager ID="CollectionPager2" ResultsLocation="Bottom" runat="server"></cc1:CollectionPager>
</asp:Content>
