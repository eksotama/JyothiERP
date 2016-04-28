Imports System.Windows.Forms

Public Class AddEmpSalaryHistory
    Dim EmpName As String
    Sub New(ByVal EmployeeName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EmpName = EmployeeName
    End Sub
  
    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub AddEmpSalaryHistory_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AddEmpSalaryHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtEmpName.Text = EmpName
        TxtcurrentSalary.Text = SQLGetNumericFieldValue("select basicsalary from employees where empname=N'" & EmpName & "'", "basicsalary")
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If CDbl(TxtSalary.Text) - CDbl(TxtcurrentSalary.Text) < 0 Then
            MsgBox("Wrong Salary Increments.....          ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to Save ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SqlStr As String = ""
            SqlStr = "INSERT INTO [EmpSalaries] ([EmpName],[Salary],[FromDate],[Todate],[Days],[years],[Gratuity],[Ispaid],[paidamount],[paiddate],[paiddetails],[increment],[sno],[currentSalary])     VALUES " _
                & " (@EmpName,@Salary,@FromDate,@Todate,@Days,@years,@Gratuity,@Ispaid,@paidamount,@paiddate,@paiddetails,@increment,@sno,@currentSalary)"

            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("EmpName", TxtEmpName.Text)
                .AddWithValue("Salary", TxtSalary.Text)
                .AddWithValue("FromDate", TxtStartDate.Value.Date)
                .AddWithValue("Todate", TxtEndDate.Value.Date)
                .AddWithValue("Days", 0)
                .AddWithValue("years", 0)
                .AddWithValue("Ispaid", 0)
                .AddWithValue("Gratuity", 0)
                .AddWithValue("paidamount", 0)
                .AddWithValue("paiddate", Today.Date)
                .AddWithValue("paiddetails", " ")
                .AddWithValue("increment", CDbl(TxtIncremet.Text))
                .AddWithValue("currentSalary", CDbl(TxtcurrentSalary.Text))
                Dim sno As Integer = 1
                sno = SQLGetNumericFieldValue("select max(sno) as d from empsalaries where empname=N'" & TxtEmpName.Text & "'", "d")
                .AddWithValue("sno", sno)

            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
            ExecuteSQLQuery("UPDATE EMPLOYEES SET basicsalary=" & CDbl(TxtcurrentSalary.Text) & " where empname=N'" & TxtEmpName.Text & "' ")
            Me.Close()
        End If
    End Sub

    Private Sub TxtIncremet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIncremet.TextChanged
        On Error Resume Next
        TxtSalary.Text = CDbl(TxtcurrentSalary.Text) + CDbl(TxtIncremet.Text)
    End Sub

    Private Sub TxtSalary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSalary.TextChanged
        On Error Resume Next
        TxtIncremet.Text = CDbl(TxtSalary.Text) - CDbl(TxtcurrentSalary.Text)
    End Sub
End Class
