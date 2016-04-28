Imports System.Data.SqlClient

Public Class EmpLeaveManagement
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim isLoadble As Boolean = False
    Dim Sqlstr As String = ""
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddATA(Optional ByVal whereStr As String = "")
        If isLoadble = False Then Exit Sub


        'SELECT [EmpName], ,[LeaveDays] ,[FromDate] ,[FromDateValue] ,[ToDate] ,[ToDateValue] ,[Narration] ,[LeaveType] ,[TransDate] ,[TransDateValue] ,[UserName] ,[ForYear] ,[n1]  FROM [JVSKINVDB100].[dbo].[EmpLeaves]
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY empname) AS [S.NO], Empname as [EMPLOYEE NAME],LeaveName AS [LEAVE TYPE], fromdate as [DATE FROM],todate as [DATE TO],LEAVEDAYS AS [DAYS],FORYEAR AS [FOR YEAR],(SELECT COLORCODE FROM LEAVES WHERE LEAVES.LEAVENAME=EMPLEAVES.LeaveName) AS [COLORC],transcode as [Transcode] FROM EMPLEAVES "
        If whereStr.Length = 0 Then
            If IsDateWiseOn.Checked = True Then
                Sqlstr = Sqlstr & " WHERE  (fromdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            End If
        Else
            Sqlstr = Sqlstr & whereStr
            If IsDateWiseOn.Checked = True Then
                Sqlstr = Sqlstr & " and  (fromdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            End If
        End If

        Dim TempBS As New BindingSource
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        TxtList.Columns("COLORC").Visible = False
        TxtList.Columns("Transcode").Visible = False
        Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(0).Width = 40

    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem1.Click
        Dim k As New GrantLeave
        k.ShowDialog()
        loaddATA()
    End Sub

    Private Sub EmpLeaveManagement_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Leaves_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  empname FROM employees", TxtEmployeeName, "empname", "*All")
        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        TxtStartDate.Value = Today.Date.AddMonths(-3)
        TxtEndDate.Value = Today.Date
        isLoadble = True
        loaddATA()

    End Sub



    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loaddATA()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.CurrentRow.Index >= 0 Then
            If SQLGetNumericFieldValue("select n1 from empleaves where transcode=" & TxtList.Item("Transcode", TxtList.CurrentRow.Index).Value, "n1") = 1 Then
                MsgBox("This transaction is already audit , not possible to delete ", MsgBoxStyle.Critical)
                Exit Sub
            Else

                If SQLGetNumericFieldValue("select fromdatevalue from empleaves where transcode=" & TxtList.Item("Transcode", TxtList.CurrentRow.Index).Value, "fromdatevalue") <= Today.Date.ToOADate Then
                    If MsgBox("The seleted Leave in running or expiry , Do you want to delete ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                        ExecuteSQLQuery("delete from empleaves where transcode=" & TxtList.Item("Transcode", TxtList.CurrentRow.Index).Value)
                        loaddATA()
                    End If
                Else
                    If MsgBox("Do you want to Cancel  the seleted Leave ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ExecuteSQLQuery("delete from empleaves where transcode=" & TxtList.Item("Transcode", TxtList.CurrentRow.Index).Value)
                        loaddATA()
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
        On Error Resume Next
        For i As Integer = 0 To TxtList.RowCount - 1
            TxtList.Item("LEAVE TYPE", i).Style.BackColor = Color.FromName(TxtList.Item("colorc", i).Value)
        Next
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        loaddATA()
    End Sub

    Private Sub IsDateWiseOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsDateWiseOn.CheckedChanged
        If IsDateWiseOn.Checked = True Then
            TxtStartDate.Enabled = True
            TxtEndDate.Enabled = True
            ImsButton2.Enabled = True
        Else
            TxtStartDate.Enabled = False
            TxtEndDate.Enabled = False
            ImsButton2.Enabled = False

        End If
        loaddATA()
    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmployeeName.SelectedIndexChanged
        If TxtEmployeeName.Text.Length = 0 Or TxtEmployeeName.Text = "*All" Then
            loaddATA()
        Else
            loaddATA(" where empname=N'" & TxtEmployeeName.Text & "' ")
        End If

    End Sub

    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        If TxtEmployeeName.Text.Length = 0 Or TxtEmployeeName.Text = "*All" Then
            loaddATA()
        Else

            loaddATA(" where (empname in (SELECT empname from employees where DepName=N'" & TxtDepartmentName.Text & "')) ")
        End If
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If Sqlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(Sqlstr, cnn)
        dscmd.Fill(ds, "EMPLEAVES")
        cnn.Close()
        Dim objRpt As New EmpLeaveMngCRReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEES LEAVES"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEES LEAVES"

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
End Class