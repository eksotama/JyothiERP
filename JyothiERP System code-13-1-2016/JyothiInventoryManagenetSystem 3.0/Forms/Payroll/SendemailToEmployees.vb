Imports System.Windows.Forms

Public Class SendemailToEmployees
    Dim subjecttext As String = ""

    Private Sub SendemailToEmployees_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("SELECT EmpName FROM Employees", TxtEmployeeName, "EmpName", "*All")
    End Sub

    Private Sub TxtType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtType.SelectedIndexChanged
        TXTMSG.Text = ""
        Dim dt As New DataTable
        dt = SQLLoadGridData("SELECT * FROM empmsgs WHERE EmpMsgType=N'" & TxtType.Text & "'")
        If dt.Rows.Count > 0 Then
            TXTMSG.Text = dt.Rows(0).Item("EmpMsgtext").ToString
            subjecttext = dt.Rows(0).Item("subject").ToString
        End If
        dt.Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please select the employee name ", MsgBoxStyle.Information)
            TxtEmployeeName.Focus()
            Exit Sub
        End If
        If TxtEmployeeName.Text = "*All" Then
            Dim elist As New DataTable
            elist = SQLLoadGridData("select * from employees")
            If elist.Rows.Count > 0 Then
                For i As Integer = 0 To elist.Rows.Count - 1
                    Dim msg As String = ""
                    Dim issend As Boolean = True
                    msg = TXTMSG.Text
                    msg = msg.Replace("@EmpName@", elist.Rows(i).Item("EmpName").ToString)
                    msg = msg.Replace("@DateofBirth@", elist.Rows(i).Item("DateofBirth").ToString)
                    msg = msg.Replace("@DateofJoining@", elist.Rows(i).Item("DateofJoining").ToString)
                    msg = msg.Replace("@Designation@", elist.Rows(i).Item("Designation").ToString)
                    msg = msg.Replace("@DepName@", elist.Rows(i).Item("DepName").ToString)
                    msg = msg.Replace("@address@", elist.Rows(i).Item("address").ToString)
                    msg = msg.Replace("@contactno@", elist.Rows(i).Item("contactno").ToString)
                    If TxtType.Text.ToUpper = "BirthDay".ToUpper Then
                        msg = msg.Replace("@expirydate@", elist.Rows(i).Item("DateofBirth").ToString)
                    ElseIf TxtType.Text.ToUpper = "Air Ticket Expiry".ToUpper Then
                        msg = msg.Replace("@expiryindays@", Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & elist.Rows(i).Item("empname").ToString & "' and Transdatevalue >= (select airticketfrom from Employees where empname=N'" & elist.Rows(i).Item("empname").ToString & "')", "tt")))
                    ElseIf TxtType.Text.ToUpper = "Emirates Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp = elist.Rows(i).Item("Emiratesexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("Emiratesexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))

                    ElseIf TxtType.Text.ToUpper = "Labour Card Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp = elist.Rows(i).Item("Labourcardexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("Labourcardexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    ElseIf TxtType.Text.ToUpper = "Leave Salary Expiry".ToUpper Then
                        msg = msg.Replace("@expiryindays@", Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & elist.Rows(i).Item("empname").ToString & "' and Transdatevalue >= (select leavesalaryfrom from Employees where empname=N'" & elist.Rows(i).Item("empname").ToString & "')", "tt")))
                    ElseIf TxtType.Text.ToUpper = "Medical Card Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp = elist.Rows(i).Item("Medicalexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("Medicalexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    ElseIf TxtType.Text.ToUpper = "Passport Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp = elist.Rows(i).Item("passportexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("passportexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    ElseIf TxtType.Text.ToUpper = "Visa Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp = elist.Rows(i).Item("visaexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("visaexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    End If
                    If issend = True Then
                        If elist.Rows(i).Item("emailid").ToString.Length > 6 Then
                            SendCustomEmailTo(elist.Rows(i).Item("emailid").ToString, subjecttext, msg)
                        End If
                    End If
                   
                Next
            End If
        Else
            Dim elist As New DataTable
            elist = SQLLoadGridData("select * from employees where empname=N'" & TxtEmployeeName.Text & "'")
            If elist.Rows.Count > 0 Then
                For i As Integer = 0 To elist.Rows.Count - 1
                    Dim msg As String = ""
                    Dim issend As Boolean = True
                    msg = TXTMSG.Text
                    msg = msg.Replace("@EmpName@", elist.Rows(i).Item("EmpName").ToString)
                    msg = msg.Replace("@DateofBirth@", elist.Rows(i).Item("DateofBirth").ToString)
                    msg = msg.Replace("@DateofJoining@", elist.Rows(i).Item("DateofJoining").ToString)
                    msg = msg.Replace("@Designation@", elist.Rows(i).Item("Designation").ToString)
                    msg = msg.Replace("@DepName@", elist.Rows(i).Item("DepName").ToString)
                    msg = msg.Replace("@address@", elist.Rows(i).Item("address").ToString)
                    msg = msg.Replace("@contactno@", elist.Rows(i).Item("contactno").ToString)
                    If TxtType.Text.ToUpper = "BirthDay".ToUpper Then
                        msg = msg.Replace("@expirydate@", elist.Rows(i).Item("DateofBirth").ToString)
                    ElseIf TxtType.Text.ToUpper = "Air Ticket Expiry".ToUpper Then

                        msg = msg.Replace("@expiryindays@", Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & elist.Rows(i).Item("empname").ToString & "' and Transdatevalue >= (select airticketfrom from Employees where empname=N'" & elist.Rows(i).Item("empname").ToString & "')", "tt")))
                    ElseIf TxtType.Text.ToUpper = "Emirates Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp.Value = elist.Rows(i).Item("Emiratesexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("Emiratesexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))

                    ElseIf TxtType.Text.ToUpper = "Labour Card Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp.Value = elist.Rows(i).Item("Labourcardexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("Labourcardexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    ElseIf TxtType.Text.ToUpper = "Leave Salary Expiry".ToUpper Then
                        msg = msg.Replace("@expiryindays@", Math.Round(SQLGetNumericFieldValue("select Sum((TotalworkingMin-lt)/TotalworkingMin) as tt from EmpAttend where status='P' and  empname=N'" & elist.Rows(i).Item("empname").ToString & "' and Transdatevalue >= (select leavesalaryfrom from Employees where empname=N'" & elist.Rows(i).Item("empname").ToString & "')", "tt")))
                    ElseIf TxtType.Text.ToUpper = "Medical Card Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp.Value = elist.Rows(i).Item("Medicalexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("Medicalexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    ElseIf TxtType.Text.ToUpper = "Passport Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp.Value = elist.Rows(i).Item("passportexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("passportexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    ElseIf TxtType.Text.ToUpper = "Visa Expiry".ToUpper Then
                        Dim dtp As New DateTimePicker
                        dtp.Value = elist.Rows(i).Item("visaexpire")
                        If DateDiff(DateInterval.Day, Today, dtp.Value) < elist.Rows(i).Item("NotifyDays") Then
                            issend = False
                        End If
                        msg = msg.Replace("@expiryindays@", elist.Rows(i).Item("visaexpire"))
                        msg = msg.Replace("@expiryindays@", DateDiff(DateInterval.Day, Today.Date, dtp.Value.Date))
                    End If
                    If issend = True Then
                        If elist.Rows(i).Item("emailid").ToString.Length > 6 Then
                            SendCustomEmailTo(elist.Rows(i).Item("emailid").ToString, subjecttext, msg)
                        End If
                    End If

                Next
            End If
        End If
    End Sub
End Class
