Imports System.Data.SqlClient
Imports System.IO

Public Class RestoreDatabase
    Dim cmd As SqlCommand
    Dim dread As SqlDataReader
    Dim SelectedDatabaseName As String = ""
    Dim RestoreDatabaseName As String = ""

    Private Sub cmbbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRestore.Click
        If SelectedDatabaseName.Length = 0 Then
            MsgBox("Please Select the Backu File ...... ", MsgBoxStyle.Information)
            Exit Sub
        End If


        If MsgBox("Do you want to Restore the Database ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                My.Application.DoEvents()
                MainForm.Cursor = Cursors.WaitCursor
                ImSlabel1.Text = ""
                Lbl.Text = "Restore in Progress..., It may take several mins depend on size"
                Timer1.Enabled = True
                ProgressBar1.Enabled = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim s As String
                s = SelectedDatabaseName
                ImSlabel1.Text = "Restore from location: " & s.ToString
                MainForm.Cursor = Cursors.WaitCursor
                SQLQuery("use master;")
                SQLQuery("ALTER DATABASE " & RestoreDatabaseName & " set offline with rollback immediate;")

                If SQLQuery("RESTORE DATABASE " & RestoreDatabaseName & " FROM DISK='" & s & "' ") = True Then
                    MainForm.Cursor = Cursors.Default
                    Lbl.Text = "Restore  is Completed successfull...."
                Else
                    MainForm.Cursor = Cursors.Default
                    Lbl.Text = "Restore  is failed......"
                End If
                SQLQuery("ALTER DATABASE " & RestoreDatabaseName & " set online with rollback immediate; ")
               

            Catch ex As Exception
                MsgBox(ex.Message)
                SQLQuery("ALTER DATABASE " & RestoreDatabaseName & " set online with rollback immediate;")
                Lbl.Text = "Restore failed......"

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
            MsgBox(ex.Message)
            retval = False
            Try
                SqlConn1.Close()
            Catch ex3 As Exception

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

    Private Sub RestoreDatabase_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub backupdatabase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SelectedDatabaseName = ""
        ProgressBar1.Enabled = False
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Value = 0
        Timer1.Enabled = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = vbOK Then
            SelectedDatabaseName = OpenFileDialog1.FileName

            Try
                RestoreDatabaseName = OpenFileDialog1.SafeFileName.Substring(0, OpenFileDialog1.SafeFileName.IndexOf("-"))
            Catch ex As Exception
                RestoreDatabaseName = SelectedDatabaseName
            End Try
            TxtRunningDatabaseName.Text = "Restore Database Name: " & RestoreDatabaseName
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtExportPath.Text = FolderBrowserDialog1.SelectedPath

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TxtCmpNames.Text.Length = 0 Then
            MsgBox("Please select the company name...")
            TxtCmpNames.Focus()
            Exit Sub
        End If
        TxtSoftwareSQLDatabaseName = MainForm.GetCompanyDatabaseName(TxtCmpNames.Text)
        If TxtSoftwareSQLDatabaseName.Length = 0 Then
            MsgBox("Invalid Company Name .....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtExportPath.Text.Contains(TxtSoftwareSQLDatabaseName) = False Then
            If MsgBox("The selected Export data files are not for selected company, Do you want to Continue ?.... ", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ConnectionStrinG = ConnectionStringFromFile & " Initial Catalog=" & TxtSoftwareSQLDatabaseName & ";"

        If IO.Directory.Exists(TxtExportPath.Text) = True Then
            If MsgBox("Do you want to Restore Database from Export Data Files ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim TBLSTR As String = " SELECT * FROM INFORMATION_SCHEMA.tables where table_type='BASE TABLE'"
                Dim cnn As SqlConnection
                cnn = New SqlConnection(ConnectionStrinG)
                cnn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
                Dim ds As New DataSet()
                MainForm.Cursor = Cursors.WaitCursor
                da.Fill(ds)
                ' Application.DoEvents()
                ProgressBar2.Visible = True
                ProgressBar2.Enabled = True
                ProgressBar2.Value = 1
                Try
                    For Each row As DataRow In ds.Tables(0).Rows
                      
                        Try
                            Dim ids As New DataSet
                            Try
                                ExecuteSQLQuery("TRUNCATE  TABLE " & row.Item("TABLE_NAME"))
                                ExecuteSQLQuery("SET IDENTITY_INSERT " & row.Item("TABLE_NAME") & " ON", False)
                            Catch ex As Exception

                            End Try
                            Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
                            dscmd.Fill(ids, row.Item("TABLE_NAME"))
                            Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
                            ids.ReadXml(TxtExportPath.Text & "\" & row.Item("TABLE_NAME") & ".xml")

                            dscmd.Update(ids, row.Item("TABLE_NAME"))
                            ExecuteSQLQuery("DBCC CHECKIDENT ('" & row.Item("TABLE_NAME") & "')", False)
                            If ProgressBar2.Value < 100 Then
                                ProgressBar2.Value = ProgressBar2.Value + 1
                            End If
                            ExecuteSQLQuery("SET IDENTITY_INSERT " & row.Item("TABLE_NAME") & " OFF", False)
                            ids.Dispose()
                        Catch ex As Exception
                            Try
                                ExecuteSQLQuery("SET IDENTITY_INSERT " & row.Item("TABLE_NAME") & " OFF", False)

                            Catch ex2 As Exception

                            End Try
                        End Try
                      
                    Next row
                Catch ex As Exception
                    MainForm.Cursor = Cursors.Default
                    MsgBox(" Failed .., " & ex.Message)
                    ProgressBar2.Enabled = False
                    Exit Sub
                End Try
                MainForm.Cursor = Cursors.Default
                ProgressBar2.Value = 100
                ProgressBar2.Enabled = False
                MsgBox("Success...")

            End If
        End If
    End Sub

    Private Sub ProgressBar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar2.Click

    End Sub

    Private Sub TxtCmpNames_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtCmpNames.SelectedIndexChanged

    End Sub

    Private Sub btnRestoreFromAnotherDB_Click(sender As System.Object, e As System.EventArgs) Handles btnRestoreFromAnotherDB.Click
        If MsgBox("Do you want to Restore from One database backup to another ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim dbname As String = ""
            Try
                dbname = MainForm.GetCompanyDatabaseName(TxtCmpNames.Text)
                If dbname.Length = 0 Then
                    MsgBox("Invalid Company Name .....", MsgBoxStyle.Information)
                    Exit Sub
                End If

                My.Application.DoEvents()
                MainForm.Cursor = Cursors.WaitCursor
                ImSlabel1.Text = ""
                Lbl.Text = "Restore in Progress..., It may take several mins depend on size"
                Timer1.Enabled = True
                ProgressBar1.Enabled = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim s As String
                s = SelectedDatabaseName
                ImSlabel1.Text = "Restore from location: " & SelectedDatabaseName.ToString
                MainForm.Cursor = Cursors.WaitCursor

                'RestoreDatabaseName
                s = s.Replace(".bak", "")
                If SQLQuery("USE MASTER; RESTORE FILELISTONLY FROM DISK='" & SelectedDatabaseName & "'; RESTORE DATABASE " & dbname & " FROM DISK='" & SelectedDatabaseName & "' WITH replace, MOVE '" & dbname & "' TO '" & s & ".mdf',MOVE '" & dbname & "_log' TO '" & s & ".ldf'") = True Then
                    MsgBox("Retore is completed, Please re-run the application..... ")
                Else
                    MsgBox("Restore failed. ")
                End If
                MsgBox("Retore is completed, Please re-run the application..... ")
            Catch ex2 As Exception

            End Try
        End If
    End Sub
End Class