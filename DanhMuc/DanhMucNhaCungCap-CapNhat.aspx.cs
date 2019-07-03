using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucNhaCungCap_CapNhat : System.Web.UI.Page
{
    string pIDNhaCungCap = "";
    string Page = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       /* if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
        {
            if (Session["QuanLyNhapXuatHang_Quyen"] != null && Session["QuanLyNhapXuatHang_Quyen"].ToString() != "")
            {
                string Quyen = Session["QuanLyNhapXuatHang_Quyen"].ToString().Trim();
                if(Quyen.CompareTo("Admin") == 0)
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
            if (Request.QueryString["IDNhaCungCap"].Trim() != "")
            {
                pIDNhaCungCap = StaticData.ValidParameter(Request.QueryString["IDNhaCungCap"].Trim());

            }
        }
        catch { }
        try
        {
            Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
        }
        catch
        {  }
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["IDNhaCungCap"].Trim() != "")
                {
                   pIDNhaCungCap = StaticData.ValidParameter(Request.QueryString["IDNhaCungCap"].Trim());

                }
            }
            catch { }
            try
            {
                   Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch {  }

            if (Page.Length > 0 && pIDNhaCungCap.Length > 0)
            {
                LoadThongNhaCungCap();
            }
        }
    }
    private void LoadThongNhaCungCap()
    {
        if (pIDNhaCungCap != "")
        {
            string sql = "select * from NhaCungCap where IDNhaCungCap =" + pIDNhaCungCap + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN NHÀ CUNG CẤP";
                btLuu.Text = "SỬA";
                txtTenNhaCungCap.Value = table.Rows[0]["TenNhaCungCap"].ToString();
                txtSoDienThoai.Value = table.Rows[0]["SDT"].ToString();
                txtMaNhaCungCap.Value = table.Rows[0]["MaNhaCungCap"].ToString();
                txtDiaChi.Value = table.Rows[0]["DiaChi"].ToString();
                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();
        
            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDNhaCungCap.Length <= 0)
        {
            string MaNhaCungCap = txtMaNhaCungCap.Value.Trim();
            string TenNhaCungCap = txtTenNhaCungCap.Value.Trim();
            string SoDienThoai = txtSoDienThoai.Value.Trim();
            string DiaChi = txtDiaChi.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
            DataTable a = Connect.GetTable("select * from NhaCungCap where MaNhaCungCap = N'" + MaNhaCungCap + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã nhà cung cấp đã tồn tại!')</script>");
                return;
            }
            if (MaNhaCungCap.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập mã nhà cung cấp !')</script>");
                return;
            }
            if (TenNhaCungCap.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên nhà cung cấp !')</script>");
                return;
            }

            string sql = " insert into NhaCungCap values (N'" + MaNhaCungCap + "',N'" + TenNhaCungCap + "',N'" + SoDienThoai + "',N'" + DiaChi + "',N'" + GhiChu + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("DanhMucNhaCungCap.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi !')</script>");
                return;
            }
        }
        else
        {
            string MaNhaCungCap = txtMaNhaCungCap.Value.Trim();
            string TenNhaCungCap = txtTenNhaCungCap.Value.Trim();
            string SoDienThoai = txtSoDienThoai.Value.Trim();
            string DiaChi = txtDiaChi.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
           
            if (MaNhaCungCap.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập mã nhà cung cấp !')</script>");
                return;
            }
            if (TenNhaCungCap.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên nhà cung cấp !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("select * from NhaCungCap where MaNhaCungCap = N'" + MaNhaCungCap + "' and IDNhaCungCap <> "+pIDNhaCungCap+"");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã nhà cung cấp đã tồn tại!')</script>");
                return;
            }
            string sql = "update NhaCungCap set MaNhaCungCap = N'" + MaNhaCungCap + "',TenNhaCungCap=N'" + TenNhaCungCap + "',SDT=N'" + SoDienThoai + "',DiaChi=N'" + DiaChi + "',GhiChu=N'" + GhiChu + "' where IDNhaCungCap = " + pIDNhaCungCap + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if(Page.Length > 0)
                Response.Redirect("DanhMucNhaCungCap.aspx?Page="+Page);
            }
            else
            {
                Response.Write("<script>alert('Lỗi mã nhà cung cấp đã được dùng !')</script>");
                return;
            }
        }

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("DanhMucNhaCungCap.aspx?Page=" + Page);
        else
        {
            Response.Redirect("DanhMucNhaCungCap.aspx");
        }
    }
}