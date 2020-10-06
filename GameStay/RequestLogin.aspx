<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RequestLogin.aspx.cs" Inherits="GameStay.RequestLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/RequestLogin_StyleSheet.css?ver=17" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="request_square" >
            <br />
            <div ><br />
                <br />
            <a class="txt_request">원활한 서비스를 이용하기 위하여 로그인 또는 회원가입 후 이용하여 주시기 바랍니다.</a><br /><br />
            <button runat="server" class="btn_gologin" onserverclick="gologin_click">로그인 및 회원가입하기</button>
            </div>
            
            </div>
        </div>
</asp:Content>
