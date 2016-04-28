Imports System.Windows.Forms

Public Class RenewEmpExpiry
    Dim EmployeeName As String = ""
    Dim EmpIdTypea As String = ""
    Dim verifiedby As String = ""
    Dim expirydate As New DateTimePicker
    Dim RefNo As String = ""
    Sub New(ByVal EmpName As String, ByVal IDType As String)

        ' This call is required by the designer.
        InitializeComponent()
        EmployeeName = EmpName
        EmpIdTypea = IDType
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub RenewEmpExpiry_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub RenewEmpExpiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtEmployeeName.Text = EmployeeName
        TxtIDType.Text = EmpIdTypea

    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Dim SQLStr As String = ""
        If MsgBox("Do you want to save Changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'Contract Expiry
            'Passport Expiry
            'VISA Expiry
            'Emirate Expiry
            'Labour Card Expiry
            'Medical Expiry
            If TxtIDType.Text = "Contract Expiry" Then
                verifiedby = ""
                expirydate.Value = SQLGetStringFieldValue("select contractexpirydate from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "contractexpirydate")
                RefNo = ""
                SaveExpiresHistory("Contract Expiry")
                ExecuteSQLQuery("update employees set contractexpirydate=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101) where EmpName=N'" & TxtEmployeeName.Text & "'")
            ElseIf TxtIDType.Text = "Passport Expiry" Then
                verifiedby = SQLGetStringFieldValue("select passportIDissuedby from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "passportIDissuedby")
                expirydate.Value = SQLGetStringFieldValue("select passportexpire from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "passportexpire")
                RefNo = SQLGetStringFieldValue("select passportIDNo from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "passportIDNo")
                SaveExpiresHistory("Passport Expiry")
                ExecuteSQLQuery("update employees set passportIDNo=N'" & TxtIdNo.Text & "',passportIDissuedby=N'" & TxtIssuedBy.Text & "', passportexpire=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101) where EmpName=N'" & TxtEmployeeName.Text & "'")
            ElseIf TxtIDType.Text = "VISA Expiry" Then
                verifiedby = SQLGetStringFieldValue("select visaIDissuedby from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "visaIDissuedby")
                expirydate.Value = SQLGetStringFieldValue("select visaexpire from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "visaexpire")
                RefNo = SQLGetStringFieldValue("select visaIDNo from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "visaIDNo")
                SaveExpiresHistory("VISA Expiry")
                ExecuteSQLQuery("update employees set visaIDNo=N'" & TxtIdNo.Text & "',visaIDissuedby=N'" & TxtIssuedBy.Text & "', visaexpire=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101) where EmpName=N'" & TxtEmployeeName.Text & "'")
            ElseIf TxtIDType.Text = "Emirate Expiry" Then
                verifiedby = SQLGetStringFieldValue("select Emiratesissuedby from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "Emiratesissuedby")
                expirydate.Value = SQLGetStringFieldValue("select Emiratesexpire from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "Emiratesexpire")
                RefNo = SQLGetStringFieldValue("select EmiratesDNo from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "EmiratesDNo")
                SaveExpiresHistory("Emirate Expiry")
                ExecuteSQLQuery("update employees set EmiratesDNo=N'" & TxtIdNo.Text & "',Emiratesissuedby=N'" & TxtIssuedBy.Text & "', Emiratesexpire=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101) where EmpName=N'" & TxtEmployeeName.Text & "'")
            ElseIf TxtIDType.Text = "Labour Card Expiry" Then
                verifiedby = SQLGetStringFieldValue("select Labourcardissuedby from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "Labourcardissuedby")
                expirydate.Value = SQLGetStringFieldValue("select Labourcardexpire from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "Labourcardexpire")
                RefNo = SQLGetStringFieldValue("select LabourcardDNo from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "LabourcardDNo")
                SaveExpiresHistory("Labour Card Expiry")
                ExecuteSQLQuery("update employees set LabourcardDNo=N'" & TxtIdNo.Text & "',Labourcardissuedby=N'" & TxtIssuedBy.Text & "', Labourcardexpire=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101) where EmpName=N'" & TxtEmployeeName.Text & "'")
            ElseIf TxtIDType.Text = "Medical Expiry" Then
                verifiedby = SQLGetStringFieldValue("select Medicalissuedby from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "Medicalissuedby")
                expirydate.Value = SQLGetStringFieldValue("select Medicalexpire from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "Medicalexpire")
                RefNo = SQLGetStringFieldValue("select MedicalDNo from employees where  EmpName=N'" & TxtEmployeeName.Text & "'", "MedicalDNo")
                SaveExpiresHistory("Medical Expiry")
                ExecuteSQLQuery("update employees set MedicalDNo=N'" & TxtIdNo.Text & "',Medicalissuedby=N'" & TxtIssuedBy.Text & "', Medicalexpire=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101) where EmpName=N'" & TxtEmployeeName.Text & "'")
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
            .AddWithValue("DocName", "Employee")
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

   
    Private Sub TxtIDType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIDType.TextChanged
        If TxtIDType.Text = "Contract Expiry" Then
            TxtIdNo.Enabled = False
            TxtIssuedBy.Enabled = False
        Else
            TxtIdNo.Enabled = True
            TxtIssuedBy.Enabled = True
        End If
    End Sub
End Class
