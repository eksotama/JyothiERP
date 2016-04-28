Imports System.Windows.Forms
Imports System.Reflection

Public Class CreateNewLeave
    Dim EditLeaveName As String
    Dim EditLeaveCode As String
    Dim IsOpenforAlter As Boolean = False
    Sub New(Optional ByVal LeaveNametoEdit As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        EditLeaveName = LeaveNametoEdit
        If LeaveNametoEdit.Length > 0 Then
            IsOpenforAlter = True
            Me.Text = "Alter a Leave"
            Label1.Text = "ALTER A LEAVE"
            BtnCreate.Text = "&Alter"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub CreateNewLeave_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TxtCode.Focus()
    End Sub
    Private Sub CreateNewLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ERPInitializeObjects(Me)
        Dim colortype As Type = GetType(System.Drawing.Color)
        Dim PIList As PropertyInfo() = colortype.GetProperties(BindingFlags.Static Or BindingFlags.DeclaredOnly Or BindingFlags.Public)
        For Each c As PropertyInfo In PIList
            Me.TxtColorCode.Items.Add(c.Name)
        Next c
        TxtColorCode.Text = "White"
        If IsOpenforAlter = True Then
            TxtLeaveName.Text = EditLeaveName
            TxtLeaveType.Text = SQLGetStringFieldValue("select leavetype from leaves where leavename=N'" & EditLeaveName & "'", "leavetype")
            TxtMaxNos.Text = SQLGetNumericFieldValue("select maxno from leaves where leavename=N'" & EditLeaveName & "'", "maxno")
            TxtCode.Text = SQLGetStringFieldValue("select LeaveCode from leaves where leavename=N'" & EditLeaveName & "'", "LeaveCode")
            TxtColorCode.Text = SQLGetStringFieldValue("select colorcode from leaves where leavename=N'" & EditLeaveName & "'", "colorcode")
            EditLeaveCode = TxtCode.Text
            BtnCreate.Text = "&Alter"
            'LeaveCode
        End If
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtCode.Text.Length = 0 Then
            MsgBox("Please Enter The Leave Code, Examples CL, PL ... ", MsgBoxStyle.Information)
            TxtCode.Focus()
            Exit Sub
        End If

        If TxtCode.Text = "P" Or TxtCode.Text = "A" Or TxtCode.Text = "PA" Or TxtCode.Text = "HD" Then
            MsgBox("The Entered Leave Code  is reserved Codes, Please Try again...", MsgBoxStyle.Information)
            TxtCode.Focus()
            Exit Sub
        End If
        If TxtLeaveName.Text.Length < 3 Then
            MsgBox("Please Enter the Leave Name ...", MsgBoxStyle.Information)
            TxtLeaveName.Focus()
            Exit Sub
        End If
        If IsOpenforAlter = True Then
            If UCase(TxtLeaveName.Text) <> UCase(EditLeaveName) Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   leaves where leavename=N'" & TxtLeaveName.Text & "'") = True Then
                    MsgBox("The Entered Leave is Already Exists, Please Try again....", MsgBoxStyle.Information)
                    TxtLeaveName.Focus()
                    Exit Sub
                End If
            End If
            If UCase(EditLeaveCode) <> UCase(TxtCode.Text) Then
                'LeaveCode
                If SQLIsFieldExists("SELECT TOP 1 1 from   leaves where LeaveCode=N'" & TxtCode.Text & "'") = True Then
                    MsgBox("The Entered Leave code is Already Exists, Please Try again....", MsgBoxStyle.Information)
                    TxtLeaveName.Focus()
                    Exit Sub
                End If
            End If
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   leaves where leavename=N'" & TxtLeaveName.Text & "'") = True Then
                MsgBox("The Entered Leave Already Exists, Please Try again....", MsgBoxStyle.Information)
                TxtLeaveName.Focus()
                Exit Sub
            End If
        End If

        If TxtLeaveType.Text.Length = 0 Then
            MsgBox("Please Select the leave Type....", MsgBoxStyle.Information)
            TxtLeaveType.Focus()
            Exit Sub
        End If
        If CDbl(TxtMaxNos.Text) <= 0 Then
            MsgBox("Please Enter the Maximum Leaves for Each Employeee...", MsgBoxStyle.Information)
            TxtMaxNos.Focus()
            Exit Sub
        End If
        If IsOpenforAlter = True Then
            If MsgBox("Do You want to Alter the Leave ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE [Leaves] set leavename=N'" & TxtLeaveName.Text & "', leavetype=N'" & TxtLeaveType.Text & "',maxno=" & TxtMaxNos.Text & ", LeaveCode=N'" & TxtCode.Text & "',colorcode=N'" & TxtColorCode.Text & "'  where leavename=N'" & EditLeaveName & "'")
                If UCase(EditLeaveCode) <> UCase(TxtCode.Text) Then
                    ExecuteSQLQuery("update EmpLeaves set leavecode=N'" & TxtCode.Text & "' where leavecode=N'" & EditLeaveCode & "'")
                End If

                Me.Close()
            End If
        Else
            If MsgBox("Do You want to create new Leave ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("INSERT INTO [Leaves] ([LeaveName],[LeaveType],[Maxno],[LeaveCode],[colorcode])     VALUES (N'" & TxtLeaveName.Text & "',N'" & TxtLeaveType.Text & "'," & TxtMaxNos.Text & ",N'" & TxtCode.Text & "',N'" & TxtColorCode.Text & "')")
                TxtLeaveName.Text = ""
                TxtMaxNos.Text = "1"

            End If
        End If


    End Sub

    Private Sub TxtColorCode_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColorCode.DropDown

    End Sub

    Private Sub TxtColorCode_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColorCode.DropDownClosed
        Panel3.BackColor = Color.FromName(TxtColorCode.Text)
    End Sub

    Private Sub TxtColorCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtColorCode.SelectedIndexChanged
        Panel3.BackColor = Color.FromName(TxtColorCode.Text)

    End Sub
End Class
