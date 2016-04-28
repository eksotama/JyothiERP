Public Class SelectEmployeeVoucherDetails
    Dim OpenedTCode As Double = 0
    Dim TotalSalary As Double = 0
    Dim EmployeeName As String = ""
    Sub New(ByVal paytotal As Double, ByVal empname As String, ByVal TCODE As Double)

        ' This call is required by the designer.
        InitializeComponent()
        OpenedTCode = TCODE
        TotalSalary = paytotal
        EmployeeName = empname
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub SelectEmployeeVoucherDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        PayList.ClearFrom(VoucherType.Payment)

    End Sub
    Private Sub PayList_AmountEnteredEvent(ByVal e As Object) Handles PayList.AmountEnteredEvent
        TxtDebitTotal.Text = PayList.GetDebitTotal
        TxtCreditTotal.Text = PayList.GetCreditTotal
        If CDbl(TxtDebitTotal.Text) - CDbl(TxtCreditTotal.Text) > 0 Then
            TxtNetTotal.Text = CDbl(TxtDebitTotal.Text) - CDbl(TxtCreditTotal.Text)
        Else
            TxtNetTotal.Text = CDbl(TxtCreditTotal.Text) - CDbl(TxtDebitTotal.Text)
        End If

    End Sub
    Sub Savedata()
        ExecuteSQLQuery("delete from TempPayRows where transcode=" & OpenedTCode & " and empname='" & EmployeeName & "'")
        Dim SqlStr As String
        SqlStr = "INSERT INTO [TempPayRows] ([Transcode] ,[LedgerName] ,[Description],[Dr],[Cr],[EmpName])) " _
              & " VALUES (@Transcode ,@LedgerName ,@Description,@Dr,@Cr,@EmpName)"
        For i As Integer = 0 To PayList.Rowcount - 1
            If Len(PayList.Items(1, i)) > 2 And CDbl(Len(PayList.Items(3, i)) > 0) Then
                Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("Transcode", OpenedTCode)
                    .AddWithValue("LedgerName", PayList.Items(1, i))
                    .AddWithValue("Description", PayList.Items(2, i))
                    If PayList.Items(0, i) = "Dr" Then
                        .AddWithValue("Dr", PayList.Items(3, i))
                        .AddWithValue("Cr", 0)
                    Else
                        .AddWithValue("Dr", 0)
                        .AddWithValue("Cr", PayList.Items(3, i))
                    End If
                    .AddWithValue("EmpName", EmployeeName)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
            End If
        Next
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If CDbl(TxtNetTotal.Text) = TotalSalary Then
        Else
            MsgBox("The Debit and Credit amount is not tally.....")
            Exit Sub
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class