<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ScheduleRpt.aspx.vb" Inherits="wdw.ScheduleRpt"%>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v2" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="~/controls/topmenu.ascx" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ScheduleRpt</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 52px">
						<DIV style="WIDTH: 941px; POSITION: relative; HEIGHT: 48px" ms_positioning="GridLayout"><asp:label id="Label1" style="Z-INDEX: 102; LEFT: 18px; POSITION: absolute; TOP: 20px" runat="server">From</asp:label><igsch:webdatechooser id="WebDateChooserFrom" style="Z-INDEX: 103; LEFT: 64px; POSITION: absolute; TOP: 16px"
								runat="server" Width="171px" NullDateLabel=" " JavaScriptFileName="/Infragistics/webschedule1/ig_webdropdown.js" JavaScriptFileNameCommon="/Infragistics/scripts/ig_csom.js" CalendarJavaScriptFileName="/Infragistics/webschedule1/ig_calendar.js">
								<CalendarLayout SelectedDate="2003-12-24" ChangeMonthToDateClicked="True" ShowYearDropDown="False"
									PrevMonthImageUrl="/Infragistics/webschedule1/ig_cal_roseP0.gif" ShowMonthDropDown="False"
									NextMonthImageUrl="/Infragistics/webschedule1/ig_cal_roseN0.gif">
									<FooterStyle Height="16pt" Font-Size="8pt" BackgroundImage="ig_cal_rose2.gif">
										<BorderDetails ColorTop="0, 168, 152, 161" WidthTop="1px" StyleTop="Solid"></BorderDetails>
									</FooterStyle>
									<SelectedDayStyle ForeColor="White" BackColor="#A08085"></SelectedDayStyle>
									<OtherMonthDayStyle ForeColor="#A09098"></OtherMonthDayStyle>
									<NextPrevStyle BackgroundImage="ig_cal_rose1.gif"></NextPrevStyle>
									<CalendarStyle BorderWidth="1px" Font-Size="9pt" Font-Names="Verdana" BorderColor="#706068" BorderStyle="Solid"
										ForeColor="#706068" BackColor="#FFF8FB"></CalendarStyle>
									<TodayDayStyle ForeColor="Black" BackColor="#E8E0E4"></TodayDayStyle>
									<DayHeaderStyle Height="1pt" Font-Size="8pt" Font-Bold="True" BackColor="#EFDEE1">
										<BorderDetails StyleBottom="Solid" ColorBottom="0, 160, 144, 152" WidthBottom="1px"></BorderDetails>
									</DayHeaderStyle>
									<TitleStyle Height="18pt" Font-Size="10pt" Font-Bold="True" BackgroundImage="ig_cal_rose1.gif"
										BackColor="#EFDEE1"></TitleStyle>
								</CalendarLayout>
								<DropButton ImageUrl2="/Infragistics/webschedule1/igsch_xpbluedn.gif" ImageUrl1="/Infragistics/webschedule1/igsch_xpblueup.gif"></DropButton>
								<ExpandEffects ShadowColor="LightGray"></ExpandEffects>
							</igsch:webdatechooser><asp:label id="Label2" style="Z-INDEX: 104; LEFT: 250px; POSITION: absolute; TOP: 20px" runat="server">To</asp:label><igsch:webdatechooser id="WebDateChooserTo" style="Z-INDEX: 101; LEFT: 281px; POSITION: absolute; TOP: 16px"
								runat="server" Width="159px" JavaScriptFileName="/Infragistics/webschedule1/ig_webdropdown.js" JavaScriptFileNameCommon="/Infragistics/scripts/ig_csom.js" CalendarJavaScriptFileName="/Infragistics/webschedule1/ig_calendar.js">
								<CalendarLayout SelectedDate="2003-12-24" ShowYearDropDown="False" PrevMonthImageUrl="/Infragistics/webschedule1/ig_cal_roseP0.gif"
									ShowMonthDropDown="False" NextMonthImageUrl="/Infragistics/webschedule1/ig_cal_roseN0.gif">
									<FooterStyle Height="16pt" Font-Size="8pt" BackgroundImage="ig_cal_rose2.gif">
										<BorderDetails ColorTop="0, 168, 152, 161" WidthTop="1px" StyleTop="Solid"></BorderDetails>
									</FooterStyle>
									<SelectedDayStyle ForeColor="White" BackColor="#A08085"></SelectedDayStyle>
									<OtherMonthDayStyle ForeColor="#A09098"></OtherMonthDayStyle>
									<NextPrevStyle BackgroundImage="ig_cal_rose1.gif"></NextPrevStyle>
									<CalendarStyle BorderWidth="1px" Font-Size="9pt" Font-Names="Verdana" BorderColor="#706068" BorderStyle="Solid"
										ForeColor="#706068" BackColor="#FFF8FB"></CalendarStyle>
									<TodayDayStyle ForeColor="Black" BackColor="#E8E0E4"></TodayDayStyle>
									<DayHeaderStyle Height="1pt" Font-Size="8pt" Font-Bold="True" BackColor="#EFDEE1">
										<BorderDetails StyleBottom="Solid" ColorBottom="0, 160, 144, 152" WidthBottom="1px"></BorderDetails>
									</DayHeaderStyle>
									<TitleStyle Height="18pt" Font-Size="10pt" Font-Bold="True" BackgroundImage="ig_cal_rose1.gif"
										BackColor="#EFDEE1"></TitleStyle>
								</CalendarLayout>
								<DropButton ImageUrl2="/Infragistics/webschedule1/igsch_xpbluedn.gif" ImageUrl1="/Infragistics/webschedule1/igsch_xpblueup.gif"></DropButton>
								<ExpandEffects ShadowColor="LightGray"></ExpandEffects>
							</igsch:webdatechooser><INPUT style="Z-INDEX: 105; LEFT: 457px; POSITION: absolute; TOP: 16px" type="submit" value="Load">
							<asp:Label id="lblErrorMsg" style="Z-INDEX: 106; LEFT: 519px; POSITION: absolute; TOP: 22px"
								runat="server" Width="411px" ForeColor="Red" Visible="False"></asp:Label></DIV>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 158px"><igtbl:ultrawebgrid id="UWGScheduleRpt" runat="server" Width="925px" EnableViewState="False">
							<Bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</Bands>
							<DisplayLayout JavaScriptFileName="/Infragistics/WebGrid2/ig_WebGrid.js" RowHeightDefault="20px"
								Version="2.00" GridLinesDefault="None" ScrollBar="Never" IndentationDefault="0" BorderCollapseDefault="Separate"
								RowSelectorsDefault="No" Name="UWGScheduleRpt">
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
								<FrameStyle Width="925px" BorderWidth="1px" Font-Size="8pt" Font-Names="Verdana" BorderStyle="Solid"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
								<RowStyleDefault BorderWidth="1px" BorderColor="Gray" BorderStyle="Solid">
									<Padding Left="3px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
								<ImageUrls ImageDirectory="/Infragistics/WebGrid2/"></ImageUrls>
							</DisplayLayout>
						</igtbl:ultrawebgrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
