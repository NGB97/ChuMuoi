using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucPhongBan_CapNhat : System.Web.UI.Page
{
    string pIDPhongBan = "";
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
        if (Request.Cookies["QuanLyNhapXuatHang_Login"] != null && Request.Cookies["QuanLyNhapXuatHang_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["QuanLyNhapXuatHang_Quyen"] != null && Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim();
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
            if (Request.QueryString["IDPhongBan"].Trim() != "")
            {
                pIDPhongBan = StaticData.ValidParameter(Request.QueryString["IDPhongBan"].Trim());

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
                if (Request.QueryString["IDPhongBan"].Trim() != "")
                {
                    pIDPhongBan = StaticData.ValidParameter(Request.QueryString["IDPhongBan"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            if (Page.Length > 0 && pIDPhongBan.Length > 0)
            {
                LoadThongTinKhachHang();
            }
        }
    }
    private void LoadThongTinKhachHang()
    {
        string sql = "select * from PhongBan where IDPhongBan =" + pIDPhongBan + "";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            dvTitle.InnerHtml = "SỬA THÔNG TIN PHÒNG BAN";
            btLuu.Text = "SỬA";
            txtMaPhongBan.Value = table.Rows[0]["MaPhongBan"].ToString();
            txtTenPhongBan.Value = table.Rows[0]["TenPhongBan"].ToString();
            DataTable a =Connect.GetTable("select * from KhachHang where IDKhachHang = " + table.Rows[0]["IDKhachHang"].ToString() + "");
            txtTenKhachHang.Value = a.Rows[0]["TenKhachHang"].ToString().Trim();
            txtIDKhachHang.Value = a.Rows[0]["IDKhachHang"].ToString().Trim();
            txtSoDienThoaiPhongBan.Value = table.Rows[0]["SoDienThoaiPhongBan"].ToString().Trim();
            txtDiaChiPhongBan.Value = table.Rows[0]["DiaChiPhongBan"].ToString().Trim();
            txtNguoiLienLac.Value = table.Rows[0]["NguoiLienLac"].ToString().Trim();
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
         if (pIDPhongBan.Length <= 0)
         {
             string MaPhongBan = txtMaPhongBan.Value.Trim();
             string TenPhongBan = txtTenPhongBan.Value.Trim();
             float SapXep = 0;
             string SoDienThoaiPhongBan = txtSoDienThoaiPhongBan.Value.Trim();
             string DiaChiPhongBan = txtDiaChiPhongBan.Value.Trim();
           
             string KhachHang = txtIDKhachHang.Value.Trim();

             DataTable a = Connect.GetTable("SELECT  * from PhongBan where MaPhongBan ='" + MaPhongBan + "'");
             if(a.Rows.Count > 0)
             {
                 Response.Write("<script>alert('Mã phòng ban đã được dùng !')</script>");
                 return;
             }
             if (MaPhongBan.Length <= 0)
             {
                 Response.Write("<script>alert('Mã phòng ban không được trống !')</script>");
                 return;
             }
             if (TenPhongBan.Length <= 0)
             {
                 Response.Write("<script>alert('Tên phòng ban không được trống !')</script>");
                 return;
             }
             if (txtIDKhachHang.Value.Trim().Length <= 0 )
             {
                 Response.Write("<script>alert('Xin chọn lại khách hàng !')</script>");
                 return;
             }
             if (txtTenKhachHang.Value.Trim().Length <= 0)
             {
                 Response.Write("<script>alert('Xin chọn lại khách hàng !')</script>");
                 return;
             }

             string sql = "insert into PhongBan values(N'" + MaPhongBan + "',N'" + TenPhongBan + "',"+KhachHang+",N'"+SoDienThoaiPhongBan+"',N'"+DiaChiPhongBan+"',N'"+txtNguoiLienLac.Value.Trim()+"')";
             bool kq = Connect.Exec(sql);
             if (kq)
             {
                 Response.Redirect("DanhMucPhongBan.aspx");
             }
             else
             {
                 Response.Write("<script>alert('Lỗi !')</script>");
                 return;
             }
         }
         else
         {
             string MaPhongBan = txtMaPhongBan.Value.Trim();
             string TenPhongBan = txtTenPhongBan.Value.Trim();


             string KhachHang = txtIDKhachHang.Value.Trim();

           
             if (MaPhongBan.Length <= 0)
             {
                 Response.Write("<script>alert('Mã phòng ban không được trống !')</script>");
                 return;
             }
             if (TenPhongBan.Length <= 0)
             {
                 Response.Write("<script>alert('Tên phòng ban không được trống !')</script>");
                 return;
             }
             if (txtIDKhachHang.Value.Trim().Length <= 0)
             {
                 Response.Write("<script>alert('Xin chọn lại khách hàng !')</script>");
                 return;
             }
             if (txtTenKhachHang.Value.Trim().Length <= 0)
             {
                 Response.Write("<script>alert('Xin chọn lại khách hàng !')</script>");
                 return;
             }
             string sql = "update PhongBan set NguoiLienLac=N'" + txtNguoiLienLac.Value.Trim() + "',SoDienThoaiPhongBan=N'" + txtSoDienThoaiPhongBan.Value.Trim() + "',DiaChiPhongBan=N'" + txtDiaChiPhongBan.Value.Trim() + "',MaPhongBan= N'" + MaPhongBan + "',TenPhongBan = N'" + TenPhongBan + "',IDKhachHang = " + KhachHang + " where IDPhongBan = " + pIDPhongBan + "";
             bool kq = Connect.Exec(sql);
             if (kq)
             {
                 if (Page.Length > 0)
                     Response.Redirect("DanhMucPhongBan.aspx?Page=" + Page);
                 else Response.Redirect("DanhMucPhongBan.aspx");
             }
             else
             {
                 Response.Write("<script>alert('Lỗi mã phòng ban này đã được dùng !')</script>");
                 return;
             }
         }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length > 0)
            Response.Redirect("DanhMucPhongBan.aspx?Page=" + Page);
        else Response.Redirect("DanhMucPhongBan.aspx");
    }
}