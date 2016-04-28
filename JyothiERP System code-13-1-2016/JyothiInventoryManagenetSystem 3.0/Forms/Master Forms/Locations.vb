Public Class Locations
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
#Region "Functions"
    Sub loaddATA()
        Dim Sqlstr As String = ""
        Sqlstr = "SELECT ROW_NUMBER() OVER (ORDER BY locationname) AS [S.NO],rtrim(locationname) AS [STOCK LOCATION],address as [Address], city as [City],contactperson as [Contact Person], contactno as [Contact No],email as [Email ID]  FROM STOCKLOCATIONS"
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
            Me.TxtList.Columns(0).Width = 35
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.TxtList.Columns(1).Width = 150

            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 220

            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 180


            Me.TxtList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(4).Width = 150

            Me.TxtList.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(5).Width = 150

            Me.TxtList.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(6).Width = 120

            Me.TxtList.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(7).Width = 120
        Catch ex As Exception

        End Try
      
    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem1.Click
        Dim k As New CreateStockLocations
        k.ShowDialog()
        loaddATA()
    End Sub

    Private Sub Locations_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loaddATA()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If APPUserRights.IsDeleteble = False Then
            MsgBox("The Delete Restricted by the Admin, No possible to Delete......, Contact Administator For Rights ", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If GetDefLocationName() = TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value Then
            MsgBox("These location is Primary location, It is not allowed to Delete ... ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   Users where LocationName=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Location is already in use, It is not possible to delete....", MsgBoxStyle.Critical)
            Exit Sub
        End If


        If SQLIsFieldExists("SELECT TOP 1 1 from   LedgerBook where Storename=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Location is already in use, It is not possible to delete....", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from   StockInvoiceDetails where Storename=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Location is already in use, It is not possible to delete....", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If SQLIsFieldExists("SELECT TOP 1 1 from   ledgers where Storename=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'") = True Then
            MsgBox("The Location is already in use, It is not possible to delete....", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Do you want to delete the Selected Location ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If MsgBox("All Stock items related to this location will be deleted, Do you want to continue", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from stocklocations where locationname=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'")
                ExecuteSQLQuery("delete from stockdbf where location=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'")
                ExecuteSQLQuery("delete from InvoiceSettings where location=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'")

            End If

            loaddATA()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem1.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub

        If SQLGetNumericFieldValue("select count(userid) as ct from users where islogin='True'", "ct") = 0 Then
            Dim CATGRM As New CreateStockLocations(TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value)
            If GetDefLocationName() = TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value Then
                CATGRM.TxtStockLocation.Enabled = False
            End If
            CATGRM.ShowDialog()
            CATGRM.Dispose()

            loaddATA()
        Else
            MsgBox("The some of users are in logged, The modification is not possible to prevent data...")
        End If
    End Sub




    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If TxtList.SelectedRows.Count > 0 Then
            Dim k As New CurrentStockItemReport(" where location=N'" & TxtList.Item("STOCK LOCATION", TxtList.CurrentRow.Index).Value & "'")
            Me.Cursor = Cursors.WaitCursor
            k.SuspendLayout()
            k.MdiParent = MainForm
            k.Dock = DockStyle.Fill
            k.Show()
            k.WindowState = FormWindowState.Maximized
            k.BringToFront()
            k.ResumeLayout()
            Me.Cursor = Cursors.Default
        End If

    End Sub

   
End Class