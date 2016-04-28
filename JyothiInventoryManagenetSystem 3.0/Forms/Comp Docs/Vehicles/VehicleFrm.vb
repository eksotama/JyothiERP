Public Class VehicleFrm

    Dim Sqlstr As String = ""
    Dim IslOaded As Boolean = False
    Dim RepSqlStr As String = ""
#Region "Functions"
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadEmployeeList(Optional ByVal sqlText As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        RepSqlStr = ""
        If TxtShowAll.Checked = True Then
            Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY VHID) AS [S.NO], VHID as [ID],VHRefNo [Ref],VHName as [Vehicle Name],VhNo as [Vehicle No],IssuedBy as [Issued By],ExpiryDate as [Expiry],DriverName1 as [Driver], (case when ISACTIVE=0 then 'NO' else 'YES' end) as [Active] from Vehicle where isdelete>=0"
            RepSqlStr = " where isdelete>=0 "
        Else
            Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY VHID) AS [S.NO],VHID as [ID],VHRefNo [Ref],VHName as [Vehicle Name],VhNo as [Vehicle No],IssuedBy as [Issued By],ExpiryDate as [Expiry],DriverName1 as [Driver], (case when ISACTIVE=0 then 'NO' else 'YES' end) as [Active] from Vehicle where isdelete=0"
            RepSqlStr = " where isdelete=0 "
        End If
        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & sqlText
            RepSqlStr = RepSqlStr & sqlText
        End If
        If TxtDocType.Text.Length = 0 Or TxtDocType.Text = "*All" Then
        Else
            Sqlstr = Sqlstr & " and VhType=N'" & TxtDocType.Text & "'"
            RepSqlStr = RepSqlStr & " and VhType=N'" & TxtDocType.Text & "'"
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
            Me.TxtList.Columns(0).Width = 150
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 65
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 250

            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 80

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 250
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateNewVehicle
        k.ShowDialog()
        k.Dispose()
        LoadEmployeeList()

    End Sub

    Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
        Dim expDate As New Date
        Dim Days As Integer = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("Active", i).Value = "NO" Then
                TxtList.Rows(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
            'ExpiryDate
            'Expiry
            expDate = TxtList.Item("Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtList.Item("Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtList.Item("Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtList.Item("Expiry", i).Style.BackColor = Color.LightGreen
            End If
        Next
    End Sub




    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        ' On Error Resume Next
        If IslOaded = False Then Exit Sub
        Dim v_isactive As Integer

        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM Vehicle WHERE vhname=N'" & TxtList.Item("Vehicle Name", e.RowIndex).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            BtnActivate.Text = "Activate"
        Else
            BtnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivate.Click
        If IslOaded = False Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If BtnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Docs Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE Vehicle SET ISACTIVE=1 WHERE vhname=N'" & TxtList.Item("Vehicle Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "DeActivate"
                LoadEmployeeList()
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Docs Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE Vehicle SET ISACTIVE=0 WHERE vhname=N'" & TxtList.Item("Vehicle Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "Activate"
                LoadEmployeeList()
                TxtList.Focus()
            End If
        End If
    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim v_isactive As Integer
        v_isactive = SQLGetNumericFieldValue("SELECT ISACTIVE FROM Vehicle WHERE vhname=N'" & TxtList.Item("Vehicle Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE")
        If v_isactive = 0 Then
            MsgBox("This Docs Account is In-Active...., Edit is not possible....")
            Exit Sub
        End If
        Dim k As New CreateNewVehicle(TxtList.Item("Vehicle Name", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
        k.Dispose()
        LoadEmployeeList()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Vehicle Name to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do you want to Deleted the selected Docs Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("UPDATE Vehicle SET isdelete=1 WHERE vhname=N'" & TxtList.Item("Vehicle Name", TxtList.CurrentRow.Index).Value & "'")
            LoadEmployeeList()
            TxtList.Focus()
        End If

    End Sub
    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadEmployeeList()
    End Sub


    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDocName.TextChanged
        If TxtDocName.Text.Length = 0 Then
            LoadEmployeeList()
        Else
            LoadEmployeeList("  and  vhname LIKE N'%" & TxtDocName.Text & "%'")
        End If
    End Sub

    Private Sub VehicleFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    'Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
    '    If TxtList.RowCount = 0 Then Exit Sub
    '    If RepSqlStr.Length = 0 Then Exit Sub
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim ds As New DataSet
    '    Dim cnn As SqlConnection

    '    cnn = New SqlConnection(ConnectionStrinG)
    '    cnn.Open()
    '    RepSqlStr = "Select * from Docs " & RepSqlStr

    '    Dim dscmd As New SqlDataAdapter(RepSqlStr, cnn)
    '    dscmd.Fill(ds, "Docs")
    '    cnn.Close()
    '    Dim objRpt As New LedgerDetailsCRReport
    '    CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
    '    CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text =UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
    '    CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF ACCOUNT Docs"
    '    objRpt.SetDataSource(ds)
    '    Dim FRM As New ReportCommonForm(objRpt)
    '    FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '    Me.Cursor = Cursors.Default
    '    FRM.ShowDialog()
    'End Sub

    Private Sub CompanyDocs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select distinct vhtype from Vehicle", TxtDocType, "vhtype", "*All")
        LoadEmployeeList()
        IslOaded = True
    End Sub


    Private Sub TxtShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShowAll.CheckedChanged
        LoadEmployeeList()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        Dim kfrm As New ViewVehicleFilesFrm(TxtList.Item("Vehicle Name", TxtList.CurrentRow.Index).Value)
        kfrm.ShowDialog()
        kfrm.Dispose()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New VehicleReportDataSet
        ds.Clear()
        For i As Integer = 0 To TxtList.RowCount - 1
            Dim row As DataRow
            row = ds.Tables(0).NewRow
            For k As Integer = 0 To TxtList.ColumnCount - 1
                Try
                    row(TxtList.Columns(k).Name) = TxtList.Item(k, i).Value
                Catch ex As Exception
                    row(TxtList.Columns(k).Name) = 0
                End Try

            Next
            ds.Tables(0).Rows.Add(row)
        Next
        Dim objRpt As New VehicleDCrReport

        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF VEHICLE"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "LIST OF VEHICLE"

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

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim kfrm As New ViewFullVehileDetails
        kfrm.ShowDialog()
        kfrm.Dispose()
    End Sub
End Class