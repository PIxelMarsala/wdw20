<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Logon.aspx.vb" Inherits="wdw.Logon" %>
<%@ Register TagPrefix="uc1" TagName="topmenu" Src="controls/topmenu.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<script language="javascript">
//This function does initial cursor positioning
function onload()
{
	document.all("txtUserId").focus();
}
</script>
<HTML>
	<HEAD>
		<title>We Do Windows - User Logon</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body onload="onload()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="#003366" height="30"><FONT color="#ffffff" size="4"><STRONG>&nbsp;User Logon</STRONG></FONT></TD>
				</TR>
			</TABLE>
			<TABLE id="Table4" style="WIDTH: 948px; HEIGHT: 33px" height="33" cellSpacing="0" cellPadding="0" width="948" border="0">
				<TR>
					<TD>
						<P>
							&nbsp;Please select a Company,&nbsp;and enter your&nbsp;User Id and Password.
						</P>
                        <asp:Literal ID="litDevWarning" runat="server"></asp:Literal>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="WIDTH: 948px; HEIGHT: 34px" height="34" cellSpacing="3" cellPadding="3" width="948" border="0">
				<TR>
					<TD style="WIDTH: 128px; HEIGHT: 19px">Company:</TD>
					<TD style="HEIGHT: 19px">
						<asp:DropDownList id="lstCompany" runat="server" Width="160px"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px; HEIGHT: 19px">User Id:</TD>
					<TD style="HEIGHT: 19px">
						<asp:TextBox id="txtUserId" runat="server" MaxLength="20"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="1px" ErrorMessage="Operator Id" ControlToValidate="txtUserId" Display="Dynamic">*</asp:RequiredFieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Password:</TD>
					<TD>
						<asp:TextBox id="txtPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Password" ControlToValidate="txtPassword" Display="Dynamic">*</asp:RequiredFieldValidator></TD>
				</TR>
			</TABLE>
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 206px; HEIGHT: 20px"></TD>
					<TD style="WIDTH: 353px; HEIGHT: 20px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 206px; HEIGHT: 102px">
						<asp:Label id="MismatchLabel" runat="server" Width="395px" ForeColor="Red" Visible="False">Please Reenter Company, User Id, Password</asp:Label>
						<asp:ValidationSummary id="LogonValidationSummary" runat="server" Width="303px" Height="47px" HeaderText="Please enter a value in the required field(s)."></asp:ValidationSummary>
					</TD>
					<TD style="WIDTH: 353px; HEIGHT: 102px"></TD>
				</TR>
			</TABLE>
			<TABLE id="Table6" cellSpacing="3" cellPadding="3" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 180px"></TD>
					<TD>
						<asp:Button id="LogonButton" runat="server" Text="Logon"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
