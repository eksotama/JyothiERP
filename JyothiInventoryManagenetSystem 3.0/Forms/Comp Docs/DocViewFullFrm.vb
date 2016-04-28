Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Public Class DocViewFullFrm

    Dim IsOpenForAlter As Boolean = False
    Dim OpenDocName As String = ""
    Dim Photoname As String = ""
    Dim DocName As String = ""
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
        loadDefaults()

        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SqlFcmd As New SqlClient.SqlCommand
            SqlFcmd.Connection = SqlConn1
            SqlFcmd.CommandText = "select * from documents where docname=N'" & TxtDocList.Text & "'"
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

    Private Sub DocViewFullFrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub CreateEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadDefaults()
        LoadDataIntoComboBox("select docname from documents", TxtDocList, "docname")
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = 0
            DocName = TxtDocList.Text
            LoadDocDatas()
        End If

    End Sub

   
   
    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach1 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach2 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach3 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach4 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach5 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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

    Private Sub BtnRemove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove1.Click
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach1 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach2 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach3 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach4 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach5 from documents where docname=N'" & DocName & "'").Rows(0).Item(0), Byte())
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

    Private Sub TxtDocList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDocList.SelectedIndexChanged
        DocName = TxtDocList.Text
        LoadDocDatas()
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = 0
        End If

    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = TxtDocList.Items.Count - 1
        End If
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        If TxtDocList.Items.Count > 0 Then
            If TxtDocList.SelectedIndex > 0 Then
                TxtDocList.SelectedIndex = TxtDocList.SelectedIndex - 1
            End If

        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If TxtDocList.Items.Count > 0 Then
            If TxtDocList.SelectedIndex < TxtDocList.Items.Count - 1 Then
                TxtDocList.SelectedIndex = TxtDocList.SelectedIndex + 1
            End If

        End If
    End Sub

    Private Sub ImsButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton6.Click, PrintToolStripMenuItem.Click
        If TxtDocList.Text.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT * FROM DOCUMENTS WHERE DOCNAME=N'" & TxtDocList.Text & "'", cnn)
        dscmd.Fill(ds, "DOCUMENTS")
        cnn.Close()
        Dim objRpt As New DocFullDetailsCRReport

        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "DOCUMENT REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "DOCUMENT REPORT"
        End If
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click, PrintAllToolStripMenuItem.CheckedChanged
        If TxtDocList.Text.Length = 0 Then Exit Sub
        Dim STR As String = ""
        If MsgBox("Do You want to Print Active and  InActive Documents Also ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            STR = "SELECT * FROM DOCUMENTS WHERE ISDELETE=0"
        Else
            STR = "SELECT * FROM DOCUMENTS WHERE ISDELETE=0 and isactive=1"
        End If
        Me.Cursor = Cursors.WaitCursor


        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(STR, cnn)
        dscmd.Fill(ds, "DOCUMENTS")
        cnn.Close()
        Dim objRpt As New DocFullDetailsCRReport

        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "DOCUMENT REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "DOCUMENT REPORT"
        End If
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub TxtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocation.TextChanged

    End Sub
End Class
