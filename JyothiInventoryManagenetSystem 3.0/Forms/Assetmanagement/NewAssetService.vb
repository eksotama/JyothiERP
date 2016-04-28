Imports System.Windows.Forms

Public Class NewAssetService

    Dim IsEditMode As Boolean = False
    Sub New(ByVal AssetName As String, Optional ByVal NoteNumber As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()
        TxtAssetName.Text = AssetName
        If NoteNumber > 0 Then
            IsEditMode = True
            TxtNoteNo.Text = NoteNumber
            Me.Text = "Edit Asset Note"
            BtnCreate.Text = "&Save"
        Else
            IsEditMode = False
            Me.Text = "New Asset Note"
            BtnCreate.Text = "&Create"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub lOADDEFS()
        TxtNoteNo.Text = SQLGetNumericFieldValue("SELECT  ( CASE WHEN MAX(NoteID) IS NULL THEN 0 ELSE MAX(NOTEID) END) AS TOT  FROM AssetNoteMaster WHERE   AssetName =N'" & TxtAssetName.Text & "'", "TOT") + 1
        TxtNotes.Text = ""
        TxtDate.CustomFormat = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern & " hh:mm tt"
        TxtDate.Format = DateTimePickerFormat.Custom
        TxtDate.Value = Today
    End Sub

    Private Sub NewAssetService_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CreateAssetNotes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsEditMode = False Then
            lOADDEFS()
        Else
            TxtDate.CustomFormat = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern & " hh:mm tt"
            TxtDate.Format = DateTimePickerFormat.Custom
            TxtDate.Value = SQLGetDateTimeFieldValue("select notedate from FROM AssetNoteMaster WHERE   AssetName =N'" & TxtAssetName.Text & "' and noteid=" & CInt(TxtNoteNo.Text), "notedate").Value
            TxtNotes.Text = SQLGetStringFieldValue("select Note from FROM AssetNoteMaster WHERE   AssetName =N'" & TxtAssetName.Text & "' and noteid=" & CInt(TxtNoteNo.Text), "Note")
        End If
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtNotes.Text.Length = 0 Then
            MsgBox("Please Enter the Notes ....", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim SqlStr As String = ""
        If IsEditMode = True Then
            If MsgBox("Do you want to Save Changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SqlStr = "UPDATE AssetNoteMaster SET Note=@Note,NoteDate=@NoteDate WHERE   AssetName =N'" & TxtAssetName.Text & "' and noteid=" & CInt(TxtNoteNo.Text)
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("Note", TxtNotes.Text)
                    .AddWithValue("NoteDate", TxtDate.Value)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            End If
        Else
            If MsgBox("Do you want to Save  ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SqlStr = "INSERT INTO [AssetNoteMaster] ([Note],[NoteDate],[AssetName],[NoteID]) VALUES (@Note,@NoteDate,@AssetName,@NoteID) "
                MAINCON.ConnectionString = ConnectionStrinG
                MAINCON.Open()
                Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
                With DBF.Parameters
                    .AddWithValue("AssetName", TxtAssetName.Text)
                    .AddWithValue("NoteID", CInt(TxtNoteNo.Text))
                    .AddWithValue("Note", TxtNotes.Text)
                    .AddWithValue("NoteDate", TxtDate.Value)
                End With
                DBF.ExecuteNonQuery()
                DBF = Nothing
                MAINCON.Close()
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Files "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png |All files (*.*)|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim rno As Integer = 0
            rno = TxtFileList.Rows.Add()
            TxtFileList.Item("tsno", rno).Value = TxtFileList.RowCount + 1
            TxtFileList.Item("tfilename", rno).Value = sd.SafeFileName
            TxtFileList.Item("tisnew", rno).Value = 1
            TxtFileList.Item("tisdelete", rno).Value = 0
            TxtFileList.Item("tpath", rno).Value = sd.FileName


        End If
    End Sub
End Class
