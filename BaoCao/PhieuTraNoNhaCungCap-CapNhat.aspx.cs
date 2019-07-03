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
            if (Request.QueryString["IDNhaCungCap"].Trim() != "")
            {
                pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDNhaCungCap"].Trim());

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
                if (Request.QueryString["IDNhaCungCap"].Trim() != "")
                {
                    pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDNhaCungCap"].Trim());

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


            DataTable a = Connect.GetTable("select isnull(max(IDPhieuTraNoNhaCungCap),0)+1 from PhieuTraNoNhaCungCap");
            txtMaPhieuTra.Value = "PTRNNCC_" + a.Rows[0][0].ToString();

            if (Page.Length > 0 && pIDChiTietGiaTheoKhach.Length > 0)
            {
                Load();
            }
            if (pIDKhachHang.Trim().Length > 0)
            {
                txtIDNhaCungCap.Value = pIDKhachHang.Trim();
                DataTable dtbTienNo = LoadTienNo(pIDKhachHang.Trim());
                if (dtbTienNo.Rows.Count > 0)
                {
                    txtSoTienNo.Value = double.Parse(dtbTienNo.Rows[0]["No"].ToString()).ToString("##,0").Replace(",", ".");
                    txtSoTienTra.Value = double.Parse(dtbTienNo.Rows[0]["DaTra"].ToString()).ToString("##,0").Replace(",", ".");
                    txtConLai.Value = double.Parse(dtbTienNo.Rows[0]["ConLai"].ToString()).ToString("##,0").Replace(",", ".");
                    txtConLai_2.Value = double.Parse(dtbTienNo.Rows[0]["ConLai"].ToString()).ToString("##,0").Replace(",", ".");
                }
                txtTenNhaCungCap.Value = StaticData.getField("NhaCungCap", "TenNhaCungCap", "IDNhaCungCap", pIDKhachHang.Trim());
            }
        }
    }
    private DataTable LoadTienNo(string idNhaCungCap)
    {
        string sql = @"select * from ( select (select a.TenNhaCungCap from NhaCungCap a where a.IDNhaCungCap = tb4.IDNhaCungCap ) as 'TenNhaCungCap', (select a.MaNhaCungCap from NhaCungCap a where a.IDNhaCungCap = tb4.IDNhaCungCap ) as 'MaNhaCungCap',tb4.IDNhaCungCap,tb4.DaTra,tb4.No,isnull((tb4.DaTra-tb4.No)*-1,0) as 'ConLai' from 
                    (select tb3.IDNhaCungCap,isnull(tb3.DaTra,0) as 'DaTra',isnull(tb3.TongTienPhieuNhap-tb3.TienDaThanhToan,0) as 'No' 
                    from 
                    (
                    select tb2.IDNhaCungCap,
                    isnull((select isnull(sum(PhieuTraNoNhaCungCap.SoTien),0) from PhieuTraNoNhaCungCap where PhieuTraNoNhaCungCap.IDNhaCungCap = tb2.IDNhaCungCap),0) as 'DaTra',
                    (select isnull(sum(PhieuNhap.TienDaThanhToan),0) from PhieuNhap where PhieuNhap.IDNhaCungCap = tb2.IDNhaCungCap) as 'TienDaThanhToan',
                    (select isnull(sum(ctpn.SoLuong*ctpn.DonGiaNhap),0) from PhieuNhap pn,ChiTietPhieuNhap ctpn where pn.IDPhieuNhap=ctpn.IDPhieuNhap and pn.IDNhaCungCap = tb2.IDNhaCungCap) as 'TongTienPhieuNhap'
                    from 
                    (
                    (select *  from NhaCungCap where IDNhaCungCap !='32' and IDNhaCungCap='" + idNhaCungCap + @"')) as tb2 ) as tb3 ) as tb4  ) as tb5";
        return Connect.GetTable(sql);
    }
    private void Load()
    {
        if (pIDChiTietGiaTheoKhach != "")
        {
            string sql = "  select * from PhieuTraNoNhaCungCap where IDPhieuTraNoNhaCungCap =" + pIDChiTietGiaTheoKhach + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN TRẢ NỢ CHO NHÀ CUNG CẤP";
                btLuu.Text = "SỬA";
                txtMaPhieuTra.Value = table.Rows[0]["MaPhieuTraNoNhaCungCap"].ToString();
                txtNgay.Value = DateTime.Parse(table.Rows[0]["Ngay"].ToString()).ToString("dd/MM/yyyy");
                //string TenSanPham = StaticData.getField("HangHoa", "TenHangHoa", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString());

                //txtTenSanPham.Value = TenSanPham; txtIDSanPham.Value = table.Rows[0]["IDHangHoa"].ToString();
                string TenNhaCungCap = StaticData.getField("NhaCungCap", "TenNhaCungCap", "IDNhaCungCap", table.Rows[0]["IDNhaCungCap"].ToString());
                txtTenNhaCungCap.Value = TenNhaCungCap; txtIDNhaCungCap.Value = table.Rows[0]["IDNhaCungCap"].ToString();
                DataTable dtbTienNo = LoadTienNo(table.Rows[0]["IDNhaCungCap"].ToString());
                string Gia = table.Rows[0]["SoTien"].ToString().Trim();
                if (dtbTienNo.Rows.Count > 0)
                {
                    txtSoTienNo.Value = double.Parse(dtbTienNo.Rows[0]["No"].ToString()).ToString("##,0").Replace(",", ".");
                    txtSoTienTra.Value = double.Parse(dtbTienNo.Rows[0]["DaTra"].ToString()).ToString("##,0").Replace(",", ".");
                    if (!Gia.Trim().Equals("0"))
                    {

                        txtConLai.Value = (double.Parse(dtbTienNo.Rows[0]["ConLai"].ToString()) + double.Parse(Gia)).ToString("##,0").Replace(",", ".");
                    }
                    else
                    {
                        txtConLai.Value = double.Parse(dtbTienNo.Rows[0]["ConLai"].ToString()).ToString("##,0").Replace(",", ".");
                    }
                    txtConLai_2.Value = double.Parse(dtbTienNo.Rows[0]["ConLai"].ToString()).ToString("##,0").Replace(",", ".");
                }
                //double Gia = double.Parse(table.Rows[0]["Gia"].ToString());
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
            string TenNhaCungCap = txtTenNhaCungCap.Value.Trim();
            string IDNhaCungCap = txtIDNhaCungCap.Value.Trim();
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

            if (TenNhaCungCap.Length <= 0 || IDNhaCungCap.Length <= 0)
            {
                Response.Write("<script>alert('Tên nhà cung cấp hàng không được trống !')</script>");
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
            DataTable checkMa = Connect.GetTable("select * from PhieuTraNoNhaCungCap where MaPhieuTraNoNhaCungCap=N'" + MaPhieuTraNo + "'");
            if(checkMa.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã phiếu đã tồn tại !')</script>");
                return;
            }
            string sql = "insert into PhieuTraNoNhaCungCap values (N'" + MaPhieuTraNo + "','" + StaticData.ConvertDDMMtoMMDD(Ngay) + "',N'" + GhiChu + "'," + IDNhaCungCap + "," + GiaBan + ")";

            bool kq = Connect.Exec(sql);
            if (kq)
            {
                //if (Page.Length > 0)
                //    Response.Redirect("PhieuTraNoNhaCungCap.aspx?Page=" + Page);
                //else Response.Redirect("PhieuTraNoNhaCungCap.aspx");
                Response.Redirect("NoNhaCungCap.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi hãy chắc rằng bạn nhập giá đúng định dạng số !')</script>");
                return;
            }
        }
        else
        {
            string TenNhaCungCap = txtTenNhaCungCap.Value.Trim();
            string IDNhaCungCap = txtIDNhaCungCap.Value.Trim();
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

            if (TenNhaCungCap.Length <= 0 || IDNhaCungCap.Length <= 0)
            {
                Response.Write("<script>alert('Tên nhà cung cấp hàng không được trống !')</script>");
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
            DataTable checkMa = Connect.GetTable("select * from PhieuTraNoNhaCungCap where MaPhieuTraNoNhaCungCap=N'" + MaPhieuTraNo + "' and IDPhieuTraNoNhaCungCap <> "+pIDChiTietGiaTheoKhach+" ");
            if (checkMa.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã phiếu đã tồn tại !')</script>");
                return;
            }
            string sql = "update PhieuTraNoNhaCungCap set IDNhaCungCap = " + IDNhaCungCap + ",SoTien=" + GiaBan + ",GhiChu=N'" + GhiChu + "',Ngay='" + StaticData.ConvertDDMMtoMMDD(Ngay) + "',MaPhieuTraNoNhaCungCap=N'" + MaPhieuTraNo + "' where IDPhieuTraNoNhaCungCap = " + pIDChiTietGiaTheoKhach + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                //if (Page.Length > 0)
                //    Response.Redirect("PhieuTraNoNhaCungCap.aspx?Page=" + Page);
                //else Response.Redirect("PhieuTraNoNhaCungCap.aspx");
                Response.Redirect("NoNhaCungCap.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi  internet !')</script>");
                return;
            }
        }

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        //if (Page.Length > 0)
        //    Response.Redirect("PhieuTraNoNhaCungCap.aspx?Page=" + Page);
        //else Response.Redirect("PhieuTraNoNhaCungCap.aspx");
        Response.Redirect("NoNhaCungCap.aspx");
    }
}