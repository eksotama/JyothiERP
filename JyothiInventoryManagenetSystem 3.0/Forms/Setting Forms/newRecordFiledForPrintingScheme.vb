Imports System.Windows.Forms

Public Class newRecordFiledForPrintingScheme

    

    Private Sub Cancel_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub newRecordFiledForPrintingScheme_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub newRecordFiledForPrintingScheme_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'select Column_name from Information_schema.columns where Table_name ='StockInvoiceRowItems'
        LoadFileds()
    End Sub
    Sub LoadFileds()
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SQLFcmd2 As New SqlClient.SqlCommand
            SQLFcmd2.Connection = SqlConn1
            SQLFcmd2.CommandText = "select Column_name,data_type from Information_schema.columns where Table_name ='StockInvoiceRowItems'"
            SQLFcmd2.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd2.ExecuteReader
            TxtRecFiledNames.Items.Clear()
            txtdatatype.Items.Clear()
            While Sreader.Read()
                If SQLIsFieldExists("SELECT TOP 1 1 from   PrintFieldLabels where dbfield=N'" & Sreader("Column_name").ToString & "'") = False Then
                    TxtRecFiledNames.Items.Add(Sreader("Column_name").ToString)
                    txtdatatype.Items.Add(Sreader("data_type").ToString)
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
            SQLFcmd2.Connection = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1.Dispose()
        End Try
    End Sub

    Private Sub TxtRecFiledNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRecFiledNames.SelectedIndexChanged, txtdatatype.SelectedIndexChanged
        TxtFieldName.Text = TxtRecFiledNames.Text
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TxtRecFiledNames.Text.Length = 0 Then Exit Sub
        If TxtFieldName.Text.Length = 0 Then
            MsgBox("Please enter the filed name ... ")
            Exit Sub
        End If
        If MsgBox("Do you want to Add this filed name ... ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqlstr As String = ""


            Dim SqlConn1 As New SqlClient.SqlConnection
            Try
                SqlConn1.ConnectionString = ConnectionStrinG
                SqlConn1.Open()
                Dim SQLFcmd2 As New SqlClient.SqlCommand
                SQLFcmd2.Connection = SqlConn1
                SQLFcmd2.CommandText = "select SchemeName from PrintingSettings "
                SQLFcmd2.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd2.ExecuteReader
                Dim dbtype As Integer = 0
                While Sreader.Read()
                    Dim temp As String = txtdatatype.Items(TxtRecFiledNames.SelectedIndex).ToString
                    If temp = "float" Or temp = "int" Or temp = "bigint" Then
                        dbtype = 1
                    End If
                    sqlstr = "INSERT INTO [PrintFieldLabels] ([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height]," _
                        & " [Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle]," _
                        & " [lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue])     VALUES" _
                        & " (N'" & Sreader("SchemeName").ToString & "',N'" & TxtFieldName.Text & "','',N'" & TxtRecFiledNames.Text & "','False',1,1,1,1," _
                        & " 'Arial',9,0,'black','left',1,1,1,1,'Arial',9,0," _
                        & "'black','left','',0,1,''," & dbtype & ",0,0)"
                    ExecuteSQLQuery(sqlstr)

                End While
                Sreader.Close()
                Sreader = Nothing
                SQLFcmd2.Connection = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SqlConn1.Close()
                SqlConn1.Dispose()
            End Try
            LoadFileds()
        End If
    End Sub
End Class
