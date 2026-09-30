<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Schedule.aspx.vb" Inherits="wdw.Schedule" %>

<%@ Register tagprefix="uc1" tagname="topmenu" src="controls/topmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="clientSearch" Src="~/controls/clientSearch.ascx" %>
<%@ Register TagPrefix="uc1" TagName="schedGrid" Src="~/controls/schedGrid.ascx" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Schedule</title>
		<script language="javascript">
//this is called from Site and is used at post back to determine if a new site has just been added
function setNewJobId(job_id) {
	document.getElementById("txtHiddenNewJobId").value = job_id;
}
//this function scrolls to previous grid rows that had focus and is called from the forms onload event <BODY> Tag
function posgrid() {
	//the hidden job id isn't actualy hidden to start with...it must be set to hidden on form load
    // These were modified to use getElementByID
    document.getElementById("SchedGrid1$txtHiddenNewJobId").style.visibility = 'hidden';

    var job_id = document.getElementById("SchedGrid1$txtHiddenNewJobId").value;
    //alert(job_id);

	//reposition the client search grid if anything had focus
	var csRow = igtbl_getActiveRow("ClientSearch1UWGClient");
	var csCell = igtbl_getActiveCell("ClientSearch1UWGClient");
	var csCell = igtbl_getActiveCell("ClientSearch1UWGClient");
	
	if (csCell != null) {
		csRow = csCell.Row;
	}
	
	if (csRow != null) {
		igtbl_scrollToView("ClientSearch1UWGClient", igtbl_getElementById(csRow.Element.id));
	}
		
	//reposition the prior grid if anything had focus
	var psRow = igtbl_getActiveRow("UWGPriorSched");
	var psCell = igtbl_getActiveCell("UWGPriorSched");
	
	if (psCell != null) {
		psRow = psCell.Row;
	}
	
	if (psRow != null) {
		igtbl_scrollToView("UWGPriorSched", igtbl_getElementById(psRow.Element.id));
	}
	
	//reposition the never grid if anything had focus
	var nsRow = igtbl_getActiveRow("UWGNeverSched");
	var nsCell = igtbl_getActiveCell("UWGNeverSched");
	
	if (nsCell != null) {
		nsRow = nsCell.Row;
	}
	
	if (nsRow != null) {
		igtbl_scrollToView("UWGNeverSched", igtbl_getElementById(nsRow.Element.id));
		//check to see if the hidden jobid field in the ScheduleGrid has a value...and if so...
		//call the launchJobOrphan function as a new site has just been added
		if (job_id != 0) {
			launchJobOrphan(job_id);
			document.getElementById("txtHiddenNewJobId").value = 0;
		}
	}
	//set the focus to the siteaddress
	document.all("ClientSearch1_txtSiteAddr").focus();
}

//this function will actually launch the job window
function launchJobOrphan(job_id) {
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
//this jscript function opens a job window when a job is double-clicked
function DoubleClickOrphan(gridName, itemName) { 
	var row = igtbl_getRowById(itemName); 
	if (row != null){
		var job_id = row.getCellFromKey("Job_ID").getValue();
		launchJobOrphan(job_id);
	} 
}
		</script>

		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body onload="posgrid()">
		<form clientidmode="Static" id="Form1" method="post" runat="server">


			<TABLE id="Table1" style="WIDTH: 1003px; HEIGHT: 160px" cellSpacing="0" cellPadding="0" width="1003" border="0">
				<TR>
					<TD style="HEIGHT: 3px" align="left" bgColor="aqua" height="3"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="left" bgColor="aqua" height="18"><uc1:clientsearch id="ClientSearch1" runat="server"></uc1:clientsearch></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px" align="left" bgColor="aqua" height="16"><uc1:schedgrid ClientIDMode="Static" id="SchedGrid1" runat="server"></uc1:schedgrid></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 90px" align="left" bgColor="aqua" height="90">
						<TABLE id="Table2" style="WIDTH: 1002px; HEIGHT: 73px" borderColor="black" cellSpacing="1" cellPadding="1" width="1002" border="1">
							<TR>
								<TD style="WIDTH: 504px" width="504"><igtbl:ultrawebgrid id="UWGNeverSched" runat="server" Width="492px" Height="62px">
										<Bands>
											<igtbl:UltraGridBand></igtbl:UltraGridBand>
										</Bands>
										<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" ColHeadersVisibleDefault="No" RowHeightDefault="20px" Version="2.00" SelectTypeRowDefault="Single" SelectTypeCellDefault="Single" BorderCollapseDefault="Separate" Name="UWGNeverSched" TableLayout="Fixed">
											<AddNewBox>
												<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

												</Style>
											</AddNewBox>
											<Pager>
												<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

												</Style>
											</Pager>
											<HeaderStyleDefault BorderStyle="Solid" BackColor="LightGray">
												<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
											</HeaderStyleDefault>
											<FrameStyle Width="492px" Cursor="Default" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Aqua" BorderStyle="Solid" BackColor="Aqua" Height="62px"></FrameStyle>
											<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
												<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
											</FooterStyleDefault>
											<ClientSideEvents DblClickHandler="DoubleClickOrphan"></ClientSideEvents>
											<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
											<SelectedRowStyleDefault BackColor="#CAD6E0"></SelectedRowStyleDefault>
											<RowStyleDefault BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Gray" BorderStyle="Solid" BackColor="White" Height="18px">
												<Padding Left="3px"></Padding>
												<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
											</RowStyleDefault>
											<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
										</DisplayLayout>
									</igtbl:ultrawebgrid></TD>
								<TD width="50%"><igtbl:ultrawebgrid id="UWGPriorSched" runat="server" Width="492px" Height="62px">
										<Bands>
											<igtbl:UltraGridBand></igtbl:UltraGridBand>
										</Bands>
										<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" ColHeadersVisibleDefault="No" RowHeightDefault="20px" Version="2.00" SelectTypeRowDefault="Single" SelectTypeCellDefault="Single" BorderCollapseDefault="Separate" Name="UWGPriorSched" TableLayout="Fixed" CellClickActionDefault="Edit">
											<AddNewBox>
												<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

												</Style>
											</AddNewBox>
											<Pager>
												<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

												</Style>
											</Pager>
											<HeaderStyleDefault BorderColor="Turquoise" BorderStyle="Solid" BackColor="LightGray" Height="18px">
												<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
											</HeaderStyleDefault>
											<FrameStyle Width="492px" Cursor="Default" BorderWidth="1px" Font-Size="8pt" Font-Names="Verdana" BorderColor="Aqua" BorderStyle="Solid" BackColor="Aqua" Height="62px"></FrameStyle>
											<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
												<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
											</FooterStyleDefault>
											<ClientSideEvents DblClickHandler="DoubleClickOrphan"></ClientSideEvents>
											<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
											<SelectedRowStyleDefault BackColor="#CAD6E0"></SelectedRowStyleDefault>
											<RowStyleDefault BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Gray" BorderStyle="Solid" BackColor="White">
												<Padding Left="3px"></Padding>
												<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
											</RowStyleDefault>
											<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
										</DisplayLayout>
									</igtbl:ultrawebgrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		    
		</form>
	</body>
</HTML>
