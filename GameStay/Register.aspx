<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GameStay.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Register_StyleSheet.css?ver5" rel="stylesheet" />
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
             <div class="div_logo" id="div_logo" onclick="onClickLogo()" runat="server">
                 <img class="img_logo" src="Images/Logo_GameStay.png" />
             </div>
             <div class="login_square">
                 <h1 class="txt_login">회원가입</h1>
                 <div class="wrap_idpass">
                     <div class="wrap_input_id">
                        <input type="text" class="input_id" placeholder="아이디"
                            runat="server" id="inputID" autocomplete="off"/>
                        <img class="icon_id" src="Images/Icon/Login/Icon_ID.png" />
                     </div>
                     <br/><br/><br/>

                     <div class="wrap_input_password">
                        <input type="password" class="input_password" placeholder="비밀번호"
                            runat="server" id="inputPassword" autocomplete="off"/>
                        <img class="icon_password" src="Images/Icon/Login/Icon_Password.png" />
                     </div>

                     <div class="wrap_input_password_dupl">
                        <input type="password" class="input_password" placeholder="비밀번호 확인"
                            runat="server" id="inputPasswordDupl" autocomplete="off"/>
                        <img class="icon_password" src="Images/Icon/Login/Icon_Password.png" />
                     </div>

                     <div class="wrap_input_email">
                        <input type="email" class="input_email" placeholder="이메일"
                            runat="server" id="inputEmail" autocomplete="off"/>
                        <img class="icon_email" src="Images/Icon/Login/Icon_Email.png" />
                     </div>
                 </div>

                 <input type="button" runat="server" class="button_register" onserverclick="Register_OnClick" value="가입"/>
             </div>
        </div>
    </form>
</body>
</html>
