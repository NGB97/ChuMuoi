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
    string pIDKhachHang = "";
    string Page = "";
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (Request.Cookies["BanSiQuanAo_Login"] != null && Request.Cookies["BanSiQuanAo_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["BanSiQuanAo_Quyen"] != null && Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim();
                if (Quyen.CompareTo("Admin") == 0)
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
            if (Request.QueryString["IDKhachHang"].Trim() != "")
            {
                pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

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
                if (Request.QueryString["IDKhachHang"].Trim() != "")
                {
                    pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

                }
            }
            catch { }
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
            DataTable GetNgay = Connect.GetTable("select CONVERT(nvarchar(20),GETDATE(),103)");
            txtNgay.Value = GetNgay.Rows[0][0].ToString();

            DataTable a = Connect.GetTable("select isnull(max(IDPhieuTraNo),0)+1 from PhieuTraNoChoKhach");
            txtMaPhieuTra.Value ="PTN_"+ a.Rows[0][0].ToString();
            if (Page.Length > 0 && pIDChiTietGiaTheoKhach.Length > 0)
            {
                Load();
            }
           if(pIDKhachHang.Trim().Length > 0)
           {
               txtIDKhachHang.Value = pIDKhachHang.Trim();

               decimal TienCanTraChoKhach = 0;
               try
               {
                   //Connect.GetTable("select sum(SoLuong*DonGiaNhap) from ChiTietPhieuNhap CTPN,PhieuNhap PN where PN.idPhieuNhap=CTPN.idPhieunhap and PN.idKhachHang=" + table.Rows[0][i]);
                   TienCanTraChoKhach = decimal.Parse(StaticData.getField("ChiTietPhieuNhap CTPN,PhieuNhap PN", "sum(CTPN.SoLuong*CTPN.DonGiaNhap)", "PN.idPhieuNhap=CTPN.idPhieunhap and PN.LoaiPhieuNhap='DaTraHang' and PN.idKhachHang", pIDKhachHang.Trim()));
               }
               catch { }

               decimal TienDaTraChoKhach = 0;
               try
               {
                   TienDaTraChoKhach = decimal.Parse(StaticData.getField("PhieuTraNoChoKhach PTN", "sum(PTN.SoTien)", "PTN.idKhachHang", pIDKhachHang.Trim()));
               }
               catch { }

               decimal TienChuaTraChoKhach = TienDaTraChoKhach - TienDaTraChoKhach;

               txtSoTienMua.Value = TienCanTraChoKhach.ToString("N0").Replace(",", ".");
               txtSoTienTra.Value = TienDaTraChoKhach.ToString("N0").Replace(",", ".");
               txtConLai.Value = TienChuaTraChoKhach.ToString("N0").Replace(",", ".");
               txtConLai_2.Value = TienChuaTraChoKhach.ToString("N0").Replace(",", ".");

               //DataTable dtbstn = LoadSoTienNo(pIDKhachHang.Trim());
               //if (dtbstn.Rows.Count > 0)
               //{
               //    txtSoTienMua.Value = double.Parse(dtbstn.Rows[0]["SoTienDaMua"].ToString()).ToString("##,0").Replace(",", ".");
               //    txtSoTienTra.Value = double.Parse(dtbstn.Rows[0]["DaTra"].ToString()).ToString("##,0").Replace(",", ".");
               //    txtConLai.Value = double.Parse(dtbstn.Rows[0]["ConLai"].ToString()).ToString("##,0").Replace(",", ".");
               //    txtConLai_2.Value = double.Parse(dtbstn.Rows[0]["ConLai"].ToString()).ToString("##,0").Replace(",", ".");
               //}
               txtTenKhachHang.Value = StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", pIDKhachHang.Trim());
           }
        }
    }
    private DataTable LoadSoTienNo(string idKH)
    {
                       string sqlsotienno = @"select tb3.IDKhachHang,tb3.SoTienDaMua,tb3.TienThanhToan+tb3.SoTien as 'DaTra'
                    ,tb3.SoTienDaMua-(tb3.TienThanhToan+tb3.SoTien) as 'ConLai'
                    from
                    (
                    select 
                    tb2.IDKhachHang,(select isnull(sum(ChiTietPhieuXuat.SoLuong*ChiTietPhieuXuat.DonGiaXuat),0) from PhieuXuat,ChiTietPhieuXuat
                    where PhieuXuat.MaPhieuXuat not like N'%-XB' and PhieuXuat.IDPhieuXuat = ChiTietPhieuXuat.IDPhieuXuat and PhieuXuat.IDKhachHang = tb2.IDKhachHang) as 'SoTienDaMua',
                    (select isnull(sum(TienThanhToan),0) from PhieuXuat where PhieuXuat.MaPhieuXuat not like N'%-XB' and IDKhachHang=tb2.IDKhachHang) as 'TienThanhToan',
                    (select isnull(sum(SoTien),0) from PhieuTraNo where IDKhachHang=tb2.IDKhachHang) as 'SoTien'
                    from 
                    (select *  from KhachHang where IDKhachHang !='10108' and IDKhachHang='" + idKH.Trim() + @"')
                    as tb2) as tb3";
               DataTable tbsotienno = Connect.GetTable(sqlsotienno);
               return tbsotienno;
    }
    private void Load()
    {
        if (pIDChiTietGiaTheoKhach != "")
        {
            string sql = "  select * from PhieuTraNoChoKhach where IDPhieuTraNo =" + pIDChiTietGiaTheoKhach + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN TRẢ NỢ KHÁCH ";
                btLuu.Text = "SỬA";
                txtMaPhieuTra.Value = table.Rows[0]["MaPhieuTraNo"].ToString();
                txtNgay.Value = DateTime.Parse(table.Rows[0]["Ngay"].ToString()).ToString("dd/MM/yyyy"); 
                string TenKhachHang = StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[0]["IDKhachHang"].ToString());
                txtTenKhachHang.Value = TenKhachHang; txtIDKhachHang.Value = table.Rows[0]["IDKhachHang"].ToString();
                string IDK_H = table.Rows[0]["IDKhachHang"].ToString();

                //decimal TienCanTraChoKhach = 0;
                //try
                //{
                //    //Connect.GetTable("select sum(SoLuong*DonGiaNhap) from ChiTietPhieuNhap CTPN,PhieuNhap PN where PN.idPhieuNhap=CTPN.idPhieunhap and PN.idKhachHang=" + table.Rows[0][i]);
                //    TienCanTraChoKhach = decimal.Parse(StaticData.getField("ChiTietPhieuNhap CTPN,PhieuNhap PN", "sum(CTPN.SoLuong*CTPN.DonGiaNhap)", "PN.idPhieuNhap=CTPN.idPhieunhap and PN.LoaiPhieuNhap='DaTraHang' and PN.idKhachHang", table.Rows[i]["idKhachHang"].ToString()));
                //}
                //catch { }

                //decimal TienDaTraChoKhach = 0;
                //try
                //{
                //    TienDaTraChoKhach = decimal.Parse(StaticData.getField("PhieuTraNoChoKhach PTN", "sum(PTN.SoTien)", "PTN.idKhachHang", table.Rows[i]["idKhachHang"].ToString()));
                //}
                //catch { }

                //decimal TienChuaTraChoKhach = TienDaTraChoKhach - TienDaTraChoKhach;

                DataTable dtbstn = LoadSoTienNo(IDK_H);
                if (dtbstn.Rows.Count > 0)
                {
                    txtSoTienMua.Value = double.Parse(dtbstn.Rows[0]["SoTienDaMua"].ToString()).ToString("##,0").Replace(",", ".");
                    txtSoTienTra.Value = double.Parse(dtbstn.Rows[0]["DaTra"].ToString()).ToString("##,0").Replace(",", ".");
                    txtConLai.Value = (double.Parse(dtbstn.Rows[0]["ConLai"].ToString()) + double.Parse(table.Rows[0]["SoTien"].ToString())).ToString("##,0").Replace(",", ".");
                    txtConLai_2.Value = double.Parse(dtbstn.Rows[0]["ConLai"].ToString()).ToString("##,0").Replace(",", ".");
                }

                //double Gia = double.Parse(table.Rows[0]["Gia"].ToString());
                string Gia = table.Rows[0]["SoTien"].ToString().Trim();
                if (Gia.Trim() == "0")
                {
                    txtGiaBan.Value = "0";
                }
                else
                    txtGiaBan.Value = double.Parse(Gia).ToString("#,##").Replace(",", ".");

                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDChiTietGiaTheoKhach.Length <= 0)
        {
            string TenKhachHang = txtTenKhachHang.Value.Trim();
            string IDKhachHang = txtIDKhachHang.Value.Trim();
            string MaPhieuTraNo = txtMaPhieuTra.Value.Trim();
            string Ngay = txtNgay.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
            string GiaBan = txtGiaBan.Value.Trim().Replace(",", "").Replace(".", "");
            double n;
            bool result = double.TryParse(GiaBan, out n);
            if (!result)
            {
                Response.Write("<script>alert('Số tiền là số tự nhiên, nếu không hãy nhập = 0 !')</script>");
                return;
            }

            if (TenKhachHang.Length <= 0 || IDKhachHang.Length <= 0)
            {
                Response.Write("<script>alert('Tên khách hàng không được trống !')</script>");
                return;
            }
            if (Ngay.Length <= 0)
            {
                Response.Write("<script>alert('Ngảy trả không được trống !')</script>");
                return;
            }
            if (MaPhieuTraNo.Length <= 0)
            {
                Response.Write("<script>alert('Mã phiếu không được trống !')</script>");
                return;
            }
            DataTable checkMa = Connect.GetTable("select * from PhieuTraNoChoKhach where MaPhieuTraNo=N'" + MaPhieuTraNo + "'");
            if(checkMa.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã phiếu đã tồn tại !')</script>");
                return;
            }
            string sql = "insert into PhieuTraNoChoKhach values (N'" + MaPhieuTraNo + "','" + StaticData.ConvertDDMMtoMMDD(Ngay) + "',N'" + GhiChu + "'," + IDKhachHang + "," + GiaBan + ",N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "','"+DateTime.Now.ToString("MM/dd/yyyy HH:mm")+"')";

            bool kq = Connect.Exec(sql);
            if (kq)
            {
                //if (Page.Length > 0)
                //    Response.Redirect("PhieuTraNoKhachHang.aspx?Page=" + Page);
                //else Response.Redirect("PhieuTraNoKhachHang.aspx");
                Response.Redirect("TraNoKhachHang.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi hãy chắc rằng bạn nhập giá đúng định dạng số !')</script>");
                return;
            }
        }
        else
        {
            string TenKhachHang = txtTenKhachHang.Value.Trim();
            string IDKhachHang = txtIDKhachHang.Value.Trim();
            string MaPhieuTraNo = txtMaPhieuTra.Value.Trim();
            string Ngay = txtNgay.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
            string GiaBan = txtGiaBan.Value.Trim().Replace(",", "").Replace(".", "");
            double n;
            bool result = double.TryParse(GiaBan, out n);
            if (!result)
            {
                Response.Write("<script>alert('Số tiền là số tự nhiên, nếu không hãy nhập = 0 !')</script>");
                return;
            }

            if (TenKhachHang.Length <= 0 || IDKhachHang.Length <= 0)
            {
                Response.Write("<script>alert('Tên khách hàng không được trống !')</script>");
                return;
            }
            if (Ngay.Length <= 0)
            {
                Response.Write("<script>alert('Ngảy trả không được trống !')</script>");
                return;
            }
            if (MaPhieuTraNo.Length <= 0)
            {
                Response.Write("<script>alert('Mã phiếu không được trống !')</script>");
                return;
            }
            DataTable checkMa = Connect.GetTable("select * from PhieuTraNo where MaPhieuTraNo=N'" + MaPhieuTraNo + "' and IDPhieuTraNo <> "+pIDChiTietGiaTheoKhach+"");
            if (checkMa.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã phiếu đã tồn tại !')</script>");
                return;
            }
            string sql = "update PhieuTraNoChoKhach set IDKhachHang = " + IDKhachHang + ",SoTien=" + GiaBan + ",GhiChu=N'" + GhiChu + "',Ngay='" + StaticData.ConvertDDMMtoMMDD(Ngay) + "',MaPhieuTraNo=N'" + MaPhieuTraNo + "' where IDPhieuTraNo = " + pIDChiTietGiaTheoKhach + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                //if (Page.Length > 0)
                //    Response.Redirect("PhieuTraNoKhachHang.aspx?Page=" + Page);
                //else Response.Redirect("PhieuTraNoKhachHang.aspx");
                Response.Redirect("TraNoKhachHang.aspx");
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
        //if (Page.Length > 0)
        //    Response.Redirect("PhieuTraNoKhachHang.aspx?Page=" + Page);
        //else Response.Redirect("PhieuTraNoKhachHang.aspx");
        Response.Redirect("TraNoKhachHang.aspx");
    }
}