<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageGame.aspx.cs" Inherits="GameStay.RegistGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/ManageGame_StyleSheet.css?ver=11" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
            <div class="div_profile_detail">
            <asp:Repeater runat="server" ID="Devname">
                    <ItemTemplate>
                    <p class="txt_profile_nickname"><%#Eval("개발사") %></p>
                </ItemTemplate>
            </asp:Repeater>
                        <a class="txt_manage_info" runat="server" id="txt_manageinfo"></a>
                <asp:Repeater runat="server" ID="DevInfo">
                    <ItemTemplate>
                    <a class="txt_manage_info">월 수익 : </a><a class="txt_manage_info"><%#Eval("매출액") %></a><a class="txt_manage_info">원</a><br />
                    <a class="txt_manage_info">총 수익 : </a><a class="txt_manage_info"><%#Eval("매출액") %></a><a class="txt_manage_info">원</a>
                </ItemTemplate>
            </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
