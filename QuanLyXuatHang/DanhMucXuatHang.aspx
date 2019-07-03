<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucXuatHang.aspx.cs" Inherits="QuanLyXuatNhap_DanhMucXuatHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />
    <script>
        window.onload = function () {
            // loadmaphieuxuat();

        }
        function InPhieuTongHopXuatHang(IDPhieuXuat) {

            //var TongTienKhachNo = $("#ContentPlaceHolder1_txtTongTienKhachNo").val();

            //var TongTienPhaiTra = $("#ContentPlaceHolder1_txtTongTienPhaiTra").val();

            //var TienThanhToan = $("#ContentPlaceHolder1_txtTienKhachThanhToan").val();
            //var IdKho = $("#ContentPlaceHolder1_txtIDKho").val();

            //var TienDonHang = $("#ContentPlaceHolder1_txtTongTienDonHang").val();

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
            xmlhttp.open("GET", "../Ajax.aspx?Action=InPhieuTongHopXuatHang2&IDPhieuXuat=" + IDPhieuXuat, true);
            xmlhttp.send();
        }
        function InPhieuXuatHang(IDPhieuXuat) {
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=InPhieuXuatHang&IDPhieuXuat=" + IDPhieuXuat, true);
            xmlhttp.send();
        }
        //
        function ExportExcel(MaPhieuXuat) {
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
                        alert(xmlhttp.responseText);
                    }
                    else {
                        alert("Không có chi tiết để xem!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=ExportExcel&MaPhieuXuat=" + MaPhieuXuat, true);
            xmlhttp.send();
        }
        //
        function ExportExcel2(MaPhieuXuat) {
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
                        alert(xmlhttp.responseText);
                    }
                    else {
                        alert("Không có chi tiết để xem!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=ExportExcel2&MaPhieuXuat=" + MaPhieuXuat, true);
            xmlhttp.send();
        }

        function LoadChiTietXuatHang(IDPhieuXuat) {
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
                        var txt = xmlhttp.responseText;

                        $("#dvXemSanPham").html(txt); MoXemQuyCach();
                        // window.location.hash = IDPhieuXuat;

                    }
                    else {
                        alert("Không có chi tiết để xem!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadChiTietXuatHang&IDPhieuXuat=" + IDPhieuXuat, true);
            xmlhttp.send();
        }


        //
        function DeletePhieuXuat(IDPhieuXuat) {

            if (confirm("Khi xóa phiếu xuất hàng, tất cả hàng hóa trong phiếu xuất đều sẽ bị xóa. Bạn có chắc chắn xóa không?")) {
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
                            window.location.reload();
                        }
                        else
                            alert("Không thể xóa!")
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeletePhieuXuat&IDPhieuXuat=" + IDPhieuXuat, true);
                xmlhttp.send();
            }

        }
        //
        function loadmaphieuxuat() {
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
                        $("#ContentPlaceHolder1_txtMaXuatHang").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,

                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaXuatHang").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaXuatHang").val(ui.item.value);


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
            xmlhttp.open("GET", "../Ajax.aspx?Action=loadmaphieuxuat", true);
            xmlhttp.send();
        }


        function MoXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'block';
            document.getElementById('fadeXemQuyCach').style.display = 'block';
        }
        function DongXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'none';
            document.getElementById('fadeXemQuyCach').style.display = 'none';
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="content-wrapper">
            <!-- Main content -->
            <section class="content">
                <div class="title">QUẢN LÝ BÁN HÀNG</div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <div class="box">
                    <div class="box-body">
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <%--  --%>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Mã phiếu :</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaXuatHang" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>

                                <div class="coninput1">
                                    <div class="titleinput"><b>Mã hàng hóa:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <%--  --%>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Tên khách :</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>

                                <div class="coninput1">
                                    <div class="titleinput"><b>SĐT:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtSDT" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Từ ngày bán:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtTuNgayXuat" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Đến ngày bán:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtDenNgayXuat" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-9">
                                <a class="btn btn-primary btn-flat" href="DanhMucXuatHang-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
                            </div>
                            <div class="col-sm-3">
                                <div style="text-align: right;">
                                    <asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Tìm kiếm" OnClick="btTimKiem_Click" />
                                    <asp:Button ID="btTatCa" class="btn btn-primary btn-flat" runat="server" Text="Tất cả" OnClick="btTatCa_Click" />
                                </div>
                            </div>
                        </div>
                        <div id="dvNguoiDung" runat="server">
                            <table class='table table-bordered table-striped'>
                                <tr>
                                    <th class='th'>STT
                                    </th>
                                    <th class='th'>Mã phiếu xuất 			

                                    </th>
                                    <th class='th'>Ngày lập phiếu xuất
                                    </th>

                                    <th class='th'>Ghi chú	

                                    </th>
                                    <th class='th'></th>
                                    <th class='th'></th>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td>Ngày xuất</td>
                                    <td>BH001</td>
                                    <td>giấy văn phòng xanh</td>



                                    <td>
                                        <a href="#">
                                            <img class="imgedit" src="../images/edit.png" />Sửa</a>

                                    </td>
                                    <td>

                                        <a href="#">
                                            <img class="imgedit" src="../images/delete.png" />Xóa</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

            </section>


            <!-- /.content -->
        </div>
        <!--Popup xem quy cách-->
        <div id="lightXemQuyCach" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
            <div class="box">
                <div id="dvQuyCach" class="box-body">

                    <div id="dvXemSanPham" style="padding: 10px; text-align: center">

                        <table class="table table-bordered table-striped">
                            <tr>
                                <th class="th">STT
                                </th>
                                <th class="th">Quy cách
                                </th>
                                <th class="th">Tình trạng
                                </th>
                            </tr>
                            <tr>
                                <td>1
                                </td>
                                <td>Quy cách 1
                                </td>
                                <td>Mới
                                </td>
                            </tr>
                            <tr>
                                <td>2
                                </td>
                                <td>Quy cách 2
                                </td>
                                <td>Cũ
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div id="fadeXemQuyCach" onclick="DongXemQuyCach()" class="black_overlay"></div>
        <!--End popup--->
        <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
        <script type="text/javascript">
            $('#ContentPlaceHolder1_txtTuNgayXuat').datetimepicker({
                //dayOfWeekStart : 1,
                //todayBtn: "linked",
                language: "it",
                autoclose: true,
                todayHighlight: true,
                timepicker: false,
                dateFormat: 'dd/mm/yyyy',
                format: 'd/m/Y',
                formatDate: 'Y/m/d',
                // value: 'today'
            });
            $('#ContentPlaceHolder1_txtDenNgayXuat').datetimepicker({
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
    </form>
</asp:Content>

