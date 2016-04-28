Imports System.Windows.Forms

Public Class CheckoutDoc
    Dim oPENEDiSSUENUMBER As String = ""
    Dim OPENDOC As String = ""
    Dim OpenedEmployeename As String = ""
    Sub New(Optional ISSUE_NO As String = "", Optional V_DOCUMENTNAME As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        oPENEDiSSUENUMBER = ISSUE_NO
        OPENDOC = V_DOCUMENTNAME
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub txttype_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txttype.SelectedIndexChanged
        If txttype.Text = "Documents" Then
            LoadDataIntoComboBox("SELECT DocName FROM Documents WHERE isCheckOut=0", TxtDocName, "DocName", OPENDOC)
        Else
            LoadDataIntoComboBox("SELECT VHName FROM Vehicle WHERE isCheckOut=0", TxtDocName, "VHName", OPENDOC)

        End If
        LoadDataIntoComboBox("select empname from employees ", TxtEmpname, "empname")
    End Sub

    Private Sub NewIssueDocument_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txttype.SelectedIndex = 0
        If oPENEDiSSUENUMBER.Length > 0 Then
            LOADDATA()
        Else
            txtno.Text = SQLGetNumericFieldValue("SELECT isnull(MAX(CAST(IssueNo AS Int)),0) as tot FROM documentissues WHERE IssueNo NOT LIKE '%[a-z]%'    AND ISNUMERIC(IssueNo) = 1", "tot") + 1
        End If
    End Sub
    Sub LOADDATA()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from documentissues where IssueNo=N'" & oPENEDiSSUENUMBER & "'"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                If Sreader("Doctype") = 0 Then
                    txttype.Text = "Documents"
                Else
                    txttype.Text = "Vehicles"
                End If
                txtno.Text = Sreader("IssueNo").ToString
                TxtDocName.Text = Sreader("DocName").ToString
                TxtEmpname.Text = Sreader("empname")
                OpenedEmployeename = TxtEmpname.Text
                TxtDate.Value = Sreader("issuedate")
                Dim dt As New DateTimePicker
                dt.Value = Sreader("expirydate")
                TxtDays.Text = DateDiff(DateInterval.Day, TxtDate.Value.Date, dt.Value.Date)
                TxtNotes.Text = Sreader("notes")
            End While

            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If txttype.Text.Length = 0 Then
            MsgBox("Please select the document type  ..", MsgBoxStyle.Information)
            txttype.Focus()
            Exit Sub
        End If
        If txtno.Text.Length = 0 Then
            MsgBox("please enter the Issue Number .. ", MsgBoxStyle.Information)
            txtno.Focus()
            Exit Sub

        End If
        If TxtDocName.Text.Length = 0 Then
            MsgBox("please select the Document Name ", MsgBoxStyle.Information)
            TxtDocName.Focus()
            Exit Sub
        End If
        If TxtEmpname.Text.Length = 0 Then
            MsgBox("please select the Employee name ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If oPENEDiSSUENUMBER.Length > 0 Then
            If UCase(oPENEDiSSUENUMBER) <> UCase(txtno.Text) Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   documentissues where IssueNo=N'" & txtno.Text & "'") = True Then
                    MsgBox("Entered Issue Number already exists., Please try again...")
                    txtno.Focus()
                    Exit Sub
                End If
            End If
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   documentissues where IssueNo=N'" & txtno.Text & "'") = True Then
                MsgBox("Entered Issue Number already exists., Please try again...")
                txtno.Focus()
                Exit Sub
            End If
        End If
        If MsgBox("Do you want to Save     ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Savedata()
            ExecuteSQLQuery("update employees set ischeckout=1  where empname=N'" & TxtEmpname.Text & "'")
            If oPENEDiSSUENUMBER.Length > 0 Then
                ExecuteSQLQuery("update employees set ischeckout=0  where empname=N'" & OpenedEmployeename & "'")
                Me.Close()
            End If
        End If
    End Sub
    Sub Savedata()
        Dim sqlstr As String = ""
        If oPENEDiSSUENUMBER.Length > 0 Then
            sqlstr = "UPDATE [documentissues]   SET [IssueNo] = @IssueNo,[empname] = @empname,[DocName] = @DocName,[issuedate] = @issuedate,[expirydate] = @expirydate,[notes] = @notes,[Doctype] = @Doctype,[Status] = @Status WHERE IssueNo=N'" & oPENEDiSSUENUMBER & "'"

        Else
            sqlstr = "INSERT INTO [documentissues]([IssueNo],[empname],[DocName],[issuedate],[expirydate],[notes],[Doctype],[Status])     VALUES " _
         & " (@IssueNo,@empname,@DocName,@issuedate,@expirydate,@notes,@Doctype,@Status) "



        End If
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("IssueNo", txtno.Text)
            .AddWithValue("empname", TxtEmpname.Text)
            .AddWithValue("DocName", TxtDocName.Text)
            .AddWithValue("issuedate", TxtDate.Value)
            Dim dt As New DateTimePicker
            dt.Value = TxtDate.Value.AddDays(CDbl(TxtDays.Text))
            .AddWithValue("expirydate", dt.Value)
            .AddWithValue("notes", TxtNotes.Text)
            If txttype.Text = "Documents" Then
                .AddWithValue("Doctype", 0)
            Else
                .AddWithValue("Doctype", 1)
            End If

            .AddWithValue("Status", True)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
