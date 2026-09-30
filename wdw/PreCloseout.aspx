<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PreCloseout.aspx.vb" Inherits="wdw.PreCloseout" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WebForm1</TITLE>
		
	<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
	<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<LINK href="/wdw/css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	
	<script> 
		function AssignValues() 
		{ // printing; 
		var nickname = "COL";
		var fromdate = "01/01/2002";
		var todate ="06/01/2002";
		launchcloseout(nickname,fromdate,todate);} 
	</script>
	<script>
        function launchcloseout(nickname, fromdate, todate) 
        {//OPEN THE WINDOW
        closeout_window=window.open('/wdw/Closeout1.aspx?nickname='+ nickname+'?fromdate='+ fromdate+'?todate='+todate,null,'height=300,width=930,status=no,toolbar=no,menubar=no,location=no'); 
        if (window.closeout_window) 
        { closeout_window.focus(); }} 
	</script>
	<form id="Form1" method="post" runat="server">
		<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 5px; POSITION: absolute; TOP: 4px" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<TR>
				<TD>
					<uc1:topmenu id="Topmenu1" runat="server"></uc1:topmenu></TD>
			</TR>
			<TR>
				<TD style="HEIGHT: 36px">
					<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
						<TR>
							<TD style="WIDTH: 168px"><asp:label id="lblFromDate" runat="server" Height="19px" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" Width="159px">From 
Date (mm/dd/yyyy):</asp:label></TD>
							<TD style="WIDTH: 189px"><asp:textbox id="txtFromDate" runat="server" Width="178px"></asp:textbox></TD>
							<TD><INPUT id="btnCloseOut" style="WIDTH: 109px; HEIGHT: 24px" onclick="AssignValues()" type="button" value="Begin Closeout" name="btnCloseOut"></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD style="HEIGHT: 56px">
					<TABLE id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
						<TR>
							<TD style="WIDTH: 167px"><asp:label id="lblToDate" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" Width="159px">To Date 
(mm/dd/yyyy):</asp:label></TD>
							<TD><asp:textbox id="txtToDate" runat="server" Width="177px"></asp:textbox></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD>
					<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
						<TR>
							<TD style="WIDTH: 167px"><asp:label id="lblSub" runat="server" Font-Bold="True">Subcontractor:</asp:label></TD>
							<TD><asp:dropdownlist id="lstSub" runat="server" Width="177px" AutoPostBack="True"></asp:dropdownlist></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
		</TABLE>
	</form>
</HTML>
