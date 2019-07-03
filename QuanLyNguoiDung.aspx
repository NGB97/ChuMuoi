<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="QuanLyNguoiDung.aspx.cs" Inherits="QuanLyNguoiDung_QuanLyNguoiDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
     <script>
        

         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">QUẢN LÝ NGƯỜI DÙNG</div>
    <div class="box">
        <div class="box-body">
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên người dùng:</b></div>
                          <div class="txtinput">
                                <input class="form-control"  data-val="true" data-val-required="" id="txtTenNguoiDung" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput" ><b>Quyền:</b></div>
                          <div class="txtinput" >
                                <select class="form-control" id="txtQuyen" runat="server" name="Content.ContentName">
                                   <option value="">&nbsp;</option>
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
                          <div class="titleinput"><b>Tài khoản:</b></div>
                          <div class="txtinput">


                                <asp:FileUpload ID="FileUpload1" runat="server" />

                              <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

                                <input class="form-control"  data-val="true" data-val-required="" id="txtTaiKhoan" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        
                      </div>
                </div>
        
              
            <div class="row">
                <div class="col-sm-9">
                    <a class="btn btn-primary btn-flat" href="QuanLyNguoiDung-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
                </div>
                <div class="col-sm-3">
                        <div style="text-align:right;">
                          
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
                          Họ tên
                        </th>
                        <th class='th'>
                          Số điện thoại
                        </th>
                        <th class='th'>
                          Email
                        </th>
                        <th class='th'>
                          Địa chỉ
                        </th>
                        <th class='th'>
                          Quyền
                        </th>
                        <th class='th'>
                          Tên đăng nhập
                        </th>
                        <th class='th'>
                          Mật khẩu
                        </th>
                        <th class='th'>
                        </th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Nguyễn Phong</td>
                        <td>0989999999</td>
                        <td>nguyenphong@gmail.com</td>
                        <td>24 Nguyễn Thị Minh Khai, Bình Thạnh, TP HCM</td>
                        <td>Admin</td>
                        <td>admin</td>
                        <td>123</td>
                        <td>
                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                        </td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Trần Thế Anh</td>
                        <td>0989999998</td>
                        <td>theanh@gmail.com</td>
                        <td>25 Nguyễn Thị Minh Khai, Bình Thạnh, TP HCM</td>
                        <td>Nhân viên</td>
                        <td>theanh</td>
                        <td>123</td>
                        <td>
                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</section>


    <!-- /.content -->
  </div>
        
        </form>
</asp:Content>

