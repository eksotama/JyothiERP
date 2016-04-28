Imports System.Windows.Forms

Public Class CreateNewCostCenterNames


    Dim IsAlter As Boolean = False
    Dim AlterCostCenterName As String = ""
    Sub New(Optional ByVal CostCName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If CostCName.Length > 0 Then
            IsAlter = True
            AlterCostCenterName = CostCName
            BtnCreate.Text = "&Alter"
        End If
    End Sub
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtStockGroupName.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Cost Center Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtStockGroupName.Focus()
            Exit Sub
        End If
        If TxtunderGroup.Text.Trim.Length = 0 Then
            MsgBox("Please Select the Under Group!! ", MsgBoxStyle.Critical, MySoftwareName)
            TxtunderGroup.Focus()
            Exit Sub
        End If

        If IsAlter = True Then
            If UCase(TxtStockGroupName.Text) <> UCase(AlterCostCenterName) Then
                If UCase(Replace(TxtStockGroupName.Text, " ", "")) <> UCase(Replace(AlterCostCenterName, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   CostCenterNames where CostName=N'" & TxtStockGroupName.Text & "'") = True Then
                        MsgBox("The Entered Cost Center Name  is already exist..", MsgBoxStyle.Information)
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

            ExecuteSQLQuery("Delete from CostCenterNames where CostName=N'" & AlterCostCenterName & "'")
            SqlStr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                    & "VALUES('" & TxtStockGroupName.Text & "','" & TxtunderGroup.Text & "',0,'')"
            ExecuteSQLQuery(SqlStr)
            ExecuteSQLQuery("UPDATE CostCenterBook SET CostCenterName=N'" & TxtStockGroupName.Text & "' WHERE CostCenterName=N'" & AlterCostCenterName & "'")
            Me.Close()
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   CostCenters where StockgroupNameTemp=N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "'") = True Then
                MsgBox("The Entered Stock Group is already exist..", MsgBoxStyle.Information)
                TxtStockGroupName.Focus()
                Exit Sub
            End If
            If MsgBox("Do you want to create ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim SqlStr As String = ""
            Dim glevel As Integer = 0
            glevel = SQLGetNumericFieldValue("select grouplevel from CostCenters where StockgroupNameTemp=N'" & Replace(TxtunderGroup.Text, " ", "").ToString & "'", "grouplevel")

            SqlStr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                & "VALUES('" & TxtStockGroupName.Text & "','" & TxtunderGroup.Text & "',0,'')"
            ExecuteSQLQuery(SqlStr)
            TxtStockGroupName.Text = ""
            TxtStockGroupName.Focus()
            ReArrangeStockGroups()
            TxtStatus.Text = "Status: Success..."
            Timer1.Enabled = True
        End If


    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtStockGroupName.Focus()
    End Sub

    Private Sub CreateStockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsAlter = True Then
            LoadDataIntoComboBox("select StockgroupName from CostCenters WHERE STOCKGROUPNAME<>'" & AlterCostCenterName & "'", TxtunderGroup, "StockgroupName")
            TxtStockGroupName.Text = AlterCostCenterName
            TxtunderGroup.Text = SQLGetStringFieldValue("SELECT GROUPROOT FROM CostCenters WHERE STOCKGROUPNAME=N'" & AlterCostCenterName & "'", "GROUPROOT")
        Else
            LoadDataIntoComboBox("select StockgroupName from CostCenters", TxtunderGroup, "StockgroupName")
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
