<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AR.aspx.vb" Inherits="wdw.AR" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<%@ Register src="controls/topmenu.ascx" tagname="topmenu" tagprefix="uc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AR</title>
		<script language="javascript">
		//this function will actually launch the client window if the Occ Client button is clicked on the page
function launchOClient(client_id) {
		
	//open address window
	//oclient_window=window.open('/client.aspx?Client_ID='+ client_id,null,'status=no,tollbar=no,menubar=no,height=535,width=990,left=0,top=23');
	oclient_window=window.open('/client.aspx?From_Parent=1&Client_ID='+ client_id,'_blank','status=no,tollbar=no,menubar=no,height=550,width=1000,left=0,top=23');
	if (window.oclient_window) {
		oclient_window.focus();
	}
}
		//this function will actually launch the job window
function launchJob(job_id) {
	//doubleclicked on a row with no job
  
	if (job_id == 0){
		return true;
	}
	
	//open job window
	job_window=window.open('/Job.aspx?Job_ID='+ job_id,null,'status=no,tollbar=no,menubar=no,height=535,width=990,left=0,top=23');
	if (window.job_window) {
		job_window.focus();
	}
}
//this function will actually launch the job window	
function DoubleClick(gridName, itemName) {

	var row = igtbl_getRowById(itemName); 
	if (row != null){
	
		var cell = igtbl_getCellById(itemName);
		var columnName = cell.Column.Key; 

		
		//figure out which job they selected a invoke a function to launch the job window
		if (columnName == "Job_ID") { 
		
			var job_id = row.getCellFromKey("Job_ID").getValue();
			launchJob(job_id);
		}
		if (columnName == "Client #") { 
		
			var client_id = row.getCellFromKey("Client #").getValue();
			launchOClient(client_id);
		}
	}
}
		</script>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 1px; WIDTH: 999px; POSITION: absolute; TOP: 1px; HEIGHT: 590px"
				cellSpacing="1" cellPadding="1" width="999" border="1">
				<TR>
					<TD style="WIDTH: 990px; HEIGHT: 26px"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu>
                    </TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" borderColor="#000000" bgColor="#ffffff" height="28"><asp:label id="Label1" runat="server" Width="61px" Font-Bold="True">Client#:</asp:label><asp:textbox id="txtClient" runat="server" Width="119px" AutoPostBack="True"></asp:textbox><asp:label id="Label3" runat="server" Width="61px" Font-Bold="True">Total#:</asp:label><asp:textbox id="txtTotal" runat="server" Width="119px" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" borderColor="#000000" bgColor="#ffffff" height="27"><asp:button id="btnSave" runat="server" Width="125px" Font-Bold="True" Text="Save"></asp:button><asp:label id="lblErrorMsg" runat="server" Font-Size="Medium" Height="5px" Width="481px" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px; HEIGHT: 490px"><igtbl:ultrawebgrid id="UG1" runat="server" Width="995px" Visible="False">
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js " StationaryMargins="Header"
								AllowAddNewDefault="Yes" AllowSortingDefault="Yes" RowHeightDefault="20px" Version="2.00.5000"
								ViewType="Hierarchical" SelectTypeRowDefault="Extended" ScrollBar="Never" SelectTypeCellDefault="Extended"
								NullTextDefault=" " HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
								Name="UG1" TableLayout="Fixed" SelectTypeColDefault="Extended" AllowUpdateDefault="Yes">
								<AddNewBox ButtonConnectorStyle="None" ButtonConnectorColor="White" View="Compact" Prompt=""
									Hidden="False" Location="Top">
									<Style BorderWidth="1px" Font-Bold="True" BorderStyle="Solid" ForeColor="Transparent" BackColor="Transparent">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

									</Style>
									<ButtonStyle Width="150px" Cursor="Hand" BorderWidth="1px" BorderColor="White" BorderStyle="Outset"
										ForeColor="Black" BackColor="DarkMagenta"></ButtonStyle>
								</AddNewBox>
								<Pager Alignment="Center" PageSize="50">
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
								<FrameStyle Width="995px" Cursor="Hand" BorderWidth="1px" Font-Size="8pt" Font-Names="Verdana"
									BorderColor="Turquoise" BorderStyle="Solid" BackColor="Turquoise"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<ClientSideEvents DblClickHandler="DoubleClick"></ClientSideEvents>
								<GroupByBox ButtonConnectorStyle="Solid" ButtonConnectorColor="Silver">
									<Style BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="DarkGray">
									</Style>
									<BandLabelStyle Cursor="Default" BorderWidth="1px" BorderColor="White" BorderStyle="Outset" BackColor="Gray"></BandLabelStyle>
								</GroupByBox>
								<SelectedHeaderStyleDefault BorderColor="White" ForeColor="Black"></SelectedHeaderStyleDefault>
								<SelectedGroupByRowStyleDefault BorderWidth="1px" BorderColor="White" BorderStyle="Outset" ForeColor="White" BackColor="#CF5F5B"></SelectedGroupByRowStyleDefault>
								<SelectedRowStyleDefault ForeColor="White" BackColor="DarkMagenta"></SelectedRowStyleDefault>
								<RowAlternateStyleDefault BackColor="White"></RowAlternateStyleDefault>
								<RowStyleDefault BorderWidth="1px" Font-Size="10pt" Font-Names="verdana" BorderColor="Gray" BorderStyle="Solid"
									HorizontalAlign="Left" ForeColor="Black" BackColor="White">
									<Padding Left="3px" Top="2px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
								<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
							</DisplayLayout>
						</igtbl:ultrawebgrid>
                        
                    </TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
