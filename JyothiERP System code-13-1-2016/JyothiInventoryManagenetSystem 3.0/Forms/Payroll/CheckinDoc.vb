Imports System.Windows.Forms

Public Class CheckinDoc

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
                TxtDocName.Items.Add(Sreader("DocName").ToString)
                TxtDocName.Text = Sreader("DocName").ToString
                TxtEmpname.Items.Add(Sreader("empname"))
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
    Private Sub NewIssueDocument_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txttype.SelectedIndex = 0
        If oPENEDiSSUENUMBER.Length > 0 Then
            LOADDATA()
        End If
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If MsgBox("Do you want to Check in this transaction ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqlstr As String = "update documentissues set Status=@Status, checkoutdate=@checkoutdate, Notes2=@Notes2 where IssueNo=N'" & oPENEDiSSUENUMBER & "'"
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("Status", False)
                .AddWithValue("checkoutdate", Txtindate.Value)
                .AddWithValue("Notes2", txtcheckinnotes.Text)

            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()

        End If
    End Sub
End Class
