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
            string sql = "  select * from KhachHang where IDKhachHang =" + pIDChiTietGiaTheoKhach + "";
           DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
        //       dvTitle.InnerHtml = "SỬA THÔNG TIN GIÁ BÁN THEO KHÁCH";
             //   btLuu.Text = "SỬA";
        //        string TenSanPham = StaticData.getField("HangHoa", "TenHangHoa", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString());

        //       // txtTenSanPham.Value = TenSanPham; 
                
                
        //        txtIDSanPham.Value = table.Rows[0]["IDHangHoa"].ToString();
                string TenKhachHang = table.Rows[0]["TenKhachHang"].ToString();
              txtTenKhachHang.Value = TenKhachHang; 
                txtIDKhachHang.Value = table.Rows[0]["IDKhachHang"].ToString();
                txtTenKhachHang.Disabled = true;
        //        double Gia = double.Parse(table.Rows[0]["Gia"].ToString());

        //        txtGiaBan.Value = Gia.ToString("#,##").Replace(",", ".");
             
        //        txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

        //        txtIDSanPham.Value = table.Rows[0]["IDHangHoa"].ToString();
        //        txtTenSanPham.Value = StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", table.Rows[0]["IDHangHoa"].ToString()) +"-"+ StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", table.Rows[0]["IDHangHoa"].ToString());
            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        string IDKhachHang = txtIDKhachHang.Value.Trim();
        if(IDKhachHang.Length <= 0 || txtTenKhachHang.Value.Trim().Length <= 0 )
        {
            Response.Write("<script>alert('Hãy chọn khách hàng');</script>");
            return;
        }
      
      string [] chuoi = Request.Cookies["ThemGia"].Value.Trim().Split('@');
      for (int i = 0; i < chuoi.Length; i++)
      {
          if (chuoi[i].Trim().Length > 0)
          {
              string[] tachnua = chuoi[i].Split('-');


              if (double.Parse(tachnua[1].Replace(",", "").Replace(".", "")) == 0)
              {

              }
              else
              {

                  DataTable check = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang = "+IDKhachHang+" and IDHangHoa = "+tachnua[0]+"");
                  if (check.Rows.Count > 0)
                  {
                      string sql = "update ChiTietGiaTheoKhach set Gia = " + tachnua[1].Replace(",", "").Replace(".", "") + " where IDKhachHang = " + IDKhachHang + " and IDHangHoa = " + tachnua[0] + " )";
                      bool c = Connect.Exec(sql);
                  }
                  else
                  {
                      string sql = "insert into ChiTietGiaTheoKhach values(" + IDKhachHang + "," + tachnua[0] + "," + tachnua[1].Replace(",", "").Replace(".", "") + ",N'')";
                      bool c = Connect.Exec(sql);
                  }
              }

          }
     
         
      }

      HttpCookie ThemNhanh = new HttpCookie("ThemGia", "");
      ThemNhanh.Expires = DateTime.Now.AddDays(-1d);
      Response.Cookies.Add(ThemNhanh);
      Response.Redirect("DanhMucKhachHangSanPham.aspx");
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("DanhMucKhachHangSanPham.aspx?Page=" + Page);
        else Response.Redirect("DanhMucKhachHangSanPham.aspx");
    }
}