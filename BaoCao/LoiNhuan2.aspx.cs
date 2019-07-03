using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyDoiTra_CongNo : System.Web.UI.Page
{
    string pTenKhachHang = "";
    string pTenSanPham = "";
    string pTuNgayBan = "";
    string pDenNgayBan = "";
    string pMaPhieuXuat = "";

    string txtFistPage = "1";
    string txtPage1 = "";
    string txtPage2 = "";
    string txtPage3 = "";
    string txtPage4 = "";
    string txtPage5 = "";
    string txtLastPage = "";
    int Page = 0;
    int MaxPage = 0;
    int PageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
      /*  if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
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
            Page = int.Parse(Request.QueryString["Page"].ToString());
        }
        catch
        {
            Page = 1;
        }
        if (!IsPostBack)
        {

            
            try
            {
                if (Request.QueryString["TuNgayBan"].Trim() != "")
                {
                    pTuNgayBan = StaticData.ValidParameter(Request.QueryString["TuNgayBan"].Trim());
                    txtTuNgayBan.Value = pTuNgayBan;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["DenNgayBan"].Trim() != "")
                {
                    pDenNgayBan = StaticData.ValidParameter(Request.QueryString["DenNgayBan"].Trim());
                    txtDenNgayBan.Value = pDenNgayBan;
                }
            }
            catch { }



            LoadDuAn();
        }
    }
    /* private void LoadQuyen()
     {
         string strSql = "select * from DuAn";
         slQuyen.DataSource = Connect.GetTable(strSql);
         slQuyen.DataTextField = "TenQuyen";
         slQuyen.DataValueField = "MaQuyen";
         slQuyen.DataBind();
         //slQuyen.Items.Add(new ListItem("-- Tất cả --", "0"));
         // slQuyen.Items.FindByText("-- Tất cả --").Selected = true;
     }*/
    #region paging
    private void SetPage()
    {
        string sql = "";

        sql += "select count(*)  from ChiTietPhieuXuat left join KhachHang on ChiTietPhieuXuat.IDKhachHang = KhachHang.IDKhachHang left join HangHoa on ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa  left join PhieuXuat on ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat  where '1'='1' and ChiTietPhieuXuat.TinhTrang = N'Còn nợ'";

        if (pTenSanPham != "")
            sql += " and HangHoa.TenHangHoa like N'%" + pTenSanPham + "%'";
        if (pTenKhachHang != "")
            sql += " and KhachHang.TenKhachHang like N'%" + pTenKhachHang + "%'";
        if (pMaPhieuXuat != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'%" + pMaPhieuXuat + "%'";
        if (pTuNgayBan != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00'";
        if (pDenNgayBan != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00'";
        DataTable tbTotalRows = Connect.GetTable(sql);
        //  Response.Write("<script>alert('"+tbTotalRows.Rows[0][0].ToString()+"')</script>");
        int TotalRows = int.Parse(tbTotalRows.Rows[0][0].ToString());
        if (TotalRows % PageSize == 0)
            MaxPage = TotalRows / PageSize;
        else
            MaxPage = TotalRows / PageSize + 1;
        txtLastPage = MaxPage.ToString();
        if (Page == 1)
        {
            for (int i = 1; i <= MaxPage; i++)
            {
                if (i <= 5)
                {
                    switch (i)
                    {
                        case 1: txtPage1 = i.ToString(); break;
                        case 2: txtPage2 = i.ToString(); break;
                        case 3: txtPage3 = i.ToString(); break;
                        case 4: txtPage4 = i.ToString(); break;
                        case 5: txtPage5 = i.ToString(); break;
                    }
                }
                else
                    return;
            }
        }
        else
        {
            if (Page == 2)
            {
                for (int i = 1; i <= MaxPage; i++)
                {
                    if (i == 1)
                        txtPage1 = "1";
                    if (i <= 5)
                    {
                        switch (i)
                        {
                            case 2: txtPage2 = i.ToString(); break;
                            case 3: txtPage3 = i.ToString(); break;
                            case 4: txtPage4 = i.ToString(); break;
                            case 5: txtPage5 = i.ToString(); break;
                        }
                    }
                    else
                        return;
                }
            }
            else
            {
                int Cout = 1;
                if (Page <= MaxPage)
                {
                    for (int i = Page; i <= MaxPage; i++)
                    {
                        if (i == Page)
                        {
                            txtPage1 = (Page - 2).ToString();
                            txtPage2 = (Page - 1).ToString();
                        }
                        if (Cout <= 3)
                        {
                            if (i == Page)
                                txtPage3 = i.ToString();
                            if (i == (Page + 1))
                                txtPage4 = i.ToString();
                            if (i == (Page + 2))
                                txtPage5 = i.ToString();
                            Cout++;
                        }
                        else
                            return;
                    }
                }
                else
                {
                    //Page = MaxPage;
                    SetPage();
                }
            }
        }
    }
    #endregion
    private void LoadDuAn()
    {
        string sql = "select isnull(sum(TienThanhToan),0) from PhieuXuat where '1'='1'  ";
        if (pTuNgayBan != "")
            sql += " and PhieuXuat.NgayXuat >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00'";
        if (pDenNgayBan != "")
            sql += " and PhieuXuat.NgayXuat <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00'";
        DataTable TienPhieuXuat = Connect.GetTable(sql);
        string sql2 = " select isnull(sum(SoTien),0) from PhieuTraNo where '1'='1' ";
        if (pTuNgayBan != "")
            sql2 += " and PhieuTraNo.Ngay >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00'";
        if (pDenNgayBan != "")
            sql2 += " and PhieuTraNo.Ngay <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00'";
        DataTable TienThuNoKhachHang = Connect.GetTable(sql2);
        double TongThu = double.Parse(TienPhieuXuat.Rows[0][0].ToString()) + double.Parse(TienThuNoKhachHang.Rows[0][0].ToString());


        string query = "select isnull(sum(TienDaThanhToan),0) from PhieuNhap where '1'='1' ";
        if (pTuNgayBan != "")
            query += " and PhieuNhap.NgayNhap >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00'";
        if (pDenNgayBan != "")
            query += " and PhieuNhap.NgayNhap <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00'";
        DataTable TienThanhToanPhieuNhap = Connect.GetTable(query);

        string query2 = "select isnull(sum(SoTien),0) from PhieuTraNoNhaCungCap where '1'='1' ";
        if (pTuNgayBan != "")
            query2 += " and PhieuTraNoNhaCungCap.Ngay >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00'";
        if (pDenNgayBan != "")
            query2 += " and PhieuTraNoNhaCungCap.Ngay <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00'";
        DataTable TienThanhToanNoNhaCungCap = Connect.GetTable(query2);
        double TongChi = double.Parse(TienThanhToanPhieuNhap.Rows[0][0].ToString()) + double.Parse(TienThanhToanNoNhaCungCap.Rows[0][0].ToString());
        //SetPage();
        // Tính lại

        string strQuery = "select isnull(sum(SoLuong*DonGiaNhap),0) from ChiTietPhieuNhap where '1'='1' ";
        if (pTuNgayBan != "")
            strQuery += " and ChiTietPhieuNhap.IDPhieuNhap in (select PhieuNhap.IDPhieuNhap from PhieuNhap where PhieuNhap.NgayNhap >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00' )";
        if (pDenNgayBan != "")
            strQuery += " and ChiTietPhieuNhap.IDPhieuNhap in (select PhieuNhap.IDPhieuNhap from PhieuNhap where PhieuNhap.NgayNhap <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00' )";
        DataTable SoTienPhieuNhap = Connect.GetTable(strQuery);
        TongThu = double.Parse(SoTienPhieuNhap.Rows[0][0].ToString());

        string strQuery2 = "select isnull(sum(SoLuong*DonGiaXuat),0) from ChiTietPhieuXuat where '1'='1' ";
        if (pTuNgayBan != "")
            strQuery2 += " and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where PhieuXuat.NgayXuat >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00') ";
        if (pDenNgayBan != "")
            strQuery2 += " and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where PhieuXuat.NgayXuat <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00') ";
        DataTable SoTienPhieuXuat = Connect.GetTable(strQuery2);
        TongChi = double.Parse(SoTienPhieuXuat.Rows[0][0].ToString());


        double KetQua = (TongChi - TongThu);
        string HienKetQua = "0";
        if(KetQua != 0)
        {
            HienKetQua = KetQua.ToString("#,##").Replace(",",".");
        }

        string html = @"Lợi nhuận : " + HienKetQua;
        if (pTuNgayBan != "" && pDenNgayBan != "")
        {
            html = @"Lợi nhuận : <a style='cursor:pointer;' onclick='showChiTietLoiNhuan();'>" + HienKetQua+"</a>";
        }
           
        
           

        dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        string TenSanPham = txtTenSanPham.Value.Trim();
        string TuNgayBan = txtTuNgayBan.Value.Trim();
        string DenNgayBan = txtDenNgayBan.Value.Trim();
        string TenKhachHang = txtTenKhachHang.Value.Trim();
        string MaPhieuXuat = txtMaPhieuXuat.Value.Trim();
        string url = "LoiNhuan.aspx?";
        if (TenSanPham != "")
            url += "TenSanPham=" + TenSanPham + "&";
        if (TuNgayBan != "")
            url += "TuNgayBan=" + TuNgayBan + "&";
        if (DenNgayBan != "")
            url += "DenNgayBan=" + DenNgayBan + "&";
        if (TenKhachHang != "")
            url += "TenKhachHang=" + TenKhachHang + "&";
        if (MaPhieuXuat != "")
            url += "MaPhieuXuat=" + MaPhieuXuat + "&";

        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        string url = "LoiNhuan.aspx";
        Response.Redirect(url);
    }
}