<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WSCore._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="/Recursos/style.css"/>
    <title></title>
</head>
<body>
    <main class="page-content">
        <div class="card">
            <div class="content">
                <h2 class="title">General</h2>
                <p class="copy">Servicios Generales del Core Sima</p>
                <a class="btn" href="/General/General.asmx">Ver</a>
            </div>
        </div>
        <div class="card">
            <div class="content">
                <h2 class="title">Control de Inspecciones</h2>
                <p class="copy">Servicios para el Control de Inspecciones del Core Sima</p>
                <a class="btn" href="/GestionCalidad/ControlInspecciones.asmx">Ver</a>
            </div>
        </div>
        <div class="card">
            <div class="content">
                <h2 class="title">Logistica</h2>
                <p class="copy">Servicios para el modulo MPV de Sistrades</p>
                <a class="btn" href="/GestionLogistica/logistica.asmx">Ver</a>
            </div>
        </div>
        <div class="card">
            <div class="content">
                <h2 class="title">Mano de Obra</h2>
                <p class="copy">Servicios para el Modulo de Mano de Obra SIMANET 2023 del Core Sima</p>
                <a class="btn" href="/GestionProduccion/ManodeObra.asmx">Ver</a>
            </div>
        </div>
        <div class="card">
            <div class="content">
                <h2 class="title">Personal</h2>
                <p class="copy">Servicios del modulo Personal del Core Sima</p>
                <a class="btn" href="/RecursosHumanos/Personal.asmx">Ver</a>
            </div>
        </div>
        <div class="card">
            <div class="content">
                <h2 class="title">Marcaciones</h2>
                <p class="copy">Servicios del modulo de Marcaciones del O7</p>
                <a class="btn" href="/RecursosHumanos/Marcaciones.asmx">Ver</a>
            </div>
        </div>
        <div class="card">
            <div class="content">
                <h2 class="title">Reportes</h2>
                <p class="copy">Servicios para el Modulo de Reportes SIMANET 2023 del Core Sima</p>
                <a class="btn" href="/GestionReportes/AdministrarReportes.asmx">Ver</a>
            </div>
        </div>
        <div class="card">
            <div class="content">
              <h2 class="title">Seguridad</h2>
              <p class="copy">Servicios del modulo de Seguridad y Accesos del Core Sima</p>
              <a class="btn" href="/Seguridad/Seguridad.asmx">Ver</a>
            </div>
        </div>
    </main>
</body>
</html>
