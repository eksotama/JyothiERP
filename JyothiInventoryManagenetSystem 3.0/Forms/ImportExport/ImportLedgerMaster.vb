Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Public Class ImportLedgerMaster
    Dim DbFiledName As String = ""
    Dim LedgerName As String = ""
    Dim LedgerType As String = ""
    Dim LedgerOpBalance As Double = 0
    Dim LedgerCity As String = ""
    Dim LedgerCountry As String = ""
    Dim Ledgeraddress As String = ""
    Dim Ledgerzipcode As String = ""
    Dim Ledgeremailid As String = ""
    Dim LedgerContactNo As String = ""
    Dim LedgerTaxRegNo As String = ""
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            ReadData(opfile.FileName)
        End If
    End Sub
  
    Sub ReadData(ByVal filename As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rowno As Integer
        Dim colno As Integer
        Dim Obj As Object
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        TxtList.Rows.Clear()
        Dim listrowno As Integer
        range = xlWorkSheet.UsedRange

        For rowno = 1 To range.Rows.Count
            For colno = 1 To 9

                Obj = CType(range.Cells(rowno, colno), Excel.Range)
                Dim TEMPSTR As String = ""
                TEMPSTR = Trim(Obj.VALUE)
                If TEMPSTR.Length > 0 Then
                    TEMPSTR = System.Text.RegularExpressions.Regex.Replace(TEMPSTR, "[ ]{2,}", " ")
                End If

                If colno = 1 Then
                    listrowno = TxtList.Rows.Add
                End If
                If colno = 3 Then
                    If IsNumeric(TEMPSTR) = True Then
                        TxtList.Item(colno - 1, rowno - 1).Value = FormatNumber(TEMPSTR, ErpDecimalPlaces, , , TriState.False)
                    End If
                Else
                    TxtList.Item(colno - 1, rowno - 1).Value = TEMPSTR
                End If
            Next
        Next
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ImportLedgerMaster_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ImportPriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        TxtList.Rows.Clear()
    End Sub

   

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
       
        If TxtList.Rows.Count = 0 Then
            MsgBox("There are no list to update..., Please selec the excel file....", MsgBoxStyle.Information)
            Exit Sub
        End If
      
        Dim count As Integer = 0
        If MsgBox(" Do you want to update the Ledger Masters ?      ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            For rowno As Integer = 0 To TxtList.RowCount - 1
                LedgerName = TxtList.Item("lname", rowno).Value
                If LedgerName = Nothing Or LedgerName.Length = 0 Then
                    GoTo NextRowLine
                End If
                LedgerType = TxtList.Item("lType", rowno).Value
                If LedgerType = Nothing Or LedgerType.Length = 0 Then
                    GoTo NextRowLine
                End If
                'validat the ledger groups
                If SQLIsFieldExists("SELECT TOP 1 1 from   AccountGroups where groupname=N'" & LedgerType & "'") = False Then
                    TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.Red
                    GoTo NextRowLine
                End If

                If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where LedgerNameTemp=N'" & Replace(LedgerName, " ", "") & "'") = True Then
                    TxtList.Rows(rowno).DefaultCellStyle.BackColor = Color.Red
                    GoTo NextRowLine
                End If
                LedgerOpBalance = TxtList.Item("opbalance", rowno).Value

                LedgerTaxRegNo = TxtList.Item("tregno", rowno).Value
                If LedgerTaxRegNo = Nothing Then
                    LedgerTaxRegNo = ""
                End If

                LedgerCity = TxtList.Item("tcity", rowno).Value
                If LedgerCity = Nothing Then
                    LedgerCity = ""
                End If

                LedgerCountry = TxtList.Item("tcountry", rowno).Value
                If LedgerCountry = Nothing Then
                    LedgerCountry = ""
                End If

                Ledgerzipcode = TxtList.Item("tzipcode", rowno).Value
                If Ledgerzipcode = Nothing Then
                    Ledgerzipcode = ""
                End If

                LedgerContactNo = TxtList.Item("tcontactno", rowno).Value
                If LedgerContactNo = Nothing Then
                    LedgerContactNo = ""
                End If

                Ledgeremailid = TxtList.Item("temailid", rowno).Value
                If Ledgeremailid = Nothing Then
                    Ledgeremailid = ""
                End If

                SaveLedgerAccount(rowno)
                count = count + 1
NextRowLine:
            Next
            MsgBox(count.ToString & " Rows are Updated ..... ", MsgBoxStyle.Information)
        End If

    End Sub
    Sub SaveLedgerAccount(ByVal Rno As Integer)

        Dim SqlStr As String = ""
        SqlStr = "INSERT INTO [ledgers] ([LedgerName],[LedgerCode],[TaxRegno],[AccountGroup],[address],[location],[state],[country],[Tel],[fax],[emailid],[website]," _
            & "[accounttype],[createdby],[alterby],[verifiedby],[Isactive],[creditlimit],[discount],[Contactperson],[pdesignation],[ptel],[pphoneno]," _
            & "[pemail],[Dr],[Cr],[OpDr],[OpCr],[IsBillWise],[photopath],[currentbalance],[partyaddresscity],[StoreName],[CreditPeriod],[Currency],[LedgerNameTemp],[BankAccNo],[EnableChequePrinting],[pincode],[IsAllowCostCentre],[n1]) " _
            & "VALUES (@LedgerName,@LedgerCode,@TaxRegno,@AccountGroup,@address,@location,@state,@country,@Tel,@fax,@emailid,@website,@accounttype,@createdby,@alterby," _
            & "@verifiedby,@Isactive,@creditlimit,@discount,@Contactperson,@pdesignation,@ptel,@pphoneno,@pemail,@Dr,@Cr,@OpDr,@OpCr,@IsBillWise, " _
            & "@photopath,@currentbalance,@partyaddresscity,@StoreName,@CreditPeriod,@Currency,@LedgerNameTemp,@BankAccNo,@EnableChequePrinting,@pincode,@IsAllowCostCentre,@n1)"
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF.Parameters
            .AddWithValue("LedgerName", LedgerName)
            .AddWithValue("LedgerCode", GetAndSetIDCode(EnumIDType.Accounts))
            .AddWithValue("TaxRegno", LedgerTaxRegNo)
            .AddWithValue("AccountGroup", LedgerType)
            'BankAccNo
            .AddWithValue("BankAccNo", "")
            .AddWithValue("address", Ledgeraddress)
            .AddWithValue("location", LedgerCity)
            .AddWithValue("state", "")
            .AddWithValue("country", LedgerCountry)
            .AddWithValue("Tel", LedgerContactNo)
            .AddWithValue("fax", "")
            .AddWithValue("emailid", Ledgeremailid)
            .AddWithValue("website", "")
            .AddWithValue("accounttype", LedgerType)
            .AddWithValue("createdby", CurrentUserName)
            .AddWithValue("alterby", "")
            .AddWithValue("verifiedby", "")
            .AddWithValue("Isactive", 1)
            .AddWithValue("creditlimit", 200000)
            .AddWithValue("discount", 0)
            .AddWithValue("Contactperson", "")
            .AddWithValue("pdesignation", "")
            .AddWithValue("ptel", "")
            .AddWithValue("pphoneno", "")
            .AddWithValue("pemail", "")
            If LedgerOpBalance > 0 Then
                .AddWithValue("Dr", LedgerOpBalance)
                .AddWithValue("Cr", 0)
                .AddWithValue("OpDr", LedgerOpBalance)
                .AddWithValue("OpCr", 0)
            Else
                .AddWithValue("Dr", 0)
                .AddWithValue("Cr", LedgerOpBalance * -1)
                .AddWithValue("OpDr", 0)
                .AddWithValue("OpCr", LedgerOpBalance * -1)
            End If
            .AddWithValue("IsBillWise", 0)
            .AddWithValue("photopath", "")
            .AddWithValue("currentbalance", 0)
            .AddWithValue("partyaddresscity", Ledgeraddress & LedgerCity)
            .AddWithValue("StoreName", DefStoreName)
            .AddWithValue("CreditPeriod", 30)
           .AddWithValue("EnableChequePrinting", "False")
            .AddWithValue("pincode", Ledgerzipcode)
            .AddWithValue("Currency", CompDetails.Currency)
            .AddWithValue("LedgerNameTemp", Replace(LedgerName, " ", ""))
            .AddWithValue("IsAllowCostCentre", "False")
            .AddWithValue("n1", 0)
          
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()

        If LedgerOpBalance <> 0 Then
            SqlStr = "INSERT INTO [LedgerBook] ([LedgerName],[TransCode],[InvoiceNo],[InvoiceType],[InvoiceName],[sno],[Dr],[Cr],[TransDate]," _
                & " [TransDateValue],[LedgerGroup],[AcLedger],[IsAdvance],[IsDeleted],[UserName],[StoreName],[Narration],[ConRate]) " _
                & " VALUES(@LedgerName,@TransCode,@InvoiceNo,@InvoiceType,@InvoiceName,@sno,@Dr,@Cr,@TransDate,@TransDateValue,@LedgerGroup," _
                & " @AcLedger,@IsAdvance,@IsDeleted,@UserName,@StoreName,@Narration,@ConRate)"

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF1.Parameters
                .AddWithValue("LedgerName", LedgerName)
                .AddWithValue("TransCode", 0)
                .AddWithValue("InvoiceNo", 0)
                .AddWithValue("InvoiceType", "Opening Balance")
                .AddWithValue("InvoiceName", "Opening Balance")
                .AddWithValue("sno", 1)
                If LedgerOpBalance > 0 Then
                    .AddWithValue("Dr", LedgerOpBalance)
                    .AddWithValue("Cr", 0)
                Else
                    .AddWithValue("Dr", 0)
                    .AddWithValue("Cr", LedgerOpBalance * -1)
                End If

                .AddWithValue("TransDate", Now)
                .AddWithValue("TransDateValue", Now.Date.ToOADate)
                .AddWithValue("LedgerGroup", LedgerType)
                .AddWithValue("AcLedger", "Opening")
                .AddWithValue("IsAdvance", 0)
                .AddWithValue("IsDeleted", 0)
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("StoreName", DefStoreName)
                .AddWithValue("Narration", "Opening Balances")
                .AddWithValue("ConRate", 1)
            End With
            DBF1.ExecuteNonQuery()
            DBF1 = Nothing
            MAINCON.Close()
        End If
    End Sub
    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        Me.Close()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        ExportToExecl()
    End Sub
    Sub ExportToExecl()
        Dim sdlg As New SaveFileDialog
        Dim xlFileName As String = ""
        sdlg.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If sdlg.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        xlFileName = sdlg.FileName
        If xlFileName.Length = 0 Then Exit Sub
        Dim cnn As SqlConnection
        Dim sql As String
        Dim i, j As Integer
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        sql = " SELECT LedgerCode as [Code], LedgerName as [Ledger Name],AccountGroup as [Account Type],address as [Location],state as [State],Tel as [Contact Number],fax as [Fax Number],emailid as [Email  ID],f1 as [Balance] FROM ledgers"
        Dim dscmd As New SqlDataAdapter(sql, cnn)
        Dim ds As New DataSet
        dscmd.Fill(ds)

        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 0 To ds.Tables(0).Columns.Count - 1
                xlWorkSheet.Cells(i + 1, j + 1) = ds.Tables(0).Rows(i).Item(j)
            Next
        Next

        xlWorkSheet.SaveAs(xlFileName)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        cnn.Close()
    End Sub
End Class