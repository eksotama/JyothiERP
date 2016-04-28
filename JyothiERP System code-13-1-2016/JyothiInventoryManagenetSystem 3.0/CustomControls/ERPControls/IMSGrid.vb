Public Class IMSGrid

    Private MouseDownRectangle As Rectangle
    Private rowIndexFromMouseDown As Integer
    Private rowIndexOfItemUnderMouseToDrop As Integer
    Private IsHasSerialNumber As Boolean = True
    Private SerialNumberColumnName As String = "stSno"

    Public Property SerialNumberColName() As String
        Get
            Return SerialNumberColumnName
        End Get
        Set(ByVal value As String)
            SerialNumberColumnName = value
        End Set
    End Property
    Public Property HasSerialNumber() As Boolean

        Get
            Return IsHasSerialNumber
        End Get
        Set(ByVal value As Boolean)
            IsHasSerialNumber = value
        End Set
    End Property
    Private Sub IMSGrid_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Me.DataError

    End Sub
    Private Sub IMSGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim OriginalIdentifier As String = ""
        Dim clientPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
        rowIndexOfItemUnderMouseToDrop = Me.HitTest(clientPoint.X, clientPoint.Y).RowIndex
        If e.Effect = DragDropEffects.Move Then
            Dim rowToMove As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            Dim row As New DataGridViewRow
            row = Me.SelectedRows(0)
            Dim SelRowIndex As Integer
            SelRowIndex = row.Index
            If rowIndexOfItemUnderMouseToDrop < 0 Or rowIndexOfItemUnderMouseToDrop >= Me.Rows.Count - 1 Then
                Return
            End If
            Me.Rows.Remove(row)
            Me.Rows.Insert(rowIndexOfItemUnderMouseToDrop, row)
            ArrangeSerialNumbers()
        End If
    End Sub

    Private Sub IMSGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Public Sub ArrangeSerialNumbers()
        Try
            For i As Integer = 1 To Me.RowCount
                Me.Item(SerialNumberColumnName, i - 1).Value = i.ToString
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub IMSGrid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        rowIndexFromMouseDown = Me.HitTest(e.X, e.Y).RowIndex
        If rowIndexFromMouseDown <> -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            MouseDownRectangle = New Rectangle(New Point(e.X - (dragSize.Width \ 2), e.Y - (dragSize.Height \ 2)), dragSize)
        Else
            MouseDownRectangle = Rectangle.Empty
        End If
    End Sub

    Private Sub IMSGrid_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If MouseDownRectangle <> Rectangle.Empty AndAlso (Not MouseDownRectangle.Contains(e.X, e.Y)) Then
                Dim dropEffect As DragDropEffects = Me.DoDragDrop(Me.Rows(rowIndexFromMouseDown), DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub IMSGrid_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Me.RowsAdded
        ArrangeSerialNumbers()
    End Sub

    Private Sub IMSGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Me.RowsRemoved
        ArrangeSerialNumbers()
    End Sub
End Class
