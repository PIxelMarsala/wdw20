<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Dispatch.aspx.vb" Inherits="wdw.Dispatch" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Dispatch</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 36px">
						<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 168px"><asp:label id="lblFromDate" runat="server" Height="19px" Font-Bold="True" Font-Names="Verdana"
										Font-Size="X-Small" Width="159px">From Date (mm/dd/yy):</asp:label></TD>
								<TD style="WIDTH: 189px"><asp:textbox id="txtFromDate" tabIndex="1" runat="server" Width="178px"></asp:textbox></TD>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 56px">
						<TABLE id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 167px"><asp:label id="lblToDate" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
										Width="159px">To Date (mm/dd/yy):</asp:label></TD>
								<TD><asp:textbox id="txtToDate" tabIndex="2" runat="server" Width="177px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 167px"><asp:label id="lblSub" runat="server" Font-Bold="True">Subcontractor:</asp:label></TD>
								<TD style="WIDTH: 180px"><asp:listbox id="lstSub" tabIndex="3" runat="server" Width="176px" SelectionMode="Multiple"></asp:listbox></TD>
								<TD><asp:button id="btnLoad" tabIndex="4" runat="server" Text="Load Report"></asp:button>
									<asp:button id="btnDone" tabIndex="6" runat="server" Text="Done" Visible="False"></asp:button>
									</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><CR:CRYSTALREPORTVIEWER ToolPanelView="None" id="CrystalReportViewer1" runat="server" Height="50px" Width="350px" Visible="False"></CR:CRYSTALREPORTVIEWER>
                    </TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
