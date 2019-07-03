using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Collections;

/// <summary>
/// Summary description for MyStaticData
/// </summary>
public class MyStaticData
{
    public double CongLai(string idPhieuXuat, string idKhachHang)
    {
        string IDKhachHang = StaticData.ValidParameter(idKhachHang);
        string IDPhieuXuat = StaticData.ValidParameter(idPhieuXuat);
        double ConLai = MyStaticData.GetNoKhachHangNgoaiTruPhieuXuat(IDKhachHang, IDPhieuXuat) - MyStaticData.GetSoTienDaTraCuaKhachHang(IDKhachHang);


        string sql = "";

        sql += "  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " ";
        DataTable table = Connect.GetTable(sql);
        double tong = double.Parse(table.Rows[0]["Tong"].ToString()) + ConLai;


        if (tong == 0)
        {
            return 0;
        }
        else
        {
            //Response.Write(tong.ToString("#,##").Replace(",", "."));
            return tong;
        }
    }
     public static double TongTienKhachNo(string idPhieuXuat,string idKhachHang)
    {
        string IDKhachHang = StaticData.ValidParameter(idKhachHang);
        string IDPhieuXuat = StaticData.ValidParameter(idPhieuXuat);
        double ConLai = MyStaticData.GetNoKhachHangNgoaiTruPhieuXuat(IDKhachHang, IDPhieuXuat) - MyStaticData.GetSoTienDaTraCuaKhachHang(IDKhachHang);
        if (ConLai == 0)
        {
            return 0;
        }
        else
        {
            return ConLai;

        }
    }
    public static double TongTienDonHang(string idPhieuXuat)
    {
        string IDPhieuXuat = StaticData.ValidParameter(idPhieuXuat);
        string sql = "";

        sql += "  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " ";
        DataTable table = Connect.GetTable(sql);
        if (double.Parse(table.Rows[0]["Tong"].ToString()) == 0)
            return 0;
        return double.Parse(table.Rows[0]["Tong"].ToString());
    }
    public static double LoadChiTietLoiNhuan(string iIDLoaiHangHoa, string iTuNgay, string iDenNgay)
    {
        string IDLoaiHangHoa = iIDLoaiHangHoa;
        string GiaThoi = StaticData.getField("LoaiHangHoa", "Gia", "IDLoaiHangHoa", IDLoaiHangHoa);

        string TuNgay = iTuNgay;
        string DenNgay = iDenNgay;

        string sql = "";

        sql += @" select *  from ChiTietPhieuXuat where '1'='1'
        

            AND IDHangHoa IN ( SELECT IDHangHoa FROM HangHoa WHERE IDLoaiHangHoa = '" + IDLoaiHangHoa + "' ) ";

        if (TuNgay != "")
            sql += " and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1'  and PhieuXuat.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(TuNgay) + "' ) ";
        if (DenNgay != "")
            sql += " and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1'  and PhieuXuat.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(DenNgay) + "' ) ";

        DataTable table = Connect.GetTable(sql);
        string html = @"";
         double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
          

            DataTable LayGiaNhapGanNhat = Connect.GetTable("select ChiTietPhieuNhap.DonGiaNhap from  ChiTietPhieuNhap where IDHangHoa = " + table.Rows[i]["IDHangHoa"].ToString() + " order by IDChiTietPhieuNhap desc");



            string GiaGoc = "0";
            if (LayGiaNhapGanNhat.Rows.Count > 0)
                GiaGoc = LayGiaNhapGanNhat.Rows[0][0].ToString();
            //string GiaGoc = LayGiaNhapGanNhat.Rows[0][0].ToString();

           
            if (GiaGoc == "0" || table.Rows[i]["DonGiaXuat"].ToString() == "0")
            {
               
            }

            else
            {
                double LoiNhuan = (double.Parse(table.Rows[i]["DonGiaXuat"].ToString()) - double.Parse(GiaThoi)) * double.Parse(table.Rows[i]["SoLuong"].ToString());

               
     
                SoTienPhaiThu += LoiNhuan;

            }

        }
        return SoTienPhaiThu;
       
    }


    public static int GetSoKH()
    {
        string query = "select count(*) from KhachHang";
        DataTable table2 = Connect.GetTable(query);


       int TongTienDaMuaTatCa = int.Parse(table2.Rows[0][0].ToString()) ;
       return TongTienDaMuaTatCa;
      
    }

    public static int GetSoNCC()
    {
        string query = @"SELECT count(*)  FROM [NhaCungCap]";
        DataTable table2 = Connect.GetTable(query);


        int TongTienDaMuaTatCa = int.Parse(table2.Rows[0][0].ToString());
        return TongTienDaMuaTatCa;

    }
    public static bool KiemTraSoLuong(string IDHangHoa, double SoLuong)
    {
      //  double TongTienDaMuaTatCa = 0;

      //  string sql = "select isnull(sum(SoLuong),0) from ChiTietPhieuXuat where IDHangHoa='" + IDHangHoa + "'";
      //  DataTable table = Connect.GetTable(sql);

      //  string query = "select isnull(sum(SoLuong),0) from ChiTietPhieuNhap where IDHangHoa=" + IDHangHoa + "";
      //  DataTable table2 = Connect.GetTable(query);


      //  TongTienDaMuaTatCa = double.Parse(table2.Rows[0][0].ToString())- double.Parse(table.Rows[0][0].ToString()) ;
      //// return TongTienDaMuaTatCa;
      //  if (TongTienDaMuaTatCa - SoLuong < 0) return false;
        return true;
    }
    public static double TongDaTraCuaKhach(string IDKhachHang)
    {
        double TongTienDaMuaTatCa = 0;

        string sql = "select isnull(sum(TienThanhToan),0) from PhieuXuat where IDKhachHang='" + IDKhachHang + "'";
        DataTable table = Connect.GetTable(sql);

        string query = "select isnull(sum(SoTien),0) from PhieuTraNo where IDKhachHang=" + IDKhachHang + "";
        DataTable table2 = Connect.GetTable(query);
        TongTienDaMuaTatCa = double.Parse(table2.Rows[0][0].ToString()) + double.Parse(table.Rows[0][0].ToString());
        return TongTienDaMuaTatCa;
    }
    public static double TongTienTrenPhieuXuatCuaKhach(string IDKhachHang)
    {
        double TongTienDaMuaTatCa = 0;

        //string sql = "select * from PhieuXuat where IDKhachHang='" + IDKhachHang + "'";
        //DataTable table = Connect.GetTable(sql);
        //for (int i = 0; i < table.Rows.Count; i++)
        //{
        //    string query = "select isnull(sum(SoLuong*DonGiaXuat),0) from ChiTietPhieuXuat where IDPhieuXuat=" + table.Rows[i]["IDPhieuXuat"].ToString() + "";
        //    DataTable table2 = Connect.GetTable(query);
        //    TongTienDaMuaTatCa += double.Parse(table2.Rows[0][0].ToString());
        //}
        //return TongTienDaMuaTatCa;
        DataTable a = Connect.GetTable(@"select 
isnull(sum(SoLuong*DonGiaXuat),0)
 from PhieuXuat,ChiTietPhieuXuat where PhieuXuat.IDPhieuXuat = ChiTietPhieuXuat.IDPhieuXuat and PhieuXuat.IDKhachHang='" + IDKhachHang + "'");
        TongTienDaMuaTatCa = double.Parse(a.Rows[0][0].ToString());
        return TongTienDaMuaTatCa;
    }

    public static int GetSoLuongSanPhamHienTai(string IDHangHoa)
    {
        int SoSPNhapKho = 0;
        int SoSPBan = 0;

        string sqlSoSPNhapKho = "select isnull(sum(SoLuong),0) from ChiTietPhieuNhap where IDHangHoa='" + IDHangHoa + "'";
        DataTable tbSoSPNhapKho = Connect.GetTable(sqlSoSPNhapKho);
        if (tbSoSPNhapKho.Rows.Count > 0)
            SoSPNhapKho = int.Parse(tbSoSPNhapKho.Rows[0][0].ToString());

        string sqlSoSPBan = "select isnull(sum(SoLuong),0) from ChiTietPhieuXuat where IDHangHoa='" + IDHangHoa + "'";
        DataTable tbSoSPBan = Connect.GetTable(sqlSoSPBan);
        if (tbSoSPBan.Rows.Count > 0)
            SoSPBan = int.Parse(tbSoSPBan.Rows[0][0].ToString());

        return SoSPNhapKho - SoSPBan;
    }
    public static double TongTienPhieuXuat(string IDPhieuXuat)
    {
        string sql = "  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " ";
        DataTable table = Connect.GetTable(sql);

        return double.Parse(table.Rows[0]["Tong"].ToString());
    }

    public static double TongTienPhieuNhap(string IDPhieuNhap)
    {
        string sql = "  select isnull(sum(DonGiaNhap*SoLuong),0) as 'Tong' from ChiTietPhieuNhap where ChiTietPhieuNhap.IDPhieuNhap = " + IDPhieuNhap + " ";
        DataTable table = Connect.GetTable(sql);

        return double.Parse(table.Rows[0]["Tong"].ToString());
    }
    public static double GetNoNhaCungCap(string IDNhaCungCap)
    {
        string sql = "  select * from PhieuNhap where PhieuNhap.IDNhaCungCap = " + IDNhaCungCap + " ";
        DataTable table = Connect.GetTable(sql);
        double No = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            double TongTienPhieu = TongTienPhieuNhap(table.Rows[i]["IDPhieuNhap"].ToString());
            double TienDaThanhToan = double.Parse(table.Rows[i]["TienDaThanhToan"].ToString());
            No += (TongTienPhieu - TienDaThanhToan);
        }
        return No;
    }
    public static double GetNoKhachHang(string IDKhachHang)
    {
        //string sql = "  select * from PhieuXuat where PhieuXuat.IDKhachHang = " + IDKhachHang + " ";
        //DataTable table = Connect.GetTable(sql);
        //double No = 0;
        //for (int i = 0; i < table.Rows.Count;i++ )
        //{
        //    double TongTienPhieu = TongTienPhieuXuat(table.Rows[i]["IDPhieuXuat"].ToString());
        //    double TienKhachThanhToan = double.Parse(table.Rows[i]["TienThanhToan"].ToString());
        //    No += (TongTienPhieu - TienKhachThanhToan);
        //}
        //return No;


        string sql = @" 
select isnull(sum(tong),0) as 'ConLai' from(

select 
((
select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat =PhieuXuat.IDPhieuXuat
)-PhieuXuat.TienThanhToan) as 'tong'
 
 from PhieuXuat where PhieuXuat.IDKhachHang = '" + IDKhachHang + @"'
  
  
  
  ) as tb1

";
        DataTable table = Connect.GetTable(sql);
        double No = double.Parse(table.Rows[0]["ConLai"].ToString());
        return No;
    }

    public static double GetNoKhachHangNgoaiTruPhieuXuat(string IDKhachHang,string IDPhieuXuat)
    {
        //string sql = "  select * from PhieuXuat where PhieuXuat.IDKhachHang = " + IDKhachHang + " and IDPhieuXuat <> " + IDPhieuXuat + " and PhieuXuat.MaPhieuXuat not like N'%-XB' ";
        //DataTable table = Connect.GetTable(sql);
        //double No = 0;
        //for (int i = 0; i < table.Rows.Count; i++)
        //{
        //    double TongTienPhieu = TongTienPhieuXuat(table.Rows[i]["IDPhieuXuat"].ToString());
        //    double TienKhachThanhToan = double.Parse(table.Rows[i]["TienThanhToan"].ToString());
        //    No += (TongTienPhieu - TienKhachThanhToan);
        //}
        //return No;

        string sql = @" 
select isnull(sum(tong),0) as 'ConLai' from(

select 
((
select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat =PhieuXuat.IDPhieuXuat
)-PhieuXuat.TienThanhToan) as 'tong'
 
 from PhieuXuat where PhieuXuat.IDKhachHang = '" + IDKhachHang + @"'
  and IDPhieuXuat <> '" +IDPhieuXuat+@"' and PhieuXuat.MaPhieuXuat not like N'%-XB' 
  
  
  ) as tb1

";
        DataTable table = Connect.GetTable(sql);
        double No = double.Parse(table.Rows[0]["ConLai"].ToString());
        return No;
    }
    public static double GetSoTienDaTraChoNhaCungCap(string IDNhaCungCap)
    {
        string sql = "  select isnull(sum(SoTien),0) from PhieuTraNoNhaCungCap where PhieuTraNoNhaCungCap.IDNhaCungCap = " + IDNhaCungCap + " ";
        DataTable table = Connect.GetTable(sql);


        //string sql2 = "  select isnull(sum(TienDaThanhToan),0) from PhieuNhap where PhieuNhap.IDNhaCungCap = " + IDNhaCungCap + " ";
        //DataTable table2 = Connect.GetTable(sql2);

        return double.Parse(table.Rows[0][0].ToString()) /*+ double.Parse(table2.Rows[0][0].ToString())*/;
    }
    public static double GetSoTienDaTraCuaKhachHang(string IDKhachHang)
    {
        string sql = "  select isnull(sum(SoTien),0) from PhieuTraNo where PhieuTraNo.IDKhachHang = " + IDKhachHang + " ";
        DataTable table = Connect.GetTable(sql);


        //string sql2 = "  select isnull(sum(TienThanhToan),0) from PhieuXuat where PhieuXuat.IDKhachHang = " + IDKhachHang + " ";
        //DataTable table2 = Connect.GetTable(sql2);
        string coi = table.Rows[0][0].ToString();
        return double.Parse(table.Rows[0][0].ToString()) /*+ double.Parse(table2.Rows[0][0].ToString())*/;
    }
	public static int GetSoSanPham(string MaSanPham)
    {
        int SoSPNhapKho =0; 
        int SoSPBan =0; 
        
        string sqlSoSPNhapKho = "select isnull(sum(SoLuong),0) from tb_NhapKho where MaSanPham='" + MaSanPham + "'";
        DataTable tbSoSPNhapKho = Connect.GetTable(sqlSoSPNhapKho);
        if (tbSoSPNhapKho.Rows.Count > 0)
            SoSPNhapKho = int.Parse(tbSoSPNhapKho.Rows[0][0].ToString());

        string sqlSoSPBan = "select isnull(sum(SoLuong),0) from tb_ChiTietDonHang where MaSanPham='" + MaSanPham + "'";
        DataTable tbSoSPBan = Connect.GetTable(sqlSoSPBan);
        if (tbSoSPBan.Rows.Count > 0)
            SoSPBan = int.Parse(tbSoSPBan.Rows[0][0].ToString());
        
        return SoSPNhapKho - SoSPBan;
    }
    public static double GetGiaVon(string IDHangHoa)
    {
        //double TongGiaVon = 0;
        //double TongSoLuong = 0;

        //string sqlSPNhapKho = "select GiaVon=isnull(sum(DonGiaNhap),0),SoLuong=isnull(sum(SoLuong),0) from ChiTietPhieuNhap where IDHangHoa=" + IDHangHoa + " ";
        //DataTable tbSPNhapKho = Connect.GetTable(sqlSPNhapKho);
        //for (int i = 0; i < tbSPNhapKho.Rows.Count;i++ )
        //{
        //    TongGiaVon += double.Parse(tbSPNhapKho.Rows[i]["GiaVon"].ToString()) * double.Parse(tbSPNhapKho.Rows[i]["SoLuong"].ToString());
        //    TongSoLuong += double.Parse(tbSPNhapKho.Rows[i]["SoLuong"].ToString());
        //}
        //if (TongGiaVon > 0)
        //    return TongGiaVon / TongSoLuong;
        //else
        //    return 0;


        double TongGiaVon = 0;
        double TongSoLuong = 0;

        string sqlSPNhapKho = "select isnull(sum(DonGiaNhap*SoLuong),0) as 'GiaVon',isnull(sum(SoLuong),0) as 'SoLuong' from ChiTietPhieuNhap where IDHangHoa=" + IDHangHoa + " ";
        DataTable tbSPNhapKho = Connect.GetTable(sqlSPNhapKho);
       
            TongGiaVon += double.Parse(tbSPNhapKho.Rows[0]["GiaVon"].ToString());
            TongSoLuong += double.Parse(tbSPNhapKho.Rows[0]["SoLuong"].ToString());
        
        if (TongGiaVon > 0)
            return TongGiaVon / TongSoLuong;
        else
            return 0;
    }
    public static double GetGiaBan(string MaSanPham)
    {
        double GiaBan = 0;
        string sqlSPNhapKho = "select top 1 GiaBan from tb_NhapKho where MaSanPham='" + MaSanPham + "' order by idNhapKho desc";
        DataTable tbSPNhapKho = Connect.GetTable(sqlSPNhapKho);
        if (tbSPNhapKho.Rows.Count > 0)
            GiaBan = double.Parse(tbSPNhapKho.Rows[0][0].ToString());
        return GiaBan;
    }
    public static double GetTienChiTraHoaHong(string idDaiLy)
    {
        double TienChiTraHoaHong = 0;
        string CapDaiLy = StaticData.getField("tb_DaiLy", "Cap", "idDaiLy", idDaiLy);
        string idTrinhDuocVien = StaticData.getField("tb_DaiLy", "idTrinhDuocVien", "idDaiLy", idDaiLy);

        int SoDaiLy = 0;
        string sqlSoDaiLy = "select count(idDaiLy) from tb_DaiLy where idTrinhDuocVien='" + idTrinhDuocVien + "'";
        DataTable tbSoDaiLy = Connect.GetTable(sqlSoDaiLy);
        if (tbSoDaiLy.Rows.Count > 0)
            SoDaiLy = int.Parse(tbSoDaiLy.Rows[0][0].ToString());

        string sqlMucChiTraHoaHong = "select idChiTraHoaHong,MucTien from tb_ChiTraHoaHong where '1'='1'";
        sqlMucChiTraHoaHong += " and CapDaiLy='" + CapDaiLy + "'";
        if (SoDaiLy <= 5)
            sqlMucChiTraHoaHong += " and SoDaiLy='1->5'";
        else
            sqlMucChiTraHoaHong += " and SoDaiLy='>5'";
        DataTable tbMucChiTraHoaHong = Connect.GetTable(sqlMucChiTraHoaHong);
        if (tbMucChiTraHoaHong.Rows.Count > 0)
            TienChiTraHoaHong = double.Parse(tbMucChiTraHoaHong.Rows[0]["MucTien"].ToString());

        return TienChiTraHoaHong;
    }
    public static double GetTienChietKhauQuanLyDaiLy(string idDaiLy, double TongTien, int SoLoaiSanPham)
    {
        double TienChietKhauQuanLyDaiLy = 0;

        string CapDaiLy = StaticData.getField("tb_DaiLy", "Cap", "idDaiLy", idDaiLy);
        string sqlChietKhau = "select PhanTramChietKhau from tb_ChietKhauQuanLyDaiLy where '1'='1'";
        sqlChietKhau += " and CapDaiLy='" + CapDaiLy + "'";
        DataTable tbChietKhau = Connect.GetTable(sqlChietKhau);
        if(tbChietKhau.Rows.Count>0)
        {
            float PhanTramChietKhau = float.Parse(tbChietKhau.Rows[0][0].ToString());
            if (SoLoaiSanPham == 1)
                TienChietKhauQuanLyDaiLy = TongTien * (PhanTramChietKhau / 100);
            else
                TienChietKhauQuanLyDaiLy = TongTien * ((PhanTramChietKhau / 2) / 100);
        }

        return TienChietKhauQuanLyDaiLy;
    }
    public static double GetTienChietKhau(string idDaiLy, double TongTien, int SoLuongSanPham)
    {
        double TienChietKhau = 0;
        string CapDaiLy = StaticData.getField("tb_DaiLy", "Cap", "idDaiLy", idDaiLy);

        if(CapDaiLy == "1")
        {
            string sqlDaiLyCap1 = "select TienChietKhau from tb_MucChietKhauCap1 where '1'='1'";
            if (TongTien >= 10000000 && TongTien < 25000000)
                sqlDaiLyCap1 += " and MucTienHoaDon='>=10tr<25tr'";
            if (TongTien >= 25000000)
                sqlDaiLyCap1 += " and MucTienHoaDon='>=25tr'";
            DataTable tbDaiLyCap1 = Connect.GetTable(sqlDaiLyCap1);
            if (tbDaiLyCap1.Rows.Count > 0)
                TienChietKhau = double.Parse(tbDaiLyCap1.Rows[0]["TienChietKhau"].ToString());
        }
        if (CapDaiLy == "2")
        {
            string sqlDaiLyCap2 = "select TienChietKhau from tb_MucChietKhauCap2 where '1'='1'";
            if (TongTien >= 5000000 && TongTien < 10000000)
                sqlDaiLyCap2 += " and MucTienHoaDon='>=5tr<10tr'";
            if (TongTien >= 10000000)
                sqlDaiLyCap2 += " and MucTienHoaDon='>=10tr'";
            DataTable tbDaiLyCap2 = Connect.GetTable(sqlDaiLyCap2);
            if (tbDaiLyCap2.Rows.Count > 0)
                TienChietKhau = double.Parse(tbDaiLyCap2.Rows[0]["TienChietKhau"].ToString());
        }
        if (CapDaiLy == "3")
        {
            string sqlDaiLyCap3 = "select PhanTramChietKhau from tb_MucChietKhauCap3 where '1'='1'";
            if (SoLuongSanPham <= 5)
                sqlDaiLyCap3 += " and SoSanPhamHoaDon='<=5'";
            if (SoLuongSanPham >= 5)
                sqlDaiLyCap3 += " and SoSanPhamHoaDon='>5'";
            DataTable tbDaiLyCap3 = Connect.GetTable(sqlDaiLyCap3);
            if(tbDaiLyCap3.Rows.Count>0)
            {
                float PhanTramChietKhau = float.Parse(tbDaiLyCap3.Rows[0]["PhanTramChietKhau"].ToString());
                TienChietKhau = TongTien * (PhanTramChietKhau / 100);
            }
        }

        return TienChietKhau;
    }

    public static bool KiemTraSo(string str)
    {
        double n;
        bool result = double.TryParse(str, out n);
        if (result) return true;
        else return false;
    }



    public static double TongTienPN(string idPhieuNhap)
    {
        double kq = 0;
        string sql = @"SELECT ISNULL(SUM(ISNULL(SoLuong,0) * ISNULL(DonGiaNhap,0)),0) AS TongTien FROM [ChiTietPhieuNhap] WHERE idPhieuNhap = '" + idPhieuNhap + "'";
        DataTable tb = Connect.GetTable(sql);

        if(tb.Rows.Count > 0)
        {
            kq = double.Parse(tb.Rows[0][0].ToString());
        }

        return kq;
    }


    public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

      
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

    
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

       
        return dTable;
    }

}