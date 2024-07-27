using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;

namespace IS385SC_NguyenManhTuan_2166
{
    public class DatabaseConnect
    {
        private SqlConnection connection;
        private void Connect()
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\IS385SC_NguyenManhTuan_2166\IS385SC_NguyenManhTuan_2166\App_Data\QuanLiBanHang.mdf;Integrated Security=True");
            connection.Open();
        }
        private void Disconnect()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public DataTable getData(string querry)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception)
            {
                dataTable = null;
            }
            finally
            {
                Disconnect();
            }
            return dataTable;
        }
        public int xuly(string sql) 
         { 
             int kq = 0; 
             try 
             { 
                 Connect(); 
                 SqlCommand cmd = new SqlCommand(sql, con); 
                 kq = cmd.ExecuteNonQuery();//thuc thi cau len khong can truy van  
             } 
             catch 
             { 
                 kq = 0; 
             } 
             finally 
             { 
                 Disconnect(); 
             } 
             return kq; 
         }

        // them vao cho btn them sua xoa
        protected void btnThem_Click(object sender, EventArgs e) 
        { 
            TextBox txtmaloai = (TextBox)GridView1.FooterRow.FindControl("txtmaloai");  
            TextBox txttenloai = (TextBox)GridView1.FooterRow.FindControl("txttenloai");  
            string maloai=txtmaloai.Text; 
            string tenloai=txttenloai.Text; 
            int kq = kn.xuly("insert into Loai values ('" + maloai + "', '" + tenloai +  "')"); 
        if (kq > 0)//neu cap nhat duoc thi hien thong bao 
        { 
            Response.Write("<script>alert('cap nhat thanh công');</script>");  GridView1.DataSource = kn.laydata("SELECT Loai.* FROM Loai");  GridView1.DataBind(); 
        } 
        else 
        { 
            Response.Write("<script>alert('cap nhat không thanh công');</script>");  } 
        } 
        //- Xử lý cho chức năng Xóa: 
        //Kích chọn GridView -> vào properties -> chọn nút Events, tìm đến thuộc tính RowDeleting  nhấp chuôt và enter 
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)  { 
            string maloai = e.Values["MaLoai"].ToString();
            int kq = kn.capnhat("delete from Loai where MaLoai = "+ maloai);  if (kq > 0)//neu cap nhat duoc thi hien thong bao 
        { 
            Response.Write("<script>alert('Xóa thanh công');</script>");  GridView1.DataSource = kn.laydata("SELECT Loai.* FROM Loai");  GridView1.DataBind(); 
        } 
        else 
        { 
            Response.Write("<script>alert('Xóa không thanh công');</script>");  } 
        } 
        //Tương tự xử lý cho sự kiện sửa 
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)  { 
            GridView1.EditIndex = e.NewEditIndex; 
            GridView1.DataSource = abc.laydata("SELECT Loai.* FROM Loai");  GridView1.DataBind(); 
        } 
        //////////////////////////////////////////////////// 
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)  { 
            GridView1.EditIndex = -1;//không lấy giá trị cột nào hết 
            GridView1.DataSource = kn.laydata("SELECT Loai.* FROM Loai");  GridView1.DataBind(); 
        } 
        
        //////////////////////////////////////////////////////////// 
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)  { 
            string maloai = e.NewValues["MaLoai"].ToString(); 
            string tenloai = e.NewValues["TenLoai"].ToString(); 
            int kq = kn.capnhat("update Loai set MaLoai= '"+ maloai +"', TenLoai='"+  tenloai +"' where MaLoai='"+ maloai +"'"); 
        if (kq > 0)//neu cap nhat duoc thi hien thong bao 
        { 
            Response.Write("<script>alert('Cập nhật thanh công');</script>");  GridView1.DataSource = kn.laydata("SELECT Loai.* FROM Loai");  GridView1.EditIndex = -1; 
            GridView1.DataBind(); 
        } 
        else 
        { 
            Response.Write("<script>alert('Cập nhật không thanh công');</script>");  } 
        }

    }
}

