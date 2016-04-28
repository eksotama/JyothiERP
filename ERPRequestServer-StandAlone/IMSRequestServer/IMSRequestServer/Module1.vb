
Imports System.IO

Module Module1
    Public DefaultConnectionno As Integer = 1
    Public Connectionstrin1 As String = "Network Library=DBMSSOCN;Data Source=&servername&;User ID=&username&;password=&password&;"
    Public Connectionstrin2 As String = "Data Source=&servername&;User ID=&username&;password=&password&;"
    Public Connectionstrin3 As String = "Network Library=DBMSSOCN;Data Source=&servername&;Integrated Security=True;User ID=&username&;password=&password&;"
    Public Connectionstrin4 As String = "Data Source=&servername&;Integrated Security=True;User ID=&username&;password=&password&;"
    Public Connectionstrin5 As String = "Server=&servername&; User ID=&username&;password=&password&;"
    Public Connectionstrin6 As String = "Server=&servername&;Integrated Security=True; User ID=&username&;password=&password&;"
    Public Connectionstrin7 As String = "Network Library=DBMSSOCN,1433;Data Source=&servername&;Integrated Security=True;User ID=&username&;password=&password&;"
    Public TxtSoftwareSQlServer As String = ""
    Public TxtSoftwareSQLDatabaseName As String = ""

    Public txtSoftwareSQlUserID As String = ""
    Public TxtSoftwareSQLPassword As String = ""
    Public TxtSoftwareSQLIPaddress As String = ""
    Public ConnectionStringFromFile As String = ""
    Public ConnectionStrinG As String = ""
    Public NewCompanyDBName As String = "MESWERPDBDD"
    'MESWERPDBDD
    Public txtSoftwareSQLdefaultCompany As String = "MESWERPDBDD"
    Public MainSqlConn As New SqlClient.SqlConnection
    Public Function TestSQLConnection() As Boolean
        Try
            MainSqlConn.ConnectionString = ConnectionStrinG
            MainSqlConn.Open()
            MainSqlConn.Close()


            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub GetSQLSettingFromFile()

        TxtSoftwareSQlServer = ""
        TxtSoftwareSQLIPaddress = ""
        TxtSoftwareSQLPassword = ""
        txtSoftwareSQlUserID = ""


        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\SQLSettings.dat") = False Then
                MsgBox("The file  SQLSettings.dat could not be read, it may not exists, Please consult your adimn")
                End
            End If
        Catch ex As Exception

        End Try

        Try
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\SQLSettings.dat")
                Dim line As String
                line = sr.ReadLine()
                If line = Nothing Then
                    TxtSoftwareSQlServer = ""
                Else
                    TxtSoftwareSQlServer = DecrypPassword(line)
                End If

                line = sr.ReadLine()
                If line = Nothing Then
                    txtSoftwareSQlUserID = ""
                Else
                    txtSoftwareSQlUserID = DecrypPassword(line)
                End If

                line = sr.ReadLine()
                If line = Nothing Then
                    TxtSoftwareSQLPassword = ""
                Else
                    TxtSoftwareSQLPassword = DecrypPassword(line)
                End If

                line = sr.ReadLine()
                If line = Nothing Then
                    TxtSoftwareSQLDatabaseName = ""
                Else
                    TxtSoftwareSQLDatabaseName = DecrypPassword(line)
                End If

                sr.Close()
            End Using
        Catch Ex As Exception

        Finally
            GetConnectionStringFromFile()
        End Try

    End Sub
    Public Sub GetConnectionStringFromFile()

        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\ConnectionString.dat") = False Then
                MsgBox("The file  ConnectionString.dat could not be read, it may not exists, Please consult your adimn")
                End
            End If
        Catch ex As Exception

        End Try
StartAgain:

        ConnectionStringFromFile = ""
        Try
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\ConnectionString.dat")
                ConnectionStringFromFile = sr.ReadLine()
                If ConnectionStringFromFile = Nothing Then
                    ConnectionStringFromFile = ""
                End If
                sr.Close()
            End Using
        Catch Ex As Exception

        Finally
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&servername&", TxtSoftwareSQlServer)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&username&", txtSoftwareSQlUserID)
            ConnectionStringFromFile = ConnectionStringFromFile.Replace("&password&", TxtSoftwareSQLPassword)
        End Try
        ConnectionStrinG = ConnectionStringFromFile
        If TestSQLConnection() = False Then
            End
        Else

        End If




    End Sub
    Public Function EncrypPassword(ByVal str As String) As String
        If str.Length = 0 Then
            Return ""
        Else
            Return Crypto.Encrypt(str, "")
        End If

    End Function
    Public Function DecrypPassword(ByVal str As String) As String
        If str.Length = 0 Then
            Return ""
        Else
            Return Crypto.Decrypt(str, "")
        End If
    End Function
    Public Function SQLIsFieldExists(ByVal SQLStr As String) As Boolean
        Dim Retvalue As Boolean = False
        Dim SqlConn As New SqlClient.SqlConnection
        ' SQLStr = "select * from Stockdbf where stockcode=N'Kybar' and stocksize=N'' and location=N'MainLocation' and batchno='1254' and expiry='2013-01-04'"
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue = True
            Else
                Retvalue = False
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = False
        Finally
            SqlConn.Close()

            SqlConn.Dispose()
        End Try
        Return Retvalue
    End Function
   
   
End Module
