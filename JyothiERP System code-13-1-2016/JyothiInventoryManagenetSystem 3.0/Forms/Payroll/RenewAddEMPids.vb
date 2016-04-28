Imports System.Windows.Forms

Public Class RenewAddEMPids

    Dim IdNo As Long = 0
    Sub New(ID As Long)

        ' This call is required by the designer.
        InitializeComponent()
        IdNo = ID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
   

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If MsgBox("Do you want to Renewal ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim MAINCON As New SqlClient.SqlConnection
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand("UPDATE EMPIDS SET EXPIRY=@EXPIRY WHERE ID=" & IdNo, MAINCON)
            With DBF.Parameters
                .AddWithValue("Expiry", TxtExpiry.Value)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing

            '
            Dim DBF2 As New SqlClient.SqlCommand("INSERT INTO [dbo].[renewHistory] ([RenewDate],[Username],[RenewID],[DateValue])     VALUES (@RenewDate,@Username,@RenewID,@DateValue) ", MAINCON)
            With DBF2.Parameters
                .AddWithValue("RenewDate", Now)
                .AddWithValue("DateValue", Now.Date.ToOADate)
                .AddWithValue("Username", CurrentUserName)
                .AddWithValue("RenewID", IdNo)
            End With
            DBF2.ExecuteNonQuery()
            DBF2 = Nothing

            MAINCON.Close()
        End If
    End Sub

    Private Sub RenewAddEMPids_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt = SQLLoadGridData("select id,empid,idname,idtype,expiry,description,IssuedBy,(select empname from employees where empid=empids.empid) as empname from empids where id=" & IdNo)
        If dt.Rows.Count > 0 Then
            TxtEmployeeName.Text = dt.Rows(0).Item("empname").ToString
            TxtIDType.Text = dt.Rows(0).Item("idtype").ToString
            TxtIdNo.Text = dt.Rows(0).Item("idname").ToString
            TxtIssuedBy.Text = dt.Rows(0).Item("IssuedBy").ToString
            TxtExpiry.Value = dt.Rows(0).Item("expiry")
            TxtExpiry.MinDate = dt.Rows(0).Item("expiry")
        End If
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
