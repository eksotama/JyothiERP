Imports System.Windows.Forms

Public Class DiscountInvoiceWise

    Dim DiscountOpenID As Integer = -1
    Dim OpenDisocuntName As String = ""
    Sub New(Optional ID As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()
        DiscountOpenID = ID
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub CreateNewDirectDiscount_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtDateFrom.Value = Today
        TxtDateTo.Value = Today
        If DiscountOpenID > -1 Then
            LoadData()
            Label1.Text = "ALTER DISCOUNT"
        End If
    End Sub
    Sub LoadData()
        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from Discounts where ID=" & DiscountOpenID)
        If dt.Rows.Count > 0 Then
            TxtDisName.Text = dt.Rows(0).Item("DiscountName").ToString
            OpenDisocuntName = TxtDisName.Text
            If dt.Rows(0).Item("IsDiscPer") = True Then
                TxtValueType.Text = "PERCENTAGE"
            Else
                TxtValueType.Text = "VALUE"
            End If

            TxtPer.Text = dt.Rows(0).Item("DiscountPer")
            TxtDateFrom.Value = dt.Rows(0).Item("DateFrom")
            TxtDateTo.Value = dt.Rows(0).Item("dateto")
        End If
        dt.Dispose()

    End Sub
    
   



    

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
      
        If TxtDisName.Text.Length = 0 Then
            MsgBox("Please Enter the Discount Name...", MsgBoxStyle.Information)
            TxtDisName.Focus()
            Exit Sub
        End If
        If TxtPer.Text.Length = 0 Then
            MsgBox("Please Enter the Discount Value...", MsgBoxStyle.Information)
            TxtPer.Focus()
            Exit Sub
        End If
        If CDbl(TxtPer.Text) <= 0 Then
            MsgBox("Please Enter the Discount Value...", MsgBoxStyle.Information)
            TxtPer.Focus()
            Exit Sub
        End If
        If TxtValueType.Text.Length = 0 Then
            MsgBox("Please Select the Discount Type... ", MsgBoxStyle.Information)
            TxtValueType.Focus()
            Exit Sub
        End If
        If DiscountOpenID > -1 Then
            If TxtDisName.Text.ToUpper <> OpenDisocuntName.ToUpper Then
                If SQLIsFieldExists("select DiscountName from Discounts where DiscountName=N'" & TxtDisName.Text & "'") = True Then
                    MsgBox("The Entered Disocunt Name is Already Exists, Please try again....")
                    TxtDisName.Focus()
                    Exit Sub
                End If
            End If
            If MsgBox("Do You want to Save Changes ?                 ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from discountDetails where DiscountID=" & DiscountOpenID)
                SaveChangesData()
                Me.Close()
            End If
        Else
            If SQLIsFieldExists("select DiscountName from Discounts where DiscountName=N'" & TxtDisName.Text & "'") = True Then
                MsgBox("The Entered Disocunt Name is Already Exists, Please try again....")
                TxtDisName.Focus()
                Exit Sub
            End If
            If MsgBox("Do You want to Save ?                 ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveData()
                Me.Close()
            End If
        End If

    End Sub
    Sub SaveChangesData()
        Dim sqlstr As String = ""

        sqlstr = "update [Discounts] set [DiscountName]=@DiscountName,[IsDiscPer]=@IsDiscPer,[DiscountPer]=@DiscountPer,[DateFrom]=@DateFrom,[DateFromValue]=@DateFromValue, " _
             & " [DateTo]=@DateTo,[DateToValue]=@DateToValue,[DiscountType]=@DiscountType where id=" & DiscountOpenID

        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("DiscountName", TxtDisName.Text)
                .AddWithValue("IsDiscPer", IIf(TxtValueType.Text = "PERCENTAGE", 1, 0))
                .AddWithValue("DiscountPer", CDbl(TxtPer.Text))
                .AddWithValue("DateFrom", TxtDateFrom.Value)
                .AddWithValue("DateFromValue", TxtDateFrom.Value.Date.ToOADate)
                .AddWithValue("DateTo", TxtDateTo.Value)
                .AddWithValue("DateToValue", TxtDateTo.Value.Date.ToOADate)
                .AddWithValue("DiscountType", "Invoice")

            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
       

    End Sub
    Sub SaveData()
        Dim sqlstr As String = ""

        sqlstr = "INSERT INTO [Discounts]([DiscountName],[StockGroup],[IsDiscPer],[DiscountPer],[DateFrom],[DateFromValue],[DateTo],[DateToValue],[DiscountType],[isActive])  " _
            & " VALUES (@DiscountName,@StockGroup,@IsDiscPer,@DiscountPer,@DateFrom,@DateFromValue,@DateTo,@DateToValue,@DiscountType,@isActive)  "
        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
            With DBF.Parameters
                .AddWithValue("DiscountName", TxtDisName.Text)
                .AddWithValue("StockGroup", "")
                .AddWithValue("IsDiscPer", IIf(TxtValueType.Text = "PERCENTAGE", 1, 0))
                .AddWithValue("DiscountPer", CDbl(TxtPer.Text))
                .AddWithValue("DateFrom", TxtDateFrom.Value)
                .AddWithValue("DateFromValue", TxtDateFrom.Value.Date.ToOADate)
                .AddWithValue("DateTo", TxtDateTo.Value)
                .AddWithValue("DateToValue", TxtDateTo.Value.Date.ToOADate)
                .AddWithValue("DiscountType", "Invoice")
                .AddWithValue("isActive", 1)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
       

    End Sub

End Class
