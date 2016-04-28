Imports System.Data.SqlClient

Public Class AllowancesdeductionsSettings
    Dim Sqlstr As String = ""
    Dim PaySlipSettingType As String = ""
    Sub New(ByVal PaySliptype As String)

        ' This call is required by the designer.
        InitializeComponent()
        PaySlipSettingType = PaySliptype
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadData()

        Sqlstr = "select payname as [Pay Name],per as [Percentage],method as [Method],orderno as [Order No] from paytypes  where paytype='Allowances' and PayTypeGroup=N'" & PaySlipSettingType & "' order by orderno "
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Sqlstr = "select payname as [Pay Name],per as [Percentage],method as [Method],orderno as [Order No] from paytypes  where paytype='Deductions' and PayTypeGroup=N'" & PaySlipSettingType & "' order by orderno"
        Dim TempBS1 As New BindingSource
        With Me.TxtList1
            TempBS1.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS1
        End With

    End Sub

    Private Sub AllowancesdeductionsSettings_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub PaySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadData()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click, CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click, ImsButton4.Click
        Dim kfrm As New NewPayAddDeductions()
        If TxtList.RowCount = 0 Then
            kfrm.TxtName.Text = "Basic Salary"
            kfrm.TxtType.Text = "Allowances"
            kfrm.TxtName.Enabled = False
            kfrm.TxtType.Enabled = False
            kfrm.TxtPer.Enabled = False
            If kfrm.TxtMethod.Items.Count > 0 Then
                kfrm.TxtMethod.SelectedIndex = 0
            End If
            kfrm.TxtMethod.Enabled = False
            kfrm.IsBasicSalary = True
        End If
        kfrm.TxtType.Text = "Allowances"
        kfrm.PaySlipSettingGroup = PaySlipSettingType
        kfrm.ShowDialog()
        kfrm.Dispose()
        LoadData()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Dim kfrm As New NewPayAddDeductions()
        If TxtList.RowCount = 0 Then
            kfrm.TxtName.Text = "Basic Salary"
            kfrm.TxtType.Text = "Allowances"
            kfrm.TxtName.Enabled = False
            kfrm.TxtType.Enabled = False
            kfrm.TxtPer.Enabled = False
            If kfrm.TxtMethod.Items.Count > 0 Then
                kfrm.TxtMethod.SelectedIndex = 0
            End If
            kfrm.IsBasicSalary = True
            kfrm.TxtMethod.Enabled = False
        Else
            kfrm.TxtType.Text = "Deductions"
        End If

        kfrm.PaySlipSettingGroup = PaySlipSettingType
        kfrm.ShowDialog()
        kfrm.Dispose()
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click, ImsButton5.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        Dim kfrm As New NewPayAddDeductions(TxtList.Item("Pay Name", TxtList.CurrentRow.Index).Value)
        If TxtList.Item("Pay Name", TxtList.CurrentRow.Index).Value = "Basic Salary" Then
            kfrm.TxtName.Text = "Basic Salary"
            kfrm.TxtType.Text = "Allowances"
            kfrm.TxtName.Enabled = False
            kfrm.TxtType.Enabled = False
            kfrm.TxtPer.Enabled = False
            If kfrm.TxtMethod.Items.Count > 0 Then
                kfrm.TxtMethod.SelectedIndex = 0
            End If
            kfrm.TxtMethod.Enabled = False
        End If
        kfrm.PaySlipSettingGroup = PaySlipSettingType
        kfrm.ShowDialog()
        kfrm.Dispose()
        LoadData()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If TxtList1.RowCount = 0 Then Exit Sub
        If TxtList1.SelectedRows.Count = 0 Then Exit Sub
        Dim kfrm As New NewPayAddDeductions(TxtList1.Item("Pay Name", TxtList1.CurrentRow.Index).Value)
        kfrm.PaySlipSettingGroup = PaySlipSettingType
        kfrm.ShowDialog()
        kfrm.Dispose()
        LoadData()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to Delete the selected Row ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If TxtList.Item("Pay Name", TxtList.CurrentRow.Index).Value = "Basic Salary" Then
                If MsgBox("The Selected entry is Basic Salary , Do you want to Delete?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If

            End If
            ExecuteSQLQuery("delete from paytypes where payname=N'" & TxtList.Item("Pay Name", TxtList.CurrentRow.Index).Value & "' and PayTypeGroup=N'" & PaySlipSettingType & "'")
        End If
        LoadData()
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If TxtList1.RowCount = 0 Then Exit Sub
        If TxtList1.SelectedRows.Count = 0 Then Exit Sub
        If MsgBox("Do you want to Delete the selected Row ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("delete from paytypes where payname=N'" & TxtList1.Item("Pay Name", TxtList1.CurrentRow.Index).Value & "' and PayTypeGroup=N'" & PaySlipSettingType & "'")
        End If
        LoadData()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, PrintToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("select * from paytypes", cnn)
        dscmd.Fill(ds, "paytypes")
        cnn.Close()
        Dim objRpt As New AddDeductionPaytypeCrReport
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = TxtHeading.Text

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