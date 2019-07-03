<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucKhachHang-CapNhat.aspx.cs" Inherits="DanhMuc_DanhMucKhachHang_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        function MoXemGiayPhepLaiXe() {
            document.getElementById('lightXemGiayPhepLaiXe').style.display = 'block';
            document.getElementById('fadeXemGiayPhepLaiXe').style.display = 'block';
        }
        function DongXemGiayPhepLaiXe() {
            document.getElementById('lightXemGiayPhepLaiXe').style.display = 'none';
            document.getElementById('fadeXemGiayPhepLaiXe').style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN KHÁCH HÀNG</div>
    <div class="title1"><a href="DanhMucKhachHang.aspx"><i class="fa fa-step-backward"></i> Danh sách khách hàng</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã khách hàng(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaKhachHang" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Tên khách hàng(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>
                <div class="form-group">
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
                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                            <div class="titleinput"><b>Mã Số Thuế:</b></div>
                            <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="txtMaSoThue" runat="server" name="Content.ContentName" type="text" value="" />
                            </div>
                        </div>
                        <div class="coninput2">
                              <div class="titleinput"><b>Số tài khoản:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="txtSoTaiKhoan" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                        </div>
                    </div>
                     
                </div>
                 <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                              <div class="titleinput"><b>Loại khách hàng:</b></div>
                              <div class="txtinput">
                                  <select class="form-control" data-val="true" style="font-weight:bold" data-val-required="" id="txtLoaiKhachHang" runat="server" name="Content.ContentName" type="text" value="">
                                      <option value="Khách lẻ" style="font-weight:bold"></option>
                                      <option value ="Khách sỉ"  style="font-weight:bold"></option>
                                    </select>
                              </div>
                         </div>
                        <div class="coninput2">
                              <div class="titleinput"><b>Email:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="txtEmail" runat="server" name="Content.ContentName" type="email" value="" />
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
                     <a class="btn btn-primary btn-flat" href="../DanhMuc/DanhMucKhachHang.aspx"><i class="glyphicon glyphicon-chevron-left"></i> Quay lại</a>
                    <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                    <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                </div>
            </form>
        </div>
    </div>
    </section>
    <!-- /.content -->
  </div>
    <!--Popup xem giấy phép lái xe-->
    <%--<div id="lightXemGiayPhepLaiXe" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvGiayPhepLaiXe" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">CẬP NHẬT GIẤY PHÉP LÁI XE</div>
                <div id="dvXemSanPham" style="padding:10px; text-align:center">
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
                                    </div>
                        </div>
                        <div style="text-align:center">
                            <input type="button" value="Thêm" class="btn btn-primary btn-flat" style="width: 80px;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemGiayPhepLaiXe" onclick="DongXemGiayPhepLaiXe()" class="black_overlay"></div>--%>
    <!--End popup--->
</asp:Content>

