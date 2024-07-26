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
        public void crud(string querry)
        {

        }
    }
}

