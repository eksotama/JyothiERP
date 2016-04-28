Imports System.Windows.Forms

Public Class SelectIncrementVoucher

    Sub LoadData(Optional ByVal SqlStrp As String = "")
        Dim SqlStr As String = ""
        'SELECT     transcode, Vhno, Transdate AS Date, SUM(Increment) AS Value  FROM         .empsalaryincrements GROUP BY transcode, Vhno, Transdate
        SqlStr = "SELECT   Transdate AS [Date],   transcode as [Trans Code], Vhno as [Voucher No], SUM(Increment) AS Value  FROM         empsalaryincrements where (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") GROUP BY transcode, Vhno, Transdate"

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("date").DefaultCellStyle.Format = "d"
            TxtList.Columns("date").Width = 80
            TxtList.Columns("date").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            TxtList.Columns("Trans Code").Width = 55
            TxtList.Columns("Trans Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            TxtList.Columns("Voucher No").Width = 80
            TxtList.Columns("Voucher No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

           
            TxtList.Columns("Value").Width = 100
            TxtList.Columns("Value").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try

    End Sub
   Sub OkPressed()
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Invoice Row....     ", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim tc As Single
            tc = TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value
            If CDbl(tc) <> 0 Then
                EmpincrementTranscode = tc
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        EmpincrementTranscode = 0
        Me.Close()
    End Sub

    Private Sub SelectIncrementVoucher_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SelectIncrementVoucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EmpincrementTranscode = 0
        TxtStartDate.Value = Today.AddMonths(-3)
        TxtEndDate.Value = Today
        LoadData()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        OkPressed()
    End Sub
    Private Sub ImsGrid1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        OkPressed()
    End Sub
    Private Sub TxtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStartDate.KeyDown, TxtEndDate.KeyDown, TxtList.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            OkPressed()
        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        LoadData()
    End Sub
End Class
