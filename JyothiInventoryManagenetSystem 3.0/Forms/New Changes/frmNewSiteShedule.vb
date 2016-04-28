Imports System.Windows.Forms

Public Class frmNewSiteShedule

    Dim OpenID As Long = 0
    Sub New(Optional ID As Long = 0)

        ' This call is required by the designer.
        InitializeComponent()
        OpenID = ID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub Loaddefs()
        TxtClientName.Text = ""
        TxtEmployeeName.Text = ""
        TxtEndDate.Value = Today
        TxtStartDate.Value = Today
        TxtIsAccom.Text = ""
        TxtIsfood.Text = ""
        TxtWorkType.Text = ""
        TxtRateType.Text = "Daily"
        TxtIsTransport.Text = ""
        TxtRate.Text = "0"

        LoadDataIntoComboBox("Select ClientName from clients ", TxtClientName, "ClientName")
        LoadDataIntoComboBox("Select EmpName from Employees ", TxtEmployeeName, "EmpName")
        LoadDataIntoComboBox("Select distinct WorkType from Siteschedule ", TxtWorkType, "WorkType")
        LoadDataIntoComboBox("Select distinct Sponsorship from Siteschedule ", TxtSponsorship, "Sponsorship")
        LoadDataIntoComboBox("Select SiteName from Sites ", TxtSite, "SiteName")

    End Sub

    Private Sub frmNewSiteShedule_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtStartDate.Format = DateTimePickerFormat.Custom
        TxtStartDate.CustomFormat = CompDetails.DateFormattext & " hh:mm tt"
        TxtEndDate.Format = DateTimePickerFormat.Custom
        TxtEndDate.CustomFormat = CompDetails.DateFormattext & " hh:mm tt"
        Loaddefs()
        opendata()
    End Sub
    Sub opendata()
        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from Siteschedule where id=" & OpenID)
        If dt.Rows.Count > 0 Then
            TxtClientName.Text = SQLGetStringFieldValue("select clientname from clients where clientid=" & dt.Rows(0).Item("ClientID"), "clientname")
            TxtEmployeeName.Text = SQLGetStringFieldValue("select empname from Employees where empid=N'" & dt.Rows(0).Item("empid") & "'", "empname")
            TxtStartDate.Value = dt.Rows(0).Item("Startdate")
            TxtEndDate.Value = dt.Rows(0).Item("enddate")
            TxtIsAccom.Text = IIf(dt.Rows(0).Item("Accommodation") = True, "YES", "NO")
            TxtIsfood.Text = IIf(dt.Rows(0).Item("Food") = True, "YES", "NO")
            TxtWorkType.Text = dt.Rows(0).Item("WorkType")
            TxtIsTransport.Text = IIf(dt.Rows(0).Item("Transport") = True, "YES", "NO")
            TxtRate.Text = dt.Rows(0).Item("Rate")
            TxtRateType.Text = dt.Rows(0).Item("RateType").ToString
            txttotalworkinghours.Text = dt.Rows(0).Item("TotalHours")
            TxtSponsorship.Text = dt.Rows(0).Item("Sponsorship").ToString
            TxtSite.Text = SQLGetStringFieldValue("select sitename from sites where siteid=" & dt.Rows(0).Item("SiteID"), "Sitename")
        End If
    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        If TxtClientName.Text.Length = 0 Then
            MsgBox("Please Select Client Name . ..          ", MsgBoxStyle.Information)
            TxtClientName.Focus()
            Exit Sub
        End If
        If TxtSite.Text.Length = 0 Then
            MsgBox("Please Select the Site ", MsgBoxStyle.Information)
            TxtSite.Focus()
            Exit Sub
        End If
        If TxtEmployeeName.Text.Length = 0 Then
            MsgBox("Please Select Employee Name . ..          ", MsgBoxStyle.Information)
            TxtEmployeeName.Focus()
            Exit Sub
        End If
       
        If OpenID <> 0 Then
            If MsgBox("Do you want to Alter ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim sl As String = ""
                sl = "UPDATE Siteschedule SET ClientID=@ClientID,EmpID=@EmpID,WorkType=@WorkType,Rate=@Rate,Food=@Food,Accommodation=@Accommodation,Transport=@Transport,StartDate=@StartDate,EndDate=@EndDate,StartDateValue=@StartDateValue,EndDateValue=@EndDateValue,RateType=@RateType,TotalHours=@TotalHours ,Sponsorship=@Sponsorship,Siteid=@SiteID WHERE ID=" & OpenID
                Save(sl)
                Me.Close()
            End If
        Else
            If MsgBox("Do you want to Create ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim sl As String = ""
                sl = "INSERT INTO [dbo].[Siteschedule] ([ClientID],[EmpID],[WorkType],[Rate],[Food],[Accommodation],[Transport],[StartDate],[EndDate],[StartDateValue],[EndDateValue],RateType,TotalHours,Sponsorship,SiteID)     VALUES " _
                    & " (@ClientID,@EmpID,@WorkType,@Rate,@Food,@Accommodation,@Transport,@StartDate,@EndDate,@StartDateValue,@EndDateValue,@RateType,@TotalHours,@Sponsorship,@SiteID) "

                Save(sl)
                Loaddefs()
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
            .AddWithValue("ClientID", CInt(SQLGetNumericFieldValue("SELECT CLIENTID FROM CLIENTS WHERE CLIENTNAME=N'" & TxtClientName.Text & "'", "clientid")))
            .AddWithValue("EmpID", SQLGetStringFieldValue("SELECT empid FROM employees WHERE empname=N'" & TxtEmployeeName.Text & "'", "empid"))
            .AddWithValue("WorkType", TxtWorkType.Text)
            .AddWithValue("Rate", CDbl(TxtRate.Text))
            .AddWithValue("Food", IIf(TxtIsfood.Text.ToUpper = "YES", 1, 0))
            .AddWithValue("Accommodation", IIf(TxtIsAccom.Text.ToUpper = "YES", 1, 0))
            .AddWithValue("Transport", IIf(TxtIsTransport.Text.ToUpper = "YES", 1, 0))
            .AddWithValue("StartDate", TxtStartDate.Value)
            .AddWithValue("EndDate", TxtEndDate.Value)
            .AddWithValue("StartDateVALUE", TxtStartDate.Value.Date.ToOADate)
            .AddWithValue("EndDateVALUE", TxtEndDate.Value.Date.ToOADate)
            .AddWithValue("RateType", TxtRateType.Text)
            .AddWithValue("TotalHours", CDbl(txttotalworkinghours.Text))
            .AddWithValue("Sponsorship", TxtSponsorship.Text)
            .AddWithValue("SiteID", SQLGetNumericFieldValue("select siteid from sites where sitename=N'" & TxtSite.Text & "'", "siteid"))
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
    End Sub

    Private Sub TxtClientName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtClientName.SelectedIndexChanged
        LoadDataIntoComboBox("select sitename from ClientSites inner join sites on sites.SiteID=clientsites.SiteID where clientid=(select clientid from Clients where ClientName=N'" & TxtClientName.Text & "')", TxtSite, "SiteName")
        TxtSite.Text = ""
    End Sub

   

    Private Sub TxtEndDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtEndDate.ValueChanged, TxtStartDate.ValueChanged
        txttotalworkinghours.Text = DateDiff(DateInterval.Hour, TxtStartDate.Value, TxtEndDate.Value)
    End Sub
End Class
