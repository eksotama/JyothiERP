Imports System.Windows.Forms

Public Class CreateNewCurrency
    Dim CurToalter As String = ""
    Sub New(Optional ByVal alterCurrency As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If alterCurrency.Length > 0 Then
            CurToalter = alterCurrency

        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadCur()
        Dim sqltext As String
        sqltext = "select CurrencyCode from Currencies where CurrencyCode not in (select CurrencyCode from CurrencyList)"
        LoadDataIntoComboBox(sqltext, TxtCurCode, "CurrencyCode")
        TxtCurCode.Focus()
        TxtConRate.IsCurrencyRateBox = True

    End Sub
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtcurName.Text.Trim.Length = 0 Then
            MsgBox("Please Enter Currency  Name!!     ", MsgBoxStyle.Critical, MySoftwareName)
            TxtcurName.Focus()
            Exit Sub
        End If
        If TxtCurCode.Text.Trim.Length = 0 Then
            MsgBox("Please Select the Currency Code!! ", MsgBoxStyle.Critical, MySoftwareName)
            TxtCurCode.Focus()
            Exit Sub
        End If
        TxtCurCode.Text = UCase(TxtCurCode.Text)
        If CDbl(TxtConRate.Text) = 0 Then
            MsgBox("Please Enter the Conversion Rate ...")
            TxtConRate.Focus()
            Exit Sub
        End If
        If CurToalter.Length = 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   CurrencyList where currencycode=N'" & TxtCurCode.Text & "'") = True Then
                MsgBox("The Entered Currency  is already exist..", MsgBoxStyle.Information)
                TxtcurName.Focus()
                Exit Sub
            End If
        Else
            If UCase(CurToalter) <> UCase(TxtCurCode.Text) Then
                If SQLIsFieldExists("SELECT TOP 1 1 from   CurrencyList where currencycode=N'" & TxtCurCode.Text & "'") = True Then
                    MsgBox("The Entered Currency  is already exist..", MsgBoxStyle.Information)
                    TxtcurName.Focus()
                    Exit Sub
                End If
            End If
        End If
       
        Dim SqlStr As String = ""
        If CurToalter.Length = 0 Then
            If MsgBox("Do you want to create ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            If MsgBox("Do you want to Alter ?                ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                Exit Sub
            End If
            ExecuteSQLQuery("DELETE FROM CURRENCYLIST WHERE CURRENCYCODE=N'" & CurToalter & "'")
        End If
     
        SqlStr = "INSERT INTO [CurrencyList] ([CurrencyName],[CurrencyCode],[CurrencySymbol],[IsActive],[ConRate],[Demicals]) " _
        & "VALUES(N'" & TxtcurName.Text & "',N'" & TxtCurCode.Text & "',N'" & TxtCurSym.Text & "',1," & TxtConRate.Text & ",2)"
        ExecuteSQLQuery(SqlStr)

     
        TxtcurName.Text = ""
        LoadCur()
        TxtcurName.Focus()
        TxtStatus.Text = "Status: Success..."
        Timer1.Enabled = True
    End Sub

    Private Sub CreateStockCategories_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtCurCode.Focus()
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

    Private Sub CreateNewCurrency_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadCur()
    End Sub
End Class
