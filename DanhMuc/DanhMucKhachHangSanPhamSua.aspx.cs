using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucKhachHangSanPham_CapNhat : System.Web.UI.Page
{
    string pIDChiTietGiaTheoKhach = "";
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
            if (Request.QueryString["IDChiTietGiaTheoKhach"].Trim() != "")
            {
                pIDChiTietGiaTheoKhach = StaticData.ValidParameter(Request.QueryString["IDChiTietGiaTheoKhach"].Trim());

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
            LenMau();
            try
            {
                if (Request.QueryString["IDChiTietGiaTheoKhach"].Trim() != "")
                {
                    pIDChiTietGiaTheoKhach = StaticData.ValidParameter(Request.QueryString["IDChiTietGiaTheoKhach"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            if (Page.Length > 0 && pIDChiTietGiaTheoKhach.Length > 0)
            {
                Load();
            }
           
        }
    }
    private void LenMau()
    {
        string sql = "  select * from LoaiHangHoa";
        //string strSql = "select * from DonViTinh";
        //txtIDSanPham.DataSource = Connect.GetTable(sql);
        //txtIDSanPham.DataTextField = "TenLoaiHangHoa";
        //txtIDSanPham.DataValueField = "IDLoaiHangHoa";
        //txtIDSanPham.DataBind();

    }
    private void Load()
    {
        if (pIDChiTietGiaTheoKhach != "")
        {
            string sql = "  select * from ChiTietGiaTheoKhach where IDChiTietGiaTheoKhach =" + pIDChiTietGiaTheoKhach + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN GIÁ BÁN THEO KHÁCH";
                btLuu.Text = "SỬA";
                string TenSanPham = StaticData.getField("HangHoa", "TenHangHoa", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString());

               // txtTenSanPham.Value = TenSanPham; 
                
                
                txtIDSanPham.Value = table.Rows[0]["IDHangHoa"].ToString();
                string TenKhachHang = StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[0]["IDKhachHang"].ToString());
                txtTenKhachHang.Value = TenKhachHang; txtIDKhachHang.Value = table.Rows[0]["IDKhachHang"].ToString();
                double Gia = double.Parse(table.Rows[0]["Gia"].ToString());

                txtGiaBan.Value = Gia.ToString("#,##").Replace(",", ".");
             
                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

                txtIDSanPham.Value = table.Rows[0]["IDHangHoa"].ToString();
                txtTenSanPham.Value = StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", table.Rows[0]["IDHangHoa"].ToString()) +"-"+ StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", table.Rows[0]["IDHangHoa"].ToString());
            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDChiTietGiaTheoKhach.Length <= 0)
        {
            string IDKhachHang = txtIDKhachHang.Value.Trim();
            string IDHangHoa = txtIDSanPham.Value.Trim();
            string TenKhacHang = txtTenKhachHang.Value.Trim();
            string TenSanPham = txtTenSanPham.Value.Trim();
            string GiaBan = txtGiaBan.Value.Trim().Replace(",", "").Replace(".", "");
            double n;
            bool result = double.TryParse(GiaBan, out n);
            if (!result)
            {
                Response.Write("<script>alert('Giá phải là số tự nhiên !')</script>");
                return;
            }

            if (TenKhacHang.Length <= 0)
            {
                Response.Write("<script>alert('Tên khách hàng không được trống !')</script>");
                return;
            }
            if (IDHangHoa.Length <= 0 || txtTenSanPham.Value.Trim().Length <= 0)
            {
                Response.Write("<script>alert('Hàng hóa không được trống !')</script>");
                return;
            }
            string GhiChu = txtGhiChu.Value.Trim();
            DataTable kiemtra = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDHangHoa + "  ");
            if(kiemtra.Rows.Count > 0)
            {
                Response.Write("<script>alert('Khách hàng và hàng hóa này đã được thiết lập giá !')</script>");
                return;
            }
            string sql = "insert into ChiTietGiaTheoKhach values (" + IDKhachHang + "," + IDHangHoa + "," + GiaBan + ",N'"+GhiChu+"')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if (Page.Length > 0)
                    Response.Redirect("DanhMucKhachHangSanPham.aspx?Page=" + Page);
                else Response.Redirect("DanhMucKhachHangSanPham.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi hãy chắc rằng bạn nhập giá đúng định dạng số !')</script>");
                return;
            }
        }
        else
        {
            string IDKhachHang = txtIDKhachHang.Value.Trim();
            string IDHangHoa = txtIDSanPham.Value.Trim();
            string TenKhacHang = txtTenKhachHang.Value.Trim();
            string TenSanPham = txtTenSanPham.Value.Trim();
            string GiaBan = txtGiaBan.Value.Trim().Replace(",", "").Replace(".", "");
            double n;
            bool result = double.TryParse(GiaBan, out n);
            if (!result)
            {
                Response.Write("<script>alert('Giá phải là số tự nhiên !')</script>");
                return;
            }

            if (TenKhacHang.Length <= 0)
            {
                Response.Write("<script>alert('Tên khách hàng không được trống !')</script>");
                return;
            }
            if (IDHangHoa.Length <= 0 || txtTenSanPham.Value.Trim().Length <= 0)
            {
                Response.Write("<script>alert('Hàng hóa không được trống !')</script>");
                return;
            }
            string GhiChu = txtGhiChu.Value.Trim();

            DataTable kiemtra = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDHangHoa + " and IDChiTietGiaTheoKhach <> " + pIDChiTietGiaTheoKhach + " ");
            if (kiemtra.Rows.Count > 0)
            {
                Response.Write("<script>alert('Khách hàng và hàng hóa này đã được thiết lập giá !')</script>");
                return;
            }

            string sql = "update ChiTietGiaTheoKhach set IDKhachHang = " + IDKhachHang + ",IDHangHoa=" + IDHangHoa + ",Gia=" + GiaBan + ",GhiChu=N'"+GhiChu+"' where IDChiTietGiaTheoKhach = "+pIDChiTietGiaTheoKhach+"";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if (Page.Length > 0)
                    Response.Redirect("DanhMucKhachHangSanPham.aspx?Page=" + Page);
                else Response.Redirect("DanhMucKhachHangSanPham.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi  !')</script>");
                return;
            }
        }

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("DanhMucKhachHangSanPham.aspx?Page=" + Page);
        else Response.Redirect("DanhMucKhachHangSanPham.aspx");
    }
}