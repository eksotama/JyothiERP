Imports System.Windows.Forms

Public Class CreateNewCounterfrm

    Dim AlterCounterID As Integer = -1
    Sub New(Optional CounterID As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()
        AlterCounterID = CounterID
        If AlterCounterID > -1 Then
            Me.Text = "Alter Counter"
            Label1.Text = "ALTER A COUNTER"
            BtnCreate.Text = "&Alter"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtCounterName.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Counter  Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtCounterName.Focus()
            Exit Sub

        End If
        If TxtunderLocation.Text.Trim.Length = 0 Then
            MsgBox("Please Select the Location Name!! ", MsgBoxStyle.Critical, MySoftwareName)
            TxtunderLocation.Focus()
            Exit Sub
        End If


        If AlterCounterID > -1 Then
            If SQLIsFieldExists("select top 1 1 from counters where countername=N'" & TxtCounterName.Text & "' and locationname=N'" & TxtunderLocation.Text & "' AND COUNTERID<>" & AlterCounterID) = True Then
                MsgBox("The Counter Name is already exists, Please try again...", MsgBoxStyle.Information)
                Exit Sub
            Else
                If MsgBox("Do you want to save changes ?      ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                ExecuteSQLQuery("UPDATE COUNTERS SET CounterName=N'" & TxtCounterName.Text & "',LocationName=N'" & TxtunderLocation.Text & "' where counterid=" & AlterCounterID)
            End If
            Me.Close()
        Else
            If SQLIsFieldExists("select top 1 1 from counters where countername=N'" & TxtCounterName.Text & "' and locationname=N'" & TxtunderLocation.Text & "'") = True Then
                MsgBox("Counter Name is already exists for this location,please try again..", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("Do you want to Save New Counter?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("INSERT INTO COUNTERS (CounterName,LocationName) VALUES ( N'" & TxtCounterName.Text & "',N'" & TxtunderLocation.Text & "')")
                TxtCounterName.Text = ""
                TxtCounterName.Focus()
                TxtStatus.Text = "Status: Success..."
                Timer1.Enabled = True
            End If
           
        End If



    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtCounterName.Focus()
    End Sub

    Private Sub CreateStockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select locationname from StockLocations", TxtunderLocation, "locationname")
        If AlterCounterID > -1 Then
            Dim dt As New DataTable
            dt = SQLLoadGridData("select * from counters where counterid=" & AlterCounterID)
            If dt.Rows.Count > 0 Then
                TxtCounterName.Text = dt.Rows(0).Item("countername").ToString
                TxtunderLocation.Text = dt.Rows(0).Item("LocationName").ToString
            End If

            BtnCreate.Text = "Alter"
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
