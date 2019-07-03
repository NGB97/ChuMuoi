using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyNguoiDung_QuanLyNguoiDung : System.Web.UI.Page
{
    string pTaiKhoan = "";
    string pTenNguoiDung = "";
    string pQuyen = "";
   

    string txtFistPage = "1";
    string txtPage1 = "";
    string txtPage2 = "";
    string txtPage3 = "";
    string txtPage4 = "";
    string txtPage5 = "";
    string txtLastPage = "";
    int Page = 0;
    int MaxPage = 0;
    int PageSize =10;
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
                if (Request.QueryString["TaiKhoan"].Trim() != "")
                {
                    pTaiKhoan = StaticData.ValidParameter(Request.QueryString["TaiKhoan"].Trim());
                    txtTaiKhoan.Value = pTaiKhoan;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TenNguoiDung"].Trim() != "")
                {
                    pTenNguoiDung = StaticData.ValidParameter(Request.QueryString["TenNguoiDung"].Trim());
                    txtTenNguoiDung.Value = pTenNguoiDung;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["Quyen"].Trim() != "")
                {
                    pQuyen = StaticData.ValidParameter(Request.QueryString["Quyen"].Trim());
                    txtQuyen.Value = pQuyen;
                }
            }
            catch { }


            LoadDuAn();
        }
    } 
    #region paging
    private void SetPage()
    {
        string sql = "";

        sql += "select count(*) from NguoiDung where '1' = '1' ";

        if (pTenNguoiDung != "")
            sql += " and TenNguoiDung like N'%" + pTenNguoiDung + "%'";
        if(pTaiKhoan != "")
            sql += " and TaiKhoan like N'%" + pTaiKhoan + "%'";
        if (pQuyen != "")
            sql += " and Quyen like N'%" + pQuyen + "%'";
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
        sql += @"select * from( SELECT ROW_NUMBER() OVER(ORDER BY IDNguoiDung desc)AS RowNumber,* FROM NguoiDung where '1'='1' ";
        if (pTenNguoiDung != "")
            sql += " and TenNguoiDung like N'%" + pTenNguoiDung + "%'";
        if (pTaiKhoan != "")
            sql += " and TaiKhoan like N'%" + pTaiKhoan + "%'";
        if (pQuyen != "")
            sql += " and Quyen like N'%" + pQuyen + "%'";
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
                         Tài khoản
                        </th>
                        <th class='th'>
                         Mật khẩu
                        </th>
                        
                          <th class='th'>
                         Tên người dùng
                        </th>
                        <th class='th'>
                           Quyền
                        </th>
                        <th class='th'>
                           
                        </th>
                    </tr>";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";


            html += "       <td>" + table.Rows[i]["TaiKhoan"].ToString() + "</td>";

            html += "       <td>" + table.Rows[i]["MatKhau"].ToString() + "</td>";

            html += "       <td>" + table.Rows[i]["TenNguoiDung"].ToString().Trim() + "</td>";
            if (table.Rows[i]["Quyen"].ToString().Trim().CompareTo("NhanVien") == 0) html += "       <td>Nhân viên</td>";
            else
            html += "       <td>" + table.Rows[i]["Quyen"].ToString().Trim() + "</td>";
            html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='window.location=\"QuanLyNguoiDung-CapNhat.aspx?Page=" + Page.ToString() + "&IDNguoiDung=" + table.Rows[i]["IDNguoiDung"].ToString() + "\"'><img title='Sửa' class='imgCommand' src='../Images/edit.png' onclick='window.location=\"QuanLyNguoiDung-CapNhat.aspx?Page=" + Page.ToString() + "&IDNguoiDung=" + table.Rows[i]["IDNguoiDung"].ToString() + "\"' /> Sửa </a>";
            html += " |<a href='#' onclick='DeleteNguoiDung(\"" + table.Rows[i]["IDNguoiDung"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png' onclick='DeleteNguoiDung(\"" + table.Rows[i]["IDNguoiDung"].ToString() + "\")' />Xóa</a></td>";
            html += "       </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='12' class='footertable'>";
        string url = "QuanLyNguoiDung.aspx?";
        if (pTenNguoiDung != "")
            url += "TenNguoiDung=" + pTenNguoiDung + "&";
        if (pTaiKhoan != "")
            url += "TaiKhoan=" + pTaiKhoan + "&";
        if (pQuyen != "")
            url += "Quyen=" + pQuyen + "&";
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
        string TenNguoiDung = txtTenNguoiDung.Value.Trim();
        string TaiKhoan = txtTaiKhoan.Value.Trim(); string Quyen = txtQuyen.Value.Trim();
        string url = "QuanLyNguoiDung.aspx?";
        if (TenNguoiDung != "")
            url += "TenNguoiDung=" + TenNguoiDung + "&";
        if (TaiKhoan != "")
            url += "TaiKhoan=" + TaiKhoan + "&";
        if (Quyen != "")
            url += "Quyen=" + Quyen + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        string url = "QuanLyNguoiDung.aspx";
      

        Response.Redirect(url);
    }
}