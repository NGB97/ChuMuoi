<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="CongNo.aspx.cs" Inherits="QuanLyDoiTra_CongNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
    <script>

        window.onload = function () {
            /* THH();*/ THHhoa(); LoadTenKhachHang(); MaPhieuXuat();

        }
        //
        function MaPhieuXuat() {
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
                        $("#ContentPlaceHolder1_txtMaPhieuXuat").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,

                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaPhieuXuat").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaPhieuXuat").val(ui.item.value);


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
        //

        function LoadTenKhachHang() {
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
                        $("#ContentPlaceHolder1_txtTenKhachHang").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,

                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenKhachHang").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenKhachHang").val(ui.item.value);


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
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadLenKhachHangAutocomplete", true);
            xmlhttp.send();
        }

        function THHhoa() {
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
                        $("#ContentPlaceHolder1_txtTenSanPham").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,

                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenSanPham").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenSanPham").val(ui.item.value);


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
            xmlhttp.open("GET", "../Ajax.aspx?Action=THHhoa", true);
            xmlhttp.send();
        }


        function MoXemBaoDuong() {
            document.getElementById('lightXemBaoDuong').style.display = 'block';
            document.getElementById('fadeXemBaoDuong').style.display = 'block';
        }
        function DongXemBaoDuong() {
            document.getElementById('lightXemBaoDuong').style.display = 'none';
            document.getElementById('fadeXemBaoDuong').style.display = 'none';
        }
        function MoXemChungTuKiemDinh() {
            document.getElementById('lightXemChungTuKiemDinh').style.display = 'block';
            document.getElementById('fadeXemChungTuKiemDinh').style.display = 'block';
        }
        function DongXemChungTuKiemDinh() {
            document.getElementById('lightXemChungTuKiemDinh').style.display = 'none';
            document.getElementById('fadeXemChungTuKiemDinh').style.display = 'none';
        }
        function MoXemChungNhanPCCC() {
            document.getElementById('lightXemChungNhanPCCC').style.display = 'block';
            document.getElementById('fadeXemChungNhanPCCC').style.display = 'block';
        }
        function DongXemChungNhanPCCC() {
            document.getElementById('lightXemChungNhanPCCC').style.display = 'none';
            document.getElementById('fadeXemChungNhanPCCC').style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">DANH MỤC CÔNG NỢ</div>
    <div class="box">
        <div class="box-body">
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên khách hàng:</b></div>
                          <div class="txtinput">
                                <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên hàng hóa:</b></div>
                          <div class="txtinput">
                               <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtTenSanPham" runat="server" name="Content.ContentName" type="text" value=""  />
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
                                <input class="form-control" data-val="true" data-val-required="" id="txtTuNgayBan" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Đến ngày bán:</b></div>
                          <div class="txtinput">
                               <input class="form-control" data-val="true" data-val-required="" id="txtDenNgayBan" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div>
             <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã phiếu xuất:</b></div>
                          <div class="txtinput">
                                <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtMaPhieuXuat" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        
                      </div>
                </div>
            <div class="row">
                <div class="col-sm-9">
                  <%--   <a class="btn btn-primary btn-flat" href="#"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>--%>
                </div>
                <div class="col-sm-3">
                        <div style="text-align:right;">
                            <asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Tìm kiếm" OnClick="btTimKiem_Click" />
                            <asp:Button ID="btTatCa" class="btn btn-primary btn-flat" runat="server" Text="Tất cả" OnClick="btTatCa_Click" />
                        </div>
                    </div>
            </div>
            <div id="dvNguoiDung" runat="server">
                <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                          STT 	 								

                        </th>
                     
                        <th class='th'>
                          Tên khách hàng
                        </th>
                        <th class='th'>
                         Đơn hàng
                        </th>
                        <th class='th'>
                         Ngày bán
                        </th>
                        <th class='th'>
                         Tên sản phẩm
                        </th>
                        <th class='th'>
                         Số lượng
                        </th>
                        <th class='th'>
                            Đơn giá xuất
                        </th>

                         <th class='th'>
                           Thành tiền
                        </th>
                         <th class='th'>
                          Đã trả
                        </th>
                         <th class='th'>
                        Số tiền nợ
                        </th>
                    </tr>
                  <%--  <tr>
                        <td>1</td>
                        <td>B0012</td>
                        <td>Xe bồn</td>
                        <td></td>
                        <td><a style="cursor:pointer" onclick="MoXemBaoDuong()">Bảo dưỡng</a></td>
                        <td><a style="cursor:pointer" onclick="MoXemChungTuKiemDinh()">Chứng từ kiểm định</a></td>
                        <td><a style="cursor:pointer" onclick="MoXemChungNhanPCCC()">Chứng nhận PCCC</a></td>
                        <td>
                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                        </td>
                    </tr>--%> 
                </table>
            </div>
        </div>
    </div>

</section>


    <!-- /.content -->
  </div>
        <!--Popup xem chứng nhận PCCC-->
    <div id="lightXemBaoDuong" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvBaoDuong" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">XEM CHỨNG NHẬN PCCC</div>
                <div id="dvXemBaoDuong" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số xe:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="B0012" disabled />
                                            </div>
                                        </div>
                                        <%--<div class="coninput1">
                                            <div class="titleinput"><b>CMND:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="CS mô tơ ngang 0.75 kW" disabled />
                                            </div>
                                        </div>--%>
                                    </div>
                        </div>
                        <table class="table table-bordered table-striped">
                                <tr>
                                    <th class="th">
                                        STT
                                    </th>
                                    <th class="th">
                                        Số phiếu bảo dưỡng
                                    </th>
                                    <th class="th">
                                        Ngày bảo dưỡng
                                    </th>
                                    <th class="th">
                                        Ngày bảo dưỡng tiếp theo
                                    </th>
                                </tr>
                                <tr>
                                        <td>
                                            1
                                        </td>
                                        <td>
                                            BD0001
                                        </td>
                                        <td>
                                            15/05/2016
                                        </td>
                                        <td>
                                            25/05/2017
                                        </td>
                                    </tr>
                                <tr>
                                        <td>
                                            2
                                        </td>
                                        <td>
                                            BD0002
                                        </td>
                                        <td>
                                            27/05/2017
                                        </td>
                                        <td>
                                            27/05/2018
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemBaoDuong" onclick="DongXemBaoDuong()" class="black_overlay"></div>
    <!--End popup--->
        <!--Popup xem chứng từ kiểm định-->
    <div id="lightXemChungTuKiemDinh" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvChungTuKiemDinh" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">XEM CHỨNG TỪ KIỂM ĐỊNH</div>
                <div id="dvXemChungTuKiemDinh" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số xe:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="B0012" disabled />
                                            </div>
                                        </div>
                                        <%--<div class="coninput1">
                                            <div class="titleinput"><b>CMND:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="CS mô tơ ngang 0.75 kW" disabled />
                                            </div>
                                        </div>--%>
                                    </div>
                        </div>
                        <table class="table table-bordered table-striped">
                                <tr>
                                    <th class="th">
                                        STT
                                    </th>
                                    <th class="th">
                                        Số phiếu kiểm định
                                    </th>
                                    <th class="th">
                                        Ngày đăng ký
                                    </th>
                                    <th class="th">
                                        Ngày hết hiệu lực
                                    </th>
                                    <th class="th">
                                        Camera hành trình
                                    </th>
                                </tr>
                                <tr>
                                        <td>
                                            1
                                        </td>
                                        <td>
                                            PKD090902
                                        </td>
                                        <td>
                                            15/05/2016
                                        </td>
                                        <td>
                                            25/05/2017
                                        </td>
                                        <td>
                                            Có
                                        </td>
                                    </tr>
                                <tr>
                                        <td>
                                            2
                                        </td>
                                        <td>
                                            PKD0002
                                        </td>
                                        <td>
                                            27/05/2017
                                        </td>
                                        <td>
                                            27/05/2018
                                        </td>
                                        <td>
                                            Không
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemChungTuKiemDinh" onclick="DongXemChungTuKiemDinh()" class="black_overlay"></div>
    <!--End popup--->
        <!--Popup xem chứng nhận PCCC-->
    <div id="lightXemChungNhanPCCC" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvChungNhanPCCC" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">XEM CHỨNG NHẬN PCCC</div>
                <div id="dvXemChungNhanPCCC" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số xe:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="B0012" disabled />
                                            </div>
                                        </div>
                                        <%--<div class="coninput1">
                                            <div class="titleinput"><b>CMND:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="CS mô tơ ngang 0.75 kW" disabled />
                                            </div>
                                        </div>--%>
                                    </div>
                        </div>
                        <table class="table table-bordered table-striped">
                                <tr>
                                    <th class="th">
                                        STT
                                    </th>
                                    <th class="th">
                                        Số chứng nhận
                                    </th>
                                    <th class="th">
                                        Ngày đăng ký
                                    </th>
                                    <th class="th">
                                        Ngày hết hạn
                                    </th>
                                </tr>
                                <tr>
                                        <td>
                                            1
                                        </td>
                                        <td>
                                            PCCC090902
                                        </td>
                                        <td>
                                            15/05/2016
                                        </td>
                                        <td>
                                            25/05/2017
                                        </td>
                                    </tr>
                                <tr>
                                        <td>
                                            2
                                        </td>
                                        <td>
                                            PCCC0002
                                        </td>
                                        <td>
                                            27/05/2017
                                        </td>
                                        <td>
                                            27/05/2018
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemChungNhanPCCC" onclick="DongXemChungNhanPCCC()" class="black_overlay"></div>
    <!--End popup--->

        <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
    <script type="text/javascript">
        $('#ContentPlaceHolder1_txtTuNgayBan').datetimepicker({
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
        $('#ContentPlaceHolder1_txtDenNgayBan').datetimepicker({
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

