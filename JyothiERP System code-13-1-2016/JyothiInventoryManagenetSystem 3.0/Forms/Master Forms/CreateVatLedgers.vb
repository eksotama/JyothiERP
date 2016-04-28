Imports System.Windows.Forms

Public Class CreateVatLedgers
    Dim IsAlterMode As Boolean = False
    Dim OpenVatName As String = ""
    Dim OpenVatTax As Double = 0
    Sub New(Optional ByVal VatName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If VatName.Length > 0 Then
            IsAlterMode = True
            OpenVatName = VatName
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadDefults()
        TxtVatTax.Text = "0"
        TxtServiceTaxAmt.Text = "0"
        TxtServiceTaxLedger.Text = ""
        TxtServiceTaxname.Text = ""
        TxtTaxType.Text = "VAT"
        TxtVatName.Text = ""
        LoadLedgers()
        TxtStatus.Text = "Ready....."
    End Sub
    Sub LoadLedgers()
        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DutiesTaxes & "'))", TxtInputVat, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DutiesTaxes & "'))", TxtOutPutvat, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "'))", Txtpurchaseledger, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "'))", TxtSalesLedger, "ledgername")
        LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DutiesTaxes & "'))", TxtServiceTaxLedger, "ledgername")
    End Sub
    Sub LoadData()
        Dim SqlConn As New SqlClient.SqlConnection
        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from vatclauses WHERE vatname=N'" & OpenVatName & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("vattype") = "Service Tax" Then
                    TxtTaxType.Text = "Service Tax"
                    TxtServiceTaxname.Text = Sreader("vatname").ToString
                    TxtServiceTaxAmt.Text = Sreader("vattax")
                    OpenVatTax = CDbl(TxtServiceTaxAmt.Text)
                    TxtServiceTaxLedger.Text = Sreader("inputvatledger")

                Else

                    TxtTaxType.Text = Sreader("vattype").ToString
                    TxtVatName.Text = Sreader("vatname").ToString
                    TxtVatTax.Text = Sreader("vattax")
                    OpenVatTax = CDbl(TxtVatTax.Text)
                    TxtInputVat.Text = Sreader("inputvatledger")
                    TxtOutPutvat.Text = Sreader("outputvatledger")
                    Txtpurchaseledger.Text = Sreader("PurchaseLedger")

                    TxtSalesLedger.Text = Sreader("SalesLedger")

                End If
               
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Private Sub TxtInputVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtInputVat.KeyDown, TxtServiceTaxLedger.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateLedgerAccounts
            newsg.ShowDialog()
            newsg.Dispose()
            LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DutiesTaxes & "'))", TxtInputVat, "ledgername")
            LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.DutiesTaxes & "'))", TxtServiceTaxLedger, "ledgername")
        End If
    End Sub

    Private Sub TxtOutPutvat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOutPutvat.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateLedgerAccounts
            newsg.ShowDialog()
            newsg.Dispose()
        End If
    End Sub

    Private Sub Txtpurchaseledger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtpurchaseledger.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateLedgerAccounts
            newsg.ShowDialog()
            newsg.Dispose()
            LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "'))", Txtpurchaseledger, "ledgername")


        End If
    End Sub

    Private Sub TxtPurchaseReturnledger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateLedgerAccounts
            newsg.ShowDialog()
            newsg.Dispose()
            LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.PurchaseAccounts & "'))", Txtpurchaseledger, "ledgername")


        End If
    End Sub

    Private Sub TxtSalesLedger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSalesLedger.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateLedgerAccounts
            newsg.ShowDialog()
            newsg.Dispose()
            LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "'))", TxtSalesLedger, "ledgername")


        End If
    End Sub

    Private Sub TxtSalesReturnLedger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim newsg As New CreateLedgerAccounts
            newsg.ShowDialog()
            newsg.Dispose()
            LoadDataIntoComboBox("select ledgername from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SalesAccounts & "'))", TxtSalesLedger, "ledgername")


        End If
    End Sub

    Private Sub CreateVatLedgers_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtTaxType.Focus()
    End Sub

   
    Private Sub CreateVatLedgers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        LoadDefults()
        If IsAlterMode = True Then
            TxtTaxType.Enabled = False
            LoadData()
        Else
            TxtTaxType.Enabled = True
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtTaxType.Text.Length = 0 Then
            MsgBox("Please Select the Tax Type ..         ", MsgBoxStyle.Information)
            TxtTaxType.Focus()
            Exit Sub
        End If
        If TxtTaxType.Text = "VAT" Or TxtTaxType.Text = "CST" Then
            If TxtVatName.Text.Length = 0 Then
                MsgBox("Please Enter the Vat Clause Name ...  ", MsgBoxStyle.Information)
                TxtVatName.Focus()
                Exit Sub
            End If
            If CDbl(TxtVatTax.Text) < 0 Then
                MsgBox("Please Enter the Vat Tax Percentage ....", MsgBoxStyle.Information)
                TxtVatTax.Focus()
                Exit Sub
            End If
            If TxtInputVat.Text.Length = 0 Or TxtOutPutvat.Text.Length = 0 Or Txtpurchaseledger.Text.Length = 0 Or TxtSalesLedger.Text.Length = 0 Then
                MsgBox("Please Select the Ledgers accounts for required fileds....")
                TxtInputVat.Focus()
                Exit Sub
            End If

            If IsAlterMode = True Then
                If UCase(TxtVatName.Text) <> UCase(OpenVatName) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vatname=N'" & TxtVatName.Text & "'") = True Then
                        MsgBox("The Vat Name is already exists, Please try again..... ")
                        TxtVatName.Focus()
                        Exit Sub
                    End If
                End If
                If OpenVatTax <> CDbl(TxtVatTax.Text) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vattax=" & CDbl(TxtVatTax.Text) & " and vattype=N'" & TxtTaxType.Text & "'") = True Then
                        MsgBox("The Vat Tax is already exists, Please try again..... ")
                        TxtVatTax.Focus()
                        Exit Sub
                    End If
                End If
                If MsgBox("Do You want to Alter VAT Clause ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim SqlStr As String = ""
                    SqlStr = "UPDATE [Vatclauses]   SET [VatName] = @VatName,[vattax] = @vattax,[inputvatledger] =@inputvatledger,[outputvatledger] = @outputvatledger,[PurchaseLedger] = @PurchaseLedger,[DebitNoteLedger] = @DebitNoteLedger,[SalesLedger] = @SalesLedger,[CreditLedger] = @CreditLedger,[isactive] = @isactive , vattype=@vattype WHERE VatName=N'" & OpenVatName & "'"
                    SaveVATData(SqlStr)
                    Me.Close()
                End If

            Else
                If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vatname=N'" & TxtVatName.Text & "'") = True Then
                    MsgBox("The Vat Name is already exists, Please try again..... ")
                    TxtVatName.Focus()
                    Exit Sub
                End If
                If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vattax=" & CDbl(TxtVatTax.Text) & " and vattype=N'" & TxtTaxType.Text & "'") = True Then
                    MsgBox("The Vat Tax is already exists, Please try again..... ")
                    TxtVatTax.Focus()
                    Exit Sub
                End If
                If MsgBox("Do You want to create VAT Clause ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [Vatclauses] ([VatName],[vattax],[inputvatledger],[outputvatledger],[PurchaseLedger],[DebitNoteLedger],[SalesLedger],[CreditLedger],[isactive],[vattype])     VALUES " _
                        & " (@VatName,@vattax,@inputvatledger,@outputvatledger,@PurchaseLedger,@DebitNoteLedger,@SalesLedger,@CreditLedger,@isactive,@vattype) "
                    SaveVATData(SqlStr)
                    TxtStatus.Text = "Saved Successfully....."
                    LoadDefults()
                End If
            End If
        Else
            If TxtServiceTaxname.Text.Length = 0 Then
                MsgBox("Please Enter the Serveice Tax Clause Name ...  ", MsgBoxStyle.Information)
                TxtServiceTaxname.Focus()
                Exit Sub
            End If
            If CDbl(TxtServiceTaxAmt.Text) < 0 Then
                MsgBox("Please Enter the Service Tax Percentage ....", MsgBoxStyle.Information)
                TxtServiceTaxAmt.Focus()
                Exit Sub
            End If
            If TxtServiceTaxLedger.Text.Length = 0 Then
                MsgBox("Please Select the Service tax Ledger ....")
                TxtServiceTaxLedger.Focus()
                Exit Sub
            End If
            If IsAlterMode = True Then
                If UCase(TxtServiceTaxname.Text) <> UCase(OpenVatName) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vatname=N'" & TxtServiceTaxname.Text & "'") = True Then
                        MsgBox("The Service Tax Name is already exists, Please try again..... ")
                        TxtServiceTaxname.Focus()
                        Exit Sub
                    End If
                End If
                If OpenVatTax <> CDbl(TxtServiceTaxAmt.Text) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vattax=" & CDbl(TxtServiceTaxAmt.Text) & " and vattype='Service Tax'") = True Then
                        MsgBox("The Service Tax is already exists, Please try again..... ")
                        TxtServiceTaxAmt.Focus()
                        Exit Sub
                    End If
                End If
                If MsgBox("Do You want to Alter Service Tax Clause ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim SqlStr As String = ""
                    SqlStr = "UPDATE [Vatclauses]   SET [VatName] = @VatName,[vattax] = @vattax,[inputvatledger] =@inputvatledger,[outputvatledger] = @outputvatledger,[PurchaseLedger] = @PurchaseLedger,[DebitNoteLedger] = @DebitNoteLedger,[SalesLedger] = @SalesLedger,[CreditLedger] = @CreditLedger,[isactive] = @isactive , vattype=@vattype WHERE VatName=N'" & OpenVatName & "'"
                    SaveServiceTaxData(SqlStr)

                    Me.Close()

                End If

            Else
                If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vatname=N'" & TxtServiceTaxname.Text & "'") = True Then
                    MsgBox("The Service Tax Name is already exists, Please try again..... ")
                    TxtServiceTaxname.Focus()
                    Exit Sub
                End If
                If SQLIsFieldExists("SELECT TOP 1 1 from   Vatclauses where vattax=" & CDbl(TxtServiceTaxAmt.Text) & " and vattype='Service Tax'") = True Then
                    MsgBox("The Service Tax is already exists, Please try again..... ")
                    TxtVatTax.Focus()
                    Exit Sub
                End If
                If MsgBox("Do You want to create Service Tax Clause ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [Vatclauses] ([VatName],[vattax],[inputvatledger],[outputvatledger],[PurchaseLedger],[DebitNoteLedger],[SalesLedger],[CreditLedger],[isactive],[vattype])     VALUES " _
                        & " (@VatName,@vattax,@inputvatledger,@outputvatledger,@PurchaseLedger,@DebitNoteLedger,@SalesLedger,@CreditLedger,@isactive,@vattype) "
                    SaveServiceTaxData(SqlStr)
                    TxtStatus.Text = "Saved Successfully....."
                    LoadDefults()
                End If
            End If
        End If
       
    End Sub
    Sub SaveServiceTaxData(ByVal SqlStr As String)
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF1.Parameters
            .AddWithValue("VatName", TxtServiceTaxname.Text)
            .AddWithValue("vattax", CDbl(TxtServiceTaxAmt.Text))
            .AddWithValue("inputvatledger", TxtServiceTaxLedger.Text)
            .AddWithValue("outputvatledger", "")
            .AddWithValue("PurchaseLedger", "")
            .AddWithValue("DebitNoteLedger", "")
            .AddWithValue("SalesLedger", "")
            .AddWithValue("CreditLedger", "")
            .AddWithValue("isactive", "True")
            .AddWithValue("vattype", TxtTaxType.Text)
        End With
        DBF1.ExecuteNonQuery()
        DBF1 = Nothing
        MAINCON.Close()
    End Sub

    Sub SaveVATData(ByVal SqlStr As String)
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF1.Parameters
            .AddWithValue("VatName", TxtVatName.Text)
            .AddWithValue("vattax", CDbl(TxtVatTax.Text))
            .AddWithValue("inputvatledger", TxtInputVat.Text)
            .AddWithValue("outputvatledger", TxtOutPutvat.Text)
            .AddWithValue("PurchaseLedger", Txtpurchaseledger.Text)
            .AddWithValue("DebitNoteLedger", Txtpurchaseledger.Text)
            .AddWithValue("SalesLedger", TxtSalesLedger.Text)
            .AddWithValue("CreditLedger", TxtSalesLedger.Text)
            .AddWithValue("isactive", "True")
            .AddWithValue("vattype", TxtTaxType.Text)
        End With
        DBF1.ExecuteNonQuery()
        DBF1 = Nothing
        MAINCON.Close()
    End Sub

    Private Sub TxtTaxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTaxType.SelectedIndexChanged
        If TxtTaxType.Text = "VAT" Or TxtTaxType.Text = "CST" Then
            VatTaxPanel.Visible = True
            ServiceTaxPanel.Visible = False
        Else
            VatTaxPanel.Visible = False
            ServiceTaxPanel.Visible = True
        End If
    End Sub
End Class
