Imports System.Windows.Forms

Public Class SendSingleSMS
    Dim currentledgername As String = ""
    Sub New(ledgername As String)

        ' This call is required by the designer.
        InitializeComponent()
        currentledgername = ledgername
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub SendSingleSMS_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("SELECT LEDGERNAME FROM LEDGERS  where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "'))", TxtLedgerName, "LEDGERNAME", "*TOALL")
        TxtLedgerName.Text = currentledgername
    End Sub

    Private Sub SendSingleSMS_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        If TxtLedgerName.Text.Length = 0 Then
            MsgBox("Please select the Ledger Name         ", MsgBoxStyle.Information)
            TxtLedgerName.Focus()
            Exit Sub
        End If
        If txtmsg.Text.Length = 0 Then
            MsgBox("Please enter the body of message            ", MsgBoxStyle.Information)
            txtmsg.Focus()
            Exit Sub
        End If
        If TxtLedgerName.Text = "*TOALL" Then
            If MsgBox("Do you want to Send the SMS for selected group ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                My.Application.DoEvents()
                Dim sqlstr As String = "select tel,pphoneno from ledger where  IsSendSMS='True' and (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')) "

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
        Else
            If MsgBox("Do you want to Send SMS for Selected Ledger Account ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Application.DoEvents()
                Dim sqlstr As String = "select tel,pphoneno from ledgers where  ledgername=N'" & TxtLedgerName.Text & "'"

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

        End If

    End Sub

    Private Sub ImsButton2_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton2.Click
        Me.Close()
    End Sub
End Class
