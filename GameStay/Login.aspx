﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameStay.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Login_StyleSheet.css?ver=13" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function onClickLogo() {
            __doPostBack('div_logo');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
           <div class="div_wrap_logo">
               <div class="div_logo" id="div_logo" onclick="onClickLogo()" runat="server">
                 <img class="img_logo" src="Images/Logo_GameStay.png" />
               </div>
           </div>
           <div class="login_square">
               <p class="txt_login">로그인</p>
                     <div class="div_wrap_id">
                        <input type="text" class="input_id" placeholder="아이디"
                               runat="server" id="inputID" autocomplete="off"/>
                        <img class="icon_id" src="Images/Icon/Login/Icon_ID.png" />
                     </div>
                     <div class="div_wrap_password">
                        <input type="password" class="input_password" placeholder="비밀번호"
                               runat="server" id="inputPassword" autocomplete="off"/>
                        <img class="icon_password" src="Images/Icon/Login/Icon_Password.png" />
                     </div>
                     <div class="div_wrap_loginbutton">
                        <button class="button_login" runat="server" onserverclick="btnLogin_OnClick">
                         <img class="img_login" src="Images/Icon/Login/Icon_Login_NotHover.png" 
                              onmouseover="this.src='Images/Icon/Login/Icon_Login_Hover.png'"
                              onmouseout="this.src='Images/Icon/Login/Icon_Login_NotHover.png'"/>
                        </button>
                    </div>
                    <div class="div_wrap_warn">
                        <a runat="server" id="txtLoginCheck" class="a_login_check" draggable="false">
                            가입하지 않은 아이디이거나,<br /> 잘못된 비밀번호입니다.
                        </a>
                    </div>
                     <div class="div_wrap_register">
                       <a class="a_register">회원이 아니신가요?</a>
                       <a class="a_register_link" href="Register.aspx">회원가입</a>
                    </div>
                    <div class="div_wrap_devLogin">
                       <a class="a_devLogin">개발자이신가요?</a>
                       <a class="a_devLogin_link" href="DevLogin.aspx">개발자 로그인</a>
                    </div>
           </div>
        </div>
    </form>
</body>
</html>

