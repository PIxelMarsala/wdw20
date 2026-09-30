<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="client.ascx.vb" Inherits="wdw.client1" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<script language="javascript">
//This function does initial cursor positioning
function onload()
{
	document.all("Client1_txtFirstName").focus();
	//document.all("Client1_pnlMore").style.visibility = 'hidden';
}
//This toggles the visibility of chg info
//function chgVisibility()
//{
//	if (document.all("Client1_pnlMore").style.visibility == 'hidden') {
//		document.all("Client1_pnlMore").style.visibility = 'visible';
//	}
//	else {
//		document.all("Client1_pnlMore").style.visibility = 'hidden';
//	}
//}
//This function will simulate a click of the search button if Enter is hit
function document.onkeydown() {
	 if ( event.keyCode == 13 ) {
		Form1.Client1_btnSave.click();
		event.returnValue=false;
	}
}
//This function clears the client search criteria fields
function clearsearch()
{
	document.all.Client1_txtSrchLastName.value = "";
	document.all.Client1_txtSrchContact.value = ""; 
	document.all.Client1_txtSrchClientID.value = ""; 
	document.all.Client1_txtSrchPrimaryArea.value = "" ; 
	document.all.Client1_txtSrchPrimaryExch.value = "" ; 
	document.all.Client1_txtSrchPrimaryNumber.value = "" ; 
	document.all.Client1_txtSrchAlternateArea.value = "" ; 
	document.all.Client1_txtSrchAlternateExch.value = "" ; 
	document.all.Client1_txtSrchAlternateNumber.value = "" ; 
	
}
//this function will actually launch the address window if the Billing button is clicked on the Client page
function launchBillingAddress() {
		
	//open address window
	address_window=window.open('/address.aspx?From_Parent=2&Address_ID='+ document.all.Client1_txtBillingAddressID.value,'_blank','height=400,width=1000,left=0,top=23,status=no,tollbar=no,menubar=no');
	if (window.address_window) {
		address_window.focus();
	}
}
//this jscript function responds to the Client grid click event and populates the edit fields with data
function ClickClient(gridName, itemName) { 
	var row = igtbl_getRowById(itemName); 
	if (row != null){
	
		var primaryPhone = row.getCellFromKey("Primary_Phone").getValue(); 
		var altPhone = row.getCellFromKey("Alt_Phone").getValue(); 
		var oth1Phone = row.getCellFromKey("Other1_Phone").getValue(); 
		var oth2Phone = row.getCellFromKey("Other2_Phone").getValue(); 
				
		document.all.Client1_txtFirstName.value = row.getCellFromKey("First_Name").getValue(); 
		document.all.Client1_txtLastName.value = row.getCellFromKey("Last_Name").getValue(); 
		document.all.Client1_txtClientID.value = row.getCellFromKey("Client_ID").getValue(); 
		document.all.Client1_txtContactName.value = row.getCellFromKey("Contact_Name").getValue(); 
		document.all.Client1_txtSpouseName.value = row.getCellFromKey("Spouse_Name").getValue();
		document.all.Client1_txtEmail.value = row.getCellFromKey("E_Mail").getValue();
		
		var billAddrID = row.getCellFromKey("BillAddress_ID").getValue()
		
		//NaN is the javascript "Not A Number" indicator to check for NULL values
		if (isNaN(billAddrID) || billAddrID == null || billAddrID == 0) {
			document.all.Client1_txtBillingAddressID.value = "";
			document.all.Client1_txtCity.value = "";
			document.all.Client1_txtState.value = "";
			document.all.Client1_txtZipCode.value = "";
			document.all.Client1_txtAddr1.value = "";
		}
		else {
			document.all.Client1_txtBillingAddressID.value = billAddrID;
			document.all.Client1_txtAddr1.value = row.getCellFromKey("Address1").getValue(); 
			document.all.Client1_txtCity.value = row.getCellFromKey("City").getValue(); 
			document.all.Client1_txtState.value = row.getCellFromKey("State").getValue(); 
			document.all.Client1_txtZipCode.value = row.getCellFromKey("ZipCode").getValue();  
		}
		
		document.all.Client1_txtCreateUser.value = row.getCellFromKey("Create_User").getValue(); 
		document.all.Client1_txtModifiedUser.value = row.getCellFromKey("Modified_User").getValue(); 
		document.all.Client1_txtCreateDate.value = row.getCellFromKey("Create_Date").getValue(); 
		document.all.Client1_txtModifiedDate.value = row.getCellFromKey("Modified_Date").getValue();
		 
		document.all.Client1_txtNotes.value = row.getCellFromKey("Notes").getValue(); 
		
		document.all.Client1_txtPrimaryArea.value = primaryPhone.substring(0,3);
		document.all.Client1_txtPrimaryExch.value = primaryPhone.substring(3,6);
		document.all.Client1_txtPrimaryNumber.value = primaryPhone.substring(6,10);
		
		document.all.Client1_txtAlternateArea.value = altPhone.substring(0,3);
		document.all.Client1_txtAlternateExch.value = altPhone.substring(3,6);
		document.all.Client1_txtAlternateNumber.value = altPhone.substring(6,10);
		
		document.all.Client1_txtOther1Area.value = oth1Phone.substring(0,3);
		document.all.Client1_txtOther1Exch.value = oth1Phone.substring(3,6);
		document.all.Client1_txtOther1Number.value = oth1Phone.substring(6,10);
		
		document.all.Client1_txtOther2Area.value = oth2Phone.substring(0,3);
		document.all.Client1_txtOther2Exch.value = oth2Phone.substring(3,6);
		document.all.Client1_txtOther2Number.value = oth2Phone.substring(6,10);
		
		
		if (row.getCellFromKey("Active").getValue() == "1") {
			document.all.Client1_chkActive.checked = true;
		}
		else{
			document.all.Client1_chkActive.checked = false;
		}
		
		if (row.getCellFromKey("COD").getValue() == "1") {
			document.all.Client1_chkCOD.checked = true;
		}
		else{
			document.all.Client1_chkCOD.checked = false;
		}
		
		//set the Client Type list box
		setList( row.getCellFromKey("Client_Type").getValue(), document.all.Client1_lstClientType)
		//set the CallBack Method list box
		//setList( row.getCellFromKey("CallBack_Method").getValue(), document.all.Client1_lstCallBackMethod)
		//set the Discount list box
		setList( row.getCellFromKey("Discount").getValue(), document.all.Client1_lstDiscount)
		//set the Acct Type list box
		setList( row.getCellFromKey("Acct_Type").getValue(), document.all.Client1_lstAccountType)
		//set the Primary Phone Type list box
		setList( row.getCellFromKey("Prm_Phone_Type").getValue(), document.all.Client1_lstPrimaryPhoneType)
		//set the Alternate Phone Type list box
		setList( row.getCellFromKey("Alt_Phone_Type").getValue(), document.all.Client1_lstAltPhoneType)
		//set the Other1 Phone Type list box
		setList( row.getCellFromKey("Other1_Phone_Type").getValue(), document.all.Client1_lstOther1PhoneType)
		//set the Other2 Phone Type list box
		setList( row.getCellFromKey("Other2_Phone_Type").getValue(), document.all.Client1_lstOther2PhoneType)
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
function setAddress(addressId, addr1, city, state , zip) {
	document.all.Client1_txtBillingAddressID.value = addressId;
	document.all.Client1_txtAddr1.value = addr1;
	document.all.Client1_txtCity.value = city;
	document.all.Client1_txtState.value = state;
	document.all.Client1_txtZipCode.value = zip;
}
</script>
<TABLE id="Table1" style="WIDTH: 1003px; HEIGHT: 561px" cellSpacing="0" cellPadding="0"
	width="1003" bgColor="palegreen" border="0">
	<TR>
		<TD style="WIDTH: 105.99%; HEIGHT: 5.26%" background="#00ffff"><asp:label id="lblErrorMsg" Font-Names="Verdana" Height="22px" Font-Size="Medium" runat="server"
				ForeColor="Red" Text="lblErrorMsg" Width="577px"></asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 992px; HEIGHT: 518px" background="#00ffff">
			<DIV style="WIDTH: 99.6%; POSITION: relative; HEIGHT: 105.82%" ms_positioning="GridLayout"><asp:dropdownlist id="lstClientType" style="Z-INDEX: 101; LEFT: 499px; POSITION: absolute; TOP: 193px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server"></asp:dropdownlist><asp:label id="lblName" style="Z-INDEX: 102; LEFT: 7px; POSITION: absolute; TOP: 196px" Font-Names="Verdana"
					Font-Size="X-Small" runat="server" ForeColor="Navy" Width="72px">First Name</asp:label><asp:textbox id="txtFirstName" style="Z-INDEX: 103; LEFT: 80px; POSITION: absolute; TOP: 192px"
					tabIndex="1" Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Transparent" MaxLength="50"></asp:textbox><asp:label id="lblLastName" style="Z-INDEX: 104; LEFT: 9px; POSITION: absolute; TOP: 227px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy"> Last/Com.</asp:label><asp:textbox id="txtLastName" style="Z-INDEX: 105; LEFT: 80px; POSITION: absolute; TOP: 223px"
					tabIndex="2" Font-Names="Verdana" Font-Size="X-Small" runat="server" MaxLength="50"></asp:textbox><asp:label id="lblType" style="Z-INDEX: 106; LEFT: 459px; POSITION: absolute; TOP: 196px" Font-Names="Verdana"
					Font-Size="X-Small" runat="server" ForeColor="Navy">Type</asp:label><asp:label id="lblSpouseName" style="Z-INDEX: 107; LEFT: 245px; POSITION: absolute; TOP: 227px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy">Spouse Name</asp:label><asp:textbox id="txtSpouseName" style="Z-INDEX: 108; LEFT: 382px; POSITION: absolute; TOP: 223px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="116px" MaxLength="50"></asp:textbox><asp:label id="lblContactName" style="Z-INDEX: 109; LEFT: 7px; POSITION: absolute; TOP: 263px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy">Contact</asp:label><asp:textbox id="txtContactName" style="Z-INDEX: 110; LEFT: 80px; POSITION: absolute; TOP: 259px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" MaxLength="50"></asp:textbox><asp:label id="lblPrimary" style="Z-INDEX: 111; LEFT: 9px; POSITION: absolute; TOP: 298px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy">Primary Ph</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtPrimaryNumber');" id="txtPrimaryExch" style="Z-INDEX: 112; LEFT: 115px; POSITION: absolute; TOP: 294px"
					tabIndex="4" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="32px" MaxLength="3"></asp:textbox><asp:textbox id="txtPrimaryNumber" style="Z-INDEX: 113; LEFT: 148px; POSITION: absolute; TOP: 294px"
					tabIndex="5" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="41px" MaxLength="4"></asp:textbox><asp:label id="lblAlternate" style="Z-INDEX: 114; LEFT: 9px; POSITION: absolute; TOP: 330px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy">Alt Ph</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtAlternateExch');" id="txtAlternateArea"
					style="Z-INDEX: 115; LEFT: 80px; POSITION: absolute; TOP: 323px" tabIndex="6" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="34" MaxLength="3"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtAlternateNumber');" id="txtAlternateExch"
					style="Z-INDEX: 116; LEFT: 115px; POSITION: absolute; TOP: 323px" tabIndex="7" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="33" MaxLength="3"></asp:textbox><asp:textbox id="txtAlternateNumber" style="Z-INDEX: 117; LEFT: 148px; POSITION: absolute; TOP: 323px"
					tabIndex="8" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="41px" MaxLength="4"></asp:textbox><asp:label id="lblCallBackMethod" style="Z-INDEX: 118; LEFT: 604px; POSITION: absolute; TOP: 196px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy" Visible="False">Callback</asp:label><asp:dropdownlist id="lstCallBackMethod" style="Z-INDEX: 119; LEFT: 663px; POSITION: absolute; TOP: 193px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="163px" Visible="False"></asp:dropdownlist><asp:dropdownlist id="lstAccountType" style="Z-INDEX: 121; LEFT: 853px; POSITION: absolute; TOP: 224px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="133px"></asp:dropdownlist><asp:label id="lblDiscount" style="Z-INDEX: 122; LEFT: 505px; POSITION: absolute; TOP: 227px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy">Discount</asp:label><asp:checkbox id="chkCOD" style="Z-INDEX: 123; LEFT: 702px; POSITION: absolute; TOP: 225px" tabIndex="-1"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy" Text="COD"></asp:checkbox><asp:checkbox id="chkActive" style="Z-INDEX: 124; LEFT: 379px; POSITION: absolute; TOP: 194px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy" Text="Active"></asp:checkbox><asp:label id="lblNotes" style="Z-INDEX: 126; LEFT: 306px; POSITION: absolute; TOP: 259px"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy">Notes</asp:label><asp:button id="btnSave" style="Z-INDEX: 127; LEFT: 858px; POSITION: absolute; TOP: 414px" accessKey="s"
					tabIndex="10" runat="server" Text="Save"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 128; LEFT: 911px; POSITION: absolute; TOP: 414px"
					accessKey="c" tabIndex="11" runat="server" Text="Cancel"></asp:button>
				<TABLE id="Table2" style="Z-INDEX: 129; LEFT: 0px; WIDTH: 999px; POSITION: absolute; TOP: 0px; HEIGHT: 157px"
					cellSpacing="0" cellPadding="0" width="999" bgColor="#ccff99" border="1">
					<TR>
						<TD style="WIDTH: 260px; HEIGHT: 160px">
							<DIV style="WIDTH: 296px; POSITION: relative; HEIGHT: 141px" ms_positioning="GridLayout"><asp:button id="btnSearch" style="Z-INDEX: 109; LEFT: 199px; POSITION: absolute; TOP: 28px"
									accessKey="h" tabIndex="-1" Height="24px" runat="server" Text="Search" Width="61px"></asp:button><asp:label id="Label3" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 3px" Font-Names="Verdana"
									Font-Size="X-Small" runat="server" ForeColor="Navy" Width="74px"> Last/Com.</asp:label><asp:textbox id="txtSrchLastName" style="Z-INDEX: 115; LEFT: 81px; POSITION: absolute; TOP: 3px"
									tabIndex="12" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="183px" MaxLength="50"></asp:textbox><asp:label id="Label4" style="Z-INDEX: 104; LEFT: 6px; POSITION: absolute; TOP: 62px" Font-Names="Verdana"
									Font-Size="X-Small" runat="server" ForeColor="Navy" Width="65px">Contact</asp:label><asp:textbox id="txtSrchContact" style="Z-INDEX: 112; LEFT: 80px; POSITION: absolute; TOP: 59px"
									tabIndex="14" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="183px" MaxLength="50"></asp:textbox><asp:label id="Label5" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 86px" Font-Names="Verdana"
									Font-Size="X-Small" runat="server" ForeColor="Navy" Width="74px">Primary Ph</asp:label><asp:label id="Label6" style="Z-INDEX: 110; LEFT: 7px; POSITION: absolute; TOP: 110px" Font-Names="Verdana"
									Font-Size="X-Small" runat="server" ForeColor="Navy" Width="62px">Alt Ph</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtSrchPrimaryExch');" id="txtSrchPrimaryArea"
									style="Z-INDEX: 108; LEFT: 80px; POSITION: absolute; TOP: 84px" tabIndex="15" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="29px" MaxLength="3"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtSrchPrimaryNumber');" id="txtSrchPrimaryExch"
									style="Z-INDEX: 111; LEFT: 113px; POSITION: absolute; TOP: 84px" tabIndex="16" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="32px" MaxLength="3"></asp:textbox><asp:textbox id="txtSrchPrimaryNumber" style="Z-INDEX: 101; LEFT: 150px; POSITION: absolute; TOP: 84px"
									tabIndex="17" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="42px" MaxLength="4"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtSrchAlternateExch');" id="txtSrchAlternateArea"
									style="Z-INDEX: 103; LEFT: 79px; POSITION: absolute; TOP: 110px" tabIndex="18" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="32px" MaxLength="3"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtSrchAlternateNumber');" id="txtSrchAlternateExch"
									style="Z-INDEX: 105; LEFT: 113px; POSITION: absolute; TOP: 110px" tabIndex="19" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="33px" MaxLength="3"></asp:textbox><asp:textbox id="txtSrchAlternateNumber" style="Z-INDEX: 107; LEFT: 150px; POSITION: absolute; TOP: 110px"
									tabIndex="20" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="42px" MaxLength="4"></asp:textbox><asp:label id="Label7" style="Z-INDEX: 113; LEFT: 7px; POSITION: absolute; TOP: 35px" Font-Names="Verdana"
									Font-Size="X-Small" runat="server" ForeColor="Navy" Width="63px">Client ID</asp:label><asp:textbox id="txtSrchClientID" style="Z-INDEX: 114; LEFT: 81px; POSITION: absolute; TOP: 32px"
									tabIndex="13" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="108px"></asp:textbox><asp:button id="btnNewClient" style="Z-INDEX: 116; LEFT: 199px; POSITION: absolute; TOP: 85px"
									accessKey="n" tabIndex="-1" Height="24px" runat="server" Text="New" Width="61px"></asp:button><INPUT id="btnClear" style="Z-INDEX: 117; LEFT: 199px; WIDTH: 61px; POSITION: absolute; TOP: 111px; HEIGHT: 24px"
									accessKey="r" onclick="clearsearch()" tabIndex="-1" type="button" value="Clear"></DIV>
						</TD>
						<TD style="WIDTH: 584px; HEIGHT: 160px">
							<DIV style="WIDTH: 695px; POSITION: relative; HEIGHT: 135px" ms_positioning="GridLayout"><igtbl:ultrawebgrid id="UWGClient" style="Z-INDEX: 167; LEFT: 0px; POSITION: absolute; TOP: 0px" Height="133px"
									runat="server" Width="690px">
									<Bands>
										<igtbl:UltraGridBand></igtbl:UltraGridBand>
									</Bands>
									<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" RowHeightDefault="20px"
										Version="2.00" NullTextDefault=" " HeaderClickActionDefault="SortSingle" BorderCollapseDefault="Separate"
										Name="xctl0UWGClient">
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
										<FrameStyle Width="690px" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderStyle="None"
											BackColor="White" Height="133px"></FrameStyle>
										<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
											<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
										</FooterStyleDefault>
										<ClientSideEvents CellClickHandler="ClickClient"></ClientSideEvents>
										<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
										<RowAlternateStyleDefault BackColor="Gainsboro"></RowAlternateStyleDefault>
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
				<asp:label id="lblClientType" style="Z-INDEX: 120; LEFT: 776px; POSITION: absolute; TOP: 227px" Font-Names="Verdana" Font-Size="X-Small" runat="server" ForeColor="Navy">Acct Type</asp:label>
                <asp:textbox id="txtNotes" style="Z-INDEX: 125; LEFT: 381px; POSITION: absolute; TOP: 259px"
					tabIndex="9" Font-Names="Verdana" Height="56px" Font-Size="X-Small" runat="server" Width="605px" MaxLength="270" TextMode="MultiLine"></asp:textbox><asp:textbox id="txtBillingAddressID" style="Z-INDEX: 130; LEFT: 466px; POSITION: absolute; TOP: 320px"
					tabIndex="-1" runat="server" Width="68px"></asp:textbox><asp:dropdownlist id="lstPrimaryPhoneType" style="Z-INDEX: 131; LEFT: 191px; POSITION: absolute; TOP: 295px"
					tabIndex="-1" runat="server" Width="112"></asp:dropdownlist><asp:dropdownlist id="lstAltPhoneType" style="Z-INDEX: 132; LEFT: 191px; POSITION: absolute; TOP: 324px"
					tabIndex="-1" runat="server" Width="112"></asp:dropdownlist><asp:button id="btnSelect" style="Z-INDEX: 133; LEFT: 789px; POSITION: absolute; TOP: 414px"
					accessKey="t" tabIndex="-1" runat="server" Text="Select" Visible="False"></asp:button><asp:dropdownlist id="lstDiscount" style="Z-INDEX: 134; LEFT: 572px; POSITION: absolute; TOP: 224px"
					tabIndex="-1" runat="server" Width="120px"></asp:dropdownlist><INPUT id="btnBillingAddress" style="Z-INDEX: 135; LEFT: 383px; POSITION: absolute; TOP: 319px"
					accessKey="b" onclick="launchBillingAddress()" tabIndex="-1" type="button" value="Bill Addr">
				<asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtPrimaryExch');" id="txtPrimaryArea" style="Z-INDEX: 136; LEFT: 80px; POSITION: absolute; TOP: 294px"
					tabIndex="3" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="34" MaxLength="3"></asp:textbox><asp:textbox id="txtAddr1" style="Z-INDEX: 137; LEFT: 539px; POSITION: absolute; TOP: 320px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="298px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtCity" style="Z-INDEX: 138; LEFT: 539px; POSITION: absolute; TOP: 344px" tabIndex="-1"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="172px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtState" style="Z-INDEX: 139; LEFT: 714px; POSITION: absolute; TOP: 345px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="34px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtZipCode" style="Z-INDEX: 140; LEFT: 752px; POSITION: absolute; TOP: 345px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="85px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:label id="Label8" style="Z-INDEX: 141; LEFT: 9px; POSITION: absolute; TOP: 361px" Font-Names="Verdana"
					Font-Size="X-Small" runat="server" ForeColor="Navy">Oth1 Ph</asp:label><asp:label id="Label9" style="Z-INDEX: 142; LEFT: 9px; POSITION: absolute; TOP: 389px" Font-Names="Verdana"
					Font-Size="X-Small" runat="server" ForeColor="Navy">Oth2 Ph</asp:label><asp:label id="Label10" style="Z-INDEX: 143; LEFT: 10px; POSITION: absolute; TOP: 416px" Font-Names="Verdana"
					Font-Size="X-Small" runat="server" ForeColor="Navy">E-mail</asp:label><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtOther1Exch');" id="txtOther1Area" style="Z-INDEX: 144; LEFT: 80px; POSITION: absolute; TOP: 352px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="34px" MaxLength="3"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtOther1Number');" id="txtOther1Exch" style="Z-INDEX: 145; LEFT: 115px; POSITION: absolute; TOP: 352px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="32px" MaxLength="3"></asp:textbox><asp:textbox id="txtOther1Number" style="Z-INDEX: 146; LEFT: 148px; POSITION: absolute; TOP: 352px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="41px" MaxLength="4"></asp:textbox><asp:dropdownlist id="lstOther1PhoneType" style="Z-INDEX: 147; LEFT: 191px; POSITION: absolute; TOP: 353px"
					tabIndex="-1" runat="server" Width="112px"></asp:dropdownlist><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtOther2Exch');" id="txtOther2Area" style="Z-INDEX: 148; LEFT: 80px; POSITION: absolute; TOP: 383px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="34px" MaxLength="3"></asp:textbox><asp:textbox onkeypress="ctrlLength(  3, 'Client1_txtOther2Number');" id="txtOther2Exch" style="Z-INDEX: 149; LEFT: 115px; POSITION: absolute; TOP: 383px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="32px" MaxLength="3"></asp:textbox><asp:textbox id="txtOther2Number" style="Z-INDEX: 150; LEFT: 148px; POSITION: absolute; TOP: 383px"
					tabIndex="-1" Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="41px" MaxLength="4"></asp:textbox><asp:dropdownlist id="lstOther2PhoneType" style="Z-INDEX: 151; LEFT: 191px; POSITION: absolute; TOP: 384px"
					tabIndex="-1" runat="server" Width="112px"></asp:dropdownlist><asp:textbox id="txtEmail" style="Z-INDEX: 152; LEFT: 80px; POSITION: absolute; TOP: 413px" tabIndex="-1"
					Font-Names="Verdana" Font-Size="X-Small" runat="server" Width="220px" MaxLength="50"></asp:textbox>
                
                <asp:panel id="pnlMore" style="Z-INDEX: 153; LEFT: 90px; POSITION: absolute; TOP: 445px" Height="51px" runat="server" Width="665px">
					<DIV style="WIDTH: 646px; POSITION: relative; HEIGHT: 45px" ms_positioning="GridLayout">
						<asp:label id="dsaf" style="Z-INDEX: 164; LEFT: 1px; POSITION: absolute; TOP: 5px" Font-Names="Verdana"
							Font-Size="XX-Small" runat="server" ForeColor="Navy" Width="79px">Create User</asp:label>
						<asp:label id="fsdf" style="Z-INDEX: 164; LEFT: 1px; POSITION: absolute; TOP: 19px" Font-Names="Verdana"
							Font-Size="XX-Small" runat="server" ForeColor="Navy">Create Date</asp:label>
						<asp:label id="Label1" style="Z-INDEX: 164; LEFT: 236px; POSITION: absolute; TOP: 7px" Font-Names="Verdana"
							Font-Size="XX-Small" runat="server" ForeColor="Navy" Width="89px">Modified User</asp:label>
						<asp:label id="Label2" style="Z-INDEX: 164; LEFT: 237px; POSITION: absolute; TOP: 26px" Font-Names="Verdana"
							Font-Size="XX-Small" runat="server" ForeColor="Navy" Width="103px">Modified Date</asp:label>
						<asp:label id="dfds" style="Z-INDEX: 164; LEFT: 477px; POSITION: absolute; TOP: 25px" Font-Names="Verdana"
							Font-Size="XX-Small" runat="server" ForeColor="Navy" Width="57px">Client ID</asp:label>
						<asp:textbox id="txtClientID" style="Z-INDEX: 164; LEFT: 536px; POSITION: absolute; TOP: 21px"
							tabIndex="-1" Font-Names="Verdana" Height="17px" Font-Size="XX-Small" runat="server" Width="99px" 
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtCreateUser" style="Z-INDEX: 164; LEFT: 74px; POSITION: absolute; TOP: 2px"
							tabIndex="-1" Font-Names="Verdana" Height="17px" Font-Size="XX-Small" runat="server" Width="85" 
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtCreateDate" style="Z-INDEX: 164; LEFT: 74px; POSITION: absolute; TOP: 20px"
							tabIndex="-1" Font-Names="Verdana" Height="17px" Font-Size="XX-Small" runat="server" Width="159" 
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtModifiedUser" style="Z-INDEX: 164; LEFT: 315px; POSITION: absolute; TOP: 3px"
							tabIndex="-1" Font-Names="Verdana" Height="17px" Font-Size="XX-Small" runat="server" Width="85px" 
							BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtModifiedDate" style="Z-INDEX: 164; LEFT: 315px; POSITION: absolute; TOP: 21px"
							tabIndex="-1" Font-Names="Verdana" Height="17px" Font-Size="XX-Small" runat="server" Width="159px" 
							BackColor="Gainsboro"></asp:textbox></DIV>
				</asp:panel></DIV>
		</TD>
	</TR>
</TABLE>
