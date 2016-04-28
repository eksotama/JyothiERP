Imports System.Windows.Forms

Public Class Roundoffsettingsfrm




    Private Sub Cancel_Button_Click_1(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub Roundoffsettings_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'roundingsettings

        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from roundingsettings "
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                inPI.Text = IIf(Sreader("AllowinPurchase") = True, "YES", "NO")
                inPR.Text = IIf(Sreader("AllowinPurchaseRet") = True, "YES", "NO")
                InPG.Text = IIf(Sreader("AllowinGnote") = True, "YES", "NO")

                inPOS.Text = IIf(Sreader("AllowinPOS") = True, "YES", "NO")
                inSI.Text = IIf(Sreader("AllowinSalesInvoice") = True, "YES", "NO")
                inSR.Text = IIf(Sreader("AllowinSalesRet") = True, "YES", "NO")
                inSD.Text = IIf(Sreader("AllowinDNote") = True, "YES", "NO")
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
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If MsgBox("Do you want to save  ?               ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim val As String = ""
            If inPOS.Text = "YES" Then
                val = val + "1"
            Else
                val = val + "0"
            End If
            If inSI.Text = "YES" Then
                val = val + ",1"
            Else
                val = val + ",0"
            End If
            If inPI.Text = "YES" Then
                val = val + ",1"
            Else
                val = val + ",0"
            End If
            If inPR.Text = "YES" Then
                val = val + ",1"
            Else
                val = val + ",0"
            End If
            If inSR.Text = "YES" Then
                val = val + ",1"
            Else
                val = val + ",0"
            End If
            If inSD.Text = "YES" Then
                val = val + ",1"
            Else
                val = val + ",0"
            End If
            If InPG.Text = "YES" Then
                val = val + ",1"
            Else
                val = val + ",0"
            End If

            If SQLIsFieldExists("SELECT TOP 1 1 from   roundingsettings ") = False Then
                ExecuteSQLQuery("INSERT INTO [roundingsettings]([AllowinPOS],[AllowinSalesInvoice],[AllowinPurchase],[AllowinPurchaseRet],[AllowinSalesRet],[AllowinDNote],[AllowinGnote])     VALUES (" & val & ")")
            Else
                ExecuteSQLQuery("UPDATE  roundingsettings SET AllowinPOS=" & IIf(inPOS.Text = "YES", 1, 0) & ",AllowinSalesInvoice=" & IIf(inSI.Text = "YES", 1, 0) & ",AllowinPurchase=" & IIf(inPI.Text = "YES", 1, 0) & ", AllowinPurchaseRet=" & IIf(inPR.Text = "YES", 1, 0) & ", AllowinSalesRet=" & IIf(inSR.Text = "YES", 1, 0) & ", AllowinDNote=" & IIf(inSD.Text = "YES", 1, 0) & ", AllowinGnote=" & IIf(InPG.Text = "YES", 1, 0))
            End If

            LoadRoundoffSettings()
            Me.Close()
        End If

    End Sub
End Class
