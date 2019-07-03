using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucHangHoa_CapNhat : System.Web.UI.Page
{
    string pIDLoaiHangCapCao = "";
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
            if (Request.QueryString["IDLoaiHangCapCao"].Trim() != "")
            {
                pIDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());

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
                if (Request.QueryString["IDLoaiHangCapCao"].Trim() != "")
                {
                    pIDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }

            if (Page.Length > 0 && pIDLoaiHangCapCao.Length > 0)
            {
                
                LoadThongTinHangHoa();
            }
            else
            {
               
            }
            LoadNhomHangHoa();
        }
    }
    void LoadNhomHangHoa()
    {
        string sql = "select * from NhomHangHoa";
        DataTable table = Connect.GetTable(sql);
        txtLoaiHangCapCao.DataSource = table;
        txtLoaiHangCapCao.DataTextField = "TenNhomHangHoa";
        txtLoaiHangCapCao.DataValueField = "TenNhomHangHoa";
        txtLoaiHangCapCao.DataBind();
    }
  
    private void LoadThongTinHangHoa()
    {
        string sql = "  select * from LoaiHangCapCao where IDLoaiHangCapCao=" + pIDLoaiHangCapCao;
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            dvTitle.InnerHtml = "SỬA THÔNG TIN NHÓM HÀNG HÓA";
            btLuu.Text = "LƯU";
            txtLoaiHangCapCao.Value = table.Rows[0]["TenLoaiCap1"].ToString();
            txtLoaiHangCapCao2.Value =  table.Rows[0]["TenLoaiHangCapCao"].ToString();
        }
    } 
    protected void btLuu_Click(object sender, EventArgs e)
    {

        if (pIDLoaiHangCapCao.Length <= 0)
        {

            string TenLoaiHangCapCao = txtLoaiHangCapCao.Value.Trim();
            string TenLoaiCap2 = txtLoaiHangCapCao2.Value.Trim();


            if (TenLoaiCap2.Length <= 0)
            {
                Response.Write("<script>alert('Tên loại hàng hóa không được trống !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("  select * from LoaiHangCapCao where TenLoaiHangCapCao = N'" + TenLoaiCap2 + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Tên loại hàng hóa đã được dùng !')</script>");
                return;
            }




            string sql = "insert into LoaiHangCapCao values(N'" + TenLoaiCap2 + "',N'" + TenLoaiHangCapCao + "' )";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("DanhMucLoaiHangCapCao.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi các thông tin bắt buộc có vấn đề !')</script>");
                return;
            }
        }
        else
        {
            string TenLoaiHangCapCao = txtLoaiHangCapCao.Value.Trim();
            string TenLoaiCap2 = txtLoaiHangCapCao2.Value.Trim();

            if (TenLoaiCap2.Length <= 0)
            {
                Response.Write("<script>alert('Tên loại hàng hóa không được trống !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("  select * from LoaiHangCapCao where TenLoaiHangCapCao = N'" + TenLoaiCap2 + "' and IDLoaiHangCapCao <> " + pIDLoaiHangCapCao + " ");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Tên loại hàng hóa đã được dùng !')</script>");
                return;
            }
          
         

            //Label1.Text = IDMauSac;

            string sql = "update LoaiHangCapCao set TenLoaiHangCapCao=N'" + TenLoaiCap2 + "', TenLoaiCap1=N'" + TenLoaiHangCapCao + "' where IDLoaiHangCapCao = " + pIDLoaiHangCapCao + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if(Page.Length > 0)
                    Response.Redirect("DanhMucLoaiHangCapCao.aspx?Page=" + Page);
                else Response.Redirect("DanhMucLoaiHangCapCao.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi các thông tin bắt buộc có vấn đề!')</script>");
                return;
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("DanhMucLoaiHangCapCao.aspx?Page=" + Page);
        else Response.Redirect("DanhMucLoaiHangCapCao.aspx");
    }
}