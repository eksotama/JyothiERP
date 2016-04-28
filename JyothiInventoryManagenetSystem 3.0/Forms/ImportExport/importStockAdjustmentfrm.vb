Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Public Class importStockAdjustmentfrm
    Dim DbFiledName As String = ""
    Dim LedgerName As String = ""
    Dim LedgerType As String = ""
    Dim LedgerOpBalance As Double = 0
    Dim LedgerCity As String = ""
    Dim LedgerCountry As String = ""
    Dim Ledgeraddress As String = ""
    Dim Ledgerzipcode As String = ""
    Dim Ledgeremailid As String = ""
    Dim LedgerContactNo As String = ""
    Dim LedgerTaxRegNo As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            ReadData(opfile.FileName)
        End If
    End Sub

    Sub ReadData(ByVal filename As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rowno As Integer
        Dim colno As Integer
        Dim Obj As Object
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        TxtList.Rows.Clear()
        Dim listrowno As Integer
        range = xlWorkSheet.UsedRange

        For rowno = 1 To range.Rows.Count
            For colno = 1 To 7

                Obj = CType(range.Cells(rowno, colno), Excel.Range)
                Dim TEMPSTR As String = ""
                TEMPSTR = Trim(Obj.VALUE)
                If TEMPSTR = Nothing Then
                    TEMPSTR = ""
                End If
                If colno = 1 Then
                    listrowno = TxtList.Rows.Add
                End If

                If colno = 5 Or colno = 6 Then
                    If IsNumeric(TEMPSTR) = True Then
                        TxtList.Item(colno - 1, rowno - 1).Value = FormatNumber(TEMPSTR, ErpDecimalPlaces, , , TriState.False)
                    Else
                        TxtList.Item(colno - 1, rowno - 1).Value = ""
                    End If
                Else
                    TxtList.Item(colno - 1, rowno - 1).Value = TEMPSTR
                End If
            Next
        Next
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ImportLedgerMaster_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ImportPriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        TxtList.Rows.Clear()
    End Sub



    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click

        If TxtList.Rows.Count = 0 Then
            MsgBox("There are no list to update..., Please selec the excel file....", MsgBoxStyle.Information)
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
        

    End Sub
    
    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   
End Class