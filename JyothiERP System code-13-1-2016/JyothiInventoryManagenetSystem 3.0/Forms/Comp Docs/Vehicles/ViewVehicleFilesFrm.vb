Imports System.Windows.Forms
Imports System.IO
Public Class ViewVehicleFilesFrm

    Dim DocName As String = ""
    Sub New(ByVal Documentname As String)

        ' This call is required by the designer.
        InitializeComponent()
        DocName = Documentname

        TxtHeading.Text = "Attachment for " & Documentname
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Sub LoadDocDatas()
        TxtAttach1.Text = ""
        TxtAttach2.Text = ""
        TxtAttach3.Text = ""
        TxtAttach4.Text = ""
        TxtAttach5.Text = ""
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SqlFcmd As New SqlClient.SqlCommand
            SqlFcmd.Connection = SqlConn1
            SqlFcmd.CommandText = "select * from Vehicle where vhname=N'" & TxtDocName.Text & "'"
            SqlFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SqlFcmd.ExecuteReader
            While Sreader.Read()
                TxtAttach1.Text = Sreader("DocAttachFileName1").ToString.Trim
                TxtAttach2.Text = Sreader("DocAttachFileName2").ToString.Trim
                TxtAttach3.Text = Sreader("DocAttachFileName3").ToString.Trim
                TxtAttach4.Text = Sreader("DocAttachFileName4").ToString.Trim
                TxtAttach5.Text = Sreader("DocAttachFileName5").ToString.Trim
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try
        If TxtAttach1.Text.Length = 0 Then
            btnBrowse1.Visible = False
            BtnRemove1.Visible = False
        Else
            btnBrowse1.Visible = True
            BtnRemove1.Visible = True
        End If
        If TxtAttach2.Text.Length = 0 Then
            btnBrowse2.Visible = False
            BtnRemove2.Visible = False
        Else
            btnBrowse2.Visible = True
            BtnRemove2.Visible = True
        End If
        If TxtAttach3.Text.Length = 0 Then
            btnBrowse3.Visible = False
            BtnRemove3.Visible = False
        Else
            btnBrowse3.Visible = True
            BtnRemove3.Visible = True
        End If
        If TxtAttach4.Text.Length = 0 Then
            btnBrowse4.Visible = False
            BtnRemove4.Visible = False
        Else
            btnBrowse4.Visible = True
            BtnRemove4.Visible = True
        End If
        If TxtAttach5.Text.Length = 0 Then
            btnBrowse5.Visible = False
            BtnRemove5.Visible = False
        Else
            btnBrowse5.Visible = True
            BtnRemove5.Visible = True
        End If

    End Sub

    Private Sub ViewVehicleFilesFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub ViewDocFilesfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select vhname from Vehicle", TxtDocName, "vhname")
        TxtDocName.Text = DocName
        LoadDocDatas()
    End Sub

    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach1 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
        Dim objSfd As New FolderBrowserDialog
        If objSfd.ShowDialog() <> DialogResult.Cancel Then
            Dim strFileToSave As String = objSfd.SelectedPath
            Dim objFileStream As New FileStream(strFileToSave & "\" & TxtAttach1.Text, FileMode.Create, FileAccess.Write)
            objFileStream.Write(objData, 0, objData.Length)
            objFileStream.Close()
        End If
        objSfd.Dispose()

    End Sub

    Private Sub btnBrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse2.Click
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach2 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
        Dim objSfd As New FolderBrowserDialog
        If objSfd.ShowDialog() <> DialogResult.Cancel Then
            Dim strFileToSave As String = objSfd.SelectedPath
            Dim objFileStream As New FileStream(strFileToSave & "\" & TxtAttach2.Text, FileMode.Create, FileAccess.Write)
            objFileStream.Write(objData, 0, objData.Length)
            objFileStream.Close()
        End If
        objSfd.Dispose()
    End Sub

    Private Sub btnBrowse3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse3.Click
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach3 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
        Dim objSfd As New FolderBrowserDialog
        If objSfd.ShowDialog() <> DialogResult.Cancel Then
            Dim strFileToSave As String = objSfd.SelectedPath
            Dim objFileStream As New FileStream(strFileToSave & "\" & TxtAttach3.Text, FileMode.Create, FileAccess.Write)
            objFileStream.Write(objData, 0, objData.Length)
            objFileStream.Close()
        End If
        objSfd.Dispose()
    End Sub

    Private Sub btnBrowse4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse4.Click
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach4 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
        Dim objSfd As New FolderBrowserDialog
        If objSfd.ShowDialog() <> DialogResult.Cancel Then
            Dim strFileToSave As String = objSfd.SelectedPath
            Dim objFileStream As New FileStream(strFileToSave & "\" & TxtAttach4.Text, FileMode.Create, FileAccess.Write)
            objFileStream.Write(objData, 0, objData.Length)
            objFileStream.Close()
        End If
        objSfd.Dispose()
    End Sub

    Private Sub btnBrowse5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse5.Click
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach5 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
        Dim objSfd As New FolderBrowserDialog
        If objSfd.ShowDialog() <> DialogResult.Cancel Then
            Dim strFileToSave As String = objSfd.SelectedPath
            Dim objFileStream As New FileStream(strFileToSave & "\" & TxtAttach5.Text, FileMode.Create, FileAccess.Write)
            objFileStream.Write(objData, 0, objData.Length)
            objFileStream.Close()
        End If
        objSfd.Dispose()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtDocName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDocName.SelectedIndexChanged
        DocName = TxtDocName.Text
        TxtHeading.Text = "Attachment for " & DocName
        LoadDocDatas()
    End Sub

    Private Sub BtnRemove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove1.Click
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach1 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
            pos = TxtAttach1.Text.ToString.IndexOf(".")
            ExtName = TxtAttach1.Text.ToString.Substring(pos, TxtAttach1.Text.Length - pos)
            sTempFileName = sTempFileName & ExtName
            Try
                Dim objFileStream As New FileStream(sTempFileName, FileMode.Create, FileAccess.Write)
                objFileStream.Write(objData, 0, objData.Length)
                objFileStream.Close()
                Process.Start(sTempFileName)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub BtnRemove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove2.Click
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach2 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
            pos = TxtAttach2.Text.ToString.IndexOf(".")
            ExtName = TxtAttach2.Text.ToString.Substring(pos, TxtAttach2.Text.Length - pos)
            sTempFileName = sTempFileName & ExtName
            Try
                Dim objFileStream As New FileStream(sTempFileName, FileMode.Create, FileAccess.Write)
                objFileStream.Write(objData, 0, objData.Length)
                objFileStream.Close()
                Process.Start(sTempFileName)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnRemove3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove3.Click
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach3 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
            pos = TxtAttach3.Text.ToString.IndexOf(".")
            ExtName = TxtAttach3.Text.ToString.Substring(pos, TxtAttach3.Text.Length - pos)
            sTempFileName = sTempFileName & ExtName
            Try
                Dim objFileStream As New FileStream(sTempFileName, FileMode.Create, FileAccess.Write)
                objFileStream.Write(objData, 0, objData.Length)
                objFileStream.Close()
                Process.Start(sTempFileName)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnRemove4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove4.Click
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach4 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
            pos = TxtAttach4.Text.ToString.IndexOf(".")
            ExtName = TxtAttach4.Text.ToString.Substring(pos, TxtAttach4.Text.Length - pos)
            sTempFileName = sTempFileName & ExtName
            Try
                Dim objFileStream As New FileStream(sTempFileName, FileMode.Create, FileAccess.Write)
                objFileStream.Write(objData, 0, objData.Length)
                objFileStream.Close()
                Process.Start(sTempFileName)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnRemove5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove5.Click
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach5 from Vehicle where vhname=N'" & DocName & "'").Rows(0).Item(0), Byte())
            pos = TxtAttach5.Text.ToString.IndexOf(".")
            ExtName = TxtAttach5.Text.ToString.Substring(pos, TxtAttach5.Text.Length - pos)
            sTempFileName = sTempFileName & ExtName
            Try
                Dim objFileStream As New FileStream(sTempFileName, FileMode.Create, FileAccess.Write)
                objFileStream.Write(objData, 0, objData.Length)
                objFileStream.Close()
                Process.Start(sTempFileName)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
