Imports System.Windows.Forms

Public Class CreateStockCategories
    Dim IsAlterMode As Boolean = False
    Dim CatNametobeAlter As String = ""
    Sub New(Optional ByVal CategoryName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If CategoryName.Length > 0 Then
            IsAlterMode = True
            CatNametobeAlter = CategoryName
            TxtCatName.Text = CategoryName
            TxtunderCat.Text = SQLGetStringFieldValue("select groupRoot from categoriesgroups where StockCategoryName=N'" & TxtCatName.Text & "'", "groupRoot")
            BtnCreate.Text = "&Alter"
            Label1.Text = "ALTER STOCK CATEGORY"
            Me.Text = Label1.Text
            BtnCreate.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.save
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
  

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtCatName.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Category Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtCatName.Focus()
            Exit Sub

        End If
        If TxtunderCat.Text.Trim.Length = 0 Then
            MsgBox("Please Select the Category group!! ", MsgBoxStyle.Critical, MySoftwareName)
            TxtunderCat.Focus()
            Exit Sub
        End If
        If TxtunderCat.Text.Trim = TxtCatName.Text.Trim Then
            MsgBox("Error: The Group Names are same level...", MsgBoxStyle.Information)
            TxtunderCat.Focus()
            Exit Sub
        End If
        If IsAlterMode = True Then
            If UCase(TxtCatName.Text) <> UCase(CatNametobeAlter) Then
                If UCase(Replace(TxtCatName.Text, " ", "")) <> UCase(Replace(CatNametobeAlter, " ", "")) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   Categoriesgroups where StockCategoryNameTemp=N'" & Replace(TxtCatName.Text, " ", "").ToString & "'") = True Then
                        MsgBox("The Entered Category is already exist..", MsgBoxStyle.Information)
                        TxtCatName.Focus()
                        Exit Sub
                    End If
                End If

            End If
        Else
            If SQLIsFieldExists("SELECT TOP 1 1 from   Categoriesgroups where StockCategoryNameTemp=N'" & Replace(TxtCatName.Text, " ", "").ToString & "'") = True Then
                MsgBox("The Entered Category is already exist..", MsgBoxStyle.Information)
                TxtCatName.Focus()
                Exit Sub
            End If
        End If
       
        If IsAlterMode = True Then
            If MsgBox("Do you want to Alter ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM Categoriesgroups WHERE StockCategoryName=N'" & CatNametobeAlter & "'")
            Else
                Exit Sub
            End If

        Else
            If MsgBox("Do you want to create ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Dim SqlStr As String = ""
        Dim glevel As Integer = 0
        glevel = SQLGetNumericFieldValue("select grouplevel from Categoriesgroups where StockCategoryNameTemp=N'" & Replace(TxtunderCat.Text, " ", "").ToString & "'", "grouplevel")

        SqlStr = "INSERT INTO [Categoriesgroups] ([StockCategoryName],[StockCategoryNameTemp],[groupRoot],[grouplevel]) " _
            & "VALUES(N'" & TxtCatName.Text & "',N'" & Replace(TxtCatName.Text, " ", "").ToString & "',N'" & TxtunderCat.Text & "'," & glevel + 1 & ")"
        ExecuteSQLQuery(SqlStr)
        If IsAlterMode = True Then
            ExecuteSQLQuery("UPDATE Categoriesgroups SET groupRoot=N'" & TxtCatName.Text & "' WHERE groupRoot=N'" & CatNametobeAlter & "'")
            ExecuteSQLQuery("UPDATE STOCKDBF SET category=N'" & TxtCatName.Text & "' WHERE category=N'" & CatNametobeAlter & "'")


            ReArrangeStockCategories()

            Me.Close()

        Else
            TxtCatName.Text = ""
            TxtCatName.Focus()
            ReArrangeStockCategories()
            LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtunderCat, "StockCategoryName")
            TxtStatus.Text = "Status: Success..."
            Timer1.Enabled = True
        End If

      

    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtCatName.Focus()
    End Sub

    Private Sub CreateStockCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", TxtunderCat, "StockCategoryName")
        If IsAlterMode = True Then
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
