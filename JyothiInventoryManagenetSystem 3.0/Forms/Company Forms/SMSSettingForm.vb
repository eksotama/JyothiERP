Imports System.Windows.Forms

Public Class SMSSettingForm

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtSMSTYPE.Text = "GSM Mobile" Then
            If TxtPortName.Text.Length = 0 Then
                MsgBox("Please Select the Port Name ...", MsgBoxStyle.Information)
                TxtPortName.Focus()
                Exit Sub
            End If

            If MsgBox("Do you want to Save ?          ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim Sqlstr As String = ""

                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                If SQLIsFieldExists("SELECT TOP 1 1 from  SMSSettings WHERE SMSType='GSM Mobile'") = False Then
                    Sqlstr = "INSERT INTO [SMSSettings] ([username],[password],[PortName],[BaudRate],[SMSType],[serviceno],[IsDefault],[portno])     VALUES (@username,@password,@PortName,@BaudRate,@SMSType,@serviceno,@IsDefault,@portno)"
                Else
                    Sqlstr = "UPDATE [SMSSettings]    SET [username] = @username,[password] = @password,[PortName] = @PortName,[BaudRate] = @BaudRate,[SMSType] = @SMSType,[serviceno] = @serviceno,[IsDefault] = @IsDefault,[portno] = @portno WHERE SMSType='GSM Mobile' "
                End If

                Dim DBF As New SqlClient.SqlCommand(Sqlstr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("username", "")
                    .AddWithValue("password", "")
                    .AddWithValue("PortName", TxtPortName.Text)
                    .AddWithValue("BaudRate", CDbl(TxtBaudRate.Text))
                    .AddWithValue("SMSType", TxtSMSTYPE.Text)
                    .AddWithValue("serviceno", TxtServiceNO.Text)
                    .AddWithValue("IsDefault", IsSetAsDefault.Checked)
                    .AddWithValue("portno", "0")
                    'CurrencyName
                End With
                DBF.ExecuteNonQuery()
                MAINCON.Close()
                If IsSetAsDefault.Checked = True Then
                    ExecuteSQLQuery("UPDATE  [SMSSettings]    SET IsDefault='False'")
                    ExecuteSQLQuery("UPDATE  [SMSSettings]    SET IsDefault='True' WHERE SMSType='GSM Mobile'")
                End If
            End If
        Else
            If TxtAPIURL.Text.Length = 0 Then
                MsgBox("Please Enter the API URL ... ")
                TxtAPIURL.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to Save ?          ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim Sqlstr As String = ""

                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                If SQLIsFieldExists("SELECT TOP 1 1 from   SMSSettings WHERE SMSType<>'GSM Mobile'") = False Then
                    Sqlstr = "INSERT INTO [SMSSettings] ([username],[password],[PortName],[BaudRate],[SMSType],[serviceno],[IsDefault],[portno])     VALUES (@username,@password,@PortName,@BaudRate,@SMSType,@serviceno,@IsDefault,@portno)"
                Else
                    Sqlstr = "UPDATE [SMSSettings]    SET [username] = @username,[password] = @password,[PortName] = @PortName,[BaudRate] = @BaudRate,[SMSType] = @SMSType,[serviceno] = @serviceno,[IsDefault] = @IsDefault,[portno] = @portno WHERE SMSType<>'GSM Mobile' "
                End If

                Dim DBF As New SqlClient.SqlCommand(Sqlstr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("username", TxtAPIURL.Text)
                    .AddWithValue("password", "")
                    .AddWithValue("PortName", TxtPortName.Text)
                    .AddWithValue("BaudRate", CDbl(TxtBaudRate.Text))
                    .AddWithValue("SMSType", TxtSMSTYPE.Text)
                    .AddWithValue("serviceno", TxtServiceNO.Text)
                    .AddWithValue("IsDefault", IsSetAsDefault.Checked)
                    .AddWithValue("portno", "0")
                    'CurrencyName
                End With
                DBF.ExecuteNonQuery()
                MAINCON.Close()
                If IsSetAsDefault.Checked = True Then
                    ExecuteSQLQuery("UPDATE  [SMSSettings]    SET IsDefault='False'")
                    ExecuteSQLQuery("UPDATE  [SMSSettings]    SET IsDefault='True' WHERE SMSType<>'GSM Mobile'")
                End If
            End If
        End If
        LoadSMSSettings()
    End Sub

    Private Sub SMSSettingForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmailSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtPortName.Items.Clear()
        For I As Int16 = 1 To 30
            TxtPortName.Items.Add("COM" & I.ToString)
        Next
        TxtSMSTYPE.Text = "GSM Mobile"
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

   

    Private Sub ImsComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSMSTYPE.SelectedIndexChanged
        If TxtSMSTYPE.Text = "GSM Mobile" Then
            GSMPanel.Visible = True
            APIPanel.Visible = False
            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand
            TxtBaudRate.Text = "9600"
            TxtPortName.Text = ""
            TxtServiceNO.Text = ""
            IsSetAsDefault.Checked = False
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "SELECT * FROM SMSSettings WHERE SMSType='GSM Mobile'"
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                While Sreader.Read()
                    TxtBaudRate.Text = Sreader("BaudRate")
                    TxtPortName.Text = Sreader("PortName")
                    TxtServiceNO.Text = Sreader("serviceno")
                    IsSetAsDefault.Checked = Sreader("IsDefault")
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
        Else
            GSMPanel.Visible = False
            APIPanel.Visible = True
            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand
            TxtBaudRate.Text = "9600"
            TxtPortName.Text = ""
            TxtServiceNO.Text = ""
            TxtAPIURL.Text = ""
            IsSetAsDefault.Checked = False
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "SELECT * FROM SMSSettings WHERE SMSType<>'GSM Mobile'"
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                While Sreader.Read()
                    TxtAPIURL.Text = Sreader("username")
                    IsSetAsDefault.Checked = Sreader("IsDefault")
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

    Private Sub ImsButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton1.Click
        Dim frm As New SmsMessageSettingForm
        frm.ShowDialog()
    End Sub
End Class
