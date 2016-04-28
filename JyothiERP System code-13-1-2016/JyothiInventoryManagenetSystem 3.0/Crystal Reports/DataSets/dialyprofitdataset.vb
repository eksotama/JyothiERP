Partial Class dialyprofitdataset
    Partial Class DataTable1DataTable

        Private Sub DataTable1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.RET_PROFITColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

        Private Sub DataTable1DataTable_DataTable1RowChanging(ByVal sender As System.Object, ByVal e As DataTable1RowChangeEvent) Handles Me.DataTable1RowChanging

        End Sub

    End Class

End Class
