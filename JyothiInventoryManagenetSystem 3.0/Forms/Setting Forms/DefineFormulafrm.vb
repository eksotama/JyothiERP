Imports System.Windows.Forms

Public Class DefineFormulafrm
    Public FORMULANAME As String = ""
    Public DbName As String = ""
    Public SchemeName As String = ""

    Dim ttype As Integer = 0
    Sub New(ftype As Integer, schname As String, Optional dbfiledname As String = "", Optional formalname As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        ttype = ftype
        SchemeName = schname
        DbName = dbfiledname
        FORMULANAME = formalname
        If ftype = 0 Then

            LoadDataIntoComboBox("select distinct DBfield from PrintFieldLabels where schemename=N'" & schname & "' and DBType<>3", TxtFieldNames, "DBfield")

        Else

            LoadDataIntoComboBox("select distinct DBfield from PrintRecords where schemename=N'" & schname & "' and DBType<>3", TxtFieldNames, "DBfield")
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DefineFormulafrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        TxtName.Focus()
    End Sub


    Private Sub DefineFormulafrm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtName.Text = DbName
        txtFormulaName.Text = FORMULANAME

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click

        Me.Close()
    End Sub

    Private Sub TxtFieldNames_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TxtFieldNames.SelectedIndexChanged
        txtFormulaName.SelectedText = TxtFieldNames.Text
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If TxtName.Text.Length < 2 Then
            MsgBox("Please Enter the Formula Name ( min 2 letters) ...", MsgBoxStyle.Information)
            TxtName.Focus()
            Exit Sub
        End If
        If txtFormulaName.Text.Length = 0 Then
            MsgBox("Please enter the formula using sql formulas and functions ...", MsgBoxStyle.Information)
            txtFormulaName.Focus()
            Exit Sub
        End If
        If DbName.Length > 0 Then
            If TxtName.Text.ToUpper <> DbName.ToUpper Then
                If ttype = 0 Then
                    If SQLIsFieldExists("select DBfield from PrintFieldLabels where DBfield=N'" & TxtName.Text & "' AND SchemeName=N'" & SchemeName & "'") = True Then
                        MsgBox("The Forumal Name  is already exists, Please try with another name.....", MsgBoxStyle.Information)
                        TxtName.Focus()
                        Exit Sub
                    End If
                Else
                    If SQLIsFieldExists("select DBfield from PrintRecords where DBfield=N'" & TxtName.Text & "'  AND SchemeName=N'" & SchemeName & "'") = True Then
                        MsgBox("The Forumal Name  is already exists, Please try with another name.....", MsgBoxStyle.Information)
                        TxtName.Focus()
                        Exit Sub
                    End If
                End If
            End If
        Else
            If ttype = 0 Then
                If SQLIsFieldExists("select DBfield from PrintFieldLabels where DBfield=N'" & TxtName.Text & "'  AND SchemeName=N'" & SchemeName & "'") = True Then
                    MsgBox("The Forumal Name  is already exists, Please try with another name.....", MsgBoxStyle.Information)
                    TxtName.Focus()
                    Exit Sub
                End If
            Else
                If SQLIsFieldExists("select DBfield from PrintRecords where DBfield=N'" & TxtName.Text & "'  AND SchemeName=N'" & SchemeName & "'") = True Then
                    MsgBox("The Forumal Name  is already exists, Please try with another name.....", MsgBoxStyle.Information)
                    TxtName.Focus()
                    Exit Sub
                End If
            End If
        End If
        Dim Err As Boolean = False
        If ttype = 0 Then
            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "select top 1 " & txtFormulaName.Text & " from StockInvoiceDetails "
                Sqlcmmd.CommandType = CommandType.Text
                Sqlcmmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim SqlConn2 As New SqlClient.SqlConnection
                Dim Sqlcmmd2 As New SqlClient.SqlCommand
                Try
                    SqlConn2.ConnectionString = ConnectionStrinG
                    SqlConn2.Open()
                    Sqlcmmd2.Connection = SqlConn2
                    Sqlcmmd2.CommandText = txtFormulaName.Text
                    Sqlcmmd2.CommandType = CommandType.Text
                    Sqlcmmd2.ExecuteNonQuery()
                Catch ex2 As Exception
                    MsgBox(ex.Message)
                    MsgBox(ex2.Message)
                    Err = True
                Finally
                    SqlConn2.Close()
                    SqlConn2.Dispose()
                    Sqlcmmd2.Connection = Nothing
                End Try


            Finally
                SqlConn.Close()
                SqlConn.Dispose()
                Sqlcmmd.Connection = Nothing
            End Try
        Else
            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "select top 1 " & txtFormulaName.Text & " from StockInvoiceRowItems "
                Sqlcmmd.CommandType = CommandType.Text
                Sqlcmmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim SqlConn2 As New SqlClient.SqlConnection
                Dim Sqlcmmd2 As New SqlClient.SqlCommand
                Try
                    SqlConn2.ConnectionString = ConnectionStrinG
                    SqlConn2.Open()
                    Sqlcmmd2.Connection = SqlConn2
                    Sqlcmmd2.CommandText = txtFormulaName.Text
                    Sqlcmmd2.CommandType = CommandType.Text
                    Sqlcmmd2.ExecuteNonQuery()
                Catch ex2 As Exception
                    MsgBox(ex.Message)
                    MsgBox(ex2.Message)
                    Err = True
                Finally
                    SqlConn2.Close()
                    SqlConn2.Dispose()
                    Sqlcmmd2.Connection = Nothing
                End Try


            Finally
                SqlConn.Close()
                SqlConn.Dispose()
                Sqlcmmd.Connection = Nothing
            End Try
        End If
        If Err = False Then
            If MsgBox("Do you want to Save ?              ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If DbName.Length = 0 Then
                    If ttype = 0 Then
                        Dim insertStr As String = ""

                        InsertStr = " INSERT INTO [PrintFieldLabels]([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue],[decimals] ,[supress],[Formulastr])     VALUES " _
                       & "(@SchemeName,@Fieldname,@labletext,@DBField,@IsVisible,@ftop,@fleft,@width,@height,@Fontname,@fontsize,@fontstyle,@fontcolor,@Align,@lTop,@lleft, " _
                       & " @lwidth,@lheight,@lFontname,@lfontsize,@lfontstyle,@lfontcolor,@lalign,@sample,@DBType,@FieldType,@PrintText,@FormatType,@DatabaseValue,@IsLedgerValue,@decimals,@supress,@Formulastr)  "
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(InsertStr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("SchemeName", SchemeName)
                            .AddWithValue("Fieldname", TxtName.Text)
                            .AddWithValue("labletext", TxtName.Text)
                            .AddWithValue("DBField", TxtName.Text)
                            .AddWithValue("IsVisible", False)
                            .AddWithValue("ftop", 10)
                            .AddWithValue("fleft", 10)
                            .AddWithValue("width", 20)
                            .AddWithValue("height", 20)
                            .AddWithValue("Fontname", "Arial")
                            .AddWithValue("fontsize", 12)
                            .AddWithValue("fontstyle", 1)
                            .AddWithValue("fontcolor", "Black")
                            .AddWithValue("Align", "Left")
                            .AddWithValue("lTop", 120)
                            .AddWithValue("lleft", 120)
                            .AddWithValue("lwidth", 120)
                            .AddWithValue("lheight", 120)
                            .AddWithValue("lFontname", "Arial")
                            .AddWithValue("lfontsize", 12)
                            .AddWithValue("lfontstyle", 1)
                            .AddWithValue("lfontcolor", "Black")
                            .AddWithValue("lalign", "Left")
                            .AddWithValue("sample", "")
                            .AddWithValue("DBType", 3)
                            .AddWithValue("FieldType", 1)
                            .AddWithValue("FormatType", 2)
                            .AddWithValue("PrintText", "")
                            .AddWithValue("DatabaseValue", 0)
                            .AddWithValue("IsLedgerValue", 0)
                            .AddWithValue("decimals", 2)
                            .AddWithValue("supress", 0)
                            .AddWithValue("Formulastr", txtFormulaName.Text)

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    Else
                        Dim insertStr As String = ""
                        insertStr = " INSERT INTO [PrintRecords]([SchemeName],[Fieldname],[labletext],[ObjectType],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[Lcase],[Rcase],[lalign],[space],[DBType],[DBField],[FormatType],[decimals],[supress],[Formulastr])     VALUES " _
                 & " (@SchemeName,@Fieldname,@labletext,@ObjectType,@IsVisible,@ftop,@fleft,@width,@height,@Fontname,@fontsize,@fontstyle,@fontcolor,@Align," _
                 & " @lTop,@lleft,@lwidth,@lheight,@lFontname,@lfontsize,@lfontstyle,@lfontcolor, " _
                 & " @Lcase,@Rcase,@lalign,@space,@DBType,@DBField,@FormatType,@decimals,@supress,@Formulastr)     "

                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand(InsertStr, MAINCON)
                        With DBF.Parameters
                            .AddWithValue("SchemeName", SchemeName)
                            .AddWithValue("Fieldname", TxtName.Text)
                            .AddWithValue("labletext", TxtName.Text)
                            .AddWithValue("ObjectType", TxtName.Text)
                            .AddWithValue("IsVisible", False)
                            .AddWithValue("ftop", 10)
                            .AddWithValue("fleft", 10)
                            .AddWithValue("width", 20)
                            .AddWithValue("height", 20)
                            .AddWithValue("Fontname", "Arial")
                            .AddWithValue("fontsize", 12)
                            .AddWithValue("fontstyle", 1)
                            .AddWithValue("fontcolor", "Black")
                            .AddWithValue("Align", "Left")
                            .AddWithValue("lTop", 120)
                            .AddWithValue("lleft", 120)
                            .AddWithValue("lwidth", 120)
                            .AddWithValue("lheight", 120)
                            .AddWithValue("lFontname", "Arial")
                            .AddWithValue("lfontsize", 12)
                            .AddWithValue("lfontstyle", 1)
                            .AddWithValue("lfontcolor", "Black")
                            .AddWithValue("Lcase", "lower case")
                            .AddWithValue("Rcase", "lower case")
                            .AddWithValue("lalign", "left")
                            .AddWithValue("space", 5)
                            .AddWithValue("DBField", TxtName.Text)
                            .AddWithValue("DBType", 3)
                            .AddWithValue("FieldType", 1)
                            .AddWithValue("FormatType", 2)
                            .AddWithValue("decimals", 2)
                            .AddWithValue("supress", 0)
                            .AddWithValue("Formulastr", txtFormulaName.Text)

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    End If
                Else
                    If ttype = 0 Then
                        Dim insertStr As String = ""
                        insertStr = "UPDATE PrintFieldLabels SET Fieldname=N'" & TxtName.Text & "', DBField=N'" & TxtName.Text & "', Formulastr=N'" & txtFormulaName.Text & "' WHERE SchemeName=N'" & SchemeName & "' and DBfield=N'" & DbName & "'"
                        ExecuteSQLQuery(insertStr)
                    Else
                        Dim insertStr As String = ""
                        insertStr = "UPDATE PrintRecords SET Fieldname=N'" & TxtName.Text & "', DBField=N'" & TxtName.Text & "', Formulastr=N'" & txtFormulaName.Text & "' WHERE SchemeName=N'" & SchemeName & "'  and DBfield=N'" & DbName & "'"
                        ExecuteSQLQuery(insertStr)
                    End If
                End If
                FORMULANAME = txtFormulaName.Text
                Me.Close()
            End If

        End If
    End Sub
End Class
