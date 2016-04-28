Public Class IMSQtyBox
    Dim UnitName As String
    Dim Subunit1 As String
    Dim subunit2 As String
    Dim subunit3 As String
    Dim NosDecimals As String
    Dim con1 As Double
    Dim con2 As Double
    Dim IscompoundUnit As Boolean = False
    Public Event QtyLostFocus(ByVal e As Object)
    Public Event QtyGotFocus(ByVal e As Object)
    Public Event QtyChanageEvent(ByVal e As Object)

    Public Property LabelColor() As Color
        Get
            Return TxtLbl1.ForeColor
        End Get
        Set(ByVal value As Color)
            TxtLbl1.ForeColor = value
            TxtLbl2.ForeColor = value

        End Set
    End Property

    Public WriteOnly Property AllowNegetiveValues() As Boolean

        Set(ByVal value As Boolean)
            Me.TxtQty1.AllowNegative = value
            Me.TxtQty2.AllowNegative = value

        End Set
    End Property

    Public Function IsSimpleUnit() As Boolean
        If IscompoundUnit = True Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function GetMainUnit() As String
        Return TxtLbl1.Text
    End Function
    Public Function GetSubUnit() As String
        Return TxtLbl2.Text
    End Function
    Public Function GetUnitName() As String
        Return UnitName
    End Function
    Public Sub SetTotalQty(ByVal Val As Double)
        If IscompoundUnit = False Then
            Me.TxtQty1.Text = Val
            Me.TxtQty2.Text = "0"
        Else
            Me.TxtQty1.Text = 0
            Me.TxtQty2.Text = Val
            CalculateValues()
        End If
    End Sub

    Public Function GetUnitConversion() As Double
        If IscompoundUnit = True Then
            Return con1
        Else
            Return 1
        End If
    End Function
    Public Sub AddStockValue(ByVal TotalQty As Double)
        If IsSimpleUnit() = True Then
            Me.TxtQty1.Text = CDbl(Me.TxtQty1.Text) + TotalQty
        Else
            Me.TxtQty2.Text = CDbl(Me.TxtQty2.Text) + TotalQty
        End If
        CalculateValuesWithNumeric()
    End Sub
    Public Function GetUnitQtys(ByVal Colno As Integer) As Double
        If Colno = 0 Then
            Return CDbl(TxtQty1.Text)
        ElseIf Colno = 1 Then
            If IscompoundUnit = True Then
                Return CDbl(TxtQty2.Text)
            Else
                Return (0)

            End If

        Else
            Return (0)
        End If
    End Function
    Public Function GetTotalQty() As Double
        Dim txtq1 As String = ""
        Dim txtq2 As String = ""
        If TxtQty1.Text.Length = 0 Then
            txtq1 = "0"
        Else
            txtq1 = TxtQty1.Text
        End If
        If TxtQty2.Text.Length = 0 Then
            txtq2 = "0"
        Else
            txtq2 = TxtQty2.Text
        End If
        'If TxtQty2.Text.Length = 0 Then
        '    TxtQty2.Text = "0"
        'End If

        If IscompoundUnit = True Then
            Return CDbl(txtq1) * con1 + CDbl(txtq2)
        Else
            Return CDbl(txtq1)
        End If
    End Function
    Public Function GetTotalQtyText() As String
        If IscompoundUnit = True Then
            Return CDbl(TxtQty1.Text).ToString & " " & TxtLbl1.Text & " " & CDbl(TxtQty2.Text).ToString & " " & TxtLbl2.Text
        Else
            Return CDbl(TxtQty1.Text).ToString & " " & TxtLbl1.Text
        End If
    End Function
    Public Sub ClearQty()
        TxtQty1.Text = "0"
        TxtQty2.Text = "0"
    End Sub

    Public Sub SetUnitName(ByVal txtunitname As String)
        Dim SqlConn As New SqlClient.SqlConnection
        UnitName = txtunitname
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
                If con1 = 0 Then
                    con1 = 1
                End If
                IscompoundUnit = CDbl(TBD.Tables(0).Rows(0).Item("UnitType").ToString.Trim)
            End If
            If IscompoundUnit = True Then
                TxtLbl2.Visible = True
                TxtQty2.Visible = True
                TxtLbl1.Visible = True
                TxtQty1.Visible = True
                TableLayoutPanel1.ColumnStyles.Item(0).Width = 50
                TableLayoutPanel1.ColumnStyles.Item(1).Width = 50
                TxtLbl1.Text = Subunit1
                TxtLbl2.Text = subunit2
            Else
                TxtLbl1.Visible = True
                TxtQty1.Visible = True
                TxtLbl2.Visible = False
                TxtQty2.Visible = False
                TxtLbl1.Text = UnitName
                TxtLbl2.Text = ""
                TableLayoutPanel1.ColumnStyles.Item(0).Width = 100
                TableLayoutPanel1.ColumnStyles.Item(1).Width = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()

            SqlFcmd.Connection = Nothing
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

    End Sub

    Private Sub IMSQtyBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Escape) And IsExitOnEscKey = True Then
            Me.FindForm.Dispose()
        End If
    End Sub

    Private Sub TxtQty2_GotFocus(sender As Object, e As System.EventArgs) Handles TxtQty2.GotFocus
        RaiseEvent QtyGotFocus(Me)
    End Sub

    Private Sub TxtQty2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQty2.LostFocus
        If IscompoundUnit = True Then

            If CDbl(TxtQty2.Text) >= con1 Then
                TxtQty1.Text = CDbl(TxtQty1.Text) + CDbl(TxtQty2.Text) \ con1
                TxtQty2.Text = CDbl(TxtQty2.Text) Mod con1
            End If
        End If
        Try
            RaiseEvent QtyLostFocus(Me)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CalculateValues()
        If IscompoundUnit = True Then
            If CDbl(TxtQty2.Text) >= con1 Then
                TxtQty1.Text = CDbl(TxtQty1.Text) + CDbl(TxtQty2.Text) \ con1
                TxtQty2.Text = CDbl(TxtQty2.Text) Mod con1
            End If
        End If
    End Sub
    Public Sub CalculateValuesWithNumeric()
        If IscompoundUnit = True Then
            If CDbl(TxtQty2.Text) <> 0 Then
                TxtQty1.Text = CDbl(TxtQty1.Text) + CDbl(TxtQty2.Text) \ con1
                TxtQty2.Text = CDbl(TxtQty2.Text) Mod con1
            End If
        End If
    End Sub
    Private Sub TxtQty2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty2.TextChanged
        Try
            RaiseEvent QtyChanageEvent(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IMSQtyBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtQty1.Text = "0"
        TxtQty2.Text = "0"
    End Sub

    Private Sub TxtQty1_GotFocus(sender As Object, e As System.EventArgs) Handles TxtQty1.GotFocus
        RaiseEvent QtyGotFocus(Me)
    End Sub

    Private Sub TxtQty1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQty1.LostFocus
        Try
            RaiseEvent QtyLostFocus(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtQty1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty1.TextChanged
        Try
            RaiseEvent QtyChanageEvent(Me)
        Catch ex As Exception

        End Try
    End Sub
End Class
