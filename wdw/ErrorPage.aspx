<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ErrorPage.aspx.vb" Inherits="ErrorPage" codePage="65001"%>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu>&nbsp;<!-- END PAGE HEADER MODULE -->
			<H1>An error has occurred</H1>
			<P>
				The system was unable to complete your request. This failure has been logged 
				and will require investigation by your support staff.</P>
		</form>
	</body>
</HTML>
