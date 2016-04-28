Public Class AdminLogin
    Dim Count As Integer = 0
    Public pwdtextvalues As String = ""
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

        TxtSoftwareSQLDatabaseName = GetCompanyDatabaseName(TxtCmpName.Text)
        ConnectionStrinG = ConnectionStringFromFile & " Initial Catalog=" & TxtSoftwareSQLDatabaseName & ";"
        sqlstr = "SELECT * FROM COMPANY WHERE [adminname]='" & UsernameTextBox.Text & "' AND [adminpassword]='" & EncrypPassword(PasswordTextBox.Text) & "'"
        If SQLIsFieldExists(sqlstr) = False Then
            MsgBox("Invalid User Name or Password ", MsgBoxStyle.Information)
            ConnectionStrinG = ""
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.DialogResult = DialogResult.Cancel
        End
    End Sub

    Private Sub AdminLogin_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown

    End Sub

    Private Sub AdminLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TxtCmpName.Focus()
    End Sub

  
    Private Sub AdminLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDatabaseLists()
        LoadCompaniesList(TxtCmpName)
        TxtCmpName.Focus()
    End Sub
    Public Function SQLLoadGridData(ByVal SQLStr As String) As DataTable
        Dim TBD As New DataTable
        Dim SqlConn As New SqlClient.SqlConnection
        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            TBD.Locale = System.Globalization.CultureInfo.InvariantCulture
            Adapter.Fill(TBD)
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
        End Try

        Return TBD
    End Function
    Private Function LoadDatabaseLists() As Boolean
        Dim TempBS As New BindingSource
        CompaniesDatabaseLists.AllowUserToAddRows = False
        CompaniesDatabaseLists.AllowUserToDeleteRows = False
        CompaniesDatabaseLists.EditMode = DataGridViewEditMode.EditProgrammatically
        With CompaniesDatabaseLists
            ' TempBS.DataSource = SQLLoadGridData("SELECT NAME  FROM SYS.databases ")
            TempBS.DataSource = SQLLoadGridData("SELECT NAME AS [DBNAME], ' ' AS [CMPNAME] FROM SYS.databases WHERE NAME LIKE '" & NewCompanyDBName & "%'")
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        If CompaniesDatabaseLists.Rows.Count = 0 Then
            Return False

        Else
            Dim TCN As String = ""
            TCN = ConnectionStrinG
            For i As Integer = 0 To CompaniesDatabaseLists.RowCount - 1
                ConnectionStrinG = TCN & " Initial Catalog=" & CompaniesDatabaseLists.Item("DBNAME", i).Value & ";"
                CompaniesDatabaseLists.Item("cmpname", i).Value = SQLGetStringFieldValue("SELECT CompanyID AS TOT FROM company ", "TOT", "")
            Next
            ConnectionStrinG = TCN
            Return True
        End If
    End Function
    Public Function SQLGetStringFieldValue(ByVal SQLStr As String, ByVal GetFieldName As String, Optional ByVal DefReturn As String = "") As String
        Dim Retvalue As String
        Dim SqlConn As New SqlClient.SqlConnection

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                If IsDBNull(TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim) = True Then
                    Retvalue = ""
                Else
                    Retvalue = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                End If

            Else
                Retvalue = DefReturn
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = DefReturn
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try
        Return Retvalue
    End Function
    Public Function GETSQLDbCmpName(ByVal SQLStr As String, ByVal GetFieldName As String, Optional ByVal DefReturn As String = "") As String
        Dim Retvalue As String
        Dim SqlConn As New SqlClient.SqlConnection

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                If IsDBNull(TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim) = True Then
                    Retvalue = ""
                Else
                    Retvalue = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                End If
            Else
                Retvalue = DefReturn
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            Retvalue = DefReturn
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
        End Try
        Return Retvalue
    End Function
    Public Sub LoadCompaniesList(ByVal cob As ComboBox)
        cob.Items.Clear()
        For I As Integer = 0 To CompaniesDatabaseLists.RowCount - 1
            cob.Items.Add(CompaniesDatabaseLists.Item("CMPNAME", I).Value)
        Next

    End Sub
    Public Function GetCompanyDatabaseName(ByVal cmpname As String) As String
        Dim dBNAME As String = ""
        For I As Integer = 0 To CompaniesDatabaseLists.RowCount - 1
            If UCase(CompaniesDatabaseLists.Item("CMPNAME", I).Value) = UCase(cmpname) Then
                dBNAME = CompaniesDatabaseLists.Item("DBNAME", I).Value
                Exit For
            End If
        Next
        Return DbName
    End Function
End Class
