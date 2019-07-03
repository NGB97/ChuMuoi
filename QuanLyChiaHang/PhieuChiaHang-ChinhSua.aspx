<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="PhieuChiaHang-ChinhSua.aspx.cs" Inherits="DanhMuc_DonViTinh_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />
    <script>
        window.onload = function () {
        }

        function ThemHangHoa() {
            var TenHangHoa = $("#ContentPlaceHolder1_slHangHoa option:selected").text();
            var IDHangHoa = $("#ContentPlaceHolder1_idslHangHoa :selected").val();

            var TenSize = $("#ContentPlaceHolder1_slSize option:selected").text();
            var IDSize = $("#ContentPlaceHolder1_slSize :selected").val();

            var TenMauSac = $("#ContentPlaceHolder1_slMauSac option:selected").text();
            var IDMauSac = $("#ContentPlaceHolder1_slMauSac :selected").val();

            var TenKhachHang = $("#ContentPlaceHolder1_slKhachHang option:selected").text();
            var IDKhachHang = $("#ContentPlaceHolder1_slKhachHang :selected").val();

            var SoLuongChia = KiemTraKhongNhap($("#ContentPlaceHolder1_txtSoLuongXuat").val());
            var GiaBan = KiemTraKhongNhap($("#ContentPlaceHolder1_txtGiaBan").val());

            var STT = KiemTraKhongNhap($("#ContentPlaceHolder1_txtSTT").val());
            STT++;
            $("#ContentPlaceHolder1_txtSTT").val(STT);
            var html = "";
            html += "<tr id='tr_" + STT + "'>";
            html += "       <td style='display: none;' id='td_ChuoiDuLieu'>" + IDHangHoa + "@_@" + IDSize + "@_@" + IDMauSac + "@_@" + IDKhachHang + "@_@" + SoLuongChia + "@_@" + GiaBan + "</td>";
            html += "       <td>" + TenHangHoa + "</td>";
            html += "       <td>" + TenSize + "</td>";
            html += "       <td>" + TenMauSac + "</td>";
            html += "       <td>" + SoLuongChia + "</td>";
            html += "       <td>" + GiaBan.replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + "</td>";
            html += "       <td>" + (GiaBan * SoLuongChia).toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + "</td>";
            html += "       <td>" + TenKhachHang + "</td>";
            //html += "       <td>";
            //html += "         <a href='#'  onclick='SuaHangHoa(" + STT + ")'> <img title='Sửa' class='imgCommand' src='../Images/edit.png' /> Sửa </a>";
            //html += "       </td>";
            html += "       <td>";
            html += "          <a href='#' onclick='XoaHangHoa(" + STT + ")'> <img title='Xoá' class='imgCommand' src='../Images/Delete.png' /> Xoá </a>";
            html += "       </td>";
            html += " </tr>";

            $("#ContentPlaceHolder1_tbody_ChiTietPhieuChia").append(html);
        }
        function XoaHangHoa(STT) {
            $("#tr_" + STT).remove();
        }
        function btLuuJS_Click() {
            var maPhieuXuat = $("#ContentPlaceHolder1_txtMaPhieuXuat").val().trim();
            var NgayXuat = $("#ContentPlaceHolder1_txtNgayTao").val().trim();
            var IDKho = $("#ContentPlaceHolder1_txtIDKho").val().trim();
            var GhiChu = $("#ContentPlaceHolder1_txtGhiChu").val().trim();

            if (maPhieuXuat == "")
            {
                alert("Vui lòng nhập mã phiếu chia !");
                return;
            }
            if (NgayXuat == "") {
                alert("Vui lòng chọn ngày lập !");
                return;
            }
            if (IDKho == "") {
                alert("Vui lòng chọn kho xuất !");
                return;
            } 
            var chuoiDuLieu_ChiTiet = "";
            var STT = KiemTraKhongNhap($("#ContentPlaceHolder1_txtSTT").val()); 
            for (var i = 0; i < STT; i++) {
                var ChuoiDuLieu = $("#tr_" + (i+1)).children("#td_ChuoiDuLieu").html();
                if (ChuoiDuLieu != undefined) {
                    chuoiDuLieu_ChiTiet += ChuoiDuLieu + "|~~|";
                }
            }
            $("#ContentPlaceHolder1_txtChuoiDuLieu").val(chuoiDuLieu_ChiTiet);

            document.getElementById("ContentPlaceHolder1_btLuu").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Main content -->
        <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN PHIẾU CHIA</div>
        <div class="title1"><a href="PhieuChiaHang.aspx"><i class="fa fa-step-backward"></i>Danh sách phiếu chia</a></div>
        <section class="content">
            <div class="box">
                <div class="box-body">
                    <form class="form-horizontal" runat="server">
                        <asp:HiddenField runat="server" ID="txtSTT" />
                        <asp:HiddenField runat="server" ID="txtChuoiDuLieu" />
                        <asp:HiddenField runat="server" ID="txtPX" />
                        <table style="width: 100%;" border="0">
                            <tr>
                                <td style="width: 30%;" valign="top">
                                    <div class="box" style="padding: 4px 4px 4px 4px;">
                                        <b>Mã phiếu xuất(*):</b>
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaPhieuXuat" runat="server" name="Content.ContentName" type="text" value="" />
                                        <b>Ngày chia(*):</b>
                                        <input class="form-control" data-val="true" data-val-required="" id="txtNgayTao" runat="server" name="Content.ContentName" type="text" value="" />
                                        <b>Xuất từ kho(*):</b>
                                        <select class="form-control" data-val="true" data-val-required="" id="txtIDKho" runat="server" name="Content.ContentName" type="text"></select>
                                        <b>Ghi chú:</b>
                                        <textarea class="form-control" id="txtGhiChu" name="Content.ContentName" runat="server"></textarea>
                                        <br />
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
                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>H. hóa(*): </b></div>
                                                        <div class="txtinput">
                                                            <asp:DropDownList ID="slHangHoa" class="form-control" runat="server" OnSelectedIndexChanged="LoadSize_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            <select style="display:none;" class="form-control" data-val="true" data-val-required="" id="idslHangHoa" runat="server" name="Content.ContentName">
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>Size(*): </b></div>
                                                        <div class="txtinput">
                                                            <asp:DropDownList class="form-control" data-val="true" data-val-required="" OnSelectedIndexChanged="LoadMauSac_SelectedIndexChanged" AutoPostBack="true" disabled="disabled" id="slSize" runat="server" name="Content.ContentName">
                                                            </asp:DropDownList>
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
                                                           <%-- <select class="form-control" data-val="true" data-val-required="" disabled="disabled" id="slMauSac" runat="server" name="Content.ContentName">
                                                            </select>--%>
                                                            <asp:DropDownList class="form-control" data-val="true" data-val-required="" OnSelectedIndexChanged="LoadIDHH_SelectedIndexChanged" AutoPostBack="true" disabled="disabled" id="slMauSac" runat="server" name="Content.ContentName">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>SL(*): </b></div>
                                                        <div class="txtinput">
                                                            <input class="form-control" data-val="true" data-val-required="" id="txtSoLuongXuat" runat="server" name="Content.ContentName" type="text" value="0" oninput='DinhDangTien(this.id)' onkeypress='onlyNumber(event)' />

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <br />
                                            <div>
                                                <div class="row">
                                                    <div class="dvnull">&nbsp;</div>
                                                     <div class="coninput1">
                                                        <div class="titleinput"><b>Khách hàng(*): </b></div>
                                                        <div class="txtinput">
                                                            <select class="form-control" data-val="true" data-val-required="" id="slKhachHang" runat="server" name="Content.ContentName" value="0">
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="coninput1">
                                                        <div class="titleinput"><b>Giá bán(*): </b></div>
                                                        <div class="txtinput">
                                                            <input class="form-control" data-val="true" data-val-required="" id="txtGiaBan" runat="server" name="Content.ContentName" oninput='DinhDangTien(this.id)' onkeypress='onlyNumber(event)' />
                                                        </div>
                                                    </div>

                                                   
                                                </div>

                                            </div>

                                            <br />
                                            <a style="cursor: pointer;" onclick='ThemHangHoa();' class="btn btn-primary btn-flat">
                                                <div>Thêm</div>
                                            </a>
                                            <br />
                                            <br />
                                        </div>
                                      </div>
                                </td>
                            </tr>
                                        <div class="form-group">
                                            <div class="row">
                                                <table class="table table-bordered table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th class='th'>Tên hàng hóa </th>
                                                            <th class='th'>Size </th>
                                                            <th class='th'>Màu </th>
                                                            <th class='th'>Số lượng </th>
                                                            <th class='th'>Đơn giá </th>
                                                            <th class='th'>Thành tiền </th>
                                                            <th class='th'>Khách hàng</th>
                                                            <th class='th'></th> 
                                                        </tr>
                                                    </thead>
                                                    <tbody id="tbody_ChiTietPhieuChia" runat="server">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-2 control-label" for="Content_ContentName"></label>
                                            <div class="col-md-10">

                                                <div class="form-group">
                                                    <div id="row">
                                                        <div class="coninput2">
                                                            <div class="txtinput">
                                                                <b>Tổng tiền đơn hàng:</b>
                                                                <input readonly="true" class="form-control" data-val="true" data-val-required="" id="txtTongTienDonHang" runat="server" name="Content.ContentName" type="text" value="0" />
                                                                <br />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                
                            <tr> 
                                <td style="width: 30%; visibility: hidden;" valign="top"></td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: center; white-space: nowrap;">

                                    <table>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td style="text-align:right;">
                                                <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" Style="display: none;" />
                                                <a id="btnLuuJS" runat="server" class="btn btn-primary btn-flat" onclick="btLuuJS_Click()">LƯU</a></td>
                                            <td>&nbsp;</td>
                                            <td style="text-align:left;"><asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" /></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                        </table>

                    </form>

                </div>

            </div>
        </section>
        <!-- /.content -->
    </div>

    <script src="../plugins/select2/select2.min.js"></script>
    <link href="../plugins/select2/select2.min.css" rel="stylesheet" />

    <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
    <script type="text/javascript">
       // $("#ContentPlaceHolder1_slHangHoa,#ContentPlaceHolder1_slKhachHang,#ContentPlaceHolder1_slMauSac").select2();

        $('#ContentPlaceHolder1_txtNgayTao').datetimepicker({
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

        function DinhDangTien(id) {
            var check = $('#' + id).val().replace(/\,/g, '');
            if (isNaN(check)) {
                $('#' + id).val("0");
            }
            else {
                $('#' + id).val($('#' + id).val().replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, ",").replace(/^\s+/, '').replace(/\s+$/, ''));
            }
        }
        function onlyNumber(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        function KiemTraKhongNhap(txt) {
            try {

                txt.trim();
            } catch (e) {
                txt = "";
            }
            try {
                var a = parseFloat(Number);
            }
            catch (e) {
                Number = "0";
            }
            if (txt == "") {
                txt = "0";
            }
            else if (txt == undefined) {
                txt = "0";
            }
            else if (txt == "-") {
                txt = "0";
            }
            else//bỏ dấu chấm 100.000  => 100000
            {
                try {
                    txt = txt.replace(/\,/g, '').trim();
                } catch (e) { }
            }
            return txt;
        }
    </script>
</asp:Content>

