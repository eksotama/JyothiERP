Imports System.Data.SqlClient

Public Class notesfrm
    Dim NoteNumber As Long
    Dim IsOpen As Boolean = False
    Dim RecordNumber As Long = 0
    Dim NoteList As New ComboBox

    Private Sub notesfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub notesfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        TxtDate.Format = DateTimePickerFormat.Custom
        TxtDate.CustomFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern().ToString & " hh:mm:ss"
        TxtDate.Value = Now
        ReloadNotesList()
    End Sub
    Sub ReloadNotesList()
        LoadDataIntoComboBox("select noteno from notes where userid=N'" & CurrentUserName & "'", NoteList, "Noteno")
        RecordNumber = Me.NoteList.Items.Count
        If RecordNumber = 0 Then

            NEwNote()
        Else
            NoteNumber = NoteList.Items(RecordNumber - 1)
            LoadNotes()
        End If
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If IsOpen = True Then
            Dim Vstr As String = ""
            Vstr = " UPDATE [notes]    SET [noteno] = @noteno,[notes] = @notes,[notedate] = @notedate,[UserID] = @UserID WHERE noteno=" & NoteNumber
            SaveNotes(Vstr)
        Else
            Dim vStr As String = ""
            vStr = "INSERT INTO [notes]([noteno],[notes],[notedate],[UserID])     VALUES (@noteno,@notes,@notedate,@UserID)  "
            SaveNotes(vStr)
            NoteList.Items.Add(NoteNumber)
            RecordNumber = NoteList.Items.Count
            NEwNote()
        End If
    End Sub
    Sub SaveNotes(ByVal Sqlstr As String)

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(Sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("noteno", NoteNumber)
            .AddWithValue("notes", TxtNotes.Text)
            .AddWithValue("notedate", TxtDate.Value)
            .AddWithValue("UserID", CurrentUserName)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
        MAINCON.Close()

    End Sub
    Sub LoadNotes()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from notes where userid=N'" & CurrentUserName & "' and noteno=" & NoteNumber
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                TxtNoteID.Text = "Note ID:" & Sreader("Noteno").ToString
                TxtNotes.Text = Sreader("notes").ToString
                TxtDate.Value = Sreader("notedate")
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
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        NEwNote()
    End Sub
    Sub NEwNote()
        If Me.NoteList.Items.Count > 25000 Then
            MsgBox("The Max no of Notes are reached, Please delete some notes and try again....        ", MsgBoxStyle.Information)
            Exit Sub
        End If
        NoteNumber = SQLGetNumericFieldValue("select max(noteno) as tot from notes", "tot") + 1
        TxtDate.Value = Now
        TxtNotes.Text = ""
        TxtNoteID.Text = "Note ID:" & NoteNumber
        IsOpen = False
    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If IsOpen = True Then
            If MsgBox("Do You want to Delete ?              ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM NOTES WHERE NOTEnO=" & NoteNumber)
                ReloadNotesList()
                NEwNote()
            End If
        Else
            NEwNote()
        End If
        TxtNotes.Focus()
    End Sub

    Function FINDNoteID(ByVal NoteNo As Long) As Integer

        Return NoteList.Items.IndexOf(NoteNo.ToString)
    End Function
    Private Sub BtnPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPre.Click
        If NoteList.Items.Count = 0 Then Exit Sub
        IsOpen = True
        RecordNumber = RecordNumber - 1
        If RecordNumber = 0 Then
            RecordNumber = 1
        End If
        NoteNumber = NoteList.Items(RecordNumber - 1)
        LoadNotes()
        TxtNotes.Focus()
    End Sub

    Private Sub TxtSearchBy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSearchBy.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Return) Then
            Dim rowpos As Long = -1
            rowpos = FINDNoteID(CLng(TxtSearchBy.Text))
            If rowpos >= 0 Then
                RecordNumber = rowpos + 1
                NoteNumber = CLng(TxtSearchBy.Text)
                LoadNotes()
            Else
                MsgBox("The Note Number is not Found.....         ", MsgBoxStyle.Information)
                TxtSearchBy.Focus()
                Exit Sub

            End If
        End If

        TxtNotes.Focus()
    End Sub


    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If NoteList.Items.Count = 0 Then Exit Sub
        IsOpen = True
        RecordNumber = RecordNumber + 1
        If RecordNumber > NoteList.Items.Count Then
            RecordNumber = NoteList.Items.Count
        End If
        NoteNumber = NoteList.Items(RecordNumber - 1)
        LoadNotes()
        TxtNotes.Focus()
    End Sub

    Private Sub TxtSearchBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchBy.TextChanged

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If TxtNotes.Text.Length = 0 Then Exit Sub

       

        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("select noteno,notedate,notes from notes where noteno=" & NoteNumber, cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New NotesCRPrint
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "NOTES"
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "NOTES"
        End If
        '   CType(objRpt.Section1.ReportObjects.Item("TxtCurrency"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub BtnPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintAll.Click
        If TxtNotes.Text.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("select noteno,notedate,notes from notes where userid=N'" & CurrentUserName & "'", cnn)
        dscmd.Fill(ds, "DataTable1")
        cnn.Close()
        Dim objRpt As New NotesCRPrint
        SetReportLogos(objRpt.Section1.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section1.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section1.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section1.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "ALL NOTES FOR THE USER " & UCase(CurrentUserName)
        Else
            CType(objRpt.Section1.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "ALL NOTES FOR THE USER " & UCase(CurrentUserName)
        End If
        '   CType(objRpt.Section1.ReportObjects.Item("TxtCurrency"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = ""

        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub
End Class