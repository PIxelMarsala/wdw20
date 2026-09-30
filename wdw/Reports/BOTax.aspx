<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BOTax.aspx.vb" Inherits="wdw.BOTax" %>

<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BOTax</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
<%--		<script>
		function PrintButtonClick()
		{
		// Cause a PostBack
		alert("Printing....");
		window.print();
		}
		</script>--%>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 1px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
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
						<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 167px">
									<asp:Label id="Label1" runat="server" Font-Bold="True">City</asp:Label></TD>
								<TD>
									<asp:dropdownlist id="lstCity" runat="server" Width="177px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" Width="350px" Height="50px" Visible="False" SeparatePages="False" HasToggleGroupTreeButton="false"></CR:CrystalReportViewer></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
