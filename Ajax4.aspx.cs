using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using System.Text;

using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
//using Spire.Doc;
//using Spire.Doc.Documents;


public partial class Ajax : System.Web.UI.Page
{
    string sTenDangNhap = "";
    string mQuyen = "";
    public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string action = Request.QueryString["Action"].Trim();
        switch (action)
        {
           


                case "LayGiaGoc":
                    LayGiaGoc(); break;

                case "LoadMaLoaiHangHoa":
                    LoadMaLoaiHangHoa(); break;

                case "LoadLenSizeVaMauTheoIDLoaiHangHoa":
                    LoadLenSizeVaMauTheoIDLoaiHangHoa(); break;

                case "CapNhatSoLuongThemNhanh":
                    CapNhatSoLuongThemNhanh(); break;

                case "ThemTheoLoaiHangCapCaoPhieuXuat":
                    ThemTheoLoaiHangCapCaoPhieuXuat(); break;

                case "LoadLaiSoLuongLanNua":
                    LoadLaiSoLuongLanNua(); break;

                case "CheatLanHai":
                    CheatLanHai(); break;
        }
    }
    private void CheatLanHai()
    {
        string chuoi = StaticData.ValidParameter(Request.QueryString["chuoi"].Trim());
        HttpCookie ThemNhanh = new HttpCookie("ThemNhanh2", chuoi);
        ThemNhanh.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(ThemNhanh);

        Response.Write(Request.Cookies["ThemNhanh2"].Value.Trim());

    }


    private void LoadLaiSoLuongLanNua()
    {
        string chuoie = Request.Cookies["ThemNhanh2"].Value.Trim();
        string[] tachchuoi = chuoie.Split('@');
        string chuoi = "";
        for (int i = 0; i < tachchuoi.Length - 1; i++)
        {
           
                string[] tachthem = tachchuoi[i].Split('_');
               
                tachchuoi[i] = tachthem[0] + "_" + tachthem[1] + "_" + tachthem[2];
            
        }
        
        for (int i = 0; i < tachchuoi.Length - 1; i++)
        {
            chuoi += tachchuoi[i];
            chuoi += "@";
        }
        Response.Write(chuoi);
    }
    private void ThemTheoLoaiHangCapCaoPhieuXuat()
    {
        string IDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string MaPhieuNhap = StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", IDPhieuNhap);
        string GiaNhap = StaticData.ValidParameter(Request.QueryString["GiaNhap"].Trim());
        string sql1 = "update LoaiHangHoa set Gia=" + GiaNhap.Replace(",","").Replace(".","") + " where IDLoaiHangHoa = "+IDLoaiHangCapCao+"";
        bool p = Connect.Exec(sql1);
        string[] chuoie = Request.Cookies["ThemNhanh2"].Value.Trim().Split('@');
       // Response.Write(Request.Cookies["ThemNhanh2"].Value.Trim());
        for (int i = 0; i < chuoie.Length - 1; i++)
        {
            string[] tachthem = chuoie[i].Split('_');
            DataTable layhang = Connect.GetTable(@"
SELECT [IDHangHoa]
      ,[MaHangHoa]
      ,[TenHangHoa]
      ,[IDSize]
      ,[IDMauSac]
      ,[GhiChu]
      ,[IDLoaiHangHoa]
  FROM [HangHoa] where IDLoaiHangHoa=" + IDLoaiHangCapCao + " and IDMauSac=" + tachthem[1] + " and IDSize=" + tachthem[2] + "");
            if (tachthem[3].Trim() == "0")
            {

            }
            else
            {
                DataTable kiemtra = Connect.GetTable("select * from ChiTietPhieuNhap where IDHangHoa = " + layhang.Rows[0]["IDHangHoa"].ToString() + " and IDPhieuNhap=" + IDPhieuNhap + "");
                if (kiemtra.Rows.Count > 0)
                {
                   // string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm nhanh hàng hóa phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
                  //  bool kq2 = Connect.Exec(sql2);
                    string sql = "update ChiTietPhieuNhap set SoLuong=SoLuong+" + tachthem[3] + " where IDChiTietPhieuNhap=" + kiemtra.Rows[0]["IDChiTietPhieuNhap"].ToString() + "";
                    bool r = Connect.Exec(sql);
                }
                else
                {
                   
                    string sql = "insert into ChiTietPhieuNhap values(" + layhang.Rows[0]["IDHangHoa"].ToString() + "," + IDPhieuNhap + "," + tachthem[3] + "," + GiaNhap + ",N'',null)";
                    bool r = Connect.Exec(sql);
                }
            }
        }
        HttpCookie ThemNhanh = new HttpCookie("ThemNhanh2", "");
        ThemNhanh.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(ThemNhanh);
        string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm nhanh hàng hóa phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
        bool kq2 = Connect.Exec(sql2);
        Response.Write("True");
    }
    private void CapNhatSoLuongThemNhanh()
    {
        string idsp = StaticData.ValidParameter(Request.QueryString["idsp"].Trim());

        string soluong = StaticData.ValidParameter(Request.QueryString["soluong"].Trim());
        string chuoie = Request.Cookies["ThemNhanh2"].Value.Trim();
        string[] tachchuoi = chuoie.Split('@');
        for (int i = 0; i < tachchuoi.Length - 1; i++)
        {
            if (tachchuoi[i].Contains(idsp))
            {
                string[] tachthem = tachchuoi[i].Split('_');
                tachthem[3] = soluong;
                tachchuoi[i] = tachthem[0] + "_" + tachthem[1] + "_" + tachthem[2] + "_" + tachthem[3];
            }
        }
        string chuoi = "";
        for (int i = 0; i < tachchuoi.Length - 1; i++)
        {
            chuoi += tachchuoi[i];
            chuoi += "@";
        }

        HttpCookie ThemNhanh = new HttpCookie("ThemNhanh2", chuoi);
        ThemNhanh.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(ThemNhanh);


      
        double tong = 0;
        string[] tinh = chuoi.Split('@');
        for (int i = 0; i < tinh.Length - 1; i++)
        {
            string[] tachnua = tinh[i].Split('_');
            tong += double.Parse(tachnua[3]);
        }
        if (tong == 0) Response.Write("0");
        else Response.Write(tong.ToString("#,##").Replace(",", "."));
    }
    private void LoadLenSizeVaMauTheoIDLoaiHangHoa()
    {

        string chuoigan = "";
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        DataTable timsize = Connect.GetTable("select distinct Size.MaSize,Size.IDSize from Size,HangHoa where HangHoa.IDSize = Size.IDSize and HangHoa.IDLoaiHangHoa = " + IDLoaiHangHoa + "");
        DataTable timmau = Connect.GetTable("select distinct MauSac.MaMauSac,MauSac.IDMauSac from MauSac,HangHoa where HangHoa.IDMauSac = MauSac.IDMauSac and HangHoa.IDLoaiHangHoa = " + IDLoaiHangHoa + "");
        string html = @"<center>

<table border='1' style='width:50%;'>
<tr>
<td>&nbsp;</td>
<td><table border='1' style='width:100%;'><tr>";
     for(int i = 0;i<timsize.Rows.Count;i++)
     {
         html += "<td>";
         html += timsize.Rows[i]["MaSize"].ToString();
         html += "</td>";
     }
     html += @"</tr></table></td><td rowspan='2'>&nbsp;</td>
</tr>

<tr>
<td><table border='1' style='width:100%;height:100%;'>";
     for (int i = 0; i < timmau.Rows.Count; i++)
     {
         html += "<tr><td>";
         html += "<input type='text' value='" + timmau.Rows[i]["MaMauSac"].ToString() + "' readonly='true'    />";
         html += "</td></tr>";
     }
     html += @"</table></td>
<td><table border='1' style='width:100%;height:100%;'>";
     for (int i = 0; i < timmau.Rows.Count; i++)
     {
         html += "<tr>";
         for (int j = 0; j < timsize.Rows.Count; j++)
         {
             html += "<td>";
             DataTable check = Connect.GetTable(@"
SELECT [IDHangHoa]
      ,[MaHangHoa]
      ,[TenHangHoa]
      ,[IDSize]
      ,[IDMauSac]
      ,[GhiChu]
      ,[IDLoaiHangHoa]
  FROM [HangHoa] where IDLoaiHangHoa=" + IDLoaiHangHoa + " and IDMauSac=" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + " and IDSize=" + timsize.Rows[j]["IDSize"].ToString().Trim() + "");
             if (check.Rows.Count > 0)
             {//onkeyup='CapNhatSoLuongThemNhanh(\"" + "sp_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "\");' onkeydown='CapNhatSoLuongThemNhanh(\"" + "sp_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "\");' onkeypress='CapNhatSoLuongThemNhanh(\"" + "sp_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "\");'
                 html += "<input style='width:40px;'  oninput='CapNhatSoLuongThemNhanh(\"" + "sp_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "\");'  value=''   type='text' id='sp_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "' />";
                 chuoigan +="sp_"+ timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim()+"_0";

                 chuoigan += "@";
             }
             else
             {
                 html += "<input style='width:40px;' value='' disabled='disabled'  type='text' id='sp_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "' />";
             }
                 html += "</td>";
         }
         html += "</tr>";
     }

     HttpCookie ThemNhanh = new HttpCookie("ThemNhanh2", chuoigan);
     ThemNhanh.Expires = DateTime.Now.AddDays(30);
     Response.Cookies.Add(ThemNhanh);
     double tong = 0;
     string[] tinh = chuoigan.Split('@');
     for (int i = 0;i< tinh.Length - 1;i++ )
     {
         string [] tachnua = tinh[i].Split('_');
         tong += double.Parse(tachnua[3]);
     }

     html += @"</table></td>
</tr>
<tr>
<td colspan='2' style='text-align:right;'><label>Tổng số lượng</label></td>

<td><label id='tongsl'>" + tong.ToString("#,##").Replace(",",".") + @"</label></td>

</tr>
</table></center><br/>";

  

     Response.Write(html);
    }
    private void LoadMaLoaiHangHoa()
    {

        string sql = "";

        sql += "select MaLoaiHangHoa from LoaiHangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["MaLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["MaLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["MaLoaiHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void LayGiaGoc()
    {


        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        DataTable Gia = Connect.GetTable("SELECT [Gia] FROM [ChiTietGiaTheoKhach] where IDHangHoa = " + IDHangHoa + " and IDKhachHang=" + IDKhachHang + "");

        if (Gia.Rows.Count > 0)
        {
            if (double.Parse(Gia.Rows[0]["Gia"].ToString()) == 0) Response.Write("0");
            else
                Response.Write(double.Parse(Gia.Rows[0]["Gia"].ToString()).ToString("#,##").Replace(",", "."));
        }
        else
        {
            Response.Write("0");
        }
    }
    
}