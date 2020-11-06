<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DevProfile.aspx.cs" Inherits="GameStay.DevProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/DevProfile_StyleSheet.css?ver=13" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
            <asp:Repeater runat="server" ID="DevInfo">
                <ItemTemplate>
                    <div class="div_profile_top">
                        <div class="div_profile_img">
                            <input type="image" id="Image1" runat="server" class="img_profile" src='<%# Eval("개발사로고") %>'/>
                        </div>
                        <div class="div_profile_detail">
                            <p class="txt_profile_nickname"><%#Eval("개발사이름") %></p>
                            <p class="txt_profile_Link">링크</p>
                        </div>
                        </ItemTemplate>
            </asp:Repeater>
                        <div class="div_profile_edit">
                            <input type="button" runat="server" class="btn_profile_edit" onserverclick="editprofile_click" id="btn_profile_edit" value="프로필 수정"/>
                        </div>
                    </div>
        <asp:Repeater runat="server" ID="DevInfo1">
                <ItemTemplate>
                    <div class="div_explain">
                        <p class="txt_profile_explain"><%#Eval("개발사소개") %></p>

                    </div>
                    </ItemTemplate>
            </asp:Repeater>
                
            <p class="txt_newgame_title ">신규출시</p>
            <div class="profile_newgame">
                <asp:Repeater runat="server" ID="NewGame1">
                    <ItemTemplate>
                        <div class="div_newgames1">
                            <input type="image" id="Img1" runat="server" class="img_newgame" src='<%# Eval("메인이미지") %>' />
                            <div class="div_newgame_intitle">
                                <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                        
                <asp:Repeater runat="server" ID="NewGame2">
                    <ItemTemplate>
                        <div class="div_newgames2">
                            <img id="Img2" class="img_newgame" src='<%# Eval("메인이미지") %>' />
                            <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                        
                        <br />
                <asp:Repeater runat="server" ID="NewGame3">
                    <ItemTemplate>
                        <div class="div_newgames3">
                            <input type="image" id="Img3" runat="server" class="img_newgame" src='<%# Eval("메인이미지") %>' />
                            <div class="div_newgame_intitle">
                                <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                        
                <asp:Repeater runat="server" ID="NewGame4">
                    <ItemTemplate>
                        <div class="div_newgames4">
                            <input type="image" id="Img4" runat="server" class="img_newgame" src='<%# Eval("메인이미지") %>' />
                            <div class="div_newgame_intitle">
                                <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
</asp:Content>
