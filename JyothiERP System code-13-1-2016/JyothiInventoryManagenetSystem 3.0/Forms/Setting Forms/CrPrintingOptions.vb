Imports System.Windows.Forms

Public Class CrPrintingOptions
    Dim OpenPicture As New OpenFileDialog
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkheader.CheckedChanged
        If chkheader.Checked = True Then
            Panel5.Enabled = True
        Else
            Panel5.Enabled = False
        End If
    End Sub

    Private Sub UserButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton2.Click
        OpenPicture.Filter = "All Picture Files |(*.gif;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.bmp;)"
        If OpenPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtHeder.ImageLocation = OpenPicture.FileName

        End If
    End Sub

    Private Sub UserButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton3.Click
        OpenPicture.Filter = "All Picture Files |(*.gif;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.bmp;)"
        If OpenPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtfooter.ImageLocation = OpenPicture.FileName

        End If
    End Sub

    Private Sub btnselectleftlogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselectleftlogo.Click
        OpenPicture.Filter = "All Picture Files |(*.gif;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.bmp;)"
        If OpenPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtleftlogobox.ImageLocation = OpenPicture.FileName

        End If
    End Sub

    Private Sub UserButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserButton1.Click
        OpenPicture.Filter = "All Picture Files |(*.gif;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.bmp;)"
        If OpenPicture.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtRightLogo.ImageLocation = OpenPicture.FileName
        End If
    End Sub

    Private Sub chkfooter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkfooter.CheckedChanged
        If chkfooter.Checked = True Then
            Panel6.Enabled = True
        Else
            Panel6.Enabled = False
        End If
    End Sub

    Private Sub chkleft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkleft.CheckedChanged
        If chkleft.Checked = True Then
            Panel2.Enabled = True
        Else
            Panel2.Enabled = False
        End If
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If MsgBox("Do you want to save ?                ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim Sqlstr As String = ""
            Sqlstr = "UPDATE CrReportSettings SET "
            If chkheader.Checked = True Then
                Sqlstr = Sqlstr & "HeaderOn='True' ,"
                Sqlstr = Sqlstr & "HeaderPath='" & TxtHeder.ImageLocation.ToString & "',"
            Else
                Sqlstr = Sqlstr & "HeaderOn='False' ,"
            End If


            If chkfooter.Checked = True Then
                Sqlstr = Sqlstr & "FooterOn='True' ,"
                Sqlstr = Sqlstr & "FooterPath='" & txtfooter.ImageLocation.ToString & "',"
            Else
                Sqlstr = Sqlstr & "FooterOn='False' ,"
            End If

            If chkleft.Checked = True Then
                Sqlstr = Sqlstr & "LeftLogoOn='True' ,"
                Sqlstr = Sqlstr & "LeftLogoPath='" & txtleftlogobox.ImageLocation.ToString & "',"
            Else
                Sqlstr = Sqlstr & "LeftLogoOn='False' ,"
            End If

            If chkright.Checked = True Then
                Sqlstr = Sqlstr & "RightLogoOn='True' ,"
                Sqlstr = Sqlstr & "RightLogoPath='" & TxtRightLogo.ImageLocation.ToString & "',"
            Else
                Sqlstr = Sqlstr & "LeftLogoOn='False' ,"
            End If

            If IsCompanyAddress.Checked = True Then
                Sqlstr = Sqlstr & "PrintAddress='True' ,"
            Else
                Sqlstr = Sqlstr & "PrintAddress='False' ,"
            End If


            If IscompanyName.Checked = True Then
                Sqlstr = Sqlstr & "PrintCompanyName='True' ,"
            Else
                Sqlstr = Sqlstr & "PrintCompanyName='False' ,"
            End If


            If ispagenumbers.Checked = True Then
                Sqlstr = Sqlstr & "PrintPageNos='True' ,"
            Else
                Sqlstr = Sqlstr & "PrintPageNos='False' ,"
            End If

            If IsTitle.Checked = True Then
                Sqlstr = Sqlstr & "PrintTitle='True' "
            Else
                Sqlstr = Sqlstr & "PrintTitle='False' "
            End If

            ExecuteSQLQuery(Sqlstr)
            LoadCrystalReportOptions()
        End If
    End Sub
    Sub LoadData()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from CrReportSettings"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                chkheader.Checked = Sreader("HeaderOn")
                chkfooter.Checked = Sreader("FooterOn")
                chkleft.Checked = Sreader("LeftLogoOn")
                chkright.Checked = Sreader("RightLogoOn")
                ispagenumbers.Checked = Sreader("PrintPageNos")
                IsCompanyAddress.Checked = Sreader("PrintAddress")
                IscompanyName.Checked = Sreader("PrintCompanyName")
                IsTitle.Checked = Sreader("PrintTitle")
                Try
                    TxtHeder.ImageLocation = Sreader("HeaderPath").ToString.Trim
                Catch ex As Exception

                End Try

                Try
                    txtfooter.ImageLocation = Sreader("FooterPath").ToString.Trim
                Catch ex As Exception

                End Try

                Try
                    txtleftlogobox.ImageLocation = Sreader("LeftLogoPath").ToString.Trim
                Catch ex As Exception

                End Try

                Try
                    TxtRightLogo.ImageLocation = Sreader("RightLogoPath").ToString.Trim
                Catch ex As Exception

                End Try


            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing

        End Try
    End Sub

    Private Sub CrPrintingOptions_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CrPrintingOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadData()
    End Sub

    Private Sub chkright_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkright.CheckedChanged
        If chkright.Checked = True Then
            Panel4.Enabled = True
        Else
            Panel4.Enabled = False
        End If
    End Sub
End Class
