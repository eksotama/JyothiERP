Imports System.Windows.Forms

Public Class ShiftDuties
    Dim TotalWorkingMins As Integer = 0
    Dim IsAlterMode As Boolean = False
    Dim AlterShiftName As String = ""
    Sub New(Optional ByVal altername As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If altername.Length > 0 Then
            AlterShiftName = altername
            IsAlterMode = True
        End If
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtShiftName.Text.Length = 0 Then
            MsgBox("Please Enter the Shift Name                  ", MsgBoxStyle.Information)
            TxtShiftName.Focus()
            Exit Sub
        End If
        If TotalWorkingMins <= 0 Then
            MsgBox("Invalid Times for the Shift Duty, Please select correct timing.....", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsAlterMode = True Then
            If UCase(TxtShiftName.Text) <> UCase(AlterShiftName) Then
                If UCase(Replace(TxtShiftName.Text, " ", "")) <> UCase(Replace(AlterShiftName, " ", "")) Then
                    If SQLIsFieldExists("select shiftname from dutysettings where shiftname=N'" & TxtShiftName.Text & "'") = True Then
                        MsgBox("The Selected Shift Name already Exists..           ", MsgBoxStyle.Information)
                        TxtShiftName.Focus()
                        Exit Sub
                    End If
                End If
            End If
            Dim sqlstr As String = ""

            sqlstr = " UPDATE [Dutysettings]    SET [ShiftName] = @ShiftName,[Timein] = @Timein,[timeout] = @timeout,[ShiftType] = @ShiftType,[ETimeIn] = @ETimeIn,[ETimeOut] = @ETimeOut,[earlyinOT] = @earlyinOT,[earlyin] = @earlyin,[lateoutOT] = @lateoutOT,[lateout] = @lateout,[breaktimefrom] = @breaktimefrom,[breaktimeto] = @breaktimeto,[issingleshift] = @issingleshift , [totalmins]=@totalmins where Shiftname=N'" & AlterShiftName & "'"
            SaveData(sqlstr)
            sqlstr = "update Duties set DutyType=N'" & TxtShiftName.Text & "' where dutytype=N'" & AlterShiftName & "'"
            ExecuteSQLQuery(sqlstr)
            Me.Close()
        Else
            If SQLIsFieldExists("select shiftname from dutysettings where shiftname=N'" & TxtShiftName.Text & "'") = True Then
                MsgBox("The Selected Shift Name already Exists..           ", MsgBoxStyle.Information)
                TxtShiftName.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to save  ?              ", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim Sqlstr As String = ""
                Sqlstr = "INSERT INTO [Dutysettings] ([ShiftName],[Timein],[timeout],[ShiftType],[ETimeIn],[ETimeOut],[earlyinOT],[earlyin],[lateoutOT],[lateout],[breaktimefrom],[breaktimeto],[issingleshift],[totalmins])     VALUES  " _
                    & " (@ShiftName,@Timein,@timeout,@ShiftType,@ETimeIn,@ETimeOut,@earlyinOT,@earlyin,@lateoutOT,@lateout,@breaktimefrom,@breaktimeto,@issingleshift,@totalmins) "
                SaveData(Sqlstr)
            End If
            Me.Close()
        End If

    End Sub

    Private Sub ShiftDuties_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub NewCompanyDutySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtTimein.Value = Today
        txtouttime.Value = Today
        TxtEarlyIn.Value = New Date(Today.Year, Today.Month, Today.Day, 0, 0, 0)
        txtearlyout.Value = New Date(Today.Year, Today.Month, Today.Day, 0, 0, 0)
        breaktimefrom.Value = Today
        breaktimeto.Value = Today

        If IsAlterMode = True Then
            TxtShiftName.Text = AlterShiftName
            LoadonOpen()
        End If
    End Sub

    Sub SaveData(ByVal SqlStr As String)

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF.Parameters
            .AddWithValue("ShiftName", TxtShiftName.Text)
            .AddWithValue("Timein", TxtTimein.Value)
            .AddWithValue("timeout", txtouttime.Value)
            .AddWithValue("ShiftType", "1")
            .AddWithValue("ETimeIn", TxtTimein.Value)
            .AddWithValue("ETimeOut", txtouttime.Value)
            .AddWithValue("earlyinOT", txtealyinasOT.Checked)
            .AddWithValue("earlyin", TxtEarlyIn.Value)

            .AddWithValue("lateoutOT", txtlateoutasOT.Checked)
            .AddWithValue("lateout", txtearlyout.Value)
         
            .AddWithValue("breaktimefrom", breaktimefrom.Value)
            .AddWithValue("breaktimeto", breaktimeto.Value)
            .AddWithValue("issingleshift", True)
            .AddWithValue("totalmins", DateDiff(DateInterval.Minute, TxtTimein.Value, txtouttime.Value))
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()
    End Sub
    Sub LoadonOpen()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from Dutysettings where ShiftName=N'" & AlterShiftName & "'"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                TxtShiftName.Text = AlterShiftName
                TxtTimein.Value = Sreader("Timein")
                txtouttime.Value = Sreader("timeout")
                txtouttime.MinDate = Sreader("timein")

                txtealyinasOT.Checked = Sreader("earlyinOT")

                TxtEarlyIn.Value = Sreader("earlyin")

                txtlateoutasOT.Checked = Sreader("lateoutOT")

                txtearlyout.Value = Sreader("lateout")
             
                breaktimefrom.Value = Sreader("breaktimefrom")
                breaktimeto.Value = Sreader("breaktimeto")

            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing

        End Try
       
    End Sub

    Private Sub TxtTimein_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTimein.ValueChanged
        Dim totalmins As Integer = 0
        totalmins = DateDiff(DateInterval.Minute, TxtTimein.Value, txtouttime.Value)
        txtouttime.MaxDate = TxtTimein.Value.AddDays(1)
        TxtTotalHours.Text = "Total Working Hours :" & totalmins \ 60 & ":" & totalmins - ((totalmins \ 60) * 60)
        TotalWorkingMins = totalmins / 60

    End Sub

    Private Sub txtouttime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtouttime.ValueChanged
        Dim totalmins As Integer = 0
        totalmins = DateDiff(DateInterval.Minute, TxtTimein.Value, txtouttime.Value)
        TxtTotalHours.Text = "Total Working Hours :" & totalmins \ 60 & ":" & totalmins - ((totalmins \ 60) * 60)
        TotalWorkingMins = totalmins / 60
    End Sub

    
End Class
