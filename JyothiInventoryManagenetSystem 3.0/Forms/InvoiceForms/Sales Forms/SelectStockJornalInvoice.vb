Imports System.Windows.Forms

Public Class SelectStockJornalInvoice
    Dim LoadType As New ClsSelectInvDB
    Dim DbName As String = ""
    Dim VhName As String = ""
    Dim InvNoFiled As String = ""
    Dim WhereSqlStr As String = ""
    Dim IsTransferRequest As Boolean = False
    Dim IsPUllingdata As Boolean = False
    Sub New(ByRef k As ClsSelectInvDB, Optional ByVal WhereSqlstring As String = "", Optional IsEnquiry As Boolean = False, Optional Ispulldata As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        LoadType = k
        WhereSqlStr = WhereSqlstring
        IsTransferRequest = IsEnquiry
        IsPUllingdata = Ispulldata
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadData(Optional ByVal SqlStrp As String = "")
        Dim SqlStr As String = ""
        If IsPUllingdata = True Then
            SqlStr = "select transdate as [Date],TransCode as [Trans Code],QutoRef as [Ref No] ,nettotal as [Value] from StockTransferDetails Where n2=0 and  isdelete=0 and vouchername='SJ'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and IsApproved=1 and IsPending=1 "
        Else
            If IsTransferRequest = True Then
                If WhereSqlStr.Length > 0 Then
                    SqlStr = "select transdate as [Date],TransCode as [Trans Code],QutoRef as [Ref No] ,nettotal as [Value] from StockTransferDetails Where n2=0 and  isdelete=0 and vouchername='SJ'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and IsApproved is null"
                    If SqlStrp.Length > 0 Then
                        SqlStr = SqlStr & SqlStrp
                    End If
                Else
                    SqlStr = "select transdate as [Date],TransCode as [Trans Code],QutoRef as [Ref No] ,nettotal as [Value] from StockTransferDetails Where n2=1 and  isdelete=0 and vouchername='SJ'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and IsApproved is null"
                    If SqlStrp.Length > 0 Then
                        SqlStr = SqlStr & SqlStrp
                    End If
                End If
            Else
                If WhereSqlStr.Length > 0 Then
                    SqlStr = "select transdate as [Date],TransCode as [Trans Code],QutoRef as [Ref No] ,nettotal as [Value] from StockInvoiceDetails Where n2=0 and  isdelete=0 and vouchername='SJ'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and IsApproved is null"
                    If SqlStrp.Length > 0 Then
                        SqlStr = SqlStr & SqlStrp
                    End If
                Else
                    SqlStr = "select transdate as [Date],TransCode as [Trans Code],QutoRef as [Ref No] ,nettotal as [Value] from StockInvoiceDetails Where n2=1 and  isdelete=0 and vouchername='SJ'  and (TransDateValue between " & TxtStartDate.Value.Date.ToOADate & " and " & TxtEndDate.Value.Date.ToOADate & ") and IsApproved is null"
                    If SqlStrp.Length > 0 Then
                        SqlStr = SqlStr & SqlStrp
                    End If
                End If
            End If

        End If
        Dim TempBS As New BindingSource
        With Me.TxtList
            TempBS.DataSource = SQLLoadGridData(SqlStr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtList.Columns("date").DefaultCellStyle.Format = "d"
            TxtList.Columns("date").Width = 90
            TxtList.Columns("Trans Code").Width = 100
            TxtList.Columns("Ref No").Width = 110
            TxtList.Columns("Value").Width = 130

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SelectStockJornalInvoice_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

   
    Private Sub ChooseInvoiceNumber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtStartDate.Value = EntryCurrentPeriodStart.Value
        TxtEndDate.Value = EntryCurrentPeriodEnd.Value
        LoadData()

    End Sub

    Private Sub TxtList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtList.DataError

    End Sub

   
    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        LoadData()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtInvoice.Text.Length = 0 Then
            LoadData()
        Else
            LoadData("  and qutoref LIKE N'%" & TxtInvoice.Text & "%' ")
        End If
    End Sub



    Private Sub ImsGrid1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtList.CellContentDoubleClick
        OkPressed()
    End Sub
    Sub OkPressed()
        If TxtList.SelectedRows.Count = 0 Then
            MsgBox("Please Select the Invoice Row....     ", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim tc As Single
            tc = TxtList.Item("Trans Code", TxtList.CurrentRow.Index).Value

            If CDbl(tc) <> 0 Then
                Dim testlock As String = IsTransactionLocked(tc)
                If testlock.Length = 0 Then
                    LoadType.SelectedTransCode = tc
                    Me.Close()
                Else
                    MsgBox(testlock)
                End If

            Else
                Exit Sub
            End If
        End If
    End Sub


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        OkPressed()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Me.Close()
    End Sub
End Class
