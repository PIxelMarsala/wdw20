<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SecurityViolation.aspx.vb" Inherits="wdw.SecurityViolation" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SecurityViolation</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 960px; HEIGHT: 1px" cellSpacing="0" cellPadding="0" width="960" border="0">
				<TR>
					<TD>
						<uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
			</TABLE>
			<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 100%" ms_positioning="GridLayout">
				<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 178px; POSITION: absolute; TOP: 126px" runat="server" Font-Names="Verdana" Font-Size="Large">You Are Not Authorized to Access the Requested Function</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 101; LEFT: 212px; POSITION: absolute; TOP: 167px" runat="server" Font-Names="Verdana" Font-Size="Large" Width="608px">Either use "Back" to return to the Previous Screen</asp:Label>
				<asp:Label id="Label3" style="Z-INDEX: 102; LEFT: 347px; POSITION: absolute; TOP: 214px" runat="server" Font-Names="Verdana" Font-Size="Large" Width="328px">or Select a new Menu Item</asp:Label></DIV>
		</form>
	</body>
</HTML>
