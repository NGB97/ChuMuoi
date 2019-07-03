﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucNhaCungCap-CapNhat.aspx.cs" Inherits="DanhMuc_DanhMucNhaCungCap_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN NHÀ CUNG CẤP</div>
    <div class="title1"><a href="DanhMucNhaCungCap.aspx"><i class="fa fa-step-backward"></i> Danh sách nhà cung cấp</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã nhà cung cấp(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaNhaCungCap" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Tên nhà cung cấp (*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtTenNhaCungCap" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>


                 <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Số điện thoại:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtSoDienThoai" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Địa chỉ:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtDiaChi" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>

                <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                    <div class="col-md-10">
                        <textarea class="form-control" id="txtGhiChu" name="Content.ContentName" runat="server"></textarea>
                    </div>
                </div>
                <div class="box-footer">
                     <a class="btn btn-primary btn-flat" href="../DanhMuc/DanhMucNhaCungCap.aspx"><i class="glyphicon glyphicon-chevron-left"></i> Quay lại</a>
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

