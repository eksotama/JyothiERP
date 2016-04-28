Imports System.Data.SqlClient

Public Class DocumentIssuesfrm
    Dim SQLSTR As String = ""
    Dim RepSqlStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub Loaddata(Optional ByVal sqlText As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        RepSqlStr = ""
        SQLSTR = "SELECT ROW_NUMBER() OVER (ORDER BY IssueNo) AS [SNO], [IssueNo] , [issuedate] AS [ISSUE DATE],DocName AS [DOC NAME],  [empname] AS [EMPLOYEE NAME],(CASE WHEN Status=1 THEN 'ISSUED' ELSE 'RECEIVED' END) AS [STATUS],notes AS [Notes],checkoutdate as [Checkin Date], notes2 as [details] FROM documentissues  "

        If sqlText.Length > 0 Then
            SQLSTR = SQLSTR & sqlText
            RepSqlStr = RepSqlStr & sqlText
        End If
        If TxtIsPeriod.Checked = True Then
            If sqlText.Length = 0 Then
                SQLSTR = SQLSTR & " where (issuedate between '" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' and '" & TxtEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "') "
                RepSqlStr = RepSqlStr & " where (issuedate between '" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' and '" & TxtEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "') "
            Else
                SQLSTR = SQLSTR & " AND (issuedate between '" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' and '" & TxtEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "') "
                RepSqlStr = RepSqlStr & " AND (issuedate between '" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' and '" & TxtEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "') "
            End If

        End If
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 35
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 85
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 130

            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 150

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(4).Width = 100
            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).Width = 80
            Me.TxtList.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(6).Width = 100
            Me.TxtList.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(7).Width = 100
            Me.TxtList.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(7).Width = 180
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        Dim frm As New CheckoutDoc
        frm.ShowDialog()
        Loaddata()
    End Sub

    Private Sub DocumentIssuesfrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtEndDate.Value = Now
        TxtStartDate.Value = TxtEndDate.Value.AddMonths(-1)
        Loaddata()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If SQLIsFieldExists("SELECT IssueNo FROM documentissues WHERE Status=0 AND IssueNo=N'" & TxtList.Item("IssueNo", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("Can not editable completed transactions ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to Edit ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim frm As New CheckoutDoc(TxtList.Item("IssueNo", TxtList.CurrentRow.Index).Value, TxtList.Item("DOC NAME", TxtList.CurrentRow.Index).Value)
            frm.ShowDialog()
            Loaddata()
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If SQLIsFieldExists("SELECT IssueNo FROM documentissues WHERE Status=0 AND IssueNo=N'" & TxtList.Item("IssueNo", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("Completed transaction can be deleted  ", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Do you want to Delete Selected Entry ?        ", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("DELETE FROM documentissues WHERE ISSUENO=N'" & TxtList.Item("IssueNo", TxtList.CurrentRow.Index).Value & "'")
            Loaddata()
        End If
    End Sub

    Private Sub TxtDocName_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDocName.TextChanged
        If TxtDocName.Text.Length = 0 Then
            Loaddata()
        Else
            Loaddata(" where DocName LIKE N'%" & TxtDocName.Text & "%' ")
        End If
    End Sub

    Private Sub BTNCHECKIN_Click(sender As System.Object, e As System.EventArgs) Handles BTNCHECKIN.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If SQLIsFieldExists("SELECT IssueNo FROM documentissues WHERE Status=0 AND IssueNo=N'" & TxtList.Item("IssueNo", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("This transaction is already Check In status...  ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to Check In   ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim frm As New CheckinDoc(TxtList.Item("IssueNo", TxtList.CurrentRow.Index).Value, TxtList.Item("DOC NAME", TxtList.CurrentRow.Index).Value)
            frm.ShowDialog()
            Loaddata()
        End If
    End Sub

    Private Sub UserButton2_Click(sender As System.Object, e As System.EventArgs) Handles UserButton2.Click
        Loaddata()
    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click
        'ISSUED DOCUMENT LIST
        'RepSqlStr
        If TxtList.RowCount = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("select * from documentissues  " & RepSqlStr, cnn)

        dscmd.Fill(ds, "documentissues")
        cnn.Close()
        Dim objRpt As New DocIssuedCrReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF EMPLOYEE DEPARTMENTS"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF EMPLOYEE DEPARTMENTS"

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

    Private Sub ImsButton2_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton2.Click
        If TxtList.RowCount = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("select * from documentissues where IssueNo=N'" & TxtList.Item("IssueNo", TxtList.CurrentRow.Index).Value & "'", cnn)
        dscmd.Fill(ds, "documentissues")
        cnn.Close()
        Dim objRpt As New IssueDocListOfReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF EMPLOYEE DEPARTMENTS"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF EMPLOYEE DEPARTMENTS"

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