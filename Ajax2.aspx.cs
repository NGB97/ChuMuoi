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
            case "LoadChiTietHangHoa":
                LoadChiTietHangHoa();break;
                case "DeleteHangHoa":
                DeleteHangHoa();break;

                case "DeleteHinhAnh":
                DeleteHinhAnh();break;

                case "ThemHangHoa":
                ThemHangHoa();break;
                case "LoadLoaiHang":
                    LoadLoaiHang(); break;

                case "LoadSize":
                    LoadSize(); break;

                case "LoadLenMau":
                    LoadLenMau(); break;

                case "ThemTheoLoaiHangHoa":
                    ThemTheoLoaiHangHoa(); break;

                case "SuaSoLuongChiTietPhieuNhap":
                    SuaSoLuongChiTietPhieuNhap(); break;

                case "SuaSoLuongChiTietPhieuXuat":
                    SuaSoLuongChiTietPhieuXuat(); break;

                case "LoadLoaiHangHoa":
                    LoadLoaiHangHoa(); break;
                case "ThemTheoLoaiHangCapCaoPhieuXuat":
                    ThemTheoLoaiHangCapCaoPhieuXuat(); break;


                case "LayGiaGoc":
                    LayGiaGoc(); break;

                case "DeleteDVT":
                    DeleteDVT(); break;


            case "LoadMauTheoSize":
                    LoadMauTheoSize(); break;


            case"GiaNhapNhaCungCapGanNhat":
                GiaNhapNhaCungCapGanNhat();break;
              
        }
    }
    private void GiaNhapNhaCungCapGanNhat()
    {

        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string IDNhaCungCap = StaticData.ValidParameter(Request.QueryString["IDNhaCungCap"].Trim());
        DataTable a = Connect.GetTable("select DonGiaNhap Gia from ChiTietPhieuNhap,PhieuNhap,HangHoa where PhieuNhap.IDPhieuNhap=ChiTietPhieuNhap.IDPhieuNhap and HangHoa.IDLoaiHangHoa=" + IDLoaiHangHoa + " and HangHoa.IDHangHoa=ChiTietPhieuNhap.IDHangHoa and IDNhaCungCap =" + IDNhaCungCap + " order by IDChiTietPhieuNhap DESC ");
        if (a.Rows.Count == 0) Response.Write("0");
        else
        {
            if (double.Parse(a.Rows[0]["Gia"].ToString().Trim()) == 0) Response.Write("0");
            else
                Response.Write(double.Parse(a.Rows[0]["Gia"].ToString().Trim()).ToString("#,##").Replace(",", "."));
        }
    }
    private void DeleteHinhAnh()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["idHinhAnh"].Trim());

        string sql = "delete from tb_HinhAnhLoaiHangHoa where idHinhAnh=" + idNguoiDung;

        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void LoadMauTheoSize()
    {
        string html = "";
        string idLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["idLoaiHangHoa"].Trim());
        string idSize = StaticData.ValidParameter(Request.QueryString["idSize"].Trim());

        string sql = "SELECT [idMauSac] FROM [HangHoa] WHERE [IDLoaiHangHoa] = '" + idLoaiHangHoa + "' AND [IDSize] = '" + idSize + "'";

        DataTable tb = Connect.GetTable(sql);
        if(tb.Rows.Count > 0)
        {
            html += @"  <table id='tbMauSac' class='table table-bordered table-striped' >
                                <tr>

                            <th class='th' style='width:60%'>
                                  Màu
                                    </th>

                                <th class='th'>
                                   Nhập số lượng
                                    </th>                                                                                                               
                                </tr> ";

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                html += "       <tr>";
                html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "idMauSac", tb.Rows[i]["idMauSac"].ToString()) + "</td>";
                html += "       <td>   <input type='text' id='mau" + (i + 1).ToString() + "' name='txt" + tb.Rows[i]["idMauSac"].ToString() + "' >    </td>";
                html += "       </tr>";

            }
            html += "        </table> ";
        }
        else
        {
            html += "Không có màu nào...";
        }


        Response.Write(html);

    }
    private void DeleteDVT()
    {


        string IDDonViTinh = StaticData.ValidParameter(Request.QueryString["IDDonViTinh"].Trim());
        string sql = "delete from DonViTinh where IDDonViTinh=" + IDDonViTinh + "";
        bool rs = Connect.Exec(sql);
        if (rs) Response.Write("True");
        else Response.Write("False");
    }
    private void LayGiaGoc()
    {


        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        DataTable a = Connect.GetTable("select Gia from LoaiHangHoa where IDLoaiHangHoa=" + IDLoaiHangHoa + "");
        if (a.Rows.Count == 0) Response.Write("0");
        else
        {
            if(double.Parse(a.Rows[0]["Gia"].ToString().Trim()) == 0) Response.Write("0");
            else
            Response.Write(double.Parse(a.Rows[0]["Gia"].ToString().Trim()).ToString("#,##").Replace(",", "."));
        }
    }
    private void ThemTheoLoaiHangCapCaoPhieuXuat()
    {
        string GiaBan = StaticData.ValidParameter(Request.QueryString["GiaBan"].Trim());

        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string IDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string IDMauSac = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());

        string MauSac = StaticData.ValidParameter(Request.QueryString["MauSac"].Trim());

        DataTable LayGiaKhach = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDLoaiHangCapCao + "");
        if (LayGiaKhach.Rows.Count <= 0)
        {
            string sql2 = "insert into ChiTietGiaTheoKhach values(" + IDKhachHang + "," + IDLoaiHangCapCao + "," + GiaBan + ",N'')";
            bool rs2 = Connect.Exec(sql2);
        }
        else
        {
            string sql2 = "update ChiTietGiaTheoKhach set Gia=" + GiaBan + " where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDLoaiHangCapCao + " ";
            bool rs2 = Connect.Exec(sql2);
        }



        DataTable tableHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + IDLoaiHangCapCao + " and IDSize = " + IDMauSac + "");
        int check = 0;
        string dm = "";
        for (int i = 0; i < tableHangHoa.Rows.Count; i++)
        {
            DataTable LayGiaTheoKhach = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "");
            if (LayGiaTheoKhach.Rows.Count <= 0)
            {
                check = check + 1;
            }


        }

        if (check > 0)
        {
            Response.Write("False");
        }
        else
        {
            int catchloi = 0;
            for (int i = 0; i < tableHangHoa.Rows.Count; i++)
            {
                if (MyStaticData.KiemTraSoLuong(tableHangHoa.Rows[i]["IDHangHoa"].ToString(), double.Parse(SoLuong)))
                {

                }
                else
                {
                    catchloi += 1;
                }
            }
            if (catchloi > 0)
            {
                Response.Write("False");
            }
            else
            {
                string[] arrMauSac = MauSac.Split(',');

                for (int i = 0; i < tableHangHoa.Rows.Count; i++)
                {
                    DataTable LayGiaTheoKhach = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "");

                    string DonGiaTheoKhach = LayGiaTheoKhach.Rows[0]["Gia"].ToString();
                    //DataTable tbHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "");
                    //for (int j = 0; j < tbHangHoa.Rows.Count; j++)
                    //{

                    if (int.Parse(arrMauSac[i]) != 0)
                    {
                        string sql = "insert into ChiTietPhieuXuat values(" + IDPhieuXuat + "," + tableHangHoa.Rows[i]["IDHangHoa"].ToString() + "," + arrMauSac[i] + "," + DonGiaTheoKhach + "," + MyStaticData.GetGiaVon(tableHangHoa.Rows[i]["IDHangHoa"].ToString()) + ",N'')";
                        bool rs = Connect.Exec(sql);
                    }
                    //}
                }
                Response.Write("True");
            }
        }

    }
    private void LoadLoaiHangHoa()
    {

        string sql = "";

        sql += "  select IDLoaiHangHoa,TenLoaiHangHoa,MaLoaiHangHoa from LoaiHangHoa";
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


            listgAutocomplete += "value: '" + table.Rows[i]["TenLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenLoaiHangHoa"].ToString() + "-" + table.Rows[i]["MaLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void SuaSoLuongChiTietPhieuXuat()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuXuat"].Trim());
        string MaPhieuXuat =StaticData.getField("PhieuXuat","MaPhieuXuat","IDPhieuXuat", StaticData.getField("ChiTietPhieuXuat", "IDPhieuXuat", "IDChiTietPhieuXuat", IDChiTietPhieuXuat));
        
        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string sql = "";

        sql += " update ChiTietPhieuXuat set SoLuong = " + SoLuong + " where IDChiTietPhieuXuat=" + IDChiTietPhieuXuat + "";
        bool table = Connect.Exec(sql);
        string listgAutocomplete = "False";

        if (table)
        {
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Sửa số lượng chi tiết phiếu xuất "+MaPhieuXuat+"','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);

            listgAutocomplete = "True";
        }

        Response.Write(listgAutocomplete);
    }
    private void SuaSoLuongChiTietPhieuNhap()
    {
        string IDChiTietPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuNhap"].Trim());
        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string MaPhieuNhap = StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", StaticData.getField("ChiTietPhieuNhap", "IDPhieuNhap", "IDChiTietPhieuNhap", IDChiTietPhieuNhap));

        string sql = "";

        sql += " update ChiTietPhieuNhap set SoLuong = "+SoLuong+" where IDChiTietPhieuNhap=" + IDChiTietPhieuNhap + "";
        bool table = Connect.Exec(sql);
        string listgAutocomplete = "False";

        if (table)
        {

            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Sửa số lượng phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);
            listgAutocomplete = "True";
        }

        Response.Write(listgAutocomplete);
    }
    private void LoadLenMau()
    {
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string IDSize = StaticData.ValidParameter(Request.QueryString["IDSize"].Trim());
        string sql = "";

        sql += "select * from MauSac where MauSac.IDMauSac in (select HangHoa.IDMauSac from HangHoa where  HangHoa.IDLoaiHangHoa=" + IDLoaiHangHoa + " and HangHoa.IDSize=" + IDSize + " ) ";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "";

        for (int i = 0; i < table.Rows.Count; i++)
        {

            listgAutocomplete += table.Rows[i]["IDMauSac"].ToString() + "@" + table.Rows[i]["TenMauSac"].ToString();
            listgAutocomplete += "~";
        }

        Response.Write(listgAutocomplete);
    }
    private void LoadSize()
    {
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string sql = "";

        //sql += " select distinct MauSac.IDMauSac,MauSac.TenMauSac from HangHoa,MauSac where HangHoa.IDMauSac=MauSac.IDMauSac and HangHoa.IDLoaiHangHoa=" + IDLoaiHangHoa + "";
        //DataTable table = Connect.GetTable(sql);
        //string listgAutocomplete = "";

        //for (int i = 0; i < table.Rows.Count; i++)
        //{

        //    listgAutocomplete += table.Rows[i]["IDMauSac"].ToString() + "@" + table.Rows[i]["TenMauSac"].ToString();
        //    listgAutocomplete += "~";
        //}
        sql += " select distinct Size.IDSize,Size.TenSize from HangHoa,Size where HangHoa.IDSize=Size.IDSize and HangHoa.IDLoaiHangHoa=" + IDLoaiHangHoa + "";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "";

        for (int i = 0; i < table.Rows.Count; i++)
        {

            listgAutocomplete += table.Rows[i]["IDSize"].ToString() + "@" + table.Rows[i]["TenSize"].ToString();
            listgAutocomplete += "~";
        }
        Response.Write(listgAutocomplete);
    }
    private void LoadLoaiHang()
    {
        string IDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());
        string sql = "";

        sql += "  select * from LoaiHangHoa where IDLoaiHangCapCao=" + IDLoaiHangCapCao + "";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "";
      
        for (int i = 0; i < table.Rows.Count; i++)
        {

            listgAutocomplete += table.Rows[i]["IDLoaiHangHoa"].ToString()+"@"+table.Rows[i]["TenLoaiHangHoa"].ToString();
            listgAutocomplete += "~" ;
        }
      
        Response.Write(listgAutocomplete);
    }
    private void LoadChiTietHangHoa()
    {
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string sql = "";
        sql += "select * from HangHoa where IDLoaiHangHoa = " + IDLoaiHangHoa + " order by HangHoa.IDHangHoa desc";
        DataTable table = Connect.GetTable(sql);
        string html = @"<table class='table table-bordered table-striped' >
                                <tr>
                                    <th class='th'>
                                        STT
                                    </th>
                                    <th class='th'>
                                     Size
                                    </th>
                                    <th class='th'>
                                     Màu
                                    </th>
                                    <th class='th'>
                                     Kiểu dáng
                                    </th>
                                    <th class='th'>
                                     Chất liệu
                                    </th>
                                 <th class='th'>
                                   Ghi chú
                                    </th>
                                    <th class='th'>
                                    </th>
                                </tr> ";
        double Tong = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            int stt = i + 1;

            html += "       <td>" + stt + "</td>";

            html += "       <td>" + StaticData.getField("Size", "TenSize", "IDSize", table.Rows[i]["IDSize"].ToString().Trim()) + "</td>";
            html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", table.Rows[i]["IDMauSac"].ToString().Trim()) + "</td>";
            html += "       <td>" + StaticData.getField("KieuDang", "TenKieuDang", "IDKieuDang", table.Rows[i]["IDKieuDang"].ToString().Trim()) + "</td>";
            html += "       <td>" + StaticData.getField("ChatLieu", "TenChatLieu", "IDChatLieu", table.Rows[i]["IDChatLieu"].ToString().Trim()) + "</td>";
           

            html += "       <td>" + table.Rows[i]["GhiChu"].ToString().Trim().Replace("\n", "<br />") + "</td>";
         
        

            html += "<td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='DeleteHangHoa(\"" + table.Rows[i]["IDHangHoa"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png'  /></a></td>";
            html += "       </tr>";

        }
      
        html += "  </table>";
        Response.Write(html);

    }
    private void ThemHangHoa()
    {
        string IDSize = StaticData.ValidParameter(Request.QueryString["IDSize"].Trim());
        string IDMauSac = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());
        string IDChatLieu = StaticData.ValidParameter(Request.QueryString["IDChatLieu"].Trim());
        string IDKieuDang = StaticData.ValidParameter(Request.QueryString["IDKieuDang"].Trim());
        string GhiChu = StaticData.ValidParameter(Request.QueryString["GhiChu"].Trim());
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        DataTable check = Connect.GetTable("select * from HangHoa where IDSize=" + IDSize + " and IDMauSac=" + IDMauSac + "  and IDChatLieu=" + IDChatLieu + " and IDKieuDang=" + IDKieuDang + " and IDLoaiHangHoa=" + IDLoaiHangHoa + "");
        if (check.Rows.Count > 0)
        {
            Response.Write("False1");
        }
        else
        {
            string sql = "insert into HangHoa(MaHangHoa,TenHangHoa,IDSize,IDMauSac,IDKieuDang,IDChatLieu,GhiChu,IDLoaiHangHoa) values(null,null," + IDSize + "," + IDMauSac + "," + IDKieuDang + "," + IDChatLieu + ",N'" + GhiChu + "'," + IDLoaiHangHoa + ")";
            bool rs = Connect.Exec(sql);

            if (rs)
            {
                Response.Write("True");
            }
            else
            {
                Response.Write("False");
            }
        }
     
    }
    private void ThemTheoLoaiHangHoa()
    {

        try
        {

            string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
            string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
            string IDSize = StaticData.ValidParameter(Request.QueryString["IDSize"].Trim());
            string IDMauSac = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());
            string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
            string GiaNhap = StaticData.ValidParameter(Request.QueryString["GiaNhap"].Trim());
            string MaPhieuNhap = StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", IDPhieuNhap);
            string sqlQuery = "update LoaiHangHoa set Gia=" + GiaNhap + " where IDLoaiHangHoa=" + IDLoaiHangHoa + "";
            bool rs1 = Connect.Exec(sqlQuery);

            DataTable getIDHangHoa = Connect.GetTable("select * from HangHoa where IDSize = " +  IDMauSac+ " and IDMauSac=" + IDSize + " and IDLoaiHangHoa=" + IDLoaiHangHoa + "");

            DataTable DonGiaNhap = Connect.GetTable("select * from LoaiHangHoa where IDLoaiHangHoa = " + IDLoaiHangHoa + " ");

            DataTable kiemtra = Connect.GetTable("select * from ChiTietPhieuNhap where IDHangHoa = " + getIDHangHoa.Rows[0]["IDHangHoa"].ToString() + " and IDPhieuNhap=" + IDPhieuNhap + "");
            if (kiemtra.Rows.Count > 0)
            {
                string sql = "update ChiTietPhieuNhap set SoLuong=SoLuong+" + SoLuong + " where IDChiTietPhieuNhap=" + kiemtra.Rows[0]["IDChiTietPhieuNhap"].ToString() + "";
                bool r = Connect.Exec(sql);
                if (r)
                {
                    string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm hàng hóa phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
                    bool kq2 = Connect.Exec(sql2);
                    Response.Write("True");
                }
                else
                    Response.Write("False");
            }
            else
            {

                string sql = "insert into ChiTietPhieuNhap values(" + getIDHangHoa.Rows[0]["IDHangHoa"].ToString() + "," + IDPhieuNhap + "," + SoLuong + "," + DonGiaNhap.Rows[0]["Gia"].ToString() + ",N'',null)";
                bool rs = Connect.Exec(sql);
                if (rs)
                {
                    string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm hàng hóa phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
                    bool kq2 = Connect.Exec(sql2);
                    Response.Write("True");
                }
                else
                    Response.Write("False");
            }
          //  Response.Write("select * from HangHoa where IDSize = " + IDSize + " and IDMauSac=" + IDMauSac + " and IDLoaiHangHoa=" + IDLoaiHangHoa + "");
        }
        catch
        {
            Response.Write("False");
        }
        
    }
    private void DeleteHangHoa()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string sql = "delete from HangHoa where IDHangHoa=" + idNguoiDung;

        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
}