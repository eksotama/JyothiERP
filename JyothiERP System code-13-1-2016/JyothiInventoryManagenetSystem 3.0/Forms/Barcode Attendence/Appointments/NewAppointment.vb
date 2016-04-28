Imports System.Windows.Forms

Public Class NewAppointment
    Dim DutyStartDate As New DateTimePicker
    Dim DutyEndDate As New DateTimePicker
    Dim NewAddItem As New ChooseItemClass
    Dim ISDOUBLESHIT As Boolean = False
    Sub New(V_DutyStartDate As DateTimePicker, V_DutyEndDate As DateTimePicker, doubleshit As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        DutyStartDate.Value = V_DutyStartDate.Value
        DutyEndDate.Value = V_DutyEndDate.Value
        ISDOUBLESHIT = doubleshit
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Panel1_Click(sender As Object, e As System.EventArgs) Handles Panel1.Click
        Dim frm As New ColorDialog
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Panel1.BackColor = frm.Color
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtStartDate.ValueChanged
        Try
            If TxtLength.Text.Length = 0 Then
                TxtLength.Text = "0"
            End If
            TxtEndDate.Value = TxtStartDate.Value.AddMinutes(CDbl(TxtLength.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtEndDate.ValueChanged
        Try
            TxtStartDate.Value = New DateTime(TxtEndDate.Value.Year, TxtEndDate.Value.Month, TxtEndDate.Value.Day, TxtStartDate.Value.Hour, TxtStartDate.Value.Minute, 0)
        Catch ex As Exception
            MsgBox("Invalid dates")
        End Try
    End Sub

    Private Sub ImsButton2_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton2.Click
        If MsgBox("Close              ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub NewAppointment_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select LedgerName from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')) ", TxtCustomerName, "LedgerName")
        LoadDataIntoComboBox("SELECT DISTINCT EmpName FROM Duties", TxtEmployeeName, "EmpName")
        LoadDef()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
      
        If TxtCustomerName.Text.Length = 0 Then
            MsgBox("Please Select the Customer Name .. ", MsgBoxStyle.Information)
            TxtCustomerName.Focus()
            Exit Sub
        End If

        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please select the Employee name ... ", MsgBoxStyle.Information)
            TxtEmployeeName.Focus()
            Exit Sub
        End If
        If CDbl(TxtLength.Text) <= 0 Then
            MsgBox("Please select the Length in Minutes ... ", MsgBoxStyle.Information)
            TxtLength.Focus()
            Exit Sub
        End If
        TxtEndDate.Value = TxtStartDate.Value.AddMinutes(CDbl(TxtLength.Text))
        If TxtServiceList.Rows.Count = 0 Then
            MsgBox("Please select the Services   ", MsgBoxStyle.Information)
            TxtServiceList.Focus()
            Exit Sub
        End If
        If ValidateDates() = False Then
            TxtStartDate.Focus()
            Exit Sub
        Else
            If MsgBox("Do you want to Save New Appointment  ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveAppointmentData()
                Me.Dispose()
            End If
        End If


    End Sub
    Sub SaveAppointmentData()
        Dim Sqlstr As String = ""
        Dim ID As Long = 0
        ID = CLng(SQLGetNumericFieldValue("SELECT MAX(AppID) +1 AS NOS FROM Appointmentdb ", "NOS"))
        Sqlstr = "INSERT INTO [Appointmentdb] ([EmpName],[AppID],[DateStart],[DateEnd],[TextVal],[Note],[LedgerName],[ColorR],[ColorG],[ColorB],[Imagepath],[PatterStyle],[PatterColorR],[PatterColorG],[PatterColorB],[IsConfirm],[IsOrderConfirm],[dateValue],[IsLocked])     VALUES " _
            & " (@EmpName,@AppID,@DateStart,@DateEnd,@TextVal,@Note,@LedgerName,@ColorR,@ColorG,@ColorB,@Imagepath,@PatterStyle,@PatterColorR,@PatterColorG,@PatterColorB,@IsConfirm,@IsOrderConfirm,@dateValue,@IsLocked) "
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()

        Dim DBFR2 As SqlClient.SqlCommand
        DBFR2 = New SqlClient.SqlCommand(Sqlstr, MAINCON)
        With DBFR2.Parameters
            .AddWithValue("EmpName", TxtEmployeeName.Text)
            .AddWithValue("AppID", ID)
            .AddWithValue("DateStart", TxtStartDate.Value)
            .AddWithValue("DateEnd", TxtEndDate.Value)
            .AddWithValue("TextVal", "")
            .AddWithValue("Note", TxtNotes.Text)
            .AddWithValue("LedgerName", TxtCustomerName.Text)
            .AddWithValue("ColorR", Panel1.BackColor.R)
            .AddWithValue("ColorG", Panel1.BackColor.G)
            .AddWithValue("ColorB", Panel1.BackColor.B)
            .AddWithValue("Imagepath", "")
            .AddWithValue("PatterStyle", 0)
            .AddWithValue("PatterColorR", 0)
            .AddWithValue("PatterColorG", 0)
            .AddWithValue("PatterColorB", 0)
            .AddWithValue("IsConfirm", 0)
            .AddWithValue("IsOrderConfirm", 0)
            .AddWithValue("IsLocked", IsItLock.Checked)
            .AddWithValue("dateValue", TxtStartDate.Value.Date.ToOADate)
        End With
        DBFR2.ExecuteNonQuery()
        DBFR2 = Nothing

        Sqlstr = "INSERT INTO [AppointmentRows]([Barcode],[AppID],[ServiceName],[Size],[Rate],[Mins])     VALUES " _
            & " (@Barcode,@AppID,@ServiceName,@Size,@Rate,@Mins) "
        For I As Integer = 0 To TxtServiceList.Rows.Count - 1
            Dim DBFR3 As SqlClient.SqlCommand
            DBFR3 = New SqlClient.SqlCommand(Sqlstr, MAINCON)
            With DBFR3.Parameters
                .AddWithValue("Barcode", TxtServiceList.Item("tbarcode", I).Value)
                .AddWithValue("AppID", ID)
                .AddWithValue("ServiceName", TxtServiceList.Item("tname", I).Value)
                .AddWithValue("Size", "")
                .AddWithValue("Rate", CDbl(TxtServiceList.Item("tprice", I).Value))
                .AddWithValue("Mins", CLng(TxtServiceList.Item("tmins", I).Value))
            End With
            DBFR3.ExecuteNonQuery()
            DBFR3 = Nothing
        Next
       
        MAINCON.Close()


    End Sub
    Function ValidateDates() As Boolean
        '  Return False

        'CHECKING DATES WITHING THE WORKING DAYS
        If DutyStartDate.Value.TimeOfDay > TxtStartDate.Value.TimeOfDay Or DutyEndDate.Value.TimeOfDay < TxtStartDate.Value.TimeOfDay Then
            MsgBox("The Start time or date is not valid, It is not the duty times....")
            Return False
        End If

        ' check foR HOLIDAYS
        If SQLIsFieldExists("SELECT TOP 1 1 from  companyleaves where (" & TxtStartDate.Value.Date.ToOADate & " between fromdatevalue and todatevalue)") = True Then
            MsgBox("The selected Date is HolyDay.....           ", MsgBoxStyle.Information)
            Return False
        End If
        'CHECK FOR DUTY IS AVIABLE OR NOT
        If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "'") = False Then
            MsgBox("The selected Date is not alloted for duty.....           ", MsgBoxStyle.Information)
            Return False
        End If

        'CHECK FOR DUTY IS AVIABLE OR NOT FOR DOUBLE SHIFT
        If ISDOUBLESHIT = True Then
            If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where  (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "' AND ( (CONVERT(TIME,'" & TxtStartDate.Value.ToString("HH:mm:ss") & "',108)  between CONVERT(TIME,TIMEOUT,108) and CONVERT(TIME,ETIMEIN,108)) OR (CONVERT(TIME,'" & TxtEndDate.Value.ToString("HH:mm:ss") & "',108)  between CONVERT(TIME,TIMEOUT,108) and CONVERT(TIME,ETIMEIN,108)) )") = True Then
                MsgBox("The selected Date is not alloted for duty.....           ", MsgBoxStyle.Information)
                Return False
            End If
        End If
      

        ' CHECKING BRAKES TIMES FROM DUTIES TABLE
        If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "' AND ( CONVERT(TIME,'" & TxtStartDate.Value.ToString("HH:mm:ss") & "',108)   between CONVERT(TIME,MealTime,108) and CONVERT(TIME,MealDuration,108)) ") = True Then
            MsgBox("The selected Date break time .....           ", MsgBoxStyle.Information)
            Return False
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "' AND (  CONVERT(TIME,'" & TxtEndDate.Value.ToString("HH:mm:ss") & "',108)  between CONVERT(TIME,MealTime,108) and CONVERT(TIME,MealDuration,108)) ") = True Then
            MsgBox("The selected Date break time .....           ", MsgBoxStyle.Information)
            Return False
        End If

        ' CHECKING BRAKES 1

        If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "' AND (CONVERT(TIME,'" & TxtStartDate.Value.ToString("HH:mm:ss") & "',108)  between CONVERT(TIME,breaktime1,108) and CONVERT(TIME,breakDuration1,108)) ") = True Then
            MsgBox("The selected Date break time .....           ", MsgBoxStyle.Information)
            Return False
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "' AND (CONVERT(TIME,'" & TxtEndDate.Value.ToString("HH:mm:ss") & "',108)  between CONVERT(TIME,breaktime1,108) and CONVERT(TIME,breakDuration1,108)) ") = True Then
            MsgBox("The selected Date break time .....           ", MsgBoxStyle.Information)
            Return False
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "' AND (CONVERT(TIME,'" & TxtStartDate.Value.ToString("HH:mm:ss") & "',108)  between CONVERT(TIME,BreakTime2,108)  and CONVERT(TIME,BreakDuration2,108)) ") = True Then
            MsgBox("The selected Date break time .....           ", MsgBoxStyle.Information)
            Return False
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from  Duties where (" & TxtStartDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and empname=N'" & TxtEmployeeName.Text & "' AND (CONVERT(TIME,'" & TxtEndDate.Value.ToString("HH:mm:ss") & "',108)  between CONVERT(TIME,BreakTime2,108) and CONVERT(TIME,BreakDuration2,108)) ") = True Then
            MsgBox("The selected Date break time .....           ", MsgBoxStyle.Information)
            Return False
        End If

        'checking the exiting appointment date and times
        If SQLIsFieldExists("select EmpName from Appointmentdb where empname=N'" & TxtEmployeeName.Text & "' and (CONVERT(datetime,'" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  between DateStart and DateEnd) ") = True Then
            MsgBox("There is already an appointment exists ....", MsgBoxStyle.Critical)
            Return False
        End If
        If SQLIsFieldExists("select EmpName from Appointmentdb where empname=N'" & TxtEmployeeName.Text & "' and (CONVERT(datetime,'" & TxtEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  between DateStart and DateEnd) ") = True Then
            MsgBox("There is already an appointment exists ....", MsgBoxStyle.Critical)
            Return False
        End If

        Return True
    End Function

    Private Sub TxtLength_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtLength.TextChanged
        If TxtLength.Text.Length = 0 Then
            TxtEndDate.Value = TxtStartDate.Value
        Else
            TxtEndDate.Value = TxtStartDate.Value.AddMinutes(CDbl(TxtLength.Text))
        End If
    End Sub
    Sub GetStockDets()

        Dim bvalue As New ChooseItemClass
        bvalue.StockItemBarCode = 0
        bvalue.CurrentField = 0
        Dim k As New ChooseItems(bvalue)
        k.ShowDialog()
        If bvalue.StockItemBarCode.Length <> 0 Then
            LoadStockItemsIntoClass(bvalue.StockItemBarCode, bvalue.StockLocation, NewAddItem)
            Dim rno As Integer = 0
            rno = TxtServiceList.Rows.Add()
            TxtServiceList.Item("tsno", rno).Value = rno + 1
            TxtServiceList.Item("tbarcode", rno).Value = NewAddItem.CustBarCode
            TxtServiceList.Item("tname", rno).Value = NewAddItem.StockItemName
            TxtServiceList.Item("tprice", rno).Value = NewAddItem.StockRate
            TxtServiceList.Item("tmins", rno).Value = NewAddItem.ServiceDuration
            FindTotalMins()
        Else

        End If
        bvalue = Nothing
        k.Dispose()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        GetStockDets()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If MsgBox("Do you want to Clear all Services ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            TxtServiceList.Rows.Clear()
            FindTotalMins()
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        TxtServiceList.Rows.RemoveAt(TxtServiceList.CurrentRow.Index)
        FindTotalMins()
    End Sub
    Sub FindTotalMins()
        Dim tot As Long = 0
        For i As Integer = 0 To TxtServiceList.Rows.Count - 1
            tot = tot + CLng(TxtServiceList.Item("tmins", i).Value)
        Next
        TxtTotalMins.Text = tot.ToString
        TxtLength.Text = TxtTotalMins.Text
    End Sub
    Sub LoadDef()
        TxtServiceList.Rows.Clear()
        TxtTotalMins.Text = "0"
        TxtLength.Text = "0"
        TxtStartDate.Value = Now
        TxtNotes.Text = ""
        IsWalkin.Checked = False
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim frm As New CreateCustomers()
        frm.ShowDialog()
        LoadDataIntoComboBox("select LedgerName from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')) ", TxtCustomerName, "LedgerName")
        TxtCustomerName.Focus()
    End Sub
End Class
