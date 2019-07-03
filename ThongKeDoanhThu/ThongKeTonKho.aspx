<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="ThongKeTonKho.aspx.cs" Inherits="BaoCao_BaoCaoTongHop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />

    <script>
        window.onload = function () {
            //TenSanPhamAutocomplete();
            //MaSanPhamAutocomplete(); loadphieu();
            LoadKho();
            LoadLoaiHangHoa(); 
        }


        function rsSoLuongTon(idLoaiHangHoa) {
            if (confirm("Bạn có muốn reset lại số lượng tồn kho?")) {
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
                            alert(txt)
                            window.location.reload();
                        }
                    }
                }

                xmlhttp.open("GET", "../Ajax.aspx?Action=rsSoLuongTon&idLoaiHangHoa=" + idLoaiHangHoa, true);
                xmlhttp.send();
            }
        }
        function LoadChiTietTonKHo(IDLoaiHangHoa) {
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadChiTietTonKHo&IDLoaiHangHoa=" + IDLoaiHangHoa, true);
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

                        $("#ContentPlaceHolder1_txtTenHangHoa").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            //appendTo: '#lightXemDungCu',
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                // alert('abc');

                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.label);
                                $("#ContentPlaceHolder1_txtIDHangHoa").val(ui.item.id);

                                return false;
                            }
                        });
                    }
                    else {
                        alert("Lỗi internet !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadLoaiHangHoa", true);
            xmlhttp.send();
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
                                $("#ContentPlaceHolder1_txtKho").val(ui.item.value);
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
        //
        function DeleteHangHoa(IDHangHoa) {
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
                        if (xmlhttp.responseText == "True") {
                            window.location.reload();
                        }
                        else
                            alert("Lỗi !")
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeleteHangHoa&IDHangHoa=" + IDHangHoa, true);
                xmlhttp.send();
            }
        }
        //
        function MaSanPhamAutocomplete() {
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
                        $("#ContentPlaceHolder1_txtMaHangHoa").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa").val(ui.item.value);
                                //  $("#ContentPlaceHolder1_idNCC").val(ui.item.id);
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=MaSanPhamAutocomplete", true);
            xmlhttp.send();
        }

        function TenSanPhamAutocomplete() {
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
                        $("#ContentPlaceHolder1_txtTenHangHoa").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.value);
                                //  $("#ContentPlaceHolder1_idNCC").val(ui.item.id);
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=TenSanPhamAutocomplete", true);
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
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                <div class="title">THỐNG KÊ TỒN KHO HÀNG HÓA</div>
                <div class="box">
                    <div class="box-body">

                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1" style="display: none;">
                                    <div class="titleinput"><b>Kho:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtNgayDauKy" runat="server" name="Content.ContentName" type="hidden" value="" />
                                        <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtKho" runat="server" name="Content.ContentName" type="text" value="" />
                                        <input class="form-control" data-val="true" data-val-required="" id="txtIDKho" runat="server" name="Content.ContentName" type="hidden" value="" />
                                    </div>
                                </div>

                                <div class="coninput1">
                                    <div class="titleinput"><b>Hàng hóa:</b></div>
                                    <div class="txtinput">
                                        <input placeholder="--Chọn--" class="form-control" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                                        <input class="form-control" data-val="true" data-val-required="" id="txtIDHangHoa" runat="server" name="Content.ContentName" type="hidden" value="" />
                                    </div>
                                </div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Loại hàng hóa:</b></div>
                                    <div class="txtinput">
                                        <select class="form-control" data-val="true" data-val-required="" id="txtLoaiHangCapCao" runat="server" name="Content.ContentName" type="text" value=""></select>
                                    </div>
                                </div>
                                <div class="coninput1" style="display: none;">

                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtNgayCuoiKy" runat="server" name="Content.ContentName" type="hidden" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" style="display: block;">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>

                                <div class="coninput1" style="display: none;">
                                    <div class="titleinput"><b>Từ phiếu xuất:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtTuPhieu" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                                <div class="coninput1" style="display: none;">
                                    <div class="titleinput"><b>Đến phiếu xuất:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtDenPhieu" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        

                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Màu hàng hoá:</b></div>
                                    <div class="txtinput">
                                        <select id="slMauSacHangHoa" runat="server"  class="form-control" ></select>
                                    </div>
                                </div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Size hàng hoá:</b></div>
                                    <div class="txtinput">
                                        <select id="slSizeHangHoa" runat="server"  class="form-control" ></select>
                                    </div>
                                </div>
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Chất liệu hàng hoá:</b></div>
                                    <div class="txtinput">
                                        <select id="slChatLieuHangHoa" runat="server"  class="form-control" ></select>
                                    </div>
                                </div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Kiểu dáng hàng hoá:</b></div>
                                    <div class="txtinput">
                                        <select id="slKieuDangHangHoa" runat="server"  class="form-control" ></select>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-sm-9" runat="server" id="dvTongTien">
                            </div>
                            <div class="col-sm-3">
                                <div style="text-align: right;">
                                    <asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Tìm kiếm" OnClick="btTimKiem_Click" />

                                    <asp:Button ID="TC" runat="server" Text="Tất cả" class="btn btn-primary btn-flat" OnClick="TC_Click" />
                                </div>
                            </div>
                        </div>

                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <div id="dvNguoiDung" runat="server">
                            <table class='table table-bordered table-striped'>
                                <tr>
                                    <th style='background-color: white;' rowspan='3'>
                                        <img src="../dist/img/UNI.png" height='100' width='70' />
                                    </th>
                                    <th style='background-color: white;' colspan='2'>CÔNG TY CỔ PHẦN ViỄN LIÊN			

                                    </th>

                                    <th style='background-color: white;'>&nbsp;
                         
                                    </th>
                                    <th style='background-color: white;'>&nbsp;
                         
                                    </th>


                                    <th style='background-color: white;'>&nbsp;
                                    </th>

                                    <th style='background-color: white;'>&nbsp;
                                    </th>
                                    <th style='background-color: white;'>&nbsp;
                                    </th>

                                    <th style='background-color: white;'>&nbsp;
                                    </th>
                                </tr>
                                <tr>

                                    <td style='background-color: white; font-style: normal' colspan='4'>Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh		

                                    </td>


                                    <td style='background-color: white;'>&nbsp;
                                    </td>

                                    <td style='background-color: white;'>&nbsp;
                                    </td>
                                    <td style='background-color: white;'>&nbsp;
                                    </td>

                                    <td style='background-color: white;'>&nbsp;
                                    </td>
                                </tr>
                                <tr>

                                    <td style='background-color: white;' colspan='2'>
                                        <b><i><u>Tel</u></i></b> : 028 3620 8997  -  <b><i><u>Fax</u></i></b> : 028 3620 8997

                                    </td>

                                    <td style='background-color: white;'>&nbsp;
                         
                                    </td>
                                    <td style='background-color: white;'>&nbsp;
                         
                                    </td>


                                    <td style='background-color: white;'>&nbsp;	
                                    </td>

                                    <td style='background-color: white;'>&nbsp;
                                    </td>
                                    <td style='background-color: white;'>&nbsp;
                                    </td>

                                    <td style='background-color: white;'>&nbsp;
                                    </td>
                                </tr>
                                <tr>

                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan='4' style='background-color: white; font-size: 25px; text-align: left;'><b>BẢNG KÊ CHI TIẾT NHẬP-XUẤT-TỒN</b></td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                </tr>
                                <tr style="height: 30px;">
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                    <td style='background-color: white;'>&nbsp;	</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                    <td style='background-color: white;'>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style='background-color: white; text-align: center;' rowspan='2'><b>Ngày</b>	</td>
                                    <td style='background-color: white; text-align: center;' rowspan='2'><b>Mã hàng<br />
                                        xuất</b>	</td>
                                    <td style='background-color: white; text-align: center;' rowspan='2'><b>Tên hàng xuất</b>	</td>
                                    <td style='background-color: white; text-align: center;' rowspan='2'><b>KIỂM KÊ<br />
                                        ĐẦU KỲ</b>	</td>
                                    <td style='background-color: white; text-align: center;' colspan='3'><b>NHẬP XUẤT TRONG KỲ</b>	</td>
                                    <td style='background-color: white; text-align: center;' rowspan='2'><b>Thành<br />
                                        tiền</b>	</td>
                                    <td style='background-color: white; text-align: center;'><b>Ghi chú</b></td>
                                </tr>

                                <tr>
                                    <td style='background-color: white; text-align: center;'><b>NHẬP</b></td>
                                    <td style='background-color: white; text-align: center;'><b>XUẤT</b></td>
                                    <td style='background-color: white; text-align: center;'><b>TỒN</b></td>
                                    <td style='background-color: white;'></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

            </section>


            <div id="lightXemQuyCach" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
                <div class="box">
                    <div id="dvQuyCach" class="box-body">

                        <div id="dvXemSanPham" style="padding: 10px; text-align: center">
                        </div>
                    </div>
                </div>
            </div>
            <div id="fadeXemQuyCach" onclick="DongXemQuyCach()" class="black_overlay"></div>


            <!-- /.content -->
        </div>
        <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
        <script type="text/javascript">
            //$('#ContentPlaceHolder1_txtNgayCuoiKy').datetimepicker({
            //    //dayOfWeekStart : 1,
            //    //todayBtn: "linked",
            //    language: "it",
            //    autoclose: true,
            //    todayHighlight: true,
            //    timepicker: false,
            //    dateFormat: 'dd/mm/yyyy',
            //    format: 'd/m/Y',
            //    formatDate: 'Y/m/d',
            //    //value: 'today'
            //});
            //$('#ContentPlaceHolder1_txtNgayDauKy').datetimepicker({
            //    //dayOfWeekStart : 1,
            //    //todayBtn: "linked",
            //    language: "it",
            //    autoclose: true,
            //    todayHighlight: true,
            //    timepicker: false,
            //    dateFormat: 'dd/mm/yyyy',
            //    format: 'd/m/Y',
            //    formatDate: 'Y/m/d',
            //    //value: 'today'
            //});
        </script>
    </form>
</asp:Content>

