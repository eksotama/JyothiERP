Imports System.Windows.Forms

Public Class createnewserialnumbers
    Dim isAlterMode As Boolean = False
    Dim AlterSerialNo As String = ""
    Dim OpenStockCode As String = ""
    Dim OpenStockSize As String = ""

    Dim OpenedStatus As Integer = 0
    Sub New(Optional ByVal stockcode As String = "", Optional ByVal stocksize As String = "", Optional ByVal SerialNo As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If stockcode.Length > 0 Then
            isAlterMode = True

            OpenStockCode = stockcode
            OpenStockSize = stocksize
            AlterSerialNo = SerialNo

        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub OpenData()
        Dim SqlConn As New SqlClient.SqlConnection

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select * from serialnumbermaster  where stockcode=N'" & OpenStockCode & "' and stocksize=N'" & OpenStockSize & "' and SERIALNUMBER=N'" & AlterSerialNo & "'"
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                TxtStockCode.Text = OpenStockCode
                TxtStockSize.Text = OpenStockSize
                TxtSerialNo.Text = AlterSerialNo
                TxtDesc.Text = Sreader("NOTE1").ToString
                TxtNote.Text = Sreader("NOTE2").ToString
                OpenedStatus = Sreader("STATUS")
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
        If SQLIsFieldExists("SELECT STOCKCODE FROM stockserialnos where stockcode=N'" & OpenStockCode & "' and stocksize=N'" & OpenStockSize & "' and SERIALNUMBER=N'" & AlterSerialNo & "'") = True Then
            TxtStockCode.Enabled = False
            TxtStockSize.Enabled = False
        Else
            TxtStockCode.Enabled = True
            TxtStockSize.Enabled = True
        End If
    End Sub
    Sub loaddefs()
        TxtSerialNo.Text = ""
        TxtSuffix.Text = ""
        TxtPrefix.Text = ""
        TxtStartFrom.Text = "0"
        TxtEndWith.Text = "0"
        TxtDesc.Text = ""
        TxtNote.Text = ""
        LoadDataIntoComboBoxByBinding("select distinct stockcode from  Stockdbf where allowserialnumbers='True' ", TxtStockCode, "stockcode")
    End Sub


    Private Sub IsAutoRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsAutoRange.CheckedChanged
        If IsAutoRange.Checked = True Then
            Panel3.Visible = True
            TxtSerialNo.Enabled = False
        Else
            Panel3.Visible = False
            TxtSerialNo.Enabled = True
        End If
    End Sub

    Private Sub TxtStockCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStockCode.SelectedIndexChanged
        LoadDataIntoComboBox("select distinct stocksize from  Stockdbf where stockcode=N'" & TxtStockCode.Text & "'", TxtStockSize, "stocksize")
    End Sub

    Private Sub createnewserialnumbers_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtStockCode.Focus()
    End Sub

    Private Sub createnewserialnumbers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddefs()
        If isAlterMode = True Then
            IsAutoRange.Checked = False
            IsAutoRange.Enabled = False
            OpenData()
        Else
            IsAutoRange.Enabled = True
        End If

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtStockCode.Text.Length = 0 Then
            MsgBox("Please select the Stock Code ...        ", MsgBoxStyle.Information)
            TxtStockCode.Focus()
            Exit Sub
        End If
        If SQLIsFieldExists("select stockcode from stockdbf where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "'") = False Then
            MsgBox("The Please select the stock size....   ", MsgBoxStyle.Information)
            TxtStockSize.Focus()
            Exit Sub
        End If
        If IsAutoRange.Checked = False Then
            If TxtSerialNo.Text.Length = 0 Then
                MsgBox("Please Enter the Serial Number             ", MsgBoxStyle.Information)
                TxtSerialNo.Focus()
                Exit Sub
            End If
        Else
            If CDbl(TxtStartFrom.Text) = 0 Then
                MsgBox("Please enter the Start from Number..... ", MsgBoxStyle.Information)
                TxtStartFrom.Focus()
                Exit Sub
            End If
            If CDbl(TxtEndWith.Text) = 0 Then
                MsgBox("Please enter the End with Number..... ", MsgBoxStyle.Information)
                TxtEndWith.Focus()
                Exit Sub
            End If
        End If

        If isAlterMode = True Then
            If UCase(TxtStockCode.Text) <> UCase(OpenStockCode) Or UCase(TxtStockSize.Text) <> UCase(OpenStockSize) Or UCase(TxtSerialNo.Text) <> UCase(AlterSerialNo) Then
                If SQLIsFieldExists("select stockcode from serialnumbermaster where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and SERIALNUMBER=N'" & TxtSerialNo.Text & "'") = True Then
                    MsgBox("The enered Serial Number is already exists...", MsgBoxStyle.Information)
                    TxtSerialNo.Focus()
                    Exit Sub
                End If
            End If
            If TxtSerialNo.Text.Length > 30 Then
                MsgBox("The serial number length is too long, Please reduce the length below 30 letters", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("Do you want to Alter ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim Sqlstr As String = ""
                OpenedStatus = 0
                Sqlstr = " UPDATE [serialnumbermaster]    SET [STOCKCODE] = @STOCKCODE,[STOCKSIZE] = @STOCKSIZE,[SERIALNUMBER] = @SERIALNUMBER,[Note1] = @Note1,[Note2] = @Note2,[Status] = @Status  where stockcode=N'" & OpenStockCode & "' and stocksize=N'" & OpenStockSize & "' and SERIALNUMBER=N'" & AlterSerialNo & "'"

                SaveSerialsNumbers(Sqlstr)


            End If
            Me.Close()
        Else
            If IsAutoRange.Checked = False Then
                If SQLIsFieldExists("select stockcode from serialnumbermaster where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and SERIALNUMBER=N'" & TxtSerialNo.Text & "'") = True Then
                    MsgBox("The enered Serial Number is already exists...", MsgBoxStyle.Information)
                    TxtSerialNo.Focus()
                    Exit Sub
                End If
                If TxtSerialNo.Text.Length > 30 Then
                    MsgBox("The serial number length is too long, Please reduce the length below 30 letters", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If MsgBox("Do you want to create ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim Sqlstr As String = ""
                    OpenedStatus = 0
                    Sqlstr = " INSERT INTO [serialnumbermaster] ([STOCKCODE],[STOCKSIZE],[SERIALNUMBER],[Note1],[Note2],[Status])  " _
                        & " VALUES  (@STOCKCODE,@STOCKSIZE,@SERIALNUMBER,@Note1,@Note2,@Status) "
                    SaveSerialsNumbers(Sqlstr)
                End If
                loaddefs()
            Else
                If MsgBox("Do you want to create ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim Startfrom As Long = 0
                Dim Endfrom As Long = 0
                Startfrom = CLng(TxtStartFrom.Text)
                Endfrom = CLng(TxtEndWith.Text)
                'inter change if the values not correct
                If Startfrom > Endfrom Then
                    Startfrom = Startfrom + Endfrom
                    Endfrom = Startfrom - Endfrom
                    Startfrom = Startfrom - Endfrom
                End If
                TxtSerialNo.Text = TxtPrefix.Text & "20000" & TxtSuffix.Text
                If TxtSerialNo.Text.Length > 30 Then
                    MsgBox("The serial number length is too long, Please reduce the length below 30 letters", MsgBoxStyle.Information)
                    Exit Sub
                End If
                For i As Long = Startfrom To Endfrom
                    TxtSerialNo.Text = TxtPrefix.Text & i.ToString & TxtSuffix.Text
                    If SQLIsFieldExists("select stockcode from serialnumbermaster where stockcode=N'" & TxtStockCode.Text & "' and stocksize=N'" & TxtStockSize.Text & "' and SERIALNUMBER=N'" & TxtSerialNo.Text & "'") = False Then
                        Dim Sqlstr As String = ""
                        OpenedStatus = 0
                        Sqlstr = " INSERT INTO [serialnumbermaster] ([STOCKCODE],[STOCKSIZE],[SERIALNUMBER],[Note1],[Note2],[Status])  " _
                            & " VALUES  (@STOCKCODE,@STOCKSIZE,@SERIALNUMBER,@Note1,@Note2,@Status) "
                        SaveSerialsNumbers(Sqlstr)
                    End If
                Next
                loaddefs()
            End If

        End If
    End Sub

    Sub SaveSerialsNumbers(ByVal sqlstr As String)

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("STOCKCODE", TxtStockCode.Text)
            .AddWithValue("STOCKSIZE", TxtStockSize.Text)
            .AddWithValue("SERIALNUMBER", TxtSerialNo.Text)
            .AddWithValue("Note1", TxtDesc.Text)
            .AddWithValue("Note2", TxtNote.Text)
            .AddWithValue("Status", OpenedStatus)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
