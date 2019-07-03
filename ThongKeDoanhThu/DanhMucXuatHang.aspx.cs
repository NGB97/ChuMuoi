using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyXuatNhap_DanhMucXuatHang : System.Web.UI.Page
{
    string pSDT = "";
    string pTenKhachHang = "";
    string pMaPhieuXuat = "";
    string pTuNgayXuat = "";
    string pDenNgayXuat = "";
    string pMaLoaiHangHoa = "";
    string pSize = "";
    string pChatLieu = "";
    string pKieuDang = "";
    string pMauSac = "";
    string txtFistPage = "1";
    string txtPage1 = "";
    string txtPage2 = "";
    string txtPage3 = "";
    string txtPage4 = "";
    string txtPage5 = "";
    string txtLastPage = "";
    int Page = 0;
    int MaxPage = 0;
    int PageSize = 10;
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
            Page = int.Parse(Request.QueryString["Page"].ToString());
        }
        catch
        {
            Page = 1;   
        }
        if (!IsPostBack)
        {
            Load_MauSac_Size_ChatLieu_KieuDang();
            try
            {
                if (Request.QueryString["MaLoaiHangHoa"].Trim() != "")
                {
                    pMaLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["MaLoaiHangHoa"].Trim());
                    txtMaHangHoa.Value = pMaLoaiHangHoa;
                }
            }
            catch { }

            try
            {
                if (Request.QueryString["SDT"].Trim() != "")
                {
                    pSDT = StaticData.ValidParameter(Request.QueryString["SDT"].Trim());
                    txtSDT.Value = pSDT;
                }
            }
            catch { }
            
            try
            { 
               pSize = StaticData.ValidParameter(Request.QueryString["SizeHH"].Trim());
               slSizeHangHoa.Value = pSize; 
            }
            catch { }

            try
            {
                pChatLieu = StaticData.ValidParameter(Request.QueryString["ChatLieuHH"].Trim());
                slChatLieuHangHoa.Value = pChatLieu;
            }
            catch { }

            try
            {
                pKieuDang = StaticData.ValidParameter(Request.QueryString["KieuDangHH"].Trim());
                slKieuDangHangHoa.Value = pKieuDang;
            }
            catch { }

            try
            {
                pMauSac = StaticData.ValidParameter(Request.QueryString["MauSacHH"].Trim());
                slMauSacHangHoa.Value = pMauSac;
            }
            catch { }

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
                if (Request.QueryString["MaPhieuXuat"].Trim() != "")
                {
                    pMaPhieuXuat = StaticData.ValidParameter(Request.QueryString["MaPhieuXuat"].Trim());
                    txtMaXuatHang.Value = pMaPhieuXuat;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TuNgayXuat"].Trim() != "")
                {
                    pTuNgayXuat = StaticData.ValidParameter(Request.QueryString["TuNgayXuat"].Trim());
                    txtTuNgayXuat.Value = pTuNgayXuat;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["DenNgayXuat"].Trim() != "")
                {
                    pDenNgayXuat = StaticData.ValidParameter(Request.QueryString["DenNgayXuat"].Trim());
                    txtDenNgayXuat.Value = pDenNgayXuat;
                }
            }
            catch { }

            LoadDuAn();
        }
    } 
    void Load_MauSac_Size_ChatLieu_KieuDang()
    { 
        string sql = "select * from ChatLieu";
        DataTable table = Connect.GetTable(sql);
        slChatLieuHangHoa.DataSource = table;
        slChatLieuHangHoa.DataTextField = "TenChatLieu";
        slChatLieuHangHoa.DataValueField = "idChatLieu";
        slChatLieuHangHoa.DataBind();
        slChatLieuHangHoa.Items.Add(new ListItem("", ""));
        slChatLieuHangHoa.Items.FindByText("").Selected = true;


        string sql2 = "select * from KieuDang";
        DataTable table2 = Connect.GetTable(sql2);
        slKieuDangHangHoa.DataSource = table2;
        slKieuDangHangHoa.DataTextField = "TenKieuDang";
        slKieuDangHangHoa.DataValueField = "idKieuDang";
        slKieuDangHangHoa.DataBind();
        slKieuDangHangHoa.Items.Add(new ListItem("", ""));
        slKieuDangHangHoa.Items.FindByText("").Selected = true;


        string sql3 = "select * from MauSac";
        DataTable table3 = Connect.GetTable(sql3);
        slMauSacHangHoa.DataSource = table3;
        slMauSacHangHoa.DataTextField = "TenMauSac";
        slMauSacHangHoa.DataValueField = "idMauSac";
        slMauSacHangHoa.DataBind();
        slMauSacHangHoa.Items.Add(new ListItem("", ""));
        slMauSacHangHoa.Items.FindByText("").Selected = true;


        string sql4 = "select * from Size";
        DataTable table4 = Connect.GetTable(sql4);
        slSizeHangHoa.DataSource = table4;
        slSizeHangHoa.DataTextField = "TenSize";
        slSizeHangHoa.DataValueField = "idSize";
        slSizeHangHoa.DataBind();
        slSizeHangHoa.Items.Add(new ListItem("", ""));
        slSizeHangHoa.Items.FindByText("").Selected = true;
    }

    #region paging
    private void SetPage()
    {
        string sql = "";

        sql += "select count(*) from PhieuXuat where '1' = '1' ";

        string timKiem_MaLoaiHangHoa = "", timKiem_Size = "", timKiem_ChatLieu = "", timKiem_KieuDang = "", timKiem_Mau = "";
        if (pMaLoaiHangHoa != "")
            timKiem_MaLoaiHangHoa = " and LoaiHangHoa.MaLoaiHangHoa like N'%" + pMaLoaiHangHoa + "%'  ";
        if (pSize != "")
            timKiem_Size = " and HangHoa.IDSize like N'%" + pSize + "%' ";
        if (pChatLieu != "")
            timKiem_ChatLieu = " and HangHoa.IDChatLieu like N'%" + pChatLieu + "%' ";
        if (pKieuDang != "")
            timKiem_KieuDang = " and HangHoa.IDKieuDang like N'%" + pKieuDang + "%' ";
        if (pMauSac != "")
            timKiem_Mau = " and HangHoa.IDMauSac like N'%" + pMauSac + "%' ";

        if (pMaLoaiHangHoa != "" || pSize != "" || pChatLieu != "" || pKieuDang != "" || pMauSac != "")
        {
            sql += @" and IDPhieuXuat in (select distinct PhieuXuat.IDPhieuXuat from PhieuXuat,ChiTietPhieuXuat,HangHoa,LoaiHangHoa where PhieuXuat.IDPhieuXuat=ChiTietPhieuXuat.IDPhieuXuat and ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and HangHoa.IDLoaiHangHoa = LoaiHangHoa.IDLoaiHangHoa 
                                              " + timKiem_MaLoaiHangHoa + @" 
                                              " + timKiem_Size + @"
                                              " + timKiem_ChatLieu + @"
                                              " + timKiem_KieuDang + @"
                                              " + timKiem_Mau + @"
                                            )";
        }
        if (pMaPhieuXuat != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'%" + pMaPhieuXuat + "%'";
        if (pTuNgayXuat != "")
            sql += " and PhieuXuat.NgayXuat >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayXuat) + " 00:00:00'";
        if (pDenNgayXuat != "")
            sql += " and PhieuXuat.NgayXuat <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayXuat) + " 00:00:00'";
        if (pTenKhachHang != "")
            sql += " and PhieuXuat.IDKhachHang in (select KhachHang.IDKhachHang from KhachHang where KhachHang.TenKhachHang like N'%" + pTenKhachHang + "%' ) ";
        if (pSDT != "")
            sql += " and PhieuXuat.IDKhachHang in (select KhachHang.IDKhachHang from KhachHang where KhachHang.DienThoai like N'%" + pSDT + "%' ) ";

        //Label1.Text = sql;
        DataTable tbTotalRows = Connect.GetTable(sql);
      //  Response.Write("<script>alert('" + tbTotalRows.Rows[0][0].ToString() + "')</script>");
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
        string chuoicong = "";
        if(pMaLoaiHangHoa != "" || pMaPhieuXuat != "" || pTuNgayXuat  != "" || pDenNgayXuat  != "" || pTenKhachHang != "" || pSDT != "" || pSize != "" || pChatLieu != "" || pKieuDang != "" || pMauSac != "")
        {
            chuoicong = "PhieuXuat.NgayXuat DESC,";
        }
        string timKiem_MaLoaiHangHoa = "", timKiem_Size = "", timKiem_ChatLieu = "", timKiem_KieuDang = "", timKiem_Mau = "";
        double Tong = 0;
        string sql = "";
        sql += "select * from( SELECT ROW_NUMBER() OVER(order by " + chuoicong + " KhachHang.TenKhachHang ASC)AS RowNumber,PhieuXuat.* FROM PhieuXuat,KhachHang where KhachHang.IDKhachHang=PhieuXuat.IDKhachHang and MaPhieuXuat not like '%-XB' ";


        if (pMaLoaiHangHoa != "") 
            timKiem_MaLoaiHangHoa = " and LoaiHangHoa.MaLoaiHangHoa like N'%" + pMaLoaiHangHoa + "%'  ";
        if (pSize != "")
            timKiem_Size = " and HangHoa.IDSize like N'%" + pSize + "%' ";
        if (pChatLieu != "")
            timKiem_ChatLieu = " and HangHoa.IDChatLieu like N'%" + pChatLieu + "%' ";
        if (pKieuDang != "")
            timKiem_KieuDang = " and HangHoa.IDKieuDang like N'%" + pKieuDang + "%' ";
        if (pMauSac != "")
            timKiem_Mau = " and HangHoa.IDMauSac like N'%" + pMauSac + "%' ";

        if (pMaLoaiHangHoa != "" || pSize != "" || pChatLieu != "" || pKieuDang != "" || pMauSac != "")
        {
            sql += @" and IDPhieuXuat in (select distinct PhieuXuat.IDPhieuXuat from PhieuXuat,ChiTietPhieuXuat,HangHoa,LoaiHangHoa where PhieuXuat.IDPhieuXuat=ChiTietPhieuXuat.IDPhieuXuat and ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and HangHoa.IDLoaiHangHoa = LoaiHangHoa.IDLoaiHangHoa 
                                              " + timKiem_MaLoaiHangHoa + @" 
                                              " + timKiem_Size + @"
                                              " + timKiem_ChatLieu + @"
                                              " + timKiem_KieuDang + @"
                                              " + timKiem_Mau + @"
                                            )";
        }


        if (pMaPhieuXuat != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'%" + pMaPhieuXuat + "%'";
        if (pTuNgayXuat != "")
            sql += " and PhieuXuat.NgayXuat >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayXuat) + " 00:00:00'";
        if (pDenNgayXuat != "")
            sql += " and PhieuXuat.NgayXuat <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayXuat) + " 00:00:00'";
        if (pTenKhachHang != "")
            sql += " and KhachHang.IDKhachHang in (select KhachHang.IDKhachHang from KhachHang where KhachHang.TenKhachHang like N'%" + pTenKhachHang + "%' ) ";

        if (pSDT != "")
            sql += " and KhachHang.IDKhachHang in (select KhachHang.IDKhachHang from KhachHang where KhachHang.DienThoai like N'%" + pSDT + "%' ) ";

        sql += "  ) as tb1 ";

        DataTable tbTong = Connect.GetTable("select isnull(sum(ChiTietPhieuXuat.SoLuong*ChiTietPhieuXuat.DonGiaXuat),0) from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat in (select tb22.IDPhieuXuat from(" + sql + ") as tb22)");
        Tong += double.Parse(tbTong.Rows[0][0].ToString());
          
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize + " + 1 AND (((" + Page + " - 1) * " + PageSize + " + 1) + " + PageSize + ") - 1";
      
        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                          STT
                        </th>
                       
                        <th class='th'>
                         Ngày lập  
                        </th>
                       <th class='th'>
                       Bán cho Khách
                        </th>
                       <th class='th'>
                       SĐT
                       </th>

                      <th class='th'>
                       Tổng tiền đơn hàng
                        </th>
                           <th class='th'>
                       Xem chi tiết
                        </th>
                          <th class='th'>
                         Ghi chú
                        </th>
                       
                        <th class='th'>
                           
                        </th>
                        <th class='th'>
                           
                        </th>
                        <th class='th'>
                           
                        </th>
                    </tr>";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";
             
            html += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") + "</td>";
            html += "       <td>" + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[i]["IDKhachHang"].ToString()) + "</td>";
            html += "       <td>" + StaticData.getField("KhachHang", "DienThoai", "IDKhachHang", table.Rows[i]["IDKhachHang"].ToString()) + "</td>";
            //  html += "       <td>" + StaticData.getField("Kho", "TenKho", "IDKho", table.Rows[i]["IDKho"].ToString()) + "</td>";

            DataTable TongTien = Connect.GetTable("select isnull(sum(SoLuong*DonGiaXuat),0) from ChiTietPhieuXuat where IDPhieuXuat = " + table.Rows[i]["IDPhieuXuat"].ToString() + "");

            if (TongTien.Rows[0][0].ToString() == "0")
                html += "<td>0</td>";
            else html += "<td>" + double.Parse(TongTien.Rows[0][0].ToString()).ToString("#,##").Replace(",", ".") + "</td>"; 

            html += " <td style='text-align:left;font-size: 100%;'><a style='cursor:pointer;' onclick='LoadChiTietXuatHang(\"" + table.Rows[i]["IDPhieuXuat"].ToString() + "\");'>Xem chi tiết</a></td>";
            html += "       <td>" + table.Rows[i]["GhiChu"].ToString().Trim().Replace("\n", "<br />") + "</td>";
            // html += "<td><a style='cursor:pointer;' class='btn btn-primary btn-flat' onclick='InPhieuXuatHang(\"" + table.Rows[i]["IDPhieuXuat"].ToString() + "\");'>IN</a></td>";
            // html += "<td><a href='#' class='btn btn-primary btn-flat' onclick='window.location=\"../Ajax.aspx?Action=ExportExcel2&MaPhieuXuat=" + StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", table.Rows[i]["IDPhieuXuat"].ToString()).Trim() + "\"'>IN BB2</a></td>";
            html += " <td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='InPhieuTongHopXuatHang(\"" + table.Rows[i]["IDPhieuXuat"].ToString() + "\")'><i class='fa fa-print' style='font-size:24px'></i><br />In</a></td>";
            html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='window.location=\"DanhMucXuatHangSua.aspx?Page=" + Page.ToString() + "&IDPhieuXuat=" + table.Rows[i]["IDPhieuXuat"].ToString() + "\"'><img title='Sửa' class='imgCommand' src='../Images/edit.png' onclick='window.location=\"DanhMucXuatHangSua.aspx?Page=" + Page.ToString() + "&IDPhieuXuat=" + table.Rows[i]["IDPhieuXuat"].ToString() + "\"' /> Sửa </a></td>";
            html += " <td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='DeletePhieuXuat(\"" + table.Rows[i]["IDPhieuXuat"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png' onclick='DeletePhieuXuat(\"" + table.Rows[i]["IDPhieuXuat"].ToString() + "\")' />Xóa</a></td>";
            html += "       </tr>";

        }

        html += "   <tr style='background-color: #d0930a'>";

        html += "       <td colspan='4'>Tổng cộng: </td>";
        html += "       <td>" + string.Format("{0:N0}", Tong).Replace(",", ".") + @" </td>";
        html += "       <td colspan='5'> </td>";

        html += "   </tr>";


        html += "   <tr>";
        html += "       <td colspan='11' class='footertable'>";
        string url = "DanhMucXuatHang.aspx?";
        if (pMaPhieuXuat != "")
            url += "MaPhieuXuat=" + pMaPhieuXuat + "&";
        if (pTuNgayXuat != "")
            url += "TuNgayXuat=" + pTuNgayXuat + "&";
        if (pDenNgayXuat != "")
            url += "DenNgayXuat=" + pDenNgayXuat + "&";
        if (pMaLoaiHangHoa != "")
            url += "MaLoaiHangHoa=" + pMaLoaiHangHoa + "&";
        if (pTenKhachHang != "")
            url += "TenKhachHang=" + pTenKhachHang + "&";
        if (pSDT != "")
            url += "SDT=" + pSDT + "&";
         
        if (pSize != "")
            url += "SizeHH=" + pSize + "&";
        if (pChatLieu != "")
            url += "ChatLieuHH=" + pChatLieu + "&";
        if (pKieuDang != "")
            url += "KieuDangHH=" + pKieuDang + "&";
        if (pMauSac != "")
            url += "MauSacHH=" + pMauSac + "&"; 

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

        html += "     </table>";

        dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {

        string MaLoaiHangHoa = txtMaHangHoa.Value.Trim();
        string MaPhieuXuat = txtMaXuatHang.Value.Trim();
        string TuNgayXuat = txtTuNgayXuat.Value.Trim();
        string DenNgayXuat = txtDenNgayXuat.Value.Trim();
        string TenKhachHang = txtTenKhachHang.Value.Trim();
        string SDT = txtSDT.Value.Trim();

        string Size = slSizeHangHoa.Value.Trim();
        string ChatLieu = slChatLieuHangHoa.Value.Trim();
        string MauSac = slMauSacHangHoa.Value.Trim();
        string KieuDang = slKieuDangHangHoa.Value.Trim();
        string url = "DanhMucXuatHang.aspx?";
        if (SDT != "")
            url += "SDT=" + SDT + "&";
        if (TenKhachHang != "")
            url += "TenKhachHang=" + TenKhachHang + "&";
        if (MaLoaiHangHoa != "")
            url += "MaLoaiHangHoa=" + MaLoaiHangHoa + "&";
        if (MaPhieuXuat != "")
            url += "MaPhieuXuat=" + MaPhieuXuat + "&";
        if (TuNgayXuat != "")
            url += "TuNgayXuat=" + TuNgayXuat + "&";
        if (DenNgayXuat != "")
            url += "DenNgayXuat=" + DenNgayXuat + "&";
        if (Size != "")
            url += "SizeHH=" + Size + "&";
        if (ChatLieu != "")
            url += "ChatLieuHH=" + ChatLieu + "&";
        if (MauSac != "")
            url += "MauSacHH=" + MauSac + "&";
        if (KieuDang != "")
            url += "KieuDangHH=" + KieuDang + "&";

        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        Response.Redirect("DanhMucXuatHang.aspx");
    }
}