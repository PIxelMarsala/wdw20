<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="userprofile.ascx.vb" Inherits="wdw.userprofile1" %>

<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<script language="javascript">
//This function does initial cursor positioning
function onload()
{
	document.all("Userprofile1_txtPswrdRpt").focus();
	document.all("Userprofile1_pnlMore").style.visibility = 'hidden';
}
//This toggles the visibility of chg info
function chgVisibility()
{
	if (document.all("Userprofile1_pnlMore").style.visibility == 'hidden') {
		document.all("Userprofile1_pnlMore").style.visibility = 'visible';
		
	}
	
	else {
		document.all("Userprofile1_pnlMore").style.visibility = 'hidden';
	}
}
//This function will simulate a click of the search button if Enter is hit
function document.onkeydown() 
{
	 if ( event.keyCode == 13 ) {
		Form1.Userprofile1_btnSave.click();
		event.returnValue=false;
	}
}
//This function clears the client search criteria fields
function clearsearch() 
{
	document.all.Userprofile1_txtSrchuserprofile.value = "";
	document.all.Userprofile1_txtSrchLastName.value = ""; 
	
}

//this function will set the list box value
function setList(item, selectList) 
{		
	for(i = 0; i < selectList.options.length; i++) {
		if (selectList.options[i].value == item) {
			selectList.options[i].selected = true;
			break;
		}
	}
}
//this jscript function responds to the userprofile grid click event and populates the edit fields with data
function Clickuser(gridName, itemName) 
{ 
	var row = igtbl_getRowById(itemName);
	if (row != null){
	
		document.all.Userprofile1_txtuserprofileID.value = row.getCellFromKey("Operator_ID").getValue();
		document.all.Userprofile1_txtUserId.value = row.getCellFromKey("UserId").getValue();
		document.all.Userprofile1_txtFirstName.value = row.getCellFromKey("First_Name").getValue(); 
		document.all.Userprofile1_txtLastName.value = row.getCellFromKey("Last_Name").getValue();
		//document.all.Userprofile1_txtPassword.value = row.getCellFromKey("password").getValue();
		document.all.Userprofile1_txtCreateUser.value = row.getCellFromKey("Create_User").getValue();
		document.all.Userprofile1_txtModifiedUser.value = row.getCellFromKey("Modified_User").getValue(); 
		document.all.Userprofile1_txtCreateDate.value = row.getCellFromKey("Create_Date").getValue(); 
		document.all.Userprofile1_txtModifiedDate.value = row.getCellFromKey("Modified_Date").getValue(); 
		
		if (row.getCellFromKey("Active").getValue() == "1") {
			document.all.Userprofile1_chkActive.checked = true;
		}
		else{
			document.all.Userprofile1_chkActive.checked = false;
		}
		
		setList( row.getCellFromKey("DefaultScheduleArea").getValue(), document.all.Userprofile1_lstDefaultArea);
		setList( row.getCellFromKey("DefaultApp_Function_ID").getValue(), document.all.Userprofile1_lstDefaultFunction);
		setList( row.getCellFromKey("Role_ID").getValue(), document.all.Userprofile1_lstRole);
		setList( row.getCellFromKey("Company_ID").getValue(), document.all.Userprofile1_lstCompany);
	} 
}
</script>
<TABLE id="Table1" style="WIDTH: 1012px; HEIGHT: 487px" cellSpacing="0" cellPadding="0"
	width="1012" bgColor="#6699cc" border="0">
	<TR>
		<TD style="WIDTH: 1010px; HEIGHT: 3px" bgColor="silver"><asp:label id="lblErrorMsg" runat="server" Width="545px" ForeColor="Red" Font-Names="Verdana"
				Font-Size="Medium">Error Message</asp:label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 1010px; HEIGHT: 484px" bgColor="silver"><asp:panel id="pnlUserSearch" runat="server" Width="1007px" ForeColor="#000040" Height="171px">
				<TABLE id="Table2" style="WIDTH: 1009px; HEIGHT: 134px; BACKGROUND-COLOR: white" cellSpacing="1"
					cellPadding="1" width="1009" bgColor="#99cccc" border="1">
					<TR>
						<TD style="WIDTH: 318px">
							<DIV style="WIDTH: 316px; POSITION: relative; HEIGHT: 120px; BACKGROUND-COLOR: white"
								ms_positioning="GridLayout">
								<asp:label id="Label10" style="Z-INDEX: 101; LEFT: 3px; POSITION: absolute; TOP: 8px" Font-Size="X-Small"
									Font-Names="Verdana" ForeColor="Navy" runat="server">User Id</asp:label>
								<asp:label id="Label11" style="Z-INDEX: 102; LEFT: 3px; POSITION: absolute; TOP: 33px" Font-Size="X-Small"
									Font-Names="Verdana" ForeColor="Navy" runat="server">Last Name</asp:label>
								<asp:textbox id="txtSrchuserprofile" style="Z-INDEX: 107; LEFT: 75px; POSITION: absolute; TOP: 4px"
									tabIndex="-1" Font-Size="X-Small" Font-Names="Verdana" Width="137px" runat="server"></asp:textbox>
								<asp:textbox id="txtSrchLastName" style="Z-INDEX: 108; LEFT: 75px; POSITION: absolute; TOP: 28px"
									tabIndex="-1" Font-Size="X-Small" Font-Names="Verdana" Width="137px" runat="server"></asp:textbox>
								<asp:button id="btnSearch" style="Z-INDEX: 113; LEFT: 242px; POSITION: absolute; TOP: 6px" accessKey="h"
									tabIndex="-1" Width="62" runat="server" Height="24" Text="Search"></asp:button>
								<asp:button id="btnNew" style="Z-INDEX: 114; LEFT: 242px; POSITION: absolute; TOP: 31px" accessKey="n"
									tabIndex="-1" Width="62" runat="server" Height="24" Text="New"></asp:button><INPUT id="btnClear" style="Z-INDEX: 115; LEFT: 242px; WIDTH: 62px; POSITION: absolute; TOP: 57px; HEIGHT: 24px"
									accessKey="r" onclick="clearsearch()" tabIndex="-1" type="button" value="Clear"></DIV>
						</TD>
						<TD>
							<igtbl:ultrawebgrid id="UWGuserprofile" tabIndex="-1" Width="677px" runat="server" Height="133px">
								<Bands>
									<igtbl:UltraGridBand></igtbl:UltraGridBand>
								</Bands>
								<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" RowHeightDefault="20px"
									Version="2.00" NullTextDefault=" " HeaderClickActionDefault="SortSingle" BorderCollapseDefault="Separate"
									Name="xctl0UWGuserprofile">
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
									<FrameStyle Width="677px" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderStyle="Solid"
										BackColor="White" Height="133px"></FrameStyle>
									<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
										<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
									</FooterStyleDefault>
									<ClientSideEvents CellClickHandler="Clickuser"></ClientSideEvents>
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
			</asp:panel>
			<DIV style="WIDTH: 100%; COLOR: silver; POSITION: relative; HEIGHT: 347px; BACKGROUND-COLOR: silver"
				ms_positioning="GridLayout">&nbsp;
				<asp:textbox id="txtFirstName" style="Z-INDEX: 101; LEFT: 148px; POSITION: absolute; TOP: 63px"
					tabIndex="10" runat="server" Width="160" Font-Names="Verdana" Font-Size="X-Small" Height="24"
					MaxLength="50"></asp:textbox><asp:textbox id="txtLastName" style="Z-INDEX: 102; LEFT: 148px; POSITION: absolute; TOP: 94px"
					tabIndex="20" runat="server" Width="161" Font-Names="Verdana" Font-Size="X-Small" Height="24px" MaxLength="50"></asp:textbox><asp:textbox id="txtUserId" style="Z-INDEX: 103; LEFT: 148px; POSITION: absolute; TOP: 30px"
					tabIndex="1" runat="server" Width="160px" Font-Names="Verdana" Font-Size="X-Small" Height="24px" MaxLength="50"></asp:textbox><asp:checkbox id="chkActive" style="Z-INDEX: 104; LEFT: 689px; POSITION: absolute; TOP: 27px"
					tabIndex="-1" runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small" Text="Active" Enabled="False"></asp:checkbox><asp:label id="Label4" style="Z-INDEX: 105; LEFT: 36px; POSITION: absolute; TOP: 66px" runat="server"
					Width="77px" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">First Name</asp:label><asp:label id="Label5" style="Z-INDEX: 106; LEFT: 35px; POSITION: absolute; TOP: 33px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">User Id</asp:label><asp:button id="btnSave" style="Z-INDEX: 107; LEFT: 824px; POSITION: absolute; TOP: 165px" accessKey="s"
					tabIndex="-1" runat="server" Width="67px" Font-Names="Verdana" Font-Size="X-Small" Height="24px" Text="Save"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 894px; POSITION: absolute; TOP: 165px"
					accessKey="c" tabIndex="-1" runat="server" Width="67" Font-Names="Verdana" Font-Size="X-Small" Height="24" Text="Cancel"></asp:button><asp:dropdownlist id="lstDefaultFunction" style="Z-INDEX: 109; LEFT: 148px; POSITION: absolute; TOP: 178px"
					tabIndex="80" runat="server" Width="247" Font-Names="Verdana" Font-Size="X-Small" Height="22"></asp:dropdownlist><INPUT id="btnMore" style="FONT-SIZE: x-small; Z-INDEX: 110; LEFT: 17px; WIDTH: 84px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 286px; HEIGHT: 24px"
					onclick="chgVisibility()" type="button" value="More Info...">
				<asp:panel id="pnlMore" style="Z-INDEX: 111; LEFT: 112px; POSITION: absolute; TOP: 282px" runat="server"
					Width="612px" Height="49px">
					<DIV style="WIDTH: 607px; POSITION: relative; HEIGHT: 46px" ms_positioning="GridLayout">
						<asp:label id="Label1" style="Z-INDEX: 138; LEFT: 485px; POSITION: absolute; TOP: 24px" Font-Size="XX-Small"
							Font-Names="Verdana" ForeColor="Navy" runat="server">User Id</asp:label>
						<asp:label id="Label6" style="Z-INDEX: 138; LEFT: 6px; POSITION: absolute; TOP: 7px" Font-Size="XX-Small"
							Font-Names="Verdana" ForeColor="Navy" runat="server">Create User</asp:label>
						<asp:label id="Label7" style="Z-INDEX: 138; LEFT: 6px; POSITION: absolute; TOP: 23px" Font-Size="XX-Small"
							Font-Names="Verdana" ForeColor="Navy" runat="server">Create Date</asp:label>
						<asp:label id="Label8" style="Z-INDEX: 138; LEFT: 234px; POSITION: absolute; TOP: 6px" Font-Size="XX-Small"
							Font-Names="Verdana" ForeColor="Navy" runat="server">Modified User</asp:label>
						<asp:label id="Label9" style="Z-INDEX: 138; LEFT: 235px; POSITION: absolute; TOP: 25px" Font-Size="XX-Small"
							Font-Names="Verdana" ForeColor="Navy" runat="server">Modified Date</asp:label>
						<asp:textbox id="txtCreateUser" style="Z-INDEX: 138; LEFT: 76px; POSITION: absolute; TOP: 2px"
							tabIndex="-1" Font-Size="XX-Small" Font-Names="Verdana" Width="83" runat="server" Height="17px"
							ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtCreateDate" style="Z-INDEX: 138; LEFT: 76px; POSITION: absolute; TOP: 20px"
							tabIndex="-1" Font-Size="XX-Small" Font-Names="Verdana" Width="157" runat="server" Height="17px"
							ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtModifiedUser" style="Z-INDEX: 138; LEFT: 316px; POSITION: absolute; TOP: 2px"
							tabIndex="-1" Font-Size="XX-Small" Font-Names="Verdana" Width="83px" runat="server" Height="17px"
							ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtModifiedDate" style="Z-INDEX: 138; LEFT: 316px; POSITION: absolute; TOP: 20px"
							tabIndex="-1" Font-Size="XX-Small" Font-Names="Verdana" Width="157px" runat="server" Height="17px"
							ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
						<asp:textbox id="txtuserprofileID" style="Z-INDEX: 138; LEFT: 558px; POSITION: absolute; TOP: 20px"
							tabIndex="-1" Font-Size="XX-Small" Font-Names="Verdana" Width="71px" runat="server" Height="17px"
							ReadOnly="True" BackColor="Gainsboro"></asp:textbox></DIV>
				</asp:panel><asp:label id="Label3" style="Z-INDEX: 112; LEFT: 36px; POSITION: absolute; TOP: 180px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Default Function</asp:label><asp:label id="Label12" style="Z-INDEX: 113; LEFT: 36px; POSITION: absolute; TOP: 97px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Last Name</asp:label><asp:textbox id="txtPassword" style="Z-INDEX: 114; LEFT: 498px; POSITION: absolute; TOP: 0px"
					tabIndex="30" runat="server" Width="161" Font-Names="Verdana" Font-Size="X-Small" Height="24px" MaxLength="100" TextMode="Password"></asp:textbox><asp:textbox id="txtNewPswrd" style="Z-INDEX: 115; LEFT: 498px; POSITION: absolute; TOP: 63px"
					tabIndex="50" runat="server" Width="161px" Font-Names="Verdana" Font-Size="X-Small" Height="24px" MaxLength="100" TextMode="Password"></asp:textbox><asp:textbox id="txtNewPswrdRpt" style="Z-INDEX: 116; LEFT: 498px; POSITION: absolute; TOP: 94px"
					tabIndex="60" runat="server" Width="161px" Font-Names="Verdana" Font-Size="X-Small" Height="24px" MaxLength="100" TextMode="Password"></asp:textbox><asp:label id="lblPassword" style="Z-INDEX: 117; LEFT: 332px; POSITION: absolute; TOP: 2px"
					runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Password</asp:label><asp:label id="Label13" style="Z-INDEX: 118; LEFT: 331px; POSITION: absolute; TOP: 66px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">New Password</asp:label><asp:label id="Label14" style="Z-INDEX: 119; LEFT: 331px; POSITION: absolute; TOP: 97px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Confirm New Password</asp:label><asp:label id="Label15" style="Z-INDEX: 120; LEFT: 36px; POSITION: absolute; TOP: 213px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Role</asp:label><asp:dropdownlist id="lstRole" style="Z-INDEX: 121; LEFT: 148px; POSITION: absolute; TOP: 210px" tabIndex="80"
					runat="server" Width="247" Font-Names="Verdana" Font-Size="X-Small" Height="22" Enabled="False"></asp:dropdownlist><asp:label id="lblConfirmPswrd" style="Z-INDEX: 122; LEFT: 332px; POSITION: absolute; TOP: 33px"
					runat="server" ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Confirm Password</asp:label><asp:textbox id="txtPswrdRpt" style="Z-INDEX: 123; LEFT: 498px; POSITION: absolute; TOP: 30px"
					tabIndex="40" runat="server" Width="161px" Font-Names="Verdana" Font-Size="X-Small" Height="24px" MaxLength="100" TextMode="Password"></asp:textbox><asp:label id="Label17" style="Z-INDEX: 124; LEFT: 36px; POSITION: absolute; TOP: 149px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Default Area</asp:label><asp:dropdownlist id="lstDefaultArea" style="Z-INDEX: 125; LEFT: 148px; POSITION: absolute; TOP: 143px"
					tabIndex="70" runat="server" Width="247" Font-Names="Verdana" Font-Size="X-Small" Height="22"></asp:dropdownlist><asp:label id="Label18" style="Z-INDEX: 126; LEFT: 36px; POSITION: absolute; TOP: 246px" runat="server"
					ForeColor="Navy" Font-Names="Verdana" Font-Size="X-Small">Company</asp:label><asp:dropdownlist id="lstCompany" style="Z-INDEX: 127; LEFT: 148px; POSITION: absolute; TOP: 245px"
					tabIndex="90" runat="server" Width="247px" Font-Names="Verdana" Font-Size="X-Small" Height="22px" Enabled="False"></asp:dropdownlist></DIV>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 1010px; HEIGHT: 3px" bgColor="silver"></TD>
	</TR>
</TABLE>
