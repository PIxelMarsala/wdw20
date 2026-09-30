<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Deposit.aspx.vb" Inherits="wdw.Deposit" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="cr" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Deposit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script>
function PrintButtonClick()
		{
		// Cause a PostBack
		alert("Printing....");
		window.print();
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 1px; WIDTH: 992px; POSITION: absolute; TOP: 5px; HEIGHT: 97px"
				cellSpacing="0" cellPadding="0" width="992" border="0">
				<TR>
					<TD style="WIDTH: 356px"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
					<TD style="WIDTH: 954px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 356px"><INPUT id="btnPrint" style="WIDTH: 40px; HEIGHT: 24px" onclick="PrintButtonClick()" tabIndex="5"
							type="button" value="Print" name="btnPrint">
						<asp:button id="btnDone" tabIndex="6" runat="server" Text="Done"></asp:button></TD>
					<TD style="WIDTH: 955px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 356px">
						<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
						</TABLE>
						<cr:crystalreportviewer id="CrystalReportViewer1" runat="server" DisplayToolbar="False" SeparatePages="False"
							Height="50px" Width="350px" DisplayGroupTree="False"></cr:crystalreportviewer>
					</TD>
					<TD style="WIDTH: 955px"></TD>
				</TR>
			</TABLE>
			&nbsp;
		    
		</form>
	</body>
</HTML>
