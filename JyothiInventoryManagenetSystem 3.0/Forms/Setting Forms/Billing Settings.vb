Public Class Billing_Settings

    Private Sub TxtSelectedSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSelectedSettings.SelectedIndexChanged, TxtLocation.SelectedIndexChanged
        TxtInvoicenoStart.Text = ""
        TxtInvoicePreFix.Text = ""
        TxtInvoicePostFix.Text = ""
        Dim SQLStr As String = ""
        If TxtLocation.Text.Length = 0 Then Exit Sub

        If TxtSelectedSettings.Text.Length = 0 Then
            Panel2.Enabled = False
            Exit Sub
        Else
            Panel2.Enabled = True
        End If

        TxtTitle.Text = TxtSelectedSettings.Text & " SETTINGS "

        Select Case TxtSelectedSettings.Text
            Case "CONTRA"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='CON' and location=N'" & TxtLocation.Text & "'"
            Case "JOURNAL"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='JOUR' and location=N'" & TxtLocation.Text & "'"
            Case "PAYMENT"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PAY' and location=N'" & TxtLocation.Text & "'"
            Case "PURCHASE"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PI' and location=N'" & TxtLocation.Text & "'"
            Case "PURCHASE ORDERS"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PO' and location=N'" & TxtLocation.Text & "'"
            Case "PURCHASE RETURNS"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PR' and location=N'" & TxtLocation.Text & "'"
            Case "RECEIPT"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='REC' and location=N'" & TxtLocation.Text & "'"
            Case "SALES"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SI' and location=N'" & TxtLocation.Text & "'"
            Case "SALES ORDERS"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SO' and location=N'" & TxtLocation.Text & "'"
            Case "SALES RETURNS"

                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SR' and location=N'" & TxtLocation.Text & "'"
            Case "SALES QUOTATION"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SQ' and location=N'" & TxtLocation.Text & "'"
            Case "SALES DELIVERY NOTE"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SD' and location=N'" & TxtLocation.Text & "'"
            Case "PURCHASE ENQUIRY"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PQ' and location=N'" & TxtLocation.Text & "'"
            Case "PURCHASE GOODS RECEIVED"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PG' and location=N'" & TxtLocation.Text & "'"
            Case "SALES VOUCHER"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SV' and location=N'" & TxtLocation.Text & "'"
            Case "SALES RETURN VOUCHER"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SRV' and location=N'" & TxtLocation.Text & "'"
            Case "PURCHASE VOUCHER"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PV' and location=N'" & TxtLocation.Text & "'"
            Case "PURCHASE RETURN VOUCHER"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='PRV' and location=N'" & TxtLocation.Text & "'"
            Case "POS"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='POS' and location=N'" & TxtLocation.Text & "'"
            Case "STOCK JOURNAL"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SJ' and location=N'" & TxtLocation.Text & "'"

            Case "SALES FORM8"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='F8' and location=N'" & TxtLocation.Text & "'"
            Case "SALES FORM8B"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='F8B' and location=N'" & TxtLocation.Text & "'"
            Case "SALES FORM8D"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='F8D' and location=N'" & TxtLocation.Text & "'"

            Case "SALES RETURNS FORM8"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SRF8' and location=N'" & TxtLocation.Text & "'"
            Case "SALES RETURNS FORM8B"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SRF8B' and location=N'" & TxtLocation.Text & "'"
            Case "SALES RETURNS FORM8D"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='SRF8D' and location=N'" & TxtLocation.Text & "'"

            Case "CASH SALES"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='CASHSALES' and location=N'" & TxtLocation.Text & "'"

            Case "CREDIT SALES"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='CREDITSALES' and location=N'" & TxtLocation.Text & "'"
            Case "CASH PURCHASE"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='CASHPURCHASE' and location=N'" & TxtLocation.Text & "'"
            Case "CREDIT PURCHASE"
                SQLStr = "SELECT * FROM INVOICESETTINGS WHERE VoucherName='CREDITPURCHASE' and location=N'" & TxtLocation.Text & "'"

                'RETURNS 
                'STOCK JOURNAL
            Case Else
                Panel2.Enabled = False
                TxtInvoiceMethod.SelectedIndex = 0
                TxtInvoicenoStart.Text = ""
                TxtInvoicePreFix.Text = ""
                TxtInvoicePostFix.Text = ""

        End Select

        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = SQLStr
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtInvoiceMethod.SelectedIndex = CInt(Sreader("InvoiceMethod").ToString.Trim())
                TxtInvoicenoStart.Text = Sreader("invoicenumber").ToString.Trim()
                TxtAllowDuplicates.SelectedIndex = CInt(Sreader("AllowDuplicate"))
                TxtInvoicePreFix.Text = Sreader("InvoicePreFix").ToString.Trim()
                TxtInvoicePostFix.Text = Sreader("InvoicePostFix").ToString.Trim()
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()

            SQLFcmd.Connection = Nothing
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static k As Boolean = True
        Static c As Byte = 0
        If k = True Then
            TxtStatus.ForeColor = Color.Green
            k = False
        Else
            TxtStatus.ForeColor = Color.Blue
            k = True
        End If
        If c = 5 Then
            Timer1.Enabled = False
            c = 0
            TxtStatus.ForeColor = Color.Green
            TxtStatus.Text = "Status: Ready"
        Else
            c = c + 1
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtLocation.Text.Length = 0 Then
            MsgBox("Please Select the Location/Branch Name.... ", MsgBoxStyle.Information)
            TxtLocation.Focus()
            Exit Sub

        End If
        If TxtSelectedSettings.Text.Length = 0 Then

            MsgBox("Please Select The Settings For ..         ", MsgBoxStyle.Information)
            TxtSelectedSettings.Focus()
            Exit Sub
        End If

        If MsgBox("Do you want to save changes ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
            Exit Sub
        End If


        Dim SqlStr As String = ""
        Select Case TxtSelectedSettings.Text
            Case "CONTRA"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='CON'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "JOURNAL"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='JOUR'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PAYMENT"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PAY'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PURCHASE"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PI'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PURCHASE ORDERS"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PO'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PURCHASE RETURNS"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PR'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "RECEIPT"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='REC'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SI'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES ORDERS"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SO'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES RETURNS"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SR'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES QUOTATION"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SQ'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES DELIVERY NOTE"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SD'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PURCHASE ENQUIRY"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PQ'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PURCHASE GOODS RECEIVED"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PG'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PURCHASE RETURN VOUCHER"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PRV'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "PURCHASE VOUCHER"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='PV'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES VOUCHER"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SV'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES RETURN VOUCHER"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SRV'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "POS"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='POS'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "STOCK JOURNAL"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SJ'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
                'SALES FORM8
            Case "SALES FORM8"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='F8'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES FORM8B"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='F8B'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES FORM8D"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='F8D'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
                'RETURNS
            Case "SALES RETURNS FORM8"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SRF8'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES RETURNS FORM8B"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SRF8B'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "SALES RETURNS FORM8D"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='SRF8D'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "CASH SALES"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='Cashsales'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "CREDIT SALES"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='CREDITSALES'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "CREDIT PURCHASE"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='CREDITPURCHASE'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
            Case "CASH PURCHASE"
                SqlStr = "update InvoiceSettings set InvoiceMethod=" & TxtInvoiceMethod.SelectedIndex & ", invoicenumber=" & TxtInvoicenoStart.Text & ", InvoicePreFix=N'" & TxtInvoicePreFix.Text & "',InvoicePostFix=N'" & TxtInvoicePostFix.Text & "',AllowDuplicate=" & TxtAllowDuplicates.SelectedIndex & " where VoucherName='CASHPURCHASE'  and location=N'" & TxtLocation.Text & "'"
                ExecuteSQLQuery(SqlStr)
        End Select
        TxtStatus.Text = "Status: Success...."
        LoadInvoiceBillingSettings()

    End Sub

    Private Sub Billing_Settings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub Billing_Settings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       
        LoadDataIntoComboBox("Select locationname from  StockLocations", TxtLocation, "locationname")
        TxtAllowDuplicates.Text = "NO"
        TxtInvoiceMethod.Text = "Automatic"
        TxtSelectedSettings.SelectedIndex = 0
    End Sub

    Private Sub TxtInvoiceMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInvoiceMethod.SelectedIndexChanged
        If TxtInvoiceMethod.Text = "Automatic" Then
            TxtAllowDuplicates.Visible = False
            lblAllowDuplicates.Visible = False
        Else
            TxtAllowDuplicates.Visible = True
            lblAllowDuplicates.Visible = True
        End If
    End Sub

    Private Sub TxtInvoicenoStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInvoicenoStart.TextChanged, TxtInvoicePostFix.TextChanged, TxtInvoicePreFix.TextChanged
        TxtPreview.Text = "Preview: " & TxtInvoicePreFix.Text & TxtInvoicenoStart.Text & TxtInvoicePostFix.Text
    End Sub
End Class