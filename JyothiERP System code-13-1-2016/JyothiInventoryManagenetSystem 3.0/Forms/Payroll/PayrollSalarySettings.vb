Public Class PayrollSalarySettings
    Dim SqlStr As String = ""
    Sub lOADdATA()
        SqlStr = "Select ROW_NUMBER() OVER (ORDER BY settingname) AS [S.NO], settingname as [PaySlip Type Name], ledgername as [Payment Account] from paysliptypes "
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns(0).Width = 80
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Dim frm As New CreatePayslipType
        frm.ShowDialog()
        lOADdATA()
    End Sub

    Private Sub PayrollSalarySettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub PayrollSalarySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lOADdATA()
    End Sub

    Private Sub BtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSettings.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If Len(TxtList.Item("PaySlip Type Name", TxtList.CurrentRow.Index).Value) = 0 Then Exit Sub
        Dim FRM As New AllowancesdeductionsSettings(TxtList.Item("PaySlip Type Name", TxtList.CurrentRow.Index).Value)
        FRM.ShowDialog()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If SQLIsFieldExists("SELECT TOP 1 1 from   paytypes where PayTypeGroup=N'" & TxtList.Item("PaySlip Type Name", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Selected Entry already used in the Pay list...", MsgBoxStyle.Information)
            Exit Sub
        Else
            If MsgBox("Do you want to DELETE the selected Entry ?         ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM paysliptypes where PayTypeGroup=N'" & TxtList.Item("PaySlip Type Name", TxtList.CurrentRow.Index).Value & "'")
                lOADdATA()
            End If
        End If
    End Sub

    Private Sub BTNASSIGN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNASSIGN.Click
        Dim frm As New AssignEmployeesToPayTypes(TxtList.Item("PaySlip Type Name", TxtList.CurrentRow.Index).Value)
        frm.ShowDialog()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim frm As New CreatePayslipType(TxtList.Item("PaySlip Type Name", TxtList.CurrentRow.Index).Value)
        frm.ShowDialog()
        lOADdATA()
    End Sub
End Class