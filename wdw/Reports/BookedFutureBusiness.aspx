<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BookedFutureBusiness.aspx.vb" Inherits="wdw.BookedFutureBusiness" %>

<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BookedFutureBusiness</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 103; LEFT: -1px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD>
                        <asp:label id="lblCurrDate" runat="server" Width="159px" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small">Current System Date (mm/dd/yyyy):</asp:label>
                        <asp:textbox id="txtCurrDate" runat="server"></asp:textbox><asp:button id="btnLoad" runat="server" Text="Load Report"></asp:button>
					</TD>
				</TR>
				<TR>
					<TD>
						<CR:crystalreportviewer id="CrystalReportViewer1" runat="server" Width="350px" Height="50px" Visible="False"></CR:crystalreportviewer></TD>
				</TR>
			</TABLE>
		    
		</form>
	</body>
</HTML>
