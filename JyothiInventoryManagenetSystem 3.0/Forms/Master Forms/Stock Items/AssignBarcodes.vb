Imports System.Windows.Forms

Public Class AssignBarcodes

    Sub New(bcode As String)

        ' This call is required by the designer.
        InitializeComponent()
        TxtBarcode.Text = bcode
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub loaddata()
        TxtList.Rows.Clear()
        Dim dt As New DataTable
        dt = SQLLoadGridData("Select ABarcode as Barcode from barcodelist where Pbarcode=N'" & TxtBarcode.Text & "'")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim rno As Integer = TxtList.Rows.Add
                TxtList.Item(0, rno).Value = dt.Rows(i).Item("Barcode").ToString
                TxtList.Item(1, rno).Value = "Delete"
            Next
        End If
    End Sub



    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        If TxtBarcode.Text.Length = 0 Then
            MsgBox("Please select the Barcode.. ")
            Exit Sub
        End If
        If IsBarcodeExists(TxtABarcode.Text) = True Then
            MsgBox("The Barcode is already exists, Please try again..", MsgBoxStyle.Information)
            TxtABarcode.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Create New Barcode ?   ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("INSERT INTO [barcodelist] ([Pbarcode]    ,[ABarcode]) values (N'" & TxtBarcode.Text & "',N'" & TxtABarcode.Text & "')")
            loaddata()
            TxtABarcode.Text = ""
            TxtABarcode.Focus()
        End If
    End Sub

    Private Sub AssignBarcodes_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtItemCode.Text = SQLGetStringFieldValue("Select top 1 stockcode from stockdbf where CustBarcode=N'" & TxtBarcode.Text & "'", "stockcode")
        TxtItemName.Text = SQLGetStringFieldValue("Select top 1 stockname from stockdbf where CustBarcode=N'" & TxtBarcode.Text & "'", "stockname")
        loaddata()
    End Sub

    Private Sub TxtList_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellClick
        If e.ColumnIndex = 1 Then
            If MsgBox("Do you want to Delete ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM BARCODELIST WHERE ABarcode=N'" & TxtList.Item(0, e.RowIndex).Value & "'")
                loaddata()
            End If
        End If
    End Sub

   
    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
