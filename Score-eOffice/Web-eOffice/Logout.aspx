<%
    Session.Abandon()
    Dim changepassword As String = ""
    If Not Request.QueryString("ChangePassword") Is Nothing Then
        changepassword = Request.QueryString("ChangePassword").ToString()
    End If
    Response.Redirect("Login.aspx?ChangePassword=" & changepassword & "")
%>
<form runat="server">
</form>