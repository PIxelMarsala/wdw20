<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="clientSearch.ascx.vb" Inherits="wdw.clientSearch" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>

<script language="javascript">
//This function clears the clientschedule search criteria fields
function clearsearch()
{
	document.all.ClientSearch1_txtSiteAddr.value = "";
	document.all.ClientSearch1_txtBillAddr.value = "";
	document.all.ClientSearch1_txtExchange.value = "" ; 
	document.all.ClientSearch1_txtPhoneNumber.value = "" ; 
	document.all.ClientSearch1_txtAltExchange.value = "" ; 
	document.all.ClientSearch1_txtAltPhoneNumber.value = "" ; 
	document.all.ClientSearch1_txtClientID.value = "" ; 
	document.all.ClientSearch1_txtLastName.value = "" ;
	document.all.ClientSearch1_txtArea.value = "" ;
	document.all.ClientSearch1_txtAltArea.value = "" ;
}
//this function will actually launch the job window
function launchJSearch(job_id) {
	//doubleclicked on a row with no job
	if (job_id == 0){
		return true;
	}
	
	//open job window
	job_window=window.open('/Job.aspx?Job_ID='+ job_id,'_blank','status=no,tollbar=no,menubar=no,height=535,width=990,left=0,top=23');
	if (window.job_window) {
		job_window.focus();
	}
}
//this function will actually launch the client window
function launchClient(client_id) {
	//doubleclicked on a row with no client
	if (client_id == 0){
		return true;
	}
	
	//open client window
	client_window=window.open('/client.aspx?From_Parent=3&Client_ID='+ client_id,'_blank', 'status=no,tollbar=no,menubar=no,height=560,width=1000,left=0,top=23');
	if (window.client_window) {
		client_window.focus();
	}
}
//this function will actually launch the site window
function launchSite(site_id) {
	//doubleclicked on a row with no site
	if (site_id == 0){
		return true;
	}
	
	//open site window with a site
	site_window=window.open('/site.aspx?From_Parent=2&Site_ID='+ site_id,'_blank','status=no,tollbar=no,menubar=no,height=585,width=1000,left=0,top=23');
	if (window.site_window) {
		site_window.focus();
	}
}
//this function will actually launch the job window
function launchNewSite() {
		
	//open new site window
	site_window=window.open('/site.aspx?From_Parent=2&Site_ID=','_blank','status=no,tollbar=no,menubar=no,height=585,width=1000,left=0,top=23');
	if (window.site_window) {
		site_window.focus();
	}
}
//this jscript function opens a job window when a job is double-clicked
function DoubleClickSearch(gridName, itemName) { 
	var row = igtbl_getRowById(itemName); 
	if (row != null){
	
		var cell = igtbl_getCellById(itemName);
		var columnName = cell.Column.Key; 
		
		//figure out which column they selected a invoke a function to launch the appropriate window
		//a client row was selected
		if (columnName == "phone_Number" || columnName == "client_ID" || columnName == "last_Name" ) { 
		
			var client_id = row.getCellFromKey("client_ID").getValue();
			launchClient(client_id);
		}
		//a site row was selected
		if (columnName == "address1" || columnName == "zip_code" || columnName == "notes" || columnName == "CT") { 
		
			var site_id = row.getCellFromKey("site_ID").getValue();
			launchSite(site_id);
		}
		//a job row was selected	
		if (columnName == "start_Date" || columnName == "job_Description" || columnName == "bill_Amount" || columnName == "status" || columnName == "outsideOnly") { 
		
			var job_id = row.getCellFromKey("job_ID").getValue();
			launchJSearch(job_id);
		}		
	} 
}
//this block of code does auto tabbing between text fields
//use the prototype of
//
//  onkeypress="ctrlLength( numberofbytesinfield, 'nextcontroltogainfocus' );" 
//
//...in your code
//
function ctrlLength(nLength,cId) {
	if (event.srcElement.value.length == nLength)
	     document.all(cId).focus();
}
</script>
<DIV style="WIDTH: 96.44%; POSITION: relative; HEIGHT: 135px" ms_positioning="GridLayout">
	<!-- <TABLE id="Table3"  WIDTH: 1003px; POSITION: absolute; TOP: 1px; HEIGHT: 33px" borderColor="#000033" cellSpacing="1" cellPadding="1" width="1003" bgColor="turquoise" border="1"> -->
	<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 1px; WIDTH: 1004px; POSITION: static; TOP: 2px; HEIGHT: 112px"
		width="1004" border="1">
		<TR>
			<TD style="WIDTH: 379px" width="379" bgColor="#00ffff">
				<DIV style="WIDTH: 390px; POSITION: relative; HEIGHT: 109px" ms_positioning="GridLayout"><asp:label id="lblClientSearchError" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"
						Font-Bold="True" runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="389px" Visible="False" ForeColor="Red">This is an error condition</asp:label><asp:label id="Label1" style="Z-INDEX: 102; LEFT: 3px; POSITION: absolute; TOP: 19px" runat="server"
						Font-Size="X-Small" Font-Names="Verdana" Width="65px">Site Addr</asp:label><asp:textbox id="txtSiteAddr" style="Z-INDEX: 103; LEFT: 66px; POSITION: absolute; TOP: 15px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="246px"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 105; LEFT: 3px; POSITION: absolute; TOP: 41px" runat="server"
						Font-Size="X-Small" Font-Names="Verdana">Bill Addr</asp:label><asp:textbox id="txtBillAddr" style="Z-INDEX: 106; LEFT: 66px; POSITION: absolute; TOP: 37px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="246px"></asp:textbox><INPUT id="btnNewSite" style="Z-INDEX: 107; LEFT: 313px; WIDTH: 69px; POSITION: absolute; TOP: 38px; HEIGHT: 24px"
						accessKey="n" onclick="launchNewSite()" type="button" value="NewSite">
					<asp:label id="Label4" style="Z-INDEX: 108; LEFT: 3px; POSITION: absolute; TOP: 65px" runat="server"
						Font-Size="X-Small" Font-Names="Verdana" Width="40px">Phone</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'ClientSearch1_txtExchange');" id="txtArea" style="Z-INDEX: 109; LEFT: 66px; POSITION: absolute; TOP: 61px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="30px" MaxLength="3"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'ClientSearch1_txtPhoneNumber');" id="txtExchange" style="Z-INDEX: 110; LEFT: 98px; POSITION: absolute; TOP: 61px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="30" MaxLength="3" Columns="3"></asp:textbox><asp:textbox id="txtPhoneNumber" style="Z-INDEX: 111; LEFT: 129px; POSITION: absolute; TOP: 61px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="37px" MaxLength="4" Columns="4"></asp:textbox><asp:label id="Label5" style="Z-INDEX: 112; LEFT: 169px; POSITION: absolute; TOP: 65px" runat="server"
						Font-Size="X-Small" Font-Names="Verdana">Alt Ph</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'ClientSearch1_txtAltExchange');" id="txtAltArea" style="Z-INDEX: 113; LEFT: 212px; POSITION: absolute; TOP: 61px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="30px"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'ClientSearch1_txtAltPhoneNumber');" id="txtAltExchange"
						style="Z-INDEX: 114; LEFT: 243px; POSITION: absolute; TOP: 61px" runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="30" MaxLength="3" Columns="3"></asp:textbox><asp:textbox id="txtAltPhoneNumber" style="Z-INDEX: 115; LEFT: 274px; POSITION: absolute; TOP: 61px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="38px" MaxLength="4" Columns="4"></asp:textbox><asp:button id="btnSearch" style="Z-INDEX: 116; LEFT: 313px; POSITION: absolute; TOP: 14px"
						accessKey="h" runat="server" Font-Size="X-Small" Font-Names="Arial" Width="69px" Text="Search"></asp:button><asp:label id="Label3" style="Z-INDEX: 117; LEFT: 3px; POSITION: absolute; TOP: 89px" runat="server"
						Font-Size="X-Small" Font-Names="Verdana" Width="61px">Client ID</asp:label><asp:textbox id="txtClientID" style="Z-INDEX: 118; LEFT: 66px; POSITION: absolute; TOP: 85px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="101px"></asp:textbox><asp:label id="lblLast" style="Z-INDEX: 119; LEFT: 177px; POSITION: absolute; TOP: 89px" runat="server"
						Font-Size="X-Small" Font-Names="Verdana">Last</asp:label><asp:textbox id="txtLastName" style="Z-INDEX: 120; LEFT: 212px; POSITION: absolute; TOP: 85px"
						runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="144px"></asp:textbox><INPUT id="clearSearchCriteria" style="Z-INDEX: 121; LEFT: 313px; WIDTH: 68px; POSITION: absolute; TOP: 62px; HEIGHT: 24px"
						accessKey="r" onclick="clearsearch()" type="button" value="Clear"></DIV>
			</TD>
			<TD align="left" width="60%" bgColor="#00ffff"><igtbl:ultrawebgrid id="UWGClient" runat="server" Width="588px" Height="123px">
					<Bands>
						<igtbl:UltraGridBand></igtbl:UltraGridBand>
					</Bands>
					<DisplayLayout ColWidthDefault="200px" JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js"
						RowHeightDefault="20px" Version="2.00" ViewType="Hierarchical" SelectTypeRowDefault="Single"
						SelectTypeCellDefault="Single" NullTextDefault=" " BorderCollapseDefault="Separate" Name="xctl0UWGClient"
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
						<HeaderStyleDefault Font-Size="10pt" Font-Names="Verdana" BorderColor="Transparent" BorderStyle="Solid"
							ForeColor="Black" BackColor="LightGray">
							<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
						</HeaderStyleDefault>
						<FrameStyle Width="588px" Cursor="Default" BorderWidth="1px" Font-Size="8pt" Font-Names="Verdana"
							BorderColor="Aqua" BorderStyle="Solid" BackColor="Aqua" Height="123px"></FrameStyle>
						<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
							<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
						</FooterStyleDefault>
						<ClientSideEvents DblClickHandler="DoubleClickSearch"></ClientSideEvents>
						<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
						<SelectedRowStyleDefault BackColor="#CAD6E0"></SelectedRowStyleDefault>
						<RowAlternateStyleDefault BackColor="Gainsboro"></RowAlternateStyleDefault>
						<RowStyleDefault BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Gray" BorderStyle="Solid"
							BackColor="Window">
							<Padding Left="3px"></Padding>
							<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
						</RowStyleDefault>
						<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
					</DisplayLayout>
				</igtbl:ultrawebgrid></TD>
		</TR>
	</TABLE>
</DIV>
