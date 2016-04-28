Imports System.Data.SqlClient

Public Class frmClientMaster
    Sub loadClients()
        Dim Sqlstr As String = ""
        ' Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCategoryName) AS [S.NO],rtrim(StockCategoryName) AS [STOCK CATEGORY],rtrim(groupRoot) AS [UNDER GROUP] FROM categoriesgroups"
        Sqlstr = " Select *,isnull((SELECT STUFF((SELECT ', '+SITENAME FROM  ClientSites inner join sites on clientsites.siteid=sites.siteid  WHERE CLIENTID=Clients.CLIENTID FOR XML PATH('')),1,1,'')),'N/A') AS [Sites] from Clients "
        '  Me.TxtList.Rows.Clear()

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("ClientID").Width = 40
            TxtList.Columns("ClientID").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            TxtList.Columns("ContactNo1").Width = 100
            TxtList.Columns("ContactNo1").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            TxtList.Columns("ContactNo2").Width = 100
            TxtList.Columns("ContactNo2").AutoSizeMode = DataGridViewAutoSizeColumnMode.None


            TxtList.Columns("Cotracttype").Width = 100
            TxtList.Columns("Cotracttype").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            TxtList.Columns("Period").Width = 50
            TxtList.Columns("Period").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            TxtList.Columns("Sites").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SiteMaster_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loadClients()
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim FRM As New FrmNewClient
        FRM.ShowDialog()
        loadClients()
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.Rows.Count = 0 Then Exit Sub
        Dim FRM As New FrmNewClient(TxtList.Item("CLIENTID", TxtList.CurrentRow.Index).Value)
        FRM.ShowDialog()
        loadClients()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnAssignSites_Click(sender As System.Object, e As System.EventArgs) Handles BtnAssignSites.Click
        Dim FRM As New AssignSites
        FRM.ShowDialog()
        loadClients()
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.Rows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to delete the seleted entry? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQueryForDELETE("Delete from Clients where ClientID=" & TxtList.Item("CLIENTID", TxtList.CurrentRow.Index).Value)
            loadClients()
        End If
    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        Dim sql As String
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        sql = "Select *,isnull((SELECT STUFF((SELECT ', '+SITENAME FROM  ClientSites inner join sites on clientsites.siteid=sites.siteid  WHERE CLIENTID=Clients.CLIENTID FOR XML PATH('')),1,1,'')),'N/A') AS [Sites] from Clients "
        Dim dscmd As New SqlDataAdapter(sql, cnn)

        dscmd.Fill(ds, "Clients")
        cnn.Close()
        Dim objRpt As New ClientMasterCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF CLIENTS"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF CLIENTS"
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