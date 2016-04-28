Public Class StockItemSearch

    Private Sub StockItemSearch_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtLocation, "locationname", "*All")
    End Sub
    Sub LoadData()
        'LOADING CURRENT STOCK
        If TxtSearchText.Text.Length = 0 Then
            MsgBox("Please Enter Few letter to Search ...  ", MsgBoxStyle.Information)
            TxtSearchText.Focus()
            Exit Sub
        End If
        Dim SQLSTR As String = ""
        Dim WHERESTR As String = ""
        If IsByItemCode.Checked = True Then
            If IsbyHaving.Checked = True Then
                WHERESTR = " WHERE STOCKCODE LIKE N'%" & TxtSearchText.Text & "%' "
            Else
                WHERESTR = " WHERE STOCKCODE =N'" & TxtSearchText.Text & "' "
            End If
        Else
            If IsbyHaving.Checked = True Then
                WHERESTR = " WHERE STOCKNAME LIKE N'%" & TxtSearchText.Text & "%' "
            Else
                WHERESTR = " WHERE STOCKNAME =N'" & TxtSearchText.Text & "' "
            End If
        End If
        If TxtLocation.Text.Length = 0 Or TxtLocation.Text = "*All" Then
        Else
            WHERESTR = WHERESTR & " and location=N'" & TxtLocation.Text & "'  "
        End If

        SQLSTR = "SELECT STOCKCODE, STOCKNAME, QTYTEXT AS [QTY],STOCKRATE AS [CP], StockDRP AS [RP],OpTotalQty as [OPQTY],BASEUNIT AS [UNITS]  FROM STOCKDBF  " & WHERESTR
        Dim TempBS As New BindingSource
        With Me.DataGridView1
            TempBS.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        'GOODS RECEIPTS NOTES
        SQLSTR = "SELECT QUTONO AS [GRN Num],transdate as [GRN Date],(SELECT TOP 1 ledgername FROM StockInvoiceDetails WHERE StockInvoiceDetails.TRANSCODE=StockInvoiceRowItems.TRANSCODE) as [Supplier Name],qtyvalues as [QR],stockrate as [PR] from StockInvoiceRowItems   " & WHERESTR & " and isdelete=0 and vouchername='PG' "
        Dim TempBS2 As New BindingSource
        With Me.DataGridView2
            TempBS2.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS2
        End With

        'CASH SALES
        SQLSTR = "SELECT QUTONO AS [CA Inv],transdate as [CA Date],(SELECT TOP 1 ledgername FROM StockInvoiceDetails WHERE StockInvoiceDetails.TRANSCODE=StockInvoiceRowItems.TRANSCODE) as [Customer Name],qtyvalues as [Qty],stockrate as [Rate] , StockDisc AS [Disc] ,StockAmount as [Amt] from StockInvoiceRowItems   " & WHERESTR & " and isdelete=0 and vouchername='POS' AND TRANSTYPE IN ('','Cash Sales') "
        Dim TempBS3 As New BindingSource
        With Me.DataGridView3
            TempBS3.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS3
        End With

        'CASH SALES
        SQLSTR = "SELECT QUTONO AS [CA Inv],transdate as [CA Date],(SELECT TOP 1 ledgername FROM StockInvoiceDetails WHERE StockInvoiceDetails.TRANSCODE=StockInvoiceRowItems.TRANSCODE) as [Customer Name],qtyvalues as [Qty],stockrate as [Rate] , StockDisc AS [Disc] ,StockAmount as [Amt] from StockInvoiceRowItems   " & WHERESTR & " and isdelete=0 and vouchername='POS' AND TRANSTYPE IN ('','Credit Sales') "
        Dim TempBS4 As New BindingSource
        With Me.DataGridView4
            TempBS4.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS4
        End With

        'DELIVERY NOTE SALES
        SQLSTR = "SELECT QUTONO AS [DN Inv],transdate as [DN Date],(SELECT TOP 1 ledgername FROM StockInvoiceDetails WHERE StockInvoiceDetails.TRANSCODE=StockInvoiceRowItems.TRANSCODE) as [Customer Name],qtyvalues as [Qty],stockrate as [Rate] , StockDisc AS [Disc] ,StockAmount as [Amt] from StockInvoiceRowItems   " & WHERESTR & " and isdelete=0 and vouchername='SD' "
        Dim TempBS5 As New BindingSource
        With Me.DataGridView5
            TempBS5.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS5
        End With


        'PURCHASE RETURNS
        SQLSTR = "SELECT QUTONO AS [PR Inv],transdate as [PR Date],(SELECT TOP 1 ledgername FROM StockInvoiceDetails WHERE StockInvoiceDetails.TRANSCODE=StockInvoiceRowItems.TRANSCODE) as [Customer Name],qtyvalues as [Qty],stockrate as [Rate] , StockDisc AS [Disc] ,StockAmount as [Amt] from StockInvoiceRowItems   " & WHERESTR & " and isdelete=0 and vouchername='PR' "
        Dim TempBS6 As New BindingSource
        With Me.DataGridView6
            TempBS6.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS6
        End With


        'SALES RETURNS
        SQLSTR = "SELECT QUTONO AS [SR Inv],transdate as [SR Date],(SELECT TOP 1 ledgername FROM StockInvoiceDetails WHERE StockInvoiceDetails.TRANSCODE=StockInvoiceRowItems.TRANSCODE) as [Customer Name],qtyvalues as [Qty],stockrate as [Rate] , StockDisc AS [Disc] ,StockAmount as [Amt] from StockInvoiceRowItems   " & WHERESTR & " and isdelete=0 and vouchername='SR' "
        Dim TempBS7 As New BindingSource
        With Me.DataGridView7
            TempBS7.DataSource = SQLLoadGridData(SQLSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS7
        End With

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        LoadData()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class