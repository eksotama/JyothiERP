Imports System.Data.SqlClient

Public Class YearEnd
    Public NewCompData As New NewCompDataStru
    Dim TxtSecondName As New TextBox
    Dim OldDataBaseConn As String = ""
    Dim NewDataBaseConn As String = ""
    Dim ProfitandLossac As Double
    Dim ProfitandlossLedgername As String = ""
    Public Structure NewCompDataStru
        Dim CompanyID As String
        Dim CompanyName As String
        Dim CompanyLicenceno As String
        Dim Companytaxregno As String
        Dim Companyaddresspoboxno As String
        Dim Companystreet As String
        Dim Companystate As String
        Dim Companycountry As String
        Dim Companytel As String
        Dim CompanyFax As String
        Dim Companyemail As String
        Dim Companywebsite As String
        Dim Companyusername As String
        Dim Companypasword As String
        Dim CompanyLogopath As String
        Dim AccDateFrom As Date
        Dim AccDateTo As Date
        Dim BookDateFrom As Date
        Dim BookDateTo As Date
        Dim CompanyAdminEmailId As String
        Dim CompanyType As String
        Dim Currency As String
        Dim CompanyVersionNumber As Integer
    End Structure

    Private Sub YearEnd_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub SpilitDatabaseform_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MainForm.LoadCompaniesList(tcompnies)

    End Sub
    Public Sub LoadSelectedComData()

        Dim SqlConn As New SqlClient.SqlConnection
        Try

            OldDataBaseConn = ConnectionStringFromFile & "; Initial Catalog=" & MainForm.GetCompanyDatabaseName(tcompnies.Text) & ";"
            SqlConn.ConnectionString = OldDataBaseConn
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from company "
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                NewCompData.CompanyID = Sreader("companyID").ToString.Trim
                NewCompData.CompanyName = Sreader("companyname").ToString.Trim
                NewCompData.CompanyLicenceno = Sreader("licenseno").ToString.Trim
                NewCompData.Companytaxregno = Sreader("taxregno").ToString.Trim
                NewCompData.Companyaddresspoboxno = Sreader("address").ToString.Trim
                NewCompData.Companystreet = Sreader("location").ToString.Trim
                NewCompData.Companystate = Sreader("state").ToString.Trim
                NewCompData.Companycountry = Sreader("country").ToString.Trim
                NewCompData.Companytel = Sreader("tel").ToString.Trim
                NewCompData.CompanyFax = Sreader("fax").ToString.Trim
                NewCompData.Companyemail = Sreader("emailid").ToString.Trim
                NewCompData.Companywebsite = Sreader("website").ToString.Trim
                NewCompData.Companyusername = Sreader("adminname").ToString.Trim
                NewCompData.Companypasword = Sreader("adminpassword").ToString.Trim
                NewCompData.CompanyLogopath = Sreader("logoimage").ToString.Trim
                NewCompData.AccDateFrom = CDate(Sreader("accyearstart").ToString.Trim)
                NewCompData.AccDateTo = CDate(Sreader("accyearend").ToString.Trim)
                NewCompData.BookDateFrom = CDate(Sreader("booksyearstart").ToString.Trim)
                NewCompData.BookDateTo = CDate(Sreader("booksyearend").ToString.Trim)
                NewCompData.CompanyAdminEmailId = Sreader("adminemailid").ToString.Trim
                NewCompData.CompanyType = Sreader("accounttype").ToString.Trim
                NewCompData.Currency = Sreader("Currency").ToString.Trim
                If IsDBNull(Sreader("Versionno")) = True Then
                    NewCompData.CompanyVersionNumber = 0
                Else
                    NewCompData.CompanyVersionNumber = Sreader("Versionno")
                End If

                'Versionno
                PhotoPathForLedgers = Sreader("photopath").ToString.Trim
                StockPhotoPath = Sreader("photopath").ToString.Trim & "\StockPhotos"
                PhotoBackupPath = Sreader("Backupath").ToString.Trim
                PhotoPathForBarcode = Sreader("BarcodePath").ToString.Trim
                AppIsItemwithSize = Sreader("IsSizeBasedItem")
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
            SqlConn.Dispose()
        End Try

    End Sub

    Private Sub tcompnies_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcompnies.LostFocus
        LoadSelectedComData()
        TxtSecondName.Text = GetSecondName()
    End Sub
    Function GetSecondName() As String
        Dim dName As String = ""
        dName = NewCompData.CompanyID & "(" & Today.ToString("dd-mm-yyyy") & ")"
        For i As Integer = 1 To 100000
            If MainForm.IsCompanyNameisExists(dName) = False Then
                Exit For
            End If
            dName = NewCompData.CompanyID & "(" & Today.ToString("dd-mm-yyyy") & ")-" & i.ToString
        Next
        Return dName
    End Function

    Private Sub tcompnies_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcompnies.SelectedIndexChanged
        LoadSelectedComData()
        TxtNewCompanyName.Text = GetSecondName()
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If tcompnies.Text.Length = 0 Then
            MsgBox("Please Select the Company Name.... ", MsgBoxStyle.Information)
            tcompnies.Focus()
            Exit Sub
        End If
        If MainForm.IsCompanyNameisExists(TxtNewCompanyName.Text) = True Then
            MsgBox("The Entered Company Name is already Exists, please try again...")
            TxtNewCompanyName.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Year End The Current Selected Company ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MainForm.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            ProgressBar1.Enabled = True
            ProgressBar1.Value = 1
            CreateNewCompany(True)
            ProgressBar1.Value = ProgressBar1.Value + 3
            'NewCompanyDBName
            Dim TEMPCONN As String = ConnectionStrinG
            Dim SelDBName As String = ""
            Dim seldbnametemp As String = MainForm.GetCompanyDatabaseName(tcompnies.Text)
            SelDBName = seldbnametemp & ".dbo."
            ConnectionStrinG = ConnectionStringFromFile & " Initial Catalog=" & NewCompanyDBName & ";"
            Dim TBLSTR As String = "SELECT * FROM INFORMATION_SCHEMA.tables where table_type='Base Table'"

            MainForm.Cursor = Cursors.WaitCursor
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
                ' MsgBox(row.Item("TABLE_NAME"))

                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
                Dim collist As String = ""
                collist = SQLGetStringFieldValue("DECLARE @listStr VARCHAR(MAX);SELECT @listStr = COALESCE(@listStr+',' , '') + '['+ column_name +']' FROM (SELECT column_name FROM information_schema.columns WHERE table_name = '" & row.Item("TABLE_NAME") & "') tt;SELECT @listStr as collist ", "collist")
                If ExecuteSQLQuery("SET IDENTITY_INSERT [dbo]." & row.Item("TABLE_NAME") & " ON; INSERT INTO " & row.Item("TABLE_NAME") & "(" & collist & ") " & " SELECT " & collist & " FROM " & SelDBName & row.Item("TABLE_NAME") & "; SET IDENTITY_INSERT [dbo]." & row.Item("TABLE_NAME") & " OFF ", False) = False Then
                    ExecuteSQLQuery(" INSERT INTO " & row.Item("TABLE_NAME") & "(" & collist & ") " & " SELECT " & collist & " FROM " & SelDBName & row.Item("TABLE_NAME") & "; ", True)
                End If

            Next row

            MainForm.Cursor = Cursors.WaitCursor
            NewDataBaseConn = ConnectionStrinG
            ProgressBar1.Value = ProgressBar1.Value + 1

            ExecuteSQLQuery("UPDATE COMPANY SET COMPANYID='" & TxtNewCompanyName.Text & "'")

            ExecuteSQLQuery("DELETE FROM StockInvoiceDetails")
            ExecuteSQLQuery("DELETE FROM StockInvoiceRowItems")

            ExecuteSQLQuery("DELETE FROM StockTransferDetails")
            ExecuteSQLQuery("DELETE FROM StockTransferRowItems")

            ExecuteSQLQuery("DELETE FROM StockJournalDbf")
            ExecuteSQLQuery("DELETE FROM logfile")
            ExecuteSQLQuery("DELETE FROM InvoiceMoreDet")
            ExecuteSQLQuery("DELETE FROM CostCenterBook")
            ExecuteSQLQuery("DELETE FROM payrollVoucherMasterData")
            ExecuteSQLQuery("DELETE FROM payrollvoucherRowDetails")
            ExecuteSQLQuery("DELETE FROM PayRollVoucherPayMaster")
            ExecuteSQLQuery("DELETE FROM payrollvoucherLedgers")
            ExecuteSQLQuery("DELETE FROM UserLogFile")

            ExecuteSQLQuery("DELETE FROM LedgerBook ")

            Dim DT As New DateTimePicker
            DT.Value = NewCompData.AccDateFrom.AddYears(1)

            ExecuteSQLQuery("UPDATE COMPANY SET accyearstart=CONVERT(datetime,'" & DT.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)")
            DT.Value = NewCompData.AccDateTo.AddYears(1)
            ExecuteSQLQuery("UPDATE COMPANY SET accyearend=CONVERT(datetime,'" & DT.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)")
            DT.Value = NewCompData.BookDateFrom.AddYears(1)

            ExecuteSQLQuery("UPDATE COMPANY SET booksyearstart=CONVERT(datetime,'" & DT.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)")
            DT.Value = NewCompData.BookDateTo.AddYears(1)
            ExecuteSQLQuery("UPDATE COMPANY SET booksyearend=CONVERT(datetime,'" & DT.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)")

            MainForm.Cursor = Cursors.WaitCursor
            
            'StockBatch
            'FIND THE PROFIT AND LOSS ACCOUNT
            ConnectionStrinG = OldDataBaseConn
            Dim Profifandlossval As Double = 0
            Dim dt1 As New DateTimePicker
            Dim isdatewise As New CheckBox
            isdatewise.Checked = False
            Profifandlossval = GetProfitLossAcValues(isdatewise, dt1, dt1, 0)
            ProfitandlossLedgername = SQLGetStringFieldValue("select ledgername from DefLedgers where ledgertype='profit'", "ledgername")
            ProgressBar1.Value = ProgressBar1.Value + 1
            DT.Value = Now
            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand
            ProgressBar1.Value = 30
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "SELECT LEDGERNAME, SUM(DR-CR) AS TOT FROM LEDGERBOOK where isdeleted=0  GROUP BY LEDGERNAME "
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                Dim COUNT As Double = 0
                Dim RCOUT As Double = 0
                Dim TCOUT As Double = 0
                TCOUT = Sreader.RecordsAffected / 70
                RCOUT = TCOUT
                While Sreader.Read()
                    COUNT = COUNT + 1
                    If COUNT >= TCOUT Then
                        Try
                            ProgressBar1.Value = ProgressBar1.Value + 1
                        Catch ex As Exception

                        End Try
                        TCOUT = TCOUT + RCOUT
                    End If
                    If Sreader("TOT") <> 0 Then
                        Dim sqlstr2 As String = ""
                        sqlstr2 = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceType],[InvoiceName],[sno],[Dr],[Cr],[TransDate]," _
                                & " [TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[ConRate],[counterID]) " _
                                & " VALUES(@LedgerName,@TransCode,@InvoiceNo,@InvoiceType,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup," _
                                & " @AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@ConRate,@counterID)"
                        MAINCON.ConnectionString = NewDataBaseConn
                        MAINCON.Open()
                        Dim DBF1 As New SqlClient.SqlCommand(sqlstr2, MAINCON)
                        With DBF1.Parameters
                            .AddWithValue("LedgerName", Sreader("LEDGERNAME").ToString.Trim)
                            .AddWithValue("TransCode", 0)
                            .AddWithValue("InvoiceNo", 0)
                            .AddWithValue("InvoiceType", "Opening Balance")
                            .AddWithValue("InvoiceName", "Opening Balance")
                            .AddWithValue("sno", 1)
                            If Sreader("TOT") > 0 Then
                                .AddWithValue("Dr", Sreader("TOT"))
                                .AddWithValue("Cr", 0)
                            ElseIf Sreader("TOT") < 0 Then
                                .AddWithValue("Dr", 0)
                                .AddWithValue("Cr", Sreader("TOT") * -1)

                            End If

                            .AddWithValue("TransDate", DT.Value)
                            .AddWithValue("TransDateValue", DT.Value.Date.ToOADate)
                            .AddWithValue("LedgerGroup", "")
                            .AddWithValue("AcLedger", "Opening")
                            .AddWithValue("IsAdvance", 0)
                            .AddWithValue("IsDeleted", 0)
                            .AddWithValue("UserName", CurrentUserName)
                            .AddWithValue("StoreName", DefStoreName)
                            .AddWithValue("Narration", "Opening Balances")
                            .AddWithValue("ConRate", GetCurrencyRate(SQLGetStringFieldValue("select currency from ledgers where ledgername=N'" & Sreader("ledgername").ToString & "'", "currency").ToString))
                            .AddWithValue("counterID", 1)
                        End With
                        DBF1.ExecuteNonQuery()
                        DBF1 = Nothing
                        MAINCON.Close()
                        If Sreader("TOT") > 0 Then
                            ExecuteSQLQueryWithConString("UPDATE LEDGERS SET OPDR=" & Sreader("TOT") & ",OPCR=0 WHERE LEDGERNAME=N'" & Sreader("LEDGERNAME").ToString & "'", NewDataBaseConn)
                        Else
                            ExecuteSQLQueryWithConString("UPDATE LEDGERS SET OPDR=0,OPCR=" & Sreader("TOT") * -1 & " WHERE LEDGERNAME=N'" & Sreader("LEDGERNAME").ToString & "'", NewDataBaseConn)
                        End If
                    Else
                        ExecuteSQLQueryWithConString("UPDATE LEDGERS SET OPDR=0,OPCR=0 WHERE LEDGERNAME=N'" & Sreader("LEDGERNAME").ToString & "'", NewDataBaseConn)
                    End If
                    MainForm.Cursor = Cursors.WaitCursor
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


            ExecuteSQLQueryWithConString("DELETE FROM STOCKBATCH WHERE TOTALQTY=0", NewDataBaseConn)
            ExecuteSQLQueryWithConString("UPDATE STOCKDBF SET OPBASEQTY=Baseqty,optotalqty=totalqty,opsubunitqty=subunitqty,opstockrate=stockrate ", NewDataBaseConn)
            ProgressBar1.Value = 100
            MainForm.Cursor = Cursors.Default
            MsgBox("SUCCESS.....Application need to Exit... ", MsgBoxStyle.Information)

            End

            MainForm.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtNewCompanyName_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNewCompanyName.TextChanged

    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class