using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucKhachHang : System.Web.UI.Page
{
    string pMaKhachHang = "";
    string pTenKhachHang = "";
    string pCapDaiLy = "";
    string pSoDienThoai = "";
    string pIDLoaiHangCapCao = "";
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
        /*if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
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
            Page = int.Parse(Request.QueryString["Page"].ToString());
        }
        catch
        {
            Page = 1;
        }
        if (!IsPostBack)
        {
            LoadQuyen();
            try
            {
                if (Request.QueryString["IDLoaiHangCapCao"].Trim() != "")
                {
                    pIDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());
                    txtLoaiHangHoa.Value = pIDLoaiHangCapCao;
                }
            }
            catch { }

            try
            {
                if (Request.QueryString["MaKhachHang"].Trim() != "")
                {
                    pMaKhachHang = StaticData.ValidParameter(Request.QueryString["MaKhachHang"].Trim());
                    txtMaKhachHang.Value = pMaKhachHang;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["CapDaiLy"].Trim() != "")
                {
                    pCapDaiLy = StaticData.ValidParameter(Request.QueryString["CapDaiLy"].Trim());
                    //slCapDaiLy.Value = pCapDaiLy;
                }
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
                if (Request.QueryString["SoDienThoai"].Trim() != "")
                {
                    pSoDienThoai = StaticData.ValidParameter(Request.QueryString["SoDienThoai"].Trim());
                    txtSoDienThoai.Value = pSoDienThoai;

                }
            }
            catch { }

           
            LoadDuAn();
        }
    }
    private void LoadQuyen()
    {
        string strSql = "select * from LoaiHangCapCao";
        txtLoaiHangHoa.DataSource = Connect.GetTable(strSql);
        txtLoaiHangHoa.DataTextField = "TenLoaiHangCapCao";
        txtLoaiHangHoa.DataValueField = "IDLoaiHangCapCao";
        txtLoaiHangHoa.DataBind();
        txtLoaiHangHoa.Items.Add(new ListItem("", ""));
        txtLoaiHangHoa.Items.FindByText("").Selected = true;
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

        sql += "select count(*) from LoaiHangHoa where '1' = '1' ";

        if (pMaKhachHang != "")
            sql += " and TenLoaiHangHoa like N'%" + pMaKhachHang + "%'";
        if (pSoDienThoai != "")
            sql += " and DienThoai like N'%" + pSoDienThoai + "%'";
        if (pIDLoaiHangCapCao != "")
            sql += " and IDLoaiHangCapCao = '" + pIDLoaiHangCapCao + "' ";
        if (pTenKhachHang != "")
            sql += " and TenKhachHang like N'%" + pTenKhachHang + "%'";
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
        sql += @"select * from( SELECT ROW_NUMBER() OVER(ORDER BY LoaiHangHoa.MaLoaiHangHoa asc)AS RowNumber,* FROM LoaiHangHoa where '1'='1' ";
        if (pMaKhachHang != "")
            sql += " and TenLoaiHangHoa like N'%" + pMaKhachHang + "%'";
        if (pSoDienThoai != "")
            sql += " and DienThoai like N'%" + pSoDienThoai + "%'";
        if (pIDLoaiHangCapCao != "")
            sql += " and IDLoaiHangCapCao = '" + pIDLoaiHangCapCao + "' ";
        if (pTenKhachHang != "")
            sql += " and TenKhachHang like N'%" + pTenKhachHang + "%'";

        sql += "  ) as tb1";
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize + " + 1 AND (((" + Page + " - 1) * " + PageSize + " + 1) + " + PageSize + ") - 1";

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                          STT
                        </th>
<th class='th'>
                         Mã hàng hóa
                        </th>
                        <th class='th'>
                         Tên hàng hóa
                        </th>
 <th class='th'>
                          Hình
                        </th>
                        <th class='th'>
                          Giá gốc
                        </th>
                        <th class='th'>
                          Thuộc loại hàng hóa
                        </th>
                        <th class='th'>
                         Đơn vị tính
                        </th>
                        <th class='th'>
                           Giá Bán
                        </th>
                        <th class='th'>
                           
                        </th>
                        <th colspan='2' class='th'>
                           
                        </th>
                    </tr>";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr >";
            html += "       <td style='vertical-align:middle;'>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";
            html += "       <td style='vertical-align:middle;'>" + table.Rows[i]["MaLoaiHangHoa"].ToString() + "</td>";

            html += "       <td style='vertical-align:middle;'><a style='cursor:pointer' onclick='XemChiTietMauSize(" + table.Rows[i]["IDLoaiHangHoa"].ToString() + ")' >" + table.Rows[i]["TenLoaiHangHoa"].ToString() +"</a></td>";
            html += "       <td style='text-align:center;'><img height='60' width='60' src='" + table.Rows[i]["HinhAnh"].ToString() + "' /></td>";
            if (table.Rows[i]["Gia"].ToString() == "0")
                html += "       <td style='vertical-align:middle;'>0</td>";
            else
                html += "       <td style='vertical-align:middle;'>" + double.Parse(table.Rows[i]["Gia"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";


            html += "       <td style='vertical-align:middle;'>" + StaticData.getField("LoaiHangCapCao", "TenLoaiHangCapCao", "IDLoaiHangCapCao", table.Rows[i]["IDLoaiHangCapCao"].ToString()) + "</td>";
            html += "       <td style='vertical-align:middle;'>" + StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", table.Rows[i]["IDDonViTinh"].ToString()) + "</td>";
            html += " <td style='text-align:center;font-size: 100%;vertical-align:middle;'><a href='#' onclick='window.location=\"DanhMucGiaBan.aspx?Page=" + Page.ToString() + "&IDLoaiHangHoa=" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "\"'><img title='Giá bán' class='imgCommand' src='../Images/edit.png'  />Giá bán</a></td>";
            html += " <td style='text-align:center;font-size: 100%;vertical-align:middle;'><a href='#' onclick='window.location=\"DanhMucLoaiHangHoaSua.aspx?Page=" + Page.ToString() + "&IDLoaiHangHoa=" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "\"'><img title='Sửa' class='imgCommand' src='../Images/edit.png'  /></a></td>";
            html += " <td style='text-align:center;font-size: 100%;vertical-align:middle;'><a href='#' onclick='DeleteKhachHang(\"" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png'  /></a></td>";
            html += "       </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='13' class='footertable'>";
        string url = "DanhMucLoaiHangHoa.aspx?";
        if (pMaKhachHang != "")
            url += "MaKhachHang=" + pMaKhachHang + "&";
        if (pSoDienThoai != "")
            url += "SoDienThoai=" + pSoDienThoai + "&";
       
        if (pTenKhachHang != "")
            url += "TenKhachHang=" + pTenKhachHang + "&";


        if (pIDLoaiHangCapCao != "")
            url += "IDLoaiHangCapCao=" + pIDLoaiHangCapCao + "&";
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
        string MaKhachHang = txtMaKhachHang.Value.Trim();
        string SoDienThoai = txtSoDienThoai.Value.Trim();
        string IDLoaiHangCapCao = txtLoaiHangHoa.Value.Trim();
       
        string TenKhachHang = txtTenKhachHang.Value.Trim();
        string url = "DanhMucLoaiHangHoa.aspx?";
        if (MaKhachHang != "")
            url += "MaKhachHang=" + MaKhachHang + "&";
        if (SoDienThoai != "")
            url += "SoDienThoai=" + SoDienThoai + "&";
     
        if (TenKhachHang != "")
            url += "TenKhachHang=" + TenKhachHang + "&";

        if (IDLoaiHangCapCao != "")
            url += "IDLoaiHangCapCao=" + IDLoaiHangCapCao + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {


        string url = "DanhMucLoaiHangHoa.aspx?";
       

        Response.Redirect(url);
    }
}