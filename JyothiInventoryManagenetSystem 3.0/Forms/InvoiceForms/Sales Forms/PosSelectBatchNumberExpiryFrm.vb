Imports System.Windows.Forms

Public Class PosSelectBatchNumberExpiryFrm
    Public SelectedBatchNo As String = ""
    Public selectedExpiryDate As New DateTimePicker
    Public selectedMRP As Double = 0
    Public selectedStockRate As Double = 0
    Dim NewAddItem As New ChooseItemClass
    Sub New(stlist As ChooseItemClass)

        ' This call is required by the designer.
        InitializeComponent()
        NewAddItem = stlist
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadData()
        Dim sqlstr As String = ""
        If MyAppSettings.IsAllowEmptyBatchnoOnSales = True Then
            sqlstr = "select BatchNo,Expiry ,mrp as [MRP], QtyText as Qty from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "'"
        Else
            sqlstr = "select BatchNo,Expiry,mrp as [MRP], QtyText as Qty from stockbatch where stockcode=N'" & NewAddItem.StockItemCode & "' and stocksize=N'" & NewAddItem.StockITemSize & "' and location=N'" & NewAddItem.StockLocation & "' and totalqty>0"
        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("BatchNo").Width = 120
            TxtList.Columns("Expiry").Width = 100
            TxtList.Columns("Qty").Width = 100
            TxtList.Columns("MRP").Width = 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PosSelectBatchNumberExpiryFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtList.Focus()
    End Sub

    Private Sub PosSelectBatchNumberExpiryFrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(sender As System.Object, e As System.EventArgs) Handles BtnOk.Click
        acceptvalues()
    End Sub
    Sub acceptvalues()
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        SelectedBatchNo = TxtList.Item("batchno", TxtList.CurrentRow.Index).Value
        selectedExpiryDate.Value = TxtList.Item("expiry", TxtList.CurrentRow.Index).Value
        selectedMRP = TxtList.Item("mrp", TxtList.CurrentRow.Index).Value
        selectedStockRate = TxtList.Item("mrp", TxtList.CurrentRow.Index).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        Dim bvalues As New newbatchexpiryClass
        bvalues.Batchno = ""
        bvalues.stockcode = NewAddItem.StockItemCode
        bvalues.Stocksize = NewAddItem.StockITemSize
        bvalues.StockLocation = NewAddItem.StockLocation
        bvalues.Expirydate.Value = Today.AddDays(1)

        Dim frm As New ReadBatchExpiryInInvoice(bvalues)
        frm.ShowDialog()
        If bvalues.Batchno.Length > 0 Then
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim batchsqlstr As String = ""
            batchsqlstr = " INSERT INTO [StockBatch] ([StockCode] ,[Barcode] ,[StockSize] ,[Location],[BaseUnit],[MainUnit],[SubUnit],[IsSimpleUnit] ,[BaseQty] ,[TotalQty] ,[SubUnitQty] ,[QtyText] ,[OpBaseQty] , " _
                & " [OpTotalQty] ,[OpSubUnitQty] ,[StockRate] ,[Expiry] ,[BatchNo] ,[OpstockRate] ,[mrp] ,[expiryDateValue])     VALUES " _
                & "(@StockCode ,@Barcode ,@StockSize ,@Location,@BaseUnit,@MainUnit,@SubUnit,@IsSimpleUnit ,@BaseQty ,@TotalQty ,@SubUnitQty ,@QtyText , " _
                & " @OpBaseQty ,@OpTotalQty ,@OpSubUnitQty ,@StockRate ,@Expiry ,@BatchNo ,@OpstockRate ,@mrp ,@expiryDateValue)   "
            Dim DBF1 As New SqlClient.SqlCommand(batchsqlstr, MAINCON)
            With DBF1.Parameters
                .AddWithValue("StockCode", NewAddItem.StockItemCode)
                .AddWithValue("Barcode", NewAddItem.StockItemBarCode)
                .AddWithValue("StockSize", NewAddItem.StockITemSize)
                .AddWithValue("Location", NewAddItem.StockLocation)
                .AddWithValue("BaseUnit", NewAddItem.StockUnitName)
                .AddWithValue("MainUnit", NewAddItem.StockMainUnitName)
                .AddWithValue("SubUnit", NewAddItem.StockSubUnitName)
                .AddWithValue("IsSimpleUnit", 1)
                .AddWithValue("BaseQty", 0)
                .AddWithValue("TotalQty", 0)
                .AddWithValue("SubUnitQty", 0)
                .AddWithValue("QtyText", 0)
                .AddWithValue("OpBaseQty", 0)
                .AddWithValue("OpTotalQty", 0)
                .AddWithValue("OpSubUnitQty", 0)
                .AddWithValue("OpstockRate", 0)
                .AddWithValue("StockRate", NewAddItem.StockRate)
                .AddWithValue("mrp", bvalues.Mrp)
                .AddWithValue("expiry", bvalues.Expirydate.Value)
                .AddWithValue("BatchNo", bvalues.Batchno)
                .AddWithValue("expiryDateValue", bvalues.Expirydate.Value.Date.ToOADate)
            End With
            DBF1.ExecuteNonQuery()
            DBF1 = Nothing
            MAINCON.Close()
            SelectedBatchNo = bvalues.Batchno
            selectedExpiryDate.Value = bvalues.Expirydate.Value
            selectedMRP = bvalues.Mrp
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
        
       
    End Sub

    Private Sub TxtListe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList.KeyDown
        If e.KeyCode = Keys.Enter Then
            AcceptValues()
        End If
    End Sub
   
    Private Sub BtnOk_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyDown, TxtList.KeyDown, BtnNew.KeyDown, BtnCancel.KeyDown
        If e.KeyCode = Keys.Enter Then
            acceptvalues()
        ElseIf e.KeyCode = Keys.Down Then
            Try
                TxtList.Item(0, TxtList.CurrentRow.Index + 1).Selected = True
            Catch ex As Exception

            End Try
        ElseIf e.KeyCode = Keys.Up Then
            Try
                TxtList.Item(0, TxtList.CurrentRow.Index - 1).Selected = True
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
