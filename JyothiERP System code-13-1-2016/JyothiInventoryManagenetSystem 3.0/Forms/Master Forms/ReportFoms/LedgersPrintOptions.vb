Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class LedgersPrintOptions
    Public LedgerTypes As String = ""
    Public CUrrentLedgername As String = ""
    Sub New(ByVal LedgerType As String, ByVal currentName As String)

        ' This call is required by the designer.
        InitializeComponent()
        LedgerTypes = LedgerType
        CUrrentLedgername = currentName
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim STR As String = ""
        If LedgerTypes = "Customers" Then
            STR = "select * from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')) "
        ElseIf LedgerTypes = "Suppliers" Then
            STR = "select * from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "')) "
        ElseIf LedgerTypes = "Payroll" Then
            STR = "select * from ledgers where n1=2 "
        Else
            STR = "select * from ledgers "
        End If

        'If MsgBox("Do You want to Print Active and  InActive employees Also ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    STR = "SELECT * FROM employees WHERE ISDELETE=0"
        'Else
        '    STR = "SELECT * FROM employees WHERE ISDELETE=0 and isactive=1"
        'End If

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(STR, cnn)
        dscmd.Fill(ds, "Ledgers")
        cnn.Close()
        Dim objRpt As New LedgerAddressList

        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LEDGER ADDRESS LIST REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LEDGER ADDRESS LIST REPORT"
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

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("Select * from ledgerbook where ledgername=N'" & CUrrentLedgername & "' and isdeleted=0", cnn)
        dscmd.Fill(ds, "ledgerbook")
        cnn.Close()
        Dim objRpt As New AccountsCRReportM
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CUrrentLedgername) & " BALANCE REPORT"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CUrrentLedgername) & " BALANCE REPORT"
        End If
        objRpt.GroupFooterSection2.SectionFormat.EnableSuppress = True
        ' objRpt.GroupFooterSection1.SectionFormat.EnableNewPageAfter = True
       

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonFormWithOptions(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sQLSTR As String = ""

        If LedgerTypes = "Customers" Then
            sQLSTR = "select * from ledgerbook where ledgername in (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))) and isdeleted=0"
        ElseIf LedgerTypes = "Suppliers" Then
            sQLSTR = "select * from ledgerbook where ledgername in (select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))) and isdeleted=0"
        Else
            sQLSTR = "select * from ledgerbook where  isdeleted=0"
        End If

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
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(LedgerTypes) & "  ACCOUNTS BALANCE REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(LedgerTypes) & "  ACCOUNTS BALANCE REPORT"
        End If
        ' CType(objRpt.Section4.ReportObjects.Item("TXTTOTAL"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CUrrentLedgername) & " BALANCE REPORT"
        objRpt.GroupFooterSection2.SectionFormat.EnableSuppress = True
        'objRpt.GroupFooterSection1.SectionFormat.EnableNewPageAfter = True
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonFormWithOptions(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        Dim gr As New GrpPrint(LedgerTypes)
        gr.ShowDialog()
        gr.Dispose()
    End Sub

    Private Sub ImsButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton6.Click
        Dim Str As String = ""

        If LedgerTypes = "Customers" Then
            Str = "select * from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')) "
        ElseIf LedgerTypes = "Suppliers" Then
            Str = "select * from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))"
        Else
            Str = "select * from ledgers "
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New AccountLedgerDataSet
        Dim cnn As SqlConnection

        cnn = New SqlConnection(ConnectionStrinG)
       
        cnn.Open()

        Dim dscmd As New SqlDataAdapter(Str, cnn)
        dscmd.Fill(ds, "ledgers")
        For i As Integer = 0 To ds.Tables("ledgers").Rows.Count - 1

            Dim R As DataRow = ds.Tables("Images").NewRow
            R("ledgername") = ds.Tables("ledgers").Rows(i).Item("ledgername").ToString
            R("ImageFile") = GetImageToDataTableColum(ds.Tables("ledgers").Rows(i).Item("photopath").ToString)
            ds.Tables("Images").Rows.Add(R)
        Next
        cnn.Close()
        Dim objRpt As New LedgerDetailsCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT LEDGERS"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT LEDGERS"
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
