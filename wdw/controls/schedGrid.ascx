<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="schedGrid.ascx.vb" Inherits="wdw.schedGrid" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<script language="javascript">
//This jscript function will clear any selections that have been made in any of the grids
function Reset() {
	igtbl_clearSelectionAll("SchedGrid1UWGDates");
	igtbl_clearSelectionAll("SchedGrid1UWGSched");
	
	//the following three grids might not have anything in them so they must be checked for that prior to clearing		
	var cell = igtbl_getActiveCell("ClientSearch1UWGClient")
	var row = igtbl_getActiveRow("ClientSearch1UWGClient")
	
	if (cell == null && row == null) {}
	else {
		igtbl_clearSelectionAll("ClientSearch1UWGClient");	
	}
	
	var cell = igtbl_getActiveCell("UWGNeverSched")
	var row = igtbl_getActiveRow("UWGNeverSched")
	
	if (cell == null && row == null) {}
	else {
		igtbl_clearSelectionAll("UWGNeverSched");	
	}
	
	var cell = igtbl_getActiveCell("UWGPriorSched")
	var row = igtbl_getActiveRow("UWGPriorSched")
	
	if (cell == null && row == null) {}
	else {
		igtbl_clearSelectionAll("UWGPriorSched");		
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
//this function will actually launch the subcontractor window
function launchSubcontractor(nick_Name) {
	//doubleclicked on a row with no job
	if (nick_Name == ""){
		return true;
	}
	
	//open job window
	subcontractor_window=window.open('/Subcontractor.aspx?From_Parent=2&nick_Name='+ nick_Name,null,'status=no,tollbar=no,menubar=no,height=990,width=990,left=0,top=23');
	if (window.subcontractor_window) {
		subcontractor_window.focus();
	}
}
//this jscript function opens windows based on what was double-clicked
function DoubleClick(gridName, itemName) { 
	var row = igtbl_getRowById(itemName); 
	if (row != null){
	
		var cell = igtbl_getCellById(itemName);
		var columnName = cell.Column.Key; 
		
		//double-clicked subcontractor
		//if (columnName == "nick_Name") { 
		
		//	var nick_Name = row.getCellFromKey("nick_Name").getValue();
		//	launchSubcontractor(nick_Name);
		//}
		
		//figure out which job they selected a invoke a function to launch the job window
		if (columnName == "suStartDate" || columnName == "suSchdAmt" || columnName == "suLastName" || columnName == "suZipCode") { 
		
			var job_id = row.getCellFromKey("suJob_Id").getValue();
			launchJob(job_id);
		}
		if (columnName == "moStartDate" || columnName == "moSchdAmt" || columnName == "moLastName" || columnName == "moZipCode") { 
		
			var job_id = row.getCellFromKey("moJob_Id").getValue();
			launchJob(job_id);
		}
			
		if (columnName == "tuStartDate" || columnName == "tuSchdAmt" || columnName == "tuLastName" || columnName == "tuZipCode") { 
		
			var job_id = row.getCellFromKey("tuJob_Id").getValue();
			launchJob(job_id);
		}
		if (columnName == "weStartDate" || columnName == "weSchdAmt" || columnName == "weLastName" || columnName == "weZipCode") { 
		
			var job_id = row.getCellFromKey("weJob_Id").getValue();
			launchJob(job_id);
		}
		if (columnName == "thStartDate" || columnName == "thSchdAmt" || columnName == "thLastName" || columnName == "thZipCode") { 
		
			var job_id = row.getCellFromKey("thJob_Id").getValue();
			launchJob(job_id);
		}
		if (columnName == "frStartDate" || columnName == "frSchdAmt" || columnName == "frLastName" || columnName == "frZipCode") { 
		
			var job_id = row.getCellFromKey("frJob_Id").getValue();
			launchJob(job_id);
		}
		if (columnName == "saStartDate" || columnName == "saSchdAmt" || columnName == "saLastName" || columnName == "saZipCode") { 
		
			var job_id = row.getCellFromKey("saJob_Id").getValue();
			launchJob(job_id);
		}
		
	} 
}

</script>
<DIV style="WIDTH: 141.07%; POSITION: relative; HEIGHT: 370px" ms_positioning="GridLayout">
	<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 1003px; POSITION: absolute; TOP: 1px; HEIGHT: 33px"
		borderColor="#000033" cellSpacing="1" cellPadding="1" width="1003" bgColor="turquoise"
		border="1">
		<TR>
			<TD style="HEIGHT: 10px" bgColor="#00ffff">
                <asp:dropdownlist id="lstArea" AutoPostBack="True" runat="server" Width="199px"></asp:dropdownlist><asp:button id="btnPrevMo" runat="server" Width="72px" Text="PrevMo"></asp:button><asp:button id="btnPrevWeek" runat="server" Width="72px" Text="PrevWk"></asp:button><asp:button id="btnNextWeek" runat="server" Width="72px" Text="NextWk"></asp:button><asp:button id="btnNextMo" runat="server" Width="72" Text="NextMo"></asp:button><asp:button id="btnToday" runat="server" Width="54px" Text="Today"></asp:button><asp:label id="lblTime" runat="server">Time</asp:label><asp:textbox id="txtTime" runat="server" Width="42px" DESIGNTIMEDRAGDROP="268"></asp:textbox><asp:button id="btnNewJob" runat="server" Text="New"></asp:button><asp:button id="btnSchedJob" runat="server" Text="Re-Sched"></asp:button><asp:button id="btnUnSchdJob" runat="server" Text="Un-Sched"></asp:button><INPUT id="btnReset" onclick="Reset()" type="button" value="Reset">
                <asp:textbox id="txtBeginDate" runat="server" Width="48px" Visible="True"></asp:textbox>
				<asp:TextBox ClientIDMode="Static" id="txtHiddenNewJobId" Width="42px" runat="server" ></asp:TextBox></TD>
		</TR>
	</TABLE>
	<igtbl:ultrawebgrid id="UWGDates" style="Z-INDEX: 102; LEFT: 45px; POSITION: absolute; TOP: 35px" runat="server"
		Width="932px" Height="23px">
		<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" ColHeadersVisibleDefault="No"
			RowHeightDefault="20px" Version="2.00" ScrollBar="Never" SelectTypeCellDefault="Single" BorderCollapseDefault="Separate"
			RowSelectorsDefault="No" Name="xctl0UWGDates" TableLayout="Fixed">
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
			<FrameStyle Width="932px" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="DarkMagenta"
				BorderStyle="Solid" Height="23px">
				<BorderDetails ColorRight="Purple" ColorLeft="Purple"></BorderDetails>
			</FrameStyle>
			<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
				<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
			</FooterStyleDefault>
			<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
			<RowStyleDefault BorderWidth="1px" BorderColor="Gray" BorderStyle="Solid" BackColor="#CFCFCF">
				<Padding Left="3px"></Padding>
				<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
			</RowStyleDefault>
			<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
		</DisplayLayout>
		<Rows>
			<igtbl:UltraGridRow Height="">
				<Cells>
					<igtbl:UltraGridCell Text="Sunday"></igtbl:UltraGridCell>
					<igtbl:UltraGridCell Text="Monday"></igtbl:UltraGridCell>
					<igtbl:UltraGridCell Text="Tuesday"></igtbl:UltraGridCell>
					<igtbl:UltraGridCell Text="Wednesday"></igtbl:UltraGridCell>
					<igtbl:UltraGridCell Text="Thursday"></igtbl:UltraGridCell>
					<igtbl:UltraGridCell Text="Friday"></igtbl:UltraGridCell>
					<igtbl:UltraGridCell Text="Saturday"></igtbl:UltraGridCell>
				</Cells>
			</igtbl:UltraGridRow>
		</Rows>
		<Bands>
			<igtbl:UltraGridBand>
				<Columns>
					<igtbl:UltraGridColumn Key="lblSunday" Width="133px" BaseColumnName="lblSunday"></igtbl:UltraGridColumn>
					<igtbl:UltraGridColumn Key="lblMonday" Width="133px" BaseColumnName="lblMonday"></igtbl:UltraGridColumn>
					<igtbl:UltraGridColumn Key="lblTuesday" Width="133px" BaseColumnName="lblTuesday"></igtbl:UltraGridColumn>
					<igtbl:UltraGridColumn Key="lblWednesday" Width="133px" BaseColumnName="lblWednesday"></igtbl:UltraGridColumn>
					<igtbl:UltraGridColumn Key="lblThursday" Width="133px" BaseColumnName="lblThursday"></igtbl:UltraGridColumn>
					<igtbl:UltraGridColumn Key="lblFriday" Width="133px" BaseColumnName="lblFriday"></igtbl:UltraGridColumn>
					<igtbl:UltraGridColumn Key="lblSaturday" Width="133px" BaseColumnName="lblSaturday"></igtbl:UltraGridColumn>
				</Columns>
			</igtbl:UltraGridBand>
		</Bands>
	</igtbl:ultrawebgrid><igtbl:ultrawebgrid id="UWGSched" style="Z-INDEX: 103; LEFT: 2px; POSITION: absolute; TOP: 58px" runat="server"
		Width="1000px" Height="310px">
		<Bands>
			<igtbl:UltraGridBand></igtbl:UltraGridBand>
		</Bands>
		<DisplayLayout ColWidthDefault="18px" JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js"
			ColHeadersVisibleDefault="No" RowHeightDefault="20px" Version="2.00" GridLinesDefault="Vertical"
			SelectTypeRowDefault="Single" ScrollBar="Always" SelectTypeCellDefault="Single" NullTextDefault=" "
			IndentationDefault="0" BorderCollapseDefault="Separate" RowSelectorsDefault="No" Name="xctl0UWGSched"
			TableLayout="Fixed">
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
			<HeaderStyleDefault BorderColor="Black" BorderStyle="Solid" ForeColor="White" BackColor="LightGray">
				<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
			</HeaderStyleDefault>
			<GroupByRowStyleDefault BorderWidth="1px" BorderColor="Black" BorderStyle="Solid" ForeColor="White" BackColor="#654678"></GroupByRowStyleDefault>
			<FrameStyle Width="1000px" Cursor="Default" BorderWidth="1px" Font-Size="8pt" Font-Names="Verdana"
				BorderColor="Aqua" BorderStyle="Solid" BackColor="Aqua" Height="310px"></FrameStyle>
			<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
				<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
			</FooterStyleDefault>
			<ClientSideEvents DblClickHandler="DoubleClick"></ClientSideEvents>
			<GroupByBox>
				<Style BackColor="#AE9EB8">
				</Style>
				<BandLabelStyle ForeColor="White" BackColor="#9972AD"></BandLabelStyle>
			</GroupByBox>
			<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
			<SelectedRowStyleDefault BackColor="#CAD6E0"></SelectedRowStyleDefault>
			<RowStyleDefault BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Gray" BorderStyle="Solid"
				ForeColor="Black" BackColor="Window">
				<Padding Left="3px"></Padding>
				<BorderDetails ColorTop="Gray" WidthLeft="0px" WidthTop="0px" ColorLeft="Gray"></BorderDetails>
			</RowStyleDefault>
			<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
		</DisplayLayout>
	</igtbl:ultrawebgrid></DIV>
