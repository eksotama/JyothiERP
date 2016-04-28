Imports System.Data.SqlClient

Public Class Coupons
    Dim Sqlstr As String = ""
    Dim IslOaded As Boolean = False
    Dim RepSqlStr As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
#Region "Functions"

    Sub LoadCustomerList(Optional ByVal sqlText As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor

        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY Cname) AS [SNo], Cname as [Coupon Name],cper as [per], datefrom as [Date From], dateto as [Date To],MaxValues as [Max Value],UsedValue as [Used Value],(CASE WHEN MaxValues-UsedValue>=0 THEN MaxValues-UsedValue ELSE 0 END) as [Unused Value] ,isActive as [Status] from couponmaster "
        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & sqlText
        End If

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 55


            Me.TxtList.Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Status").Width = 150

            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(1).Width = 350
            Me.TxtList.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Me.TxtList.Columns("per").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("per").Width = 80
            Me.TxtList.Columns("per").DefaultCellStyle.Format = "N2"
            Me.TxtList.Columns("Per").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("Date From").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date From").Width = 100
            Me.TxtList.Columns("Date From").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Date From").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Date To").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date To").Width = 100
            Me.TxtList.Columns("Date To").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Date To").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Percentage").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Percentage").Width = 120
            Me.TxtList.Columns("Percentage").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Percentage").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("Max Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Max Value").Width = 120
            Me.TxtList.Columns("Max Value").DefaultCellStyle.Format = "N2"
            Me.TxtList.Columns("Max Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.TxtList.Columns("Used Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Used Value").Width = 120
            Me.TxtList.Columns("Used Value").DefaultCellStyle.Format = "N2"
            Me.TxtList.Columns("Used Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Unused Value").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Unused Value").Width = 120
            Me.TxtList.Columns("Unused Value").DefaultCellStyle.Format = "N2"
            Me.TxtList.Columns("Unused Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateNewCoupon
        k.ShowDialog()
        LoadCustomerList()

    End Sub

    Private Sub Coupons_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        LoadCustomerList()
        IslOaded = True

    End Sub



    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        If IslOaded = False Then Exit Sub



        If TxtList.Item("status", e.RowIndex).Value = False Then
            BtnActivate.Text = "Activate"
        Else
            BtnActivate.Text = "DeActivate"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivate.Click, ActivateToolStripMenuItem.Click
        If IslOaded = False Then Exit Sub
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If BtnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE couponmaster SET ISACTIVE='True' WHERE Cname=N'" & TxtList.Item("Coupon Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "DeActivate"
                TxtList.Item("status", TxtList.CurrentRow.Index).Value = True
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE couponmaster SET ISACTIVE='False' WHERE Cname=N'" & TxtList.Item("Coupon Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "Activate"
                TxtList.Item("status", TxtList.CurrentRow.Index).Value = False
                TxtList.Focus()
            End If
        End If
    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub

        Dim k As New CreateNewCoupon(TxtList.Item("Coupon Name", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
        k.Dispose()
        LoadCustomerList()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Coupon Name to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   StockInvoiceDetails where CouponName=N'" & TxtList.Item("Coupon Name", TxtList.CurrentRow.Index).Value & "' and transcode>0") = True Then
            MsgBox("The CouponName is already used in Invoice, It is not possible to delete..")
            Exit Sub
        Else
            If MsgBox("Do You want to Delete The Coupon Name  ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("Delete from couponmaster where Cname=N'" & TxtList.Item("Coupon Name", TxtList.CurrentRow.Index).Value & "'")
                LoadCustomerList()
            End If

        End If
    End Sub
    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadCustomerList()
    End Sub


    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged
        If TxtLedgerName.Text.Length = 0 Then
            LoadCustomerList()
        Else
            LoadCustomerList(" WHERE   Cname LIKE N'%" & TxtLedgerName.Text & "%'")
        End If
    End Sub





    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If Sqlstr.Length = 0 Then Exit Sub
        Dim ds As New CouponMasterDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim Tempstr As String = ""
        'Percentage 
        Tempstr = Sqlstr.Replace("[per]", "Percentage")
        Dim dscmd As New SqlDataAdapter(Tempstr, cnn)
        dscmd.Fill(ds, "couponmaster")
        cnn.Close()
        Dim objRpt As New CouponMasterCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "COUPON REPORT"
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True

        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = True
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "COUPON REPORT"

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