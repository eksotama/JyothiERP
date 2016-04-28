Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class ReportCommonForm

    Dim reportname As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim SQLSting As String = ""
    Dim DatabaseTable As String = ""
    Sub New(ByVal crreportname As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        ' This call is required by the designer.
        InitializeComponent()
        reportname = crreportname
        ' Add any initialization after the InitializeComponent() call.
        '  myDataSet.EnforceConstraints = False
    End Sub

    Private Sub ReportCommonForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

   

    Private Sub ReportCommonForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        reportname.Dispose()
        CrystalReportViewer1.Dispose()
    End Sub

    Private Sub ReportCommonForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadReport()
    End Sub
    Public Sub LoadReport()
        CrystalReportViewer1.ReportSource = reportname
        CrystalReportViewer1.Refresh()
    End Sub
End Class
