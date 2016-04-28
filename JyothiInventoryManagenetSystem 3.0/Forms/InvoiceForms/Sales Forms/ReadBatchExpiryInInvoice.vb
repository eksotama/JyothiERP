Imports System.Windows.Forms

Public Class ReadBatchExpiryInInvoice
    Dim bvalues As New newbatchexpiryClass
    Dim IsAlterMode As Boolean = False
    Sub New(ByRef bval As newbatchexpiryClass, Optional ByVal IsEditmode As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        bvalues = bval
        If IsEditmode = True Then
            IsAlterMode = True
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    
    Private Sub ReadBatchExpiryInInvoice_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        txtbatchno.Focus()

        txtexpirydate.Value = New Date(TxtYear.Value.Year, TxtMonth.Value.Month, 1)


    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If txtbatchno.Text.Length = 0 Then Exit Sub
        If IsAlterMode = True Then
            If UCase(txtbatchno.Text) <> UCase(bvalues.Batchno) Then
                If SQLIsFieldExists("select stockcode from stockbatch where stockcode=N'" & bvalues.stockcode & "' and stocksize=N'" & bvalues.Stocksize & "' and location=N'" & bvalues.StockLocation & "' and batchno=N'" & txtbatchno.Text & "'") = True Then
                    MsgBox("The Entered Batch No is already Exists.. ", MsgBoxStyle.Critical)
                    txtbatchno.Focus()
                    Exit Sub
                End If

            End If
            bvalues.Batchno = txtbatchno.Text
            bvalues.Expirydate = txtexpirydate
            bvalues.Mrp = CDbl(txtmrp.Text)
            Me.Close()
        Else
            If SQLIsFieldExists("select stockcode from stockbatch where stockcode=N'" & bvalues.stockcode & "' and stocksize=N'" & bvalues.Stocksize & "' and location=N'" & bvalues.StockLocation & "' and batchno=N'" & txtbatchno.Text & "'") = True Then
                MsgBox("The Entered Batch No is already Exists.. ", MsgBoxStyle.Critical)
                txtbatchno.Focus()
                Exit Sub

            End If
            bvalues.Batchno = txtbatchno.Text
            bvalues.Expirydate = txtexpirydate
            bvalues.Mrp = CDbl(txtmrp.Text)
            Me.Close()
        End If
       
       
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        bvalues.Batchno = ""
        Me.Close()
    End Sub

    Private Sub txtbatchno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbatchno.LostFocus
        If SQLIsFieldExists("select stockcode from stockbatch where stockcode=N'" & bvalues.stockcode & "' and stocksize=N'" & bvalues.Stocksize & "' and location=N'" & bvalues.StockLocation & "' and batchno=N'" & txtbatchno.Text & "'") = True Then
            Panel1.BackColor = Color.Red
        Else
            Panel1.BackColor = Color.Green
        End If

    End Sub

    Private Sub txtbatchno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbatchno.TextChanged

    End Sub

    Private Sub ReadBatchExpiryInInvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtbatchno.Text = bvalues.Batchno
        If IsAlterMode = True Then
            txtexpirydate.Value = bvalues.Expirydate.Value
            BtnCreate.Text = "Alter"
            TxtMonth.Value = New Date(bvalues.Expirydate.Value.Year, bvalues.Expirydate.Value.Month, 1)
            TxtYear.Value = New Date(bvalues.Expirydate.Value.Year, bvalues.Expirydate.Value.Month, 1)
            txtmrp.Text = bvalues.Mrp
        Else
            TxtYear.Value = Today
            TxtMonth.Value = Today
            txtmrp.Text = bvalues.Mrp
        End If
      
    End Sub

    Private Sub ImsDate1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonth.ValueChanged
      
        txtexpirydate.Value = New Date(TxtYear.Value.Year, TxtMonth.Value.Month, 1)
    End Sub

    Private Sub TxtYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtYear.ValueChanged
        txtexpirydate.Value = New Date(TxtYear.Value.Year, TxtMonth.Value.Month, 1)
    End Sub
End Class
