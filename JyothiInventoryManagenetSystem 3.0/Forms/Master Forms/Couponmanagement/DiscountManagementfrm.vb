Imports System.Data.SqlClient

Public Class DiscountManagementfrm

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

        Sqlstr = "SELECT  ID, DiscountName as [Discount Name],StockGroup as [StockGroup], datefrom as [Date From], dateto as [Date To],DiscountPer as [Percentage] ,DiscountType as [DISCOUNT TYPE] ,isActive as [Status] from Discounts "
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

            Me.TxtList.Columns("DiscountPer").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("DiscountPer").Width = 80
            Me.TxtList.Columns("DiscountPer").DefaultCellStyle.Format = "N2"
            Me.TxtList.Columns("DiscountPer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Date From").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date From").Width = 100
            Me.TxtList.Columns("Date From").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Date From").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.TxtList.Columns("Date To").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns("Date To").Width = 100
            Me.TxtList.Columns("Date To").DefaultCellStyle.Format = "d"
            Me.TxtList.Columns("Date To").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        Dim k As New CreateNewDirectDiscount
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
                ExecuteSQLQuery("UPDATE Discounts SET isActive=1 WHERE DiscountName=N'" & TxtList.Item("Discount Name", TxtList.CurrentRow.Index).Value & "'")
                BtnActivate.Text = "DeActivate"
                TxtList.Item("status", TxtList.CurrentRow.Index).Value = True
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE Discounts SET isActive=0 WHERE DiscountName=N'" & TxtList.Item("Discount Name", TxtList.CurrentRow.Index).Value & "'")
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
        If TxtList.Item("DISCOUNT TYPE", TxtList.CurrentRow.Index).Value.ToString.ToUpper = "invoice".ToUpper Then
            Dim k As New DiscountInvoiceWise(TxtList.Item("ID", TxtList.CurrentRow.Index).Value)
            k.ShowDialog()
            k.Dispose()
        Else
            Dim k As New CreateNewDirectDiscount(TxtList.Item("ID", TxtList.CurrentRow.Index).Value)
            k.ShowDialog()
            k.Dispose()
        End If
       
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
            MsgBox("Please Select the Discount Name to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do You want to Delete The Discount Name  ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("delete from discountDetails where DiscountID=" & TxtList.Item("id", TxtList.CurrentRow.Index).Value)
            ExecuteSQLQuery("Delete from Discounts where id=" & TxtList.Item("id", TxtList.CurrentRow.Index).Value)
            LoadCustomerList()
        End If

    End Sub
    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadCustomerList()
    End Sub


    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDisName.TextChanged
        If TxtDisName.Text.Length = 0 Then
            LoadCustomerList()
        Else
            LoadCustomerList(" WHERE   DiscountName LIKE N'%" & TxtDisName.Text & "%'")
        End If
    End Sub




   
    Private Sub BtnNewInv_Click(sender As System.Object, e As System.EventArgs) Handles BtnNewInv.Click
        Dim k As New DiscountInvoiceWise
        k.ShowDialog()
        LoadCustomerList()
    End Sub
End Class