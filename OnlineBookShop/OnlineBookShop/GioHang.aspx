<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="OnlineBookShop.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="prod_box_big">
        <div class="top_prod_box_big"></div>
    <asp:GridView ID="gvGioHang" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvGioHang_RowDeleting" OnRowEditing="gvGioHang_RowEditing" OnRowUpdating="gvGioHang_RowUpdating" OnSelectedIndexChanged="gvGioHang_SelectedIndexChanged" Width="551px" OnRowCancelingEdit="gvGioHang_RowCancelingEdit" HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="Mã Sách">
                <ItemTemplate>
                    <asp:Label ID="lbMaSach" runat="server" Text='<%# Eval("MaSach") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên Sách">
                <ItemTemplate>
                    <asp:Label ID="lbTenSach" runat="server" Text='<%# Eval("TenSach") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Đơn Giá">
                <ItemTemplate>
                    <asp:Label ID="lbDonGia" runat="server" Text='<%# Eval("DonGia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Số Lượng">
                <ItemTemplate>
                    <asp:Label ID="lbSoLuong" runat="server" Text='<%# Eval("SoLuong") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSoLuong" runat="server" Text='<%# Eval("SoLuong") %>' Width="50px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Thành Tiền">
                <ItemTemplate>
                    <asp:Label ID="lbThanhTien" runat="server" Text='<%# Eval("ThanhTien") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>    
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

    </asp:GridView>
         <div class="bottom_prod_box_big"></div>
    </div>
    <div style="font-size:15px;margin-left:25px">
    <strong style="color:green">Tổng tiền: </strong>
    <asp:Label ID="lbTongTien" runat="server" Text="0 VND"></asp:Label>
        <div style="float:right;cursor:pointer;width:75px;height:50px"><asp:Button ID="btnMuaHang" runat="server" Text="Mua hàng" BorderColor="Lime" Height="50px" Width="75px" /></div>
        </div>
</asp:Content>
