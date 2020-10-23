<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DevProfile.aspx.cs" Inherits="GameStay.DevProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/DevProfile_StyleSheet.css?ver=12" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
            <asp:Repeater runat="server" ID="DevInfo">
                <ItemTemplate>
                    <div class="div_profile_img">
                        <input type="image" id="img_profile" runat="server" class="img_profile" src='<%# Eval("개발사로고") %>'/>

                    </div
                    <div class="div_profile_detail">
                        <p class="txt_profile_nickname"><%#Eval("개발사") %></p>
                        <a class="txt_profile_detail">보유한 게임 :</a> <a class="txt_profile_countgame">12</a> <a class="txt_profile_detail">개</a>

                    </div>
                    <div class="div_profile_edit">
                        <input type="button" runat="server" class="btn_profile_edit" onserverclick="editprofile_click" id="btn_profile_edit" value="프로필 수정"/>

                    </div>
                    </div>
                    <div class="profile_square_explain">
                        <p class="txt_profile_explain">개발사 설명</p>
                        <p class="txt_profile_explain-1"><%#Eval("개발사소개") %></p>

                    </div>

                </ItemTemplate>
            </asp:Repeater>
        <br />
        <br />
    </div>
        </div>
</asp:Content>
