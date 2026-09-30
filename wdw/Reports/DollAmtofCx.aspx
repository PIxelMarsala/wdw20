<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DollAmtofCx.aspx.vb" Inherits="wdw.DollAmtofCx" %>

<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DollAmtofCx</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 36px">
						<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 168px">
									<asp:label id="lblFromDate" runat="server" Width="159px" Font-Size="X-Small" Font-Names="Verdana"
										Font-Bold="True" Height="19px">From Date (mm/dd/yyyy):</asp:label></TD>
								<TD style="WIDTH: 189px">
									<asp:textbox id="txtFromDate" runat="server" Width="178px"></asp:textbox></TD>
								<TD>
									<asp:Button id="btnLoad" runat="server" Text="Load Report"></asp:Button>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 167px">
									<asp:label id="lblToDate" runat="server" Width="159px" Font-Size="X-Small" Font-Names="Verdana"
										Font-Bold="True">To Date (mm/dd/yyyy):</asp:label></TD>
								<TD>
									<asp:textbox id="txtToDate" runat="server" Width="177px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" Width="350px" Height="50px" Visible="False"></CR:CrystalReportViewer></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
