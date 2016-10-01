Imports XCS.Process.Common
Imports System.Web.Security

Imports System.Xml.Serialization
Imports System.IO
Imports XCS.Data.Table
Imports XCS.Data.Common
Imports XCS.Data.Common.Utilities

Partial Class WebApp_frmLogin
    Inherits System.Web.UI.Page

    Dim SerialUserData As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Dim frm As Template_LoginMasterPage
            frm = Me.Master
            frm.SetPageName("Login Page")

            HttpContext.Current.Response.Cookies.Clear()
            FormsAuthentication.SignOut()

            TextBox1.Text = Server.MapPath(Request.FilePath)
        End If
    End Sub

    Private Sub ShowError(ByVal err As String)
        lblError.Text = err
        tbError.Visible = True
        zPop.Show()
    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate

        Dim uProc As New LoginProcess
        e.Authenticated = uProc.Login(Login1.UserName, Login1.Password)
        If (e.Authenticated = False) Then
            ShowError(uProc.ErrorMessage)
        Else


            SerialUserData = ""
            Dim sData As StaffData = uProc.GetStaffData()



            Dim lData As New LoggedOnStaffData


            lData.ID = sData.ID
            lData.CREATE_BY = sData.CREATE_BY
            lData.CREATE_ON = sData.CREATE_ON
            lData.UPDATE_BY = sData.UPDATE_BY
            lData.UPDATE_ON = sData.UPDATE_ON
            lData.USERNAME = sData.USERNAME
            lData.PWD = sData.PWD
            lData.STAFFNAME = sData.STAFFNAME
            lData.POSITION_NAME = sData.POSITION_NAME
            lData.DIVISION_NAME = sData.DIVISION_NAME
            lData.CAN_RAISE = sData.CAN_RAISE
            lData.CAN_ACCEPT_ASSIGNMENT = sData.CAN_ACCEPT_ASSIGNMENT
            lData.CAN_CLOSE = sData.CAN_CLOSE
            lData.ACTIVE = sData.ACTIVE

            Dim sr As New XmlSerializer(GetType(LoggedOnStaffData))
            Dim st As New MemoryStream()
            sr.Serialize(st, lData)
            Dim b() As Byte = st.GetBuffer()
            SerialUserData = Convert.ToBase64String(b)
        End If

    End Sub

    Protected Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn
        HttpContext.Current.Response.Cookies.Clear()
        Dim fat As New FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddDays(1), True, SerialUserData)
        Dim ck As New HttpCookie(".LOGTRACKING")
        ck.Value = FormsAuthentication.Encrypt(fat)
        ck.Expires = fat.Expiration
        HttpContext.Current.Response.Cookies.Add(ck)

        If Request("ReturnUrl") Is Nothing Or Request("ReturnUrl") = "" Then
            Response.Redirect(FormsAuthentication.DefaultUrl & "?time=" & Today.Now.Millisecond)
        Else
            Response.Redirect(Request("ReturnUrl"))
        End If
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        zPop.Hide()
        Button1.Enabled = True
    End Sub

    Protected Sub Login1_LoginError(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoginError

    End Sub
End Class
