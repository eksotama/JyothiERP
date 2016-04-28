Imports System.Windows.Forms

Public Class NewPayAddDeductions
    Dim AlterName As String = ""
    Dim IsAlter As Boolean = False
    Public PaySlipSettingGroup As String = ""
    Public IsBasicSalary As Boolean = False
    Sub New(Optional ByVal EditName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If EditName.Length > 0 Then
            IsAlter = True
            AlterName = EditName
            If EditName = "Basic Salary" Then
                IsBasicSalary = True
            End If
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
   

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtType.Text.Length = 0 Then
            MsgBox("Please Select the Type             ", MsgBoxStyle.Information)
            TxtType.Focus()
            Exit Sub
        End If
        If UCase(TxtName.Text.Replace(" ", "")) = "NETSALARY" Or UCase(TxtName.Text.Replace(" ", "")) = "NETTOTAL" Or UCase(TxtName.Text.Replace(" ", "")) = "SUBTOTAL" Or UCase(TxtName.Text.Replace(" ", "")) = "GROSS" Or UCase(TxtName.Text.Replace(" ", "")) = "GROSSTOTAL" Or UCase(TxtName.Text.Replace(" ", "")) = "TOTAL" Then
            MsgBox("The Bad Name , Please Try again....      ")
            TxtName.Focus()
            Exit Sub
        End If
        If TxtName.Text.Length = 0 Then
            MsgBox("Please Enter the Name        ", MsgBoxStyle.Information)
            TxtName.Focus()
            Exit Sub
        End If
        If TxtMethod.Text.Length = 0 Then
            MsgBox("Please Select the Method   ", MsgBoxStyle.Information)
            TxtMethod.Focus()
            Exit Sub
        End If

        If TxtLedger.Text.Length = 0 Then
            MsgBox("Please Select the Ledger Account Name             ", MsgBoxStyle.Information)
            TxtLedger.Focus()
            Exit Sub
        End If

        'If TxtPayLedger.Text.Length = 0 Then
        '    MsgBox("Please Select the Payment Ledger Account Name             ", MsgBoxStyle.Information)
        '    TxtPayLedger.Focus()
        '    Exit Sub
        'End If
        If IsAlter = True Then
            If UCase(TxtName.Text) <> UCase(AlterName) Then
                If SQLIsFieldExists("select payname from paytypes where payname=N'" & TxtName.Text & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'") = True Then
                    MsgBox("The Name is already Exists, Please try again....   ")
                    TxtName.Focus()
                    Exit Sub
                End If
            End If
            If MsgBox("Do you want to Alter ?          ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete  from paytypes where payname=N'" & AlterName & "' and PayTypeGroup=N'" & PaySlipSettingGroup & "'")
                ExecuteSQLQuery("INSERT INTO [PayTypes] ([PayType],[PayName],[per],[method],[orderno],[LedgerName],[PaymentLedger],[PayTypeGroup])     VALUES (N'" & TxtType.Text & "',N'" & TxtName.Text & "'," & TxtPer.Text & ",N'" & TxtMethod.Text & "'," & TxtOrderNo.Text & ",N'" & TxtLedger.Text & "',N'" & TxtPayLedger.Text & "',N'" & PaySlipSettingGroup & "')")
                If UCase(TxtName.Text) <> UCase(AlterName) Then

                    ExecuteSQLQuery("update payrollvoucherRowDetails set payname=N'" & TxtName.Text & "' where payname=N'" & AlterName & "'")
                    ExecuteSQLQuery("update payrollvoucherLedgers set payname=N'" & TxtName.Text & "' where payname=N'" & AlterName & "'")

                    ExecuteSQLQuery("update payrollVoucherMasterData set sqlstr=replace(sqlstr,'[" & AlterName & "]' ,'[" & TxtName.Text & "]')")


                    'payrolldetailsdata
                End If
                Me.Close()
            End If
        Else
            If SQLIsFieldExists("select payname from paytypes where payname=N'" & TxtName.Text & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'") = True Then
                MsgBox("The Name is already Exists, Please try again....   ")
                TxtName.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to Save ?          ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("INSERT INTO [PayTypes] ([PayType],[PayName],[per],[method],[orderno],[LedgerName],[PaymentLedger],[PayTypeGroup])     VALUES (N'" & TxtType.Text & "',N'" & TxtName.Text & "'," & TxtPer.Text & ",N'" & TxtMethod.Text & "'," & TxtOrderNo.Text & ",N'" & TxtLedger.Text & "',N'" & TxtPayLedger.Text & "',N'" & PaySlipSettingGroup & "')")
                loaddefs()
            End If
        End If
        IsBasicSalary = False
    End Sub
    Sub loaddefs()
        TxtName.Text = ""
        TxtPer.Text = "0"
        TxtMethod.Text = ""
        TxtType.Text = ""
        TxtOrderNo.Text = SQLGetNumericFieldValue("select max(orderno) as tot from paytypes where  PayTypeGroup=N'" & PaySlipSettingGroup & "'", "tot") + 1
        TxtName.Enabled = True
        TxtMethod.Enabled = True
        TxtType.Enabled = True
        TxtType.Focus()
        If IsBasicSalary = True Then
            TxtName.Text = "Basic Salary"
            TxtType.Text = "Allowances"
            TxtName.Enabled = False
            TxtType.Enabled = False
            TxtPer.Enabled = False
            If TxtMethod.Items.Count > 0 Then
                TxtMethod.SelectedIndex = 0
            End If
            TxtMethod.Enabled = False
            TxtMethod.Text = "Fixed"
        End If
    End Sub

    Private Sub NewPayAddDeductions_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub NewPayAddDeductions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Whstr As String = " where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "' or groupname=N'Direct' or groupname=N'" & AccountGroupNames.IndirectIncomes & "' or groupname=N'" & AccountGroupNames.DirectIncomes & "' or groupname=N'" & AccountGroupNames.LoansAdvancesAssets & "' or groupname=N'" & AccountGroupNames.DutiesTaxes & "' or groupname=N'" & AccountGroupNames.DepositsAccountsAssets & "')) "
        LoadDataIntoComboBox("select ledgername from ledgers  " & Whstr, TxtLedger, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.BankAccounts & "' or groupname=N'" & AccountGroupNames.CashAccounts & "' or groupname=N'" & AccountGroupNames.BankOD & "')) ", TxtPayLedger, "ledgername")

        If IsAlter = True Then
            TxtName.Text = AlterName
            TxtType.Text = SQLGetStringFieldValue("select paytype from paytypes where payname=N'" & AlterName & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'", "paytype")
            TxtMethod.Text = SQLGetStringFieldValue("select method from paytypes where payname=N'" & AlterName & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'", "method")
            TxtPer.Text = SQLGetNumericFieldValue("select per from paytypes where payname=N'" & AlterName & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'", "per")
            TxtOrderNo.Text = SQLGetNumericFieldValue("select orderno from paytypes where payname=N'" & AlterName & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'", "orderno")
            TxtLedger.Text = SQLGetStringFieldValue("select LedgerName from paytypes where payname=N'" & AlterName & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'", "LedgerName")
            TxtPayLedger.Text = SQLGetStringFieldValue("select PaymentLedger from paytypes where payname=N'" & AlterName & "'  and PayTypeGroup=N'" & PaySlipSettingGroup & "'", "PaymentLedger")
            BtnSave.Text = "&Alter"
        Else
            loaddefs()
        End If
    End Sub

    Private Sub TxtMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMethod.SelectedIndexChanged, TxtPayLedger.SelectedIndexChanged, TxtLedger.SelectedIndexChanged
        If TxtMethod.Text = "Fixed" Then
            TxtPer.MaxLength = 10
            TxtPer.Max = 99999999
            txtperlbl.Text = "Fixed Amount"
        Else
            TxtPer.MaxLength = 5
            TxtPer.Max = 99
            txtperlbl.Text = "Percentage %"
        End If
    End Sub

    Private Sub TxtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtType.SelectedIndexChanged
        If TxtType.Text = "Deductions" Then
            TxtPayLedger.Enabled = False
        Else
            TxtPayLedger.Enabled = True
        End If
    End Sub
End Class
