Imports System.Data.SqlClient

Public Class StockCategories
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim AlterCatName As String = ""
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
    Sub loadCategories(Optional ByVal SearchSqlstr As String = "")
        Dim Sqlstr As String = ""
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCategoryName) AS [S.NO],rtrim(StockCategoryName) AS [STOCK CATEGORY],rtrim(groupRoot) AS [UNDER GROUP] FROM categoriesgroups"
        Sqlstr = Sqlstr & SearchSqlstr
        Dim TempBS As New BindingSource
        '   Me.TxtList.Rows.Clear()
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
        Me.TxtList.Columns(2).Width = 350

        LoadDatainListView(SearchSqlstr)
        TxtTree.ExpandAll()
    End Sub
    Sub LoadDatainListView(Optional ByVal SearchSqlstr As String = "")
        TxtTree.Nodes.Clear()
        Dim rootNode As TreeNode
        Dim SqlStr As String = ""
        If SearchSqlstr.Length = 0 Then
            SqlStr = "select StockCategoryName from Categoriesgroups WHERE grouplevel=2 "
        Else
            SqlStr = "select StockCategoryName from Categoriesgroups " & SearchSqlstr & " and grouplevel=2"
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
                rootNode = New TreeNode(Sreader("StockCategoryName").ToString.Trim)
                LoadSubNodes(Sreader("StockCategoryName").ToString.Trim, rootNode)
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

        Try
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter("select StockCategoryName from Categoriesgroups where grouproot=N'" & GpName & "'", cnn)
            Dim table As New DataTable
            dscmd.Fill(table)
            cnn.Close()
            Dim aNode As TreeNode
            For counter = 0 To table.Rows.Count - 1
                aNode = New TreeNode(table.Rows(counter).Item("StockCategoryName").ToString.Trim)
                LoadSubNodes(table.Rows(counter).Item("StockCategoryName").ToString.Trim, aNode)
                nodeToAddTo.Nodes.Add(aNode)
            Next

        Catch ex As Exception

        End Try
      


        'Dim sqlcon As New SqlClient.SqlConnection
        'Dim sqlcmd As New SqlClient.SqlCommand
        'Dim aNode As TreeNode
        'Try
        '    sqlcon.ConnectionString = ConnectionStrinG
        '    sqlcon.Open()
        '    sqlcmd.Connection = sqlcon
        '    sqlcmd.CommandText = "select StockCategoryName from Categoriesgroups where grouproot=N'" & GpName & "'"
        '    sqlcmd.CommandType = CommandType.Text
        '    Dim Sreader1 As SqlClient.SqlDataReader
        '    Sreader1 = sqlcmd.ExecuteReader
        '    While Sreader1.Read()
        '        aNode = New TreeNode(Sreader1("StockCategoryName").ToString.Trim)
        '        LoadSubNodes(Sreader1("StockCategoryName").ToString.Trim, aNode)

        '        nodeToAddTo.Nodes.Add(aNode)
        '    End While
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    sqlcon.Close()
        '    sqlcmd.Connection = Nothing
        'End Try

    End Sub



#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim CATFRM As New CreateStockCategories
        CATFRM.ShowDialog()
        loadCategories()
    End Sub

    Private Sub StockCategories_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtTree.Dock = DockStyle.Fill
        TxtList.Dock = DockStyle.Fill
        loadCategories()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click, EditToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Edit Restricted by the Admin, No possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If CheckBox1.Checked = True Then
            Try
                AlterCatName = TxtTree.SelectedNode.Text
            Catch ex As Exception
                MsgBox("Please Select the Stock Categories Name ....")
                Exit Sub
            End Try
        Else
            AlterCatName = TxtList.Item("STOCK CATEGORY", TxtList.CurrentRow.Index).Value
        End If
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        Dim CATGRM As New CreateStockCategories(AlterCatName)
        CATGRM.ShowDialog()
        loadCategories()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If CheckBox1.Checked = True Then
            Try
                AlterCatName = TxtTree.SelectedNode.Text
            Catch ex As Exception
                MsgBox("Please Select the Stock Categories Name ....")
                Exit Sub
            End Try

        Else
            If TxtList.SelectedRows.Count = 0 Then Exit Sub
            AlterCatName = TxtList.Item("STOCK CATEGORY", TxtList.CurrentRow.Index).Value
        End If

        If SQLIsFieldExists("SELECT category FROM STOCKDBF WHERE category=N'" & AlterCatName & "'") = True Then
            MsgBox("The Selected Catergory Name is already used , It can't be deleted...")
            Exit Sub
        Else
            If MsgBox("Do you want to Delete the selected Category Name ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from categoriesgroups where StockCategoryName=N'" & AlterCatName & "'")
                ReArrangeStockCategories()
                loadCategories()
            End If
        End If
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loadCategories()
    End Sub

    Private Sub TxtSearchBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchBy.TextChanged
        If TxtSearchBy.Text.Length = 0 Then
            loadCategories()
        Else
            loadCategories(" where StockCategoryName LIKE N'%" & TxtSearchBy.Text & "%'")
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim CATFRM As New CreateStockCategories
        CATFRM.ShowDialog()
        loadCategories()
    End Sub


    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT * from categoriesgroups", cnn)
        dscmd.Fill(ds, "categoriesgroups")
        cnn.Close()
        Dim objRpt As New StockCategoriesMasteReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK CATEGORIES REPORTS"
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "STOCK CATEGORIES REPORTS"

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
End Class