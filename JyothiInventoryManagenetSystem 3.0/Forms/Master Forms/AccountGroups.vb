Imports System.Data.SqlClient

Public Class AccountGroups
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim AlterGroupName As String = ""
    Dim SearchSqlstr As String = ""
    Public Shared LedgersBalaceReportFrom As LedgerBalanceSheetForm
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
    Sub loadAccountgroups(Optional ByVal SQLStrTemp As String = "")
        Dim Sqlstr As String = ""
        If SQLStrTemp.Length = 0 Then
            Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY grouproot) AS [S.NO],rtrim(GroupName) AS [ACCOUNT GROUP],rtrim(groupRoot) AS [UNDER GROUP], (case ISPRIMARY when 1 then 'Primary' ELSE  'SubGroup' END) AS [GROUP TYPE]  FROM accountgroups order by grouproot "
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
        For i As Integer = 0 To Me.TxtList.RowCount - 1
            If IsDBNull(Me.TxtList.Item(2, i).Value) = True Then
                Me.TxtList.Item(2, i).Value = "*Primary"
            End If
        Next
        LoadDatainListView()
        TxtTree.ExpandAll()
    End Sub

    Sub LoadDatainListView()
        TxtTree.Nodes.Clear()
        Dim rootNode As TreeNode
        Dim SqlStr As String = ""
        If SearchSqlstr.Length = 0 Then
            SqlStr = "select GroupName from AccountGroups WHERE grouplevel=0 "
        Else
            SqlStr = "select GroupName from AccountGroups where  " & SearchSqlstr '& " and grouplevel=0 "
        End If


        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim SQLFcmd12 As New SqlClient.SqlCommand
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            SQLFcmd12.Connection = SqlConn2
            SQLFcmd12.CommandText = SqlStr
            SQLFcmd12.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd12.ExecuteReader
            While Sreader.Read()
                rootNode = New TreeNode(Sreader("GroupName").ToString.Trim)
                LoadSubNodes(Sreader("GroupName").ToString.Trim, rootNode)
                TxtTree.Nodes.Add(rootNode)

            End While
            Sreader.Close()
        Catch ex As Exception

        Finally
            SqlConn2.Close()
            SQLFcmd.Connection = Nothing
        End Try




    End Sub
    Sub LoadSubNodes(ByVal GpName As String, ByVal nodeToAddTo As TreeNode)
        'Dim sqlcon As New SqlClient.SqlConnection

        'Dim aNode As TreeNode
        'Try
        '    Dim sqlcmd As New SqlClient.SqlCommand
        '    sqlcon.ConnectionString = ConnectionStrinG
        '    sqlcon.Open()
        '    sqlcmd.Connection = sqlcon

        '    sqlcmd.CommandText = "select GroupName from AccountGroups where grouproot=N'" & GpName & "'"
        '    sqlcmd.CommandType = CommandType.Text
        '    Dim Sreader1 As SqlClient.SqlDataReader
        '    Sreader1 = sqlcmd.ExecuteReader
        '    While Sreader1.Read()
        '        aNode = New TreeNode(Sreader1("GroupName").ToString.Trim)
        '        LoadSubNodes(Sreader1("GroupName").ToString.Trim, aNode)
        '        nodeToAddTo.Nodes.Add(aNode)
        '    End While
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    sqlcon.Close()

        'End Try
        Try
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter("select GroupName from AccountGroups where grouproot=N'" & GpName & "'", cnn)
            Dim table As New DataTable
            dscmd.Fill(table)
            cnn.Close()
            Dim aNode As TreeNode
            For counter = 0 To table.Rows.Count - 1
                aNode = New TreeNode(table.Rows(counter).Item("GroupName").ToString.Trim)
                LoadSubNodes(table.Rows(counter).Item("GroupName").ToString.Trim, aNode)
                nodeToAddTo.Nodes.Add(aNode)
            Next
        Catch ex As Exception

        End Try
      

    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        NewFuction()
    End Sub
    Sub NewFuction()
        Dim K As New CreateAccountGroups
        K.ShowDialog()
        loadAccountgroups()
    End Sub

    Private Sub AccountGroups_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub AccountGroups_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtTree.Dock = DockStyle.Fill
        TxtList.Dock = DockStyle.Fill
        LoadDataIntoComboBox("select groupname from AccountGroups where isprimary=1", TxtPrimaryGroup, "groupname", "*All")
        loadAccountgroups()

        UpdateLogFile(DefStoreName, 0, "AccountGroup", "0", CurrentUserName, "Accessed", System.Environment.MachineName, "Account Groups Accessed")
    End Sub

    Private Sub TxtFilterByGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByGroup.TextChanged

        If TxtFilterByGroup.Text.Length = 0 Then
            SearchSqlstr = ""
            loadAccountgroups("SELECT ROW_NUMBER() OVER (ORDER BY grouproot) AS [S.NO],rtrim(GroupName) AS [ACCOUNT GROUP],rtrim(groupRoot) AS [UNDER GROUP], (case ISPRIMARY when 1 then 'Primary' ELSE  'SubGroup' END) AS [GROUP TYPE]  FROM accountgroups order by grouproot")

        Else
            SearchSqlstr = "GroupName LIKE N'%" & TxtFilterByGroup.Text & "%'"
            loadAccountgroups("SELECT ROW_NUMBER() OVER (ORDER BY grouproot) AS [S.NO],rtrim(GroupName) AS [ACCOUNT GROUP],rtrim(groupRoot) AS [UNDER GROUP], (case ISPRIMARY when 1 then 'Primary' ELSE  'SubGroup' END) AS [GROUP TYPE]  FROM accountgroups where GroupName LIKE N'%" & TxtFilterByGroup.Text & "%'  order by grouproot")

        End If
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click, CloseToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        DeleteFunction()
    End Sub
    Sub DeleteFunction()
        If CheckBox1.Checked = True Then
            Try
                AlterGroupName = TxtTree.SelectedNode.Text
            Catch ex As Exception
                MsgBox("Please Select the Stock Group Name ....")
                Exit Sub
            End Try
        Else
            If TxtList.SelectedRows.Count = 0 Then Exit Sub
            AlterGroupName = TxtList.Item("ACCOUNT GROUP", TxtList.CurrentRow.Index).Value
        End If
        If SQLGetNumericFieldValue("select isprimary from accountgroups where Groupname=N'" & AlterGroupName & "'", "isprimary") = 1 Then
            MsgBox("The Selected Group is Primary Group, It is not editable ....")
            Exit Sub
        End If


        If IsAllowToDeleteAccountGroup(AlterGroupName) = False Then
            MsgBox("The Selected Group curretly used by ledger(s) ..., Delete is not allowed....")
            Exit Sub
        Else
            If MsgBox("Are u sure, Do you want to delete the selected group...", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM AccountGroups WHERE Groupname=N'" & AlterGroupName & "'")
                loadAccountgroups()
            End If
        End If

        
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If CheckBox1.Checked = True Then
            Try
                AlterGroupName = TxtTree.SelectedNode.Text
            Catch ex As Exception
                MsgBox("Please Select the Stock Group Name ....")
                Exit Sub
            End Try
        Else
            If TxtList.SelectedRows.Count = 0 Then Exit Sub
            AlterGroupName = TxtList.Item("ACCOUNT GROUP", TxtList.CurrentRow.Index).Value
        End If
        If SQLGetNumericFieldValue("select isprimary from accountgroups where Groupname=N'" & AlterGroupName & "'", "isprimary") = 1 Then
            MsgBox("The Selected Group is Primary Group, It is not editable ....")
            Exit Sub
        End If
        Dim K As New CreateAccountGroups(AlterGroupName)
        K.ShowDialog()
        loadAccountgroups()
    End Sub
  
    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        PrintFunction()
    End Sub
    Sub PrintFunction()
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        Dim sql As String
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        sql = "SELECT * FROM accountgroups"
        Dim dscmd As New SqlDataAdapter(sql, cnn)
        dscmd.Fill(ds, "accountgroups")
        cnn.Close()
        Dim objRpt As New AccountGroupsCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT GROUPS"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT GROUPS"
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
  

   

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TxtList.Visible = False
            TxtTree.Visible = True
        Else
            TxtList.Visible = True
            TxtTree.Visible = False
        End If
    End Sub

  

    Private Sub TxtPrimaryGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrimaryGroup.SelectedIndexChanged
        If TxtPrimaryGroup.Text.Length = 0 Or TxtPrimaryGroup.Text = "*All" Then
            SearchSqlstr = ""
            loadAccountgroups("SELECT ROW_NUMBER() OVER (ORDER BY grouproot) AS [S.NO],rtrim(GroupName) AS [ACCOUNT GROUP],rtrim(groupRoot) AS [UNDER GROUP], (case ISPRIMARY when 1 then 'Primary' ELSE  'SubGroup' END) AS [GROUP TYPE]  FROM accountgroups order by grouproot")

        Else
            SearchSqlstr = " GroupName IN (select subgroup from AccountGroupsList where groupname=N'" & TxtPrimaryGroup.Text & "')"
            loadAccountgroups("SELECT ROW_NUMBER() OVER (ORDER BY grouproot) AS [S.NO],rtrim(GroupName) AS [ACCOUNT GROUP],rtrim(groupRoot) AS [UNDER GROUP], (case ISPRIMARY when 1 then 'Primary' ELSE  'SubGroup' END) AS [GROUP TYPE]  FROM accountgroups where GroupName IN (select subgroup from AccountGroupsList where groupname=N'" & TxtPrimaryGroup.Text & "')   order by grouproot")

        End If

    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Dim ViweGroupName As String = ""
        If CheckBox1.Checked = True Then
            Try
                ViweGroupName = TxtTree.SelectedNode.Text
            Catch ex As Exception
                MsgBox("Please Select the Stock Group Name ....")
                Exit Sub
            End Try
        Else
            If TxtList.SelectedRows.Count = 0 Then Exit Sub
            ViweGroupName = TxtList.Item("ACCOUNT GROUP", TxtList.CurrentRow.Index).Value
        End If

        If ViweGroupName.Length > 0 Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
                LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
                LedgersBalaceReportFrom.MdiParent = MainForm
                LedgersBalaceReportFrom.BringToFront()
                LedgerBalanceSheetForm.TxtHeading.Text = UCase(ViweGroupName) & " REPORT"
                LedgersBalaceReportFrom.TxtGroupName.Text = Trim(ViweGroupName)
                LedgersBalaceReportFrom.Dock = DockStyle.Fill
                LedgersBalaceReportFrom.Show()
                LedgersBalaceReportFrom.WindowState = FormWindowState.Maximized
            Else
                LedgersBalaceReportFrom.MdiParent = Me
                LedgersBalaceReportFrom.Dock = DockStyle.Fill
                LedgersBalaceReportFrom.Show()
                LedgersBalaceReportFrom.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If
       
    End Sub
End Class