Public Class VehicleIDMonitor
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtVhIDList.DataError

    End Sub
    Sub loaddata()
        Dim Sqlstr As String = ""
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY vhname) as [Sno], vhid as [Vehicle ID],vhname as [Vehicle Name],ExpiryDate as [Expiry], " _
            & " InsurenceExpiry1 as [Insurence1 Expiry],InsurenceExpiry2 as [Insurence2 Expiry],InsurenceExpiry3 as [Insurence3 Expiry] from vehicle  where isdelete=0 "
      

        If TxtType.Text.Length = 0 Or TxtType.Text = "*All" Then
        Else
            Sqlstr = Sqlstr & " and depname=N'" & TxtType.Text & "'"
        End If

        Dim TempBS As New BindingSource
        '   Me.TxtList.Rows.Clear()
        With Me.TxtVhIDList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtVhIDList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtVhIDList.Columns(0).Width = 45
        Me.TxtVhIDList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtVhIDList.Columns(1).Width = 40
        Me.TxtVhIDList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtVhIDList.Columns(2).Width = 120



    End Sub

    Private Sub VehicleIDMonitor_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmployeeIDMonitor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  distinct vhtype FROM vehicle", TxtType, "vhtype", "*All")
        loaddata()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtVhIDList.CellDoubleClick
        If TxtVhIDList.RowCount = 0 Then Exit Sub
        If TxtVhIDList.CurrentRow.Index < 0 Then Exit Sub
        'Expiry
        'Insurence1 Expiry
        'Insurence2 Expiry
        'Insurence3 Expiry
        Dim Expdate As New Date
        Dim Days As Integer = 0
        If TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If


        ElseIf TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Insurence1 Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Insurence1 Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If

        ElseIf TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Insurence2 Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Insurence2 Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If
        ElseIf TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Insurence3 Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Insurence3 Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If
        End If
    End Sub

    Private Sub TxtList_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles TxtVhIDList.CellPainting
        Dim expDate As New Date
        Dim Days As Integer = 0
        For i As Integer = 0 To TxtVhIDList.Rows.Count - 1
            'Expiry
            'Insurence1 Expiry
            'Insurence2 Expiry
            'Insurence3 Expiry
            expDate = TxtVhIDList.Item("Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtVhIDList.Item("Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtVhIDList.Item("Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtVhIDList.Item("Expiry", i).Style.BackColor = Color.LightGreen
            End If

            expDate = TxtVhIDList.Item("Insurence1 Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtVhIDList.Item("Insurence1 Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtVhIDList.Item("Insurence1 Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtVhIDList.Item("Insurence1 Expiry", i).Style.BackColor = Color.LightGreen
            End If

            expDate = TxtVhIDList.Item("Insurence2 Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtVhIDList.Item("Insurence2 Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtVhIDList.Item("Insurence2 Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtVhIDList.Item("Insurence2 Expiry", i).Style.BackColor = Color.LightGreen
            End If


            expDate = TxtVhIDList.Item("Insurence3 Expiry", i).Value
            Days = DateDiff(DateInterval.Day, Today.Date, expDate)

            If Days <= 0 Then
                TxtVhIDList.Item("Insurence3 Expiry", i).Style.BackColor = Color.IndianRed
            ElseIf Days <= 60 Then
                TxtVhIDList.Item("Insurence3 Expiry", i).Style.BackColor = Color.LightGoldenrodYellow
            Else
                TxtVhIDList.Item("Insurence3 Expiry", i).Style.BackColor = Color.LightGreen
            End If




        Next

    End Sub

    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtType.SelectedIndexChanged
        loaddata()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtVhIDList.RowCount = 0 Then Exit Sub
        If TxtVhIDList.CurrentRow.Index < 0 Then Exit Sub
        'Expiry
        'Insurence1 Expiry
        'Insurence2 Expiry
        'Insurence3 Expiry
        Dim Expdate As New Date
        Dim Days As Integer = 0
        If TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If


        ElseIf TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Insurence1 Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Insurence1 Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If

        ElseIf TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Insurence2 Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Insurence2 Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If
        ElseIf TxtVhIDList.Columns(TxtVhIDList.CurrentCell.ColumnIndex).Name = "Insurence3 Expiry" Then
            Expdate = TxtVhIDList.Item(TxtVhIDList.CurrentCell.ColumnIndex, TxtVhIDList.CurrentCell.RowIndex).Value
            Days = DateDiff(DateInterval.Day, Today.Date, Expdate)
            If Days <= 0 Then
                If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim k As New RenewVehicleIDs(TxtVhIDList.Item("Vehicle Name", TxtVhIDList.CurrentRow.Index).Value, "Insurence3 Expiry")
                    k.TxtExpiry.MinDate = Expdate.AddDays(1)
                    k.ShowDialog()
                    k.Dispose()
                    loaddata()
                End If
            End If
        End If
    End Sub
End Class