Imports System.Windows.Forms

Public Class SearchStockDbffrm

    Dim SearchFieldName As String = ""
    Public IsAllowtoShowAll As Boolean = False
    Public SelectedName As String = ""
    Public SelectedRowIndex As Long = 0
    Sub New(SearchName As String, Optional IsShowAll As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        SearchFieldName = SearchName
        IsAllowtoShowAll = IsShowAll
        Searchlbl.Text = "Search For " & SearchName
        'Me.Text = "Search For " & SearchName
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub loadstockitems(Optional ByVal SqlStrOp As String = "")

        Dim Sqlstr As String = ""
        If SearchFieldName = "stockcode" Then
            Sqlstr = "select * from (select Stockcode, ROW_NUMBER() OVER (ORDER BY Stockcode) as sn from stockdbf group by Stockcode) tb "
        Else
            If IsAllowtoShowAll = True Then
                Sqlstr = "SELECT  " & SearchFieldName & " from stockdbf "
            Else
                Sqlstr = "SELECT DISTINCT " & SearchFieldName & " from stockdbf "
            End If
        End If
       


        Sqlstr = Sqlstr & SqlStrOp
        Dim TempBS As New BindingSource

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        If SearchFieldName = "stockcode" Then
            Try
                TxtList.Columns(1).Visible = False
            Catch ex As Exception

            End Try
        End If
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
        SelectedName = ""
        SelectedRowIndex = 0
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the " & SearchFieldName & " from the list.............. ", MsgBoxStyle.Information)
            TxtList.Focus()
            Exit Sub
        Else

            SelectedName = TxtList.Item(0, TxtList.CurrentRow.Index).Value
            SelectedRowIndex = TxtList.CurrentRow.Index + 1
            Me.Close()
        End If

    End Sub
    Private Sub TxtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStockCode.KeyDown
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
            str = "  "
        Else
            str = " where " & SearchFieldName & "  LIKE N'%" & TxtStockCode.Text & "%'  "
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
