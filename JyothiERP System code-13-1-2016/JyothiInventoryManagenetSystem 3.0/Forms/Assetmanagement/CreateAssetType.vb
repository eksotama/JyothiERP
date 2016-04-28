Imports System.Windows.Forms

Public Class CreateAssetType
    Dim IsAlter As Boolean = False
    Dim AlterAssetTypeName As String = ""
    Sub New(Optional ByVal VAssetTypeName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If VAssetTypeName.Length > 0 Then
            IsAlter = True
            AlterAssetTypeName = VAssetTypeName
            BtnCreate.Text = "&Alter"
        End If
    End Sub
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtStockGroupName.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Asset Type Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtStockGroupName.Focus()
            Exit Sub
        End If
        If TxtunderGroup.Text.Trim.Length = 0 Then
            MsgBox("Please Select the Under Asset Type!! ", MsgBoxStyle.Critical, MySoftwareName)
            TxtunderGroup.Focus()
            Exit Sub
        End If
        If TxtStockGroupName.Text.Trim = TxtunderGroup.Text.Trim Then
            MsgBox("Error: The Group Names are same level...", MsgBoxStyle.Information)
            TxtunderGroup.Focus()
            Exit Sub
        End If
        If IsAlter = True Then
            If UCase(TxtStockGroupName.Text) <> UCase(AlterAssetTypeName) Then
                If UCase(Replace(TxtStockGroupName.Text, " ", "")) <> UCase(Replace(AlterAssetTypeName, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from  assetgroups where AssetGroupNameTemp=N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "'") = True Then
                        MsgBox("The Entered Asset Type is already exist..", MsgBoxStyle.Information)
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

            ExecuteSQLQuery("Delete from assetgroups where AssetGroupName=N'" & AlterAssetTypeName & "'")
            glevel = SQLGetNumericFieldValue("select grouplevel from assetgroups where AssetGroupNameTemp=N'" & Replace(TxtunderGroup.Text, " ", "").ToString & "'", "grouplevel")

            SqlStr = "INSERT INTO [assetgroups] ([AssetGroupName],[AssetGroupNameTemp],[groupRoot],[grouplevel]) " _
                & "VALUES(N'" & TxtStockGroupName.Text & "',N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "',N'" & TxtunderGroup.Text & "'," & glevel + 1 & ")"

            ExecuteSQLQuery(SqlStr)
            ExecuteSQLQuery("UPDATE assetgroups SET groupRoot=N'" & TxtStockGroupName.Text & "' WHERE groupRoot=N'" & AlterAssetTypeName & "'")


            ReArrangeAssetTypes()

            ExecuteSQLQuery("UPDATE assets SET assettype=N'" & TxtStockGroupName.Text & "' WHERE assettype=N'" & AlterAssetTypeName & "'")


            Me.Close()
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from  assetgroups where AssetGroupNameTemp=N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "'") = True Then
                MsgBox("The Entered Asset Type is already exist..", MsgBoxStyle.Information)
                TxtStockGroupName.Focus()
                Exit Sub
            End If

            If MsgBox("Do you want to create ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim SqlStr As String = ""
            Dim glevel As Integer = 0
            glevel = SQLGetNumericFieldValue("select grouplevel from assetgroups where AssetGroupNameTemp=N'" & Replace(TxtunderGroup.Text, " ", "").ToString & "'", "grouplevel")

            SqlStr = "INSERT INTO [assetgroups] ([AssetGroupName],[AssetGroupNameTemp],[groupRoot],[grouplevel]) " _
                & "VALUES(N'" & TxtStockGroupName.Text & "',N'" & Replace(TxtStockGroupName.Text, " ", "").ToString & "',N'" & TxtunderGroup.Text & "'," & glevel + 1 & ")"
            ExecuteSQLQuery(SqlStr)
            TxtStockGroupName.Text = ""
            TxtStockGroupName.Focus()
            ReArrangeAssetTypes()
            TxtStatus.Text = "Status: Success..."
            LoadDataIntoComboBox("select AssetGroupName from assetgroups", TxtunderGroup, "AssetGroupName")
            Timer1.Enabled = True
        End If


    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtStockGroupName.Focus()
    End Sub

    Private Sub CreateStockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsAlter = True Then
            LoadDataIntoComboBox("select AssetGroupName from assetgroups WHERE AssetGroupName<>N'" & AlterAssetTypeName & "'", TxtunderGroup, "AssetGroupName")
            TxtStockGroupName.Text = AlterAssetTypeName
            TxtunderGroup.Text = SQLGetStringFieldValue("SELECT GROUPROOT FROM assetgroups WHERE AssetGroupName=N'" & AlterAssetTypeName & "'", "GROUPROOT")
        Else
            LoadDataIntoComboBox("select AssetGroupName from assetgroups", TxtunderGroup, "AssetGroupName")
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
