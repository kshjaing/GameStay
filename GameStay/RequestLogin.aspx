<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RequestLogin.aspx.cs" Inherits="GameStay.RequestLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/RequestLogin_StyleSheet.css?ver=13" rel="stylesheet" />
    <script>
        function gologinOnClick() {
            __doPostBack('p_goLogin');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="request_square">
            <div class="wrap_p">
                <p class="p_guide" runat="server" id="p_guide">테스트</p>
                <p class="p_gologin" id="p_goLogin" onclick="gologinOnClick()">로그인</p>
            </div>
        </div>
    </div>
</asp:Content>
