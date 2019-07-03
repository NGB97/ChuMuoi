<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="BaoTonKho.aspx.cs" Inherits="BaoTonKho_BaoTonKho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">BÁO TỒN KHO</div>
    <div class="box">
        <div class="box-body">
            <%--<div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã sản phẩm:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtHoTen" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Mã vạch:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="Text1" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên sản phẩm:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="Text2" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>--%>
            <div class="row">
                <div class="col-sm-9">
                    <%--<a class="btn btn-primary btn-flat" href="QuanLyThongTinSanPham-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i> Thêm mới</a>--%>
                </div>
                <div class="col-sm-3">
                        <div style="text-align:right;">
                            <asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Tìm kiếm" />
                        </div>
                    </div>
            </div>
            <table class="table table-bordered table-striped">
                <tr>
                    <th class="th">
                        STT
                    </th>
                    <th class="th">
                        Mã sản phẩm
                    </th>
                    <th class="th">
                        Tên sản phẩm
                    </th>
                    <th class="th">
                        Định mức tồn kho
                    </th>
                    <th class="th">
                        Số lượng tồn
                    </th>
                </tr>
                <tr>
                        <td>
                            1
                        </td>
                        <td>
                            SP001
                        </td>
                        <td>
                            Sản phẩm 001
                        </td>
                        <td>
                            2
                        </td>
                        <td>
                            2
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2
                        </td>
                        <td>
                            SP002
                        </td>
                        <td>
                            Sản phẩm 002
                        </td>
                        <td>
                            3
                        </td>
                        <td>
                            1
                        </td>
                    </tr>
            </table>
            <br />
            <div class="pagination-container" style="text-align:center">
                <ul class="pagination">
                    <li class="active"><a>1</a></li>
                    <li class=""><a>2</a></li>
                    <li class=""><a>3</a></li>
                    <li class=""><a>4</a></li>
                    <li class=""><a>5</a></li>
                </ul>
            </div>
        </div>
    </div>
</section>

    <!-- /.content -->
  </div>
        </form>
</asp:Content>

