<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="Layout.Master" CodeBehind="Default.aspx.vb" Inherits="VisualBasicDemo._Default" %>

		<asp:Content runat="server" ContentPlaceHolderID="container">
            <h1>ActiveXperts Email Component - ASP .NET VB</h1>
			<hr />
			<p>ActiveXperts Email Component can also be used client-side (i.e. connected to the client's PC).
			 There's an HTML sample included with the product.<br />
			 For more details, <a href="http://www.activexperts.com/support/kb/index.asp?productcode=004&idcategory=457" target="_blank">click here</a>.
			</p>
			<div class="content">
				<h1>Table of contents</h1>				
				<button onclick="window.location='frmsmtp.aspx'" 
					class="Button" type="button">SMTP Send</button>
				
				<button onclick="window.location='frmpop3.aspx'" 
					class="Button" type="button">POP3 Receive</button>
			</div>
			<p>
				This demo uses the ActiveXperts Email Component, an <a href="http://www.activexperts.com" target="_blank">ActiveXperts Software</a> product.
			</p>
		</asp:Content>