Imports System.Windows.Forms

Public Class SelectItemCodeorName
    Dim IsListStockName As Boolean = True
    Public IsAllowToSelectAll As Boolean = False
    Sub New(Optional ByVal isstockname As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        IsListStockName = isstockname
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public FileterLocationName As String = ""
    Sub loadstockitems(Optional ByVal SqlStrOp As String = "")

        Dim Sqlstr As String = ""

        If IsListStockName = True Then
            Sqlstr = " select top 1 '*All' as stockname from StockDbf union  select distinct stockname from stockdbf  "
            Me.Text = "SELECT ITEM NAME"
        Else
            If IsAllowToSelectAll = True Then
                Sqlstr = " select top 1 '*All' as stockcode from StockDbf union  select distinct stockcode from stockdbf  "
            Else
                Sqlstr = " select distinct stockcode from stockdbf  "
            End If
            Me.Text = "SELECT ITEM CODE"
        End If

        Sqlstr = Sqlstr & SqlStrOp
        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With


    End Sub

    Private Sub ChooseItems_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtStockCode.Focus()
    End Sub

    Private Sub ChooseItems_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TxtList.Dispose()
    End Sub
    Private Sub ChooseItems_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SearchStockItemName = ""
        loadstockitems()


    End Sub
    Sub AcceptValues()
        SearchStockItemName = ""
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Item from the list.............. ", MsgBoxStyle.Information)
            TxtList.Focus()
            Exit Sub
        Else
            SearchStockItemName = TxtList.Item(0, TxtList.CurrentRow.Index).Value
            Me.Close()
        End If

    End Sub
    Private Sub TxtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStockCode.KeyDown, TxtStockName.KeyDown
        If e.KeyCode = Keys.Enter Then
            AcceptValues()
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
    Private Sub TxtListe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList.KeyDown
        If e.KeyCode = Keys.Enter Then
            AcceptValues()
        End If
    End Sub

    Private Sub TxtStockCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.TextChanged
        Dim str As String = ""
        If TxtStockCode.Text.Length = 0 Then
            str = "  where stocktype=0 "
        Else
            str = " where stockcode LIKE N'%" & TxtStockCode.Text & "%' and stocktype=0 "
        End If

        loadstockitems(str)
    End Sub



    Private Sub TxtStockName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockName.TextChanged
        Dim str As String = ""

        If TxtStockCode.Text.Length = 0 Then
            str = "  where stocktype=0 "
        Else
            str = " where stockname LIKE N'%" & TxtStockName.Text & "%' and stocktype=0 "
        End If

        loadstockitems(str)
    End Sub



    Private Sub TxtList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        AcceptValues()
    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        AcceptValues()
    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub




    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        AcceptValues()
    End Sub





    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class
