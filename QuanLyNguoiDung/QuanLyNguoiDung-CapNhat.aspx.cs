using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyNguoiDung_QuanLyNguoiDung_CapNhat : System.Web.UI.Page
{
    string pTaiKhoan = "";
   
    string Page = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["BanSiQuanAo_Login"] != null && Request.Cookies["BanSiQuanAo_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["BanSiQuanAo_Quyen"] != null && Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim();
                if (Quyen.CompareTo("Admin") == 0)
                {

                }
                else
                {
                    Response.Redirect("../Home/Default.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Home/DangNhap.aspx");
        }
        try
        {
            if (Request.QueryString["IDNguoiDung"].Trim() != "")
            {
                pTaiKhoan = StaticData.ValidParameter(Request.QueryString["IDNguoiDung"].Trim());

            }
        }
        catch { }
        try
        {
            Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
        }
        catch
        { }
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["IDNguoiDung"].Trim() != "")
                {
                    pTaiKhoan = StaticData.ValidParameter(Request.QueryString["IDNguoiDung"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            if (Page.Length > 0 && pTaiKhoan.Length > 0)
            {
                LoadThongTinChungLoai();
            }
        }
    }
    private void LoadThongTinChungLoai()
    {
        if (pTaiKhoan != "")
        {
            string sql = "select * from NguoiDung where IDNguoiDung =" + pTaiKhoan + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN NGƯỜI DÙNG";
                btLuu.Text = "SỬA";
                txtHoTen.Value = table.Rows[0]["TenNguoiDung"].ToString();
                slQuyen.Value = table.Rows[0]["Quyen"].ToString();
                txtTaiKhoan.Value = table.Rows[0]["TaiKhoan"].ToString();
                txtMatKhau.Value = table.Rows[0]["MatKhau"].ToString();

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pTaiKhoan.Length <= 0)
        {
            string HoTen = txtHoTen.Value.Trim();
            string TaiKhoan = txtTaiKhoan.Value.Trim();
            string MatKhau = txtMatKhau.Value.Trim();
            string Quyen = slQuyen.Value.Trim();
            if (HoTen.Length <= 0 || TaiKhoan.Length <= 0 || MatKhau.Length <= 0 || Quyen.Length <= 0)
            {

                Response.Write("<script>alert('Các thông tin phải được điền đầy đủ');</script>");
                return;
            }
            string sql = "  insert into NguoiDung values (N'" + TaiKhoan + "',N'" + MatKhau + "',N'" + HoTen + "',N'" + Quyen + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
                Response.Redirect("QuanLyNguoiDung.aspx");
            else
            {
                Response.Write("<script>alert('Lỗi hãy kiểm tra các thông tin và chắc rằng: Tài khoản phải là duy nhất và các thông tin không được bỏ trống, có thể tài khoản của bạn vừa nhập trùng với tài khoản khác');</script>"); return;
            }
        }
        else
        {
            string HoTen = txtHoTen.Value.Trim();
            string TaiKhoan = txtTaiKhoan.Value.Trim();
            string MatKhau = txtMatKhau.Value.Trim();
            string Quyen = slQuyen.Value.Trim();
            if (HoTen.Length <= 0 || TaiKhoan.Length <= 0 || MatKhau.Length <= 0 || Quyen.Length <= 0)
            {

                Response.Write("<script>alert('Các thông tin phải được điền đầy đủ');</script>");
                return;
            }
            string sql = "  update NguoiDung set TaiKhoan=N'" + TaiKhoan + "',MatKhau = N'" + MatKhau + "',Quyen=N'" + Quyen + "',TenNguoiDung=N'" + HoTen + "' where IDNguoiDung="+pTaiKhoan+"";
            bool kq = Connect.Exec(sql);
            if (kq) { if(Page.Length >0)
        Response.Redirect("QuanLyNguoiDung.aspx?Page="+Page);
        else Response.Redirect("QuanLyNguoiDung.aspx");}
              
            else
            {
                Response.Write("<script>alert('Lỗi hãy kiểm tra các thông tin và chắc rằng: Tài khoản phải là duy nhất,có thể tài khoản của bạn vừa nhập đã tồn tại và các thông tin không được bỏ trống');</script>"); return;
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length >0)
        Response.Redirect("QuanLyNguoiDung.aspx?Page="+Page);
        else Response.Redirect("QuanLyNguoiDung.aspx");
    }
}