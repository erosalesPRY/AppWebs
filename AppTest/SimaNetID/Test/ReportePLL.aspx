<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportePLL.aspx.cs" Inherits="SIMANET_W22R.Test.ReportePLL" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <rsweb:ReportViewer ID="rpvPlanilla" runat="server">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
