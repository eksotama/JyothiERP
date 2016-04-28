Imports System.Windows.Forms

Public Class changeunitdecimals

    Dim Predecimals As Integer = 0
    Sub New(ByVal unitname As String)

        ' This call is required by the designer.
        InitializeComponent()
        TxtUnitName.Text = unitname
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub changeunitdecimals_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub changeunitdecimals_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtDecimals.Text = SQLGetNumericFieldValue("select Decimals from Stockunits where unitname=N'" & TxtUnitName.Text & "'", "Decimals")
        Predecimals = CInt(TxtDecimals.Text)
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If Predecimals > CInt(TxtDecimals.Text) Then
            If MsgBox("The Decimals are reduced , Do you want to Continuee....  ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        ExecuteSQLQuery("update stockunits set decimals=" & CInt(TxtDecimals.Text) & " where unitname=N'" & TxtUnitName.Text & "'")
        Me.Close()
    End Sub
End Class
