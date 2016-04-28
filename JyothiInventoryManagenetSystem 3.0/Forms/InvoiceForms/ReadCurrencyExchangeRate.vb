Imports System.Windows.Forms

Public Class ReadCurrencyExchangeRate

    Sub New(ByVal crate As Double, Optional ByVal curname As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ErpReadExchangeRate = crate
        txtcurrate.Text = ErpReadExchangeRate
        ImSlabel1.Text = "Exchange Rate for " & curname
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ErpReadExchangeRate = CDbl(txtcurrate.Text)
        Me.Close()
    End Sub

    Private Sub ReadCurrencyExchangeRate_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtcurrate.Focus()
    End Sub
End Class
