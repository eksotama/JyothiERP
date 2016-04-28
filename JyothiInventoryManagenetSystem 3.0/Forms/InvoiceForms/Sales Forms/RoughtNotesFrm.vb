Imports System.Windows.Forms
Imports System.Drawing.Printing

Public Class RoughtNotesFrm


    Private Sub Label1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown, Label9.MouseDown, Label8.MouseDown, Label7.MouseDown, Label6.MouseDown, Label5.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown, Label16.MouseDown, Label15.MouseDown, Label14.MouseDown, Label12.MouseDown, Label11.MouseDown, Label10.MouseDown, Label19.MouseDown, Label18.MouseDown, Label17.MouseDown, Label13.MouseDown, Label20.MouseDown
        sender.BorderStyle = BorderStyle.Fixed3D

    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp, Label9.MouseUp, Label8.MouseUp, Label7.MouseUp, Label6.MouseUp, Label5.MouseUp, Label4.MouseUp, Label3.MouseUp, Label2.MouseUp, Label16.MouseUp, Label15.MouseUp, Label14.MouseUp, Label12.MouseUp, Label11.MouseUp, Label10.MouseUp, Label19.MouseUp, Label18.MouseUp, Label17.MouseUp, Label13.MouseUp, Label20.MouseUp
        sender.BorderStyle = BorderStyle.FixedSingle

        If sender.TEXT.ToUPPER = "B" Then
            SendKeys.Send("{BACKSPACE}")
        ElseIf sender.TEXT.ToUPPER = "ENTER" Then
            SendKeys.Send("{ENTER}")
        ElseIf sender.TEXT.ToUPPER = "TAB" Then
            SendKeys.Send("{TAB}")
        ElseIf sender.TEXT.ToUPPER = "DEL" Then
            SendKeys.Send("{DELETE}")
        ElseIf sender.TEXT.ToUPPER = "L" Then
            SendKeys.Send("{LEFT}")
        ElseIf sender.TEXT.ToUPPER = "R" Then
            SendKeys.Send("{RIGHT}")
        ElseIf sender.TEXT.ToUPPER = "D" Then
            SendKeys.Send("{DOWN}")
        ElseIf sender.TEXT.ToUPPER = "U" Then
            SendKeys.Send("{UP}")
        ElseIf sender.TEXT.ToUPPER = "-" Then
            SendKeys.Send("-")

        Else
            SendKeys.Send(sender.text)
        End If
    End Sub

    Private Sub txtlist_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtlist.CellClick

        'SendKeys.Send("{RIGHT}")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtlist.CellContentClick

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtlist.CellEndEdit
        If e.ColumnIndex = 3 Then
            Dim CalValue As Double = 0
            Dim StrSql As String = "select (" & txtlist.Item(3, txtlist.CurrentRow.Index).Value & ")  as Val from DuMMY"
            CalValue = FormatNumber(SQLGetNumericFieldValueForNumericTextBox(StrSql, "Val", 0, False), 2, , , TriState.False)
            txtlist.Item(3, txtlist.CurrentRow.Index).Value = CalValue
        End If
        If e.ColumnIndex = 1 Then
            Dim str As String = ""
            Dim bcode As String = txtlist.Item(1, txtlist.CurrentRow.Index).Value
            str = SQLGetStringFieldValue("select stockname from stockdbf where custbarcode=N'" & bcode & "' and location=N'" & GetLocation() & "'", "stockname")
            If str.Length > 0 Then
                txtlist.Item(1, txtlist.CurrentRow.Index).Value = str
                str = SQLGetNumericFieldValue("select stockdrp from stockdbf where custbarcode=N'" & bcode & "' and location=N'" & GetLocation() & "'", "stockdrp")
                If txtlist.Item(3, txtlist.CurrentRow.Index).Value = Nothing Then
                    txtlist.Item(3, txtlist.CurrentRow.Index).Value = str
                ElseIf IsNumeric(txtlist.Item(3, txtlist.CurrentRow.Index).Value) = False Then
                    txtlist.Item(3, txtlist.CurrentRow.Index).Value = str
                End If
            Else
                str = SQLGetStringFieldValue("select stockname from stockdbf where stockcode=N'" & bcode & "' and location=N'" & GetLocation() & "'", "stockname")
                If str.Length > 0 Then
                    txtlist.Item(1, txtlist.CurrentRow.Index).Value = str
                    str = SQLGetNumericFieldValue("select stockdrp from stockdbf where stockcode=N'" & bcode & "' and location=N'" & GetLocation() & "'", "stockdrp")
                   If txtlist.Item(3, txtlist.CurrentRow.Index).Value = Nothing Then
                        txtlist.Item(3, txtlist.CurrentRow.Index).Value = str
                    ElseIf IsNumeric(txtlist.Item(3, txtlist.CurrentRow.Index).Value) = False Then
                        txtlist.Item(3, txtlist.CurrentRow.Index).Value = str
                    End If

                End If
            End If

        End If
        findtotals()
    End Sub
    Sub findtotals()
        Dim tot As Double = 0
        For i As Integer = 0 To txtlist.RowCount - 1
            Try
                tot = tot + CDbl(txtlist.Item(3, i).Value)
            Catch ex As Exception

            End Try
        Next
        TxtTotal.Text = "TOTAL: " & FormatNumber(tot, 2)
    End Sub
    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click, CLoseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnClear.Click, ClearToolStripMenuItem.Click
        txtlist.Rows.Clear()
        Try
            txtlist.CurrentCell = txtlist.Item(3, 0)
        Catch ex As Exception

        End Try
        txtlist.Focus()
    End Sub

    Private Sub PrtDoc_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PrtDoc.BeginPrint

        PrtDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 20 * txtlist.RowCount + 150)
        PrtDoc.DefaultPageSettings.Landscape = False
        PrtDoc.DefaultPageSettings.Margins.Left = 2
        PrtDoc.DefaultPageSettings.Margins.Right = 2
        PrtDoc.DefaultPageSettings.Margins.Top = 1
        PrtDoc.DefaultPageSettings.Margins.Bottom = 10
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrtDoc.PrintPage
        Dim drawFormat As New StringFormat
        Dim drawFont As Font = New Font("Arial", 11, FontStyle.Regular)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim top As Integer = 0
        Dim hgap As Integer = 19
        top = 25
        Dim sno As Integer = 1

        For i As Integer = 0 To txtlist.RowCount - 1
            Dim ss As String = ""
            Try
                ss = FormatNumber(CDbl(txtlist.Item(3, i).Value), 2)
            Catch ex As Exception
                ss = 0
            End Try
            Try
                If CDbl(ss) <> 0 Then
                    drawFormat.Alignment = StringAlignment.Near
                    Dim rect1 As New Rectangle(2, top, 30, hgap)
                    e.Graphics.DrawString(sno, drawFont, drawBrush, rect1, drawFormat)
                    Dim linestr As String = ""
                    Try
                        linestr = txtlist.Item(1, i).Value.ToString
                    Catch ex3 As Exception
                        linestr = ""
                    End Try
                    Try
                        linestr = linestr + " " + txtlist.Item(2, i).Value
                    Catch ex4 As Exception

                    End Try
                    'linestr = IIf(txtlist.Item(1, i).Value = Nothing, "", txtlist.Item(1, i).Value.ToString) + " " + IIf(txtlist.Item(2, i).Value = Nothing, "", txtlist.Item(2, i).Value.ToString)
                    Dim rect5 As New Rectangle(30, top, 200, hgap)
                    e.Graphics.DrawString(linestr, drawFont, drawBrush, rect5, drawFormat)
                    Dim rect2 As New Rectangle(200, top, 70, hgap)
                    drawFormat.Alignment = StringAlignment.Far

                    e.Graphics.DrawString(ss, drawFont, drawBrush, rect2, drawFormat)
                    sno = sno + 1
                    top = top + hgap
                End If
            Catch ex As Exception

            End Try

        Next
        top = top + 7
        e.Graphics.DrawLine(Pens.Black, 0, top, 280, top)
        top = top + hgap + 10
        Dim rect3 As New Rectangle(0, top, 270, 30)
        drawFormat.Alignment = StringAlignment.Far
        Dim drawFont1 As Font = New Font("Arial", 12, FontStyle.Bold)
        e.Graphics.DrawString(TxtTotal.Text, drawFont1, drawBrush, rect3, drawFormat)

        top = top + hgap + 70
        Dim rect6 As New Rectangle(20, top, 70, 25)
        e.Graphics.DrawString(".", drawFont1, drawBrush, rect6, drawFormat)
    End Sub

    Private Sub ImsButton3_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton3.Click, PrintToolStripMenuItem.Click
        PrtDoc.Print()
    End Sub

    Private Sub txtlist_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles txtlist.CellEnter
        If e.ColumnIndex <> 3 Then
            SendKeys.Send("{f2}")
        Else

        End If
    End Sub

   

    Private Sub txtlist_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles txtlist.CellValidating
       
    End Sub

    Private Sub txtlist_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles txtlist.DataError

    End Sub

   

    

    Private Sub txtlist_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles txtlist.RowsAdded
        arrageserials()
    End Sub

    Private Sub txtlist_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles txtlist.RowsRemoved
        findtotals()
        arrageserials()
    End Sub
    Sub arrageserials()
        For i As Integer = 1 To txtlist.RowCount
            txtlist.Rows(i - 1).HeaderCell.Value = i.ToString
            txtlist.Item(0, i - 1).Value = i
        Next
    End Sub

    Private Sub RoughtNotesFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtlist.Focus()
    End Sub

    Private Sub RoughtNotesFrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            txtlist.CurrentCell = txtlist.Item(3, 0)
        Catch ex As Exception

        End Try
    End Sub

   
End Class
