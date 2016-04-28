Public Class CompanyDuties
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loaddATA()
        Dim Sqlstr As String
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY shiftname) AS [S.NO],shiftname as [Shift Name],timein as [1stTimeIn],timeout as [1stTimeOut],etimein as [2ndTimeIn],etimeout as [2ndTimeOut], earlyin as [Early In], lateout as [Late Out],(case when issingleshift=1 then 'Single Shift' else 'Double Shift' end) as [Shift Type] from dutysettings"
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 40

            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 200

            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 80
            If txt24Format.Checked = True Then
                Me.TxtList.Columns(2).DefaultCellStyle.Format = "HH:mm"
            Else
                Me.TxtList.Columns(2).DefaultCellStyle.Format = "hh:mm tt"
            End If


            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 80
            If txt24Format.Checked = True Then
                Me.TxtList.Columns(3).DefaultCellStyle.Format = "HH:mm"
            Else
                Me.TxtList.Columns(3).DefaultCellStyle.Format = "hh:mm tt"
            End If

            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 80
            If txt24Format.Checked = True Then
                Me.TxtList.Columns(4).DefaultCellStyle.Format = "HH:mm"
            Else
                Me.TxtList.Columns(4).DefaultCellStyle.Format = "hh:mm tt"
            End If

            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).Width = 80
            If txt24Format.Checked = True Then
                Me.TxtList.Columns(5).DefaultCellStyle.Format = "HH:mm"
            Else
                Me.TxtList.Columns(5).DefaultCellStyle.Format = "hh:mm tt"
            End If

            Me.TxtList.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(6).Width = 80
           Me.TxtList.Columns(6).DefaultCellStyle.Format = "HH:mm"

            Me.TxtList.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(7).Width = 80
             Me.TxtList.Columns(7).DefaultCellStyle.Format = "HH:mm"

        Catch ex As Exception

        End Try

    End Sub
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem1.Click
        Dim k As New ShiftDuties()
        k.ShowDialog()
        loaddATA()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If TxtList.RowCount = 0 Then Exit Sub
        'Shift Type Single Shift
        If TxtList.Item("Shift Type", TxtList.CurrentRow.Index).Value = "Single Shift" Then
            Dim k As New ShiftDuties(TxtList.Item("Shift Name", TxtList.CurrentRow.Index).Value)
            k.ShowDialog()
            loaddATA()
        Else
            Dim k As New DoubleShiftDuties(TxtList.Item("Shift Name", TxtList.CurrentRow.Index).Value)
            k.ShowDialog()
            loaddATA()
        End If
       
    End Sub

    Private Sub CompanyDuties_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CompanyDuties_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loaddATA()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loaddATA()
    End Sub

    Private Sub txt24Format_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt24Format.CheckedChanged
        loaddATA()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If MsgBox("Do you want to delete the selected Shift Name : " & TxtList.Item("Shift Name", TxtList.CurrentRow.Index).Value & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ExecuteSQLQuery("delete from dutysettings where shiftname=N'" & TxtList.Item("Shift Name", TxtList.CurrentRow.Index).Value & "'")
        loaddATA()
    End Sub

    Private Sub BtnNew_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click

    End Sub

    Private Sub btnDblnewshift_Click(sender As System.Object, e As System.EventArgs) Handles btnDblnewshift.Click, NewDoubleToolStripMenuItem.Click
        Dim k As New DoubleShiftDuties()
        k.ShowDialog()
        loaddATA()
    End Sub

    Private Sub BtnReport_Click(sender As System.Object, e As System.EventArgs) Handles BtnReport.Click

    End Sub
End Class