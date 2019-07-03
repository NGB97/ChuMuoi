<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DieuXe.aspx.cs" Inherits="DieuXe_DieuXe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        function MoXemDungCu() {
            document.getElementById('lightXemDungCu').style.display = 'block';
            document.getElementById('fadeXemDungCu').style.display = 'block';
        }
        function DongXemDungCu() {
            document.getElementById('lightXemDungCu').style.display = 'none';
            document.getElementById('fadeXemDungCu').style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">ĐIỀU XE</div>
    <div class="box">
        <div class="box-body">
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã điều xe:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="txtTenNguoiDung" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Số xe:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="Text1" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div>
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Từ ngày:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="Text2" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Đến ngày:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="Text3" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div>
            <div class="row">
                <div class="col-sm-9">
                    <a class="btn btn-primary btn-flat" href="DieuXe-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
                </div>
                <div class="col-sm-3">
                        <div style="text-align:right;">
                            <asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Tìm kiếm" />
                            <asp:Button ID="btTatCa" class="btn btn-primary btn-flat" runat="server" Text="Tất cả" />
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
                          Mã điều xe
                        </th>
                        <th class='th'>
                          Ngày
                        </th>
                        <th class='th'>
                          Tên hàng
                        </th>
                        <th class='th'>
                          Nơi nhận
                        </th>
                        <th class='th'>
                          Nơi giao
                        </th>
                        <th class='th'>
                          Chủ hàng
                        </th>
                        <th class='th'>
                          Số lượng
                        </th>
                        <th class='th'>
                          Số xe
                        </th>
                        <th class='th'>
                          Kéo mooc
                        </th>
                        <th class='th'>
                          Chứng từ 1
                        </th>
                        <th class='th'>
                          Chứng từ 2
                        </th>
                        <th class='th'>
                          Ghi chú
                        </th>
                        <th class='th'>
                          Người phụ trách
                        </th>
                        <th class='th'>
                          Tài xế
                        </th>
                        <th class='th'>
                          Lơ xe
                        </th>
                        <th class='th'>
                          Thời điểm đi
                        </th>
                        <th class='th'>
                          Dụng cụ
                        </th>
                        <th class='th' style="width:110px"></th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>DX0001</td>
                        <td>15/08/2017</td>
                        <td>Rau quả</td>
                        <td>15 Ung Văn Khiêm, TP HCM</td>
                        <td>15 XVNT, TP HCM</td>
                        <td>Nguyễn Văn A</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>15/05/2017 10:30</td>
                        <td><a style="cursor:pointer" onclick="MoXemDungCu();">Xem dụng cụ</a></td>
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
        <!--Popup xem dụng cụ-->
    <div id="lightXemDungCu" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvDungCu" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">XEM DỤNG CỤ</div>
                <div id="dvXemDungCu" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Mã điều xe:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="DX0012" disabled />
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
                                        Tên dụng cụ
                                    </th>
                                    <th class="th">
                                        Quy cách
                                    </th>
                                </tr>
                                <tr style="background-color: #b0daff;">
                                    <td rowspan="2" style="vertical-align: inherit;">1</td>
                                    <td rowspan="2" style="vertical-align: inherit;">Dụng cụ 1</td>
                                    <td>Quy cách 11</td>
                                  </tr>
                                  <tr style="background-color: #b0daff;">
                                    <td>Quy cách 12</td>
                                  </tr>
                            <tr style="background-color: #b0daff;">
                                    <td rowspan="3" style="vertical-align: inherit;">2</td>
                                    <td rowspan="3" style="vertical-align: inherit;">Dụng cụ 2</td>
                                    <td>Quy cách 21</td>
                                  </tr>
                                  <tr style="background-color: #b0daff;">
                                    <td>Quy cách 22</td>
                                  </tr>
                            <tr style="background-color: #b0daff;">
                                    <td>Quy cách 23</td>
                                  </tr>
                            </table>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemDungCu" onclick="DongXemDungCu()" class="black_overlay"></div>
    <!--End popup--->
        </form>
</asp:Content>

