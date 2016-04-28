Public Class EmpSalaryHistory
    Dim OpenedEmpName As String = ""
    Dim DOJ As New DateTimePicker
    Dim DOE As New DateTimePicker
    Dim SqlStr As String = ""
    Sub New(Optional ByVal EMployeeName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        OpenedEmpName = EMployeeName
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LoadData()

        If TxtEmpName.Text.Length = 0 Then Exit Sub
        SqlStr = "select sno as [SNo], (FromDate) as [From Date],(todate) as [To Date],salary as [Salary],DATEDIFF(day,fromdate,todate) as [Service Days],DATEDIFF(day,fromdate,todate)/365.00 as [Total Years of Services],1.00 as [Total Gratuity] from EmpSalaries where empname=N'" & TxtEmpName.Text & "' order by sno, fromdate"
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try
            TxtList.Columns("Total Gratuity").Visible = False
            TxtList.Columns("SNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            TxtList.Columns("SNo").SortMode = DataGridViewColumnSortMode.NotSortable

            TxtList.Columns("From Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            TxtList.Columns("From Date").DefaultCellStyle.Format = "d"


            TxtList.Columns("To Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            TxtList.Columns("To Date").DefaultCellStyle.Format = "d"



            TxtList.Columns("Salary").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Salary").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Service Days").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Service Days").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

            TxtList.Columns("Total Years of Services").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Total Years of Services").DefaultCellStyle.Format = "N" & ErpDecimalPlaces


            TxtList.Columns("Total Gratuity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            TxtList.Columns("Total Gratuity").DefaultCellStyle.Format = "N" & ErpDecimalPlaces

        Catch ex As Exception

        End Try

        For i As Integer = 0 To TxtList.Columns.Count - 1
            TxtList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        'Dim Total As Double = 0
        'For i As Integer = 0 To TxtList.RowCount - 1
        '    TxtList.Item("Total Gratuity", i).Value = GetGratuityValue(TxtList.Item("Total Years of Services", i).Value, "") * TxtList.Item("Salary", i).Value * TxtList.Item("Total Years of Services", i).Value
        '    Total = Total + CDbl(TxtList.Item("Total Gratuity", i).Value)

        'Next
        'TxtTotal.Text = FormatNumber(Total, 2)
        DOJ.Value = SQLGetStringFieldValue("select DateofJoining from employees where empname=N'" & TxtEmpName.Text & "'", "DateofJoining")
        DOE.Value = SQLGetStringFieldValue("select contractexpirydate from employees where empname=N'" & TxtEmpName.Text & "'", "contractexpirydate")


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EmpSalaryHistory_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub EmpSalaryHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select Empname from employees", TxtEmpName, "empname")
        TxtEmpName.Text = OpenedEmpName
        LoadData()
    End Sub

    Private Sub TxtEmpName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmpName.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If TxtEmpName.Text.Length = 0 Then
            MsgBox("Please select the Employee Name...", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim addEmpHistryFrm As New AddEmpSalaryHistory(TxtEmpName.Text)
        If DOE.Value.Date = DOJ.Value.Date Then
            MsgBox("The Joining and Expiry date are same.....")
            Exit Sub
        End If
        addEmpHistryFrm.TxtEndDate.MaxDate = DOE.Value.Date
        If TxtList.RowCount = 0 Then
            addEmpHistryFrm.TxtStartDate.MinDate = DOJ.Value.Date
            addEmpHistryFrm.TxtEndDate.MinDate = DOJ.Value.Date.AddDays(30)
        Else
            addEmpHistryFrm.TxtStartDate.MinDate = SQLGetStringFieldValue("select max(todate) as d from EmpSalaries where empname=N'" & TxtEmpName.Text & "'", "d")
            addEmpHistryFrm.TxtStartDate.Value = SQLGetStringFieldValue("select max(todate) as d from EmpSalaries where empname=N'" & TxtEmpName.Text & "'", "d")
            addEmpHistryFrm.TxtEndDate.MinDate = SQLGetStringFieldValue("select max(todate) as d from EmpSalaries where empname=N'" & TxtEmpName.Text & "'", "d")
        End If
        addEmpHistryFrm.ShowDialog()
        LoadData()
    End Sub

    Private Sub Btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndelete.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index = TxtList.RowCount - 1 Then
            If SQLGetNumericFieldValue("select max(sno) as d from empsalaries where empname=N'" & TxtEmpName.Text & "'", "d") = TxtList.Item("Sno", TxtList.CurrentRow.Index).Value Then
                If MsgBox("Do you want to delete the Entry ......", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim cursalary As Double = 0
                    cursalary = SQLGetNumericFieldValue(" select currentSalary  from empsalaries where empname=N'" & TxtEmpName.Text & "' and sno=" & TxtList.Item("Sno", TxtList.CurrentRow.Index).Value, "currentSalary")
                    ExecuteSQLQuery("DELETE from empsalaries where empname=N'" & TxtEmpName.Text & "' and sno=" & TxtList.Item("Sno", TxtList.CurrentRow.Index).Value)
                    ExecuteSQLQuery("UPDATE EMPLOYEES SET basicsalary=" & cursalary & " where empname=N'" & TxtEmpName.Text & "' ")
                    'currentSalary
                    LoadData()
                End If
            End If
        Else
            MsgBox("Error: Only the Last Row can be Delete......", MsgBoxStyle.Information)
        End If
    End Sub
End Class