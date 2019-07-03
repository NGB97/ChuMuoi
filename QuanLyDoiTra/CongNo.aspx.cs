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
        if (Request.Cookies["QuanLyNhapXuatHang_Login"] != null && Request.Cookies["QuanLyNhapXuatHang_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["QuanLyNhapXuatHang_Quyen"] != null && Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim();
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
                if (Request.QueryString["TenKhachHang"].Trim() != "")
                {
                    pTenKhachHang = StaticData.ValidParameter(Request.QueryString["TenKhachHang"].Trim());
                    txtTenKhachHang.Value = pTenKhachHang;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TenSanPham"].Trim() != "")
                {
                    pTenSanPham = StaticData.ValidParameter(Request.QueryString["TenSanPham"].Trim());
                    txtTenSanPham.Value = pTenSanPham;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["MaPhieuXuat"].Trim() != "")
                {
                    pMaPhieuXuat = StaticData.ValidParameter(Request.QueryString["MaPhieuXuat"].Trim());
                    txtMaPhieuXuat.Value = pMaPhieuXuat;
                }
            }
            catch { }
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
        string sql = "";
        sql += @"select * from( SELECT ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.NgayXuatChiTiet desc)AS RowNumber,KhachHang.TenKhachHang,ChiTietPhieuXuat.GhiChu,ChiTietPhieuXuat.NgayXuatChiTiet,PhieuXuat.MaPhieuXuat,HangHoa.TenHangHoa,HangHoa.MaHangHoa,ChiTietPhieuXuat.SoLuong,ChiTietPhieuXuat.DonGiaXuat from ChiTietPhieuXuat left join KhachHang on ChiTietPhieuXuat.IDKhachHang = KhachHang.IDKhachHang left join HangHoa on ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa  left join PhieuXuat on ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat  where '1'='1' and ChiTietPhieuXuat.TinhTrang = N'Còn nợ' ";
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
        sql += "  ) as tb1";

        DataTable Tong = Connect.GetTable("select isnull(SUM(tab2.SoLuong * tab2.DonGiaXuat),0) as 'Tong',isnull(SUM(tab2.SoLuong),0) as 'sl',isnull(sum(tab2.DonGiaXuat),0) as 'dgx' from (" + sql + ") as tab2");

        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize + " + 1 AND (((" + Page + " - 1) * " + PageSize + " + 1) + " + PageSize + ") - 1";

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                          STT
                        </th>
                        <th class='th'>
                        Ngày xuất
                        </th>
                        <th class='th'>
                          Mã phiếu xuất
                        </th>
                        <th class='th'>
                          Mã hàng hóa
                        </th>
                        <th class='th'>
                          Tên hàng hóa
                        </th>
                         <th class='th'>
                           Số lượng
                        </th>
                        <th class='th'>
                          Đơn giá xuất
                        </th>
                        <th class='th'>
                         Thành tiền
                        </th>
                        <th class='th'>
                          Tên khách hàng
                        </th>
                          <th class='th'>
                         Ghi chú
                        </th>
                      
                    </tr>";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";

            html += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
            html += "       <td>" + table.Rows[i]["MaPhieuXuat"].ToString() + "</td>";
            html += "       <td>" + table.Rows[i]["MaHangHoa"].ToString() + "</td>";
            html += "       <td>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";

            double r = double.Parse(table.Rows[i]["SoLuong"].ToString());
            html += "       <td>" + r.ToString("#,##").Replace(",", ".") + "</td>";
            double r2 = double.Parse(table.Rows[i]["DonGiaXuat"].ToString());
            // html += "       <td>" + table.Rows[i]["DonGiaNhap"].ToString() + "</td>";
            html += "       <td>" + r2.ToString("#,##").Replace(",", ".") + "</td>";
            double tong = r * r2;
            html += "       <td>" + tong.ToString("#,##").Replace(",", ".") + "</td>";
            html += "       <td>" + table.Rows[i]["TenKhachHang"].ToString() + "</td>";
            html += "       <td>" + table.Rows[i]["GhiChu"].ToString().Trim() + "</td>";
            // html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='window.location=\"DanhMucHangHoa-CapNhat.aspx?Page=" + Page.ToString() + "&IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "\"'><img title='Sửa' class='imgCommand' src='../Images/edit.png' onclick='window.location=\"DanhMucHangHoa-CapNhat.aspx?Page=" + Page.ToString() + "&IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "\"' /> Sửa </a></td>";
            //  html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='DeleteHangHoa(\"" + table.Rows[i]["IDHangHoa"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png' onclick='DeleteHangHoa(\"" + table.Rows[i]["IDHangHoa"].ToString() + "\")' />Xóa</a></td>";
            html += "       </tr>";

        }

        html += "<tr style='background-color: #00ff00;'>";

        html += "<td colspan='5' style='text-align: right;'><b>Tổng:</b></td>";
        double a =double.Parse( Tong.Rows[0]["sl"].ToString());
        double a2 = double.Parse(Tong.Rows[0]["dgx"].ToString());
        double a3 = double.Parse(Tong.Rows[0]["Tong"].ToString());
        html += "<td><b>" + a.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "<td><b>" + a2.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "<td><b>" + a3.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "<td colspan='2'>&nbsp;</td>";

        html += "</tr>";

        html += "   <tr>";
        html += "       <td colspan='10' class='footertable'>";
        string url = "CongNo.aspx?";
        if (pTenSanPham != "")
            url += "TenSanPham=" + pTenSanPham + "&";
        if (pTuNgayBan != "")
            url += "TuNgayBan=" + pTuNgayBan + "&";
        if (pDenNgayBan != "")
            url += "DenNgayBan=" + pDenNgayBan + "&";
        if (pTenKhachHang != "")
            url += "TenKhachHang=" + pTenKhachHang + "&";
        if (pMaPhieuXuat != "")
            url += "MaPhieuXuat=" + pMaPhieuXuat + "&";
        url += "Page=";
        html += "           <a class='notepaging' id='page_fist' href='" + url + txtFistPage + "' /><<</a>";
        //Page 1
        if (txtPage1 != "")
        {
            if (Page.ToString() == txtPage1)
                html += "           <a id='page_1' class='notepagingactive' href='" + url + txtPage1 + "' />" + txtPage1 + "</a>";
            else
                html += "           <a id='page_1' class='notepaging' href='" + url + txtPage1 + "' />" + txtPage1 + "</a>";
        }
        else
        {
            html += "           <a id='page_1' class='notepagingnone' href='" + url + txtPage1 + "' />" + txtPage1 + "</a>";
        }
        //Page 2
        if (txtPage2 != "")
        {
            if (Page.ToString() == txtPage2)
                html += "           <a id='page_2' class='notepagingactive' href='" + url + txtPage2 + "' />" + txtPage2 + "</a>";
            else
                html += "           <a id='page_2' class='notepaging' href='" + url + txtPage2 + "' />" + txtPage2 + "</a>";
        }
        else
        {
            html += "           <a id='page_2' class='notepagingnone' href='" + url + txtPage2 + "' />" + txtPage2 + "</a>";
        }
        //Page 3
        if (txtPage3 != "")
        {
            if (Page.ToString() == txtPage3)
                html += "           <a id='page_3' class='notepagingactive' href='" + url + txtPage3 + "' />" + txtPage3 + "</a>";
            else
                html += "           <a id='page_3' class='notepaging' href='" + url + txtPage3 + "' />" + txtPage3 + "</a>";
        }
        else
        {
            html += "           <a id='page_3' class='notepagingnone' href='" + url + txtPage3 + "' />" + txtPage3 + "</a>";
        }
        //Page 4
        if (txtPage4 != "")
        {
            if (Page.ToString() == txtPage4)
                html += "           <a id='page_4' class='notepagingactive' href='" + url + txtPage4 + "' />" + txtPage4 + "</a>";
            else
                html += "           <a id='page_4' class='notepaging' href='" + url + txtPage4 + "' />" + txtPage4 + "</a>";
        }
        else
        {
            html += "           <a id='page_4' class='notepagingnone' href='" + url + txtPage4 + "' />" + txtPage4 + "</a>";
        }
        //Page 5
        if (txtPage5 != "")
        {
            if (Page.ToString() == txtPage5)
                html += "           <a id='page_5' class='notepagingactive' href='" + url + txtPage5 + "' />" + txtPage5 + "</a>";
            else
                html += "           <a id='page_5' class='notepaging' href='" + url + txtPage5 + "' />" + txtPage5 + "</a>";
        }
        else
        {
            html += "           <a id='page_5' class='notepagingnone' href='" + url + txtPage5 + "' />" + txtPage5 + "</a>";
        }

        html += "           <a id='page_last' class='notepaging' href='" + url + txtLastPage + "' />>></a>";
        html += "   </td>";

        html += "</tr>";
        /**/
      
        html += "     </table>";

        dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        string TenSanPham = txtTenSanPham.Value.Trim();
        string TuNgayBan = txtTuNgayBan.Value.Trim();
        string DenNgayBan = txtDenNgayBan.Value.Trim();
        string TenKhachHang = txtTenKhachHang.Value.Trim();
        string MaPhieuXuat = txtMaPhieuXuat.Value.Trim();
        string url = "CongNo.aspx?";
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
        string url = "CongNo.aspx";
        Response.Redirect(url);
    }
}