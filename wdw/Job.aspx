<%@ Page validateRequest="false" Language="vb" AutoEventWireup="false" Codebehind="Job.aspx.vb" Inherits="wdw.Job1"%>
<%@ Register TagPrefix="uc1" TagName="job" Src="controls/job.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Job</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body onload="onload()">
		<form id="Form1" method="post" runat="server">
			<uc1:job id="Job1" style="WIDTH: 172px; HEIGHT: 40px" runat="server"></uc1:job>
		</form>
	</body>
</HTML>
