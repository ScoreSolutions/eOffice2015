Imports System.Data
Imports LinqDB.ConnectDB

Partial Class Controls_ucLeftMainMenu
    Inherits System.Web.UI.UserControl

#Region "Declare Class & Variable"
    Private dtMenu As DataTable
    Private dvMainMenu, dvMinorMenu, dvSubMenu, dvSubSubMenu As DataView
    Private strDefaultImageCssName As String = "icon-folder-close"
    Private strNavigateURL, strScreenName, strImageCssName, strLinkExternal As String
    Private intRowID As Long
    Protected strside_accordion As String
#End Region

#Region "Declare Property"


    Private ReadOnly Property ppRowIDMenu() As Integer
        Get
            Return Val(Request.Params("RowIDMenu") & "")
        End Get
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RenderMenu()
    End Sub

#Region "Render Menu"
    Private Sub RenderMenu() 'เมนูรองรับมากสุด 4 level
        Try

            Dim strSql As New StringBuilder
            strSql.Append(" SELECT	Screen.RowID,")
            strSql.Append(" Screen.RowID_M_Module,")
            strSql.Append(" Screen.RowID_M_SubModule,")
            strSql.Append(" isnull(Module.ModuleName,'') ModuleName,")
            strSql.Append(" isnull(SubModule.Name,'') SubModuleName,")
            strSql.Append(" isnull(Screen.RowID_RootMenu,0)RowID_RootMenu,")
            strSql.Append(" isnull(Screen.RowID_ParentMenu,0)RowID_ParentMenu,")
            strSql.Append(" isnull(Screen.RowID_SubParentMenu,0)RowID_SubParentMenu,")
            strSql.Append(" Screen.Sequence,")
            strSql.Append(" Screen.ScreenName,")
            strSql.Append(" Screen.ScreenID,")
            strSql.Append(" isnull(Screen.IsMenu,0) IsMenu,")
            strSql.Append(" Screen.NavigateURL,")
            strSql.Append(" Screen.Remark,")
            strSql.Append(" Screen.ImageURL,")
            strSql.Append("(select COUNT(RowID) from M_Screen where (RowID_RootMenu=Screen.RowID or RowID_ParentMenu=Screen.RowID  or  RowID_SubParentMenu  =Screen.RowID ) ) as LevelCheck")
            strSql.Append(" FROM M_Screen Screen")
            strSql.Append(" LEFT JOIN M_Module Module")
            strSql.Append(" ON Module.RowID = Screen.RowID_M_Module")
            strSql.Append(" LEFT JOIN M_SubModule SubModule")
            strSql.Append(" ON SubModule.RowID = Screen.RowID_M_SubModule")

            dtMenu = SqlDB.ExecuteTable(strSql.ToString)


            Dim strMenu As New StringBuilder

            dvMainMenu = dtMenu.Copy.DefaultView
            dvMainMenu.RowFilter = "RowId_RootMenu = 0"
            dvMainMenu.Sort = "Sequence"
            strMenu.Append("<ul class=""nav nav-list"">")

            For i As Integer = 0 To dvMainMenu.Count - 1

                Select Case dvMainMenu(i)("LevelCheck") & ""
                    Case 0 'กรณีมี Root เดียว
                        'Level 1
                        strScreenName = dvMainMenu(i)("ScreenName") & ""
                        strNavigateURL = dvMainMenu(i)("NavigateUrl") & "?RowIDMenu=" & dvMainMenu(i)("RowID")
                        strImageCssName = dvMainMenu(i)("ImageURL") & ""

                        strMenu.Append("<li " & IIf(dvMainMenu(i)("RowID") = ppRowIDMenu, "class=""active""", "") & " >")
                        strMenu.Append("<a href=" & IIf(strNavigateURL <> "", strNavigateURL, "#") & " >")
                        strMenu.Append("<i class=" & strImageCssName & "></i>")
                        strMenu.Append("<span class=""menu-text"">" & strScreenName & " </span>")
                        strMenu.Append("</li>")
                    Case Else 'กรณีมีหลาย Root 
                        'Level 1
                        strScreenName = dvMainMenu(i)("ScreenName") & ""
                        strNavigateURL = dvMainMenu(i)("NavigateUrl") & "?RowIDMenu=" & dvMainMenu(i)("RowID")
                        strImageCssName = dvMainMenu(i)("ImageURL") & ""

                        strMenu.Append("<li " & IIf(dvMainMenu(i)("RowID") = ppRowIDMenu, "class=""active""", "") & " >")
                        ' strMenu.Append("<li>")
                        strMenu.Append("<a href=""#"" class=""dropdown-toggle"">")
                        strMenu.Append("<i class=" & strImageCssName & "></i>")
                        strMenu.Append("<span class=""menu-text"">" & strScreenName & " </span>")
                        strMenu.Append("<b class=""arrow icon-angle-down""></b>")
                        strMenu.Append("</a>")
                        'Level 2
                        dvMinorMenu = dtMenu.Copy.DefaultView
                        dvMinorMenu.RowFilter = "RowId_ParentMenu = 0  AND RowId_RootMenu = " & dvMainMenu(i)("RowId")
                        dvMinorMenu.Sort = "Sequence"
                        If dvMinorMenu.Count > 0 Then
                            strMenu.Append("<ul class=""submenu"">")
                            For j As Integer = 0 To dvMinorMenu.Count - 1 'Level 2
                                intRowID = dvMinorMenu(j)("RowID")
                                strScreenName = dvMinorMenu(j)("ScreenName") & ""
                                strNavigateURL = dvMinorMenu(j)("NavigateUrl") & "?RowIDMenu=" & dvMainMenu(i)("RowID")
                                strImageCssName = dvMinorMenu(j)("ImageURL") & ""

                                dvSubMenu = dtMenu.Copy.DefaultView
                                dvSubMenu.RowFilter = "RowId_SubParentMenu=0 AND RowId_RootMenu = " & dvMinorMenu(j)("RowId_RootMenu") & " AND RowId_ParentMenu = " & intRowID
                                dvSubMenu.Sort = "Sequence"
                                If dvSubMenu.Count > 0 Then


                                    strMenu.Append("<li>")
                                    strMenu.Append("<a href=""#"" class=""dropdown-toggle"">")
                                    strMenu.Append("<i class=""icon-double-angle-right""></i>")
                                    strMenu.Append(strScreenName)
                                    strMenu.Append("<b class=""arrow icon-angle-down""></b>")
                                    strMenu.Append("</a>")
                                    strMenu.Append("<ul class=""submenu"">")
                                    For k As Integer = 0 To dvSubMenu.Count - 1   ' Level 3

                                        intRowID = dvSubMenu(k)("RowID")
                                        strScreenName = dvSubMenu(k)("ScreenName") & ""
                                        strNavigateURL = dvSubMenu(k)("NavigateUrl") & "?RowIDMenu=" & dvMainMenu(i)("RowID")
                                        strImageCssName = dvSubMenu(k)("ImageURL") & ""
                                        dvSubSubMenu = dtMenu.Copy.DefaultView
                                        dvSubSubMenu.RowFilter = "RowId_RootMenu = " & dvSubMenu(k)("RowId_RootMenu") & " AND RowId_ParentMenu=" & dvSubMenu(k)("RowId_ParentMenu") & "  AND RowId_SubParentMenu = " & intRowID
                                        dvSubSubMenu.Sort = "Sequence"
                                        If dvSubSubMenu.Count > 0 Then
                                            strMenu.Append("<li>")
                                            strMenu.Append("<a href=""#"" class=""dropdown-toggle"">")
                                            strMenu.Append("<i class=" & strImageCssName & "></i>")
                                            strMenu.Append(strScreenName)
                                            strMenu.Append("<b class=""arrow icon-angle-down""></b>")
                                            strMenu.Append("</a>")
                                            strMenu.Append("<ul class=""submenu"">")
                                            For L As Integer = 0 To dvSubSubMenu.Count - 1 ' Level 4
                                                strScreenName = dvSubSubMenu(L)("ScreenName") & ""
                                                strNavigateURL = dvSubSubMenu(L)("NavigateUrl") & "?RowIDMenu=" & dvMainMenu(i)("RowID")
                                                strImageCssName = dvSubSubMenu(L)("ImageURL") & ""

                                                ' strMenu.Append("<li " & IIf(dvSubSubMenu(L)("RowID") = ppRowIDMenu, "class=""active""", "") & " >")
                                                strMenu.Append("<li>")
                                                strMenu.Append("<a href=" & IIf(strNavigateURL <> "", strNavigateURL, "#") & " >")
                                                strMenu.Append("<i class=" & strImageCssName & "></i>")
                                                strMenu.Append(strScreenName)
                                                strMenu.Append("</a>")
                                                strMenu.Append("</li>")

                                            Next
                                            strMenu.Append("</ul>")
                                            strMenu.Append("</li>")
                                        Else
                                            ' strMenu.Append("<li " & IIf(dvSubMenu(k)("RowID") = ppRowIDMenu, "class=""active""", "") & " >")
                                            strMenu.Append("<li>")
                                            strMenu.Append("<a href=" & IIf(strNavigateURL <> "", strNavigateURL, "#") & " >")
                                            strMenu.Append("<i class=" & strImageCssName & "></i>")
                                            strMenu.Append(strScreenName)
                                            strMenu.Append("</a>")
                                            strMenu.Append("</li>")
                                        End If


                                    Next
                                    strMenu.Append("</ul>")
                                    strMenu.Append("</li>")

                                Else

                                    strMenu.Append("<li " & IIf(dvMinorMenu(j)("RowID") = ppRowIDMenu, "class=""active""", "") & " >")
                                    strMenu.Append("<a href=" & IIf(strNavigateURL <> "", strNavigateURL, "#") & " >")
                                    strMenu.Append("<i class=" & strImageCssName & "></i>")
                                    strMenu.Append(strScreenName)
                                    strMenu.Append("</a>")
                                    strMenu.Append("</li>")
                                End If


                            Next
                            strMenu.Append("</ul>")
                        End If
                        strMenu.Append("</li>")
                End Select
            Next
            strMenu.Append("</ul>")

            strside_accordion = strMenu.ToString
        Catch ex As Exception
            ex.Message.ToString()
        End Try
    End Sub
#End Region



#Region "Get Datatable Menu"

#End Region

End Class
