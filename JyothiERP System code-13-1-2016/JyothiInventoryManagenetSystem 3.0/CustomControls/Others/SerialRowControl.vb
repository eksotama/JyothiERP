Public Class SerialRowControl
    Public TotalQty As Integer = 0
    Public StockCode As String = ""
    Public StockSize As String = ""
    Public Transcode As Double = 0
    Public VoucherName As String = ""
    Sub GenrateRows()
        For i As Integer = 1 To TotalQty
            NewRow()
        Next
        CType(CBoxList.Controls(0), IMSComboBox).Focus()
    End Sub
    Sub NewRow()
        Dim cmb As New IMSComboBox
        cmb.AllowOnlyListValues = True
        cmb.AllowEmpty = True
        If VoucherName = "SD" Or VoucherName = "POS" Or VoucherName = "SI" Then
            'LoadDataIntoComboBox("select SERIALNUMBER from stockserialnos where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and vouchername='PI' and (SERIALNUMBER not in (select SerialNumber from stockserialnos  where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and vouchername='SI' and transcode<>" & Transcode & "))", cmb, "SERIALNUMBER")
            LoadDataIntoComboBox("select SERIALNUMBER from serialnumbermaster where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and (SERIALNUMBER not in (select SerialNumber from stockserialnos  where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and vouchername='SI' and transcode<>" & Transcode & "))", cmb, "SERIALNUMBER")
        ElseIf VoucherName = "SR" Then
            LoadDataIntoComboBox("select SerialNumber from stockserialnos  where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and vouchername='SI' and transcode<>" & Transcode & "", cmb, "SERIALNUMBER")
        ElseIf VoucherName = "PG" Or VoucherName = "DP" Or VoucherName = "PI" Then
            LoadDataIntoComboBox("select SERIALNUMBER from serialnumbermaster where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and (SERIALNUMBER not in (select SerialNumber from stockserialnos  where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and vouchername='PI' and transcode<>" & Transcode & "))", cmb, "SERIALNUMBER")
        Else
            LoadDataIntoComboBox("select SerialNumber from stockserialnos  where stockcode=N'" & StockCode & "' and stocksize=N'" & StockSize & "' and vouchername='PI' and transcode<>" & Transcode & "", cmb, "SERIALNUMBER")

        End If

        cmb.Width = CBoxList.Width - 10
        CBoxList.Controls.Add(cmb)
    End Sub
    Public Function GetRows() As Integer
        Return CBoxList.Controls.Count
    End Function
    Public Function GetItem(ByVal rowno As Integer) As String
        Return CType(CBoxList.Controls(rowno), IMSComboBox).Text
    End Function

    Public Sub SetItem(ByVal rowno As Integer, ByVal value As String)
        CType(CBoxList.Controls(rowno), IMSComboBox).Text = value

    End Sub
End Class
