Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Configuration
Imports XCS.Data.Common
Imports XCS.Process.Master
Imports System.Xml.Serialization
Imports System.IO
Imports System
Imports XCS.Process.Common



Public Class Func

    Public Shared Function GetUserName() As String
        Dim p As New Page
        Return p.User.Identity.Name.Trim
    End Function
    Public Shared Function ChkLogin() As Boolean
        Dim User As LoggedOnStaffData = GetLogOnUser()
        Return (User.STAFFNAME.Trim <> "")
    End Function

    Public Shared Function GetLogOnUser() As LoggedOnStaffData
        Dim ret As New LoggedOnStaffData
        Try
            Dim id As FormsIdentity = HttpContext.Current.User.Identity
            Dim tik As FormsAuthenticationTicket = id.Ticket
            Dim sr As New XmlSerializer(GetType(LoggedOnStaffData))
            Dim st As New MemoryStream(Convert.FromBase64String(tik.UserData))
            ret = sr.Deserialize(st)
        Catch ex As Exception

        End Try

        Return ret
    End Function

    Public Shared Function GetConfigValue(ByVal configName As String, ByVal trans As DbTransProcess) As String
        Dim Proc As New FunctionProcess
        Return Proc.GetConfigValue(configName, trans)
    End Function


    Public Shared Sub SetAlert(ByVal msg As String, ByVal frm As Page, ByVal txtClientID As String)
        Dim popupScript = "<script language='javascript'> " & _
        " alert('" & msg & "'); " & _
        " document.getElementById('" & txtClientID & "').select();" & _
        " </script>"
        ScriptManager.RegisterStartupScript(frm, GetType(String), "SetAlert1", popupScript, False)
    End Sub

    Public Shared Sub SetAlert(ByVal msg As String, ByVal frm As Page)
        Dim popupScript = "<script language='javascript'> " & _
        " alert('" & msg & "'); " & _
        " </script>"
        ScriptManager.RegisterStartupScript(frm, GetType(String), "SetAlert1", popupScript, False)
    End Sub

    Public Shared Function GetUploadPath() As String
        Return ConfigurationSettings.AppSettings("UploadPath").ToString
    End Function
    Public Shared Function GetImageUrl(ByVal req As HttpRequest) As String
        Return req.Url.Host & ConfigurationSettings.AppSettings("UploadURL").ToString
    End Function

End Class
