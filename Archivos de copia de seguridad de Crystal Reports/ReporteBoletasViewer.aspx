﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteBoletasViewer.aspx.cs" Inherits="SKFPortal.Reportes.Boleta.ReporteBoletasViewer" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporteador Boleta</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewerBoleta" runat="server" AutoDataBind="true" />
        </div>
    </form>
</body>
</html>
