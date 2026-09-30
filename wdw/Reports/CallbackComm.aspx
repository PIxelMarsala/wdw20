<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CallbackComm.aspx.vb" Inherits="wdw.CallbackComm" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CallbackCommission</title>

		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<TABLE id="Table1" style="Z-INDEX: 102; POSITION: absolute; TOP: 2px; LEFT: 7px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 36px">
						<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 245px" colSpan="3"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px; HEIGHT: 31px"><asp:label id="Label1" runat="server" Width="133px" Height="19px" Font-Size="X-Small" Font-Names="Verdana"
										Font-Bold="True">User:</asp:label></TD>
								<TD style="WIDTH: 379px; HEIGHT: 31px"><asp:listbox id="lstUser" tabIndex="3" runat="server" Width="176px" Height="39px" SelectionMode="Multiple"></asp:listbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"><asp:label id="lblCommission" runat="server" Width="133px" Height="19px" Font-Size="X-Small"
										Font-Names="Verdana" Font-Bold="True">Commission (%):</asp:label></TD>
								<TD style="WIDTH: 379px"><asp:listbox id="lstSub" runat="server" Width="54px">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
									</asp:listbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"><asp:label id="lblFromDate" runat="server" Width="159px" Height="19px" Font-Size="X-Small"
										Font-Names="Verdana" Font-Bold="True">From Date 
(mm/dd/yyyy):</asp:label></TD>
								<TD style="WIDTH: 379px"><asp:textbox id="txtFromDate" tabIndex="1" runat="server" Width="178px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"><asp:label id="lblToDate" runat="server" Width="159px" Font-Size="X-Small" Font-Names="Verdana"
										Font-Bold="True">To Date (mm/dd/yyyy):</asp:label></TD>
								<TD style="WIDTH: 379px"><asp:textbox id="txtToDate" tabIndex="2" runat="server" Width="177px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 124px"></TD>
								<TD style="WIDTH: 379px">&nbsp;
									<asp:button id="btnLoad" runat="server" Text="Load Report"></asp:button>
								</TD>
							</TR>
						</TABLE>
						<CR:CRYSTALREPORTVIEWER id="CrystalReportViewer1" runat="server" Width="350px" Height="50px" SeparatePages="False" Visible="False" ></CR:CRYSTALREPORTVIEWER></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
