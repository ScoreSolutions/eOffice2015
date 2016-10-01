﻿<%@ Page Language="C#" MasterPageFile="Layout.Master" AutoEventWireup="true" CodeBehind="frmpop3.aspx.cs" Inherits="CScharpDemo.frmPop3" %>

		<asp:Content runat="server" ContentPlaceHolderID="container">
            <h1>ActiveXperts Email Component - ASP .NET C# POP3</h1>
			<hr />
			<p>
				In computing, the Post Office Protocol (POP) is an application-layer Internet standard protocol used by local e-mail clients to retrieve e-mail from a remote server over a TCP/IP connection and uses TCP port 110 by default.<br />
				For more details about using ActiveXperts Email Component with ASP .NET, <a href="http://www.activexperts.com/support/kb/index.asp?productcode=004&idcategory=464"
					target="_blank">click here</a>.<br />
			</p>
			<form id="form1" runat="server">
				<h2>Component:</h2>
				<h3><asp:Label ID="lblInfo" runat="server" CssClass="FullWidth"></asp:Label></h3>
				
				<!-- Host, Secure -->
				<asp:Label ID="lblHost" runat="server" Text="POP3 Host:"></asp:Label>
				<p>
					<asp:TextBox ID="txtHost" runat="server">pop3.mycompany.com</asp:TextBox>
					<asp:CheckBox ID="cbSecure" runat="server" CssClass="cbFix" Text=" Secure" />
				</p>
				
				<!-- Account -->
				<asp:Label ID="lblAccount" runat="server" Text="POP3 Account:"></asp:Label>
				<p>
					<asp:TextBox ID="txtAccount" runat="server">user@mycompany.com</asp:TextBox>
				</p>
				
				<!-- Password -->
				<asp:Label ID="lblPassword" runat="server" Text="POP3 Password:"></asp:Label>
				<p>
					<asp:TextBox ID="txtPassword" runat="server" TextMode="Password">secret</asp:TextBox>
				</p>
				
				<!-- Empty row -->
				<div class="clearRow"></div>
				
				
				<!-- List Messages button -->
				<div class="clearLabel"></div>
				<p>
					<asp:Button ID="btnListMessages" runat="server" Text="List Messages" 
						onclick="btnSendMessage_Click" />
				</p>
				
				<!-- Messages Listbox -->
				<asp:Label ID="lblMessagesReceived" runat="server" Text="Messages received:"></asp:Label>
				<p>
					<asp:ListBox ID="lvMessages" runat="server" CssClass="FullWidth" Rows="10"></asp:ListBox>
				</p>
				
				 <!-- Result -->
				<asp:Label ID="lblResult" runat="server" Font-Bold="true" Text="Result:"></asp:Label>
				<p>
					<asp:TextBox ID="txtResult" runat="server" CssClass="FullWidth Bold"></asp:TextBox>
				</p>
				
				<!-- Log File-->
				<asp:Label ID="lblLogFile" runat="server" Text="Logfile:"></asp:Label>
				<p>
				    <asp:TextBox ID="txtLogFile" runat="server" CssClass="FullWidth"></asp:TextBox>
				</p>
			</form>
			<p>
				This demo uses the ActiveXperts Email Component, an <a href="http://www.activexperts.com" target="_blank">ActiveXperts Software</a> product.<br />
				<a href="Default.aspx">Back to main page</a> 
			</p>
		</asp:Content>