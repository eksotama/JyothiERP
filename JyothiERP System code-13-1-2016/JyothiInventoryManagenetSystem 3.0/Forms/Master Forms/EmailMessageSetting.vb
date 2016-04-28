Imports System.Windows.Forms

Public Class EmailMessageSetting
    Dim TODAYDATE As String = "12-5-2014 14:15"
    Dim INVOICENO As String = "142"
    Dim INVOICEDATE As String = "11-05-2014"
    Dim PARTYNAME As String = "JYOTHI SURESH"
    Dim CURRENTAMOUNT As String = "4500"
    Dim INVOICEBALANCE As String = "2500"
    Dim PAYMENTBY As String = "CASH"
    Dim BALANCE As String = "18500 DR"



    Private Sub EmailMessageSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMsg.TextChanged
        Dim TempStr As New TextBox
        TempStr.Multiline = True
        TempStr.Text = TxtMsg.Text
        TempStr.Text = TempStr.Text.Replace("@TODAYDATE@", TODAYDATE)
        TempStr.Text = TempStr.Text.Replace("@INVOICENO@", INVOICENO)
        TempStr.Text = TempStr.Text.Replace("@INVOICEDATE@", INVOICEDATE)
        TempStr.Text = TempStr.Text.Replace("@PARTYNAME@", PARTYNAME)
        TempStr.Text = TempStr.Text.Replace("@CURRENTAMOUNT@", CURRENTAMOUNT)
        TempStr.Text = TempStr.Text.Replace("@INVOICEBALANCE@", INVOICEBALANCE)
        TempStr.Text = TempStr.Text.Replace("@PAYMENTBY@", PAYMENTBY)
        TempStr.Text = TempStr.Text.Replace("@BALANCE@", BALANCE)
        WebBrowser1.DocumentText = TempStr.Text
    End Sub


    Private Sub TxtMsgType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMsgType.SelectedIndexChanged
        If SQLIsFieldExists("select vouchername from smsmailsettings where vouchername=N'" & TxtMsgType.Text & "' and IsEmail='True'") = True Then
            TxtMsg.Text = SQLGetStringFieldValue(" select msgtext from smsmailsettings where vouchername=N'" & TxtMsgType.Text & "'  and IsEmail='True' ", "msgtext")
            IsSendAttachment.Checked = SQLGetBooleanFieldValue(" select isattachfile from smsmailsettings where vouchername=N'" & TxtMsgType.Text & "'  and IsEmail='True'", "isattachfile")
            TxtSubject.Text = SQLGetStringFieldValue(" select mailSubject from smsmailsettings where vouchername=N'" & TxtMsgType.Text & "'  and IsEmail='True'", "mailSubject")
            'mailSubject
        Else
            ExecuteSQLQuery("INSERT INTO [smsmailsettings] ([vouchername] ,[msgtext],[isattachfile],[IsEmail],[mailSubject])     VALUES (N'" & TxtMsgType.Text & "','','false','true','')")
            TxtMsg.Text = ""
            IsSendAttachment.Checked = False
        End If

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MsgBox("Do You want to Save Changes  ?              ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim SqlStr As String = ""
        
        SqlStr = "UPDATE [smsmailsettings]   SET msgtext=@msgtext,isattachfile=@isattachfile,mailSubject=@mailSubject where vouchername=N'" & TxtMsgType.Text & "'  and IsEmail='True'"
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Try
            Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF1.Parameters
                .AddWithValue("msgtext", TxtMsg.Text)
                If IsSendAttachment.Checked = True Then
                    .AddWithValue("isattachfile", "True")
                Else
                    .AddWithValue("isattachfile", "False")
                End If
                .AddWithValue("mailSubject", TxtSubject.Text)
                'mailSubject
            End With
            DBF1.ExecuteNonQuery()
            DBF1.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MAINCON.Close()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
