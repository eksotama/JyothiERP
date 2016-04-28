Imports System.Windows.Forms

Public Class CreateStockGroups
    Dim IsAlter As Boolean = False
    Dim AlterStockGroupName As String = ""
    Sub New(Optional ByVal VStockName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If VStockName.Length > 0 Then
            IsAlter = True
            AlterStockGroupName = VStockName
            BtnCreate.Text = "&Alter"
            Label1.Text = "ALTER A STOCK GROUP"
            Me.Text = Label1.Text
            BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.save
        End If
    End Sub
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtStockGroupName.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Stock Group Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtStockGroupName.Focus()
            Exit Sub
        End If
        If TxtunderGroup.Text.Trim.Length = 0 Then
            MsgBox("Please Select the Under Stock Group!! ", MsgBoxStyle.Critical, MySoftwareName)
            TxtunderGroup.Focus()
            Exit Sub
        End If
        If TxtStockGroupName.Text.Trim = TxtunderGroup.Text.Trim Then
            MsgBox("Error: The Group Names are same level...", MsgBoxStyle.Information)
            TxtunderGroup.Focus()
            Exit Sub
        End If
        If IsAlter = True Then
            If UCase(TxtStockGroupName.Text) <> UCase(AlterStockGroupName) Then
                If UCase(Replace(TxtStockGroupName.Text, " ", "")) <> UCase(Replace(AlterStockGroupName, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   stockgroups where StockgroupNameTemp=N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "'") = True Then
                        MsgBox("The Entered Stock Group is already exist..", MsgBoxStyle.Information)
                        TxtStockGroupName.Focus()
                        Exit Sub
                    End If
                End If


            End If

            If MsgBox("Do you want to Alter ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim SqlStr As String = ""
            Dim glevel As Integer = 0

            ExecuteSQLQuery("Delete from stockgroups where stockgroupname=N'" & AlterStockGroupName & "'")
            glevel = SQLGetNumericFieldValue("select grouplevel from stockgroups where StockgroupNameTemp=N'" & Replace(TxtunderGroup.Text, " ", "").ToString & "'", "grouplevel")

            SqlStr = "INSERT INTO [stockgroups] ([StockgroupName],[StockgroupNameTemp],[groupRoot],[grouplevel]) " _
                & "VALUES(N'" & TxtStockGroupName.Text & "',N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "',N'" & TxtunderGroup.Text & "'," & glevel + 1 & ")"

            ExecuteSQLQuery(SqlStr)
            ExecuteSQLQuery("UPDATE stockgroups SET groupRoot=N'" & TxtStockGroupName.Text & "' WHERE groupRoot=N'" & AlterStockGroupName & "'")


            ReArrangeStockGroups()

            ExecuteSQLQuery("UPDATE STOCKDBF SET STOCKGROUP=N'" & TxtStockGroupName.Text & "' WHERE STOCKGROUP=N'" & AlterStockGroupName & "'")
            ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET STOCKGROUP=N'" & TxtStockGroupName.Text & "' WHERE STOCKGROUP=N'" & AlterStockGroupName & "'")

            Me.Close()
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   stockgroups where StockgroupNameTemp=N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "'") = True Then
                MsgBox("The Entered Stock Group is already exist..", MsgBoxStyle.Information)
                TxtStockGroupName.Focus()
                Exit Sub
            End If

            If MsgBox("Do you want to create ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim SqlStr As String = ""
            Dim glevel As Integer = 0
            glevel = SQLGetNumericFieldValue("select grouplevel from stockgroups where StockgroupNameTemp=N'" & Replace(TxtunderGroup.Text, " ", "").ToString & "'", "grouplevel")

            SqlStr = "INSERT INTO [stockgroups] ([StockgroupName],[StockgroupNameTemp],[groupRoot],[grouplevel]) " _
                & "VALUES(N'" & TxtStockGroupName.Text & "',N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "',N'" & TxtunderGroup.Text & "'," & glevel + 1 & ")"
            ExecuteSQLQuery(SqlStr)
            TxtStockGroupName.Text = ""
            TxtStockGroupName.Focus()
            ReArrangeStockGroups()
            TxtStatus.Text = "Status: Success..."
            LoadDataIntoComboBox("select StockgroupName from Stockgroups", TxtunderGroup, "StockgroupName")
            Timer1.Enabled = True
        End If
        

    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ERPInitializeObjects(Me)
        TxtStockGroupName.Focus()
    End Sub

    Private Sub CreateStockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsAlter = True Then
            LoadDataIntoComboBox("select StockgroupName from Stockgroups WHERE STOCKGROUPNAME<>N'" & AlterStockGroupName & "'", TxtunderGroup, "StockgroupName")
            TxtStockGroupName.Text = AlterStockGroupName
            TxtunderGroup.Text = SQLGetStringFieldValue("SELECT GROUPROOT FROM STOCKGROUPS WHERE STOCKGROUPNAME=N'" & AlterStockGroupName & "'", "GROUPROOT")
        Else
            LoadDataIntoComboBox("select StockgroupName from Stockgroups", TxtunderGroup, "StockgroupName")
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
