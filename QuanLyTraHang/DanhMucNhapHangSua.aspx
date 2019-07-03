<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucNhapHangSua.aspx.cs" Inherits="QuanLyDungCu_DanhMucNhapHang_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />
    <script>
        window.onload = function () {
            <%
        HttpCookie ThemNhanh = new HttpCookie("ThemNhanh2", "");
        ThemNhanh.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(ThemNhanh);
        %>

              <%
        HttpCookie SuaNhapNhanh2 = new HttpCookie("SuaNhapNhanh2", "");
        SuaNhapNhanh2.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(SuaNhapNhanh2);
        %>

            LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');
            LoadLoaiHangHoa();
            ABCAutocomplete();
            //TenNhaCCNhapAutocomplete();
            ABCAutocomplete2();
            //ABCAutocomplete3();
            //ABCAutocomplete4();
            LoadNhaCungCap();
            LoadKho();
        }
        function LayGiaGoc() {
            var IDLoaiHangHoa = $('#ContentPlaceHolder1_slLoaiHangHoa').val();
            var IDNhaCungCap = $("#ContentPlaceHolder1_txtIDNCC").val();
            var xmlhttp2;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp2 = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp2.onreadystatechange = function () {
                if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {

                    if (xmlhttp2.responseText != "") {
                        $('#ContentPlaceHolder1_txtGiaNhap').val(xmlhttp2.responseText);

                    }
                    else
                        alert("Lỗi !")
                }
            }
            xmlhttp2.open("GET", "../Ajax2.aspx?Action=GiaNhapNhaCungCapGanNhat&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDNhaCungCap=" + IDNhaCungCap, true);
            xmlhttp2.send();
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
        function SuaSoLuongChiTietPhieuNhap(IDChiTietPhieuNhap) {

            var soluong = document.getElementById("sl_" + IDChiTietPhieuNhap);

            if (soluong.disabled == true) {

                soluong.disabled = false;
                document.getElementById("hinh_" + IDChiTietPhieuNhap).innerHTML = "<img  class='imgCommand' src='../Images/save.png'   />";
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
                                    LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');

                                }
                                else
                                    alert("Lỗi !")
                            }
                        }
                        xmlhttp2.open("GET", "../Ajax2.aspx?Action=SuaSoLuongChiTietPhieuNhap&IDChiTietPhieuNhap=" + IDChiTietPhieuNhap + "&SoLuong=" + soluong.value.trim().replace(/\./g, '').replace(/\,/g, ''), true);
                        xmlhttp2.send();
                    }
                }
            }
        }

        function ABCAutocomplete4() {
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
                        $("#ContentPlaceHolder1_txtMaHangHoa2").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            appendTo: '#lightXemDungCu2',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa2").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa2").val(ui.item.show);
                                $("#ContentPlaceHolder1_txtTenHangHoa2").val(ui.item.id);
                                $("#ContentPlaceHolder1_txtIDHangHoa2").val(ui.item.iid);
                                var mhh = $("#ContentPlaceHolder1_txtMaHangHoa2").val();
                                if (mhh.length > 0) {
                                    var xmlhttp2;
                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                        xmlhttp2 = new XMLHttpRequest();
                                    }
                                    else {// code for IE6, IE5
                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                    }
                                    xmlhttp2.onreadystatechange = function () {
                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                            if (xmlhttp2.responseText != "") {
                                                //alert(xmlhttp2.responseText)
                                                var txt = xmlhttp2.responseText;

                                                var va = eval("(" + txt + ")");//xmlhttp2.responseText.split('@~');
                                                $("#ContentPlaceHolder1_txtDonViTinh2").val(va[0]);
                                                $("#ContentPlaceHolder1_txtMauSac2").val(va[1]);
                                                $("#ContentPlaceHolder1_txtNhomHangHoa2").val(va[2]);
                                                $("#ContentPlaceHolder1_txtChungLoai2").val(va[3]);
                                                $("#ContentPlaceHolder1_txtDongGoi2").val(va[4]);
                                            }
                                            else
                                                alert("Lỗi !")
                                        }
                                    }
                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadMa&MaHangHoa=" + mhh, true);
                                    xmlhttp2.send();
                                }
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=ABCAutocomplete3", true);
            xmlhttp.send();
        }
        //
        function ABCAutocomplete3() {
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
                        $("#ContentPlaceHolder1_txtMaHangHoa").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            appendTo: '#lightXemDungCu',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa").val(ui.item.show);
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.id);
                                $("#ContentPlaceHolder1_txtIDHangHoa").val(ui.item.iid);
                                var mhh = $("#ContentPlaceHolder1_txtMaHangHoa").val();
                                if (mhh.length > 0) {
                                    var xmlhttp2;
                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                        xmlhttp2 = new XMLHttpRequest();
                                    }
                                    else {// code for IE6, IE5
                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                    }
                                    xmlhttp2.onreadystatechange = function () {
                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                            if (xmlhttp2.responseText != "") {
                                                //alert(xmlhttp2.responseText)
                                                var txt = xmlhttp2.responseText;

                                                var va = eval("(" + txt + ")");//xmlhttp2.responseText.split('@~');
                                                $("#ContentPlaceHolder1_txtDonViTinh").val(va[0]);
                                                $("#ContentPlaceHolder1_txtMauSac").val(va[1]);
                                                $("#ContentPlaceHolder1_txtNhomHangHoa").val(va[2]);
                                                $("#ContentPlaceHolder1_txtChungLoai").val(va[3]);
                                                $("#ContentPlaceHolder1_txtDongGoi").val(va[4]);
                                            }
                                            else
                                                alert("Lỗi !")
                                        }
                                    }
                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadMa&MaHangHoa=" + mhh, true);
                                    xmlhttp2.send();
                                }
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=ABCAutocomplete3", true);
            xmlhttp.send();
        }
        //
        function DeleteChiTietPhieuNhap(IDChiTietPhieuNhap) {
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
                            LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');

                        }
                        else {
                            // alert(" Thông tin đơn hàng này sẽ được xóa nhưng có thể đây là đơn hàng duy nhất nên không thể tính lại lợi nhuận !");
                            LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');
                        }
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeleteChiTietPhieuNhap&IDChiTietPhieuNhap=" + IDChiTietPhieuNhap, true);
                xmlhttp.send();
            }
            else {

            }

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
                            appendTo: '#lightXemDungCu2',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa2").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa2").val(ui.item.value);

                                $("#ContentPlaceHolder1_txtIDHangHoa2").val(ui.item.id);
                                var mhh = $("#ContentPlaceHolder1_txtIDHangHoa2").val();
                                if (mhh.length > 0) {
                                    var xmlhttp2;
                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                        xmlhttp2 = new XMLHttpRequest();
                                    }
                                    else {// code for IE6, IE5
                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                    }
                                    xmlhttp2.onreadystatechange = function () {
                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                            if (xmlhttp2.responseText != "") {
                                                var txt = xmlhttp2.responseText;

                                                var va = eval("(" + txt + ")");
                                                // var va = xmlhttp2.responseText.split('@~');
                                                //alert("a");
                                                //  var va = listKhachHangAutocomplete;
                                                $("#ContentPlaceHolder1_txtDonViTinh2").val(va[0]);
                                                $("#ContentPlaceHolder1_txtMauSac2").val(va[1]);
                                                $("#ContentPlaceHolder1_txtDonGiaNhap2").val(va[2]);

                                            }
                                            else
                                                alert("Lỗi !")
                                        }
                                    }
                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadMa&MaHangHoa=" + mhh, true);
                                    xmlhttp2.send();
                                }
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=ABCAutocomplete", true);
            xmlhttp.send();
        }
        //
        function ThemChiTietPhieuNhap() {
            var TenHangHoa = $('#ContentPlaceHolder1_txtTenHangHoa').val();
            var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa").val();
            var IDPhieuNhap = '<%= Request.QueryString["IDPhieuNhap"].Trim() %>';
            var SoLuong = $("#ContentPlaceHolder1_txtSoLuong").val().replace(/\./g, '').replace(/\,/g, '');
            var DonGia = $("#ContentPlaceHolder1_txtDonGiaNhap").val().replace(/\./g, '').replace(/\,/g, '');
            var GhiChu = $("#ContentPlaceHolder1_txtGhiChuChiTietNhap").val();
            var loi = '';
            if (TenHangHoa.trim().length <= 0 || IDHangHoa.trim().length <= 0) {
                loi += 'Hãy chọn hàng hóa\n';
            }
            if (SoLuong.trim().length <= 0) {
                loi += 'Không bỏ trống số lượng, nếu không thì hãy nhập 0\n';
            }
            if (isNaN(SoLuong)) {
                loi += 'Số lượng phải là số\n';
            }
            if (DonGia.trim().length <= 0) {
                loi += 'Không bỏ trống đơn giá nhập, nếu không thì hãy nhập 0\n';
            }
            if (isNaN(DonGia)) {
                loi += 'Đơn giá nhập phải là số\n';
            }
            if (loi.trim().length <= 0) {
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
                            DongXemDungCu();
                            LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');

                        }
                        else {
                            alert('Lỗi xin kiểm tra lại thông tin');
                        }

                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=ThemChiTietPhieuNhap&IDHangHoa=" + IDHangHoa + "&IDPhieuNhap=" + IDPhieuNhap + "&SoLuong=" + SoLuong + "&DonGia=" + DonGia + "&GhiChu=" + GhiChu, true);
                xmlhttp.send();
            }
            else {
                alert(loi);
            }
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
                            appendTo: '#lightXemDungCu',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.value);

                                $("#ContentPlaceHolder1_txtIDHangHoa").val(ui.item.id);
                                var mhh = $("#ContentPlaceHolder1_txtIDHangHoa").val();
                                if (mhh.length > 0) {
                                    var xmlhttp2;
                                    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                                        xmlhttp2 = new XMLHttpRequest();
                                    }
                                    else {// code for IE6, IE5
                                        xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                                    }
                                    xmlhttp2.onreadystatechange = function () {
                                        if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                                            if (xmlhttp2.responseText != "") {
                                                //alert(xmlhttp2.responseText)
                                                var txt = xmlhttp2.responseText;

                                                var va = eval("(" + txt + ")");//xmlhttp2.responseText.split('@~');
                                                $("#ContentPlaceHolder1_txtDonViTinh").val(va[0]);
                                                $("#ContentPlaceHolder1_txtMauSac").val(va[1]);
                                                $("#ContentPlaceHolder1_txtDonGiaNhap").val(va[2]);
                                            }
                                            else
                                                alert("Lỗi !")
                                        }
                                    }
                                    xmlhttp2.open("GET", "../Ajax.aspx?Action=LoadMa&MaHangHoa=" + mhh, true);
                                    xmlhttp2.send();
                                }
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=ABCAutocomplete", true);
            xmlhttp.send();
        }
        //
        function TinhTien() {
            $('#ContentPlaceHolder1_txtDonGiaNhap').keyup(function () {
                $('#ContentPlaceHolder1_txtDonGiaNhap').val($('#ContentPlaceHolder1_txtDonGiaNhap').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                var SoTien = 0;
                var Vat = 0;

                if ($('#ContentPlaceHolder1_txtDonGiaNhap').val() == "")
                    SoTien = 0;
                else
                    SoTien = $('#ContentPlaceHolder1_txtDonGiaNhap').val().replace(/\./g, '').replace(/\,/g, '');
            }
            );

            $('#ContentPlaceHolder1_txtTienDaThanhToan').keyup(function () {
                $('#ContentPlaceHolder1_txtTienDaThanhToan').val($('#ContentPlaceHolder1_txtTienDaThanhToan').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
            }
           );


            $('#ContentPlaceHolder1_txtGiaNhap').keyup(function () {
                $('#ContentPlaceHolder1_txtGiaNhap').val($('#ContentPlaceHolder1_txtGiaNhap').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
            }
             );

            $('#ContentPlaceHolder1_txtGiaNhapGoiY').keyup(function () {
                $('#ContentPlaceHolder1_txtGiaNhapGoiY').val($('#ContentPlaceHolder1_txtGiaNhapGoiY').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
            }
           );


        }
        function TinhTien2() {
            $('#ContentPlaceHolder1_txtSoLuong').keyup(function () {
                $('#ContentPlaceHolder1_txtSoLuong').val($('#ContentPlaceHolder1_txtSoLuong').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                var SoTien = 0;
                var Vat = 0;

                if ($('#ContentPlaceHolder1_txtSoLuong').val() == "")
                    SoTien = 0;
                else
                    SoTien = $('#ContentPlaceHolder1_txtSoLuong').val().replace(/\./g, '').replace(/\,/g, '');



            }
            );

            $('#ContentPlaceHolder1_txtSoLuongThem').keyup(function () {
                $('#ContentPlaceHolder1_txtSoLuongThem').val($('#ContentPlaceHolder1_txtSoLuongThem').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));


            }
           );


            $('#ContentPlaceHolder1_txtGiaBanChoKhachSuaNhanhHangHoa').keyup(function () {
                $('#ContentPlaceHolder1_txtGiaBanChoKhachSuaNhanhHangHoa').val($('#ContentPlaceHolder1_txtGiaBanChoKhachSuaNhanhHangHoa').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));




            }
           );

        }
        //
        //
        function TinhTien3() {
            $('#ContentPlaceHolder1_txtDonGiaNhap2').keyup(function () {
                $('#ContentPlaceHolder1_txtDonGiaNhap2').val($('#ContentPlaceHolder1_txtDonGiaNhap2').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                var SoTien = 0;
                var Vat = 0;

                if ($('#ContentPlaceHolder1_txtDonGiaNhap2').val() == "")
                    SoTien = 0;
                else
                    SoTien = $('#ContentPlaceHolder1_txtDonGiaNhap2').val().replace(/\./g, '').replace(/\,/g, '');
            }
            );
        }
        function TinhTien4() {
            $('#ContentPlaceHolder1_txtSoLuong2').keyup(function () {
                $('#ContentPlaceHolder1_txtSoLuong2').val($('#ContentPlaceHolder1_txtSoLuong2').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                var SoTien = 0;
                var Vat = 0;

                if ($('#ContentPlaceHolder1_txtSoLuong2').val() == "")
                    SoTien = 0;
                else
                    SoTien = $('#ContentPlaceHolder1_txtSoLuong2').val().replace(/\./g, '').replace(/\,/g, '');



            }
            );
        }
        //
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
                                $('#ContentPlaceHolder1_slSize').empty();
                                $('#ContentPlaceHolder1_slMauSac').empty();

                                $("#ContentPlaceHolder1_txtLoaiHangHoa").val(ui.item.label);
                                $("#ContentPlaceHolder1_slLoaiHangHoa").val(ui.item.id);
                                if ($("#ContentPlaceHolder1_slLoaiHangHoa").val().trim().length > 0) {
                                    LoadLenSize();
                                }
                                if ($("#ContentPlaceHolder1_slLoaiHangHoa").val().trim().length > 0) {
                                    LayGiaGoc();
                                }
                                //alert("đù má");
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
                                $("#ContentPlaceHolder1_txtShowLoaiHangCapCao").val(ui.item.label);
                                $("#ContentPlaceHolder1_txtLoaiHangCapCao").val(ui.item.id);

                                if ($("#ContentPlaceHolder1_txtLoaiHangCapCao").val().trim().length > 0) {
                                    LoadGiaNhapGoiY();
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
                        alert("Lỗi internet")


                }
            }
            xmlhttp.open("GET", "../Ajax4.aspx?Action=LoadLenSizeVaMauTheoIDLoaiHangHoa&IDLoaiHangHoa=" + IDLoaiHangHoa, true);
            xmlhttp.send();
        }

        function CapNhatSoLuongThemNhanh(chuoi) {
            // alert(chuoi);
            var soluong = $('#' + chuoi).val();
            var idsp = chuoi;
            //alert(soluong.toString());

            if (soluong.trim().length <= 0) {
                // $('#' + chuoi).val("0");
                //  soluong = $('#' + chuoi).val();
                $('#' + chuoi).val("");
                soluong = "0";
            }

            if (isNaN(soluong)) {
                // $('#' + chuoi).val("0");
                //  soluong = $('#' + chuoi).val();
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

                        $('#tongsl').html(xmlhttp.responseText);

                    }
                    else
                        alert("Lỗi internet");


                }
            }
            xmlhttp.open("GET", "../Ajax4.aspx?Action=CapNhatSoLuongThemNhanh&soluong=" + soluong + "&idsp=" + idsp, true);
            xmlhttp.send();
        }



        function LoadGiaNhapGoiY() {
            var IDLoaiHangHoa = $("#ContentPlaceHolder1_txtLoaiHangCapCao").val();
            var IDNhaCungCap = $("#ContentPlaceHolder1_txtIDNCC").val();
            // $("#ContentPlaceHolder1_txtMaHangHoa").val(t);

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
                        // alert(xmlhttp.responseText)
                        $('#ContentPlaceHolder1_txtGiaNhapGoiY').val(xmlhttp.responseText);
                    }
                    else
                        alert("Lỗi !")
                }
            }
            xmlhttp.open("GET", "../Ajax2.aspx?Action=GiaNhapNhaCungCapGanNhat&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDNhaCungCap=" + IDNhaCungCap, true);
            xmlhttp.send();
        }
        //

        function LoadMa() {
            var t = $("#ContentPlaceHolder1_txtMaHangHoa").val();
            // $("#ContentPlaceHolder1_txtMaHangHoa").val(t);

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
                        // alert(xmlhttp.responseText)
                        var va = xmlhttp.responseText.split('@');
                        $("#ContentPlaceHolder1_txtDonViTinh").val(va[0]);
                        $("#ContentPlaceHolder1_txtMauSac").val(va[1]);
                        $("#ContentPlaceHolder1_txtNhomHangHoa").val(va[2]);
                        $("#ContentPlaceHolder1_txtChungLoai").val(va[3]);
                    }
                    else
                        alert("Lỗi !")
                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadMa&MaHangHoa=" + t, true);
            xmlhttp.send();
        }

        //
        function LoadChiTietPhieuNhap(IDPhieuNhap) {

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
                        $("#hh").html(xmlhttp.responseText);

                    }
                    else
                        alert("Lỗi !")
                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadChiTietPhieuNhap&IDPhieuNhap=" + IDPhieuNhap, true);
            xmlhttp.send();

        }

        //SuaChiTietPhieuNhap
        function MoXemDungCu2() {
            document.getElementById('lightXemDungCu2').style.display = 'block';
            document.getElementById('fadeXemDungCu2').style.display = 'block';
        }
        function DongXemDungCu2() {
            document.getElementById('lightXemDungCu2').style.display = 'none';
            document.getElementById('fadeXemDungCu2').style.display = 'none';
        }
        function MoXemDungCu() {
            /**/
            $("#ContentPlaceHolder1_txtIDHangHoa").val("");
            $("#ContentPlaceHolder1_txtTenHangHoa").val("");
            $("#ContentPlaceHolder1_txtMaHangHoa").val("");
            $('#ContentPlaceHolder1_txtSoLuong').val("0");
            $('#ContentPlaceHolder1_txtDonGiaNhap').val("0");
            $("#ContentPlaceHolder1_txtTenNhaCungCap").val("");
            $("#ContentPlaceHolder1_txtMaNhaCungCap").val("");
            //  $("#ContentPlaceHolder1_txtNgayNhapChiTiet").val("");
            // $("#ContentPlaceHolder1_slHinhThuc").val("");
            $("#ContentPlaceHolder1_txtGhiChuChiTietNhap").val("");
            $("#ContentPlaceHolder1_txtMauSac").val("");
            $("#ContentPlaceHolder1_txtDonViTinh").val("");
            $("#ContentPlaceHolder1_txtChungLoai").val("");
            $("#ContentPlaceHolder1_txtNhomHangHoa").val("");
            $("#ContentPlaceHolder1_txtDongGoi").val("");
            $("#ContentPlaceHolder1_txtIDChiTietPhieuNhap").val("");
            /**/
            document.getElementById('lightXemDungCu').style.display = 'block';
            document.getElementById('fadeXemDungCu').style.display = 'block';
        }
        function DongXemDungCu() {
            document.getElementById('lightXemDungCu').style.display = 'none';
            document.getElementById('fadeXemDungCu').style.display = 'none';
        }
        function SuaChiTietPhieuNhap() {
            var TenHangHoa = $('#ContentPlaceHolder1_txtTenHangHoa2').val();
            var IDChiTietPhieuNhap = $("#ContentPlaceHolder1_txtIDChiTietPhieuNhap").val();
            var IDHangHoa = $("#ContentPlaceHolder1_txtIDHangHoa2").val();
            var IDPhieuNhap = '<%= Request.QueryString["IDPhieuNhap"].Trim() %>'
            var SoLuong = $("#ContentPlaceHolder1_txtSoLuong2").val().replace(/\./g, '').replace(/\,/g, '');
            var DonGia = $("#ContentPlaceHolder1_txtDonGiaNhap2").val().replace(/\./g, '').replace(/\,/g, '');

            var GhiChu = $("#ContentPlaceHolder1_txtGhiChuChiTietNhap2").val();

            var loi = '';
            if (TenHangHoa.trim().length <= 0 || IDHangHoa.trim().length <= 0) {
                loi += 'Hãy chọn hàng hóa\n';
            }
            if (SoLuong.trim().length <= 0) {
                loi += 'Không bỏ trống số lượng, nếu không thì hãy nhập 0\n';
            }
            if (isNaN(SoLuong)) {
                loi += 'Số lượng phải là số\n';
            }
            if (DonGia.trim().length <= 0) {
                loi += 'Không bỏ trống đơn giá nhập, nếu không thì hãy nhập 0\n';
            }
            if (isNaN(DonGia)) {
                loi += 'Đơn giá nhập phải là số\n';
            }


            if (loi.trim().length <= 0) {
                var xmlhttp2;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp2 = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp2 = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp2.onreadystatechange = function () {
                    if (xmlhttp2.readyState == 4 && xmlhttp2.status == 200) {
                        if (xmlhttp2.responseText != "") {
                            DongXemDungCu2();
                            //  alert(xmlhttp2.responseText);
                            LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');
                            // window.location.hash = IDChiTietPhieuNhap;
                        }
                        else {
                            alert('Kiểm tra lại thông tin!!');
                        }
                    }
                }
                xmlhttp2.open("GET", "../Ajax.aspx?Action=SuaChiTietPhieuNhap&IDHangHoa=" + IDHangHoa + "&IDPhieuNhap=" + IDPhieuNhap + "&SoLuong=" + SoLuong + "&DonGia=" + DonGia + "&GhiChu=" + GhiChu + "&IDChiTietPhieuNhap=" + IDChiTietPhieuNhap, true);
                xmlhttp2.send();
            }
            else {
                alert(loi);
            }

        }
        function SuaChiTietNhap(IDChiTietPhieuNhap) {
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
                        var txt = xmlhttp.responseText;
                        var listKhachHangAutocomplete = eval("(" + txt + ")");
                        var tach = listKhachHangAutocomplete;
                        // alert(tach[0]);
                        // var tach = xmlhttp.responseText.split('@');
                        $("#ContentPlaceHolder1_txtIDHangHoa2").val(tach[4]);
                        $("#ContentPlaceHolder1_txtTenHangHoa2").val(tach[0]);

                        $("#ContentPlaceHolder1_txtSoLuong2").val(tach[1]);
                        $("#ContentPlaceHolder1_txtDonGiaNhap2").val(tach[2]);

                        $("#ContentPlaceHolder1_txtGhiChuChiTietNhap2").val(tach[3]);
                        $("#ContentPlaceHolder1_txtMauSac2").val(tach[6]);
                        $("#ContentPlaceHolder1_txtDonViTinh2").val(tach[7]);

                        $("#ContentPlaceHolder1_txtIDChiTietPhieuNhap").val(tach[5]);
                        /*   Vùng update */

                        /* end update*/
                        MoXemDungCu2();
                    }
                    else {

                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=SuaChiTietNhap&IDChiTietPhieuNhap=" + IDChiTietPhieuNhap, true);
            xmlhttp.send();
        }

        function Dong() {
            document.getElementById('light').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
        }
        function Mo() {
            $('#ContentPlaceHolder1_slLoaiHangCapCao').val("");
            document.getElementById('light').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
        }

        function Dong1() {
            document.getElementById('light1').style.display = 'none';
            document.getElementById('fade1').style.display = 'none';
        }
        function Mo1() {
            document.getElementById('divBangChoDe').style.display = 'none';
            document.getElementById('light1').style.display = 'block';
            document.getElementById('fade1').style.display = 'block';
        }

        function InPhieuTongHopNhapHang(IDPhieuNhap) {

            var TongTienKhachNo = $("#ContentPlaceHolder1_txtTongTienKhachNo").val();
            var TienThanhToan = $("#ContentPlaceHolder1_txtTienDaThanhToan").val();
            var IdKho = $("#ContentPlaceHolder1_txtIDKho").val();

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
                        alert("Lỗi in");
                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=InPhieuTongHopNhapHang&IDPhieuNhap=" + IDPhieuNhap + "&TienThanhToan=" + TienThanhToan + "&IdKho=" + IdKho, true);
            xmlhttp.send();
        }

        function DongfadeSuaNhanhHangHoa() {
            document.getElementById('lightSuaNhanhHangHoa').style.display = 'none';
            document.getElementById('fadeSuaNhanhHangHoa').style.display = 'none';
        }
        function MoSuaNhanhHangHoa() {
            document.getElementById("BangGiaMauSuaNhanhHH").style.display = 'none';
            LoadLoaiHangHoaSuaNhanh();
            document.getElementById('lightSuaNhanhHangHoa').style.display = 'block';
            document.getElementById('fadeSuaNhanhHangHoa').style.display = 'block';
        }


        function LoadLoaiHangHoaSuaNhanh() {
            var IDPhieuNhap = '<%=Request.QueryString["IDPhieuNhap"].Trim()%>';

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
                                document.getElementById("BangGiaMauSuaNhanhHH").style.display = 'block';
                                $("#ContentPlaceHolder1_txtLoaiHangHoaSuaNhanh").val(ui.item.value);
                                $("#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh").val(ui.item.id);
                                LoadLenGiaSuaNhanh($("#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh").val());
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
            xmlhttp.open("GET", "../Ajax8.aspx?Action=LoadLoaiHangHoaSuaNhanh&IDPhieuNhap=" + IDPhieuNhap, true);
            xmlhttp.send();
        }

        function LoadLoaiHangHoaSuaNhanhTheoDon() {
            var IDLoaiHangHoa = $("#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh").val().trim();
            var IDPhieuNhap = '<%=Request.QueryString["IDPhieuNhap"].Trim()%>';

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
                        $('#BangGiaMauSuaNhanhHH').html(xmlhttp.responseText);

                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax8.aspx?Action=LoadLenSizeVaMauTheoIDLoaiHangHoa&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDPhieuNhap=" + IDPhieuNhap, true);
            xmlhttp.send();
        }

        function LoadLenGiaSuaNhanh(IDLoaiHangHoa) {

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
            xmlhttp.open("GET", "../Ajax8.aspx?Action=LoadLenGiaSuaNhanh&IDLoaiHangHoa=" + IDLoaiHangHoa.toString(), true);
            xmlhttp.send();
        }



        function CapNhatSoLuongSuaNhanh(spnn) {
            var Getsptn = spnn.toString();
            var SoLuong = $("#" + spnn).val().replace(/\./g, '').replace(/\,/g, '');
            //alert(Getsptn + "~" + SoLuong);
            if (SoLuong.trim().length <= 0) SoLuong = "0";

            if (isNaN(SoLuong)) {
                SoLuong = "0";
                $("#" + spnn).val("");
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
                        $('#tongslsnthoi').html(tong);
                        $('#tongslsnthoi').html($('#tongslsnthoi').html().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                        // alert(xmlhttp.responseText);
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax8.aspx?Action=CapNhatSoLuongSuaNhanh&Getsptn=" + Getsptn + "&SoLuong=" + SoLuong, true);
            xmlhttp.send();
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
            xmlhttp.open("GET", "../Ajax8.aspx?Action=CapNhatSoLuongCookieSuaNhanh", true);
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
                        // alert(xmlhttp.responseText);

                    }

                }
            }
            xmlhttp.open("GET", "../Ajax8.aspx?Action=ganlai&chuoigan=" + chuoigan, true);
            xmlhttp.send();
        }

        function SuaLaiCookieNhanhHangHoa() {

            CapNhatSoLuongCookieSuaNhanh();
            if (true) {
                var IDPhieuNhap = '<%=Request.QueryString["IDPhieuNhap"].Trim()%>';
                var IDLoaiHangHoa = $('#ContentPlaceHolder1_txtIDLoaiHangHoaSuaNhanh').val();
                var GiaBan = $('#ContentPlaceHolder1_txtGiaBanChoKhachSuaNhanhHangHoa').val().replace(/\./g, '').replace(/\,/g, '');

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
                            LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');

                        }
                        else {

                        }

                    }
                }
                xmlhttp.open("GET", "../Ajax8.aspx?Action=SuaLaiCookieNhanhHangHoa&IDPhieuNhap=" + IDPhieuNhap + "&IDLoaiHangHoa=" + IDLoaiHangHoa + "&GiaBan=" + GiaBan, true);
                xmlhttp.send();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Main content -->
        <div class="title" id="dvTitle" runat="server">SỬA THÔNG TIN TRẢ HÀNG</div>
        <div class="title1"><a href="DanhMucNhapHang.aspx"><i class="fa fa-step-backward"></i>Danh sách phiếu trả hàng</a></div>
        <section class="content">
            <div class="box">
                <div class="box-body">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Mã phiếu trả(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaPhieuNhap" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                                <div class="coninput2">
                                    <div class="titleinput"><b>Ngày tạo phiếu trả(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtNgayNhap" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Trả từ khách hàng(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtTenNCC" runat="server" name="Content.ContentName" type="text" value="" placeholder="--Chọn--" />
                                        <input class="form-control" data-val="true" data-val-required="" id="txtIDNCC" runat="server" name="Content.ContentName" type="hidden" value="" />
                                    </div>
                                </div>
                                <div class="coninput2">
                                    <div class="titleinput"><b>Trả vào kho(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtKho" runat="server" name="Content.ContentName" type="hidden" value="" placeholder="--Chọn--" />
                                        <select class="form-control" data-val="true" data-val-required="" id="txtIDKho" runat="server" name="Content.ContentName" value=""></select>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                            <div class="col-md-10">
                                <textarea class="form-control" id="txtGhiChu" runat="server" name="Content.ContentName"></textarea>
                            </div>
                        </div>

                        <div class="box-footer">
<%--                            <a class="btn btn-primary btn-flat" href="../QuanLyTraHang/DanhMucNhapHang.aspx"><i class="glyphicon glyphicon-chevron-left"></i>Quay lại</a>--%>
                            <asp:Button ID="btLuu" runat="server" Text="SỬA" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                            <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                        </div>
                        <div class="box">

                            <div style="text-align: center; font-weight: bold; padding: 10px">THÊM HÀNG HÓA</div>
                            <div id="dv2" style="padding: 10px; text-align: center">


                                <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1" style="display: none;">

                                            <div class="txtinput">
                                                <center>    <select onchange="LoadLoaiHang();" class="form-control" data-val="true" data-val-required="" id="slLoaiHangCapCao" runat="server" name="Content.ContentName"  >
                                                   
                                                      </select></center>
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Hàng hóa(*): </b></div>
                                            <div class="txtinput">
                                                <center>      <input placeholder="--Chọn--" type="text" class="form-control" data-val="true" data-val-required="" id="txtLoaiHangHoa" runat="server" name="Content.ContentName" />
                                                   
                                                     </center>
                                                <input type="hidden" class="form-control" data-val="true" data-val-required="" id="slLoaiHangHoa" runat="server" name="Content.ContentName" />


                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Size(*): </b></div>
                                            <div class="txtinput">

                                                <center>      <select onchange="LoadLenMau();" class="form-control" data-val="true" data-val-required="" id="slMauSac" runat="server" name="Content.ContentName"  >
                                                   
                                                      </select></center>


                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>

                                        <div class="coninput1">
                                            <div class="titleinput"><b>Màu(*): </b></div>
                                            <div class="txtinput">
                                                <center>      <select  class="form-control" data-val="true" data-val-required="" id="slSize" runat="server" name="Content.ContentName"  >
                                                   
                                                      </select></center>

                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số lượng(*): </b></div>
                                            <div class="txtinput">

                                                <center> 
                                        <input  class="form-control" data-val="true" data-val-required="" id="txtSoLuong" runat="server" name="Content.ContentName" type="text" value="0" onkeyup="TinhTien2();" />

                                        </center>
                                            </div>
                                        </div>
                                    </div>

                                </div>


                                <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>

                                        <div class="coninput1">
                                            <div class="titleinput"><b>Giá trả(*): </b></div>
                                            <div class="txtinput">

                                                <center>      <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtGiaNhap" runat="server" name="Content.ContentName" value="0" />
                                                   
                                                      </center>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <center> <a style="cursor:pointer;" onclick='ThemTheoLoaiHangHoa();' class="btn btn-primary btn-flat"><div >Thêm</div></a></center>
                            </div>
                        </div>
                        <div class="form-group">
<%--                            <label class="col-md-2 control-label" for="Content_ContentName">Hàng hóa:</label>--%>
                            <div class="col-md-12">
                                <div>
                                    <input type="button" onclick='MoXemDungCu();' value="Thêm chi tiết hàng hóa" class="btn btn-primary btn-flat" style="width: 210px; display: none;" />
                                    <input type="button" onclick='Mo();' value="Thêm hàng hóa" class="btn btn-primary btn-flat" style="width: 210px; display: none;" />
                                    <a style='cursor: pointer;' class='btn btn-primary btn-flat' onclick='InPhieuTongHopNhapHang("<%=Request.QueryString["IDPhieuNhap"].ToString().Trim()%>");'>IN PHIẾU TỔNG HỢP</a>

                                    <%-- <input type="button" onclick='Mo1();' value="Thêm nhanh hàng hóa" class="btn btn-primary btn-flat" style="width: 210px;" />
                                    <input type="button" onclick='MoSuaNhanhHangHoa();' value="Sửa nhanh hàng hóa" class="btn btn-primary btn-flat" style="width: 210px;" />--%>
                                </div>
                                <%--start --%>
                                <div id="hh">
                                </div>
                                <%-- end--%>
                                <div class="form-group">
                                    <div class="row">

                                        <div class="coninput1">
                                            <div class="titleinput"><b></b></div>
                                            <div class="txtinput">
                                            </div>
                                        </div>

                                        <div class="coninput1">
                                            <div class="titleinput"><b>Tiền thanh toán(*): </b></div>
                                            <div class="txtinput">

                                                <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtTienDaThanhToan" runat="server" name="Content.ContentName" type="text" value="0" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                      <div class="box-footer">
                            <%--<a class="btn btn-primary btn-flat" href="../QuanLyNhapHang/DanhMucNhapHang.aspx"><i class="glyphicon glyphicon-chevron-left"></i> Quay lại</a>--%>
                            <asp:Button ID="Button1" runat="server" Text="Lưu" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                            <%--<asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />--%>
                        </div>

                    </form>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>

    <div id="lightSuaNhanhHangHoa" class="white_content" style="top: 10%; width: 80%; left: 15%; height: 70%;">
        <div class="box">
            <div class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">SỬA HÀNG HÓA !</div>
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
                                       <input onkeyup="TinhTien2();"  class="form-control"  id="txtGiaBanChoKhachSuaNhanhHangHoa" runat="server" name="Content.ContentName" />
                                   </center>
                                </div>

                            </div>

                        </div>
                    </div>

                    <div id="BangGiaMauSuaNhanhHH" style="display: none;">
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

    <!--Popup xem dụng cụ-->
    <div id="lightXemDungCu" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvDungCu" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px" id="titleThemHangHoa">THÊM CHI TIẾT HÀNG HÓA</div>
                <div id="dvXemDungCu" style="padding: 10px; text-align: center">
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Tên chi tiết hàng hóa(*):</b></div>
                                <div class="txtinput">
                                    <%--  <select class="form-control" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" onchange="LoadMa();"></select>   --%>
                                    <input class="form-control" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" placeholder="--Chọn--" />
                                    <input type="hidden" class="form-control" data-val="true" data-val-required="" id="txtIDHangHoa" runat="server" name="Content.ContentName" />

                                </div>
                            </div>
                            <div class="coninput1" style="display: none;">
                                <div class="titleinput"><b>Mã hàng hóa:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" id="txtMaHangHoa" runat="server" name="Content.ContentName" type="text" value="" readonly="true" />
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Size</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtDonViTinh" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Màu sắc</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtMauSac" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Số lượng(*):</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Đơn giá trả(*):</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input readonly="true" class="form-control" data-val="true" data-val-required="" id="txtDonGiaNhap" runat="server" name="Content.ContentName" type="text" value="0" onkeyup="TinhTien();" />
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Ghi chú:</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input id="txtGhiChuChiTietNhap" type="text" class="form-control" data-val="true" data-val-required="" runat="server" name="Content.ContentName" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group" style="display: none;">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Nhóm hàng hóa:</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">

                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtNhomHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Chủng loại hàng hóa:</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">

                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtChungLoai" runat="server" name="Content.ContentName" type="text" value="" />

                                </div>
                            </div>
                        </div>
                    </div>


                    <%-- start--%>
                    <div class="form-group" style="display: none;">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Đóng gói</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtDongGoi" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Tên khách hàng:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" placeholder="--Chọn--" id="txtTenNhaCungCap" runat="server" name="Content.ContentName" type="text" value="" />
                                    <input class="form-control" data-val="true" data-val-required="" id="txtMaNhaCungCap" runat="server" name="Content.ContentName" type="hidden" value="" />
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="form-group" style="display: none;">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Hình thức</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <select class="form-control" data-val="true" data-val-required="" id="slHinhThuc" runat="server" name="Content.ContentName">
                                        <option value="Nhập hàng">Nhập hàng</option>
                                        <option value="Trả hàng">Trả hàng</option>
                                    </select>
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Ngày trả chi tiết:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" id="txtNgayNhapChiTiet" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>

                        </div>

                    </div>


                    <center> <a style="cursor:pointer;" onclick='ThemChiTietPhieuNhap()' class="btn btn-primary btn-flat"><div id="Add">Thêm</div></a>
                        </center>
                </div>
            </div>
        </div>

    </div>

    <div id="fadeXemDungCu" onclick="DongXemDungCu()" class="black_overlay"></div>
    <!--End popup--->

    <div id="lightXemDungCu2" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvDungCu2" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">SỬA CHI TIẾT HÀNG HÓA</div>
                <div id="dvXemDungCu2" style="padding: 10px; text-align: center">
                    <div class="form-group">
                        <div class="row">


                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Tên chi tiết hàng hóa(*):</b></div>
                                <div class="txtinput">
                                    <%--  <select class="form-control" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" onchange="LoadMa();"></select>   --%>
                                    <input class="form-control" data-val="true" data-val-required="" id="txtTenHangHoa2" runat="server" name="Content.ContentName" placeholder="--Chọn--" />
                                    <input type="hidden" class="form-control" data-val="true" data-val-required="" id="txtIDHangHoa2" runat="server" name="Content.ContentName" />

                                </div>
                            </div>
                            <div class="coninput1" style="display: none;">
                                <div class="titleinput"><b>Mã hàng hóa:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" id="txtMaHangHoa2" runat="server" name="Content.ContentName" type="text" value="" readonly="true" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Size</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">

                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtDonViTinh2" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Màu sắc</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtMauSac2" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Số lượng(*):</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input class="form-control" data-val="true" data-val-required="" id="txtSoLuong2" runat="server" name="Content.ContentName" type="text" value="" onkeyup="TinhTien4();" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="form-group" style="display: none;">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Nhóm hàng hóa:</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">

                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtNhomHangHoa2" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Chủng loại hàng hóa:</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">

                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtChungLoai2" runat="server" name="Content.ContentName" type="text" value="" />

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Đơn giá nhập(*):</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input readonly="true" class="form-control" data-val="true" data-val-required="" id="txtDonGiaNhap2" runat="server" name="Content.ContentName" type="text" value="" onkeyup="TinhTien3();" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Ghi chú:</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input id="txtGhiChuChiTietNhap2" class="form-control" data-val="true" data-val-required="" runat="server" name="Content.ContentName" />
                                </div>
                            </div>

                        </div>

                    </div>

                    <%-- start--%>
                    <div class="form-group" style="display: none;">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Đóng gói</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtDongGoi2" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Tên khách hàng:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" id="txtTenNhaCungCap2" runat="server" name="Content.ContentName" type="text" value="" placeholder="--Chọn--" />
                                    <input class="form-control" data-val="true" data-val-required="" id="txtMaNhaCungCap2" runat="server" name="Content.ContentName" type="hidden" value="" />
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="form-group" style="display: none;">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Hình thức</b></div>
                                <div class="txtinput" style="padding-top: 0px; text-align: left">
                                    <select class="form-control" data-val="true" data-val-required="" id="slHinhThuc2" runat="server" name="Content.ContentName">
                                        <option value="Nhập hàng">Nhập hàng</option>
                                        <option value="Trả hàng">Trả hàng</option>
                                    </select>
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Ngày trả chi tiết:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" id="txtNgayNhapChiTiet2" runat="server" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>

                        </div>

                    </div>
                    <center> <a style="cursor:pointer;" onclick='SuaChiTietPhieuNhap();' class="btn btn-primary btn-flat"><div >Sửa</div></a></center>
                    <div class="form-group">
                        <label class="col-md-2 control-label" for="Content_ContentName"></label>
                        <div class="col-md-10">
                        </div>

                    </div>
                    <input class="form-control" data-val="true" data-val-required="" id="txtIDChiTietPhieuNhap" runat="server" name="Content.ContentName" type="hidden" value="" />

                    <div style="text-align: center">

                        <%--  <input type="button" value="Thêm" class="btn btn-primary btn-flat" style="width: 80px;" /> --%>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div id="fadeXemDungCu2" onclick="DongXemDungCu2()" class="black_overlay"></div>
    <!--End popup--->


    <!--popup thêm theo loại-->
    <div id="light" class="white_content" style="top: 9%; width: 40%; left: 35%; height: 85%;">
    </div>

    <div id="fade" onclick="Dong()" class="black_overlay"></div>
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
                                <div class="titleinput"><b>Giá trả(*)</b></div>
                                <div class="txtinput">
                                    <center>      
                                       <input  type="text" class="form-control" data-val="true" data-val-required="" id="txtGiaNhapGoiY" onkeyup="TinhTien();" runat="server" name="Content.ContentName"  />
                                </div>
                            </div>
                            <div class="coninput1" style="display: none;">
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



                        </div>
                    </div>
                    <br />
                    <div id="divBangChoDe" style="display: none;">


                        <!-- Get -->

                    </div>
                    <br />
                    <center> <a style="cursor:pointer;" onclick='LoadLaiSoLuongLanNua();' class="btn btn-primary btn-flat"><div >CẬP NHẬT SỐ LƯỢNG</div></a></center>

                    <br />
                    <center> <a style="cursor:pointer;" onclick='ThemTheoLoaiHangCapCao();' class="btn btn-primary btn-flat"><div >Thêm</div></a></center>


                </div>
            </div>
        </div>

    </div>

    <div id="fade1" onclick="Dong1()" class="black_overlay"></div>
    <script>
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
            xmlhttp.open("GET", "../Ajax4.aspx?Action=LoadLaiSoLuongLanNua", true);
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
                        //alert(xmlhttp.responseText);
                    }
                    else {

                    }

                }
            }
            xmlhttp.open("GET", "../Ajax4.aspx?Action=CheatLanHai&chuoi=" + chuoi.toString(), true);
            xmlhttp.send();

        }




        function LoadLenMau() {
            var IDLoaiHangHoa = $('#ContentPlaceHolder1_slLoaiHangHoa').val();
            var IDSize = $('#ContentPlaceHolder1_slMauSac').val();
            if (IDLoaiHangHoa.trim().length <= 0 || IDSize.trim().length <= 0) {
                $('#ContentPlaceHolder1_slSize').empty();
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
                            // $("#ContentPlaceHolder1_slSize").append("<option value='' selected='selected'></option>");

                        }
                        else {
                            $('#ContentPlaceHolder1_slSize').empty();
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
                            $('#ContentPlaceHolder1_slMauSac').empty();
                            var txt = xmlhttp.responseText.split('~');
                            for (var i = 0; i < txt.length - 1; i++) {
                                var chuoinho = txt[i].split('@');
                                $("#ContentPlaceHolder1_slMauSac").append("<option value='" + chuoinho[0] + "'>" + chuoinho[1] + "</option>");
                            }
                            // $("#ContentPlaceHolder1_slMauSac").append("<option value='' selected='selected'></option>");
                            LoadLenMau();
                        }
                        else {
                            $('#ContentPlaceHolder1_slMauSac').empty();
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
        function ThemTheoLoaiHangCapCao() {

            LoadLaiSoLuongLanNua();
            if (true) {


                var IDPhieuNhap = '<%= Request.QueryString["IDPhieuNhap"].Trim() %>';
                var IDLoaiHangCapCao = $('#ContentPlaceHolder1_txtLoaiHangCapCao').val();
                var SoLuong = $('#ContentPlaceHolder1_txtSoLuongThem').val().replace(/\./g, '').replace(/\,/g, '');
                var GiaNhap = $('#ContentPlaceHolder1_txtGiaNhapGoiY').val().replace(/\./g, '').replace(/\,/g, '');

                if ($('#ContentPlaceHolder1_txtShowLoaiHangCapCao').val().trim().length <= 0 || IDLoaiHangCapCao.trim().length <= 0 || SoLuong.trim().length <= 0 || GiaNhap.trim().length <= 0) {
                    alert('Hãy chọn hàng hóa và nhập số lượng');
                }
                else {
                    if (isNaN(SoLuong) || isNaN(GiaNhap)) {
                        alert('Số lượng và giá nhập phải là số');
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
                                    //alert(xmlhttp.responseText);
                                    LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');
                                    Dong1();

                                }
                                else {
                                    alert("Lỗi internet !")
                                }

                            }
                        }
                        xmlhttp.open("GET", "../Ajax4.aspx?Action=ThemTheoLoaiHangCapCaoPhieuXuat&IDLoaiHangCapCao=" + IDLoaiHangCapCao + "&IDPhieuNhap=" + IDPhieuNhap + "&GiaNhap=" + GiaNhap, true);
                        xmlhttp.send();
                    }
                }
            }
        }
        function ThemTheoLoaiHangHoa() {
            var IDPhieuNhap = '<%= Request.QueryString["IDPhieuNhap"].Trim() %>';
            var IDLoaiHangHoa = $('#ContentPlaceHolder1_slLoaiHangHoa').val();
            var IDSize = $('#ContentPlaceHolder1_slSize').val();
            var IDMauSac = $('#ContentPlaceHolder1_slMauSac').val();
            var SoLuong = $('#ContentPlaceHolder1_txtSoLuong').val().replace(/\./g, '').replace(/\,/g, '');
            var GiaNhap = $('#ContentPlaceHolder1_txtGiaNhap').val().replace(/\./g, '').replace(/\,/g, '');
            var loi = '';
            if (SoLuong.trim().length <= 0) {
                loi += 'Số lượng không được trống, nếu không thì nhập = 0';
            }
            if (isNaN(SoLuong.trim())) {
                loi += 'Số lượng phải là số';
            }

            if (GiaNhap.trim().length <= 0) {
                loi += 'Giá nhập không được trống, nếu không thì nhập = 0';
            }
            if (isNaN(GiaNhap.trim())) {
                loi += 'Giá nhập phải là số';
            }

            if (loi.trim().length <= 0) {


                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        //  alert(xmlhttp.responseText);
                        if (xmlhttp.responseText != "False") {
                            //alert(xmlhttp.responseText);
                            LoadChiTietPhieuNhap('<%= Request.QueryString["IDPhieuNhap"].Trim() %>');
                           Dong();
                       }
                       else {
                           alert("Kiểm tra lại tất cả thông tin có dấu (*) tất cả đều là bắt buộc !")
                       }

                   }
                }
               xmlhttp.open("GET", "../Ajax2.aspx?Action=ThemTheoLoaiHangHoa&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDPhieuNhap=" + IDPhieuNhap + "&IDSize=" + IDSize + "&IDMauSac=" + IDMauSac + "&SoLuong=" + SoLuong + "&GiaNhap=" + GiaNhap, true);
               xmlhttp.send();
           }
           else alert(loi);
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
       function LoadNhaCungCap() {
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
                       $("#ContentPlaceHolder1_txtTenNCC").autocomplete({

                           minLength: 0,
                           source: listKhachHangAutocomplete,
                           focus: function (event, ui) {
                               $("#ContentPlaceHolder1_txtTenNCC").val(ui.item.label);
                               return false;
                           },
                           select: function (event, ui) {
                               $("#ContentPlaceHolder1_txtTenNCC").val(ui.item.value);
                               $("#ContentPlaceHolder1_txtIDNCC").val(ui.item.id);
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
           xmlhttp.open("GET", "../Ajax.aspx?Action=KhachHangAutocomplete", true);
           xmlhttp.send();
       }
    </script>
    <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
    <script type="text/javascript">
        $('#ContentPlaceHolder1_txtNgayNhapChiTiet').datetimepicker({
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

        $('#ContentPlaceHolder1_txtNgayNhapChiTiet2').datetimepicker({
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
        $('#ContentPlaceHolder1_txtNgayNhap').datetimepicker({
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

