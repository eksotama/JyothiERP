Imports System.Windows.Forms

Public Class DoubleShiftDuties

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

    Private Sub DoubleShiftDuties_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub NewCompanyDutySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Txt1stInTime.Value = Today
        txt1stOuttime.Value = Today
        Txt2ndInTime.Value = Today
        txt2ndouttime.Value = Today
        TxtEarlyIn.Value = Today
        txtearlyout.Value = Today
        breaktimefrom.Value = Today
        breaktimeto.Value = Today
        TxtEarlyIn.Value = New Date(Today.Year, Today.Month, Today.Day, 0, 0, 0)
        txtearlyout.Value = New Date(Today.Year, Today.Month, Today.Day, 0, 0, 0)

        If IsAlterMode = True Then
            TxtShiftName.Text = AlterShiftName
            LoadonOpen()
        Else
            Txt1stInTime.MinDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, 0, 0, 0)
            txt1stOuttime.MinDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, Txt1stInTime.Value.Hour, Txt1stInTime.Value.Minute, 0)
            Txt2ndInTime.MinDate = New Date(txt1stOuttime.Value.Year, txt1stOuttime.Value.Month, txt1stOuttime.Value.Day, txt1stOuttime.Value.Hour, txt1stOuttime.Value.Minute, 0)
            txt2ndouttime.MinDate = New Date(Txt2ndInTime.Value.Year, Txt2ndInTime.Value.Month, Txt2ndInTime.Value.Day, Txt2ndInTime.Value.Hour, Txt2ndInTime.Value.Minute, 0)

            Txt1stInTime.MaxDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, 23, 0, 0)
            txt1stOuttime.MaxDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, 23, 0, 0)
            Txt2ndInTime.MaxDate = New Date(txt1stOuttime.Value.Year, txt1stOuttime.Value.Month, txt1stOuttime.Value.Day + 1, 23, 0, 0)
            txt2ndouttime.MaxDate = New Date(Txt2ndInTime.Value.Year, Txt2ndInTime.Value.Month, Txt2ndInTime.Value.Day + 1, 23, 0, 0)

        End If
    End Sub

    Sub SaveData(ByVal SqlStr As String)

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF.Parameters
            .AddWithValue("ShiftName", TxtShiftName.Text)
            .AddWithValue("Timein", Txt1stInTime.Value)
            .AddWithValue("timeout", txt1stOuttime.Value)
            .AddWithValue("ShiftType", "1")
            .AddWithValue("ETimeIn", Txt2ndInTime.Value)
            .AddWithValue("ETimeOut", txt2ndouttime.Value)
            .AddWithValue("earlyinOT", txtealyinasOT.Checked)
            .AddWithValue("earlyin", TxtEarlyIn.Value)
            .AddWithValue("lateoutOT", txtlateoutasOT.Checked)
            .AddWithValue("lateout", txtearlyout.Value)
            .AddWithValue("breaktimefrom", breaktimefrom.Value)
            .AddWithValue("breaktimeto", breaktimeto.Value)
            .AddWithValue("issingleshift", False)
          
            .AddWithValue("totalmins", DateDiff(DateInterval.Minute, Txt1stInTime.Value, txt1stOuttime.Value) + DateDiff(DateInterval.Minute, Txt2ndInTime.Value, txt2ndouttime.Value))
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
                Txt1stInTime.Value = Sreader("Timein")
                txt1stOuttime.Value = Sreader("timeout")
                Txt2ndInTime.Value = Sreader("eTimein")
                txt2ndouttime.Value = Sreader("etimeout")
                txtealyinasOT.Checked = Sreader("earlyinOT")
                TxtEarlyIn.Value = Sreader("earlyin")
                txtlateoutasOT.Checked = Sreader("lateoutOT")
                txtearlyout.Value = Sreader("lateout")
                breaktimefrom.Value = Sreader("breaktimefrom")
                breaktimeto.Value = Sreader("breaktimeto")

                Txt1stInTime.MinDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, 0, 0, 0)
                txt1stOuttime.MinDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, Txt1stInTime.Value.Hour, Txt1stInTime.Value.Minute, 0)
                Txt2ndInTime.MinDate = New Date(txt1stOuttime.Value.Year, txt1stOuttime.Value.Month, txt1stOuttime.Value.Day, txt1stOuttime.Value.Hour, txt1stOuttime.Value.Minute, 0)
                txt2ndouttime.MinDate = New Date(Txt2ndInTime.Value.Year, Txt2ndInTime.Value.Month, Txt2ndInTime.Value.Day, Txt2ndInTime.Value.Hour, Txt2ndInTime.Value.Minute, 0)

                Txt1stInTime.MaxDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, 23, 0, 0)
                txt1stOuttime.MaxDate = New Date(Txt1stInTime.Value.Year, Txt1stInTime.Value.Month, Txt1stInTime.Value.Day, 23, 0, 0)
                Txt2ndInTime.MaxDate = New Date(txt1stOuttime.Value.Year, txt1stOuttime.Value.Month, txt1stOuttime.Value.Day + 1, 23, 0, 0)
                txt2ndouttime.MaxDate = New Date(Txt2ndInTime.Value.Year, Txt2ndInTime.Value.Month, Txt2ndInTime.Value.Day + 1, 23, 0, 0)


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

    Private Sub Txt1stInTime_LostFocus(sender As Object, e As System.EventArgs) Handles Txt1stInTime.LostFocus
        txt1stOuttime.MinDate = Txt1stInTime.Value
    End Sub

    Private Sub Txt2ndInTime_LostFocus(sender As Object, e As System.EventArgs) Handles Txt2ndInTime.LostFocus
        txt2ndouttime.MinDate = Txt2ndInTime.Value
    End Sub

    Private Sub TxtTimein_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt1stInTime.ValueChanged, Txt2ndInTime.ValueChanged
        Dim totalmins As Integer = 0
        totalmins = DateDiff(DateInterval.Minute, Txt1stInTime.Value, txt1stOuttime.Value) + DateDiff(DateInterval.Minute, Txt2ndInTime.Value, txt2ndouttime.Value)
        TxtTotalHours.Text = "Total Working Hours :" & totalmins \ 60 & ":" & totalmins - ((totalmins \ 60) * 60)
        TotalWorkingMins = totalmins / 60
    End Sub

    Private Sub txtouttime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt1stOuttime.ValueChanged, txt2ndouttime.ValueChanged
        Dim totalmins As Integer = 0
        totalmins = DateDiff(DateInterval.Minute, Txt1stInTime.Value, txt1stOuttime.Value) + DateDiff(DateInterval.Minute, Txt2ndInTime.Value, txt2ndouttime.Value)
        TxtTotalHours.Text = "Total Working Hours :" & totalmins \ 60 & ":" & totalmins - ((totalmins \ 60) * 60)
        TotalWorkingMins = totalmins / 60
        Txt2ndInTime.MinDate = txt1stOuttime.Value
    End Sub

    Private Sub TxtEarlyIn_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtEarlyIn.ValueChanged

    End Sub
End Class
