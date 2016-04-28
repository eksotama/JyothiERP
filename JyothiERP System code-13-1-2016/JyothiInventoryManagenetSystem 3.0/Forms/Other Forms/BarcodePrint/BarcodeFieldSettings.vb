Imports System.Windows.Forms
Imports System.Drawing
Public Class BarcodeFieldSettings
    Dim SchemeName As String = ""
    Sub New(schname As String)

        ' This call is required by the designer.
        InitializeComponent()
        SchemeName = schname
        ' Add any initialization after the InitializeComponent() call.

    End Sub
  
    Private Sub ImsButton6_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton6.Click

        Dim fontstyle As Integer = 0
        If TxtFLStyleU.Checked = True Then
            If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                fontstyle = 7
            ElseIf TxtFLStyleB.Checked = True Then
                fontstyle = 5
            ElseIf TxtFLSytleI.Checked = True Then
                fontstyle = 6
            Else
                fontstyle = 3
            End If
        Else
            If TxtFLStyleB.Checked = True And TxtFLSytleI.Checked = True Then
                fontstyle = 4
            ElseIf TxtFLStyleB.Checked = True Then
                fontstyle = 1
            ElseIf TxtFLSytleI.Checked = True Then
                fontstyle = 2
            Else
                fontstyle = 8
            End If
        End If
        If MsgBox("Do you want to Save changes                 ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim Sqlstr As String = ""
            If TxtFieldNames.Text.ToUpper = "barcode".ToUpper Then
                If IsShowFiled.Checked = True Then
                    Sqlstr = "UPDATE [BarcodeFieldSettings]   SET [Lwidth] =" & CInt(TxtFLWidth.Value) & " ,[LHeight] =" & CInt(TxtFLHeight.Value) & ",[LTop] =" & CInt(TxtFLtop.Value) & " ,[Lleft] =" & CInt(TxtFLLeft.Value) & ",[LText] =N'" & txtFLtext.Text & "' ,[Fontname] =N'" & TxtFLFont.Text & "',[fontsize] =" & CInt(TxtFLFontSize.Text) & " ,[fontstyle] =" & fontstyle & " ,[fontcolor] =N'" & TxtFLFontColor.Text & "' ,[Align] =N'" & TxtFLAlign.Text & "' ,[IsVisible] =1 ,[backcolor] =N'" & TxtFLBackColor.Text & "',Lcase=N'" & TxtCase.Text & "',Rotate=N'" & TxtBarcodeRotation.Text & "',IsComaSep=" & IIf(IsCommaSep.Checked = True, 1, 0) & " WHERE schemename=N'" & SchemeName & "' and FiledName=N'" & TxtFieldNames.Text & "'"
                Else
                    Sqlstr = "UPDATE [BarcodeFieldSettings]   SET [Lwidth] =" & CInt(TxtFLWidth.Value) & " ,[LHeight] =" & CInt(TxtFLHeight.Value) & ",[LTop] =" & CInt(TxtFLtop.Value) & " ,[Lleft] =" & CInt(TxtFLLeft.Value) & ",[LText] =N'" & txtFLtext.Text & "' ,[Fontname] =N'" & TxtFLFont.Text & "',[fontsize] =" & CInt(TxtFLFontSize.Text) & " ,[fontstyle] =" & fontstyle & " ,[fontcolor] =N'" & TxtFLFontColor.Text & "' ,[Align] =N'" & TxtFLAlign.Text & "' ,[IsVisible] =0 ,[backcolor] =N'" & TxtFLBackColor.Text & "',Lcase=N'" & TxtCase.Text & "',Rotate=N'" & TxtBarcodeRotation.Text & "',IsComaSep=" & IIf(IsCommaSep.Checked = True, 1, 0) & "  WHERE schemename=N'" & SchemeName & "' and FiledName=N'" & TxtFieldNames.Text & "'"
                End If
            Else
                If IsShowFiled.Checked = True Then
                    Sqlstr = "UPDATE [BarcodeFieldSettings]   SET [Lwidth] =" & CInt(TxtFLWidth.Value) & " ,[LHeight] =" & CInt(TxtFLHeight.Value) & ",[LTop] =" & CInt(TxtFLtop.Value) & " ,[Lleft] =" & CInt(TxtFLLeft.Value) & ",[LText] =N'" & txtFLtext.Text & "' ,[Fontname] =N'" & TxtFLFont.Text & "',[fontsize] =" & CInt(TxtFLFontSize.Text) & " ,[fontstyle] =" & fontstyle & " ,[fontcolor] =N'" & TxtFLFontColor.Text & "' ,[Align] =N'" & TxtFLAlign.Text & "' ,[IsVisible] =1 ,[backcolor] =N'" & TxtFLBackColor.Text & "',Lcase=N'" & TxtCase.Text & "',Rotate='',IsComaSep=" & IIf(IsCommaSep.Checked = True, 1, 0) & "  WHERE schemename=N'" & SchemeName & "' and FiledName=N'" & TxtFieldNames.Text & "'"
                Else
                    Sqlstr = "UPDATE [BarcodeFieldSettings]   SET [Lwidth] =" & CInt(TxtFLWidth.Value) & " ,[LHeight] =" & CInt(TxtFLHeight.Value) & ",[LTop] =" & CInt(TxtFLtop.Value) & " ,[Lleft] =" & CInt(TxtFLLeft.Value) & ",[LText] =N'" & txtFLtext.Text & "' ,[Fontname] =N'" & TxtFLFont.Text & "',[fontsize] =" & CInt(TxtFLFontSize.Text) & " ,[fontstyle] =" & fontstyle & " ,[fontcolor] =N'" & TxtFLFontColor.Text & "' ,[Align] =N'" & TxtFLAlign.Text & "' ,[IsVisible] =0 ,[backcolor] =N'" & TxtFLBackColor.Text & "',Lcase=N'" & TxtCase.Text & "',Rotate='',IsComaSep=" & IIf(IsCommaSep.Checked = True, 1, 0) & "  WHERE schemename=N'" & SchemeName & "' and FiledName=N'" & TxtFieldNames.Text & "'"
                End If
            End If
           
            ExecuteSQLQuery(Sqlstr)

        End If
    End Sub

    Private Sub ImsButton5_Click(sender As System.Object, e As System.EventArgs) Handles ImsButton5.Click
       Me.Close()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If txtFont.ShowDialog() Then
            TxtFLSample.Font = txtFont.Font
            TxtFLSample.ForeColor = txtFont.Color
            TxtFLFont.Text = txtFont.Font.Name
            If txtFont.Font.Underline = True Then
                TxtFLStyleU.Checked = True
            Else
                TxtFLStyleU.Checked = False
            End If
            If txtFont.Font.Bold = True Then
                TxtFLStyleB.Checked = True
            Else
                TxtFLStyleB.Checked = False
            End If
            If txtFont.Font.Italic = True Then
                TxtFLSytleI.Checked = True
            Else
                TxtFLSytleI.Checked = False
            End If
            TxtFLFontSize.Text = txtFont.Font.Size
            TxtFLFontColor.Text = txtFont.Color.Name.ToString

            txtFLtext.Font = txtFont.Font

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ColorDialog1.SolidColorOnly = True

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                TxtFLBackColor.Text = ColorDialog1.Color.Name
                TxtFLBackColor.BackColor = Color.FromName(ColorDialog1.Color.Name)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TxtFieldNames_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtFieldNames.SelectedIndexChanged
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select * from BarcodeFieldSettings where Schemename=N'" & SchemeName & "' and FiledName=N'" & TxtFieldNames.Text & "'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            While Sreader.Read()
                If Sreader("IsVisible") = True Then
                    IsShowFiled.Checked = True
                Else
                    IsShowFiled.Checked = False
                End If
                txtFLtext.Text = Sreader("LText")
                TxtFLtop.Value = Sreader("LTop")
                TxtFLLeft.Value = Sreader("Lleft")
                TxtFLWidth.Value = Sreader("Lwidth")
                TxtFLHeight.Value = Sreader("LHeight")

                TxtFLFont.Text = Sreader("fontname")
                TxtFLFontSize.Text = Sreader("fontsize")
                TxtFLFontColor.Text = Sreader("fontcolor")
                TxtFLAlign.Text = Sreader("Align")
                TxtFLBackColor.Text = Sreader("backcolor")
                IsCommaSep.Checked = Sreader("IsComaSep")

                Try
                    TxtFLBackColor.BackColor = Color.FromName(Sreader("backcolor"))
                Catch ex As Exception

                End Try
                If Sreader("fontstyle") = 1 Then
                    TxtFLStyleB.Checked = True
                    TxtFLStyleU.Checked = False
                    TxtFLSytleI.Checked = False
                ElseIf Sreader("fontstyle") = 2 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 3 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 4 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = False
                ElseIf Sreader("fontstyle") = 5 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 6 Then
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = True
                ElseIf Sreader("fontstyle") = 7 Then
                    TxtFLStyleB.Checked = True
                    TxtFLSytleI.Checked = True
                    TxtFLStyleU.Checked = True
                Else
                    TxtFLStyleB.Checked = False
                    TxtFLSytleI.Checked = False
                    TxtFLStyleU.Checked = False
                End If
                Try
                    TxtCase.Text = Sreader("Lcase").ToString
                Catch ex As Exception

                End Try
                TxtBarcodeRotation.Text = Sreader("Rotate").ToString
            End While
            Sreader.Close()
            Sreader = Nothing
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
        End Try
        txtFLtext.Font = TxtFLSample.Font
        If TxtFieldNames.Text = "Barcode" Then
            lblbarcoderotation.Visible = True
            TxtBarcodeRotation.Visible = True
        Else
            lblbarcoderotation.Visible = False
            TxtBarcodeRotation.Visible = False

        End If
    End Sub

    

    Private Sub BarcodeFieldSettings_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtFieldNames.SelectedIndex = 0
        TxtBarcodeRotation.DataSource = System.[Enum].GetNames(GetType(RotateFlipType))

    End Sub
End Class
