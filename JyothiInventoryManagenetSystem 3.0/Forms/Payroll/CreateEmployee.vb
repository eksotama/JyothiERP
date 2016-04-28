Imports System.Windows.Forms
Imports System.IO

Public Class CreateEmployee
    Dim IsOpenForAlter As Boolean = False
    Dim EMpNametobeAlter As String = ""
    Dim Photoname As String = ""
    Dim iSpHOTOiSsELECTED As Boolean = False
    Dim IsImagechanged As Boolean = False
    Dim IsIDEdit As Boolean = False
    Dim imageData1 As Byte()
    Dim imageData2 As Byte()
    Dim imageData3 As Byte()
    Dim OpenIDForIDcard As Long = 0
    Sub New(Optional ByVal EmpName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If EmpName.Length > 0 Then
            IsOpenForAlter = True
            EMpNametobeAlter = EmpName
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadIDDefaluts()
        TxtIDDesc.Text = ""
        TxtIDExpiry.Value = Now
        TxtIDIssuedBy.Text = ""
        TxtIDName.Text = ""
        TxtIDType.Text = ""
        PictureBox1.Image = My.Resources.NOPIC
        PictureBox2.Image = My.Resources.NOPIC
        PictureBox3.Image = My.Resources.NOPIC
        IsIDEdit = False
        BtnCancel.Visible = False
        BtnAddDoc.Text = "Add"
        LoadDataIntoComboBox("select distinct IDtype from empids", TxtIDType, "IDtype")
    End Sub
    Sub loadDefaults()
        TxtEmpID.Text = GetIDCode(EnumIDType.EmployeeID)
        ExecuteSQLQuery("delete from EmpDocAttachments where empid='" & TxtEmpID.Text & "'")
        ExecuteSQLQuery("delete from EmpIds where empid=N'" & TxtEmpID.Text & "'")
        TxtPersonalID.Text = GetIDCode(EnumIDType.EmployeePErID)
        LoadDataIntoComboBox("SELECT DISTINCT Designation FROM EMPLOYEES", TxtDesignation, "Designation")
        LoadDataIntoComboBox("SELECT DISTINCT TeamName FROM EMPLOYEES", TxtteamName, "TeamName")
        LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartment, "DepName")
        LoadDataIntoComboBox("SELECT DISTINCT Nationality FROM EMPLOYEES", txtNationality, "Nationality")
        LoadDataIntoComboBox("select StockgroupName from CostCenters ", TxtCostCotegory, "StockgroupName")
        LoadDataIntoComboBox("select DISTINCT IDtype from EmpIds ", TxtIDType, "IDtype")
        '
        TxtAddList.Rows.Clear()
        If TxtCostCotegory.Items.Count > 0 Then
            TxtCostCotegory.SelectedIndex = 0
        End If
        ' LoadDataIntoComboBox("SELECT DISTINCT Contracttype FROM EMPLOYEES", TxtContractType, "Contracttype")
        IsImagechanged = False
        TxtPic.SizeMode = PictureBoxSizeMode.StretchImage
        TxtPic.Image = My.Resources.NOPIC
        TxtEmpName.Text = ""
        TxtBackAcno.Text = ""
        TxtNotifyDays.Text = "30"
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
        TxtAirTicketDays.Text = "0"
        TxtLeaveSalaryDays.Text = "0"
        TxtPno1.Text = ""
        TxtRAddress.Text = ""
        TxtRcity.Text = ""
        TxtRnumber.Text = ""
        TxtRemailid.Text = ""

        TxtSalaryType.Text = ""
        TxtVisaExpiry.Value = Today
        txtVisaID.Text = ""
        TxtVisaIssuedby.Text = ""
      
        txtAirDueFrom.Value = Today
        TxtLeaveDueFrom.Value = Today
        TxtAttach1.Text = ""
       
        TxtLeaveSalaryDays.Text = "0"
        TxtAirTicketDays.Text = "0"
        txtAirDueFrom.Value = Today
        TxtLeaveDueFrom.Value = Today
        LoadIDDefaluts()
        LoadIDData()
    End Sub
    Sub LoadEmpData()
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
                TxtRnumber.Text = Sreader("contactno")
                TxtRemailid.Text = Sreader("emailid")
                TxtPaddress.Text = Sreader("Paddress")
                TxtPno1.Text = Sreader("pcontactno1")
                TxtPEmailid.Text = Sreader("pemailid")
                Photoname = ""
                Try

                    TxtPic.Image = GetImageFromDatabase("ImageData", "SELECT TOP 1  IMAGEDATA FROM IMAGES where BCODE=N'EMP" & TxtEmpID.Text & "'")
                Catch ex As Exception

                End Try
                IsImagechanged = False
                TxtPersonalID.Text = Sreader("EmpPersonalID")
                TxtBankCode.Text = Sreader("bankcode")
                TxtBackAcno.Text = Sreader("bankacno")
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
                TxtHourRate.Text = Sreader("rateperhour")
                TxtteamName.Text = Sreader("TeamName")
               

               
                Try
                    TxtCostCotegory.Text = Sreader("CostCat").ToString
                Catch ex As Exception

                End Try
                TxtLeaveDueFrom.Value = Date.FromOADate(Sreader("leavesalaryfrom"))
                txtAirDueFrom.Value = Date.FromOADate(Sreader("airticketfrom"))
                TxtLeaveSalaryDays.Text = Sreader("leavesalaryduedays")
                TxtAirTicketDays.Text = Sreader("airticketduedays")
                TxtNotifyDays.Text = Sreader("NotifyDays")
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
        Loadattachments()
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
    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If TxtEmpName.Text.Length < 3 Then
            MsgBox("Please Enter the Employee Name.. ", MsgBoxStyle.Information)
            TabControl1.SelectedIndex = 0
            TxtEmpName.Focus()
            Exit Sub
        End If
        If TxtGender.Text.Length = 0 Then
            MsgBox("Please Select the Gender of the Employee.. ", MsgBoxStyle.Information)
            TxtGender.Focus()
            TabControl1.SelectedIndex = 0
            Exit Sub
        End If
        If TxtCostCotegory.Text.Length = 0 Then
            MsgBox("Please Select the Cost Cotegory Name...... ", MsgBoxStyle.Information)
            TabControl1.SelectedIndex = 0
            TxtCostCotegory.Focus()
            Exit Sub
        End If
        If CDbl(TxtBasicSalary.Text) < 1 Then
            MsgBox("Please Enter the Fixed Salary Amount....", MsgBoxStyle.Information)
            TabControl1.SelectedIndex = 1
            TxtBasicSalary.Focus()
            Exit Sub
        End If
        If TxtLeaveSalaryDays.Text.Length = 0 Then
            TxtLeaveSalaryDays.Text = "0"
        End If
        If TxtAirTicketDays.Text.Length = 0 Then
            TxtAirTicketDays.Text = "0"
        End If
        'If CDbl(TxtSalary.Text) < 1 Then
        '    MsgBox("Please Enter the Fixed Salary Amount....", MsgBoxStyle.Information)
        '    TabControl1.SelectedIndex = 1
        '    TxtSalary.Focus()
        '    Exit Sub
        'End If
        If TxtDepartment.Text.Length = 0 Then
            MsgBox("Please Select the Department, To create new, Press Alt+C", MsgBoxStyle.Information)
            TabControl1.SelectedIndex = 0
            TxtDepartment.Focus()
            Exit Sub
        End If
        If TxtContractType.Text.Length = 0 Then
            MsgBox("Please Select The Contract Type....        ", MsgBoxStyle.Information)
            TxtContractType.Focus()
            Exit Sub
        End If
        If IsOpenForAlter = True Then
            If UCase(TxtEmpName.Text) <> UCase(EMpNametobeAlter) Then
                If UCase(Replace(TxtEmpName.Text, " ", "")) <> UCase(Replace(EMpNametobeAlter, " ", "")) Then
                    If SQLIsFieldExists("Select EmpName from employees where EmpName=N'" & TxtEmpName.Text & "'") = True Then
                        MsgBox("The Employee Name already exists, Please try again....", MsgBoxStyle.Critical)
                        TxtEmpName.Focus()
                        Exit Sub
                    End If
                    If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & TxtEmpName.Text & "'") = True Then
                        MsgBox("The Employee Name is already exists, Please try again....", MsgBoxStyle.Critical)
                        TxtEmpName.Focus()
                        Exit Sub
                    End If
                    If Application.OpenForms.Count > 3 Then
                        MsgBox("Please Close all Forms and try again.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If

            End If
            If IsthereanyUsersLogin() > 0 Then
                MsgBox("Currently some users are logged In, Rename is not recommended..... ", MsgBoxStyle.Critical)
                Exit Sub
            End If
           
        Else
            If SQLIsFieldExists("Select EmpName from employees where EmpName=N'" & TxtEmpName.Text & "'") = True Then
                MsgBox("The Employee Name already exists, Please try again....", MsgBoxStyle.Critical)
                TxtEmpName.Focus()
                Exit Sub
            ElseIf SQLIsFieldExists("Select EmpName from employees where EmpName=N'" & Replace(TxtEmpName.Text, " ", "") & "'") = True Then
                MsgBox("The Employee Name already exists, Please try again....", MsgBoxStyle.Critical)
                TxtEmpName.Focus()
                Exit Sub
            End If
            If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & TxtEmpName.Text & "'") = True Then
                MsgBox("The Employee Name already exists, Please try again....", MsgBoxStyle.Critical)
                TxtEmpName.Focus()
                Exit Sub
            End If
        End If
        If IsOpenForAlter = True Then
            If MsgBox("Do you want to Alter?   ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim SQLstr As String = ""
            SQLstr = "UPDATE Employees SET  EmpID=@EmpID,EmpName=@EmpName,Gender=@Gender,DateofBirth=@DateofBirth,Nationality=@Nationality,Education=@Education,DateofJoining=@DateofJoining,Designation=@Designation,DepName=@DepName," _
          & " Contracttype=@Contracttype,contractexpirydate=@contractexpirydate,address=@address,contactno=@contactno,emailid=@emailid,Paddress=@Paddress,pcontactno1=@pcontactno1,pcontactno2=@pcontactno2,pemailid=@pemailid,photopath=@photopath,EmpPersonalID=@EmpPersonalID," _
          & " bankcode=@bankcode,bankacno=@bankacno,fixedsalary=@fixedsalary,empbankacno=@empbankacno,empbankname=@empbankname,empbankbranch=@empbankbranch,passportIDNo=@passportIDNo,passportIDissuedby=@passportIDissuedby,passportexpire=@passportexpire,visaIDNo=@visaIDNo," _
          & " visaIDissuedby=@visaIDissuedby,visaexpire=@visaexpire,EmiratesDNo=@EmiratesDNo,Emiratesissuedby=@Emiratesissuedby,Emiratesexpire=@Emiratesexpire,LabourcardDNo=@LabourcardDNo,Labourcardissuedby=@Labourcardissuedby,Labourcardexpire=@Labourcardexpire,MedicalDNo=@MedicalDNo," _
          & "Medicalissuedby=@Medicalissuedby,Medicalexpire=@Medicalexpire,SalaryType=@SalaryType,EmpCity=@EmpCity,PEmpCity=@PEmpCity,bankifsccode=@bankifsccode,bankmicrcode=@bankmicrcode,Isactive=@Isactive,IsDelete=@IsDelete, " _
          & " basicsalary=@basicsalary,allowance=@allowance,CostCat=@CostCat,rateperhour=@rateperhour,TeamName=@TeamName,leavesalaryduedays=@leavesalaryduedays,airticketduedays=@airticketduedays,airticketfrom=@airticketfrom,leavesalaryfrom=@leavesalaryfrom,NotifyDays=@NotifyDays  WHERE  empname=N'" & EMpNametobeAlter & "'"
            SaveData(SQLstr)

            If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & EMpNametobeAlter & "'") = False Then
                If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & Replace(EMpNametobeAlter, " ", "") & "'") = False Then

                    SQLstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                      & "VALUES(N'" & TxtEmpName.Text & "',N'" & TxtCostCotegory.Text & "',0,'Employee')"
                    ExecuteSQLQuery(SQLstr)
                End If

            End If
            'UPDATES NAMES
            ExecuteSQLQuery("EXEC UPDATEEMPLOYEESNAMES N'" & TxtEmpName.Text & "',N'" & EMpNametobeAlter & "'")
          
            Me.Close()
        Else
            If MsgBox("Do you want to Create?   ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            TxtEmpID.Text = GetAndSetIDCode(EnumIDType.EmployeeID)
            GetIDCode(EnumIDType.EmployeePErID)
            Dim SQLstr As String = ""

            SQLstr = "INSERT INTO [Employees]([EmpID],[EmpName],[Gender],[DateofBirth],[Nationality],[Education],[DateofJoining],[Designation],[DepName]," _
                & " [Contracttype],[contractexpirydate],[address],[contactno],[emailid],[Paddress],[pcontactno1],[pcontactno2],[pemailid],[photopath],[EmpPersonalID]," _
                & " [bankcode],[bankacno],[fixedsalary],[empbankacno],[empbankname],[empbankbranch],[passportIDNo],[passportIDissuedby],[passportexpire],[visaIDNo]," _
                & " [visaIDissuedby],[visaexpire],[EmiratesDNo],[Emiratesissuedby],[Emiratesexpire],[LabourcardDNo],[Labourcardissuedby],[Labourcardexpire],[MedicalDNo]," _
                & "[Medicalissuedby],[Medicalexpire],[SalaryType],[EmpCity],[PEmpCity],[bankifsccode],[bankmicrcode],[Isactive],[IsDelete],[basicsalary],[allowance],[CostCat],[rateperhour],[TeamName],[leavesalaryduedays],[airticketduedays],[airticketfrom],[leavesalaryfrom],[NotifyDays]) " _
                & " VALUES (@EmpID,@EmpName,@Gender,@DateofBirth,@Nationality,@Education,@DateofJoining,@Designation,@DepName,@Contracttype,@contractexpirydate," _
                & "@address,@contactno,@emailid,@Paddress,@pcontactno1,@pcontactno2,@pemailid,@photopath,@EmpPersonalID,@bankcode,@bankacno,@fixedsalary,@empbankacno," _
                & "@empbankname,@empbankbranch,@passportIDNo,@passportIDissuedby,@passportexpire,@visaIDNo,@visaIDissuedby,@visaexpire,@EmiratesDNo,@Emiratesissuedby," _
                & " @Emiratesexpire,@LabourcardDNo,@Labourcardissuedby,@Labourcardexpire,@MedicalDNo,@Medicalissuedby,@Medicalexpire,@SalaryType,@EmpCity,@PEmpCity,@bankifsccode," _
                & " @bankmicrcode,@Isactive,@IsDelete,@basicsalary,@allowance,@CostCat,@rateperhour,@TeamName,@leavesalaryduedays,@airticketduedays,@airticketfrom,@leavesalaryfrom,@NotifyDays)"
            SaveData(SQLstr)

            SQLstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
              & "VALUES(N'" & TxtEmpName.Text & "',N'" & TxtCostCotegory.Text & "',0,'Employee')"
            ExecuteSQLQuery(SQLstr)


            TabControl1.SelectedIndex = 0
            TxtEmpName.Focus()
        End If
        loadDefaults()

    End Sub
    Sub SaveData(Sqlstr As String)

        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("EmpID", TxtEmpID.Text)
            .AddWithValue("EmpName", TxtEmpName.Text)
            .AddWithValue("Gender", TxtGender.Text)
            .AddWithValue("DateofBirth", TxtDOB.Value.Date)
            .AddWithValue("Nationality", txtNationality.Text)
            .AddWithValue("Education", TxtEducation.Text)
            .AddWithValue("DateofJoining", TxtDOJ.Value.Date)
            .AddWithValue("Designation", TxtDesignation.Text)
            .AddWithValue("DepName", TxtDepartment.Text)
            .AddWithValue("Contracttype", TxtContractType.Text)
            .AddWithValue("contractexpirydate", TxtContactExpiry.Value.Date)
            .AddWithValue("address", TxtRAddress.Text)
            .AddWithValue("contactno", TxtRnumber.Text)
            .AddWithValue("emailid", TxtRemailid.Text)
            .AddWithValue("Paddress", TxtPaddress.Text)
            .AddWithValue("pcontactno1", TxtPno1.Text)
            .AddWithValue("pcontactno2", "")
            .AddWithValue("pemailid", TxtPEmailid.Text)
            .AddWithValue("photopath", PhotoPathForLedgers & "\" & TxtEmpID.Text & ".jpg")
            .AddWithValue("EmpPersonalID", TxtPersonalID.Text)
            .AddWithValue("bankcode", TxtBankCode.Text)
            .AddWithValue("bankacno", TxtBackAcno.Text)
            .AddWithValue("fixedsalary", 0)
            .AddWithValue("empbankacno", TxtBankAcNumber.Text)
            .AddWithValue("empbankname", TxtBankName.Text)
            .AddWithValue("empbankbranch", TxtBranch.Text)
            .AddWithValue("passportIDNo", TxtPassportID.Text)
            .AddWithValue("passportIDissuedby", TxtpassportIssuedby.Text)
            .AddWithValue("passportexpire", TxtPassportExpiry.Value.Date)
            .AddWithValue("visaIDNo", txtVisaID.Text)
            .AddWithValue("visaIDissuedby", TxtVisaIssuedby.Text)
            .AddWithValue("visaexpire", TxtVisaExpiry.Value.Date)
            .AddWithValue("EmiratesDNo", TxtEmiratesId.Text)
            .AddWithValue("Emiratesissuedby", TxtEmiratesIssedby.Text)
            .AddWithValue("Emiratesexpire", TxtEmirateExpiry.Value.Date)
            .AddWithValue("LabourcardDNo", TxtLabourID.Text)
            .AddWithValue("Labourcardissuedby", TxtLabourIssedby.Text)
            .AddWithValue("Labourcardexpire", TxtLabourExpiry.Value.Date)
            .AddWithValue("MedicalDNo", TxtmedicalID.Text)
            .AddWithValue("Medicalissuedby", TxtMedicalIssuedBy.Text)
            .AddWithValue("Medicalexpire", TxtMedicalExpiry.Value.Date)
            .AddWithValue("SalaryType", TxtSalaryType.Text)
            .AddWithValue("EmpCity", TxtRcity.Text)
            .AddWithValue("PEmpCity", TxtPcity.Text)
            .AddWithValue("bankifsccode", TxtIFSC.Text)
            .AddWithValue("bankmicrcode", TxtMICR.Text)
            .AddWithValue("Isactive", 1)
            .AddWithValue("IsDelete", 0)
            .AddWithValue("allowance", CDbl(TxtHourRate.Text))
            .AddWithValue("basicsalary", CDbl(TxtBasicSalary.Text))
            .AddWithValue("CostCat", TxtCostCotegory.Text)
            .AddWithValue("leavesalaryduedays", CLng(TxtLeaveSalaryDays.Text))
            .AddWithValue("airticketduedays", CLng(TxtAirTicketDays.Text))
            .AddWithValue("rateperhour", CDbl(TxtHourRate.Text))
            .AddWithValue("TeamName", TxtteamName.Text)
            .AddWithValue("leavesalaryfrom", TxtLeaveDueFrom.Value.Date.ToOADate)
            .AddWithValue("airticketfrom", txtAirDueFrom.Value.Date.ToOADate)
            .AddWithValue("NotifyDays", CLng(TxtNotifyDays.Text))
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing

        If IsOpenForAlter = True Then
            For i As Integer = 0 To TxtAddList.Rows.Count - 1
                If TxtAddList.Item(3, i).Value <> 1 Then
                    If TxtAddList.Item(0, i).Value = 0 Then
                        Dim DBF2 As New SqlClient.SqlCommand("INSERT INTO [dbo].[EmpAdditionalInfo] ([EmpID],[Additional_name],[Additional_description])     VALUES (@EmpID,@Additional_name,@Additional_description) ", MAINCON)
                        With DBF2.Parameters
                            .AddWithValue("EmpID", TxtEmpID.Text)
                            .AddWithValue("Additional_name", TxtAddList.Item(1, i).Value)
                            .AddWithValue("Additional_description", TxtAddList.Item(2, i).Value)
                        End With
                        DBF2.ExecuteNonQuery()
                        DBF2 = Nothing
                    Else
                        Dim DBF2 As New SqlClient.SqlCommand("UPDATE [EmpAdditionalInfo] SET EmpID=@EmpID,Additional_name=@Additional_name,Additional_description=@Additional_description WHERE ID=" & TxtAddList.Item(0, i).Value, MAINCON)
                        With DBF2.Parameters
                            .AddWithValue("EmpID", TxtEmpID.Text)
                            .AddWithValue("Additional_name", TxtAddList.Item(1, i).Value)
                            .AddWithValue("Additional_description", TxtAddList.Item(2, i).Value)
                        End With
                        DBF2.ExecuteNonQuery()
                        DBF2 = Nothing
                    End If
                Else
                    ExecuteSQLQuery("DELETE FROM EmpAdditionalInfo WHERE ID=" & TxtAddList.Item(0, i).Value)

                End If
            Next
        Else
            For i As Integer = 0 To TxtAddList.Rows.Count - 1
                If TxtAddList.Item(3, i).Value <> 1 Then
                    Dim DBF2 As New SqlClient.SqlCommand("INSERT INTO [dbo].[EmpAdditionalInfo] ([EmpID],[Additional_name],[Additional_description])     VALUES (@EmpID,@Additional_name,@Additional_description) ", MAINCON)
                    With DBF2.Parameters
                        .AddWithValue("EmpID", TxtEmpID.Text)
                        .AddWithValue("Additional_name", TxtAddList.Item(1, i).Value)
                        .AddWithValue("Additional_description", TxtAddList.Item(2, i).Value)
                    End With
                    DBF2.ExecuteNonQuery()
                    DBF2 = Nothing
                End If
            Next
        End If
       


        MAINCON.Close()

        

        If IsImagechanged = True Then
            If SQLIsFieldExists("SELECT TOP 1 1 from   images where BCODE=N'EMP" & TxtEmpID.Text & "'") = False Then
                If Photoname.Length > 0 Then
                    InsertImageIntoDatabase(Photoname, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", "EMP" & TxtEmpID.Text, "")
                Else
                    InsertImageIntoDatabase(TxtPic.Image, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", "EMP" & TxtEmpID.Text, "")
                End If
            Else
                If Photoname.Length > 0 Then
                    UpdateImageIntoDatabase(Photoname, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'EMP" & TxtEmpID.Text & "'", "")
                Else
                    UpdateImageIntoDatabase(TxtPic.Image, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'EMP" & TxtEmpID.Text & "'", "")
                End If
            End If
        ElseIf IsOpenForAlter = False Then
            If Photoname.Length > 0 Then
                UpdateImageIntoDatabase(Photoname, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'EMP" & TxtEmpID.Text & "'", "")
            Else
                UpdateImageIntoDatabase(TxtPic.Image, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'EMP" & TxtEmpID.Text & "'", "")
            End If
        End If





    End Sub
    Sub InsertAttachment(ByVal filename As String)

        Dim objFileStream As New FileStream(filename, FileMode.Open, FileAccess.Read)
        Dim intLength As Integer = Convert.ToInt32(objFileStream.Length)
        Dim objData As Byte()
        objData = New Byte(intLength - 1) {}
        Dim strPath As String() = filename.Split(Convert.ToChar("\"))
        objFileStream.Read(objData, 0, intLength)
        objFileStream.Close()

        Dim SqlStr As String = "INSERT INTO [dbo].[EmpDocAttachments] ([EmpID],[DocAttach],[DocAttachFileName],[DateofAttachment],[DateofModified],[DateofAccess])     VALUES (@EmpID,@DocAttach,@DocAttachFileName,@DateofAttachment,@DateofModified,@DateofAccess) "

        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("EmpID", TxtEmpID.Text)
                .AddWithValue("DocAttach", objData)
                .AddWithValue("DocAttachFileName", strPath(strPath.Length - 1))
                .AddWithValue("DateofAttachment", Now)
                .AddWithValue("DateofModified", Now)
                .AddWithValue("DateofAccess", Now)
            End With
            DBF.ExecuteNonQuery()
            DBF = Nothing
            MAINCON.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Loadattachments()
    End Sub
   
    Private Sub CreateEmployee_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub CreateEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadDefaults()
        If IsOpenForAlter = True Then
            LoadEmpData()
            BtnCreate.Text = "&Alter"
        Else

        End If

    End Sub

    Private Sub ImsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton1.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtPic.Image = Image.FromFile(sd.FileName)
            Photoname = sd.FileName
            iSpHOTOiSsELECTED = True
            IsImagechanged = True
        End If
    End Sub

    Private Sub ImsButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton2.Click
        TxtPic.Image = My.Resources.NOPIC
        Photoname = ""
        IsImagechanged = True
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If MsgBox("Do you want to close?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub TxtDepartment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDepartment.KeyDown, TxtteamName.KeyDown
        If e.Alt = True And e.KeyCode = Keys.C Then
            If APPUserRights.IsAdvanceUser = False Then Exit Sub
            Dim CATFRM As New CreateNewDepartment
            CATFRM.ShowDialog()
            LoadDataIntoComboBox("SELECT  DepName FROM DepartmentGroups", TxtDepartment, "DepName")
        End If
    End Sub


    Private Sub ImsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImsButton3.Click
        Dim k As New WebcamImage
        k.ShowDialog()
        If TempFileNames2.Length > 0 Then
            TxtPic.Image = Image.FromFile(TempFileNames2)
            Photoname = TempFileNames2
            iSpHOTOiSsELECTED = True
            IsImagechanged = True
        End If
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
   

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        LoadIDDefaluts()
        LoadIDData()
        IsIDEdit = False
    End Sub

    Private Sub BtnAddDoc_Click(sender As System.Object, e As System.EventArgs) Handles BtnAddDoc.Click
        If TxtIDType.Text.Length = 0 Then
            MsgBox("Please Enter the ID Type ..       ", MsgBoxStyle.Information)
            TxtIDType.Focus()
            Exit Sub
        End If
        If TxtIDName.Text.Length = 0 Then
            MsgBox("Please Enter the ID Name  ..       ", MsgBoxStyle.Information)
            TxtIDName.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to Add ?         ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SaveDataPhotos()
            LoadIDDefaluts()
            LoadIDData()
        End If
    End Sub
    Sub LoadIDData()

        TxtIDList.Columns.Clear()
        Dim Sqlstr As String = "SELECT [ID] ,[EmpID] ,[IDName] AS NO,[IDType],[Description],IssueDate,[Expiry],[Photo1],[Photo2],[Photo3]  FROM [dbo].[EmpIds]   WHERE EMPID=N'" & TxtEmpID.Text & "'"
        Dim TempBS As New BindingSource
        With Me.TxtIDList
            TempBS.DataSource = SQLLoadGridData(Sqlstr)
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With

        Try

            Dim dc1 As New DataGridViewButtonColumn

            dc1.HeaderText = "Edit?"
            dc1.Name = "stEDIT"
            dc1.Width = 50
            dc1.Text = "Edit"
            dc1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtIDList.Columns.Add(dc1)

            Dim dc2 As New DataGridViewButtonColumn

            dc2.HeaderText = "Delete?"
            dc2.Name = "stDELETE"
            dc1.Text = "Delete"
            dc2.Width = 50
            dc2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            TxtIDList.Columns.Add(dc2)


            TxtIDList.Columns("EmpID").Visible = False
            Try
                CType(TxtIDList.Columns("Photo1"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
                CType(TxtIDList.Columns("Photo2"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
                CType(TxtIDList.Columns("Photo3"), DataGridViewImageColumn).ImageLayout = ImageLayout.Stretch
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        For i As Integer = 0 To TxtIDList.RowCount - 1
            TxtIDList.Item("stEDIT", i).Value = "EDIT"
            TxtIDList.Item("stDelete", i).Value = "DELETE"

        Next

    End Sub
    Sub SaveDataPhotos()
        Dim ms1 As New MemoryStream()
        Dim ms2 As New MemoryStream()
        Dim ms3 As New MemoryStream()
        Dim objData1 As Byte()
        Dim objData2 As Byte()
        Dim objData3 As Byte()
        'If IsNothing(fs) = False Then
        '    System.Drawing.Image.FromStream(fs).Save(ms, System.Drawing.Image.FromStream(fs).RawFormat)
        'Else
        '    My.Resources.NOPIC.Save(ms, My.Resources.NOPIC.RawFormat)
        'End If
        Try
            PictureBox1.Image.Save(ms1, PictureBox1.Image.RawFormat)
            objData1 = ms1.GetBuffer()
        Catch ex As Exception
            objData1 = imageData1
        End Try

        Try
            PictureBox2.Image.Save(ms2, PictureBox2.Image.RawFormat)
            objData2 = ms2.GetBuffer()
        Catch ex As Exception
            objData2 = imageData2
        End Try

        Try
            PictureBox3.Image.Save(ms3, PictureBox3.Image.RawFormat)
            objData3 = ms3.GetBuffer()
        Catch ex As Exception
            objData3 = imageData3
        End Try
       
        Dim sQLsTR As String = ""
        If IsIDEdit = True Then
            sQLsTR = "UPDATE [EmpIds] SET [EmpID]=@EmpID,[IDName]=@IDName,[IDType]=@IDType,[Expiry]=@Expiry,[Photo1]=@Photo1,[Photo2]=@Photo2,[Photo3]=@Photo3,[Description]=@Description,IssueDate=@IssueDate WHERE ID=" & OpenIDForIDcard
        Else
            sQLsTR = "INSERT INTO [dbo].[EmpIds] ([EmpID],[IDName],[IDType],[Expiry],[Photo1],[Photo2],[Photo3],[Description],IssueDate)     VALUES " _
          & " (@EmpID,@IDName,@IDType,@Expiry,@Photo1,@Photo2,@Photo3,@Description,@IssueDate) "
        End If
      
        Dim MAINCON As New SqlClient.SqlConnection
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(sqlstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("EmpID", TxtEmpID.Text)
            .AddWithValue("IDName", TxtIDName.Text)
            .AddWithValue("IDType", TxtIDType.Text)
            .AddWithValue("Expiry", TxtIDExpiry.Value)
            .AddWithValue("Photo1", objData1)
            .AddWithValue("Photo2", objData2)
            .AddWithValue("Photo3", objData3)

            .AddWithValue("Description", TxtIDDesc.Text)
            .AddWithValue("IssueDate", tXTiSSUEdATE.Value)
        End With
        DBF.ExecuteNonQuery()
        DBF = Nothing
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim temp As Image = PictureBox1.Image
            PictureBox1.Image = Nothing
            temp.Dispose()
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(sd.FileName, IO.FileMode.Open, IO.FileAccess.Read)

            PictureBox1.WaitOnLoad = True
            PictureBox1.LoadAsync(sd.FileName)



        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim temp As Image = PictureBox2.Image
            PictureBox2.Image = Nothing
            temp.Dispose()
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(sd.FileName, IO.FileMode.Open, IO.FileAccess.Read)

            PictureBox2.WaitOnLoad = True
            PictureBox2.LoadAsync(sd.FileName)



        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim temp As Image = PictureBox3.Image
            PictureBox3.Image = Nothing
            temp.Dispose()
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(sd.FileName, IO.FileMode.Open, IO.FileAccess.Read)

            PictureBox3.WaitOnLoad = True
            PictureBox3.LoadAsync(sd.FileName)



        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        PictureBox1.Image = My.Resources.NOPIC

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        PictureBox2.Image = My.Resources.NOPIC
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        PictureBox3.Image = My.Resources.NOPIC
    End Sub

    Private Sub TxtIDList_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtIDList.CellClick
        If e.ColumnIndex = TxtIDList.Columns("stDelete").Index Then
            If MsgBox("Do you want to Delete Selected Entry ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM EMPIDS WHERE ID=" & TxtIDList.Item("id", e.RowIndex).Value)
                LoadIDData()
            End If

        ElseIf e.ColumnIndex = TxtIDList.Columns("stEdit").Index Then
            If MsgBox("Do you want to Edit?   ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                LoadIDDefaluts()
                Dim dt As New DataTable
                OpenIDForIDcard = TxtIDList.Item("id", e.RowIndex).Value
                dt = SQLLoadGridData("select * from empids where id=" & OpenIDForIDcard)
                If dt.Rows.Count > 0 Then
                    PictureBox1.Image = My.Resources.NOPIC
                    Try

                        imageData1 = DirectCast(dt.Rows(0).Item("photo1"), Byte())
                        If Not imageData1 Is Nothing Then
                            Using ms As New MemoryStream(imageData1, 0, imageData1.Length)
                                ms.Write(imageData1, 0, imageData1.Length)
                                PictureBox1.Image = Image.FromStream(ms, True)
                            End Using
                        End If
                    Catch ex As Exception
                    End Try

                    PictureBox2.Image = My.Resources.NOPIC
                    Try

                        imageData2 = DirectCast(dt.Rows(0).Item("photo2"), Byte())
                        If Not imageData2 Is Nothing Then
                            Using ms As New MemoryStream(imageData2, 0, imageData2.Length)
                                ms.Write(imageData2, 0, imageData2.Length)
                                PictureBox2.Image = Image.FromStream(ms, True)
                            End Using
                        End If
                    Catch ex As Exception
                    End Try

                    PictureBox3.Image = My.Resources.NOPIC
                    Try

                        imageData3 = DirectCast(dt.Rows(0).Item("photo3"), Byte())
                        If Not imageData3 Is Nothing Then
                            Using ms As New MemoryStream(imageData3, 0, imageData3.Length)
                                ms.Write(imageData3, 0, imageData3.Length)
                                PictureBox3.Image = Image.FromStream(ms, True)
                            End Using
                        End If
                    Catch ex As Exception
                    End Try

                    TxtIDName.Text = dt.Rows(0).Item("IDName").ToString
                    TxtIDType.Text = dt.Rows(0).Item("IDType").ToString
                    TxtIDExpiry.Value = dt.Rows(0).Item("Expiry")
                    TxtIDDesc.Text = dt.Rows(0).Item("Description").ToString
                    tXTiSSUEdATE.Value = dt.Rows(0).Item("IssueDate")
                    IsIDEdit = True
                    BtnCancel.Visible = True
                    BtnAddDoc.Text = "Alter"
                End If

            End If
        End If
    End Sub

    Private Sub TxtIDList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtIDList.CellContentClick

    End Sub

    Private Sub TxtIDList_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtIDList.DataError

    End Sub

    Private Sub ImsNumericTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles ImsNumericTextBox1.TextChanged
        TxtNotifyDays.Text = ImsNumericTextBox1.Text
    End Sub

    Private Sub btnaddadd_Click(sender As System.Object, e As System.EventArgs) Handles btnaddadd.Click
        Dim rno As Integer = 0
        rno = TxtAddList.Rows.Add()
        TxtAddList.Item(0, rno).Value = 0
        TxtAddList.Item(1, rno).Value = ""
        TxtAddList.Item(2, rno).Value = ""
        TxtAddList.Item(3, rno).Value = 0
    End Sub

    Private Sub BtnDeleteRow_Click(sender As System.Object, e As System.EventArgs) Handles BtnDeleteRow.Click
        If TxtAddList.Rows.Count > 0 Then
            TxtAddList.Rows(TxtAddList.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Red
            TxtAddList.Item(3, TxtAddList.CurrentRow.Index).Value = 1
        End If
    End Sub

    Private Sub btnattadd_Click(sender As System.Object, e As System.EventArgs) Handles btnattadd.Click
        If TxtAttach1.Text.Length = 0 Then
            MsgBox("Please select the file to upload.... ", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Do You want to Add new Attachment ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            InsertAttachment(TxtAttach1.Text)
            TxtAttach1.Text = ""
        End If

    End Sub

    Private Sub TxtAttcList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtAttcList.CellContentClick

    End Sub

    Private Sub TxtAttcList_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtAttcList.DataError

    End Sub

    Private Sub TxtAddList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TxtAddList.CellContentClick

    End Sub

    Private Sub TxtAddList_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TxtAddList.DataError

    End Sub

    Private Sub BtnAttDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnAttDelete.Click

        If TxtAttcList.Rows.Count > 0 Then
            If TxtAttcList.SelectedRows.Count = 0 Then Exit Sub
            If MsgBox("Do you want to Delete the Selected Attachment ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ExecuteSQLQuery("delete from EmpDocAttachments where id=" & TxtAttcList.Item("ID", TxtAttcList.CurrentRow.Index).Value)
                Loadattachments()
            End If
        End If
    End Sub
End Class
