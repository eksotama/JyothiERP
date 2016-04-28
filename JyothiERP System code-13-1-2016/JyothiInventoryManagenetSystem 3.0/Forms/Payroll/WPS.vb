Imports Microsoft.Office.Interop

Public Class WPS

    Dim EmployeeCode As String
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ERPInitializeObjects(Me)
        On Error Resume Next
        dtxt.Text = Format(Now, "yyyy-MM-dd")
        ttxt.Text = Format(Now, "HHMM")
        mtxt.Text = Format(Now, "MMyyyy")
        AED.Text = "AED"
        Bcode.Items.Add("302620122-NBD")
        Bcode.Items.Add("703420114-IB")
        edrcount.Text = ""
        euid.LoadFile(Application.StartupPath & "\euid.txt", RichTextBoxStreamType.PlainText)
        UID.Text = euid.Text
        UID.Focus()
        TxtEmpPersonalID.Focus()
        dtp1.Value = New Date(Today.Date.Year, Today.Date.Month, 1)
        dtp2.Value = New Date(Today.Date.Year, Today.Date.Month, Date.DaysInMonth(Today.Date.Year, Today.Date.Month))
        TxtNoDays.Text = Format(dtp2.Value, "dd")
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i As Integer
        If Me.TxtList.Rows.Count <> 0 Then
            i = (Me.TxtList.Rows.Count - 1) + 1
        End If
        Dim K As Integer
        Dim S As String = ""
        'T5.Text = i
        If Not (Len(Format("0000000#######", TxtEmpPersonalID.Text)) = 14) Then
            For K = 1 To 14 - Len(TxtEmpPersonalID.Text)
                S = S & "0"
            Next
            TxtEmpPersonalID.Text = S + TxtEmpPersonalID.Text
        End If
        Me.TxtList.Rows.Add("EDR", Format("0000000#######.000", TxtEmpPersonalID.Text.ToString).ToString, TxtBankCode.Text.Trim, TxtEmployeeAcNo.Text.Trim, dtp1.Text, dtp2.Text, TxtNoDays.Text, TxtSalary.Text, TextBox6.Text, t7.Text)
        tot()
        Call clean()
    End Sub
    Sub SAV()
        Dim fn As String
        fn = Application.StartupPath & "\csvfile"

        Try
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\csvfile")
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\siffile")
        Catch ex As Exception

        End Try

        'sAVE fILE
        Dim fname As String = "summa"
        'sd1.InitialDirectory = fn
        'sd1.Filter = "CSV files (*.csv)|*.CSV"
        'sd1.FilterIndex = 2
        'sd1.RestoreDirectory = True

        'If (sd1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
        'fname = sd1.FileName
        'Me.Text = fname
        rt1.SaveFile(Application.StartupPath & "\csvfile\" & fname & ".csv", RichTextBoxStreamType.PlainText)
        Me.Text = Application.StartupPath & "\csvfile\" & fname & ".csv"
        MessageBox.Show("SIF file Created Successfully", "Easy SIF Creator 2.0")
        'End If
        'Me.Text = fname
    End Sub
    Sub clean()
        TxtEmpPersonalID.Text = ""
        TxtBankCode.Text = ""
        TxtEmployeeAcNo.Text = ""
        TxtNoDays.Text = "0"
        TxtSalary.Text = "0"
        TextBox6.Text = "0"
        t7.Text = "0"
        TxtEmpPersonalID.Focus()
    End Sub
    Sub tot()
        Dim n1, m1 As Integer
        n1 = Me.TxtList.Rows.Count
        totsal.Text = ""

        For m1 = 0 To n1 - 1
            totsal.Text = Val(totsal.Text) + Val(TxtList.Rows(m1).Cells(7).FormattedValue)
        Next
        edrcount.Text = TxtList.Rows.Count
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        On Error GoTo sha
        Dim n, m As Integer
        If edrcount.Text.Trim = "" Then
            MsgBox("Enter Your Correct Data", MsgBoxStyle.Information, "Easy SIF Creator 2.0")
            Exit Sub
        End If
        If UID.Text.Trim = "" Then
            MsgBox("Enter Employee Unique ID", MsgBoxStyle.Information, "Easy SIF Creator 2.0")
            UID.Focus()
            Exit Sub
        End If
        If Bcod.Text.Trim = "" Then
            MsgBox("Enter Bank Code Of Employer", MsgBoxStyle.Information, "Easy SIF Creator 2.0")
            Bcode.Focus()
            Exit Sub
        End If
        n = Me.TxtList.Rows.Count
        rt1.Text = ""
        For m = 0 To n - 1
            If Trim(rt1.Text) = "" Then
                rt1.Text = TxtList.Rows(m).Cells(0).FormattedValue + "," + TxtList.Rows(m).Cells(1).FormattedValue + "," + TxtList.Rows(m).Cells(2).FormattedValue + "," + TxtList.Rows(m).Cells(3).FormattedValue + "," + TxtList.Rows(m).Cells(4).FormattedValue + "," + TxtList.Rows(m).Cells(5).FormattedValue + "," + TxtList.Rows(m).Cells(6).FormattedValue + "," + TxtList.Rows(m).Cells(7).FormattedValue + "," + TxtList.Rows(m).Cells(8).FormattedValue + "," + TxtList.Rows(m).Cells(9).FormattedValue
            Else
                rt1.Text = rt1.Text + vbCrLf + TxtList.Rows(m).Cells(0).FormattedValue + "," + TxtList.Rows(m).Cells(1).FormattedValue + "," + TxtList.Rows(m).Cells(2).FormattedValue + "," + TxtList.Rows(m).Cells(3).FormattedValue + "," + TxtList.Rows(m).Cells(4).FormattedValue + "," + TxtList.Rows(m).Cells(5).FormattedValue + "," + TxtList.Rows(m).Cells(6).FormattedValue + "," + TxtList.Rows(m).Cells(7).FormattedValue + "," + TxtList.Rows(m).Cells(8).FormattedValue + "," + TxtList.Rows(m).Cells(9).FormattedValue
            End If
        Next
        'new
        rt1.Text = rt1.Text + vbCrLf + "SCR," + UID.Text + "," + Bcod.Text + "," + dtxt.Text + "," + ttxt.Text + "," + mtxt.Text + "," + edrcount.Text + "," + totsal.Text + "," + "AED," + Trim(txtcname.Text)
        GoTo xxx
sha:
        MsgBox("Enter Correctly", MsgBoxStyle.Critical, "Easy SIF Creator 2.0")
xxx:
        Call SAV()

        System.IO.File.Copy(Me.Text, Application.StartupPath & " \siffile" & "\SUMMA.CSV", True)
        Rename(Application.StartupPath & " \siffile" & "\SUMMA.CSV", Application.StartupPath & " \siffile\" & UID.Text & Format(Now, "yyMMdd") & Format(Now, "HHMMss") & ".SIF")
        'System.IO.File.Copy(Me.Text, "C:\TEMP\SUMMA.CSV", True)
        'Rename("C:\TEMP\SUMMA.CSV", "C:\TEMP\" & UID.Text & Format(Now, "yyMMdd") & Format(Now, "HHMMss") & ".SIF")

        Dim op As String
        op = "explorer " & Application.StartupPath & " \siffile"
        Shell(op, AppWinStyle.MaximizedFocus)
    End Sub

    Private Sub TextBox5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSalary.GotFocus
        TxtNoDays.Text = Format(dtp2.Value, "dd")
    End Sub


    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSalary.LostFocus
        If TxtSalary.Text.Trim = "" Then
            TxtSalary.Text = "0.000"
        ElseIf Not TxtSalary.Text.Trim = "0.000" Then


            If Len(TxtSalary.Text.Trim) >= 4 Then
                If Not Mid(Trim(TxtSalary.Text), Val(Len(TxtSalary.Text)) - 2, 1) = "." Then
                    TxtSalary.Text = Trim(TxtSalary.Text) & ".000"
                End If
            Else
                TxtSalary.Text = Trim(TxtSalary.Text) & ".000"
            End If


        End If

    End Sub


    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        If TextBox6.Text.Trim = "" Then
            TextBox6.Text = "0.000"
        ElseIf Not TextBox6.Text.Trim = "0.000" Then

            If Len(TextBox6.Text.Trim) >= 4 Then
                If Not Mid(Trim(TextBox6.Text), Val(Len(TextBox6.Text)) - 2, 1) = "." Then
                    TextBox6.Text = Trim(TextBox6.Text) & ".000"
                End If
            Else
                TextBox6.Text = Trim(TextBox6.Text) & ".000"
            End If
        End If
        t7.Focus()
    End Sub


    Private Sub dtp2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp2.LostFocus
        TxtNoDays.Text = Format(dtp2.Value, "dd")
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        datelbl.Text = Now

    End Sub



    Private Sub t7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles t7.LostFocus
        If t7.Text.Trim = "" Then
            t7.Text = 0
        End If
    End Sub


    Private Sub Bcode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bcode.Click

    End Sub


    Private Sub Bcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcode.SelectedIndexChanged
        Select Case Bcode.SelectedIndex
            Case 0
                Bcod.Text = "302620122"
            Case 1
                Bcod.Text = "703420114"
        End Select
    End Sub

    Private Sub edrcount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edrcount.TextChanged

    End Sub

    Private Sub UID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UID.LostFocus
        Dim K As Integer
        Dim S As String = ""
        If (Len(UID.Text.Trim) < 14) Then
            For K = 1 To 14 - Len(UID.Text)
                S = S & "0"
            Next
            UID.Text = S + UID.Text
        End If

        If Len(UID.Text.Trim) > 14 Then
            MsgBox("uid greater than 14 digit", MsgBoxStyle.Critical, "Easy SIF Creator 2.0")
            UID.Focus()
        End If

    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub t1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEmpPersonalID.KeyPress
        SelectedEmpCodeforWPS = ""
        Dim k As New SelectEmpoyee(EmployeeCode)
        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtEmpPersonalID.Text = SelectedEmpCodeforWPS
        End If
        'SqlStr = "SELECT EmpID AS [Employee ID],EmpName as [Employee Name],Designation as [Designation], EmpPersonalID as [Emp Personal Id],bankcode as [Bank Code],bankacno as [Bank Acc No],fixedsalary as [Salary] from EMPLOYEES where Isactive=1"
        TxtBankCode.Text = SQLGetStringFieldValue("select bankcode from EMPLOYEES where EmpID=N'" & TxtEmpPersonalID.Text & "'", "bankcode")
        TxtEmployeeAcNo.Text = SQLGetStringFieldValue("select bankacno from EMPLOYEES where EmpID=N'" & TxtEmpPersonalID.Text & "'", "bankacno")
        TxtSalary.Text = FormatNumber(SQLGetNumericFieldValue("select fixedsalary from EMPLOYEES where EmpID=N'" & TxtEmpPersonalID.Text & "'", "fixedsalary"), ErpDecimalPlaces, , , TriState.False)
        TxtEmpPersonalID.Text = SQLGetStringFieldValue("select EmpPersonalID from employees where empid=N'" & TxtEmpPersonalID.Text & "'", "EmpPersonalID")

    End Sub


    'Private Sub t2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles t2.Validating
    '    If Len(t2.Text.Trim) > 9 Then
    '        MsgBox("Please Enter 9 Digit Agent Code", MsgBoxStyle.Exclamation, "Easy SIF Creator 2.0")
    '        t2.Focus()
    '        System.Windows.Forms.SendKeys.Send("{Home}+{End}")
    '        e.Cancel = True
    '    End If
    'End Sub

    'Private Sub t3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles t3.Validating
    '    If Not (Len(t3.Text.Trim) = 14 Or Len(t3.Text.Trim) = 24) Then
    '        MsgBox("Enter 14 Digit A/c No or 24 Digit IBAN No", MsgBoxStyle.Exclamation, "Easy SIF Creator 2.0")
    '        t3.Focus()
    '        System.Windows.Forms.SendKeys.Send("{Home}+{End}")
    '        e.Cancel = True
    '    End If
    'End Sub

    Private Sub t1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtEmpPersonalID.Validating
        If Len(TxtEmpPersonalID.Text.Trim) > 14 Then
            MsgBox("Invalid Entry", MsgBoxStyle.Exclamation, "Easy SIF Creator 2.0")
            TxtEmpPersonalID.Focus()
            System.Windows.Forms.SendKeys.Send("{Home}+{End}")
            e.Cancel = True
        End If
    End Sub


    Private Sub BtnImportBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportBrowse.Click
        MsgBox("The Employee data shuld be in the order of the list and  valid values...", MsgBoxStyle.Information)
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
        My.Application.DoEvents()
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filename)
        xlWorkSheet = xlWorkBook.Worksheets("sheet1")

        Dim listrowno As Integer = 0
        range = xlWorkSheet.UsedRange
        Dim imgPath As String = ""
        If TxtList.RowCount > 0 Then
            If MsgBox("The List already had employee Detailes, Do you want to Append the List?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                TxtList.Rows.Clear()
            End If
        End If
        Dim rn As Integer = 0
        For rowno = 1 To range.Rows.Count
            'EDR
            ' VALIDATE FOR EMPTY 
            If Len(CType(range.Cells(rowno, 1), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 2), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 3), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 4), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 5), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 6), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 7), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 8), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 9), Excel.Range).Value) = 0 Then GoTo NextRow
            If Len(CType(range.Cells(rowno, 10), Excel.Range).Value) = 0 Then GoTo NextRow

            'VALIDATE FOR DATES

            If IsDate(CType(range.Cells(rowno, 5), Excel.Range).Value) = False Then GoTo NextRow
            If IsDate(CType(range.Cells(rowno, 6), Excel.Range).Value) = False Then GoTo NextRow
            'VALIDATE FOR NUMBERS
            If IsNumeric(CType(range.Cells(rowno, 7), Excel.Range).Value) = False Then GoTo NextRow
            If IsNumeric(CType(range.Cells(rowno, 8), Excel.Range).Value) = False Then GoTo NextRow
            If IsNumeric(CType(range.Cells(rowno, 9), Excel.Range).Value) = False Then GoTo NextRow
            If IsNumeric(CType(range.Cells(rowno, 10), Excel.Range).Value) = False Then GoTo NextRow

            Try
                rn = TxtList.Rows.Add
                TxtList.Item("A", rn).Value = CType(range.Cells(rowno, 1), Excel.Range).Value
                TxtEmpPersonalID.Text = CType(range.Cells(rowno, 2), Excel.Range).Value.ToString
                Dim K As Integer
                Dim S As String = ""
                If Not (Len(Format("0000000#######", TxtEmpPersonalID.Text)) = 14) Then
                    For K = 1 To 14 - Len(TxtEmpPersonalID.Text)
                        S = S & "0"
                    Next
                    TxtEmpPersonalID.Text = S + TxtEmpPersonalID.Text
                End If

                TxtList.Item("B", rn).Value = Format("0000000#######.000", TxtEmpPersonalID.Text)
                TxtList.Item("C", rn).Value = CType(range.Cells(rowno, 3), Excel.Range).Value
                TxtList.Item("D", rn).Value = CType(range.Cells(rowno, 4), Excel.Range).Value
                dtp1.Value = CType(range.Cells(rowno, 5), Excel.Range).Value
                dtp2.Value = CType(range.Cells(rowno, 6), Excel.Range).Value

                TxtList.Item("E", rn).Value = dtp1.Text
                TxtList.Item("F", rn).Value = dtp2.Text

                TxtList.Item("G", rn).Value = CType(range.Cells(rowno, 7), Excel.Range).Value
                TxtList.Item("H", rn).Value = FormatNumber(CType(range.Cells(rowno, 8), Excel.Range).Value, ErpDecimalPlaces, , , TriState.False)
                TxtList.Item("I", rn).Value = FormatNumber(CType(range.Cells(rowno, 9), Excel.Range).Value, ErpDecimalPlaces, , , TriState.False)
                TxtList.Item("J", rn).Value = CType(range.Cells(rowno, 10), Excel.Range).Value
                TxtEmpPersonalID.Text = ""

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
        tot()
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

    
   
    Private Sub TxtSalary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalary.TextChanged

    End Sub
End Class