using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS385SC_NguyenManhTuan_2166
{
    public partial class SanPham : System.Web.UI.Page
    {
        DatabaseConnect db = new DatabaseConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack) { return; }
            string maDanhMuc = Request.QueryString["MaDanhMuc"];
            string querry = "";
            if (!string.IsNullOrEmpty(maDanhMuc) )
                querry = "select * from HangHoa where MaDanhMuc = '" + maDanhMuc + "'";
            this.DataList2.DataSource = db.getData(querry);
            this.DataList2.DataBind();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string MaHang = ((LinkButton)sender).CommandArgument;
            Response.Redirect("ChiTietSanPham.aspx?MaHang=" + MaHang);
        }
    }
}