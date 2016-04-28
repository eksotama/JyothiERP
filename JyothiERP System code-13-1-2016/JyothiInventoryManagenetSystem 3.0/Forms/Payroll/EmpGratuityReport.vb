Public Class EmpGratuityReport
    Dim SqlStr As String = ""

    Private Sub EmpGratuityReport_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub EmpGratuityReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        TxtMethod.Items.Clear()
        LoadDataIntoComboBox("select distinct method from EmpGratuityMethods", TxtMethod, "method")
        If TxtMethod.Items.Count > 0 Then
            TxtMethod.SelectedIndex = 0
        Else
            MsgBox("There are no Gratuity Setting, Please Set Gratuity Setting and then try again..... ")

        End If
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()
        If TxtMethod.Text.Length = 0 Then
            MsgBox("There are no Gratuity Setting, Please Set Gratuity Setting and then try again..... ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
            SqlStr = "Select empname as [Employee Name], DateofJoining as [Date of Joining], 0.000 as [Basic Salary], 0.000 as [Service Days], 0.000 as [Total Years of Services], 0.000 as [Total Gratuity], 0.000 as [Net Gratuity] from employees "
        Else
            SqlStr = "Select empname as [Employee Name], DateofJoining as [Date of Joining],0.000 as [Basic Salary], 0.000 as [Service Days], 0.000 as [Total Years of Services], 0.000 as [Total Gratuity], 0.000 as [Net Gratuity] from employees where depname=N'" & TxtDepartmentName.Text & "'"
        End If
        Dim TempBS As New BindingSource
        Me.Cursor = Cursors.WaitCursor
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Employee Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Employee Name").Width = 80
            TxtList.Columns("Employee Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            TxtList.Columns("Date of Joining").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Date of Joining").Width = 150
            TxtList.Columns("Date of Joining").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            TxtList.Columns("Date of Joining").DefaultCellStyle.Format = "d"

            '0 as [Basic Salary],


            TxtList.Columns("Basic Salary").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Basic Salary").Width = 120
            TxtList.Columns("Basic Salary").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Basic Salary").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Service Days").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Service Days").Width = 120
            TxtList.Columns("Service Days").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Service Days").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Total Years of Services").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Total Years of Services").Width = 120
            TxtList.Columns("Total Years of Services").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    TxtList.Columns("Total Years of Services").DefaultCellStyle.Format = "N" & ErpDecimalPlaces


            TxtList.Columns("Total Gratuity").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Total Gratuity").Width = 120
            TxtList.Columns("Total Gratuity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Total Gratuity").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Total Gratuity").DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

            TxtList.Columns("Net Gratuity").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Net Gratuity").Width = 120
            TxtList.Columns("Net Gratuity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Net Gratuity").DefaultCellStyle.Format = "N" & ErpDecimalPlaces
            TxtList.Columns("Net Gratuity").DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

            TxtList.Columns("Total Gratuity").DefaultCellStyle.BackColor = Color.Wheat
            TxtList.Columns("Net Gratuity").DefaultCellStyle.BackColor = Color.MistyRose
        Catch ex As Exception

        End Try
        Dim GrandTotal As Double = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            GetEmploeeTotalsOnBasic(TxtList.Item("Employee Name", i).Value, i)
            GrandTotal = GrandTotal + TxtList.Item("Net Gratuity", i).Value
        Next
        TxtTotal.Text = FormatNumber(GrandTotal, ErpDecimalPlaces)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Sub GetEmploeeTotalsOnBasic(ByVal empname As String, ByVal rno As Integer)
        If empname.Length = 0 Then Exit Sub
        Dim netyears As Double = 0
        Dim NetTotal As Double = 0
        Dim NetSerDays As Double = 0
        Dim BasicSalary As Double = 0
        SqlStr = "select sum(DATEDIFF(day,fromdate,todate)) as [tot]  from EmpSalaries where empname=N'" & empname & "'"
        NetSerDays = SQLGetNumericFieldValue(SqlStr, "Tot")
        netyears = FormatNumber(NetSerDays / 365.0, ErpDecimalPlaces, , , TriState.False)
        BasicSalary = SQLGetNumericFieldValue("select basicsalary  from employees where empname=N'" & empname & "'", "basicsalary")
        If netyears < 1 Then
            NetTotal = 0
        ElseIf netyears <= 5 Then
            NetTotal = GetGratuityValue(netyears, TxtMethod.Text) * BasicSalary * netyears
        Else
            NetTotal = GetGratuityValue(5, TxtMethod.Text) * BasicSalary * netyears
            If netyears - 5 > 0 Then
                NetTotal = NetTotal + GetGratuityValue(netyears - 5, TxtMethod.Text) * BasicSalary * netyears
            End If

        End If
       
        
        TxtList.Item("Basic Salary", rno).Value = BasicSalary
        TxtList.Item("Service Days", rno).Value = NetSerDays
        TxtList.Item("Total Years of Services", rno).Value = netyears
        TxtList.Item("Total Gratuity", rno).Value = NetTotal.ToString
        If NetTotal > BasicSalary * 24 Then
            TxtList.Item("Net Gratuity", rno).Value = BasicSalary * 24
        Else
            TxtList.Item("Net Gratuity", rno).Value = NetTotal
        End If



    End Sub
  

    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub BtnGtySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGtySettings.Click
        Dim kfrm As New EmpGratuityCalculationMethods
        kfrm.ShowDialog()
        LoadDataIntoComboBox("select distinct method from EmpGratuityMethods", TxtMethod, "method")
    End Sub

    Private Sub TxtMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMethod.SelectedIndexChanged
        LoadData()
    End Sub
End Class