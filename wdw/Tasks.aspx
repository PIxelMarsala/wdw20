<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Tasks.aspx.vb" Inherits="wdw.Tasks" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tasks</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 2px" cellSpacing="1" cellPadding="1" width="100%" border="1">
				<TR>
					<TD style="WIDTH: 990px; HEIGHT: 27px"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px; HEIGHT: 24px">
						<asp:label id="lblErrorMsg" runat="server" Height="22px" Width="577px" Text="lblErrorMsg" ForeColor="Red" Font-Names="Verdana" Font-Size="Medium">lblErrorMsg</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px; HEIGHT: 591px"><igtbl:ultrawebgrid id="UG1" runat="server" Width="995px" Height="593px">
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" StationaryMargins="Header" AllowAddNewDefault="Yes" RowHeightDefault="20px" Version="2.00.5000" ViewType="Hierarchical" SelectTypeRowDefault="Extended" SelectTypeCellDefault="Extended" NullTextDefault=" " BorderCollapseDefault="Separate" AllowColSizingDefault="Free" Name="UG1" TableLayout="Fixed" SelectTypeColDefault="Extended" AllowUpdateDefault="Yes">
								<AddNewBox ButtonConnectorStyle="None" ButtonConnectorColor="White" View="Compact" Hidden="False">
									<Style BorderWidth="1px" BorderStyle="Solid" ForeColor="Black" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

									</Style>
									<ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="Black" BackColor="DarkMagenta"></ButtonStyle>
								</AddNewBox>
								<Pager Alignment="Center" PageSize="50">
									<Style BorderWidth="1px" BorderStyle="Solid" ForeColor="Black" BackColor="LightGray">

<Padding Left="0px" Top="2px">
</Padding>

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

									</Style>
								</Pager>
								<HeaderStyleDefault BorderWidth="1px" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" BorderStyle="Solid" HorizontalAlign="Center" ForeColor="Black" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</HeaderStyleDefault>
								<GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
								<RowSelectorStyleDefault BorderWidth="1px" BorderStyle="Outset" BackColor="White"></RowSelectorStyleDefault>
								<FrameStyle Width="995px" Cursor="Hand" BorderWidth="1px" Font-Size="8pt" Font-Names="Verdana" BorderColor="Turquoise" BorderStyle="Solid" BackColor="Turquoise" Height="593px"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
									<Style BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
									</Style>
									<BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
								</GroupByBox>
								<SelectedHeaderStyleDefault BorderColor="White" ForeColor="Black"></SelectedHeaderStyleDefault>
								<SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
								<SelectedRowStyleDefault ForeColor="White" BackColor="DarkMagenta"></SelectedRowStyleDefault>
								<RowAlternateStyleDefault BackColor="White"></RowAlternateStyleDefault>
								<RowStyleDefault BorderWidth="1px" Font-Size="10pt" Font-Names="verdana" BorderColor="Gray" BorderStyle="Solid" HorizontalAlign="Left" ForeColor="Black" BackColor="White">
									<Padding Left="3px" Top="2px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
								<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
							</DisplayLayout>
						</igtbl:ultrawebgrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px"><asp:button id="btnSubmit" runat="server" Font-Bold="True" Text="Submit"></asp:button></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
