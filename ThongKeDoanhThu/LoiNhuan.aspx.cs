using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyDoiTra_DoiTra : System.Web.UI.Page
{
    string pKhachHang = "";
    string pTenHangHoa = "";
    string pTuNgayNhap = "";
    string pDenNgayNhap = "";
    string pMaLoaiHangHoa = "";
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
            LoadKhachHang();

            //try
            //{
            //    if (Request.QueryString["TenHangHoa"].Trim() != "")
            //    {
            //        pTenHangHoa = Request.QueryString["TenHangHoa"].Trim().ToString().Replace("\\", "");
            //        txtTenHangHoa.Value = pTenHangHoa;
            //    }
            //}
            //catch { }

            try
            {
                if (Request.QueryString["MaLoaiHangHoa"].Trim() != "")
                {
                    pMaLoaiHangHoa = Request.QueryString["MaLoaiHangHoa"].Trim().ToString().Replace("\\", "");
                    txtMaHangHoa.Value = pMaLoaiHangHoa;
                }
            }
            catch { }

            try
            {
                if (Request.QueryString["KhachHang"].Trim() != "")
                {
                    pKhachHang = StaticData.ValidParameter(Request.QueryString["KhachHang"].Trim());

                    txtKhachHang.Value = StaticData.getField("KhachHang", "TenKhachHang", "idKhachHang", pKhachHang);
                 hdKhachHang.Value = pKhachHang;
                }
            }
            catch { }




            try
            {
                if (Request.QueryString["TuNgayNhap"].Trim() != "")
                {
                    pTuNgayNhap = StaticData.ValidParameter(Request.QueryString["TuNgayNhap"].Trim());
                    txtTuNgayNhap.Value = pTuNgayNhap;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["DenNgayNhap"].Trim() != "")
                {
                    pDenNgayNhap = StaticData.ValidParameter(Request.QueryString["DenNgayNhap"].Trim());
                    txtDenNgayNhap.Value = pDenNgayNhap;
                }
            }
            catch { }



            LoadDuAn();
        }
    }


     private void LoadKhachHang()
     {
         string strSql = "select * from KhachHang";
         slKhachHang.DataSource = Connect.GetTable(strSql);
         slKhachHang.DataTextField = "TenKhachHang";
         slKhachHang.DataValueField = "IDKhachHang";
         slKhachHang.DataBind();
         slKhachHang.Items.Add(new ListItem("-- Tất cả --", "0"));
         slKhachHang.Items.FindByText("-- Tất cả --").Selected = true;
     }


    #region paging
    private void SetPage()
    {
        string sql = "";

        sql += @"select * from (select ROW_NUMBER() OVER(ORDER BY tb2.TongLN desc) AS RowNumber,*
from(
select tb1.TenLoaiHangHoa,tb1.MaLoaiHangHoa,tb1.IDLoaiHangHoa, tb1.Ton ,tb1.TongLN
from 
(
select LoaiHangHoa.TenLoaiHangHoa,LoaiHangHoa.MaLoaiHangHoa,LoaiHangHoa.IDLoaiHangHoa,LoaiHangHoa.Gia, 

( select isnull(sum(TongXuat),0) from(select (select isnull(sum(ctpx.SoLuong),0) 
from ChiTietPhieuXuat ctpx where ctpx.IDHangHoa=hh.IDHangHoa and ctpx.IDPhieuXuat in 
(select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1' ";
        if (pTuNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        if (pDenNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + "' ";
        if (pKhachHang != "")
            sql += " and PhieuXuat.IDKhachHang = '" + pKhachHang + "' ";
        sql += @" ) ) as 'TongXuat' 

from HangHoa hh where hh.IDLoaiHangHoa = LoaiHangHoa.IDLoaiHangHoa) as tbTongXuat ) as 'Ton' ,
(
select isnull(sum(LN.SoLuong*(LN.DonGiaXuat-LN.GiaNhapGanNhat)),0) as 'TongLoiNhuan' from(
select 
 isnull(
(select top 1 ChiTietPhieuNhap.DonGiaNhap from  ChiTietPhieuNhap where ChiTietPhieuNhap.IDHangHoa = ChiTietPhieuXuat.IDHangHoa


  and ChiTietPhieuNhap.IDPhieuNhap in (select pn.IDPhieuNhap from PhieuNhap pn where '1'='1' ";

        //if (pTuNgayNhap != "")
        //    sql += " and pn.NgayNhap >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        //if (pDenNgayNhap != "")
        //    sql += "  and pn.NgayNhap  <= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
  
sql+= @"  )


order by IDChiTietPhieuNhap desc ) ,0 ) as 'GiaNhapGanNhat',
ChiTietPhieuXuat.DonGiaXuat,
CASE 
  WHEN ChiTietPhieuXuat.DonGiaXuat = 0 THEN 0
  WHEN isnull((select top 1 ChiTietPhieuNhap.DonGiaNhap from ChiTietPhieuNhap where ChiTietPhieuNhap.IDHangHoa = ChiTietPhieuXuat.IDHangHoa
 and ChiTietPhieuNhap.IDPhieuNhap in (select pn1.IDPhieuNhap from PhieuNhap pn1 where '1'='1' 
";
//if (pTuNgayNhap != "")
//    sql += " and pn1.NgayNhap >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
//if (pDenNgayNhap != "")
//    sql += "  and pn1.NgayNhap  <= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";


sql+=@" ) order by IDChiTietPhieuNhap desc ) ,0)= 0 THEN 0  

  ELSE ChiTietPhieuXuat.SoLuong 
END as 'SoLuong'

from ChiTietPhieuXuat where '1'='1'
        

            AND ChiTietPhieuXuat.IDHangHoa IN ( SELECT HangHoa.IDHangHoa FROM HangHoa WHERE HangHoa.IDLoaiHangHoa = LoaiHangHoa.IDLoaiHangHoa )

			 and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1' ";

        if (pTuNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        if (pDenNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + "' ";
        if (pKhachHang != "")
            sql += " and PhieuXuat.IDKhachHang = '" + pKhachHang + "' ";
        sql += @" ) ) as LN

) as 'TongLN'


from LoaiHangHoa where '1'='1' and LoaiHangHoa.IDLoaiHangHoa in (select distinct c.IDLoaiHangHoa from ChiTietPhieuXuat a,PhieuXuat px,HangHoa b,LoaiHangHoa c where a.IDPhieuXuat=px.IDPhieuXuat and a.IDHangHoa = b.IDHangHoa and b.IDLoaiHangHoa=c.IDLoaiHangHoa
";
        if (pTuNgayNhap != "")
            sql += " and px.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        if (pDenNgayNhap != "")
            sql += " and px.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + "' ";
        if (pKhachHang != "")
            sql += " and px.IDKhachHang = '" + pKhachHang + "' ";
        sql += @" ) ";
        if (pMaLoaiHangHoa != "")
        {
            sql += " and LoaiHangHoa.MaLoaiHangHoa like N'%" + pMaLoaiHangHoa + "%' ";
        }
        sql += " ) as tb1 ) as tb2 ) as tb3 ";

        

       // DataTable tbTotalRows = Connect.GetTable("select count(*) from ("+sql+") as tb");
        DataTable tbTotalRows = Connect.GetTable(sql);
        //  Response.Write("<script>alert('"+tbTotalRows.Rows[0][0].ToString()+"')</script>");
        //int TotalRows = int.Parse(tbTotalRows.Rows[0][0].ToString());
        int TotalRows = int.Parse(tbTotalRows.Rows.Count.ToString());
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
        sql += @"select * from (select ROW_NUMBER() OVER(ORDER BY tb2.TongLN desc) AS RowNumber,*
from(
select tb1.TenLoaiHangHoa,tb1.MaLoaiHangHoa,tb1.IDLoaiHangHoa, tb1.Ton ,tb1.TongLN
from 
(
select LoaiHangHoa.TenLoaiHangHoa,LoaiHangHoa.MaLoaiHangHoa,LoaiHangHoa.IDLoaiHangHoa,LoaiHangHoa.Gia, 

( select isnull(sum(TongXuat),0) from(select (select isnull(sum(ctpx.SoLuong),0) 
from ChiTietPhieuXuat ctpx where ctpx.IDHangHoa=hh.IDHangHoa and ctpx.IDPhieuXuat in 
(select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1' and PhieuXuat.MaPhieuXuat not like '%XB%' ";
        if (pTuNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        if (pDenNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + "' ";
        if (pKhachHang != "")
            sql += " and PhieuXuat.IDKhachHang = '" + pKhachHang + "' ";
        sql += @" ) ) as 'TongXuat' 

from HangHoa hh where hh.IDLoaiHangHoa = LoaiHangHoa.IDLoaiHangHoa) as tbTongXuat ) as 'Ton' ,
(
select isnull(sum(LN.SoLuong*(LN.DonGiaXuat-LN.GiaNhapGanNhat)),0) as 'TongLoiNhuan' from(
select 
 isnull(
(select top 1 ChiTietPhieuNhap.DonGiaNhap from  ChiTietPhieuNhap where ChiTietPhieuNhap.IDHangHoa = ChiTietPhieuXuat.IDHangHoa

  and ChiTietPhieuNhap.IDPhieuNhap in (select pn.IDPhieuNhap from PhieuNhap pn where '1'='1' and pn.MaPhieuNhap not like '%XB%' ";
        //if (pTuNgayNhap != "")
        //    sql += " and pn.NgayNhap >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        //if (pDenNgayNhap != "")
        //    sql += "  and pn.NgayNhap  <= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
  
sql+= @"  )
order by IDChiTietPhieuNhap desc ) ,0 ) as 'GiaNhapGanNhat',
ChiTietPhieuXuat.DonGiaXuat,
CASE 
  WHEN ChiTietPhieuXuat.DonGiaXuat = 0 THEN 0
  WHEN isnull((select top 1 ChiTietPhieuNhap.DonGiaNhap from ChiTietPhieuNhap where ChiTietPhieuNhap.IDHangHoa = ChiTietPhieuXuat.IDHangHoa
 and ChiTietPhieuNhap.IDPhieuNhap in (select pn1.IDPhieuNhap from PhieuNhap pn1 where '1'='1' and pn1.MaPhieuNhap not like '%XB%' ";

//if (pTuNgayNhap != "")
//    sql += " and pn1.NgayNhap >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
//if (pDenNgayNhap != "")
//    sql += "  and pn1.NgayNhap  <= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";

sql+=@" ) order by IDChiTietPhieuNhap desc ) ,0 ) = 0 THEN 0  

  ELSE ChiTietPhieuXuat.SoLuong 
END as 'SoLuong'

from ChiTietPhieuXuat where '1'='1'
        

            AND ChiTietPhieuXuat.IDHangHoa IN ( SELECT HangHoa.IDHangHoa FROM HangHoa WHERE HangHoa.IDLoaiHangHoa = LoaiHangHoa.IDLoaiHangHoa )

			 and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1' and PhieuXuat.MaPhieuXuat not like '%XB%' ";

        if (pTuNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        if (pDenNgayNhap != "")
            sql += " and PhieuXuat.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + "' ";
        if (pKhachHang != "")
            sql += " and PhieuXuat.IDKhachHang = '" + pKhachHang + "' ";
        sql += @" ) ) as LN

) as 'TongLN'


from LoaiHangHoa where '1'='1' and LoaiHangHoa.IDLoaiHangHoa in (select distinct c.IDLoaiHangHoa from ChiTietPhieuXuat a,PhieuXuat px,HangHoa b,LoaiHangHoa c where a.IDPhieuXuat=px.IDPhieuXuat and a.IDHangHoa = b.IDHangHoa and b.IDLoaiHangHoa=c.IDLoaiHangHoa
";
        if (pTuNgayNhap != "")
            sql += " and px.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + "' ";
        if (pDenNgayNhap != "")
            sql += " and px.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + "' ";
        if (pKhachHang != "")
            sql += " and px.IDKhachHang = '" + pKhachHang + "' ";
        sql += @" ) ";
        if (pMaLoaiHangHoa != "")
        {
            sql += " and LoaiHangHoa.MaLoaiHangHoa like N'%" + pMaLoaiHangHoa + "%' ";
        }
sql+=" ) as tb1 ) as tb2 ) as tb3 ";

        //DataTable table2 = Connect.GetTable(sql);
        //double TongLoiNhuan = 0;
        //for (int i = 0; i < table2.Rows.Count; i++)
        //{
        //    DataTable LayGiaNhapGanNhat = Connect.GetTable("select ChiTietPhieuNhap.DonGiaNhap from  ChiTietPhieuNhap where IDHangHoa = " + table2.Rows[i]["IDHangHoa"].ToString() + " order by IDChiTietPhieuNhap desc");

        //    string GiaGoc = "0";
        //    if (LayGiaNhapGanNhat.Rows.Count > 0)
        //        GiaGoc = LayGiaNhapGanNhat.Rows[0][0].ToString();
           


        //    double LoiNhuan = (double.Parse(table2.Rows[i]["DonGiaXuat"].ToString()) - double.Parse(GiaGoc)) * double.Parse(table2.Rows[i]["SoLuong"].ToString());

        //    if (GiaGoc == "0" || double.Parse(table2.Rows[i]["DonGiaXuat"].ToString()) == 0)
        //    {
        //        TongLoiNhuan += 0;
        //    }
        //    else
        //    {
        //        TongLoiNhuan += LoiNhuan;
        //    }


        //}
        string sql3 = "select isnull(sum(tb4.TongLN),0) from (" + sql + ") as tb4";
        double TLN = 0;
        DataTable table2 = Connect.GetTable(sql3);
        //for (int i2 = 0; i2 < table2.Rows.Count; i2++)
        //{
        //    TLN += MyStaticData.LoadChiTietLoiNhuan(table2.Rows[i2]["IDLoaiHangHoa"].ToString(), txtTuNgayNhap.Value.Trim(), txtDenNgayNhap.Value.Trim());

        //}
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize + " + 1 AND (((" + Page + " - 1) * " + PageSize + " + 1) + " + PageSize + ") - 1";

        DataTable table = Connect.GetTable(sql);

       // Label1.Text = sql;


        string sql2 = @"SELECT ISNULL( SUM (LoiNhuan), 0) FROM (

SELECT * FROM (

SELECT ROW_NUMBER() OVER(ORDER BY idLoaiHangHoa desc) AS RowNumber, idLoaiHangHoa, SUM(SoLuong) AS SoLuong, SUM(LoiNhuan) AS LoiNhuan FROM (
SELECT * FROM (

SELECT * , (CASE WHEN DonGiaXuat = 0 THEN 0 WHEN GiaGoc = 0 Then 0 ELSE (DonGiaXuat - GiaGoc) * SoLuong END) AS LoiNhuan  FROM (
SELECT * FROM (

	SELECT 
	
	 *

	 , GiaGoc = ISNULL( ( select TOP 1 ChiTietPhieuNhap.DonGiaNhap from  ChiTietPhieuNhap where IDPhieuNhap not in (select IDPhieuNhap from PhieuNhap where MaPhieuNhap like '%-XB') and IDHangHoa =  tb1.idHangHoa order by IDChiTietPhieuNhap desc), 0)
	 from (

	SELECT 
	  ctpx.*, lhh.TenLoaiHangHoa, lhh.idLoaiHangHoa from ChiTietPhieuXuat ctpx, 
				HangHoa hh,
				LoaiHangHoa lhh
  
	 where IDPhieuXuat not in (select IDPhieuXuat from PhieuXuat where MaPhieuXuat like '%-XB') and '1'='1' 
 
	 AND ctpx.IDHangHoa = hh.idHangHoa
	 AND hh.IDLoaiHangHoa = lhh.IDLoaiHangHoa ";


          if (pMaLoaiHangHoa != "")

                  sql2 += " AND lhh.MaLoaiHangHoa = '" + pMaLoaiHangHoa + "'";

 	sql2 += @" )
 
	  as tb1  WHERE  '1' = '1' ";

    if (pTuNgayNhap != "")
        sql2 += "  AND tb1.IDPhieuXuat IN ( SELECT PhieuXuat.idPhieuXuat FROM PhieuXuat WHERE IDPhieuXuat not in (select IDPhieuXuat from PhieuXuat where MaPhieuXuat like '%-XB') and NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + " 00:00:00' ) ";
    if (pDenNgayNhap != "")
        sql2 += " AND  tb1.IDPhieuXuat IN ( SELECT PhieuXuat.idPhieuXuat FROM PhieuXuat WHERE IDPhieuXuat not in (select IDPhieuXuat from PhieuXuat where MaPhieuXuat like '%-XB') and NgayXuat <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + " 00:00:00' ) ";


    if (pKhachHang != "" && pKhachHang != "0")
        sql2 += " AND tb1.IDPhieuXuat IN ( SELECT PhieuXuat.idPhieuXuat FROM PhieuXuat   WHERE IDPhieuXuat not in (select IDPhieuXuat from PhieuXuat where MaPhieuXuat like '%-XB') and IDKhachHang  = '" + pKhachHang + "' ) ";


    sql2 += @"	 

	

	  ) AS T4

	  ) AS T5

	  ) AS T6

	  ) AS T7

	
	
	     GROUP By idLoaiHangHoa

		) AS T8

		) AS T9 ";


      //  DataTable table2 = Connect.GetTable(sql2);

            SetPage();

            string html = @" <table class='table table-bordered table-striped'>
                            <tr>
                                <th class='th'>
                                  STT
                                </th>
                                <th class='th'>
                                Hàng hóa
                       
                                <th class='th'>
                                Số lượng
                                </th>

                                <th class='th'>
                                Tổng lợi nhuận
                                </th>

                            </tr>";
            // double SoTienPhaiThu = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "       <tr>";
                html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";

                html += "       <td> <a style='cursor:pointer;' onclick='LoadChiTietLoiNhuan(\"" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "\");'> " + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", table.Rows[i]["IDLoaiHangHoa"].ToString()) + " - " + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", table.Rows[i]["IDLoaiHangHoa"].ToString()) + " </a> </td>";

                // html += "       <td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
                //html += "       <td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
                //  html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";

                if (table.Rows[i]["Ton"].ToString() == "0") html += "<td>0</td>";
                else html += "<td>" + double.Parse(table.Rows[i]["Ton"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";


              // double LoiNhuan = MyStaticData.LoadChiTietLoiNhuan(table.Rows[i]["IDLoaiHangHoa"].ToString(),txtTuNgayNhap.Value.Trim(),txtDenNgayNhap.Value.Trim());
                double LoiNhuan = double.Parse(table.Rows[i]["TongLN"].ToString());
                if (LoiNhuan == 0) html += "<td>0</td>";
                else html += "<td>" + LoiNhuan.ToString("#,##").Replace(",", ".") + "</td>";


                //DataTable LayGiaNhapGanNhat = Connect.GetTable("select ChiTietPhieuNhap.DonGiaNhap from  ChiTietPhieuNhap where IDHangHoa = " + table.Rows[i]["IDHangHoa"].ToString() + " order by IDChiTietPhieuNhap desc");



                //string GiaGoc = "0";
                //if (LayGiaNhapGanNhat.Rows.Count > 0)
                //    GiaGoc = LayGiaNhapGanNhat.Rows[0][0].ToString();
                ////string GiaGoc = LayGiaNhapGanNhat.Rows[0][0].ToString();

                //if (GiaGoc == "0") html += "<td>0</td>";
                //else html += "       <td>" + double.Parse(GiaGoc).ToString("#,##").Replace(",", ".") + "</td>";



                //if (table.Rows[i]["DonGiaXuat"].ToString() == "0") html += "<td>0</td>";
                //else html += "       <td>" + double.Parse(table.Rows[i]["DonGiaXuat"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

                //if (GiaGoc == "0" || table.Rows[i]["DonGiaXuat"].ToString() == "0")
                //{
                //    html += "<td>0</td>";
                //}

                //else
                //{
                //    double LoiNhuan = (double.Parse(table.Rows[i]["DonGiaXuat"].ToString()) - double.Parse(GiaGoc)) * double.Parse(table.Rows[i]["SoLuong"].ToString());

                //    if (LoiNhuan == 0) html += "<td>0</td>";
                //    else html += "       <td>" + LoiNhuan.ToString("#,##").Replace(",", ".") + "</td>";


                //}

                html += "       </tr>";

            }
            html += "   <tr>";
            html += "       <td colspan='9' class='footertable'>";
            string url = "LoiNhuan.aspx?";
            if (pMaLoaiHangHoa != "")
                url += "MaLoaiHangHoa=" + pMaLoaiHangHoa + "&";
            if (pKhachHang != "" && pKhachHang != "0")
                url += "KhachHang=" + pKhachHang + "&";
            if (pTuNgayNhap != "")
                url += "TuNgayNhap=" + pTuNgayNhap + "&";
            if (pDenNgayNhap != "")
                url += "DenNgayNhap=" + pDenNgayNhap + "&";


          
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
            html += "<tr style='background-color:yellow;font-weight: bold;'>";
            html += "<td colspan='3' style='text-align:right;'><b>Tổng cộng</b></td>";




            html += "<td>" + double.Parse(table2.Rows[0][0].ToString()).ToString("#,##").Replace(",",".") + "</td>";
            html += "</tr>";
            html += "     </table>";

            dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        string KhachHang = hdKhachHang.Value.Trim(); //slKhachHang.Value.Trim();

        if(txtKhachHang.Value.Trim().Length <= 0)
        {
            KhachHang = "";
        }

        string TuNgayNhap = txtTuNgayNhap.Value.Trim();
        string DenNgayNhap = txtDenNgayNhap.Value.Trim();
       // string TenHangHoa = txtMaHangHoa.Value.Trim();
        string MaLoaiHangHoa = txtMaHangHoa.Value.Trim();

        if (txtMaHangHoa.Value.Trim().Length <= 0)
        {
            MaLoaiHangHoa = "";
        }


        string url = "LoiNhuan.aspx?";
        //if (MaPhieuNhap != "")
        //    url += "MaPhieuNhap=" + MaPhieuNhap + "&";

        if (TuNgayNhap != "")
            url += "TuNgayNhap=" + TuNgayNhap + "&";
        if (DenNgayNhap != "")
            url += "DenNgayNhap=" + DenNgayNhap + "&";
        //if (TenHangHoa != "")
        //    url += "TenHangHoa=" + TenHangHoa + "&";

        if (KhachHang != "" && KhachHang != "0")
            url += "KhachHang=" + KhachHang + "&";

        if (MaLoaiHangHoa != "")
            url += "MaLoaiHangHoa=" + MaLoaiHangHoa + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        string url = "LoiNhuan.aspx?TuNgayNhap=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayNhap=" + DateTime.Now.ToString("dd/MM/yyyy") + "";
        Response.Redirect(url);
    }
}