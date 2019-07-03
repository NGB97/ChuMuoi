using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_DangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btDangNhap_Click(object sender, EventArgs e)
    {
       
        string Username = txtTenDangNhap.Value.Trim();
        string Password = txtMatKhau.Value.Trim();
        if (Username == "")
        {
           Response.Write("<script>alert('Bạn chưa nhập tên đăng nhập !')</script>");
          // ThongBao.InnerHtml = "<p>Bạn chưa nhập tên đăng nhập</p>";
            return;
        }
        if (Password == "")
        {
            Response.Write("<script>alert('Bạn chưa nhập mật khẩu !')</script>");
            return;
        }
        DataTable tbCheckUsername = Connect.GetTable("select top 1 * from NguoiDung where TaiKhoan=N'" + StaticData.ValidParameter(Username) + "'");
        if (tbCheckUsername.Rows.Count > 0)
        {
            DataTable tbCheckPassword = Connect.GetTable("select top 1 * from NguoiDung where TaiKhoan=N'" + StaticData.ValidParameter(Username) + "' and MatKhau=N'" + StaticData.ValidParameter(Password) + "'");
            if (tbCheckPassword.Rows.Count > 0)
            {
               /* Session["QuanLyNhapXuatHang_Login"] = Username; 
                Session["QuanLyNhapXuatHang_Quyen"] = tbCheckPassword.Rows[0]["Quyen"].ToString().Trim();
               Response.Redirect("Default.aspx");*/

                HttpCookie cookie_QuanLyNhapXuatHang_Login = new HttpCookie("BanSiQuanAo_Login", Username);
                cookie_QuanLyNhapXuatHang_Login.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie_QuanLyNhapXuatHang_Login);
                string Quyen = tbCheckPassword.Rows[0]["Quyen"].ToString();
                HttpCookie cookie_QuanLyNhapXuatHang_Quyen = new HttpCookie("BanSiQuanAo_Quyen", Quyen);
                cookie_QuanLyNhapXuatHang_Quyen.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie_QuanLyNhapXuatHang_Quyen);

                HttpCookie cookie_QuanLyNhapXuatHang_ID = new HttpCookie("BanSiQuanAo_ID", tbCheckPassword.Rows[0]["IDNguoiDung"].ToString().Trim());
                cookie_QuanLyNhapXuatHang_ID.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie_QuanLyNhapXuatHang_ID);
                //Response.Write("<script>alert('" + Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim() + "')</script>");

               Response.Redirect("Default.aspx");
            }
            else
           {
                Response.Write("<script>alert('Mật khẩu chưa đúng !')</script>");
                return;
            }
        }
        else
        {
            Response.Write("<script>alert('Tên đăng nhập chưa đúng !')</script>");
            return;
        }
    }
}