<%@ Page Title="" Language="C#" MasterPageFile="~/QLBanHang.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="IS385SC_NguyenManhTuan_2166.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList ID="DataList2" runat="server" RepeatColumns="3">
        <ItemTemplate>
            <div style="margin:20px">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/Image/"+ Eval("HinhAnh") %>' Width="100%"/>
                <br />
                <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("TenHang") %>' CommandArgument='<%# Eval("MaHang")%>' OnClick="LinkButton2_Click"></asp:LinkButton>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Đơn giá"></asp:Label>
                &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# Eval("DonGia","{0:0,0}") %>'></asp:Label>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("DonViTinh") %>'></asp:Label>
            </div>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
