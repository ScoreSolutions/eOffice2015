Imports XCS.Data
Imports XCS.Process
Imports System.IO

Partial Class WebApp_frmCRForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Request("id") IsNot Nothing Then
                CreateCRForm(Request("id"))
            End If
        End If
    End Sub

    Private Sub CreateCRForm(ByVal vID As Long)
        Dim para As New Table.IssueTrackingLogData
        Dim eng As New XCS.Process.Common.IssueFormProcess
        Dim trans As New XCS.Process.Common.DbTransProcess
        trans.CreateTransaction()
        If trans.Trans IsNot Nothing Then
            para = eng.GetIssueDataByID(vID, trans)

            Dim mst As New XCS.Process.Master.ProjectFormProcess
            Dim pPara As New Table.ProjectData
            pPara = mst.GetProjectData(para.PROJECT_ID, trans)


            Dim ret As String = ""
            ret += "<table border ='1' cellspacing='0' cellpadding='0' width='800px' >"
            ret += "    <tr>"
            ret += "        <td colspan='8'><img src='../Images/ScoreLogo.gif' border='0' /></td>"
            ret += "    </tr>"
            ret += "    <tr  ><td colspan='8' style='background-color:#000000;height:5px;'></td></tr>"
            ret += "    <tr>"
            ret += "        <td align='center' valign='middle' colspan='5' rowspan='3' ><b>CHANGE REQUEST FORM</b></td>"
            ret += "        <td align='left'><b>CR #</b></td>"
            ret += "        <td align='center' colspan='2' >CR" & para.RAISED_ON.ToString("MMddyy") & para.LOG_NO & "</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td align='left'><b>Project Billing #</b></td>"
            ret += "        <td align='center' colspan='2' >" & pPara.PROJECT_CODE & "</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td align='left'><b>Project Name #</b></td>"
            ret += "        <td align='center' colspan='2' >" & pPara.PROJECT_CODE & "</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td ><b>Originator's Name:</b></td>"
            ret += "        <td colspan='2' >&nbsp;</td>"
            ret += "        <td ><b>Priority:</b></td>"
            ret += "        <td align='center' colspan='4' >" & GetPriority(para.PRIORITY) & "</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td ><b>Functional Area:</b></td>"
            ret += "        <td colspan='2' >" & GetFunctionalArea(para.ID, trans) & "</td>"
            ret += "        <td colspan='2' ><b>Date Raised:</b></td>"
            ret += "        <td align='center' colspan='3' >" & para.RAISED_ON.ToString("MMMM dd,yyyy", New Globalization.CultureInfo("en-US")) & "</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td ><b>Phase/Process:</b></td>"
            ret += "        <td colspan='2' >&nbsp;</td>"
            ret += "        <td colspan='2' ><b>Assigned to:</b></td>"
            ret += "        <td align='center' colspan='3' >" & GetStaffData(para.ASSIGNED_TO, trans).STAFFNAME & "</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td ><b>Client Request?:</b></td>"
            ret += "        <td colspan='2' >&nbsp;</td>"
            ret += "        <td colspan='3' ><b>Date Resolution Required:</b></td>"
            ret += "        <td align='center' colspan='2' >" & para.EXPECTED_CLOSED_DATE.ToString("MMMM dd,yyyy", New Globalization.CultureInfo("en-US")) & "</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td width='140px' >&nbsp;</td>"
            ret += "        <td width='60px' >&nbsp;</td>"
            ret += "        <td width='120px' >&nbsp;</td>"
            ret += "        <td width='80px' >&nbsp;</td>"
            ret += "        <td width='60px' >&nbsp;</td>"
            ret += "        <td width='120px' >&nbsp;</td>"
            ret += "        <td width='100px' >&nbsp;</td>"
            ret += "        <td >&nbsp;</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td colspan='5' align='left' >"
            ret += "            <b>Accepted :</b><br /><br /><br /><br /><b>Date:</b>"
            ret += "        </td>"
            ret += "        <td colspan='3' align='left' >"
            ret += "            <b>Accepted :</b><br /><br /><br /><br /><b>Date:</b>"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr style='Height:50px' valign='top' >"
            ret += "        <td colspan='5' align='left' >"
            ret += "            <b>Completion Verified By:</b>"
            ret += "        </td>"
            ret += "        <td colspan='3' align='left' >"
            ret += "            <b>Completion Date:</b>"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr >"
            ret += "        <td align='left' ><b>Status :</b></td>"
            ret += "        <td colspan='7' align='left' >"
            ret += "            <input type='checkbox' />Open &nbsp;&nbsp;"
            ret += "            <input type='checkbox' />Assigned &nbsp;&nbsp;"
            ret += "            <input type='checkbox' />Investigated &nbsp;&nbsp;"
            ret += "            <input type='checkbox' />Resolved &nbsp;&nbsp;"
            ret += "            <input type='checkbox' />Approved &nbsp;&nbsp;"
            ret += "            <input type='checkbox' />Deferred &nbsp;&nbsp;"
            ret += "            <input type='checkbox' />No Action"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr style='Height:50px' valign='top' >"
            ret += "        <td colspan='8' align='left' >"
            ret += "            <b>Change Details:</b><br />"
            ret += "            " & para.LOG_DESC
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr style='Height:50px' valign='top' >"
            ret += "        <td colspan='8' align='left' >"
            ret += "            <b>Investigation :</b>"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr  >"
            ret += "        <td colspan='8' align='center' >"
            ret += "            <b>Estimate Impact</b>"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td >Effort (man-hour):</td>"
            ret += "        <td colspan='2' >&nbsp;</td>"
            ret += "        <td ><input type='checkbox' />Man-Hour &nbsp;&nbsp;</td>"
            ret += "        <td ><input type='checkbox' />Man-Day &nbsp;&nbsp;</td>"
            ret += "        <td align='right' rowspan='2' valign='top' ><b>Cost(THB)</b></td>"
            ret += "        <td align='center' rowspan='2' colspan='2' >&nbsp;</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td ><b>Schedule:</b></td>"
            ret += "        <td colspan='4' >&nbsp;</td>"
            ret += "    </tr>"
            ret += "    <tr >"
            ret += "        <td colspan='8' align='left' >"
            ret += "            <b>Remarks:</b>" & para.COMMENTS
            ret += "        </td>"
            ret += "    </tr>"

            ret += "    <tr style='Height:50px' valign='top' >"
            ret += "        <td colspan='8' align='left' >"
            ret += "            <b>Posible Action(List Change) :</b>"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr  >"
            ret += "        <td colspan='8' align='center' >"
            ret += "            <b>Actual Impact</b>"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td >Effort (man-hour):</td>"
            ret += "        <td colspan='2' >&nbsp;</td>"
            ret += "        <td ><input type='checkbox' />Man-Hour &nbsp;&nbsp;</td>"
            ret += "        <td ><input type='checkbox' />Man-Day &nbsp;&nbsp;</td>"
            ret += "        <td align='right' rowspan='2' valign='top' ><b>Cost(THB)</b></td>"
            ret += "        <td align='center' rowspan='2' colspan='2' >&nbsp;</td>"
            ret += "    </tr>"
            ret += "    <tr>"
            ret += "        <td ><b>Schedule:</b></td>"
            ret += "        <td colspan='4' >&nbsp;</td>"
            ret += "    </tr>"
            ret += "    <tr >"
            ret += "        <td colspan='8' align='left' >"
            ret += "            <b>Remarks:</b>" & para.COMMENTS
            ret += "        </td>"
            ret += "    </tr>"
            ret += "    <tr style='Height:50px' valign='top' >"
            ret += "        <td colspan='5' align='left' >"
            ret += "            <b>Associated Problem Report:</b>"
            ret += "        </td>"
            ret += "        <td colspan='3' align='left' >"
            ret += "            <b>Associated Risk and Issue Form:</b>"
            ret += "        </td>"
            ret += "    </tr>"
            ret += "</table>"
            trans.CommitTransaction()

            lblCrForm.Text = ret
        End If


    End Sub

    Private Function GetPriority(ByVal vPriority As String) As String
        Dim ret As String = ""
        Select Case vPriority
            Case "L"
                ret = "Low"
            Case "M"
                ret = "Medium"
            Case "H"
                ret = "Height"
        End Select

        Return ret
    End Function

    Private Function GetFunctionalArea(ByVal vLogID As Long, ByVal trans As XCS.DAL.Common.Utilities.TransactionDB) As String
        Dim eng As New XCS.Process.Common.CRFormProcess
        Return eng.GetFunctionalArea(vLogID, trans)
    End Function

    Private Function GetStaffData(ByVal vUserName As String, ByVal trans As XCS.DAL.Common.Utilities.TransactionDB) As XCS.Data.Table.StaffData
        Dim eng As New XCS.Process.Master.StaffFormProcess
        Return eng.GetStaffData(vUserName, trans)
    End Function

    'Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
    '    Response.ClearContent()
    '    Response.Charset = "utf-8"
    '    Response.AddHeader("content-disposition", "attachment;filename=CrForm.xls")
    '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '    Response.ContentType = "application/vnd.xls"
    '    Dim sw As New StringWriter()
    '    Dim htw As New HtmlTextWriter(sw)
    '    Dim frm As New HtmlForm()
    '    frm.Attributes("runat") = "server"
    '    frm.Controls.Add(lblCrForm)
    '    lblCrForm.RenderControl(htw)

    '    Response.Write(sw.ToString())
    '    Response.[End]()
    'End Sub
End Class
