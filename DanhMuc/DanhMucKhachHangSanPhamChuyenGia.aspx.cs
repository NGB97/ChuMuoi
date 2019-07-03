using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucKhachHangSanPhamChuyenGia : System.Web.UI.Page
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
    private void Load()
    {
        
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
       
            string IDKhachHang = txtIDKhachHang.Value.Trim();
         
            string TenKhacHang = txtTenKhachHang.Value.Trim();

            string TenKhacHangCu = txtTenKhachCu.Value.Trim();
            string IDKhachHangCu = txtIDKhachHangCu.Value.Trim();


            if (TenKhacHang.Length <= 0 || IDKhachHang.Length <= 0)
            {
                Response.Write("<script>alert('Xin chọn đủ thông tin có dấu (*) !')</script>");
                return;
            }
            if (TenKhacHangCu.Length <= 0 || IDKhachHangCu.Length <= 0)
            {
                Response.Write("<script>alert('Xin chọn đủ thông tin có dấu (*) !')</script>");
                return;
            }
            DataTable GiaTheoKhachCu = Connect.GetTable("select IDHangHoa,Gia from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHangCu + "");
            if (GiaTheoKhachCu.Rows.Count <= 0)
            {
                Response.Write("<script>alert('Khách hàng cũ này chưa có giá bán cho bất kỳ sản phẩm nào !')</script>");
                return;
            }
            else
            {
                for(int i = 0;i<GiaTheoKhachCu.Rows.Count;i++)
                {
                    DataTable kiemtra = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + GiaTheoKhachCu.Rows[i]["IDHangHoa"].ToString().Trim() + "  ");
                    if (kiemtra.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        string query = "insert into ChiTietGiaTheoKhach values(" + IDKhachHang + "," + GiaTheoKhachCu.Rows[i]["IDHangHoa"].ToString().Trim() + "," + GiaTheoKhachCu.Rows[i]["Gia"].ToString().Trim() + ",N'')";
                        bool rs = Connect.Exec(query);
                        if (!rs)
                        {
                            Response.Write("<script>alert('Có lỗi xảy ra !')</script>");
                            return;
                        }
                    }
                }
                Response.Redirect("DanhMucKhachHangSanPham.aspx");
            }
            /*string sql = "insert into ChiTietGiaTheoKhach values (" + IDKhachHang + "," + IDHangHoa + "," + GiaBan + ",N'"+GhiChu+"')";
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
            }*/
        
        

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
      
         Response.Redirect("DanhMucKhachHangSanPham.aspx");
    }
}