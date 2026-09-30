<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="topmenu.ascx.vb" Inherits="wdw.topmenu" %>

<%@ Register TagPrefix="ignav" Namespace="Infragistics.WebUI.UltraWebNavigator" Assembly="Infragistics.WebUI.UltraWebNavigator.v3" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR vAlign="top" align="center">
		<TD><ignav:ultrawebmenu id="UltraWebMenu1" JavaScriptFilename="/Infragistics/WebNavigator3/ig_webmenu.js"
				Font-Names="Verdana" runat="server" BackColor="DarkMagenta" Cursor="auto" DefaultIslandClass="MainBar"
				Height="31px" TopAligment="Center" Width="1005px" BorderColor="Indigo" SeparatorClass="SeparatorClass"
				DisabledClass="DisabledClass" ForeColor="#FFFFFF" HoverClass="SubMenus" FileUrl=" " BorderStyle="None"
				BorderWidth="1px" ImageDirectory="/Infragistics/WebNavigator3/" JavaScriptFileNameCommon="/Infragistics/Scripts/ig_csom.js">
				<Styles>
					<ignav:Style Cursor="default" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Black"
						BorderStyle="None" ForeColor="Indigo" BackColor="#988AA8" CssClass="MainBar"></ignav:Style>
					<ignav:Style Cursor="default" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Indigo"
						BorderStyle="None" ForeColor="Indigo" BackColor="#C0FFFF" CssClass="SubMenus"></ignav:Style>
					<ignav:Style Cursor="hand" BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderColor="Indigo"
						BorderStyle="Solid" ForeColor="Indigo" BackColor="Plum" CssClass="Rollover"></ignav:Style>
					<ignav:Style BorderWidth="1px" Font-Size="X-Small" Font-Names="Verdana" BorderStyle="Outset"
						ForeColor="White" BackColor="Silver" CssClass="IslandClass"></ignav:Style>
					<ignav:Style BackgroundImage="ig_menuSep.gif" CssClass="SeparatorClass" CustomRules="background-repeat:repeat-x; "></ignav:Style>
					<ignav:Style ForeColor="LightGray" CssClass="DisabledClass"></ignav:Style>
					<ignav:Style BorderWidth="1px" BorderStyle="Solid" CssClass="TopItem"></ignav:Style>
				</Styles>
				<ExpandEffects ShadowColor="Silver"></ExpandEffects>
				<Levels>
					<ignav:Level Index="0" LevelCheckBoxes="False"></ignav:Level>
					<ignav:Level Index="1" LevelCheckBoxes="False"></ignav:Level>
					<ignav:Level Index="2"></ignav:Level>
					<ignav:Level Index="3"></ignav:Level>
				</Levels>
				<Items>
					<ignav:Item TargetUrl="" Text="Schedule">
						<Items>
							<ignav:Item TargetUrl="/Schedule.aspx" Text="Schedule"></ignav:Item>
							<ignav:Item TargetUrl="/Reports/Dispatch.aspx" Text="Dispatch Tickets"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item TargetUrl="" Text="Client">
						<Items>
							<ignav:Item TargetUrl="/Address.aspx" Text="Address"></ignav:Item>
							<ignav:Item TargetUrl="/Client.aspx" Text="Client"></ignav:Item>
							<ignav:Item TargetUrl="/Site.aspx" Text="Site"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item TargetUrl="/Subcontractor.aspx" Text="SubContractor"></ignav:Item>
					<ignav:Item TargetUrl="/Callback.aspx" Text="Call Back">
						<Items>
							<ignav:Item TargetUrl="/Callback.aspx" Text="Call Back"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item TargetUrl="" Text="Closeout">
						<Items>
							<ignav:Item TargetUrl="/Closeout.aspx" Text="Closeout"></ignav:Item>
							<ignav:Item TargetUrl="/Reports/Invoice.aspx" Text="Invoice"></ignav:Item>
							<ignav:Item TargetUrl="/reports/Deposit.aspx" Text="Deposit Ticket"></ignav:Item>
							<ignav:Item TargetUrl="/AR.aspx" Text="AccountsReceivable"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item Text="Reports">
						<Items>
							<ignav:Item Text="Metrics">
								<Items>
									<ignav:Item TargetUrl="/Reports/Scboard.aspx" Text="Scoreboard"></ignav:Item>
									<ignav:Item TargetUrl="/Reports/Scboard2.aspx" Text="Scoreboard Count"></ignav:Item>
									<ignav:Item TargetUrl="/Reports/ScboardNC.aspx" Text="Scoreboard N/C"></ignav:Item>
									<ignav:Item TargetUrl="/Reports/RevBySubCont.aspx" Text="Margin"></ignav:Item>
									<ignav:Item TargetUrl="/Reports/DetRevBySubCont.aspx" Text="Margin Detail"></ignav:Item>
									<ignav:Item TargetUrl="/Reports/DollAmtofCx.aspx" Text="Cancellations "></ignav:Item>
									<ignav:Item TargetUrl="/Reports/BookedFutureBusiness.aspx" Text="Future Months Business"></ignav:Item>
								</Items>
							</ignav:Item>
							<ignav:Item TargetUrl="/Reports/CallbackComm.aspx" Text="Callback Commission"></ignav:Item>
                            <ignav:Item TargetUrl="/Reports/BOTax.aspx" Text="Tax: B&amp;O"></ignav:Item>
                            <ignav:Item TargetUrl="/Reports/BOTax_Detail.aspx" Text="Tax: B&amp;O Detail"></ignav:Item>
							<ignav:Item Text="Transactions">
								<Items>
									<ignav:Item TargetUrl="/Reports/NewOldCustZp.aspx" Text="New Clients by Zipcode"></ignav:Item>
								</Items>
							</ignav:Item>
							<ignav:Item TargetUrl="/Reports/ScheduleRpt.aspx" Text="Schedule"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item Text="Misc">
						<Items>
							<ignav:Item TargetUrl="" Text="Pricing">
								<Items>
									<ignav:Item TargetUrl="/Tasks.aspx" Text="Items"></ignav:Item>
									<ignav:Item TargetUrl="/Pricing.aspx" Text="Pricing"></ignav:Item>
								</Items>
							</ignav:Item>
							<ignav:Item TargetUrl="/UserProfile.aspx" Text="User Profile"></ignav:Item>
							<ignav:Item TargetUrl="hasher.aspx" Text="Hasher"></ignav:Item>
						</Items>
					</ignav:Item>
					<ignav:Item TargetUrl="/LogOff.aspx" Text="Log Off"></ignav:Item>
				</Items>
			</ignav:ultrawebmenu></TD>
	</TR>
</TABLE>
