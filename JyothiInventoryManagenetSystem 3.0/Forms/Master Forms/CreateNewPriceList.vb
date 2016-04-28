Imports System.Windows.Forms

Public Class CreateNewPriceList

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CreateNewPriceList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        Txtpricelistname.Focus()

    End Sub
    Private Sub CreateNewPriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Txtpricelistname.Text = ""
    End Sub

   
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If Txtpricelistname.Text.Length = 0 Then
            MsgBox("Please Enter the Name of the Price List....")
            Txtpricelistname.Focus()
            Exit Sub
        End If
        Txtpricelistname.Text = Txtpricelistname.Text.Replace(" ", "")
        Dim err As Boolean = True
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            'CREATE A TABLE FILED IN STOCKDBF FOR RATE AND WITHTAX RATE
            SQLFcmd.CommandText = "ALTER TABLE stockdbf ADD " & Txtpricelistname.Text & " float  "
            SqlFcmd.CommandType = CommandType.Text
            SqlFcmd.ExecuteNonQuery()
        Catch ex As Exception
            err = False
        Finally
            SqlConn.Close()

            SqlFcmd.Connection = Nothing
        End Try
        If err = True Then
            ExecuteSQLQuery("INSERT INTO [PriceList] ([Pricelistname])  VALUES (N'" & Txtpricelistname.Text & "')")
        Else
            MsgBox("Entered Price List Name already Exist, Please Try again...")
            Exit Sub
        End If
        Txtpricelistname.Focus()
        Me.Close()
    End Sub
End Class
