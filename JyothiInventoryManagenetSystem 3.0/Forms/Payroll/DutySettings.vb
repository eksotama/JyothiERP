Imports System.Windows.Forms

Public Class DutySettings

    Dim StartDateValue As Integer = 10

    Private Sub ImsComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtType.SelectedIndexChanged
        TxtEndDate1.Visible = False
        TxtEndDate2.Visible = False
        TxtEndDate3.Visible = False
        TxtEndDate4.Visible = False
        TxtStartDate1.Visible = False
        TxtStartDate2.Visible = False
        TxtStartDate3.Visible = False
        TxtStartDate4.Visible = False
        ImSlabel1.Visible = False
        ImSlabel2.Visible = False
        ImSlabel3.Visible = False
        ImSlabel4.Visible = False
        TxtEENDDate1.Visible = False
        TxtEENDDate2.Visible = False
        TxtEStartDate1.Visible = False
        TxtEStartDate2.Visible = False
        TxtStartDate2.Enabled = False
        TxtEndDate1.Enabled = False
        TxtEndDate2.Enabled = False
        Dim TempValue As Integer = StartDateValue
        If TxtType.Text = "12 Hours" Then
            ImSlabel1.Visible = True
            ImSlabel2.Visible = True
            TxtEndDate1.Visible = True
            TxtEndDate2.Visible = True
            TxtStartDate1.Visible = True
            TxtStartDate2.Visible = True
            'n.val.Value = Today.Date & " " & Today.Date.Hour & ":" & Today.Date.Minute & ":" & Today.Date.Second
            TxtStartDate1.Value = Today.Date & " 10:00:00"
            TxtEndDate1.Value = Today.Date & " 22:00:00"
            TxtStartDate2.Value = Today.Date & " 22:00:00"
            TxtEndDate2.Value = Today.Date & " 10:00:00"
            'TxtStartDate1.Value.Date.
        ElseIf TxtType.Text = "6 Hours" Then
            TxtEndDate1.Visible = True
            TxtEndDate2.Visible = True
            TxtEndDate3.Visible = True
            TxtEndDate4.Visible = True
            TxtStartDate1.Visible = True
            TxtStartDate2.Visible = True
            TxtStartDate3.Visible = True
            TxtStartDate4.Visible = True
            ImSlabel1.Visible = True
            ImSlabel2.Visible = True
            ImSlabel3.Visible = True
            ImSlabel4.Visible = True

            TxtStartDate1.Value = Today.Date & " 10:00:00"
            TxtEndDate1.Value = Today.Date & " 16:00:00"

            TxtStartDate2.Value = Today.Date & " 16:00:00"
            TxtEndDate2.Value = Today.Date & " 22:00:00"


            TxtStartDate3.Value = Today.Date & " 22:00:00"
            TxtEndDate3.Value = Today.Date & " 04:00:00"


            TxtStartDate4.Value = Today.Date & " 04:00:00"
            TxtEndDate4.Value = Today.Date & " 10:00:00"
        ElseIf TxtType.Text = "8 Hours" Then
            TxtEndDate1.Visible = True
            TxtEndDate2.Visible = True
            TxtEndDate3.Visible = True

            TxtStartDate1.Visible = True
            TxtStartDate2.Visible = True
            TxtStartDate3.Visible = True

            ImSlabel1.Visible = True
            ImSlabel2.Visible = True
            ImSlabel3.Visible = True


            TxtStartDate1.Value = Today.Date & " 10:00:00"
            TxtEndDate1.Value = Today.Date & " 18:00:00"

            TxtStartDate2.Value = Today.Date & " 18:00:00"
            TxtEndDate2.Value = Today.Date & " 02:00:00"


            TxtStartDate3.Value = Today.Date & " 02:00:00"
            TxtEndDate3.Value = Today.Date & " 10:00:00"

        ElseIf TxtType.Text = "Single Shift" Then
            TxtEndDate1.Visible = True
            TxtStartDate1.Visible = True
            TxtStartDate1.Enabled = True
            ImSlabel1.Visible = True
            TxtEndDate1.Enabled = True
            TxtStartDate1.Value = Today.Date & " 10:00:00"
            TxtEndDate1.Value = Today.Date & " 05:00:00"

        ElseIf TxtType.Text = "Mrng Evng Single Shift" Then
            TxtEndDate1.Visible = True
            TxtStartDate1.Visible = True
            TxtEStartDate1.Visible = True
            TxtEENDDate1.Visible = True
            ImSlabel1.Visible = True
            TxtStartDate2.Enabled = True
            TxtEndDate1.Enabled = True
            TxtEndDate2.Enabled = True
            TxtStartDate1.Value = Today.Date & " 10:00:00"
            TxtEndDate1.Value = Today.Date & " 05:00:00"

        ElseIf TxtType.Text = "Mrng Evng Double Shift" Then
            ImSlabel1.Visible = True
            ImSlabel2.Visible = True
            TxtEndDate1.Visible = True
            TxtEndDate2.Visible = True
            TxtStartDate1.Visible = True
            TxtStartDate2.Visible = True
            TxtEStartDate1.Visible = True
            TxtEENDDate1.Visible = True
            TxtEStartDate2.Visible = True
            TxtEENDDate2.Visible = True
            TxtStartDate2.Enabled = True
            TxtEndDate1.Enabled = True
            TxtEndDate2.Enabled = True

            TxtStartDate1.Value = Today.Date & " 10:00:00"
            TxtEndDate1.Value = Today.Date & " 22:00:00"
            TxtStartDate2.Value = Today.Date & " 22:00:00"
            TxtEndDate2.Value = Today.Date & " 10:00:00"
        End If

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        If MsgBox("Do you want to save ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("delete from dutysettings")
            If TxtType.Text = "12 Hours" Then
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('First Shift',CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Second Shift',CONVERT(datetime,'" & TxtStartDate2.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate2.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
            ElseIf TxtType.Text = "6 Hours" Then
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('First Shift',CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Second Shift',CONVERT(datetime,'" & TxtStartDate2.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate2.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Third Shift',CONVERT(datetime,'" & TxtStartDate3.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate3.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Fourth Shift',CONVERT(datetime,'" & TxtStartDate4.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate4.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
            ElseIf TxtType.Text = "8 Hours" Then
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('First Shift',CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Second Shift',CONVERT(datetime,'" & TxtStartDate2.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate2.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Third Shift',CONVERT(datetime,'" & TxtStartDate3.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate3.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
            ElseIf TxtType.Text = "Single Shift" Then
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('First Shift',CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
            ElseIf TxtType.Text = "Mrng Evng Single Shift" Then
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Mrng Envg Shift 1',CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
            ElseIf TxtType.Text = "Mrng Evng Double Shift" Then
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Mrng Envg Shift 1',CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType])     VALUES('Mrng Envg Shift 2',CONVERT(datetime,'" & TxtStartDate2.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate2.Value.ToString("HH:mm:ss") & "',101),'" & TxtType.Text & "')")

            End If
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub TxtStartDate1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStartDate1.ValueChanged, TxtEStartDate1.ValueChanged
        Dim timeval As Integer = 0
        timeval = TxtStartDate1.Value.Hour - StartDateValue
        TxtStartDate2.Value = TxtStartDate2.Value.AddHours(timeval)
        TxtStartDate3.Value = TxtStartDate3.Value.AddHours(timeval)
        TxtStartDate4.Value = TxtStartDate4.Value.AddHours(timeval)
        TxtEndDate1.Value = TxtEndDate1.Value.AddHours(timeval)
        TxtEndDate2.Value = TxtEndDate2.Value.AddHours(timeval)
        TxtEndDate3.Value = TxtEndDate3.Value.AddHours(timeval)
        TxtEndDate4.Value = TxtEndDate4.Value.AddHours(timeval)
        StartDateValue = TxtStartDate1.Value.Hour
    End Sub

    Private Sub DutySettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub DutySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub
    Sub LoadData()
        If SQLIsFieldExists("SELECT TOP 1 1 from   dutysettings") = True Then
            TxtType.Text = SQLGetStringFieldValue("select shifttype from dutysettings ", "shifttype")
            TxtStartDate1.Value = SQLGetStringFieldValue("select timein from dutysettings where shiftname='First Shift' ", "timein")
        Else
            TxtType.SelectedIndex = 0
        End If
    End Sub
  
End Class
