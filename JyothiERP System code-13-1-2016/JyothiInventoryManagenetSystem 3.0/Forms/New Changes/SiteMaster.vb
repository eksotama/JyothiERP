Imports System.Data.SqlClient

Public Class SiteMaster
    Sub lOADsITES()
        Dim Sqlstr As String = ""
        ' Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCategoryName) AS [S.NO],rtrim(StockCategoryName) AS [STOCK CATEGORY],rtrim(groupRoot) AS [UNDER GROUP] FROM categoriesgroups"
        Sqlstr = "SELECT * FROM SITES"
        '  Me.TxtList.Rows.Clear()

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

    End Sub

    Private Sub SiteMaster_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lOADsITES()
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim FRM As New FrmNewSite
        FRM.ShowDialog()
        lOADsITES()
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If TxtList.Rows.Count = 0 Then Exit Sub
        Dim FRM As New FrmNewSite(TxtList.Item("SITEID", TxtList.CurrentRow.Index).Value)
        FRM.ShowDialog()
        lOADsITES()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.Rows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to delete the seleted entry? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQueryForDELETE("Delete from sites where siteid=" & TxtList.Item("SITEID", TxtList.CurrentRow.Index).Value)
            lOADsITES()
        End If
    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New SiteMasterDataSet
        Dim cnn As SqlConnection
        Dim sql As String
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        sql = "SELECT * FROM SITES"
        Dim dscmd As New SqlDataAdapter(sql, cnn)
        dscmd.Fill(ds, "SITES")
        cnn.Close()
        Dim objRpt As New SiteMasterCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF SITES"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF SITES"
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