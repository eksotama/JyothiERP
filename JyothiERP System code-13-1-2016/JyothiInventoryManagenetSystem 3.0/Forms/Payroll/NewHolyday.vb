Imports System.Windows.Forms

Public Class NewHolyday
    Dim IsAlter As Boolean = False
    Dim AlterSNo As Integer = 0
    Sub New(Optional ByVal Slno As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()
        If Slno > 0 Then
            IsAlter = True
            AlterSNo = Slno
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub NewHolyday_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

   
    Private Sub NewHolyday_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       
        If IsAlter = True Then
            BtnCreate.Text = "&Alter"
            TxtLeaveName.Text = SQLGetStringFieldValue("select leavename from companyleaves where sno=" & AlterSNo, "leavename")
            TxtNarration.Text = SQLGetStringFieldValue("select narration from companyleaves where sno=" & AlterSNo, "narration")
            txtStartDate.Value = SQLGetStringFieldValue("select fromdate from companyleaves where sno=" & AlterSNo, "fromdate")
            TxtEndDate.Text = SQLGetStringFieldValue("select todate from companyleaves where sno=" & AlterSNo, "todate")
        Else
            TxtNarration.Text = ""
            TxtLeaveName.Text = ""
            txtdays.Text = "1"

            txtStartDate.Value = Today.Date
            TxtEndDate.Value = Today.Date.AddDays(1)
        End If
    End Sub

    Private Sub txtStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartDate.ValueChanged
        TxtEndDate.MinDate = txtStartDate.Value
        txtdays.Text = DateDiff(DateInterval.Day, txtStartDate.Value.Date, TxtEndDate.Value.Date)
    End Sub

    Private Sub TxtEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEndDate.ValueChanged
        txtdays.Text = DateDiff(DateInterval.Day, txtStartDate.Value.Date, TxtEndDate.Value.Date)
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtLeaveName.Text.Length < 2 Then
            MsgBox("Please Enter Leave Name....               ", MsgBoxStyle.Information)
            TxtLeaveName.Focus()
            Exit Sub
        End If
        If CDbl(txtdays.Text) < 0 Then
            MsgBox("Invalid Date Range, Please Try again....   ", MsgBoxStyle.Information)
            txtStartDate.Focus()
            Exit Sub
        End If
        If CDbl(txtdays.Text) > 100 Then
            If MsgBox("The Holydays are more thant 100 days, Do you want to Continue.......", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If IsAlter = True Then
            Dim isvalid As Boolean = True
            If SQLIsFieldExists("SELECT TOP 1 1 from   companyleaves where (" & txtStartDate.Value.Date.ToOADate & " between fromdatevalue and todatevalue) and SNO<>" & AlterSNo) = True Then
                isvalid = False
            End If
            If SQLIsFieldExists("SELECT TOP 1 1 from   companyleaves where (" & TxtEndDate.Value.Date.ToOADate & " between fromdatevalue and todatevalue) and SNO<>" & AlterSNo) = True Then
                isvalid = False
            End If
            If isvalid = False Then
                MsgBox("The Selected dates are invalid or already used, Please make sure the dates......", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("Do you want to Alter a Holyday ?             ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            Dim isvalid As Boolean = True
            If SQLIsFieldExists("SELECT TOP 1 1 from   companyleaves where (" & txtStartDate.Value.Date.ToOADate & " between fromdatevalue and todatevalue)") = True Then
                isvalid = False
            End If
            If SQLIsFieldExists("SELECT TOP 1 1 from   companyleaves where (" & TxtEndDate.Value.Date.ToOADate & " between fromdatevalue and todatevalue)") = True Then
                isvalid = False
            End If
            If isvalid = False Then
                MsgBox("The Selected dates are invalid or already used, Please make sure the dates......", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("Do you want to Create a Holyday ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Dim Sqlstr As String = ""
        Dim Sno As Integer = 1
      
        If IsAlter = True Then
          

            Sqlstr = "UPDATE CompanyLeaves SET [LeaveName]=@LeaveName,[FromDate]=@FromDate,[ToDate]=@ToDate,[FromDateValue]=@FromDateValue,[ToDateValue]=@ToDateValue,[Narration]=@Narration,[F1]=@F1,[N1]=@N1,[sno]=@sno WHERE  SNO=" & AlterSNo
            Sno = AlterSNo
        Else
           
            Sno = SQLGetNumericFieldValue("select max(sno) as s from companyleaves", "s")
            If Sno = 0 Then
                Sno = 1
            Else
                Sno = Sno + 1
            End If
            Sqlstr = "INSERT INTO [CompanyLeaves]([LeaveName],[FromDate],[ToDate],[FromDateValue],[ToDateValue],[Narration],[F1],[N1],[Sno])     VALUES " _
                & " (@LeaveName,@FromDate,@ToDate,@FromDateValue,@ToDateValue,@Narration,@F1,@N1,@Sno) "

        End If

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
        With DBF.Parameters
            .AddWithValue("LeaveName", TxtLeaveName.Text)
            .AddWithValue("FromDate", txtStartDate.Value.Date)
            .AddWithValue("ToDate", TxtEndDate.Value.Date)
            .AddWithValue("FromDateValue", txtStartDate.Value.Date.ToOADate)
            .AddWithValue("ToDateValue", TxtEndDate.Value.Date.ToOADate)
            .AddWithValue("Narration", TxtNarration.Text)
            .AddWithValue("F1", "")
            .AddWithValue("N1", 0)
            .AddWithValue("sno", Sno)

        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()
        Me.Close()
       
    End Sub
End Class
