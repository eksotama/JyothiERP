Public Class VATComputation
    Dim Isloaded As Boolean = False

    Sub loaddata()

        Dim SqlStr As String = ""
        Dim Rowno As Integer = 0
        Dim TotalInputValue As Double = 0
        Dim TotalOutputValue As Double = 0
        Dim val As Double = 0

        TxtoutList.Rows.Clear()
        TxtInList.Rows.Clear()
        Dim whereSql As String = ""
        whereSql = "  and isdeleted=0  and  (Transdatevalue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ")"

        'finding input vat and accessble valvues

        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from Vatclauses where vattype='VAT' or vattype='CST' order by vattax DESC"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                Rowno = TxtoutList.Rows.Add
                If Sreader("vattax") = 0 Then
                    TxtoutList.Item("todetails", Rowno).Value = Sreader("VATName").ToString
                    TxtoutList.Item("toamt", Rowno).Value = SQLGetNumericFieldValue("select sum(cr-dr) as tot from ledgerbook where ledgername=N'" & Sreader("SalesLedger").ToString & "' " & whereSql, "tot")
                    TxtoutList.Item("totax", Rowno).Value = 0
                Else
                    TxtoutList.Item("todetails", Rowno).Value = Sreader("VATName").ToString
                    TxtoutList.Item("toamt", Rowno).Value = SQLGetNumericFieldValue("select sum(cr-dr) as tot from ledgerbook where ledgername=N'" & Sreader("SalesLedger").ToString & "' " & whereSql, "tot")
                    TxtoutList.Item("totax", Rowno).Value = SQLGetNumericFieldValue("select sum(cr-dr) as tot from ledgerbook where ledgername=N'" & Sreader("outputvatledger").ToString & "' " & whereSql, "tot")
                    TotalOutputValue = TotalOutputValue + CDbl(TxtoutList.Item("totax", Rowno).Value)
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try

        Dim SqlConn1 As New SqlClient.SqlConnection
        Dim Sqlcmmd1 As New SqlClient.SqlCommand
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Sqlcmmd1.Connection = SqlConn1
            Sqlcmmd1.CommandText = "select * from Vatclauses where vattype='VAT'  order by vattax DESC"
            Sqlcmmd1.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd1.ExecuteReader
            While Sreader.Read()
                Rowno = TxtInList.Rows.Add
                If Sreader("vattax") = 0 Then
                    TxtInList.Item("tidetails", Rowno).Value = Sreader("VATName").ToString
                    TxtInList.Item("tiamt", Rowno).Value = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where ledgername=N'" & Sreader("PurchaseLedger").ToString & "' " & whereSql, "tot")
                    TxtInList.Item("titax", Rowno).Value = 0
                Else
                    TxtInList.Item("tidetails", Rowno).Value = Sreader("VATName").ToString
                    TxtInList.Item("tiamt", Rowno).Value = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where ledgername=N'" & Sreader("PurchaseLedger").ToString & "' " & whereSql, "tot")
                    TxtInList.Item("titax", Rowno).Value = SQLGetNumericFieldValue("select sum(dr-cr) as tot from ledgerbook where ledgername=N'" & Sreader("inputvatledger").ToString & "' " & whereSql, "tot")
                    TotalInputValue = TotalInputValue + CDbl(TxtInList.Item("titax", Rowno).Value)
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            Sqlcmmd1.Connection = Nothing
        End Try
        TxtVATRefund.Text = "0"
        TxtVATPayble.Text = "0"
        TxtDrTotal.Text = FormatNumber(TotalOutputValue, ErpDecimalPlaces)
        TxtCrTotals.Text = FormatNumber(TotalInputValue, ErpDecimalPlaces)
        If CDbl(TxtDrTotal.Text) > CDbl(TxtCrTotals.Text) Then
            'vatpayble
            lblVATRefund.Visible = False
            TxtVATRefund.Visible = False
            lblVATPayble.Visible = True
            TxtVATPayble.Visible = True
            TxtVATPayble.Text = FormatNumber(CDbl(TxtDrTotal.Text) - CDbl(TxtCrTotals.Text), ErpDecimalPlaces)
        Else
            'vatrefundable
            lblVATRefund.Visible = True
            TxtVATRefund.Visible = True
            lblVATPayble.Visible = False
            TxtVATPayble.Visible = False
            TxtVATRefund.Text = FormatNumber(CDbl(TxtCrTotals.Text) - CDbl(TxtDrTotal.Text), ErpDecimalPlaces)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loaddata()
    End Sub

    Private Sub VATComputation_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub VATComputation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtStartDate.Value = CDate("1/" & Today.Month & "/" & Today.Year)
        TxtEndDate.Value = CDate(Date.DaysInMonth(Today.Year, Today.Month) & "/" & Today.Month & "/" & Today.Year)
        loaddata()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New VATComputationDataSet
        ds.Clear()
        ds.Tables(0).Rows.Clear()
        If TxtoutList.RowCount > TxtInList.RowCount Then
            For i As Integer = 0 To TxtoutList.RowCount - 1
                Dim row As DataRow
                row = ds.Tables("Datatable1").NewRow
                For k As Integer = 0 To TxtoutList.ColumnCount - 1
                    row(TxtoutList.Columns(k).Name) = TxtoutList.Item(k, i).Value
                    Try
                        row(TxtInList.Columns(k).Name) = TxtInList.Item(k, i).Value
                    Catch ex As Exception

                    End Try
                Next
                ds.Tables("Datatable1").Rows.Add(row)
            Next
        Else
            For i As Integer = 0 To TxtInList.RowCount - 1
                Dim row As DataRow
                row = ds.Tables("Datatable1").NewRow
                For k As Integer = 0 To TxtInList.ColumnCount - 1
                    row(TxtInList.Columns(k).Name) = TxtInList.Item(k, i).Value
                    Try
                        row(TxtoutList.Columns(k).Name) = TxtoutList.Item(k, i).Value
                    Catch ex As Exception

                    End Try
                Next
                ds.Tables("Datatable1").Rows.Add(row)
            Next
        End If

        Dim objRpt As New VATComputationCRReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
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