Imports System.Windows.Forms

Public Class tempform2

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(TxtList.Columns(CInt(TextBox1.Text)).ValueType.ToString)
    End Sub

    Private Sub tempform2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       

    End Sub
End Class
