Imports System.Data.SqlClient

Public Class empsalaryincrements
    Dim IsEditMode As Boolean = False
    Dim isSaved As Boolean = True
    Dim SqlStr As String = ""
    Dim OpenedTranscode As Double = 0

    Private Sub empsalaryincrements_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub empsalaryincrements_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDefs()
    End Sub
    Sub LoadDefs()
        TxtVhNo.Text = "1"
        TxtDate.Value = Today
        TxtList.Rows.Clear()
        LoadDataIntoComboBox("SELECT DISTINCT teamname from employees ", txtTeamname, "teamname", "*All")
        LoadDataIntoComboBox("SELECT DISTINCT DepName from employees ", TxtDepartment, "DepName", "*All")
        LoadDataIntoComboBox("SELECT DISTINCT Designation from employees ", TxtDesignation, "Designation", "*All")
        TxtTotal.Text = "0"
        isSaved = True
        IsEditMode = False
    End Sub

    
    Sub LoadEmployees(ByVal whereSqlstr As String)
        SqlStr = "SELECT EmpID, empname , basicsalary ,0 as [Increment], basicsalary as [NewSalary] from employees where IsDelete=0 "
        SqlStr = SqlStr & whereSqlstr
        TxtList.Rows.Clear()
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = SqlStr
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            Dim i As Integer = 0
            While Sreader.Read()
                i = TxtList.Rows.Add()
                TxtList.Item("tempid", i).Value = Sreader("empid")
                TxtList.Item("tempname", i).Value = Sreader("empname")
                TxtList.Item("tcurrentsalary", i).Value = Sreader("basicsalary")
                TxtList.Item("tincrement", i).Value = Sreader("Increment")
                TxtList.Item("tnewsalary", i).Value = Sreader("NewSalary")
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        isSaved = False
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If MsgBox("Do you want to Apply ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i As Integer = 0 To TxtList.RowCount - 1
                TxtList.Item("tincrement", i).Value = CDbl(TxtList.Item("tcurrentsalary", i).Value) * CDbl(TxtPer.Text) / 100
                TxtList.Item("tnewsalary", i).Value = CDbl(TxtList.Item("tcurrentsalary", i).Value) + CDbl(TxtList.Item("tincrement", i).Value)
            Next
            FindTotals()
        End If
    End Sub

    Private Sub TxtList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles TxtList.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Dim cell As DataGridViewCell = TxtList.Rows(e.RowIndex).Cells(e.ColumnIndex)
            TxtList.CurrentCell = cell
            Me.ContextMenuStrip1.Show(Cursor.Position)
            FindTotals()
        End If
    End Sub

    Private Sub TxtList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellEndEdit

    End Sub

    Private Sub TxtList_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles TxtList.CellValidating
        On Error Resume Next
        If e.ColumnIndex = TxtList.Columns("tincrement").Index Then
            If IsNumeric(e.FormattedValue) = False Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        ElseIf e.ColumnIndex = TxtList.Columns("tnewsalary").Index Then
            If IsNumeric(e.FormattedValue) = False Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If

        End If

    End Sub

    Private Sub TxtList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellValueChanged
        On Error Resume Next
        If e.ColumnIndex = TxtList.Columns("tincrement").Index Then
            TxtList.Item("tnewsalary", e.RowIndex).Value = CDbl(TxtList.Item("tcurrentsalary", e.RowIndex).Value) + CDbl(TxtList.Item("tincrement", e.RowIndex).Value)
            FindTotals()
        ElseIf e.ColumnIndex = TxtList.Columns("tnewsalary").Index Then
            TxtList.Item("tincrement", e.RowIndex).Value = CDbl(TxtList.Item("tnewsalary", e.RowIndex).Value) - CDbl(TxtList.Item("tcurrentsalary", e.RowIndex).Value)
            FindTotals()
        End If
    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

   

    

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
    Sub FindTotals()
        Dim tot As Double = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            tot = tot + CDbl(TxtList.Item("tincrement", i).Value)
        Next
        TxtTotal.Text = FormatNumber(tot, ErpDecimalPlaces)
        isSaved = False
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        TxtList.Rows.RemoveAt(TxtList.CurrentRow.Index)
        FindTotals()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If isSaved = False Then
            If MsgBox("Current voucher is not save, Do you want to create New ?", MsgBoxStyle.YesNo) = vbYes Then
                LoadDefs()
            End If
        Else
            LoadDefs()

        End If

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If IsEditMode = True Then
            If MsgBox("Do you want to Delete ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from empsalaryincrements where transcode=" & OpenedTranscode)
                UpdateSalaries()
                LoadDefs()
            End If

        End If
    End Sub

    Private Sub BtnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSAVE.Click
        If TxtList.RowCount = 0 Then
            MsgBox("Please Select the Employees and enter the increment ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtVhNo.Text.Length = 0 Then
            MsgBox("Please Enter the Voucher No        ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If IsEditMode = True Then
            ExecuteSQLQuery("delete from empsalaryincrements where transcode=" & OpenedTranscode)
        Else
            OpenedTranscode = GetAndSetIDCode(EnumIDType.TransCode)
        End If
        SqlStr = "INSERT INTO [empsalaryincrements] ([EmpName],[oldSalary],[NewSalary],[Increment],[Datefrom],[datefromvalue],[transcode],[sno],[Vhno],[Transdate],[Transdatevalue],[EMPID])     VALUES  " _
            & " (@EmpName,@oldSalary,@NewSalary,@Increment,@Datefrom,@datefromvalue,@transcode,@sno,@Vhno,@Transdate,@Transdatevalue,@EMPID) "
        Dim Sno As Long = 0
        For i As Integer = 0 To TxtList.RowCount - 1
            Sno = SQLGetNumericFieldValue("select max(sno) as tot from empsalaryincrements ", "tot")
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("empname", TxtList.Item("tempname", i).Value)
                .AddWithValue("empid", TxtList.Item("tempid", i).Value)
                .AddWithValue("oldSalary", TxtList.Item("tcurrentsalary", i).Value)
                .AddWithValue("NewSalary", TxtList.Item("tnewsalary", i).Value)
                .AddWithValue("Increment", TxtList.Item("tincrement", i).Value)
                .AddWithValue("Datefrom", TxtDate.Value)
                .AddWithValue("datefromvalue", TxtDate.Value.Date.ToOADate)
                .AddWithValue("transcode", OpenedTranscode)
                .AddWithValue("sno", Sno)
                .AddWithValue("Vhno", TxtVhNo.Text)
                .AddWithValue("Transdate", TxtDate.Value)
                .AddWithValue("Transdatevalue", TxtDate.Value.ToOADate)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Next
        UpdateSalaries()
        LoadDefs()
    End Sub
    Sub UpdateSalaries()



        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select empname from employees"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                ApplyNewSalary(Sreader("empname"))
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub
    Sub ApplyNewSalary(ByVal empname As String)
        Dim SqlConn As New SqlClient.SqlConnection
        Dim sqlstr As String = "SELECT     TOP 1 Transdatevalue, NewSalary    FROM empsalaryincrements WHERE     (EmpName = N'" & empname & "') ORDER BY Transdatevalue DESC"
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = sqlstr
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                ExecuteSQLQuery("UPDATE EMPLOYEES SET BASICSALARY=" & CDbl(Sreader("NEWSALARY")) & " WHERE EMPNAME=N'" & empname & "'")
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub

    Sub LoadvhData(ByVal TCODE)
        Dim SqlConn As New SqlClient.SqlConnection
        LoadDefs()
        Dim I As Integer = 0
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "SELECT * FROM  empsalaryincrements where transcode=" & TCODE
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtVhNo.Text = Sreader("Vhno")
                TxtDate.Value = Sreader("Transdate")
                I = TxtList.Rows.Add
                TxtList.Item("TEMPNAME", I).Value = Sreader("EmpName")
                TxtList.Item("TEMPID", I).Value = Sreader("EMPID")
                TxtList.Item("TCURRENTSALARY", I).Value = Sreader("oldSalary")
                TxtList.Item("TIncrement", I).Value = Sreader("Increment")
                TxtList.Item("TNewSalary", I).Value = Sreader("NewSalary")
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        IsEditMode = True
        FindTotals()
        OpenedTranscode = TCODE
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        EmpincrementTranscode = 0
        Dim frm As New SelectIncrementVoucher
        frm.ShowDialog()
        If EmpincrementTranscode <> 0 Then
            LoadvhData(EmpincrementTranscode)
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If isSaved = False Then
            If MsgBox("Do you want to Close ?       ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        If IsEditMode = True Then
            If TxtList.RowCount = 0 Then Exit Sub

            Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet
            Dim cnn As SqlConnection
            cnn = New SqlConnection(ConnectionStrinG)
            cnn.Open()
            Dim dscmd As New SqlDataAdapter("select * from empsalaryincrements WHERE TRANSCODE=" & OpenedTranscode, cnn)
            dscmd.Fill(ds, "empsalaryincrements")
            cnn.Close()

            Dim objRpt As New EmpSalaryIncrementReports
            SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
            If PrintOptionsforCR.IsPrintHeader = False Then
                CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
                CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
                CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE DETAILS"
            Else
                CType(objRpt.Section2.ReportObjects.Item("txtperiod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEE DETAILS"

            End If
            objRpt.SetDataSource(ds)
            Dim FRM As New ReportCommonForm(objRpt)
            FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            Me.Cursor = Cursors.Default
            FRM.ShowDialog()
            FRM.Dispose()
            objRpt.Dispose()
            ds.Dispose()
        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        If MsgBox("Do yo want to Load Employees ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If TxtDepartment.Text = "*All" Then
            LoadEmployees(" ")
        Else
            LoadEmployees(" and depname=N'" & TxtDepartment.Text & "' ")
        End If
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        If MsgBox("Do yo want to Load Employees ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


        If txtTeamname.Text = "*All" Then
            LoadEmployees(" ")
        Else
            LoadEmployees(" and teamname=N'" & txtTeamname.Text & "' ")
        End If
    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        If MsgBox("Do yo want to Load Employees ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If TxtDesignation.Text = "*All" Then
            LoadEmployees(" ")
        Else
            LoadEmployees(" and Designation=N'" & TxtDesignation.Text & "' ")
        End If
    End Sub
End Class