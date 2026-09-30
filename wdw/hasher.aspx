<%@ Page Language="vb" AutoEventWireup="false" Codebehind="hasher.aspx.vb" Inherits="hasher"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>hasher</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="css/wdw.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="#003366" height="30"><FONT color="#ffffff" size="4"><STRONG>Password&nbsp;Hasher</STRONG></FONT></TD>
				</TR>
			</TABLE>
			<TABLE id="Table4" style="WIDTH: 948px; HEIGHT: 33px" height="33" cellSpacing="0" cellPadding="0"
				width="948" border="0">
				<TR>
					<TD>
						<P>
							This form has a dual purpose.
						</P>
						<P>1). Calculates a one-way hash. This is how WDW manages user passwords (hash it).<BR>
							This employs a one-way hash algorithm. This feature is for testing only.<BR>
							2). Calculates a database password using 3DES. This enrypted password is stored<BR>
							in the WDW Web.config file and decrypted at run time to access the database. 
							Should<BR>
							the Service Provider ever change the database user id and or password, then it<BR>
							must be stored encrypted in the web.config file.</P>
						<P>Please supply desired password&nbsp;and select "Hash It" or "Encrypt It". 
							"Decrypt It" is
							<BR>
							used to take and encrypted password and decrypt it to plain text.<BR>
						</P>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="WIDTH: 948px; HEIGHT: 34px" height="34" cellSpacing="3" cellPadding="3"
				width="948" border="0">
				<TR>
					<TD style="WIDTH: 142px; HEIGHT: 19px">Password:</TD>
					<TD style="HEIGHT: 19px">
						<asp:TextBox id="txtPassword" runat="server" MaxLength="20" Width="516px" Height="122px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 142px; HEIGHT: 19px">Hashed/Encrypted Password:</TD>
					<TD style="HEIGHT: 19px">
						<asp:TextBox id="txtHashed" runat="server" MaxLength="20" Width="517px" Height="139px"></asp:TextBox></TD>
				</TR>
			</TABLE>
			<TABLE id="Table6" cellSpacing="3" cellPadding="3" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 180px"></TD>
					<TD>
						<P>
							<asp:Button id="hash" runat="server" Text="Hash It"></asp:Button>
							<asp:Button id="btnEncrypt" runat="server" Text="Encrypt It"></asp:Button>
							<asp:Button id="btnDecrypt" runat="server" Text="Decrypt It"></asp:Button></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
