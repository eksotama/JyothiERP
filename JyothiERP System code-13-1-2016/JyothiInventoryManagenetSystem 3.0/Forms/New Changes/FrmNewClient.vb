Imports System.Windows.Forms

Public Class FrmNewClient

    Dim OpenedID As Integer = 0
    Dim OpenedClientName As String = ""
    Sub New(Optional ID As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()
        OpenedID = ID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub loaddefs()
        TxtClientName.Clear()
        TxtAddress.Clear()
        TxtContactno1.Clear()
        TxtContactno2.Clear()
        TxtContractType.Text = ""
        TxtDesc.Clear()
        TxtEmailID.Clear()
        TxtPeriod.Text = "0"
        TxtContactPerson.Clear()


    End Sub

    Private Sub FrmNewClient_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDataIntoComboBox("select distinct Cotracttype from Clients", TxtContractType, "Cotracttype")
        loaddefs()
        If OpenedID <> -1 Then

            BtnCreate.Text = "&Alter"
            Me.Text = "Alter a Client"
            Label2.Text = "ALTER A CLIENT"
            OpenCLientData()
        End If
    End Sub
    Sub OpenCLientData()

        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from Clients where ClientID=" & OpenedID)
        If dt.Rows.Count > 0 Then
            TxtClientName.Text = dt.Rows(0).Item("ClientName").ToString
            TxtAddress.Text = dt.Rows(0).Item("Address").ToString
            TxtContactno1.Text = dt.Rows(0).Item("ContactNo1").ToString
            TxtContactno2.Text = dt.Rows(0).Item("ContactNo2").ToString
            TxtDesc.Text = dt.Rows(0).Item("Description").ToString
            TxtEmailID.Text = dt.Rows(0).Item("EmailID").ToString
            TxtContractType.Text = dt.Rows(0).Item("Cotracttype").ToString
            TxtPeriod.Text = dt.Rows(0).Item("Period").ToString
            TxtContactPerson.Text = dt.Rows(0).Item("ContactPerson").ToString
            OpenedClientName = TxtClientName.Text
        End If
    End Sub
    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If TxtClientName.Text.Length = 0 Then
            MsgBox("Please Enter the Client Name ...", MsgBoxStyle.Information)
            TxtClientName.Focus()
            Exit Sub
        End If
        If OpenedID > 0 Then
            If OpenedClientName.ToUpper <> TxtClientName.Text.ToUpper Then
                If SQLIsFieldExists("Select ClientName from Clients where ClientName=N'" & TxtClientName.Text & "'") = True Then
                    MsgBox("The Client Name is already exists,Please try again...   ", MsgBoxStyle.Information)
                    TxtClientName.Focus()
                    Exit Sub
                End If

            End If
            If MsgBox("Do you want to Alter a Client ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim sqlstr As String = ""
                sqlstr = "update [Clients] SET [ClientName]=@ClientName,[Address]=@Address,[ContactNo1]=@ContactNo1,[ContactNo2]=@ContactNo2,[EmailID]=@EmailID,[Cotracttype]=@Cotracttype,[Period]=@Period,[ContactPerson]=@ContactPerson,[Description]=@Description WHERE ClientID=" & OpenedID
                Save(sqlstr)
                Me.Close()
            End If
        Else
            If SQLIsFieldExists("Select ClientName from Clients where ClientName=N'" & TxtClientName.Text & "'") = True Then
                MsgBox("The Client Name is already exists,Please try again...   ", MsgBoxStyle.Information)
                TxtClientName.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to Create a Client ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim sqlstr As String = ""
                sqlstr = " INSERT INTO [dbo].[Clients] ([ClientName],[Address],[ContactNo1],[ContactNo2],[EmailID],[Cotracttype],[Period],[ContactPerson],[Description])     VALUES (@ClientName,@Address,@ContactNo1,@ContactNo2,@EmailID,@Cotracttype,@Period,@ContactPerson,@Description) "
                Save(sqlstr)
                loaddefs()
                TxtClientName.Focus()
            End If
        End If
    End Sub
    Sub Save(sqlstr As String)
        Dim MAINCON As New SqlClient.SqlConnection
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("ClientName", TxtClientName.Text)
            .AddWithValue("Address", TxtAddress.Text)
            .AddWithValue("ContactNo1", TxtContactno1.Text)
            .AddWithValue("ContactNo2", TxtContactno2.Text)
            .AddWithValue("Description", TxtDesc.Text)
            .AddWithValue("EmailID", TxtEmailID.Text)
            .AddWithValue("Cotracttype", TxtContractType.Text)
            .AddWithValue("Period", CInt(TxtPeriod.Text))
            .AddWithValue("ContactPerson", TxtContactPerson.Text)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
    End Sub
End Class
