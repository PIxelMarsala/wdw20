<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="address.ascx.vb" Inherits="address" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<script language="javascript">
//This function does initial cursor positioning
function onload() {
	document.all("Address1_txtAddr1").focus();
	//document.all("Address1_pnlMore").style.visibility = 'hidden';
	//document.all("Address1_lstHiddenZipCity").style.visibility = 'hidden';
}
//This function is invoked on the "onkeyup" event of the zip textbox
function lookupZip() {
	var zipStr = document.all.Address1_txtZip.value;
	if (zipStr.length == 5) {
		var city = findCity(zipStr);
		if (city != 0) {
			document.all.Address1_txtCity.value = city;
		}
	}
}
//this function will search for a city that matches the zip entered
function findCity(zip) {
	for(i = 0; i < document.all.Address1_lstHiddenZipCity.options.length; i++) {
		if (document.all.Address1_lstHiddenZipCity.options[i].value == zip) {
			return document.all.Address1_lstHiddenZipCity.options[i].text
		}
	}
	return 0
}
//This toggles the visibility of chg info
//function chgVisibility() {
//	if (document.all("Address1_pnlMore").style.visibility == 'hidden') {
//		document.all("Address1_pnlMore").style.visibility = 'visible';
//	}
	
//	else {
//		document.all("Address1_pnlMore").style.visibility = 'hidden';
//	}
//}
//This function moves the cursor to the 3rd position
function posZip()  {
	var rng = document.all.Address1_txtZip.createTextRange();
	rng.moveStart("character",2);
	rng.select();
}
//This function will simulate a click of the search button if Enter is hit
function document.onkeydown() {
	 if ( event.keyCode == 13 ) {
		Form1.Address1_btnSave.click();
		event.returnValue=false;
	}
}
//This function clears the client search criteria fields
function clearsearch()
{
	document.all.Address1_txtSrchAddr1.value = "";
	document.all.Address1_txtSrchAddr2.value = "";
	document.all.Address1_txtSrchCareOf.value = "";
	document.all.Address1_txtSrchAddrId.value = "";
}
//this jscript function responds to the Address grid click event and populates the edit fields with data
function ClickAddress(gridName, itemName) { 
	var row = igtbl_getRowById(itemName); 
	if (row != null){
	
		document.all.Address1_txtCareOf.value = row.getCellFromKey("CareOf").getValue();
		document.all.Address1_txtAddr1.value = row.getCellFromKey("Address1").getValue(); 
		document.all.Address1_txtAddr2.value = row.getCellFromKey("Address2").getValue(); 
		document.all.Address1_txtAddr3.value = row.getCellFromKey("Address3").getValue(); 
		document.all.Address1_txtCity.value = row.getCellFromKey("City").getValue(); 
		document.all.Address1_txtCounty.value = row.getCellFromKey("County").getValue(); 
		document.all.Address1_txtCountry.value = row.getCellFromKey("Country").getValue(); 
		document.all.Address1_txtZip.value = row.getCellFromKey("ZipCode").getValue(); 
		
		document.all.Address1_txtAddressID.value = row.getCellFromKey("Address_ID").getValue();
				
		document.all.Address1_txtCreateUser.value = row.getCellFromKey("Create_User").getValue();
		document.all.Address1_txtModifiedUser.value = row.getCellFromKey("Modified_User").getValue(); 
		document.all.Address1_txtCreateDate.value = row.getCellFromKey("Create_Date").getValue(); 
		document.all.Address1_txtModifiedDate.value = row.getCellFromKey("Modified_Date").getValue(); 
				
		if (row.getCellFromKey("Active").getValue() == "1") {
			document.all.Address1_chkActive.checked = true;
		}
		else{
			document.all.Address1_chkActive.checked = false;
		}
		
		//set the State list box
		setList( row.getCellFromKey("State").getValue(), document.all.Address1_lstState)
	} 
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

</script>
<P>
	<TABLE id="Table1" style="WIDTH: 1005px; HEIGHT: 360px" cellSpacing="0" cellPadding="0"
		width="1005" bgColor="#ff99cc" border="0">
		<TR>
			<TD style="WIDTH: 954px; HEIGHT: 192px"><asp:label id="lblErrorMsg" ForeColor="Red" Font-Size="Medium" Font-Names="Verdana" runat="server">Error Message</asp:label>
				<TABLE id="Table2" style="WIDTH: 1004px; HEIGHT: 115px" cellSpacing="0" cellPadding="0"
					width="1004" bgColor="#ffcccc" border="1">
					<TR>
						<TD style="WIDTH: 343px; HEIGHT: 113px">
							<DIV style="WIDTH: 99.77%; POSITION: relative; HEIGHT: 87.2%" ms_positioning="GridLayout">
                                <asp:label id="Label1" style="Z-INDEX: 101; LEFT: 4px; POSITION: absolute; TOP: 7px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Addr1</asp:label><asp:textbox id="txtSrchAddr1" style="Z-INDEX: 102; LEFT: 65px; POSITION: absolute; TOP: 4px" tabIndex="5" Font-Size="X-Small" Font-Names="Verdana" runat="server" MaxLength="50" Height="24" Width="171"></asp:textbox>
                                <asp:label id="Label2" style="Z-INDEX: 103; LEFT: 4px; POSITION: absolute; TOP: 31px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Addr2</asp:label><asp:textbox id="txtSrchAddr2" style="Z-INDEX: 104; LEFT: 65px; POSITION: absolute; TOP: 29px" tabIndex="6" runat="server" MaxLength="50" Height="24px" Width="171px"></asp:textbox>
                                <asp:label id="Label3" style="Z-INDEX: 105; LEFT: 4px; POSITION: absolute; TOP: 56px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">CareOf</asp:label><asp:textbox id="txtSrchCareOf" style="Z-INDEX: 106; LEFT: 65px; POSITION: absolute; TOP: 55px" tabIndex="7" Font-Size="X-Small" Font-Names="Verdana" runat="server" MaxLength="50" Height="24" Width="171"></asp:textbox>
                                <asp:label id="Label4" style="Z-INDEX: 107; LEFT: 4px; POSITION: absolute; TOP: 83px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Address Id</asp:label><asp:textbox id="txtSrchAddrId" style="Z-INDEX: 108; LEFT: 91px; POSITION: absolute; TOP: 82px" tabIndex="8" Font-Size="X-Small" Font-Names="Verdana" runat="server" Width="55px"></asp:textbox>
                                <asp:button id="btnSearch" style="Z-INDEX: 109; LEFT: 249px; POSITION: absolute; TOP: 8px" accessKey="h" tabIndex="-1" runat="server" Width="83px" Text="Search"></asp:button><asp:button id="btnNew" style="Z-INDEX: 110; LEFT: 249px; POSITION: absolute; TOP: 36px" accessKey="n" tabIndex="-1" runat="server" Width="82px" Text="New"></asp:button>
                                <INPUT id="btnClear" style="Z-INDEX: 111; LEFT: 249px; WIDTH: 81px; POSITION: absolute; TOP: 64px; HEIGHT: 24px" accessKey="r" onclick="clearsearch()" tabIndex="-1" type="button" value="Clear">
							</DIV>
						</TD>
						<TD style="HEIGHT: 113px"><igtbl:ultrawebgrid id="UWGAddress" runat="server" Height="124px" Width="656px">
								<Bands>
									<igtbl:UltraGridBand></igtbl:UltraGridBand>
								</Bands>
								<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" RowHeightDefault="20px"
									Version="2.00" NullTextDefault=" " HeaderClickActionDefault="SortSingle" BorderCollapseDefault="Separate"
									Name="xctl0UWGAddress">
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
									<FrameStyle Width="656px" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderStyle="Solid"
										BackColor="White" Height="124px"></FrameStyle>
									<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
										<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
									</FooterStyleDefault>
									<ClientSideEvents CellClickHandler="ClickAddress"></ClientSideEvents>
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
			</TD>
		</TR>
		<TR>
			<TD style="WIDTH: 954px; HEIGHT: 195px">
				<DIV style="WIDTH: 102.16%; POSITION: relative; HEIGHT: 101.34%" ms_positioning="GridLayout">
                        <asp:label id="Label5" style="Z-INDEX: 101; LEFT: 5px; POSITION: absolute; TOP: 5px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Addr1</asp:label>
                        <asp:label id="Label6" style="Z-INDEX: 102; LEFT: 5px; POSITION: absolute; TOP: 32px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Addr2</asp:label>
                        <asp:label id="Label7" style="Z-INDEX: 103; LEFT: 5px; POSITION: absolute; TOP: 59px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Addr3</asp:label>
                        <asp:label id="Label8" style="Z-INDEX: 104; LEFT: 4px; POSITION: absolute; TOP: 86px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">CareOf</asp:label>
                        <asp:textbox id="txtCareOf" style="Z-INDEX: 105; LEFT: 60px; POSITION: absolute; TOP: 84px" tabIndex="-1" runat="server" MaxLength="50" Height="26" Width="241px"></asp:textbox>
                        <asp:textbox id="txtAddr1" style="Z-INDEX: 106; LEFT: 61px; POSITION: absolute; TOP: 4px" tabIndex="1" runat="server" MaxLength="50" Height="26px" Width="240px"></asp:textbox>
                        <asp:textbox id="txtAddr2" style="Z-INDEX: 107; LEFT: 61px; POSITION: absolute; TOP: 30px" tabIndex="-1" runat="server" MaxLength="50" Height="26px" Width="240px"></asp:textbox>
                        <asp:textbox id="txtAddr3" style="Z-INDEX: 108; LEFT: 61px; POSITION: absolute; TOP: 57px" tabIndex="-1" runat="server" MaxLength="50" Height="26px" Width="241"></asp:textbox>
                        <asp:checkbox id="chkActive" style="Z-INDEX: 109; LEFT: 470px; POSITION: absolute; TOP: 3px" tabIndex="-1" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server" Text="Active"></asp:checkbox>
                        <asp:textbox id="txtCity" style="Z-INDEX: 110; LEFT: 370px; POSITION: absolute; TOP: 31px" tabIndex="-1" runat="server" Width="160px"></asp:textbox>
                        <asp:label id="Label9" style="Z-INDEX: 111; LEFT: 314px; POSITION: absolute; TOP: 34px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">City</asp:label>
                        <asp:label id="Label10" style="Z-INDEX: 112; LEFT: 314px; POSITION: absolute; TOP: 63px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">State</asp:label>
                        <asp:dropdownlist id="lstState" style="Z-INDEX: 113; LEFT: 370px; POSITION: absolute; TOP: 60px" tabIndex="-1" runat="server" Width="55px"></asp:dropdownlist>
                        <asp:label id="Label11" style="Z-INDEX: 114; LEFT: 437px; POSITION: absolute; TOP: 63px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Zip</asp:label>
                        <asp:textbox onkeyup="lookupZip()" id="txtZip" style="Z-INDEX: 115; LEFT: 465px; POSITION: absolute; TOP: 57px" onfocus="posZip()" tabIndex="2" runat="server" MaxLength="10" Width="65px"></asp:textbox>
                        <asp:label id="Label12" style="Z-INDEX: 116; LEFT: 497px; POSITION: absolute; TOP: 87px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">Country</asp:label>
                        <asp:textbox id="txtCountry" style="Z-INDEX: 117; LEFT: 552px; POSITION: absolute; TOP: 86px" tabIndex="-1" runat="server" Width="115px"></asp:textbox>
                        <asp:label id="Label13" style="Z-INDEX: 118; LEFT: 314px; POSITION: absolute; TOP: 85px" ForeColor="Navy" Font-Size="X-Small" Font-Names="Verdana" runat="server">County</asp:label>
                        <asp:textbox id="txtCounty" style="Z-INDEX: 119; LEFT: 370px; POSITION: absolute; TOP: 85px" tabIndex="-1" runat="server" MaxLength="50" Width="114px"></asp:textbox>
                        <asp:button id="btnSelect" style="Z-INDEX: 120; LEFT: 705px; POSITION: absolute; TOP: 83px" accessKey="t" Font-Size="X-Small" Font-Names="Verdana" runat="server" Height="24" Width="62" Text="Select" Visible="False"></asp:button>
                        <asp:button id="btnSave" style="Z-INDEX: 121; LEFT: 778px; POSITION: absolute; TOP: 83px" accessKey="s" tabIndex="3" Font-Size="X-Small" Font-Names="Verdana" runat="server" Height="24" Width="62" Text="Save"></asp:button>
                        <asp:button id="btnCancel" style="Z-INDEX: 122; LEFT: 851px; POSITION: absolute; TOP: 83px" accessKey="c" tabIndex="4" Font-Size="X-Small" Font-Names="Verdana" runat="server" Height="24px" Width="62px" Text="Cancel"></asp:button>
                        
					<asp:panel id="pnlMore" style="Z-INDEX: 124; LEFT: 88px; POSITION: absolute; TOP: 113px" runat="server"
						Height="61px" Width="624px">
						<DIV style="WIDTH: 621px; POSITION: relative; HEIGHT: 55px" ms_positioning="GridLayout">
							<asp:label id="Label14" style="Z-INDEX: 135; LEFT: 5px; POSITION: absolute; TOP: 12px" runat="server"
								Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Navy">Create User</asp:label>
							<asp:label id="Label15" style="Z-INDEX: 135; LEFT: 5px; POSITION: absolute; TOP: 30px" runat="server"
								Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Navy">Create Date</asp:label>
							<asp:TextBox id="txtCreateUser" style="Z-INDEX: 135; LEFT: 78px; POSITION: absolute; TOP: 7px"
								tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Width="88" Height="17px"
								BackColor="Gainsboro"></asp:TextBox>
							<asp:TextBox id="txtCreateDate" style="Z-INDEX: 135; LEFT: 78px; POSITION: absolute; TOP: 26px"
								tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Width="158" Height="17px"
								BackColor="Gainsboro"></asp:TextBox>
							<asp:label id="Label16" style="Z-INDEX: 135; LEFT: 239px; POSITION: absolute; TOP: 13px" runat="server"
								Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Navy">Modified User</asp:label>
							<asp:label id="Label17" style="Z-INDEX: 135; LEFT: 239px; POSITION: absolute; TOP: 30px" runat="server"
								Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Navy">Modified Date</asp:label>
							<asp:TextBox id="txtModifiedUser" style="Z-INDEX: 135; LEFT: 317px; POSITION: absolute; TOP: 7px"
								tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Width="88px" Height="17px"
								BackColor="Gainsboro"></asp:TextBox>
							<asp:TextBox id="txtModifiedDate" style="Z-INDEX: 135; LEFT: 317px; POSITION: absolute; TOP: 26px"
								tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Width="158px" Height="17px"
								BackColor="Gainsboro"></asp:TextBox>
							<asp:label id="Label18" style="Z-INDEX: 135; LEFT: 478px; POSITION: absolute; TOP: 29px" runat="server"
								Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Navy">Address Id</asp:label>
							<asp:TextBox id="txtAddressID" style="Z-INDEX: 135; LEFT: 540px; POSITION: absolute; TOP: 27px"
								tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Width="72px" Height="17px"
								BackColor="Gainsboro"></asp:TextBox></DIV>
					</asp:panel><asp:listbox id="lstHiddenZipCity" style="Z-INDEX: 125; LEFT: 549px; POSITION: absolute; TOP: 29px"
						tabIndex="-1" runat="server" Height="45px"></asp:listbox></DIV>
			</TD>
		</TR>
	</TABLE>
</P>
