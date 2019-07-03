<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucLoaiHangHoaSua.aspx.cs" Inherits="DanhMuc_DanhMucKhachHang_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        window.onload = function () {
            LoadChiTietHangHoa('<%= Request.QueryString["IDLoaiHangHoa"].Trim() %>');

        }
        function ThemHangHoa() {
            var IDLoaiHangHoa = '<%= Request.QueryString["IDLoaiHangHoa"].Trim() %>';
            var IDSize = $('#ContentPlaceHolder1_txtSize').val();
            var IDMauSac = $('#ContentPlaceHolder1_txtMau').val();
            var IDKieuDang = $('#ContentPlaceHolder1_txtKieuDang').val();
            var IDChatLieu = $('#ContentPlaceHolder1_txtChatLieu').val();
            var GhiChu = $('#GhiChu').val();
            if (IDSize.trim().length <= 0 || IDMauSac.trim().length <= 0 || IDKieuDang.trim().length <= 0 || IDChatLieu.trim().length <= 0) {
                alert('Hãy chọn đủ các mục cần yêu cầu')
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
                            LoadChiTietHangHoa('<%= Request.QueryString["IDLoaiHangHoa"].Trim() %>');
                            //DongXemGiayPhepLaiXe();
                        }
                        else {
                            if (xmlhttp.responseText == "False1") {
                                alert("Size ,màu, kiểu dáng, chất liệu này đã tồn tại !")
                            }
                            else
                                alert("Lỗi internet !")
                        }
                    }
                }
                xmlhttp.open("GET", "../Ajax2.aspx?Action=ThemHangHoa&IDSize=" + IDSize + "&IDMauSac=" + IDMauSac + "&GhiChu=" + GhiChu + "&IDLoaiHangHoa=" + IDLoaiHangHoa + "&IDKieuDang=" + IDKieuDang + "&IDChatLieu=" + IDChatLieu, true);
                xmlhttp.send();
            }
        }
        function DeleteHangHoa(IDHangHoa) {
            if (confirm('Bạn có muốn xóa không ?')) {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        // alert(xmlhttp.responseText);
                        if (xmlhttp.responseText != "False") {
                            LoadChiTietHangHoa('<%= Request.QueryString["IDLoaiHangHoa"].Trim() %>');
                        }
                        else
                            alert("Lỗi !")
                    }
                }
                xmlhttp.open("GET", "../Ajax2.aspx?Action=DeleteHangHoa&IDHangHoa=" + IDHangHoa, true);
                xmlhttp.send();
            }

        }

        function DeleteHinhAnh(IdHinhAnh) {
            if (confirm('Bạn có muốn xóa không ?')) {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        // alert(xmlhttp.responseText);
                        if (xmlhttp.responseText != "False") {

                            window.location.reload();
                        }
                        else
                            alert("Không thể xóa hình ảnh.... !")
                    }
                }
                xmlhttp.open("GET", "../Ajax2.aspx?Action=DeleteHinhAnh&IdHinhAnh=" + IdHinhAnh, true);
                xmlhttp.send();
            }

        }

        function LoadChiTietHangHoa(IDLoaiHangHoa) {

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
            xmlhttp.open("GET", "../Ajax2.aspx?Action=LoadChiTietHangHoa&IDLoaiHangHoa=" + IDLoaiHangHoa, true);
            xmlhttp.send();

        }
        function MoXemGiayPhepLaiXe() {
            document.getElementById('lightXemGiayPhepLaiXe').style.display = 'block';
            document.getElementById('fadeXemGiayPhepLaiXe').style.display = 'block';
        }
        function DongXemGiayPhepLaiXe() {
            document.getElementById('lightXemGiayPhepLaiXe').style.display = 'none';
            document.getElementById('fadeXemGiayPhepLaiXe').style.display = 'none';
        }
        function TinhTien() {
            $('#ContentPlaceHolder1_txtTenKhachHang').keyup(function () {
                $('#ContentPlaceHolder1_txtTenKhachHang').val($('#ContentPlaceHolder1_txtTenKhachHang').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

            });


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Main content -->
        <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN HÀNG HÓA</div>
        <div class="title1"><a href="DanhMucLoaiHangHoa.aspx"><i class="fa fa-step-backward"></i>Danh sách hàng hóa</a></div>
        <section class="content">
            <div class="box">
                <div class="box-body">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Mã hàng hóa(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaLoaiHangHoa" runat="server" name="Content.ContentName" type="text" />
                                    </div>
                                </div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Đơn vị tính(*):</b></div>
                                    <div class="txtinput">
                                        <select class="form-control" data-val="true" data-val-required="" id="txtDonViTinh" runat="server" name="Content.ContentName">
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Tên hàng hóa(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaKhachHang" runat="server" name="Content.ContentName" type="text" />
                                    </div>
                                </div>
                                <div class="coninput2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 50%">
                                                <div class="titleinput"><b>Giá gốc(*):</b></div>
                                                <div class="txtinput">
                                                    <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value="0" />
                                                </div>
                                            </td>
                                            <td style="width: 50%;padding-left:15px;">
                                                <div class="titleinput"><b>Giá bán:</b></div>
                                                <div class="txtinput">
                                                    <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtGiaBanWeb" runat="server" name="Content.ContentName" type="text" value="0" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Hình ảnh: </b></div>
                                    <div class="txtinput">
                                        <asp:FileUpload ID="fileUpload" runat="server" />

                                    </div>
                                </div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Loại hàng hóa(*): </b></div>
                                    <div class="txtinput">
                                        <select class="form-control" runat="server" id="txtLoaiHangCapCao">
                                        </select>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" hidden="hidden">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Sản phẩm hót: </b></div>
                                    <div class="txtinput">
                                        <asp:CheckBox ID="ckbHot" runat="server" />
                                        Đây là sản phẩm hot
                                 
                                    </div>
                                </div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Sản phẩm mới: </b></div>
                                    <div class="txtinput">
                                        <asp:CheckBox ID="ckbMoi" runat="server" />
                                        Đây là sản phẩm mới
                                 
                                    </div>
                                </div>

                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Hiển thị: </b></div>
                                    <div class="txtinput">
                                        <asp:CheckBox ID="ckbHienThi" runat="server" />
                                        Được phép hiển thị
                                 
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
<%--                                <div class="dvnull">&nbsp;</div>--%>
                                <div class="coninput1">
                                    <div class="txtinput" id="showHinhRa" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div style="text-align: center; font-weight: bold;">
                            <h3>THÊM CHI TIẾT HÀNG HÓA</h3>
                        </div>
                        <div id="dvXemSanPham" style="padding: 10px; text-align: center">
                            <div class="form-group">
                                <div class="row">
                                    <div class="dvnull">&nbsp;</div>
                                    <div class="coninput1">
                                        <div class="titleinput"><b>Size(*):</b></div>
                                        <div class="txtinput">
                                            <select class="form-control" runat="server" data-val="true" data-val-required="" name="Content.ContentName" id="txtSize"></select>
                                        </div>
                                    </div>
                                    <div class="dvnull"></div>
                                    <div class="coninput1">
                                        <div class="titleinput"><b>Màu(*):</b></div>
                                        <div class="txtinput">
                                            <select class="form-control" runat="server" data-val="true" data-val-required="" name="Content.ContentName" id="txtMau"></select>
                                        </div>
                                    </div>
                                    <div class="dvnull"></div>
                                    <div class="coninput1" style="padding-top:18px;">
                                        <div class="titleinput"><b>Kiểu dáng(*):</b></div>
                                        <div class="txtinput">
                                            <select class="form-control" runat="server" data-val="true" data-val-required="" name="Content.ContentName" id="txtKieuDang"></select>
                                        </div>
                                    </div>
                                    <div class="dvnull">&nbsp;</div>
                                    <div class="coninput1">
                                        <div class="titleinput"><b>Chất liệu(*):</b></div>
                                        <div class="txtinput">
                                            <select class="form-control" runat="server" data-val="true" data-val-required="" name="Content.ContentName" id="txtChatLieu"></select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="dvnull">&nbsp;</div>
                                    <div class="coninput1">
                                        <div class="titleinput"><b>Ghi chú:</b></div>
                                        <div class="txtinput">
                                            <input id="GhiChu" class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="text-align: center">
                                <input type="button" onclick="ThemHangHoa();" value="Thêm" class="btn btn-primary btn-flat" style="width: 80px;" />
                            </div>
                        </div>
                        <%--<div>
                            <input type="button" onclick="MoXemGiayPhepLaiXe()" value="Thêm chi tiết" class="btn btn-primary btn-flat" style="width: 180px;" />
                        </div>--%>
                        <div id="hh">
                        </div>
                        <div class="form-group">
                           <%-- <div style="text-align: center; font-size: 20px; margin-bottom: 10px">Upload hình ảnh sản phẩm...</div>--%>
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1" hidden="hidden">
                                    <div class="titleinput"><b>Chọn hình ảnh(*):</b></div>
                                    <div class="txtinput">
                                        <asp:FileUpload ID="FileUploadHinhAnh" runat="server" />
                                    </div>
                                </div>
                                <div class="coninput1" hidden="hidden">
                                    <div class="titleinput">
                                        <asp:Button ID="btUpLoad" class="btn btn-primary btn-flat" runat="server" Text="UpLoad" OnClick="btUpLoad_Click" />
                                    </div>
                                    <div class="txtinput">
                                    </div>
                                </div>
                            </div>
                            <div class="row" hidden="hidden">
                                <div id="divHinhAnh" runat="server">
                                    Chưa có hình ảnh nào ...
                                </div>
                            </div>
                            <div class="box-footer">
                                <asp:Button ID="btLuu" runat="server" Text="LƯU" value="Lưu" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                                <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                            </div>
                        </div>
                        <hr />
                    </form>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
    <!--Popup xem giấy phép lái xe-->
    
    <div id="fadeXemGiayPhepLaiXe" onclick="DongXemGiayPhepLaiXe()" class="black_overlay"></div>
    <!--End popup--->
</asp:Content>

