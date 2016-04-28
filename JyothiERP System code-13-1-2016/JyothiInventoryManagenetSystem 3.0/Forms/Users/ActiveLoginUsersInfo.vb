Public Class ActiveLoginUsersInfo
    Dim SQlStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaduserdata()
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        If CheckBox1.Checked = True Then
            SQlStr = "SELECT [userid], [LoginSystemName] as [System Name],[LoginTime],(case islogin when 'True' then 0 ELSE   LogoutTime END) as [Logout Time], (case islogin when 'True' then 0 ELSE   DATEDIFF(ss,LoginTime,LogoutTime) END) AS [Time in Sec]   FROM [Users] "
        Else
            SQlStr = "SELECT [userid],[LoginSystemName] as [System Name] ,[LoginTime]  FROM [Users] where IsLogin='True'"
        End If


        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 250
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 150
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 150
            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 150


        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        loaduserdata()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        If MsgBox("Do you want to logout the selected User ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        If IsUserAdmin = True Then

            If TxtList.Item("userid", TxtList.CurrentRow.Index).Value = "Admin" Then
                MsgBox("Admin Can't be logout directly.....")
            Else
                Try
                    ExecuteSQLQuery("update users set IsLogin='False',LogoutTime=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "',101) where UserID=N'" & TxtList.Item("userid", TxtList.CurrentRow.Index).Value & "'")
                    loaduserdata()
                Catch ex As Exception

                End Try
            End If

        End If

    End Sub

    Private Sub ActiveLoginUsersInfo_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ActiveLoginUsersInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loaduserdata()
    End Sub
End Class