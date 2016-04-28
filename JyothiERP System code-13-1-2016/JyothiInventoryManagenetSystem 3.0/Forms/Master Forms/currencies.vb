Public Class currencies
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
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
    Sub loadLists(Optional ByVal SQLStrTemp As String = "")
        Dim Sqlstr As String = ""
        If SQLStrTemp.Length = 0 Then
            'Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY grouproot) AS [S.NO],rtrim(GroupName) AS [ACCOUNT GROUP],rtrim(groupRoot) AS [UNDER GROUP], (case ISPRIMARY when 1 then 'Primary' ELSE  'SubGroup' END) AS [GROUP TYPE]  FROM accountgroups order by grouproot"
            Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] ,[CurrencyName],[CurrencyCode],[CurrencySymbol],[IsActive]  FROM [CurrenciesList]"
        Else
            Sqlstr = SQLStrTemp
        End If
        Dim TempBS As New BindingSource
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(0).Width = 45
        Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(1).Width = 350
        Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(2).Width = 250

    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Dim K As New CreateNewCurrency
        K.ShowDialog()
        loadLists()
        loadLists()
    End Sub

    Private Sub currencies_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AccountGroups_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadLists()
        UpdateLogFile(DefStoreName, 0, "Currencies", "0", CurrentUserName, "Accessed", System.Environment.MachineName, "Currencies Accessed")
    End Sub

    Private Sub TxtFilterByGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByCurName.TextChanged

        If TxtFilterByCurName.Text.Length = 0 Then
            loadLists("SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] ,[CurrencyName],[CurrencyCode],[CurrencySymbol],[IsActive]  FROM [Currencies]")
        Else
            loadLists("SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] ,[CurrencyName],[CurrencyCode],[CurrencySymbol],[IsActive]  FROM [Currencies] where CurrencyName like N'%" & TxtFilterByCurName.Text & "%'")
        End If
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Dispose()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click

        'If TxtList.SelectedRows.Count = 0 Then
        '    MsgBox("Please Select the Group Name to delete ....")
        '    Exit Sub
        'ElseIf Len(TxtList.Item("UNDER GROUP", TxtList.CurrentRow.Index).Value) = 0 Then
        '    MsgBox("The Primary Groups can't be deleted......")
        '    Exit Sub
        'Else
        '    If IsAllowToDeleteAccountGroup(TxtList.Item("ACCOUNT GROUP", TxtList.CurrentRow.Index).Value) = False Then
        '        MsgBox("The Selected Group curretly used by ledger(s) ..., Delete is not allowed....")
        '        Exit Sub
        '    Else
        '        If MsgBox("Are u sure, Do you want to delete the selected group...", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
        '            ExecuteSQLQuery("DELETE FROM AccountGroups WHERE AccountGroup='" & TxtList.Item("ACCOUNT GROUP", TxtList.CurrentRow.Index).Value & "'")
        '            loadLists()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        'If TxtList.SelectedRows.Count = 0 Then
        '    MsgBox("Please Select the Group Name to Edit....")
        '    Exit Sub
        'Else
        '    Dim K As New CreateAccountGroups(TxtList.Item("ACCOUNT GROUP", TxtList.CurrentRow.Index).Value)
        '    K.ShowDialog()
        '    loadAccountgroups()
        'End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        'Dim ds As New DataSet1
        'Dim cnn As SqlConnection
        'Dim sql As String
        'cnn = New SqlConnection(ConnectionStrinG)
        'cnn.Open()
        'sql = "SELECT * FROM accountgroups"
        'Dim dscmd As New SqlDataAdapter(sql, cnn)
        'dscmd.Fill(ds, "accountgroups")
        'cnn.Close()
        'Dim objRpt As New AccountGroupsCRReport
        'CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
        'CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text =UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
        'CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT GROUPS"
        'objRpt.SetDataSource(ds)
        'Dim FRM As New ReportCommonForm(objRpt)
        'FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        'FRM.ShowDialog()
    End Sub
End Class