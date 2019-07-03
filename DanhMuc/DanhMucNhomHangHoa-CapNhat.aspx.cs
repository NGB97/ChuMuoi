using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucNhomHangHoa_CapNhat : System.Web.UI.Page
{
    string pIDNhomHangHoa = "";
    string Page = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        /* if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
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
            if (Request.QueryString["IDNhomHangHoa"].Trim() != "")
            {
                pIDNhomHangHoa = StaticData.ValidParameter(Request.QueryString["IDNhomHangHoa"].Trim());

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
                if (Request.QueryString["IDNhomHangHoa"].Trim() != "")
                {
                    pIDNhomHangHoa = StaticData.ValidParameter(Request.QueryString["IDNhomHangHoa"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            if (Page.Length > 0 && pIDNhomHangHoa.Length > 0)
            {
                LoadThongTinNhomHangHoa();
            }
        }
    }
    private void LoadThongTinNhomHangHoa()
    {
        if (pIDNhomHangHoa != "")
        {
            string sql = "select * from NhomHangHoa where IDNhomHangHoa =" + pIDNhomHangHoa + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN NHÓM HÀNG HÓA";
                btLuu.Text = "SỬA";
                txtMaNhomHangHoa.Value = table.Rows[0]["MaNhomHangHoa"].ToString();
                txtTenNhomHangHoa.Value = table.Rows[0]["TenNhomHangHoa"].ToString();

                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDNhomHangHoa.Length <= 0)
        {
            string MaNhomHangHoa = txtMaNhomHangHoa.Value.Trim();
            string TenNhomHangHoa = txtTenNhomHangHoa.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
            DataTable a = Connect.GetTable("select * from NhomHangHoa where MaNhomHangHoa = N'" + MaNhomHangHoa + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã nhóm hàng hóa đã tồn tại!')</script>");
                return;
            }
            if (MaNhomHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập mã nhóm hàng hóa !')</script>");
                return;
            }
            if (TenNhomHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên nhóm hàng hóa !')</script>");
                return;
            }
            string sql = "  insert into NhomHangHoa values(N'"+MaNhomHangHoa+"',N'"+TenNhomHangHoa+"',N'"+GhiChu+"')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("DanhMucNhomHangHoa.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi !')</script>");
                return;
            }
        }
        else
        {
            string MaNhomHangHoa = txtMaNhomHangHoa.Value.Trim();
            string TenNhomHangHoa = txtTenNhomHangHoa.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
           
            if (MaNhomHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập mã nhóm hàng hóa !')</script>");
                return;
            }
            if (TenNhomHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên nhóm hàng hóa !')</script>");
                return;
            }
            string sql = " update NhomHangHoa set MaNhomHangHoa=N'" + MaNhomHangHoa + "',TenNhomHangHoa=N'" + TenNhomHangHoa + "',GhiChu=N'" + GhiChu + "' where IDNhomHangHoa=" + pIDNhomHangHoa + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if (Page.Length > 0)
                    Response.Redirect("DanhMucNhomHangHoa.aspx?Page=" + Page);
                else
                {
                    Response.Redirect("DanhMucNhomHangHoa.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Lỗi mã nhóm hàng hóa đã được dùng !')</script>");
                return;
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("DanhMucNhomHangHoa.aspx?Page=" + Page);
        else
        {
            Response.Redirect("DanhMucNhomHangHoa.aspx");
        }
    }
}