<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucXuatHang-CapNhat.aspx.cs" Inherits="QuanLyDungCu_DanhMucXuatHang_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />
    <script>
        window.onload = function () {
            //TenSanPhamAutocomplete();
            LoadKH();
            LoadKho();
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
        function MoXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'block';
            document.getElementById('fadeXemQuyCach').style.display = 'block';
        }
        function DongXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'none';
            document.getElementById('fadeXemQuyCach').style.display = 'none';
        }
        function TinhTien() {
            $('#ContentPlaceHolder1_txtTienKhachThanhToan').keyup(function () {
                $('#ContentPlaceHolder1_txtTienKhachThanhToan').val($('#ContentPlaceHolder1_txtTienKhachThanhToan').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
            }
            );
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Main content -->
        <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN BÁN HÀNG</div>
        <div class="title1" id="NgayTieuDe" runat="server"></div>
        <section class="content">
            <div class="box">
                <div class="box-body">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Mã phiếu bán(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaPhieuXuat" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                                <div class="coninput2">
                                    <div class="titleinput"><b>Ngày bán(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtNgayXuat" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Khách hàng(*):</b></div>
                                    <div class="txtinput">
                                        <input placeholder="--Chọn--" class="form-control" data-val="true" data-val-required="" id="txtKhachHang" runat="server" name="Content.ContentName" type="text" value="" />
                                        <input placeholder="--Chọn--" class="form-control" data-val="true" data-val-required="" id="txtIDKhachHang" runat="server" name="Content.ContentName" type="hidden" value="" />
                                    </div>
                                </div>
                                <div class="coninput2" style="display: none;">
                                    <div class="titleinput"><b>Tiền khách thanh toán(*):</b></div>
                                    <div class="txtinput">
                                        <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtTienKhachThanhToan" runat="server" name="Content.ContentName" type="text" value="0" />
                                    </div>
                                </div>
                                <div class="coninput2">
                                    <div class="titleinput"><b>Xuất từ kho(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtKho" runat="server" name="Content.ContentName" type="hidden" value="" placeholder="--Chọn--" />
                                        <select class="form-control" data-val="true" data-val-required="" id="txtIDKho" runat="server" name="Content.ContentName"></select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" style="display: none;">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>


                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                            <div class="col-md-10">
                                <textarea class="form-control" id="txtGhiChu" runat="server" name="Content.ContentName"></textarea>
                            </div>
                        </div>


                        <div class="box-footer">
                            <table>
                                <tr>
                                    <td>
                                        <div runat="server" id="QuayLai">

                                            <a class="btn btn-primary btn-flat" href="../QuanLyXuatHang/DanhMucXuatHang.aspx"><i class="glyphicon glyphicon-chevron-left"></i>Quay lại</a>
                                        </div>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                                    </td>
                                </tr>
                            </table> 
                        </div>
                    </form>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
    <!--Popup xem quy cách-->
    <div id="lightXemQuyCach" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvQuyCach" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">CẬP NHẬT XUẤT HÀNG</div>
                <div id="dvXemQuyCach" style="padding: 10px; text-align: center">
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Tên hàng hóa:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtTenHangHoa" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Tên khách hàng:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtTenKhachHang" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Đơn giá xuất:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtDonGiaXuat" disabled="disabled" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Số lượng:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtSoLuong" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Thành tiền:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" id="txtThanhTien" disabled="disabled" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>

                            <div class="coninput1">
                                <div class="titleinput"><b>Tình trạng:</b></div>
                                <div class="txtinput">
                                    <select class="form-control" id="slTinhTrang" data-val="true" data-val-required="" name="Content.ContentName">
                                        <option>Đã thanh toán
                                        </option>

                                        <option>Còn nợ
                                        </option>
                                    </select>

                                </div>
                            </div>

                        </div>
                    </div>




                    <div style="text-align: center">
                        <input type="button" value="Thêm" class="btn btn-primary btn-flat" style="width: 80px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="fadeXemQuyCach" onclick="DongXemQuyCach()" class="black_overlay"></div>
    <!--End popup--->
    <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
    <script type="text/javascript">
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
            value: 'today'
        });

    </script>
</asp:Content>

