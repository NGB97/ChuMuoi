using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Text;
public partial class BaoCao_BaoCaoTongHop : System.Web.UI.Page
{
    string pIDLoaiHangHoa = "";
    string pMaHangHoa = "";
    string pTenHangHoa = "";
    string pLoaiHangCapCao = "";
    string pNgayDauKy = "";
    string pNgayCuoiKy = "";
    string pTuPhieu = "";
    string pDenPhieu = "";
    string pIDKho = "";
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
    int PageSize2 = 15;
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
            LoadQuyen();
            Load_MauSac_Size_ChatLieu_KieuDang();

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
                if (Request.QueryString["IDLoaiHangHoa"].Trim() != "")
                {
                    pIDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
                    txtIDHangHoa.Value = pIDLoaiHangHoa;
                    //txtKho.Value = StaticData.getField("Kho", "TenKho", "IDKho", pIDKho);
                    txtTenHangHoa.Value = StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", pIDLoaiHangHoa) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", pIDLoaiHangHoa);
                }
            }
            catch { }

            try
            {
                if (Request.QueryString["IDKho"].Trim() != "")
                {
                    pIDKho = StaticData.ValidParameter(Request.QueryString["IDKho"].Trim());
                    txtIDKho.Value = pIDKho;
                    txtKho.Value = StaticData.getField("Kho", "TenKho", "IDKho", pIDKho);
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["NgayDauKy"].Trim() != "")
                {
                    pNgayDauKy = StaticData.ValidParameter(Request.QueryString["NgayDauKy"].Trim());
                    txtNgayDauKy.Value = pNgayDauKy;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["NgayCuoiKy"].Trim() != "")
                {
                    pNgayCuoiKy = StaticData.ValidParameter(Request.QueryString["NgayCuoiKy"].Trim());
                    txtNgayCuoiKy.Value = pNgayCuoiKy;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TenHangHoa"].Trim() != "")
                {
                    pTenHangHoa = StaticData.ValidParameter(Request.QueryString["TenHangHoa"].Trim());
                    txtTenHangHoa.Value = pTenHangHoa;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TuPhieu"].Trim() != "")
                {
                    pTuPhieu = StaticData.ValidParameter(Request.QueryString["TuPhieu"].Trim());
                    txtTuPhieu.Value = pTuPhieu;
                }
            }
            catch { }

            try
            {
                if (Request.QueryString["LoaiHangCapCao"].Trim() != "")
                {
                    pLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["LoaiHangCapCao"].Trim());
                    txtLoaiHangCapCao.Value = pLoaiHangCapCao;

                }
            }
            catch { }

            try
            {
                if (Request.QueryString["DenPhieu"].Trim() != "")
                {
                    pDenPhieu = StaticData.ValidParameter(Request.QueryString["DenPhieu"].Trim());
                    txtDenPhieu.Value = pDenPhieu;
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
        slChatLieuHangHoa.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
        slChatLieuHangHoa.Items.FindByText("").Selected = true;


        string sql2 = "select * from KieuDang";
        DataTable table2 = Connect.GetTable(sql2);
        slKieuDangHangHoa.DataSource = table2;
        slKieuDangHangHoa.DataTextField = "TenKieuDang";
        slKieuDangHangHoa.DataValueField = "idKieuDang";
        slKieuDangHangHoa.DataBind();
        slKieuDangHangHoa.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
        slKieuDangHangHoa.Items.FindByText("").Selected = true;


        string sql3 = "select * from MauSac";
        DataTable table3 = Connect.GetTable(sql3);
        slMauSacHangHoa.DataSource = table3;
        slMauSacHangHoa.DataTextField = "TenMauSac";
        slMauSacHangHoa.DataValueField = "idMauSac";
        slMauSacHangHoa.DataBind();
        slMauSacHangHoa.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
        slMauSacHangHoa.Items.FindByText("").Selected = true;


        string sql4 = "select * from Size";
        DataTable table4 = Connect.GetTable(sql4);
        slSizeHangHoa.DataSource = table4;
        slSizeHangHoa.DataTextField = "TenSize";
        slSizeHangHoa.DataValueField = "idSize";
        slSizeHangHoa.DataBind();
        slSizeHangHoa.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
        slSizeHangHoa.Items.FindByText("").Selected = true;
    }
    private void LoadQuyen()
    {
        string strSql = "select * from LoaiHangCapCao";
        DataTable table = new DataTable();
        table.Columns.Add("IDLoaiHangCapCao", typeof(string));
        table.Columns.Add("TenLoaiHangCapCao", typeof(string));
        table.Columns.Add("TenLoaiCap1", typeof(string));
        table.Rows.Add("", "", "Tất cả");
        DataTable temp = Connect.GetTable(strSql);

        for (int i = 0; i < temp.Rows.Count; i++)
        {
            string IDLoaiHangCapCao = temp.Rows[i]["IDLoaiHangCapCao"].ToString().Trim();
            string TenLoaiHangCapCao = temp.Rows[i]["TenLoaiHangCapCao"].ToString().Trim();
            string TenLoaiCap1 = temp.Rows[i]["TenLoaiCap1"].ToString().Trim();

            table.Rows.Add(IDLoaiHangCapCao, TenLoaiHangCapCao, TenLoaiCap1);
        }

        txtLoaiHangCapCao.DataSource = table; //Connect.GetTable(strSql);
        txtLoaiHangCapCao.DataTextField = "TenLoaiHangCapCao";
        txtLoaiHangCapCao.DataValueField = "IDLoaiHangCapCao";
        txtLoaiHangCapCao.DataBind();
        //txtLoaiHangCapCao.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
        //txtLoaiHangCapCao.Items.FindByText("").Selected = true;
    }
    #region paging
    private void SetPage()
    {
        string sql = @"select count(*) from ( 
                                                                                                            select IDHangHoa,TenSize,TenMauSac,TenKieuDang,TenChatLieu,TenLoaiHangHoa ,HH.idLoaiHangHoa ,HH.idSize,HH.idMauSac,HH.idKieuDang,HH.idChatLieu 
                                                                                                            from HangHoa HH, LoaiHangHoa LHH, Size S,ChatLieu CL, KieuDang KD,MauSac MS 
                                                                                                            where HH.IDSize=S.IDSize and HH.idChatLieu=CL.idChatLieu and KD.idKieuDang=HH.idKieuDang and MS.idMauSac=HH.idMauSac and HH.idLoaiHangHoa=LHH.idLoaiHangHoa
                                                                                                            ) as tb2 where '1'='1' ";

        if (pTenHangHoa != "")
            sql += " and TenLoaiHangHoa like N'%" + pTenHangHoa + "%' ";

        if (pSize != "")
            sql += " and idSize like N'%" + pSize + "%' ";
        if (pMauSac != "")
            sql += " and idMauSac like N'%" + pMauSac + "%' ";
        if (pKieuDang != "")
            sql += " and idKieuDang like N'%" + pKieuDang + "%' ";
        if (pChatLieu != "")
            sql += " and idChatLieu like N'%" + pChatLieu + "%' "; 
         
        DataTable tbTotalRows = Connect.GetTable(sql); 
        int TotalRows = int.Parse(tbTotalRows.Rows[0][0].ToString());
        if (TotalRows % PageSize2 == 0)
            MaxPage = TotalRows / PageSize2;
        else
            MaxPage = TotalRows / PageSize2 + 1;
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
        string sql = @"select * from(select ROW_NUMBER() OVER(ORDER BY IDHangHoa asc)AS RowNumber,* from ( 
                                                                                                            select IDHangHoa,TenSize,TenMauSac,TenKieuDang,TenChatLieu,TenLoaiHangHoa ,HH.idLoaiHangHoa,HH.idSize,HH.idMauSac,HH.idKieuDang,HH.idChatLieu 
                                                                                                            from HangHoa HH, LoaiHangHoa LHH, Size S,ChatLieu CL, KieuDang KD,MauSac MS 
                                                                                                            where HH.IDSize=S.IDSize and HH.idChatLieu=CL.idChatLieu and KD.idKieuDang=HH.idKieuDang and MS.idMauSac=HH.idMauSac and HH.idLoaiHangHoa=LHH.idLoaiHangHoa
                                                                                                            ) as tb2 where '1'='1' ";


         if (pTenHangHoa != "")
             sql += " and TenLoaiHangHoa like N'%" + pTenHangHoa + "%' ";

         if (pSize != "")
             sql += " and idSize like N'%" + pSize + "%' ";
         if (pMauSac != "")
             sql += " and idMauSac like N'%" + pMauSac + "%' ";
         if (pKieuDang != "")
             sql += " and idKieuDang like N'%" + pKieuDang + "%' ";
         if (pChatLieu != "")
             sql += " and idChatLieu like N'%" + pChatLieu + "%' "; 

        sql += "  ) as tb1";

        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize2 + " + 1 AND (((" + Page + " - 1) * " + PageSize2 + " + 1) + " + PageSize2 + ") - 1";
        DataTable table = Connect.GetTable(sql);
        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                  <tr>
                        <th class='th'  style='text-align: center;'>
                            STT
                        </th>
                        <th class='th'  style='text-align: center;'>
                            Tên hàng hóa
                        </th>
                        <th class='th'  style='text-align: center;'>
                            Size
                        </th>         
                        <th class='th'  style='text-align: center;'>
                            Chất liệu
                        </th>
                        <th class='th'  style='text-align: center;'>
                            Kiểu dáng
                        </th>
                        <th class='th'  style='text-align: center;'>
                            Màu sắc
                        </th>
                        <th class='th'  style='text-align: center;'>
                            Số lượng tồn
                        </th>
                        <th class='th'  style='text-align: center;'>
                            
                        </th>
                    </tr>";  
        for (int i = 0; i < table.Rows.Count; i++)
        {
            int soLuongTon = 0;
            try
            {
                soLuongTon = int.Parse(StaticData.getField("HangHoa HH", "( (select sum(soLuong) from ChiTietPhieuNhap where idHangHoa=HH.IdHangHoa) -  (select sum(soLuong) from ChiTietPhieuXuat where idHangHoa=HH.IdHangHoa) ) as SoLuongTon", "HH.idHangHoa", table.Rows[i]["idHangHoa"].ToString()));
            }
            catch { }

            html += "    <tr >";
            html += "       <td>" + (((Page - 1) * PageSize2) + i + 1).ToString() + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["TenLoaiHangHoa"]  + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["TenSize"] + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["TenChatLieu"] + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["TenKieuDang"] + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["TenMauSac"] + "</td>";  
            html += "       <td style='text-align: center;'>" + soLuongTon.ToString("N0") + "</td>";  

            html += "     </tr>"; 
        } 
        html += "   <tr>";
        html += "       <td colspan='9' class='footertable'>";
         
        string url = "ThongKeTonKho.aspx?";
        if (pNgayDauKy != "")
            url += "NgayDauKy=" + pNgayDauKy + "&";
        if (pNgayCuoiKy != "")
            url += "NgayCuoiKy=" + pNgayCuoiKy + "&";
        if (pTuPhieu != "")
            url += "TuPhieu=" + pTuPhieu + "&";
        if (pDenPhieu != "")
            url += "DenPhieu=" + pDenPhieu + "&";
        if (pTenHangHoa != "")
            url += "TenHangHoa=" + pTenHangHoa + "&";
        if (pIDKho != "")
            url += "IDKho=" + pIDKho + "&";
        if (pLoaiHangCapCao != "")
            url += "LoaiHangCapCao=" + pLoaiHangCapCao + "&";
        if (pIDLoaiHangHoa != "")
            url += "IDLoaiHangHoa=" + pIDLoaiHangHoa + "&";

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
        string NgayDauKy = txtNgayDauKy.Value.Trim();
        string NgayCuoiKy = txtNgayCuoiKy.Value.Trim();
        string TuPhieu = txtTuPhieu.Value.Trim();
        string DenPhieu = txtDenPhieu.Value.Trim();
        string IDKho = txtIDKho.Value.Trim();
        string TenKho = txtKho.Value.Trim();
        string TenHangHoa = txtTenHangHoa.Value.Trim();
        string LoaiHangCapCao = txtLoaiHangCapCao.Value.Trim();
        string IDLoaiHangHoa = txtIDHangHoa.Value.Trim();

        string Size = slSizeHangHoa.Value.Trim();
        string ChatLieu = slChatLieuHangHoa.Value.Trim();
        string MauSac = slMauSacHangHoa.Value.Trim();
        string KieuDang = slKieuDangHangHoa.Value.Trim();
        

        if (txtTenHangHoa.Value.Trim().Length <= 0)
        {
            IDLoaiHangHoa = "";
        }

        if (TenKho.Length <= 0) IDKho = "";
        string url = "ThongKeTonKho.aspx?";
        if (IDLoaiHangHoa != "")
            url += "IDLoaiHangHoa=" + IDLoaiHangHoa + "&";
        if (NgayDauKy != "")
            url += "NgayDauKy=" + NgayDauKy + "&";
        if (NgayCuoiKy != "")
            url += "NgayCuoiKy=" + NgayCuoiKy + "&";
        if (TuPhieu != "")
            url += "TuPhieu=" + TuPhieu + "&";
        if (DenPhieu != "")
            url += "DenPhieu=" + DenPhieu + "&";
        if (IDKho != "")
            url += "IDKho=" + IDKho + "&";
        
        if (Size != "")
            url += "SizeHH=" + Size + "&";
        if (ChatLieu != "")
            url += "ChatLieuHH=" + ChatLieu + "&";
        if (MauSac != "")
            url += "MauSacHH=" + MauSac + "&";
        if (KieuDang != "")
            url += "KieuDangHH=" + KieuDang + "&";
        //if (TenHangHoa != "")
        //    url += "TenHangHoa=" + TenHangHoa + "&";
        if (LoaiHangCapCao != "")
            url += "LoaiHangCapCao=" + LoaiHangCapCao + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {

    }
    protected void TC_Click(object sender, EventArgs e)
    {
        Response.Redirect("ThongKeTonKho.aspx");
    }
}