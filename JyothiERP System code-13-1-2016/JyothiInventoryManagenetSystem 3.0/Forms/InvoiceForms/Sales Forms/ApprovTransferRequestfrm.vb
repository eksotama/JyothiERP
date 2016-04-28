Public Class ApprovTransferRequestfrm
    Dim SqlStr As String = ""
    Sub loaddata()
        SqlStr = " SELECT  ROW_NUMBER() OVER (ORDER BY TransCode) AS [SNO],TransCode, TransDate, QutoNo as [RefNo],nettotal  as [Total Value], (select top 1 location from StockTransferRowItems where StockTransferRowItems.TransCode=StockTransferDetails.TransCode and vouchername='SJout') as [Fromlocation],(select top 1 location from StockTransferRowItems where StockTransferRowItems.TransCode=StockTransferDetails.TransCode and vouchername='SJin') as [Tolocation], case when IsApproved is null THEN 'PENDING' WHEN IsApproved=1 THEN 'APPROVED' ELSE 'REJECTED' END AS [STATUS]  FROM StockTransferDetails where (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        SqlStr = SqlStr
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then

            Else
                TempBS.Filter = " Tolocation='" & TxtLocation.Text & "'"
            End If
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
    End Sub

    Private Sub ApprovTransferRequestfrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadDataIntoComboBox("select locationname from StockLocations ", TxtLocation, "locationname", "*All")
        loaddata()
    End Sub

    Private Sub TxtLocation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtLocation.SelectedIndexChanged
        loaddata()
    End Sub

    Private Sub ImsButton3_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton3.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        loaddata()
    End Sub

    Private Sub BtnApprove_Click(sender As System.Object, e As System.EventArgs) Handles BtnApprove.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If TxtList.Item("Status", TxtList.CurrentRow.Index).Value = "APPROVED" Then
            If MsgBox("This Transfer Enquiry is already Approved, Do You want to Reject ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("update StockTransferDetails set IsApproved=0 where transcode=" & TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
                loaddata()
            End If
            Exit Sub
        End If

        If MsgBox("Do you want to Approve ?              ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("update StockTransferDetails set IsApproved=1 where transcode=" & TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
            loaddata()
        End If
    End Sub

    Private Sub btnDisply_Click(sender As System.Object, e As System.EventArgs) Handles btnDisply.Click
        Dim frm As New Showtransferrequestfrm(TxtList.Item("transcode", TxtList.CurrentRow.Index).Value)
        frm.ShowDialog()
        frm.Dispose()
    End Sub
End Class