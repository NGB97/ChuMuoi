using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucHangHoa_CapNhat : System.Web.UI.Page
{
    string pIDHangHoa = "";
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
            if (Request.QueryString["IDHangHoa"].Trim() != "")
            {
                pIDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

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
                if (Request.QueryString["IDHangHoa"].Trim() != "")
                {
                    pIDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            if (Page.Length > 0 && pIDHangHoa.Length > 0)
            {
                LoadDVT(); //LoadMauSac(); LoadNhomHangHoa();
                LenMau();
                LoadLoaiHangHoa();
                LoadThongTinHangHoa();
               
            }
            else
            {
                LoadDVT();  //LoadMauSac(); LoadNhomHangHoa();
                LenMau();
                LoadLoaiHangHoa();
            }
        }
    }
    private void LenMau()
    {
        string sql = "  select * from MauSac";
        //string strSql = "select * from DonViTinh";
        txtMauSac.DataSource = Connect.GetTable(sql);
        txtMauSac.DataTextField = "TenMauSac";
        txtMauSac.DataValueField = "IDMauSac";
        txtMauSac.DataBind();
        
    }
    private void LoadThongTinHangHoa()
    {
        string sql = "  select * from HangHoa where IDHangHoa="+pIDHangHoa;
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            dvTitle.InnerHtml = "SỬA THÔNG TIN CHI TIẾT HÀNG HÓA";
            btLuu.Text = "SỬA";
            txtMaHangHoa.Value = table.Rows[0]["MaHangHoa"].ToString();
            txtTenHangHoa.Value = table.Rows[0]["TenHangHoa"].ToString();

            string MaDonViTinh =  table.Rows[0]["IDSize"].ToString();
           
            string MaMauSac = table.Rows[0]["IDMauSac"].ToString();

            txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

            txtDVT.Value = MaDonViTinh;
      
            txtMauSac.Value = MaMauSac;
            txtLoaiHangHoa.Value = table.Rows[0]["IDLoaiHangHoa"].ToString();
        }
    }
    private void LoadDVT()
    {
        string strSql = "select * from Size";
        txtDVT.DataSource = Connect.GetTable(strSql);
        txtDVT.DataTextField = "TenSize";
        txtDVT.DataValueField = "IDSize";
        txtDVT.DataBind();
      //  txtDVT.Items.Add(new ListItem("", ""));
        // slQuyen.Items.FindByText("-- Tất cả --").Selected = true;
    }

    private void LoadLoaiHangHoa()
    {
        string strSql = "select * from LoaiHangHoa";
        txtLoaiHangHoa.DataSource = Connect.GetTable(strSql);
        txtLoaiHangHoa.DataTextField = "TenLoaiHangHoa";
        txtLoaiHangHoa.DataValueField = "IDLoaiHangHoa";
        txtLoaiHangHoa.DataBind();
        //  txtDVT.Items.Add(new ListItem("", ""));
        // slQuyen.Items.FindByText("-- Tất cả --").Selected = true;
    }
 
 
    protected void btLuu_Click(object sender, EventArgs e)
    {
      
        if (pIDHangHoa.Length <= 0)
        {
            string MaHangHoa = txtMaHangHoa.Value.Trim();
            string TenHangHoa = txtTenHangHoa.Value.Trim();
            string DVT = txtDVT.Value.Trim();
            string MauSac = txtMauSac.Value.Trim();
            string ChungLoai = txtChungLoai.Value.Trim();
            string NhomHang = txtNhomHang.Value.Trim(); 
            string DongGoi = txtDongGoi.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
            string MaVach = txtMaVach.Value.Trim();
            string IDLoaiHangHoa = txtLoaiHangHoa.Value.Trim();
           
            if (MaHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Mã hàng hóa không được trống !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("  select * from HangHoa where MaHangHoa = N'" + MaHangHoa + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã hàng hóa đã được dùng !')</script>");
                return;
            }
            if (TenHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Tên hàng hóa không được trống !')</script>");
                return;
            }



            string sql = "insert into HangHoa values(N'" + MaHangHoa + "',N'" + TenHangHoa + "'," + DVT + "," + MauSac + ",N'" + GhiChu + "'," + IDLoaiHangHoa + ")";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("DanhMucHangHoa.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi các thông tin bắt buộc có vấn đề !')</script>");
                return;
            }
        }
        else
        {
            string MaHangHoa = txtMaHangHoa.Value.Trim();
            string TenHangHoa = txtTenHangHoa.Value.Trim();
            string DVT = txtDVT.Value.Trim();
            string MauSac = txtMauSac.Value.Trim();
            string ChungLoai = txtChungLoai.Value.Trim();
            string NhomHang = txtNhomHang.Value.Trim(); string DongGoi = txtDongGoi.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
            string MaVach = txtMaVach.Value.Trim();
            string IDLoaiHangHoa = txtLoaiHangHoa.Value.Trim();
          


            if (MaHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Mã hàng hóa không được trống !')</script>");
                return;
            }
            DataTable b = Connect.GetTable("select * from HangHoa where MaHangHoa = N'" + MaHangHoa + "' and IDHangHoa <> " + pIDHangHoa + "");
            if (b.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã hàng hóa đã được dùng !')</script>");
                return;
            }
            if (TenHangHoa.Length <= 0)
            {
                Response.Write("<script>alert('Tên hàng hóa không được trống !')</script>");
                return;
            }
          
         

            //Label1.Text = IDMauSac;

            string sql = "update HangHoa set IDLoaiHangHoa=" + IDLoaiHangHoa + ",MaHangHoa=N'" + MaHangHoa + "',TenHangHoa=N'" + TenHangHoa + "',IDSize = " + DVT + ",IDMauSac=" + MauSac + ",GhiChu=N'" + GhiChu + "' where IDHangHoa = " + pIDHangHoa + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if(Page.Length > 0)
                    Response.Redirect("DanhMucHangHoa.aspx?Page=" + Page);
                else Response.Redirect("DanhMucHangHoa.aspx");
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
            Response.Redirect("DanhMucHangHoa.aspx?Page=" + Page);
        else Response.Redirect("DanhMucHangHoa.aspx");
    }
}