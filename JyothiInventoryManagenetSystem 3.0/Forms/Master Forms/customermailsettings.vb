Imports System.Data.SqlClient

Public Class customermailsettings
    Dim Sqlstr As String = ""
    Dim IslOaded As Boolean = False
    Dim RepSqlStr As String = ""
    Dim IsLoadingData As Boolean = True
    Dim IsValueIsChanged As Boolean = False

    Private Sub TxtList_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles TxtList.CellBeginEdit
        IsValueIsChanged = True
    End Sub
    Private Sub TxtList_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles TxtList.CellValidating
        If IsValueIsChanged = False Then Exit Sub
        If IsLoadingData = True Then Exit Sub

        If e.ColumnIndex = TxtList.Columns("Email ID").Index Then
            If ValidateEmailID(e.FormattedValue) = True Then
                ExecuteSQLQuery("UPDATE LEDGERS SET emailid='" & e.FormattedValue & "' where ledgername=N'" & TxtList.Item("Customer Name", e.RowIndex).Value & "'")
                e.Cancel = False
            ElseIf e.FormattedValue.ToString.Length = 0 Then
                ExecuteSQLQuery("UPDATE LEDGERS SET emailid='" & e.FormattedValue & "' where ledgername=N'" & TxtList.Item("Customer Name", e.RowIndex).Value & "'")
                e.Cancel = False
            Else

                e.Cancel = True
            End If
        ElseIf e.ColumnIndex = TxtList.Columns("Is Send Email").Index Then
            If e.FormattedValue = True Then
                ExecuteSQLQuery("UPDATE LEDGERS SET IsSendEmail='True' where ledgername=N'" & TxtList.Item("Customer Name", e.RowIndex).Value & "'")
                e.Cancel = False
            ElseIf e.FormattedValue = False Then
                ExecuteSQLQuery("UPDATE LEDGERS SET IsSendEmail='False' where ledgername=N'" & TxtList.Item("Customer Name", e.RowIndex).Value & "'")
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
        IsValueIsChanged = False
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
#Region "Functions"

    Sub LoadCustomerList(Optional ByVal sqlText As String = "")
        IsLoadingData = True
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        RepSqlStr = " where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))"
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY LedgerCode) AS [SNo], LedgerCode as [Code], LedgerName as [Customer Name],emailid as [Email ID], IsSendEmail as [Is Send Email] from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))"
        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & sqlText
            RepSqlStr = RepSqlStr & sqlText
        End If
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 50
            Me.TxtList.Columns(0).ReadOnly = True

            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 150
            Me.TxtList.Columns(1).ReadOnly = True

            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(2).Width = 250
            Me.TxtList.Columns(2).ReadOnly = True

            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 250
            Me.TxtList.Columns(3).ReadOnly = False

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 100
            Me.TxtList.Columns(4).ReadOnly = False
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
        IsLoadingData = False
    End Sub
#End Region

    Private Sub customermailsettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' ", TxtAccountGroup, "subgroup")
        TxtAccountGroup.Items.Add("*All")
        LoadCustomerList()
        IslOaded = True
        Me.MenuStrip1.Visible = False
    End Sub






    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click, ImsButton1.Click
        Me.Close()
    End Sub




    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadCustomerList()
    End Sub
    Private Sub TxtAccountGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccountGroup.SelectedIndexChanged
        If TxtAccountGroup.Text = "*All" Or TxtAccountGroup.Text.Length = 0 Then
            LoadCustomerList()
        Else
            LoadCustomerList(" and AccountGroup=N'" & TxtAccountGroup.Text & "'")
        End If
    End Sub

    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged
        If TxtLedgerName.Text.Length = 0 Then
            LoadCustomerList()
        Else
            LoadCustomerList(" and  LedgerName LIKE N'%" & TxtLedgerName.Text & "%'")
        End If
    End Sub



    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New CutomerEmailReportDataSet
        ds.Clear()

        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables("Datatable1").NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1

                Try
                    row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                Catch ex As Exception
                    row(TxtList.Columns(k).Name) = ""
                End Try
            Next
            ds.Tables("Datatable1").Rows.Add(row)
        Next

        Dim objRpt As New CustomerEmailCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "CUSTOMERS EMAIL ADDRESS REPORTS"
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "CUSTOMERS EMAIL ADDRESS REPORTS"

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
        Dim frm As New EmailMessageSetting
        frm.ShowDialog()
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub


End Class