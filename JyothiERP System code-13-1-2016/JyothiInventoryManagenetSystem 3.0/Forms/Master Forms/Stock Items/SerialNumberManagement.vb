Public Class SerialNumberManagement
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
    Sub LoadData(Optional ByVal WhereSqlStr As String = "")
        MainForm.Cursor = Cursors.WaitCursor
        Dim Sqlstr As String
        'STATUS=0 FOR NEW STATUS=1 PURCHASED STATUS=2 SOLD

        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNo], [StockCode] as [Stock Code], [StockSize] as [Stock Size],SERIALNUMBER as [Serial Number],note1 as [Description], (CASE WHEN (SELECT COUNT(*) FROM stockserialnos WHERE stockserialnos.StockCode=serialnumbermaster.STOCKCODE AND stockserialnos.STOCKSIZE=serialnumbermaster.STOCKSIZE)=0 THEN 'NEW' ELSE 'USED' END) AS [Status] FROM [serialnumbermaster] "

        'serialnumbermaster
        Sqlstr = Sqlstr & WhereSqlStr

        Dim TempBS As New BindingSource



        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            If TxtFilterByStatus.Text = "USED" Then
                TempBS.Filter = " Status='USED' "
            ElseIf TxtFilterByStatus.Text = "NEW" Then
                TempBS.Filter = " Status='NEW' "
            End If
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            Me.TxtList.Columns("SNo").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("SNo").Width = 80

            Me.TxtList.Columns("Stock Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns("Stock Code").Width = 180

            Me.TxtList.Columns("Stock Size").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Stock Size").Width = 180

            Me.TxtList.Columns("Serial Number").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Serial Number").Width = 180

            Me.TxtList.Columns("Description").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Description").Width = 180

            Me.TxtList.Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Status").Width = 100

        Catch ex As Exception

        End Try

        MainForm.Cursor = Cursors.Default
    End Sub
#End Region

   
    Private Sub TxtFilterByStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByStatus.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim frm As New createnewserialnumbers
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.Item("Status", TxtList.CurrentRow.Index).Value = "NEW" Then
            Dim frm As New createnewserialnumbers(TxtList.Item("Stock Code", TxtList.CurrentRow.Index).Value, TxtList.Item("Stock size", TxtList.CurrentRow.Index).Value, TxtList.Item("Serial Number", TxtList.CurrentRow.Index).Value)
            frm.ShowDialog()
            LoadData()
        Else
            MsgBox("The Serial Number already in used for Invoices, It it not editable  ...", MsgBoxStyle.Critical)
        End If
       
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.Item("Status", TxtList.CurrentRow.Index).Value = "NEW" Then
            If MsgBox("Do you want to Delete selected Serial Number ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM serialnumbermaster WHERE STOCKCODE=N'" & TxtList.Item("Stock code", TxtList.CurrentRow.Index).Value & "' AND STOCKSIZE=N'" & TxtList.Item("Stock Size", TxtList.CurrentRow.Index).Value & "' AND SERIALNUMBER=N'" & TxtList.Item("Serial Number", TxtList.CurrentRow.Index).Value & "'")
                LoadData()
            End If
        Else
            MsgBox("The Serial Number already in used for Invoices, It it not be Delete  ...", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub SerialNumberManagement_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtFilterByStatus.Text = "NEW"
    End Sub

    Private Sub ImsButton4_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New SerialNumberMasterDataSet
        ds.Clear()

        ds.Tables(0).Rows.Clear()

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

        Dim objRpt As New SerialNumberMasterCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SERIAL NUMBERS REPORT"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "SERIAL NUMBERS REPORT"
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