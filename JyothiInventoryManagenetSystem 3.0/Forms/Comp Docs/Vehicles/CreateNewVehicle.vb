Imports System.Windows.Forms
Imports System.IO

Public Class CreateNewVehicle
    Dim IsImagechanged As Boolean = False
    Dim Photoname As String = ""
    Dim IsOpenForAlter As Boolean = False
    Dim OpenedVhName As String
    Dim Ischeckedout As Boolean = False
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
        IsImagechanged = False
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
        TxtCostCenterCategory.Text = ""
        TxtLedgerName.Text = ""
        Photoname = ""
        TxtPic.Image = My.Resources.NOPIC
        TxtPic.SizeMode = PictureBoxSizeMode.StretchImage
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

    Private Sub BtnCam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCam.Click
        Dim k As New WebcamImage
        k.ShowDialog()
        k.Dispose()

        If TempFileNames2.Length > 0 Then
            TxtPic.Image = Image.FromFile(TempFileNames2)
            Photoname = TempFileNames2
            IsImagechanged = True
        End If
    End Sub

    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Dim sd As OpenFileDialog = New OpenFileDialog
        sd.Title = "Select Image "
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        ' sd.Filter = "Bitmap |*.bmp| JPG | *.jpg | GIF | *.gif | All Files|*.*"
        sd.FilterIndex = 1
        sd.Multiselect = False
        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then

            TxtPic.Image = Image.FromFile(sd.FileName)
            Photoname = sd.FileName
            IsImagechanged = True
        End If
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        TxtPic.Image = My.Resources.NOPIC
        Photoname = ""
        IsImagechanged = True
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtType.Text.Length < 2 Then
            MsgBox("Please Select the Type of Vehicle .... ", MsgBoxStyle.Information)
            TxtType.Focus()
            Exit Sub
        End If
        If TxtID.Text.Length = 0 Then
            MsgBox("Please Enter the Vehicle ID ....  ", MsgBoxStyle.Information)
            TxtID.Focus()
            Exit Sub
        End If
        If TxtVhName.Text.Length < 3 Then
            MsgBox("Please Enter the Name of the Vehicle ...", MsgBoxStyle.Information)
            TxtVhName.Focus()
            Exit Sub
        End If
        If TxtVhNo.Text.Length < 2 Then
            MsgBox("Please Enter the Vehicle Number...", MsgBoxStyle.Information)
            TxtVhNo.Focus()
            Exit Sub
        End If
        If TxtCostCenterCategory.Text.Length = 0 Then
            MsgBox("Please Select the Cost Cotegory Name...... ", MsgBoxStyle.Information)
            TabControl1.SelectedIndex = 0
            TxtCostCenterCategory.Focus()
            Exit Sub
        End If
        If IsOpenForAlter = True Then
            If UCase(OpenedVhName) <> UCase(TxtVhName.Text) Then
                If UCase(Replace(TxtVhName.Text, " ", "")) <> UCase(Replace(OpenedVhName, " ", "")) Then
                    If SQLIsFieldExists("select VHName from vehicle where vhname=N'" & TxtVhName.Text & "'") = True Then
                        MsgBox("The Vehicle Name is already Exits, Please Try with another....", MsgBoxStyle.Information)
                        TxtVhName.Focus()
                        Exit Sub
                    End If
                    If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & TxtVhName.Text & "'") = True Then
                        MsgBox("The Vechicle Name for cost center is already exists, Please try again....", MsgBoxStyle.Critical)
                        TxtVhName.Focus()
                        Exit Sub
                    End If
                End If

            End If
        Else
            If SQLIsFieldExists("select VHName from vehicle where vhname=N'" & TxtVhName.Text & "'") = True Then
                MsgBox("The Vehicle Name is already Exits, Please Try with another....", MsgBoxStyle.Information)
                TxtVhName.Focus()
                Exit Sub
            End If
            If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & TxtVhName.Text & "'") = True Then
                MsgBox("The Employee Name for cost center is  already exists, Please try again....", MsgBoxStyle.Critical)
                TxtVhName.Focus()
                Exit Sub
            End If
        End If
        If IsOpenForAlter = True Then
            If MsgBox("Do you want to Alter ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveData()
                Me.Close()
            End If

            If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & OpenedVhName & "'") = False Then
                If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & Replace(OpenedVhName, " ", "") & "'") = False Then
                    Dim Sqlstr As String = ""
                    Sqlstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                      & "VALUES(N'" & OpenedVhName & "',N'" & TxtCostCenterCategory.Text & "',0,'Vehicle')"
                    ExecuteSQLQuery(Sqlstr)
                End If

            End If
            ExecuteSQLQuery("UPDATE CostCenterNames SET CostName=N'" & TxtVhName.Text & "' WHERE CostName=N'" & OpenedVhName & "'")
            ExecuteSQLQuery("UPDATE CostCenterBook SET CostCenterName=N'" & TxtVhName.Text & "' WHERE CostCenterName=N'" & OpenedVhName & "'")
        Else
            If MsgBox("Do you want to Save ?            ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveData()


                Dim Sqlstr As String = ""
                Sqlstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                  & "VALUES(N'" & TxtVhName.Text & "',N'" & TxtCostCenterCategory.Text & "',0,'Vehicle')"
                ExecuteSQLQuery(Sqlstr)

                LoadDefs()
                TabControl1.SelectedIndex = 0
                TxtType.Focus()

            End If
        End If

    End Sub

    Private Sub CreateNewVehicle_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub CreateNewVehicle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDataIntoComboBox("select empname from employees where isdelete=0 and isactive=1", TxtDriverName, "empname")
        LoadDataIntoComboBox("select empname from employees where isdelete=0 and isactive=1", TxtAssistantName, "empname")
        'LoadDataIntoComboBox("select ledgername from ledgers where isactive=1 and accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.IndirectExpenses & "' or groupname=N'" & AccountGroupNames.DirectExpenses & "') ", TxtLedgerName, "ledgername")
        TxtLedgerName.Items.Add("")
        LoadDataIntoComboBox("select stockgroupname from CostCenters ", TxtCostCenterCategory, "stockgroupname")
        'TxtAccountGroup
        LoadDefs()
        If IsOpenForAlter = True Then
            BtnSave.Text = "&Alter"
            LoadVhData()
        End If
    End Sub
    Sub LoadVhData()
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
                TxtCostCenterCategory.Text = Sreader("AccountGroup")
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

                    Photoname = ""
                Catch ex As Exception

                End Try

                TxtAttach1.Text = Sreader("DocAttachFileName1").ToString.Trim
                TxtAttach2.Text = Sreader("DocAttachFileName2").ToString.Trim
                TxtAttach3.Text = Sreader("DocAttachFileName3").ToString.Trim
                TxtAttach4.Text = Sreader("DocAttachFileName4").ToString.Trim
                TxtAttach5.Text = Sreader("DocAttachFileName5").ToString.Trim
                Ischeckedout = Sreader("isCheckOut")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn1.Close()
        End Try
    End Sub
    Sub SaveData()
        MainForm.Cursor = Cursors.WaitCursor
        Dim SqlStr As String = ""

        If IsOpenForAlter = True Then
            SqlStr = "UPDATE Vehicle SET  [VhType]=@VhType,[VHRefNo]=@VHRefNo,[VHID]=@VHID,[VHName]=@VHName,[IssuedBy]=@IssuedBy,[ExpiryDate]=@ExpiryDate,[RegNo]=@RegNo,[RegDate]=@RegDate,[VhNo]=@VhNo,[ContactNo1]=@ContactNo1,[ContactNo2]=@ContactNo2,[Chasisno]=@Chasisno,[EngineNo]=@EngineNo,[AccountGroup]=@AccountGroup,[AcountLedgerName]=@AcountLedgerName,[PhotoPath]=@PhotoPath,[IsDelete]=@IsDelete,[IsActive]=@IsActive,[Status]=@Status,[DocAdd1]=@DocAdd1,[DocAdd2]=@DocAdd2,[DocAdd3]=@DocAdd3,[DocAdd4]=@DocAdd4,[DriverName1]=@DriverName1,[DriverName2]=@DriverName2,[AssistantName1]=@AssistantName1,[AssistantName2]=@AssistantName2,[Color]=@Color,[Model]=@Model,[MadeBy]=@MadeBy,[InsurenceNo1]=@InsurenceNo1,[InsurenceDate1]=@InsurenceDate1,[InsurenceExpiry1]=@InsurenceExpiry1,[InsurenceNo2]=@InsurenceNo2,[InsurenceDate2]=@InsurenceDate2,[InsurenceExpiry2]=@InsurenceExpiry2,[InsurenceNo3]=@InsurenceNo3,[InsurenceDate3]=@InsurenceDate3,[InsurenceExpiry3]=@InsurenceExpiry3,[InsurenceDetails3]=@InsurenceDetails3,[InsurenceDetails2]=@InsurenceDetails2,[InsurenceDetails1]=@InsurenceDetails1,isCheckOut=@isCheckOut WHERE vhname=N'" & OpenedVhName & "'"
        Else
            SqlStr = "INSERT INTO [Vehicle] ([VhType],[VHRefNo],[VHID],[VHName],[IssuedBy],[ExpiryDate],[RegNo],[RegDate],[VhNo], " _
                & "[ContactNo1],[ContactNo2],[Chasisno],[EngineNo],[AccountGroup],[AcountLedgerName],[PhotoPath],[IsDelete],[IsActive]," _
                & "[Status],[DocAdd1],[DocAdd2],[DocAdd3],[DocAdd4],[DriverName1],[DriverName2],[AssistantName1],[AssistantName2]," _
                & "[Color],[Model],[MadeBy],[InsurenceNo1],[InsurenceDate1],[InsurenceExpiry1],[InsurenceNo2],[InsurenceDate2]," _
                & "[InsurenceExpiry2],[InsurenceNo3],[InsurenceDate3],[InsurenceExpiry3],[InsurenceDetails3],[InsurenceDetails2],[InsurenceDetails1],[isCheckOut])     VALUES " _
         & " (@VhType,@VHRefNo,@VHID,@VHName,@IssuedBy,@ExpiryDate,@RegNo,@RegDate,@VhNo,@ContactNo1,@ContactNo2,@Chasisno,@EngineNo, " _
         & "@AccountGroup,@AcountLedgerName,@PhotoPath,@IsDelete,@IsActive,@Status,@DocAdd1,@DocAdd2,@DocAdd3,@DocAdd4,@DriverName1, " _
         & "@DriverName2,@AssistantName1,@AssistantName2,@Color,@Model,@MadeBy,@InsurenceNo1,@InsurenceDate1,@InsurenceExpiry1," _
         & "@InsurenceNo2,@InsurenceDate2,@InsurenceExpiry2,@InsurenceNo3,@InsurenceDate3,@InsurenceExpiry3,@InsurenceDetails3,@InsurenceDetails2,@InsurenceDetails1,@isCheckOut) "

        End If
        Try
            MAINCON.ConnectionString = ConnectionStrinG
            MAINCON.Open()
            Dim DBF As New SqlClient.SqlCommand(SqlStr, MAINCON)
            With DBF.Parameters
                .AddWithValue("VhType", TxtType.Text)
                .AddWithValue("VHRefNo", TxtRefNo.Text)
                .AddWithValue("VHID", TxtID.Text)
                .AddWithValue("VHName", TxtVhName.Text)
                .AddWithValue("IssuedBy", TxtIssuedBy.Text)
                .AddWithValue("ExpiryDate", TxtRegExpiry.Value.Date)
                .AddWithValue("RegNo", TxtRegNo.Text)
                .AddWithValue("RegDate", TxtRegDate.Value.Date)
                .AddWithValue("VhNo", TxtVhNo.Text)
                .AddWithValue("ContactNo1", TxtContactNo1.Text)
                .AddWithValue("ContactNo2", TxtContactNO2.Text)
                .AddWithValue("Chasisno", TxtChassiNo.Text)
                .AddWithValue("EngineNo", TxtEngineNo.Text)
                .AddWithValue("AccountGroup", TxtCostCenterCategory.Text)
                .AddWithValue("AcountLedgerName", TxtLedgerName.Text)
                .AddWithValue("PhotoPath", PhotoPathForLedgers & "\Others\" & TxtVhName.Text & ".jpg")
                .AddWithValue("IsDelete", 0)
                .AddWithValue("IsActive", 1)
                .AddWithValue("Status", "N")
                .AddWithValue("DocAdd1", TxtAdd1.Text)
                .AddWithValue("DocAdd2", TxtAdd2.Text)
                .AddWithValue("DocAdd3", TxtAdd3.Text)
                .AddWithValue("DocAdd4", TxtAdd4.Text)
                .AddWithValue("DriverName1", TxtDriverName.Text)
                .AddWithValue("DriverName2", "")
                .AddWithValue("AssistantName1", TxtAssistantName.Text)
                .AddWithValue("AssistantName2", "")
                .AddWithValue("Color", TxtColor.Text)
                .AddWithValue("Model", TxtModel.Text)
                .AddWithValue("MadeBy", TxtMadeBy.Text)
                .AddWithValue("InsurenceNo1", TxtRef1.Text)
                .AddWithValue("InsurenceDate1", TxtRegDate1.Value.Date)
                .AddWithValue("InsurenceExpiry1", TxtExpiryDate1.Value.Date)
                .AddWithValue("InsurenceNo2", TxtRef2.Text)
                .AddWithValue("InsurenceDate2", TxtRegDate2.Value.Date)
                .AddWithValue("InsurenceExpiry2", TxtExpiryDate2.Value.Date)
                .AddWithValue("InsurenceNo3", TxtRef3.Text)
                .AddWithValue("InsurenceDate3", txtRegDate3.Value.Date)
                .AddWithValue("InsurenceExpiry3", TxtExpiryDate3.Value.Date)
                .AddWithValue("InsurenceDetails3", TxtDetails1.Text)
                .AddWithValue("InsurenceDetails2", TxtDetails2.Text)
                .AddWithValue("InsurenceDetails1", TxtDetails3.Text)
                .AddWithValue("isCheckOut", Ischeckedout)
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
            ExecuteSQLQuery("Update vehicle set DocAttachFileName1='',DocAttachFileSize1=0,DocAttach1=NULL where vhname=N'" & TxtVhName.Text & "'")
        End If

        If TxtAttach2.Text.Length > 0 Then
            If TxtAttach2.Text.Contains("\") = True Then SaveAttachment(TxtAttach2.Text, "DocAttachFileName2", "DocAttachFileSize2", "DocAttach2")
        Else
            ExecuteSQLQuery("Update vehicle set DocAttachFileName2='',DocAttachFileSize2=0,DocAttach2=NULL where vhname=N'" & TxtVhName.Text & "'")
        End If

        If TxtAttach3.Text.Length > 0 Then
            If TxtAttach3.Text.Contains("\") = True Then SaveAttachment(TxtAttach3.Text, "DocAttachFileName3", "DocAttachFileSize3", "DocAttach3")
        Else
            ExecuteSQLQuery("Update vehicle set DocAttachFileName3='',DocAttachFileSize3=0,DocAttach3=NULL where vhname=N'" & TxtVhName.Text & "'")
        End If

        If TxtAttach4.Text.Length > 0 Then
            If TxtAttach4.Text.Contains("\") = True Then SaveAttachment(TxtAttach4.Text, "DocAttachFileName4", "DocAttachFileSize4", "DocAttach4")
        Else
            ExecuteSQLQuery("Update vehicle set DocAttachFileName4='',DocAttachFileSize4=0,DocAttach4=NULL where vhname=N'" & TxtVhName.Text & "'")
        End If

        If TxtAttach5.Text.Length > 0 Then
            If TxtAttach5.Text.Contains("\") = True Then SaveAttachment(TxtAttach5.Text, "DocAttachFileName5", "DocAttachFileSize5", "DocAttach5")
        Else
            ExecuteSQLQuery("Update vehicle set DocAttachFileName5='',DocAttachFileSize5=0,DocAttach5=NULL where vhname=N'" & TxtVhName.Text & "'")
        End If
        If IsImagechanged = True Then
            If SQLIsFieldExists("SELECT TOP 1 1 from  images where BCODE=N'VEH" & TxtVhName.Text & "'") = False Then
                If Photoname.Length > 0 Then
                    InsertImageIntoDatabase(Photoname, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", "VEH" & TxtVhName.Text, "")
                Else
                    InsertImageIntoDatabase(TxtPic.Image, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", "VEH" & TxtVhName.Text, "")
                End If
            Else
                If Photoname.Length > 0 Then
                    UpdateImageIntoDatabase(Photoname, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'VEH" & TxtVhName.Text & "'", "")
                Else
                    UpdateImageIntoDatabase(TxtPic.Image, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=V'VEH" & TxtVhName.Text & "'", "")
                End If
            End If
        ElseIf IsOpenForAlter = False Then
            If Photoname.Length > 0 Then
                UpdateImageIntoDatabase(Photoname, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'VEH" & TxtVhName.Text & "'", "")
            Else
                UpdateImageIntoDatabase(TxtPic.Image, "imagedata", "UPDATE IMAGES SET IMAGEDATA=@IMAGEDATA WHERE BCODE=N'VEH" & TxtVhName.Text & "'", "")
            End If
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

        Dim SqlStr As String = "update vehicle set " & filedFilename & "=@FiledFileName," & filedfilesize & "=@filedfilesize," & fileddata & "=@fileddata" & " where vhname=N'" & TxtVhName.Text & "'"

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

End Class
