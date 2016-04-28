Public Class ReportCommonFormWithOptions
    Dim reportname As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim SQLSting As String = ""
    Dim DatabaseTable As String = ""
    Sub New(ByVal crreportname As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        ' This call is required by the designer.
        InitializeComponent()
        reportname = crreportname
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub ReportCommonFormWithOptions_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ReportCommonForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadReport()
    End Sub
    Sub LoadReport()
        CrystalReportViewer1.ReportSource = reportname
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked = True Then
                reportname.ReportDefinition.Sections(3).SectionFormat.EnableSuppress = False
            Else
                reportname.ReportDefinition.Sections(3).SectionFormat.EnableSuppress = True
            End If
            CrystalReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try

    End Sub

   
End Class