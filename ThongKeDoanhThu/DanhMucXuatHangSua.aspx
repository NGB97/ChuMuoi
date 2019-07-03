<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucXuatHangSua.aspx.cs" Inherits="QuanLyXuatNhap_DanhMucXuatHangSua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />
    <script>
        window.onload = function () {
            <%
        HttpCookie ThemNhanh = new HttpCookie("ThemNhanh", "");
        ThemNhanh.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(ThemNhanh);
        %>
             <%
        HttpCookie SuaNhanhHangHoa = new HttpCookie("SuaNhanhHangHoa", "");
        SuaNhanhHangHoa.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(SuaNhanhHangHoa);
        %>

            LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
            TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
            ABCAutocomplete();
            //LoadLenKhachHangAutocomplete();
            ABCAutocomplete2();
            LoadLoaiHangHoa();
            LoadKH();
            LoadKho();


        }


        function CapNhatSoLuongThemNhanh(chuoi) {
            // alert(chuoi);
            var soluong = $('#' + chuoi).val();
            var idsp = chuoi;
            //alert(soluong.toString());

            if (soluong.trim().length <= 0) {
                //  $('#' + chuoi).val("0");
                //  soluong = $('#' + chuoi).val();
                $('#' + chuoi).val("");
                soluong = "0";
            }

            if (isNaN(soluong)) {
                // $('#' + chuoi).val("0");
                // soluong = $('#' + chuoi).val();


                $('#' + chuoi).val("");
                soluong = "0";
            }


            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //  alert(xmlhttp.responseText)
                        $('#tongsl').html(xmlhttp.responseText);

                    }
                    else
                        alert("Lỗi internet");


                }
            }
            xmlhttp.open("GET", "../Ajax3.aspx?Action=CapNhatSoLuongThemNhanh&soluong=" + soluong + "&idsp=" + idsp, true);
            xmlhttp.send();
        }





        function CongLai() {
            var IDPhieuXuat = '<%= Request.QueryString["IDPhieuXuat"].Trim() %>';
            var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
            var TongTienKhachNo = $('#ContentPlaceHolder1_txtTongTienKhachNo').val().replace(/\./g, '').replace(/\,/g, '');

            var TongTienDonHang = $('#ContentPlaceHolder1_txtTongTienDonHang').val().replace(/\./g, '').replace(/\,/g, '');


            var TongTienPhaiTra = parseFloat(TongTienKhachNo) + parseFloat(TongTienDonHang);
            //alert(TongTienPhaiTra);
            $('#ContentPlaceHolder1_txtTongTienPhaiTra').val(TongTienPhaiTra);
            $('#ContentPlaceHolder1_txtTongTienPhaiTra').val($('#ContentPlaceHolder1_txtTongTienPhaiTra').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {


                        $('#ContentPlaceHolder1_txtTongTienPhaiTra').val(xmlhttp.responseText);
                        //  $('#ContentPlaceHolder1_txtTongTienPhaiTra').val($('#ContentPlaceHolder1_txtTongTienPhaiTra').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                        if (document.getElementById("ContentPlaceHolder1_ThanhToanTienMat").checked == true) {
                            $('#ContentPlaceHolder1_txtTienKhachThanhToan').val(xmlhttp.responseText.replace(/\./g, '').replace(/\,/g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                        }
                        else {
                            if (document.getElementById("ContentPlaceHolder1_CongNo").checked == true) {
                                $('#ContentPlaceHolder1_txtTienKhachThanhToan').val('0');
                            }
                        }
                    }
                    else
                        alert("Lỗi internet")


                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=CongLai&IDPhieuXuat=" + IDPhieuXuat + "&IDKhachHang=" + IDKhachHang, true);
            xmlhttp.send();
        }


        function TongTienKhachNo() {
            var IDPhieuXuat = '<%= Request.QueryString["IDPhieuXuat"].Trim() %>';
            var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {


                        $('#ContentPlaceHolder1_txtTongTienKhachNo').val(xmlhttp.responseText);
                    }
                    else
                        alert("Lỗi internet")


                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=TongTienKhachNo&IDKhachHang=" + IDKhachHang + "&IDPhieuXuat=" + IDPhieuXuat, true);
            xmlhttp.send();
        }

        function TongTienDonHang(IDPhieuXuat) {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {


                        $('#ContentPlaceHolder1_txtTongTienDonHang').val(xmlhttp.responseText);
                    }
                    else
                        alert("Lỗi internet")


                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=TongTienDonHang&IDPhieuXuat=" + IDPhieuXuat, true);
            xmlhttp.send();
        }
        function InPhieuXuatHang(IDPhieuXuat) {



            var TongTienKhachNo = $("#ContentPlaceHolder1_txtTongTienKhachNo").val();

            var TienThanhToan = $("#ContentPlaceHolder1_txtTienKhachThanhToan").val();
            var IdKho = $("#ContentPlaceHolder1_txtIDKho").val();

            var checkTienTT = "true";
            var check = document.getElementById("ContentPlaceHolder1_ThanhToanTienMat");
            if (check.checked == true) {

            }
            else {
                checkTienTT = "false";
            }


            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {

                        var print = window.open('', '_blank');

                        var shtml = "<html>";
                        shtml += "<body onload=\"window.print(); window.close();\">";
                        shtml += xmlhttp.responseText;
                        shtml += "</body>";
                        shtml += "</html>";

                        print.document.write(shtml);
                        print.document.close();

                    }
                    else
                        alert("Lỗi in")


                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=InPhieuXuatHang&IDPhieuXuat=" + IDPhieuXuat + "&TongTienKhachNo=" + TongTienKhachNo + "&TienThanhToan=" + TienThanhToan + "&IdKho=" + IdKho + "&checkTienTT=" + checkTienTT, true);
            xmlhttp.send();
        }

        function InChiTietVaSua() {
            var MaPhieuXuat = $('#ContentPlaceHolder1_txtMaPhieuXuat').val();
            var IDPhieuXuat = '<%=Request.QueryString["IDPhieuXuat"].Trim()%>';
            var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
            var NgayXuat = $('#ContentPlaceHolder1_txtNgayXuat').val();
            var IDKho = $('#ContentPlaceHolder1_txtIDKho').val();
            var GhiChu = $('#ContentPlaceHolder1_txtGhiChu').val();
            var TienThanhToan = $('#ContentPlaceHolder1_txtTienKhachThanhToan').val();
            if (IDKho.trim().length <= 0 || NgayXuat.trim().length <= 0) {
                alert('Hãy chọn đủ thông tin bắt buộc!');
            }
            else {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        //alert(xmlhttp.responseText);
                        if (xmlhttp.responseText != "False") {
                            InPhieuXuatHang(IDPhieuXuat);
                        }
                        else
                            alert("Lỗi in")


                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=InChiTietVaSua&IDPhieuXuat=" + IDPhieuXuat + "&IDKhachHang=" + IDKhachHang + "&NgayXuat=" + NgayXuat + "&IDKho=" + IDKho + "&GhiChu=" + GhiChu + "&TienThanhToan=" + TienThanhToan + "&MaPhieuXuat=" + MaPhieuXuat, true);
                xmlhttp.send();
            }
        }

        function InTongHopVaSua() {
            var MaPhieuXuat = $('#ContentPlaceHolder1_txtMaPhieuXuat').val();
            var IDPhieuXuat = '<%=Request.QueryString["IDPhieuXuat"].Trim()%>';
            var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
            var NgayXuat = $('#ContentPlaceHolder1_txtNgayXuat').val();
            var IDKho = $('#ContentPlaceHolder1_txtIDKho').val();
            var GhiChu = $('#ContentPlaceHolder1_txtGhiChu').val();
            var TienThanhToan = $('#ContentPlaceHolder1_txtTienKhachThanhToan').val();
            if (IDKho.trim().length <= 0 || NgayXuat.trim().length <= 0) {
                alert('Hãy chọn đủ thông tin bắt buộc!');
            }
            else {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        //alert(xmlhttp.responseText);
                        if (xmlhttp.responseText != "False") {
                            InPhieuTongHopXuatHang(IDPhieuXuat);
                        }
                        else
                            alert("Lỗi in")


                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=InChiTietVaSua&IDPhieuXuat=" + IDPhieuXuat + "&IDKhachHang=" + IDKhachHang + "&NgayXuat=" + NgayXuat + "&IDKho=" + IDKho + "&GhiChu=" + GhiChu + "&TienThanhToan=" + TienThanhToan + "&MaPhieuXuat=" + MaPhieuXuat, true);
                xmlhttp.send();
            }
        }


        function InPhieuTongHopXuatHang(IDPhieuXuat) {

            var TongTienKhachNo = $("#ContentPlaceHolder1_txtTongTienKhachNo").val();

            var TongTienPhaiTra = $("#ContentPlaceHolder1_txtTongTienPhaiTra").val();

            var TienThanhToan = $("#ContentPlaceHolder1_txtTienKhachThanhToan").val();
            var IdKho = $("#ContentPlaceHolder1_txtIDKho").val();

            var TienDonHang = $("#ContentPlaceHolder1_txtTongTienDonHang").val();
            var checkTienTT = "true";
            var check = document.getElementById("ContentPlaceHolder1_ThanhToanTienMat");
            if (check.checked == true) {

            }
            else {
                checkTienTT = "false";
            }
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {

                        var print = window.open('', '_blank');

                        var shtml = "<html>";
                        shtml += "<body onload=\"window.print(); window.close();\">";
                        shtml += xmlhttp.responseText;
                        shtml += "</body>";
                        shtml += "</html>";

                        print.document.write(shtml);
                        print.document.close();

                    }
                    else
                        alert("Lỗi in")


                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=InPhieuTongHopXuatHang&IDPhieuXuat=" + IDPhieuXuat + "&TongTienKhachNo=" + TongTienKhachNo + "&TienThanhToan=" + TienThanhToan + "&IdKho=" + IdKho + "&TienDonHang=" + TienDonHang + "&TongTienPhaiTra=" + TongTienPhaiTra + "&checkTienTT=" + checkTienTT, true);
            xmlhttp.send();
        }




        function LoadLoaiHangHoa() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                               .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');

                        var listKhachHangAutocomplete = eval("(" + txt + ")");

                        $("#ContentPlaceHolder1_txtLoaiHangHoa").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            //appendTo: '#lightXemDungCu',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtLoaiHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                // alert('abc');
                                $('#ContentPlaceHolder1_slSize').empty();
                                $('#ContentPlaceHolder1_slMauSac').empty();
                                $("#ContentPlaceHolder1_txtLoaiHangHoa").val(ui.item.label);
                                $("#ContentPlaceHolder1_slLoaiHangHoa").val(ui.item.id);
                                if ($("#ContentPlaceHolder1_slLoaiHangHoa").val().trim().length > 0) {
                                    LoadLenSize();
                                    var IDHangHoa = $("#ContentPlaceHolder1_slLoaiHangHoa").val().trim();
                                    var IDKhachHang = $("#ContentPlaceHolder1_txtIDKhachHang").val().trim();

                                    LoadLenGiaTheoKhachThoi(IDKhachHang, IDHangHoa);
                                }
                                return false;
                            }
                        });


                        $("#ContentPlaceHolder1_txtShowLoaiHangCapCao").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            appendTo: '#light1',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtShowLoaiHangCapCao").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {

                                $("#divBangGiaMau").html("");

                                $("#ContentPlaceHolder1_txtShowLoaiHangCapCao").val(ui.item.label);
                                $("#ContentPlaceHolder1_txtLoaiHangCapCao").val(ui.item.id);
                                if ($("#ContentPlaceHolder1_txtLoaiHangCapCao").val().trim().length > 0) {
                                    LoadMauDonThe();
                                }
                                if ($("#ContentPlaceHolder1_txtLoaiHangCapCao").val().trim().length > 0) {
                                    //alert("đụ má");
                                    LoadLenGiaTheoKhachThoi2()
                                }
                                if ($("#ContentPlaceHolder1_txtLoaiHangCapCao").val().trim().length > 0) {
                                    document.getElementById('divBangChoDe').style.display = 'block';
                                    LoadLenSizeVaMauTheoIDLoaiHangHoa($("#ContentPlaceHolder1_txtLoaiHangCapCao").val());
                                }
                                return false;
                            }
                        });


                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadLoaiHangHoa", true);
            xmlhttp.send();
        }

        function LoadLenSizeVaMauTheoIDLoaiHangHoa(IDLoaiHangHoa) {

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {

                        $('#divBangChoDe').html(xmlhttp.responseText);

                    }
                    else
                        alert("Lỗi internet !")


                }
            }
            xmlhttp.open("GET", "../Ajax3.aspx?Action=LoadLenSizeVaMauTheoIDLoaiHangHoa&IDLoaiHangHoa=" + IDLoaiHangHoa, true);
            xmlhttp.send();
        }

        function LoadLenGiaTheoKhachThoi2() {
            var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
            var IDHangHoa = $("#ContentPlaceHolder1_txtLoaiHangCapCao").val();
            //  alert(IDKhachHang.toString() + "-" + IDHangHoa.toString());
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {


                        $('#ContentPlaceHolder1_txtGiaBanChoKhach').val(xmlhttp.responseText);
                    }
                    else
                        alert("Lỗi internet")


                }
            }
            xmlhttp.open("GET", "../Ajax3.aspx?Action=LayGiaGoc&IDKhachHang=" + IDKhachHang + "&IDHangHoa=" + IDHangHoa, true);
            xmlhttp.send();
        }


        function LoadLenGiaSuaNhanh() {
            var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
            var IDLoaiHangHoa = $("#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh").val();
            //  alert(IDKhachHang.toString() + "-" + IDHangHoa.toString());
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {


                        $('#ContentPlaceHolder1_txtGiaBanChoKhachSuaNhanhHangHoa').val(xmlhttp.responseText);
                    }
                    else
                        alert("Lỗi internet")


                }
            }
            xmlhttp.open("GET", "../Ajax3.aspx?Action=LayGiaGoc&IDKhachHang=" + IDKhachHang + "&IDHangHoa=" + IDLoaiHangHoa, true);
            xmlhttp.send();
        }

        function LoadLenGiaTheoKhachThoi(IDKhachHang, IDHangHoa) {
            //  alert(IDKhachHang.toString() + "-" + IDHangHoa.toString());
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {


                        $('#ContentPlaceHolder1_txtGiaDeNghi').val(xmlhttp.responseText);
                    }
                    else
                        alert("Lỗi internet")


                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadLenGiaTheoKhachThoi&IDKhachHang=" + IDKhachHang.toString() + "&IDHangHoa=" + IDHangHoa.toString(), true);
            xmlhttp.send();
        }
        function ChuyenSo(IDChiTietPhieuNhap) {
            $('#sl_' + IDChiTietPhieuNhap).keyup(function () {
                var soluong = $('#sl_' + IDChiTietPhieuNhap).val().trim();
                if (soluong.length <= 0) {
                    $('#sl_' + IDChiTietPhieuNhap).val("1");
                }
                if (isNaN(soluong)) {
                    $('#sl_' + IDChiTietPhieuNhap).val("1");
                }

                $('#sl_' + IDChiTietPhieuNhap).val($('#sl_' + IDChiTietPhieuNhap).val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
            });
        }

        function SuaSoLuongChiTietPhieuXuat(IDChiTietPhieuXuat) {

            var soluong = document.getElementById("sl_" + IDChiTietPhieuXuat);

            if (soluong.disabled == true) {

                soluong.disabled = false;
                document.getElementById("hinh_" + IDChiTietPhieuXuat).innerHTML = "<img  class='imgCommand' src='../Images/save.png'   />";
            }
            else {
                if (soluong.value.trim().replace(/\./g, '').replace(/\,/g, '').length <= 0) {
                    alert("Số lượng không được trống nếu không hãy nhập 0");
                }
                else {
                    if (isNaN(soluong.value.trim().replace(/\./g, '').replace(/\,/g, ''))) {
                        alert("Số lượng phải là số");
                    }
                    else {
                        var xmlhttp2;
                        if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                            xmlhttp2 = new XMLHttpRequest();
                        }
                        else {// code for IE6, IE5
                            xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                        }
                        xmlhttp2.onreadystatechange = function () {
                            if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                if (xmlhttp2.responseText != "False") {
                                    LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                    TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                    TongTienKhachNo();
                                    CongLai();


                                }
                                else
                                    alert("Lỗi !")
                            }
                        }
                        xmlhttp2.open("GET", "../Ajax2.aspx?Action=SuaSoLuongChiTietPhieuXuat&IDChiTietPhieuXuat=" + IDChiTietPhieuXuat + "&SoLuong=" + soluong.value.trim().replace(/\./g, '').replace(/\,/g, ''), true);
                        xmlhttp2.send();
                    }
                }
            }
        }

        function LoadKho() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                               .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');

                        var listKhachHangAutocomplete = eval("(" + txt + ")");
                        //alert(listKhuVucAutocomplete.toString());
                        //listKhuVucAutocomplete = [{ value: 'Công ty CP CT VIỆTTRONICS', label: 'Công ty CP CT VIỆTTRONICS', id: '2' }];
                        $("#ContentPlaceHolder1_txtKho").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtKho").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtKho").val(ui.item.value);
                                $("#ContentPlaceHolder1_txtIDKho").val(ui.item.id);
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadKho", true);
            xmlhttp.send();
        }
        function DeleteChiTietPhieuXuat(IDChiTietPhieuXuat) {
            if (confirm("Bạn có muốn xóa không ?")) {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText != "False") {
                            LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                            TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                            TongTienKhachNo();
                            CongLai();
                            // CongLai();


                        }
                        else
                            alert("Lỗi tải thông tin!")
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeleteChiTietPhieuXuat&IDChiTietPhieuXuat=" + IDChiTietPhieuXuat, true);
                xmlhttp.send();
            }
        }
        //
        function SuaChiTietPhieuXuat() {
            var TenHangHoa = $('#ContentPlaceHolder1_txtTenHangHoa2').val();
            var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa2").val();
            var IDPhieuXuat = '<%= Request.QueryString["IDPhieuXuat"].Trim() %>';
            var SoLuong = $("#ContentPlaceHolder1_txtSoLuong2").val().replace(/\./g, '').replace(/\,/g, '');
            var DonGiaXuat = $("#ContentPlaceHolder1_txtDonGiaXuat2").val().replace(/\./g, '').replace(/\,/g, '');
            var GhiChu = $('#ContentPlaceHolder1_txtGhiChuChiTietXuat2').val();
            var loi = '';
            if (TenHangHoa.trim().length <= 0 || IDHangHoa.trim().length <= 0) {
                loi += 'Hãy chọn hàng hóa\n';
            }
            if (DonGiaXuat.trim().length <= 0) {
                loi += 'Khách này chưa được thiết lập giá\n';
            }
            if (SoLuong.trim().length <= 0) {
                loi += 'Số lượng không được trống, nếu không hãy nhập = 0\n';
            }
            if (isNaN(SoLuong)) {
                loi += 'Số lượng phải là số tự nhiên\n';
            }

            if (loi.trim().length <= 0) {

                var xmlhttp;
                if (window.XMLHttpRequest) {
                    xmlhttp = new XMLHttpRequest();
                }
                else {
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText != "False") {
                            //alert(xmlhttp.responseText);
                            DongXemQuyCach2();
                            LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');

                        }
                        else {
                            alert("Lỗi hãy kiểm tra lại mọi thông tin !");

                        }
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=SuaChiTietPhieuXuat&IDPhieuXuat=" + IDPhieuXuat + "&IDHangHoa=" + IDHangHoa + "&SoLuong=" + SoLuong + "&DonGiaXuat=" + DonGiaXuat + "&GhiChu=" + GhiChu + "&IDChiTietPhieuXuat=" + $('#ContentPlaceHolder1_IDChiTietPhieuXuat').val(), true);
                xmlhttp.send();


            }
            else
                alert(loi);

        }
        //
        function ABCAutocomplete2() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                              .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');
                        listKhachHangAutocomplete = eval("(" + txt + ")");
                        $("#ContentPlaceHolder1_txtTenHangHoa2").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            appendTo: '#lightXemQuyCach2',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa2").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtLoiNhuan2").val("");
                                $("#ContentPlaceHolder1_txtTenHangHoa2").val(ui.item.value);

                                $("#ContentPlaceHolder1_txtIDHangHoa2").val(ui.item.id);

                                var IDKhachHang = $("#ContentPlaceHolder1_txtIDKhachHang").val();
                                var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa2").val();


                                if (IDHangHoa.length > 0) {
                                    var xmlhttp2;
                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                        xmlhttp2 = new XMLHttpRequest();
                                    }
                                    else {// code for IE6, IE5
                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                    }
                                    xmlhttp2.onreadystatechange = function () {
                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                            if (xmlhttp2.responseText != "False") {

                                                $("#ContentPlaceHolder1_txtDonGiaXuat2").val(xmlhttp2.responseText);


                                            }
                                            else {

                                                $("#ContentPlaceHolder1_txtDonGiaXuat2").val("");

                                            }

                                        }
                                    }
                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadLenGiaTheoKhachHang&IDKhachHang=" + IDKhachHang + "&IDHangHoa=" + IDHangHoa, true);
                                    xmlhttp2.send();
                                }


                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi internet !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=ABCAutocomplete", true);
            xmlhttp.send();
        }
        //
        function LoadLenKhachHangAutocomplete2() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                              .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');
                        listKhachHangAutocomplete = eval("(" + txt + ")");
                        $("#ContentPlaceHolder1_txtTenKhachHang2").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            appendTo: '#lightXemQuyCach2',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenKhachHang2").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtLoiNhuan2").val("");
                                $("#ContentPlaceHolder1_txtTenKhachHang2").val(ui.item.show);

                                $("#ContentPlaceHolder1_txtIDKhachHang2").val(ui.item.id);

                                $("#ContentPlaceHolder1_txtTenPhongBan2").val(ui.item.tenPhongBan);
                                $("#ContentPlaceHolder1_txtIDPhongBan2").val(ui.item.idPhongBan);
                                $("#ContentPlaceHolder1_txtTenCuaHang2").val(ui.item.tenCuaHang);
                                $("#ContentPlaceHolder1_txtIDCuaHang2").val(ui.item.idCuaHang);

                                var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa2").val();
                                var IDKhachHang = $("#ContentPlaceHolder1_txtIDKhachHang2").val();

                                if (IDHangHoa.length > 0 /*&& $("#ContentPlaceHolder1_txtTenHangHoa2").val().length > 0*/) {
                                    //alert(IDHangHoa + "/" + IDKhachHang);
                                    var xmlhttp2;
                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                        xmlhttp2 = new XMLHttpRequest();
                                    }
                                    else {// code for IE6, IE5
                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                    }
                                    xmlhttp2.onreadystatechange = function () {
                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                            if (xmlhttp2.responseText != "False") {

                                                $("#ContentPlaceHolder1_txtDonGiaXuat2").val(xmlhttp2.responseText);
                                                if ($("#ContentPlaceHolder1_txtSoLuong2").val().length > 0) {
                                                    var iSoLuong = $("#ContentPlaceHolder1_txtSoLuong2").val().replace(/\./g, '').replace(/\,/g, '');
                                                    var sluong = parseInt(iSoLuong);

                                                    var iSoLuong2 = $("#ContentPlaceHolder1_txtDonGiaXuat2").val().replace(/\./g, '').replace(/\,/g, '');
                                                    var sluong2 = parseInt(iSoLuong2);

                                                    var tong = sluong * sluong2;
                                                    $("#ContentPlaceHolder1_txtThanhTien2").val(tong);
                                                    $('#ContentPlaceHolder1_txtThanhTien2').val($('#ContentPlaceHolder1_txtThanhTien2').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                                                    var xmlhttp23;
                                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                                        xmlhttp23 = new XMLHttpRequest();
                                                    }
                                                    else {// code for IE6, IE5
                                                        xmlhttp23 = new ActiveXObject("Microsoft.XMLHTTP");
                                                    }
                                                    xmlhttp23.onreadystatechange = function () {
                                                        if (xmlhttp23.readyState == 4 && xmlhttp2.status == 200) {
                                                            var ggianhap = xmlhttp23.responseText.replace(/\./g, '').replace(/\,/g, '');
                                                            var tongnhap = tong - (parseInt(ggianhap) * sluong);
                                                            $("#ContentPlaceHolder1_txtLoiNhuan2").val(tongnhap);
                                                            $("#ContentPlaceHolder1_txtLoiNhuan2").val($('#ContentPlaceHolder1_txtLoiNhuan2').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                                                        }
                                                    }
                                                    xmlhttp23.open("GET", "../Ajax.aspx?Action=LayDGBQGQ&IDHangHoa=" + IDHangHoa, true);
                                                    xmlhttp23.send();

                                                }


                                            }
                                            else {

                                                $("#ContentPlaceHolder1_txtDonGiaXuat2").val("");
                                                if ($("#ContentPlaceHolder1_txtDonGiaXuat2").val().length <= 0) {
                                                    $("#ContentPlaceHolder1_txtSoLuong2").val("");
                                                    $("#ContentPlaceHolder1_txtThanhTien2").val("");
                                                    $("#ContentPlaceHolder1_txtLoiNhuan2").val("");
                                                }
                                            }


                                        }
                                    }
                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadLenGiaTheoKhachHang&IDKhachHang=" + IDKhachHang + "&IDHangHoa=" + IDHangHoa, true);
                                    xmlhttp2.send();

                                }


                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi tải 2!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadLenKhachHangAutocomplete", true);
            xmlhttp.send();
        }
        //
        function SuaChiTietXuat(IDChiTietPhieuXuat) {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "False") {
                        MoXemQuyCach2();
                        var txt = xmlhttp.responseText.replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');
                        var va = eval("(" + txt + ")");
                        $("#ContentPlaceHolder1_txtTenHangHoa2").val(va[0]);
                        $("#ContentPlaceHolder1_txtMauSac2").val(va[1]);
                        $("#ContentPlaceHolder1_txtSize2").val(va[2]);
                        $("#ContentPlaceHolder1_txtDonGiaXuat2").val(va[4]);
                        $("#ContentPlaceHolder1_txtSoLuong2").val(va[3]);


                        $("#ContentPlaceHolder1_txtGhiChuChiTietXuat2").val(va[6]);

                        $("#ContentPlaceHolder1_IDChiTietPhieuXuat").val(IDChiTietPhieuXuat);

                        $("#ContentPlaceHolder1_txtIDHangHoa2").val(va[7]);



                    }
                    else
                        alert("Lỗi tải thông tin!")
                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=SuaChiTietXuat&IDChiTietPhieuXuat=" + IDChiTietPhieuXuat, true);
            xmlhttp.send();
        }
        //
        function ThemChiTietPhieuXuat() {
            var TenHangHoa = $('#ContentPlaceHolder1_txtTenHangHoa').val();
            var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa").val();
            var IDPhieuXuat = '<%= Request.QueryString["IDPhieuXuat"].Trim() %>';
            var SoLuong = $("#ContentPlaceHolder1_txtSoLuong").val().replace(/\./g, '').replace(/\,/g, '');
            var DonGiaXuat = $("#ContentPlaceHolder1_txtDonGiaXuat").val().replace(/\./g, '').replace(/\,/g, '');
            var loi = '';
            if (TenHangHoa.trim().length <= 0 || IDHangHoa.trim().length <= 0) {
                loi += 'Hãy chọn hàng hóa\n';
            }
            if (DonGiaXuat.trim().length <= 0) {
                loi += 'Khách này chưa được thiết lập giá\n';
            }
            if (SoLuong.trim().length <= 0) {
                loi += 'Số lượng không được trống, nếu không hãy nhập = 0\n';
            }
            if (isNaN(SoLuong)) {
                loi += 'Số lượng phải là số tự nhiên\n';
            }
            if (loi.trim().length <= 0) {

                var xmlhttp;
                if (window.XMLHttpRequest) {
                    xmlhttp = new XMLHttpRequest();
                }
                else {
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText != "False") {
                            DongXemQuyCach();
                            LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');

                                        }
                                        else
                                            alert("Lỗi hãy kiểm tra lại mọi thông tin !")
                                    }
                                }
                                xmlhttp.open("GET", "../Ajax.aspx?Action=ThemChiTietPhieuXuat&IDPhieuXuat=" + IDPhieuXuat + "&IDHangHoa=" + IDHangHoa + "&SoLuong=" + SoLuong + "&DonGiaXuat=" + DonGiaXuat + "&GhiChu=" + $('#ContentPlaceHolder1_txtGhiChuChiTietXuat').val(), true);
                                xmlhttp.send();

                            }
                            else {
                                alert(loi);
                            }

                        }
                        //

                        //
                        function TinhTien2() {
                            $('#ContentPlaceHolder1_txtSoLuongThem').keyup(function () {
                                $('#ContentPlaceHolder1_txtSoLuongThem').val($('#ContentPlaceHolder1_txtSoLuongThem').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));


                            }
                           );

                            $('#ContentPlaceHolder1_txtGiaDeNghi').keyup(function () {
                                $('#ContentPlaceHolder1_txtGiaDeNghi').val($('#ContentPlaceHolder1_txtGiaDeNghi').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));


                            }
                        );


                            $('#ContentPlaceHolder1_txtSoLuong2').keyup(function () {
                                $('#ContentPlaceHolder1_txtSoLuong2').val($('#ContentPlaceHolder1_txtSoLuong2').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                                var SoTien = 0;
                                var SoTien = 0;
                                var Vat = 0;

                                if ($("#ContentPlaceHolder1_txtDonGiaXuat2").val().length <= 0 || $("#ContentPlaceHolder1_txtTenHangHoa2").val().length <= 0 || $("#ContentPlaceHolder1_txtTenKhachHang2").val().length <= 0)
                                    SoTien = 0;
                                else
                                    SoTien = $('#ContentPlaceHolder1_txtDonGiaXuat2').val().replace(/\./g, '').replace(/\,/g, '');

                                if ($("#ContentPlaceHolder1_txtDonGiaXuat2").val().length <= 0 || $("#ContentPlaceHolder1_txtTenHangHoa2").val().length <= 0 || $("#ContentPlaceHolder1_txtTenKhachHang2").val().length <= 0)
                                    Vat = 0;
                                else
                                    Vat = $('#ContentPlaceHolder1_txtSoLuong2').val().replace(/\./g, '').replace(/\,/g, '');

                                var TongTien = parseInt((parseInt(SoTien) * parseInt(Vat)));



                                $('#ContentPlaceHolder1_txtThanhTien2').val(TongTien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                                var CheckDonGia = isNaN(TongTien);
                                if (CheckDonGia || $('#ContentPlaceHolder1_txtSoLuong2').val().trim().length <= 0) {
                                    $('#ContentPlaceHolder1_txtThanhTien2').val("");
                                    $('#ContentPlaceHolder1_txtLoiNhuan2').val("");
                                }
                                else {
                                    if ($('#ContentPlaceHolder1_txtTenHangHoa2').val().trim().length <= 0 || $('#ContentPlaceHolder1_txtIDHangHoa2').val().trim().length <= 0 || $("#ContentPlaceHolder1_txtDonGiaXuat2").val().length <= 0 || $('#ContentPlaceHolder1_txtThanhTien2').val().trim().length <= 0) {
                                        $('#ContentPlaceHolder1_txtLoiNhuan2').val("");
                                    }
                                    else {
                                        var IDHangHoa = $('#ContentPlaceHolder1_txtIDHangHoa2').val();
                                        var xmlhttp;
                                        if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                            xmlhttp = new XMLHttpRequest();
                                        }
                                        else {// code for IE6, IE5
                                            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                                        }
                                        xmlhttp.onreadystatechange = function () {
                                            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                                                if (xmlhttp.responseText != "False") {
                                                    var SoLuongXuatRa = $('#ContentPlaceHolder1_txtSoLuong2').val().replace(/\./g, '').replace(/\,/g, '');
                                                    // alert($('#ContentPlaceHolder1_txtDonGiaNhap2').val());
                                                    var DonGiaNhapHang = $('#ContentPlaceHolder1_txtDonGiaNhap2').val().replace(/\./g, '').replace(/\,/g, '');//xmlhttp.responseText.trim().replace(/\./g, '').replace(/\,/g, '');
                                                    // alert(DonGiaNhapHang+"-"+TongTien);
                                                    var LoiNhuan = TongTien - (parseInt((parseInt(SoLuongXuatRa) * parseInt(DonGiaNhapHang))));

                                                    $('#ContentPlaceHolder1_txtLoiNhuan2').val(LoiNhuan.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                                                }
                                                else
                                                    alert("Lỗi hãy kiểm tra lại mọi thông tin !")
                                            }
                                        }
                                        xmlhttp.open("GET", "../Ajax.aspx?Action=LayGiaNhapGanNhat&IDHangHoa=" + IDHangHoa, true);
                                        xmlhttp.send();
                                    }
                                }

                            }
                            );

                            $('#ContentPlaceHolder1_txtSoLuongXuat').keyup(function () {
                                $('#ContentPlaceHolder1_txtSoLuongXuat').val($('#ContentPlaceHolder1_txtSoLuongXuat').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                            });
                        }
                        //

                        function LoadChiTietPhieuXuat(IDPhieuXuat) {

                            var xmlhttp;
                            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                xmlhttp = new XMLHttpRequest();
                            }
                            else {// code for IE6, IE5
                                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                            }
                            xmlhttp.onreadystatechange = function () {
                                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                                    if (xmlhttp.responseText != "") {
                                        //  DongXemDungCu2();
                                        //   DongXemDungCu();
                                        $("#xh").html(xmlhttp.responseText);

                                    }
                                    else
                                        alert("Lỗi !")
                                }
                            }
                            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadChiTietPhieuXuat&IDPhieuXuat=" + IDPhieuXuat, true);
                            xmlhttp.send();

                        }
                        //
                        function ABCAutocomplete() {
                            var xmlhttp;
                            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                xmlhttp = new XMLHttpRequest();
                            }
                            else {// code for IE6, IE5
                                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                            }
                            xmlhttp.onreadystatechange = function () {
                                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                                    if (xmlhttp.responseText != "") {
                                        //alert(xmlhttp.responseText);
                                        var txt = xmlhttp.responseText
                                              .replace(/[\"]/g, '\\"')
                                              .replace(/[\\]/g, '\\\\')
                                              .replace(/[\/]/g, '\\/')
                                              .replace(/[\b]/g, '\\b')
                                              .replace(/[\f]/g, '\\f')
                                              .replace(/[\n]/g, '\\n')
                                              .replace(/[\r]/g, '\\r')
                                              .replace(/[\t]/g, '\\t');
                                        listKhachHangAutocomplete = eval("(" + txt + ")");
                                        $("#ContentPlaceHolder1_txtTenHangHoa").autocomplete({
                                            minLength: 0,
                                            source: listKhachHangAutocomplete,
                                            appendTo: '#lightXemQuyCach',
                                            focus: function (event, ui) {
                                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.label);
                                                return false;
                                            },
                                            select: function (event, ui) {

                                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.value);

                                                $("#ContentPlaceHolder1_txtIDHangHoa").val(ui.item.id);


                                                var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa").val();
                                                var IDKhachHang = $("#ContentPlaceHolder1_txtIDKhachHang").val();
                                                // alert(IDKhachHang);
                                                LoadMauSize(IDHangHoa);


                                                if (IDHangHoa.length > 0) {
                                                    var IDKhachHang = $("#ContentPlaceHolder1_txtIDKhachHang").val();
                                                    var xmlhttp2;
                                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                                        xmlhttp2 = new XMLHttpRequest();
                                                    }
                                                    else {// code for IE6, IE5
                                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                                    }
                                                    xmlhttp2.onreadystatechange = function () {
                                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                                            //alert(xmlhttp2.responseText);
                                                            if (xmlhttp2.responseText != "False") {

                                                                $("#ContentPlaceHolder1_txtDonGiaXuat").val(xmlhttp2.responseText);


                                                            }
                                                            else {

                                                                $("#ContentPlaceHolder1_txtDonGiaXuat").val("");

                                                            }

                                                        }
                                                    }
                                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadLenGiaTheoKhachHang&IDKhachHang=" + IDKhachHang + "&IDHangHoa=" + IDHangHoa, true);
                                                    xmlhttp2.send();
                                                }


                                                return false;
                                            }
                                        })
                                    }
                                    else {
                                        alert("Lỗi tải !")
                                    }

                                }
                            }
                            xmlhttp.open("GET", "../Ajax.aspx?Action=ABCAutocomplete", true);
                            xmlhttp.send();
                        }
                        //
                        function LoadLenKhachHangAutocomplete() {
                            var xmlhttp;
                            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                xmlhttp = new XMLHttpRequest();
                            }
                            else {// code for IE6, IE5
                                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                            }
                            xmlhttp.onreadystatechange = function () {
                                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                                    if (xmlhttp.responseText != "") {
                                        //alert(xmlhttp.responseText);
                                        var txt = xmlhttp.responseText
                                              .replace(/[\"]/g, '\\"')
                                              .replace(/[\\]/g, '\\\\')
                                              .replace(/[\/]/g, '\\/')
                                              .replace(/[\b]/g, '\\b')
                                              .replace(/[\f]/g, '\\f')
                                              .replace(/[\n]/g, '\\n')
                                              .replace(/[\r]/g, '\\r')
                                              .replace(/[\t]/g, '\\t');
                                        // alert(txt);
                                        listKhachHangAutocomplete = eval("(" + txt + ")");
                                        $("#ContentPlaceHolder1_txtTenKhachHang").autocomplete({
                                            minLength: 0,
                                            source: listKhachHangAutocomplete,
                                            appendTo: '#lightXemQuyCach',
                                            focus: function (event, ui) {
                                                $("#ContentPlaceHolder1_txtTenKhachHang").val(ui.item.label);
                                                return false;
                                            },
                                            select: function (event, ui) {
                                                $("#ContentPlaceHolder1_txtLoiNhuan").val("");
                                                $("#ContentPlaceHolder1_txtTenKhachHang").val(ui.item.show);

                                                $("#ContentPlaceHolder1_txtIDKhachHang").val(ui.item.id);
                                                $("#ContentPlaceHolder1_txtTenPhongBan").val(ui.item.tenPhongBan);
                                                $("#ContentPlaceHolder1_txtIDPhongBan").val(ui.item.idPhongBan);
                                                $("#ContentPlaceHolder1_txtTenCuaHang").val(ui.item.tenCuaHang);
                                                $("#ContentPlaceHolder1_txtIDCuaHang").val(ui.item.idCuaHang);
                                                var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa").val();
                                                var IDKhachHang = $("#ContentPlaceHolder1_txtIDKhachHang").val();
                                                if (IDHangHoa.length > 0/* &&  $("#ContentPlaceHolder1_txtTenHangHoa").val().length > 0*/) {
                                                    var xmlhttp2;
                                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                                        xmlhttp2 = new XMLHttpRequest();
                                                    }
                                                    else {// code for IE6, IE5
                                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                                    }
                                                    xmlhttp2.onreadystatechange = function () {
                                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                                            if (xmlhttp2.responseText != "False") {

                                                                $("#ContentPlaceHolder1_txtDonGiaXuat").val(xmlhttp2.responseText);
                                                                if ($("#ContentPlaceHolder1_txtSoLuong").val().length > 0) {
                                                                    var iSoLuong = $("#ContentPlaceHolder1_txtSoLuong").val().replace(/\./g, '').replace(/\,/g, '');
                                                                    var sluong = parseInt(iSoLuong);

                                                                    var iSoLuong2 = $("#ContentPlaceHolder1_txtDonGiaXuat").val().replace(/\./g, '').replace(/\,/g, '');
                                                                    var sluong2 = parseInt(iSoLuong2);

                                                                    var tong = sluong * sluong2;
                                                                    $("#ContentPlaceHolder1_txtThanhTien").val(tong);
                                                                    $('#ContentPlaceHolder1_txtThanhTien').val($('#ContentPlaceHolder1_txtThanhTien').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                                                                    var xmlhttp23;
                                                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                                                        xmlhttp23 = new XMLHttpRequest();
                                                                    }
                                                                    else {// code for IE6, IE5
                                                                        xmlhttp23 = new ActiveXObject("Microsoft.XMLHTTP");
                                                                    }
                                                                    xmlhttp23.onreadystatechange = function () {
                                                                        if (xmlhttp23.readyState == 4 && xmlhttp2.status == 200) {
                                                                            var ggianhap = xmlhttp23.responseText.replace(/\./g, '').replace(/\,/g, '');
                                                                            var tongnhap = tong - (parseInt(ggianhap) * sluong);
                                                                            $("#ContentPlaceHolder1_txtLoiNhuan").val(tongnhap);
                                                                            $("#ContentPlaceHolder1_txtLoiNhuan").val($('#ContentPlaceHolder1_txtLoiNhuan').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                                                                        }
                                                                    }
                                                                    xmlhttp23.open("GET", "../Ajax.aspx?Action=LayDGBQGQ&IDHangHoa=" + IDHangHoa, true);
                                                                    xmlhttp23.send();
                                                                    //alert('a')
                                                                }

                                                            }
                                                            else {
                                                                //alert("Lỗi tải 23!")
                                                                $("#ContentPlaceHolder1_txtDonGiaXuat").val("");
                                                                if ($("#ContentPlaceHolder1_txtDonGiaXuat").val().length <= 0) {
                                                                    $("#ContentPlaceHolder1_txtSoLuong").val("");
                                                                    $("#ContentPlaceHolder1_txtThanhTien").val("");
                                                                    $("#ContentPlaceHolder1_txtLoiNhuan").val("");
                                                                }
                                                            }

                                                        }
                                                    }
                                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadLenGiaTheoKhachHang&IDKhachHang=" + IDKhachHang + "&IDHangHoa=" + IDHangHoa, true);
                                                    xmlhttp2.send();

                                                }

                                                //$( "#results").text($("#topicID").val());    
                                                //alert($("#hdIdKhuVuc").val());
                                                return false;
                                            }
                                        })
                                    }
                                    else {
                                        alert("Lỗi tải 2!")
                                    }

                                }
                            }
                            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadLenKhachHangAutocomplete", true);
                            xmlhttp.send();
                        }
                        //
                        function MoXemQuyCach() {
                            $("#ContentPlaceHolder1_txtTenHangHoa").val("");
                            $("#ContentPlaceHolder1_txtIDHangHoa").val("");



                            $("#ContentPlaceHolder1_txtMauSac").val("");

                            $("#ContentPlaceHolder1_txtSoLuong").val("0");

                            $("#ContentPlaceHolder1_txtSize").val("");
                            $("#ContentPlaceHolder1_txtGhiChuChiTietXuat").val("");

                            document.getElementById('lightXemQuyCach').style.display = 'block';
                            document.getElementById('fadeXemQuyCach').style.display = 'block';
                        }
                        function Xoa() {
                            if ($("#ContentPlaceHolder1_txtTenKhachHang").val().trim().length <= 0) {
                                $("#ContentPlaceHolder1_txtTenPhongBan").val("");
                                $("#ContentPlaceHolder1_txtIDPhongBan").val("");
                                $("#ContentPlaceHolder1_txtTenCuaHang").val("");
                                $("#ContentPlaceHolder1_txtIDCuaHang").val("");
                                $("#ContentPlaceHolder1_txtLoiNhuan").val("");

                            }
                            else {

                            }

                        }
                        function Xoa3() {
                            if ($("#ContentPlaceHolder1_txtTenHangHoa").val().trim().length <= 0) {
                                $("#ContentPlaceHolder1_txtThanhTien").val("");
                                $("#ContentPlaceHolder1_txtLoiNhuan").val("");
                                $("#ContentPlaceHolder1_txtDonGiaXuat").val("");
                                $("#ContentPlaceHolder1_txtDonGiaNhap").val("");
                            }
                            else {

                            }

                        }
                        function Xoa4() {
                            if ($("#ContentPlaceHolder1_txtTenHangHoa2").val().trim().length <= 0) {
                                $("#ContentPlaceHolder1_txtThanhTien2").val("");
                                $("#ContentPlaceHolder1_txtLoiNhuan2").val("");
                                $("#ContentPlaceHolder1_txtDonGiaXuat2").val("");
                                $("#ContentPlaceHolder1_txtDonGiaNhap2").val("");
                                $("#ContentPlaceHolder1_IDChiTietPhieuNhap2").val("");
                            }
                            else {

                            }

                        }
                        function Xoa2() {
                            if ($("#ContentPlaceHolder1_txtTenKhachHang2").val().trim().length <= 0) {
                                $("#ContentPlaceHolder1_txtTenPhongBan2").val("");
                                $("#ContentPlaceHolder1_txtIDPhongBan2").val("");
                                $("#ContentPlaceHolder1_txtTenCuaHang2").val("");
                                $("#ContentPlaceHolder1_txtIDCuaHang2").val("");
                                $("#ContentPlaceHolder1_txtLoiNhuan2").val("");
                            }
                            else {

                            }

                        }
                        function DongXemQuyCach() {
                            document.getElementById('lightXemQuyCach').style.display = 'none';
                            document.getElementById('fadeXemQuyCach').style.display = 'none';
                        }

                        function MoXemQuyCach2() {


                            document.getElementById('lightXemQuyCach2').style.display = 'block';
                            document.getElementById('fadeXemQuyCach2').style.display = 'block';
                        }
                        function DongXemQuyCach2() {
                            document.getElementById('lightXemQuyCach2').style.display = 'none';
                            document.getElementById('fadeXemQuyCach2').style.display = 'none';
                        }
                        function TinhTien() {
                            $('#ContentPlaceHolder1_txtSoLuong').keyup(function () {
                                $('#ContentPlaceHolder1_txtSoLuong').val($('#ContentPlaceHolder1_txtSoLuong').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                            }
                            );

                            $('#ContentPlaceHolder1_txtTienKhachThanhToan').keyup(function () {
                                $('#ContentPlaceHolder1_txtTienKhachThanhToan').val($('#ContentPlaceHolder1_txtTienKhachThanhToan').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                            }
                           );

                            $('#ContentPlaceHolder1_txtGiaBanChoKhach').keyup(function () {
                                $('#ContentPlaceHolder1_txtGiaBanChoKhach').val($('#ContentPlaceHolder1_txtGiaBanChoKhach').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                            }
                         );


                        }

                        function Dong1() {
                            document.getElementById('light1').style.display = 'none';
                            document.getElementById('fade1').style.display = 'none';
                        }
                        function Mo1() {
                            document.getElementById('light1').style.display = 'block';
                            document.getElementById('fade1').style.display = 'block';
                        }

                        function DongfadeSuaNhanhHangHoa() {
                            document.getElementById('lightSuaNhanhHangHoa').style.display = 'none';
                            document.getElementById('fadeSuaNhanhHangHoa').style.display = 'none';
                        }
                        function MoSuaNhanhHangHoa() {
                            document.getElementById("divBangGiaMauSuaNhanhHangHoa").style.display = 'none';
                            LoadLoaiHangHoaSuaNhanh();
                            document.getElementById('lightSuaNhanhHangHoa').style.display = 'block';
                            document.getElementById('fadeSuaNhanhHangHoa').style.display = 'block';
                        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Main content -->
        <div class="title" id="dvTitle" runat="server">SỬA THÔNG TIN BÁN HÀNG</div>
        <div class="title1" id="NgayTieuDe" runat="server"><a href="DanhMucXuatHang.aspx"><i class="fa fa-step-backward"></i>Danh sách bán hàng</a></div>
        <section class="content">
            <div class="box">
                <div class="box-body">

                    <form class="form-horizontal" runat="server">
                        <table style="width: 100%;" border="0">
                            <tr>
                                <td style="width: 30%;" valign="top">
                                    <div class="box" style="padding: 4px 4px 4px 4px;">
                                        <b>Mã phiếu xuất(*):</b>
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaPhieuXuat" runat="server" name="Content.ContentName" type="text" value="" />&nbsp;
                                        <br />
                                        <b>Khách hàng(*):</b>
                                        <input placeholder="--Chọn--" class="form-control" data-val="true" data-val-required="" id="txtKhachHang" runat="server" name="Content.ContentName" type="text" value="" readonly="true" />
                                        <input placeholder="--Chọn--" class="form-control" data-val="true" data-val-required="" id="txtIDKhachHang" runat="server" name="Content.ContentName" type="hidden" value="" /><br />
                                        <b>Ngày bán(*):</b>
                                        <input class="form-control" data-val="true" data-val-required="" id="txtNgayXuat" runat="server" name="Content.ContentName" type="text" value="" />&nbsp;<br />
                                        <b>Xuất từ kho(*):</b>
                                        <input class="form-control" data-val="true" data-val-required="" id="txtKho" runat="server" name="Content.ContentName" type="hidden" value="" placeholder="--Chọn--" />
                                        <select class="form-control" data-val="true" data-val-required="" id="txtIDKho" runat="server" name="Content.ContentName" type="text"></select>
                                        <b>Ghi chú:</b>
                                        <textarea class="form-control" id="txtGhiChu" name="Content.ContentName" runat="server"></textarea>
                                        <br />

                                        <div class="form-group" style="display: none;">
                                            <div class="row">
                                                <div class="dvnull">&nbsp;</div>
                                                <div class="coninput1">
                                                    <div class="titleinput"><b></b></div>
                                                    <div class="txtinput">
                                                    </div>
                                                </div>
                                                <div class="coninput2">
                                                    <div class="titleinput"><b></b></div>
                                                    <div class="txtinput">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group" style="display: none;">
                                            <div class="row">
                                                <div class="dvnull">&nbsp;</div>
                                                <div class="coninput1">
                                                    <div class="titleinput"></div>
                                                    <div class="txtinput">
                                                    </div>
                                                </div>
                                                <div class="coninput2">
                                                    <div class="titleinput"></div>
                                                    <div class="txtinput">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group" style="display: none;">
                                            <label class="col-md-2 control-label" for="Content_ContentName"></label>
                                            <div class="col-md-10">
                                            </div>
                                        </div>
                                        <div class="box-footer" style="display: none;">
                                        </div>
                                    </div>
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td valign="top">
                                    <div class="box" style="padding: 4px 4px 4px 4px;">


                                        <div style="text-align: center; font-weight: bold;">THÊM HÀNG HÓA</div>
                                        <br />
                                        <div id="dv2" style="text-align: center">


                                            <div>
                                                <div class="row">
                                                    <div class="dvnull">&nbsp;</div>
                                                    <div class="coninput1" style="display: none;">

                                                        <div class="txtinput">
                                                            <center>    <select onchange="LoadLoaiHang();" class="form-control" data-val="true" data-val-required="" id="Select1" runat="server" name="Content.ContentName"  >
                                                   
                                                      </select></center>
                                                        </div>
                                                    </div>
                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>H. hóa(*): </b></div>
                                                        <div class="txtinput">

                                                            <center>      <input placeholder="--Chọn--" type="text" class="form-control" data-val="true" data-val-required="" id="txtLoaiHangHoa" runat="server" name="Content.ContentName" />
                                                   
                                                     </center>
                                                            <input type="hidden" class="form-control" data-val="true" data-val-required="" id="slLoaiHangHoa" runat="server" name="Content.ContentName" />


                                                        </div>
                                                    </div>
                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>Size(*): </b></div>
                                                        <div class="txtinput">

                                                            <center>      <select onchange="LoadLenMau();" class="form-control" data-val="true" data-val-required="" id="slSize" runat="server" name="Content.ContentName"  >
                                                   
                                                      </select>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div>
                                                <div class="row">
                                                    <div class="dvnull">&nbsp;</div>

                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>Màu(*):</b></div>
                                                        <div class="txtinput">




                                                            <center>      <select  class="form-control" data-val="true" data-val-required="" id="slMauSac" runat="server" name="Content.ContentName"  >
                                                   
                                                      </select></center>
                                                            </center>
                                                        </div>
                                                    </div>
                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>SL(*): </b></div>
                                                        <div class="txtinput">

                                                            <center> 
                                      <input  class="form-control" data-val="true" data-val-required="" id="txtSoLuongXuat" runat="server" name="Content.ContentName" type="text" value="0" onkeyup="TinhTien2();" />

                                        </center>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <br />
                                            <div>
                                                <div class="row">
                                                    <div class="dvnull">&nbsp;</div>

                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>Giá bán(*): </b></div>
                                                        <div class="txtinput">
                                                            <center>      <input onkeyup="TinhTien2();"  class="form-control" data-val="true" data-val-required="" id="txtGiaDeNghi" runat="server" name="Content.ContentName"  />
                                                   
                                                     
                                   </center>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>



                                            <br />
                                            <center> <a style="cursor:pointer;" onclick='ThemTheoLoaiHangHoa();' class="btn btn-primary btn-flat"><div >Thêm</div></a></center>
                                            <br />




                                        </div>





                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="Content_ContentName"></label>
                                            <div class="col-md-10">
                                                <div>
                                                    <input type="button" onclick="MoXemQuyCach()" value="Thêm chi tiết hàng hóa" class="btn btn-primary btn-flat" style="width: 210px; display: none;" />
                                                    <input type="button" onclick="Mo()" value="Thêm hàng hóa" class="btn btn-primary btn-flat" style="width: 210px; display: none;" />
                                                    <input type="button" onclick='Mo1();' value="Thêm nhanh hàng hóa" class="btn btn-primary btn-flat" style="width: 210px;" />
                                                    <input type="button" onclick='MoSuaNhanhHangHoa();' value="Sửa hàng hóa" class="btn btn-primary btn-flat" style="width: 210px;" />

                                                </div>

                                                <div id="xh">
                                                </div>
                                                <div class="form-group">
                                                    <div id="row">
                                                        <div class="coninput2">
                                                            <div class="titleinput"></div>
                                                            <div class="txtinput">
                                                                <b>Tổng tiền đơn hàng:</b>
                                                                <input readonly="true" class="form-control" data-val="true" data-val-required="" id="txtTongTienDonHang" runat="server" name="Content.ContentName" type="text" value="0" />
                                                                <br />
                                                                <b>Tổng tiền phải trả:</b>
                                                                <input readonly="true" class="form-control" data-val="true" data-val-required="" id="txtTongTienPhaiTra" runat="server" name="Content.ContentName" type="text" value="0" />
                                                            </div>
                                                        </div>
                                                        <div class="coninput2">
                                                            <div class="titleinput"></div>
                                                            <div class="txtinput">

                                                                <b>Tổng tiền khách nợ:</b>
                                                                <input class="form-control" readonly="true" data-val="true" data-val-required="" id="txtTongTienKhachNo" runat="server" name="Content.ContentName" type="text" value="0" />
                                                                <br />
                                                                <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtTienKhachThanhToan" runat="server" name="Content.ContentName" type="text" value="0" style="display: none;" />
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <input type="checkbox" id="CongNo" runat="server" onchange="ThayDoiThanhToan2();" />
                                                                            Công nợ</td>
                                                                        <td>
                                                                            <input type="checkbox" id="ThanhToanTienMat" runat="server" onchange="ThayDoiThanhToan();" />
                                                                            Thanh toán tiền mặt
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>





                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="coninput2">
                                                    <div class="titleinput"></div>
                                                    <div class="txtinput">
                                                    </div>
                                                </div>
                                                <div class="coninput2">
                                                    <div class="titleinput"></div>
                                                    <div class="txtinput">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                </td>
                            </tr>
                            <tr>
                                
                                <td style="width: 30%;visibility:hidden;" valign="top"> 
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: center; white-space: nowrap;">

                                    <center> <table>
                                 <tr>
                                     <td>
                                          <div runat="server" id="QuayLai">

                              <asp:LinkButton class="btn btn-primary btn-flat" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="glyphicon glyphicon-chevron-left"></i> Quay lại</asp:LinkButton>
                                          </div> 
                                     </td>
                                     <td>&nbsp;</td>
                                      <td>  <asp:Button ID="btLuu" runat="server" Text="SỬA" class="btn btn-primary btn-flat" OnClick="btLuu_Click" /></td>
                                      <td>&nbsp;</td>
                                      <td> <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" /></td>
                                     <td>&nbsp;</td>
                                     <td>  <a style='cursor:pointer;' class='btn btn-primary btn-flat' onclick='InChiTietVaSua("<%=Request.QueryString["IDPhieuXuat"].ToString().Trim()%>");'>IN CHI TIẾT</a></td>
                                 <td>&nbsp;</td>
                                     <td> <a style='cursor:pointer;' class='btn btn-primary btn-flat' onclick='InTongHopVaSua("<%=Request.QueryString["IDPhieuXuat"].ToString().Trim()%>");'>IN PHIẾU TỔNG HỢP</a></td>
                                 </tr>
                             </table>
                            
                               </center>





                                </td>
                            </tr>
                        </table>
                    </form>

                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>


    <div id="lightSuaNhanhHangHoa" class="white_content" style="top: 10%; width: 80%; left: 15%; height: 70%;">
        <div class="box">
            <div class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">SỬA HÀNG HÓA</div>
                <div style="padding: 10px; text-align: center">




                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Hàng hóa(*)</b></div>
                                <div class="txtinput">
                                    <center>      
                                       <input placeholder="--Chọn hàng--" type="text" class="form-control" data-val="true" data-val-required="" id="txtLoaiHangHoaSuaNhanh" runat="server" name="Content.ContentName"  />
                                       <input type="hidden" class="form-control" data-val="true" data-val-required="" id="txtIDLoaiHangHoaSuaNhanh" runat="server" name="Content.ContentName"  />
                                                   
                                                      </center>

                                </div>

                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Giá bán (*):</b></div>
                                <div class="txtinput">
                                    <center>      
                                       <input onkeyup="TinhTien();"  class="form-control"  id="txtGiaBanChoKhachSuaNhanhHangHoa" runat="server" name="Content.ContentName" />

                                      
                                    
                                                   
                                                      </center>

                                </div>

                            </div>
                            <div class="coninput1" style="display: none">
                                <div class="titleinput"><b>Số lượng(*)</b></div>
                                <div class="txtinput">
                                    <center>      
                                     <input onkeyup="TinhTien2();" value="1" type="text" class="form-control" data-val="true" data-val-required=""  runat="server" name="Content.ContentName"  />
                                                
                                                      </center>

                                </div>

                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1" style="display: none;">
                                <div class="titleinput"><b>Size</b></div>
                                <div class="txtinput">
                                    <center>      
                                       <select  class="form-control"  runat="server" name="Content.ContentName" onchange="ChonSize()">

                                       </select>
                                    
                                                   
                                                      </center>

                                </div>

                            </div>


                        </div>
                    </div>



                    <div id="divBangGiaMauSuaNhanhHangHoa" style="display: none;">


                        <!-- Get -->

                    </div>

                    <div id="divBangChoDeSuaNhanhHangHoa" style="display: none;">


                        <!-- Get -->

                    </div>
                    <br />
                    <center> <a style="cursor:pointer;" onclick='CapNhatSoLuongCookieSuaNhanh();' class="btn btn-primary btn-flat"><div >CẬP NHẬT SỐ LƯỢNG</div></a></center>
                    <br />


                    <center> 
                       
                       
                       <a style="cursor:pointer;" onclick='SuaLaiCookieNhanhHangHoa();' class="btn btn-primary btn-flat"><div >Sửa</div></a></center>


                </div>
            </div>
        </div>

    </div>

    <div id="fadeSuaNhanhHangHoa" onclick="DongfadeSuaNhanhHangHoa()" class="black_overlay"></div>


    <!--popup thêm theo loại-->
    <div id="light1" class="white_content" style="top: 10%; width: 80%; left: 15%; height: 70%;">
        <div class="box">
            <div id="dv1" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">THÊM NHANH HÀNG HÓA</div>
                <div id="dv11" style="padding: 10px; text-align: center">




                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Hàng hóa(*)</b></div>
                                <div class="txtinput">
                                    <center>      
                                       <input placeholder="--Chọn hàng--" type="text" class="form-control" data-val="true" data-val-required="" id="txtShowLoaiHangCapCao" runat="server" name="Content.ContentName"  />
                                       <input type="hidden" class="form-control" data-val="true" data-val-required="" id="txtLoaiHangCapCao" runat="server" name="Content.ContentName"  />
                                                   
                                                      </center>

                                </div>

                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Giá bán (*):</b></div>
                                <div class="txtinput">
                                    <center>      
                                       <input onkeyup="TinhTien();"  class="form-control"  id="txtGiaBanChoKhach" runat="server" name="Content.ContentName" />

                                      
                                    
                                                   
                                                      </center>

                                </div>

                            </div>
                            <div class="coninput1" style="display: none">
                                <div class="titleinput"><b>Số lượng(*)</b></div>
                                <div class="txtinput">
                                    <center>      
                                     <input onkeyup="TinhTien2();" value="1" type="text" class="form-control" data-val="true" data-val-required="" id="txtSoLuongThem" runat="server" name="Content.ContentName"  />
                                                
                                                      </center>

                                </div>

                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1" style="display: none;">
                                <div class="titleinput"><b>Size</b></div>
                                <div class="txtinput">
                                    <center>      
                                       <select  class="form-control"  id="txtMauThemNhanh" runat="server" name="Content.ContentName" onchange="ChonSize()">

                                       </select>
                                    
                                                   
                                                      </center>

                                </div>

                            </div>


                        </div>
                    </div>



                    <div id="divBangGiaMau">


                        <!-- Get -->

                    </div>

                    <div id="divBangChoDe" style="display: none;">


                        <!-- Get -->

                    </div>
                    <br />
                    <center> <a style="cursor:pointer;" onclick='LoadLaiSoLuongLanNua();' class="btn btn-primary btn-flat"><div >CẬP NHẬT SỐ LƯỢNG</div></a></center>
                    <br />


                    <center> 
                       
                       
                       <a style="cursor:pointer;" onclick='ThemTheoLoaiHangCapCaoPhieuXuat();' class="btn btn-primary btn-flat"><div >Thêm</div></a></center>


                </div>
            </div>
        </div>

    </div>

    <div id="fade1" onclick="Dong1()" class="black_overlay"></div>
    <!--Popup xem quy cách-->
    <div id="lightXemQuyCach" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvQuyCach" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">THÊM CHI TIẾT XUẤT HÀNG</div>
                <div id="dvXemQuyCach" style="padding: 10px; text-align: center">
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>


                            <div class="coninput1">
                                <div class="titleinput"><b>Tên hàng hóa(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtTenHangHoa" data-val="true" data-val-required="" name="Content.ContentName" runat="server" type="text" value="" placeholder="--Chọn--" />
                                    <input id="txtIDHangHoa" type="hidden" name="Content.ContentName" runat="server" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Số lượng(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtSoLuong" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="0" runat="server" onkeyup="TinhTien();" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>


                            <div class="coninput1">
                                <div class="titleinput"><b>Màu(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtMauSac" data-val="true" data-val-required="" name="Content.ContentName" runat="server" type="text" readonly="true" />

                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Size(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtSize" data-val="true" data-val-required="" name="Content.ContentName" type="text" readonly="true" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Đơn giá xuất(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtDonGiaXuat" readonly="true" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" runat="server" />
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Ghi chú:</b></div>
                                <div class="txtinput">
                                    <input id="txtGhiChuChiTietXuat" class="form-control" data-val="true" data-val-required="" runat="server" name="Content.ContentName" />
                                </div>
                            </div>
                            <input type="hidden" id="txtIDChiTietPhieuXuat" runat="server" />

                        </div>
                    </div>
                    <center>
                       <a class="btn btn-primary btn-flat" style="cursor:pointer;" onclick="ThemChiTietPhieuXuat();">Thêm</a>
                    </center>
                    <div style="text-align: center">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="fadeXemQuyCach" onclick="DongXemQuyCach()" class="black_overlay"></div>
    <!--End popup--->


    <!--Popup xem quy cách-->
    <div id="lightXemQuyCach2" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvQuyCach2" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">SỬA CHI TIẾT XUẤT HÀNG</div>
                <div id="dvXemQuyCach2" style="padding: 10px; text-align: center">





                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>


                            <div class="coninput1">
                                <div class="titleinput"><b>Tên hàng hóa(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtTenHangHoa2" data-val="true" data-val-required="" name="Content.ContentName" runat="server" type="text" value="" placeholder="--Chọn--" />
                                    <input id="txtIDHangHoa2" type="hidden" name="Content.ContentName" runat="server" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Số lượng(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtSoLuong2" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="0" runat="server" onkeyup="TinhTien();" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>


                            <div class="coninput1">
                                <div class="titleinput"><b>Màu(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtMauSac2" data-val="true" data-val-required="" name="Content.ContentName" runat="server" type="text" readonly="true" />

                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Size(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtSize2" data-val="true" data-val-required="" name="Content.ContentName" type="text" readonly="true" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Đơn giá xuất(*):</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtDonGiaXuat2" readonly="true" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" runat="server" />
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Ghi chú:</b></div>
                                <div class="txtinput">
                                    <input id="txtGhiChuChiTietXuat2" class="form-control" data-val="true" data-val-required="" runat="server" name="Content.ContentName" />
                                    <input id="IDChiTietPhieuXuat" type="hidden" class="form-control" data-val="true" data-val-required="" runat="server" name="Content.ContentName" />
                                </div>
                            </div>


                        </div>
                    </div>



                    <center>
                     <a class="btn btn-primary btn-flat" style="cursor:pointer;" onclick="SuaChiTietPhieuXuat();">SỬA</a>    
                        </center>



                </div>
            </div>

        </div>
    </div>
    <div id="fadeXemQuyCach2" onclick="DongXemQuyCach2()" class="black_overlay"></div>
    <!--End popup--->
    <div id="light" class="white_content" style="top: 9%; width: 40%; left: 35%; height: 85%;">
        <div class="box">
            <div id="dv" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">THÊM HÀNG HÓA</div>
                <div id="dv2" style="padding: 10px; text-align: center">




                    <div class="form-group">
                        <label>Loại hàng (*)</label>

                        <center>      <select onchange="LoadLoaiHang();" class="form-control" data-val="true" data-val-required="" id="slLoaiHangCapCao" runat="server" name="Content.ContentName"  >
                                                   
                                                      </select></center>


                    </div>
                    <div class="form-group">
                        <label>Hàng hóa(*)</label>

                        <center>      </center>


                    </div>
                    <div class="form-group">
                        <label>Size(*)</label>

                        <center>     </center>


                    </div>
                    <div class="form-group">
                        <label>Màu(*)</label>

                        <center>     </center>


                    </div>

                    <div class="form-group">
                        <label>Số lượng(*)</label>

                        <center> 
                                        

</center>


                    </div>



                </div>
            </div>
        </div>

    </div>

    <div id="fade" onclick="Dong()" class="black_overlay"></div>
    <script>
        function ThayDoiThanhToan() {
            if (document.getElementById("ContentPlaceHolder1_ThanhToanTienMat").checked == false) {
                document.getElementById("ContentPlaceHolder1_ThanhToanTienMat").checked = true;
            }
            document.getElementById("ContentPlaceHolder1_CongNo").checked = false;

            $('#ContentPlaceHolder1_txtTienKhachThanhToan').val($('#ContentPlaceHolder1_txtTongTienDonHang').val());
        }
        function ThayDoiThanhToan2() {


            if (document.getElementById("ContentPlaceHolder1_CongNo").checked == false) {
                document.getElementById("ContentPlaceHolder1_CongNo").checked = true;
            }

            document.getElementById("ContentPlaceHolder1_ThanhToanTienMat").checked = false;
            $('#ContentPlaceHolder1_txtTienKhachThanhToan').val('0');
        }


        function CapNhatSoLuongCookieSuaNhanh() {

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText.split('@');
                        var tong = 0;
                        var chuoigan = "";
                        for (var i = 0; i < txt.length - 1; i++) {
                            var getSoLuong = $('#' + txt[i]).val().replace(/\./g, '').replace(/\,/g, '');
                            if (getSoLuong.trim().length > 0) {
                                var sl = parseFloat(getSoLuong);
                                tong += sl;

                                chuoigan += txt[i] + "_" + getSoLuong;
                            }
                            else chuoigan += txt[i] + "_0";

                            chuoigan += "@";
                        }
                        ganlai(chuoigan);


                    }

                }
            }
            xmlhttp.open("GET", "../Ajax7.aspx?Action=CapNhatSoLuongCookieSuaNhanh", true);
            xmlhttp.send();
        }

        function ganlai(chuoigan) {

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);

                    }

                }
            }
            xmlhttp.open("GET", "../Ajax7.aspx?Action=ganlai&chuoigan=" + chuoigan, true);
            xmlhttp.send();
        }
        function SuaLaiCookieNhanhHangHoa() {
            CapNhatSoLuongCookieSuaNhanh();
            if (true) {
                var IDPhieuXuat = '<%=Request.QueryString["IDPhieuXuat"].Trim()%>';
                var IDLoaiHangHoa = $('#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh').val();
                var GiaBan = $('#ContentPlaceHolder1_txtGiaBanChoKhachSuaNhanhHangHoa').val().replace(/\./g, '').replace(/\,/g, '');
                var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val()
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText != "") {
                            //alert(xmlhttp.responseText);
                            DongfadeSuaNhanhHangHoa();


                            LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                            TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                            TongTienKhachNo();
                            CongLai();
                        }
                        else {

                        }

                    }
                }
                xmlhttp.open("GET", "../Ajax7.aspx?Action=SuaLaiCookieNhanhHangHoa&IDPhieuXuat=" + IDPhieuXuat + "&IDLoaiHangHoa=" + IDLoaiHangHoa + "&GiaBan=" + GiaBan + "&IDKhachHang=" + IDKhachHang, true);
                xmlhttp.send();
            }
        }

        function LoadLoaiHangHoaSuaNhanh() {
            var IDPhieuXuat = '<%=Request.QueryString["IDPhieuXuat"].Trim()%>';

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                               .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');

                        var listKhachHangAutocomplete = eval("(" + txt + ")");


                        $("#ContentPlaceHolder1_txtLoaiHangHoaSuaNhanh").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            appendTo: '#lightSuaNhanhHangHoa',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtLoaiHangHoaSuaNhanh").val(ui.item.value);
                                return false;
                            },
                            select: function (event, ui) {
                                document.getElementById("divBangGiaMauSuaNhanhHangHoa").style.display = 'block';
                                $("#ContentPlaceHolder1_txtLoaiHangHoaSuaNhanh").val(ui.item.value);
                                $("#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh").val(ui.item.id);
                                LoadLenGiaSuaNhanh();
                                if ($("#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh").val().trim().length > 0) {
                                    LoadLoaiHangHoaSuaNhanhTheoDon();
                                }
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        });

                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax7.aspx?Action=LoadLoaiHangHoaSuaNhanh&IDPhieuXuat=" + IDPhieuXuat, true);
            xmlhttp.send();
        }

        function LoadLoaiHangHoaSuaNhanhTheoDon() {
            var IDLoaiHangHoa = $("#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh").val().trim();
            var IDPhieuXuat = '<%=Request.QueryString["IDPhieuXuat"].Trim()%>';
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        $('#divBangGiaMauSuaNhanhHangHoa').html(xmlhttp.responseText);

                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax7.aspx?Action=LoadLenSizeVaMauTheoIDLoaiHangHoa&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDPhieuXuat=" + IDPhieuXuat, true);
            xmlhttp.send();
        }

        function CapNhatSoLuongSuaNhanh(sptn) {
            var Getsptn = sptn.toString();
            var SoLuong = $("#" + sptn).val().replace(/\./g, '').replace(/\,/g, '');
            if (SoLuong.trim().length <= 0) SoLuong = "0";

            if (isNaN(SoLuong)) {
                SoLuong = "0";
                $("#" + sptn).val("");

            }
            // alert(Getsptn + "~" + SoLuong);
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        var txt = xmlhttp.responseText.split('@');
                        var tong = 0;
                        for (var i = 0; i < txt.length - 1; i++) {
                            var getSoLuong = $('#' + txt[i]).val().replace(/\./g, '').replace(/\,/g, '');
                            if (getSoLuong.trim().length > 0) {
                                var sl = parseFloat(getSoLuong);
                                tong += sl;
                            }
                        }
                        $('#tongsl').html(tong);
                        $('#tongsl').html($('#tongsl').html().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                        // alert(xmlhttp.responseText);
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax7.aspx?Action=CapNhatSoLuongSuaNhanh&Getsptn=" + Getsptn + "&SoLuong=" + SoLuong, true);
            xmlhttp.send();
        }

        function ChonSize() {
            var idLoaiHangHoa = $("#ContentPlaceHolder1_txtLoaiHangCapCao").val();
            var idSize = $('#ContentPlaceHolder1_txtMauThemNhanh').val();


            // alert(idLoaiHangHoa + "," + idSize)


            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

                    $("#divBangGiaMau").html(xmlhttp.responseText);
                }
            }
            xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadMauTheoSize&idLoaiHangHoa=" + idLoaiHangHoa + "&idSize=" + idSize, true);
            xmlhttp.send();

        }


        function LoadLenMau() {
            var IDLoaiHangHoa = $('#ContentPlaceHolder1_slLoaiHangHoa').val();
            var IDSize = $('#ContentPlaceHolder1_slSize').val();
            if (IDLoaiHangHoa.trim().length <= 0 || IDSize.trim().length <= 0) {
                $('#ContentPlaceHolder1_slMauSac').empty();
            }
            else {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText != "") {
                            $('#ContentPlaceHolder1_slMauSac').empty();
                            var txt = xmlhttp.responseText.split('~');
                            for (var i = 0; i < txt.length - 1; i++) {
                                var chuoinho = txt[i].split('@');
                                $("#ContentPlaceHolder1_slMauSac").append("<option value='" + chuoinho[0] + "'>" + chuoinho[1] + "</option>");
                            }
                            // $("#ContentPlaceHolder1_slMauSac").append("<option value='' selected='selected'></option>");

                        }
                        else {
                            $('#ContentPlaceHolder1_slMauSac').empty();
                        }

                    }
                }
                xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadLenMau&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDSize=" + IDSize, true);
                xmlhttp.send();
            }
        }
        function LoadSize(IDLoaiHangHoa) {
            var IDLoaiHangHoa = $('#ContentPlaceHolder1_slLoaiHangHoa').val();
            if (IDLoaiHangHoa.trim().length <= 0) {
                $('#ContentPlaceHolder1_slSize').empty();
                $('#ContentPlaceHolder1_slMauSac').empty();
            }
            else {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText != "") {
                            $('#ContentPlaceHolder1_slSize').empty();
                            var txt = xmlhttp.responseText.split('~');
                            for (var i = 0; i < txt.length - 1; i++) {
                                var chuoinho = txt[i].split('@');
                                $("#ContentPlaceHolder1_slSize").append("<option value='" + chuoinho[0] + "'>" + chuoinho[1] + "</option>");
                            }
                            //  $("#ContentPlaceHolder1_slSize").append("<option value='' selected='selected'></option>");

                            LoadLenMau();

                        }
                        else {
                            $('#ContentPlaceHolder1_slSize').empty();
                        }

                    }
                }
                xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadSize&IDLoaiHangHoa=" + IDLoaiHangHoa, true);
                xmlhttp.send();
            }
        }
        function LoadLenSize() {
            LoadSize();
        }
        function LoadLoaiHang() {

            var IDLoaiHangCapCao = $('#ContentPlaceHolder1_slLoaiHangCapCao').val();
            if (IDLoaiHangCapCao.trim().length <= 0) {
                $('#ContentPlaceHolder1_slLoaiHangHoa').empty();
                $('#ContentPlaceHolder1_slSize').empty();
                $('#ContentPlaceHolder1_slMauSac').empty();
            }
            else {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText != "") {
                            $('#ContentPlaceHolder1_slLoaiHangHoa').empty();
                            var txt = xmlhttp.responseText.split('~');
                            for (var i = 0; i < txt.length - 1; i++) {
                                var chuoinho = txt[i].split('@');
                                $("#ContentPlaceHolder1_slLoaiHangHoa").append("<option value='" + chuoinho[0] + "'>" + chuoinho[1] + "</option>");
                            }
                            $("#ContentPlaceHolder1_slLoaiHangHoa").append("<option value='' selected='selected'></option>");

                        }
                        else {
                            $('#ContentPlaceHolder1_slSize').empty();
                        }

                    }
                }
                xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadLoaiHang&IDLoaiHangCapCao=" + IDLoaiHangCapCao, true);
                xmlhttp.send();
            }
        }
        function ThemTheoLoaiHangCapCaoPhieuXuat() {
            LoadLaiSoLuongLanNua();
            if (true) {

                try {
                    var IDMauSac = $('#ContentPlaceHolder1_txtMauThemNhanh').val();


                    var IDPhieuXuat = '<%= Request.QueryString["IDPhieuXuat"].Trim() %>';
                    var IDLoaiHangCapCao = $('#ContentPlaceHolder1_txtLoaiHangCapCao').val();
                    var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
                    var SoLuong = $('#ContentPlaceHolder1_txtSoLuongThem').val().replace(/\./g, '').replace(/\,/g, '');
                    var GiaBan = $('#ContentPlaceHolder1_txtGiaBanChoKhach').val().replace(/\./g, '').replace(/\,/g, '');

                    if ($('#ContentPlaceHolder1_txtShowLoaiHangCapCao').val().trim().length <= 0 || IDLoaiHangCapCao.trim().length <= 0 || GiaBan.trim().length <= 0) {
                        alert('Hãy chọn hàng hóa và nhập số lượng');
                    }
                    else {
                        if (isNaN(GiaBan)) {
                            alert(' giá bán phải là số');
                        }
                        else {
                            var xmlhttp;
                            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                xmlhttp = new XMLHttpRequest();
                            }
                            else {// code for IE6, IE5
                                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                            }
                            xmlhttp.onreadystatechange = function () {
                                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                                    //alert(xmlhttp.responseText);
                                    if (xmlhttp.responseText == "True") {

                                        LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                        Dong1();
                                        TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                        TongTienKhachNo();
                                        CongLai();
                                        document.getElementById('divBangChoDe').style.display = 'none';


                                    }
                                    else {
                                        alert('Lỗi internet hoặc có hàng hóa chưa được thiết lập giá cho khách này, hoặc có thể hàng hóa này có những mẫu size, màu không đủ số lượng để xuất !!!!')

                                    }

                                }
                            }
                            xmlhttp.open("GET", "../Ajax3.aspx?Action=ThemTheoLoaiHangCapCaoPhieuXuat&IDLoaiHangCapCao=" + IDLoaiHangCapCao + "&IDPhieuXuat=" + IDPhieuXuat + "&GiaBan=" + GiaBan + "&IDKhachHang=" + IDKhachHang, true);
                            xmlhttp.send();
                        }
                    }


                    <%--var RowCount = $('#tbMauSac').find('tr').length;

                var MangMau = [];

                if (RowCount > 0)
                {
                    for (i = 1; i < RowCount; i++) {
                        if( $("#mau" + i).val().trim() != "" )
                        {
                            MangMau.push($("#mau" + i).val().trim())
                        }
                        else
                        {
                            MangMau.push("0");
                        }
                    }
                }

             
              //  alert(MangMau);


              if (IDMauSac.trim().length <= 0) {

                    if ($('#ContentPlaceHolder1_txtShowLoaiHangCapCao').val().trim().length <= 0 || IDLoaiHangCapCao.trim().length <= 0 || SoLuong.trim().length <= 0 || GiaBan.trim().length <= 0) {
                        alert('Hãy chọn hàng hóa và nhập số lượng');
                    }
                    else {
                        if (isNaN(SoLuong) || isNaN(GiaBan)) {
                            alert('Số lượng và giá bán phải là số');
                        }
                        else {
                            var xmlhttp;
                            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                xmlhttp = new XMLHttpRequest();
                            }
                            else {// code for IE6, IE5
                                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                            }
                            xmlhttp.onreadystatechange = function () {
                                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                                    //   alert(xmlhttp.responseText);
                                    if (xmlhttp.responseText == "True") {
                                        //alert(xmlhttp.responseText);
                                        LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                        Dong1();
                                        TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                        TongTienKhachNo();
                                        CongLai();
                                        // CongLai();


                                    }
                                    else {
                                        alert('Lỗi internet hoặc có hàng hóa chưa được thiết lập giá cho khách này, hoặc có thể hàng hóa này có những mẫu size, màu không đủ số lượng để xuất !!')
                                        // alert(xmlhttp.responseText);
                                    }

                                }
                            }
                            xmlhttp.open("GET", "../Ajax.aspx?Action=ThemTheoLoaiHangCapCaoPhieuXuat&IDLoaiHangCapCao=" + IDLoaiHangCapCao + "&IDPhieuXuat=" + IDPhieuXuat + "&IDKhachHang=" + IDKhachHang + "&SoLuong=" + SoLuong + "&GiaBan=" + GiaBan + "&MauSac=" + MangMau, true);
                            xmlhttp.send();
                        }
                    }
                }
                else
                {
                    if ($('#ContentPlaceHolder1_txtShowLoaiHangCapCao').val().trim().length <= 0 || IDLoaiHangCapCao.trim().length <= 0 || SoLuong.trim().length <= 0 || GiaBan.trim().length <= 0) {
                        alert('Hãy chọn hàng hóa và nhập số lượng');
                    }
                    else {
                        if (isNaN(SoLuong) || isNaN(GiaBan)) {
                            alert('Số lượng và giá bán phải là số');
                        }
                        else {
                            var xmlhttp;
                            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                xmlhttp = new XMLHttpRequest();
                            }
                            else {// code for IE6, IE5
                                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                            }
                            xmlhttp.onreadystatechange = function () {
                                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

                                    if (xmlhttp.responseText == "True") {
                                        // alet("đụ má");
                                        LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                        Dong1();
                                        TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                        TongTienKhachNo();
                                        CongLai();
                                   


                                    }
                                    else {
                                        alert('Lỗi internet hoặc có hàng hóa chưa được thiết lập giá cho khách này, hoặc có thể hàng hóa này có những mẫu size, màu không đủ số lượng để xuất !!!!')
                                   
                                    }

                                }
                            }
                            xmlhttp.open("GET", "../Ajax2.aspx?Action=ThemTheoLoaiHangCapCaoPhieuXuat&IDLoaiHangCapCao=" + IDLoaiHangCapCao + "&IDPhieuXuat=" + IDPhieuXuat + "&IDKhachHang=" + IDKhachHang + "&SoLuong=" + SoLuong + "&IDMauSac=" + IDMauSac + "&GiaBan=" + GiaBan + "&MauSac=" + MangMau, true);
                            xmlhttp.send();
                        }
                    }
                }--%>
                }
                catch (err) {
                    alert("Hãy nhập đủ thông tin");
                }
            }
        }
        function ThemTheoLoaiHangHoa() {
            var IDPhieuXuat = '<%= Request.QueryString["IDPhieuXuat"].Trim() %>';
            var IDLoaiHangHoa = $('#ContentPlaceHolder1_slLoaiHangHoa').val();
            var IDKhachHang = $('#ContentPlaceHolder1_txtIDKhachHang').val();
            var IDSize = $('#ContentPlaceHolder1_slSize').val();
            var IDMauSac = $('#ContentPlaceHolder1_slMauSac').val();
            var SoLuong = $('#ContentPlaceHolder1_txtSoLuongXuat').val().replace(/\./g, '').replace(/\,/g, '');
            var GiaDeNghi = $('#ContentPlaceHolder1_txtGiaDeNghi').val().replace(/\./g, '').replace(/\,/g, '');



            if (isNaN(SoLuong) || isNaN(GiaDeNghi)) {
                alert('Số lượng, và giá bán phải nhập số');
            }
            else {
                try {
                    if (IDLoaiHangHoa.trim().length <= 0 || SoLuong.trim().length <= 0 || IDSize.trim().length <= 0 || IDMauSac.trim().length <= 0 || $('#ContentPlaceHolder1_txtLoaiHangHoa').val().trim().length <= 0 || GiaDeNghi.trim().length <= 0) {
                        alert('Hãy nhập đủ thông tin bắt buộc có dấu (*)');
                    }
                    else {
                        var xmlhttp;
                        if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                            xmlhttp = new XMLHttpRequest();
                        }
                        else {// code for IE6, IE5
                            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                        }
                        xmlhttp.onreadystatechange = function () {
                            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                                //alert(xmlhttp.readyState);
                                if (xmlhttp.responseText == "True") {
                                    //alert(xmlhttp.responseText);
                                    LoadChiTietPhieuXuat('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                    Dong();
                                    TongTienDonHang('<%= Request.QueryString["IDPhieuXuat"].Trim() %>');
                                    TongTienKhachNo();
                                    CongLai();
                                    // CongLai();




                                }
                                else {
                                    if (xmlhttp.responseText == "False1") alert('Hãy kiểm tra lại mọi thông tin có dấu (*) tất cả đều bắt buộc có thể bạn đã nhập sai dữ liệu nào đó');
                                    else
                                        alert('1. Lỗi internet hoặc hàng hóa này chưa được thiết lập giá cho khách này \n2. Hãy kiểm tra lại mọi thông tin có dấu (*) tất cả đều bắt buộc\n3. Có thể sản phẩm này tồn kho không còn đủ để bán  !')
                                }

                            }
                        }
                        xmlhttp.open("GET", "../Ajax.aspx?Action=ThemTheoLoaiHangHoaPhieuXuat&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDPhieuXuat=" + IDPhieuXuat + "&IDKhachHang=" + IDKhachHang + "&IDSize=" + IDSize + "&IDMauSac=" + IDMauSac + "&SoLuong=" + SoLuong + "&GiaDeNghi=" + GiaDeNghi, true);
                        xmlhttp.send();
                    }
                }
                catch (err) {
                    alert('Hãy nhập đủ thông tin bắt buộc');
                }
            }
        }
        function Dong() {
            document.getElementById('light').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
        }
        function Mo() {
            document.getElementById('light').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
        }
        function LoadKH() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                               .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');

                        var listKhachHangAutocomplete = eval("(" + txt + ")");
                        //alert(listKhuVucAutocomplete.toString());
                        //listKhuVucAutocomplete = [{ value: 'Công ty CP CT VIỆTTRONICS', label: 'Công ty CP CT VIỆTTRONICS', id: '2' }];
                        $("#ContentPlaceHolder1_txtKhachHang").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtKhachHang").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtKhachHang").val(ui.item.value);
                                $("#ContentPlaceHolder1_txtIDKhachHang").val(ui.item.id);
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=TenKhachAutocomplete", true);
            xmlhttp.send();
        }
        function LoadMauSize(IDHangHoa) {

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        var txt = xmlhttp.responseText.split('@');
                        $('#ContentPlaceHolder1_txtMauSac').val(txt[1]);
                        $('#ContentPlaceHolder1_txtSize').val(txt[0]);
                    }
                    else
                        alert("Lỗi tải thông tin!")
                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadMauSize&IDHangHoa=" + IDHangHoa, true);
            xmlhttp.send();

        }





        function LoadMauDonThe() {
            var IDLoaiHangHoa = $("#ContentPlaceHolder1_txtLoaiHangCapCao").val();
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        $('#ContentPlaceHolder1_txtMauThemNhanh').empty();
                        var txt = xmlhttp.responseText.split('~');
                        for (var i = 0; i < txt.length - 1; i++) {
                            var chuoinho = txt[i].split('@');
                            $("#ContentPlaceHolder1_txtMauThemNhanh").append("<option value='" + chuoinho[0] + "'>" + chuoinho[1] + "</option>");
                        }
                        $("#ContentPlaceHolder1_txtMauThemNhanh").append("<option value='' selected='selected'></option>");

                    }
                    else {
                        $('#ContentPlaceHolder1_txtMauThemNhanh').empty();
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadSize&IDLoaiHangHoa=" + IDLoaiHangHoa, true);
            xmlhttp.send();
        }

        function LoadLaiSoLuongLanNua() {

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        var txt = xmlhttp.responseText.split('@');
                        var tong = 0;
                        var chuoi = '';
                        for (var i = 0; i < txt.length - 1; i++) {
                            if ($('#' + txt[i]).val().trim().length > 0) {
                                tong += parseFloat($('#' + txt[i]).val());
                                chuoi += txt[i] + '_' + $('#' + txt[i]).val();
                            }
                            else {
                                chuoi += txt[i] + '_0';
                            }
                            chuoi += '@';
                            // alert($('#' + txt[i]).val());
                        }
                        //  tong.toString().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, ".");
                        // alert(tong);
                        $('#tongsl').html(tong);
                        $('#tongsl').html($('#tongsl').html().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                        CheatLanHai(chuoi);
                    }
                    else {

                    }

                }
            }
            xmlhttp.open("GET", "../Ajax3.aspx?Action=LoadLaiSoLuongLanNua", true);
            xmlhttp.send();

        }



        function CheatLanHai(chuoi) {

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        // alert(xmlhttp.responseText);
                        // alert("fuck you");
                    }
                    else {

                    }

                }
            }
            xmlhttp.open("GET", "../Ajax3.aspx?Action=CheatLanHai&chuoi=" + chuoi.toString(), true);
            xmlhttp.send();

        }

    </script>
    <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
    <script type="text/javascript">
        $('#ContentPlaceHolder1_txtNgayXuatChiTiet').datetimepicker({
            //dayOfWeekStart : 1,
            //todayBtn: "linked",
            language: "it",
            autoclose: true,
            todayHighlight: true,
            timepicker: false,
            dateFormat: 'dd/mm/yyyy',
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            //value: 'today'
        });
        $('#ContentPlaceHolder1_txtNgayXuatChiTiet2').datetimepicker({
            //dayOfWeekStart : 1,
            //todayBtn: "linked",
            language: "it",
            autoclose: true,
            todayHighlight: true,
            timepicker: false,
            dateFormat: 'dd/mm/yyyy',
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            //value: 'today'
        });
        $('#ContentPlaceHolder1_txtNgayXuat').datetimepicker({
            //dayOfWeekStart : 1,
            //todayBtn: "linked",
            language: "it",
            autoclose: true,
            todayHighlight: true,
            timepicker: false,
            dateFormat: 'dd/mm/yyyy',
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            //value: 'today'
        });

    </script>
</asp:Content>

