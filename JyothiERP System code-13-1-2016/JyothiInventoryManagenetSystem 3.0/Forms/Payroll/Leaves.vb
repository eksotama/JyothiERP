Imports System.Data.SqlClient

Public Class Leaves
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddATA()
        Dim Sqlstr As String
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY LeaveName) AS [S.NO],leavecode as [LEAVE CODE],LeaveName AS [LEAVE NAME],LeaveType AS [TYPE],Maxno AS [Maximum Leaves],colorcode as [colorc],'' AS [COLOR CODE] FROM leaves"
        Dim TempBS As New BindingSource
        

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("colorc").Visible = False
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 35
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem1.Click
        Dim k As New CreateNewLeave
        k.ShowDialog()
        loaddATA()
    End Sub

    Private Sub Leaves_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Leaves_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, ReloadToolStripMenuItem.Click

        loaddATA()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.CurrentRow.Index >= 0 Then
            If MsgBox("Do you want to Alter the selected Leave ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim k As New CreateNewLeave(TxtList.Item("LEAVE NAME", TxtList.CurrentRow.Index).Value)
                k.ShowDialog()
                loaddATA()
            End If
        End If
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loaddATA()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        If SQLIsFieldExists("SELECT TOP 1 1 from   EmpLeaves where LEAVECODE=N'" & TxtList.Item("LEAVE CODE", TxtList.CurrentRow.Index).Value & "'") = False Then
            If MsgBox("Do you want to Delete the Selected Leave ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from leaves where leavecode=N'" & TxtList.Item("LEAVE CODE", TxtList.CurrentRow.Index).Value & "'")
                loaddATA()
            End If
        Else
            MsgBox("The selected leave is already used, Delete is not allowed...", MsgBoxStyle.Critical)

        End If
    End Sub

    Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
        On Error Resume Next
        For i As Integer = 0 To TxtList.RowCount - 1
            TxtList.Item("COLOR CODE", i).Style.BackColor = Color.FromName(TxtList.Item("colorc", i).Value)
        Next
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click, ReportToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New LeaveTblDataset
        ds.Clear()
        'Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY LeaveName) AS [S.NO],leavecode as [LEAVE CODE],LeaveName AS [LEAVE NAME],LeaveType AS [TYPE],Maxno AS [Maximum Leaves],colorcode as [colorc],'' AS [COLOR CODE] FROM leaves"
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            row("leavecode") = TxtList.Item("LEAVE CODE", i).Value
            row("LeaveName") = TxtList.Item("LEAVE NAME", i).Value
            row("LeaveType") = TxtList.Item("TYPE", i).Value
            row("Maxno") = TxtList.Item("Maximum Leaves", i).Value
            row("colorcode") = TxtList.Item("colorc", i).Value
            Try
                row("R") = Color.FromName(TxtList.Item("colorc", i).Value).R
                row("G") = Color.FromName(TxtList.Item("colorc", i).Value).G
                row("B") = Color.FromName(TxtList.Item("colorc", i).Value).B
            Catch ex As Exception

            End Try


            ds.Tables(0).Rows.Add(row)
        Next

        Dim objRpt As New LeaveTblCRReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE LEAVES"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE LEAVES"

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