<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_ProductDetail.aspx.cs" Inherits="GameStay.Store_ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Store_ProductDetail_StyleSheet.css?ver=1" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="wrap_total_images">
            <asp:Repeater runat="server" ID="detailTitleRepeater">
                <ItemTemplate>
                    <p class="p_title"><%# Eval("게임명") %></p>
                </ItemTemplate>
            </asp:Repeater>
            <div class="div_main_image">

            </div>
            <div class="div_wrap_small_images" id="div_wrap_small_images" runat="server">
                <asp:Repeater runat="server" ID="detailVideoRepeater" OnDataBinding="divSmallImages_Resize">
                   <ItemTemplate>
                       <div class="div_wrap_placeholder">
                           <img src='<%# Eval("미리보기이미지") %>' class="img_placeholder"/>
                       </div>
                   </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="detailImageRepeater">
                   <ItemTemplate>
                       <div class="div_wrap_screenshot">
                           <img src='<%# Eval("스크린샷") %>' class="img_screenshot" />
                       </div>
                   </ItemTemplate>
                </asp:Repeater>
            </div>
            
            
            
        </div>
        <div class="wrap_total_infobox"></div>
    </div>
</asp:Content>
