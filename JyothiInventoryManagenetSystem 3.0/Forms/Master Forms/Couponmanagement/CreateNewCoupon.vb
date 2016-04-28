Imports System.Windows.Forms

Public Class CreateNewCoupon

    Dim AlterCouponName As String = ""
    Dim UsedValue As Double = 0
    Dim MaxUses As Double = 0
    Dim status As Boolean = True
    Dim IsAlterMode As Boolean = False

    Sub New(Optional ByVal V_AlterCouponName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If V_AlterCouponName.Length > 0 Then
            AlterCouponName = V_AlterCouponName
            IsAlterMode = True
            BtnCreate.Text = "&Alter"
            TxtIsMultiCoupon.Visible = False
        Else
            TxtIsMultiCoupon.Visible = True
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
   

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtIsMultiCoupon.Checked = True Then
            If TxtPrefix.Text.Length = 0 Then
                MsgBox("Please Enter the Prefix of Coupon Name ....        ")
                TxtPrefix.Focus()
                Exit Sub
            End If
        Else
            If txtCouponName.Text.Length < 2 Then
                MsgBox("Please enter the Coupon Name ....", MsgBoxStyle.Information)
                txtCouponName.Focus()
                Exit Sub
            End If
        End If
        
        If TxtDateFrom.Value > TxtDateTo.Value Then
            Dim td As New DateTimePicker
            td.Value = TxtDateFrom.Value
            TxtDateFrom.Value = TxtDateTo.Value
            TxtDateTo.Value = td.Value
        End If

        If IsAlterMode = True Then
            If UCase(txtCouponName.Text) <> UCase(AlterCouponName) Then
                If SQLIsFieldExists("select cname from couponmaster where cname=N'" & txtCouponName.Text & "'") = True Then
                    MsgBox("The Entered Coupon Name is already Exists... ", MsgBoxStyle.Information)
                    txtCouponName.Focus()
                    Exit Sub
                End If

            End If

            If MsgBox("Do you want to Save Changes ?               ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim SqlStr As String = ""
                SqlStr = "UPDATE [couponmaster]    SET [Cname] = @Cname,[cper] = @cper,[datefrom] = @datefrom,[dateto] = @dateto,[MaxValues] = @MaxValues,[UsedValue] = @UsedValue,[MaxNoofUses] = @MaxNoofUses,[isActive] = @isActive,[Datefromvalue] = @Datefromvalue,[DatetoValue] = @DatetoValue  where cname=N'" & AlterCouponName & "'"
                SaveChanges(SqlStr)
            End If
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET CouponName=N'" & txtCouponName.Text & "' WHERE CouponName=N'" & AlterCouponName & "'")
        Else
            If TxtIsMultiCoupon.Checked = True Then
                If MsgBox("Do you want to Create ?               ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim Nofrom As Long = 0
                    Dim NoTo As Long = 0
                    Dim t As Long = 0
                    Nofrom = CLng(TxtStartNo.Text)
                    NoTo = CLng(TxtEndNo.Text)
                    If Nofrom > NoTo Then
                        t = NoTo
                        NoTo = Nofrom
                        Nofrom = t
                    End If

                    For i As Long = Nofrom To NoTo
                        txtCouponName.Text = TxtPrefix.Text & i.ToString
                        If SQLIsFieldExists("select cname from couponmaster where cname=N'" & txtCouponName.Text & "'") = False Then
                            Dim SqlStr As String = ""
                            SqlStr = "INSERT INTO [couponmaster] ([Cname],[cper],[datefrom],[dateto],[MaxValues],[UsedValue],[MaxNoofUses],[isActive],[Datefromvalue],[DatetoValue])     VALUES " _
                                & " (@Cname,@cper,@datefrom,@dateto,@MaxValues,@UsedValue,@MaxNoofUses,@isActive,@Datefromvalue,@DatetoValue)    "
                            SaveChanges(SqlStr)
                        End If
                        Me.Close()
                    Next
                End If

            Else
                If SQLIsFieldExists("select cname from couponmaster where cname=N'" & txtCouponName.Text & "'") = True Then
                    MsgBox("The Entered Coupon Name is already Exists... ", MsgBoxStyle.Information)
                    txtCouponName.Focus()
                    Exit Sub
                End If
                If MsgBox("Do you want to Create ?               ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [couponmaster] ([Cname],[cper],[datefrom],[dateto],[MaxValues],[UsedValue],[MaxNoofUses],[isActive],[Datefromvalue],[DatetoValue])     VALUES " _
                        & " (@Cname,@cper,@datefrom,@dateto,@MaxValues,@UsedValue,@MaxNoofUses,@isActive,@Datefromvalue,@DatetoValue)    "
                    SaveChanges(SqlStr)
                    Me.Close()
                End If
            End If

        End If
    End Sub
    Sub SaveChanges(ByVal sqlstring As String)
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(sqlstring, MAINCON)
        With DBF.Parameters
            .AddWithValue("Cname", txtCouponName.Text)
            .AddWithValue("cper", CDbl(TxtPer.Text))
            .AddWithValue("datefrom", TxtDateFrom.Value)
            .AddWithValue("dateto", TxtDateTo.Value)
            .AddWithValue("MaxValues", CDbl(TxtMaxValue.Text))
            .AddWithValue("UsedValue", UsedValue)
            .AddWithValue("MaxNoofUses", MaxUses)
            .AddWithValue("isActive", status)
            .AddWithValue("Datefromvalue", TxtDateFrom.Value.Date.ToOADate)
            .AddWithValue("DatetoValue", TxtDateTo.Value.Date.ToOADate)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()
    End Sub
    Sub LoadData()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from couponmaster where cname=N'" & AlterCouponName & "'"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                txtCouponName.Text = Sreader("Cname")
                TxtPer.Text = Sreader("cper")
                TxtDateFrom.Value = Sreader("datefrom")
                TxtDateTo.Value = Sreader("dateto")
                TxtMaxValue.Text = Sreader("MaxValues")
                UsedValue = Sreader("UsedValue")
                MaxUses = Sreader("MaxNoofUses")
                status = Sreader("isActive")
              
            End While

            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing

        End Try
    End Sub

    Private Sub CreateNewCoupon_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CreateNewCoupon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loaddefs()
        If IsAlterMode = True Then
            LoadData()
        End If
    End Sub
    Sub loaddefs()
        UsedValue = "0"
        TxtMaxValue.Text = "0"
        TxtPer.Text = "1"
        TxtDateFrom.Value = Today
        TxtDateTo.Value = Today
        txtCouponName.Text = ""
        MaxUses = 0
        status = True
    End Sub

    Private Sub TxtIsMultiCoupon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIsMultiCoupon.CheckedChanged
        If TxtIsMultiCoupon.Checked = True Then
            GroupBox1.Visible = True
            TxtPrefix.Focus()
        Else
            GroupBox1.Visible = False
            txtCouponName.Focus()
        End If
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click, Label11.Click, Label10.Click

    End Sub
End Class
