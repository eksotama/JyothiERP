Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class GrpPrint
    Dim LedgerTypes As String = ""
    Sub New(ByVal Ledgertype As String)

        ' This call is required by the designer.
        InitializeComponent()
        LedgerTypes = Ledgertype
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtunderAccGroup.Text.Length = 0 Then
            MsgBox("Please select the Group Name...", MsgBoxStyle.Information)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim sQLSTR As String = ""
        sQLSTR = "select * from ledgerbook where ledgername in (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtunderAccGroup.Text & "'))) and isdeleted=0"
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(sQLSTR, cnn)
        dscmd.Fill(ds, "ledgerbook")
        cnn.Close()
        Dim objRpt As New AccountsCRReportM
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(LedgerTypes) & " ACCOUNTS BALANCE REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(LedgerTypes) & " ACCOUNTS BALANCE REPORT"
        End If
        ' CType(objRpt.Section4.ReportObjects.Item("TXTTOTAL"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CUrrentLedgername) & " BALANCE REPORT"
        objRpt.GroupFooterSection2.SectionFormat.EnableSuppress = True
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonFormWithOptions(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub GrpPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        If LedgerTypes = "Suppliers" Then
            LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'", TxtunderAccGroup, "subgroup")
        ElseIf LedgerTypes = "Customers" Then
            LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'", TxtunderAccGroup, "subgroup")
        Else
            LoadDataIntoComboBox("select groupname from accountgroups", TxtunderAccGroup, "groupname")
        End If

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
