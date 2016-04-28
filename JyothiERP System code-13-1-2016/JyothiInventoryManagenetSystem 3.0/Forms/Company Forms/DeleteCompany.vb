Imports System.Windows.Forms

Public Class DeleteCompany


    Private Sub DeleteCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '        DataGridView1 = CompaniesDatabaseLists
        'DBNAME cmpname
        clist.Rows.Clear()
        For i As Integer = 0 To MainForm.CompaniesDatabaseLists.Rows.Count - 1
            If UCase(MainForm.CompaniesDatabaseLists.Item("dbname", i).Value) <> UCase(TxtSoftwareSQLDatabaseName) Then
                Dim rno As Integer = 0
                rno = clist.Rows.Add
                clist.Item("tcmpname", rno).Value = MainForm.CompaniesDatabaseLists.Item("cmpname", i).Value
                clist.Item("tdbname", rno).Value = MainForm.CompaniesDatabaseLists.Item("dbname", i).Value

            End If
        Next

    End Sub

    
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If clist.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to Delete the Selected Company ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + vbDefaultButton2) = MsgBoxResult.Yes Then
                If MsgBox("Warning: All transaction and master will be deleted along with Company, Do you want to Delete ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + vbDefaultButton2) = MsgBoxResult.Yes Then
                    Try


                        ExecuteSQLQuery("USE " & clist.Item("tdbname", clist.CurrentRow.Index).Value)
                        ExecuteSQLQuery("alter database [" & clist.Item("tdbname", clist.CurrentRow.Index).Value & "] set single_user with rollback immediate")


                        Dim SqlConn As New SqlClient.SqlConnection
                        Dim Sqlcmmd As New SqlClient.SqlCommand
                        Dim err As Boolean = False
                        Try
                            SqlConn.ConnectionString = ConnectionStrinG
                            SqlConn.Open()
                            Sqlcmmd.Connection = SqlConn
                            Sqlcmmd.CommandText = "DROP DATABASE " & clist.Item("tdbname", clist.CurrentRow.Index).Value
                            Sqlcmmd.CommandType = CommandType.Text
                            Sqlcmmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            err = True
                        Finally
                            SqlConn.Close()
                            SqlConn.Dispose()
                            Sqlcmmd.Connection = Nothing
                        End Try

                        If err = False Then
                            MsgBox("The Database " & clist.Item("tdbname", clist.CurrentRow.Index).Value & " is Permanently Deleted Successfully ")
                            clist.Rows.RemoveAt(clist.CurrentRow.Index)
                        End If


                    Catch ex As Exception
                        MsgBox("Error: Unable to delete the database ")
                    End Try

                End If
            End If
        End If
    End Sub
End Class
