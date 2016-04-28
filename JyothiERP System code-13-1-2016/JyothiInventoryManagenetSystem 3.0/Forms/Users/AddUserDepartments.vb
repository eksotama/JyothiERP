Imports System.Windows.Forms

Public Class AddUserDepartments
    Dim EditUserID As String = ""
    Sub New(ByVal UserId As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EditUserID = UserId
    End Sub
    

    Private Sub AddUserDepartments_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtDepartment.Focus()
    End Sub

    Private Sub AddUserDepartments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtDepartment.Items.Clear()
        TxtDepartment.Items.Add("Sales")
        TxtDepartment.Items.Add("Purchase")
        TxtDepartment.Items.Add("Inventory")
        TxtDepartment.Items.Add("Accounts & Finance")
        TxtDepartment.Items.Add("Accounts Only")
        TxtDepartment.Items.Add("Admin & Payroll")
        TxtDepartment.Items.Add("Admin")
        TxtDepartment.Items.Add("Payroll")
        TxtDepartment.Items.Add("Master")
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtDepartment.Text.Length = 0 Then
            MsgBox("Please Select the Department....", MsgBoxStyle.Information)
            TxtDepartment.Focus()
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   UserDepartments where userid=N'" & EditUserID & "' and depname=N'" & TxtDepartment.Text & "'") = True Then
            MsgBox("The Department selected is already exists...")
            Exit Sub
        End If
        If MsgBox("Do You want to Add?     ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("INSERT INTO [UserDepartments] ([UserID],[DepName],[Isdelete])  VALUES(N'" & EditUserID & "',N'" & TxtDepartment.Text & "',0)")
        End If
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
