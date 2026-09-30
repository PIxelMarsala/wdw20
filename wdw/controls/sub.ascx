<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="sub.ascx.vb" Inherits="wdw._sub" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<script language="javascript">
//This function does initial cursor positioning
function onload()
{
	document.all("Sub1_txtNickName").focus();
	//document.all("Sub1_pnlMore").style.visibility = 'hidden';
	document.all("Sub1_txtHiddenNickName").style.visibility = 'hidden';
	document.all("Sub1_chkHiddenActive").style.visibility = 'hidden';
	document.all("Sub1_btnRetrieveAreas").style.visibility = 'hidden';
}
//this function will actually launch the address window if the primary address button is clicked
function launchPrimaryAddress() {
		
	//open address window
	address_window=window.open('/address.aspx?From_Parent=2&Address_ID='+ document.all.Sub1_txtPrimaryAddressID.value,'_blank','height=365,width=1000,left=0,top=23,status=no,tollbar=no,menubar=no');
	if (window.address_window) {
		address_window.focus();
	}
}
//this function will actually launch the address window if the alternate address button is clicked
function launchAlternateAddress() {
		
	//open address window
	address_window=window.open('/address.aspx?From_Parent=3&Address_ID='+ document.all.Sub1_txtAlternateAddressID.value,'_blank','height=365,width=1000,left=0,top=23,status=no,tollbar=no,menubar=no');
	if (window.address_window) {
		address_window.focus();
	}
}
//this sets the local address information and is called by the address window when launched from here
function setAddress(addressId, addr1, city, state , zip) {

	document.all.Sub1_txtPrimaryAddressID.value = addressId;
	document.all.Sub1_txtPrimaryAddress.value = addr1 + " " + city + ", " + state + " " + zip;
}
//this sets the local address information and is called by the address window when launched from here
function setAlternateAddress(addressId, addr1, city, state , zip) {

	document.all.Sub1_txtAlternateAddressID.value = addressId;
	document.all.Sub1_txtAlternateAddress.value = addr1 + " " + city + ", " + state + " " + zip;
}
//This toggles the visibility of chg info
//function chgVisibility()
//{
//	if (document.all("Sub1_pnlMore").style.visibility == 'hidden') {
//		document.all("Sub1_pnlMore").style.visibility = 'visible';
//	}
//	else {
//		document.all("Sub1_pnlMore").style.visibility = 'hidden';
//	}
//}
//This function will simulate a click of the search button if Enter is hit
function document.onkeydown() {
	 if ( event.keyCode == 13 ) {
		all.Sub1_btnSave.click();
		event.returnValue=false;
	}
}
//This function clears the client search criteria fields
function clearsearch()
{
	document.all.Sub1_txtSrchLastName.value = "";
	document.all.Sub1_txtSrchNickName.value = ""; 
	document.all.Sub1_txtSrchPrmArea.value = "" ; 
	document.all.Sub1_txtSrchPrmExch.value = "" ; 
	document.all.Sub1_txtSrchPrmPhone.value = "" ; 
	document.all.Sub1_txtSrchAltArea.value = "" ; 
	document.all.Sub1_txtSrchAltExch.value = "" ; 
	document.all.Sub1_txtSrchAltNumber.value = "" ; 
	
}

//this jscript function responds to the Sub grid click event and populates the edit fields with data
function ClickSub(gridName, itemName) { 
	var row = igtbl_getRowById(itemName); 
	if (row != null){
	
		var primaryPhone = row.getCellFromKey("Phone_No").getValue(); 
		var altPhone = row.getCellFromKey("Alt_Phone").getValue(); 
						
		document.all.Sub1_txtFirstName.value = row.getCellFromKey("First_Name").getValue(); 
		document.all.Sub1_txtLastName.value = row.getCellFromKey("Last_Name").getValue(); 
		document.all.Sub1_txtNickName.value = row.getCellFromKey("Nick_Name").getValue(); 
		document.all.Sub1_txtHiddenNickName.value = row.getCellFromKey("Nick_Name").getValue(); 
		document.all.Sub1_txtCompanyName.value = row.getCellFromKey("Company_Name").getValue(); 
		document.all.Sub1_txtSubID.value = row.getCellFromKey("Sub_ID").getValue(); 
		document.all.Sub1_txtContactName.value = row.getCellFromKey("Contact_Name").getValue(); 
		document.all.Sub1_txtEMail.value = row.getCellFromKey("E_Mail").getValue();
		document.all.Sub1_txtTID.value = row.getCellFromKey("TID").getValue();
		document.all.Sub1_txtUBI.value = row.getCellFromKey("UBI").getValue();
		document.all.Sub1_txtDollarMaxAmount.value = row.getCellFromKey("dollarMaxAmount").getValue();
		document.all.Sub1_txtSpouseName.value = row.getCellFromKey("Spouse_Name").getValue();
		document.all.Sub1_txtNotes.value = row.getCellFromKey("Notes").getValue();
		document.all.Sub1_txtHeight.value = row.getCellFromKey("Height").getValue();
		
		
		var primaryAddrID = row.getCellFromKey("PrimaryAddress_ID").getValue()
		var alternateAddrID = row.getCellFromKey("AlternateAddress_ID").getValue()
		
		
		//NaN is the javascript "Not A Number" indicator to check for NULL values
		if (isNaN(primaryAddrID) || primaryAddrID == 0) {
			document.all.Sub1_txtPrimaryAddressID.value = "";
			document.all.Sub1_txtPrimaryAddress.value = "";
		}
		else {
			document.all.Sub1_txtPrimaryAddressID.value = primaryAddrID;
			document.all.Sub1_txtPrimaryAddress.value = row.getCellFromKey("Address1").getValue() + " " + row.getCellFromKey("City").getValue() + ", " + row.getCellFromKey("State").getValue() + " " + row.getCellFromKey("ZipCode").getValue()
		
		}
		
		//NaN is the javascript "Not A Number" indicator to check for NULL values
		if (isNaN(alternateAddrID) || alternateAddrID == 0) {
			document.all.Sub1_txtAlternateAddressID.value = "";
			document.all.Sub1_txtAlternateAddress.value = "";
		}
		else {
			document.all.Sub1_txtAlternateAddressID.value = alternateAddrID;
			document.all.Sub1_txtAlternateAddress.value = row.getCellFromKey("AAddress1").getValue() + " " + row.getCellFromKey("ACity").getValue() + ", " + row.getCellFromKey("AState").getValue() + " " + row.getCellFromKey("AZipCode").getValue()
		}
		
		document.all.Sub1_txtCreateUser.value = row.getCellFromKey("Create_User").getValue(); 
		document.all.Sub1_txtModifiedUser.value = row.getCellFromKey("Modified_User").getValue(); 
		document.all.Sub1_txtCreateDate.value = row.getCellFromKey("Create_Date").getValue(); 
		document.all.Sub1_txtModifiedDate.value = row.getCellFromKey("Modified_Date").getValue();
		 
			
		document.all.Sub1_txtPrimaryArea.value = primaryPhone.substring(0,3);
		document.all.Sub1_txtPrimaryExch.value = primaryPhone.substring(3,6);
		document.all.Sub1_txtPrimaryNumber.value = primaryPhone.substring(6,10);
		
		document.all.Sub1_txtAlternateArea.value = altPhone.substring(0,3);
		document.all.Sub1_txtAlternateExch.value = altPhone.substring(3,6);
		document.all.Sub1_txtAlternateNumber.value = altPhone.substring(6,10);
	
		if (row.getCellFromKey("Active").getValue() == "1") {
			document.all.Sub1_chkActive.checked = true;
			document.all.Sub1_chkHiddenActive.checked = true;
		}
		else{
			document.all.Sub1_chkActive.checked = false;
			document.all.Sub1_chkHiddenActive.checked = false;
		}
		
		if (row.getCellFromKey("Mon_AM").getValue() == "1") {
			document.all.Sub1_chkMonAM.checked = true;
		}
		else{
			document.all.Sub1_chkMonAM.checked = false;
		}
		
		if (row.getCellFromKey("Mon_PM").getValue() == "1") {
			document.all.Sub1_chkMonPM.checked = true;
		}
		else{
			document.all.Sub1_chkMonPM.checked = false;
		}
		
		if (row.getCellFromKey("Tues_AM").getValue() == "1") {
			document.all.Sub1_chkTueAM.checked = true;
		}
		else{
			document.all.Sub1_chkTueAM.checked = false;
		}
		
		if (row.getCellFromKey("Tues_PM").getValue() == "1") {
			document.all.Sub1_chkTuePM.checked = true;
		}
		else{
			document.all.Sub1_chkTuePM.checked = false;
		}
		
		if (row.getCellFromKey("Wed_AM").getValue() == "1") {
			document.all.Sub1_chkWedAM.checked = true;
		}
		else{
			document.all.Sub1_chkWedAM.checked = false;
		}
		
		if (row.getCellFromKey("Wed_PM").getValue() == "1") {
			document.all.Sub1_chkWedPM.checked = true;
		}
		else{
			document.all.Sub1_chkWedPM.checked = false;
		}
		
		if (row.getCellFromKey("Th_AM").getValue() == "1") {
			document.all.Sub1_chkThuAM.checked = true;
		}
		else{
			document.all.Sub1_chkThuAM.checked = false;
		}
		
		if (row.getCellFromKey("Th_PM").getValue() == "1") {
			document.all.Sub1_chkThuPM.checked = true;
		}
		else{
			document.all.Sub1_chkThuPM.checked = false;
		}
		
		if (row.getCellFromKey("Fri_AM").getValue() == "1") {
			document.all.Sub1_chkFriAM.checked = true;
		}
		else{
			document.all.Sub1_chkFriAM.checked = false;
		}
		
		if (row.getCellFromKey("Fri_PM").getValue() == "1") {
			document.all.Sub1_chkFriPM.checked = true;
		}
		else{
			document.all.Sub1_chkFriPM.checked = false;
		}
		
		if (row.getCellFromKey("Sat_AM").getValue() == "1") {
			document.all.Sub1_chkSatAM.checked = true;
		}
		else{
			document.all.Sub1_chkSatAM.checked = false;
		}
		
		if (row.getCellFromKey("Sat_PM").getValue() == "1") {
			document.all.Sub1_chkSatPM.checked = true;
		}
		else{
			document.all.Sub1_chkSatPM.checked = false;
		}
		
		if (row.getCellFromKey("Sun_AM").getValue() == "1") {
			document.all.Sub1_chkSunAM.checked = true;
		}
		else{
			document.all.Sub1_chkSunAM.checked = false;
		}
		
		if (row.getCellFromKey("Sun_PM").getValue() == "1") {
			document.all.Sub1_chkSunPM.checked = true;
		}
		else{
			document.all.Sub1_chkSunPM.checked = false;
		}
		
		if (row.getCellFromKey("Gutters").getValue() == "1") {
			document.all.Sub1_chkGutters.checked = true;
		}
		else{
			document.all.Sub1_chkGutters.checked = false;
		}
		
		if (row.getCellFromKey("PwrWash").getValue() == "1") {
			document.all.Sub1_chkPwrWash.checked = true;
		}
		else{
			document.all.Sub1_chkPwrWash.checked = false;
		}
		
		if (row.getCellFromKey("NewConst").getValue() == "1") {
			document.all.Sub1_chkNewConst.checked = true;
		}
		else{
			document.all.Sub1_chkNewConst.checked = false;
		}
		
	
				
		//set the Primary Phone Type list box
		setList( row.getCellFromKey("Phone_Type").getValue(), document.all.Sub1_lstPrmPhoneType)
		//set the Alternate Phone Type list box
		setList( row.getCellFromKey("Alt_Phone_Type").getValue(), document.all.Sub1_lstAltPhoneType)
		//set the Parent Sub Id
		setList( row.getCellFromKey("ParentSub_ID").getValue(), document.all.Sub1_lstParentSub)
		
		document.all.Sub1_btnRetrieveAreas.click()
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
//this sets the local address information and is called by the address window when launched from here
//function setAddress(addressId, addr1, city, state , zip) {
//	document.all.Sub1_txtBillingAddressID.value = addressId;
//	document.all.Sub1_txtAddr1.value = addr1;
//	document.all.Sub1_txtCity.value = city;
//	document.all.Sub1_txtState.value = state;
//	document.all.Sub1_txtZipCode.value = zip;
//}
</script>
<DIV style="WIDTH: 100%; HEIGHT: 60.96%; BACKGROUND-COLOR: #ffcc99" ms_positioning="FlowLayout">
	<DIV style="WIDTH: 952px; HEIGHT: 201px" ms_positioning="FlowLayout">
		<TABLE id="Table1" style="WIDTH: 974px; HEIGHT: 166px" cellSpacing="0" cellPadding="0" width="974" bgColor="moccasin" border="1">
			<TR>
				<TD style="WIDTH: 351px" bgColor="#ffcc99"><asp:label id="lblErrorMsg" runat="server" Width="323px" ForeColor="Red" Font-Names="Verdana" Font-Size="Medium" Height="6px">Error Message</asp:label></TD>
				<TD bgColor="#ffcc99"></TD>
			</TR>
			<TR>
				<TD style="WIDTH: 351px">
					<DIV style="WIDTH: 344px; POSITION: relative; HEIGHT: 122px" ms_positioning="GridLayout"><asp:label id="lbl" style="Z-INDEX: 101; LEFT: 5px; POSITION: absolute; TOP: 6px" runat="server"
							ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Nick Name</asp:label><asp:textbox id="txtSrchNickName" style="Z-INDEX: 102; LEFT: 77px; POSITION: absolute; TOP: 3px"
							tabIndex="-1" runat="server" Width="105px" Font-Names="Verdana" Font-Size="X-Small" MaxLength="50"></asp:textbox><asp:label id="Label1" style="Z-INDEX: 103; LEFT: 6px; POSITION: absolute; TOP: 33px" runat="server"
							ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Last Name</asp:label><asp:textbox id="txtSrchLastName" style="Z-INDEX: 104; LEFT: 76px; POSITION: absolute; TOP: 30px"
							tabIndex="-1" runat="server" Width="132px" Font-Names="Verdana" Font-Size="X-Small" MaxLength="50"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 105; LEFT: 5px; POSITION: absolute; TOP: 58px" runat="server"
							Width="88px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Primary Ph</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtSrchPrmExch');" id="txtSrchPrmArea" style="Z-INDEX: 106; LEFT: 75px; POSITION: absolute; TOP: 57px"
							tabIndex="-1" runat="server" Width="35px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtSrchPrmPhone');" id="txtSrchPrmExch" style="Z-INDEX: 107; LEFT: 112px; POSITION: absolute; TOP: 57px"
							tabIndex="-1" runat="server" Width="36px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtSrchPrmPhone" style="Z-INDEX: 108; LEFT: 149px; POSITION: absolute; TOP: 57px"
							tabIndex="-1" runat="server" Width="60px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:label id="Label3" style="Z-INDEX: 109; LEFT: 7px; POSITION: absolute; TOP: 86px" runat="server"
							Width="54px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Alt Ph</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtSrchAltExch');" id="txtSrchAltArea" style="Z-INDEX: 110; LEFT: 75px; POSITION: absolute; TOP: 82px"
							tabIndex="-1" runat="server" Width="35px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtSrchAltNumber');" id="txtSrchAltExch" style="Z-INDEX: 111; LEFT: 113px; POSITION: absolute; TOP: 82px"
							tabIndex="-1" runat="server" Width="35px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtSrchAltNumber" style="Z-INDEX: 112; LEFT: 149px; POSITION: absolute; TOP: 82px"
							tabIndex="-1" runat="server" Width="59px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:button id="btnSearch" style="Z-INDEX: 113; LEFT: 261px; POSITION: absolute; TOP: 25px"
							accessKey="h" tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="X-Small" Text="Search"></asp:button><asp:button id="btnNew" style="Z-INDEX: 114; LEFT: 261px; POSITION: absolute; TOP: 52px" accessKey="n"
							tabIndex="-1" runat="server" Width="69px" Font-Names="Verdana" Font-Size="X-Small" Text="New"></asp:button><INPUT id="btnClear" style="Z-INDEX: 115; LEFT: 261px; WIDTH: 69px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 78px; HEIGHT: 24px"
							accessKey="r" onclick="clearsearch()" tabIndex="-1" type="button" value="Clear"></DIV>
				</TD>
				<TD>
					<DIV style="WIDTH: 622px; POSITION: relative; HEIGHT: 125px" ms_positioning="GridLayout"><igtbl:ultrawebgrid id="UWGSub" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
							Width="621px" Height="125px">
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" RowHeightDefault="20px"
								Version="2.00" NullTextDefault=" " BorderCollapseDefault="Separate" Name="xctl0UWGSub">
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
								<FrameStyle Width="621px" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderStyle="Solid"
									BackColor="White" Height="125px"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<ClientSideEvents CellClickHandler="ClickSub"></ClientSideEvents>
								<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
								<RowStyleDefault BorderWidth="1px" BorderColor="Gray" BorderStyle="Solid">
									<Padding Left="3px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
								<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
							</DisplayLayout>
						</igtbl:ultrawebgrid></DIV>
				</TD>
			</TR>
		</TABLE>
	</DIV>
	<DIV style="WIDTH: 975px; POSITION: relative; HEIGHT: 375px" ms_positioning="GridLayout">
		<asp:panel id="pnlMore" style="Z-INDEX: 101; LEFT: 97px; POSITION: absolute; TOP: 307px" runat="server" Width="735px" Height="50px">
			<DIV style="WIDTH: 731px; POSITION: relative; HEIGHT: 49px" ms_positioning="GridLayout">
				<asp:TextBox id="txtSubID" style="Z-INDEX: 101; LEFT: 562px; POSITION: absolute; TOP: 28px" runat="server"
					Width="55px" Font-Size="XX-Small" BackColor="Gainsboro"></asp:TextBox>
				<asp:Label id="Label4" style="Z-INDEX: 102; LEFT: 515px; POSITION: absolute; TOP: 32px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Sub_ID</asp:Label>
				<asp:Label id="Label29" style="Z-INDEX: 103; LEFT: 7px; POSITION: absolute; TOP: 9px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Create User</asp:Label>
				<asp:Label id="Label30" style="Z-INDEX: 104; LEFT: 7px; POSITION: absolute; TOP: 32px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Create Date</asp:Label>
				<asp:Label id="Label31" style="Z-INDEX: 105; LEFT: 243px; POSITION: absolute; TOP: 9px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Modified User</asp:Label>
				<asp:Label id="Label32" style="Z-INDEX: 106; LEFT: 243px; POSITION: absolute; TOP: 32px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="XX-Small">Modified Date</asp:Label>
				<asp:TextBox id="txtCreateUser" style="Z-INDEX: 107; LEFT: 77px; POSITION: absolute; TOP: 5px"
					tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" BackColor="Gainsboro"></asp:TextBox>
				<asp:TextBox id="txtCreateDate" style="Z-INDEX: 108; LEFT: 78px; POSITION: absolute; TOP: 28px"
					tabIndex="-1" runat="server" Width="159px" Font-Names="Verdana" Font-Size="XX-Small" BackColor="Gainsboro"></asp:TextBox>
				<asp:TextBox id="txtModifiedUser" style="Z-INDEX: 109; LEFT: 324px; POSITION: absolute; TOP: 5px"
					tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="XX-Small" BackColor="Gainsboro"></asp:TextBox>
				<asp:TextBox id="txtModifiedDate" style="Z-INDEX: 110; LEFT: 324px; POSITION: absolute; TOP: 28px"
					tabIndex="-1" runat="server" Width="159px" Font-Names="Verdana" Font-Size="XX-Small" BackColor="Gainsboro"></asp:TextBox></DIV>
		</asp:panel>
		<asp:label id="Label5" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 4px" runat="server"
			Width="70px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">First Name</asp:label><asp:label id="Label6" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 31px" runat="server"
			Width="77px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Last Name</asp:label><asp:label id="Label7" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 55px" runat="server"
			Width="107px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Company Name</asp:label><asp:label id="Label8" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: -26px" runat="server"
			Width="76px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Nick Name</asp:label><asp:dropdownlist id="lstParentSub" style="Z-INDEX: 107; LEFT: 462px; POSITION: absolute; TOP: 52px"
			tabIndex="-1" runat="server" Width="95px" Font-Names="Verdana" Font-Size="X-Small"></asp:dropdownlist><asp:label id="Label9" style="Z-INDEX: 108; LEFT: 406px; POSITION: absolute; TOP: 54px" runat="server"
			Width="53px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Par Sub</asp:label><asp:label id="Label10" style="Z-INDEX: 109; LEFT: 12px; POSITION: absolute; TOP: 146px" runat="server"
			Width="96px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Primary Ph</asp:label><asp:label id="Label11" style="Z-INDEX: 110; LEFT: 12px; POSITION: absolute; TOP: 175px" runat="server"
			Width="67px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Alt Ph</asp:label><asp:textbox id="txtNickName" style="Z-INDEX: 111; LEFT: 111px; POSITION: absolute; TOP: -28px"
			tabIndex="10" runat="server" Width="131px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtFirstName" style="Z-INDEX: 112; LEFT: 111px; POSITION: absolute; TOP: 0px"
			tabIndex="20" runat="server" Width="131px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtLastName" style="Z-INDEX: 113; LEFT: 111px; POSITION: absolute; TOP: 27px"
			tabIndex="30" runat="server" Width="131px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtCompanyName" style="Z-INDEX: 114; LEFT: 111px; POSITION: absolute; TOP: 51px"
			tabIndex="40" runat="server" Width="131px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtPrimaryExch');" id="txtPrimaryArea" style="Z-INDEX: 115; LEFT: 115px; POSITION: absolute; TOP: 146px"
			tabIndex="50" runat="server" Width="36px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtPrimaryNumber');" id="txtPrimaryExch" style="Z-INDEX: 116; LEFT: 155px; POSITION: absolute; TOP: 146px"
			tabIndex="60" runat="server" Width="36px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtPrimaryNumber" style="Z-INDEX: 117; LEFT: 192px; POSITION: absolute; TOP: 146px"
			tabIndex="70" runat="server" Width="53px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtAlternateExch');" id="txtAlternateArea" style="Z-INDEX: 118; LEFT: 115px; POSITION: absolute; TOP: 175px"
			tabIndex="-1" runat="server" Width="37px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Sub1_txtAlternateNumber');" id="txtAlternateExch" style="Z-INDEX: 119; LEFT: 155px; POSITION: absolute; TOP: 175px"
			tabIndex="-1" runat="server" Width="36px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtAlternateNumber" style="Z-INDEX: 120; LEFT: 193px; POSITION: absolute; TOP: 175px"
			tabIndex="-1" runat="server" Width="54px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:dropdownlist id="lstPrmPhoneType" style="Z-INDEX: 121; LEFT: 251px; POSITION: absolute; TOP: 146px"
			tabIndex="-1" runat="server" Width="111px" Font-Names="Verdana" Font-Size="X-Small"></asp:dropdownlist><asp:dropdownlist id="lstAltPhoneType" style="Z-INDEX: 122; LEFT: 251px; POSITION: absolute; TOP: 175px"
			tabIndex="-1" runat="server" Width="110px" Font-Names="Verdana" Font-Size="X-Small"></asp:dropdownlist><asp:label id="Label12" style="Z-INDEX: 123; LEFT: 249px; POSITION: absolute; TOP: 4px" runat="server"
			Width="94px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small"> Cont</asp:label><asp:label id="Label13" style="Z-INDEX: 124; LEFT: 249px; POSITION: absolute; TOP: 31px" runat="server"
			Width="83px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">TID</asp:label><asp:label id="Label14" style="Z-INDEX: 125; LEFT: 249px; POSITION: absolute; TOP: 55px" runat="server"
			Width="96px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">UBI</asp:label><asp:label id="Label15" style="Z-INDEX: 126; LEFT: 404px; POSITION: absolute; TOP: 30px" runat="server"
			Width="54px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">E-mail</asp:label><asp:textbox id="txtContactName" style="Z-INDEX: 127; LEFT: 284px; POSITION: absolute; TOP: 0px"
			tabIndex="-1" runat="server" Width="112px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtTID" style="Z-INDEX: 128; LEFT: 285px; POSITION: absolute; TOP: 27px" tabIndex="90"
			runat="server" Width="110px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtUBI" style="Z-INDEX: 129; LEFT: 285px; POSITION: absolute; TOP: 52px" tabIndex="100"
			runat="server" Width="110px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtEMail" style="Z-INDEX: 130; LEFT: 448px; POSITION: absolute; TOP: 25px" tabIndex="-1"
			runat="server" Width="107px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:label id="Label16" style="Z-INDEX: 131; LEFT: 12px; POSITION: absolute; TOP: 209px" runat="server"
			Width="99px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Max Dollar Amt</asp:label><asp:textbox id="txtDollarMaxAmount" style="Z-INDEX: 132; LEFT: 115px; POSITION: absolute; TOP: 209px"
			tabIndex="80" runat="server" Width="42px"></asp:textbox><asp:label id="Label17" style="Z-INDEX: 133; LEFT: 9px; POSITION: absolute; TOP: 266px" runat="server"
			Width="63px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Availability</asp:label><asp:label id="Label18" style="Z-INDEX: 134; LEFT: 105px; POSITION: absolute; TOP: 267px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">AM</asp:label><asp:label id="Label19" style="Z-INDEX: 135; LEFT: 106px; POSITION: absolute; TOP: 290px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">PM</asp:label><asp:label id="Label20" style="Z-INDEX: 136; LEFT: 137px; POSITION: absolute; TOP: 248px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Sun</asp:label><asp:label id="Label21" style="Z-INDEX: 137; LEFT: 193px; POSITION: absolute; TOP: 248px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Mon</asp:label><asp:label id="Label22" style="Z-INDEX: 138; LEFT: 255px; POSITION: absolute; TOP: 248px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Tue</asp:label><asp:label id="Label23" style="Z-INDEX: 139; LEFT: 311px; POSITION: absolute; TOP: 248px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Wed</asp:label><asp:label id="Label24" style="Z-INDEX: 140; LEFT: 374px; POSITION: absolute; TOP: 248px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Thu</asp:label><asp:label id="Label25" style="Z-INDEX: 141; LEFT: 430px; POSITION: absolute; TOP: 248px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Fri</asp:label><asp:label id="Label26" style="Z-INDEX: 142; LEFT: 482px; POSITION: absolute; TOP: 248px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Sat</asp:label><asp:checkbox id="chkSunAM" style="Z-INDEX: 143; LEFT: 139px; POSITION: absolute; TOP: 264px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkSunPM" style="Z-INDEX: 144; LEFT: 139px; POSITION: absolute; TOP: 288px"
			tabIndex="-1" runat="server"></asp:checkbox>&nbsp;&nbsp;&nbsp;
		<asp:checkbox id="chkMonAM" style="Z-INDEX: 145; LEFT: 194px; POSITION: absolute; TOP: 264px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkMonPM" style="Z-INDEX: 146; LEFT: 194px; POSITION: absolute; TOP: 288px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkTueAM" style="Z-INDEX: 147; LEFT: 256px; POSITION: absolute; TOP: 264px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkTuePM" style="Z-INDEX: 148; LEFT: 256px; POSITION: absolute; TOP: 288px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkWedAM" style="Z-INDEX: 149; LEFT: 315px; POSITION: absolute; TOP: 264px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkWedPM" style="Z-INDEX: 150; LEFT: 316px; POSITION: absolute; TOP: 288px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkThuAM" style="Z-INDEX: 151; LEFT: 375px; POSITION: absolute; TOP: 264px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkThuPM" style="Z-INDEX: 152; LEFT: 375px; POSITION: absolute; TOP: 288px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkFriAM" style="Z-INDEX: 153; LEFT: 427px; POSITION: absolute; TOP: 264px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkFriPM" style="Z-INDEX: 154; LEFT: 428px; POSITION: absolute; TOP: 288px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkSatAM" style="Z-INDEX: 155; LEFT: 482px; POSITION: absolute; TOP: 264px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:checkbox id="chkSatPM" style="Z-INDEX: 156; LEFT: 482px; POSITION: absolute; TOP: 288px"
			tabIndex="-1" runat="server"></asp:checkbox><asp:button id="btnSave" style="Z-INDEX: 157; LEFT: 684px; POSITION: absolute; TOP: 272px" accessKey="s"
			tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="X-Small" Text="Save"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 158; LEFT: 746px; POSITION: absolute; TOP: 272px"
			accessKey="c" tabIndex="-1" runat="server" Font-Names="Verdana" Font-Size="X-Small" Text="Cancel"></asp:button><asp:checkbox id="chkActive" style="Z-INDEX: 159; LEFT: 248px; POSITION: absolute; TOP: -28px"
			tabIndex="-1" runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small" Text="Active" TextAlign="Left"></asp:checkbox><asp:checkboxlist id="chkLstAssignedAreas" style="Z-INDEX: 160; LEFT: 557px; POSITION: absolute; TOP: 0px"
			runat="server" Width="371px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small" RepeatColumns="2"></asp:checkboxlist><asp:label id="Label27" style="Z-INDEX: 161; LEFT: 564px; POSITION: absolute; TOP: -25px" runat="server"
			Width="157px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Assigned Areas</asp:label><asp:textbox id="txtHiddenNickName" style="Z-INDEX: 162; LEFT: 371px; POSITION: absolute; TOP: 82px"
			runat="server" Width="97px"></asp:textbox><asp:checkbox id="chkHiddenActive" style="Z-INDEX: 163; LEFT: 365px; POSITION: absolute; TOP: 107px"
			runat="server"></asp:checkbox><asp:button id="btnRetrieveAreas" style="Z-INDEX: 164; LEFT: 676px; POSITION: absolute; TOP: -27px"
			runat="server" Width="86px" Text="Retrieve"></asp:button><INPUT id="btnPrimaryAddress" onclick="launchPrimaryAddress()" style="FONT-SIZE: x-small; Z-INDEX: 165; LEFT: 8px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 84px"
			type="button" value="Prm"><INPUT style="FONT-SIZE: x-small; Z-INDEX: 166; LEFT: 9px; WIDTH: 36px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 114px; HEIGHT: 24px"
			accessKey="btnAlternateAddress" onclick="launchAlternateAddress()" type="button" value="Alt">
		<asp:label id="lblHeight" style="Z-INDEX: 167; LEFT: 170px; POSITION: absolute; TOP: 209px"
			runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Height</asp:label><asp:textbox id="txtHeight" style="Z-INDEX: 168; LEFT: 216px; POSITION: absolute; TOP: 209px"
			runat="server" Width="25px" Font-Names="Arial" Font-Size="X-Small"></asp:textbox><asp:checkbox id="chkGutters" style="Z-INDEX: 169; LEFT: 368px; POSITION: absolute; TOP: 146px"
			runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small" Text="Gutters"></asp:checkbox><asp:checkbox id="chkNewConst" style="Z-INDEX: 170; LEFT: 446px; POSITION: absolute; TOP: 146px"
			runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small" Text="New Const"></asp:checkbox><asp:checkbox id="chkPwrWash" style="Z-INDEX: 171; LEFT: 368px; POSITION: absolute; TOP: 175px"
			runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small" Text="Pwr Wash"></asp:checkbox><asp:textbox id="txtNotes" style="Z-INDEX: 172; LEFT: 304px; POSITION: absolute; TOP: 209px"
			runat="server" Width="507px" Font-Names="Verdana" Font-Size="X-Small" Height="39px" MaxLength="180" TextMode="MultiLine"></asp:textbox><asp:label id="Label28" style="Z-INDEX: 173; LEFT: 253px; POSITION: absolute; TOP: 209px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Notes</asp:label><asp:textbox id="txtPrimaryAddressID" style="Z-INDEX: 174; LEFT: 49px; POSITION: absolute; TOP: 84px"
			runat="server" Width="59px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtAlternateAddressID" style="Z-INDEX: 175; LEFT: 50px; POSITION: absolute; TOP: 114px"
			runat="server" Width="59px" Font-Names="Verdana" Font-Size="X-Small"></asp:textbox><asp:textbox id="txtPrimaryAddress" style="Z-INDEX: 176; LEFT: 111px; POSITION: absolute; TOP: 84px"
			runat="server" Width="445px" Font-Names="Verdana" Font-Size="X-Small" Enabled="False"></asp:textbox><asp:textbox id="txtAlternateAddress" style="Z-INDEX: 177; LEFT: 111px; POSITION: absolute; TOP: 114px"
			runat="server" Width="446px" Font-Names="Verdana" Font-Size="X-Small" DESIGNTIMEDRAGDROP="795" Enabled="False"></asp:textbox><asp:label id="Label33" style="Z-INDEX: 178; LEFT: 399px; POSITION: absolute; TOP: 4px" runat="server"
			ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Spouse</asp:label><asp:textbox id="txtSpouseName" style="Z-INDEX: 179; LEFT: 448px; POSITION: absolute; TOP: 0px"
			runat="server" Width="107px"></asp:textbox></DIV>
</DIV>
