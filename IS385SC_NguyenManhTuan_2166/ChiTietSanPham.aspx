<%@ Page Title="" Language="C#" MasterPageFile="~/QLBanHang.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="IS385SC_NguyenManhTuan_2166.ChiTietSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
            <div style="display:flex;">
                <div style="margin-right:10px">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/Image/"+ Eval("HinhAnh") %>' Width="200px"/>
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenHang") %>'></asp:Label><br/>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Mota") %>'></asp:Label><br/>
                    <asp:Label ID="Label3" runat="server" Text="Đơn giá:"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("DonGia","{0:0,0}") %>'></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("DonViTinh") %>'></asp:Label><br/>
                    <asp:Label ID="Label6" runat="server" Text="Số lượng"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/>
                    <asp:Button ID="Button1" runat="server" Text="Mua" />
                    <asp:Button ID="Button2" runat="server" Text="Xem giỏ hàng" />
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
