<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_ProductDetail.aspx.cs" Inherits="GameStay.Store_ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Store_ProductDetail_StyleSheet.css?ver=1" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="wrap_total_images">
            <div class="div_main_image">

            </div>
            <div class="div_wrap_small_images">
                
            </div>
            <asp:Repeater runat="server" ID="detailTitleRepeater">
                <ItemTemplate>
                    <p class="p_title"><%# Eval("게임명") %></p>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater runat="server" ID="detailImageRepeater">
                <ItemTemplate>
                     <img src='<%# Eval("스크린샷") %>' class="img" />
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater runat="server" ID="detailVideoRepeater">
                <ItemTemplate>
                    <iframe width="800" height="460" src='<%# Eval("영상링크") %>'
                        frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" 
                        allowfullscreen></iframe>
                </ItemTemplate>
            </asp:Repeater>
                
        </div>
        <div class="wrap_total_infobox"></div>
    </div>
</asp:Content>
