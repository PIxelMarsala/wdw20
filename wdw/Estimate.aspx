<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Estimate.aspx.vb" Inherits="wdw.Estimate" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Estimate</title>
		<script language="javascript">
		//this function will for pressing the enter key
//function EnterDown(gridName, cellId, key) {   
	//if(key == 13){        
		//var cell = igtbl_getCellById(cellId);   
		//if(cell) {            
			//if(cell.Row.getIndex()<cell.Row.OwnerCollection.length-1)
		//cell.Row.OwnerCollection.getRow(cell.Row.getIndex()+1).getCell(cell.Column.Index).activate(); 
	 		//igtbl_cancelEvent(event);                
		//return true;
		//}
	//}
//}	
		</script>
		<style>
		</style>
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<BODY>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<form id="Form1" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
			method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 1px; WIDTH: 995px; POSITION: absolute; TOP: 0px; HEIGHT: 576px"
				cellSpacing="1" cellPadding="1" width="995" border="1">
				<TR>
					<TD style="WIDTH: 1001px; HEIGHT: 24px"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 1001px; HEIGHT: 24px"><asp:label id="Label1" runat="server" Width="106px" Font-Bold="True">Job#</asp:label><asp:textbox id="txtJob" runat="server"></asp:textbox><asp:textbox id="txtBidHeader" runat="server" Width="157px" Visible="False"></asp:textbox><asp:literal id="Literal1" runat="server"></asp:literal><asp:label id="lblOverrde" runat="server" Font-Bold="True">Override Amt:</asp:label><asp:textbox id="txtOverride" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 1001px; HEIGHT: 27px"><asp:label id="lblErrorMsg" runat="server" Width="441px" Font-Size="Medium" ForeColor="Red"
							Height="5px"></asp:label><asp:textbox id="txttotal" runat="server" Visible="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 1001px; HEIGHT: 426px"><igtbl:ultrawebgrid id="UG1" runat="server" Width="993px" Height="460px">
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js " StationaryMargins="Header"
								RowHeightDefault="20px" Version="2.00.5000" ViewType="Hierarchical" SelectTypeRowDefault="Extended"
								SelectTypeCellDefault="Extended" NullTextDefault=" " BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
								Name="UG1" TableLayout="Fixed" CellClickActionDefault="Edit" SelectTypeColDefault="Extended"
								AllowUpdateDefault="Yes">
								<AddNewBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver" View="Compact">
									<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

									</Style>
									<ButtonStyle Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></ButtonStyle>
								</AddNewBox>
								<Pager Alignment="Center" PageSize="40">
									<Style BorderWidth="1px" BorderStyle="Solid" ForeColor="Black" BackColor="LightGray">

<Padding Left="0px" Top="2px">
</Padding>

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

									</Style>
								</Pager>
								<HeaderStyleDefault BorderWidth="1px" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" BorderStyle="Solid"
									HorizontalAlign="Center" ForeColor="Black" BackColor="LightGray" Height="40px">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</HeaderStyleDefault>
								<GroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray"></GroupByRowStyleDefault>
								<RowSelectorStyleDefault BorderWidth="1px" BorderStyle="Outset" BackColor="White"></RowSelectorStyleDefault>
								<FrameStyle Width="993px" Cursor="Hand" BorderWidth="1px" Font-Size="8pt" Font-Names="Verdana"
									BorderColor="Turquoise" BorderStyle="Solid" BackColor="Turquoise" Height="460px"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
									<Style BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
									</Style>
									<BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
								</GroupByBox>
								<SelectedHeaderStyleDefault BorderColor="White" ForeColor="Black"></SelectedHeaderStyleDefault>
								<SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="White"></SelectedGroupByRowStyleDefault>
								<SelectedRowStyleDefault ForeColor="White" BackColor="DarkMagenta"></SelectedRowStyleDefault>
								<RowAlternateStyleDefault BackColor="White"></RowAlternateStyleDefault>
								<RowStyleDefault BorderWidth="1px" Font-Size="10pt" Font-Names="verdana" BorderColor="Gray" BorderStyle="Solid"
									HorizontalAlign="Left" ForeColor="#333333" BackColor="White">
									<Padding Left="3px" Top="2px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
								<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
							</DisplayLayout>
						</igtbl:ultrawebgrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 1001px; HEIGHT: 32px">
                        <asp:button id="btnCreate" runat="server" Font-Bold="True" Text="Create Estimate"></asp:button>
                        <asp:button id="BtnDelete" runat="server" Font-Bold="True" Text="ClearEstimate"></asp:button>
                        <asp:button id="btnSelect" runat="server" Font-Bold="True" Text="Select"></asp:button>
						<asp:button id="btnExpand" runat="server" Font-Bold="True" Text="Expand"></asp:button>
						<asp:button id="btnCollapse" runat="server" Font-Bold="True" Text="Collapse" Enabled="False"></asp:button></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</BODY>
</HTML>
