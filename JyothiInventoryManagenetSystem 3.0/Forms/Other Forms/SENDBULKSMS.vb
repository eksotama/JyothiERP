Imports System.Windows.Forms

Public Class SENDBULKSMS

  

    Private Sub SENDBULKSMS_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "' ", TxtAccountGroup, "subgroup", "*All")
    End Sub

    Private Sub ImsButton2_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton2.Click
        Me.Close()
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        If TxtAccountGroup.Text.Length = 0 Then
            MsgBox("Please select the group name       ", MsgBoxStyle.Information)
            TxtAccountGroup.Focus()
            Exit Sub
        End If
        If txtmsg.Text.Length = 0 Then
            MsgBox("Please enter the body of message            ", MsgBoxStyle.Information)
            txtmsg.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Send the SMS for selected group ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'IsSendSMS='True'
            My.Application.DoEvents()
            Dim sqlstr As String = "select tel,pphoneno from ledgers where  IsSendSMS='True' and AccountGroup=N'" & TxtAccountGroup.Text & "'"

            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand

            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = sqlstr
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                While Sreader.Read()
                    Dim mbno As String = Sreader("tel").ToString.Trim
                    If mbno.Length > 0 Then
                        If SendSMSToMobile(mbno, txtmsg.Text) = False Then
                            If MsgBox("The sending is failed, do you want to contine..?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                Exit While
                            End If
                        End If
                    Else
                        mbno = Sreader("pphoneno").ToString.Trim
                        If mbno.Length > 0 Then
                            If SendSMSToMobile(mbno, txtmsg.Text) = False Then
                                If MsgBox("The sending is failed, do you want to contine..?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    Exit While
                                End If
                            End If
                        End If
                    End If
                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn.Close()
                SqlConn.Dispose()
                Sqlcmmd.Connection = Nothing
            End Try

        End If
    End Sub

End Class
