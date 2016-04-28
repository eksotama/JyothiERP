Imports System.Windows.Forms

Public Class CreateAccountGroups
    Public IsOpenforEdit As Boolean = False
    Public GroupNametoEdit As String = ""
    Sub New(Optional ByVal EditGroupName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If EditGroupName.Length = 0 Then
            IsOpenforEdit = False
        Else
            IsOpenforEdit = True
            GroupNametoEdit = EditGroupName
            BtnCreate.Text = "&Alter"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click

        If TxtAccGroupName.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Account Group  Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtAccGroupName.Focus()
            Exit Sub

        End If
        If TxtunderAccGroup.Text.Trim.Length = 0 Then
            MsgBox("Please Select the Under Group!! ", MsgBoxStyle.Critical, MySoftwareName)
            TxtunderAccGroup.Focus()
            Exit Sub
        End If
        If TxtunderAccGroup.Text.Trim = TxtAccGroupName.Text.Trim Then
            MsgBox("Error: The Group Names are same level...", MsgBoxStyle.Information)
            TxtunderAccGroup.Focus()
            Exit Sub
        End If

        If IsOpenforEdit = True Then
            If UCase(GroupNametoEdit) <> UCase(TxtAccGroupName.Text) Then
                If UCase(Replace(TxtAccGroupName.Text, " ", "")) <> UCase(Replace(GroupNametoEdit, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   accountgroups where groupnameTemp=N'" & Replace(TxtAccGroupName.Text, " ", "").ToString & "'") = True Then
                        MsgBox("The Entered Group Name is already exist..", MsgBoxStyle.Information)
                        TxtAccGroupName.Focus()
                        Exit Sub
                    End If
                End If

            End If
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   accountgroups where groupnameTemp=N'" & Replace(TxtAccGroupName.Text, " ", "").ToString & "'") = True Then
                MsgBox("The Entered Group Name is already exist..", MsgBoxStyle.Information)
                TxtAccGroupName.Focus()
                Exit Sub
            End If
        End If


        If IsOpenforEdit = True Then
            If MsgBox("Do you want to Alter ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim SqlStr As String = ""
            Dim glevel As Integer = 0
            Dim gactype As Integer = 0
            glevel = SQLGetNumericFieldValue("select GroupLevel from accountgroups where groupnameTemp=N'" & Replace(TxtunderAccGroup.Text, " ", "").ToString & "'", "GroupLevel")
            gactype = SQLGetNumericFieldValue("select Actype from accountgroups where groupnameTemp=N'" & Replace(TxtunderAccGroup.Text, " ", "").ToString & "'", "Actype")
            SqlStr = "DELETE FROM AccountGroups WHERE GROUPNAME=N'" & GroupNametoEdit & "'"
            ExecuteSQLQuery(SqlStr)
            SqlStr = "INSERT INTO [AccountGroups] ([GroupName],[GroupNameTemp],[GroupRoot],[GroupLevel],[UserName],[Isprimary],[AcType]) " _
                & "VALUES(N'" & TxtAccGroupName.Text & "',N'" & Replace(TxtAccGroupName.Text, " ", "").ToString & "',N'" & TxtunderAccGroup.Text & "'," & glevel + 1 & ",N'" & CurrentUserName & "',0," & gactype & ")"
            ExecuteSQLQuery(SqlStr)
            SqlStr = "UPDATE LEDGERS SET AccountGroup=N'" & TxtAccGroupName.Text & "'  WHERE ACCOUNTGROUP=N'" & GroupNametoEdit & "'"
            ExecuteSQLQuery(SqlStr)
            SqlStr = "UPDATE AccountGroups SET grouproot=N'" & TxtAccGroupName.Text & "' WHERE grouproot=N'" & GroupNametoEdit & "'"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "UPDATE vehicle SET AccountGroup=N'" & TxtAccGroupName.Text & "' WHERE AccountGroup=N'" & GroupNametoEdit & "'"
            ExecuteSQLQuery(SqlStr)

            SqlStr = "UPDATE LedgerBook SET LedgerGroup=N'" & TxtAccGroupName.Text & "' WHERE LedgerGroup=N'" & GroupNametoEdit & "'"
            ExecuteSQLQuery(SqlStr)

            TxtAccGroupName.Text = ""
            TxtAccGroupName.Focus()
            ReArrangeAccountGroups()
        Else
            If MsgBox("Do you want to create ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim SqlStr As String = ""
            Dim glevel As Integer = 0
            Dim gactype As Integer = 0
            glevel = SQLGetNumericFieldValue("select GroupLevel from accountgroups where groupnameTemp=N'" & Replace(TxtunderAccGroup.Text, " ", "").ToString & "'", "GroupLevel")
            gactype = SQLGetNumericFieldValue("select Actype from accountgroups where groupnameTemp=N'" & Replace(TxtunderAccGroup.Text, " ", "").ToString & "'", "Actype")

            SqlStr = "INSERT INTO [AccountGroups] ([GroupName],[GroupNameTemp],[GroupRoot],[GroupLevel],[UserName],[Isprimary],[AcType]) " _
                & "VALUES(N'" & TxtAccGroupName.Text & "',N'" & Replace(TxtAccGroupName.Text, " ", "").ToString & "',N'" & TxtunderAccGroup.Text & "'," & glevel + 1 & ",N'" & CurrentUserName & "',0," & gactype & ")"
            ' MsgBox(SqlStr)
            ExecuteSQLQuery(SqlStr)
            TxtAccGroupName.Text = ""
            TxtAccGroupName.Focus()
            ReArrangeAccountGroups()
            LoadDataIntoComboBox("select groupname from accountgroups", TxtunderAccGroup, "groupname")
        End If
        TxtStatus.Text = "Status: Success..."
        Timer1.Enabled = True

    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtAccGroupName.Focus()

    End Sub

    Private Sub CreateStockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select groupname from accountgroups", TxtunderAccGroup, "groupname")
        If IsOpenforEdit = True Then
            TxtAccGroupName.Text = GroupNametoEdit
            TxtunderAccGroup.Text = SQLGetStringFieldValue("select GroupRoot from AccountGroups where groupname=N'" & TxtAccGroupName.Text & "'", "GroupRoot")
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static k As Boolean = True
        Static c As Byte = 0
        If k = True Then
            TxtStatus.ForeColor = Color.Green
            k = False
        Else
            TxtStatus.ForeColor = Color.Blue
            k = True
        End If
        If c = 5 Then
            Timer1.Enabled = False
            c = 0
            TxtStatus.ForeColor = Color.Green
            TxtStatus.Text = "Status: Ready"
        Else
            c = c + 1
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

End Class
