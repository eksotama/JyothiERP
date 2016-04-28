Imports System.Windows.Forms

Public Class DocRenewExpiry
    Dim DocName As String = ""
    Dim DocType As String = ""
    Dim verifiedby As String = ""
    Dim expirydate As New DateTimePicker
    Dim RefNo As String = ""
    Sub New(ByVal dname As String, ByVal dtype As String)

        ' This call is required by the designer.
        InitializeComponent()
        DocName = dname
        DocType = dtype
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DocRenewExpiry_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
   
    Private Sub DocRenewExpiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtDocumentName.Text = DocName
        TxtDocType.Text = DocType
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtIssuedBy.Text.Length < 2 Then
            MsgBox("Please Enter the Issued By Field .... ", MsgBoxStyle.Information)
            TxtIssuedBy.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Save ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            verifiedby = SQLGetStringFieldValue("select IssuedBy from documents where  docname=N'" & TxtDocumentName.Text & "'", "IssuedBy")
            expirydate.Value = SQLGetStringFieldValue("select ExpiryDate from documents where  docname=N'" & TxtDocumentName.Text & "'", "ExpiryDate")
            RefNo = SQLGetStringFieldValue("select DocRefNo from documents where  docname=N'" & TxtDocumentName.Text & "'", "DocRefNo")
            SaveExpiresHistory()
            ExecuteSQLQuery("update documents set expirydate=CONVERT(datetime,'" & TxtExpiry.Value.ToString("yyyy-MM-dd") & "',101), IssuedBy=N'" & TxtIssuedBy.Text & "'  where docname=N'" & TxtDocumentName.Text & "'")
            Me.Close()
        End If
    End Sub
    Sub SaveExpiresHistory()
        Dim Sqlstr As String = ""
        Sqlstr = "INSERT INTO [ExpiryHistory] ([DocType],[DocName],[IDType],[verifiedby],[ExpiryDate],[AlterDate],[UserName],[renewDate],[RefNumber],[RegNumber],[F1],[F2],[RegDate])     VALUES " _
            & " (@DocType,@DocName,@IDType,@verifiedby,@ExpiryDate,@AlterDate,@UserName,@renewDate,@RefNumber,@RegNumber,@F1,@F2,@RegDate)  "
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(Sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("DocType", TxtDocType.Text)
            .AddWithValue("IDType", "")
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
End Class
