Imports System.Windows.Forms

Public Class AssignSites
    Dim ClientID As Integer = 0
    Sub loadsites()
        If TxtClientName.Text.Length = 0 Then Exit Sub

        Dim sqlstr As String = ""
        sqlstr = "select siteid, sitename from sites where siteid not in (select siteid from ClientSites where clientID=" & ClientID & ")"
        Dim TempBS As New BindingSource
        With Me.ImsList1
            TempBS.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            ImsList1.Columns(0).Visible = False
        Catch ex As Exception

        End Try

        sqlstr = "select id,sites.siteid as SiteID,sitename from ClientSites inner join  sites  on Sites.SiteID=clientsites.siteid where clientID=" & ClientID
        Dim TempBS2 As New BindingSource
        With Me.ImsList2
            TempBS2.DataSource = SQLLoadGridData(sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS2
        End With
        Try
            ImsList2.Columns(0).Visible = False
            ImsList2.Columns(1).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtClientName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtClientName.SelectedIndexChanged
        ClientID = SQLGetNumericFieldValue("select clientid from clients where clientName=N'" & TxtClientName.Text & "'", "clientid")
        loadsites()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TxtClientName.Text.Length = 0 Then
            MsgBox("Please Select Client Name...", MsgBoxStyle.Information)
            TxtClientName.Focus()
            Exit Sub


        End If
        ExecuteSQLQuery("insert into ClientSites (clientID,siteid) values (" & ClientID & "," & ImsList1.Item("siteid", ImsList1.CurrentRow.Index).Value & ")")
        loadsites()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TxtClientName.Text.Length = 0 Then
            MsgBox("Please Select Client Name...", MsgBoxStyle.Information)
            TxtClientName.Focus()
            Exit Sub


        End If
        ExecuteSQLQuery("DELETE FROM  ClientSites WHERE ID=" & ImsList2.Item("ID", ImsList2.CurrentRow.Index).Value)
        loadsites()
    End Sub

    Private Sub AssignSites_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select ClientName from Clients ", TxtClientName, "ClientName")
        If TxtClientName.Items.Count > 0 Then TxtClientName.SelectedIndex = 0

    End Sub
End Class
