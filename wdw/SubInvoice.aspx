<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SubInvoice.aspx.vb" Inherits="wdw.SubInvoice" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SubInvoice</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 9px; POSITION: absolute; TOP: 2px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 36px">
						<CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" Height="50px" Width="350px" DisplayToolbar="True" Visible="False" SeparatePages="False"></CR:CrystalReportViewer>
					</TD>
				</TR>
			</TABLE>
		    
		</form>
	</body>
</HTML>
