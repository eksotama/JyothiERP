Imports System.Windows.Forms

Public Class CreateSalesPersons
    Dim AlterSalesPerson As String = ""
    Dim IsAlter As Boolean = False

#Region "Functions"
    Sub New(Optional ByVal VsalesPerson As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If VsalesPerson.Length > 0 Then
            IsAlter = True
            AlterSalesPerson = VsalesPerson
        Else
            IsAlter = False
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadDefaults()
        TxtName.Text = ""
        TxtAddress.Text = ""
        TxtGender.Text = "Male"
        TxtEmail.Text = ""
        TxtCity.Text = ""
        TxtContactno.Text = ""
    End Sub
    Sub LoadSalesPersonDetails()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from salespersons where salespersonname=N'" & AlterSalesPerson & "'"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                TxtName.Text = AlterSalesPerson
                TxtAddress.Text = Sreader("Address").ToString.Trim
                TxtGender.Text = Sreader("Gender").ToString.Trim
                TxtContactno.Text = Sreader("Tel").ToString.Trim
                TxtCity.Text = Sreader("state").ToString.Trim
                TxtEmail.Text = Sreader("emailid").ToString.Trim
                TxtCommisition.Text = Sreader("per")

            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing
        End Try
    End Sub
#End Region

    Private Sub CreateSalesPersons_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtName.Focus()
    End Sub


    Private Sub CreateSalesPersons_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsAlter = True Then
            LoadDefaults()
            LoadSalesPersonDetails()
        Else
            LoadDefaults()
        End If

    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtName.Text.Length < 3 Then
            MsgBox("Please Enter the Sales Person Name  . . ", MsgBoxStyle.Information)
            TxtName.Focus()
            Exit Sub
        End If
        If IsAlter = True Then
            If UCase(TxtName.Text) <> UCase(AlterSalesPerson) Then
                If UCase(Replace(TxtName.Text, " ", "")) <> UCase(Replace(AlterSalesPerson, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   salespersons where salespersonname=N'" & TxtName.Text.Trim & "'") = True Then
                        MsgBox("The Entered Sales Person Name  is already exist..", MsgBoxStyle.Information)
                        TxtName.Focus()
                        Exit Sub
                    End If
                    If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & TxtName.Text & "'") = True Then
                        MsgBox("The Employee Name is already exists, Please try again....", MsgBoxStyle.Critical)
                        TxtName.Focus()
                        Exit Sub
                    End If
                End If

            End If

            If MsgBox("Do you want to Modify  ?       ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            ExecuteSQLQuery("delete from salespersons where salespersonname=N'" & AlterSalesPerson & "'")
            Dim SqlStr As String = ""
            SqlStr = "INSERT INTO [salespersons] ([salespersonname],[Address],[Gender],[state],[country],[Tel],[emailid],[Isactive],[per]) " _
               & "VALUES(N'" & TxtName.Text & "',N'" & TxtAddress.Text & "',N'" & TxtGender.Text & "',N'" & TxtCity.Text & "','',N'" & TxtContactno.Text & "',N'" & TxtEmail.Text & "',1," & CDbl(TxtCommisition.Text) & ")"
            ExecuteSQLQuery(SqlStr)
            ExecuteSQLQuery("update StockInvoiceDetails set salesperson=N'" & TxtName.Text & "' where salesperson=N'" & AlterSalesPerson & "'")

            ExecuteSQLQuery("UPDATE CostCenterNames SET CostName=N'" & TxtName.Text & "' WHERE CostName=N'" & AlterSalesPerson & "'")
            ExecuteSQLQuery("UPDATE CostCenterBook SET CostCenterName=N'" & TxtName.Text & "' WHERE CostCenterName=N'" & AlterSalesPerson & "'")
            Me.Close()
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   salespersons where salespersonname=N'" & TxtName.Text.Trim & "'") = True Then
                MsgBox("The Entered Sales Person Name  is already exist..", MsgBoxStyle.Information)
                TxtName.Focus()
                Exit Sub
            ElseIf SQLIsFieldExists("SELECT TOP 1 1 from   salespersons where salespersonname=N'" & Replace(TxtName.Text.Trim, " ", "") & "'") = True Then
                MsgBox("The Entered Sales Person Name  is already exist..", MsgBoxStyle.Information)
                TxtName.Focus()
                Exit Sub
            End If
            If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & TxtName.Text & "'") = True Then
                MsgBox("The Sales Name is already exists, Please try again....", MsgBoxStyle.Critical)
                TxtName.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to create  ?       ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim SqlStr As String = ""
            SqlStr = "INSERT INTO [salespersons] ([salespersonname],[Address],[Gender],[state],[country],[Tel],[emailid],[Isactive],[per]) " _
               & "VALUES(N'" & TxtName.Text & "',N'" & TxtAddress.Text & "',N'" & TxtGender.Text & "',N'" & TxtCity.Text & "','',N'" & TxtContactno.Text & "',N'" & TxtEmail.Text & "',1," & CDbl(TxtCommisition.Text) & ")"
            ExecuteSQLQuery(SqlStr)


            SqlStr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
              & "VALUES(N'" & TxtName.Text & "','*Primary',0,'SalesPersons')"
            ExecuteSQLQuery(SqlStr)

            TxtStatus.Text = "Status : Success.."
            Timer1.Enabled = True
            LoadDefaults()
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
