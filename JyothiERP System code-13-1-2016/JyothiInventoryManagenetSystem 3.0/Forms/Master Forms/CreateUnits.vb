Imports System.Windows.Forms

Public Class CreateUnits
    Dim IsAlter As Boolean = False
    Dim AlterUnitName As String = ""
#Region "Functions"
    Sub LoadDefaults()
        TxtSimpleUnitName.Text = ""
        TxtConversion.Text = 0
        TxtDecimals.Text = "0"
        LoadDataIntoComboBox("select unitname from stockunits where unittype=0", TxtMainUnitName, "unitname")
        LoadDataIntoComboBox("select unitname from stockunits where unittype=0", TxtSubUnit, "unitname")

    End Sub
    Sub LoadUnitData()
        Dim SqlConn1 As New SqlClient.SqlConnection
        Dim Sqlcmmd1 As New SqlClient.SqlCommand
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Sqlcmmd1.Connection = SqlConn1
            Sqlcmmd1.CommandText = "select * from stockunits where unitname=N'" & AlterUnitName & "'"
            Sqlcmmd1.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd1.ExecuteReader
            While Sreader.Read()
                If Sreader("UnitType") = 1 Then
                    TxtUnitType.Text = "Compound"
                    TxtMainUnitName.Text = Sreader("MainUnitName").ToString.Trim
                    TxtMainUnitName.Text = Sreader("SubUnitName").ToString.Trim
                    TxtConversion.Text = Sreader("UnitConversion")
                    TxtDecimals.Text = Sreader("Decimals")
                Else
                    TxtUnitType.Text = "Simple"
                    TxtSimpleUnitName.Text = Sreader("unitname").ToString.Trim
                    TxtFormalName.Text = Sreader("formalname").ToString.Trim
                    TxtDecimals.Text = Sreader("Decimals")
                    'Decimals
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
            SqlConn1 = Nothing
            Sqlcmmd1.Connection = Nothing
        End Try
    End Sub
#End Region

    Sub New(Optional ByVal VUnitName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If VUnitName.Length > 0 Then
            IsAlter = True
            AlterUnitName = VUnitName
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TxtUnitType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUnitType.SelectedIndexChanged
        If TxtUnitType.Text = "Simple" Then
            TxtSimplePanel.Visible = True
            TxtCompoundpanel.Visible = False
        Else
            TxtSimplePanel.Visible = False
            TxtCompoundpanel.Visible = True
        End If
    End Sub

    Private Sub CreateUnits_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtSimpleUnitName.Focus()
    End Sub

    Private Sub CreateUnits_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDefaults()
        If IsAlter = True Then
            LoadUnitData()
            BtnCreate.Text = "&Alter"
        Else
            TxtUnitType.Text = "Simple"
        End If

    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click

        If TxtUnitType.Text = "Simple" Then
            'FOR Simple Unit
            If TxtSimpleUnitName.Text.Trim.Length = 0 Then
                MsgBox("Please Enter the Unit Name ", MsgBoxStyle.Information, MySoftwareName)
                TxtSimpleUnitName.Focus()
                Exit Sub
            End If
            If IsAlter = True Then
                If UCase(TxtSimpleUnitName.Text) <> UCase(AlterUnitName) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   stockunits where unitname=N'" & TxtSimpleUnitName.Text.Trim & "'") = True Then
                        MsgBox("The Entered Unit is already exist..", MsgBoxStyle.Information)
                        TxtSimpleUnitName.Focus()
                        Exit Sub
                    End If
                End If
                'ExecuteSQLQuery("delete from stockunits where unitname=N'" & AlterUnitName & "'")
                If MsgBox("Do you want to Alter ?         ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, MySoftwareName) Then
                    Dim SqlStr As String = ""
                    ExecuteSQLQuery("delete from stockunits where unitname=N'" & AlterUnitName & "'")
                    SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                        & "VALUES(N'" & TxtSimpleUnitName.Text & "', N'" & TxtSimpleUnitName.Text & "','',1,0,N'" & TxtFormalName.Text & "'," & TxtDecimals.Text & ")"
                    '   MsgBox(SqlStr)
                    ExecuteSQLQuery(SqlStr)
                    LoadDefaults()
                    TxtStatus.Text = "Status: Saved successfully..."
                    TxtSimpleUnitName.Focus()
                    Timer1.Enabled = True
                    Me.Close()
                End If
            Else
                If SQLIsFieldExists("SELECT TOP 1 1 from   stockunits where unitname=N'" & TxtSimpleUnitName.Text.Trim & "'") = True Then
                    MsgBox("The Entered Unit is already exist..", MsgBoxStyle.Information)
                    TxtSimpleUnitName.Focus()
                    Exit Sub
                End If
                If MsgBox("Do you want to Create ?         ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, MySoftwareName) Then
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                        & "VALUES(N'" & TxtSimpleUnitName.Text & "', N'" & TxtSimpleUnitName.Text & "','',1,0,N'" & TxtFormalName.Text & "'," & TxtDecimals.Text & ")"
                    '   MsgBox(SqlStr)
                    ExecuteSQLQuery(SqlStr)
                    LoadDefaults()
                    TxtStatus.Text = "Status: Saved successfully..."
                    TxtSimpleUnitName.Focus()
                    Timer1.Enabled = True
                End If
            End If
        Else
            'FOr compound unit
            If TxtMainUnitName.Text.Trim.Length = 0 Then
                MsgBox("Please Select The Primary Unit Name          ", MsgBoxStyle.Information)
                TxtMainUnitName.Focus()
                Exit Sub
            End If
            If TxtSubUnit.Text.Trim.Length = 0 Then
                MsgBox("Please Select The Sub Unit Name          ", MsgBoxStyle.Information)
                TxtSubUnit.Focus()
                Exit Sub
            End If
            If TxtMainUnitName.Text = TxtSubUnit.Text Then
                MsgBox("The Main and Sub units are same......", MsgBoxStyle.Information)
                TxtMainUnitName.Focus()
                Exit Sub
            End If
            If CDbl(TxtConversion.Text) <= 1 Then
                MsgBox("Please Enter the Unit Conversion    ", MsgBoxStyle.Information)
                TxtConversion.Focus()
                Exit Sub
            End If
            Dim unitstr As String
            unitstr = TxtMainUnitName.Text & " Of " & TxtConversion.Text & " " & TxtSubUnit.Text
            If IsAlter = True Then
                If UCase(TxtSimpleUnitName.Text) <> UCase(AlterUnitName) Then
                    If SQLIsFieldExists("SELECT TOP 1 1 from   stockunits where unitname=N'" & unitstr & "'") = True Then
                        MsgBox("The Entered Unit is already exist..", MsgBoxStyle.Information)
                        TxtSimpleUnitName.Focus()
                        Exit Sub
                    End If
                End If

                If MsgBox("Do you want to Alter  ?         ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, MySoftwareName) = MsgBoxResult.Yes Then
                    ExecuteSQLQuery("delete from stockunits where unitname=N'" & AlterUnitName & "'")
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                         & "VALUES(N'" & unitstr & "', N'" & TxtMainUnitName.Text.Trim & "',N'" & TxtSubUnit.Text.Trim & "'," & CDbl(TxtConversion.Text) & ",1,'',2)"
                    '   MsgBox(SqlStr)
                    ExecuteSQLQuery(SqlStr)
                    LoadDefaults()
                    TxtMainUnitName.Focus()
                    TxtStatus.Text = "Status: Saved successfully..."
                    Timer1.Enabled = True
                    Me.Close()
                End If

            Else
                If SQLIsFieldExists("SELECT TOP 1 1 from   stockunits where unitname=N'" & unitstr & "'") = True Then
                    MsgBox("The Entered Unit is already exist..", MsgBoxStyle.Information)
                    TxtMainUnitName.Focus()
                    Exit Sub
                End If
                If MsgBox("Do you want to Create ?         ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, MySoftwareName) = MsgBoxResult.Yes Then
                    Dim SqlStr As String = ""
                    SqlStr = "INSERT INTO [Stockunits]([UnitName],[MainUnitName],[SubUnitName],[UnitConversion],[UnitType],[formalname],[Decimals]) " _
                         & "VALUES(N'" & unitstr & "', N'" & TxtMainUnitName.Text.Trim & "',N'" & TxtSubUnit.Text.Trim & "'," & CDbl(TxtConversion.Text) & ",1,'',2)"
                    '   MsgBox(SqlStr)
                    ExecuteSQLQuery(SqlStr)
                    LoadDefaults()
                    TxtMainUnitName.Focus()
                    TxtStatus.Text = "Status: Saved successfully..."
                    Timer1.Enabled = True
                End If

            End If


        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static k As Boolean = True
        Static c As Byte = 0
        If k = True Then
            TxtStatus.ForeColor = Color.Green
            k = False
        Else
            TxtStatus.ForeColor = Color.Blue
            k = True
        End If
        If c = 5 Then
            Timer1.Enabled = False
            c = 0
            TxtStatus.ForeColor = Color.Green
            TxtStatus.Text = "Status: Ready"
        Else
            c = c + 1
        End If
    End Sub
End Class
