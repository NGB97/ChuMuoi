<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DieuXe-CapNhat.aspx.cs" Inherits="DieuXe_DieuXe_CapNhat" %>

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
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN ĐIỀU XE</div>
    <div class="title1"><a href="DanhMucDieuXe.aspx"><i class="fa fa-step-backward"></i> Danh sách điều xe</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã điều xe(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtHoTen" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Tên hàng(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtDienThoai" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Nơi nhận:</b></div>
                          <div class="txtinput">
                             <select class="form-control">
                                 <option>-- Chọn --</option>
                             </select>
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Nơi giao:</b></div>
                          <div class="txtinput">
                              <select class="form-control">
                                 <option>-- Chọn --</option>
                             </select>
                          </div>
                        </div>
                      </div>
                </div>
                <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                              <div class="titleinput"><b>Chủ hàng:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="Text17" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                            <div class="coninput2">
                              <div class="titleinput"><b>Số lượng:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="Text5" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                          </div>
                      </div>
                <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                              <div class="titleinput"><b>Xe:</b></div>
                              <div class="txtinput">
                                  <select class="form-control">
                                 <option>-- Chọn --</option>
                             </select>
                              </div>
                            </div>
                            <div class="coninput2">
                              <div class="titleinput"><b>Kéo mooc:</b></div>
                              <div class="txtinput" style="padding-top:6px; text-align:left">
                                  <input type="checkbox" />
                              </div>
                            </div>
                          </div>
                      </div>
                <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                              <div class="titleinput"><b>Chứng từ 1:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="Text1" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                            <div class="coninput2">
                              <div class="titleinput"><b>Chứng từ 2:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="Text2" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                          </div>
                      </div>
                <%--<div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                    <div class="col-md-10">
                        <input class="form-control" data-val="true" data-val-required="" id="Text13" runat="server" name="Content.ContentName" type="text" value="" />
                    </div>
                </div>--%>
                <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                              <div class="titleinput"><b>Ghi chú:</b></div>
                              <div class="txtinput">
                                  <textarea class="form-control"></textarea>
                              </div>
                            </div>
                            <div class="coninput2">
                              <div class="titleinput"><b>Người phụ trách:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="Text4" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                          </div>
                      </div>
                <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                              <div class="titleinput"><b>Tài xế:</b></div>
                              <div class="txtinput">
                                  <select class="form-control">
                                     <option>-- Chọn --</option>
                                 </select>
                              </div>
                            </div>
                            <div class="coninput2">
                              <div class="titleinput"><b>Lơ xe:</b></div>
                              <div class="txtinput" style="padding-top:6px; text-align:left">
                                  <select class="form-control">
                                     <option>-- Chọn --</option>
                                 </select>
                              </div>
                            </div>
                          </div>
                      </div>
                <div class="form-group">
                        <div class="row">
                            <div class="dvnull">&nbsp;</div>
                            <div class="coninput1">
                              <div class="titleinput"><b>Ngày đi:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" data-val="true" data-val-required="" id="Text3" runat="server" name="Content.ContentName" type="text" value="" />
                              </div>
                            </div>
                            <div class="coninput2">
                              <div class="titleinput"><b>Giờ đi:</b></div>
                              <div class="txtinput" style="padding-top:6px; text-align:left">
                                  <table>
                                      <tr>
                                          <td>
                                              <input class="form-control" data-val="true" data-val-required="" id="Text6" runat="server" name="Content.ContentName" type="text" value="" />
                                          </td>
                                          <td>:</td>
                                          <td>
                                              <input class="form-control" data-val="true" data-val-required="" id="Text7" runat="server" name="Content.ContentName" type="text" value="" />
                                          </td>
                                      </tr>
                                  </table>
                              </div>
                            </div>
                          </div>
                      </div>
                <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName" >Dụng cụ:</label>
                    <div class="col-md-10">
                        <div>
                            <input type="button" onclick="MoXemDungCu()" value="Thêm dụng cụ" class="btn btn-primary btn-flat" style="width: 130px;" />
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
                                    <th class="th" style="width:110px;">
                                    </th>
                                </tr>
                                <tr style="background-color: #b0daff;">
                                    <td rowspan="2" style="vertical-align: inherit;">1</td>
                                    <td rowspan="2" style="vertical-align: inherit;">Dụng cụ 1</td>
                                    <td>Quy cách 11</td>
                                    <td rowspan="2" style="vertical-align: inherit;">
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                                        </td>
                                  </tr>
                                  <tr style="background-color: #b0daff;">
                                    <td>Quy cách 12</td>
                                  </tr>
                            <tr style="background-color: #b0daff;">
                                    <td rowspan="3" style="vertical-align: inherit;">2</td>
                                    <td rowspan="3" style="vertical-align: inherit;">Dụng cụ 2</td>
                                    <td>Quy cách 21</td>
                                    <td rowspan="3" style="vertical-align: inherit;">
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                                        </td>
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
    <!--Popup xem dụng cụ-->
    <div id="lightXemDungCu" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvDungCu" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">CẬP NHẬT DỤNG CỤ</div>
                <div id="dvXemDungCu" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Dụng cụ:</b></div>
                                            <div class="txtinput">
                                                <select class="form-control">
                                                    <option>Dụng cụ 1</option>
                                                    <option>Dụng cụ 2</option>
                                                </select>
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
                                            <div class="titleinput"><b>Quy cách 11</b></div>
                                            <div class="txtinput" style="padding-top:5px; text-align:left">
                                                <input type="checkbox" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Quy cách 12</b></div>
                                            <div class="txtinput" style="padding-top:5px; text-align:left">
                                                <input type="checkbox" />
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Quy cách 13</b></div>
                                            <div class="txtinput" style="padding-top:5px; text-align:left">
                                                <input type="checkbox" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Quy cách 14</b></div>
                                            <div class="txtinput" style="padding-top:5px; text-align:left">
                                                <input type="checkbox" />
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Quy cách 15</b></div>
                                            <div class="txtinput" style="padding-top:5px; text-align:left">
                                                <input type="checkbox" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Quy cách 16</b></div>
                                            <div class="txtinput" style="padding-top:5px; text-align:left">
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
    <div id="fadeXemDungCu" onclick="DongXemDungCu()" class="black_overlay"></div>
    <!--End popup--->
</asp:Content>

