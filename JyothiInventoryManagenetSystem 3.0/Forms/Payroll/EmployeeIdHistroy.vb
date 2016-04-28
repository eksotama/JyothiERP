Public Class EmployeeIdHistroy
    Dim sqlstr As String = ""
    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub EmployeeIdHistroy_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LOADDATA()
    End Sub

    Sub LOADDATA()
        sqlstr = "SELECT  empids.ID,RenewDate,Username,(select empname from employees where empid=empids.empid) as [Employee Name],IDType,IDName,Expiry FROM renewHistory INNER JOIN EMPIDS ON renewHistory.RenewID=EmpIds.ID  "
        If TxtIsPeriod.Checked = True Then
            sqlstr = sqlstr & " where (DateValue between " & (CDbl(TxtStartDate.Value.Date.ToOADate)) & " and " & (CDbl(TxtEndDate.Value.Date.ToOADate)) & ") "
        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

    End Sub

    Private Sub UserButton2_Click(sender As System.Object, e As System.EventArgs) Handles UserButton2.Click
        LOADDATA()
    End Sub
End Class