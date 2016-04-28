Public Class IMSQTYE
    Dim UnitName As String
    Dim Subunit1 As String
    Dim subunit2 As String
    Dim subunit3 As String
    Dim con1 As Double
    Dim con2 As Double
    Public IscompoundUnit As Boolean = False
    Dim IsvisableLables As Boolean = True
    Public Event ThisLostFocus(ByVal e As Object)


    Public Property VisibleLabels() As Boolean
        Get
            Return IsvisableLables
        End Get
        Set(ByVal value As Boolean)
            IsvisableLables = value
            If IsvisableLables = True Then
                TableLayoutPanel1.RowStyles(0).Height = 37.5
            Else
                TableLayoutPanel1.RowStyles(0).Height = 0
            End If
            '  Me.Validate()

        End Set
    End Property
    Public Function IsSimpleUnit() As Boolean
        If IscompoundUnit = True Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function GetTotalQtyText() As String

        If CDbl(TxtQty2.Text) = 0 Then
            Return TxtQty1.Text & " " & Subunit1
        Else
            Return TxtQty1.Text & " " & Subunit1 & " " & TxtQty2.Text & " " & subunit2
        End If

    End Function

    Public Function GetConverionUnit() As Double
        If con1 <= 1 Then
            Return 1
        Else
            Return con1
        End If

    End Function
    Public Function GetMainUnitName() As String
        Return Subunit1
    End Function
    Public Function GetSubUnitName() As String
        Return subunit2
    End Function
    Public Function GetUnitName() As String
        Return UnitName
    End Function
    Public Function GetUnitQtys(ByVal Colno As Integer) As Double
        If Colno = 0 Then
            Return CDbl(TxtQty1.Text)
        ElseIf Colno = 1 Then
            Return CDbl(TxtQty2.Text)
        Else
            Return (0)
        End If
    End Function
    Public Function GetTotalQty() As Double
        If IscompoundUnit = True Then
            Return CDbl(TxtQty1.Text) * con1 + CDbl(TxtQty2.Text)
        Else
            Return CDbl(TxtQty1.Text)
        End If
    End Function
  
    Public Sub ClearQty()
        TxtQty1.Text = "0"
        TxtQty2.Text = "0"
    End Sub
    Public Sub SetUnitName(ByVal txtunitname As String)
        Dim SqlConn As New SqlClient.SqlConnection

        Try
            SqlConn.ConnectionString = connectionstring
            SqlConn.Open()

            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand("Select * from stockunits where unitname=N'" & txtunitname & "'", SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Subunit1 = TBD.Tables(0).Rows(0).Item("MainUnitName").ToString.Trim
                subunit2 = TBD.Tables(0).Rows(0).Item("SubUnitName").ToString.Trim
                con1 = CDbl(TBD.Tables(0).Rows(0).Item("Unitconversion").ToString.Trim)
                If con1 = 0 Then con1 = 1
                IscompoundUnit = CDbl(TBD.Tables(0).Rows(0).Item("UnitType").ToString.Trim)
            End If
            If IscompoundUnit = True Then
                TxtQty2.Visible = True
                TableLayoutPanel1.ColumnStyles.Item(0).Width = 50
                TableLayoutPanel1.ColumnStyles.Item(1).Width = 50
            Else
                TxtQty2.Visible = False
                TableLayoutPanel1.ColumnStyles.Item(0).Width = 100
                TableLayoutPanel1.ColumnStyles.Item(1).Width = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try
       
        Dim MDecimal As Double
        Dim SDecimal As Double
        If IsSimpleUnit() = True Then
            TxtQty1.AllowDecimal = True
            TxtQty1.DecimalPlaces = SQLGetNumericFieldValue("select decimals from stockunits where unitname=N'" & txtunitname & "'", "decimals")
        Else
            MDecimal = SQLGetNumericFieldValue("select decimals from stockunits where unitname=N'" & Subunit1 & "'", "decimals")
            SDecimal = SQLGetNumericFieldValue("select decimals from stockunits where unitname=N'" & subunit2 & "'", "decimals")

            TxtQty1.AllowDecimal = False
            TxtQty1.DecimalPlaces = 0
            TxtQty2.AllowDecimal = True
            TxtQty2.DecimalPlaces = SDecimal
        End If
        UnitName = txtunitname
    End Sub

    Private Sub IMSQtyBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) And IsExitOnEscKey = True Then
            Me.FindForm.Dispose()
        End If
    End Sub

    Private Sub TxtQty2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQty2.LostFocus
        If IscompoundUnit = True Then
            If CDbl(TxtQty2.Text) >= con1 Then
                TxtQty1.Text = CDbl(TxtQty1.Text) + CDbl(TxtQty2.Text) \ con1
                TxtQty2.Text = CDbl(TxtQty2.Text) Mod con1
            End If
        End If

    End Sub

    Public Sub CalculateQtys()
        If IscompoundUnit = True Then
            If CDbl(TxtQty2.Text) >= con1 Then
                TxtQty1.Text = CDbl(TxtQty1.Text) + CDbl(TxtQty2.Text) \ con1
                TxtQty2.Text = CDbl(TxtQty2.Text) Mod con1
            End If
        End If
    End Sub
    Public Sub ValidateQtys()
        If IscompoundUnit = True Then
            If CDbl(TxtQty2.Text) >= con1 Then
                TxtQty1.Text = CDbl(TxtQty1.Text) + CDbl(TxtQty2.Text) \ con1
                TxtQty2.Text = CDbl(TxtQty2.Text) Mod con1
            End If
        Else
            TxtQty1.Text = TxtQty2.Text
            TxtQty2.Text = "0"
        End If
    End Sub
    Private Sub TxtQty2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty2.TextChanged
        RaiseEvent ThisLostFocus(Me)
    End Sub

    Private Sub TxtQty1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQty1.LostFocus
        RaiseEvent ThisLostFocus(Me)
    End Sub
End Class
