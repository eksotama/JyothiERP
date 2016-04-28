Public Class CurrencyExchageRates
    Dim Isloading As Boolean = True
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
    Sub loadLists(Optional ByVal SQLStrTemp As String = "")
        Dim Sqlstr As String = ""
        If SQLStrTemp.Length = 0 Then
            'Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY grouproot) AS [S.NO],rtrim(GroupName) AS [ACCOUNT GROUP],rtrim(groupRoot) AS [UNDER GROUP], (case ISPRIMARY when 1 then 'Primary' ELSE  'SubGroup' END) AS [GROUP TYPE]  FROM accountgroups order by grouproot"
            'Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] , [CurrencyName] ,[CurrencyCode]  ,[CurrencySymbol],[ConRate],[Demicals]  FROM [CurrencyList] where currencycode<>'" & CompDetails.Currency & "'"
            Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] , [CurrencyName] ,[CurrencyCode]  ,[CurrencySymbol],[ConRate],[Demicals]  FROM [CurrencyList] "

        Else
            Sqlstr = SQLStrTemp
        End If
        Dim TempBS As New BindingSource
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 45

            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 350
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 120
            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 150
            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 150
            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 150

        Catch ex As Exception

        End Try
        Try
            Me.TxtList.Columns(0).ReadOnly = True
            Me.TxtList.Columns(1).ReadOnly = True
            Me.TxtList.Columns(2).ReadOnly = True
            Me.TxtList.Columns(4).ReadOnly = False
            Me.TxtList.Columns(5).ReadOnly = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentClick

    End Sub

    Private Sub TxtList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellValueChanged
        If Isloading = True Then Exit Sub
        If UCase(CompDetails.Currency) = UCase(TxtList.Item("currencycode", TxtList.CurrentRow.Index).Value) Then
            MsgBox("The Base Currency Is not posible to Modify")
            Exit Sub
        End If


        If TxtList.Item("ConRate", TxtList.CurrentRow.Index).Value.ToString.Length > 0 Then
            ExecuteSQLQuery("update currencylist set conrate=" & CDbl(TxtList.Item("ConRate", TxtList.CurrentRow.Index).Value) & " where CurrencyCode=N'" & TxtList.Item("CurrencyCode", TxtList.CurrentRow.Index).Value & "'")
        End If
        If TxtList.Item("Demicals", TxtList.CurrentRow.Index).Value.ToString.Length > 0 Then
            ExecuteSQLQuery("update currencylist set Demicals=" & CDbl(TxtList.Item("Demicals", TxtList.CurrentRow.Index).Value) & " where CurrencyCode=N'" & TxtList.Item("CurrencyCode", TxtList.CurrentRow.Index).Value & "'")
        End If


    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub CurrencyExchageRates_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CurrencyExchageRates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Isloading = True
        loadLists()
        Isloading = False
    End Sub

    Private Sub TxtFilterByCurName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilterByCurName.TextChanged
        If TxtFilterByCurName.Text.Length = 0 Then
            loadLists("SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] , [CurrencyName] ,[CurrencyCode]  ,[CurrencySymbol],[ConRate],[Demicals]  FROM [CurrencyList] where currencycode<>N'" & CompDetails.Currency & "'")
        Else
            loadLists("SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] , [CurrencyName] ,[CurrencyCode]  ,[CurrencySymbol],[ConRate],[Demicals]  FROM [CurrencyList] WHERE CurrencyName LIKE N'%" & TxtFilterByCurName.Text & "%' and currencycode<>N'" & CompDetails.Currency & "'")
        End If
    End Sub

    Private Sub TxtCurCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCurCode.TextChanged
        If TxtCurCode.Text.Length = 0 Then
            loadLists("SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] , [CurrencyName] ,[CurrencyCode]  ,[CurrencySymbol],[ConRate],[Demicals]  FROM [CurrencyList] where currencycode<>N'" & CompDetails.Currency & "'")
        Else
            loadLists("SELECT ROW_NUMBER() OVER (ORDER BY CurrencyName) AS [S.NO] , [CurrencyName] ,[CurrencyCode]  ,[CurrencySymbol],[ConRate],[Demicals]  FROM [CurrencyList] WHERE CurrencyCode LIKE N'%" & TxtCurCode.Text & "%' and currencycode<>N'" & CompDetails.Currency & "'")
        End If
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        loadLists()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        Printfuctions()
    End Sub
    Sub Printfuctions()

    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        Dim k As New CreateNewCurrency
        k.ShowDialog()
        loadLists()

    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        If UCase(CompDetails.Currency) = UCase(TxtList.Item("currencycode", TxtList.CurrentRow.Index).Value) Then
            MsgBox("The Base Currency Is not posible to Modify")
            Exit Sub
        End If
        If SQLIsFieldExists("select currency from ledgers where currency=N'" & TxtList.Item("currencycode", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Selected Currency is used in ledgers, It is not possible to delete....")
            Exit Sub
        Else
            If MsgBox("Do You want to delete the selected Currency?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete currencylist where currencycode=N'" & TxtList.Item("currencycode", TxtList.CurrentRow.Index).Value & "'")
                loadLists()
            End If
        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        If UCase(CompDetails.Currency) = UCase(TxtList.Item("currencycode", TxtList.CurrentRow.Index).Value) Then
            MsgBox("The Base Currency Is not posible to Modify")
            Exit Sub
        End If
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        If SQLIsFieldExists("select currency from ledgers where currency=N'" & TxtList.Item("currencycode", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Selected Currency is used in ledgers, It is not possible to Edit....")
            Exit Sub
        Else
            Dim k As New CreateNewCurrency(TxtList.Item("currencycode", TxtList.CurrentRow.Index).Value)
            k.ShowDialog()
            loadLists()
        End If
    End Sub
End Class