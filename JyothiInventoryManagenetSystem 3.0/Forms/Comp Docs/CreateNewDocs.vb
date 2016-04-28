Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class CreateNewDocs

    Dim IsOpenForAlter As Boolean = False
    Dim OpenDocName As String = ""
    Dim Photoname As String = ""
    Dim Ischekedout As Boolean = False
    Sub New(Optional ByVal EmpName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If EmpName.Length > 0 Then
            IsOpenForAlter = True
            OpenDocName = EmpName

        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadDocDatas()
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SqlFcmd As New SqlClient.SqlCommand
            SqlFcmd.Connection = SqlConn1
            SqlFcmd.CommandText = "select * from documents where docname=N'" & OpenDocName & "'"
            SqlFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SqlFcmd.ExecuteReader
            While Sreader.Read()
                TxtDocType.Text = Sreader("DocType").ToString.Trim
                TxtRefNo.Text = Sreader("DocRefNo").ToString.Trim
                TxtDocNo.Text = Sreader("DocID").ToString.Trim
                TxtDocName.Text = Sreader("DocName").ToString.Trim
                TxtIssuedBy.Text = Sreader("IssuedBy").ToString.Trim
                TxtExpiryDate.Value = Sreader("ExpiryDate")
                TxtAdd1.Text = Sreader("DocAdd1").ToString.Trim
                TxtAdd2.Text = Sreader("DocAdd2").ToString.Trim
                TxtAdd3.Text = Sreader("DocAdd3").ToString.Trim
                TxtAdd4.Text = Sreader("DocAdd4").ToString.Trim
                TxtLocation.Text = Sreader("Location").ToString.Trim
                TxtPerson.Text = Sreader("ContactPerson").ToString.Trim
                TxtPersonAddress.Text = Sreader("PersonAddress").ToString.Trim
                TxtAttach1.Text = Sreader("DocAttachFileName1").ToString.Trim
                TxtAttach2.Text = Sreader("DocAttachFileName2").ToString.Trim
                TxtAttach3.Text = Sreader("DocAttachFileName3").ToString.Trim
                TxtAttach4.Text = Sreader("DocAttachFileName4").ToString.Trim
                TxtAttach5.Text = Sreader("DocAttachFileName5").ToString.Trim
                Ischekedout = Sreader("isCheckOut")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try

    End Sub
    Sub loadDefaults()
        TxtRefNo.Text = ""
        TxtDocName.Text = ""
        TxtDocNo.Text = ""
        TxtDocType.Text = ""
        TxtAdd1.Text = ""
        TxtAdd2.Text = ""
        TxtAdd3.Text = ""
        TxtAdd4.Text = ""
        TxtAttach1.Text = ""
        TxtAttach2.Text = ""
        TxtAttach3.Text = ""
        TxtAttach4.Text = ""
        TxtAttach5.Text = ""
        TxtPerson.Text = ""
        TxtPersonAddress.Text = ""
        TxtExpiryDate.Value = Today
        TxtIssuedBy.Text = ""
        TxtLocation.Text = ""
    End Sub

    Private Sub CreateNewDocs_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub CreateEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadDefaults()
        If IsOpenForAlter = True Then
            LoadDocDatas()
            BtnCreate.Text = "&Alter"

        End If

    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtDocType.Text.Length < 3 Then
            MsgBox("Please Enter the Document Type  (Min Length 3 Letters)...   ", MsgBoxStyle.Information)
            TxtDocType.Focus()
            Exit Sub
        End If
        If TxtDocName.Text.Length < 3 Then
            MsgBox("Please Enter the Document Name (Min Length 3 Letters)....", MsgBoxStyle.Information)
            TxtDocName.Focus()
            Exit Sub
        End If
        If IsOpenForAlter = True Then
            If UCase(OpenDocName) <> UCase(TxtDocName.Text) Then
                If SQLIsFieldExists("select DocName from Documents where DocName=N'" & TxtDocName.Text & "'") = True Then
                    MsgBox("The Entered Document Name is already Exits......", MsgBoxStyle.Information)
                    TxtDocName.Focus()
                    Exit Sub
                End If
            End If
        Else
            If SQLIsFieldExists("select DocName from Documents where DocName=N'" & TxtDocName.Text & "'") = True Then
                MsgBox("The Entered Document Name is already Exits......", MsgBoxStyle.Information)
                TxtDocName.Focus()
                Exit Sub
            End If
        End If
        If MsgBox("Do you want to Save ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveDocuments()
            ExecuteSQLQuery("update documentissues set docname=N'" & TxtDocName.Text & "' where docname=N'" & OpenDocName & "'")
            If IsOpenForAlter = True Then
                Me.Close()
            End If
            loadDefaults()
        End If
    End Sub
    Sub SaveDocuments()
        MainForm.Cursor = Cursors.WaitCursor
        Dim SqlStr As String = ""
        If IsOpenForAlter = True Then
            SqlStr = "UPDATE DOCUMENTS SET DocType=@DocType,DocRefNo=@DocRefNo,DocID=@DocID,DocName=@DocName,IssuedBy=@IssuedBy, ExpiryDate=@ExpiryDate," _
                & " DocAdd1=@DocAdd1,DocAdd2=@DocAdd2,DocAdd3=@DocAdd3,DocAdd4=@DocAdd4,Location=@Location,ContactPerson=@ContactPerson,PersonAddress=@PersonAddress,IsDelete=@IsDelete,IsActive=@IsActive,Status=@Status, isCheckOut=@isCheckOut WHERE DOCNAME=N'" & OpenDocName & "'"
        Else
            SqlStr = "INSERT INTO [Documents]([DocType],[DocRefNo],[DocID],[DocName],[IssuedBy],[ExpiryDate],[DocAdd1],[DocAdd2],[DocAdd3],[DocAdd4],[Location],[ContactPerson],[PersonAddress],[IsDelete],[IsActive],[Status],[isCheckOut])     VALUES " _
         & " (@DocType,@DocRefNo,@DocID,@DocName,@IssuedBy,@ExpiryDate,@DocAdd1,@DocAdd2,@DocAdd3,@DocAdd4,@Location,@ContactPerson,@PersonAddress,@IsDelete,@IsActive,@Status,@isCheckOut) "

        End If
         Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("DocType", TxtDocType.Text)
                .AddWithValue("DocRefNo", TxtRefNo.Text)
                .AddWithValue("DocID", TxtDocNo.Text)
                .AddWithValue("DocName", TxtDocName.Text)
                .AddWithValue("IssuedBy", TxtIssuedBy.Text)
                .AddWithValue("ExpiryDate", TxtExpiryDate.Value.Date)
                .AddWithValue("DocAdd1", TxtAdd1.Text)
                .AddWithValue("DocAdd2", TxtAdd2.Text)
                .AddWithValue("DocAdd3", TxtAdd3.Text)
                .AddWithValue("DocAdd4", TxtAdd4.Text)
                .AddWithValue("Location", TxtLocation.Text)
                .AddWithValue("ContactPerson", TxtPerson.Text)
                .AddWithValue("PersonAddress", TxtPersonAddress.Text)
                .AddWithValue("IsDelete", 0)
                .AddWithValue("IsActive", 1)
                .AddWithValue("Status", "New")
                .AddWithValue("isCheckOut", Ischekedout)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If TxtAttach1.Text.Length > 0 Then
            If TxtAttach1.Text.Contains("\") = True Then SaveAttachment(TxtAttach1.Text, "DocAttachFileName1", "DocAttachFileSize1", "DocAttach1")
        Else
            ExecuteSQLQuery("Update documents set DocAttachFileName1='',DocAttachFileSize1=0,DocAttach1=NULL where docname=N'" & TxtDocName.Text & "'")
        End If

        If TxtAttach2.Text.Length > 0 Then
            If TxtAttach2.Text.Contains("\") = True Then SaveAttachment(TxtAttach2.Text, "DocAttachFileName2", "DocAttachFileSize2", "DocAttach2")
        Else
            ExecuteSQLQuery("Update documents set DocAttachFileName2='',DocAttachFileSize2=0,DocAttach2=NULL where docname=N'" & TxtDocName.Text & "'")
        End If

        If TxtAttach3.Text.Length > 0 Then
            If TxtAttach3.Text.Contains("\") = True Then SaveAttachment(TxtAttach3.Text, "DocAttachFileName3", "DocAttachFileSize3", "DocAttach3")
        Else
            ExecuteSQLQuery("Update documents set DocAttachFileName3='',DocAttachFileSize3=0,DocAttach3=NULL where docname=N'" & TxtDocName.Text & "'")
        End If

        If TxtAttach4.Text.Length > 0 Then
            If TxtAttach4.Text.Contains("\") = True Then SaveAttachment(TxtAttach4.Text, "DocAttachFileName4", "DocAttachFileSize4", "DocAttach4")
        Else
            ExecuteSQLQuery("Update documents set DocAttachFileName4='',DocAttachFileSize4=0,DocAttach4=NULL where docname=N'" & TxtDocName.Text & "'")
        End If

        If TxtAttach5.Text.Length > 0 Then
            If TxtAttach5.Text.Contains("\") = True Then SaveAttachment(TxtAttach5.Text, "DocAttachFileName5", "DocAttachFileSize5", "DocAttach5")
        Else
            ExecuteSQLQuery("Update documents set DocAttachFileName5='',DocAttachFileSize5=0,DocAttach5=NULL where docname=N'" & TxtDocName.Text & "'")
        End If
        MainForm.Cursor = Cursors.Default

    End Sub

    Sub SaveAttachment(ByVal filename As String, ByVal filedFilename As String, ByVal filedfilesize As String, ByVal fileddata As String)

        Dim objFileStream As New FileStream(filename, FileMode.Open, FileAccess.Read)
        Dim intLength As Integer = Convert.ToInt32(objFileStream.Length)
        Dim objData As Byte()
        objData = New Byte(intLength - 1) {}
        Dim strPath As String() = filename.Split(Convert.ToChar("\"))
        objFileStream.Read(objData, 0, intLength)
        objFileStream.Close()

        Dim SqlStr As String = "update documents set " & filedFilename & "=@FiledFileName," & filedfilesize & "=@filedfilesize," & fileddata & "=@fileddata" & " where docname=N'" & TxtDocName.Text & "'"

        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("FiledFileName", strPath(strPath.Length - 1))
                .AddWithValue("filedfilesize", intLength / 1024)
                .AddWithValue("fileddata", objData)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnRemove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove1.Click
        TxtAttach1.Text = ""
    End Sub

    Private Sub BtnRemove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove2.Click
        TxtAttach2.Text = ""
    End Sub

    Private Sub BtnRemove3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove3.Click
        TxtAttach3.Text = ""
    End Sub

    Private Sub BtnRemove4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove4.Click
        TxtAttach4.Text = ""
    End Sub

    Private Sub BtnRemove5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove5.Click
        TxtAttach5.Text = ""
    End Sub

    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Files "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png |All files (*.*)|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtAttach1.Text = sd.FileName
        End If
    End Sub

    Private Sub btnBrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse2.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Files "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png |All files (*.*)|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtAttach2.Text = sd.FileName
        End If
    End Sub

    Private Sub btnBrowse3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse3.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Files "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png |All files (*.*)|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtAttach3.Text = sd.FileName
        End If
    End Sub

    Private Sub btnBrowse4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse4.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Files "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png |All files (*.*)|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtAttach4.Text = sd.FileName
        End If
    End Sub

    Private Sub btnBrowse5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse5.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Files "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png |All files (*.*)|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtAttach5.Text = sd.FileName
        End If
    End Sub
End Class
