Imports System.Data.SqlClient

Public Class ExportData

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'LOOKING LIST OF TABLES
        If path.Text.Length = 0 Then Exit Sub
        Dim TBLSTR As String = "SELECT * FROM INFORMATION_SCHEMA.tables"
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
        Dim ds As New DataSet()
        da.Fill(ds)

        For Each row As DataRow In ds.Tables(0).Rows
            Dim ids As New DataSet
            Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
            dscmd.Fill(ids, row.Item("TABLE_NAME"))
            Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
            ids.WriteXml(path.Text & "\" & row.Item("TABLE_NAME") & ".xml")
        Next row


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog() = vbOK Then
            path.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If path.Text.Length = 0 Then Exit Sub
        Dim TBLSTR As String = "SELECT * FROM INFORMATION_SCHEMA.tables"
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
        Dim ds As New DataSet()
        da.Fill(ds)

        For Each row As DataRow In ds.Tables(0).Rows

            Dim ids As New DataSet

            Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
            dscmd.Fill(ids, row.Item("TABLE_NAME"))
            Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
            ids.ReadXml(path.Text & "\" & row.Item("TABLE_NAME") & ".xml")
            dscmd.Update(ids, row.Item("TABLE_NAME"))

        Next row

    End Sub
End Class