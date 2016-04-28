Imports System.Data.SqlClient

Public Class UserActivities
    Dim SQLStr As String = ""
    Dim SqlDelStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddata(Optional ByVal ExtraSQLstr As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        SqlDelStr = ""
        If TxtIsPeriod.Checked = True Then
            SQLStr = " SELECT [StoreName],[TransDatetime],[Transcode],[voucherName],[voucherNo],[UserName],[Status],[Systemno],[Details],[ID]  FROM [LogFile] where (transdatevalue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")"
            SqlDelStr = " (transdatevalue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")"
            If ExtraSQLstr.Length > 0 Then
                SQLStr = SQLStr & " and username=N'" & ExtraSQLstr & "'"
                SqlDelStr = " (transdatevalue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")" & "  and username=N'" & ExtraSQLstr & "'"
            End If
        Else
            SQLStr = "SELECT [StoreName],[TransDatetime],[Transcode],[voucherName],[voucherNo],[UserName],[Status],[Systemno],[Details],[ID]  FROM [LogFile] "
            If ExtraSQLstr.Length > 0 Then
                SQLStr = SQLStr & " where username=N'" & ExtraSQLstr & "'"
                SqlDelStr = " username=N'" & ExtraSQLstr & "'"
            End If
        End If
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQLStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImsComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUserName.SelectedIndexChanged
        If TxtUserName.Text.Length = 0 Or TxtUserName.Text = "*All" Then
            loaddata()
        Else
            loaddata(TxtUserName.Text)
        End If
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        If TxtUserName.Text.Length = 0 Or TxtUserName.Text = "*All" Then
            loaddata()
        Else
            loaddata(TxtUserName.Text)
        End If
    End Sub

    Private Sub UserActivities_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub UserLogInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT DISTINCT UserName FROM LogFile", TxtUserName, "username")
        If TxtUserName.Items.Count > 0 Then
            TxtUserName.SelectedIndex = 0
        Else
            loaddata()
        End If
        TxtUserName.Items.Add("*All")

    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If SqlDelStr.Length = 0 Then
            If MsgBox("Do you want to Clear Entire User Activity Log File............", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                If MsgBox("Are you sure, Do you want to Delete All Activity log Information ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    ExecuteSQLQuery("DELETE FROM LogFile")
                    loaddata()
                End If
            End If
        Else
            If MsgBox("Are you sure, Do you want to Delete ? ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM LogFile WHERE " & SqlDelStr)
                loaddata()
            End If
        End If
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub


    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If SQLStr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SQLStr, cnn)
        dscmd.Fill(ds, "LogFile")
        cnn.Close()
        Dim objRpt As New UserActivityLoginCRReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "USER ACTIVITIES"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "USER ACTIVITIES"

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

    Private Sub btnSelectedDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectedDelete.Click, DELETESELETEDToolStripMenuItem.Click
        If TxtList.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to Delete selected Rows...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each x As DataGridViewRow In TxtList.SelectedRows
                    ExecuteSQLQuery("delete from logfile where Transcode=" & TxtList.Item("Transcode", x.Index).Value)
                Next
                loaddata()
            End If
        End If

    End Sub
End Class