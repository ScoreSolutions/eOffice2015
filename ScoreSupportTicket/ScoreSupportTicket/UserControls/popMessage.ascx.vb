
Partial Class UserControl_popMessage
    Inherits System.Web.UI.UserControl

    Public Event OnOKClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event OnCancelClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event OnYesClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event OnNoClick(ByVal sender As Object, ByVal e As EventArgs)

    Dim _txtFocus As Object

    Public Property TxtFocus() As Object
        Get
            Return _txtFocus
        End Get
        Set(ByVal value As Object)
            _txtFocus = value
        End Set
    End Property

    Public Sub ShowMessage(ByVal MessageType As MsgType, ByVal MsgText As String, ByVal TitleText As String)
        lblMessage.Text = MsgText
        lblPopupName.Text = TitleText

        If MessageType = MsgType.Exclamation Then
            btnOK.Visible = True
            imgIcon.ImageUrl = "~/Images/icon_exclamation.gif"
        ElseIf MessageType = MsgType.Information Then
            btnOK.Visible = True
            imgIcon.ImageUrl = "~/Images/icon_information.jpg"
        ElseIf MessageType = MsgType.Question Then
            btnOK.Visible = True
            btnCancel.Visible = True
            imgIcon.ImageUrl = "~/Images/icon_question.jpg"
        End If
        popMessage.Show()
    End Sub

    Public Enum MsgType
        Information = 1
        Exclamation = 2
        Question = 3
    End Enum

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        RaiseEvent OnOKClick(sender, e)
        'popMessage.Hide()
    End Sub

    Public Sub Hide()
        popMessage.Hide()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        RaiseEvent OnCancelClick(sender, e)
    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        RaiseEvent OnYesClick(sender, e)
    End Sub

    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.Click
        RaiseEvent OnNoClick(sender, e)
    End Sub
End Class
