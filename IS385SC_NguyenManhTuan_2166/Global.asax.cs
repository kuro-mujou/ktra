using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace IS385SC_NguyenManhTuan_2166
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();
            //Kiểm tra xem có file Dem.txt
            //Nếu chưa có, tạo file
            if (!System.IO.File.Exists(Server.MapPath("~/Dem.txt")))
                System.IO.File.WriteAllText(Server.MapPath("~/Dem.txt"), "0");
            //Nếu đã có file Dem.txt, đọc số liệu người truy cập
            Application["SoLuotTruyCap"] =
            int.Parse(System.IO.File.ReadAllText(Server.MapPath("~/Dem.txt")));
            Application.UnLock();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            //Tăng số lượt truy cập lên 1
            Application["SoLuotTruyCap"] =
            (int)Application["SoLuotTruyCap"] + 1;
            //Ghi xuống file
            System.IO.File.WriteAllText(Server.MapPath("~/Dem.txt"),
            Application["SoLuotTruyCap"].ToString());
            //Xử lý số người online
            //Nếu chưa có thì gán là 1, có rồi thì tăng 1
            if (Application["SLOnline"] == null)//chưa có
                Application["SLOnline"] = 1;
            else
                Application["SLOnline"] = (int)Application["SLOnline"] + 1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["SLOnline"] = (int)Application["SLOnline"] - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}

//code lab
            //lblSoLuotTC.Text = Application["SoLuotTruyCap"].ToString();
            //lblOnline.Text = Application["SLOnline"].ToString();
//void Application_Start(object sender, EventArgs e)
//{
//    // Code that runs on application startup
//    Application.Lock();
//    RouteConfig.RegisterRoutes(RouteTable.Routes);
//    BundleConfig.RegisterBundles(BundleTable.Bundles);
//    //Kiểm tra xem có file Dem.txt
//    //Nếu chưa có, tạo file
//    if (!System.IO.File.Exists(Server.MapPath("~/Dem.txt")))
//        System.IO.File.WriteAllText(Server.MapPath("~/Dem.txt"), "0");
//    //Nếu đã có file Dem.txt, đọc số liệu người truy cập
//    Application["SoLuotTruyCap"] =
//    int.Parse(System.IO.File.ReadAllText(Server.MapPath("~/Dem.txt")));
//    Application.UnLock();
//}
//void Session_Start(object sender, EventArgs e)
//{
//    // Code that runs when a new session is started
//    //Tăng số lượt truy cập lên 1
//    Application["SoLuotTruyCap"] =
//    (int)Application["SoLuotTruyCap"] + 1;
//    //Ghi xuống file
//    System.IO.File.WriteAllText(Server.MapPath("~/Dem.txt"),
//    Application["SoLuotTruyCap"].ToString());
//    //Xử lý số người online
//    //Nếu chưa có thì gán là 1, có rồi thì tăng 1
//    if (Application["SLOnline"] == null)//chưa có
//        Application["SLOnline"] = 1;
//    else
//        Application["SLOnline"] = (int)Application["SLOnline"] + 1;
//}
//void Session_End(object sender, EventArgs e)
//{
//    Application["SLOnline"] = (int)Application["SLOnline"] - 1;
//}
