Imports System.Windows.Forms

Public Class InvoiceOptions

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "NO" Or ComboBox1.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowCurrentBalance='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowCurrentBalance='True'")
        End If
        If ComboBox2.Text = "NO" Or ComboBox2.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowNarration='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowNarration='True'")
        End If
        If ComboBox3.Text = "NO" Or ComboBox3.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowRatePer='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowRatePer='True'")
        End If
        If ComboBox4.Text = "NO" Or ComboBox4.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowAccount='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowAccount='True'")
        End If
        If ComboBox5.Text = "NO" Or ComboBox5.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowDiscount='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowDiscount='True'")
        End If
        If ComboBox6.Text = "NO" Or ComboBox6.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowItemMoreInfo='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowItemMoreInfo='True'")
        End If
        If ComboBox7.Text = "NO" Or ComboBox7.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowItemCode='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowItemCode='True'")
        End If
        If ComboBox8.Text = "NO" Or ComboBox8.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowItemName='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowItemName='True'")
        End If
        If ComboBox9.Text = "NO" Or ComboBox9.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowNetRate='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowNetRate='True'")
        End If
        If ComboBox10.Text = "NO" Or ComboBox10.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowTax='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set ShowTax='True'")
        End If
        If ComboBox11.Text = "NO" Or ComboBox11.Text = "" Then
            ExecuteSQLQuery("update InvoiceDisplaySettings set isallowdisc2='False'")
        Else
            ExecuteSQLQuery("update InvoiceDisplaySettings set isallowdisc2='True'")
        End If

        'isallowdisc2
        LoadInoiceDisplaySettings()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub InvoiceOptions_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub AppSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      

        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from InvoiceDisplaySettings"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                ComboBox1.Text = IIf(Sreader("ShowCurrentBalance") = "True", "YES", "NO")
                ComboBox2.Text = IIf(Sreader("ShowNarration") = "True", "YES", "NO")
                ComboBox3.Text = IIf(Sreader("ShowRatePer") = "True", "YES", "NO")
                ComboBox4.Text = IIf(Sreader("ShowAccount") = "True", "YES", "NO")
                ComboBox5.Text = IIf(Sreader("ShowDiscount") = "True", "YES", "NO")
                ComboBox6.Text = IIf(Sreader("ShowItemMoreInfo") = "True", "YES", "NO")
                ComboBox7.Text = IIf(Sreader("ShowItemCode") = "True", "YES", "NO")
                ComboBox8.Text = IIf(Sreader("ShowItemName") = "True", "YES", "NO")
                ComboBox9.Text = IIf(Sreader("ShowNetRate") = "True", "YES", "NO")
                ComboBox10.Text = IIf(Sreader("ShowTax") = "True", "YES", "NO")
                ComboBox11.Text = IIf(Sreader("isallowdisc2") = "True", "YES", "NO")

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing
        End Try

    End Sub

End Class
