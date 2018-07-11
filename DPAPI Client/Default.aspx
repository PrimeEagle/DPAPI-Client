<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="DPAPIClient.Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnDecryptConfig" style="Z-INDEX: 110; LEFT: 64px; POSITION: absolute; TOP: 296px"
				runat="server" Text="Decrypt String from Config File"></asp:Button>
			<asp:Label id="lblError" style="Z-INDEX: 109; LEFT: 249px; POSITION: absolute; TOP: 267px"
				runat="server" ForeColor="Red"></asp:Label>
			<asp:Button id="btnDecrypt" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 263px"
				runat="server" Text="Decrypt"></asp:Button>
			<asp:Button id="btnEncrypt" style="Z-INDEX: 107; LEFT: 60px; POSITION: absolute; TOP: 261px"
				runat="server" Text="Encrypt"></asp:Button>
			<asp:Label id="Label3" style="Z-INDEX: 106; LEFT: 62px; POSITION: absolute; TOP: 204px" runat="server">Decrypted Data</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 60px; POSITION: absolute; TOP: 150px" runat="server">Encrypted Data</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 62px; POSITION: absolute; TOP: 94px" runat="server">Data to Encrypt</asp:Label>
			<asp:TextBox id="txtDataToEncrypt" style="Z-INDEX: 101; LEFT: 59px; POSITION: absolute; TOP: 115px"
				runat="server" Width="614px"></asp:TextBox>
			<asp:TextBox id="txtEncryptedData" style="Z-INDEX: 102; LEFT: 59px; POSITION: absolute; TOP: 170px"
				runat="server" Width="614px"></asp:TextBox>
			<asp:TextBox id="txtDecryptedData" style="Z-INDEX: 103; LEFT: 59px; POSITION: absolute; TOP: 221px"
				runat="server" Width="614px"></asp:TextBox>
		</form>
	</body>
</HTML>
