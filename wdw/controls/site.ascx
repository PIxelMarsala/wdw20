<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="site.ascx.vb" Inherits="wdw.site" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<script language="javascript">
//This function does initial cursor positioning
function onload()
{
	document.all("btnSiteAddressID").focus();
	//document.all("Site1_pnlMore").style.visibility = 'hidden';
}
//This toggles the visibility of chg info
//function chgVisibility()
//{
//	if (document.all("Site1_pnlMore").style.visibility == 'hidden') {
//		document.all("Site1_pnlMore").style.visibility = 'visible';
//	}
	
//	else {
//		document.all("Site1_pnlMore").style.visibility = 'hidden';
//	}
//}
//This function will simulate a click of the search button if Enter is hit
function document.onkeydown() {
	 if ( event.keyCode == 13 ) {
		Form1.Site1_btnSave.click();
		event.returnValue=false;
	}
}
//This function clears the client search criteria fields
function clearsearch()
{
	document.all.Site1_txtSrchSiteID.value = "";
	document.all.Site1_txtSrchSiteAddr.value = ""; 
	document.all.Site1_txtSrchOccClient.value = ""; 
	document.all.Site1_txtSrchBillClient.value = "" ; 
}
//this function will actually launch the address window if the Site Address button is clicked on the page
function launchAddress() {
		
	//open address window
	address_window=window.open('/address.aspx?From_Parent=1&Address_ID='+ document.all.Site1_txtSiteAddressID.value,'_blank','height=400,width=1000,left=0,top=23,status=no,tollbar=no,menubar=no');
	if (window.address_window) {
		address_window.focus();
	}
}
//this function will actually launch the client window if the Occ Client button is clicked on the page
function launchOClient() {
		
	//open address window
	oclient_window=window.open('/client.aspx?From_Parent=1&Client_ID='+ document.all.Site1_txtOccClientID.value,'_blank','status=no,tollbar=no,menubar=no,height=550,width=1000,left=0,top=23');
	if (window.oclient_window) {
		oclient_window.focus();
	}
}
//this function will actually launch the client window if the Bill Client button is clicked on the page
function launchBClient() {
		
	//open address window
	bclient_window=window.open('/client.aspx?From_Parent=2&Client_ID='+ document.all.Site1_txtBillClientID.value,'_blank','status=no,tollbar=no,menubar=no,height=550,width=1000,left=0,top=23');
	if (window.bclient_window) {
		bclient_window.focus();
	}
}
//this sets the local addressid
function setAddress(addressId, addr1, city, state, zip) {
	document.all.Site1_txtSiteAddressID.value = addressId;
	document.all.Site1_txtSiteAddr1.value = addr1;
	document.all.Site1_txtCity.value = city;
	document.all.Site1_txtState.value = state;
	document.all.Site1_txtZipCode.value = zip;
}
//this sets the local Occ Client
function setOClient(clientId, fname, lname, pphone, pphonet, aphone, aphonet, o1phone, o1phonet, o2phone, o2phonet, contact) {
	document.all.Site1_txtOccClientID.value = clientId;
	document.all.Site1_txtOccClientFirst.value = fname;
	document.all.Site1_txtOccClientLast.value = lname;
}
//this sets the local Bill Client
function setBClient(clientId, fname, lname, pphone, pphonet, aphone, aphonet, o1phone, o1phonet, o2phone, o2phonet, contact) {
	document.all.Site1_txtBillClientID.value = clientId;
	document.all.Site1_txtBillClientFirst.value = fname;
	document.all.Site1_txtBillClientLast.value = lname;
}
//this function will set the list box value
function setList(item, selectList) {		
	for(i = 0; i < selectList.options.length; i++) {
		if (selectList.options[i].value == item) {
			selectList.options[i].selected = true;
			break;
		}
	}
}
//this jscript function responds to the Site grid click event and populates the edit fields with data
function ClickSite(gridName, itemName) { 
	var row = igtbl_getRowById(itemName);
	var tempID 
	if (row != null){
	
		document.all.Site1_txtSiteID.value = row.getCellFromKey("Site_ID").getValue();
		document.all.Site1_txtNoStories.value = row.getCellFromKey("No_Stories").getValue(); 
		document.all.Site1_txtNotes.value = row.getCellFromKey("Notes").getValue();
		//set the Source Type list box
		setList( row.getCellFromKey("Source").getValue(), document.all.Site1_lstSource)
						
		if (row.getCellFromKey("Active").getValue() == "1") {
			document.all.Site1_chkActive.checked = true;
		}
		else{
			document.all.Site1_chkActive.checked = false;
		}
		
		if (row.getCellFromKey("Note_Type").getValue() == "1") {
			document.all.Site1_chkNoteType.checked = true;
		}
		else{
			document.all.Site1_chkNoteType.checked = false;
		}
		
		tempID = row.getCellFromKey("SiteAddress_ID").getValue();
		if (isNaN(tempID) || tempID == null || tempID == 0) {
			document.all.Site1_txtSiteAddressID.value = "";
			document.all.Site1_txtCity.value = "";
			document.all.Site1_txtState.value = "";
			document.all.Site1_txtZipCode.value = "";
			document.all.Site1_txtSiteAddr1.value = "";
		}
		else {
			document.all.Site1_txtSiteAddressID.value = tempID;
			document.all.Site1_txtSiteAddr1.value = row.getCellFromKey("Address1").getValue(); 
			document.all.Site1_txtCity.value = row.getCellFromKey("City").getValue(); 
			document.all.Site1_txtState.value = row.getCellFromKey("State").getValue(); 
			document.all.Site1_txtZipCode.value = row.getCellFromKey("ZipCode").getValue();  
		}
		
		tempID = row.getCellFromKey("OccClient_ID").getValue();
		if (isNaN(tempID) || tempID == null  || tempID == 0) {
			document.all.Site1_txtOccClientID.value = "";
			document.all.Site1_txtOccClientFirst.value = "";
			document.all.Site1_txtOccClientLast.value = "";
		}
		else {
			document.all.Site1_txtOccClientID.value = tempID;
			document.all.Site1_txtOccClientFirst.value = row.getCellFromKey("Occ_First").getValue();  
			document.all.Site1_txtOccClientLast.value = row.getCellFromKey("Occ_Last").getValue();
		}
		
		tempID = row.getCellFromKey("BillClient_ID").getValue();
		if (isNaN(tempID) || tempID == null  || tempID == 0) {
			document.all.Site1_txtBillClientID.value = "";
			document.all.Site1_txtBillClientFirst.value = "";
			document.all.Site1_txtBillClientLast.value = "";
		}
		else {
			document.all.Site1_txtBillClientID.value = tempID; 
			document.all.Site1_txtBillClientFirst.value = row.getCellFromKey("Bill_First").getValue();
			document.all.Site1_txtBillClientLast.value = row.getCellFromKey("Bill_Last").getValue(); 
		}
		
		document.all.Site1_txtCreateUser.value = row.getCellFromKey("Create_User").getValue();
		document.all.Site1_txtModifiedUser.value = row.getCellFromKey("Modified_User").getValue(); 
		document.all.Site1_txtCreateDate.value = row.getCellFromKey("Create_Date").getValue(); 
		document.all.Site1_txtModifiedDate.value = row.getCellFromKey("Modified_Date").getValue(); 
	} 
}
</script>
<TABLE id="Table1" style="WIDTH: 1012px; HEIGHT: 518px" cellSpacing="0" cellPadding="0"
	width="1012" bgColor="#6699cc" border="0">
	<TR>
		<TD style="WIDTH: 1011px"><asp:label id="lblErrorMsg" Font-Size="Medium" Font-Names="Verdana" ForeColor="Red" Width="555px"
				runat="server">Error Message</asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 1011px; HEIGHT: 484px">
			<TABLE id="Table2" style="WIDTH: 1011px; HEIGHT: 126px" cellSpacing="1" cellPadding="1"
				width="1011" bgColor="#99cccc" border="1">
				<TR>
					<TD style="WIDTH: 318px">
						<DIV style="WIDTH: 316px; POSITION: relative; HEIGHT: 120px" ms_positioning="GridLayout"><asp:label id="Label10" style="Z-INDEX: 101; LEFT: 3px; POSITION: absolute; TOP: 8px" Font-Size="X-Small"
								Font-Names="Verdana" ForeColor="Navy" runat="server">Site Addr</asp:label><asp:label id="Label11" style="Z-INDEX: 102; LEFT: 3px; POSITION: absolute; TOP: 33px" Font-Size="X-Small"
								Font-Names="Verdana" ForeColor="Navy" runat="server">Site Id</asp:label><asp:label id="Label12" style="Z-INDEX: 103; LEFT: 3px; POSITION: absolute; TOP: 56px" Font-Size="X-Small"
								Font-Names="Verdana" ForeColor="Navy" runat="server">Occ Client</asp:label><asp:label id="Label14" style="Z-INDEX: 105; LEFT: 3px; POSITION: absolute; TOP: 80px" Font-Size="X-Small"
								Font-Names="Verdana" ForeColor="Navy" runat="server">Bill Client</asp:label><asp:textbox id="txtSrchSiteAddr" style="Z-INDEX: 107; LEFT: 75px; POSITION: absolute; TOP: 4px"
								Font-Size="X-Small" Font-Names="Verdana" Width="229px" runat="server" tabIndex="9"></asp:textbox><asp:textbox id="txtSrchSiteID" style="Z-INDEX: 108; LEFT: 75px; POSITION: absolute; TOP: 28px"
								Font-Size="X-Small" Font-Names="Verdana" Width="61px" runat="server" tabIndex="10"></asp:textbox><asp:textbox id="txtSrchOccClient" style="Z-INDEX: 109; LEFT: 75px; POSITION: absolute; TOP: 52px"
								Font-Size="X-Small" Font-Names="Verdana" Width="118px" runat="server" tabIndex="11"></asp:textbox><asp:textbox id="txtSrchBillClient" style="Z-INDEX: 111; LEFT: 75px; POSITION: absolute; TOP: 77px"
								Font-Size="X-Small" Font-Names="Verdana" Width="118px" runat="server" tabIndex="12"></asp:textbox><asp:button id="btnSearch" style="Z-INDEX: 113; LEFT: 242px; POSITION: absolute; TOP: 30px"
								Width="62" runat="server" Text="Search" Height="24" tabIndex="-1" accessKey="h"></asp:button><asp:button id="btnNew" style="Z-INDEX: 114; LEFT: 242px; POSITION: absolute; TOP: 55px" Width="62"
								runat="server" Text="New" Height="24" tabIndex="-1" accessKey="n"></asp:button><INPUT style="Z-INDEX: 115; LEFT: 242px; WIDTH: 62px; POSITION: absolute; TOP: 81px; HEIGHT: 24px"
								accessKey="r" onclick="clearsearch()" type="button" value="Clear" tabIndex="-1" id="btnClear"></DIV>
					</TD>
					<TD><igtbl:ultrawebgrid id="UWGSite" Width="667px" runat="server" Height="141px">
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" RowHeightDefault="20px"
								Version="2.00" NullTextDefault=" " HeaderClickActionDefault="SortSingle" BorderCollapseDefault="Separate"
								Name="xctl0UWGSite">
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
								<FrameStyle Width="667px" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderStyle="Solid"
									BackColor="White" Height="141px"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<ClientSideEvents CellClickHandler="ClickSite"></ClientSideEvents>
								<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
								<RowAlternateStyleDefault BackColor="Gainsboro"></RowAlternateStyleDefault>
								<RowStyleDefault BorderWidth="1px" BorderColor="Gray" BorderStyle="Solid">
									<Padding Left="3px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
								<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
							</DisplayLayout>
						</igtbl:ultrawebgrid></TD>
				</TR>
			</TABLE>
			<DIV style="WIDTH: 1010px; POSITION: relative; HEIGHT: 324px" ms_positioning="GridLayout"><INPUT style="Z-INDEX: 101; LEFT: 8px; WIDTH: 103px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 64px; HEIGHT: 24px"
					onclick="launchOClient()" type="button" value="Occ Client" tabIndex="2" id="btnOccClient">
				<INPUT style="Z-INDEX: 102; LEFT: 9px; WIDTH: 103px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 94px; HEIGHT: 24px"
					onclick="launchBClient()" type="button" value="Bill Client" tabIndex="3" id="btnBillClient">
				<asp:textbox id="txtOccClientID" style="Z-INDEX: 103; LEFT: 118px; POSITION: absolute; TOP: 65px"
					Font-Size="X-Small" Font-Names="Verdana" Width="88px" runat="server" tabIndex="-1"></asp:textbox><asp:textbox id="txtBillClientID" style="Z-INDEX: 104; LEFT: 118px; POSITION: absolute; TOP: 96px"
					Font-Size="X-Small" Font-Names="Verdana" Width="88px" runat="server" tabIndex="-1"></asp:textbox><INPUT style="Z-INDEX: 105; LEFT: 8px; WIDTH: 103px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 13px; HEIGHT: 24px"
					onclick="launchAddress()" type="button" value="Site Address" tabIndex="1" id="btnSiteAddressID">
				<asp:textbox id="txtSiteAddressID" style="Z-INDEX: 106; LEFT: 118px; POSITION: absolute; TOP: 14px"
					Font-Size="X-Small" Font-Names="Verdana" Width="88" runat="server" tabIndex="-1"></asp:textbox><asp:checkbox id="chkActive" style="Z-INDEX: 107; LEFT: 381px; POSITION: absolute; TOP: 137px"
					Font-Size="X-Small" Font-Names="Verdana" ForeColor="Navy" runat="server" Text="Active" tabIndex="-1"></asp:checkbox><asp:label id="Label2" style="Z-INDEX: 108; LEFT: 243px; POSITION: absolute; TOP: 139px" Font-Size="X-Small"
					Font-Names="Verdana" ForeColor="Navy" Width="77px" runat="server">No Stories</asp:label><asp:textbox id="txtNoStories" style="Z-INDEX: 109; LEFT: 313px; POSITION: absolute; TOP: 135px"
					Font-Size="X-Small" Font-Names="Verdana" Width="39px" runat="server" tabIndex="4"></asp:textbox><asp:textbox id="txtNotes" style="Z-INDEX: 110; LEFT: 117px; POSITION: absolute; TOP: 165px"
					Font-Size="X-Small" Font-Names="Verdana" Width="609px" runat="server" Height="53px" TextMode="MultiLine" tabIndex="5" MaxLength="270"></asp:textbox><asp:label id="Label4" style="Z-INDEX: 111; LEFT: 16px; POSITION: absolute; TOP: 230px" Font-Size="X-Small"
					Font-Names="Verdana" ForeColor="Navy" Width="77px" runat="server">Source</asp:label><asp:label id="Label5" style="Z-INDEX: 112; LEFT: 15px; POSITION: absolute; TOP: 162px" Font-Size="X-Small"
					Font-Names="Verdana" ForeColor="Navy" runat="server">Note</asp:label><asp:button id="btnSelect" style="Z-INDEX: 113; LEFT: 753px; POSITION: absolute; TOP: 165px"
					Font-Size="X-Small" Font-Names="Verdana" Width="67px" runat="server" Text="Select" Height="24px" Visible="False" tabIndex="-1" accessKey="t"></asp:button><asp:button id="btnSave" style="Z-INDEX: 114; LEFT: 824px; POSITION: absolute; TOP: 165px" Font-Size="X-Small"
					Font-Names="Verdana" Width="67px" runat="server" Text="Save" Height="24px" accessKey="s" tabIndex="7"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 115; LEFT: 894px; POSITION: absolute; TOP: 165px"
					Font-Size="X-Small" Font-Names="Verdana" Width="67" runat="server" Text="Cancel" Height="24" accessKey="c" tabIndex="8"></asp:button><asp:checkbox id="chkNoteType" style="Z-INDEX: 116; LEFT: 114px; POSITION: absolute; TOP: 137px"
					Font-Size="X-Small" Font-Names="Verdana" ForeColor="Navy" runat="server" Text="Critical Note" tabIndex="-1"></asp:checkbox><asp:textbox id="txtSiteAddr1" style="Z-INDEX: 117; LEFT: 209px; POSITION: absolute; TOP: 14px"
					Font-Size="X-Small" Font-Names="Verdana" Width="345" runat="server" ReadOnly="True" BackColor="Gainsboro" tabIndex="-1"></asp:textbox><asp:textbox id="txtOccClientFirst" style="Z-INDEX: 118; LEFT: 209px; POSITION: absolute; TOP: 65px"
					Font-Size="X-Small" Font-Names="Verdana" Width="99px" runat="server" ReadOnly="True" BackColor="Gainsboro" tabIndex="-1"></asp:textbox><asp:textbox id="txtBillClientFirst" style="Z-INDEX: 119; LEFT: 210px; POSITION: absolute; TOP: 96px"
					Font-Size="X-Small" Font-Names="Verdana" Width="99px" runat="server" ReadOnly="True" BackColor="Gainsboro" tabIndex="-1"></asp:textbox><asp:textbox id="txtCity" style="Z-INDEX: 120; LEFT: 209px; POSITION: absolute; TOP: 39px" Font-Size="X-Small"
					Font-Names="Verdana" Width="188px" runat="server" ReadOnly="True" BackColor="Gainsboro" tabIndex="-1"></asp:textbox><asp:textbox id="txtState" style="Z-INDEX: 121; LEFT: 402px; POSITION: absolute; TOP: 39px" Font-Size="X-Small"
					Font-Names="Verdana" Width="36px" runat="server" ReadOnly="True" BackColor="Gainsboro" tabIndex="-1"></asp:textbox><asp:textbox id="txtZipCode" style="Z-INDEX: 122; LEFT: 442px; POSITION: absolute; TOP: 39px"
					Font-Size="X-Small" Font-Names="Verdana" Width="112px" runat="server" BackColor="Gainsboro" tabIndex="-1"></asp:textbox><asp:textbox id="txtOccClientLast" style="Z-INDEX: 123; LEFT: 312px; POSITION: absolute; TOP: 66px"
					Font-Size="X-Small" Font-Names="Verdana" Width="242px" runat="server" ReadOnly="True" BackColor="Gainsboro" tabIndex="-1"></asp:textbox><asp:textbox id="txtBillClientLast" style="Z-INDEX: 124; LEFT: 312px; POSITION: absolute; TOP: 96px"
					Font-Size="X-Small" Font-Names="Verdana" Width="243px" runat="server" ReadOnly="True" BackColor="Gainsboro" tabIndex="-1"></asp:textbox>
				<asp:DropDownList id="lstSource" style="Z-INDEX: 125; LEFT: 117px; POSITION: absolute; TOP: 227px"
					tabIndex="-1" runat="server" Width="245px" Font-Names="Verdana" Font-Size="X-Small"></asp:DropDownList>

				<asp:Panel id="pnlMore" style="Z-INDEX: 127; LEFT: 112px; POSITION: absolute; TOP: 254px" runat="server"
					Width="612px" Height="49px" Visible="true">
					<DIV style="WIDTH: 607px; POSITION: relative; HEIGHT: 46px" ms_positioning="GridLayout">
						<asp:label id="Label1" style="Z-INDEX: 138; LEFT: 476px; POSITION: absolute; TOP: 24px" runat="server"
							ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Site Id</asp:label>
						<asp:label id="Label6" style="Z-INDEX: 138; LEFT: 6px; POSITION: absolute; TOP: 7px" runat="server"
							ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Create User</asp:label>
						<asp:label id="Label7" style="Z-INDEX: 138; LEFT: 6px; POSITION: absolute; TOP: 23px" runat="server"
							ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Create Date</asp:label>
						<asp:label id="Label8" style="Z-INDEX: 138; LEFT: 234px; POSITION: absolute; TOP: 6px" runat="server"
							ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Modified User</asp:label>
						<asp:label id="Label9" style="Z-INDEX: 138; LEFT: 235px; POSITION: absolute; TOP: 25px" runat="server"
							ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Modified Date</asp:label>
						<asp:textbox id="txtCreateUser" style="Z-INDEX: 138; LEFT: 76px; POSITION: absolute; TOP: 2px"
							tabIndex="-1" runat="server" Width="83" Font-Names="Verdana" Font-Size="XX-Small" Height="17px"
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtCreateDate" style="Z-INDEX: 138; LEFT: 76px; POSITION: absolute; TOP: 20px"
							tabIndex="-1" runat="server" Width="157" Font-Names="Verdana" Font-Size="XX-Small" Height="17px"
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtModifiedUser" style="Z-INDEX: 138; LEFT: 316px; POSITION: absolute; TOP: 2px"
							tabIndex="-1" runat="server" Width="83px" Font-Names="Verdana" Font-Size="XX-Small" Height="17px"
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtModifiedDate" style="Z-INDEX: 138; LEFT: 316px; POSITION: absolute; TOP: 20px"
							tabIndex="-1" runat="server" Width="157px" Font-Names="Verdana" Font-Size="XX-Small" Height="17px"
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtSiteID" style="Z-INDEX: 138; LEFT: 516px; POSITION: absolute; TOP: 20px"
							tabIndex="-1" runat="server" Width="71px" Font-Names="Verdana" Font-Size="XX-Small" Height="17px"
							BackColor="Gainsboro"></asp:textbox></DIV>
				</asp:Panel>
				<asp:DropDownList id="lstCallBackMethod" style="Z-INDEX: 129; LEFT: 562px; POSITION: absolute; TOP: 228px"
					runat="server" Width="163px"></asp:DropDownList>
				<asp:Label id="lblCallbackMethod" style="Z-INDEX: 130; LEFT: 495px; POSITION: absolute; TOP: 231px"
					runat="server" Width="59px" ForeColor="Navy">Callback</asp:Label></DIV>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 1011px; HEIGHT: 3px"></TD>
	</TR>
</TABLE>
