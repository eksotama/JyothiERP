Imports System.Windows.Forms

Public Class EmpGratuityCalculationMethods
    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub
    Sub loadData()
        Dim SQLstr As String = ""
        SQLstr = "SELECT ROW_NUMBER() OVER (ORDER BY years) AS [SNO], years as [Years],price as [Gratuity Days],method as [Method] from EmpGratuityMethods where method=N'" & TxtMethod.Text & "' order by years"
        Dim TempBS As New BindingSource
        Try
            Me.TxtList.Rows.Clear()
        Catch ex As Exception

        End Try

        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SQLstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("SNO").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("SNO").Width = 45

            TxtList.Columns("Gratuity Days").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            TxtList.Columns("Years").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Years").Width = 120

            TxtList.Columns("Method").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtList.Columns("Method").Width = 150

        Catch ex As Exception

        End Try
        For i As Integer = 0 To TxtList.RowCount - 1

        Next
        'select max(years) as tot from EmpGratuityMethods 
        TxtStartyear.Text = SQLGetNumericFieldValue("select max(years) as tot from EmpGratuityMethods ", "tot")
    End Sub

    Private Sub EmpGratuityCalculationMethods_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
   
    Private Sub EmpGratuityCalculationMethods_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select distinct method from EmpGratuityMethods", TxtMethod, "method")
        If TxtMethod.Items.Count = 0 Then
            TxtMethod.Items.Add("Method 1")

        End If
        loadData()

    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If CDbl(TxtValue.Text) < 0 Then
            MsgBox("Please Enter the Gratuity Value greater than zero ... ", MsgBoxStyle.Information)
            TxtValue.Focus()
            Exit Sub
        End If
        If CDbl(TxtYears.Text) <= 0 Or CDbl(TxtYears.Text) <= CDbl(TxtStartyear.Text) Then
            MsgBox("Please Enter the Gratuity Years greater than zero ... ", MsgBoxStyle.Information)
            TxtYears.Focus()
            Exit Sub
        End If
        If TxtMethod.Text.Length = 0 Then
            MsgBox("Please Select the Method of calculation.... ", MsgBoxStyle.Information)
            TxtMethod.Focus()
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   EmpGratuityMethods where years=" & TxtYears.Text & " and method=N'" & TxtMethod.Text & "'") = True Then
            MsgBox("The Entered Calculated Values for the Year is already exits....", MsgBoxStyle.Information)
            TxtYears.Focus()
            Exit Sub
        End If


        If MsgBox("Do you want to add Calucations ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim calvalue As Integer = 0
            Dim SqlStr As String = ""

            If TxtMethod.Text = "On Period Wise" Then
                calvalue = 1
            Else
                calvalue = 2
            End If
            SqlStr = "INSERT INTO [EmpGratuityMethods] ([Method],[Years],[Price],[MethodValue])     VALUES (N'" & TxtMethod.Text & "'," & CDbl(TxtYears.Text) & "," & CDbl(TxtValue.Text) & "," & calvalue & ")"
            ExecuteSQLQuery(SqlStr)
            loadData()
            TxtValue.Focus()
        End If
    End Sub



    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If TxtList.RowCount = 0 Then Exit Sub
        If TxtList.CurrentRow.Index < 0 Then Exit Sub
        If TxtList.CurrentRow.Index <> TxtList.RowCount - 1 Then
            MsgBox("You can delete last row only...            ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to delete the selected Row ?  ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ExecuteSQLQuery("DELETE FROM EmpGratuityMethods WHERE Years=" & TxtList.Item("Years", TxtList.CurrentRow.Index).Value & " and method=N'" & TxtMethod.Text & "'")
            loadData()
        End If
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Me.Close()
    End Sub

    Private Sub TxtMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMethod.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub BtnNewMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewMethod.Click
        Dim inputstring As String = ""
ReEntry:
        inputstring = InputBox("Enter the Method Name ", "")
        If inputstring.Length > 0 Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   EmpGratuityMethods where  method=N'" & inputstring & "'") = True Then
                If MsgBox("The Entered Method Name  is already exits.., Do you want to try again?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    GoTo ReEntry
                End If
            Else
                TxtMethod.Items.Add(inputstring)
                TxtMethod.Text = inputstring
            End If
        Else
            Exit Sub
        End If
    End Sub
End Class
