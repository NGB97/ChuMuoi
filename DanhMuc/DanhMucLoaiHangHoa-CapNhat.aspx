<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucLoaiHangHoa-CapNhat.aspx.cs" Inherits="DanhMuc_DanhMucKhachHang_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
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
                                    <div class="titleinput"><b>Loại hàng hóa(*): </b></div>
                                    <div class="txtinput">
                                        <select class="form-control" runat="server" id="txtLoaiHangCapCao">
                                        </select>
                                    </div>
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
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 50%">
                                                <div class="titleinput"><b>Giá gốc(*):</b></div>
                                                <div class="txtinput">
                                                    <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value="0" />
                                                </div>
                                            </td>

                                            <td style="width: 50%">
                                                <div class="titleinput" style="padding-left: 10px;"><b>Giá bán(*):</b></div>
                                                <div class="txtinput">
                                                    <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtGiaBanWeb" runat="server" name="Content.ContentName" type="text" value="0" />
                                                </div>
                                            </td>

                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="form-group" hidden="hidden">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Sản phẩm hot: </b></div>
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
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="txtinput" id="showHinhRa" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" style="display: none;">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Địa chỉ:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtDiaChi" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                                <div class="coninput2">
                                    <div class="titleinput"><b>Số điện thoại:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtSoDienThoai" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" style="display: none;">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Mã Số Thuế:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaSoThue" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="form-group" style="display: none;">
                            <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                            <div class="col-md-10">
                                <textarea class="form-control" id="txtGhiChu" runat="server" name="Content.ContentName"></textarea>
                            </div>
                        </div>

                        <div class="box-footer">
                            <asp:Button ID="btLuu" runat="server" Text="Tiếp tục" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                            <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                        </div>
                    </form>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
    <!--Popup xem giấy phép lái xe-->
    <div id="lightXemGiayPhepLaiXe" class="white_content" style="top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvGiayPhepLaiXe" class="box-body">
                <div style="text-align: center; font-weight: bold; padding: 10px">CẬP NHẬT GIẤY PHÉP LÁI XE</div>
                <div id="dvXemSanPham" style="padding: 10px; text-align: center">
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Số giấy phép lái xe:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Hạng xe:</b></div>
                                <div class="txtinput">
                                    <select class="form-control">
                                        <option>-- Chọn --</option>
                                        <option>A1</option>
                                        <option>A2</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                                <div class="titleinput"><b>Ngày hết hạn:</b></div>
                                <div class="txtinput">
                                    <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                </div>
                            </div>
                            <%--<div class="coninput1">
                                            <div class="titleinput"><b>Hạng xe:</b></div>
                                            <div class="txtinput">
                                                <select class="form-control">
                                                    <option>-- Chọn --</option>
                                                    <option>A1</option>
                                                    <option>A2</option>
                                                </select>
                                            </div>
                                        </div>--%>
                        </div>
                    </div>
                    <div style="text-align: center">
                        <input type="button" value="Thêm" class="btn btn-primary btn-flat" style="width: 80px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="fadeXemGiayPhepLaiXe" onclick="DongXemGiayPhepLaiXe()" class="black_overlay"></div>
    <!--End popup--->
</asp:Content>

