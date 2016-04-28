Imports System.Windows.Forms

Public Class EmployeeEMailSettings

   
    Private Sub EmployeeEMailSettings_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtType.SelectedIndex = 0
    End Sub
    Sub loadmsg()
        TXTMSG.Text = ""
        Dim dt As New DataTable
        dt = SQLLoadGridData("SELECT * FROM empmsgs WHERE EmpMsgType=N'" & TxtType.Text & "'")
        If dt.Rows.Count > 0 Then
            TXTMSG.Text = dt.Rows(0).Item("EmpMsgtext").ToString
            TxtSubject.Text = dt.Rows(0).Item("subject").ToString
        End If
        dt.Dispose()
    End Sub
    Sub savemsg()
        Dim dt As New DataTable
        dt = SQLLoadGridData("SELECT * FROM empmsgs WHERE EmpMsgType=N'" & TxtType.Text & "'")
        If dt.Rows.Count > 0 Then
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand("update set EmpMsgtext=@EmpMsgtext,subject=@subject where EmpMsgType=N'" & TxtType.Text & "'", MAINCON)
            With DBF.Parameters
                .AddWithValue("EmpMsgtext", TXTMSG.Text)
                .AddWithValue("subject", TxtSubject.Text)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Else
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand("INSERT INTO empmsgs (EmpMsgType,EmpMsgtext,subject) VALUES (@EmpMsgType,@EmpMsgtext,@subject )", MAINCON)
            With DBF.Parameters
                .AddWithValue("EmpMsgType", TxtType.Text)
                .AddWithValue("EmpMsgtext", TXTMSG.Text)
                .AddWithValue("subject", TxtSubject.Text)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        End If
        dt.Dispose()
    End Sub

    Private Sub TxtType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtType.SelectedIndexChanged
        loadmsg()
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If MsgBox("Do you want to Save changes ?      ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            savemsg()
        End If
    End Sub
End Class
