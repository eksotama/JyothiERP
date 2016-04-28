Imports System.Data.SqlClient
Imports System.Xml

Public Class backupdatabase
    Dim cmd As SqlCommand
    Dim dread As SqlDataReader
    Private Sub cmbbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBackup.Click


        SaveFileDialog1.FileName = TxtSoftwareSQLDatabaseName & "-" & CompDetails.CompanyName & "-" & Now.ToString("yyyy-MMM-dd hh-mm-ss") & "-"
        If SaveFileDialog1.ShowDialog() = vbOK Then
            Try
                MainForm.Cursor = Cursors.WaitCursor
                My.Application.DoEvents()
                ImSlabel1.Text = ""
                Lbl.Text = "Backup in Progress..., It may take several mins depend on size"
                Timer1.Enabled = True
                ProgressBar1.Enabled = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim s As String
                s = SaveFileDialog1.FileName
                ImSlabel1.Text = "Backup location: " & s.ToString
                MainForm.Cursor = Cursors.WaitCursor
                SQLQuery("backup database " & TxtSoftwareSQLDatabaseName & " to disk='" & s & "'")
                MainForm.Cursor = Cursors.Default
                Lbl.Text = "Backup  is Completed successfull...."
            Catch ex As Exception
                MsgBox(ex.Message)
                Lbl.Text = "Backup faild......"
            Finally
                ProgressBar1.Enabled = False
                ProgressBar1.Style = ProgressBarStyle.Blocks
                ProgressBar1.Value = 0
                Timer1.Enabled = False
            End Try
        End If

    End Sub

    Function SQLQuery(ByVal que As String) As Boolean
        Dim retval As Boolean = True
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try

            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            cmd = New SqlCommand(que, SqlConn1)
            cmd.ExecuteNonQuery()
            SqlConn1.Close()
        Catch ex As Exception
            retval = False
            Try
                SqlConn1.Close()
            Catch ex2 As Exception

            End Try
        End Try
        Return retval
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = 100
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub backupdatabase_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub backupdatabase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ProgressBar1.Enabled = False
        TxtExportPath.Text = PhotoBackupPath
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Value = 0
        Timer1.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Do you want to Export Data ? " & Chr(13) & " It will take longer time depend on size of data , Do you want to Continue ? ....", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If TxtExportPath.Text.Length = 0 Then
                If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    TxtExportPath.Text = FolderBrowserDialog1.SelectedPath
                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim sqlstr As String = ""
                    sqlstr = "UPDATE  company  SET Backupath=@Backupath "
                    Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                    With DBF.Parameters
                        .AddWithValue("Backupath", TxtExportPath.Text)
                    End With
                    DBF.ExecuteNonQuery()
                    MAINCON.Close()
                    PhotoBackupPath = TxtExportPath.Text
                Else
                    Exit Sub
                End If
            Else
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim sqlstr As String = ""
                sqlstr = "UPDATE  company  SET Backupath=@Backupath "
                Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("Backupath", TxtExportPath.Text)

                End With
                DBF.ExecuteNonQuery()
                MAINCON.Close()
                PhotoBackupPath = TxtExportPath.Text
            End If
          
            Try
                System.IO.Directory.CreateDirectory(TxtExportPath.Text & "\" & TxtSoftwareSQLDatabaseName & "-" & CompDetails.CompanyName & "-" & Now.ToString("yyyy-MMM-dd hh-mm-ss"))
            Catch ex As Exception
                MsgBox(" Error" & ex.Message.ToString)
                Exit Sub
            End Try
            MainForm.Cursor = Cursors.WaitCursor
            TxtExportPath.Text = TxtExportPath.Text & "\" & TxtSoftwareSQLDatabaseName & "-" & CompDetails.CompanyName & "-" & Now.ToString("yyyy-MMM-dd hh-mm-ss") & "\"
            Dim TBLSTR As String = " SELECT * FROM INFORMATION_SCHEMA.tables where table_type='BASE TABLE'"
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
            Dim ds As New DataSet()
            da.Fill(ds)
            ProgressBar2.Visible = True
            ProgressBar2.Enabled = True
            ProgressBar2.Value = 0
            For Each row As DataRow In ds.Tables(0).Rows
                Dim ids As New DataSet
                Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
                dscmd.Fill(ids, row.Item("TABLE_NAME"))
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
                ids.WriteXml(TxtExportPath.Text & "\" & row.Item("TABLE_NAME") & ".xml")
                Try
                    ProgressBar2.Value = ProgressBar2.Value + 1
                Catch ex As Exception

                End Try
            Next row
            MainForm.Cursor = Cursors.Default
            MsgBox("Data exported successfully ....")
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtExportPath.Text = FolderBrowserDialog1.SelectedPath

        End If
    End Sub
End Class