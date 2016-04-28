Imports System.Windows.Forms

Public Class FrmNewSite
    Dim OpenedSitename As String = ""
    Dim OpenedSiteID As Integer = 0
    Sub New(Optional ID As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()
        OpenedSiteID = ID
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmNewSite_Load(sender As Object, e As System.EventArgs) Handles Me.Load
       OpenSitedata
    End Sub
    Sub OpenSitedata()

        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from sites where siteid=" & OpenedSiteID)
        If dt.Rows.Count > 0 Then
            TxtSiteName.Text = dt.Rows(0).Item("SiteName").ToString
            TxtAddress.Text = dt.Rows(0).Item("SiteAddress").ToString
            TxtContactno1.Text = dt.Rows(0).Item("ContactNo1").ToString
            TxtContactno2.Text = dt.Rows(0).Item("ContactNo2").ToString
            TxtDesc.Text = dt.Rows(0).Item("Description").ToString
            OpenedSitename = TxtSiteName.Text
            BtnCreate.Text = "&Alter"
            Me.Text = "Alter a Client"
            Label2.Text = "ALTER A CLIENT"
        End If
    End Sub
    Sub Loaddefs()
        TxtSiteName.Clear()
        TxtAddress.Clear()
        TxtContactno1.Clear()
        TxtContactno2.Clear()
        TxtDesc.Clear()


    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If TxtSiteName.Text.Length = 0 Then
            MsgBox("Please Enter the site name...", MsgBoxStyle.Information)
            TxtSiteName.Focus()
            Exit Sub
        End If
        If OpenedSiteID > 0 Then
            If OpenedSitename.ToUpper <> TxtSiteName.Text.ToUpper Then
                If SQLIsFieldExists("Select SiteName from sites where SiteName=N'" & TxtSiteName.Text & "'") = True Then
                    MsgBox("The site Name is already exists,Please try again...   ", MsgBoxStyle.Information)
                    TxtSiteName.Focus()
                    Exit Sub
                End If

            End If
            If MsgBox("Do you want to Alter a Site ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim sqlstr As String = ""
                sqlstr = "update [Sites] SET [SiteName]=@SiteName,[SiteAddress]=@SiteAddress,[ContactNo1]=@ContactNo1,[ContactNo2]=@ContactNo2,[Description]=@Description WHERE SITEID=" & OpenedSiteID
                Save(sqlstr)
                Me.Close()
            End If
        Else
            If SQLIsFieldExists("Select SiteName from sites where SiteName=N'" & TxtSiteName.Text & "'") = True Then
                MsgBox("The site Name is already exists,Please try again...   ", MsgBoxStyle.Information)
                TxtSiteName.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to Create a Site ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim sqlstr As String = ""
                sqlstr = "INSERT INTO [dbo].[Sites] ([SiteName],[SiteAddress],[ContactNo1],[ContactNo2],[Description])     VALUES (@SiteName,@SiteAddress,@ContactNo1,@ContactNo2,@Description) "
                Save(sqlstr)
                Loaddefs()
                TxtSiteName.Focus()
            End If
        End If
    End Sub
    Sub Save(sqlstr As String)
        Dim MAINCON As New SqlClient.SqlConnection
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("SiteName", TxtSiteName.Text)
            .AddWithValue("SiteAddress", TxtAddress.Text)
            .AddWithValue("ContactNo1", TxtContactno1.Text)
            .AddWithValue("ContactNo2", TxtContactno2.Text)
            .AddWithValue("Description", TxtDesc.Text)
            

        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
    End Sub
End Class
