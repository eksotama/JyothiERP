Imports System.Windows.Forms

Public Class RenewVehicleIDs

    Dim VehicleName As String = ""
    Dim EmpIdTypea As String = ""
    Dim verifiedby As String = ""
    Dim expirydate As New DateTimePicker
    Dim RefNo As String = ""
    Sub New(ByVal VhName As String, ByVal IDType As String)

        ' This call is required by the designer.
        InitializeComponent()
        VehicleName = VhName
        EmpIdTypea = IDType
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub RenewVehicleIDs_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub RenewEmpExpiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtVhname.Text = VehicleName
        TxtIDType.Text = EmpIdTypea

    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Dim SQLStr As String = ""
        If MsgBox("Do you want to save Changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'Expiry
            'Insurence1 Expiry
            'Insurence2 Expiry
            'Insurence3 Expiry
            If TxtIDType.Text = "Expiry" Then
                verifiedby = ""
                expirydate.Value = SQLGetStringFieldValue("select ExpiryDate from vehicle where  vhname=N'" & TxtVhname.Text & "'", "ExpiryDate")
                RefNo = ""
                SaveExpiresHistory("Expiry")
                ExecuteSQLQuery("update vehicle set IssuedBy=N'" & TxtIssuedBy.Text & "', ExpiryDate=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101) where vhname=N'" & TxtVhname.Text & "'")
            ElseIf TxtIDType.Text = "Insurence1 Expiry" Then
                verifiedby = SQLGetStringFieldValue("select InsurenceDetails1 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceDetails1")
                expirydate.Value = SQLGetStringFieldValue("select InsurenceExpiry1 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceExpiry1")
                RefNo = SQLGetStringFieldValue("select InsurenceNo1 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceNo1")
                SaveExpiresHistory("Insurence1 Expiry")
                ExecuteSQLQuery("update vehicle set InsurenceDetails1=N'" & TxtIssuedBy.Text & "', InsurenceExpiry1=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101),InsurenceNo1=N'" & TxtIdNo.Text & "' where vhname=N'" & TxtVhname.Text & "'")
            ElseIf TxtIDType.Text = "Insurence2 Expiry" Then
                verifiedby = SQLGetStringFieldValue("select InsurenceDetails2 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceDetails2")
                expirydate.Value = SQLGetStringFieldValue("select InsurenceExpiry2 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceExpiry2")
                RefNo = SQLGetStringFieldValue("select InsurenceNo2 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceNo2")
                SaveExpiresHistory("Insurence2 Expiry")
                ExecuteSQLQuery("update vehicle set InsurenceDetails2=N'" & TxtIssuedBy.Text & "', InsurenceExpiry2=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101),InsurenceNo2=N'" & TxtIdNo.Text & "' where vhname=N'" & TxtVhname.Text & "'")
            ElseIf TxtIDType.Text = "Insurence3 Expiry" Then
                verifiedby = SQLGetStringFieldValue("select InsurenceDetails3 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceDetails3")
                expirydate.Value = SQLGetStringFieldValue("select InsurenceExpiry3 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceExpiry3")
                RefNo = SQLGetStringFieldValue("select InsurenceNo3 from vehicle where  vhname=N'" & TxtVhname.Text & "'", "InsurenceNo3")
                SaveExpiresHistory("Insurence3 Expiry")
                ExecuteSQLQuery("update vehicle set InsurenceDetails3=N'" & TxtIssuedBy.Text & "', InsurenceExpiry3=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101),InsurenceNo3=N'" & TxtIdNo.Text & "' where vhname=N'" & TxtVhname.Text & "'")
           
            End If


        End If
        Me.Close()
    End Sub
    Sub SaveExpiresHistory(ByVal DocType As String)
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [ExpiryHistory] ([DocType],[DocName],[IDType],[verifiedby],[ExpiryDate],[AlterDate],[UserName],[renewDate],[RefNumber],[RegNumber],[F1],[F2],[RegDate])     VALUES " _
            & " (@DocType,@DocName,@IDType,@verifiedby,@ExpiryDate,@AlterDate,@UserName,@renewDate,@RefNumber,@RegNumber,@F1,@F2,@RegDate)  "
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(Sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("DocType", DocType)
            .AddWithValue("IDType", TxtIDType.Text)
            .AddWithValue("DocName", "Vehicle")
            .AddWithValue("verifiedby", verifiedby)
            .AddWithValue("ExpiryDate", expirydate.Value.Date)
            .AddWithValue("AlterDate", Today.Date)
            .AddWithValue("UserName", CurrentUserName)
            .AddWithValue("renewDate", Today.Date)
            .AddWithValue("RefNumber", RefNo)
            .AddWithValue("RegNumber", "")
            .AddWithValue("F1", "")
            .AddWithValue("F2", "")
            .AddWithValue("RegDate", Today.Date)
        End With

        DBF.ExecuteNonQuery()
        MAINCON.Close()
    End Sub


    

End Class
