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

            case "LoadLoaiHangHoaSuaNhanh":
                LoadLoaiHangHoaSuaNhanh(); break;
            case "LoadLenSizeVaMauTheoIDLoaiHangHoa":
                LoadLenSizeVaMauTheoIDLoaiHangHoa(); break;

            case "CapNhatSoLuongSuaNhanh":
                CapNhatSoLuongSuaNhanh(); break;

            case "CapNhatSoLuongCookieSuaNhanh":
                CapNhatSoLuongCookieSuaNhanh(); break;

            case "ganlai":
                ganlai(); break;

            case "SuaLaiCookieNhanhHangHoa":
                SuaLaiCookieNhanhHangHoa(); break;


            case "LoadLenGiaSuaNhanh":
                LoadLenGiaSuaNhanh(); break;
        }
    }
    private void LoadLenGiaSuaNhanh()
    {
       
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string sql1 = "select * from LoaiHangHoa where IDLoaiHangHoa = " + IDLoaiHangHoa + "";
        DataTable a = Connect.GetTable(sql1);
        if (a.Rows.Count <= 0) Response.Write("0");
        else{
            if (a.Rows[0]["Gia"].ToString().Trim() == "0") Response.Write("0");
            else
                Response.Write(double.Parse(a.Rows[0]["Gia"].ToString().Trim()).ToString("#,##").Replace(",","."));
        }
    }
    private void SuaLaiCookieNhanhHangHoa()
    {
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string GiaBan = StaticData.ValidParameter(Request.QueryString["GiaBan"].Trim()).Replace(",", "").Replace(".", "");
        string MaPhieuNhap = StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", IDPhieuNhap);
        string query = "update LoaiHangHoa set Gia = " + GiaBan + " where IDLoaiHangHoa=" + IDLoaiHangHoa + "  ";
        
        
        bool rs = Connect.Exec(query);

        DataTable bb = Connect.GetTable("select * from LoaiHangHoa where IDLoaiHangHoa=" + IDLoaiHangHoa + " ");
        string[] chuoi = Request.Cookies["SuaNhapNhanh2"].Value.Trim().Split('@');
        for (int i = 0; i < chuoi.Length - 1; i++)
        {
            string[] tacnhorieng = chuoi[i].Split('_');
            if (double.Parse(tacnhorieng[3].Replace(",", "").Replace(".", "")) > 0)
            {
                DataTable XacDinhHangHoa = Connect.GetTable(@"SELECT * FROM [HangHoa] where IDLoaiHangHoa=" + IDLoaiHangHoa + " and IDMauSac=" + tacnhorieng[1] + " and IDSize=" + tacnhorieng[2] + "");

                DataTable checkChiTietPhieuXuat = Connect.GetTable("select * from ChiTietPhieuNhap where IDHangHoa=" + XacDinhHangHoa.Rows[0]["IDHangHoa"].ToString() + " and IDPhieuNhap=" + IDPhieuNhap + "");
                if (checkChiTietPhieuXuat.Rows.Count > 0)
                {
                    string s = "update ChiTietPhieuNhap set DonGiaNhap=" + bb.Rows[0]["Gia"].ToString() + ",SoLuong=" + tacnhorieng[3].Replace(",", "").Replace(".", "") + " where IDChiTietPhieuNhap=" + checkChiTietPhieuXuat.Rows[0]["IDChiTietPhieuNhap"].ToString() + "";
                    bool rs1 = Connect.Exec(s);

                    if (tacnhorieng[3].Replace(",", "").Replace(".", "").Trim() == "0")
                    {
                        string s1 = "delete from ChiTietPhieuNhap where IDChiTietPhieuNhap='" + checkChiTietPhieuXuat.Rows[0]["IDChiTietPhieuNhap"].ToString() + "'";
                        bool rs2 = Connect.Exec(s1);
                    }
                }
                else
                {
                    string s = "insert into ChiTietPhieuNhap(IDHangHoa,IDPhieuNhap,SoLuong,DonGiaNhap,GhiChu) values(" + XacDinhHangHoa.Rows[0]["IDHangHoa"].ToString() + "," + IDPhieuNhap + "," + tacnhorieng[3].Replace(",", "").Replace(".", "") + "," + GiaBan + ",N'')";
                    bool rs1 = Connect.Exec(s);
                }
            }
            else
            {
                DataTable XacDinhHangHoa = Connect.GetTable(@"SELECT * FROM [HangHoa] where IDLoaiHangHoa=" + IDLoaiHangHoa + " and IDMauSac=" + tacnhorieng[1] + " and IDSize=" + tacnhorieng[2] + "");

                DataTable checkChiTietPhieuXuat = Connect.GetTable("select * from ChiTietPhieuNhap where IDHangHoa=" + XacDinhHangHoa.Rows[0]["IDHangHoa"].ToString() + " and IDPhieuNhap=" + IDPhieuNhap + "");
                if (checkChiTietPhieuXuat.Rows.Count > 0)
                {
                  

                    if (tacnhorieng[3].Replace(",", "").Replace(".", "").Trim() == "0")
                    {
                        string s1 = "delete from ChiTietPhieuNhap where IDChiTietPhieuNhap='" + checkChiTietPhieuXuat.Rows[0]["IDChiTietPhieuNhap"].ToString() + "'";
                        bool rs2 = Connect.Exec(s1);
                    }
                }
            }
        }

        string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Sửa nhanh hàng hóa phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
        bool kq2 = Connect.Exec(sql2);
        HttpCookie SuaNhanhHangHoa = new HttpCookie("SuaNhapNhanh2", "");
        SuaNhanhHangHoa.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(SuaNhanhHangHoa);
        Response.Write("True");
      //  Response.Write(Request.Cookies["SuaNhanhHangHoa"].Value.Trim());
    }
    private void ganlai()
    {
        string chuoigan = StaticData.ValidParameter(Request.QueryString["chuoigan"].Trim());
        HttpCookie SuaNhanhHangHoa = new HttpCookie("SuaNhapNhanh2", chuoigan);
        SuaNhanhHangHoa.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(SuaNhanhHangHoa);

      //  Response.Write(chuoigan);
    }
    private void CapNhatSoLuongCookieSuaNhanh()
    {
        //Response.Write(Request.Cookies["SuaNhanhHangHoa"].Value.Trim());
        string[] chuoi = Request.Cookies["SuaNhapNhanh2"].Value.Trim().Split('@');
        string trachuoi = "";
        for (int i = 0; i < chuoi.Length - 1; i++)
        {
            string[] tacnhorieng = chuoi[i].Split('_');
            trachuoi += tacnhorieng[0] + "_" + tacnhorieng[1] + "_" + tacnhorieng[2] + "@";
        }
        Response.Write(trachuoi);
    }
    private void CapNhatSoLuongSuaNhanh()
    {
        string Getsptn = StaticData.ValidParameter(Request.QueryString["Getsptn"].Trim());
        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());

        string[] chuoi = Request.Cookies["SuaNhapNhanh2"].Value.Trim().Split('@');
        
        string trachuoi = "";
        for(int i = 0;i<chuoi.Length-1;i++)
        {
            string [] tacnhorieng = chuoi[i].Split('_');
            trachuoi += tacnhorieng[0] + "_" + tacnhorieng[1] + "_" + tacnhorieng[2]+"@";
            if(chuoi[i].Contains(Getsptn))
            {
                string [] tachchuoi = chuoi[i].Split('_');
                tachchuoi[3] = SoLuong;

                chuoi[i] = tachchuoi[0] + "_" + tachchuoi[1] + "_" + tachchuoi[2] + "_" + tachchuoi[3];
                
            }
        }
        string chuoigan = "";
        for(int i=0;i<chuoi.Length-1;i++)
        {
            chuoigan += chuoi[i];
            chuoigan += "@";
        }

        HttpCookie SuaNhanhHangHoa = new HttpCookie("SuaNhapNhanh2", chuoigan);
        SuaNhanhHangHoa.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(SuaNhanhHangHoa);

        Response.Write(trachuoi);
      
    }
    private void LoadLoaiHangHoaSuaNhanh()
    {
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string sql = "";

        sql += @"select distinct LoaiHangHoa.TenLoaiHangHoa,LoaiHangHoa.MaLoaiHangHoa,LoaiHangHoa.IDLoaiHangHoa from ChiTietPhieuNhap,HangHoa,LoaiHangHoa
where ChiTietPhieuNhap.IDHangHoa=HangHoa.IDHangHoa and HangHoa.IDLoaiHangHoa = LoaiHangHoa.IDLoaiHangHoa and ChiTietPhieuNhap.IDPhieuNhap=" + IDPhieuNhap + "";
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
            listgAutocomplete += "value: '" + table.Rows[i]["TenLoaiHangHoa"].ToString() +"-"+table.Rows[i]["MaLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "'";
           // listgAutocomplete += "label: '" + table.Rows[i]["MaLoaiHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }


    private void LoadLenSizeVaMauTheoIDLoaiHangHoa()
    {
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string chuoigan = "";
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        DataTable timsize = Connect.GetTable("select distinct Size.MaSize,Size.IDSize from Size,HangHoa where HangHoa.IDSize = Size.IDSize and HangHoa.IDLoaiHangHoa = " + IDLoaiHangHoa + "");
        DataTable timmau = Connect.GetTable("select distinct MauSac.MaMauSac,MauSac.IDMauSac from MauSac,HangHoa where HangHoa.IDMauSac = MauSac.IDMauSac and HangHoa.IDLoaiHangHoa = " + IDLoaiHangHoa + "");
        string html = @"<center><table border='1' style='width:50%;'>
<tr>
<td>&nbsp;</td>
<td><table border='1' style='width:100%;'><tr>";
        for (int i = 0; i < timsize.Rows.Count; i++)
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
                {
                    //string s = "select * from ChiTietPhieuXuat where IDPhieuXuat=" + IDPhieuXuat + " and IDHangHoa=" + check.Rows[0]["IDHangHoa"].ToString() + " ";

                    DataTable getSoLuong = Connect.GetTable("select * from ChiTietPhieuNhap where IDPhieuNhap=" + IDPhieuNhap + " and IDHangHoa = " + check.Rows[0]["IDHangHoa"].ToString().Trim() + "");
                    string s = "";
                    if(getSoLuong.Rows.Count > 0)
                     s = getSoLuong.Rows[0]["SoLuong"].ToString().Trim();


                    html += "<input style='width:40px;' oninput='CapNhatSoLuongSuaNhanh(\"" + "spsnn_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "\");' onkeyup='CapNhatSoLuongSuaNhanh(\"" + "spsnn_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "\");'  value='" + s + "'   type='text' id='spsnn_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "' />";
                    if(s.Trim().Length > 0)
                    chuoigan += "spsnn_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "_"+s+"";
                    else
                        chuoigan += "spsnn_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "_0";


                    chuoigan += "@";
                }
                else
                {
                    html += "<input style='width:40px;' value='' disabled='disabled'  type='text' id='spsnn_" + timmau.Rows[i]["IDMauSac"].ToString().Trim() + "_" + timsize.Rows[j]["IDSize"].ToString().Trim() + "' />";
                }
                html += "</td>";
            }
            html += "</tr>";
        }

        HttpCookie ThemNhanh = new HttpCookie("SuaNhapNhanh2", chuoigan);
        ThemNhanh.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(ThemNhanh);
        double tong = 0;
        string[] tinh = chuoigan.Split('@');
        for (int i = 0; i < tinh.Length - 1; i++)
        {
            string[] tachnua = tinh[i].Split('_');
            tong += double.Parse(tachnua[3]);
        }

        html += @"</table></td>
</tr>
<tr>
<td colspan='2' style='text-align:right;'><label>Tổng số lượng</label></td>";
        html += @"
<td><label id='tongslsnthoi'>" + tong.ToString("#,##").Replace(",", ".") + @"</label></td>

</tr>
</table></center><br/>";



        Response.Write(html);
    }
}