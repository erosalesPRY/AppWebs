﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SIMANET_W22R.Error" %>

<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc1" %>

<%@ Register src="Controles/Header.ascx" tagname="Header" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    

        <style type="text/css">
                html,body{height:100%;width:100%}
                /*body{display:flex;margin:0;align-items:center;justify-content:center;font-size:120%;font-family:Tahoma,Arial,sans-serif;text-align:center;color:#eee;background-color:#1f2345;background-image:linear-gradient(-12deg,#1f2345,80%,#98fdff)}*/
                body{margin:0;align-items:center;justify-content:center;font-size:120%;font-family:Tahoma,Arial,sans-serif;text-align:center;color:#eee;background-color:#1f2345;background-image:linear-gradient(-12deg,#1f2345,80%,#98fdff)}
                main{width:100%;margin:0 auto}
                a{color:#98fdff}
                h1{font-size:2em;text-transform:uppercase}
                .lighten{font-weight:500}
                .svg-scalefix-container{position:relative;height:0;width:100%;padding:0;padding-bottom:35%}
                .svg-scalefix{position:absolute;height:100%;width:100%;left:0;top:0}
                svg *{stroke:#eee;fill:#212540}
                #fourohno{fill:#486475}
                .server-light{fill:#486475}
                .server-lighting{fill:#eee}
                .led{fill:#98fdff;animation: blink .3s infinite;stroke:#98fdff}
                .led:nth-child(2n+0){animation-duration:.2s}
                .led:nth-child(3n+3){animation-delay:.1s}
                @keyframes blink{0,100%{opacity:1}50%{opacity:0}}
                tspan{font-size:15px;stroke:none;fill:#eee}
                #copyright{font-size:10px}
                @media only screen and (min-width:48em){main{width:85%}#fourohno{animation:linear smokey 12s 5;transform-box:fill-box;transform-origin:bottom center}@keyframes smokey{0%{opacity:0;transform:scale(1,.5)}70%{opacity:.4}100%{opacity:0;transform:scale(1,1)}}}
                .ColorMsgLbl {
                    color: black;
                }
                .ColorMsg {
                    color: white;

                }
        </style>
    


</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;height:100%">
                <tr>
                    <td style="width:100%">
                        <uc1:Header ID="Header1" runat="server" />
                    </td>
                </tr>
              <tr>
                    <td style="width:100%">
                            <main id="drop" role="main">
                            <article class="modal">
                                <header>
                                    <h1>page error<span class="lighten">(404)</span></h1>
                                </header>
         
                            </article>
			                       <table border="0px" style="width:100%">
				                    <tr>
                                        <td align="left" class="ColorMsgLbl">Pagina:</td>
                                        <td  style="width:100%" align="left"><text><tspan class="ColorMsg" id="LblPagina" runat="server" >Metodo</tspan></text> </td>
                                    </tr>
				                    <tr>
                                        <td align="left" class="ColorMsgLbl">Metodo:</td>
                                        <td  style="width:100%" align="left"><text><tspan class="ColorMsg" id="LblMetodo" runat="server">Metodo</tspan></text></td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="ColorMsgLbl">Source:</td>
                                        <td style="width:100%" align="left"><text><tspan class="ColorMsg" id="LblSource" runat="server">©Origen del error</tspan></text></td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="ColorMsgLbl">Descripción:</td>
                                        <td  style="width:100%" align="left"><text><tspan class="ColorMsg" id="LblDescripcion" runat="server">Descripcion del error</tspan></text></td>
                                    </tr>			
                                </table>
                            <div class="svg-scalefix-container">
                                <svg class="svg-scalefix" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1071 349" preserveAspectRatio="xMinYMin meet"><title>404 Not Found</title><desc>Image showing server number 404 is broken</desc><defs>
                                    <filter x="-50%" y="-50%" width="200%" height="200%" id="blurry" filterUnits="objectBoundingBox">
					                    <feGaussianBlur stdDeviation="8" in="SourceGraphic" result="blur"/>
                                    </filter></defs>
				                    <g class="floor" transform="translate(137 235)">
					                    <rect x="3" y="49" width="792" height="1"/>
					                    <rect x="243" y="27" width="311" height="1"/>
					                    <rect x="237" y="12" width="317.6" height="1"/>
					                    <rect x="237.4" width="317.6" height="1"/>
					                    <path d="M343 2L234 86h2L343 2zM455 2l104 82h-2L455 2zM756.3 55.8L797 66h-2l-38.7-9.8v-.4zM41 55.8L.3 66h2L41 56.2v-.4z"/>
				                    </g>
				                    <g>
					                    <path class="server-lighting" d="M695.7 0l-64.2 56H644l70-56h-18.3zM1050.8 106L999 121h4.9l54.1-15h-7.2zM935.7 54l-147.2 66H801l153-66h-18.3zM380.8 0L445 56h-12.6L362.5 0h18.3zM25.6 106l51.9 15h-4.9l-54.1-15h7.1zM140.8 54L288 120h-12.6L122.5 54h18.3z"/>
				                    </g>
				                    <g transform="translate(530 143)"><path d="M497 0v101L.5 58 497 0z" class="server-light"/><rect class="server-dark" x="497" width="44" height="101"/><rect class="numplate-dark" x="512" y="16" width="17" height="6"/></g><g transform="translate(537 103)"><rect class="server-dark" x="399" width="68" height="160"/><path d="M399 .5v159L.5 98 399 .5z" class="server-light"/><path d="M396 8v144l-37-6V17l37-9z" class="server-dark"/><rect class="numplate-dark" x="419" y="23" width="27" height="10"/></g><g transform="translate(537 27)"><rect class="server-dark" x="70" y="122" width="11" height="82"/><rect class="server-dark" x="126" y="81" width="65" height="147"/><rect class="numplate-dark" x="147" y="99" width="26" height="10"/><path d="M70 123L0 175.05 70 205v-82zm56-42l-45 33.32v94.47l45 19.2V81zM236 0l-81 59.9v180.6l81 34.5V0z" class="server-light"/><path d="M189 43.3l-31 22.8v166.2l31 13.1V43.3zM233 11l-39 28.6v207.9l39 16.5V11zM99.5 106.1L83 118.2v88l16.5 6.9v-107zM123 89l-20.8 15.2v110.1L123 223V89zM68 127l-11.4 8.4v60.8L68 201v-74z" class="server-dark"/><rect class="server-dark" x="236" width="121" height="275"/><g transform="translate(271 44)"><rect class="numplate" width="53" height="20"/><text><tspan x="14.04" y="16">404</tspan></text></g></g><g transform="translate(0 143)"><path d="M43.5 0v101L540 58 43.5 0z" class="server-light"/><rect class="server-dark" width="44" height="101"/><rect class="numplate-dark" x="11.5" y="16" width="17" height="6"/></g><g transform="translate(68 102)"><rect class="server-dark" width="68" height="160"/><path d="M67.5.5v159L466 98 67.5.5z" class="server-light"/><path d="M71 8v144l37-6V17L71 8z" class="server-dark"/><rect class="numplate-dark" x="20.5" y="23" width="27" height="10"/></g><g transform="translate(178 26)"><rect class="server-dark" x="276" y="122" width="11" height="82"/><rect class="server-dark" x="166" y="81" width="65" height="147"/><rect class="numplate-dark" x="184" y="99" width="26" height="10"/><path d="M287 123l70 52.05L287 205v-82zm-56-42l45 33.32v94.47L231 228V81zM121 0l81 59.9v180.6L121 275V0z" class="server-light"/><path d="M168 43.3l31 22.8v166.2l-31 13.1V43.3zM124 11l39 28.6v207.9L124 264V11zM257.5 106.1l16.5 12.1v88l-16.5 6.9v-107zM234 89l20.8 15.2v110.1L234 223V89zM289 127l11.4 8.4v60.8L289 201v-74z" class="server-dark"/><rect class="server-dark" width="121" height="275"/><rect class="numplate" x="33" y="44" width="53" height="20"/><text><tspan x="47.04" y="61">402</tspan></text></g><g transform="translate(476 26)"><rect class="server-dark" width="121" height="277"/><g transform="translate(35 45)"><rect class="numplate" width="53" height="20"/><text><tspan x="14.04" y="16">403</tspan></text></g></g><g transform="translate(309 65)"><rect class="led" x="2" width="2" height="2"/><rect class="led" x="23" y="31" width="2" height="2"/><rect class="led" x="9" y="56" width="2" height="2"/><rect class="led" x="7" y="10" width="2" height="2"/><rect class="led" y="76" width="2" height="2"/><rect class="led" x="22" y="122" width="2" height="2"/><rect class="led" x="9" y="160" width="2" height="2"/><rect class="led" x="24" y="192" width="2" height="2"/><rect class="led" x="2" y="170" width="2" height="2"/><rect class="led" x="46" y="22" width="2" height="2"/><rect class="led" x="44" y="100" width="2" height="2"/><rect class="led" x="60" y="108" width="2" height="2"/><rect class="led" x="48" y="142" width="2" height="2"/><rect class="led" x="59" y="178" width="2" height="2"/><rect class="led" x="46" y="22" width="2" height="2"/><rect class="led" x="54" y="38" width="2" height="2"/></g><g transform="translate(700 74)" fill="#50E3C2"><rect class="led" transform="matrix(-1 0 0 1 122 0)" x="60" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 118 0)" x="58" y="31" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 108 0)" x="53" y="67" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 78 0)" x="38" y="38" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 126 0)" x="62" y="76" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 82 0)" x="40" y="122" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 86 0)" x="42" y="159" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 108 0)" x="53" y="194" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 122 0)" x="60" y="170" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 2 0)" y="23" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 14 0)" x="6" y="74" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 6 0)" x="2" y="108" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 30 0)" x="14" y="131" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 8 0)" x="3" y="178" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 36 0)" x="17" y="29" width="2" height="2"/><rect class="led" transform="matrix(-1 0 0 1 18 0)" x="8" y="38" width="2" height="2"/></g><g transform="translate(416 138)"><rect class="led" x="25" y="30" width="1" height="1"/><rect class="led" x="32" y="12" width="1" height="1"/><rect class="led" x="29" y="47" width="1" height="1"/><rect class="led" x="6" y="16" width="1" height="1"/><rect class="led" y="24" width="1" height="1"/><rect class="led" x="11" y="43" width="1" height="1"/><rect class="led" x="1" y="69" width="1" height="1"/><rect class="led" x="6" y="96" width="1" height="1"/><rect class="led" x="12" y="67" width="1" height="1"/><rect class="led" x="6" y="59" width="1" height="1"/></g><g transform="matrix(-1 0 0 1 656 138)"><rect class="led" x="25" y="30" width="1" height="1"/><rect class="led" x="32" y="12" width="1" height="1"/><rect class="led" x="12" width="1" height="1"/><rect class="led" x="6" y="16" width="1" height="1"/><rect class="led" y="24" width="1" height="1"/><rect class="led" x="11" y="43" width="1" height="1"/><rect class="led" x="1" y="69" width="1" height="1"/><rect class="led" x="6" y="96" width="1" height="1"/><rect class="led" x="29" y="70" width="1" height="1"/><rect class="led" x="6" y="59" width="1" height="1"/></g><text><tspan id="copyright" x="771.07" y="336">©Copyright SIMA PERU S.A 2022</tspan></text><path d="M751.24 251.84s-15.33-25.95 3.34-35.24c18.66-9.3 12.75-21.77 12.75-21.77s-11.4-12.27-25.43-5.78c-14.03 6.5-29.28 24.96-32.72 16.95-3.44-8.02 21.6-12.1 31-19.05 9.38-6.94 36.87-8.6 36.87-24.4 0-15.8-5.34-24.95-18.15-32.08-12.82-7.13-53.87-4.52-53.87-4.52S674.1 113.5 688.6 104.8c10.8-6.5 20.44 21.52 49.6 18.38 29.13-3.14 30.06-17.7 33.12-23.08 13.68-24.02 16.7-63.63-16.74-59.85-14.64 1.66-29.85 16.13-42.14 17-22.06 1.6-38-10.2-47.7-2.65-15.1 11.76-34.2 62.6-13.1 83.47 21.1 20.88 42.22 29.14 63.85 29.14 21.63 0 32.14-29.13 40.86-13.9 8.73 15.2-31.9 19.6-49.03 16.54-17.13-3.07-27.78 13.92-25.54 29.3 2.23 15.4 14.82 23.8 30.64 29.78 15.83 5.98 20.96-24.17 35.2-24.17 14.24 0-2.24.5-7.47 11.85-5.23 11.33 11.07 35.24 11.07 35.24z" id="fourohno" filter="url(#blurry)"/>
                                </svg>
                            </div>
                            <aside>
                                <p><small><a href="/404page/">About 404 page</a></small></p>
                            </aside>
                            </main>     
                    </td>
                </tr>

        </table>

    
        
        <cc1:EasyClockDigital ID="EasyClockDigital1" runat="server" />

    </form>
  
</body>
</html>