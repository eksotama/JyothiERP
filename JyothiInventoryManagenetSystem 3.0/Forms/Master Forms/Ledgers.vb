Imports System.Data.SqlClient

Public Class Ledgers
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim IslOaded As Boolean = False
    Dim Sqlstr As String = ""
    Dim RepSqlStr As String = ""
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

#Region "Functions"

    Sub LoadLedgerAccounts(Optional ByVal sqlText As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        RepSqlStr = " "
        Dim subquery As String = ""
        subquery = "(select *,(select CAST(sum(dr-cr) AS money) from ledgerbook where isdeleted=0 and ledgerbook.ledgername=ledgers.LedgerName ) as bal from ledgers) as tt"
        Sqlstr = "SELECT LedgerCode as [Code], LedgerName as [Ledger Name],AccountGroup as [Account Type],address as [Location],state as [State],Tel as [Contact Number],fax as [Fax Number],emailid as [Email  ID],(case when bal>0 then CONVERT(nvarchar,bal,1) +' Dr' else CONVERT(nvarchar,bal*-1,1) +' Cr' end) as [Balance] from  " & subquery

        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & sqlText
            RepSqlStr = sqlText
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
            Me.TxtList.Columns(0).Width = 55
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 150
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 250
            Me.TxtList.Columns("balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            'For i As Integer = 0 To TxtList.RowCount - 1
            '    TxtList.Item("Balance", i).Value = GetCurrentBalanceText(TxtList.Item("Ledger Name", i).Value)
            'Next
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub

#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateLedgerAccounts
        k.ShowDialog()
        LoadLedgerAccounts()
    End Sub

    Private Sub Ledgers_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadLedgerAccounts()
        LoadDataIntoComboBox("select groupname from AccountGroups", TxtAccountGroup, "groupname")
        TxtAccountGroup.Items.Add("*All")

        IslOaded = True
    End Sub
    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadLedgerAccounts()
    End Sub

    Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
        'For i As Integer = 0 To TxtList.RowCount - 1
        '    If TxtList.Item("balance", i).Value.ToString.Contains("Cr") = True Then
        '        TxtList.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
        '    Else
        '        TxtList.Rows(i).DefaultCellStyle.BackColor = Color.White

        '    End If
        'Next

    End Sub

    Private Sub TxtAccountGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAccountGroup.SelectedIndexChanged
        If TxtAccountGroup.Text = "*All" Or TxtAccountGroup.Text.Length = 0 Then
            LoadLedgerAccounts()
        Else
            ' where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))
            LoadLedgerAccounts(" where AccountGroup in (select subgroup from AccountGroupsList where groupname=N'" & TxtAccountGroup.Text & "')")
        End If
    End Sub

    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged
        If TxtLedgerName.Text.Length = 0 Then
            LoadLedgerAccounts()
        Else
            LoadLedgerAccounts(" where  LedgerName LIKE N'%" & TxtLedgerName.Text & "%'")
        End If
    End Sub

    Private Sub TxtLedgerCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerCity.TextChanged
        If TxtLedgerCity.Text.Length = 0 Then
            LoadLedgerAccounts()
        Else
            LoadLedgerAccounts(" where  address LIKE N'%" & TxtLedgerCity.Text & "%'")
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub


        Dim kfrm As New LedgersPrintOptions("Ledgers", TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value)
        kfrm.ShowDialog()
        kfrm.Dispose()
        'If RepSqlStr.Length = 0 Then Exit Sub
        'Me.Cursor = Cursors.WaitCursor
        'Dim ds As New DataSet
        'Dim cnn As SqlConnection

        'cnn = New SqlConnection(ConnectionStrinG)
        'cnn.Open()
        'RepSqlStr = "Select * from Ledgers " & RepSqlStr

        'Dim dscmd As New SqlDataAdapter(RepSqlStr, cnn)
        'dscmd.Fill(ds, "ledgers")
        'cnn.Close()
        'Dim objRpt As New LedgerDetailsCRReport

        'SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        'If PrintOptionsforCR.IsPrintHeader = False Then
        '    CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        '    CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text =UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
        '    CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT LEDGERS"
        'Else
        '    CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT LEDGERS"
        'End If

        'objRpt.SetDataSource(ds)
        'Dim FRM As New ReportCommonForm(objRpt)
        'FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        'Me.Cursor = Cursors.Default
        'FRM.ShowDialog()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        If IslOaded = False Then Exit Sub
        Dim v_isactive As Integer

        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM LEDGERS WHERE LEDGERNAME=N'" & TxtList.Item("Ledger Name", e.RowIndex).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            btnActivate.Text = "Activate"
        Else
            btnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivate.Click, AcitvateToolStripMenuItem.Click
        If IslOaded = False Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If BtnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE LEDGERS SET ISACTIVE=1 WHERE LEDGERNAME=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "DeActivate"
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE LEDGERS SET ISACTIVE=0 WHERE LEDGERNAME=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "Activate"
                TxtList.Focus()
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Ledger Name to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SQLGetNumericFieldValue("select Isprimary from ledgers where ledgername=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "' ", "Isprimary") = 1 Then
            MsgBox("The Selected Ledger is Primary Ledger, It is not be Deleted.... ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgerbook where ledgername=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "' and transcode>0") = True Then
            MsgBox("The Ledger is already used in accounts, It is not possible to delete this ledger..")
            Exit Sub
        Else

            If MsgBox("Do You want to Delete The Ledger Account ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("Delete from ledgers where ledgername=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "'")
                ExecuteSQLQuery("Delete from ledgerbook where ledgername=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "'")
                ExecuteSQLQuery("UPDATE DEFLEDGERS SET ledgername=N'' WHERE ledgername=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "'")
                LoadDefLedgerValues()
                LoadLedgerAccounts()
            End If

        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        Dim v_isactive As Integer
        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM LEDGERS WHERE LEDGERNAME=N'" & TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE")
       
        Dim k As New CreateLedgerAccounts(TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value)
        If v_isactive = 0 Then
            k.TxtLedgerName.Enabled = False
        End If
        k.ShowDialog()
        LoadLedgerAccounts()
        LoadDefLedgerValues()
        LoadPOSSettings()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click, ReportsToolStripMenuItem.Click
        If TxtList.SelectedRows.Count > 0 Then
            Dim K As New MonthlyAccountBalanceSheet(TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value)
            Me.Cursor = Cursors.WaitCursor
            K.SuspendLayout()
            K.MdiParent = MainForm
            K.Dock = DockStyle.Fill
            K.TxtHeading.Text = UCase(TxtList.Item("Ledger Name", TxtList.CurrentRow.Index).Value) & " " & " BALANCE SHEET"
            K.Show()
            K.WindowState = FormWindowState.Maximized
            K.BringToFront()
            K.ResumeLayout()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New ImportLedgerMaster
        frm.ShowDialog()

        LoadLedgerAccounts()
    End Sub
End Class