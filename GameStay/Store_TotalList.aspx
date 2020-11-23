<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_TotalList.aspx.cs" Inherits="GameStay.Store_TotalList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Store_TotalList_StyleSheet.css?ver=11" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <p class="p_totalgame">게임 탐색</p>
        <div class="div_wrap_search">
            <div class="div_wrap_image_search">
                <img class="img_search" src="Images/Icon/Icon_Search.png" />
            </div>
            <input type="text" class="input_search" />
        </div>
        <asp:Repeater runat="server" ID="titleRepeater">
            <ItemTemplate>
                <div class="div_wrap_contentbox" id="div_wrap_contentbox">
                     <div class="div_wrap_image">
                         <img src='<%# Eval("와이드이미지") %>' class="image"/>
                     </div>
                     <div class="div_wrap_p_title">
                         <p class="p_title"><%# Eval("게임명") %></p>
                     </div>
                     <div class="div_wrap_p_price">
                         <p class="p_price">&#8361;<%# Eval("할인가격", "{0:0,00}") %>원</p>
                     </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
