Imports System.Windows.Forms

Public Class NewCompanyDutySettings
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
            sqlstr = "UPDATE DUTYSETTINGS SET Shiftname=N'" & TxtShiftName.Text & "',timein=CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),timeout=CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),etimein=CONVERT(datetime,'" & TxtEStartDate1.Value.ToString("HH:mm:ss") & "',101),etimeout=CONVERT(datetime,'" & TxtEENDDate1.Value.ToString("HH:mm:ss") & "',101) where Shiftname=N'" & AlterShiftName & "'"
            ExecuteSQLQuery(sqlstr)
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
                ExecuteSQLQuery("INSERT INTO [Dutysettings]([ShiftName],[Timein],[timeout],[ShiftType],[eTimein],[etimeout])     VALUES(N'" & TxtShiftName.Text & "',CONVERT(datetime,'" & TxtStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEndDate1.Value.ToString("HH:mm:ss") & "',101),'',CONVERT(datetime,'" & TxtEStartDate1.Value.ToString("HH:mm:ss") & "',101),CONVERT(datetime,'" & TxtEENDDate1.Value.ToString("HH:mm:ss") & "',101))")
            End If
            Me.Close()
        End If
       
    End Sub

    Private Sub NewCompanyDutySettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub NewCompanyDutySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsAlterMode = True Then
            TxtShiftName.Text = AlterShiftName
            On Error Resume Next
            TxtStartDate1.Value = SQLGetStringFieldValue("select timein from dutysettings where ShiftName=N'" & AlterShiftName & "'", "timein", Today.ToString)
            TxtEndDate1.Value = SQLGetStringFieldValue("select timeout from dutysettings where ShiftName=N'" & AlterShiftName & "'", "timeout", Today.ToString)
            TxtEStartDate1.Value = SQLGetStringFieldValue("select etimein from dutysettings where ShiftName=N'" & AlterShiftName & "'", "etimein", Today.ToString)
            TxtEENDDate1.Value = SQLGetStringFieldValue("select etimeout from dutysettings where ShiftName=N'" & AlterShiftName & "'", "etimeout", Today.ToString)

        End If
    End Sub
End Class
