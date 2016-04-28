Imports System.Windows.Forms

Public Class CreateNewUser
    Dim IsAlterMode As Boolean = False
    Dim OpenedEmailId As String = ""
    Dim OpenedUserName As String = ""
    Dim OpenedUserID As String = ""
    Sub New(Optional ByVal UName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If UName.Length > 0 Then
            OpenedUserName = UName
            IsAlterMode = True
            Me.Text = "ALTER A USER"
            Label2.Text = "ALTER A USER"
            BtnCreate.Text = "&Alter"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.TopLevelControl.SelectNextControl(sender, True, True, True, True)
        End If
    End Sub


    Sub SaveData()
        Dim SqlStr As String
        If IsAlterMode = True Then
            ExecuteSQLQuery("update employees set IsUser='False',AssignedUserName='' where empname=N'" & OpenedUserName & "'")
            Dim utype As Integer = 0
            If TxtUserType.Text = "Administrator" Then
                utype = 1
            End If
            Dim counterid As Integer = 0
            If TxtCounterName.Text = "None" Then
                counterid = 0
            Else
                counterid = CInt(SQLGetNumericFieldValue("select counterID from counters where countername=N'" & TxtCounterName.Text & "' and Locationname=N'" & TxtLocation.Text & "'", "counterid"))
            End If
            SqlStr = "UPDATE USERS SET " _
                & "username=N'" & TxtEmpName.Text & "'," _
                & "userpassword=N'" & EncrypPassword(TxtPassword1.Text) & "'," _
                & "UserEmailID=N'" & TxtEmailID.Text & "'," _
                & "UserID=N'" & TxtUserID.Text & "'," _
                & "UserSecurityQ1=N'" & TxtQ1.Text & "'," _
                & "UserSecurityQ2=N'" & TxtQ2.Text & "'," _
                & "UserSecurityA1=N'" & EncrypPassword(TxtA1.Text) & "'," _
                & "UserSecurityA2=N'" & EncrypPassword(TxtA2.Text) & "'," _
                & "UserDepartment=N'" & TxtDepartment.Text & "'," _
                & "StoreName=N'" & TxtLocation.Text & "'," _
                & "UserType=" & utype & ",CounterID=" & counterid & "," _
                & "LocationName=N'" & TxtLocation.Text & "' " _
                & " where username=N'" & OpenedUserName & "'"
            ExecuteSQLQuery(SqlStr)
            ExecuteSQLQuery("update employees set IsUser='True',AssignedUserName=N'" & TxtUserID.Text & "' where empname=N'" & TxtEmpName.Text & "'")
            ExecuteSQLQuery("UPDATE DefLedgers SET UserName=N'" & TxtUserID.Text & "' WHERE USERNAME=N'" & OpenedUserName & "'")
           
            Me.Close()
        Else


            SqlStr = "INSERT INTO [Users] ([UserName],[UserPassword],[UserType],[UserEmailID],[UserID],[UserSecurityQ1],[UserSecurityQ2],[UserSecurityA1],[UserSecurityA2],[UserDepartment],[StoreName],[LocationName],[IsActive],[SQLUserID],[SQLpwd],[IsLogin],[CounterID]) " _
                     & " VALUES (@UserName,@UserPassword,@UserType,@UserEmailID,@UserID,@UserSecurityQ1,@UserSecurityQ2,@UserSecurityA1,@UserSecurityA2,@UserDepartment,@StoreName,@LocationName,@IsActive,@SQLUserID,@SQLpwd,@IsLogin,@CounterID)"
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("UserName", TxtEmpName.Text)
                .AddWithValue("UserPassword", EncrypPassword(TxtPassword1.Text))
                If TxtUserType.Text = "Administrator" Then
                    .AddWithValue("UserType", 1)
                Else
                    .AddWithValue("UserType", 0)
                End If

                .AddWithValue("UserEmailID", TxtEmailID.Text)
                .AddWithValue("UserID", TxtUserID.Text)
                .AddWithValue("UserSecurityQ1", TxtQ1.Text)
                .AddWithValue("UserSecurityQ2", TxtQ2.Text)
                .AddWithValue("UserSecurityA1", EncrypPassword(TxtA1.Text))
                .AddWithValue("UserSecurityA2", EncrypPassword(TxtA2.Text))
                .AddWithValue("UserDepartment", TxtDepartment.Text)
                .AddWithValue("StoreName", TxtLocation.Text)
                .AddWithValue("LocationName", TxtLocation.Text)
                .AddWithValue("IsActive", "True")
                .AddWithValue("SQLUserID", TxtUserID.Text)
                .AddWithValue("SQLpwd", TxtUserID.Text & "@jerp")
                .AddWithValue("IsLogin", "False")
              
                If TxtCounterName.Text = "None" Then
                    .AddWithValue("CounterID", 0)
                Else
                    .AddWithValue("CounterID", CInt(SQLGetNumericFieldValue("select counterID from counters where countername=N'" & TxtCounterName.Text & "' and Locationname=N'" & TxtLocation.Text & "'", "counterid")))
                End If
                'SQLUserID
                'IsActive
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
            ExecuteSQLQuery("update employees set IsUser='True',AssignedUserName=N'" & TxtUserID.Text & "' where empname=N'" & TxtEmpName.Text & "'")
            'IsAdvanceUser
            ExecuteSQLQuery("INSERT INTO [UserRights] ([UserName],[IsEdit],[IsAccess],[IsReadOnly],[IsDelete],[IsFullRights],[IsMaster] ,[IsOptions]) Values(N'" & TxtUserID.Text & "','True','True','False','True','True','True','True')")
            'ExecuteSQLQuery("INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','cash',N'" & TxtUserID.Text & "') ")
            'ExecuteSQLQuery("INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','sales',N'" & TxtUserID.Text & "') ")
            'ExecuteSQLQuery("INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','salesret',N'" & TxtUserID.Text & "') ")
            'ExecuteSQLQuery("INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','purch',N'" & TxtUserID.Text & "') ")
            'ExecuteSQLQuery("INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('','purchret',N'" & TxtUserID.Text & "') ")
            'ExecuteSQLQuery("INSERT INTO [DefLedgers]([LedgerName],[LedgerType],[UserName]) VALUES('cash','pos','" & TxtUserID.Text & "') ")

            'ExecuteSQLQuery("CREATE LOGIN " & TxtUserID.Text & " WITH PASSWORD=N'" & TxtUserID.Text & "@jerp', DEFAULT_DATABASE=[" & TxtSoftwareSQLDatabaseName & "], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF")
            'ExecuteSQLQuery("EXEC sp_addsrvrolemember @loginame = N'" & TxtUserID.Text & "', @rolename = N'sysadmin'")
            'MsgBox("SQL Login Details for this user in Client System : " & Chr(13) & "username: " & TxtUserID.Text & Chr(13) & "Password:" & TxtUserID.Text & "@jerp")

        End If

        LoadDefs()


    End Sub
    Sub OpenUserDataForEdit()
        Dim SqlConn1 As New SqlClient.SqlConnection
        Dim Sqlcmmd1 As New SqlClient.SqlCommand
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Sqlcmmd1.Connection = SqlConn1
            Sqlcmmd1.CommandText = "select * from users where username=N'" & OpenedUserName & "'"
            Sqlcmmd1.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd1.ExecuteReader
            While Sreader.Read()

                TxtEmpName.Text = Sreader("UserName").ToString.Trim
                TxtPassword1.Text = DecrypPassword(Sreader("UserPassword").ToString.Trim)
                TxtPassword2.Text = TxtPassword1.Text
                If Sreader("UserType") = 1 Then
                    TxtUserType.Text = "Administrator"
                Else
                    TxtUserType.Text = "User"
                End If
                TxtEmailID.Text = Sreader("UserEmailID").ToString.Trim
                TxtUserID.Text = Sreader("UserID").ToString.Trim
                TxtQ1.Text = Sreader("UserSecurityQ1").ToString.Trim
                TxtQ2.Text = Sreader("UserSecurityQ2").ToString.Trim
                TxtA1.Text = DecrypPassword(Sreader("UserSecurityA1").ToString.Trim)
                TxtA2.Text = DecrypPassword(Sreader("UserSecurityA2").ToString.Trim)
                TxtDepartment.Text = Sreader("UserDepartment").ToString.Trim
                TxtLocation.Text = Sreader("StoreName").ToString.Trim
                Dim countertid As String = Sreader("counterID").ToString
                If countertid.Length = 0 Then
                    TxtCounterName.Text = "None"
                Else
                    TxtCounterName.Text = SQLGetStringFieldValue("select countername from counters where counterid=" & Sreader("counterID").ToString, "counterName")
                End If
               

               

                OpenedEmailId = TxtEmailID.Text
                OpenedUserID = TxtUserID.Text
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1 = Nothing
            Sqlcmmd1.Connection = Nothing
        End Try
    End Sub

    Sub LoadDefs()
        LoadDataIntoComboBox("select EmpName from Employees where isactive=1 and isdelete=0 and empname not in (select UserName from users)", TxtEmpName, "EmpName")
        LoadDataIntoComboBox("select locationname  from StockLocations", TxtLocation, "locationname")
        TxtUserType.Items.Clear()
        TxtUserType.Items.Add("User")
        TxtUserType.Text = "User"
        TxtA1.Text = ""
        TxtA2.Text = ""
        TxtEmailID.Text = ""
        TxtPassword1.Text = ""
        TxtPassword2.Text = ""
        TxtCounterName.Items.Clear()
        TxtCounterName.Items.Add("None")
        TxtCounterName.Text = "None"
        TxtUserID.Text = ""
        TxtUserType.Text = ""
        IsAlterMode = False
    End Sub
    
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub CreateNewUser_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CreateNewUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtDepartment.Items.Clear()
        TxtDepartment.Items.Add("Sales")
        TxtDepartment.Items.Add("Purchase")
        TxtDepartment.Items.Add("Inventory")
        TxtDepartment.Items.Add("Accounts & Finance")
        TxtDepartment.Items.Add("Accounts Only")
        TxtDepartment.Items.Add("Admin & Payroll")
        TxtDepartment.Items.Add("Admin")
        TxtDepartment.Items.Add("Payroll")
        TxtDepartment.Items.Add("Master")
        TxtDepartment.Items.Add("Production")
   

        If IsAlterMode = True Then
            LoadDefs()
            IsAlterMode = True
            BtnCreate.Text = "&Alter"
            TxtEmpName.Items.Add(OpenedUserName)
            OpenUserDataForEdit()
        Else
            LoadDefs()
        End If
    End Sub
   
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtEmpName.Text.Length = 0 Then
            MsgBox("Please Select the Employee Name ....", MsgBoxStyle.Information)
            TxtEmpName.Focus()
            Exit Sub
        End If
        If TxtDepartment.Text.Length = 0 Then
            MsgBox("Please Select the Department....", MsgBoxStyle.Information)
            TxtDepartment.Focus()
            Exit Sub
        End If
        If TxtLocation.Text.Length = 0 Then
            MsgBox("Please Select the Location or Store Name...", MsgBoxStyle.Information)
            TxtLocation.Focus()
            Exit Sub
        End If
      If TxtUserID.Text.Length < 6 Then
            MsgBox("The User ID need minimum 6 letters...", MsgBoxStyle.Information)
            TxtUserID.Focus()
            Exit Sub
        End If
        If IsNumeric(TxtUserID.Text.Substring(0, 1).ToString) = True Then
            MsgBox("Admin User name is invalide, can not start with digit..", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TxtCounterName.Text.Length = 0 Then
            MsgBox("Please Select The Counter Name...", MsgBoxStyle.Information)
            TxtCounterName.Focus()
            Exit Sub
        End If
      
        TxtUserType.Text = "User"
        If IsAlterMode = True Then
            If UCase(TxtUserID.Text) <> UCase(OpenedUserID) Then
                If SQLIsFieldExists("SELECT userid FROM Users WHERE userid=N'" & TxtUserID.Text & "'") = True Then
                    MsgBox("The User ID already Exists...    ", MsgBoxStyle.Information)
                    TxtUserID.Focus()
                    Exit Sub
                ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   COMPANY WHERE adminname=N'" & TxtUserID.Text & "'") = True Then
                    MsgBox("The User ID already Exists...    ", MsgBoxStyle.Information)
                    TxtUserID.Focus()
                    Exit Sub
                End If
            End If
        Else
            If SQLIsFieldExists("SELECT userid FROM Users WHERE userid=N'" & TxtUserID.Text & "'") = True Then
                MsgBox("The User ID already Exists...    ", MsgBoxStyle.Information)
                TxtUserID.Focus()
                Exit Sub
            ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   COMPANY WHERE adminname=N'" & TxtUserID.Text & "'") = True Then
                MsgBox("The User ID already Exists...    ", MsgBoxStyle.Information)
                TxtUserID.Focus()
                Exit Sub
            End If

        End If

        If TxtPassword1.Text.Length < 6 Then
            MsgBox("The Password need minimum 6 letters...", MsgBoxStyle.Information)
            TxtPassword1.Focus()
            Exit Sub
        End If
        If TxtPassword1.Text <> TxtPassword2.Text Then
            MsgBox("The passwords does not match ....", MsgBoxStyle.Information)
            TxtPassword1.Focus()
            Exit Sub
        End If
        If ValidateEmailID(TxtEmailID.Text) = False Then
            MsgBox("The Email ID is not valid ..        ", MsgBoxStyle.Information)
            TxtEmailID.Focus()
            Exit Sub
        End If

        If IsAlterMode = True Then
            If UCase(OpenedEmailId) <> UCase(TxtEmailID.Text) Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   users where UserEmailID=N'" & TxtEmailID.Text & "'") = True Then
                    MsgBox("The Entered Email ID is already exists...    ", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
            If MsgBox("Do you want to Alter ?                ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveData()
                Me.Close()
            End If
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   users where UserEmailID=N'" & TxtEmailID.Text & "'") = True Then
                MsgBox("The Entered Email ID is already exists...    ", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("Do you want to Create ?                ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveData()
            End If
        End If
    End Sub

    Private Sub TxtEmpName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmpName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            Dim k As New CreateEmployee
            k.ShowDialog()
            LoadDataIntoComboBox("select EmpName from Employees where isactive=1 and isdelete=0 and empname not in (select UserName from users)", TxtEmpName, "EmpName")
        End If
    End Sub


    Private Sub TxtDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepartment.SelectedIndexChanged, TxtCounterName.SelectedIndexChanged

    End Sub

    Private Sub TxtPassword1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPassword1.TextChanged, TxtPassword2.TextChanged
        CheckPwd()
    End Sub
    Sub CheckPwd()
        If TxtPassword1.Text.Length < 6 Or TxtPassword2.Text.Length < 6 Then
            IsPwdMatch.Text = "Max of length is 6 letter "
            IsPwdMatch.ForeColor = Color.DarkRed
        ElseIf TxtPassword1.Text = TxtPassword2.Text Then
            IsPwdMatch.Text = "Passwords Match"
            IsPwdMatch.ForeColor = Color.DarkGreen
        Else

            IsPwdMatch.Text = "Passwords Does't Match"
            IsPwdMatch.ForeColor = Color.DarkRed
        End If
    End Sub

    Private Sub TxtEmailID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmailID.LostFocus
        If ValidateEmailID(TxtEmailID.Text) = True Then
            TxtEmailID.ForeColor = Color.DarkGreen
        Else
            TxtEmailID.ForeColor = Color.DarkRed
        End If
    End Sub

    Private Sub TxtEmailID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmailID.TextChanged

    End Sub

    Private Sub TxtUserID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUserID.LostFocus
        If IsAlterMode = True Then
            If UCase(TxtUserID.Text) <> UCase(OpenedUserID) Then
                If SQLIsFieldExists("SELECT userid FROM Users WHERE userid=N'" & TxtUserID.Text & "'") = True Then
                    IsUserAvailable.Text = "Already Used"
                    IsUserAvailable.ForeColor = Color.DarkRed
                    Exit Sub
                ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   COMPANY WHERE adminname=N'" & TxtUserID.Text & "'") = True Then
                    IsUserAvailable.Text = "Already Used"
                    IsUserAvailable.ForeColor = Color.DarkRed
                    Exit Sub
                Else
                    IsUserAvailable.Text = "User ID is Available"
                    IsUserAvailable.ForeColor = Color.DarkGreen
                End If

            End If
        Else
            If SQLIsFieldExists("SELECT userid FROM Users WHERE userid=N'" & TxtUserID.Text & "'") = True Then
                IsUserAvailable.Text = "Already Used"
                IsUserAvailable.ForeColor = Color.DarkRed
                TxtUserID.Focus()
                Exit Sub
            ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   COMPANY WHERE adminname=N'" & TxtUserID.Text & "'") = True Then
                IsUserAvailable.Text = "Already Used"
                IsUserAvailable.ForeColor = Color.DarkRed
                TxtUserID.Focus()
                Exit Sub
            Else
                IsUserAvailable.Text = "User ID is Available"
                IsUserAvailable.ForeColor = Color.DarkGreen
            End If

        End If
    End Sub

    Private Sub TxtUserID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUserID.TextChanged

    End Sub

    Private Sub TxtLocation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtLocation.SelectedIndexChanged
        LoadDataIntoComboBox("select CounterName from counters where locationname=N'" & TxtLocation.Text & "'", TxtCounterName, "CounterName", "None")

    End Sub
End Class
