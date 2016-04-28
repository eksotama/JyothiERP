Imports System.Windows.Forms

Public Class UserRights
    Dim OpenedUserName As String
    Sub New(ByVal uname As String)

        ' This call is required by the designer.
        InitializeComponent()
        OpenedUserName = uname
        ' Add any initialization after the InitializeComponent() call.
        TxtUserName.Text = "For User : " & uname
    End Sub
    ' ExecuteSQLQuery("INSERT INTO [UserRights] ([UserName],[IsEdit],[IsAccess],[IsReadOnly],[IsDelete],[IsFullRights]) Values('" & TxtUserID.Text & "','True','True','False','True','True')")
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

    Private Sub UserRights_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub UserRights_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SQLstr As String = ""
        Dim SqlConn As New SqlClient.SqlConnection

        SQLstr = "select * from UserRights where username=N'" & OpenedUserName & "'"
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLstr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()

                If Sreader("IsEdit") = True Then
                    txtEditing.Text = "TRUE"
                Else
                    txtEditing.Text = "FALSE"
                End If

                If Sreader("IsDelete") = True Then
                    TxtDelete.Text = "TRUE"
                Else
                    TxtDelete.Text = "FALSE"
                End If

                If Sreader("IsReadOnly") = True Then
                    TxtReadOnly.Text = "TRUE"
                Else
                    TxtReadOnly.Text = "FALSE"
                End If

                If Sreader("IsFullRights") = True Then
                    TxtFullRights.Text = "TRUE"
                    TxtFullRights.SelectedIndex = 1
                Else
                    TxtFullRights.Text = "FALSE"
                    TxtFullRights.SelectedIndex = 0
                End If


                If Sreader("IsMaster") = True Then
                    TxtMaster.Text = "TRUE"
                Else
                    TxtMaster.Text = "FALSE"
                End If

                If Sreader("IsOptions") = True Then
                    TxtAdvance.Text = "TRUE"
                Else
                    TxtAdvance.Text = "FALSE"
                End If


            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing
        End Try
        LoadDeprts()
    End Sub

   

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtFullRights.Text.Length = 0 Or TxtReadOnly.Text.Length = 0 Or TxtDelete.Text.Length = 0 Or txtEditing.Text.Length = 0 Then
            MsgBox("Please Select The Required Fileds....")
            Exit Sub
        End If

        If MsgBox("Do you want to Save Changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("UPDATE  [UserRights] SET ISEDIT='" & txtEditing.Text & "', ISREADONLY='" & TxtReadOnly.Text & "', ISFULLRIGHTS='" & TxtFullRights.Text & "',IsDelete='" & TxtDelete.Text & "' ,IsMaster='" & TxtMaster.Text & "',IsOptions='" & TxtAdvance.Text & "' WHERE USERNAME=N'" & OpenedUserName & "'")
            LoadUserRights()
            Me.Close()


        End If

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

   

    Private Sub TxtFullRights_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFullRights.SelectedIndexChanged

        If TxtFullRights.Text = "TRUE" Then
            TxtReadOnly.SelectedIndex = 0
            TxtDelete.SelectedIndex = 1
            txtEditing.SelectedIndex = 1
        Else
            TxtReadOnly.SelectedIndex = 1
            TxtDelete.SelectedIndex = 0
            txtEditing.SelectedIndex = 0

        End If
    End Sub
    Sub LoadDeprts()
        Dim TempBS As New BindingSource
        My.Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        Dim SqlString As String = ""
        SqlString = "SELECT  ROW_NUMBER() OVER (ORDER BY [DepName]) AS [S.NO],[DepName] as [Department] from UserDepartments where isdelete=0 and userid=N'" & OpenedUserName & "'"
       
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlString)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            Me.TxtList.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.TxtList.Columns(0).Width = 45
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BtnAddDep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDep.Click
        Dim k As New AddUserDepartments(OpenedUserName)
        k.ShowDialog()
        LoadDeprts()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtList.RowCount = 0 Then
            MsgBox("There is no data            ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtList.CurrentRow.Index >= 0 Then
            If MsgBox("Do you want to delete the additional department :" & TxtList.Item("Department", TxtList.CurrentRow.Index).Value & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from UserDepartments where userid=N'" & OpenedUserName & "' and depname=N'" & TxtList.Item("Department", TxtList.CurrentRow.Index).Value & "'")
                LoadDeprts()
            End If
        End If
    End Sub
End Class
