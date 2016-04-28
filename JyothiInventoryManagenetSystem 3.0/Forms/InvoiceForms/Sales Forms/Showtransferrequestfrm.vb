Public Class Showtransferrequestfrm
    Dim OpenedTranscode As Single = 0
    Sub New(Openid As Single)

        ' This call is required by the designer.
        InitializeComponent()
        OpenedTranscode = Openid
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadDefaults()

        TxtDate.Value = Now
        TxtQutoNo.Text = GetInvVhNumber(InvoiceNoStrct.STOCKJOURNAL)
        TxtInvNo.Text = GetInvVhNumber(InvoiceNoStrct.STOCKJOURNAL)
        LoadDataIntoComboBox("select locationname from StockLocations where isdelete=0 ", TxtLocationFrom, "locationname")
        LoadDataIntoComboBox("select locationname from StockLocations where isdelete=0 ", TxtLocationTo, "locationname")
        TxtLocationFrom.Text = GetLocation()
        TxtDate.Value = Now
        TxtFromList.Rows.Clear()
        TxtToList.Rows.Clear()
        If IsCustomBarCode = True Then
            TxtFromList.Columns("sfbarcode").Visible = False
            TxtFromList.Columns("sfcustbarcode").Visible = True

            TxtToList.Columns("stbarcode").Visible = False
            TxtToList.Columns("stcustbarcode").Visible = True
        End If


    End Sub
    Sub OpenbyID(tcode As Single)
        LoadDefaults()
        OpenedTranscode = tcode
        UpdateLogFile(DefStoreName, OpenedTranscode, "StockJournal", TxtQutoNo.Text, CurrentUserName, "Accessed", System.Environment.MachineName, "Accessed  StockJournal  for TransCode: " & OpenedTranscode.ToString)
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockTransferRowItems where transcode=" & OpenedTranscode & " and vouchername='SJout'  order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim i As Integer = 0
            While Sreader.Read()
                i = TxtFromList.Rows.Add()
                TxtFromList.Item("sfsno", i).Value = i + 1
                TxtFromList.Item("sflocation", i).Value = Sreader("location").ToString.Trim
                TxtFromList.Item("sfitemcode", i).Value = Sreader("StockCode").ToString.Trim
                TxtFromList.Item("sfitemname", i).Value = Sreader("StockName").ToString.Trim
                TxtFromList.Item("sfbarcode", i).Value = Sreader("Barcode").ToString.Trim
                TxtFromList.Item("sfcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                TxtFromList.Item("sfsize", i).Value = Sreader("StockSize").ToString.Trim
                TxtFromList.Item("sfbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                TxtFromList.Item("sfexpiry", i).Value = Sreader("Expiry")
                TxtFromList.Item("sfqty", i).Value = Sreader("TotalQty")
                TxtFromList.Item("sfqtytext", i).Value = Sreader("QtyText").ToString.Trim
                TxtFromList.Item("sfprice", i).Value = Sreader("StockRate")
                TxtFromList.Item("sfrateper", i).Value = Sreader("RatePer").ToString.Trim

                TxtFromList.Item("sfamount", i).Value = Sreader("StockAmount")
                Try
                    TxtFromList.Item("sfprate", i).Value = Sreader("PresetRate")
                Catch ex As Exception
                    TxtFromList.Item("sfprate", i).Value = GetPresetCostofStockItem(Sreader("Barcode").ToString.Trim)
                End Try
                If i <= 0 Then
                    TxtDate.Value = CDate(Sreader("transdate"))
                    TxtInvNo.Text = Sreader("QutoNo").ToString.Trim
                    TxtQutoNo.Text = Sreader("Qutoref").ToString.Trim
                    TxtLocationFrom.Text = Sreader("location").ToString.Trim
                End If
                '.AddWithValue("PresetRate", CDbl(TxtList.Item("stprate", i).Value))
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

        ' LOAD DESTINATION DATA
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockTransferRowItems where transcode=" & OpenedTranscode & " and vouchername='SJin'  order by sno"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim i As Integer = 0
            While Sreader.Read()
                i = TxtToList.Rows.Add()
                TxtToList.Item("stsno", i).Value = i + 1
                TxtToList.Item("stlocation", i).Value = Sreader("location").ToString.Trim
                TxtToList.Item("stitemcode", i).Value = Sreader("StockCode").ToString.Trim
                TxtToList.Item("stitemname", i).Value = Sreader("StockName").ToString.Trim
                TxtToList.Item("stbarcode", i).Value = Sreader("Barcode").ToString.Trim
                TxtToList.Item("stcustbarcode", i).Value = Sreader("CustBarcode").ToString.Trim
                TxtToList.Item("stsize", i).Value = Sreader("StockSize").ToString.Trim
                TxtToList.Item("stbatchno", i).Value = Sreader("BatchNo").ToString.Trim
                TxtToList.Item("stexpiry", i).Value = Sreader("Expiry")
                TxtToList.Item("stqty", i).Value = Sreader("TotalQty")
                TxtToList.Item("stqtytext", i).Value = Sreader("QtyText").ToString.Trim
                TxtToList.Item("stprice", i).Value = Sreader("StockRate")
                TxtToList.Item("strateper", i).Value = Sreader("RatePer").ToString.Trim

                TxtToList.Item("stamount", i).Value = Sreader("StockAmount")
                Try
                    TxtToList.Item("stprate", i).Value = Sreader("PresetRate")
                Catch ex As Exception
                    TxtToList.Item("stprate", i).Value = GetPresetCostofStockItem(Sreader("Barcode").ToString.Trim)
                End Try
                If i <= 0 Then
                    TxtLocationTo.Text = Sreader("location").ToString.Trim
                End If
                i = i + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        FindTOTotalAmount()
        FindTotalAmount()
    End Sub

    Private Sub Showtransferrequestfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Showtransferrequestfrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        OpenbyID(OpenedTranscode)
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Sub FindTotalAmount()
        Dim tot As Double = 0
        For i As Integer = 0 To TxtFromList.RowCount - 1
            tot = tot + CDbl(TxtFromList.Item("sfamount", i).Value)
        Next
        TxtTotalValue.Text = FormatNumber(tot, ErpDecimalPlaces, , , TriState.False)
    End Sub
    Sub FindTOTotalAmount()
        Dim tot As Double = 0
        For i As Integer = 0 To TxtToList.RowCount - 1
            tot = tot + CDbl(TxtToList.Item("stamount", i).Value)
        Next
        TxtTTotalAmount.Text = FormatNumber(tot, ErpDecimalPlaces, , , TriState.False)
    End Sub

    Private Sub TxtLocationFrom_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtLocationFrom.SelectedIndexChanged

    End Sub
End Class