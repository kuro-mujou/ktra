using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS385SC_NguyenManhTuan_2166
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        DatabaseConnect db = new DatabaseConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack) { return; }
            string maHang = Request.QueryString["MaHang"];
            string querry = "";
            if (!string.IsNullOrEmpty(maHang))
                querry = "select * from HangHoa where MaHang = '" + maHang + "'";
            this.DataList2.DataSource = db.getData(querry);
            this.DataList2.DataBind();
        }
    }
}