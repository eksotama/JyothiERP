Imports System.Windows.Forms

Public Class BarcodeSettingsFrm

    Private Sub BarcodeSettingsFrm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub



    Private Sub BarcodeSettingsFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            TxtBarcodeLength.Value = SQLGetNumericFieldValue("select barcodelength from barcodesettings", "barcodelength")
        Catch ex As Exception
            TxtBarcodeLength.Value = 8
        End Try
        IsLeadingZeros.Text = IIf(SQLGetBooleanFieldValue("select Isreplacezeros from barcodesettings", "Isreplacezeros"), "YES", "NO")
        IsFixedLength.Text = SQLGetBooleanFieldValue("select FixedLength from barcodesettings", "FixedLength")
        IsAutoFill.Text = IIf(SQLGetBooleanFieldValue("select Isautofill from barcodesettings", "Isautofill"), "YES", "NO")
        If IsLeadingZeros.Text.Length = 0 Then
            IsLeadingZeros.Text = "NO"
        End If
        If IsFixedLength.Text.Length = 0 Then
            IsFixedLength.Text = "YES"
        End If
        If IsAutoFill.Text.Length = 0 Then
            IsAutoFill.Text = "NO"
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   barcodesettings") = True Then
            If SQLIsFieldExists("Select mrp from stockdbf ") = True Then
                MsgBox("This barcode is not recommended to change ", MsgBoxStyle.Information)

            End If
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If SQLIsFieldExists("SELECT TOP 1 1 from   barcodesettings") = False Then
            MsgBox("You should  save the defalut settings...")
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If MsgBox("Do you want to save changes  ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   barcodesettings") = False Then
                ExecuteSQLQuery("INSERT INTO [barcodesettings]([barcodelength],[Isreplacezeros],[Isautofill],[FixedLength],[BarcodeType])     VALUES (" & TxtBarcodeLength.Value & ",'" & IIf(IsLeadingZeros.Text = "YES", 1, 0) & "','" & IIf(IsAutoFill.Text = "YES", 1, 0) & "','" & IIf(IsFixedLength.Text = "YES", 1, 0) & "','CODE128')")
            Else
                ExecuteSQLQuery("UPDATE [barcodesettings]   SET [barcodelength] =" & TxtBarcodeLength.Value & " ,[Isreplacezeros] ='" & IIf(IsLeadingZeros.Text = "YES", 1, 0) & "' ,[Isautofill] ='" & IIf(IsAutoFill.Text = "YES", 1, 0) & "',[FixedLength] ='" & IIf(IsFixedLength.Text = "YES", 1, 0) & "',[BarcodeType] ='CODE128'")
            End If
            BarcodeSettingsVals.BarcodeLength = SQLGetNumericFieldValue("select barcodelength from barcodesettings", "barcodelength")
            BarcodeSettingsVals.IsLeadingZeros = SQLGetBooleanFieldValue("select Isreplacezeros from barcodesettings", "Isreplacezeros")
            BarcodeSettingsVals.IsFixedLegth = SQLGetBooleanFieldValue("select FixedLength from barcodesettings", "FixedLength")
            BarcodeSettingsVals.IsAutoFill = SQLGetBooleanFieldValue("select Isautofill from barcodesettings", "Isautofill")
            LoadBarcodeSettings()
            Me.Close()
        End If

    End Sub

    Private Sub IsFixedLength_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsFixedLength.SelectedIndexChanged
        If IsFixedLength.Text = "YES" Then
            IsAutoFill.Text = "YES"
            IsLeadingZeros.Text = "YES"
            IsLeadingZeros.Enabled = False
        Else
            IsLeadingZeros.Enabled = True
        End If
    End Sub
End Class
