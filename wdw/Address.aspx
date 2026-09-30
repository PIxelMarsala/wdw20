<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Address.aspx.vb" Inherits="wdw.Address1"%>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="address" Src="controls/address.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Address</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body onload="onload()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="aqua">
				<TR>
					<TD>
						<uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD bgColor="aqua">
						<uc1:address id="Address1" style="WIDTH: 185px; HEIGHT: 16px" runat="server"></uc1:address></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
