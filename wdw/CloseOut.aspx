<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Closeout.aspx.vb" Inherits="wdw.Closeout" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CloseOut</title>
		<script language="javascript">
//this function will actually launch the job window
function launchInvoice() {
    var CloseOutId = document.all("txtCloseOutHeader").value;
    var Valid = document.all("txtValid").value;
            	
	if (Valid == "False"){
	   alert("The CloseOut Record is not Valid, therefore you can not view the invoice.");
	}		
	else {
	  invoice_window=window.open('SubInvoice.aspx?CloseOut_ID=' + CloseOutId ,'_blank','status=no,tollbar=no,scrollbars=yes,menubar=no,height=600,width=1000,left=0,top=23');
		if (window.invoice_window){
			invoice_window.focus();	
		}
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
		if (columnName == "Job") { 
		
			var job_id = row.getCellFromKey("Job").getValue();
			launchJob(job_id);
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
					<TD style="WIDTH: 990px; HEIGHT: 26px"><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" borderColor="black" bgColor="#ffffff" height="27"><asp:label id="Label1" runat="server" Font-Bold="True">CloseOut Header:</asp:label><asp:textbox id="txtCloseOutHeader" runat="server" Enabled="False">0</asp:textbox><asp:label id="lblErrorMsg" runat="server" Font-Size="Medium" ForeColor="Red" Height="5px"
							Width="481px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px" borderColor="#000000" bgColor="#ffffff" colSpan="2" height="23"><asp:radiobutton id="rdNew" runat="server" Font-Bold="True" GroupName="Group1" AutoPostBack="True"
							Text="New CloseOut"></asp:radiobutton><asp:radiobutton id="rdExist" runat="server" Font-Bold="True" Height="6px" GroupName="Group1" AutoPostBack="True"
							Text="Existing Closeout"></asp:radiobutton><asp:textbox id="txtValid" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px" borderColor="black" bgColor="white" colSpan="2" height="23"><asp:label id="lblSub" runat="server" Font-Bold="True">Subcontractor:</asp:label><asp:dropdownlist id="lstSub" runat="server" Width="134px" AutoPostBack="True"></asp:dropdownlist><asp:label id="lblCODate" runat="server" Font-Bold="True" Visible="False">Close Date:</asp:label><asp:dropdownlist id="lstSubCo" runat="server" Width="234px" Visible="False"></asp:dropdownlist><asp:button id="BtnLoad" runat="server" Font-Bold="True" Text="GetCloseOut" Visible="False"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px; HEIGHT: 490px"><igtbl:ultrawebgrid id="UG1" runat="server" Width="995px" Height="489px">
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" StationaryMargins="Header"
								AllowAddNewDefault="Yes" AllowSortingDefault="Yes" RowHeightDefault="20px" Version="2.00.5000"
								ViewType="Hierarchical" SelectTypeRowDefault="Extended" ScrollBar="Always" SelectTypeCellDefault="Extended"
								NullTextDefault=" " BorderCollapseDefault="Separate" AllowColSizingDefault="Free" Name="UG1"
								TableLayout="Fixed" CellClickActionDefault="Edit" SelectTypeColDefault="Extended" AllowUpdateDefault="Yes">
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
									BorderColor="Turquoise" BorderStyle="Solid" BackColor="Turquoise" Height="489px"></FrameStyle>
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
								<RowStyleDefault BorderWidth="1px" Font-Size="10pt" Font-Names="verdana" BorderColor="Gray" BorderStyle="Solid" HorizontalAlign="Left" ForeColor="Black" BackColor="White">
									<Padding Left="3px" Top="2px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
								<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
							</DisplayLayout>
						</igtbl:ultrawebgrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 990px">
                        <asp:button id="btnSubmit" runat="server" Font-Bold="True" Width="125px" Text="FinalizeCloseOut" Visible="False"></asp:button>
                        <INPUT id="btnInv" style="FONT-WEIGHT: bold; WIDTH: 102px; HEIGHT: 24px" onclick="launchInvoice()" tabIndex="2" type="button" value="Display Invoice">
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
