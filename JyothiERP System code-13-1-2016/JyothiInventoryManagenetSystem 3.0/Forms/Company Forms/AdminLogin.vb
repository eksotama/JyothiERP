Public Class AdminLogin
    Dim Count As Integer = 0

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim sqlstr As String = ""
        If TxtCmpName.Text.Length < 2 Then
            MsgBox("Please Select the Company Name  ", MsgBoxStyle.Information)
            TxtCmpName.Focus()
            Exit Sub
        End If
        If UsernameTextBox.Text.Length < 2 Then
            MsgBox("Please Enter the User Name ", MsgBoxStyle.Information)
            UsernameTextBox.Focus()
            Exit Sub
        End If
        If PasswordTextBox.Text.Length < 2 Then
            MsgBox("Please Enter the Password ", MsgBoxStyle.Information)
            PasswordTextBox.Focus()
            Exit Sub
        End If
        pwdtextvalues = PasswordTextBox.Text
        Me.Cursor = Cursors.WaitCursor

        TxtSoftwareSQLDatabaseName = MainForm.GetCompanyDatabaseName(TxtCmpName.Text)
        txtSoftwareSQLdefaultCompany = TxtSoftwareSQLDatabaseName
        ConnectionStrinG = ConnectionStringFromFile & " Initial Catalog=" & TxtSoftwareSQLDatabaseName & ";"
        sqlstr = "SELECT * FROM COMPANY WHERE [adminname]=N'" & UsernameTextBox.Text & "' AND [adminpassword]=N'" & EncrypPassword(PasswordTextBox.Text) & "'"
        If SQLIsFieldExists(sqlstr) = False Then
            If IsUserAlreadyLogin(UsernameTextBox.Text) = True Then
                MsgBox("The Seleted User already login, Please Try with another user or contact admin...")
                Exit Sub
            End If
            sqlstr = "SELECT * FROM users WHERE [userid]=N'" & UsernameTextBox.Text & "' AND [userpassword]=N'" & EncrypPassword(PasswordTextBox.Text) & "'"
            If SQLIsFieldExists(sqlstr) = False Then
                MsgBox("Invalid User Name or Password ", MsgBoxStyle.Information, MySoftwareName)
                ConnectionStrinG = ""
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                CurrentUserName = UsernameTextBox.Text
                IsUserAdmin = False
                CurrentCounterID = SQLGetNumericFieldValue("select counterid from users where userid=N'" & UsernameTextBox.Text & "'", "counterid")
                User_IsAllowtoDelete = IIf(SQLGetStringFieldValue("Select top 1 isdelete from UserRights  WHERE USERNAME=N'" & CurrentUserName & "'", "isdelete") = "YES", True, False)
                User_IsAllowtoEdit = IIf(SQLGetStringFieldValue("Select top 1 ISEDIT from UserRights  WHERE USERNAME=N'" & CurrentUserName & "'", "ISEDIT") = "YES", True, False)
                User_IsCreateMasters = IIf(SQLGetStringFieldValue("Select top 1 IsMaster from UserRights  WHERE USERNAME=N'" & CurrentUserName & "'", "IsMaster") = "YES", True, False)
                UserLogInlogoutID = GetAndSetIDCode(EnumIDType.UserTransID)
                UpdateUserLogin()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Else
            CurrentUserName = UsernameTextBox.Text
            IsUserAdmin = True
            User_IsAllowtoDelete = True
            User_IsAllowtoEdit = True
            User_IsCreateMasters = True
            CurrentCounterID = 0
            UserLogInlogoutID = GetAndSetIDCode(EnumIDType.UserTransID)
            UpdateUserLogin()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub AdminLogin_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AdminLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TxtCmpName.Focus()

    End Sub

  
    Private Sub AdminLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        MainForm.LoadCompaniesList(TxtCmpName)
        TxtCmpName.Focus()
        PasswordTextBox.Text = ""
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TxtCmpName.Text.Length = 0 Then
            MsgBox("Select the Company name    ", MsgBoxStyle.Information)
            Exit Sub
        End If
        TxtSoftwareSQLDatabaseName = MainForm.GetCompanyDatabaseName(TxtCmpName.Text)
        ConnectionStrinG = ConnectionStringFromFile & "; Initial Catalog=" & TxtSoftwareSQLDatabaseName & ";"
        RecoverPassword.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim frm As New RestoreDatabase
        frm.TxtCmpNames.Items.Clear()
        For i As Integer = 0 To TxtCmpName.Items.Count - 1
            frm.TxtCmpNames.Items.Add(TxtCmpName.Items(i).ToString)
        Next
        frm.ShowDialog()
    End Sub
End Class
