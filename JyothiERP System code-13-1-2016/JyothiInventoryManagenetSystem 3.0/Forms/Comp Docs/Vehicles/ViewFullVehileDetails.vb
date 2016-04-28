Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient

Public Class ViewFullVehileDetails


    Dim Photoname As String = ""
    Dim IsOpenForAlter As Boolean = False
    Dim OpenedVhName As String
    Sub New(Optional ByVal vehiclename As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If vehiclename.Length > 0 Then
            IsOpenForAlter = True
            OpenedVhName = vehiclename
        Else
            IsOpenForAlter = False
            OpenedVhName = ""
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If MsgBox("Do you want to Close ?    ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
    Sub LoadDefs()
        TxtType.Text = ""
        TxtRefNo.Text = ""
        TxtID.Text = ""
        TxtVhName.Text = ""
        TxtIssuedBy.Text = ""
        TxtRegExpiry.Value = Today.Date
        TxtRegNo.Text = ""
        TxtRegDate.Value = Today.Date
        TxtVhNo.Text = ""
        TxtContactNo1.Text = ""
        TxtContactNO2.Text = ""
        TxtChassiNo.Text = ""
        TxtEngineNo.Text = ""
        TxtAccountGroup.Text = ""
        TxtLedgerName.Text = ""
        Photoname = ""
        TxtAdd1.Text = ""
        TxtAdd2.Text = ""
        TxtAdd3.Text = ""
        TxtAdd4.Text = ""
        TxtDriverName.Text = ""
        TxtAssistantName.Text = ""
        TxtColor.Text = ""
        TxtModel.Text = ""
        TxtMadeBy.Text = ""
        TxtRef1.Text = ""
        TxtPic.SizeMode = PictureBoxSizeMode.StretchImage
        TxtRegDate1.Value = Today.Date
        TxtExpiryDate1.Value = Today.Date
        TxtRef2.Text = ""
        TxtRegDate2.Value = Today.Date
        TxtExpiryDate2.Value = Today.Date
        TxtRef3.Text = ""
        txtRegDate3.Value = Today.Date
        TxtExpiryDate3.Value = Today.Date
        TxtDetails1.Text = ""
        TxtDetails2.Text = ""
        TxtDetails3.Text = ""
        TxtID.Text = ""
        TxtAttach1.Text = ""
        TxtAttach2.Text = ""
        TxtAttach3.Text = ""
        TxtAttach4.Text = ""
        TxtAttach5.Text = ""

        TxtPic.Image = Nothing
        TxtPic.BackgroundImage = Nothing
    End Sub

    'Private Sub BtnRemove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove1.Click
    '    TxtAttach1.Text = ""
    'End Sub

    'Private Sub BtnRemove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove2.Click
    '    TxtAttach2.Text = ""
    'End Sub

    'Private Sub BtnRemove3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove3.Click
    '    TxtAttach3.Text = ""
    'End Sub

    'Private Sub BtnRemove4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove4.Click
    '    TxtAttach4.Text = ""
    'End Sub

    'Private Sub BtnRemove5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove5.Click
    '    TxtAttach5.Text = ""
    'End Sub


    Private Sub BtnRemove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove1.Click
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach1 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach2 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach3 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach4 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
            objData = DirectCast(SQLLoadGridData("select DocAttach5 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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

    Private Sub ViewFullVehileDetails_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub CreateNewVehicle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select empname from employees where isdelete=0 and isactive=1", TxtDriverName, "empname")
        LoadDataIntoComboBox("select empname from employees where isdelete=0 and isactive=1", TxtAssistantName, "empname")
        LoadDataIntoComboBox("select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "'  or groupname=N'" & AccountGroupNames.DirectExpenses & "' ", TxtAccountGroup, "subgroup")
        LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "') ", TxtLedgerName, "ledgername")
        LoadDataIntoComboBox("select vhname from vehicle", TxtDocList, "vhname")
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = 0
            OpenedVhName = TxtDocList.Text
            LoadVhData()
        End If
    End Sub
    Sub LoadVhData()
        LoadDefs()
        Dim SqlConn1 As New SqlClient.SqlConnection
        Try
            SqlConn1.ConnectionString = ConnectionStrinG
            SqlConn1.Open()
            Dim SqlFcmd As New SqlClient.SqlCommand
            SqlFcmd.Connection = SqlConn1
            SqlFcmd.CommandText = "select * from Vehicle where vhname=N'" & OpenedVhName & "'"
            SqlFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SqlFcmd.ExecuteReader
            While Sreader.Read()
                TxtType.Text = Sreader("VhType").ToString.Trim
                TxtRefNo.Text = Sreader("VHRefNo").ToString.Trim
                TxtID.Text = Sreader("VHID")
                TxtVhName.Text = Sreader("VHName")
                TxtIssuedBy.Text = Sreader("IssuedBy")
                TxtRegExpiry.Value = Sreader("ExpiryDate")
                TxtRegNo.Text = Sreader("RegNo")
                TxtRegDate.Value = Sreader("RegDate")
                TxtVhNo.Text = Sreader("VhNo")
                TxtContactNo1.Text = Sreader("ContactNo1")
                TxtContactNO2.Text = Sreader("ContactNo2")
                TxtChassiNo.Text = Sreader("Chasisno")
                TxtEngineNo.Text = Sreader("EngineNo")
                TxtAccountGroup.Text = Sreader("AccountGroup")
                TxtLedgerName.Text = Sreader("AcountLedgerName")

                TxtAdd1.Text = Sreader("DocAdd1")
                TxtAdd2.Text = Sreader("DocAdd2")
                TxtAdd3.Text = Sreader("DocAdd3")
                TxtAdd4.Text = Sreader("DocAdd4")
                TxtDriverName.Text = Sreader("DriverName1")
                TxtAssistantName.Text = Sreader("AssistantName1")
                TxtColor.Text = Sreader("Color")
                TxtModel.Text = Sreader("Model")
                TxtMadeBy.Text = Sreader("MadeBy")
                TxtRef1.Text = Sreader("InsurenceNo1")
                TxtRegDate1.Value = Sreader("InsurenceDate1")
                TxtExpiryDate1.Value = Sreader("InsurenceExpiry1")
                TxtRef2.Text = Sreader("InsurenceNo2")
                TxtRegDate2.Value = Sreader("InsurenceDate2")
                TxtExpiryDate2.Value = Sreader("InsurenceExpiry2")
                TxtRef3.Text = Sreader("InsurenceNo3")
                txtRegDate3.Value = Sreader("InsurenceDate3")
                TxtExpiryDate3.Value = Sreader("InsurenceExpiry3")
                TxtDetails1.Text = Sreader("InsurenceDetails3")
                TxtDetails2.Text = Sreader("InsurenceDetails2")
                TxtDetails3.Text = Sreader("InsurenceDetails1")
                Try
                    TxtPic.Image = GetImageFromDatabase("ImageData", "select TOP 1  ImageData from images where BCODE=N'VEH" & TxtVhName.Text & "'")
                    ' Photoname = Sreader("PhotoPath").ToString.Trim
                Catch ex As Exception

                End Try

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


    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = TxtDocList.Items.Count - 1
        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        If TxtDocList.Items.Count > 0 Then
            If TxtDocList.SelectedIndex < TxtDocList.Items.Count - 1 Then
                TxtDocList.SelectedIndex = TxtDocList.SelectedIndex + 1
            End If

        End If
    End Sub

    Private Sub TxtDocList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDocList.SelectedIndexChanged
        OpenedVhName = TxtDocList.Text
        LoadVhData()
    End Sub

    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        If TxtDocList.Items.Count > 0 Then
            If TxtDocList.SelectedIndex > 0 Then
                TxtDocList.SelectedIndex = TxtDocList.SelectedIndex - 1
            End If

        End If
    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = 0
        End If
    End Sub
    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach1 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach2 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach3 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach4 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
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
        objData = DirectCast(SQLLoadGridData("select DocAttach5 from vehicle where vhname=N'" & OpenedVhName & "'").Rows(0).Item(0), Byte())
        Dim objSfd As New FolderBrowserDialog
        If objSfd.ShowDialog() <> DialogResult.Cancel Then
            Dim strFileToSave As String = objSfd.SelectedPath
            Dim objFileStream As New FileStream(strFileToSave & "\" & TxtAttach5.Text, FileMode.Create, FileAccess.Write)
            objFileStream.Write(objData, 0, objData.Length)
            objFileStream.Close()
        End If
        objSfd.Dispose()
    End Sub

    Private Sub ImsButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton6.Click, PrintToolStripMenuItem.CheckedChanged
        If TxtDocList.Text.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT * ,(select TOP 1  imagedata from images where BCODE=N'VEH' + VHName) as Image  FROM vehicle WHERE vhname=N'" & OpenedVhName & "'", cnn)
        dscmd.Fill(ds, "vehicle")
        cnn.Close()
        Dim objRpt As New VehicleFullDetailsCRReport

        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "VEHICLE REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "VEHICLE REPORT"
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

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        If TxtDocList.Text.Length = 0 Then Exit Sub
        Dim STR As String = ""
        If MsgBox("Do You want to Print Active and  InActive Vehicles Also ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            STR = "SELECT * ,(select TOP 1  imagedata from images where BCODE=N'VEH' + VHName) as Image FROM vehicle WHERE ISDELETE=0"
        Else
            STR = "SELECT *,(select TOP 1  imagedata from images where BCODE=N'VEH' + VHName) as Image FROM vehicle WHERE ISDELETE=0 and isactive=1"
        End If
        Me.Cursor = Cursors.WaitCursor


        Dim ds As New DataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(STR, cnn)
        dscmd.Fill(ds, "vehicle")
        cnn.Close()
        Dim objRpt As New VehicleFullDetailsCRReport

        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "VEHICLE REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "VEHICLE REPORT"
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

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub
End Class
