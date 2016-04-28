Imports System.Windows.Forms

Public Class EditEmpBarcode
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please Select the Employee Name ..... ", MsgBoxStyle.Information)
            TxtEmployeeName.Focus()
            Exit Sub
        End If
        If TxtBarcode.Text.Length = DefaultBarcodeLength Then
            If SQLIsFieldExists("select barcode from employees where barcode=N'" & TxtBarcode.Text & "' and empname<>N'" & TxtEmployeeName.Text & "'") = True Then
                MsgBox("The Entered Barcode is already assited to existing employeee ", MsgBoxStyle.Critical)
                TxtBarcode.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to save changes ?           ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("UPDATE EMPLOYEES SET BARCODE=N'" & TxtBarcode.Text & "' WHERE EMPNAME=N'" & TxtEmployeeName.Text & "'")
                Me.Close()
            End If
        Else
            MsgBox("Please Enter the Barcode length in " & DefaultBarcodeLength & "  .... ", MsgBoxStyle.Information)

        End If
       

    End Sub

    Private Sub EditEmpBarcode_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub EditEmpBarcode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("SELECT empname from employees where isdelete=0", TxtEmployeeName, "empname")
    End Sub
End Class
