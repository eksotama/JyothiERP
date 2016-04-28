Public Class EmployeeAdditionalIDmonitor
    Dim Sqlstr As String = ""
    Sub loaddATA(Optional ByVal whereStr As String = "")
       
        Dim Sqlstr As String = ""
        If TxtEmployeeName.Text.Length = 0 Or TxtEmployeeName.Text = "*All" Then
            Sqlstr = "SELECT [ID] , (select empname from employees where empid=empids.empid) AS [EMPLOYEE NAME] ,[IDName],[IDType],[Description],[Expiry],[Photo1],[Photo2],[Photo3]  FROM [dbo].[EmpIds]   "
        Else
            Sqlstr = "SELECT [ID] , '" & TxtEmployeeName.Text & "' AS [EMPLOYEE NAME] ,[IDName],[IDType],[Description],[Expiry],[Photo1],[Photo2],[Photo3]  FROM [dbo].[EmpIds]   WHERE EMPID=(SELECT EMPID FROM EMPLOYEES WHERE EMPNAME=N'" & TxtEmployeeName.Text & "')"
        End If

        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            CType(TxtList.Columns("Photo1"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
            CType(TxtList.Columns("Photo2"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
            CType(TxtList.Columns("Photo3"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub EmployeeAdditionalIDmonitor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("SELECT  empname FROM employees", TxtEmployeeName, "empname", "*All")
        If TxtEmployeeName.Items.Count > 0 Then
            TxtEmployeeName.SelectedIndex = 0
        End If
        loaddATA()
    End Sub

    Private Sub TxtIDType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtIDType.SelectedIndexChanged
        loaddATABYID()
    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtEmployeeName.SelectedIndexChanged
        loaddATA()
    End Sub
    Sub loaddATABYID(Optional ByVal whereStr As String = "")
        If TxtIDType.Text.Length = 0 Then Exit Sub
        Dim Sqlstr As String = "SELECT [ID] , select Empname from employees where empid=empids.empid as [Employee Name] ,[IDName],[IDType],[Description],[Expiry],[Photo1],[Photo2],[Photo3]  FROM [dbo].[EmpIds]   WHERE IDType=N'" & TxtIDType.Text & "'"
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

    End Sub

    Private Sub BtnRenew_Click(sender As System.Object, e As System.EventArgs) Handles BtnRenew.Click
        If TxtList.Rows.Count = 0 Then Exit Sub
        Dim frm As New RenewAddEMPids(TxtList.Item("ID", TxtList.CurrentRow.Index).Value)
        frm.ShowDialog()
        loaddATA()

    End Sub

    Private Sub btnHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeIdHistroy.SuspendLayout()
        EmployeeIdHistroy.MdiParent = MainForm
        EmployeeIdHistroy.Dock = DockStyle.Fill
        EmployeeIdHistroy.Show()
        EmployeeIdHistroy.WindowState = FormWindowState.Maximized
        EmployeeIdHistroy.BringToFront()
        EmployeeIdHistroy.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub
End Class