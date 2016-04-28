Imports System.Data.SqlClient

Public Class Printbarcode48Lfrm
    Dim SqlSTR As String = ""
    Sub LoadStock(Optional ByVal WhereStr As String = "")
        Dim AdditionSqlText = ""

        SqlSTR = "SELECT ROW_NUMBER() OVER (ORDER BY StockCode) AS [SNO], StockCode , stockName ,[custBarcode] as [BARCODE],StockDRP as [DRP],StockWRP as [WRP],0 as [No Of Copies]  FROM [StockDbf]  "

        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlSTR)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TxtList.Columns("Stockcode").Width = 280
            TxtList.Columns("stockName").Width = 250
            TxtList.Columns("BARCODE").Width = 125
            TxtList.Columns("SNo").ReadOnly = True
        Catch ex As Exception

        End Try



    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        TxtList.ClearSelection()
        For i As Integer = TxtList.Rows.Count - 1 To 0 Step -1
            Dim s As String = TxtList.Item("stockcode", i).Value.ToString.ToUpper
            If s.Contains(TxtStockCode.Text.ToUpper) = True Then
                TxtList.FirstDisplayedCell = TxtList.Item(0, i)
                TxtList.Item(0, i).Selected = True

            End If
        Next

    End Sub

    Private Sub Printbarcode48Lfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Printbarcode48Lfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtCmpName.Text = CompDetails.CompanyName
        LoadStock()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        TxtList.ClearSelection()
        For i As Integer = TxtList.Rows.Count - 1 To 0 Step -1
            Dim s As String = TxtList.Item("stockname", i).Value.ToString.ToUpper
            If s.Contains(TxtStockName.Text.ToUpper) = True Then
                TxtList.FirstDisplayedCell = TxtList.Item(0, i)
                TxtList.Item(0, i).Selected = True

            End If
        Next
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        TxtList.ClearSelection()
        For i As Integer = TxtList.Rows.Count - 1 To 0 Step -1
            Dim s As String = TxtList.Item("BARCODE", i).Value.ToString.ToUpper
            If s.Contains(TxtBarcode.Text.ToUpper) = True Then
                TxtList.FirstDisplayedCell = TxtList.Item(0, i)

                TxtList.Item(0, i).Selected = True

            End If
        Next
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        If MsgBox("Do You want to Print ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        lOADbCODEDATA()
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New BarcodeDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("Select * from printbarcode", cnn)
        dscmd.Fill(ds, "printbarcode")
        cnn.Close()
        Dim objRpt As New Barcode48crReport
       
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub
    Sub lOADbCODEDATA()
        ExecuteSQLQuery("DELETE FROM PRINTBARCODE")
        For I As Integer = 0 To TxtList.Rows.Count - 1
            If IsNumeric(TxtList.Item("No Of Copies", I).Value.ToString) = True Then
                If TxtList.Item("No Of Copies", I).Value > 0 Then
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [printbarcode] (itemname,barcode,rate,copies,f1,n1) values (@itemname,@barcode,@rate,@copies,@f1,@n1)"
                    For k As Integer = 0 To CInt(TxtList.Item("No Of Copies", I).Value) - 1
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                        With DBF.Parameters
                            If CheckBox1.Checked = True Then
                                .AddWithValue("itemname", TxtList.Item("stockcode", I).Value.ToString)
                            Else
                                .AddWithValue("itemname", TxtList.Item("stockname", I).Value.ToString)
                            End If
                            If CheckBox2.Checked = True Then
                                .AddWithValue("rate", TxtList.Item("WRP", I).Value.ToString)
                            Else
                                .AddWithValue("rate", TxtList.Item("DRP", I).Value.ToString)
                            End If
                            .AddWithValue("barcode", "*" & TxtList.Item("barcode", I).Value.ToString & "*")
                            .AddWithValue("copies", 0)
                            If CheckBox3.Checked = True Then
                                .AddWithValue("f1", TxtCmpName.Text)
                            Else
                                .AddWithValue("f1", "")
                            End If

                            .AddWithValue("n1", 1)
                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    Next

                End If
            End If

        Next
    End Sub
    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        Me.Close()
    End Sub

    Private Sub ImsButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton6.Click
        If MsgBox("Do You want to Print ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        lOADbCODEDATA()
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New BarcodeDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("Select * from printbarcode", cnn)
        dscmd.Fill(ds, "printbarcode")
        cnn.Close()
        Dim objRpt As New Barcode24crReport

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