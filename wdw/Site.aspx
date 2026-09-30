<%@ Register TagPrefix="uc1" TagName="site" Src="controls/site.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Site.aspx.vb" Inherits="wdw.Site1"%>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Site</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body onload="onload()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" bgColor="aqua" border="0">
				<TR>
					<TD>
						<uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD>
						<uc1:site id="Site1" style="WIDTH: 184px; HEIGHT: 16px" runat="server"></uc1:site></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
