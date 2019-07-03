using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DonViTinh_CapNhat : System.Web.UI.Page
{
    string pIDKieuDang = "";
    string Page = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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
            if (Request.QueryString["IDKieuDang"].Trim() != "")
            {
                pIDKieuDang = StaticData.ValidParameter(Request.QueryString["IDKieuDang"].Trim());

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
                if (Request.QueryString["IDKieuDang"].Trim() != "")
                {
                    pIDKieuDang = StaticData.ValidParameter(Request.QueryString["IDKieuDang"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch { }

            if (Page.Length > 0 && pIDKieuDang.Length > 0)
            {
                LoadThongDVT();
            }
        }
    }
    private void LoadThongDVT()
    {
        if (pIDKieuDang != "")
        {
            string sql = "select * from KieuDang where IDKieuDang =" + pIDKieuDang + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN kiểu dáng";
                btLuu.Text = "SỬA";
                txtMaKieuDang.Value = table.Rows[0]["MaKieuDang"].ToString();
                txtTenKieuDang.Value = table.Rows[0]["TenKieuDang"].ToString();
              
                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDKieuDang.Length <= 0)
        {
            string MaKieuDang = txtMaKieuDang.Value.Trim();
            string TenKieuDang = txtTenKieuDang.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
          
            if (MaKieuDang.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống mã kiểu dáng !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("SELECT * FROM KieuDang where MaKieuDang = N'" + MaKieuDang + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Bạn nhập mã kiểu dáng đã tồn tại !')</script>");
                return;
            }
            if (TenKieuDang.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên kiểu dáng !')</script>");
                return;
            }

            string sql = "insert into KieuDang values(N'" + MaKieuDang + "',N'" + TenKieuDang + "',N'" + GhiChu + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("KieuDang.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi  !')</script>");
                return;
            }
        }
        else
        {
            string MaKieuDang = txtMaKieuDang.Value.Trim();
            string TenKieuDang = txtTenKieuDang.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
          
            if (MaKieuDang.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống mã kiểu dáng !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("SELECT * FROM KieuDang where MaKieuDang = N'" + MaKieuDang + "' and IDKieuDang <> " + pIDKieuDang + " ");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Bạn nhập mã kiểu dáng đã tồn tại !')</script>");
                return;
            }
            if (TenKieuDang.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên kiểu dáng !')</script>");
                return;
            }

            string sql = " update KieuDang set MaKieuDang = N'" + MaKieuDang + "',TenKieuDang = N'" + TenKieuDang + "', GhiChu = N'" + GhiChu + "' where IDKieuDang = " + pIDKieuDang + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if (Page.Length > 0)
                    Response.Redirect("KieuDang.aspx?Page=" + Page);
                else Response.Redirect("KieuDang.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi mã kiểu dáng này đã được sử dụng !')</script>");
                return;
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length > 0)
        Response.Redirect("KieuDang.aspx?Page="+Page);
        else Response.Redirect("KieuDang.aspx");
    }
}