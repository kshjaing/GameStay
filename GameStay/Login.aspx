<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameStay.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Login_StyleSheet.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
             <div class="div_logo">
                 <img class="img_logo" src="Images/Logo_GameStay.png" />
             </div>
             <div class="login_square">
                 <h1 class="txt_login">로그인</h1>
                 <div class="wrap_idpass">
                     <div class="wrap_input_id">
                        <input type="text" class="input_id" placeholder="아이디"/>
                        <img class="icon_id" src="Images/Icon/Icon_ID.png" />
                     </div>
                     <br/><br/><br/>

                     <div class="wrap_input_password">
                        <input type="password" class="input_password" placeholder="비밀번호"/>
                        <img class="icon_password" src="Images/Icon/Icon_Password.png" />
                     </div> 
                     <br /><br />

                     <div class="wrap_login">
                         <input type="checkbox" class="check_autologin" />
                         <a class="a_autologin" onclick="">자동 로그인</a>
                         <div class="div_icon_login">
                             <img class="imgbutton_login" src="Images/Icon/Icon_Login_NotHover.png"
                                 onmouseover="this.src='Images/Icon/Icon_Login_Hover.png'"
                                 onmouseout="this.src='Images/Icon/Icon_Login_NotHover.png'"/>
                         </div>
                     </div>
                     <br /><br /><br /><br /><br /><br /><br /><br />

                     <a class="a_register" href="Register.aspx">회원이 아니신가요?</a>
                     <br /><br />
                 </div>
             </div>
        </div>
    </form>
</body>
</html>
