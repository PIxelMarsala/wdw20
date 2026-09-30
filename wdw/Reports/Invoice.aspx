<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Invoice.aspx.vb" Inherits="wdw.Invoice" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
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
						<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 424px"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
							</TR>
						</table>

						<div>
							<div>
								<asp:label id="lblWDWAddrLine1" runat="server" Width="198px" Font-Bold="True" Font-Size="X-Small" Font-Names="Verdana">WDW Address Line 1:</asp:label>
								<asp:textbox id="txtWDWAddrLine1" runat="server" Width="276px"></asp:textbox>
							</div>
							<div>
								<asp:label id="lblWDWAddrLine2" runat="server" Width="198px" Font-Bold="True" Font-Size="X-Small" Font-Names="Verdana">WDW Address Line 2:</asp:label>
								<asp:textbox id="txtWDWAddrLine2" runat="server" Width="276px"></asp:textbox>
							</div>
							<div>
								<asp:label id="lblPhone" runat="server" Width="198px" Font-Bold="True" Font-Size="X-Small" Font-Names="Verdana">Phone #:</asp:label>
								<asp:textbox id="txtPhone" runat="server" Width="178px"></asp:textbox>
							</div>
							<div>
								<asp:label id="lblFax" runat="server" Width="198px" Font-Bold="True" Font-Size="X-Small" Font-Names="Verdana">Fax #:</asp:label>
								<asp:textbox id="txtFax" runat="server" Width="179px"></asp:textbox>
							</div>
						</div>

						<div style="margin-top:10px;padding:10px;border-top:1px solid blue;">
							<asp:Label Width="198px" Text="Release Date (m/d/yy): " AssociatedControlID="txtReleaseDate" runat="server"></asp:Label>
							<asp:TextBox ID="txtReleaseDate" runat="server" Width="276px" AutoPostBack="true" OnTextChanged="txtReleaseDate_TextChanged"></asp:TextBox>
							&nbsp;<asp:Button ID="btnRefreshList" runat="server" Text="Show Invoices" OnClick="btnRefreshList_Click" />
							<p style="margin-top:3px;color:darkslategrey;margin-left:25px;">** Latest Invoice Release Date: <label id="lblMaxDate" runat="server" /></p>
						</div>

						<div>
							<p>Select one or more invoices for printing: (<asp:LinkButton ID="lnkSelectAll" runat="server" Text="Select All" OnClick="lnkSelectAll_Click"></asp:LinkButton> | <asp:LinkButton ID="lnkSelectNone" runat="server" Text="Unselect All" onclick="lnkSelectNone_Click"></asp:LinkButton>)</p>
							<asp:CheckBoxList ID="chklstInvoices" AutoPostBack="false" runat="server" RepeatColumns="2" BorderColor="Black" CellPadding="3">
							</asp:CheckBoxList>
						</div>

						<div style="margin-top:10px;padding:10px;border-top:1px solid blue;">
							<asp:button id="btnLoad" runat="server" Width="112px" Text="Run Report"></asp:button>
						</div>
						<CR:CRYSTALREPORTVIEWER id="CrystalReportViewer1" runat="server" SeparatePages="False" DisplayToolbar="True" EnableDrillDown="False" Visible="False" Width="350px" Height="50px"></CR:CRYSTALREPORTVIEWER></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
