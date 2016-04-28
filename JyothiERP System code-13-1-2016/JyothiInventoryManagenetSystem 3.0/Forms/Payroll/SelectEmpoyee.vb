Imports System.Windows.Forms

Public Class SelectEmpoyee
    Dim EmpCode As String
    Dim SqlStr As String
    Sub New(ByRef EmployeeCode As String)

        ' This call is required by the designer.
        InitializeComponent()
        EmpCode = EmployeeCode
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub LOADEMPDATA()
        Dim TempBS As New BindingSource
        SqlStr = "SELECT EmpID AS [Employee ID],EmpName as [Employee Name],Designation as [Designation], EmpPersonalID as [Emp Personal Id],bankcode as [Bank Code],bankacno as [Bank Acc No],basicsalary as [Salary] from EMPLOYEES where Isactive=1"
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("Employee ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Employee ID").Width = 80
            TxtList.Columns("Employee Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            TxtList.Columns("Employee Name").Width = 20
            TxtList.Columns("Designation").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Designation").Width = 120
            TxtList.Columns("Emp Personal Id").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Emp Personal Id").Width = 120
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        PressedOk()
       
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        EmpCode = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectEmpoyee_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub SelectEmpoyee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LOADEMPDATA()
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        PressedOk()
    End Sub

    Private Sub PressedOk()
        SelectedEmpCodeforWPS = TxtList.Item("Employee ID", TxtList.CurrentRow.Index).Value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub TxtList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtList.KeyDown
        If e.KeyCode = Keys.Return Then
            PressedOk()
        End If
    End Sub

End Class
