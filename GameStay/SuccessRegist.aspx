<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SuccessRegist.aspx.cs" Inherits="GameStay.SuccessRegist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/RequestLogin_StyleSheet.css?ver=17" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="request_square" >
            <br />
            <div ><br />
                <br />
            <a class="txt_request">회원가입을 진심으로 축하합니다! 로그인 후 이용하여 주시기 바랍니다.</a><br /><br />
            <button runat="server" class="btn_gologin" onserverclick="gologin_click">로그인하기</button>
            </div>
            
            </div>
        </div>
</asp:Content>
