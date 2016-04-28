Public Class IMSColorBox
    Property ColorName() As String
        Get
            Try
                Return Me.Items(Me.SelectedIndex).ToString
            Catch ex As Exception
                Return "White"
            End Try

        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Private Sub ColorBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        Dim g As Graphics = e.Graphics
        Dim rect As Rectangle = e.Bounds
        If (e.Index >= 0) Then
            Dim n As String = CType(sender, ComboBox).Items(e.Index).ToString
            Dim f As New Font("Arial", 11, FontStyle.Regular)
            Dim c As New Color
            c = Color.FromName(n)
            Dim b As New SolidBrush(c)
            g.DrawString(n, f, Brushes.Black, rect.X, rect.Top)
            g.FillRectangle(b, rect.X + 100, rect.Y + 5, rect.Width - 50, rect.Height - 1)

        End If
    End Sub
End Class
