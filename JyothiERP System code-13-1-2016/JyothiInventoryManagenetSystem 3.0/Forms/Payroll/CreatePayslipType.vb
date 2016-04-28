Imports System.Windows.Forms

Public Class CreatePayslipType
    Dim AlterName As String = ""
    Dim IsAlterMode As Boolean = False
    Sub New(Optional ByVal payslipname As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If payslipname.Length > 0 Then
            IsAlterMode = True
            AlterName = payslipname
            TxtName.Text = payslipname
            ImsHeadingLabel1.Text = "ALTER A PAY SLIP TYPE"
            Me.Text = ImsHeadingLabel1.Text
            BtnSave.Text = "&Alter"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtName.Text.Length = 0 Then
            MsgBox("Please Enter the Name of the PaySlip Type... ", MsgBoxStyle.Exclamation)
            TxtName.Focus()
            Exit Sub
        End If
        If TxtPayLedger.Text.Length = 0 Then
            MsgBox("Please select the payment Ledger Account...", MsgBoxStyle.Information)
            TxtPayLedger.Focus()
            Exit Sub
        End If
        If IsAlterMode = True Then
            If UCase(TxtName.Text.Replace(" ", "")) <> UCase(AlterName.Replace(" ", "")) Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   paysliptypes where settingname=N'" & TxtName.Text & "'") = True Then
                    MsgBox("The Enter name is alreay exists..", MsgBoxStyle.Information)
                    TxtName.Focus()
                    Exit Sub
                End If
            End If
            ExecuteSQLQuery("UPDATE [paysliptypes]  SET settingname=N'" & TxtName.Text & "',ledgername=N'" & TxtPayLedger.Text & "' WHERE settingname=N'" & AlterName & "'")
            ExecuteSQLQuery("UPDATE [Employees]  SET payslipmethod=N'" & TxtName.Text & "' WHERE payslipmethod=N'" & AlterName & "'")

            Me.Close()
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   paysliptypes where settingname=N'" & TxtName.Text & "'") = True Then
                MsgBox("The Enter name is alreay exists..", MsgBoxStyle.Information)
                TxtName.Focus()
                Exit Sub
            End If
            ExecuteSQLQuery("INSERT INTO [paysliptypes]  ([settingname]    ,[IsActive],[ledgername])     VALUES (N'" & TxtName.Text & "',1,N'" & TxtPayLedger.Text & "')")
            Me.Close()
        End If
    End Sub

    Private Sub CreatePayslipType_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CreatePayslipType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "')) ", TxtPayLedger, "ledgername")
        If IsAlterMode = True Then
            TxtPayLedger.Text = SQLGetStringFieldValue("select ledgername from paysliptypes where settingname=N'" & AlterName & "'", "ledgername")
        End If
    End Sub
End Class
