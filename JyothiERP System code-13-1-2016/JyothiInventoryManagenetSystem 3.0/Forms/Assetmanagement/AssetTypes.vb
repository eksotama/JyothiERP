Imports System.Data.SqlClient

Public Class AssetTypes
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Dim StockGrpName As String = ""
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
    Sub loadstockgroups(Optional ByVal SearchStr As String = "")
        Dim Sqlstr As String
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY AssetGroupName) AS [S.NO],rtrim(AssetGroupName) AS [ASSET TYPE],rtrim(groupRoot) AS [UNDER TYPE] FROM assetgroups"
        Sqlstr = Sqlstr & SearchStr
        Dim TempBS As New BindingSource
        ' Me.TxtList.Rows.Clear()
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
        LoadDatainListView(SearchStr)
        TxtTree.ExpandAll()
    End Sub

    Sub LoadDatainListView(Optional ByVal SearchSqlstr As String = "")
        TxtTree.Nodes.Clear()
        Dim rootNode As TreeNode
        Dim SqlStr As String
        If SearchSqlstr.Length = 0 Then
            SqlStr = "select AssetGroupName from assetgroups WHERE grouplevel=2"
        Else
            SqlStr = "select AssetGroupName from assetgroups " & SearchSqlstr & " and grouplevel=2"
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
                rootNode = New TreeNode(Sreader("AssetGroupName").ToString.Trim)
                LoadSubNodes(Sreader("AssetGroupName").ToString.Trim, rootNode)
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
            Dim dscmd As New SqlDataAdapter("select AssetGroupName from assetgroups where grouproot=N'" & GpName & "'", cnn)
            Dim table As New DataTable
            dscmd.Fill(table)
            cnn.Close()
            Dim aNode As TreeNode
            For counter = 0 To table.Rows.Count - 1
                aNode = New TreeNode(table.Rows(counter).Item("AssetGroupName").ToString.Trim)
                LoadSubNodes(table.Rows(counter).Item("AssetGroupName").ToString.Trim, aNode)
                nodeToAddTo.Nodes.Add(aNode)
            Next
        Catch ex As Exception

        End Try


    End Sub


#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim K As New CreateAssetType
        K.ShowDialog()
        loadstockgroups()
    End Sub

    Private Sub AssetTypes_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtTree.Dock = DockStyle.Fill
        TxtList.Dock = DockStyle.Fill
        loadstockgroups()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
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
                StockGrpName = TxtTree.SelectedNode.Text
            Catch ex As Exception
                MsgBox("Please Select the Asset Type  ....")
                Exit Sub
            End Try
        Else
            If TxtList.SelectedRows.Count = 0 Then Exit Sub
            If TxtList.Item("ASSET TYPE", TxtList.CurrentRow.Index).Value = "*Primary" Then
                MsgBox("The Primary group is not editable....", MsgBoxStyle.Information)
                Exit Sub
            End If
            StockGrpName = TxtList.Item("ASSET TYPE", TxtList.CurrentRow.Index).Value
        End If



        If SQLIsFieldExists("select assettype from assets where assettype=N'" & StockGrpName & "'") = True Then
            MsgBox("The ASSET TYPE already used in Assets , it is not possible to delete ...", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to delete ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("delete from assetgroups where AssetGroupName=N'" & StockGrpName & "'")
            loadstockgroups()
        End If
    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        If TxtSearch.Text.Length = 0 Then
            loadstockgroups()
        Else
            loadstockgroups("  where AssetGroupName LIKE N'%" & TxtSearch.Text & "%'")
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, No possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If CheckBox1.Checked = True Then
            Try
                StockGrpName = TxtTree.SelectedNode.Text
            Catch ex As Exception
                MsgBox("Please Select the ASSET TYPE Name ....")
                Exit Sub
            End Try
        Else
            If TxtList.SelectedRows.Count = 0 Then Exit Sub
            If TxtList.Item("ASSET TYPE", TxtList.CurrentRow.Index).Value = "*Primary" Then
                MsgBox("The Primary group is not editable....", MsgBoxStyle.Information)
                Exit Sub
            End If
            StockGrpName = TxtList.Item("ASSET TYPE", TxtList.CurrentRow.Index).Value
        End If


        If MsgBox("Do you want to Edit ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim K As New CreateAssetType(StockGrpName)
            K.ShowDialog()
            loadstockgroups()
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New ASSETTYPEMASTERDATASET
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT * from assetgroups", cnn)
        dscmd.Fill(ds, "assetgroups")
        cnn.Close()
        Dim objRpt As New AssetGroupMasterReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "ASSET TYPES "
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "ASSET TYPES "

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