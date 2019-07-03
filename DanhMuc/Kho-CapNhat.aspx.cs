using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_MauSac_CapNhat : System.Web.UI.Page
{
    string pIDMauSac = "";
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
            if (Request.QueryString["IDMauSac"].Trim() != "")
            {
                pIDMauSac = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());

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
                if (Request.QueryString["IDMauSac"].Trim() != "")
                {
                    pIDMauSac = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }

            if (Page.Length > 0 && pIDMauSac.Length > 0)
            {
                LoadThongDVT();
            }
        }
    }
    private void LoadThongDVT()
    {
        if (pIDMauSac != "")
        {
            string sql = "select * from Kho where IDKho =" + pIDMauSac + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN KHO";
                btLuu.Text = "SỬA";
                txtMaMauSac.Value = table.Rows[0]["MaKho"].ToString();
                txtTenMauSac.Value = table.Rows[0]["TenKho"].ToString();

                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDMauSac.Length <= 0)
        {
            string MaMauSac = txtMaMauSac.Value.Trim();
            string TenMauSac = txtTenMauSac.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();

          

            if (MaMauSac.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập mã Kho !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("select * from Kho where MaKho = N'" + MaMauSac + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã Kho đã tồn tại!')</script>");
                return;
            }
            if (TenMauSac.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên kho !')</script>");
                return;
            }

            string sql = "  insert into Kho values(N'" + MaMauSac + "',N'" + TenMauSac + "',N'" + GhiChu + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
               // if (Page.Length > 0)
                Response.Redirect("Kho.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi  !')</script>");
                return;
            }
        }
        else
        {
            string MaMauSac = txtMaMauSac.Value.Trim();
            string TenMauSac = txtTenMauSac.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();

            if (MaMauSac.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập mã Kho !')</script>");
                return;
            }
            if (TenMauSac.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên Kho !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("select * from Kho where MaKho = N'" + MaMauSac + "' and IDKho <> " + pIDMauSac + " ");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã Kho đã tồn tại!')</script>");
                return;
            }
            string sql = "update Kho set MaKho=N'" + MaMauSac + "',TenKho=N'" + TenMauSac + "', GhiChu=N'" + GhiChu + "' where IDKho=" + pIDMauSac + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                 if (Page.Length > 0)
                     Response.Redirect("Kho.aspx?Page=" + Page);
                 else Response.Redirect("Kho.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi internet !')</script>");
                return;
            }
        }

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("Kho.aspx?Page=" + Page);
        else
        {
            Response.Redirect("Kho.aspx");
        }
    }
}