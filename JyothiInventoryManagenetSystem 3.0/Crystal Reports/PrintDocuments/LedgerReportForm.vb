Imports System.Data.SqlClient

Public Class LedgerReportForm
    Dim SQLStr As String = ""
    Dim Crep As New LedgerDetailsCRReport

    Sub New(ByVal strqury As String)

        ' This call is required by the designer.
        InitializeComponent()
        SQLStr = strqury
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub LedgerReportForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub LedgerReportForm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub LedgerReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadReport()
    End Sub
   Sub LoadReport()
        Dim myDataSet As New AccountLedgerDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(SQLStr, cnn)
        dscmd.Fill(myDataSet, "ledgers")

        For i As Integer = 0 To myDataSet.Tables("ledgers").Rows.Count - 1

            Dim R As DataRow = myDataSet.Tables("Images").NewRow
            R("ledgername") = myDataSet.Tables("ledgers").Rows(i).Item("ledgername").ToString
            R("ImageFile") = GetImageToDataTableColum(myDataSet.Tables("ledgers").Rows(i).Item("photopath").ToString)
            myDataSet.Tables("Images").Rows.Add(R)
        Next

        cnn.Close()

        Crep.SetDataSource(myDataSet)
        Me.CrystalReportViewer1.ReportSource = Crep
        Me.CrystalReportViewer1.RefreshReport()
        Me.Cursor = Cursors.Default
  End Sub


    Private Sub CrystalReportViewer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CrystalReportViewer1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

   
End Class