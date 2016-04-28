Imports System.Data.SqlClient

Public Class StockBatchWiseDetails
    Dim IslOaded As Boolean = False
    Dim WhereConditionSqlStr As String = ""
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
    'If IsDBNull(Dbf.Fields("photopath").Value) = False Then
    '                        CType(MembersList.Item("cphoto", i), DataGridViewImageCell).Value = Image.FromFile(Dbf.Fields("photopath").Value)
    '                    End If
#Region "Functions"
    Sub loadstockitems(Optional ByVal WhereSqlStr As String = "")
        MainForm.Cursor = Cursors.WaitCursor
        Dim Sqlstr As String
        If TxtIsPeriod.Checked = True Then
            If WhereSqlStr.Length = 0 Then
                WhereSqlStr = " where (expiryDateValue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            Else
                WhereSqlStr = WhereSqlStr & "  and (expiryDateValue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"
            End If
            Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY BatchNo) AS [SNo],[location] as [Location],  [StockCode] as [Stock Code], [StockSize] as [Stock Size], BATCHNO AS [Batch No],expiry as [Expiry],mrp as [MRP Price], qtytext as [Qty]  FROM [Stockbatch] "
        Else
            Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY BatchNo) AS [SNo],[location] as [Location],  [StockCode] as [Stock Code], [StockSize] as [Stock Size], BATCHNO AS [Batch No],expiry as [Expiry],mrp as [MRP Price], qtytext as [Qty]  FROM [Stockbatch]"
        End If


        Sqlstr = Sqlstr & WhereSqlStr
        WhereConditionSqlStr = WhereSqlStr
        Dim TempBS As New BindingSource

        Try
            TxtList.Columns.Remove("SImage")

        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try

            Me.TxtList.Columns("SNo").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("SNo").Width = 35
            Me.TxtList.Columns("Expiry").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Expiry").DefaultCellStyle.Format = "MM/yyyy"
            Me.TxtList.Columns("Expiry").Width = 100
            Me.TxtList.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Location").Width = 120

            Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Stock Code").Width = 180

            Me.TxtList.Columns("Stock Size").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Size").Width = 180
            ' BATCHNO AS [Batch No],expiry as [Expiry],mrp as [MRP Price] 
            Me.TxtList.Columns("Batch No").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Batch No").Width = 150

          

            Me.TxtList.Columns("MRP Price").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("MRP Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.TxtList.Columns("MRP Price").Width = 120

            Me.TxtList.Columns("qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("qty").Width = 150
        Catch ex As Exception

        End Try
        Try
            If AppIsItemwithSize = False Then
                TxtList.Columns("Stock Size").Visible = False
            End If
        Catch ex As Exception

        End Try


        MainForm.Cursor = Cursors.Default
    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        'Dim k As New CreateNewStockItem
        'k.ShowDialog()
        'loadstockitems()
    End Sub

    Private Sub StockBatchWiseDetails_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select locationname from STOCKLOCATIONS", TxtFilterBy, "locationname", "*All")
        TxtStartDate.Value = Today.AddMonths(-1)
        TxtEndDate.Value = Today.AddYears(5)
        loadstockitems()
        IslOaded = True
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub

        If TxtList.RowCount = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New stockbatchdataset
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT * FROM STOCKBATCH  " & WhereConditionSqlStr, cnn)
        dscmd.Fill(ds, "stockbatch")
        cnn.Close()
        Dim objRpt As New CurrentStockCrReportBatchwise
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "CURRENT STOCK REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "CURRENT STOCK REPORT"

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



    Private Sub TxtFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterBy.SelectedIndexChanged
        If TxtFilterBy.Text.Length = 0 Or TxtFilterBy.Text = "*All" Then
            loadstockitems()
        Else
            loadstockitems(" where location=N'" & TxtFilterBy.Text & "'")
        End If
    End Sub

    Private Sub TxtSearchByStockItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchByStockItem.TextChanged
        If TxtSearchByStockItem.Text.Length = 0 Then
            loadstockitems()
        Else
            loadstockitems(" where stockcode like N'%" & TxtSearchByStockItem.Text & "%'")
        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If IsTrailApplication = True Then
            MsgBox("Edit and Delete is not allowed in trail version....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from   StockInvoiceRowItems where stockcode=N'" & TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value & "' and stocksize=N'" & TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value & "' and batchno=N'" & TxtList.Item("Batch no", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Selected Batch Number is already in use, It can not be Delete......", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Application.OpenForms.Count > 2 Then
            MsgBox("Please Close all Forms before delete the Item...", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsthereanyUsersLogin() = True Then
            MsgBox("Some Users are in login, It it not possible to delete at this time...", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to delete the current Seleted Batch number ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If IsthereanyUsersLogin() = True Then
                MsgBox("Some Users are in login, It it not possible to delete at this time...", MsgBoxStyle.Critical)
                Exit Sub
            Else
                ExecuteSQLQuery("delete from stockbatch where stockcode=N'" & TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value & "' and stocksize=N'" & TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value & "' and batchno=N'" & TxtList.Item("Batch no", TxtList.CurrentRow.Index).Value & "'")
                loadstockitems()
            End If
        End If
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loadstockitems()
    End Sub


    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If IsTrailApplication = True Then
            MsgBox("Edit is not allowed in trail version....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsEditable = False Then
            MsgBox("The Edit Restricted by the Admin, Not possible to Edit......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Application.OpenForms.Count > 2 Then
            MsgBox("Please Close all Forms to prevent data.. and try again...", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Do you want to Alter the current Batch Details ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim bvalues As New newbatchexpiryClass
            bvalues.Batchno = TxtList.Item("batch no", TxtList.CurrentRow.Index).Value
            bvalues.stockcode = TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value
            bvalues.Mrp = CDbl(TxtList.Item("MRP Price", TxtList.CurrentRow.Index).Value)
            bvalues.Stocksize = TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value
            bvalues.StockLocation = TxtList.Item("Location", TxtList.CurrentRow.Index).Value
            bvalues.Expirydate.Value = CDate(TxtList.Item("expiry", TxtList.CurrentRow.Index).Value)
            Dim TempBatchno As String = ""
            TempBatchno = bvalues.Batchno
            Dim frm As New ReadBatchExpiryInInvoice(bvalues, True)
            frm.ShowDialog()
            If bvalues.Batchno.Length > 0 Then
                ExecuteSQLQuery("update stockbatch set batchno=N'" & bvalues.Batchno & "' , mrp=" & bvalues.Mrp & ",expiry=CONVERT(datetime,'" & bvalues.Expirydate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) where stockcode=N'" & bvalues.stockcode & "' and Stocksize=N'" & bvalues.Stocksize & "' and location=N'" & bvalues.StockLocation & "' and batchno=N'" & TempBatchno & "'")
                ExecuteSQLQuery("update StockInvoiceRowItems set batchno=N'" & bvalues.Batchno & "' , mrp=" & bvalues.Mrp & ",expiry=CONVERT(datetime,'" & bvalues.Expirydate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) where stockcode=N'" & bvalues.stockcode & "' and Stocksize=N'" & bvalues.Stocksize & "' and location=N'" & bvalues.StockLocation & "' and batchno=N'" & TempBatchno & "'")
                loadstockitems()
            End If
         

        End If
    End Sub

    Private Sub TxtSearchbyStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchbyStockBatchno.TextChanged
        If TxtSearchbyStockBatchno.Text.Length = 0 Then
            loadstockitems()
        Else
            loadstockitems(" where batchno like N'%" & TxtSearchbyStockBatchno.Text & "%'")
        End If
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        If TxtFilterBy.Text.Length = 0 Or TxtFilterBy.Text = "*All" Then
            loadstockitems()
        Else
            loadstockitems(" where location=N'" & TxtFilterBy.Text & "'")
        End If
    End Sub
End Class