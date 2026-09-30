<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CBLbl.aspx.vb" Inherits="wdw.CBLbl"%>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CBLbl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<P>
			<FORM id="Form1" method="post" runat="server">
				<TABLE id="Table1" style="Z-INDEX: 103; LEFT: 8px; WIDTH: 768px; POSITION: absolute; TOP: 8px; HEIGHT: 84px"
					cellSpacing="0" cellPadding="0" width="768" border="0">
					<TR>
						<TD><asp:button id="btnLoad" runat="server" Text="Export"></asp:button>
							<asp:Label id="Label1" runat="server"></asp:Label>
							<asp:hyperlink id="HyperLink2" runat="server" NavigateUrl="http:\\localhost\wdw\ExportCrystal\label.rtf" Visible="False">Save Export</asp:hyperlink>
							<asp:Label id="lblErrorMsg" runat="server" Width="54px" ForeColor="Red" Font-Size="Medium">lblErrorMsg</asp:Label>
							<asp:Button id="btnDone" runat="server" Text="Done"></asp:Button>
						</TD>
					</TR>
					<TR>
						<TD><cr:crystalreportviewer id="CrystalReportViewer1" runat="server" Visible="False" DisplayGroupTree="False" Width="350px" Height="50px" DisplayToolbar="False"></cr:crystalreportviewer></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</FORM>
		</P>
	</body>
</HTML>
