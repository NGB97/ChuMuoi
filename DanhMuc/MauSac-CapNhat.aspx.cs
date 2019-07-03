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
            string sql = "select * from MauSac where IDMauSac =" + pIDMauSac + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN MÀU SẮC";
                btLuu.Text = "SỬA";
                txtMaMauSac.Value = table.Rows[0]["Code"].ToString();
                txtTenMauSac.Value = table.Rows[0]["TenMauSac"].ToString();

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

            DataTable a = Connect.GetTable("select * from MauSac where MaMauSac = N'" + MaMauSac + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã màu sắc đã tồn tại!')</script>");
                return;
            }

            if (MaMauSac.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập mã màu sắc !')</script>");
                return;
            }
            if (TenMauSac.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên màu sắc !')</script>");
                return;
            }

            string sql = "  insert into MauSac values(N'" + MaMauSac + "',N'" + TenMauSac + "',N'" + GhiChu + "',N'" + MaMauSac + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
               // if (Page.Length > 0)
                    Response.Redirect("MauSac.aspx");
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
                Response.Write("<script>alert('Bạn chưa nhập mã màu sắc !')</script>");
                return;
            }
            if (TenMauSac.Length <= 0)
            {
                Response.Write("<script>alert('Bạn chưa nhập tên màu sắc !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("select * from MauSac where MaMauSac = N'" + MaMauSac + "' and IDMauSac <> "+pIDMauSac+" ");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã màu sắc đã tồn tại!')</script>");
                return;
            }
            string sql = "update MauSac set Code=N'" + MaMauSac + "',TenMauSac=N'" + TenMauSac + "', GhiChu=N'" + GhiChu + "' where IDMauSac=" + pIDMauSac + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                 if (Page.Length > 0)
                     Response.Redirect("MauSac.aspx?Page=" + Page);
                 else Response.Redirect("MauSac.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi mã màu sắc này đã được dùng !')</script>");
                return;
            }
        }

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("MauSac.aspx?Page=" + Page);
        else
        {
            Response.Redirect("MauSac.aspx");
        }
    }
}