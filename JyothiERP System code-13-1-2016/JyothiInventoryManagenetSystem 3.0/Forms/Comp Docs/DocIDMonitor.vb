Public Class DocIDMonitor
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
    Sub loaddata()
        Dim Sqlstr As String = ""
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY DocName) as [Sno],DocType as [Doc Type],DocRefNo as [Ref],DocName as [Document Name],IssuedBy as [Issued By],ExpiryDate as [Expiry Date],DATEDIFF(day,  { fn CURDATE() },ExpiryDate ) as [Days] from documents  "
       
        If TxtDocType.Text.Length = 0 Or TxtDocType.Text = "*All" Then
        Else
            Sqlstr = Sqlstr & " and DocType=N'" & TxtDocType.Text & "'"
        End If

        Dim TempBS As New BindingSource
        '   Me.TxtList.Rows.Clear()
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(0).Width = 45
        Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(1).Width = 150
        Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(2).Width = 60
        Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.TxtList.Columns(3).Width = 180
       
    End Sub

    Private Sub DocIDMonitor_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EmployeeIDMonitor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT  distinct doctype FROM documents", TxtDocType, "doctype", "*All")
        loaddata()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub


    Private Sub TxtDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDocType.SelectedIndexChanged
        loaddata()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, RenewToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        Dim days As Double = 0
        Dim Expdate As New Date
        days = CDbl(TxtList.Item("Days", TxtList.CurrentRow.Index).Value)
        Expdate = TxtList.Item("Expiry Date", TxtList.CurrentCell.RowIndex).Value
        If days <= 0 Then
            If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim kfrm As New DocRenewExpiry(TxtList.Item("Document Name", TxtList.CurrentRow.Index).Value, TxtList.Item("Doc Type", TxtList.CurrentRow.Index).Value)
                kfrm.TxtExpiry.MinDate = Expdate
                kfrm.ShowDialog()
                kfrm.Dispose()
                loaddata()
            End If
        End If
    End Sub

    Private Sub TxtList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellDoubleClick
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        Dim days As Double = 0
        Dim Expdate As New Date
        days = CDbl(TxtList.Item("Days", TxtList.CurrentRow.Index).Value)
        Expdate = TxtList.Item("Expiry Date", TxtList.CurrentCell.RowIndex).Value
        If Days <= 0 Then
            If MsgBox("Do you want to Renewal ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim kfrm As New DocRenewExpiry(TxtList.Item("Document Name", TxtList.CurrentRow.Index).Value, TxtList.Item("Doc Type", TxtList.CurrentRow.Index).Value)
                kfrm.TxtExpiry.MinDate = Expdate
                kfrm.ShowDialog()
                kfrm.Dispose()
                loaddata()
            End If
        End If
    End Sub

    Private Sub TxtList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles TxtList.CellFormatting
        For i As Integer = 0 To TxtList.RowCount - 1
            Try
                Dim days As Double = 0
                days = CDbl(TxtList.Item("Days", i).Value)
                If days <= 0 Then
                    TxtList.Rows(i).DefaultCellStyle.BackColor = Color.IndianRed
                ElseIf days < 60 Then
                    TxtList.Rows(i).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                Else
                    TxtList.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub
End Class