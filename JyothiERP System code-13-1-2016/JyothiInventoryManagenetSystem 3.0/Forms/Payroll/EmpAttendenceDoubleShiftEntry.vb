Imports System.Globalization
Public Class EmpAttendenceDoubleShiftEntry
    Dim SqlStr As String = ""
    Dim Isonloading As Boolean = True
    Dim TempDate As New DateTimePicker
    Dim TempDatetime As New DateTimePicker

    Private Sub EmpAttendenceDoubleShiftEntry_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub EmpAttendenceEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartmentName, "DepName", "*All")
        TxtpresentDate.Value = Today
        TxtpresentDate.MaxDate = Today.AddDays(1)
        ' loadData()
    End Sub

    Private Sub TxtpresentDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtpresentDate.ValueChanged
        loadData()
    End Sub
    Sub loadData()
        TxtList.SuspendLayout()
        TxtList.Rows.Clear()
        If SQLIsFieldExists("SELECT TOP 1 1 from   companyleaves where (" & TxtpresentDate.Value.Date.ToOADate & " between fromdatevalue and todatevalue)") = True Then
            MsgBox("The selected Date is HolyDay.....           ", MsgBoxStyle.Information)
            If MsgBox("Do you want to reQuery the attendese ?       ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                ExecuteSQLQuery(" DELETE from empattend where  transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                Exit Sub
            End If
        End If

        If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
            SqlStr = "Select empname,depname from employees where IsDelete=0 and empname in ( select distinct empname from Duties  where (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and (DutyType in (SELECT shiftname FROM dutysettings WHERE issingleshift='False')) ) "
        Else
            SqlStr = "Select empname ,depname from employees where IsDelete=0 and depname=N'" & TxtDepartmentName.Text & "' and empname in ( select distinct empname from Duties  where (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and (DutyType in (SELECT shiftname FROM dutysettings WHERE issingleshift='False')) ) "
        End If

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SqlFcmd As New SqlClient.SqlCommand
            SqlFcmd.Connection = SqlConn1
            SqlFcmd.CommandText = SqlStr
            SqlFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SqlFcmd.ExecuteReader
            Dim rno As Integer = 0
            While Sreader.Read()
                rno = TxtList.Rows.Add
                TxtList.Item("tempName", rno).Value = Sreader("empname")
                TxtList.Item("tdepname", rno).Value = Sreader("depname")
                Dim ShiftName As String = ""
                ShiftName = SQLGetStringFieldValue("select DutyType from Duties  where (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue ) and EmpName=N'" & Sreader("empname") & "'", "DutyType")

                If SQLIsFieldExists("SELECT TOP 1 1 from   empleaves where empname=N'" & Sreader("empname") & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue)") = True Then
                    TxtList.Item("tEntryTime", rno).Value = ""
                    TxtList.Item("tLeaveTime", rno).Value = ""
                    TxtList.Item("teEntryTime", rno).Value = ""
                    TxtList.Item("teLeaveTime", rno).Value = ""
                    TxtList.Item("tot", rno).Value = "0"
                    TxtList.Item("tlate", rno).Value = "0"
                    TxtList.Item("TworkingHr", rno).Value = "0"
                    TxtList.Item("tnarration", rno).Value = ""
                    TxtList.Item("tStatus", rno).Value = SQLGetStringFieldValue("select leavecode from leaves where leavename=N'" & SQLGetStringFieldValue("select leavename from empleaves where empname=N'" & Sreader("empname") & "' and (fromdatevalue<=" & TxtpresentDate.Value.Date.ToOADate & " and " & TxtpresentDate.Value.Date.ToOADate & "<=todatevalue) ", "leavename") & "'", "Leavecode")
                    TxtList.Rows(rno).ReadOnly = True
                Else
                    If SQLIsFieldExists("select StratTime from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate) = True Then
                        Dim TempDate1 As New DateTimePicker
                        Dim TempDate2 As New DateTimePicker
                        Try
                            TempDatetime.Value = SQLGetStringFieldValue("select StratTime from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "StratTime")
                            TempDate1.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            TxtList.Item("tEntryTime", rno).Value = TempDate1.Value
                        Catch ex As Exception

                        End Try
                        Try
                            TempDatetime.Value = SQLGetStringFieldValue("select EndTime from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "EndTime")
                            TempDate2.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            TxtList.Item("tLeaveTime", rno).Value = TempDate2.Value
                        Catch ex As Exception

                        End Try
                        Try
                            TempDatetime.Value = SQLGetStringFieldValue("select eStratTime from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "eStratTime")
                            TempDate2.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            TxtList.Item("teEntryTime", rno).Value = TempDate2.Value
                        Catch ex As Exception

                        End Try
                        Try
                            TempDatetime.Value = SQLGetStringFieldValue("select eEndTime from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "eEndTime")
                            TempDate2.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            TxtList.Item("teLeaveTime", rno).Value = TempDate2.Value
                        Catch ex As Exception

                        End Try

                        TxtList.Item("tot", rno).Value = SQLGetNumericFieldValue("select max(ot) as tot from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "tot")
                        TxtList.Item("tlate", rno).Value = SQLGetNumericFieldValue("select max(lt) as tot from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "tot")
                        TxtList.Item("TworkingHr", rno).Value = SQLGetNumericFieldValue("select max(TotalworkingMin-lt+ot) as tot from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "tot")
                        TxtList.Item("tnarration", rno).Value = SQLGetStringFieldValue("select Narration as tot from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "tot")
                    Else
                        TxtList.Item("tEntryTime", rno).Value = ""
                        TxtList.Item("tLeaveTime", rno).Value = ""
                        TxtList.Item("teEntryTime", rno).Value = ""
                        TxtList.Item("teLeaveTime", rno).Value = ""
                        TxtList.Item("tot", rno).Value = "0"
                        TxtList.Item("tlate", rno).Value = "0"
                        TxtList.Item("TworkingHr", rno).Value = "0"
                        TxtList.Item("tnarration", rno).Value = ""
                    End If
                    TxtList.Item("tStatus", rno).Value = IIf(IsDate(TxtList.Item("tEntryTime", rno).Value), "P", "A")
                End If
                If SQLIsFieldExists("SELECT TOP 1 1 from   duties where empname=N'" & Sreader("empname") & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )") = True Then
                    TempDatetime.Value = SQLGetStringFieldValue("select timein from duties  where empname=N'" & Sreader("empname") & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "timein")
                    TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                    TxtList.Item("tshiftintime", rno).Value = TempDate.Value
                    TempDatetime.Value = SQLGetStringFieldValue("select timeout from duties  where empname=N'" & Sreader("empname") & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "timeout")
                    TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                    TxtList.Item("tshiftouttime", rno).Value = TempDate.Value

                    TempDatetime.Value = SQLGetStringFieldValue("select etimein from duties  where empname=N'" & Sreader("empname") & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "etimein")
                    TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                    TxtList.Item("teshiftintime", rno).Value = TempDate.Value
                    TempDatetime.Value = SQLGetStringFieldValue("select etimeout from duties  where empname=N'" & Sreader("empname") & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "etimeout")
                    TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                    TxtList.Item("teshiftouttime", rno).Value = TempDate.Value

                    TxtList.Item("Ttobeworkingmins", rno).Value = SQLGetNumericFieldValue("select top 1 DATEDIFF(minute, TimeIn, TimeOut) as tot from duties  where empname=N'" & Sreader("empname") & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "tot")
                    TxtList.Item("Ttobeworkingmins", rno).Value = CDbl(TxtList.Item("Ttobeworkingmins", rno).Value) + SQLGetNumericFieldValue("select top 1 DATEDIFF(minute, eTimeIn, eTimeOut) as tot from duties  where empname=N'" & Sreader("empname") & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "tot")
                    TxtList.Item("tearlyin", rno).Value = SQLGetStringFieldValue("select earlyin from Dutysettings where ShiftName=N'" & ShiftName & "'", "earlyin")
                    TxtList.Item("tIsEarlyasOT", rno).Value = SQLGetBooleanFieldValue("select earlyinOT from Dutysettings where ShiftName=N'" & ShiftName & "'", "earlyinOT")
                    TxtList.Item("tearlyout", rno).Value = SQLGetStringFieldValue("select lateout from Dutysettings where ShiftName=N'" & ShiftName & "'", "lateout")
                    TxtList.Item("tlateoutasOT", rno).Value = SQLGetBooleanFieldValue("select lateoutOT from Dutysettings where ShiftName=N'" & ShiftName & "'", "lateoutOT")
                    TxtList.Item("tnarration", rno).Value = SQLGetStringFieldValue("select Narration as tot from empattend where empname=N'" & Sreader("empname") & "' and Transdatevalue=" & TxtpresentDate.Value.Date.ToOADate, "tot")
                Else
                    TxtList.Item("tshiftintime", rno).Value = Today
                    TxtList.Item("tshiftouttime", rno).Value = Today
                    TxtList.Item("teshiftintime", rno).Value = Today
                    TxtList.Item("teshiftouttime", rno).Value = Today
                    TxtList.Item("Ttobeworkingmins", rno).Value = 0
                    TxtList.Item("tearlyin", rno).Value = SQLGetStringFieldValue("select earlyin from Dutysettings where ShiftName=N'" & ShiftName & "'", "earlyin")
                    TxtList.Item("tIsEarlyasOT", rno).Value = SQLGetBooleanFieldValue("select earlyinOT from Dutysettings where ShiftName=N'" & ShiftName & "'", "earlyinOT")
                    TxtList.Item("tearlyout", rno).Value = SQLGetStringFieldValue("select lateout from Dutysettings where ShiftName=N'" & ShiftName & "'", "lateout")
                    TxtList.Item("tlateoutasOT", rno).Value = SQLGetBooleanFieldValue("select lateoutOT from Dutysettings where ShiftName=N'" & ShiftName & "'", "lateoutOT")
                    TxtList.Item("tnarration", rno).Value = ""
                End If
            End While
            SqlFcmd.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try

        TxtList.ResumeLayout()
    End Sub



    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick

        If TxtList.Item("tStatus", TxtList.CurrentRow.Index).Value = "P" Or TxtList.Item("tStatus", TxtList.CurrentRow.Index).Value = "" Or TxtList.Item("tStatus", TxtList.CurrentRow.Index).Value = "A" Then
            If e.ColumnIndex = TxtList.Columns("tEntryTime").DisplayIndex Then
                If IsDate(TxtList.Item("tEntryTime", e.RowIndex).Value) = True Then
                    Dim n As New AttendEntryClass
                    Try
                        n.val.Value = TxtList.Item("tEntryTime", e.RowIndex).Value
                    Catch ex As Exception
                        n.val.Value = TxtpresentDate.Value
                    End Try

                    Dim ks As New SelectAttendenceEntry(n)
                    If ks.ShowDialog() = vbOK Then
                        TxtList.Item("tEntryTime", e.RowIndex).Value = n.val.Value
                        CalculateOTValues(e.RowIndex)
                        ExecuteSQLQuery("update empattend set StratTime=CONVERT(datetime,'" & n.val.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) ,ot=" & CLng(TxtList.Item("tot", e.RowIndex).Value) & ",lt=" & TxtList.Item("tlate", e.RowIndex).Value & "  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)

                    End If
                Else
                    Dim n As New AttendEntryClass
                    If SQLIsFieldExists("SELECT TOP 1 1 from   duties where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )") = True Then
                        TempDatetime.Value = SQLGetStringFieldValue("select timein from duties  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "timein")
                        TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                        n.val.Value = TempDate.Value
                    Else
                        n.val.Value = TxtpresentDate.Value
                    End If
                    Dim ks As New SelectAttendenceEntry(n)
                    If ks.ShowDialog() = vbOK Then
                        TxtList.Item("tEntryTime", e.RowIndex).Value = n.val.Value
                        TxtList.Item("tStatus", e.RowIndex).Value = "P"

                        CalculateOTValues(e.RowIndex)
                        If SQLIsFieldExists(" select * from empattend where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate) = True Then
                            ExecuteSQLQuery("update empattend set StratTime=CONVERT(datetime,'" & n.val.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101),ot=" & CLng(TxtList.Item("tot", e.RowIndex).Value) & ",lt=" & TxtList.Item("tlate", e.RowIndex).Value & "  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                        Else
                            Dim SQLstr As String = ""
                            SQLstr = "INSERT INTO [EmpAttend]([EmpName],[StratTime],[Status],[Transdatevalue],[TransDate],[ot],[LT],[period],TotalworkingMin,TickCount,Narration) " _
                                & " VALUES(@EmpName,@StratTime,@Status,@Transdatevalue,@TransDate,@ot,@LT,@period,@TotalworkingMin,@TickCount,@Narration) "
                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("EmpName", TxtList.Item("tempName", e.RowIndex).Value)
                                .AddWithValue("StratTime", n.val.Value)
                                .AddWithValue("Status", "P")
                                .AddWithValue("period", "D")
                                .AddWithValue("ot", TxtList.Item("tot", e.RowIndex).Value)
                                .AddWithValue("Transdatevalue", TxtpresentDate.Value.Date.ToOADate)
                                .AddWithValue("TransDate", TxtpresentDate.Value)
                                .AddWithValue("LT", TxtList.Item("tlate", e.RowIndex).Value)
                                .AddWithValue("TotalworkingMin", TxtList.Item("Ttobeworkingmins", e.RowIndex).Value)
                                .AddWithValue("TickCount", 0.5)
                                .AddWithValue("Narration", TxtList.Item("tNarration", e.RowIndex).Value)
                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()
                        End If

                    End If

                End If
            ElseIf e.ColumnIndex = TxtList.Columns("tLeaveTime").DisplayIndex Then
                If IsDate(TxtList.Item("tEntryTime", e.RowIndex).Value) = True Then
                    Dim n As New AttendEntryClass
                    If IsDate(TxtList.Item("tLeaveTime", e.RowIndex).Value) = True Then
                        Try
                            n.val.Value = TxtList.Item("tLeaveTime", e.RowIndex).Value
                        Catch ex As Exception
                            n.val.Value = TxtpresentDate.Value.Date & " " & Today.Date.TimeOfDay.ToString()
                        End Try
                    Else
                        If SQLIsFieldExists("SELECT TOP 1 1 from   duties where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )") = True Then
                            TempDatetime.Value = SQLGetStringFieldValue("select timeout from duties  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "timeout")
                            TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            n.val.Value = TempDate.Value
                        Else
                            n.val.Value = TxtpresentDate.Value
                        End If
                    End If
                    Dim ks As New SelectAttendenceEntry(n)
                    If ks.ShowDialog() = vbOK Then
                        TxtList.Item("tLeaveTime", e.RowIndex).Value = n.val.Value
                        CalculateOTValues(e.RowIndex)
                        ExecuteSQLQuery("update empattend set EndTime=CONVERT(datetime,'" & n.val.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) ,ot=" & CLng(TxtList.Item("tot", e.RowIndex).Value) & ",lt=" & TxtList.Item("tlate", e.RowIndex).Value & "   where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                        TxtList.Item("tStatus", e.RowIndex).Value = "P"

                    End If
                Else
                    MsgBox("Please Enter Entry Time ...", MsgBoxStyle.Information)
                    Exit Sub
                End If
            ElseIf e.ColumnIndex = TxtList.Columns("teEntryTime").DisplayIndex Then
                If IsDate(TxtList.Item("teEntryTime", e.RowIndex).Value) = True Then
                    Dim n As New AttendEntryClass
                    Try
                        n.val.Value = TxtList.Item("teEntryTime", e.RowIndex).Value
                    Catch ex As Exception
                        n.val.Value = TxtpresentDate.Value
                    End Try

                    Dim ks As New SelectAttendenceEntry(n)
                    If ks.ShowDialog() = vbOK Then
                        TxtList.Item("teEntryTime", e.RowIndex).Value = n.val.Value
                        CalculateOTValues(e.RowIndex)
                        ExecuteSQLQuery("update empattend set eStratTime=CONVERT(datetime,'" & n.val.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) ,ot=" & CLng(TxtList.Item("tot", e.RowIndex).Value) & ",lt=" & TxtList.Item("tlate", e.RowIndex).Value & "  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)

                    End If
                Else
                    Dim n As New AttendEntryClass
                    If SQLIsFieldExists("SELECT TOP 1 1 from   duties where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )") = True Then
                        TempDatetime.Value = SQLGetStringFieldValue("select etimein from duties  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "etimein")
                        TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                        n.val.Value = TempDate.Value
                    Else
                        n.val.Value = TxtpresentDate.Value
                    End If
                    Dim ks As New SelectAttendenceEntry(n)
                    If ks.ShowDialog() = vbOK Then
                        TxtList.Item("teEntryTime", e.RowIndex).Value = n.val.Value
                        TxtList.Item("tStatus", e.RowIndex).Value = "P"
                        'changed

                        If SQLIsFieldExists(" select * from empattend where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate) = True Then
                            'ExecuteSQLQuery("update empattend set eStratTime=CONVERT(datetime,'" & n.val.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101),ot=" & CLng(TxtList.Item("tot", e.RowIndex).Value) & ",lt=" & TxtList.Item("tlate", e.RowIndex).Value & "  where empname='" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                            CalculateOTValues(e.RowIndex)
                            ExecuteSQLQuery("update empattend set eStratTime=CONVERT(datetime,'" & n.val.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101),ot=" & CLng(TxtList.Item("tot", e.RowIndex).Value) & ",lt=" & TxtList.Item("tlate", e.RowIndex).Value & "  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                        Else
                            Dim SQLstr As String = ""
                            SQLstr = "INSERT INTO [EmpAttend]([EmpName],[eStratTime],[Status],[Transdatevalue],[TransDate],[ot],[LT],[period],TotalworkingMin,TickCount,Narration) " _
                                & " VALUES(@EmpName,@eStratTime,@Status,@Transdatevalue,@TransDate,@ot,@LT,@period,@TotalworkingMin,@TickCount,@Narration) "
                            MAINCON.ConnectionString = ConnectionStrinG
                            MAINCON.Open()
                            Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
                            With DBF.Parameters
                                .AddWithValue("EmpName", TxtList.Item("tempName", e.RowIndex).Value)
                                .AddWithValue("eStratTime", n.val.Value)
                                .AddWithValue("Status", "P")
                                .AddWithValue("period", "D")
                                .AddWithValue("ot", TxtList.Item("tot", e.RowIndex).Value)
                                .AddWithValue("Transdatevalue", TxtpresentDate.Value.Date.ToOADate)
                                .AddWithValue("TransDate", TxtpresentDate.Value)
                                .AddWithValue("LT", TxtList.Item("tlate", e.RowIndex).Value)
                                .AddWithValue("TotalworkingMin", TxtList.Item("Ttobeworkingmins", e.RowIndex).Value)
                                .AddWithValue("TickCount", 0.5)
                                .AddWithValue("Narration", TxtList.Item("tNarration", e.RowIndex).Value)
                            End With
                            DBF.ExecuteNonQuery()
                            DBF = Nothing
                            MAINCON.Close()
                            CalculateOTValues(e.RowIndex)
                        End If
                        'end


                    End If

                End If
            ElseIf e.ColumnIndex = TxtList.Columns("teLeaveTime").DisplayIndex Then
                If IsDate(TxtList.Item("teEntryTime", e.RowIndex).Value) = True Then
                    Dim n As New AttendEntryClass
                    If IsDate(TxtList.Item("teLeaveTime", e.RowIndex).Value) = True Then
                        Try
                            n.val.Value = TxtList.Item("teLeaveTime", e.RowIndex).Value
                        Catch ex As Exception
                            n.val.Value = TxtpresentDate.Value.Date & " " & Today.Date.TimeOfDay.ToString()
                        End Try
                    Else
                        If SQLIsFieldExists("SELECT TOP 1 1 from   duties where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )") = True Then
                            TempDatetime.Value = SQLGetStringFieldValue("select etimeout from duties  where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "etimeout")
                            TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            n.val.Value = TempDate.Value
                        Else
                            n.val.Value = TxtpresentDate.Value
                        End If
                    End If
                    Dim ks As New SelectAttendenceEntry(n)
                    If ks.ShowDialog() = vbOK Then
                        TxtList.Item("teLeaveTime", e.RowIndex).Value = n.val.Value
                        CalculateOTValues(e.RowIndex)
                        ExecuteSQLQuery("update empattend set eEndTime=CONVERT(datetime,'" & n.val.Value.ToString("yyyy-MM-dd HH:mm:ss") & "',101) ,ot=" & CLng(TxtList.Item("tot", e.RowIndex).Value) & ",lt=" & TxtList.Item("tlate", e.RowIndex).Value & "   where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                        TxtList.Item("tStatus", e.RowIndex).Value = "P"

                    End If
                End If



            ElseIf e.ColumnIndex = TxtList.Columns("tStatus").DisplayIndex Then
                If SQLIsFieldExists(" select * from empattend where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate) = True Then
                    If MsgBox("Do you want to mark as Absent ?         ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        ExecuteSQLQuery(" DELETE from empattend where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                        TxtList.Item("tEntryTime", e.RowIndex).Value = ""
                        TxtList.Item("tLeaveTime", e.RowIndex).Value = ""
                        TxtList.Item("teEntryTime", e.RowIndex).Value = ""
                        TxtList.Item("teLeaveTime", e.RowIndex).Value = ""
                        TxtList.Item("tot", e.RowIndex).Value = "0"
                        TxtList.Item("tlate", e.RowIndex).Value = "0"
                        TxtList.Item("TworkingHr", e.RowIndex).Value = "0"
                        TxtList.Item("tStatus", e.RowIndex).Value = "A"
                        TxtList.Item("tNarration", e.RowIndex).Value = ""
                    End If
                End If
            End If
            If e.ColumnIndex = TxtList.Columns("tEntryTime").DisplayIndex Or e.ColumnIndex = TxtList.Columns("tLeaveTime").DisplayIndex And e.ColumnIndex = TxtList.Columns("teEntryTime").DisplayIndex Or e.ColumnIndex = TxtList.Columns("teLeaveTime").DisplayIndex Then
                CalculateOTValues(e.RowIndex)
            End If
        End If

    End Sub



    Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
        'On Error Resume Next
        For i As Integer = 0 To TxtList.RowCount - 1
            If TxtList.Item("tStatus", i).Value = "P" Or TxtList.Item("tStatus", i).Value = "" Or TxtList.Item("tStatus", i).Value = "A" Then
                TxtList.Item("tStatus", i).Style.BackColor = Color.White
                If TxtList.Item("tStatus", i).Value = "P" Then
                    TxtList.Item("tot", i).ReadOnly = False
                    TxtList.Item("tlate", i).ReadOnly = False
                Else
                    TxtList.Item("tot", i).ReadOnly = True
                    TxtList.Item("tlate", i).ReadOnly = True
                End If

            Else
                TxtList.Item("tStatus", i).Style.BackColor = Color.FromName(SQLGetStringFieldValue("select colorcode from leaves where leavecode=N'" & TxtList.Item("tStatus", i).Value & "'", "colorcode"))

            End If

        Next
    End Sub

    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartmentName.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If MsgBox("Do you want to mark as Present ?      ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim timein As New DateTimePicker
            Dim timeout As New DateTimePicker
            Dim timeEin As New DateTimePicker
            Dim timeEout As New DateTimePicker
            loadData()
            For i As Integer = 0 To TxtList.RowCount - 1
                If TxtList.Item("tStatus", i).Value = "A" Then
                    If SQLIsFieldExists(" select * from empattend where empname=N'" & TxtList.Item("tempName", i).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate) = False Then
                        If SQLIsFieldExists("SELECT TOP 1 1 from   duties where empname=N'" & TxtList.Item("tempName", i).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )") = True Then
                            TempDatetime.Value = SQLGetStringFieldValue("select timein from duties  where empname=N'" & TxtList.Item("tempName", i).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "timein")
                            TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            timein.Value = TempDate.Value

                            TempDatetime.Value = SQLGetStringFieldValue("select timeout from duties  where empname=N'" & TxtList.Item("tempName", i).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "timeout")
                            TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            timeout.Value = TempDate.Value

                            TempDatetime.Value = SQLGetStringFieldValue("select Etimein from duties  where empname=N'" & TxtList.Item("tempName", i).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "Etimein")
                            TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            timeEin.Value = TempDate.Value

                            TempDatetime.Value = SQLGetStringFieldValue("select Etimeout from duties  where empname=N'" & TxtList.Item("tempName", i).Value & "' and (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue )", "Etimeout")
                            TempDate.Value = New DateTime(TxtpresentDate.Value.Year, TxtpresentDate.Value.Month, TxtpresentDate.Value.Day, TempDatetime.Value.Hour, TempDatetime.Value.Minute, TempDatetime.Value.Second)
                            timeEout.Value = TempDate.Value
                        Else
                            timein.Value = TxtpresentDate.Value.Date & " 10:00:00"
                            timeout.Value = TxtpresentDate.Value.Date & " 18:00:00"
                            timeEin.Value = TxtpresentDate.Value.Date & " 10:00:00"
                            timeEout.Value = TxtpresentDate.Value.Date & " 18:00:00"
                        End If

                        Dim SQLstr As String = ""
                        SQLstr = "INSERT INTO [EmpAttend]([EmpName],[StratTime],[Status],[Transdatevalue],[TransDate],[ot],[EndTime],[lt],[period],[TotalworkingMin],[EStratTime],[EEndTime],TickCount,Narration) " _
                            & " VALUES(@EmpName,@StratTime,@Status,@Transdatevalue,@TransDate,@ot,@EndTime,@lt,@period,@TotalworkingMin,@EStratTime,@EEndTime,@TickCount,@Narration) "
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("EmpName", TxtList.Item("tempName", i).Value)
                            .AddWithValue("StratTime", timein.Value)
                            .AddWithValue("TotalworkingMin", DateDiff(DateInterval.Minute, timein.Value, timeout.Value) + DateDiff(DateInterval.Minute, timeEin.Value, timeEout.Value))
                            .AddWithValue("EndTime", timeout.Value)
                            .AddWithValue("EStratTime", timeEin.Value)
                            .AddWithValue("EEndTime", timeEout.Value)
                            .AddWithValue("Status", "P")
                            .AddWithValue("ot", 0)
                            .AddWithValue("period", "S")
                            .AddWithValue("LT", 0)
                            .AddWithValue("Transdatevalue", TxtpresentDate.Value.Date.ToOADate)
                            .AddWithValue("TransDate", TxtpresentDate.Value)
                            .AddWithValue("TickCount", 1)
                            .AddWithValue("Narration", "")
                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()

                        CalculateOTValues(i)
                    End If
                End If
            Next
            loadData()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If MsgBox("Do you want to Unmark All (Absent)   ?                ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If TxtDepartmentName.Text.Length = 0 Or TxtDepartmentName.Text = "*All" Then
                ExecuteSQLQuery(" DELETE from empattend where  transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
            Else
                SqlStr = "Select empname ,depname from employees where IsDelete=0 and depname=N'" & TxtDepartmentName.Text & "'"
                ExecuteSQLQuery(" DELETE from empattend where  transdatevalue=" & TxtpresentDate.Value.Date.ToOADate & " and (empname in (Select empname from employees where IsDelete=0 and depname=N'" & TxtDepartmentName.Text & "' and empname in ( select distinct empname from Duties  where (" & TxtpresentDate.Value.Date.ToOADate & " between datefromvalue and datetovalue) and (DutyType in (SELECT shiftname FROM dutysettings WHERE issingleshift='False')) ) ))")
            End If
            loadData()
        End If
    End Sub

    Private Sub TxtList_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles TxtList.CellValidating
        Try
            If e.FormattedValue.ToString.Length = 0 Then
                TxtList.Item(e.ColumnIndex, e.RowIndex).Value = 0
                Exit Sub
            End If

            If e.ColumnIndex = 6 Then
                If IsNumeric(e.FormattedValue) = True Then
                    If CDbl(e.FormattedValue) < 0 Then
                        Me.TxtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                        MsgBox("The Value Should be 0 to 12 hours                           ", MsgBoxStyle.Critical)

                        e.Cancel = True
                        Exit Sub
                    End If
                    If CDbl(e.FormattedValue) > 12 * 60 Then
                        Me.TxtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                        MsgBox("The Value Should be 0 to 12 hours                            ", MsgBoxStyle.Critical)
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    Me.TxtList.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                    MsgBox("The Value Should be 0 to 12 hours                                ", MsgBoxStyle.Critical)
                    e.Cancel = True
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellValueChanged
       

    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click, ReloadToolStripMenuItem.Click
        loadData()

    End Sub


    Private Sub TxtList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub
    Sub CalculateOTValues(ByVal rowno As Integer)
        On Error Resume Next
       
        If IsDate(TxtList.Item("tEntryTime", rowno).Value) = True And IsDate(TxtList.Item("tLeaveTime", rowno).Value) = True And IsDate(TxtList.Item("teEntryTime", rowno).Value) = True And IsDate(TxtList.Item("teLeaveTime", rowno).Value) = True Then
            Dim Totalmin As Integer = 0
            Dim Totalworkingmin As Integer = 0
            Dim TimeIn As New DateTimePicker
            Dim TimeOut As New DateTimePicker
            Dim Earlyinmin As Integer = 0
            Dim earlyoutmin As Integer = 0
            Totalmin = TxtList.Item("Ttobeworkingmins", rowno).Value
            TimeIn.Value = TxtList.Item("tEntryTime", rowno).Value
            TimeOut.Value = TxtList.Item("tLeaveTime", rowno).Value
            Totalworkingmin = DateDiff(DateInterval.Minute, TimeIn.Value, TimeOut.Value)

            TimeIn.Value = TxtList.Item("teEntryTime", rowno).Value
            TimeOut.Value = TxtList.Item("teLeaveTime", rowno).Value
            Totalworkingmin = Totalworkingmin + DateDiff(DateInterval.Minute, TimeIn.Value, TimeOut.Value)


            'tearlyin  'tearlyout
            TimeIn.Value = TxtList.Item("tearlyin", rowno).Value
            Earlyinmin = TimeIn.Value.Hour * 60 + TimeIn.Value.Minute
            TimeIn.Value = TxtList.Item("tearlyout", rowno).Value
            earlyoutmin = TimeIn.Value.Hour * 60 + TimeIn.Value.Minute
            TxtList.Item("TworkingHr", rowno).Value = Totalworkingmin
            If TxtList.Item("tIsEarlyasOT", rowno).Value = True And TxtList.Item("tlateoutasOT", rowno).Value = True Then
                If Totalworkingmin < Totalmin + Earlyinmin + earlyoutmin Then
                    If Totalworkingmin = Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = "0"
                    ElseIf Totalworkingmin < Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = Totalmin - Totalworkingmin
                    Else
                        TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                        TxtList.Item("tlate", rowno).Value = 0
                    End If
                ElseIf Totalworkingmin > Totalmin + Earlyinmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                    TxtList.Item("tlate", rowno).Value = "0"
                ElseIf Totalworkingmin = Totalmin + Earlyinmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = "0"
                    TxtList.Item("tlate", rowno).Value = "0"
                End If
            ElseIf TxtList.Item("tIsEarlyasOT", rowno).Value = True And TxtList.Item("tlateoutasOT", rowno).Value = False Then
                If Totalworkingmin < Totalmin + Earlyinmin Then
                    If Totalworkingmin = Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = "0"
                    ElseIf Totalworkingmin < Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = Totalmin - Totalworkingmin
                    Else
                        TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                        TxtList.Item("tlate", rowno).Value = 0
                    End If
                ElseIf Totalworkingmin > Totalmin + Earlyinmin Then
                    TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                    TxtList.Item("tlate", rowno).Value = "0"
                ElseIf Totalworkingmin = Totalmin + Earlyinmin Then
                    TxtList.Item("tot", rowno).Value = "0"
                    TxtList.Item("tlate", rowno).Value = "0"
                End If

            ElseIf TxtList.Item("tIsEarlyasOT", rowno).Value = False And TxtList.Item("tlateoutasOT", rowno).Value = True Then
                If Totalworkingmin < Totalmin + earlyoutmin Then
                    If Totalworkingmin = Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = "0"
                    ElseIf Totalworkingmin < Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = Totalmin - Totalworkingmin
                    Else
                        TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                        TxtList.Item("tlate", rowno).Value = 0
                    End If
                ElseIf Totalworkingmin > Totalmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                    TxtList.Item("tlate", rowno).Value = "0"
                ElseIf Totalworkingmin = Totalmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = "0"
                    TxtList.Item("tlate", rowno).Value = "0"
                End If
            Else
                TxtList.Item("tot", rowno).Value = "0"
                TxtList.Item("tlate", rowno).Value = "0"
            End If
        ElseIf IsDate(TxtList.Item("tEntryTime", rowno).Value) = True And IsDate(TxtList.Item("tLeaveTime", rowno).Value) = True Then
            Dim Totalmin As Integer = 0
            Dim Totalworkingmin As Integer = 0
            Dim TimeIn As New DateTimePicker
            Dim TimeOut As New DateTimePicker
            Dim Earlyinmin As Integer = 0
            Dim earlyoutmin As Integer = 0

            Totalmin = TxtList.Item("Ttobeworkingmins", rowno).Value
            TimeIn.Value = TxtList.Item("tEntryTime", rowno).Value
            TimeOut.Value = TxtList.Item("tLeaveTime", rowno).Value
            Totalworkingmin = DateDiff(DateInterval.Minute, TimeIn.Value, TimeOut.Value)
            TimeIn.Value = TxtList.Item("tearlyin", rowno).Value
            Earlyinmin = TimeIn.Value.Hour * 60 + TimeIn.Value.Minute
            TimeIn.Value = TxtList.Item("tearlyout", rowno).Value
            earlyoutmin = TimeIn.Value.Hour * 60 + TimeIn.Value.Minute
            TxtList.Item("TworkingHr", rowno).Value = Totalworkingmin
            If TxtList.Item("tIsEarlyasOT", rowno).Value = True And TxtList.Item("tlateoutasOT", rowno).Value = True Then
                If Totalworkingmin < Totalmin + Earlyinmin + earlyoutmin Then
                    If Totalworkingmin = Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = "0"
                    ElseIf Totalworkingmin < Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = Totalmin - Totalworkingmin
                    Else
                        TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                        TxtList.Item("tlate", rowno).Value = 0
                    End If
                ElseIf Totalworkingmin > Totalmin + Earlyinmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                    TxtList.Item("tlate", rowno).Value = "0"
                ElseIf Totalworkingmin = Totalmin + Earlyinmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = "0"
                    TxtList.Item("tlate", rowno).Value = "0"
                End If
            ElseIf TxtList.Item("tIsEarlyasOT", rowno).Value = True And TxtList.Item("tlateoutasOT", rowno).Value = False Then
                If Totalworkingmin < Totalmin + Earlyinmin Then
                    If Totalworkingmin = Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = "0"
                    ElseIf Totalworkingmin < Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = Totalmin - Totalworkingmin
                    Else
                        TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                        TxtList.Item("tlate", rowno).Value = 0
                    End If
                ElseIf Totalworkingmin > Totalmin + Earlyinmin Then
                    TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                    TxtList.Item("tlate", rowno).Value = "0"
                ElseIf Totalworkingmin = Totalmin + Earlyinmin Then
                    TxtList.Item("tot", rowno).Value = "0"
                    TxtList.Item("tlate", rowno).Value = "0"
                End If

            ElseIf TxtList.Item("tIsEarlyasOT", rowno).Value = False And TxtList.Item("tlateoutasOT", rowno).Value = True Then
                If Totalworkingmin < Totalmin + earlyoutmin Then
                    If Totalworkingmin = Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = "0"
                    ElseIf Totalworkingmin < Totalmin Then
                        TxtList.Item("tot", rowno).Value = "0"
                        TxtList.Item("tlate", rowno).Value = Totalmin - Totalworkingmin
                    Else
                        TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                        TxtList.Item("tlate", rowno).Value = 0
                    End If
                ElseIf Totalworkingmin > Totalmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = Totalworkingmin - Totalmin
                    TxtList.Item("tlate", rowno).Value = "0"
                ElseIf Totalworkingmin = Totalmin + earlyoutmin Then
                    TxtList.Item("tot", rowno).Value = "0"
                    TxtList.Item("tlate", rowno).Value = "0"
                End If
            Else
                TxtList.Item("tot", rowno).Value = "0"
                TxtList.Item("tlate", rowno).Value = "0"
            End If
        Else
            TxtList.Item("tot", rowno).Value = "0"
            TxtList.Item("tlate", rowno).Value = "0"
        End If
        'update morning and evenging shift values

        If IsDate(TxtList.Item("tEntryTime", rowno).Value) = True And IsDate(TxtList.Item("tLeaveTime", rowno).Value) = True And IsDate(TxtList.Item("teEntryTime", rowno).Value) = True And IsDate(TxtList.Item("teLeaveTime", rowno).Value) = True Then
            ExecuteSQLQuery("update empattend set TickCount=1   where empname=N'" & TxtList.Item("tempName", rowno).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
        ElseIf IsDate(TxtList.Item("tEntryTime", rowno).Value) = True And IsDate(TxtList.Item("tLeaveTime", rowno).Value) = True Then
            ExecuteSQLQuery("update empattend set TickCount=0.5   where empname=N'" & TxtList.Item("tempName", rowno).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
        ElseIf IsDate(TxtList.Item("teEntryTime", rowno).Value) = True And IsDate(TxtList.Item("teLeaveTime", rowno).Value) = True Then
            ExecuteSQLQuery("update empattend set TickCount=0.5   where empname=N'" & TxtList.Item("tempName", rowno).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
        Else
            ExecuteSQLQuery("update empattend set TickCount=0   where empname=N'" & TxtList.Item("tempName", rowno).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
        End If
        If TxtList.Item("tNarration", rowno).Value = "" Then
            ExecuteSQLQuery("update empattend set Narration=''   where empname=N'" & TxtList.Item("tempName", rowno).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
        Else
            Dim SQLstr As String = ""
            SQLstr = "update empattend set Narration=@Narration   where empname=N'" & TxtList.Item("tempName", rowno).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("Narration", TxtList.Item("tNarration", rowno).Value)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        End If


    End Sub

    Private Sub TxtList_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellEndEdit
        Try
            If e.ColumnIndex = TxtList.Columns("tnarration").Index Then
                If TxtList.Item("tNarration", e.RowIndex).Value = "" Then
                    ExecuteSQLQuery("update empattend set Narration=''   where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate)
                ElseIf Len(TxtList.Item("tNarration", e.RowIndex).Value) < 100 Then
                    Dim SQLstr As String = ""
                    SQLstr = "update empattend set Narration=@Narration   where empname=N'" & TxtList.Item("tempName", e.RowIndex).Value & "' and transdatevalue=" & TxtpresentDate.Value.Date.ToOADate
                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
                    With DBF.Parameters
                        .AddWithValue("Narration", TxtList.Item("tNarration", e.RowIndex).Value)
                    End With
                    DBF.ExecuteNonQuery()
                    DBF = Nothing
                    MAINCON.Close()
                Else
                    MsgBox("Error:  Exceeds the length of characters, should be less than 100 characters...")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class