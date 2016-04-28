Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class CompanyLeaves
    Dim SQlstr As String = ""
    Public IsOnLoad As Boolean = True
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        SQlstr = "select sno as [S.No], leavename as [Holyday Name],fromdate as [From Date],todate as [To Date],narration as [Narration] from companyleaves order by sno"
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 40

            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 150

            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 120
            Me.TxtList.Columns(2).DefaultCellStyle.Format = "d"

            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 120
            Me.TxtList.Columns(3).DefaultCellStyle.Format = "d"

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(4).Width = 120

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CompanyLeaves_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub CompanyLeaves_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadData()
        If SQLIsFieldExists("select leavename from companyleaves where leavename='Sunday'") = True Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        If SQLIsFieldExists("select leavename from companyleaves where leavename='Saturday'") = True Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        If SQLIsFieldExists("select leavename from companyleaves where leavename='Friday'") = True Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If

        IsOnLoad = False
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Dim kfrm As New NewHolyday
        kfrm.ShowDialog()
        kfrm.Dispose()
        LoadData()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If MsgBox("Do you want to Edit ?             ", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim kfrm As New NewHolyday(TxtList.Item("S.No", TxtList.CurrentRow.Index).Value)
            kfrm.ShowDialog()
            kfrm.Dispose()
            LoadData()
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If MsgBox("Do you want to Delete ?             ", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   CompanyLeaves where " & TxtList.Item("S.No", TxtList.CurrentRow.Index).Value & " <  (SELECT     MAX(Sno) AS Expr1   FROM  CompanyLeaves AS CompanyLeaves_1)") = True Then
                If MsgBox("The Selected is not recommended to delete, Do you want to continue....", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ExecuteSQLQuery("DELETE FROM COMPANYLEAVES WHERE SNO=" & TxtList.Item("S.No", TxtList.CurrentRow.Index).Value)
                    LoadData()
                End If
            Else
                ExecuteSQLQuery("DELETE FROM COMPANYLEAVES WHERE SNO=" & TxtList.Item("S.No", TxtList.CurrentRow.Index).Value)
                LoadData()
            End If
        End If

    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click, ReportToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If SQlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SQlstr, cnn)
        dscmd.Fill(ds, "companyleaves")
        cnn.Close()
        Dim objRpt As New CompanyLeavesCRReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "HOLYDAY DETAILS"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "HOLYDAY DETAILS"

        End If
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If IsOnLoad = True Then Exit Sub
        If CheckBox1.Checked = True Then

            If MsgBox("Do you want to mark holyday for sundays ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MainForm.Cursor = Cursors.WaitCursor
                Dim stdate As New DateTimePicker
                stdate.Value = CompDetails.AccDateFrom
                For i As Integer = 0 To 7
                    If stdate.Value.DayOfWeek() = 0 Then
                        Exit For
                    End If
                    stdate.Value = stdate.Value.AddDays(1)
                Next

                While stdate.Value.Date < CompDetails.AccDateTo
                    Dim Sno As Integer = 1
                    Sno = SQLGetNumericFieldValue("select max(sno) as s from companyleaves", "s")
                    If Sno = 0 Then
                        Sno = 1
                    Else
                        Sno = Sno + 1
                    End If
                    If stdate.Value.DayOfWeek() = 0 Then
                        SQlstr = "INSERT INTO [CompanyLeaves]([LeaveName],[FromDate],[ToDate],[FromDateValue],[ToDateValue],[Narration],[F1],[N1],[Sno])     VALUES " _
                       & " (@LeaveName,@FromDate,@ToDate,@FromDateValue,@ToDateValue,@Narration,@F1,@N1,@Sno) "

                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(SQlstr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("LeaveName", "Sunday")
                            .AddWithValue("FromDate", stdate.Value.Date)
                            .AddWithValue("ToDate", stdate.Value.Date)
                            .AddWithValue("FromDateValue", stdate.Value.Date.ToOADate)
                            .AddWithValue("ToDateValue", stdate.Value.Date.ToOADate)
                            .AddWithValue("Narration", "")
                            .AddWithValue("F1", "")
                            .AddWithValue("N1", 0)
                            .AddWithValue("sno", Sno)
                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()

                    End If

                    stdate.Value = stdate.Value.AddDays(7)
                End While



            End If
        Else

            If MsgBox("Do you want to unmark holyday for sundays ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MainForm.Cursor = Cursors.WaitCursor
                Dim stdate As New DateTimePicker
                stdate.Value = CompDetails.AccDateFrom
                For i As Integer = 0 To 8
                    If stdate.Value.DayOfWeek() = 0 Then
                        Exit For
                    End If
                    stdate.Value = stdate.Value.AddDays(1)
                Next
                While stdate.Value.Date < CompDetails.AccDateTo
                    If stdate.Value.DayOfWeek() = 0 Then
                        ExecuteSQLQuery("delete from CompanyLeaves where FromDateValue=" & stdate.Value.Date.ToOADate & " and ToDateValue=" & stdate.Value.Date.ToOADate)
                    End If
                    stdate.Value = stdate.Value.AddDays(7)
                End While
            End If
        End If
        MainForm.Cursor = Cursors.Default
        LoadData()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If IsOnLoad = True Then Exit Sub
        If CheckBox2.Checked = True Then
            If MsgBox("Do you want to mark holyday for Saturday ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MainForm.Cursor = Cursors.WaitCursor
                Dim stdate As New DateTimePicker
                stdate.Value = CompDetails.AccDateFrom
                For i As Integer = 0 To 7
                    If stdate.Value.DayOfWeek() = 6 Then
                        Exit For
                    End If
                    stdate.Value = stdate.Value.AddDays(1)
                Next

                While stdate.Value.Date < CompDetails.AccDateTo
                    Dim Sno As Integer = 1
                    Sno = SQLGetNumericFieldValue("select max(sno) as s from companyleaves", "s")
                    If Sno = 0 Then
                        Sno = 1
                    Else
                        Sno = Sno + 1
                    End If
                    If stdate.Value.DayOfWeek() = 6 Then
                        SQlstr = "INSERT INTO [CompanyLeaves]([LeaveName],[FromDate],[ToDate],[FromDateValue],[ToDateValue],[Narration],[F1],[N1],[Sno])     VALUES " _
                       & " (@LeaveName,@FromDate,@ToDate,@FromDateValue,@ToDateValue,@Narration,@F1,@N1,@Sno) "

                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(SQlstr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("LeaveName", "Saturday")
                            .AddWithValue("FromDate", stdate.Value.Date)
                            .AddWithValue("ToDate", stdate.Value.Date)
                            .AddWithValue("FromDateValue", stdate.Value.Date.ToOADate)
                            .AddWithValue("ToDateValue", stdate.Value.Date.ToOADate)
                            .AddWithValue("Narration", "")
                            .AddWithValue("F1", "")
                            .AddWithValue("N1", 0)
                            .AddWithValue("sno", Sno)
                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()

                    End If

                    stdate.Value = stdate.Value.AddDays(7)
                End While



            End If
        Else

            If MsgBox("Do you want to unmark holyday for Saturday ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MainForm.Cursor = Cursors.WaitCursor
                Dim stdate As New DateTimePicker
                stdate.Value = CompDetails.AccDateFrom
                For i As Integer = 0 To 7
                    If stdate.Value.DayOfWeek() = 6 Then
                        Exit For
                    End If
                    stdate.Value = stdate.Value.AddDays(1)
                Next
                While stdate.Value.Date < CompDetails.AccDateTo
                    If stdate.Value.DayOfWeek() = 6 Then
                        ExecuteSQLQuery("delete from CompanyLeaves where FromDateValue=" & stdate.Value.Date.ToOADate & " and ToDateValue=" & stdate.Value.Date.ToOADate)
                    End If
                    stdate.Value = stdate.Value.AddDays(7)
                End While
            End If
        End If
        MainForm.Cursor = Cursors.Default
        LoadData()
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If IsOnLoad = True Then Exit Sub
        If CheckBox3.Checked = True Then
            If MsgBox("Do you want to mark holyday for Friday ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MainForm.Cursor = Cursors.WaitCursor
                Dim stdate As New DateTimePicker
                stdate.Value = CompDetails.AccDateFrom
                For i As Integer = 0 To 7
                    If stdate.Value.DayOfWeek() = 5 Then
                        Exit For
                    End If
                    stdate.Value = stdate.Value.AddDays(1)
                Next

                While stdate.Value.Date < CompDetails.AccDateTo
                    Dim Sno As Integer = 1
                    Sno = SQLGetNumericFieldValue("select max(sno) as s from companyleaves", "s")
                    If Sno = 0 Then
                        Sno = 1
                    Else
                        Sno = Sno + 1
                    End If
                    If stdate.Value.DayOfWeek() = 5 Then
                        SQlstr = "INSERT INTO [CompanyLeaves]([LeaveName],[FromDate],[ToDate],[FromDateValue],[ToDateValue],[Narration],[F1],[N1],[Sno])     VALUES " _
                       & " (@LeaveName,@FromDate,@ToDate,@FromDateValue,@ToDateValue,@Narration,@F1,@N1,@Sno) "

                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(SQlstr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("LeaveName", "Friday")
                            .AddWithValue("FromDate", stdate.Value.Date)
                            .AddWithValue("ToDate", stdate.Value.Date)
                            .AddWithValue("FromDateValue", stdate.Value.Date.ToOADate)
                            .AddWithValue("ToDateValue", stdate.Value.Date.ToOADate)
                            .AddWithValue("Narration", "")
                            .AddWithValue("F1", "")
                            .AddWithValue("N1", 0)
                            .AddWithValue("sno", Sno)
                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()

                    End If

                    stdate.Value = stdate.Value.AddDays(7)
                End While



            End If
        Else

            If MsgBox("Do you want to unmark holyday for Friday ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MainForm.Cursor = Cursors.WaitCursor
                Dim stdate As New DateTimePicker
                stdate.Value = CompDetails.AccDateFrom
                For i As Integer = 0 To 7
                    If stdate.Value.DayOfWeek() = 5 Then
                        Exit For
                    End If
                    stdate.Value = stdate.Value.AddDays(1)
                Next
                While stdate.Value.Date < CompDetails.AccDateTo
                    If stdate.Value.DayOfWeek() = 5 Then
                        ExecuteSQLQuery("delete from CompanyLeaves where FromDateValue=" & stdate.Value.Date.ToOADate & " and ToDateValue=" & stdate.Value.Date.ToOADate)
                    End If
                    stdate.Value = stdate.Value.AddDays(7)
                End While
            End If
        End If
        MainForm.Cursor = Cursors.Default
        LoadData()
    End Sub
End Class
