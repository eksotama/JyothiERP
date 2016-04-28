Public Class barcodeattendence
    Dim SqlStr As String = ""
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TxtPresentDate.Text = Now.ToString
    End Sub
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddata()
        SqlStr = "Select empname,depname from employees where IsDelete=0 "
        TxtList.Rows.Clear()
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
                TxtList.Item("tempName", rno).Value = Sreader("empname").ToString.Trim
                TxtList.Item("tdepname", rno).Value = Sreader("depname").ToString.Trim
                If SQLIsFieldExists("SELECT TOP 1 1 from  empleaves where empname=N'" & Sreader("empname").ToString.Trim & "' and (fromdatevalue<=" & Today.Date.ToOADate & " and " & Today.Date.ToOADate & "<=todatevalue)") = True Then
                    TxtList.Item("tStatus", rno).Value = SQLGetStringFieldValue("select leavecode from leaves where leavename=N'" & SQLGetStringFieldValue("select leavename from empleaves where empname=N'" & Sreader("empname").ToString.Trim & "' and (fromdatevalue<=" & Today.Date.ToOADate & " and " & Today.Date.ToOADate & "<=todatevalue) ", "leavename") & "'", "Leavecode")
                    TxtList.Rows(rno).ReadOnly = True
                Else
                    TxtList.Item("tStatus", rno).Value = IIf(SQLGetStringFieldValue("select StratTime from empattend where empname=N'" & Sreader("empname").ToString.Trim & "' and Transdatevalue=" & Today.Date.ToOADate, "StratTime").Length > 0, "P", "A")
                End If
            End While
            SqlFcmd.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try


    End Sub

    Private Sub barcodeattendence_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub barcodeattendence_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loaddata()
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        If MsgBox("Do you want to close ?       ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        TxtBarcode.Text = ""
        TxtEmpName.Text = ""
        TxtDepName.Text = ""
        Try
            TxtPic.BackgroundImage = Nothing
        Catch ex As Exception

        End Try
        TxtTime.Text = ""
        TxtBarcode.Focus()
    End Sub

    Private Sub TxtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBarcode.TextChanged
        RecordAttendance()
    End Sub
    Sub RecordAttendance()
        If TxtBarcode.Text.Length = DefaultBarcodeLength Then
            If SQLIsFieldExists("select empname from employees where barcode=N'" & TxtBarcode.Text & "' and isdelete=0") = True Then
                TxtEmpName.Text = SQLGetStringFieldValue("select empname from employees where barcode=N'" & TxtBarcode.Text & "'", "Empname")
                TxtDepName.Text = SQLGetStringFieldValue("select depname from employees where barcode=N'" & TxtBarcode.Text & "'", "depname")
                Dim piccode As String = SQLGetStringFieldValue("select photopath from employees where barcode=N'" & TxtBarcode.Text & "'", "photopath")

                Try
                    TxtPic.BackgroundImage = Image.FromFile(piccode)
                Catch ex As Exception

                End Try
                If SQLIsFieldExists(" select * from empattend where empname=N'" & TxtEmpName.Text & "' and transdatevalue=" & Today.Date.ToOADate) = True Then
                    ExecuteSQLQuery("update empattend set EndTime='" & Now.ToString("HH:ss") & "' where empname=N'" & TxtEmpName.Text & "' and transdatevalue=" & Today.Date.ToOADate)
                    TxtStatus.Text = "Exit Time Recorded at " & Now.ToString("HH:ss")
                Else
                    Dim SQLstr As String = ""
                    SQLstr = "INSERT INTO [EmpAttend]([EmpName],[StratTime],[Status],[Transdatevalue],[TransDate]) " _
                        & " VALUES(@EmpName,@StratTime,@Status,@Transdatevalue,@TransDate) "
                    MAINCON.ConnectionString = ConnectionStrinG
                    MAINCON.Open()
                    Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
                    With DBF.Parameters
                        .AddWithValue("EmpName", TxtEmpName.Text)
                        .AddWithValue("StratTime", Now.ToString("HH:ss"))
                        .AddWithValue("Status", "P")
                        .AddWithValue("Transdatevalue", Today.Date.ToOADate)
                        .AddWithValue("TransDate", Today.Date)
                    End With
                    DBF.ExecuteNonQuery()
                    DBF = Nothing
                    MAINCON.Close()
                    TxtStatus.Text = "Entry Time Recorded at" & Now.ToString("HH:ss")
                End If
                loaddata()
            End If
            TxtBarcode.Text = ""
           
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If TxtBarcode.Text.Length = DefaultBarcodeLength Then
            RecordAttendance()
        Else
            MsgBox("Invalid Barcode Entry... Please Try again...", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
End Class