using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DonViTinh_CapNhat : System.Web.UI.Page
{
    string pIDNhomHangHoa = "";
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
            catch { }

            if (Page.Length > 0 && pIDNhomHangHoa.Length > 0)
            {
                LoadThongDVT();
            }
        }
    }
    private void LoadThongDVT()
    {
        if (pIDNhomHangHoa != "")
        {
            string sql = "select * from NhomHangHoa where IDNhomHangHoa =" + pIDNhomHangHoa + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN KIỂU DÁNG";
                btLuu.Text = "SỬA";
                txtTenNhomHangHoa.Value = table.Rows[0]["TenNhomHangHoa"].ToString();  

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDNhomHangHoa.Length <= 0)
        { 
            string TenNhomHangHoa = txtTenNhomHangHoa.Value.Trim();

            if (TenNhomHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên nhóm hàng hoá !')</script>");
                return;
            }

            string sql = "insert into NhomHangHoa values(N'" + TenNhomHangHoa + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("NhomHangHoa.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi  !')</script>");
                return;
            }
        }
        else
        { 
            string TenNhomHangHoa = txtTenNhomHangHoa.Value.Trim();

            if (TenNhomHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên nhóm hàng hoá !')</script>");
                return;
            }
            string sql = " update NhomHangHoa set TenNhomHangHoa = N'" + TenNhomHangHoa + "'  where IDNhomHangHoa = " + pIDNhomHangHoa + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if (Page.Length > 0)
                    Response.Redirect("NhomHangHoa.aspx?Page=" + Page);
                else Response.Redirect("NhomHangHoa.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi !')</script>");
                return;
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length > 0)
        Response.Redirect("NhomHangHoa.aspx?Page="+Page);
        else Response.Redirect("NhomHangHoa.aspx");
    }
}