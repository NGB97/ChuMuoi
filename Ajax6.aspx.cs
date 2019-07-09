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


            case "CapNhatGiaoChoKhach":
                CapNhatGiaoChoKhach(); break;


            case "listsanpham":
                    listsanpham(); break;
        }
    }
 
    private void listsanpham()
    {
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string chuoi = "";
      
        DataTable table = Connect.GetTable("select IDLoaiHangHoa,TenLoaiHangHoa,MaLoaiHangHoa from LoaiHangHoa");

        string html = @"<table border='1' style='width:100%;' class='table table-bordered table-striped'><tr>
        <th>STT</th><th>Tên hàng</th><th>Giá</th>
        </tr>
        ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>"+(i+1).ToString()+"</td>";

            html += "<td>" + table.Rows[i]["TenLoaiHangHoa"].ToString() + "-" + table.Rows[i]["MaLoaiHangHoa"].ToString() + "</td>";
            DataTable check = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang = " + IDKhachHang + " and IDHangHoa = " + table.Rows[i]["IDLoaiHangHoa"].ToString() + "");
             if (check.Rows.Count > 0)
             {
                 if (check.Rows[0]["Gia"].ToString().Trim() == "0")
                     html += "<td><input disabled='disabled' type='text' onkeyup='TinhTienSo(" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + ");' id='gia_" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "' value='0' /><a style='cursor:pointer;' onclick='CapNhatGiaoChoKhach(" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + ")' ><img id='hinhthoi_" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "' src='../images/Edit.png' height='30' width='30' /></a></td>";
                 else
                     html += "<td><input disabled='disabled' type='text' onkeyup='TinhTienSo(" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + ");' id='gia_" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "' value='" + double.Parse(check.Rows[0]["Gia"].ToString()).ToString("#,##").Replace(",", ".") + "' /><a style='cursor:pointer;' onclick='CapNhatGiaoChoKhach(" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + ")' ><img id='hinhthoi_" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "' src='../images/Edit.png' height='30' width='30' /></a></td>";
             }
             else
                 html += "<td><input disabled='disabled' type='text' onkeyup='TinhTienSo(" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + ");' id='gia_" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "' value='0' /><a style='cursor:pointer;' onclick='CapNhatGiaoChoKhach(" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + ")' ><img id='hinhthoi_" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "' src='../images/Edit.png' height='30' width='30' /></a></td>";
            html += "</tr>";
        }
     html += @"</table><br/>";
     Response.Write(html);
    }

    private void CapNhatGiaoChoKhach()
    {
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string Gia = StaticData.ValidParameter(Request.QueryString["Gia"].Trim());
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

        DataTable check = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang = " + IDKhachHang + " and IDHangHoa = " + IDLoaiHangHoa + "");
        if (check.Rows.Count > 0)
        {
            string sql = "update ChiTietGiaTheoKhach set Gia = " + Gia.Replace(",", "").Replace(".", "") + " where IDKhachHang = " + IDKhachHang + " and IDHangHoa = " + IDLoaiHangHoa + " ";
            bool c = Connect.Exec(sql);
        }
        else
        {
            string sql = "insert into ChiTietGiaTheoKhach values(" + IDKhachHang + "," + IDLoaiHangHoa + "," + Gia.Replace(",", "").Replace(".", "") + ",N'')";
            bool c = Connect.Exec(sql);
        }

        Response.Write("True");
    }
    
}