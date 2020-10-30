<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GameStay.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Profile_StyleSheet.css?ver=12" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
            <asp:Repeater runat="server" ID="UserInfo">
                <ItemTemplate>
                  <div class="div_profile_img">
                     <img class="img_profile" src='<%# Eval("프로필사진") %>'/>
                  </div>
                  <div class="div_profile_detail">
                      <p class="txt_profile_nickname"><%#Eval("닉네임") %></p>
                      <a class="txt_profile_detail">레벨 : </a> <a class="txt_profile_level" ><%#Eval("레벨") %></a> <br />
                      </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater runat="server" ID="HasGameCountRepeater">
                <ItemTemplate>
                      <a class="txt_profile_detail">보유한 게임 :</a> <a class="txt_profile_countgame"><%# Eval("소유한 게임 수") %></a> <a class="txt_profile_detail">개</a>
                  </div>
                </ItemTemplate>
            </asp:Repeater>
                      
                
            <div class="div_profile_edit">
                <input type="button" runat="server" class="btn_profile_edit" onserverclick="editprofile_click" id="btn_profile_edit" value="프로필 수정"/>
            </div>
        </div>

    <div class="profile_square_game">
        <p class="txt_profile_game">최근에 구매한 게임</p>

        <div class="div_profile_game-1">
            
        <div class="div_profile_game" >
           <asp:Repeater runat="server" ID="RecentGame1">
                <ItemTemplate>
                    <img src='<%#Eval("메인이미지") %>' class="img_profile_game"/>
                       <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                       <p class="txt_profile_game_date"><%#Eval("거래일", "{0:yyyy년MM월dd일}") %></p>
                </ItemTemplate>
           </asp:Repeater>
        </div>
        <div class="div_profile_game">
            <asp:Repeater runat="server" ID="RecentGame2">
                    <ItemTemplate>
                        <img src='<%#Eval("메인이미지") %>' class="img_profile_game"/>
                        <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                        <p class="txt_profile_game_date"><%#Eval("거래일", "{0:yyyy년MM월dd일}") %></p>
                    </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="div_profile_game">
            <asp:Repeater runat="server" ID="RecentGame3">
                    <ItemTemplate>
                        <img src='<%#Eval("메인이미지") %>' class="img_profile_game"/>
                        <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                        <p class="txt_profile_game_date"><%#Eval("거래일", "{0:yyyy년MM월dd일}") %></p>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        </div>
    </div>

        <div class="profile_square_screenshot">
            <p class="txt_profile_screenshot">스크린샷</p>
            <div class="div_profile_scs_main">
                <input type="image" src="Images/GameTitleImages/TitleImage_TheElderScrolls5Skyrim.JPG" class="img_profile_scs_main" />
            </div>
            <div class="div_profile_scs_sub">
                <input type="image" src="Images/GameTitleImages/TitleImage_Firewatch.PNG" class="img_profile_scs_sub"/><br />
                <input type="image" src="Images/GameTitleImages/TitleImage_Cyberpunk2077.JPG" class="img_profile_scs_sub"/>
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
