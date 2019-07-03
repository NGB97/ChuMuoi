<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucXe-CapNhat.aspx.cs" Inherits="QuanLyXe_DanhMucXe_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
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
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN XE</div>
    <div class="title1"><a href="DanhMucXe.aspx"><i class="fa fa-step-backward"></i> Danh sách xe</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên xe(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtHoTen" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Loại xe(*):</b></div>
                          <div class="txtinput">
                              <select class="form-control">
                                    <option>-- Chọn --</option>
                                    <option>Xe phi</option>
                                    <option>Xe bồn</option>
                                </select>
                          </div>
                        </div>
                      </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Số mooc:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="Text1" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <%--<div class="coninput2">
                          <div class="titleinput"><b>Loại xe(*):</b></div>
                          <div class="txtinput">
                              <select class="form-control">
                                    <option>-- Chọn --</option>
                                    <option>Xe phi</option>
                                    <option>Xe bồn</option>
                                </select>
                          </div>
                        </div>--%>
                      </div>
                </div>
                <%--<div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Nơi ở:</label>
                    <div class="col-md-10">
                        <input class="form-control" data-val="true" data-val-required="" id="Text13" runat="server" name="Content.ContentName" type="text" value="" />
                    </div>
                </div>--%>
                <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName" >Bảo dưỡng:</label>
                    <div class="col-md-10">
                        <div>
                            <input type="button" onclick="MoXemBaoDuong()" value="Thêm bảo dưỡng" class="btn btn-primary btn-flat" style="width: 140px;" />
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
                                    <th class="th">
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
                                    <td>
                                        <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                        <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
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
                                            26/05/2017
                                        </td>
                                        <td>
                                            25/05/2018
                                        </td>
                                        <td>
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName" >Chứng từ kiểm định:</label>
                    <div class="col-md-10">
                        <div>
                            <input type="button" onclick="MoXemChungTuKiemDinh()" value="Thêm chứng từ kiểm định" class="btn btn-primary btn-flat" style="width: 200px;" />
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
                                    <th class="th">
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
                                        <td>
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
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
                                        <td>
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName" >Chứng từ nhận PCCC:</label>
                    <div class="col-md-10">
                        <div>
                            <input type="button" onclick="MoXemChungNhanPCCC()" value="Thêm chứng nhận PCCC" class="btn btn-primary btn-flat" style="width: 180px;" />
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
                                    <th class="th">
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
                                        <td>
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
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
                                        <td>
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" />
                    <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" />
                </div>
            </form>
        </div>
    </div>
    </section>
    <!-- /.content -->
  </div>
    <!--Popup cập nhật bảo dưỡng-->
    <div id="lightXemBaoDuong" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvBaoDuong" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">CẬP NHẬT BẢO DƯỠNG</div>
                <div id="dvXemBaoDuong" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số phiếu bảo dường:</b></div>
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
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Ngày bảo dưỡng:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Ngày bảo dưỡng tiếp theo:</b></div>
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
    <div id="fadeXemBaoDuong" onclick="DongXemBaoDuong()" class="black_overlay"></div>
    <!--End popup--->
    <!--Popup cập nhật chứng từ kiểm định-->
    <div id="lightXemChungTuKiemDinh" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvChungTuKiemDinh" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">CẬP NHẬT CHỨNG TỪ KIỂM ĐỊNH</div>
                <div id="dvXemChungTuKiemDinh" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số phiếu kiểm định:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Ngày đăng ký:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Ngày hết hiệu lực:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Camera hành trình:</b></div>
                                            <div class="txtinput" style="text-align: left; padding-top:6px">
                                                <input type="checkbox" />
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
    <div id="fadeXemChungTuKiemDinh" onclick="DongXemChungTuKiemDinh()" class="black_overlay"></div>
    <!--End popup--->
    <!--Popup cập nhật chứng nhận PCCC-->
    <div id="lightXemChungNhanPCCC" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvChungNhanPCCC" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">CẬP NHẬT CHỨNG NHẬN PCCC</div>
                <div id="dvXemChungNhanPCCC" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số chứng nhận:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <%--<div class="coninput1">
                                            <div class="titleinput"><b>Ngày đăng ký:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>--%>
                                    </div>
                        </div>
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Ngày đăng ký:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Camera hết hạn:</b></div>
                                            <div class="txtinput" style="text-align: left; padding-top:6px">
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
    <div id="fadeXemChungNhanPCCC" onclick="DongXemChungNhanPCCC()" class="black_overlay"></div>
    <!--End popup--->
</asp:Content>

