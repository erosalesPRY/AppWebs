﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIMANET_W22R.Login" %>

<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>


      <!--estilos base-->
    <link href="Recursos/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Recursos/css/font-awesome.min.css" rel="stylesheet"/>
    <!--Librria Base-->
    <script src="Recursos/Js/jquery.min.js"></script>
    
    <!-*****************************************************************************************************-->
    <link href="Recursos/css/jquery-confirm.min.css" rel="stylesheet" />
    <script src="Recursos/Js/jquery-confirm.min.js"></script>
    <!-*****************************************************************************************************-->
   
    <link href="Recursos/css/StyleEasy.css" rel="stylesheet" />
    <script src="Recursos/LibSIMA/Objetcs.js"></script>
    <script src="Recursos/LibSIMA/AccesoDatosBase.js"></script>


    <style>
        .FondoLog2 {
            background-image: url(Recursos/img/FondoLogin.jpg);
             background-repeat: no-repeat;       
        }


        #cabecera {
          height : 100vh;
          width:100%;
          min-height: 400px;
          text-align: center;
          color: #fff;
          background-image: url(Recursos/img/FondoLogin.jpg);
          background-repeat: no-repeat;
          background-position: center;
          background-size: cover;
        }


    </style>
   

</head>
<body class="FondoLog" onkeypress="if(event.keyCode==13){EasyLoginCard1_ctl19_ToolBar_Onclick({Id:'btnLogin',Texto:'Aceptar',Descripcion:'',Icono:'',RunAtServer:'True',ClassName:'btn btn-primary',Ubicacion:'Izquierda'});}">
    <form id="form1" runat="server">
        <cc1:EasyLoginCard ID="EasyLoginCard1" runat="server" AutenticacionWindows="False" CadenaLDAP="LDAP://simaperu.com.pe" CssClass="padre" ImagenLogo="Recursos/img/escudo.gif" OnValidacion="EasyLoginCard1_Validacion" ></cc1:EasyLoginCard>
           
        
    <style type="text/css">
           .CardLogin  {
               margin-top: 220px;
                /*margin-right: auto;*/
                margin-left: auto;
                /*padding-right: 15px;*/
                padding-left: 405px;
                width: 100%;
                position:absolute;
            }
       


     </style>
     <cc1:EasyClockDigital ID="EasyClockDigital1" runat="server" /></form>
 
   <section id="cabecera">
      <div class="contenedor">
          <h1>SIMA PERU S.A</h1>
        <h1>Profesionales en la Industria Naval y Metal Mecanica</h1>
        <p>tecnología de Desarrollo Web.</p>
      </div>
    </section>

   
    <script>
      /*  var index = 0;
        var text = 'Servicios Industriales de la Marina S.A';
        var speed = 50;

        function textEffect() {
            if (index < text.length) {
                document.getElementById("effect")
                    .innerHTML += text.charAt(index);
                index++;
                setTimeout(textEffect, speed);
            }
            else {
                index = 0;
                document.getElementById("effect").innerHTML = "";
                setTimeout(textEffect, 1200);
            }
        }
        textEffect();*/



        window.addEventListener('keydown', detectCapsLock)
        window.addEventListener('keyup', detectCapsLock)

        function detectCapsLock(e) {
            if (e.getModifierState('CapsLock')) {
                // caps lock is on 
                //alert('Mayusculas activas');
            } else {
                // caps lock is off
                //alert('Mayusculas desactivada');
            }
        }

    </script>
</body>
</html>
