Module ClientModules
    Public IsUserAdmin As Boolean = True
    Public pwdtextvalues As String = ""
    Public AllowedUserDepartmentLists As New ComboBox
    Public IsDefaultColorScheme As Boolean = True
    Public IsAllowSalesPersoninCostcentere As Boolean = False

    Public Function IsthereanyUsersLogin() As Boolean
        If SQLGetNumericFieldValue("select count(userid) as ct from users where islogin='True' and userid<>N'" & CurrentUserName & "'", "ct") = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
   
    Public Structure CustEmailValuesStruct
        Dim TODAYDATE As String
        Dim INVOICENO As String
        Dim INVOICEDATE As String
        Dim PARTYNAME As String
        Dim CURRENTAMOUNT As String
        Dim INVOICEBALANCE As String
        Dim PAYMENTBY As String
        Dim BALANCE As String
        Dim EmailID As String
        Dim issendemail As Boolean
        Dim isattachfile As Boolean
        Dim attachfilename As String
        Dim emailsubject As String
        Dim emailmessage As String
    End Structure
    Public Sub UpdateUserLogin()
        Dim SqlStr As String = ""
        SqlStr = "INSERT INTO [UserLogFile]([UserName],[LoginTime],[LogoutTime],[LiveTime],[SystemName],[LoginTimeValue],[Transcode])" _
            & " VALUES (@UserName,@LoginTime,@LogoutTime,@LiveTime,@SystemName,@LoginTimeValue,@Transcode)"
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()

        Try
            Dim DBF1 As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF1.Parameters
                .AddWithValue("UserName", CurrentUserName)
                .AddWithValue("LoginTime", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .AddWithValue("LogoutTime", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .AddWithValue("LiveTime", 0)
                .AddWithValue("SystemName", System.Environment.MachineName)
                .AddWithValue("LoginTimeValue", Now.Date.ToOADate)
                .AddWithValue("Transcode", UserLogInlogoutID)
            End With
            DBF1.ExecuteNonQuery()
            DBF1.Dispose()
        Catch ex As Exception

        End Try
        MAINCON.Close()

        If IsUserAdmin = False Then
            Try
                ExecuteSQLQuery("update users set IsLogin='True',LoginTime=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "',101), LoginSystemName=N'" & System.Environment.MachineName & "' where UserID=N'" & CurrentUserName & "'")
            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Function IsUserAlreadyLogin(ByVal username As String) As Boolean
        Dim result As Boolean = False
        result = SQLGetBooleanFieldValue("select islogin from users where UserID=N'" & username & "'", "islogin")
        Return result
    End Function
    Public Function IsAdminAlreadyLogin(ByVal username As String) As Boolean
        Dim result As Boolean = False
        result = SQLGetBooleanFieldValue("select islogin from users where UserID=N'" & username & "'", "islogin")
        Return result
    End Function
    Public Sub UpdateUserLogOff()
        'CONVERT(datetime, 25-02-2012, 101)
        ExecuteSQLQuery("update userlogfile set logouttime=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "',101)  where transcode=" & UserLogInlogoutID)
        If IsUserAdmin = False Then
            Try
                ExecuteSQLQuery("update users set IsLogin='False',LogoutTime=CONVERT(datetime,'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "',101) where UserID=N'" & CurrentUserName & "'")
            Catch ex As Exception

            End Try
        End If

        Try
            ExecuteSQLQuery("DELETE FROM LOCKTRANS WHERE USERNAME=N'" & CurrentUserName & "' AND SYSTEMNAME=N'" & System.Environment.MachineName & "'")
        Catch ex As Exception

        End Try
    End Sub
    Public Function GetLocation() As String
        Dim Loc As String = ""
        Loc = SQLGetStringFieldValue("select LocationName from users where userid=N'" & CurrentUserName & "'", "LocationName")
        If Loc.Length = 0 Then
            Loc = GetDefLocationName()
        End If
        Return Loc
    End Function
    Public Function GetDefLocationName() As String
        Return SQLGetStringFieldValue("select locationname from stocklocations where IsDefault=1", "locationname")
    End Function
    Public Function DefStoreName() As String
        Dim k As String = ""
        k = SQLGetStringFieldValue("select StoreName from users where userid=N'" & CurrentUserName & "'", "StoreName")
        If k.Length = 0 Then
            k = "MainLocation"
        End If
        Return k
    End Function
    Public Function DefDepartment() As String
        Dim k As String = ""
        k = SQLGetStringFieldValue("select UserDepartment from users where userid=N'" & CurrentUserName & "'", "UserDepartment")
        If k.Length = 0 Then
            k = ""
        End If
        Return k
    End Function
    Public Sub SetUserSoftwareSettings()
        Dim SQLstr As String = ""


        SQLstr = "select * from users where userid=N'" & CurrentUserName & "'"
        Dim SqlConn As New SqlClient.SqlConnection
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
                DefaultLocation = Sreader("LocationName").ToString.Trim
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
    Sub SetMenusForUsers()
        If IsUserAdmin = False Then
            MainForm.MainMenuProduction.Visible = False

            MainForm.MainMenu.Visible = True
            MainForm.CompanyToolsToolStripMenuItem.Visible = False
            MainForm.MenuSettings.Visible = False
            MainForm.MenuAccounts.Visible = False
            MainForm.MenuSales.Visible = False
            MainForm.MenuPurchase.Visible = False
            MainForm.MenuInventory.Visible = False
            MainForm.MenuAdminPayroll.Visible = False
            MainForm.MenuCompany.Visible = False
            MainForm.MenuReport.Visible = False
            MainForm.FinanceMainMenu.Visible = False

            MainForm.CompanyToolsToolStripMenuItem.Enabled = False
            MainForm.MenuSettings.Enabled = False
            MainForm.MenuAccounts.Enabled = False
            MainForm.MenuSales.Enabled = False
            MainForm.MenuPurchase.Enabled = False
            MainForm.MenuInventory.Enabled = False
            MainForm.MenuAdminPayroll.Enabled = False
            MainForm.MenuCompany.Enabled = False
            MainForm.MenuReport.Enabled = False
            MainForm.FinanceMainMenu.Enabled = False
            MainForm.MainMenuProduction.Enabled = False
            MainForm.MenuUserSettings.Visible = True
            If AllowedUserDepartmentLists.Items.Contains("Sales") = True Then
                MainForm.MenuSales.Visible = True
                MainForm.MenuSales.Enabled = True
                'ADDING SIDEBARS
                Dim adpanel1 As New SalesSideBarMenu
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)

            End If
            If AllowedUserDepartmentLists.Items.Contains("Purchase") = True Then
                MainForm.MenuPurchase.Visible = True
                MainForm.MenuPurchase.Enabled = True

                Dim adpanel1 As New PurchaseSideBarMenu
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)
            End If
            If AllowedUserDepartmentLists.Items.Contains("Inventory") = True Then
                MainForm.MenuInventory.Visible = True
                MainForm.MenuInventory.Enabled = True

                Dim adpanel1 As New InventorySideBarMenu
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)
            End If
            If AllowedUserDepartmentLists.Items.Contains("Accounts & Finance") = True Then
                MainForm.MenuAccounts.Visible = True
                MainForm.MenuReport.Visible = True
                MainForm.FinanceMainMenu.Visible = True

                MainForm.MenuAccounts.Enabled = True
                MainForm.MenuReport.Enabled = True
                MainForm.FinanceMainMenu.Enabled = True

                Dim adpanel1 As New AccountFinanceSideBarMenu
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)

            End If
            'Accounts Only
            If AllowedUserDepartmentLists.Items.Contains("Accounts Only") = True Then
                MainForm.MenuAccounts.Visible = True
                MainForm.MenuReport.Visible = True

                MainForm.MenuAccounts.Enabled = True
                MainForm.MenuReport.Enabled = True

                Dim adpanel1 As New AccountOnlySideBar
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)

            End If
            If AllowedUserDepartmentLists.Items.Contains("Admin & Payroll") = True Then
                MainForm.MenuAdminPayroll.Visible = True
                MainForm.MainMenuAdminOnly.Visible = True

                MainForm.MenuAdminPayroll.Enabled = True
                MainForm.MainMenuAdminOnly.Enabled = True
                Dim adpanel1 As New AdminPayrollSideBarMenu
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)

            End If
            If AllowedUserDepartmentLists.Items.Contains("Master") = True Then

                MainForm.MenuInventory.Visible = True
                MainForm.MenuPurchase.Visible = True
                MainForm.MenuSales.Visible = True
                MainForm.MenuReport.Visible = True

                MainForm.MenuInventory.Enabled = True
                MainForm.MenuPurchase.Enabled = True
                MainForm.MenuSales.Enabled = True
                MainForm.MenuReport.Enabled = True

                Dim adpanel1 As New MasterOnlySideBar
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)

            End If


            If AllowedUserDepartmentLists.Items.Contains("Admin") = True Then
                MainForm.MainMenuAdminOnly.Visible = True

                MainForm.MainMenuAdminOnly.Enabled = True

                Dim adpanel1 As New AdminOnlySideBar
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)


            End If

            If AllowedUserDepartmentLists.Items.Contains("Payroll") = True Then
                MainForm.MenuAdminPayroll.Visible = True

                MainForm.MenuAdminPayroll.Enabled = True

                Dim adpanel1 As New PayrollOnlySideBar
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainForm.MainPannelMaster.Controls.Add(adpanel1)


            End If
            If AllowedUserDepartmentLists.Items.Contains("Production") = True Then
                MainForm.MainMenuProduction.Visible = True
                MainForm.MainMenuProduction.Enabled = True
            End If
        Else
            MainForm.MainMenu.Visible = True
        End If
    End Sub

    Public Sub LoadUserRights()
        Dim SQLstr As String = ""
        Dim SqlConn As New SqlClient.SqlConnection

        SQLstr = "select * from UserRights where username=N'" & CurrentUserName & "'"
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
                    APPUserRights.IsEditable = True
                Else
                    APPUserRights.IsEditable = False
                End If

                If Sreader("IsDelete") = True Then
                    APPUserRights.IsDeleteble = True

                Else
                    APPUserRights.IsDeleteble = False

                End If

                If Sreader("IsReadOnly") = True Then
                    APPUserRights.IsAccessable = True

                Else
                    APPUserRights.IsAccessable = False
                End If

                If Sreader("IsFullRights") = True Then
                    APPUserRights.IsHasFullRights = True
                Else
                    APPUserRights.IsHasFullRights = False
                End If

                If Sreader("IsMaster") = True Then
                    APPUserRights.IsAccessMasters = True
                Else
                    APPUserRights.IsAccessMasters = False
                End If

                If Sreader("IsOptions") = True Then
                    APPUserRights.IsAdvanceUser = True
                Else
                    APPUserRights.IsAdvanceUser = False
                End If

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
    Public Function GetServiceLists(AppID As Long) As String
        Dim slist As String = ""
        Dim SqlConn2 As New SqlClient.SqlConnection
        Dim Sqlcmmd2 As New SqlClient.SqlCommand
        Try
            SqlConn2.ConnectionString = ConnectionStrinG
            SqlConn2.Open()
            Sqlcmmd2.Connection = SqlConn2
            Sqlcmmd2.CommandText = "SELECT ServiceName FROM AppointmentRows WHERE AppID=" & AppID
            Sqlcmmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd2.ExecuteReader
            While Sreader.Read()
                If slist.Length = 0 Then
                    slist = Sreader("ServiceName").ToString
                Else
                    slist = slist & "," & Sreader("ServiceName").ToString
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn2.Close()
            SqlConn2.Dispose()
            Sqlcmmd2.Connection = Nothing
        End Try
        Return slist
    End Function
End Module
