using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucKhachHang_CapNhat : System.Web.UI.Page
{
    string pIDKhachHang = "";
    string Page = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
        {
            if (Session["QuanLyNhapXuatHang_Quyen"] != null && Session["QuanLyNhapXuatHang_Quyen"].ToString() != "")
            {
                string Quyen = Session["QuanLyNhapXuatHang_Quyen"].ToString().Trim();
                if (Quyen.CompareTo("Admin") == 0)
                {

                }
                else
                {
                    Response.Redirect("../Home/Default.aspx");
                }
            }
        }*/
        if (Request.Cookies["BanSiQuanAo_Login"] != null && Request.Cookies["BanSiQuanAo_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["BanSiQuanAo_Quyen"] != null && Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim();
                if (Quyen.CompareTo("Admin") == 0 || Quyen.CompareTo("NhanVien") == 0)
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
            if (Request.QueryString["IDKhachHang"].Trim() != "")
            {
                pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

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
                if (Request.QueryString["IDKhachHang"].Trim() != "")
                {
                    pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            if (Page.Length > 0 && pIDKhachHang.Length > 0)
            {
                LoadThongTinKhachHang();
            }
        }
    }
    private void LoadThongTinKhachHang()
    {
        string sql = "select * from KhachHang where IDKhachHang =" + pIDKhachHang + "";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            dvTitle.InnerHtml = "SỬA THÔNG TIN KHÁCH HÀNG";
            btLuu.Text = "SỬA";
            txtMaKhachHang.Value = table.Rows[0]["MaKhachHang"].ToString();
            txtTenKhachHang.Value = table.Rows[0]["TenKhachHang"].ToString();
            txtSoDienThoai.Value = table.Rows[0]["DienThoai"].ToString();
            txtDiaChi.Value = table.Rows[0]["DiaChi"].ToString();
            txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();
          
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
         if (pIDKhachHang.Length <= 0)
         {
             string MaKhachHang = txtMaKhachHang.Value.Trim();
             string TenKhachHang = txtTenKhachHang.Value.Trim();
             string SoDienThoai = txtSoDienThoai.Value.Trim();
             string GhiChu = txtGhiChu.Value.Trim();
             string DiaChi = txtDiaChi.Value.Trim();
             string MaSoThue = txtMaSoThue.Value.Trim();
             string SoTaiKhoan = txtSoTaiKhoan.Value.Trim();
             string LoaiKhachHang = txtLoaiKhachHang.Value.Trim();
             string Email = txtEmail.Value.Trim();
             if (MaKhachHang.Length <= 0)
             {
                 Response.Write("<script>alert('Mã khách không được trống !')</script>");
                 return;
             }
             DataTable a = Connect.GetTable("SELECT  * FROM [KhachHang] where MaKhachHang =N'" + MaKhachHang + "'");
             if(a.Rows.Count > 0)
             {
                 Response.Write("<script>alert('Mã khách đã được dùng !')</script>");
                 return;
             }
            
             if (TenKhachHang.Length <= 0)
             {
                 Response.Write("<script>alert('Tên khách không được trống !')</script>");
                 return;
             }

             string sql = "insert into KhachHang values(N'" + MaKhachHang + "',N'" + TenKhachHang + "',N'" + SoDienThoai + "',N'" + DiaChi + "', N'" + GhiChu + "', '" + MaSoThue + "', '" + SoTaiKhoan + "', N'" + LoaiKhachHang + "', '" + Email + "')";
             bool kq = Connect.Exec(sql);
             if (kq)
             {
                 Response.Redirect("DanhMucKhachHang.aspx");
             }
             else
             {
                 Response.Write("<script>alert('Lỗi !')</script>");
                 return;
             }
         }
         else
         {
             string MaKhachHang = txtMaKhachHang.Value.Trim();
             string TenKhachHang = txtTenKhachHang.Value.Trim();
             string CapDaiLy = "";
             string SoDienThoai = txtSoDienThoai.Value.Trim();
             string GhiChu = txtGhiChu.Value.Trim();
             string DiaChi = txtDiaChi.Value.Trim();

         
             if (MaKhachHang.Length <= 0)
             {
                 Response.Write("<script>alert('Mã khách không được trống !')</script>");
                 return;
             }
             DataTable a = Connect.GetTable("SELECT  * FROM [KhachHang] where MaKhachHang =N'" + MaKhachHang + "' and IDKhachHang <> "+pIDKhachHang+" ");
             if (a.Rows.Count > 0)
             {
                 Response.Write("<script>alert('Mã khách đã được dùng !')</script>");
                 return;
             }
            
             if (TenKhachHang.Length <= 0)
             {
                 Response.Write("<script>alert('Tên khách không được trống !')</script>");
                 return;
             }

             string sql = "update KhachHang set MaKhachHang = N'" + MaKhachHang + "',TenKhachHang =N'" + TenKhachHang + "',DienThoai=N'" + SoDienThoai + "',DiaChi=N'" + DiaChi + "',GhiChu=N'" + GhiChu + "' where IDKhachHang = " + pIDKhachHang + "";
             bool kq = Connect.Exec(sql);
             if (kq)
             {
                 if (Page.Length > 0)
                     Response.Redirect("DanhMucKhachHang.aspx?Page=" + Page);
                 else Response.Redirect("DanhMucKhachHang.aspx");
             }
             else
             {
                 Response.Write("<script>alert('Lỗi mã khách hàng đã được dùng !')</script>");
                 return;
             }
         }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length > 0)
            Response.Redirect("DanhMucKhachHang.aspx?Page="+Page);
        else Response.Redirect("DanhMucKhachHang.aspx");
    }
}