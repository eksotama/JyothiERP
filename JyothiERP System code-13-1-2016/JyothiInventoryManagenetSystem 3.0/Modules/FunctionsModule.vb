Imports System.Net.Mail
Imports System.Net
Imports System.Text

Module FunctionsModule
    Public EmailValues As New EmailValuesStruct
    Public IsEmailIsConfigured As Boolean = False
    Public AppIsItemwithSize As Boolean = False
    Public TempFileNames1 As String = ""
    Public TempFileNames2 As String = ""
    Public Enum FormNameStruct
        salesquoto = 1
        salesorder = 2
        salesdelavery = 3
        salesinvoice = 4
        purchasequoto = 5
        purchaseorder = 6
        purchasereceived = 7
        purchaseinvoice = 8
        salesvoucher = 9
        salesreturnvoucher = 10
        purchasevoucher = 11
        purchasereturnvoucher = 12
        paymnetvoucher = 13
        receiptvoucher = 14
        contravoucher = 15
        journalvoucher = 16
        SalesRetInvoice = 17
        PurchaseRetInvoice = 18
        alterLedger = 19
        altersalespersons = 20
        alterareas = 21
        altergroups = 22
        alterStockitem = 23

    End Enum
    Structure EmailValuesStruct
        Dim EmailId As String
        Dim Password As String
        Dim Server As String
        Dim Port As Integer
        Dim Footermsg As String
        Dim ISitSSL As String
    End Structure

    Public Sub LoadEmailSettings()
        Dim SQLstr As String = ""
        Dim SqlConn As New SqlClient.SqlConnection
        Dim found As Boolean = False
        SQLstr = "select * from emaildb"
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLstr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader

            Sreader = Sqlcmmd.ExecuteReader
            found = False
            While Sreader.Read()
                EmailValues.EmailId = Sreader("EmailID").ToString.Trim
                EmailValues.Password = DecrypPassword(Sreader("EmailPassword").ToString.Trim)
                EmailValues.Server = Sreader("ServerName").ToString.Trim
                EmailValues.Port = Sreader("Port")
                EmailValues.Footermsg = Sreader("emailfooter").ToString
                EmailValues.ISitSSL = Sreader("IsSSL").ToString
                found = True
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing
        End Try
        If found = True Then
            IsEmailIsConfigured = True
        Else
            IsEmailIsConfigured = False
        End If
    End Sub
    Public Function SendCustomEmailTo(ByVal emailto As String, ByVal subject As String, ByVal msg As String, Optional ByVal filename As String = "", Optional ByVal CCemail As String = "") As Boolean
        If ValidateEmailID(emailto) = False Then
            Return False
            Exit Function
        End If
        MainForm.Cursor = Cursors.WaitCursor
        Dim ISSUCCESS As Boolean = False
        My.Application.DoEvents()
        Try

            Dim SmtpSserver As New SmtpClient()
            Dim mail As New MailMessage
            SmtpSserver.Credentials = New Net.NetworkCredential(EmailValues.EmailId, EmailValues.Password)
            '587 Smtp.gmail.com
            SmtpSserver.Port = EmailValues.Port
            SmtpSserver.Host = EmailValues.Server
            SmtpSserver.UseDefaultCredentials = False
            If EmailValues.ISitSSL = "YES" Then
                SmtpSserver.EnableSsl = True
            Else
                SmtpSserver.EnableSsl = False
            End If


            mail = New MailMessage
            mail.From = New MailAddress(EmailValues.EmailId)

            mail.To.Add(emailto)
            If CCemail.Length > 1 Then
                mail.CC.Add(CCemail)
            End If
            mail.Subject = subject
            ' mail.BodyEncoding = Encoding.UTF8

            mail.IsBodyHtml = True
            If filename.Length > 0 Then
                Dim attach As New Mail.Attachment(filename)
                mail.Attachments.Add(attach) 'add the attachment
            End If
            mail.Body = msg & EmailValues.Footermsg
            SmtpSserver.Send(mail)
            ISSUCCESS = True
        Catch ex As Exception
            ISSUCCESS = False
            MsgBox(ex.Message.ToString)
            MainForm.Cursor = Cursors.Default
        End Try
        MainForm.Cursor = Cursors.Default
        Return ISSUCCESS
    End Function
    Public Function GetPDCValues(ByVal tcode As Double) As PDCSettingsClass
        Dim pdcval As New PDCSettingsClass
        'IsChequePrint
        'ClearPDC
        'TodaydateValue
        'IsPostDated
        'TodayDate
        Dim SQLstr As String = ""
        Dim SqlConn As New SqlClient.SqlConnection
        SQLstr = "select * from ledgerbook where transcode=" & tcode
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLstr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                If IsDBNull(Sreader("IsChequePrint")) = True Then
                    pdcval.ischequePrint = False
                Else
                    pdcval.ischequePrint = Sreader("IsChequePrint")
                End If

                If IsDBNull(Sreader("IsPostDated")) = True Then
                    pdcval.IsPDC = False
                Else
                    pdcval.IsPDC = Sreader("IsPostDated")
                End If


                If IsDBNull(Sreader("ClearPDC")) = True Then
                    pdcval.IsPDCClear = False
                Else
                    pdcval.IsPDCClear = Sreader("ClearPDC")
                End If

                If IsDBNull(Sreader("TodayDate")) = True Then
                    pdcval.TodayDate.Value = Today
                Else
                    pdcval.TodayDate.Value = Sreader("TodayDate")
                End If


                Exit While
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return pdcval
    End Function
    Public Sub UpdatePDCValues(ByVal tcode As Double, ByVal pdcval As PDCSettingsClass)
        'Cast([Date] as datetime)
        Dim SqlStr As String = "UPDATE LEDGERBOOK SET IsChequePrint='" & pdcval.ischequePrint & "',ClearPDC='" & pdcval.IsPDCClear & "', TodaydateValue=" & pdcval.TodayDate.Value.Date.ToOADate & ",IsPostDated='" & pdcval.IsPDC & "',TodayDate=CONVERT(datetime,'" & pdcval.TodayDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) where transcode=" & tcode
        ExecuteSQLQuery(SqlStr)
    End Sub
End Module
