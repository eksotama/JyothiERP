Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class QueryForm

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "suresh123456" Then
            TxtSqlQuery.Visible = True
            Button2.Visible = True
            Button5.Visible = True
            Button4.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Do you want to execute ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            If CheckBox1.Checked = True Then
                If TextBox3.Text.Length = 0 Then
                    MsgBox("Filed is missing ...")
                    Exit Sub
                End If
                MsgBox(SQLGetStringFieldValue(TxtSqlQuery.Text, TextBox3.Text))
            ElseIf CheckBox2.Checked = True Then
                Dim TempBS As New BindingSource
                txtlist.DataSource = Nothing
                With Me.txtlist
                    TempBS.DataSource = SQLLoadGridData(TxtSqlQuery.Text)
                    .AutoGenerateColumns = True
                    .DataSource = TempBS
                End With
            Else

                ExecuteSQLQuery(TxtSqlQuery.Text)
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox3.Visible = True

        Else
            TextBox3.Visible = False
        End If
    End Sub





    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtExportPath.Text = FolderBrowserDialog1.SelectedPath

        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If TxtCmpNames.Text.Length = 0 Then
            MsgBox("Please select the company name...")
            TxtCmpNames.Focus()
            Exit Sub
        End If
        TxtSoftwareSQLDatabaseName = MainForm.GetCompanyDatabaseName(TxtCmpNames.Text)
        If TxtSoftwareSQLDatabaseName.Length = 0 Then
            MsgBox("Invalid Company Name .....", MsgBoxStyle.Information)
            Exit Sub
        End If
        If TxtExportPath.Text.Contains(TxtSoftwareSQLDatabaseName) = False Then
            If MsgBox("The selected Export data files are not for selected company, Do you want to Continue ?.... ", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ConnectionStrinG = ConnectionStringFromFile & " Initial Catalog=" & TxtSoftwareSQLDatabaseName & ";"

        If IO.Directory.Exists(TxtExportPath.Text) = True Then
            If MsgBox("Do you want to Restore Database from Export Data Files ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim TBLSTR As String = "SELECT * FROM INFORMATION_SCHEMA.tables"
                Dim cnn As SqlConnection
                cnn = New SqlConnection(ConnectionStrinG)
                cnn.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(TBLSTR, cnn)
                Dim ds As New DataSet()
                MainForm.Cursor = Cursors.WaitCursor
                da.Fill(ds)
                ' Application.DoEvents()
               

                For Each row As DataRow In ds.Tables(0).Rows

                    Try
                        Dim ids As New DataSet

                        Dim dscmd As New SqlDataAdapter("select * from " & row.Item("TABLE_NAME"), cnn)
                        dscmd.Fill(ids, row.Item("TABLE_NAME"))
                        Dim cb As SqlCommandBuilder = New SqlCommandBuilder(dscmd)
                        ids.ReadXml(TxtExportPath.Text & "\" & row.Item("TABLE_NAME") & ".xml")
                        ExecuteSQLQuery("TRUNCATE  TABLE " & row.Item("TABLE_NAME"))
                        dscmd.Update(ids, row.Item("TABLE_NAME"))

                        ids.Dispose()
                    Catch ex As Exception

                    End Try

                Next row

                MainForm.Cursor = Cursors.Default


                Exit Sub
                MainForm.Cursor = Cursors.Default

                MsgBox("Success...")

            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim sqlstr As String = ""
        sqlstr = " with stockdbfetc as ( select *, row_number() over (partition by stockcode,stocksize order by stockcode,stocksize) as rownumber from stockdbf  ) delete from stockdbfetc where rownumber>1  "
        ExecuteSQLQuery(sqlstr)
       

        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim rowcount As Integer = 0
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from stockdbf"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader

            While Sreader.Read()
                ExecuteSQLQuery("UPDATE STOCKINVOICEROWITEMS SET BARCODE=N'" & Sreader("CUSTBARCODE").ToString & "' WHERE STOCKCODE=N'" & Sreader("STOCKCODE").ToString & "' AND STOCKSIZE=N'" & Sreader("STOCKSIZE").ToString & "'")

                ExecuteSQLQuery("exec UpdateStockQty N'" & Sreader("location").ToString & "',N'" & Sreader("stockcode").ToString & "',N'" & Sreader("stocksize").ToString & "',N'" & Sreader("batchno").ToString & "'")
                ExecuteSQLQuery("EXEC proInventoryCosting N'" & Sreader("location").ToString & "',N'" & Sreader("stockcode").ToString & "',N'" & Sreader("stocksize").ToString & "'," & UpdateQuantityForNon_StockAlso)
                ExecuteSQLQuery("exec UpdateBatchStockQty N'" & Sreader("location").ToString & "',N'" & Sreader("stockcode").ToString & "',N'" & Sreader("stocksize").ToString & "',N'" & Sreader("batchno").ToString & "'")
                rowcount = rowcount + 1
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try

        MsgBox("Total records " & rowcount.ToString)
    End Sub
End Class
