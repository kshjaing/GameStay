<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="GameStay.Library" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Library_StyleSheet.css?ver=12" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="div_library_total">
            <asp:Repeater runat="server" ID="library_list">
                <ItemTemplate>
                    <div class="div_lib_game" onmouseover="onMouseDivFeature()">
                        <div class="squar_lib_game">
                            <img class="img_lib_game" src="<%# Eval("라이브러리이미지") %>"/>
                            <a class="txt_lib_game"><%# Eval("영어게임명") %></a>
                        </div>
                        <div>
                            <input type="button" class="btn_lib" value="상점페이지"/><br /><br />
                            <input type="button" class="btn_lib" value="커뮤니티"/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
