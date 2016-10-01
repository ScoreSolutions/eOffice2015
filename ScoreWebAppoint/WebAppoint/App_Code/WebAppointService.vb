Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebAppointService
    Inherits System.Web.Services.WebService

#Region "Action Table Demo"

    <WebMethod()> _
    Public Function LoadPerson(ByVal RowID As Integer) As Boolean
        Return True
    End Function

    <WebMethod()> _
    Public Function DeleteDemo(ByVal RowID As String) As Boolean
        Try

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()> _
    Public Function SaveDemo(ByVal RowID As Long, _
                                 ByVal strNameTH As String, _
                                 ByVal strDescription As String, _
                                 ByVal strUpdateBy As String) As Long
        Try

            Return RowID

        Catch ex As Exception
            Return 0
        End Try
    End Function
#End Region

End Class