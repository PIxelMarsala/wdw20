<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="job.ascx.vb" Inherits="wdw.job" %>
<script language="javascript">
//This function does initial cursor positioning
function onload()
{
	document.all("Job1_txtTime").focus();
	document.all("Job1_pnlMore").style.visibility = 'hidden';
}

//This toggles the visibility of chg info
function chgVisibility()
{
	if (document.all("Job1_pnlMore").style.visibility == 'hidden') {
		document.all("Job1_pnlMore").style.visibility = 'visible';
	}
	
	else {
		document.all("Job1_pnlMore").style.visibility = 'hidden';
	}
}
//This function will simulate a click of the save button if Enter is hit
function document.onkeydown() {
	 if ( event.keyCode == 13 ) {
		Form1.Job1_btnSave.click();
		event.returnValue=false;
	}
}
//this function will actually launch the job window
function launchSite() {

	var siteId = document.all.Job1_txtSiteId.value
		
	//open site window with a site
	site_window=window.open('/site.aspx?From_Parent=1&Site_ID='+ siteId ,'_blank','status=no,tollbar=no,menubar=no,height=585,width=1000,left=0,top=23');
	if (window.site_window) {
		site_window.focus();
	}
}
//this function will actually launch the client window if the Occ Client button is clicked on the page
function launchOClient() {
		
	//open address window
	oclient_window=window.open('/client.aspx?From_Parent=1&Client_ID='+ document.all.Job1_txtOccClientId.value,'_blank','status=no,tollbar=no,menubar=no,height=550,width=1000,left=0,top=23');
	if (window.oclient_window) {
		oclient_window.focus();
	}
}
//this function will actually launch the client window if the Bill Client button is clicked on the page
function launchBClient() {
		
	//open address window
	bclient_window=window.open('/client.aspx?From_Parent=2&Client_ID='+ document.all.Job1_txtBillClientId.value,'_blank','status=no,tollbar=no,menubar=no,height=550,width=1000,left=0,top=23');
	if (window.bclient_window) {
		bclient_window.focus();
	}
}
//this function will launch the estimate window
function launchEstimate() {

	var jobId = document.all.Job1_txtJobId.value
	var siteId = document.all.Job1_txtSiteId.value
	var bidId = document.all.Job1_txtBidId.value
			
	//open site window with a site
	estimate_window=window.open('/Estimate.aspx?Bid_ID=' + bidId + '&Job_ID='+ jobId + '&Site_ID=' + siteId ,'_blank','status=no,tollbar=no,menubar=no,height=600,width=1000,left=0,top=23');
	if (window.estimate_window) {
		estimate_window.focus();
	}
}
//this function is called by the Site page to populate the bid Id and the amt
function setSite(siteId, noStories, notes, critical) {
	if (siteId == document.all.Job1_txtSiteId.value) {
		document.all.Job1_txtSiteNoStories.value = noStories;
		document.all.Job1_txtSiteNote.value = notes;
		if (critical == 1) {
			document.all.Job1_txtSiteNote.style.backgroundColor = 'lightcoral';
		}
		else {
			document.all.Job1_txtSiteNote.style.backgroundColor = 'gainsboro';
		}
	}
}
//this function is called by the Estimate page to populate the bid Id and the amt
function setEstimate(bidId, schedAmt, description) {

	//var status = document.all.Job1_lstStatus.selectedIndex
	//only update the job with estimate stuff if the job status is open or closed
	//if (status == 1 || status == 3) {
		document.all.Job1_txtBidId.value = bidId;
		document.getElementById('Job1_txtSchedAmt').value = schedAmt;
		document.getElementById('Job1_txtPayBasis').value = schedAmt;
		document.getElementById('Job1_txtBillAmt').value = schedAmt;
		document.getElementById('Job1_txtDescription').value = description;
	//}
}
//this sets the local addressid
function setAddress(addressId, addr1, city, state, zip, careOf) {
	document.all.Job1_txtSiteAddressID.value = addressId;
	document.all.Job1_txtSiteAddr1.value = addr1;
	document.all.Job1_txtCity.value = city;
	document.all.Job1_txtState.value = state;
	document.all.Job1_txtZipCode.value = zip;
	document.all.Job1_txtCareOf.value = careOf;
}
//this sets the local Occ Client
function setOClient(clientId, fname, lname, pphone, pphonet, aphone, aphonet, o1phone, o1phonet, o2phone, o2phonet, contact) {
	if (clientId == document.all.Job1_txtOccClientId.value) {
		document.all.Job1_txtOccFirstName.value = fname;
		document.all.Job1_txtOccLastName.value = lname;
		document.all.Job1_txtOccContact.value = contact;
	
		document.all.Job1_txtOccPPhone.value = pphone;
		document.all.Job1_txtOccAPhone.value = aphone;
		document.all.Job1_txtOccO1Phone.value = o1phone;
		document.all.Job1_txtOccO2Phone.value = o2phone;
		
		//set the Primary Phone Type list box
		setList( pphonet, document.all.Job1_lstOccPPhoneType)
		//set the Alternate Phone Type list box
		setList( aphonet, document.all.Job1_lstOccAPhoneType)
		//set the Other1 Phone Type list box
		setList( o1phonet, document.all.Job1_lstOccO1PhoneType)
		//set the Other2 Phone Type list box
		setList( o2phonet, document.all.Job1_lstOccO2PhoneType)
	}
}
//this sets the local Bill Client
function setBClient(clientId, fname, lname, pphone, pphonet, aphone, aphonet, o1phone, o1phonet, o2phone, o2phonet, contact) {
	if (clientId == document.all.Job1_txtBillClientId.value) {
		document.all.Job1_txtBillFirstName.value = fname;
		document.all.Job1_txtBillLastName.value = lname;
		document.all.Job1_txtBillContact.value = contact;
		
		document.all.Job1_txtBillPPhone.value = pphone;
		document.all.Job1_txtBillAPhone.value = aphone;
		document.all.Job1_txtBillO1Phone.value = o1phone;
		document.all.Job1_txtBillO2Phone.value = o2phone;
		
		//set the Primary Phone Type list box
		setList( pphonet, document.all.Job1_lstBillPPhoneType)
		//set the Alternate Phone Type list box
		setList( aphonet, document.all.Job1_lstBillAPhoneType)
		//set the Other1 Phone Type list box
		setList( o1phonet, document.all.Job1_lstBillO1PhoneType)
		//set the Other2 Phone Type list box
		setList( o2phonet, document.all.Job1_lstBillO2PhoneType)
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
<TABLE id="Table1" style="WIDTH: 985px; HEIGHT: 500px" cellSpacing="0" cellPadding="0"
	width="985" bgColor="lemonchiffon" border="0">
	<TR>
		<TD style="HEIGHT: 510px"><asp:label id="lblErrorMsg" ForeColor="Red" runat="server" Font-Size="Medium" Width="904px"></asp:label>
			<DIV style="WIDTH: 984px; POSITION: relative; HEIGHT: 513px" ms_positioning="GridLayout"><asp:textbox id="txtTime" style="Z-INDEX: 101; LEFT: 83px; POSITION: absolute; TOP: 25px" runat="server"
					Font-Size="X-Small" Width="32px" Font-Names="Verdana"></asp:textbox><asp:checkbox id="chkCritical" style="Z-INDEX: 102; LEFT: 175px; POSITION: absolute; TOP: 134px"
					tabIndex="-1" ForeColor="#0000C0" runat="server" Font-Size="X-Small" Width="103px" Font-Names="Verdana" Text="Time Critical"></asp:checkbox><asp:checkbox id="chkOutside" style="Z-INDEX: 103; LEFT: 289px; POSITION: absolute; TOP: 134px"
					tabIndex="-1" ForeColor="#0000C0" runat="server" Font-Size="X-Small" Font-Names="Verdana" Text="Out Only"></asp:checkbox><asp:label id="Label5" style="Z-INDEX: 104; LEFT: 307px; POSITION: absolute; TOP: 29px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">Status</asp:label><asp:label id="Label6" style="Z-INDEX: 105; LEFT: 50px; POSITION: absolute; TOP: 54px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Width="60px" Font-Names="Verdana">Schedule Amt</asp:label><asp:textbox id="txtSchedAmt" style="Z-INDEX: 106; LEFT: 117px; POSITION: absolute; TOP: 58px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="59" Font-Names="Verdana" ReadOnly="True"></asp:textbox><asp:label id="Label7" style="Z-INDEX: 107; LEFT: 183px; POSITION: absolute; TOP: 62px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Width="51px" Font-Names="Verdana">Bill Amt</asp:label><asp:label id="Label8" style="Z-INDEX: 108; LEFT: 52px; POSITION: absolute; TOP: 100px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">Pay Basis</asp:label><asp:textbox id="txtBillAmt" style="Z-INDEX: 109; LEFT: 237px; POSITION: absolute; TOP: 58px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="59px" Font-Names="Verdana" ReadOnly="True"></asp:textbox><asp:textbox id="txtPayBasis" style="Z-INDEX: 110; LEFT: 117px; POSITION: absolute; TOP: 96px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="59px" Font-Names="Verdana" ReadOnly="True"></asp:textbox><asp:label id="Label9" style="Z-INDEX: 111; LEFT: 181px; POSITION: absolute; TOP: 100px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">Sub Pay</asp:label><asp:textbox id="txtSubPay" style="Z-INDEX: 112; LEFT: 238px; POSITION: absolute; TOP: 96px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="59px" Font-Names="Verdana" ReadOnly="True"></asp:textbox><asp:checkbox id="chkPriorSched" style="Z-INDEX: 113; LEFT: 396px; POSITION: absolute; TOP: 134px"
					tabIndex="-1" ForeColor="#0000C0" runat="server" Font-Size="X-Small" Font-Names="Verdana" Text="Prior Schedule" Enabled="False"></asp:checkbox><asp:dropdownlist id="lstPmtMethod" style="Z-INDEX: 114; LEFT: 355px; POSITION: absolute; TOP: 96px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="101px" Font-Names="Verdana"></asp:dropdownlist><asp:label id="Label10" style="Z-INDEX: 115; LEFT: 306px; POSITION: absolute; TOP: 91px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Width="61px" Font-Names="Verdana">Pmt Meth</asp:label><asp:dropdownlist id="lstStatus" style="Z-INDEX: 116; LEFT: 356px; POSITION: absolute; TOP: 26px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="148px" Font-Names="Verdana"></asp:dropdownlist><asp:label id="Label11" style="Z-INDEX: 117; LEFT: 306px; POSITION: absolute; TOP: 48px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Width="44px" Font-Names="Verdana"> Cancel Reason</asp:label><asp:dropdownlist id="lstCancelReason" style="Z-INDEX: 118; LEFT: 355px; POSITION: absolute; TOP: 58px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="149px" Font-Names="Verdana"></asp:dropdownlist><asp:label id="Label12" style="Z-INDEX: 119; LEFT: 3px; POSITION: absolute; TOP: 160px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Width="73px" Font-Names="Verdana">Job Description</asp:label><asp:textbox id="txtDescription" style="Z-INDEX: 120; LEFT: 88px; POSITION: absolute; TOP: 159px"
					tabIndex="3" runat="server" Font-Size="X-Small" Width="418px" Font-Names="Verdana" Height="93px" MaxLength="270" TextMode="MultiLine"></asp:textbox><asp:textbox id="txtNotes" style="Z-INDEX: 121; LEFT: 88px; POSITION: absolute; TOP: 260px" tabIndex="4"
					runat="server" Font-Size="X-Small" Width="419px" Font-Names="Verdana" Height="92px" TextMode="MultiLine" MaxLength="270"></asp:textbox><asp:label id="Label13" style="Z-INDEX: 122; LEFT: 4px; POSITION: absolute; TOP: 263px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Width="53px" Font-Names="Verdana">Job Notes</asp:label><asp:button id="btnSave" style="Z-INDEX: 123; LEFT: 309px; POSITION: absolute; TOP: 363px" tabIndex="5"
					runat="server" Font-Size="X-Small" Width="70px" Font-Names="Verdana" Text="Save"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 124; LEFT: 387px; POSITION: absolute; TOP: 363px"
					tabIndex="6" runat="server" Font-Size="X-Small" Font-Names="Verdana" Text="Cancel"></asp:button><asp:textbox id="txtDate" style="Z-INDEX: 125; LEFT: 6px; POSITION: absolute; TOP: 25px" tabIndex="-1"
					runat="server" Font-Size="X-Small" Width="75px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtAddr1" style="Z-INDEX: 126; LEFT: 597px; POSITION: absolute; TOP: 25px" tabIndex="-1"
					runat="server" Font-Size="X-Small" Width="307px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtCity" style="Z-INDEX: 127; LEFT: 597px; POSITION: absolute; TOP: 51px" tabIndex="-1"
					runat="server" Font-Size="X-Small" Width="172px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtState" style="Z-INDEX: 128; LEFT: 772px; POSITION: absolute; TOP: 51px" tabIndex="-1"
					runat="server" Font-Size="X-Small" Width="28px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtZipCode" style="Z-INDEX: 129; LEFT: 803px; POSITION: absolute; TOP: 51px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="100px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtSubName" style="Z-INDEX: 130; LEFT: 117px; POSITION: absolute; TOP: 25px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="178px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><INPUT id="btnSite" style="Z-INDEX: 131; LEFT: 542px; WIDTH: 45px; POSITION: absolute; TOP: 24px; HEIGHT: 24px"
					onclick="launchSite()" tabIndex="-1" type="button" value="Site"> <INPUT id="btnBid" style="Z-INDEX: 132; LEFT: 3px; WIDTH: 38px; POSITION: absolute; TOP: 56px; HEIGHT: 24px"
					onclick="launchEstimate()" tabIndex="2" type="button" value="Est">
				<asp:textbox id="txtSiteNote" style="Z-INDEX: 133; LEFT: 597px; POSITION: absolute; TOP: 126px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="377px" Font-Names="Verdana" ReadOnly="True"
					Height="79px" TextMode="MultiLine" BackColor="Gainsboro"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 134; LEFT: 526px; POSITION: absolute; TOP: 128px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">Site Note</asp:label><asp:label id="Label3" style="Z-INDEX: 135; LEFT: 519px; POSITION: absolute; TOP: 103px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">No Stories</asp:label><asp:textbox id="txtSiteNoStories" style="Z-INDEX: 136; LEFT: 597px; POSITION: absolute; TOP: 100px"
					tabIndex="-1" runat="server" Width="36px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtOccFirstName" style="Z-INDEX: 137; LEFT: 854px; POSITION: absolute; TOP: 208px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="118px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtOccLastName" style="Z-INDEX: 138; LEFT: 597px; POSITION: absolute; TOP: 208px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="250px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtOccContact" style="Z-INDEX: 139; LEFT: 597px; POSITION: absolute; TOP: 234px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:label id="Label19" style="Z-INDEX: 140; LEFT: 539px; POSITION: absolute; TOP: 237px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">Contact</asp:label><asp:label id="Label21" style="Z-INDEX: 141; LEFT: 553px; POSITION: absolute; TOP: 263px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">P Ph</asp:label><asp:textbox id="txtOccPPhone" style="Z-INDEX: 142; LEFT: 597px; POSITION: absolute; TOP: 259px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:label id="Label20" style="Z-INDEX: 143; LEFT: 553px; POSITION: absolute; TOP: 287px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">A Ph</asp:label><asp:textbox id="txtOccAPhone" style="Z-INDEX: 144; LEFT: 597px; POSITION: absolute; TOP: 283px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:label id="Label23" style="Z-INDEX: 145; LEFT: 532px; POSITION: absolute; TOP: 390px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">Contact</asp:label><asp:label id="Label24" style="Z-INDEX: 146; LEFT: 550px; POSITION: absolute; TOP: 417px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">P Ph</asp:label><asp:label id="Label25" style="Z-INDEX: 147; LEFT: 548px; POSITION: absolute; TOP: 441px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">A Ph</asp:label><asp:textbox id="txtBillContact" style="Z-INDEX: 148; LEFT: 597px; POSITION: absolute; TOP: 387px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtBillPPhone" style="Z-INDEX: 149; LEFT: 597px; POSITION: absolute; TOP: 412px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtBillAPhone" style="Z-INDEX: 150; LEFT: 597px; POSITION: absolute; TOP: 436px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="158px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtBillFirstName" style="Z-INDEX: 151; LEFT: 855px; POSITION: absolute; TOP: 363px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="118" Font-Names="Verdana" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtBillLastName" style="Z-INDEX: 152; LEFT: 597px; POSITION: absolute; TOP: 363px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="253" Font-Names="Verdana" BackColor="Gainsboro"></asp:textbox><INPUT id="btnOccClient" style="FONT-SIZE: x-small; Z-INDEX: 153; LEFT: 517px; WIDTH: 77px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 208px; HEIGHT: 24px"
					onclick="launchOClient()" tabIndex="-1" type="button" value="Occ Client"> <INPUT id="btnBillClient" style="FONT-SIZE: x-small; Z-INDEX: 154; LEFT: 517px; WIDTH: 77px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 363px; HEIGHT: 24px"
					onclick="launchBClient()" tabIndex="-1" type="button" value="Bill Client"> <INPUT id="btnMore" style="FONT-SIZE: x-small; Z-INDEX: 155; LEFT: 7px; WIDTH: 86px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 363px; HEIGHT: 24px"
					onclick="chgVisibility()" tabIndex="-1" type="button" value="More Info...">
				<asp:panel id="pnlMore" style="Z-INDEX: 156; LEFT: 5px; POSITION: absolute; TOP: 398px" runat="server"
					Width="469px" Height="89px">
					<DIV style="WIDTH: 510px; POSITION: relative; HEIGHT: 89px" ms_positioning="GridLayout">
						<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 51px; POSITION: absolute; TOP: 8px" Font-Size="XX-Small"
							runat="server" ForeColor="#0000C0" Font-Names="Verdana">Job</asp:label>
						<asp:textbox id="txtJobId" style="Z-INDEX: 102; LEFT: 73px; POSITION: absolute; TOP: 5px" tabIndex="-1"
							Width="62px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True" Height="17px"
							BackColor="Gainsboro"></asp:textbox>
						<asp:TextBox id="txtSubId" style="Z-INDEX: 104; LEFT: 165px; POSITION: absolute; TOP: 5px" tabIndex="-1"
							Width="65px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" Height="17px" BackColor="Gainsboro"></asp:TextBox>
						<asp:Label id="Label26" style="Z-INDEX: 103; LEFT: 142px; POSITION: absolute; TOP: 8px" Font-Size="XX-Small"
							runat="server" ForeColor="#0000C0" Font-Names="Verdana">Sub</asp:Label>
						<asp:label id="Label27" style="Z-INDEX: 105; LEFT: 234px; POSITION: absolute; TOP: 8px" Width="18px"
							Font-Size="XX-Small" runat="server" ForeColor="#0000C0" Font-Names="Verdana">Bid</asp:label>
						<asp:textbox id="txtBidId" style="Z-INDEX: 106; LEFT: 252px; POSITION: absolute; TOP: 5px" tabIndex="-1"
							Width="64px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True" Height="17px"
							BackColor="Gainsboro"></asp:textbox>
						<asp:label id="Label28" style="Z-INDEX: 107; LEFT: 316px; POSITION: absolute; TOP: 8px" Width="18px"
							Font-Size="XX-Small" runat="server" ForeColor="#0000C0" Font-Names="Verdana">Site</asp:label>
						<asp:textbox id="txtSiteId" style="Z-INDEX: 108; LEFT: 340px; POSITION: absolute; TOP: 4px" tabIndex="-1"
							Width="73px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
						<asp:label id="Label4" style="Z-INDEX: 109; LEFT: 30px; POSITION: absolute; TOP: 28px" Font-Size="XX-Small"
							runat="server" ForeColor="#0000C0" Font-Names="Verdana">OClient</asp:label>
						<asp:textbox id="txtOccClientId" style="Z-INDEX: 110; LEFT: 73px; POSITION: absolute; TOP: 24px"
							tabIndex="-1" Width="84px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True"
							BackColor="Gainsboro"></asp:textbox>
						<asp:label id="Label18" style="Z-INDEX: 111; LEFT: 168px; POSITION: absolute; TOP: 28px" Font-Size="XX-Small"
							runat="server" ForeColor="#0000C0" Font-Names="Verdana">BClient</asp:label>
						<asp:textbox id="txtBillClientId" style="Z-INDEX: 112; LEFT: 214px; POSITION: absolute; TOP: 24px"
							tabIndex="-1" Width="88px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True"
							BackColor="Gainsboro"></asp:textbox>
						<asp:label id="Label14" style="Z-INDEX: 113; LEFT: 2px; POSITION: absolute; TOP: 48px" Width="75px"
							Font-Size="XX-Small" runat="server" ForeColor="#0000C0" Font-Names="Verdana">Create User</asp:label>
						<asp:textbox id="txtCreateUser" style="Z-INDEX: 114; LEFT: 73px; POSITION: absolute; TOP: 45px"
							tabIndex="-1" Width="72" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True"
							Height="17px" BackColor="Gainsboro"></asp:textbox>
						<asp:label id="Label17" style="Z-INDEX: 115; LEFT: 229px; POSITION: absolute; TOP: 48px" Width="86px"
							Font-Size="XX-Small" runat="server" ForeColor="#0000C0" Font-Names="Verdana">Modified User</asp:label>
						<asp:textbox id="txtModifiedUser" style="Z-INDEX: 116; LEFT: 307px; POSITION: absolute; TOP: 45px"
							tabIndex="-1" Width="72px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True"
							Height="17px" BackColor="Gainsboro"></asp:textbox>
						<asp:label id="Label15" style="Z-INDEX: 117; LEFT: 2px; POSITION: absolute; TOP: 68px" Width="75px"
							Font-Size="XX-Small" runat="server" ForeColor="#0000C0" Font-Names="Verdana">Create Date</asp:label>
						<asp:textbox id="txtCreateDate" style="Z-INDEX: 118; LEFT: 73px; POSITION: absolute; TOP: 65px"
							tabIndex="-1" Width="156px" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True"
							Height="17px" BackColor="Gainsboro"></asp:textbox>
						<asp:label id="Label16" style="Z-INDEX: 119; LEFT: 229px; POSITION: absolute; TOP: 68px" Width="80px"
							Font-Size="XX-Small" runat="server" ForeColor="#0000C0" Font-Names="Verdana">Modified Date</asp:label>
						<asp:textbox id="txtModifiedDate" style="Z-INDEX: 120; LEFT: 307px; POSITION: absolute; TOP: 65px"
							tabIndex="-1" Width="156" Font-Size="XX-Small" runat="server" Font-Names="Verdana" ReadOnly="True"
							Height="17px" BackColor="Gainsboro"></asp:textbox></DIV>
				</asp:panel><asp:label id="Label22" style="Z-INDEX: 157; LEFT: 543px; POSITION: absolute; TOP: 313px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">O1 Ph</asp:label><asp:label id="Label29" style="Z-INDEX: 158; LEFT: 543px; POSITION: absolute; TOP: 337px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">O2 Ph</asp:label><asp:textbox id="txtOccO1Phone" style="Z-INDEX: 159; LEFT: 597px; POSITION: absolute; TOP: 307px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="158px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtOccO2Phone" style="Z-INDEX: 160; LEFT: 597px; POSITION: absolute; TOP: 332px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="158px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:label id="Label30" style="Z-INDEX: 161; LEFT: 549px; POSITION: absolute; TOP: 467px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">O1 Ph</asp:label><asp:label id="Label31" style="Z-INDEX: 162; LEFT: 549px; POSITION: absolute; TOP: 490px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">O2 Ph</asp:label><asp:textbox id="txtBillO1Phone" style="Z-INDEX: 163; LEFT: 597px; POSITION: absolute; TOP: 460px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="158px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:textbox id="txtBillO2Phone" style="Z-INDEX: 164; LEFT: 597px; POSITION: absolute; TOP: 486px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="158px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="lstOccPPhoneType" style="Z-INDEX: 165; LEFT: 759px; POSITION: absolute; TOP: 260px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="125" Font-Names="Verdana" BackColor="Gainsboro"></asp:dropdownlist><asp:dropdownlist id="lstOccAPhoneType" style="Z-INDEX: 166; LEFT: 759px; POSITION: absolute; TOP: 284px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="125" Font-Names="Verdana" BackColor="Gainsboro"></asp:dropdownlist><asp:dropdownlist id="lstOccO1PhoneType" style="Z-INDEX: 167; LEFT: 759px; POSITION: absolute; TOP: 308px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="125" Font-Names="Verdana" BackColor="Gainsboro"></asp:dropdownlist><asp:dropdownlist id="lstOccO2PhoneType" style="Z-INDEX: 168; LEFT: 759px; POSITION: absolute; TOP: 333px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="125px" Font-Names="Verdana" BackColor="Gainsboro"></asp:dropdownlist><asp:dropdownlist id="lstBillAPhoneType" style="Z-INDEX: 169; LEFT: 759px; POSITION: absolute; TOP: 438px"
					tabIndex="-1" runat="server" Width="126px" BackColor="Gainsboro"></asp:dropdownlist><asp:dropdownlist id="lstBillO1PhoneType" style="Z-INDEX: 170; LEFT: 759px; POSITION: absolute; TOP: 462px"
					tabIndex="-1" runat="server" Width="126px" BackColor="Gainsboro"></asp:dropdownlist><asp:dropdownlist id="lstBillO2PhoneType" style="Z-INDEX: 171; LEFT: 759px; POSITION: absolute; TOP: 487px"
					tabIndex="-1" runat="server" Width="126px" BackColor="Gainsboro"></asp:dropdownlist><asp:dropdownlist id="lstBillPPhoneType" style="Z-INDEX: 172; LEFT: 759px; POSITION: absolute; TOP: 413px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="126px" Font-Names="Verdana" BackColor="Gainsboro"></asp:dropdownlist><asp:label id="Label32" style="Z-INDEX: 173; LEFT: 536px; POSITION: absolute; TOP: 80px" ForeColor="#0000C0"
					runat="server" Font-Size="X-Small" Font-Names="Verdana">Care Of</asp:label><asp:textbox id="txtCareOf" style="Z-INDEX: 174; LEFT: 597px; POSITION: absolute; TOP: 75px"
					tabIndex="-1" runat="server" Font-Size="X-Small" Width="173px" Font-Names="Verdana" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
				<asp:CheckBox id="chkReminder" style="Z-INDEX: 175; LEFT: 85px; POSITION: absolute; TOP: 134px"
					tabIndex="-1" Font-Size="X-Small" runat="server" ForeColor="#0000C0" Font-Names="Verdana"
					Text="Reminder"></asp:CheckBox></DIV>
		</TD>
	</TR>
</TABLE>

