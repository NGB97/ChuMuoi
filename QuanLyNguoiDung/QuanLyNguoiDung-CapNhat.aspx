<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="QuanLyNguoiDung-CapNhat.aspx.cs" Inherits="QuanLyNguoiDung_QuanLyNguoiDung_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN NGƯỜI DÙNG</div>
    <div class="title1"><a href="QuanLyNguoiDung.aspx"><i class="fa fa-step-backward"></i> Danh sách người dùng</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Họ tên(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtHoTen" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                         <div class="coninput1">
                        <div class="titleinput"><b>Quyền(*):</b></div>
                          <div class="txtinput">
                              <select class="form-control" id="slQuyen" runat="server" name="Content.ContentName">
                                      <option value="NhanVien">Nhân viên</option>
                                    <option value="Admin">Admin</option>
                                </select>
                          </div>
                              </div>
                      </div>
                </div>
              
                <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                              <div class="titleinput"><b>Tài khoản(*):</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="txtTaiKhoan" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                            <div class="coninput2">
                              <div class="titleinput"><b>Mật khẩu(*):</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="txtMatKhau" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                          </div>
                      </div>
                <%--<div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Địa chỉ:</label>
                    <div class="col-md-10">
                        <input class="form-control" data-val="true" data-val-required="" id="Text1" runat="server" name="Content.ContentName" type="text" value="" />
                    </div>
                </div>--%>
                <div class="box-footer">

                     <a class="btn btn-primary btn-flat" href="../QuanLyNguoiDung/QuanLyNguoiDung.aspx"><i class="glyphicon glyphicon-chevron-left"></i> Quay lại</a>
                    <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                    <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                </div>
            </form>
        </div>
    </div>
    </section>
    <!-- /.content -->
  </div>
</asp:Content>

