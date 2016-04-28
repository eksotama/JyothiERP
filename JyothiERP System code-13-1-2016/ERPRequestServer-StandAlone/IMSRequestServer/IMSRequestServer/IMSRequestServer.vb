Public Class IMSServerForm
    Public ConnStr As String = ""
    Public IMServer As New IMSServerClass
    Public SqlFcmd As New SqlClient.SqlCommand
    Dim SqlConnTrans As New SqlClient.SqlConnection
    Dim SqlConnIMSServer As New SqlClient.SqlConnection
    Public Function GETIMSServerValues(ByVal SQLStr As String) As IMSServerClass
        Dim Retvalue As New IMSServerClass
        Try

            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConnIMSServer)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue.IMSServerReq.RequestSystemName = TBD.Tables(0).Rows(0).Item("ReqSystemName").ToString.Trim
                Retvalue.IMSServerReq.RequestID = CSng(TBD.Tables(0).Rows(0).Item("ReqNo"))
            Else
                Retvalue.IMSServerReq.RequestSystemName = ""
            End If
            Adapter.Dispose()
            TBD.Dispose()
        Catch ex As Exception
            Retvalue.IMSServerReq.RequestSystemName = ""
        Finally
          
        End Try
        Return Retvalue
    End Function
    Public Function SQLGetStringFieldValue(ByVal SQLStr As String, ByVal GetFieldName As String, Optional ByVal DefReturn As String = "") As String
        Dim Retvalue As String

        Try
        
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConnTrans)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
            Else
                Retvalue = DefReturn
            End If
            Adapter.Dispose()
            TBD.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = DefReturn
        Finally
           
        End Try
        Return Retvalue
    End Function
    Public Sub LoadLockTrans()

        Try
            Dim SqlStr As String = ""
            SqlStr = "SELECT [TransCode],[UserName],[SystemName],[Details],[TransDate]  FROM [LockTrans]"
            Dim TempBS As New BindingSource
            With Me.TxtLockList
                TempBS.DataSource = SQLLoadGridData(SqlStr)
                .AutoGenerateColumns = True
                .DataSource = TempBS
            End With
            TxtLockList.Columns(0).Width = 80
            TxtLockList.Columns(1).Width = 150
            TxtLockList.Columns(2).Width = 150
            TxtLockList.Columns(3).Width = 200
            TxtLockList.Columns(4).Width = 100
        Catch ex As Exception

        End Try
      

    End Sub
    Public Function ExecuteSQLQuery(ByVal SQLInsertString As String) As Boolean
        Dim err As Boolean = True

        Try
           
            SqlFcmd.Connection = SqlConnTrans
            SqlFcmd.CommandText = SQLInsertString
            SqlFcmd.CommandType = CommandType.Text
            SqlFcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            err = False
        Finally
            SqlFcmd.Connection = Nothing
        End Try
        Return err
    End Function
    Sub LoadReqList()
        Dim SqlStr As String = ""
        SqlStr = "SELECT [UserName],[ReqSystemName],[ReqNo],[Status]  FROM [Request]"
        Dim TempBS As New BindingSource
        With Me.TxtReqlist
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TxtReqlist.Columns(0).Width = 180
            TxtReqlist.Columns(2).Width = 250
            TxtReqlist.Columns(3).Width = 100
        Catch ex As Exception

        End Try
    End Sub
    Public Function SQLLoadGridData(ByVal SQLStr As String) As DataTable
        Dim TBD As New DataTable
        Try
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConnTrans)
            TBD.Locale = System.Globalization.CultureInfo.InvariantCulture
            Adapter.Fill(TBD)
            Adapter.Dispose()
        Catch ex As Exception
            TxtErrorStatus.Text = ex.Message
        Finally
            SqlFcmd.Connection = Nothing
        End Try

        Return TBD
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static IsReqStarted As Boolean = False
        Static sT As String = ""
        Static Count As Single = 0
        Count = Count + 1
        LoadReqList()
        If Count > 999999999 Then
            Count = 1
        End If
        If IsReqStarted = False Then

            IMServer = GETIMSServerValues("SELECT * FROM REQUEST  ORDER BY ReqNo")
            TxtStatus.Text = "Server is in idle...."
            If IMServer.IMSServerReq.RequestSystemName.Length > 0 Then
                ExecuteSQLQuery("UPDATE REQUEST SET Status='R' WHERE ReqSystemName='" & IMServer.IMSServerReq.RequestSystemName & "' AND REQNO=" & IMServer.IMSServerReq.RequestID)
                TxtStatus.Text = "REQUEST PROCESSING FOR  " & IMServer.IMSServerReq.RequestSystemName & " AND Req ID=" & IMServer.IMSServerReq.RequestID
                IsReqStarted = True
                Count = 1
            End If
        Else

            sT = SQLGetStringFieldValue("SELECT * FROM REQUEST WHERE ReqSystemName='" & IMServer.IMSServerReq.RequestSystemName & "' AND REQNO=" & IMServer.IMSServerReq.RequestID, "Status")
            If sT = "C" Or sT = "" Then
                ExecuteSQLQuery("DELETE FROM REQUEST  WHERE ReqSystemName='" & IMServer.IMSServerReq.RequestSystemName & "' AND REQNO=" & IMServer.IMSServerReq.RequestID)
                IsReqStarted = False

                Count = 1
            ElseIf Count > 25 Then
                ExecuteSQLQuery("DELETE FROM REQUEST  WHERE ReqSystemName='" & IMServer.IMSServerReq.RequestSystemName & "' AND REQNO=" & IMServer.IMSServerReq.RequestID)
                IsReqStarted = False

                Count = 1
            End If
        End If
    End Sub
    Private Sub Form1_MinimumSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MinimumSizeChanged
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                JyothiERPServer.BalloonTipText = "ERP Server is minimized"
                JyothiERPServer.ShowBalloonTip(12)
                JyothiERPServer.Visible = False
                Me.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles JyothiERPServer.Click
        Try

            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            Me.BringToFront()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub IMSServerForm_Load() Handles Me.Load
        ConnStr = ""
        GetSQLSettingFromFile()
        If ConnectionStrinG.Contains("&") = True Then
            End
        End If
        ConnStr = ConnectionStrinG
        
        If AdminLogin.ShowDialog() <> DialogResult.OK Then
            End
        End If
        ConnectionStrinG = ConnStr & " Initial Catalog=" & TxtSoftwareSQLDatabaseName & ";"
        ConnStr = ConnectionStrinG
        SqlConnIMSServer.ConnectionString = ConnStr
        SqlConnIMSServer.Open()

        SqlConnTrans.ConnectionString = ConnStr
        SqlConnTrans.Open()
        Me.Text = Me.Text & " - " & SQLGetStringFieldValue("select * from company", "companyname")
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LoadLockTrans()
    End Sub

    Private Sub BtnRelese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRelese.Click
        If TxtLockList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox("Relase the Lock for selected transaction....", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("DELETE  FROM LockTrans WHERE TransCode=" & TxtLockList.Item(0, TxtLockList.CurrentRow.Index).Value)
            LoadLockTrans()
        End If
    End Sub



    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        LoadLockTrans()
        loaduserdata()
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles JyothiERPServer.DoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub
    Sub loaduserdata()
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Dim SqlStr As String = ""
        Me.Cursor = Cursors.WaitCursor
        SqlStr = "SELECT [userid],[LoginSystemName] as [System Name] ,[LoginTime]  FROM [Users] where IsLogin='True'"

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        loaduserdata()
    End Sub

   
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        Try
            If MsgBox("Do you want to logout the selected User ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If TxtList.Item("userid", TxtList.CurrentRow.Index).Value = "Admin" Then
                MsgBox("Admin Can't be logout directly.....")
            Else
                Try
                    ExecuteSQLQuery("update users set IsLogin='False',LogoutTime=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd hh:mm:ss") & "',101) where UserID=N'" & TxtList.Item("userid", TxtList.CurrentRow.Index).Value & "'")
                    loaduserdata()
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Do you want to Close the Server ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
            End
        End If
    End Sub
End Class
