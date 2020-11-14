<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="GameStay.Library" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Library_StyleSheet.css?ver=13" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="div_library_total">
            <asp:Repeater runat="server" ID="library_list">
                <ItemTemplate>
                    <div class="div_lib_game">
                        <div class="squar_lib_game">
                            <img class="img_lib_game" src="<%# Eval("라이브러리이미지") %>"/>
                            <div class="div_wrap_buttons">
                                <asp:HyperLink NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'
                                 runat="server" CssClass="link">
                                    <div class="div_btn_lib">
                                        <p class="p_lib">상점페이지</p>
                                    </div>
                                </asp:HyperLink>
                                <asp:HyperLink NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'
                                 runat="server" CssClass="link">
                                     <div class="div_btn_lib">
                                        <p class="p_lib">커뮤니티</p>
                                     </div>
                               </asp:HyperLink>
                            </div>
                            <div class="div_title">
                                <p class="p_title"><%# Eval("게임명") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
