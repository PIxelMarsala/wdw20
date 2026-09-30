<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Callback.aspx.vb" Inherits="wdw.Callback" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Callback</title>
		<script language="javascript">
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
//this function will actually launch the schedule window
function launchSchedule(client_id) {
	//doubleclicked on a row with no client_id
  
	if (client_id == 0){
		return true;
	}
	
	//open job window
	schedule_window=window.open('/Schedule.aspx?From_Parent=1&Client_ID='+ client_id,null,'status=no,tollbar=no,menubar=no,height=630,width=1020,left=0,top=23');
	if (window.schedule_window) {
		schedule_window.focus();
	}
}
//this function will actually launch the job window	
function DoubleClick(gridName, itemName) {

	var row = igtbl_getRowById(itemName); 
	if (row != null){
	
		var cell = igtbl_getCellById(itemName);
		var columnName = cell.Column.Key; 

		
		//figure out which job they selected a invoke a function to launch the job window
		if (columnName == "Job") { 
		
			var job_id = row.getCellFromKey("Job").getValue();
			launchJob(job_id);
		}
		//figure out which client they selected a invoke a function to launch the schedule window with a search
		//on that client
		if (columnName == "Client_ID" || columnName == "First Name" || columnName == "Last Name") { 
		
			var client_id = row.getCellFromKey("Client_ID").getValue();
			launchSchedule(client_id);
		}
	}
}
//this function will actually launch the lblrpt
function launchLable() {
    var CBMethod = document.all("ddlCB").value;
    var FromDate = document.all("txtFromDate").value;
    var ToDate = document.all("txtToDate").value;
    var FromZip = document.all("txtFromZip").value;
    var ToZip = document.all("txtToZip").value;
    var LastName = document.all("txtLastName").value;
    var Address1 = document.all("txtSiteAddr").value;
    var FromStart = document.all("txtFromStart").value;
    var ToStart = document.all("txtToStart").value;
            
    lbl_window=window.open('CBLbl.aspx?CB_Method='+ CBMethod + '&From_Date='+ FromDate + '&To_Date='+ ToDate +'&From_Zip='+ FromZip + '&To_Zip='+ ToZip + '&Last_Name='+ LastName + '&Addr1='+ Address1 +'&From_Start='+ FromStart + '&To_Start='+ ToStart,'_blank','status=no,tollbar=no,menubar=yes,scrollbars=yes, height=600,width=1000,left=0,top=23');
		if (window.lbl_window){
			lbl_window.focus();	
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
					<TD style="WIDTH: 990px; HEIGHT: 26px"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" borderColor="#000000" bgColor="#ffffff" height="27"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="71px" Font-Bold="True">Callback Method:</asp:label><asp:dropdownlist id="ddlCB" runat="server" Height="31px" Width="142px"></asp:dropdownlist><asp:button id="BtnLoad" runat="server" Text="Load"></asp:button><INPUT id="btnLbl" style="FONT-WEIGHT: bold; WIDTH: 98px; HEIGHT: 24px" onclick="launchLable()"
							tabIndex="2" type="button" value="Display Labels" name="btnLbl">
						<asp:button id="btnCollapse" runat="server" Font-Bold="True" Text="Collapse" Enabled="False"></asp:button><asp:button id="btnExpand" runat="server" Font-Bold="True" Text="Expand"></asp:button><asp:button id="btnClear" runat="server" Text="Clear"></asp:button>
						<asp:label id="lblErrorMsg" runat="server" Width="248px" Height="5px" Font-Size="Medium" ForeColor="Red"
							DESIGNTIMEDRAGDROP="105"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 4px" borderColor="black" bgColor="#ffffff" height="4"><asp:label id="lblFromDate" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="159px" Font-Bold="True">From Date 
(mm/dd/yyyy):</asp:label><asp:textbox id="txtFromDate" runat="server" Width="112px"></asp:textbox><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="159px" Font-Bold="True">To Date 
(mm/dd/yyyy):</asp:label><asp:textbox id="txtToDate" runat="server" Width="111px"></asp:textbox><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="99px" Font-Bold="True">From Zip:</asp:label><asp:textbox id="txtFromZip" runat="server" Width="107px"></asp:textbox><asp:label id="lblToZip" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="97px" Font-Bold="True">To Zip:</asp:label><asp:textbox id="txtToZip" runat="server" Width="95px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" borderColor="#000000" bgColor="#ffffff" height="27">
						<asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="159px" Font-Bold="True">From Start Date 
(mm/dd/yyyy):</asp:label>
						<asp:textbox id="txtFromStart" runat="server" Width="112px"></asp:textbox>
						<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="159px" Font-Bold="True">To Start Date 
(mm/dd/yyyy):</asp:label>
						<asp:textbox id="txtToStart" runat="server" Width="111px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" borderColor="#000000" bgColor="#ffffff" height="27"><asp:label id="lblClient" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="159px" Font-Bold="True">Client#:</asp:label><asp:textbox id="txtClient" runat="server" Width="132px"></asp:textbox><asp:label id="lblLast" runat="server" Font-Names="Verdana" Font-Size="X-Small" Font-Bold="True">Last</asp:label><asp:textbox id="txtLastName" runat="server" Font-Names="Verdana" Font-Size="X-Small" Width="144px"></asp:textbox><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="X-Small" Height="19px"
							Width="67px" Font-Bold="True">Address:</asp:label><asp:textbox id="txtSiteAddr" runat="server" Font-Names="Verdana" Font-Size="X-Small" Width="246px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px; HEIGHT: 490px"><igtbl:ultrawebgrid id="UG1" runat="server" Height="488px" Width="995px" Visible="False">
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" StationaryMargins="Header"
								AllowAddNewDefault="Yes" AllowSortingDefault="Yes" RowHeightDefault="20px" Version="2.00.5000"
								ViewType="Hierarchical" SelectTypeRowDefault="Extended" SelectTypeCellDefault="Extended" NullTextDefault=" "
								HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
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
									BorderColor="Turquoise" BorderStyle="Solid" BackColor="Turquoise" Height="488px"></FrameStyle>
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
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
						</igtbl:ultrawebgrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px"><asp:button id="btnSave" runat="server" Width="125px" Font-Bold="True" Text="Save"></asp:button></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
