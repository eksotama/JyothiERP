Imports System.Windows.Forms

Public Class NewAllotDuty
    Dim AlterEmpName As String = ""
    Dim AlterSno As Integer = 0
    Dim IsAlterMode As Boolean = False
    Sub New(Optional ByVal refno As Integer = 0, Optional ByVal EmpName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        AlterSno = refno
        AlterEmpName = EmpName
        If AlterSno > 0 Then
            IsAlterMode = True
        Else
            IsAlterMode = False
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub NewAllotDuty_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub NewAllotDuty_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select empname from employees where isdelete=0 and isactive=1", TxtEmployeeName, "empname")
        LoadDataIntoComboBox("select shiftname from dutysettings", TxtShiftName, "shiftname")
        Panel1.Visible = True
        If IsAlterMode = True Then
            BtnSave.Text = "&Alter"
            TxtEmployeeName.Text = AlterEmpName
            TxtStartDate.MinDate = Today.Date.AddYears(-100)
            TxtEndDate.MinDate = Today.Date.AddYears(-100)
            TxtEndDate.MaxDate = Today.Date.AddYears(100)
            TxtEndDate.MaxDate = Today.Date.AddYears(100)
            TxtStartDate.Value = SQLGetStringFieldValue("select datefrom from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "datefrom")
            TxtEndDate.Value = SQLGetStringFieldValue("select dateto from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "dateto")
            TxtStartDate.MinDate = TxtStartDate.Value
            TxtEndDate.MinDate = TxtStartDate.Value.AddDays(1)
            If MyAppSettings.IsMrngEvngShiftDuty = True Then
                On Error Resume Next
                TxtMStartDate.Value = SQLGetStringFieldValue("select timein from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "timein")
                TxtMEnddate.Value = SQLGetStringFieldValue("select timeout from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "timeout")
                TxtEStartDate.Value = SQLGetStringFieldValue("select etimein from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "etimein")
                TxtEEndDate.Value = SQLGetStringFieldValue("select etimeout from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "etimeout")
            End If



            TxtMealBreakTime.Value = SQLGetDateTimeFieldValue("select MealTime from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "MealTime").Value
            TxtTeaBreakTime1.Value = SQLGetDateTimeFieldValue("select breaktime1 from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "breaktime1").Value
            TxtTeaBreakTime2.Value = SQLGetDateTimeFieldValue("select BreakTime2 from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "BreakTime2").Value

            TxtMealColor.BackColor = Color.FromArgb(SQLGetNumericFieldValue("select MealTimeColorR from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "MealTimeColorR"), SQLGetNumericFieldValue("select MealTimeColorG from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "MealTimeColorG"), SQLGetNumericFieldValue("select MealTimeColorB from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "MealTimeColorB"))
            TxtBreak1Color.BackColor = Color.FromArgb(SQLGetNumericFieldValue("select Break1ColorR from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break1ColorR"), SQLGetNumericFieldValue("select Break1ColorG from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break1ColorG"), SQLGetNumericFieldValue("select Break1ColorB from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break1ColorB"))
            TxtBreak2Color.BackColor = Color.FromArgb(SQLGetNumericFieldValue("select Break2ColorR from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break2ColorR"), SQLGetNumericFieldValue("select Break2ColorG from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break2ColorG"), SQLGetNumericFieldValue("select Break2ColorB from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break2ColorB"))


            txtmealText.Text = (SQLGetStringFieldValue("select MealTimeText from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "MealTimeText"))
            TxtBreak1Text.Text = (SQLGetStringFieldValue("select Break1Text from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break1Text"))
            TxtBreak2Text.Text = (SQLGetStringFieldValue("select Break2Text from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "Break2Text"))

            Dim temp As New DateTimePicker
            temp.Value = SQLGetDateTimeFieldValue("select MealDuration from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "MealDuration").Value
            TxtMealMins.Value = DateDiff(DateInterval.Minute, TxtMealBreakTime.Value, temp.Value)

            temp.Value = SQLGetDateTimeFieldValue("select breakDuration1 from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "breakDuration1").Value
            Txtbreak1min.Value = DateDiff(DateInterval.Minute, TxtTeaBreakTime1.Value, temp.Value)

            temp.Value = SQLGetDateTimeFieldValue("select BreakDuration2 from duties where empname=N'" & TxtEmployeeName.Text & "' and sno=" & AlterSno, "BreakDuration2").Value
            Txtbreak2min.Value = DateDiff(DateInterval.Minute, TxtTeaBreakTime2.Value, temp.Value)

          



        Else
            If TxtEmployeeName.Items.Count > 0 Then
                TxtEmployeeName.SelectedIndex = 0
            End If
        End If
      
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please Select the Employee Name  ..... ", MsgBoxStyle.Information)
            TxtEmployeeName.Focus()
            Exit Sub
        End If
        If TxtShiftName.Text.Length = 0 Then
            MsgBox("Please select the Shift Name       ", MsgBoxStyle.Information)
            TxtShiftName.Focus()
            Exit Sub
        End If
        If TxtStartDate.Value > TxtEndDate.Value Then
            MsgBox("Error: Invalid Period selection, Please try again....", MsgBoxStyle.Information)
            TxtStartDate.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save ?        ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If MyAppSettings.IsMrngEvngShiftDuty = True Then
                Dim SqlStr As String = ""
                Dim Sno As Integer = 1
                If IsAlterMode = True Then
                    SqlStr = "UPDATE Duties SET [EmpName]=@EmpName,[DutyType]=@DutyType,[TimeIn]=@TimeIn,[TimeOut]=@TimeOut,[datefrom]=@datefrom,[dateto]=@dateto,[datefromvalue]=@datefromvalue,[datetovalue]=@datetovalue,[sno]=@sno,ETimeIn=@ETimeIn,ETimeOut=@ETimeOut,MealTime=@MealTime ,MealDuration=@MealDuration ,breaktime1=@breaktime1 ,breakDuration1=@breakDuration1 ,BreakTime2=@BreakTime2 ,BreakDuration2=@BreakDuration2 ,MealTimeText=@MealTimeText ,Break1Text=@Break1Text ,Break2Text=@Break2Text ,MealTimeColorR=@MealTimeColorR,MealTimeColorG=@MealTimeColorG,MealTimeColorB=@MealTimeColorB,Break1Colorr=@Break1Colorr,Break1ColorG=@Break1ColorG,Break1ColorB=@Break1ColorB,Break2ColorR=@Break2ColorR,Break2ColorG=@Break2ColorG,Break2ColorB=@Break2ColorB  WHERE EMPNAME=N'" & TxtEmployeeName.Text & "' AND SNO=" & AlterSno



                    Sno = AlterSno
                Else
                    Sno = SQLGetNumericFieldValue("select max(sno) as s from duties where empname=N'" & TxtEmployeeName.Text & "'", "s")
                    If Sno = 0 Then
                        Sno = 1
                    Else
                        Sno = Sno + 1
                    End If
                    SqlStr = "INSERT INTO [Duties]([EmpName],[DutyType],[TimeIn],[TimeOut],[datefrom],[dateto],[datefromvalue],[datetovalue],[sno],[ETimein],[ETimeOut],[MealTime],[MealDuration],[breaktime1],[breakDuration1],[BreakTime2],[BreakDuration2],[MealTimeText],[Break1Text],[Break2Text],[MealTimeColorR],[MealTimeColorG] ,[MealTimeColorB] ,[Break1Colorr] ,[Break1ColorG] ,[Break1ColorB] ,[Break2ColorR] ,[Break2ColorG] ,[Break2ColorB] )     VALUES " _
                        & " (@EmpName,@DutyType,@TimeIn,@TimeOut,@datefrom,@dateto,@datefromvalue,@datetovalue,@sno,@ETimein,@ETimeOut,@MealTime,@MealDuration,@breaktime1,@breakDuration1,@BreakTime2,@BreakDuration2,@MealTimeText,@Break1Text,@Break2Text,@MealTimeColorR,@MealTimeColorG,@MealTimeColorB,@Break1Colorr,@Break1ColorG,@Break1ColorB,@Break2ColorR,@Break2ColorG,@Break2ColorB) "

                End If
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("EmpName", TxtEmployeeName.Text)
                    .AddWithValue("DutyType", TxtShiftName.Text)
                    .AddWithValue("TimeIn", TxtMStartDate.Value)
                    .AddWithValue("TimeOut", TxtMEnddate.Value)
                    .AddWithValue("Etimein", TxtEStartDate.Value)
                    .AddWithValue("ETimeOut", TxtEEndDate.Value)
                    .AddWithValue("datefrom", TxtStartDate.Value)
                    .AddWithValue("dateto", TxtEndDate.Value)
                    .AddWithValue("datefromvalue", TxtStartDate.Value.Date.ToOADate)
                    .AddWithValue("datetovalue", TxtEndDate.Value.Date.ToOADate)
                    .AddWithValue("sno", Sno)
                    .AddWithValue("MealTime", TxtMealBreakTime.Value)
                    .AddWithValue("MealDuration", TxtMealBreakTime.Value.AddMinutes(TxtMealMins.Value))
                    .AddWithValue("breaktime1", TxtTeaBreakTime1.Value)
                    .AddWithValue("breakDuration1", TxtTeaBreakTime1.Value.AddMinutes(Txtbreak1min.Value))
                    .AddWithValue("BreakTime2", TxtTeaBreakTime2.Value)
                    .AddWithValue("BreakDuration2", TxtTeaBreakTime2.Value.AddMinutes(Txtbreak2min.Value))
                    .AddWithValue("MealTimeText", txtmealText.Text)
                    .AddWithValue("Break1Text", TxtBreak1Text.Text)
                    .AddWithValue("Break2Text", TxtBreak2Text.Text)
                    .AddWithValue("MealTimeColorR", TxtMealColor.BackColor.R)
                    .AddWithValue("Break1ColorR", TxtBreak1Color.BackColor.R)
                    .AddWithValue("Break2ColorR", TxtBreak2Color.BackColor.R)
                    .AddWithValue("MealTimeColorG", TxtMealColor.BackColor.G)
                    .AddWithValue("Break1ColorG", TxtBreak1Color.BackColor.G)
                    .AddWithValue("Break2ColorG", TxtBreak2Color.BackColor.G)
                    .AddWithValue("MealTimeColorB", TxtMealColor.BackColor.B)
                    .AddWithValue("Break1ColorB", TxtBreak1Color.BackColor.B)
                    .AddWithValue("Break2ColorB", TxtBreak2Color.BackColor.B)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
                Me.Close()



            Else
                Dim SqlStr As String = ""
                Dim timein As New DateTimePicker
                Dim timeout As New DateTimePicker
                Dim Sno As Integer = 1
                timein.Value = SQLGetStringFieldValue("select timein from dutysettings where shiftname=N'" & TxtShiftName.Text & "'", "timein")
                timeout.Value = SQLGetStringFieldValue("select timeout from dutysettings where shiftname=N'" & TxtShiftName.Text & "'", "timeout")
                If IsAlterMode = True Then
                    SqlStr = "UPDATE Duties SET [EmpName]=@EmpName,[DutyType]=@DutyType,[TimeIn]=@TimeIn,[TimeOut]=@TimeOut,[datefrom]=@datefrom,[dateto]=@dateto,[datefromvalue]=@datefromvalue,[datetovalue]=@datetovalue,[sno]=@sno ,MealTime=@MealTime ,MealDuration=@MealDuration ,breaktime1=@breaktime1 ,breakDuration1=@breakDuration1 ,BreakTime2=@BreakTime2 ,BreakDuration2=@BreakDuration2 ,MealTimeText=@MealTimeText ,Break1Text=@Break1Text ,Break2Text=@Break2Text ,MealTimeColorR=@MealTimeColorR,MealTimeColorG=@MealTimeColorG,MealTimeColorB=@MealTimeColorB,Break1Colorr=@Break1Colorr,Break1ColorG=@Break1ColorG,Break1ColorB=@Break1ColorB,Break2ColorR=@Break2ColorR,Break2ColorG=@Break2ColorG,Break2ColorB=@Break2ColorB WHERE EMPNAME=N'" & TxtEmployeeName.Text & "' AND SNO=" & AlterSno
                    Sno = AlterSno
                Else
                    Sno = SQLGetNumericFieldValue("select max(sno) as s from duties where empname=N'" & TxtEmployeeName.Text & "'", "s")
                    If Sno = 0 Then
                        Sno = 1
                    Else
                        Sno = Sno + 1
                    End If
                    SqlStr = "INSERT INTO [Duties]([EmpName],[DutyType],[TimeIn],[TimeOut],[datefrom],[dateto],[datefromvalue],[datetovalue],[sno],[MealTime] ,[MealDuration] ,[breaktime1] ,[breakDuration1] ,[BreakTime2] ,[BreakDuration2] ,[MealTimeText] ,[Break1Text] ,[Break2Text] ,[MealTimeColorR],[MealTimeColorG] ,[MealTimeColorB] ,[Break1Colorr] ,[Break1ColorG] ,[Break1ColorB] ,[Break2ColorR] ,[Break2ColorG] ,[Break2ColorB] )     VALUES " _
                        & " (@EmpName,@DutyType,@TimeIn,@TimeOut,@datefrom,@dateto,@datefromvalue,@datetovalue,@sno,@MealTime ,@MealDuration ,@breaktime1 ,@breakDuration1 ,@BreakTime2 ,@BreakDuration2 ,@MealTimeText ,@Break1Text ,@Break2Text ,@MealTimeColorR,@MealTimeColorG,@MealTimeColorB,@Break1Colorr,@Break1ColorG,@Break1ColorB,@Break2ColorR,@Break2ColorG,@Break2ColorB) "

                End If
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("EmpName", TxtEmployeeName.Text)
                    .AddWithValue("DutyType", TxtShiftName.Text)
                    .AddWithValue("TimeIn", timein.Value)
                    .AddWithValue("TimeOut", timeout.Value)
                    .AddWithValue("datefrom", TxtStartDate.Value)
                    .AddWithValue("dateto", TxtEndDate.Value)
                    .AddWithValue("datefromvalue", TxtStartDate.Value.Date.ToOADate)
                    .AddWithValue("datetovalue", TxtEndDate.Value.Date.ToOADate)
                    .AddWithValue("sno", Sno)
                   .AddWithValue("MealTime", TxtMealBreakTime.Value)
                    .AddWithValue("MealDuration", TxtMealBreakTime.Value.AddMinutes(TxtMealMins.Value))
                    .AddWithValue("breaktime1", TxtTeaBreakTime1.Value)
                    .AddWithValue("breakDuration1", TxtTeaBreakTime1.Value.AddMinutes(Txtbreak1min.Value))
                    .AddWithValue("BreakTime2", TxtTeaBreakTime2.Value)
                    .AddWithValue("BreakDuration2", TxtTeaBreakTime2.Value.AddMinutes(Txtbreak2min.Value))
                    .AddWithValue("MealTimeText", txtmealText.Text)
                    .AddWithValue("Break1Text", TxtBreak1Text.Text)
                    .AddWithValue("Break2Text", TxtBreak2Text.Text)
                    .AddWithValue("MealTimeColorR", TxtMealColor.BackColor.R)
                    .AddWithValue("Break1ColorR", TxtBreak1Color.BackColor.R)
                    .AddWithValue("Break2ColorR", TxtBreak2Color.BackColor.R)
                    .AddWithValue("MealTimeColorG", TxtMealColor.BackColor.G)
                    .AddWithValue("Break1ColorG", TxtBreak1Color.BackColor.G)
                    .AddWithValue("Break2ColorG", TxtBreak2Color.BackColor.G)
                    .AddWithValue("MealTimeColorB", TxtMealColor.BackColor.B)
                    .AddWithValue("Break1ColorB", TxtBreak1Color.BackColor.B)
                    .AddWithValue("Break2ColorB", TxtBreak2Color.BackColor.B)

                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
                Me.Close()
            End If
            
        End If

    End Sub

    Private Sub TxtEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmployeeName.SelectedIndexChanged

        TxtStartDate.MinDate = Today.Date.AddYears(-100)

        TxtEndDate.MinDate = Today.Date.AddYears(-100)
        TxtEndDate.MaxDate = Today.Date.AddYears(100)
        Try
            TxtStartDate.Value = SQLGetStringFieldValue("select max(dateto) as val from duties where empname=N'" & TxtEmployeeName.Text & "'", "val")
        Catch ex As Exception
            TxtStartDate.Value = SQLGetStringFieldValue("select DateofJoining from employees where empname=N'" & TxtEmployeeName.Text & "'", "DateofJoining")
        End Try
        TxtStartDate.MinDate = TxtStartDate.Value
        TxtEndDate.MinDate = TxtStartDate.Value.AddDays(1)
        Try
            TxtEndDate.MaxDate = SQLGetStringFieldValue("select contractexpirydate from employees where empname=N'" & TxtEmployeeName.Text & "'", "contractexpirydate")
        Catch ex As Exception
            MsgBox("The Expiry date is too near for this employeee", MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub TxtShiftName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtShiftName.SelectedIndexChanged
        If TxtShiftName.Text.Length = 0 Then Exit Sub
        On Error Resume Next
        TxtMStartDate.Value = SQLGetStringFieldValue("select timein from dutysettings where ShiftName=N'" & TxtShiftName.Text & "'", "timein", Today.ToString)
        TxtMEnddate.Value = SQLGetStringFieldValue("select timeout from dutysettings where ShiftName=N'" & TxtShiftName.Text & "'", "timeout", Today.ToString)
        TxtEStartDate.Value = SQLGetStringFieldValue("select etimein from dutysettings where ShiftName=N'" & TxtShiftName.Text & "'", "etimein", Today.ToString)
        TxtEEndDate.Value = SQLGetStringFieldValue("select etimeout from dutysettings where ShiftName=N'" & TxtShiftName.Text & "'", "etimeout", Today.ToString)

    End Sub

    Private Sub TxtMealColor_Click(sender As Object, e As System.EventArgs) Handles TxtMealColor.Click
        Dim fr As New ColorDialog
        If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtMealColor.BackColor = fr.Color
        End If
    End Sub

    Private Sub TxtBreak1Color_Click(sender As Object, e As System.EventArgs) Handles TxtBreak1Color.Click
        Dim fr As New ColorDialog
        If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtBreak1Color.BackColor = fr.Color
        End If
    End Sub

    Private Sub TxtBreak2Color_Click(sender As Object, e As System.EventArgs) Handles TxtBreak2Color.Click
        Dim fr As New ColorDialog
        If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtBreak2Color.BackColor = fr.Color
        End If
    End Sub

   
    
    
  
End Class
