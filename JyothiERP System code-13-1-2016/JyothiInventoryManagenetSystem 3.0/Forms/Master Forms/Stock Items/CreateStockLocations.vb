Imports System.Windows.Forms

Public Class CreateStockLocations
    Dim IsAlter As Boolean = False
    Dim AlterLocationName As String = ""
    Dim IsDefaultLocationName As Integer = 0
    Sub New(Optional ByVal vLocationName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If vLocationName.Length > 0 Then
            IsAlter = True
            Me.Text = "ALTER A LOCATION"
            Label1.Text = "ALTER A LOCATION"
            AlterLocationName = vLocationName
            BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.save
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtStockLocation.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Stock Location Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtStockLocation.Focus()
            Exit Sub

        End If
        TxtStockLocation.Text = TxtStockLocation.Text.Trim
        If IsAlter = True Then
            If (TxtStockLocation.Text <> AlterLocationName) Then
                If UCase(Replace(TxtStockLocation.Text, " ", "")) <> UCase(Replace(AlterLocationName, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   stocklocations where locationtemp=N'" & Replace(TxtStockLocation.Text, " ", "") & "'") = True Then
                        MsgBox("The Entered Stock Location is already exist..", MsgBoxStyle.Information)
                        TxtStockLocation.Focus()
                        Exit Sub
                    End If
                End If


            End If

            If MsgBox("Do you want to Alter ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            If SQLGetNumericFieldValue("select count(userid) as ct from users where islogin='True'", "ct") = 0 Then

                IsDefaultLocationName = SQLGetNumericFieldValue("select IsDefault from StockLocations WHERE locationname=N'" & AlterLocationName & "'", "IsDefault")

                Dim Sqlstr As String = ""
                Sqlstr = "UPDATE [StockLocations]     SET [locationname] = @locationname ,[locationtemp] = @locationtemp ,[Isvisible] = @Isvisible ,[IsDefault] = @IsDefault,[IsDelete] = @IsDelete,[ADDRESS] = @ADDRESS,[CITY] = @CITY,[contactno] = @contactno,[contactperson] = @contactperson,[email] = @email WHERE locationname=N'" & AlterLocationName & "'"
                SaveData(Sqlstr)
                If (TxtStockLocation.Text <> AlterLocationName) Then
                    ExecuteSQLQuery("EXEC UPDATELOCATIONNAMES N'" & TxtStockLocation.Text & "',N'" & AlterLocationName & "'")
                   
                End If

            Else
                MsgBox("The some of users are in logged, The modification is not possible to prevent data...")
            End If

        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   stocklocations where locationtemp=N'" & Replace(TxtStockLocation.Text, " ", "").ToString & "'") = True Then
                MsgBox("The Entered Stock Location is already exist..", MsgBoxStyle.Information)
                TxtStockLocation.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to create ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim sqlstr As String = ""
            Sqlstr = " INSERT INTO [StockLocations] ([locationname],[locationtemp],[Isvisible],[IsDefault],[IsDelete],[ADDRESS],[CITY],[contactno],[contactperson],[email])     VALUES " _
         & " (@locationname,@locationtemp,@Isvisible,@IsDefault,@IsDelete,@ADDRESS,@CITY,@contactno,@contactperson,@email) "

            SaveData(sqlstr)
            'CREATING INVOICE NUMBER SETTING FOR THIS LOCATIONS
            ExecuteSQLQuery("EXEC INSERTNEWSETTINGSLOC N'" & TxtStockLocation.Text & "'")


            TxtStockLocation.Text = ""
            TxtStockLocation.Focus()

            TxtStatus.Text = "Status: Success..."
            Timer1.Enabled = True
        End If
       
        
        If IsAlter = True Then
            Me.Close()
        End If
    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtStockLocation.Focus()
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

    Private Sub CreateStockLocations_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStockLocation.Text = AlterLocationName
        If IsAlter = True Then
            LoadStockLocaionDetails()
            BtnCreate.Text = "&Alter"
        End If
    End Sub


    Sub SaveData(ByVal Sqlstr As String)
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBFR = New SqlClient.SqlCommand(Sqlstr, MAINCON)
        With DBFR.Parameters
            .AddWithValue("locationname", TxtStockLocation.Text)
            .AddWithValue("locationtemp", TxtStockLocation.Text.Replace(" ", ""))
            .AddWithValue("Isvisible", 1)
            .AddWithValue("IsDefault", IsDefaultLocationName)
            .AddWithValue("IsDelete", 0)
            .AddWithValue("ADDRESS", txtaddress.Text)
            .AddWithValue("CITY", txtcity.Text)
            .AddWithValue("contactno", txtcontactno.Text)
            .AddWithValue("contactperson", txtpname.Text)
            .AddWithValue("email", txtemailid.Text)
        End With
        DBFR.ExecuteNonQuery()
        DBFR = Nothing
        MAINCON.Close()

       
    End Sub

    Sub LoadStockLocaionDetails()
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "select * from StockLocations  WHERE locationname=N'" & AlterLocationName & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtStockLocation.Text = AlterLocationName
                txtaddress.Text = Sreader("address").ToString
                txtcity.Text = Sreader("CITY").ToString
                txtcontactno.Text = Sreader("contactno").ToString
                txtpname.Text = Sreader("contactperson").ToString
                txtemailid.Text = Sreader("email").ToString

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
    End Sub


    
End Class
