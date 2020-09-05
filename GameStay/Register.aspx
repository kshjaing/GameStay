<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GameStay.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Register_StyleSheet.css?ver15" rel="stylesheet" />
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
                 <h1 class="txt_login">회원가입</h1>
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

                     <div class="wrap_input_password_dupl">
                        <input type="password" class="input_password" placeholder="비밀번호 확인"/>
                        <img class="icon_password" src="Images/Icon/Icon_Password.png" />
                     </div>

                     <div class="wrap_input_email">
                        <input type="email" class="input_email" placeholder="이메일"/>
                        <img class="icon_email" src="Images/Icon/Icon_Email.png" />
                     </div>
                 </div>

                 <input type="button" class="button_register" value="가입"/>
             </div>
        </div>
    </form>
</body>
</html>
