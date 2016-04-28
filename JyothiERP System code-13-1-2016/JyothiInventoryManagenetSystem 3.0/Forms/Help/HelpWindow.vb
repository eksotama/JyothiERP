Public Class HelpWindow

    Private Sub HelpWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ERPInitializeObjects(Me)
        WebBrowser1.Navigate("E:\JyothiInventoryManagenetSystem 3.0\JyothiInventoryManagenetSystem 3.0\bin\Debug\1.html")
    End Sub
End Class