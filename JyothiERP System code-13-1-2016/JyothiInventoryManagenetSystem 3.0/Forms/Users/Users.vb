Imports System.Data.SqlClient

Public Class Users
    Dim Sqlstr As String = ""
    Dim IslOaded As Boolean = False

#Region "Functions"
    Sub LoadSuppliersList(Optional ByVal sqlText As String = "")
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor

        Sqlstr = "SELECT  ROW_NUMBER() OVER (ORDER BY UserName) AS [S.NO], [UserName] as [Employee Name],[UserID] as [User ID],UserDepartment as [Department],(case [UserType] when 1 then 'Admin' ELSE  'User' END) as [User Type] ,[UserEmailID] as [Email ID] from users "
        If sqlText.Length > 0 Then
            Sqlstr = Sqlstr & sqlText
        End If

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 55
            Me.TxtList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(1).Width = 150
            Me.TxtList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(2).Width = 250

            Me.TxtList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(3).Width = 250

        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, NewToolStripMenuItem.Click
        If SQLIsFieldExists("select EmpName from Employees where isactive=1 and isdelete=0 and empname not in (select UserName from users)") = True Then
            Dim k As New CreateNewUser
            k.ShowDialog()
            LoadSuppliersList()
        Else
            MsgBox("There are No Employees, Please Create the Employee.....")
        End If

    End Sub

    Private Sub Users_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub StockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadSuppliersList()
        IslOaded = True
    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub TxtList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.RowEnter
        On Error Resume Next
        If SQLGetBooleanFieldValue("SELECT ISACTIVE FROM users WHERE UserName=N'" & TxtList.Item("Employee Name", e.RowIndex).Value & "'", "ISACTIVE") = False Then
            btnActivate.Text = "ACTIVATE"
        Else
            btnActivate.Text = "DEACTIVATE"
        End If

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click, ACTIVATEToolStripMenuItem.Click
        If IslOaded = False Then Exit Sub
        If btnActivate.Text = "Activate" Then
            If MsgBox("Do you want to Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE users SET ISACTIVE='True' WHERE UserName=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'")
                btnActivate.Text = "DEACTIVATE"
                TxtList.Focus()
            End If
        Else
            If MsgBox("Do you want to De-Activate the selected Account..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE users SET ISACTIVE='False' WHERE UserName=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'")
                btnActivate.Text = "ACTIVATE"
                TxtList.Focus()
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, DeleteToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the User Name to delete...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do You want to Delete The User Account ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("Delete from users where username=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'")
            LoadSuppliersList()
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click, EditToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If IsTrailApplication = True Then
            If SQLGetNumericFieldValue("select count(*) as tot from users", "tot") > 3 Then
                MsgBox("The 2 Users only for trail version....", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        If SQLGetBooleanFieldValue("SELECT ISACTIVE FROM users WHERE UserName=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE") = False Then
            MsgBox("This Account is In-Active...., Edit is not possible....")
            Exit Sub
        End If
        Dim k As New CreateNewUser(TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value)
        k.TxtUserID.Enabled = False
        k.ShowDialog()
        LoadSuppliersList()
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        LoadSuppliersList()
    End Sub


    Private Sub TxtLedgerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLedgerName.TextChanged
        If TxtLedgerName.Text.Length = 0 Then
            LoadSuppliersList()
        Else
            LoadSuppliersList(" where  username LIKE N'%" & TxtLedgerName.Text & "%'")
        End If
    End Sub

    Private Sub BtnRights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRights.Click, RIGHTSToolStripMenuItem.Click
        If TxtList.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If SQLGetBooleanFieldValue("SELECT ISACTIVE FROM users WHERE UserName=N'" & TxtList.Item("Employee Name", TxtList.CurrentRow.Index).Value & "'", "ISACTIVE") = False Then
            MsgBox("This Account is In-Active...., Edit is not possible....")
            Exit Sub
        End If
        Dim k As New UserRights(TxtList.Item("User ID", TxtList.CurrentRow.Index).Value)
        k.ShowDialog()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click, PrintToolStripMenuItem.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If Sqlstr.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(Sqlstr, cnn)
        dscmd.Fill(ds, "Users")
        cnn.Close()
        Dim objRpt As New UserCrReport
        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "USERS ACCOUNTS"
        Else
            CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "USERS ACCOUNTS"

        End If
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub
End Class