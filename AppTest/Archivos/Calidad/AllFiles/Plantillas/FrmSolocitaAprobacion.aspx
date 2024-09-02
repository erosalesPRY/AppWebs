<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSolocitaPaorbacion.aspx.cs" Inherits="demoOracle.Test.FrmSolocitaPaorbacion" %>

<HTML>
	<HEAD>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <meta content="text/html; charset=iso-8859-1" http-equiv=Content-Type> 
        
        
		<style> 
			.hmmessage P { PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 0px }
			body cellDestino { FONT-FAMILY: Calibri; FONT-SIZE: 12pt }
			.BaseItemInGrid { BORDER-BOTTOM: #99bbe8 1px dotted; BORDER-LEFT: #99bbe8 1px dotted; MARGIN-TOP: 5px; FONT: 11px tahoma,arial,sans-serif; BACKGROUND: #dfe8f6; HEIGHT: 20px; COLOR: #15428b; BORDER-TOP: #99bbe8 1px dotted; CURSOR: default; BORDER-RIGHT: #99bbe8 1px dotted }
			.BordeFT { border-radius: 60%; box-shadow: 0px 0px 15px #000; -moz-transition: all 1s; -webkit-transition: all 1s; -o-transition: all 1s }
		    .auto-style1 {
                color: #CC3300;
            }
		</style>

		<script>
			alert();
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="10">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
				<TR>
					<TD height="20" width="3%"></TD>
					<TD rowspan="4" style="BORDER-BOTTOM: darkgray 1px solid; BORDER-LEFT: darkgray 1px solid; PADDING-BOTTOM: 15px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BORDER-TOP: darkgray 1px solid; BORDER-RIGHT: darkgray 1px solid; PADDING-TOP: 5px"
						bgColor="ghostwhite" height="20" valign="top">
                        <IMG style="WIDTH: 77px; HEIGHT: 88px" alt="" src="[IMG]" width="77" 
                            height="88" class="BordeFT"></TD>
					<TD width="97%" colSpan="6" height="20"></TD>
				</TR>
				<TR>
					<TD bgColor="3375BB" height="25"></TD>
					<TD style="PADDING-LEFT: 5px; COLOR: #ffffff; FONT-WEIGHT: bold" bgColor="3375BB" height="25"
						colSpan="6">SOLICITUD DE APROBACIÓN</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="PADDING-LEFT: 5px; FONT-WEIGHT: bold; border-bottom: gray 1px solid;" colSpan="6" align="left">[QUIENENVIA]</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="PADDING-LEFT: 5px; FONT-SIZE: 10pt; FONT-WEIGHT: bold" noWrap></TD>
					<TD style="FONT-SIZE: 10pt" noWrap align="left"></TD>
					<TD style="FONT-SIZE: 10pt; FONT-WEIGHT: bold" noWrap></TD>
					<TD style="FONT-SIZE: 10pt" noWrap align="left"></TD>
					<TD style="FONT-SIZE: 10pt; FONT-WEIGHT: bold" noWrap></TD>
					<TD style="FONT-SIZE: 10pt" width="50%" align="left"></TD>
				</TR>
                <tr>
                    <td>
                    </td>
                    <td rowspan="1" colspan="7">
			<table border="0">
                            <tr>
                                <td colspan="8" style="border-bottom: gray 1px solid; font-size: 10pt; height: 33px;">
                                    Se remite Ficha de Inspección, la cual se describe líneas abajo,
                                    a fin se sirva dar su aprobación. Cabe resaltar, que se deben aprobar con la finalidad de agilizar los procesos de inspección ,
                                    en el cual se deban de cumplir con los plazos establecidos.
                                </td>
                            </tr>
                            <tr>
                                <td  nowrap="nowrap" style="padding-left: 5px; font-weight: bold; font-size: 10pt">
                                    PROYECTO:</td>
                                <td colspan="7"> [PROYECTO]</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                 <td>
                                </td>
                                 <td>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap" style="padding-left: 5px; font-weight: bold; font-size: 10pt;
                                    height: 19px">
                                    INSPECCIÓN:</td>
                                <td align="left" nowrap="nowrap" style="font-size: 10pt; height: 19px">
                                    <span style="font-size: 10pt">[NRO]</span></td>
                                <td nowrap="nowrap" style="padding-left: 5px; font-weight: bold; font-size: 10pt;
                                    height: 19px">
                                    FECHA DE INSPECCIÓN:</td>
                                <td align="left" nowrap="nowrap" style="font-size: 10pt; height: 19px">
                                    [FECHA]</td>
                                <td nowrap="nowrap" style="padding-left: 5px; font-weight: bold; font-size: 10pt;
                                    height: 19px">
                                    ESTADO:</td>
                                <td align="left" nowrap="nowrap" style="font-size: 10pt; height: 19px">
                                    [ESTADO]</td>
                                <td nowrap="nowrap" style="padding-left: 5px; font-weight: bold; font-size: 10pt;
                                    height: 19px">
                                    PROCESO:</td>
                                <td align="left" nowrap="nowrap" style="font-size: 10pt; height: 19px">
                                    [PROCESO]</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td height="20"  style="padding-left: 5px; font-weight: bold; font-size: 10pt">
                        CLIENTE:</td>
                    <td colspan="7" nowrap="nowrap" style="padding-left: 5px; font-weight: bold; font-size: 10pt">
                        [CLIENTE]</td>
                </tr>
				<TR>
					<TD style="height: 20px" ></TD>
					<TD style="PADDING-LEFT: 5px; FONT-SIZE: 10pt; FONT-WEIGHT: bold; border-bottom-style: dotted; border-bottom-width: 1px; border-bottom-color: #808080; height: 20px;" colSpan="7">
                        DESCRIPCIÓN</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="PADDING-LEFT: 5px; FONT-SIZE: 10pt" colSpan="7" align="left">[DESCRIPCION]</TD>
				</TR>
                <tr>
                    <td>
                    </td>
                    <td align="left" colspan="7" style="padding-left: 5px; font-size: 10pt; border-bottom: #808080 1px dotted;height: 20px"></td>
                </tr>
                <tr>
		    <td></td>
                    <td colspan=7 style="font-size: 10pt;color:gray;">[MSG]
                    </td>
                </tr>
		<tr>
			<td colspan=8 bgColor="3375BB" height="45" align="center">
	 			<table style="width:100%;">
					<tr>
						<td align="right">[APROB]</td>
						<td style="width:10%;"></td>
						<td  align="left">[DESAPROB]</td>
					</tr>
				</table> 
			</td>
		</tr>
		<tr>
			<td></td>
                    	<td colspan="6" style="font-size: 10pt">Para mayor detalle ingrese a esta dirección: <a href="[PATHAPP]">SIMA <em><span>Net Suite</span></em></a></td>
			<td></td>
			<td align="right"></td>
		</tr>
		</TABLE>
		</form>
	</body>
</HTML>