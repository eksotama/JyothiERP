Public Class EditCalander
    Dim B As CalanderBox

   
    Dim DutyStartDate As New DateTimePicker
    Dim DutyEndDate As New DateTimePicker
    Dim NewAddItem As New ChooseItemClass
    Sub New(ByRef CB As CalanderBox, V_DutyStartDate As DateTimePicker, V_DutyEndDate As DateTimePicker)

        ' This call is required by the designer.
        InitializeComponent()
        B = CB
        DutyStartDate.Value = V_DutyStartDate.Value
        DutyEndDate.Value = V_DutyEndDate.Value
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Panel1_Click(sender As Object, e As System.EventArgs) Handles Panel1.Click
        Dim frm As New ColorDialog
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Panel1.BackColor = frm.Color
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtStartDate.ValueChanged
        If TxtLength.Text.Length = 0 Then
            TxtLength.Text = "0"
        End If
        TxtEndDate.Value = TxtStartDate.Value.AddMinutes(CDbl(TxtLength.Text))
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtEndDate.ValueChanged
        Try
            TxtStartDate.Value = New DateTime(TxtEndDate.Value.Year, TxtEndDate.Value.Month, TxtEndDate.Value.Day, TxtStartDate.Value.Hour, TxtStartDate.Value.Minute, 0)
        Catch ex As Exception

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
                B.TextVal = TxtNotes.Text
                B.StartTime.Value = TxtStartDate.Value
                B.EndTime.Value = TxtEndDate.Value
                B.BackColor = Panel1.BackColor
                B.EmployeeID = TxtEmployeeName.Text
                Me.Dispose()
            End If
        End If


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

        If SQLIsFieldExists("select EmpName from Appointmentdb where empname=N'" & TxtEmployeeName.Text & "' and (CONVERT(datetime,'" & TxtStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  between DateStart and DateEnd) and appid<>" & B.ID) = True Then
            MsgBox("There is already an appointment exists ....", MsgBoxStyle.Critical)
            Return False
        End If
        If SQLIsFieldExists("select EmpName from Appointmentdb where empname=N'" & TxtEmployeeName.Text & "' and (CONVERT(datetime,'" & TxtEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  between DateStart and DateEnd)  and appid<>" & B.ID) = True Then
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
        'LOAD DATA TO THE BOX USING APPID
        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim Sqlcmmd2 As New SqlClient.SqlCommand

        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Sqlcmmd2.Connection = SqlConn2
            Sqlcmmd2.CommandText = "SELECT * FROM Appointmentdb WHERE APPID=" & B.ID
            Sqlcmmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd2.ExecuteReader
            While Sreader.Read()
                TxtEmployeeName.Text = Sreader("EMPNAME")
                TxtStartDate.Value = Sreader("DateStart")
                TxtEndDate.Value = Sreader("DateEnd")
                TxtLength.Text = DateDiff(DateInterval.Minute, TxtStartDate.Value, TxtEndDate.Value)
                TxtNotes.Text = Sreader("NOTE").ToString
                TxtCustomerName.Text = Sreader("LedgerName")
                Panel1.BackColor = Color.FromArgb(Sreader("ColorR"), Sreader("ColorG"), Sreader("ColorB"))
                If Sreader("IsLocked") = True Then
                    IsItLock.Checked = True
                Else
                    IsItLock.Checked = False
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            Sqlcmmd2.Connection = Nothing
        End Try

        Dim SqlConn3 As New SqlClient.SqlConnection
        Dim Sqlcmmd3 As New SqlClient.SqlCommand

        Try
            SqlConn3.ConnectionString = ConnectionStrinG
            SqlConn3.Open()
            Sqlcmmd3.Connection = SqlConn3
            Sqlcmmd3.CommandText = "SELECT * FROM AppointmentRows WHERE AppID=" & B.ID
            Sqlcmmd3.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd3.ExecuteReader
            While Sreader.Read()
                Dim rno As Integer = 0
                rno = TxtServiceList.Rows.Add()
                TxtServiceList.Item("tsno", rno).Value = rno + 1
                TxtServiceList.Item("tbarcode", rno).Value = Sreader("Barcode")
                TxtServiceList.Item("tname", rno).Value = Sreader("ServiceName")
                TxtServiceList.Item("tprice", rno).Value = Sreader("Rate")
                TxtServiceList.Item("tmins", rno).Value = Sreader("Mins")

                
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn3.Close()
            SqlConn3.Dispose()
            Sqlcmmd3.Connection = Nothing
        End Try

        FindTotalMins()
    End Sub
    Sub SaveAppointmentData()
        Dim Sqlstr As String = ""
  

        Sqlstr = "UPDATE [Appointmentdb]   SET [EmpName] =@EmpName,[DateStart] =@DateStart,[DateEnd] =@DateEnd,[TextVal] =@TextVal,[Note] =@Note,[LedgerName] =@LedgerName,[ColorR] =@ColorR,[ColorG] =@ColorG,[ColorB] =@ColorB,[dateValue] =@dateValue,IsLocked=@IsLocked  where appid=" & B.ID
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()

        Dim DBFR2 As SqlClient.SqlCommand
        DBFR2 = New SqlClient.SqlCommand(Sqlstr, MAINCON)
        With DBFR2.Parameters
            .AddWithValue("EmpName", TxtEmployeeName.Text)
            .AddWithValue("DateStart", TxtStartDate.Value)
            .AddWithValue("DateEnd", TxtEndDate.Value)
            .AddWithValue("TextVal", "")
            .AddWithValue("Note", TxtNotes.Text)
            .AddWithValue("LedgerName", TxtCustomerName.Text)
            .AddWithValue("ColorR", Panel1.BackColor.R)
            .AddWithValue("ColorG", Panel1.BackColor.G)
            .AddWithValue("ColorB", Panel1.BackColor.B)
            .AddWithValue("dateValue", TxtStartDate.Value.Date.ToOADate)
            .AddWithValue("IsLocked", IsItLock.Checked)
        End With
        DBFR2.ExecuteNonQuery()
        DBFR2 = Nothing

        ExecuteSQLQuery("DELETE FROM AppointmentRows WHERE APPID=" & B.ID)
        Sqlstr = "INSERT INTO [AppointmentRows]([Barcode],[AppID],[ServiceName],[Size],[Rate],[Mins])     VALUES " _
            & " (@Barcode,@AppID,@ServiceName,@Size,@Rate,@Mins) "
        For I As Integer = 0 To TxtServiceList.Rows.Count - 1
            Dim DBFR3 As SqlClient.SqlCommand
            DBFR3 = New SqlClient.SqlCommand(Sqlstr, MAINCON)
            With DBFR3.Parameters
                .AddWithValue("Barcode", TxtServiceList.Item("tbarcode", I).Value)
                .AddWithValue("AppID", B.ID)
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
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim frm As New CreateCustomers()
        frm.ShowDialog()
        LoadDataIntoComboBox("select LedgerName from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.CustomersAccounts & "')) ", TxtCustomerName, "LedgerName")
        TxtCustomerName.Focus()
    End Sub

    Private Sub IsItLock_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles IsItLock.CheckedChanged
        If IsItLock.Checked = True Then
            TxtEmployeeName.Enabled = False
        Else
            TxtEmployeeName.Enabled = True
        End If
    End Sub
End Class
