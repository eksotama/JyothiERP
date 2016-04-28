Imports System.Windows.Forms

Public Class SelectStockJournalInvoice
    Dim LoadType As New ClsSelectInvDB
    Dim DbName As String = ""
    Dim InvNoFiled As String = ""
    Sub New(ByRef k As ClsSelectInvDB)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        LoadType = k
    End Sub
   
    Sub LoadData(Optional ByVal SqlStrp As String = "")
        Dim SqlStr As String = ""
        If SqlStrp.Length = 0 Then
            SqlStrp = "select * from StockJournalDbf where (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ")"
        End If
        TxtList.Rows.Clear()
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SqlFcmd.Connection = SqlConn
            SqlFcmd.CommandText = SqlStrp
            SqlFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SqlFcmd.ExecuteReader
            Dim i As Integer = 0

            While Sreader.Read()
                i = TxtList.Rows.Add()
                TxtList.Item("stdate", i).Value = Sreader("location").ToString.Trim
                TxtList.Item("strefno", i).Value = Sreader("StockCode").ToString.Trim
                TxtList.Item("stlocfrom", i).Value = Sreader("StockName").ToString.Trim
                TxtList.Item("stlocto", i).Value = Sreader("Barcode")
                TxtList.Item("sttranscode", i).Value = Sreader("CustBarcode").ToString.Trim
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlFcmd.Connection = Nothing
        End Try

    End Sub

    Private Sub SelectStockJournalInvoice_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    
    Private Sub ChooseInvoiceNumber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadData()

    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub TxtLedgerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStartDate.KeyDown, TxtEndDate.KeyDown, TxtInvoice.KeyDown, TxtList.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            OkPressed()
        End If
    End Sub


    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtInvoice.Text.Length > 0 Then
            LoadData("select * from StockJournalDbf where (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and refno LIKE N'%" & TxtInvoice.Text & "%'")
        End If
    End Sub



    Private Sub ImsGrid1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        OkPressed()
    End Sub
    Sub OkPressed()
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Invoice Row....     ", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim tc As Single
            tc = TxtList.Item("stTransCode", TxtList.CurrentRow.Index).Value
            If CDbl(tc) <> 0 Then
                Dim testlock As String = IsTransactionLocked(tc)
                If testlock.Length = 0 Then
                    LoadType.SelectedTransCode = tc
                    Me.Close()
                Else
                    MsgBox(testlock)
                End If

            Else
                Exit Sub
            End If
        End If
    End Sub


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        OkPressed()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class
