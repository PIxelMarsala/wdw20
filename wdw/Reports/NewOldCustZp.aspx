<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewOldCustZp.aspx.vb" Inherits="wdw.NewOldCustZp" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm2</title>
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
								<TD style="WIDTH: 168px"><asp:label id="lblFromDate" runat="server" Font-Bold="True" Height="19px" Width="159px" Font-Size="X-Small"
										Font-Names="Verdana">From Date (mm/dd/yyyy):</asp:label></TD>
								<TD style="WIDTH: 189px"><asp:textbox id="txtFromDate" runat="server" Width="178px"></asp:textbox></TD>
								<TD><asp:button id="btnLoad" runat="server" Text="Load Report" Width="79px"></asp:button>
                                    </TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 167px"><asp:label id="lblToDate" runat="server" Font-Bold="True" Width="159px" Font-Size="X-Small"
										Font-Names="Verdana">To Date (mm/dd/yyyy):</asp:label></TD>
								<TD><asp:textbox id="txtToDate" runat="server" Width="177px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 167px"><asp:label id="lblzip" runat="server" Font-Bold="True">Zips:</asp:label></TD>
								<TD><asp:listbox id="lstZip" runat="server" Width="176px" SelectionMode="Multiple"></asp:listbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><cr:crystalreportviewer id="CrystalReportViewer1" runat="server" Height="50px" Width="350px" Visible="False"
							DisplayToolbar="False" SeparatePages="False"></cr:crystalreportviewer></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
