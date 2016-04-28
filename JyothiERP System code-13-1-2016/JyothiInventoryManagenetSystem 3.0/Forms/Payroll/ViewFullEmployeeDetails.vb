Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class ViewFullEmployeeDetails

    Dim IsOpenForAlter As Boolean = False
    Dim EMpNametobeAlter As String = ""
    Dim Photoname As String = ""
    Sub New(Optional ByVal EmpName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If EmpName.Length > 0 Then
            IsOpenForAlter = True
            EMpNametobeAlter = EmpName
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadIDData()

        TxtIDList.Columns.Clear()
        Dim Sqlstr As String = "SELECT [ID] ,[EmpID] ,[IDName],[IDType],[Description],[Expiry],[Photo1],[Photo2],[Photo3]  FROM [dbo].[EmpIds]   WHERE EMPID=N'" & TxtEmpID.Text & "'"
        Dim TempBS As New BindingSource
        With Me.TxtIDList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try


            TxtIDList.Columns("EmpID").Visible = False

            CType(TxtIDList.Columns("Photo1"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
            CType(TxtIDList.Columns("Photo2"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
            CType(TxtIDList.Columns("Photo3"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
        Catch ex As Exception

        End Try
       
        Loadattachments()
    End Sub
    Sub loadDefaults()
        ' TxtEmpID.Text = GetIDCode(EnumIDType.EmployeeID)
        ' TxtPersonalID.Text = GetIDCode(EnumIDType.EmployeePErID)
        LoadDataIntoComboBox("SELECT DISTINCT Designation FROM EMPLOYEES", TxtDesignation, "Designation")
        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartment, "DepName")
        LoadDataIntoComboBox("SELECT DISTINCT Nationality FROM EMPLOYEES", txtNationality, "Nationality")
        'LoadDataIntoComboBox("SELECT DISTINCT Contracttype FROM EMPLOYEES", TxtContractType, "Contracttype")

        TxtEmpName.Text = ""
        TxtBackAcno.Text = ""
        TxtBankAcNumber.Text = ""
        TxtBankCode.Text = ""
        TxtBankName.Text = ""
        TxtBranch.Text = ""
        TxtContractType.Text = ""
        TxtDepartment.Text = ""
        TxtDesignation.Text = ""
        TxtDOB.Text = Today.Date.AddYears(-18)
        TxtDOJ.Text = Today.Date
        TxtEducation.Text = ""
        TxtEmirateExpiry.Value = Today.Date
        TxtEmiratesId.Text = ""
        TxtEmiratesIssedby.Text = ""
        TxtContactExpiry.Value = Today.Date
        TxtGender.Text = "Male"
        TxtIFSC.Text = ""
        TxtLabourExpiry.Value = Today
        TxtLabourID.Text = ""
        TxtLabourIssedby.Text = ""
        TxtMedicalExpiry.Value = Today
        TxtmedicalID.Text = ""
        TxtMedicalIssuedBy.Text = ""
        TxtMICR.Text = ""
        txtNationality.Text = ""
        Txtno2.Text = ""
        TxtPaddress.Text = ""
        TxtPassportExpiry.Value = Today
        TxtPassportID.Text = ""
        TxtpassportIssuedby.Text = ""
        TxtPcity.Text = ""
        TxtPEmailid.Text = ""

        TxtPno1.Text = ""
        TxtRAddress.Text = ""
        TxtRcity.Text = ""
        TxtRnumber.Text = ""
        TxtRemailid.Text = ""
        TxtSalary.Text = "0"
        TxtSalaryType.Text = ""
        TxtVisaExpiry.Value = Today
        txtVisaID.Text = ""
        TxtVisaIssuedby.Text = ""
       

      
    End Sub
    Sub LoadEmpData()
        loadDefaults()
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = "select * from employees where EmpName=N'" & EMpNametobeAlter & "'"
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                TxtEmpID.Text = Sreader("EmpID")
                TxtEmpName.Text = Sreader("EmpName")
                TxtGender.Text = Sreader("Gender")
                TxtDOB.Value = Sreader("DateofBirth")
                txtNationality.Text = Sreader("Nationality")
                TxtEducation.Text = Sreader("Education")
                TxtDOJ.Value = Sreader("DateofJoining")
                TxtDesignation.Text = Sreader("Designation")
                TxtDepartment.Text = Sreader("DepName")
                TxtContractType.Text = Sreader("Contracttype")
                TxtContactExpiry.Value = Sreader("contractexpirydate")
                TxtRAddress.Text = Sreader("address")
                TxtPno1.Text = Sreader("contactno")
                TxtRemailid.Text = Sreader("emailid")
                TxtPaddress.Text = Sreader("Paddress")
                TxtPno1.Text = Sreader("pcontactno1")
                TxtPEmailid.Text = Sreader("pemailid")
                Photoname = Sreader("photopath")

                Try
                    TxtPic.BackgroundImage = GetImageFromDatabase("ImageData", "SELECT TOP 1  IMAGEDATA FROM IMAGES where BCODE=N'EMP" & TxtEmpID.Text & "'")
                Catch ex As Exception

                End Try
                TxtPersonalID.Text = Sreader("EmpPersonalID")
                TxtBankCode.Text = Sreader("bankcode")
                TxtBackAcno.Text = Sreader("bankacno")
                TxtSalary.Text = Sreader("fixedsalary")
                TxtBankAcNumber.Text = Sreader("empbankacno")
                TxtBankName.Text = Sreader("empbankname")
                TxtBranch.Text = Sreader("empbankbranch")
                TxtPassportID.Text = Sreader("passportIDNo")
                TxtpassportIssuedby.Text = Sreader("passportIDissuedby")
                TxtPassportExpiry.Value = Sreader("passportexpire")
                txtVisaID.Text = Sreader("visaIDNo")
                TxtVisaIssuedby.Text = Sreader("visaIDissuedby")
                TxtVisaExpiry.Value = Sreader("visaexpire")
                TxtEmiratesId.Text = Sreader("EmiratesDNo")
                TxtEmiratesIssedby.Text = Sreader("Emiratesissuedby")
                TxtEmirateExpiry.Value = Sreader("Emiratesexpire")
                TxtLabourID.Text = Sreader("LabourcardDNo")
                TxtLabourIssedby.Text = Sreader("Labourcardissuedby")
                TxtLabourExpiry.Value = Sreader("Labourcardexpire")
                TxtmedicalID.Text = Sreader("MedicalDNo")
                TxtMedicalIssuedBy.Text = Sreader("Medicalissuedby")
                TxtMedicalExpiry.Value = Sreader("Medicalexpire")
                TxtSalaryType.Text = Sreader("SalaryType")
                TxtRcity.Text = Sreader("EmpCity")
                TxtPcity.Text = Sreader("PEmpCity")
                TxtIFSC.Text = Sreader("bankifsccode")
                TxtMICR.Text = Sreader("bankmicrcode")
                TxtBasicSalary.Text = Sreader("basicsalary")
                TxtAllowance.Text = Sreader("allowance")
                

                Try
                    TxtCostCotegory.Text = Sreader("CostCat").ToString
                Catch ex As Exception

                End Try
            End While
            Sreader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn = Nothing
            Sqlcmmd.Connection = Nothing

        End Try
        LoadIDData()
        LoadAdditionalData()
    End Sub
    Sub LoadAdditionalData()
        Dim dt As New DataTable
        dt = SQLLoadGridData("select * from EmpAdditionalInfo where empid='" & TxtEmpID.Text & "'")
        TxtAddList.Rows.Clear()
        If dt.Rows.Count > 0 Then
            Dim rno As Integer = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                rno = TxtAddList.Rows.Add
                TxtAddList.Item(0, rno).Value = dt.Rows(i).Item("id")
                TxtAddList.Item(1, rno).Value = dt.Rows(i).Item("Additional_name")
                TxtAddList.Item(2, rno).Value = dt.Rows(i).Item("Additional_description")
                TxtAddList.Item(3, rno).Value = 0
            Next
        End If
    End Sub
    Private Sub ViewFullEmployeeDetails_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CreateEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadDefaults()
        LoadDataIntoComboBox("select empname from employees where isdelete=0", TxtDocList, "Empname")
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = 0
        End If

    End Sub

   

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If MsgBox("Do you want to close?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtDepartment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDepartment.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim CATFRM As New CreateNewDepartment
            CATFRM.ShowDialog()
            LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartment, "DepName")
        End If
    End Sub


   

    Private Sub TxtDocList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDocList.SelectedIndexChanged
        EMpNametobeAlter = TxtDocList.Text
        LoadEmpData()
    End Sub

    Private Sub ImsButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton4.Click
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = TxtDocList.Items.Count - 1
        End If
    End Sub

    Private Sub ImsButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton6.Click
        If TxtDocList.Items.Count > 0 Then
            If TxtDocList.SelectedIndex < TxtDocList.Items.Count - 1 Then
                TxtDocList.SelectedIndex = TxtDocList.SelectedIndex + 1
            End If

        End If
    End Sub

    Private Sub ImsButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton5.Click
        If TxtDocList.Items.Count > 0 Then
            If TxtDocList.SelectedIndex > 0 Then
                TxtDocList.SelectedIndex = TxtDocList.SelectedIndex - 1
            End If

        End If
    End Sub

    Private Sub ImsButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton7.Click
        If TxtDocList.Items.Count > 0 Then
            TxtDocList.SelectedIndex = 0
        End If
    End Sub

    
Private Sub ImsButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton8.Click
        If TxtDocList.Text.Length = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New employeeDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter("SELECT *, (SELECT TOP 1  IMAGEDATA FROM IMAGES where BCODE=N'EMP'+employees.empid) as Image FROM employees WHERE empname=N'" & EMpNametobeAlter & "'", cnn)
        dscmd.Fill(ds, "employees")
        'For i As Integer = 0 To ds.Tables("Employees").Rows.Count - 1
        '    Dim R As DataRow = ds.Tables("Images").NewRow
        '    R("EmpID") = ds.Tables("employees").Rows(i).Item("empid").ToString
        '    R("ImageFile") = GetImageFromDatabase("imagedata", "Select * from images where BCODE=N'EMP" & ds.Tables("employees").Rows(i).Item("empid").ToString & "'")
        '    ds.Tables("Images").Rows.Add(R)
        'Next
        cnn.Close()
        Dim objRpt As New EmployeeFullDetailsCRReport

        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEES  REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEES  REPORT"
        End If
        ' CType(objRpt.Section2.ReportObjects.Item("Picture4"), CrystalDecisions.CrystalReports.Engine.PictureObject).Dispose()
        'Picture4
        objRpt.SetDataSource(ds)
        Dim FRM As New ReportCommonForm(objRpt)
        FRM.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cursor = Cursors.Default
        FRM.ShowDialog()
        FRM.Dispose()
        objRpt.Dispose()
        ds.Dispose()
    End Sub

    Private Sub ImsButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton9.Click
        If TxtDocList.Text.Length = 0 Then Exit Sub
        Dim STR As String = ""
        If MsgBox("Do You want to Print Active and  InActive employees Also ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            STR = "SELECT *, (SELECT TOP 1  IMAGEDATA FROM IMAGES where BCODE=N'EMP'+employees.empid) as Image FROM employees WHERE ISDELETE=0"
        Else
            STR = "SELECT * , (SELECT TOP 1  IMAGEDATA FROM IMAGES where BCODE=N'EMP'+employees.empid) as Image FROM employees WHERE ISDELETE=0 and isactive=1"
        End If
        Me.Cursor = Cursors.WaitCursor
       

        Dim ds As New employeeDataSet
        Dim cnn As SqlConnection
        cnn = New SqlConnection(ConnectionStrinG)
        cnn.Open()
        Dim dscmd As New SqlDataAdapter(STR, cnn)
        dscmd.Fill(ds, "employees")
      
        cnn.Close()
        Dim objRpt As New EmployeeFullDetailsCRReport

        SetReportLogos(objRpt.Section2.ReportObjects, objRpt.DataDefinition, "txthead", "txtsubhead", "txttitle")
        If PrintOptionsforCR.IsPrintHeader = False Then
            CType(objRpt.Section2.ReportObjects.Item("txthead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.CompanyName)
            CType(objRpt.Section2.ReportObjects.Item("txtsubhead"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = UCase(CompDetails.Companystreet & ", " & CompDetails.Companystate)
            CType(objRpt.Section2.ReportObjects.Item("txttitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEES  REPORT"
        Else
            CType(objRpt.Section2.ReportObjects.Item("TxtPeriod"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "EMPLOYEES  REPORT"
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


    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        If TxtAttcList.Rows.Count = 0 Then Exit Sub
        Dim objData As Byte()
        objData = DirectCast(SQLLoadGridData("select DocAttach from EmpDocAttachments where Id=" & TxtAttcList.Item("ID", TxtAttcList.CurrentRow.Index).Value).Rows(0).Item(0), Byte())
        Dim objSfd As New FolderBrowserDialog
        If objSfd.ShowDialog() <> DialogResult.Cancel Then
            Dim strFileToSave As String = objSfd.SelectedPath
            Dim objFileStream As New FileStream(strFileToSave & "\" & TxtAttcList.Item("DocAttachFileName", TxtAttcList.CurrentRow.Index).Value, FileMode.Create, FileAccess.Write)
            objFileStream.Write(objData, 0, objData.Length)
            objFileStream.Close()
        End If
    End Sub

  
    Private Sub BtnRemove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove1.Click
        If TxtAttcList.Rows.Count = 0 Then Exit Sub
        Try
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()
            Dim ExtName As String = ""
            Dim objData As Byte()
            Dim pos As Integer = 0
            objData = DirectCast(SQLLoadGridData("select DocAttach from EmpDocAttachments where Id=" & TxtAttcList.Item("ID", TxtAttcList.CurrentRow.Index).Value).Rows(0).Item(0), Byte())
            Dim txtattach1 As New TextBox
            txtattach1.Text = TxtAttcList.Item("DocAttachFileName", TxtAttcList.CurrentRow.Index).Value
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


    Private Sub TxtIDList_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtIDList.CellClick


    End Sub

    Private Sub TxtIDList_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtIDList.CellDoubleClick
        If e.ColumnIndex = TxtIDList.Columns("photo1").Index Or e.ColumnIndex = TxtIDList.Columns("photo2").Index Or e.ColumnIndex = TxtIDList.Columns("photo3").Index Then
            Try
                Dim sTempFileName As String = System.IO.Path.GetTempFileName()

                Dim objData As Byte()


                If e.ColumnIndex = TxtIDList.Columns("photo1").Index Then
                    objData = DirectCast(SQLLoadGridData("select photo1 from empids where id=" & TxtIDList.Item("id", e.RowIndex).Value).Rows(0).Item(0), Byte())
                ElseIf e.ColumnIndex = TxtIDList.Columns("photo2").Index Then
                    objData = DirectCast(SQLLoadGridData("select photo2 from empids where id=" & TxtIDList.Item("id", e.RowIndex).Value).Rows(0).Item(0), Byte())
                ElseIf e.ColumnIndex = TxtIDList.Columns("photo3").Index Then
                    objData = DirectCast(SQLLoadGridData("select photo3 from empids where id=" & TxtIDList.Item("id", e.RowIndex).Value).Rows(0).Item(0), Byte())
                End If

                sTempFileName = sTempFileName & ".jpg"
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
        End If
       
        
    End Sub

    Sub Loadattachments()

        Dim Sqlstr As String = "SELECT ID,[DocAttach],[DocAttachFileName],[DateofAttachment] from EmpDocAttachments where EmpID='" & TxtEmpID.Text & "'"
        Dim TempBS As New BindingSource
        With Me.TxtAttcList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        Try
            TxtAttcList.Columns("ID").Visible = False
            Dim column As DataGridViewImageColumn = TxtAttcList.Columns("docattach")
            column.ImageLayout = DataGridViewImageCellLayout.Stretch


        Catch ex As Exception

        End Try
    End Sub
    Private Sub TxtIDList_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtIDList.DataError

    End Sub

    Private Sub TabPage4_Click(sender As System.Object, e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub TxtAttcList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtAttcList.CellContentClick

    End Sub

    Private Sub TxtAttcList_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtAttcList.DataError

    End Sub
End Class
