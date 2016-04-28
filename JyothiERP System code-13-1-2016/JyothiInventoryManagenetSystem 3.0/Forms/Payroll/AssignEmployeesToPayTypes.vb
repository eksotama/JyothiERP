Imports System.Windows.Forms

Public Class AssignEmployeesToPayTypes
    Dim V_payslipname As String = ""
    Dim templist As New ListBox
    Sub New(ByVal paysliptypename As String)

        ' This call is required by the designer.
        InitializeComponent()
        V_payslipname = paysliptypename
        TxtPayslipType.Text = "Settings for " & paysliptypename
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AssignEmployeesToPayTypes_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AssignEmployeesToPayTypes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT DISTINCT DepName FROM EMPLOYEES ", TxtFilterByDep, "DepName", "*All")
        loaddata()
        If TxtFilterByDep.Items.Count > 0 Then
            TxtFilterByDep.SelectedIndex = 0
        End If
    End Sub
    Sub loaddata()

        TxtAssigedList.Items.Clear()
        templist.Items.Clear()
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            SQLFcmd.Connection = SqlConn1
            SQLFcmd.CommandText = "SELECT EmpName FROM EMPLOYEES where payslipmethod=N'" & V_payslipname & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtAssigedList.Items.Add(Sreader("Empname").ToString.Trim)
                templist.Items.Add(Sreader("Empname").ToString.Trim)
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Private Sub TxtFilterByDep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByDep.SelectedIndexChanged

        LoadEmployees()
    End Sub
    Sub LoadEmployees()
        If TxtFilterByDep.Text.Length = 0 Or TxtFilterByDep.Text = "*All" Then
            Dim wheresqlstr As String = ""

            TxtEmpList.Items.Clear()
            Dim SqlConn1 As New SqlClient.SqlConnection
            Try
                SqlConn1.ConnectionString = ConnectionStrinG
                SqlConn1.Open()
                SQLFcmd.Connection = SqlConn1
                If TxtOnlyUnassigned.Checked = True Then
                    SQLFcmd.CommandText = "SELECT EmpName FROM EMPLOYEES where payslipmethod='' or payslipmethod is null"
                Else

                    SQLFcmd.CommandText = "SELECT EmpName FROM EMPLOYEES"
                End If

                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
                    If TxtAssigedList.Items.Contains(Sreader("empname").ToString.Trim) = False Then
                        TxtEmpList.Items.Add(Sreader("Empname").ToString.Trim)
                    End If
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn1.Close()
                SqlConn1.Dispose()
                SQLFcmd.Connection = Nothing
            End Try
        Else
            TxtEmpList.Items.Clear()
            Dim SqlConn1 As New SqlClient.SqlConnection
            Try
                SqlConn1.ConnectionString = ConnectionStrinG
                SqlConn1.Open()
                SQLFcmd.Connection = SqlConn1
                If TxtOnlyUnassigned.Checked = True Then
                    SQLFcmd.CommandText = "SELECT EmpName FROM EMPLOYEES where (payslipmethod='' or payslipmethod is null) and DepName=N'" & TxtFilterByDep.Text & "'"
                Else
                    SQLFcmd.CommandText = "SELECT EmpName FROM EMPLOYEES  where DepName=N'" & TxtFilterByDep.Text & "'"
                End If

                SQLFcmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd.ExecuteReader
                While Sreader.Read()
                    If TxtAssigedList.Items.Contains(Sreader("empname").ToString.Trim) = False Then
                        TxtEmpList.Items.Add(Sreader("Empname").ToString.Trim)
                    End If
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn1.Close()
                SqlConn1.Dispose()
                SQLFcmd.Connection = Nothing
            End Try
        End If
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If TxtEmpList.SelectedItems.Count > 0 Then
            For i As Integer = 0 To TxtEmpList.SelectedItems.Count - 1
                TxtAssigedList.Items.Add(TxtEmpList.SelectedItems(i))
            Next
            Do While (TxtEmpList.SelectedItems.Count > 0)
                TxtEmpList.Items.Remove(TxtEmpList.SelectedItem)
            Loop
        End If
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        If TxtAssigedList.SelectedItems.Count > 0 Then
            For i As Integer = 0 To TxtAssigedList.SelectedItems.Count - 1
                TxtEmpList.Items.Add(TxtAssigedList.SelectedItems(i))
            Next
            Do While (TxtAssigedList.SelectedItems.Count > 0)
                TxtAssigedList.Items.Remove(TxtAssigedList.SelectedItem)
            Loop
        End If
       
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If MsgBox("Do you want to Save changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i As Integer = 0 To templist.Items.Count - 1
                ExecuteSQLQuery("UPDATE EMPLOYEES SET payslipmethod='' WHERE EMPNAME=N'" & templist.Items(i).ToString & "'")
            Next
            For I As Integer = 0 To TxtAssigedList.Items.Count - 1
                ExecuteSQLQuery("UPDATE EMPLOYEES SET payslipmethod=N'" & V_payslipname & "' WHERE EMPNAME=N'" & TxtAssigedList.Items(I).ToString & "'")
            Next
        End If
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub TxtOnlyUnassigned_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOnlyUnassigned.CheckedChanged
        LoadEmployees()
    End Sub
End Class
