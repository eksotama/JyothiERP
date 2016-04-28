Module Conns
    Public DefaultConnectionno As Integer = 1
    Public Connectionstrin1 As String = "Network Library=DBMSSOCN;Data Source=&servername&;User ID=&username&;password=&password&;"
    Public Connectionstrin2 As String = "Data Source=&servername&;User ID=&username&;password=&password&;"
    Public Connectionstrin3 As String = "Network Library=DBMSSOCN;Data Source=&servername&;Integrated Security=True;User ID=&username&;password=&password&;"
    Public Connectionstrin4 As String = "Data Source=&servername&;Integrated Security=True;User ID=&username&;password=&password&;"
    Public Connectionstrin5 As String = "Server=&servername&; User ID=&username&;password=&password&;"
    Public Connectionstrin6 As String = "Server=&servername&;Integrated Security=True; User ID=&username&;password=&password&;"
    Public Connectionstrin7 As String = "Network Library=DBMSSOCN,1433;Data Source=&servername&;Integrated Security=True;User ID=&username&;password=&password&;"


    Public IMSServerReq As New RequestStructure
    Structure RequestStructure
        Dim RequestSystemName As String
        Dim RequestID As Single
    End Structure
End Module
