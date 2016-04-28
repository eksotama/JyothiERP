Imports System.Windows.Forms

Public Class ReadSerialNumbers
    Dim stockcode As String = ""
    Dim StockSize As String = ""
    Public HoldList As String = ""
    Dim Transcode As Double = 0
    Public CurRow As Integer = 0
    Public CurCol As Integer = 0
    Dim Isloding As Boolean = True
    Dim NoofRows As Integer = 0
    Dim Vouchername As String = ""
    Sub New(ByVal stcode As String, ByVal stsize As String, ByVal totalqty As Integer, ByVal sllist As String, ByVal vhname As String, ByVal tcode As Double)

        ' This call is required by the designer.
        InitializeComponent()
        HoldList = sllist
        If IsNothing(HoldList) = True Then
            HoldList = ""
        End If
        stockcode = stcode
        StockSize = stsize
        TxtHead.Text = "For " & stcode & " - " & StockSize
        NoofRows = totalqty
        Transcode = tcode
        Vouchername = vhname
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ReadSerialNumbers_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(sender)
        Try
            SerialRowControl1.CBoxList.Controls(0).Focus()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ReadSerialNumbers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        MainForm.Cursor = Cursors.WaitCursor
        SerialRowControl1.TotalQty = NoofRows
        SerialRowControl1.StockCode = stockcode
        SerialRowControl1.StockSize = StockSize
        SerialRowControl1.Transcode = Transcode
        SerialRowControl1.VoucherName = Vouchername
        SerialRowControl1.GenrateRows()
        Dim arr As String() = HoldList.Split(", ")
        For i As Integer = 0 To SerialRowControl1.GetRows - 1
            SerialRowControl1.SetItem(i, arr.GetValue(i).ToString)

        Next

        MainForm.Cursor = Cursors.Default

       
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        ' finding(duplicates)
        For i As Integer = 0 To SerialRowControl1.GetRows - 1
            Dim isexsists As Boolean = False
            For k = i + 1 To SerialRowControl1.GetRows - 1
                If UCase(SerialRowControl1.GetItem(i)) = UCase(SerialRowControl1.GetItem(k)) Then
                    MsgBox("Duplicate values are exists, Please recorrect the values..... ", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next
        Next
        'checking valid values
        For i As Integer = 0 To SerialRowControl1.GetRows - 1
            If SerialRowControl1.GetItem(i).Length = 0 Then
                MsgBox("Empty Values are not allowed, Please recorrect the values..... ", MsgBoxStyle.Information)
                Exit Sub
            End If
        Next

        If MsgBox("Do you want to Accept ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            HoldList = ""
            For i As Integer = 0 To SerialRowControl1.GetRows - 1
                If i = 0 Then
                    HoldList = SerialRowControl1.GetItem(i)
                Else
                    HoldList = HoldList & ", " & SerialRowControl1.GetItem(i)
                End If
            Next
            Me.Close()
        End If
    End Sub
    
   
    

  

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        HoldList = ""
        Me.Close()
    End Sub
End Class
