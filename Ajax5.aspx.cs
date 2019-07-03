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


            case "TinhTienSo":
                TinhTienSo(); break;


            case "listsanpham":
                    listsanpham(); break;
        }
    }
 
    private void listsanpham()
    {
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
            html += "<td><input type='text' onkeyup='TinhTienSo(" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + ");' id='gia_" + table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "' value='0' /></td>";
            chuoi += table.Rows[i]["IDLoaiHangHoa"].ToString().Trim() + "-0";
            chuoi += "@";
            html += "</tr>";
        }

  

     html += @"</table><br/>";

     HttpCookie ThemNhanh = new HttpCookie("ThemGia", chuoi);
     ThemNhanh.Expires = DateTime.Now.AddDays(30);
     Response.Cookies.Add(ThemNhanh);

     Response.Write(html);
    }

    private void TinhTienSo()
    {


        string Gia = StaticData.ValidParameter(Request.QueryString["Gia"].Trim()).Replace(",","").Replace(".","");
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());

        string [] tach = Request.Cookies["ThemGia"].Value.Trim().Split('@');
        for(int i = 0;i<tach.Length-1;i++)
        {
           string[] tachnua = tach[i].Split('-');
           if (tachnua[0].Trim() == IDLoaiHangHoa.Trim())
           {
               tachnua[1] = Gia;

               tach[i] = tachnua[0] + "-" + tachnua[1];
           }
       }
        string chuoi = "";
        for (int i = 0; i < tach.Length; i++)
        {
            chuoi += tach[i];
            chuoi += "@";
        }

        HttpCookie ThemNhanh = new HttpCookie("ThemGia", chuoi);
        ThemNhanh.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(ThemNhanh);

        Response.Write(chuoi);
    }
    
}