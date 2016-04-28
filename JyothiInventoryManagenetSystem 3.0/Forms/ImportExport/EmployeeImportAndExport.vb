Imports Microsoft.Office.Interop

Public Class EmployeeImportAndExport
    Dim ExSqlstr As String = ""
    Sub LoadExportList()

        ExSqlstr = "SELECT EmpID AS [ID],Empname as [Employee Name],Gender as [Gender],Dateofbirth as [Date of Birth],DateofJoining as [Date of Joining],Designation as [Designation],DepName as [Department],Contracttype as [Contract Type],contractexpirydate as [Contract Expiry Date],Paddress as [Street],PEmpCity as [City],pcontactno1 as [Contact No1],pcontactno2 as [Contact No2],pemailid as [Email ID],EmpPersonalID as [Personal ID],bankcode as [Bank Code],bankacno as [Bank Ac No],basicsalary as [Basic Salary],fixedsalary as [Fixed Salary],SalaryType as [Salary Type],passportIDNo as [Passport ID],passportexpire as [Passport Expiry],passportIDissuedby as [Passport Issued By],visaIDNo as [VISA ID],visaexpire as [VISA Expiry],visaIDissuedby as [VISA Issued By]," _
            & "EmiratesDNo as [Emirate ID],Emiratesexpire as [Emirate Expiry],Emiratesissuedby as [Emirate Issued By],LabourcardDNo as [Labour ID],Labourcardexpire as [Labour Expiry],Labourcardissuedby as [Labour Issed By],MedicalDNo as [Medical ID],Medicalexpire as [Medical Expiry],Medicalissuedby as [Medical Issued By] from employees "
        If TxtDepartment.Text = "*All" Or TxtDepartment.Text.Length = 0 Then
        Else
            ExSqlstr = ExSqlstr & " where depname=N'" & TxtDepartment.Text & "'"
        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(ExSqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Basic Salary").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Basic Salary").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Fixed Salary").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            TxtList.Columns("Fixed Salary").DefaultCellStyle.Format = "N" & ErpDecimalPlaces


        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmployeeImportAndExport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmployeeImportAndExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select DepName from DepartmentGroups ", TxtDepartment, "DepName")
        TxtDepartment.Items.Add("*All")
        TxtDepartment.Text = "*All"
        LoadExportList()
        For i As Integer = 0 To TxtList.ColumnCount - 1
            TxtIList.Columns.Add(TxtList.Columns(i).HeaderText, TxtList.Columns(i).HeaderText)
        Next
        '        TxtIList.HitTest 
    End Sub

    Private Sub TxtDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartment.SelectedIndexChanged
        LoadExportList()
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

        Dim i, j As Integer
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        
        If IsWithHeadings.Checked = True Then
            For c As Integer = 0 To TxtList.ColumnCount - 1
                xlWorkSheet.Cells(1, c + 1) = TxtList.Columns(c).HeaderText
            Next

            For i = 1 To TxtList.Rows.Count
                For j = 0 To TxtList.Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = TxtList.Item(j, i - 1).Value
                Next
            Next
        Else

            For i = 0 To TxtList.Rows.Count - 1
                For j = 0 To TxtList.Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = TxtList.Item(j, i).Value
                Next
            Next
        End If


        xlWorkSheet.SaveAs(xlFileName)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)


        Try
            Process.Start(xlFileName)
        Catch ex As Exception

        End Try
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

    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        ExportToExecl()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim sdlg As New SaveFileDialog
        Dim xlFileName As String = ""
        sdlg.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If sdlg.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        xlFileName = sdlg.FileName
        If xlFileName.Length = 0 Then Exit Sub


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


        For c As Integer = 0 To TxtList.ColumnCount - 1
            xlWorkSheet.Cells(1, c + 1) = TxtList.Columns(c).HeaderText
        Next



        xlWorkSheet.SaveAs(xlFileName)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)


        Try
            Process.Start(xlFileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnImportBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportBrowse.Click
        Dim opfile As New OpenFileDialog
        '(*.bmp, *.jpg)|*.bmp;*.jpg
        opfile.Filter = "(*.xlsx, *.xls)|*.xlsx;*.xls "
        If opfile.ShowDialog() = DialogResult.OK Then
            ReadData(opfile.FileName)
        End If
        If TxtIList.Rows.Count = 0 Then
            MsgBox("There are no items to Import....", MsgBoxStyle.Information)

        End If
    End Sub
    Sub ReadData(ByVal filename As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rowno As Integer
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        TxtIList.Rows.Clear()
        Dim listrowno As Integer = 0
        range = xlWorkSheet.UsedRange
        Dim imgPath As String = ""
        TxtIList.Rows.Clear()
        Dim rn As Integer = 0
        For rowno = 2 To range.Rows.Count
            If Len(CType(range.Cells(rowno, 2), Excel.Range).Value) = 0 Then GoTo NextRow
            Try

                rn = TxtIList.Rows.Add()
                TxtIList.Item("ID", rn).Value = ""
                TxtIList.Item("Employee Name", rn).Value = CType(range.Cells(rowno, 2), Excel.Range).Value
                TxtIList.Item("Gender", rn).Value = CType(range.Cells(rowno, 3), Excel.Range).Value
                TxtIList.Item("Date of Birth", rn).Value = CType(range.Cells(rowno, 4), Excel.Range).Value
                TxtIList.Item("Date of Joining", rn).Value = CType(range.Cells(rowno, 5), Excel.Range).Value
                TxtIList.Item("Designation", rn).Value = CType(range.Cells(rowno, 6), Excel.Range).Value
                TxtIList.Item("Department", rn).Value = CType(range.Cells(rowno, 7), Excel.Range).Value
                TxtIList.Item("Contract Type", rn).Value = IIf(UCase(CType(range.Cells(rowno, 8), Excel.Range).Value) = "LIMITED" Or UCase(CType(range.Cells(rowno, 8), Excel.Range).Value) = "UNLIMITED", CType(range.Cells(rowno, 8), Excel.Range).Value, "Unlimited")
                TxtIList.Item("Contract Expiry Date", rn).Value = IIf(CType(range.Cells(rowno, 9), Excel.Range).Value = Nothing Or Len(CType(range.Cells(rowno, 9), Excel.Range).Value) = 0, Today, CType(range.Cells(rowno, 9), Excel.Range).Value)
                TxtIList.Item("Street", rn).Value = CType(range.Cells(rowno, 10), Excel.Range).Value
                TxtIList.Item("City", rn).Value = CType(range.Cells(rowno, 11), Excel.Range).Value
                TxtIList.Item("Contact No1", rn).Value = CType(range.Cells(rowno, 12), Excel.Range).Value
                TxtIList.Item("Contact No2", rn).Value = CType(range.Cells(rowno, 13), Excel.Range).Value
                TxtIList.Item("Email ID", rn).Value = CType(range.Cells(rowno, 14), Excel.Range).Value
                TxtIList.Item("Personal ID", rn).Value = CType(range.Cells(rowno, 15), Excel.Range).Value
                TxtIList.Item("Bank Code", rn).Value = CType(range.Cells(rowno, 16), Excel.Range).Value
                TxtIList.Item("Bank Ac No", rn).Value = CType(range.Cells(rowno, 17), Excel.Range).Value
                TxtIList.Item("Basic Salary", rn).Value = CType(range.Cells(rowno, 18), Excel.Range).Value
                TxtIList.Item("Fixed Salary", rn).Value = CType(range.Cells(rowno, 19), Excel.Range).Value
                TxtIList.Item("Salary Type", rn).Value = CType(range.Cells(rowno, 20), Excel.Range).Value
                TxtIList.Item("Passport ID", rn).Value = CType(range.Cells(rowno, 21), Excel.Range).Value
                TxtIList.Item("Passport Expiry", rn).Value = IIf(CType(range.Cells(rowno, 22), Excel.Range).Value = Nothing Or Len(CType(range.Cells(rowno, 22), Excel.Range).Value) = 0, Today, CType(range.Cells(rowno, 22), Excel.Range).Value)
                TxtIList.Item("Passport Issued By", rn).Value = CType(range.Cells(rowno, 23), Excel.Range).Value
                TxtIList.Item("VISA ID", rn).Value = CType(range.Cells(rowno, 24), Excel.Range).Value
                TxtIList.Item("VISA Expiry", rn).Value = IIf(CType(range.Cells(rowno, 25), Excel.Range).Value = Nothing Or Len(CType(range.Cells(rowno, 25), Excel.Range).Value) = 0, Today, CType(range.Cells(rowno, 25), Excel.Range).Value)
                TxtIList.Item("VISA Issued By", rn).Value = CType(range.Cells(rowno, 26), Excel.Range).Value
                TxtIList.Item("Emirate ID", rn).Value = CType(range.Cells(rowno, 27), Excel.Range).Value
                TxtIList.Item("Emirate Expiry", rn).Value = IIf(CType(range.Cells(rowno, 28), Excel.Range).Value = Nothing Or Len(CType(range.Cells(rowno, 28), Excel.Range).Value) = 0, Today, CType(range.Cells(rowno, 28), Excel.Range).Value)
                TxtIList.Item("Emirate Issued By", rn).Value = CType(range.Cells(rowno, 29), Excel.Range).Value
                TxtIList.Item("Labour ID", rn).Value = CType(range.Cells(rowno, 30), Excel.Range).Value
                TxtIList.Item("Labour Expiry", rn).Value = IIf(CType(range.Cells(rowno, 31), Excel.Range).Value = Nothing Or Len(CType(range.Cells(rowno, 31), Excel.Range).Value) = 0, Today, CType(range.Cells(rowno, 31), Excel.Range).Value)
                TxtIList.Item("Labour Issed By", rn).Value = CType(range.Cells(rowno, 32), Excel.Range).Value
                TxtIList.Item("Medical ID", rn).Value = CType(range.Cells(rowno, 33), Excel.Range).Value
                TxtIList.Item("Medical Expiry", rn).Value = IIf(CType(range.Cells(rowno, 34), Excel.Range).Value = Nothing Or Len(CType(range.Cells(rowno, 34), Excel.Range).Value) = 0, Today, CType(range.Cells(rowno, 34), Excel.Range).Value)
                TxtIList.Item("Medical Issued By", rn).Value = CType(range.Cells(rowno, 35), Excel.Range).Value


            Catch ex As Exception
                MsgBox(ex.Message & " Invalid Columns of Data..... ")
                If MsgBox("Do you want to continue...              ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    GoTo EndPoint
                End If

            End Try


NextRow:
        Next
EndPoint:
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

    End Sub
    Sub SaveData()
        For r As Integer = 0 To TxtIList.RowCount - 1
            ValidateRows(r)
        Next

        Dim txtempID As String = ""
        Dim EmpName As String = ""
        For i As Integer = 0 To TxtIList.Rows.Count - 1
            Dim IsCreated As Boolean = False
            If Len(TxtIList.Item("Employee Name", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                EmpName = TxtIList.Item("Employee Name", i).Value
                EmpName = EmpName.Trim
                If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & EmpName & "'") = True Then
                    GoTo NextRowLbl
                End If
            End If

            If Len(TxtIList.Item("Passport Expiry", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsDate(TxtIList.Item("Passport Expiry", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If

           
            If Len(TxtIList.Item("VISA Expiry", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsDate(TxtIList.Item("VISA Expiry", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If

            If Len(TxtIList.Item("Labour Expiry", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsDate(TxtIList.Item("Labour Expiry", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If

            If Len(TxtIList.Item("Medical Expiry", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsDate(TxtIList.Item("Medical Expiry", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If


            If Len(TxtIList.Item("Date of Birth", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsDate(TxtIList.Item("Date of Birth", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If
            If Len(TxtIList.Item("Date of Joining", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsDate(TxtIList.Item("Date of Joining", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If
            If Len(TxtIList.Item("Contract Expiry Date", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsDate(TxtIList.Item("Contract Expiry Date", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If
            If Len(TxtIList.Item("Basic Salary", i).Value) = 0 Then
                GoTo NextRowLbl
            Else
                If IsNumeric(TxtIList.Item("Basic Salary", i).Value) = False Then
                    GoTo NextRowLbl
                End If
            End If
            If Len(TxtIList.Item("Fixed Salary", i).Value) = 0 Then
                TxtIList.Item("Fixed Salary", i).Value = TxtIList.Item("Basic Salary", i).Value
            Else
                If IsNumeric(TxtIList.Item("Fixed Salary", i).Value) = False Then
                    TxtIList.Item("Fixed Salary", i).Value = TxtIList.Item("Basic Salary", i).Value
                End If
            End If

           
            Dim TxtDateValue As New DateTimePicker

            txtempID = GetAndSetIDCode(EnumIDType.EmployeeID)
            Dim SQLstr As String = ""
            SQLstr = "INSERT INTO [Employees]([EmpID],[EmpName],[Gender],[DateofBirth],[Nationality],[Education],[DateofJoining],[Designation],[DepName]," _
                & " [Contracttype],[contractexpirydate],[address],[contactno],[emailid],[Paddress],[pcontactno1],[pcontactno2],[pemailid],[photopath],[EmpPersonalID]," _
                & " [bankcode],[bankacno],[fixedsalary],[empbankacno],[empbankname],[empbankbranch],[passportIDNo],[passportIDissuedby],[passportexpire],[visaIDNo]," _
                & " [visaIDissuedby],[visaexpire],[EmiratesDNo],[Emiratesissuedby],[Emiratesexpire],[LabourcardDNo],[Labourcardissuedby],[Labourcardexpire],[MedicalDNo]," _
                & "[Medicalissuedby],[Medicalexpire],[SalaryType],[EmpCity],[PEmpCity],[bankifsccode],[bankmicrcode],[Isactive],[IsDelete],[DocAdd1],[DocAdd2],[DocAdd3],[DocAdd4],[basicsalary],[allowance],[CostCat],[rateperhour],[TeamName]) " _
                & " VALUES (@EmpID,@EmpName,@Gender,@DateofBirth,@Nationality,@Education,@DateofJoining,@Designation,@DepName,@Contracttype,@contractexpirydate," _
                & "@address,@contactno,@emailid,@Paddress,@pcontactno1,@pcontactno2,@pemailid,@photopath,@EmpPersonalID,@bankcode,@bankacno,@fixedsalary,@empbankacno," _
                & "@empbankname,@empbankbranch,@passportIDNo,@passportIDissuedby,@passportexpire,@visaIDNo,@visaIDissuedby,@visaexpire,@EmiratesDNo,@Emiratesissuedby," _
                & " @Emiratesexpire,@LabourcardDNo,@Labourcardissuedby,@Labourcardexpire,@MedicalDNo,@Medicalissuedby,@Medicalexpire,@SalaryType,@EmpCity,@PEmpCity,@bankifsccode," _
                & " @bankmicrcode,@Isactive,@IsDelete,@DocAdd1,@DocAdd2,@DocAdd3,@DocAdd4,@basicsalary,@allowance,@CostCat,@rateperhour,@TeamName)"
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("EmpID", txtempID)
                .AddWithValue("EmpName", EmpName.Trim)
                .AddWithValue("Gender", TxtIList.Item("Gender", i).Value)
                TxtDateValue.Value = CDate(TxtIList.Item("Date of Birth", i).Value)
                .AddWithValue("DateofBirth", TxtDateValue.Value.Date)
                .AddWithValue("Nationality", "")
                .AddWithValue("Education", "")
                TxtDateValue.Value = CDate(TxtIList.Item("Date of Joining", i).Value)
                .AddWithValue("DateofJoining", TxtDateValue.Value.Date)
                .AddWithValue("Designation", TxtIList.Item("Designation", i).Value)
                .AddWithValue("DepName", TxtIList.Item("Department", i).Value)
                .AddWithValue("Contracttype", TxtIList.Item("Contract Type", i).Value)
                TxtDateValue.Value = CDate(TxtIList.Item("Contract Expiry Date", i).Value)
                .AddWithValue("contractexpirydate", TxtDateValue.Value.Date)
                .AddWithValue("address", TxtIList.Item("Street", i).Value)
                .AddWithValue("contactno", TxtIList.Item("Contact No1", i).Value)
                .AddWithValue("emailid", TxtIList.Item("Email ID", i).Value)
                .AddWithValue("Paddress", TxtIList.Item("Street", i).Value)
                .AddWithValue("pcontactno1", TxtIList.Item("Contact No1", i).Value)
                .AddWithValue("pcontactno2", TxtIList.Item("Contact No2", i).Value)
                .AddWithValue("pemailid", TxtIList.Item("Email ID", i).Value)
                .AddWithValue("photopath", PhotoPathForLedgers & "\" & txtempID & ".jpg")
                .AddWithValue("EmpPersonalID", TxtIList.Item("Personal ID", i).Value)
                .AddWithValue("bankcode", TxtIList.Item("Bank Code", i).Value)
                .AddWithValue("bankacno", TxtIList.Item("Bank Ac No", i).Value)
                .AddWithValue("fixedsalary", TxtIList.Item("Fixed Salary", i).Value)
                .AddWithValue("empbankacno", TxtIList.Item("Bank Ac No", i).Value)
                .AddWithValue("empbankname", "")
                .AddWithValue("empbankbranch", "")
                .AddWithValue("passportIDNo", TxtIList.Item("Passport ID", i).Value)
                .AddWithValue("passportIDissuedby", TxtIList.Item("Passport Issued By", i).Value)
                TxtDateValue.Value = CDate(TxtIList.Item("Passport Expiry", i).Value)
                .AddWithValue("passportexpire", TxtDateValue.Value.Date)
                .AddWithValue("visaIDNo", TxtIList.Item("VISA ID", i).Value)
                .AddWithValue("visaIDissuedby", TxtIList.Item("VISA Issued By", i).Value)
                TxtDateValue.Value = CDate(TxtIList.Item("VISA Expiry", i).Value)
                .AddWithValue("visaexpire", TxtDateValue.Value.Date)
                .AddWithValue("EmiratesDNo", TxtIList.Item("Emirate ID", i).Value)
                .AddWithValue("Emiratesissuedby", TxtIList.Item("Emirate Issued By", i).Value)
                TxtDateValue.Value = CDate(TxtIList.Item("Emirate Expiry", i).Value)
                .AddWithValue("Emiratesexpire", TxtDateValue.Value.Date)
                .AddWithValue("LabourcardDNo", TxtIList.Item("Labour ID", i).Value)
                .AddWithValue("Labourcardissuedby", TxtIList.Item("Labour Issed By", i).Value)
                TxtDateValue.Value = CDate(TxtIList.Item("Labour Expiry", i).Value)
                .AddWithValue("Labourcardexpire", TxtDateValue.Value.Date)
                .AddWithValue("MedicalDNo", TxtIList.Item("Medical ID", i).Value)
                .AddWithValue("Medicalissuedby", TxtIList.Item("Medical Issued By", i).Value)
                TxtDateValue.Value = CDate(TxtIList.Item("Medical Expiry", i).Value)
                .AddWithValue("Medicalexpire", TxtDateValue.Value.Date)
                .AddWithValue("SalaryType", TxtIList.Item("Salary Type", i).Value)
                .AddWithValue("EmpCity", TxtIList.Item("City", i).Value)
                .AddWithValue("PEmpCity", TxtIList.Item("City", i).Value)
                .AddWithValue("bankifsccode", "")
                .AddWithValue("bankmicrcode", "")
                .AddWithValue("Isactive", 1)
                .AddWithValue("IsDelete", 0)
                .AddWithValue("DocAdd1", "")
                .AddWithValue("DocAdd2", "")
                .AddWithValue("DocAdd3", "")
                .AddWithValue("DocAdd4", "")
                .AddWithValue("allowance", 0)
                .AddWithValue("basicsalary", TxtIList.Item("Basic Salary", i).Value)
                .AddWithValue("CostCat", "*Primary")
                .AddWithValue("rateperhour", 0)
                .AddWithValue("TeamName", "")
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
            ExecuteSQLQuery("Update Employees set DocAttachFileName1='',DocAttachFileSize1=0,DocAttach1=NULL where empname=N'" & EmpName & "'")
            ExecuteSQLQuery("Update Employees set DocAttachFileName2='',DocAttachFileSize2=0,DocAttach2=NULL where empname=N'" & EmpName & "'")
            ExecuteSQLQuery("Update Employees set DocAttachFileName3='',DocAttachFileSize3=0,DocAttach3=NULL where empname=N'" & EmpName & "'")
            ExecuteSQLQuery("Update Employees set DocAttachFileName4='',DocAttachFileSize4=0,DocAttach4=NULL where empname=N'" & EmpName & "'")
            ExecuteSQLQuery("Update Employees set DocAttachFileName5='',DocAttachFileSize5=0,DocAttach5=NULL where empname=N'" & EmpName & "'")

            SQLstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
              & "VALUES(N'" & EmpName & "','*Primary',0,'Employee')"
            ExecuteSQLQuery(SQLstr)
            IsCreated = True
NextRowLbl:
            If IsCreated = False Then
                TxtIList.Rows(i).DefaultCellStyle.BackColor = Color.IndianRed
            Else
                TxtIList.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next




    End Sub
    Sub ValidateRows(ByVal rn As Integer)

        If TxtIList.Item("Gender", rn).Value = Nothing Then
            TxtIList.Item("Gender", rn).Value = ""
            TxtIList.Item("Gender", rn).Value = "Male"
        Else
            If UCase(TxtIList.Item("Gender", rn).Value) = "MALE" Then
                TxtIList.Item("Gender", rn).Value = "Male"
            Else
                TxtIList.Item("Gender", rn).Value = "Female"
            End If
        End If
        If TxtIList.Item("Designation", rn).Value = Nothing Then
            TxtIList.Item("Designation", rn).Value = ""
        End If

        If TxtIList.Item("Department", rn).Value = Nothing Then
            TxtIList.Item("Department", rn).Value = ""
        End If
        If TxtIList.Item("Contract Type", rn).Value = Nothing Then
            TxtIList.Item("Contract Type", rn).Value = "Unlimited"
        Else
            If TxtIList.Item("Contract Type", rn).Value <> "Limited" Then
                TxtIList.Item("Contract Type", rn).Value = "Unlimited"
            End If
        End If

        If TxtIList.Item("Street", rn).Value = Nothing Then
            TxtIList.Item("Street", rn).Value = ""
        End If
        If TxtIList.Item("City", rn).Value = Nothing Then
            TxtIList.Item("City", rn).Value = ""
        End If

        If TxtIList.Item("Contact No1", rn).Value = Nothing Then
            TxtIList.Item("Contact No1", rn).Value = ""
        End If
        If TxtIList.Item("Contact No2", rn).Value = Nothing Then
            TxtIList.Item("Contact No2", rn).Value = ""
        End If
        If TxtIList.Item("Email ID", rn).Value = Nothing Then
            TxtIList.Item("Email ID", rn).Value = ""
        End If
        If TxtIList.Item("Personal ID", rn).Value = Nothing Then
            TxtIList.Item("Personal ID", rn).Value = ""
        End If
        If TxtIList.Item("Bank Code", rn).Value = Nothing Then
            TxtIList.Item("Bank Code", rn).Value = ""
        End If
        If TxtIList.Item("Bank Ac No", rn).Value = Nothing Then
            TxtIList.Item("Bank Ac No", rn).Value = ""
        End If
        If TxtIList.Item("Salary Type", rn).Value = Nothing Then
            TxtIList.Item("Salary Type", rn).Value = "Basic"
        Else
            If UCase(TxtIList.Item("Salary Type", rn).Value) = "BASIC" Then
                TxtIList.Item("Salary Type", rn).Value = "Basic"
            Else
                TxtIList.Item("Salary Type", rn).Value = "Fixed"
            End If
        End If
        If TxtIList.Item("Passport ID", rn).Value = Nothing Then
            TxtIList.Item("Passport ID", rn).Value = ""
        End If

        If TxtIList.Item("Passport Issued By", rn).Value = Nothing Then
            TxtIList.Item("Passport Issued By", rn).Value = ""
        End If
        If TxtIList.Item("VISA ID", rn).Value = Nothing Then
            TxtIList.Item("VISA ID", rn).Value = ""
        End If
        If TxtIList.Item("VISA Issued By", rn).Value = Nothing Then
            TxtIList.Item("VISA Issued By", rn).Value = ""
        End If

        If TxtIList.Item("Emirate ID", rn).Value = Nothing Then
            TxtIList.Item("Emirate ID", rn).Value = ""
        End If

        If TxtIList.Item("Emirate Issued By", rn).Value = Nothing Then
            TxtIList.Item("Emirate Issued By", rn).Value = ""
        End If
        If TxtIList.Item("Labour ID", rn).Value = Nothing Then
            TxtIList.Item("Labour ID", rn).Value = ""
        End If
        If TxtIList.Item("Labour Issed By", rn).Value = Nothing Then
            TxtIList.Item("Labour Issed By", rn).Value = ""
        End If
        If TxtIList.Item("Medical ID", rn).Value = Nothing Then
            TxtIList.Item("Medical ID", rn).Value = ""
        End If

        If TxtIList.Item("Medical Issued By", rn).Value = Nothing Then
            TxtIList.Item("Medical Issued By", rn).Value = ""
        End If


    End Sub

    Private Sub BtnImportUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportUpdate.Click
        If MsgBox("Do you want to update ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveData()
        End If
    End Sub
End Class