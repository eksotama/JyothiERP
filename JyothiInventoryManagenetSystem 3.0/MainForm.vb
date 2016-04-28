Imports System.IO
Imports SoftwareLocker

Public Class MainForm

    Public Shared purchaseVoucherEntry As VoucherEntryForm
    Public Shared PurchaseReturnVoucherEntry As VoucherEntryForm
    Public Shared SalesVoucherEntry As VoucherEntryForm
    Public Shared SalesReturnVoucherEntry As VoucherEntryForm
    Public Shared PaymentVoucherEntry As VoucherEntryForm
    Public Shared ReceiptVoucherEntry As VoucherEntryForm
    Public Shared JournalVoucherEntry As VoucherEntryForm
    Public Shared ContraVoucherEntry As VoucherEntryForm

    Public Shared SinglePaymentVoucherEntry As SingleEntryVoucherForm
    Public Shared SingleReceiptVoucherEntry As SingleEntryVoucherForm
    Public Shared SingleContraVoucherEntry As SingleEntryVoucherForm
    Public Shared SalesInvoiceFormSRCash As SalesInvoiceAllFormControl
    Public Shared CustomerBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared SupplierBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared LedgersBalaceReportFrom As LedgerBalanceSheetForm
    Public Shared LedgerAccountReportFormForCashBook As LedgerAccountReportForm
    Public Shared LedgerAccountReportFormForLedgers As LedgerAccountReportForm

    Public Shared SalesSOReportForm As SalesTransactionReports
    Public Shared SalesSRReportForm As SalesTransactionReports
    Public Shared SalesSIReportForm As SalesTransactionReports
    Public Shared SalesSDReportForm As SalesTransactionReports
    Public Shared SalesSQReportForm As SalesTransactionReports
    Public Shared SalesPOSReportForm As SalesTransactionReports

    Public Shared StockJournalbyLoc As StockTransferFrm
    Public Shared StockJournalIBT As StockTransferFrm

    Public Shared StockRepForm As StockItemwiseReport
    Public Shared LedgerAccountsBalanceForm As LedgerTransactionsReportForm
    Public Shared CustomersBalanceForm As LedgerTransactionsReportForm
    Public Shared SuppliersBalanceForm As LedgerTransactionsReportForm
    Public Shared CashBookFrm As LedgerTransactionsReportForm
    Public Shared BankBookFrm As LedgerTransactionsReportForm
    Public Shared empshistryfrm As EmpSalaryHistory
    Public Shared ApprovePurchaseEnquirieSVAR As ApprovePurchaseEnquiriesfrm
    Public Shared PurchasePQReportForm As PurchaseTransactionReports
    Public Shared PurchasePGReportForm As PurchaseTransactionReports
    Public Shared PurchasePIReportForm As PurchaseTransactionReports
    Public Shared PurchasePOReportForm As PurchaseTransactionReports
    Public Shared PurchasePRReportForm As PurchaseTransactionReports

    Public Shared SalesInvoiceFormSQ As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSI As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSD As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSR As SalesInvoiceAllFormControl
    Public Shared POSfrm As POS
    Public Shared SalesInvoiceFormPOS As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormPOSNotax As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormPOSform8 As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormPOSform8b As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormPOSform8D As SalesInvoiceAllFormControl
    Public Shared SalesReturnsInvoiceFormPOSform8 As SalesInvoiceAllFormControl
    Public Shared SalesReturnsInvoiceFormPOSform8b As SalesInvoiceAllFormControl
    Public Shared SalesReturnsInvoiceFormPOSform8D As SalesInvoiceAllFormControl
    Public Shared SalesInvoiceFormSO As SalesInvoiceAllFormControl


    Public Shared PurchaseInvoiceFormPQ As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPI As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPG As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPR As PurchaseInvoiceAllFromControl
    Public Shared PurchaseInvoiceFormPO As PurchaseInvoiceAllFromControl
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get

    End Property

    Private Sub MainForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub


    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' AlternativeBarcodeToolStripMenuItem.Text = "Alternative Barcode"

        'System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern()
        HideCompanyTitleMenu.Checked = False
        OptionSideBarToolStripMenuItem.Checked = False
        AppCompanyTitleBar.Visible = False
        AppMainBarContainer.Height = 1
        AppSideBarContainer.Width = 1
        ERPInitializeObjects(Me)
        

        GetSQLSettingFromFile()
        ConnectionStrinG = ConnectionStringFromFile
        If ConnectionStrinG.Contains("&") = True Then
            End
        End If
        ConnectionStrinG = ConnectionStringFromFile
        If TestSQLConnection() = False Then
            MsgBox("The Server Settings are invalid or Server is not accessble, Please Try Again....")
            End
        End If
        ' CheckForTrailApplication()
        IsTrailApplication = False

        LoginIntoAPP()
        If EntryCurrentPeriodEnd.Value < Today Then
            Dim frm As New ChangeCurrentPeriod
            frm.ShowDialog()
            frm.Dispose()
        End If




    End Sub
    Sub CheckForTrailApplication()
        'product code: 621
        'Application ID : *123456*
        ' You can change both 
	' for yearly subscription, you have set a parameter true for issubscription 
	'ex: Enter the days as 365, like as follows 
	'Dim TRAILCHECKER As New SoftwareLocker.TrialMaker("SURESH", Application.StartupPath + "\\REGIANS.reg", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\JSIES.dbf", "To get the Activation Key, call us at : +91 9491354794", 365, 58, "136", "*123456*", True)

        Dim TRAILCHECKER As New SoftwareLocker.TrialMaker("SURESH", Application.StartupPath + "\\REGIANS.reg", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\JSIES.dbf", "To get the Activation Key, call us at : +91 9491354794", 100, 58, "136", "*123456*", False)
        Dim myOwnKey As Byte() = {97, 250, 1, 5, 84, 21, 7, 63, 4, 54, 87, 56, 123, 10, 3, 62, 7, 9, 20, 36, 37, 21, 101, 57}
        TRAILCHECKER.TripleDESKey = myOwnKey
        Dim RT As TrialMaker.RunTypes
        RT = TRAILCHECKER.ShowDialog

        Dim is_trial As Boolean = True
        If RT <> TrialMaker.RunTypes.Expired Then
            If (RT = TrialMaker.RunTypes.Full) Then
                is_trial = False
            Else
                is_trial = True
            End If
        Else
            End
        End If
        IsTrailApplication = is_trial
        If IsTrailApplication = True Then
            Me.MainMenuAdminOnly.Enabled = False
        Else
            Me.MainMenuAdminOnly.Enabled = True
        End If
        'END OF THE ACTIVATION
    End Sub
    Sub LoginIntoAPP(Optional ByVal IsSelectCompany As Boolean = False)
        Dim tempcon As String = ""
        tempcon = ConnectionStrinG
        Me.Cursor = Cursors.WaitCursor
        If LoadDatabaseLists() = False Then
            Me.Cursor = Cursors.Default
            Dim ccreate As New Company
            ccreate.ShowDialog()
            MsgBox("Please Restart the program....              ")
            End
        Else

            Me.Cursor = Cursors.WaitCursor
            If IsSelectCompany = True Then
                AdminLogin.Cancel.Text = "&Close"
                If AdminLogin.ShowDialog() <> DialogResult.OK Then
                    ConnectionStrinG = tempcon
                    Me.Cursor = Cursors.WaitCursor
                    AdvDashBoardfrm.SuspendLayout()
                    AdvDashBoardfrm.MdiParent = Me
                    AdvDashBoardfrm.Dock = DockStyle.Fill
                    AdvDashBoardfrm.Show()
                    AdvDashBoardfrm.WindowState = FormWindowState.Maximized
                    AdvDashBoardfrm.BringToFront()
                    AdvDashBoardfrm.ResumeLayout()
                    Me.Cursor = Cursors.Default

                    Me.Cursor = Cursors.WaitCursor
                    EmployeeIDMonitor.SuspendLayout()
                    EmployeeIDMonitor.MdiParent = Me
                    EmployeeIDMonitor.Dock = DockStyle.Fill
                    EmployeeIDMonitor.Show()
                    EmployeeIDMonitor.WindowState = FormWindowState.Maximized
                    EmployeeIDMonitor.BringToFront()
                    EmployeeIDMonitor.ResumeLayout()
                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If

            Else
                If AdminLogin.ShowDialog() <> DialogResult.OK Then
                    End
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            APPUserRights.IsAccessable = True
            APPUserRights.IsDeleteble = True
            APPUserRights.IsEditable = True
            APPUserRights.IsHasFullRights = True
            APPUserRights.IsAdvanceUser = True
            APPUserRights.IsAccessMasters = True
            MainMenuAdminOnly.Visible = False
            FinanceMainMenu.Visible = False
            If IsUserAdmin = False Then
                MainMenuAdminOnly.Visible = False
                LoadUserRights()
                SetUserSoftwareSettings()
                LoadDataIntoComboBox("select depname from UserDepartments where userid=N'" & CurrentUserName & "' and isdelete=0", AllowedUserDepartmentLists, "depname", DefDepartment)
                SetMenusForUsers()
                MenuUserSettings.Visible = True
            Else
                Dim adpanel1 As New AdminSideBarMenu
                adpanel1.arrangecontrols(0)
                adpanel1.Dock = DockStyle.Fill
                MainPannelMaster.Controls.Add(adpanel1)
                MenuUserSettings.Visible = False
                MainMenuAdminOnly.Visible = True
                MainMenuAdminOnly.Visible = True
                FinanceMainMenu.Visible = True
            End If

            LoadCompanyData()

            TxtCompanyName.Text = CompDetails.CompanyID
            TxtCompanyAddress.Text = CompDetails.Companystreet
            TxtCompanyAccPeriod.Text = FormatDateTime(CompDetails.AccDateFrom.Date, DateFormat.ShortDate) & " - " & FormatDateTime(CompDetails.AccDateTo.Date.ToString, DateFormat.ShortDate)
            TxtSoftwareProductName.Text = Me.Text
            TxtSoftwareLicenceInfo.Text = ""
        End If



        If TestSQLConnection() = False Then
            Me.Cursor = Cursors.Default
            MsgBox("The Server Settings are invalid           ")
            End
        End If
        If TestSQLDatabaseIsEXIST(txtSoftwareSQLdefaultCompany) = True Then
            UpdateVersionDatabase()
            LoadDefLedgerValues()
            LoadInvoiceBillingSettings()
            LoadSettings()
            LoadInoiceDisplaySettings()
            LoadEmailSettings()
            LoadRoundoffSettings()
            LoadBarcodeSettings()
            LoadPOSSettings()
            If MyAppSettings.IsCustomBarcode = True Then
                CustomBarcodeSettingsToolStripMenuItem.Visible = True
                IsCustomBarCode = True
            Else
                CustomBarcodeSettingsToolStripMenuItem.Visible = False
                IsCustomBarCode = False
            End If
        Else
            End
        End If
        If IsClientAndServerSystem = True Then
            If IsUserAdmin = True Then
                If IsRunServerWithApplication = True Then
                    Try
                        If Process.GetProcessesByName("ERPServer").Count <= 0 Then
                            Process.Start(Microsoft.VisualBasic.CurDir & "\ERPServer.exe", ConnectionStrinG)
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Process.GetProcessesByName("ERPServer").Count <= 0 Then
                            Process.Start(Microsoft.VisualBasic.CurDir & "\ERPServer.exe", ConnectionStrinG)
                        End If
                    Catch ex2 As Exception

                    End Try
                End If

            End If
        End If

        Try
            TxtMainLogo.BackgroundImage = GetImageFromDatabase("IMAGEDATA", "SELECT TOP 1  IMAGEDATA FROM IMAGES WHERE BCODE=N'@CMP0000L0GO'")
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
        AppCalander.TodayDate = Today
        ExecuteSQLQuery("SET LANGUAGE 'British English'")
        Me.Cursor = Cursors.Default

        SetAdditionalMenuSettings()
        LoadCrystalReportOptions()
        LoadSMSSettings()

        StatusBarCurrentUserName.Text = "Current User: " & CurrentUserName
        TenMinuteTimer.Enabled = True
        If My.Computer.Screen.WorkingArea.Width <= 1024 Then
            AppSideBarContainer.Width = 1
        End If
        If MyAppSettings.POSPriceListName.Length = 0 Then
            MyAppSettings.POSPriceListName = "*All"
        End If




        'DASH BOARD FOR ADMIN

        If IsUserAdmin = True Then
            DashBoardToolStripMenuItem.Visible = True
            DashBoardToolStripMenuItem.Enabled = True
            Me.Cursor = Cursors.WaitCursor
            AdvDashBoardfrm.SuspendLayout()
            AdvDashBoardfrm.MdiParent = Me
            AdvDashBoardfrm.Dock = DockStyle.Fill
            AdvDashBoardfrm.Show()
            AdvDashBoardfrm.WindowState = FormWindowState.Maximized
            AdvDashBoardfrm.BringToFront()
            AdvDashBoardfrm.ResumeLayout()
          
            'EmployeeIDMonitor.SuspendLayout()
            'EmployeeIDMonitor.MdiParent = Me
            'EmployeeIDMonitor.Dock = DockStyle.Fill
            'EmployeeIDMonitor.Show()
            'EmployeeIDMonitor.WindowState = FormWindowState.Maximized
            'EmployeeIDMonitor.BringToFront()
            'EmployeeIDMonitor.ResumeLayout()
            Me.Cursor = Cursors.Default
        Else
            DashBoardToolStripMenuItem.Visible = False
            DashBoardToolStripMenuItem.Enabled = False
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Sub SetAdditionalMenuSettings()
        If MyAppSettings.IsAllowSalesOrders = False Then
            SalesOrderToolStripMenuItem.Visible = False
            SalesOrdersToolStripMenuItem1.Visible = False
            MainOrderMenuItem.Visible = False
        End If
        If MyAppSettings.IsAllowPurchaseOrders = False Then
            OrderToolStripMenuItem.Visible = False
            PurchaseOrdersToolStripMenuItem.Visible = False
            OutstandingsToolStripMenuItem1.Visible = False
        End If
        If MyAppSettings.IsAllowDebitNote = False Then
            PurchaseReturnsDebitNoteToolStripMenuItem.Visible = False
            DebitNoteToolStripMenuItem.Visible = False
        End If
        If MyAppSettings.IsAllowCreditNote = False Then
            CreditNoteToolStripMenuItem.Visible = False
            SalesReturnsCreditNoteToolStripMenuItem.Visible = False
        End If
        If MyAppSettings.IsAllowDeliveryNote = False Then
            SalesDeliveryNoteToolStripMenuItem.Visible = False
        End If
        If MyAppSettings.IsAllowGReceiptNote = False Then
            PurchaseGoodsReceiptNoteToolStripMenuItem.Visible = False
        End If
        If MyAppSettings.IsAllowMultiPriceLevels = False Then
            PriceListToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub UnitsOfMeasurementsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitsOfMeasurementsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockUnits.SuspendLayout()
        StockUnits.MdiParent = Me
        StockUnits.Dock = DockStyle.Fill
        StockUnits.Show()
        StockUnits.WindowState = FormWindowState.Maximized
        StockUnits.BringToFront()
        StockUnits.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StockCatogoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCatogoriesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockCategories.SuspendLayout()
        StockCategories.MdiParent = Me
        StockCategories.Dock = DockStyle.Fill
        StockCategories.Show()
        StockCategories.WindowState = FormWindowState.Maximized
        StockCategories.BringToFront()
        StockCategories.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StockGroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockGroupsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockGroups.SuspendLayout()
        StockGroups.MdiParent = Me
        StockGroups.Dock = DockStyle.Fill
        StockGroups.Show()
        StockGroups.WindowState = FormWindowState.Maximized
        StockGroups.BringToFront()
        StockGroups.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        AccountGroups.SuspendLayout()
        AccountGroups.MdiParent = Me
        AccountGroups.Dock = DockStyle.Fill
        AccountGroups.Show()
        AccountGroups.WindowState = FormWindowState.Maximized
        AccountGroups.BringToFront()
        AccountGroups.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BillingSttingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingSttingsToolStripMenuItem.Click, ToolStripMenuItem59.Click
        Billing_Settings.ShowDialog()
    End Sub

    Private Sub SalesManInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesManInfoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SalesPersons.SuspendLayout()
        SalesPersons.MdiParent = Me
        SalesPersons.Dock = DockStyle.Fill
        SalesPersons.Show()
        SalesPersons.WindowState = FormWindowState.Maximized
        SalesPersons.BringToFront()
        SalesPersons.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CreateNewStockItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewStockItemToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        StockItems.SuspendLayout()
        StockItems.MdiParent = Me
        StockItems.Dock = DockStyle.Fill
        StockItems.Show()
        StockItems.WindowState = FormWindowState.Maximized
        StockItems.BringToFront()
        StockItems.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StockLocationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockLocationsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Locations.SuspendLayout()
        Locations.MdiParent = Me
        Locations.Dock = DockStyle.Fill
        Locations.Show()
        Locations.WindowState = FormWindowState.Maximized
        Locations.BringToFront()
        Locations.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SuppliseInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppliseInfoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Suppliers.SuspendLayout()
        Suppliers.MdiParent = Me
        Suppliers.Dock = DockStyle.Fill
        Suppliers.Show()
        Suppliers.WindowState = FormWindowState.Maximized
        Suppliers.BringToFront()
        Suppliers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CustomerInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerInfoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Customers.SuspendLayout()
        Customers.MdiParent = Me
        Customers.Dock = DockStyle.Fill
        Customers.Show()
        Customers.WindowState = FormWindowState.Maximized
        Customers.BringToFront()
        Customers.ResumeLayout()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub QuatotionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuatotionToolStripMenuItem.Click


        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()

        If SalesInvoiceFormSQ Is Nothing OrElse SalesInvoiceFormSQ.IsDisposed Then
            SalesInvoiceFormSQ = New SalesInvoiceAllFormControl("SQ")
            SalesInvoiceFormSQ.SuspendLayout()
            SalesInvoiceFormSQ.MdiParent = Me

            SalesInvoiceFormSQ.BringToFront()
            SalesInvoiceFormSQ.Dock = DockStyle.Fill
            SalesInvoiceFormSQ.Show()
            SalesInvoiceFormSQ.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSQ.MdiParent = Me
            SalesInvoiceFormSQ.Dock = DockStyle.Fill
            SalesInvoiceFormSQ.Show()
            SalesInvoiceFormSQ.BringToFront()
        End If
        Me.Cursor = Cursors.Default
        SalesInvoiceFormSQ.ResumeLayout()
    End Sub

    Private Sub LedgersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgersToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Ledgers.SuspendLayout()
        Ledgers.MdiParent = Me
        Ledgers.Dock = DockStyle.Fill
        Ledgers.Show()
        Ledgers.WindowState = FormWindowState.Maximized
        Ledgers.BringToFront()
        Ledgers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub HideCompanyTitleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideCompanyTitleMenu.Click
        If HideCompanyTitleMenu.Checked = True Then
            AppCompanyTitleBar.Visible = True
            'AppTitle.Height = 87
            AppMainBarContainer.Height = 66

        Else
            AppCompanyTitleBar.Visible = False
            'AppTitle.Height = 25
            AppMainBarContainer.Height = 1
        End If
        MainMenu.Visible = True
    End Sub

    Private Sub OptionSideBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionSideBarToolStripMenuItem.Click
        My.Application.DoEvents()
        If OptionSideBarToolStripMenuItem.Checked = True Then
            'APPSideBar.Width = 175
            AppSideBarContainer.Width = 220
        Else
            'APPSideBar.Width = 1
            AppSideBarContainer.Width = 1
        End If
    End Sub

    Private Sub DefaultLedgerSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultLedgerSettingsToolStripMenuItem.Click
        DefaultLedgerSettingsForm.ShowDialog()
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click

        If DefLedgers.PurchaseAccount.Length < 2 Then
            MsgBox("The Purchase Ledger not Exists. without Purchase Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If purchaseVoucherEntry Is Nothing OrElse purchaseVoucherEntry.IsDisposed Then
            purchaseVoucherEntry = New VoucherEntryForm("Purchase Voucher")
            purchaseVoucherEntry.MdiParent = Me
            purchaseVoucherEntry.BringToFront()
            purchaseVoucherEntry.Dock = DockStyle.Fill
            purchaseVoucherEntry.Show()
            purchaseVoucherEntry.WindowState = FormWindowState.Maximized
        Else
            purchaseVoucherEntry.MdiParent = Me
            purchaseVoucherEntry.Dock = DockStyle.Fill
            purchaseVoucherEntry.Show()
            purchaseVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DebitNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitNoteToolStripMenuItem.Click
        If DefLedgers.PurchaseRetAccount.Length < 2 Then
            MsgBox("The Purchase Returns Ledger not Exists. without Purchase Return Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseReturnVoucherEntry Is Nothing OrElse PurchaseReturnVoucherEntry.IsDisposed Then
            PurchaseReturnVoucherEntry = New VoucherEntryForm("Debit Note Voucher")
            PurchaseReturnVoucherEntry.MdiParent = Me
            PurchaseReturnVoucherEntry.BringToFront()
            PurchaseReturnVoucherEntry.Dock = DockStyle.Fill
            PurchaseReturnVoucherEntry.Show()
            PurchaseReturnVoucherEntry.WindowState = FormWindowState.Maximized
        Else
            PurchaseReturnVoucherEntry.MdiParent = Me
            PurchaseReturnVoucherEntry.Dock = DockStyle.Fill
            PurchaseReturnVoucherEntry.Show()
            PurchaseReturnVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ContraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraToolStripMenuItem.Click
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            DefaultLedgerSettingsForm.ShowDialog()
            If DefLedgers.CashAccount.Length < 2 Then
                Exit Sub
            End If

        End If
        If MyAppSettings.AllowSingleEntryMode = True Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SingleContraVoucherEntry Is Nothing OrElse SingleContraVoucherEntry.IsDisposed Then
                SingleContraVoucherEntry = New SingleEntryVoucherForm("Contra")
                SingleContraVoucherEntry.MdiParent = Me
                SingleContraVoucherEntry.BringToFront()
                SingleContraVoucherEntry.Dock = DockStyle.Fill
                SingleContraVoucherEntry.Show()
                SingleContraVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                SingleContraVoucherEntry.MdiParent = Me
                SingleContraVoucherEntry.Dock = DockStyle.Fill
                SingleContraVoucherEntry.Show()
                SingleContraVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If ContraVoucherEntry Is Nothing OrElse ContraVoucherEntry.IsDisposed Then
                ContraVoucherEntry = New VoucherEntryForm("Contra")
                ContraVoucherEntry.MdiParent = Me
                ContraVoucherEntry.BringToFront()
                ContraVoucherEntry.Dock = DockStyle.Fill
                ContraVoucherEntry.Show()
                ContraVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                ContraVoucherEntry.MdiParent = Me
                ContraVoucherEntry.Dock = DockStyle.Fill
                ContraVoucherEntry.Show()
                ContraVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub JournalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If JournalVoucherEntry Is Nothing OrElse JournalVoucherEntry.IsDisposed Then
            JournalVoucherEntry = New VoucherEntryForm("Journal")
            JournalVoucherEntry.MdiParent = Me
            JournalVoucherEntry.BringToFront()
            JournalVoucherEntry.Dock = DockStyle.Fill
            JournalVoucherEntry.Show()
            JournalVoucherEntry.WindowState = FormWindowState.Maximized
        Else
            JournalVoucherEntry.MdiParent = Me
            JournalVoucherEntry.Dock = DockStyle.Fill
            JournalVoucherEntry.Show()
            JournalVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        If DefLedgers.SalesAccount.Length < 2 Then
            MsgBox("The Sales Ledger is not Exists. without  Sales Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesVoucherEntry Is Nothing OrElse SalesVoucherEntry.IsDisposed Then
            SalesVoucherEntry = New VoucherEntryForm("Sales Voucher")
            SalesVoucherEntry.MdiParent = Me
            SalesVoucherEntry.BringToFront()
            SalesVoucherEntry.Dock = DockStyle.Fill
            SalesVoucherEntry.Show()
            SalesVoucherEntry.WindowState = FormWindowState.Maximized
        Else
            SalesVoucherEntry.MdiParent = Me
            SalesVoucherEntry.Dock = DockStyle.Fill
            SalesVoucherEntry.Show()
            SalesVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub CreditNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditNoteToolStripMenuItem.Click
        If DefLedgers.SalesRetAccount.Length < 2 Then
            MsgBox("The Sales Returns Ledger not Exists. without Sales Return Ledger , voucher can't be created...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnVoucherEntry Is Nothing OrElse SalesReturnVoucherEntry.IsDisposed Then
            SalesReturnVoucherEntry = New VoucherEntryForm("Credit Note Voucher")
            SalesReturnVoucherEntry.MdiParent = Me
            SalesReturnVoucherEntry.BringToFront()
            SalesReturnVoucherEntry.Dock = DockStyle.Fill
            SalesReturnVoucherEntry.WindowState = FormWindowState.Maximized
            SalesReturnVoucherEntry.Show()
        Else
            SalesReturnVoucherEntry.MdiParent = Me
            SalesReturnVoucherEntry.Dock = DockStyle.Fill
            SalesReturnVoucherEntry.Show()
            SalesReturnVoucherEntry.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentsToolStripMenuItem.Click
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            DefaultLedgerSettingsForm.ShowDialog()
            If DefLedgers.CashAccount.Length < 2 Then
                Exit Sub
            End If

        End If
        If MyAppSettings.AllowSingleEntryMode = True Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SinglePaymentVoucherEntry Is Nothing OrElse SinglePaymentVoucherEntry.IsDisposed Then
                SinglePaymentVoucherEntry = New SingleEntryVoucherForm("Payment")
                SinglePaymentVoucherEntry.MdiParent = Me
                SinglePaymentVoucherEntry.BringToFront()
                SinglePaymentVoucherEntry.Dock = DockStyle.Fill
                SinglePaymentVoucherEntry.Show()
                SinglePaymentVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                SinglePaymentVoucherEntry.MdiParent = Me
                SinglePaymentVoucherEntry.Dock = DockStyle.Fill
                SinglePaymentVoucherEntry.Show()
                SinglePaymentVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If PaymentVoucherEntry Is Nothing OrElse PaymentVoucherEntry.IsDisposed Then
                PaymentVoucherEntry = New VoucherEntryForm("Payment")
                PaymentVoucherEntry.MdiParent = Me
                PaymentVoucherEntry.BringToFront()
                PaymentVoucherEntry.Dock = DockStyle.Fill
                PaymentVoucherEntry.Show()
                PaymentVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                PaymentVoucherEntry.MdiParent = Me
                PaymentVoucherEntry.Dock = DockStyle.Fill
                PaymentVoucherEntry.Show()
                PaymentVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub ReceiptsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptsToolStripMenuItem.Click
        If DefLedgers.CashAccount.Length < 2 Then
            MsgBox("The Cash Account Ledger not Exists. without Cash Account Ledger , voucher can't be created...")
            DefaultLedgerSettingsForm.ShowDialog()
            If DefLedgers.CashAccount.Length < 2 Then
                Exit Sub
            End If
        End If
        If MyAppSettings.AllowSingleEntryMode = True Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SingleReceiptVoucherEntry Is Nothing OrElse SingleReceiptVoucherEntry.IsDisposed Then
                SingleReceiptVoucherEntry = New SingleEntryVoucherForm("Receipt")
                SingleReceiptVoucherEntry.MdiParent = Me
                SingleReceiptVoucherEntry.BringToFront()
                SingleReceiptVoucherEntry.Dock = DockStyle.Fill
                SingleReceiptVoucherEntry.Show()
                SingleReceiptVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                SingleReceiptVoucherEntry.MdiParent = Me
                SingleReceiptVoucherEntry.Dock = DockStyle.Fill
                SingleReceiptVoucherEntry.Show()
                SingleReceiptVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If ReceiptVoucherEntry Is Nothing OrElse ReceiptVoucherEntry.IsDisposed Then
                ReceiptVoucherEntry = New VoucherEntryForm("Receipt")
                ReceiptVoucherEntry.MdiParent = Me
                ReceiptVoucherEntry.BringToFront()
                ReceiptVoucherEntry.Dock = DockStyle.Fill
                ReceiptVoucherEntry.Show()
                ReceiptVoucherEntry.WindowState = FormWindowState.Maximized
            Else
                ReceiptVoucherEntry.MdiParent = Me
                ReceiptVoucherEntry.Dock = DockStyle.Fill
                ReceiptVoucherEntry.Show()
                ReceiptVoucherEntry.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub CreateNewCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewCompanyToolStripMenuItem.Click
        Dim ccreate As New Company(True)
        ccreate.ShowDialog()

    End Sub

    Private Sub SalesOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrderToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSO Is Nothing OrElse SalesInvoiceFormSO.IsDisposed Then
            SalesInvoiceFormSO = New SalesInvoiceAllFormControl("SO")
            SalesInvoiceFormSO.MdiParent = Me
            SalesInvoiceFormSO.BringToFront()
            SalesInvoiceFormSO.Dock = DockStyle.Fill
            SalesInvoiceFormSO.Show()
            SalesInvoiceFormSO.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSO.MdiParent = Me
            SalesInvoiceFormSO.Dock = DockStyle.Fill
            SalesInvoiceFormSO.Show()
            SalesInvoiceFormSO.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PriceListToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        PriceList.SuspendLayout()
        PriceList.MdiParent = Me
        PriceList.Dock = DockStyle.Fill
        PriceList.Show()
        PriceList.WindowState = FormWindowState.Maximized
        PriceList.BringToFront()
        PriceList.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        AppLogout()
    End Sub
    Public Sub AppLogout()
        If MsgBox("Do you want to Exit ?       ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        UpdateUserLogOff()
        Dim frm As New backupdatabase
        frm.ShowDialog()
        End
    End Sub

    Private Sub DevelaryNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoiceToolStripMenuItem.Click
        If MyAppSettings.IsAllowDeliveryNote = False Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SalesInvoiceFormPOS Is Nothing OrElse SalesInvoiceFormPOS.IsDisposed Then

                SalesInvoiceFormPOS = New SalesInvoiceAllFormControl("POS", True)
                SalesInvoiceFormPOS.MdiParent = Me
                SalesInvoiceFormPOS.BringToFront()
                SalesInvoiceFormPOS.Dock = DockStyle.Fill
                SalesInvoiceFormPOS.Show()
                SalesInvoiceFormPOS.WindowState = FormWindowState.Maximized
            Else
                SalesInvoiceFormPOS.MdiParent = Me
                SalesInvoiceFormPOS.Dock = DockStyle.Fill
                SalesInvoiceFormPOS.Show()
                SalesInvoiceFormPOS.BringToFront()
            End If
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If SalesInvoiceFormSI Is Nothing OrElse SalesInvoiceFormSI.IsDisposed Then
                SalesInvoiceFormSI = New SalesInvoiceAllFormControl("SI")
                SalesInvoiceFormSI.MdiParent = Me
                SalesInvoiceFormSI.BringToFront()
                SalesInvoiceFormSI.Dock = DockStyle.Fill
                SalesInvoiceFormSI.Show()
                SalesInvoiceFormSI.WindowState = FormWindowState.Maximized
            Else
                SalesInvoiceFormSI.MdiParent = Me
                SalesInvoiceFormSI.Dock = DockStyle.Fill
                SalesInvoiceFormSI.Show()
                SalesInvoiceFormSI.BringToFront()
            End If
            Me.Cursor = Cursors.Default
        End If

    End Sub



    Private Sub QuickTaskList_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MyAppOpenedFormsList.DropDownItemClicked
        Try
            For Each f As Form In My.Application.OpenForms
                If f.Equals(Me) = False Then
                    If UCase(f.Text) = UCase(e.ClickedItem.Text) Then
                        f.BringToFront()
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripDropDownButton1_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyAppOpenedFormsList.DropDownOpening
        MyAppOpenedFormsList.DropDownItems.Clear()
        Try
            For Each f As Form In My.Application.OpenForms
                If f.Equals(Me) = False Then
                    MyAppOpenedFormsList.DropDownItems.Add(f.Text)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub StockJournalVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockJournalVoucherToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockJournalFrm.SuspendLayout()
        StockJournalFrm.MdiParent = Me
        StockJournalFrm.Dock = DockStyle.Fill
        StockJournalFrm.Show()
        StockJournalFrm.WindowState = FormWindowState.Maximized
        StockJournalFrm.BringToFront()
        StockJournalFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ListOfCurrenciesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfCurrenciesToolStripMenuItem.Click

    End Sub

    Private Sub ExchangeRateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExchangeRateToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CurrencyExchageRates.SuspendLayout()
        CurrencyExchageRates.MdiParent = Me
        CurrencyExchageRates.Dock = DockStyle.Fill
        CurrencyExchageRates.Show()
        CurrencyExchageRates.WindowState = FormWindowState.Maximized
        CurrencyExchageRates.BringToFront()
        CurrencyExchageRates.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub ACReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACReportsToolStripMenuItem.Click

    End Sub

    Private Sub CompanyToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyToolsToolStripMenuItem.Click
        Dim k As New AlterCompany
        k.ShowDialog()
    End Sub

    Private Sub LedgerAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerAccountsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
            LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
            LedgersBalaceReportFrom.MdiParent = Me
            LedgersBalaceReportFrom.BringToFront()
            LedgersBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.CashAccounts
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            LedgersBalaceReportFrom.MdiParent = Me
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow

    End Sub



    Private Sub DayBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        DaybookReportFrm.SuspendLayout()
        DaybookReportFrm.MdiParent = Me
        DaybookReportFrm.Dock = DockStyle.Fill
        DaybookReportFrm.Show()
        DaybookReportFrm.WindowState = FormWindowState.Maximized
        DaybookReportFrm.BringToFront()
        DaybookReportFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub InvoicePrintingSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoicePrintingSettingsToolStripMenuItem.Click, ToolStripMenuItem63.Click
        Dim k As New InvoicePriningSettings
        k.ShowDialog()
    End Sub

    Private Sub CompanySettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanySettingsToolStripMenuItem.Click
        Dim k As New InventorySettings
        k.ShowDialog()
    End Sub

    Private Sub SalesReturnsCreditNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub POSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CustomBarcodeSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomBarcodeSettingsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CustomBarcodeEntry.SuspendLayout()
        CustomBarcodeEntry.MdiParent = Me
        CustomBarcodeEntry.Dock = DockStyle.Fill
        CustomBarcodeEntry.Show()
        CustomBarcodeEntry.WindowState = FormWindowState.Maximized
        CustomBarcodeEntry.BringToFront()
        CustomBarcodeEntry.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrdersToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SalesOrderList.SuspendLayout()
        SalesOrderList.MdiParent = Me
        SalesOrderList.Dock = DockStyle.Fill
        SalesOrderList.Show()
        SalesOrderList.WindowState = FormWindowState.Maximized
        SalesOrderList.BringToFront()
        SalesOrderList.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesQuotationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesQuotationsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSQReportForm Is Nothing OrElse SalesSQReportForm.IsDisposed Then
            SalesSQReportForm = New SalesTransactionReports("SQ")
            SalesSQReportForm.MdiParent = Me
            SalesSQReportForm.BringToFront()
            SalesSQReportForm.Dock = DockStyle.Fill
            SalesSQReportForm.Show()
            SalesSQReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSQReportForm.MdiParent = Me
            SalesSQReportForm.Dock = DockStyle.Fill
            SalesSQReportForm.Show()
            SalesSQReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SalesOrdersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrdersToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSOReportForm Is Nothing OrElse SalesSOReportForm.IsDisposed Then
            SalesSOReportForm = New SalesTransactionReports("SO")
            SalesSOReportForm.MdiParent = Me
            SalesSOReportForm.BringToFront()
            SalesSOReportForm.Dock = DockStyle.Fill
            SalesSOReportForm.Show()
            SalesSOReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSOReportForm.MdiParent = Me
            SalesSOReportForm.Dock = DockStyle.Fill
            SalesSOReportForm.Show()
            SalesSOReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SalesDeliveriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalesInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub POSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalesReturnInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub PurchaseEnquryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseEnquryToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePQReportForm Is Nothing OrElse PurchasePQReportForm.IsDisposed Then
            PurchasePQReportForm = New PurchaseTransactionReports("PQ")
            PurchasePQReportForm.MdiParent = Me
            PurchasePQReportForm.BringToFront()
            PurchasePQReportForm.Dock = DockStyle.Fill
            PurchasePQReportForm.Show()
            PurchasePQReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePQReportForm.MdiParent = Me
            PurchasePQReportForm.Dock = DockStyle.Fill
            PurchasePQReportForm.Show()
            PurchasePQReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PurchaseOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrdersToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePOReportForm Is Nothing OrElse PurchasePOReportForm.IsDisposed Then
            PurchasePOReportForm = New PurchaseTransactionReports("PO")
            PurchasePOReportForm.MdiParent = Me
            PurchasePOReportForm.BringToFront()
            PurchasePOReportForm.Dock = DockStyle.Fill
            PurchasePOReportForm.Show()
            PurchasePOReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePOReportForm.MdiParent = Me
            PurchasePOReportForm.Dock = DockStyle.Fill
            PurchasePOReportForm.Show()
            PurchasePOReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub DepartmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartmentsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Departments.SuspendLayout()
        Departments.MdiParent = Me
        Departments.Dock = DockStyle.Fill
        Departments.Show()
        Departments.WindowState = FormWindowState.Maximized
        Departments.BringToFront()
        Departments.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Employees.SuspendLayout()
        Employees.MdiParent = Me
        Employees.Dock = DockStyle.Fill
        Employees.Show()
        Employees.WindowState = FormWindowState.Maximized
        Employees.BringToFront()
        Employees.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub PayRollVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayRollVoucherToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        PayrollMultiVoucher.SuspendLayout()
        PayrollMultiVoucher.MdiParent = Me
        PayrollMultiVoucher.Dock = DockStyle.Fill
        PayrollMultiVoucher.Show()
        PayrollMultiVoucher.WindowState = FormWindowState.Maximized
        PayrollMultiVoucher.BringToFront()
        PayrollMultiVoucher.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub WPSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WPSToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        WPS.SuspendLayout()
        WPS.MdiParent = Me
        WPS.Dock = DockStyle.Fill
        WPS.Show()
        WPS.WindowState = FormWindowState.Maximized
        WPS.BringToFront()
        WPS.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub LOGOUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGOUTToolStripMenuItem.Click
        AppLogout()
    End Sub

    Private Sub BillingOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingOptionsToolStripMenuItem.Click, ToolStripMenuItem60.Click
        InvoiceOptions.ShowDialog()
    End Sub






    Private Sub QuotationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPQ Is Nothing OrElse PurchaseInvoiceFormPQ.IsDisposed Then
            PurchaseInvoiceFormPQ = New PurchaseInvoiceAllFromControl("PQ")
            PurchaseInvoiceFormPQ.MdiParent = Me
            PurchaseInvoiceFormPQ.BringToFront()
            PurchaseInvoiceFormPQ.Dock = DockStyle.Fill
            PurchaseInvoiceFormPQ.Show()
            PurchaseInvoiceFormPQ.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPQ.MdiParent = Me
            PurchaseInvoiceFormPQ.Dock = DockStyle.Fill
            PurchaseInvoiceFormPQ.Show()
            PurchaseInvoiceFormPQ.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub InvoiceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoiceToolStripMenuItem1.Click
        If MyAppSettings.IsAllowGReceiptNote = False Then
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If PurchaseInvoiceFormPI Is Nothing OrElse PurchaseInvoiceFormPI.IsDisposed Then
                PurchaseInvoiceFormPI = New PurchaseInvoiceAllFromControl("DP")
                PurchaseInvoiceFormPI.MdiParent = Me
                PurchaseInvoiceFormPI.BringToFront()
                PurchaseInvoiceFormPI.Dock = DockStyle.Fill
                PurchaseInvoiceFormPI.Show()
                PurchaseInvoiceFormPI.WindowState = FormWindowState.Maximized
            Else
                PurchaseInvoiceFormPI.MdiParent = Me
                PurchaseInvoiceFormPI.Dock = DockStyle.Fill
                PurchaseInvoiceFormPI.Show()
                PurchaseInvoiceFormPI.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        Else
            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            If PurchaseInvoiceFormPI Is Nothing OrElse PurchaseInvoiceFormPI.IsDisposed Then
                PurchaseInvoiceFormPI = New PurchaseInvoiceAllFromControl("PI")
                PurchaseInvoiceFormPI.MdiParent = Me
                PurchaseInvoiceFormPI.BringToFront()
                PurchaseInvoiceFormPI.Dock = DockStyle.Fill
                PurchaseInvoiceFormPI.Show()
                PurchaseInvoiceFormPI.WindowState = FormWindowState.Maximized
            Else
                PurchaseInvoiceFormPI.MdiParent = Me
                PurchaseInvoiceFormPI.Dock = DockStyle.Fill
                PurchaseInvoiceFormPI.Show()
                PurchaseInvoiceFormPI.BringToFront()
            End If
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub DeleveryNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PurchaseReturnsDebitNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPO Is Nothing OrElse PurchaseInvoiceFormPO.IsDisposed Then
            PurchaseInvoiceFormPO = New PurchaseInvoiceAllFromControl("PO")
            PurchaseInvoiceFormPO.MdiParent = Me
            PurchaseInvoiceFormPO.BringToFront()
            PurchaseInvoiceFormPO.Dock = DockStyle.Fill
            PurchaseInvoiceFormPO.Show()
            PurchaseInvoiceFormPO.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPO.MdiParent = Me
            PurchaseInvoiceFormPO.Dock = DockStyle.Fill
            PurchaseInvoiceFormPO.Show()
            PurchaseInvoiceFormPO.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub





    Private Sub SalesDeliveryNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveryNoteToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSD Is Nothing OrElse SalesInvoiceFormSD.IsDisposed Then
            SalesInvoiceFormSD = New SalesInvoiceAllFormControl("SD")
            SalesInvoiceFormSD.MdiParent = Me
            SalesInvoiceFormSD.BringToFront()
            SalesInvoiceFormSD.Dock = DockStyle.Fill
            SalesInvoiceFormSD.Show()
            SalesInvoiceFormSD.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSD.MdiParent = Me
            SalesInvoiceFormSD.Dock = DockStyle.Fill
            SalesInvoiceFormSD.Show()
            SalesInvoiceFormSD.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesReturnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PurchaseGoodsReceiptNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseGoodsReceiptNoteToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPG Is Nothing OrElse PurchaseInvoiceFormPG.IsDisposed Then
            PurchaseInvoiceFormPG = New PurchaseInvoiceAllFromControl("PG")
            PurchaseInvoiceFormPG.MdiParent = Me
            PurchaseInvoiceFormPG.BringToFront()
            PurchaseInvoiceFormPG.Dock = DockStyle.Fill
            PurchaseInvoiceFormPG.Show()
            PurchaseInvoiceFormPG.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPG.MdiParent = Me
            PurchaseInvoiceFormPG.Dock = DockStyle.Fill
            PurchaseInvoiceFormPG.Show()
            PurchaseInvoiceFormPG.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub PurchaseOrdersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrdersToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        PurchaseOrdersList.SuspendLayout()
        PurchaseOrdersList.MdiParent = Me
        PurchaseOrdersList.Dock = DockStyle.Fill
        PurchaseOrdersList.Show()
        PurchaseOrdersList.WindowState = FormWindowState.Maximized
        PurchaseOrdersList.BringToFront()
        PurchaseOrdersList.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TenMinuteTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TenMinuteTimer.Tick
        AppDateTime.Text = "Date && Time:" & Now
        ' TenMinuteTimer.Enabled = False
    End Sub

    Private Sub SalesOrdersDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrdersDetailsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        OrderSummeryForm.SuspendLayout()
        OrderSummeryForm.MdiParent = Me
        OrderSummeryForm.Dock = DockStyle.Fill
        OrderSummeryForm.Show()
        OrderSummeryForm.WindowState = FormWindowState.Maximized
        OrderSummeryForm.BringToFront()
        OrderSummeryForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PurchaseOrdersDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrdersDetailsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        PendingPuchaseOrderForm.SuspendLayout()
        PendingPuchaseOrderForm.MdiParent = Me
        '  PurchaseOrdersList.IsShowItemWise.Checked = True
        PendingPuchaseOrderForm.Dock = DockStyle.Fill
        PendingPuchaseOrderForm.Show()
        PendingPuchaseOrderForm.WindowState = FormWindowState.Maximized
        PendingPuchaseOrderForm.BringToFront()
        PendingPuchaseOrderForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CustomersBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SuppliersBalancesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AccountBalancesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CashBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgerAccountReportFormForCashBook Is Nothing OrElse LedgerAccountReportFormForCashBook.IsDisposed Then
            LedgerAccountReportFormForCashBook = New LedgerAccountReportForm("", AccountGroupNames.CashAccounts)
            LedgerAccountReportFormForCashBook.MdiParent = Me
            LedgerAccountReportFormForCashBook.BringToFront()
            LedgerAccountReportFormForCashBook.Dock = DockStyle.Fill
            LedgerAccountReportFormForCashBook.Show()
            LedgerAccountReportFormForCashBook.WindowState = FormWindowState.Maximized
        Else
            LedgerAccountReportFormForCashBook.MdiParent = Me
            LedgerAccountReportFormForCashBook.Dock = DockStyle.Fill
            LedgerAccountReportFormForCashBook.Show()
            LedgerAccountReportFormForCashBook.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EmailSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailSettingsToolStripMenuItem.Click, ToolStripMenuItem70.Click
        Dim k As New EmailSettings
        k.ShowDialog()

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim k As New ChangePassword(CurrentUserName, True)
            k.ShowDialog()
        End If
    End Sub

    Private Sub ChangeRecoveryOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeRecoveryOptionsToolStripMenuItem.Click

        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ChangeRecoveryOptions.ShowDialog()
        End If
    End Sub

    Private Sub ChangeRecoveryOptionsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeRecoveryOptionsToolStripMenuItem1.Click
        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ChangeRecoveryOptions.ShowDialog()
        End If
    End Sub

    Private Sub ChnagePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChnagePasswordToolStripMenuItem.Click
        ConfirmPassword.PasswordTextBox.Text = ""
        If ConfirmPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim k As New ChangePassword(CurrentUserName, True)
            k.ShowDialog()
        End If
    End Sub

    Private Sub POSToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()

        If POSfrm Is Nothing OrElse POSfrm.IsDisposed Then
            POSfrm = New POS
            POSfrm.MdiParent = Me
            POSfrm.BringToFront()
            POSfrm.Dock = DockStyle.Fill
            POSfrm.Show()
            POSfrm.WindowState = FormWindowState.Maximized
        Else
            POSfrm.MdiParent = Me
            POSfrm.Dock = DockStyle.Fill
            POSfrm.Show()
            POSfrm.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesReturnsCreditNoteToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnsCreditNoteToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSR Is Nothing OrElse SalesInvoiceFormSR.IsDisposed Then
            SalesInvoiceFormSR = New SalesInvoiceAllFormControl("SR", , , True)
            SalesInvoiceFormSR.MdiParent = Me
            SalesInvoiceFormSR.BringToFront()
            SalesInvoiceFormSR.Dock = DockStyle.Fill
            SalesInvoiceFormSR.Show()
            SalesInvoiceFormSR.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSR.MdiParent = Me
            SalesInvoiceFormSR.Dock = DockStyle.Fill
            SalesInvoiceFormSR.Show()
            SalesInvoiceFormSR.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PurchaseReturnsDebitNoteToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnsDebitNoteToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPR Is Nothing OrElse PurchaseInvoiceFormPR.IsDisposed Then
            PurchaseInvoiceFormPR = New PurchaseInvoiceAllFromControl("PR")
            PurchaseInvoiceFormPR.MdiParent = Me
            PurchaseInvoiceFormPR.BringToFront()
            PurchaseInvoiceFormPR.Dock = DockStyle.Fill
            PurchaseInvoiceFormPR.Show()
            PurchaseInvoiceFormPR.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPR.MdiParent = Me
            PurchaseInvoiceFormPR.Dock = DockStyle.Fill
            PurchaseInvoiceFormPR.Show()
            PurchaseInvoiceFormPR.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub AppCalculator_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AppCalculator.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If AppCalculator.Calculate(sender.Text) = -99999999999 Then
                MsgBox("Invalid  Expression, Please Try Again......                   ", MsgBoxStyle.Information, "Error Information")
            Else
                sender.Text = AppCalculator.Calculate(sender.Text)
            End If
            AppCalculator.Focus()
        End If

    End Sub


    Private Sub IncommingStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OutgoingStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub StockSummeryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSummeryToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        stocksummery.SuspendLayout()
        stocksummery.MdiParent = Me
        stocksummery.Dock = DockStyle.Fill
        stocksummery.Show()
        stocksummery.WindowState = FormWindowState.Maximized
        stocksummery.BringToFront()
        stocksummery.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockRepForm Is Nothing OrElse StockRepForm.IsDisposed Then
            StockRepForm = New StockItemwiseReport()
            StockRepForm.MdiParent = Me
            StockRepForm.BringToFront()
            StockRepForm.Dock = DockStyle.Fill
            StockRepForm.Show()
            StockRepForm.WindowState = FormWindowState.Maximized
        Else
            StockRepForm.MdiParent = Me
            StockRepForm.Dock = DockStyle.Fill
            StockRepForm.Show()
            StockRepForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub StockItemReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockItemReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockRepForm Is Nothing OrElse StockRepForm.IsDisposed Then
            StockRepForm = New StockItemwiseReport()
            StockRepForm.MdiParent = Me
            StockRepForm.BringToFront()
            StockRepForm.Dock = DockStyle.Fill
            StockRepForm.Show()
            StockRepForm.WindowState = FormWindowState.Maximized
        Else
            StockRepForm.MdiParent = Me
            StockRepForm.Dock = DockStyle.Fill
            StockRepForm.Show()
            StockRepForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub StockSummeryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSummeryToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        stocksummery.SuspendLayout()
        stocksummery.MdiParent = Me
        stocksummery.Dock = DockStyle.Fill
        stocksummery.Show()
        stocksummery.WindowState = FormWindowState.Maximized
        stocksummery.BringToFront()
        stocksummery.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FinanicalReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RecycleBin.SuspendLayout()
        RecycleBin.MdiParent = Me
        RecycleBin.Dock = DockStyle.Fill
        RecycleBin.Show()
        RecycleBin.WindowState = FormWindowState.Maximized
        RecycleBin.BringToFront()
        RecycleBin.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ChequePriningSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChequePriningSettingsToolStripMenuItem.Click, ToolStripMenuItem64.Click
        Dim k As New CheckPrintingSettings
        k.ShowDialog()
    End Sub

    Private Sub AccountAuditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountAuditToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        AuditForm.SuspendLayout()
        AuditForm.MdiParent = Me
        AuditForm.Dock = DockStyle.Fill
        AuditForm.Show()
        AuditForm.WindowState = FormWindowState.Maximized
        AuditForm.BringToFront()
        AuditForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub OverdueReceivToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OverDuePayablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MovementAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovementAnalysisToolStripMenuItem.Click

    End Sub

    Private Sub ByStockGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByStockGroupToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        MovementAnanlysisbyStockGroupWise.SuspendLayout()
        MovementAnanlysisbyStockGroupWise.MdiParent = Me
        MovementAnanlysisbyStockGroupWise.Dock = DockStyle.Fill
        MovementAnanlysisbyStockGroupWise.Show()
        MovementAnanlysisbyStockGroupWise.WindowState = FormWindowState.Maximized
        MovementAnanlysisbyStockGroupWise.BringToFront()
        MovementAnanlysisbyStockGroupWise.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ByStockItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByStockItemToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockMovementAnalysis.SuspendLayout()
        StockMovementAnalysis.MdiParent = Me
        StockMovementAnalysis.Dock = DockStyle.Fill
        StockMovementAnalysis.Show()
        StockMovementAnalysis.WindowState = FormWindowState.Maximized
        StockMovementAnalysis.BringToFront()
        StockMovementAnalysis.ResumeLayout()
        StockMovementAnalysis.BringToFront()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ProfitLossAcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub balancesheet_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub VoucherPrintingSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherPrintingSettingsToolStripMenuItem.Click, ToolStripMenuItem65.Click
        Dim k As New VoucherPrintingSettings
        k.ShowDialog()
    End Sub

    Private Sub ReorderStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReorderStatusToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ReorderForm.SuspendLayout()
        ReorderForm.MdiParent = Me
        ReorderForm.Dock = DockStyle.Fill
        ReorderForm.Show()
        ReorderForm.WindowState = FormWindowState.Maximized
        ReorderForm.BringToFront()
        ReorderForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LedgerAccountsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerAccountsToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgerAccountsBalanceForm Is Nothing OrElse LedgerAccountsBalanceForm.IsDisposed Then
            LedgerAccountsBalanceForm = New LedgerTransactionsReportForm()
            LedgerAccountsBalanceForm.MdiParent = Me
            LedgerAccountsBalanceForm.BringToFront()
            LedgerAccountsBalanceForm.Dock = DockStyle.Fill
            LedgerAccountsBalanceForm.Show()
            LedgerAccountsBalanceForm.WindowState = FormWindowState.Maximized
        Else
            LedgerAccountsBalanceForm.MdiParent = Me
            LedgerAccountsBalanceForm.Dock = DockStyle.Fill
            LedgerAccountsBalanceForm.Show()
            LedgerAccountsBalanceForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CurrentStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentStockToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim currentstockfrm As New CurrentStockItemReport
        currentstockfrm.SuspendLayout()
        currentstockfrm.MdiParent = Me
        currentstockfrm.Dock = DockStyle.Fill
        currentstockfrm.Show()
        currentstockfrm.WindowState = FormWindowState.Maximized
        currentstockfrm.BringToFront()
        currentstockfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub EmployeeLeavesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeLeavesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmpLeaveManagement.SuspendLayout()
        EmpLeaveManagement.MdiParent = Me
        EmpLeaveManagement.Dock = DockStyle.Fill
        EmpLeaveManagement.Show()
        EmpLeaveManagement.WindowState = FormWindowState.Maximized
        EmpLeaveManagement.BringToFront()
        EmpLeaveManagement.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntryToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmpAttendenceEntry.SuspendLayout()
        EmpAttendenceEntry.MdiParent = Me
        EmpAttendenceEntry.Dock = DockStyle.Fill
        EmpAttendenceEntry.Show()
        EmpAttendenceEntry.WindowState = FormWindowState.Maximized
        EmpAttendenceEntry.BringToFront()
        EmpAttendenceEntry.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripMenuItem.Click
        Dim K As New loginagain
        Me.Visible = False
        K.Show()

    End Sub

    Private Sub AttendenceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendenceSheetToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeAttendenceSheet.SuspendLayout()
        EmployeeAttendenceSheet.MdiParent = Me
        EmployeeAttendenceSheet.Dock = DockStyle.Fill
        EmployeeAttendenceSheet.Show()
        EmployeeAttendenceSheet.WindowState = FormWindowState.Maximized
        EmployeeAttendenceSheet.BringToFront()
        EmployeeAttendenceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default

        'Me.Cursor = Cursors.WaitCursor
        'Attendence.SuspendLayout()
        'Attendence.MdiParent = Me
        'Attendence.Dock = DockStyle.Fill
        'Attendence.Show()
        'Attendence.WindowState = FormWindowState.Maximized
        'Attendence.BringToFront()
        'Attendence.ResumeLayout()
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub CashBookToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If CashBookFrm Is Nothing OrElse CashBookFrm.IsDisposed Then
            CashBookFrm = New LedgerTransactionsReportForm(IIf(DefLedgers.CashAccount = Nothing, "", DefLedgers.CashAccount))
            CashBookFrm.MdiParent = Me
            CashBookFrm.BringToFront()
            CashBookFrm.Dock = DockStyle.Fill
            CashBookFrm.IsCashBookReport = True
            CashBookFrm.Show()
            CashBookFrm.WindowState = FormWindowState.Maximized
        Else
            CashBookFrm.MdiParent = Me
            CashBookFrm.Dock = DockStyle.Fill
            CashBookFrm.Show()
            CashBookFrm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BankBooksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankBooksToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If BankBookFrm Is Nothing OrElse BankBookFrm.IsDisposed Then
            BankBookFrm = New LedgerTransactionsReportForm(IIf(DefLedgers.BankAccount = Nothing, "", DefLedgers.BankAccount))
            BankBookFrm.MdiParent = Me
            BankBookFrm.BringToFront()
            BankBookFrm.Dock = DockStyle.Fill
            BankBookFrm.IsBankBookReport = True
            BankBookFrm.Show()
            BankBookFrm.WindowState = FormWindowState.Maximized
        Else
            BankBookFrm.MdiParent = Me
            BankBookFrm.Dock = DockStyle.Fill
            BankBookFrm.Show()
            BankBookFrm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub







    Private Sub PDCClearanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDCClearanceToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        PDCForm.SuspendLayout()
        PDCForm.MdiParent = Me
        PDCForm.Dock = DockStyle.Fill
        PDCForm.Show()
        PDCForm.WindowState = FormWindowState.Maximized
        PDCForm.BringToFront()
        PDCForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MenuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuHelp.Click

    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Users.SuspendLayout()
        Users.MdiParent = Me
        Users.Dock = DockStyle.Fill
        Users.Show()
        Users.WindowState = FormWindowState.Maximized
        Users.BringToFront()
        Users.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UsersLogInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersLogInfoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        UserLogInfo.SuspendLayout()
        UserLogInfo.MdiParent = Me
        UserLogInfo.Dock = DockStyle.Fill
        UserLogInfo.Show()
        UserLogInfo.WindowState = FormWindowState.Maximized
        UserLogInfo.BringToFront()
        UserLogInfo.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ActiveUsersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiveUsersToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        ActiveLoginUsersInfo.SuspendLayout()
        ActiveLoginUsersInfo.MdiParent = Me
        ActiveLoginUsersInfo.Dock = DockStyle.Fill
        ActiveLoginUsersInfo.Show()
        ActiveLoginUsersInfo.WindowState = FormWindowState.Maximized
        ActiveLoginUsersInfo.BringToFront()
        ActiveLoginUsersInfo.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub UsersActivitiesLogFileToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersActivitiesLogFileToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        UserActivities.SuspendLayout()
        UserActivities.MdiParent = Me
        UserActivities.Dock = DockStyle.Fill
        UserActivities.Show()
        UserActivities.WindowState = FormWindowState.Maximized
        UserActivities.BringToFront()
        UserActivities.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReportPrintingOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportPrintingOptionsToolStripMenuItem.Click, ToolStripMenuItem66.Click
        Dim frm As New CrPrintingOptions
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub DayBookCrystalReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookCrystalReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Daybook.SuspendLayout()
        Daybook.MdiParent = Me
        Daybook.Dock = DockStyle.Fill
        Daybook.Show()
        Daybook.WindowState = FormWindowState.Maximized
        Daybook.BringToFront()
        Daybook.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PayCalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayCalculatorToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmpGratuityReport.SuspendLayout()
        EmpGratuityReport.MdiParent = Me
        EmpGratuityReport.Dock = DockStyle.Fill
        EmpGratuityReport.Show()
        EmpGratuityReport.WindowState = FormWindowState.Maximized
        EmpGratuityReport.BringToFront()
        EmpGratuityReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EmployeeSalaryHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeSalaryHistoryToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If empshistryfrm Is Nothing OrElse empshistryfrm.IsDisposed Then
            empshistryfrm = New EmpSalaryHistory
            empshistryfrm.MdiParent = Me
            empshistryfrm.BringToFront()
            empshistryfrm.Dock = DockStyle.Fill
            empshistryfrm.Show()
            empshistryfrm.WindowState = FormWindowState.Maximized
        Else
            empshistryfrm.MdiParent = Me
            empshistryfrm.Dock = DockStyle.Fill
            empshistryfrm.Show()
            empshistryfrm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub GratuityReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GratuityReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmpGratuityReport.SuspendLayout()
        EmpGratuityReport.MdiParent = Me
        EmpGratuityReport.Dock = DockStyle.Fill
        EmpGratuityReport.Show()
        EmpGratuityReport.WindowState = FormWindowState.Maximized
        EmpGratuityReport.BringToFront()
        EmpGratuityReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub BarcodeAttendenceRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeAttendenceRegisterToolStripMenuItem1.Click
        Me.Visible = False
        Dim k As New barcodeattendence
        k.ShowDialog()
        Me.Visible = True
    End Sub

    Private Sub BarcodeSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeSettingsToolStripMenuItem.Click
        Dim k As New empbarcodeSettings
        k.ShowDialog()
    End Sub




    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Dim frm As New backupdatabase
        frm.ShowDialog()
    End Sub






    Private Sub SuppliersBalancesReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub EmployeeIDMonitorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeIDMonitorToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeIDMonitor.SuspendLayout()
        EmployeeIDMonitor.MdiParent = Me
        EmployeeIDMonitor.Dock = DockStyle.Fill
        EmployeeIDMonitor.Show()
        EmployeeIDMonitor.WindowState = FormWindowState.Maximized
        EmployeeIDMonitor.BringToFront()
        EmployeeIDMonitor.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MaintainDocumentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaintainDocumentsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CompanyDocs.SuspendLayout()
        CompanyDocs.MdiParent = Me
        CompanyDocs.Dock = DockStyle.Fill
        CompanyDocs.Show()
        CompanyDocs.WindowState = FormWindowState.Maximized
        CompanyDocs.BringToFront()
        CompanyDocs.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DocumentMonitorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentMonitorToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        DocIDMonitor.SuspendLayout()
        DocIDMonitor.MdiParent = Me
        DocIDMonitor.Dock = DockStyle.Fill
        DocIDMonitor.Show()
        DocIDMonitor.WindowState = FormWindowState.Maximized
        DocIDMonitor.BringToFront()
        DocIDMonitor.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MaintainVehiclesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaintainVehiclesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VehicleFrm.SuspendLayout()
        VehicleFrm.MdiParent = Me
        VehicleFrm.Dock = DockStyle.Fill
        VehicleFrm.Show()
        VehicleFrm.WindowState = FormWindowState.Maximized
        VehicleFrm.BringToFront()
        VehicleFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VehicleIDMonitorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehicleIDMonitorToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        VehicleIDMonitor.SuspendLayout()
        VehicleIDMonitor.MdiParent = Me
        VehicleIDMonitor.Dock = DockStyle.Fill
        VehicleIDMonitor.Show()
        VehicleIDMonitor.WindowState = FormWindowState.Maximized
        VehicleIDMonitor.BringToFront()
        VehicleIDMonitor.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesRegisterToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        MonthlySalesRegistorfrm.SuspendLayout()
        MonthlySalesRegistorfrm.MdiParent = Me
        MonthlySalesRegistorfrm.Dock = DockStyle.Fill
        MonthlySalesRegistorfrm.Show()
        MonthlySalesRegistorfrm.WindowState = FormWindowState.Maximized
        MonthlySalesRegistorfrm.BringToFront()
        MonthlySalesRegistorfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PurchaseRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRegisterToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        MonthlyPurchaseRegisterFrm.SuspendLayout()
        MonthlyPurchaseRegisterFrm.MdiParent = Me
        MonthlyPurchaseRegisterFrm.Dock = DockStyle.Fill
        MonthlyPurchaseRegisterFrm.Show()
        MonthlyPurchaseRegisterFrm.WindowState = FormWindowState.Maximized
        MonthlyPurchaseRegisterFrm.BringToFront()
        MonthlyPurchaseRegisterFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MonthlySalesRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        MonthlySalesRegistorfrm.SuspendLayout()
        MonthlySalesRegistorfrm.MdiParent = Me
        MonthlySalesRegistorfrm.Dock = DockStyle.Fill
        MonthlySalesRegistorfrm.Show()
        MonthlySalesRegistorfrm.WindowState = FormWindowState.Maximized
        MonthlySalesRegistorfrm.BringToFront()
        MonthlySalesRegistorfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub DutiesSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DutiesSettingsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CompanyDuties.SuspendLayout()
        CompanyDuties.MdiParent = Me
        CompanyDuties.Dock = DockStyle.Fill
        CompanyDuties.Show()
        CompanyDuties.WindowState = FormWindowState.Maximized
        CompanyDuties.BringToFront()
        CompanyDuties.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DutiesManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DutiesManagementToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dutyallotment.SuspendLayout()
        Dutyallotment.MdiParent = Me
        Dutyallotment.Dock = DockStyle.Fill
        Dutyallotment.Show()
        Dutyallotment.WindowState = FormWindowState.Maximized
        Dutyallotment.BringToFront()
        Dutyallotment.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub LeaveTypesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeaveTypesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        Leaves.SuspendLayout()
        Leaves.MdiParent = Me
        Leaves.Dock = DockStyle.Fill
        Leaves.Show()
        Leaves.WindowState = FormWindowState.Maximized
        Leaves.BringToFront()
        Leaves.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GratuitySettingsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GratuitySettingsToolStripMenuItem1.Click
        Dim k As New EmpGratuityCalculationMethods
        k.ShowDialog()
    End Sub

    Private Sub HolydaysToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HolydaysToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        CompanyLeaves.SuspendLayout()
        CompanyLeaves.MdiParent = Me
        CompanyLeaves.Dock = DockStyle.Fill
        CompanyLeaves.Show()
        CompanyLeaves.WindowState = FormWindowState.Maximized
        CompanyLeaves.BringToFront()
        CompanyLeaves.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AllowancesDeductionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllowancesDeductionsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        PayrollSalarySettings.SuspendLayout()
        PayrollSalarySettings.MdiParent = Me
        PayrollSalarySettings.Dock = DockStyle.Fill
        PayrollSalarySettings.Show()
        PayrollSalarySettings.WindowState = FormWindowState.Maximized
        PayrollSalarySettings.BringToFront()
        PayrollSalarySettings.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RatioAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AdminQueryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminQueryToolStripMenuItem.Click
        Dim kfrm As New QueryForm
        kfrm.ShowDialog()
        kfrm.Dispose()
    End Sub

    Private Sub TrailBalanceSheetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrailBalanceSheetToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor

        TrailBalanceSheet.SuspendLayout()
        TrailBalanceSheet.MdiParent = Me
        TrailBalanceSheet.Dock = DockStyle.Fill
        TrailBalanceSheet.Show()
        TrailBalanceSheet.WindowState = FormWindowState.Maximized
        TrailBalanceSheet.BringToFront()
        TrailBalanceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ProfitLossAcToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitLossAcToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ProfitandLossForm.SuspendLayout()
        ProfitandLossForm.MdiParent = Me
        ProfitandLossForm.Dock = DockStyle.Fill
        ProfitandLossForm.Show()
        ProfitandLossForm.WindowState = FormWindowState.Maximized
        ProfitandLossForm.BringToFront()
        ProfitandLossForm.ResumeLayout()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceSheetToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        BalanceSheet.SuspendLayout()
        BalanceSheet.MdiParent = Me
        BalanceSheet.Dock = DockStyle.Fill
        BalanceSheet.Show()
        BalanceSheet.WindowState = FormWindowState.Maximized
        BalanceSheet.BringToFront()
        BalanceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CashFlowToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashFlowToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        CashFlowFrm.SuspendLayout()
        CashFlowFrm.MdiParent = Me
        CashFlowFrm.Dock = DockStyle.Fill
        CashFlowFrm.Show()
        CashFlowFrm.WindowState = FormWindowState.Maximized
        CashFlowFrm.BringToFront()
        CashFlowFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FundFlowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FundFlowToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        FundFlowFrm.SuspendLayout()
        FundFlowFrm.MdiParent = Me
        FundFlowFrm.Dock = DockStyle.Fill
        FundFlowFrm.Show()
        FundFlowFrm.WindowState = FormWindowState.Maximized
        FundFlowFrm.BringToFront()
        FundFlowFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RatioAnalysisToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RatioAnalysisToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        AccountAnalysis.SuspendLayout()
        AccountAnalysis.MdiParent = Me
        AccountAnalysis.Dock = DockStyle.Fill
        AccountAnalysis.Show()
        AccountAnalysis.WindowState = FormWindowState.Maximized
        AccountAnalysis.BringToFront()
        AccountAnalysis.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AccountsReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountsReportsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
            LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
            LedgersBalaceReportFrom.MdiParent = Me
            LedgersBalaceReportFrom.BringToFront()
            LedgersBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.CashAccounts
            LedgersBalaceReportFrom.TxtHeading.Text = "CASH ACCOUNTS REPORT "
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            LedgersBalaceReportFrom.MdiParent = Me
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CostCentresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostCentresToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CostCentersNames.SuspendLayout()
        CostCentersNames.MdiParent = Me
        CostCentersNames.Dock = DockStyle.Fill
        CostCentersNames.Show()
        CostCentersNames.WindowState = FormWindowState.Maximized
        CostCentersNames.BringToFront()
        CostCentersNames.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub CostCenterReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CostCenterCotegoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostCenterCotegoriesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CostCenterCategories.SuspendLayout()
        CostCenterCategories.MdiParent = Me
        CostCenterCategories.Dock = DockStyle.Fill
        CostCenterCategories.Show()
        CostCenterCategories.WindowState = FormWindowState.Maximized
        CostCenterCategories.BringToFront()
        CostCenterCategories.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UpdateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateVersionMenuItem.Click
        If SQLIsFieldExists("SELECT TOP 1 1 from   INVOICESETTINGS WHERE VOUCHERNAME='F8'") = False Then
            ExecuteSQLQuery("INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8','MainLocation') ")
            ExecuteSQLQuery("INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8B','MainLocation') ")
            ExecuteSQLQuery("INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8D','MainLocation') ")
        End If
        UpdateVersionMenuItem.Visible = False
    End Sub
    Sub UpdateVersionDatabase()
        If CompDetails.CompanyVersionNumber < 11 Then
            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD [CDiscount] [float] NULL,[CouponName] [nvarchar](50) NULL,	[CDisCountPer] [float] NULL")
            ExecuteSQLQuery("CREATE TABLE  [couponmaster]( [Cname] [nvarchar](50) NULL,[cper] [float] NULL,[datefrom] [datetime] NULL,[dateto] [datetime] NULL,[MaxValues] [float] NULL,[UsedValue] [float] NULL,[MaxNoofUses] [float] NULL,[isActive] [bit] NULL,[Datefromvalue] [bigint] NULL,[DatetoValue] [bigint] NULL,[IsAllowOneTime] [bit] NULL) ON [PRIMARY]")
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET CDiscount=0,CouponName='',CDisCountPer=0")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=11")
            CompDetails.CompanyVersionNumber = 11
        End If
        If CompDetails.CompanyVersionNumber < 12 Then
            ExecuteSQLQuery("ALTER TABLE settings ADD [SalesPricewithTax] [bit] NULL,	[StockPricewithTax] [bit] NULL,[IsAllowEmptyBatchNo] [bit] NULL")
            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD  [sinvoiceno] [nvarchar](50) NULL,	[sinvoicedate] [datetime] NULL ")
            ExecuteSQLQuery("UPDATE settings SET SalesPricewithTax='False' , StockPricewithTax='False',IsAllowEmptyBatchNo='False'")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=12")
            CompDetails.CompanyVersionNumber = 12
        End If
        If CompDetails.CompanyVersionNumber < 13 Then
            ExecuteSQLQuery("CREATE TABLE [barcodesettings]([barcodelength] [int] NULL,[Isreplacezeros] [bit] NULL,[Isautofill] [bit] NULL,[FixedLength] [bit] NULL,[BarcodeType] [nvarchar](50) NULL) ON [PRIMARY] ")
            ExecuteSQLQuery("CREATE TABLE [barcodeprintimages] ([Schemename] [nvarchar](50) NULL,[imagewidth] [int] NULL,[imageHeight] [int] NULL,[LTop] [int] NULL,[Lleft] [int] NULL,[imagepath] [nvarchar](250) NULL,[Orderno] [int] NULL,[IsVisible] [bit] NULL,[Imagename] [nvarchar](50) NULL,[Rotate] [int] NULL) ON [PRIMARY] ")
            ExecuteSQLQuery("CREATE TABLE [barcodeprintlabels]([Schemename] [nvarchar](50) NULL,[Lwidth] [int] NULL,[LHeight] [int] NULL,[LTop] [int] NULL,[Lleft] [int] NULL,[DbName] [nvarchar](50) NULL,[LText] [nvarchar](50) NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[backcolor] [nvarchar](50) NULL,[Rotate] [int] NULL,[IsDbFiled] [int] NULL) ON [PRIMARY] ")
            ExecuteSQLQuery("CREATE TABLE [barcodePrintLines]([schemename] [nvarchar](50) NULL,[ltop] [int] NULL,[lleft] [int] NULL,[lwidth] [int] NULL,[lheight] [int] NULL,[fieldname] [nvarchar](75) NULL,[FieldType] [smallint] NULL,[LineColor] [nvarchar](50) NULL,[BoarderStyle] [nvarchar](50) NULL,[BoarderWidth] [int] NULL,[IsVisible] [bit] NULL,[fillcolor] [nvarchar](50) NULL,[Rotate] [int] NULL) ON [PRIMARY] ")
            ExecuteSQLQuery("CREATE TABLE [BarcodePrintSchemes]([Schemename] [nvarchar](50) NULL,[Barcodewidth] [int] NULL,[BarcodeHeight] [int] NULL,[Lwidth] [int] NULL,[LHeight] [int] NULL,[LTop] [int] NULL,[Lleft] [int] NULL,[LVgap] [int] NULL,[LHgap] [int] NULL,[nocolumns] [int] NULL,[barcodetype] [nvarchar](50) NULL,[papertype] [nvarchar](50) NULL,[BarcodeLeft] [int] NULL,[BarcodeTop] [int] NULL,[barcodeColor] [nvarchar](75) NULL,[Rotate] [int] NULL) ON [PRIMARY] ")
            ExecuteSQLQuery("ALTER TABLE EmailDb ADD [emailfooter] [nvarchar](550) NULL ,[IsSSL] [nvarchar](5) NULL ")
            ExecuteSQLQuery("UPDATE EmailDb SET emailfooter='',IsSSL='YES'")
            ExecuteSQLQuery("alter table SMSSettings alter column username [nvarchar](700)")
            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand
            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "SELECT distinct location FROM InvoiceSettings"
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                While Sreader.Read()
                    'ExecuteSQLQuery("INSERT INTO [InvoiceSettings] ([InvoiceNumber],[InvoicePreFix],[InvoicePostFix],[InvoiceMethod],[PrintonSave],[eachnarration],[PrintingScheme1],[PrintingScheme2],[PrintingScheme3],[F1],[F2],[N1],[N2],[AllowDuplicate],[VoucherName],[location])     VALUES (1,'','',1,0,0,'','','','','',0,0,0,'F8','" & Sreader("location").ToString & " ')")
                    'ExecuteSQLQuery("INSERT INTO [InvoiceSettings] ([InvoiceNumber],[InvoicePreFix],[InvoicePostFix],[InvoiceMethod],[PrintonSave],[eachnarration],[PrintingScheme1],[PrintingScheme2],[PrintingScheme3],[F1],[F2],[N1],[N2],[AllowDuplicate],[VoucherName],[location])     VALUES (1,'','',1,0,0,'','','','','',0,0,0,'F8B','" & Sreader("location").ToString & "')")
                    'ExecuteSQLQuery("INSERT INTO [InvoiceSettings] ([InvoiceNumber],[InvoicePreFix],[InvoicePostFix],[InvoiceMethod],[PrintonSave],[eachnarration],[PrintingScheme1],[PrintingScheme2],[PrintingScheme3],[F1],[F2],[N1],[N2],[AllowDuplicate],[VoucherName],[location])     VALUES (1,'','',1,0,0,'','','','','',0,0,0,'F8D','" & Sreader("location").ToString & "')")
                    ExecuteSQLQuery("INSERT INTO [InvoiceSettings] ([InvoiceNumber],[InvoicePreFix],[InvoicePostFix],[InvoiceMethod],[PrintonSave],[eachnarration],[PrintingScheme1],[PrintingScheme2],[PrintingScheme3],[F1],[F2],[N1],[N2],[AllowDuplicate],[VoucherName],[location])     VALUES (1,'','',1,0,0,'','','','','',0,0,0,'SRF8','" & Sreader("location").ToString & "')")
                    ExecuteSQLQuery("INSERT INTO [InvoiceSettings] ([InvoiceNumber],[InvoicePreFix],[InvoicePostFix],[InvoiceMethod],[PrintonSave],[eachnarration],[PrintingScheme1],[PrintingScheme2],[PrintingScheme3],[F1],[F2],[N1],[N2],[AllowDuplicate],[VoucherName],[location])     VALUES (1,'','',1,0,0,'','','','','',0,0,0,'SRF8B','" & Sreader("location").ToString & "')")
                    ExecuteSQLQuery("INSERT INTO [InvoiceSettings] ([InvoiceNumber],[InvoicePreFix],[InvoicePostFix],[InvoiceMethod],[PrintonSave],[eachnarration],[PrintingScheme1],[PrintingScheme2],[PrintingScheme3],[F1],[F2],[N1],[N2],[AllowDuplicate],[VoucherName],[location])     VALUES (1,'','',1,0,0,'','','','','',0,0,0,'SRF8D','" & Sreader("location").ToString & "')")
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
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=13")
            CompDetails.CompanyVersionNumber = 13
        End If
        If CompDetails.CompanyVersionNumber < 14 Then
            ExecuteSQLQuery("drop table stockserialnos ")
            ExecuteSQLQuery("drop table serialnumbermaster")
            ExecuteSQLQuery(" CREATE TABLE [stockserialnos]([StockCode] [nvarchar](75) NULL,[StockSize] [nvarchar](25) NULL,[SerialNumber] [nvarchar](50) NULL,[MFD] [datetime] NULL,[Narration] [nvarchar](150) NULL,[Status] [nvarchar](10) NULL,[transcode] [bigint] NULL,[vouchername] [nvarchar](5) NULL) ON [PRIMARY] ")
            ExecuteSQLQuery(" CREATE TABLE [serialnumbermaster]([STOCKCODE] [nvarchar](75) NULL,[STOCKSIZE] [nvarchar](75) NULL,[SERIALNUMBER] [nvarchar](50) NULL,[Note1] [nvarchar](150) NULL,[Note2] [nvarchar](150) NULL,[Status] [int] NULL,[MFD] [datetime] NULL,[purchasedate] [datetime] NULL,[expirydate] [datetime] NULL,[warrantydate] [datetime] NULL,[Guaranteedate] [datetime] NULL) ON [PRIMARY]")
            ExecuteSQLQuery("ALTER TABLE settings ADD [IsAllowMultiTax] [bit] NULL ")
            ExecuteSQLQuery("ALTER TABLE StockDbf ADD [Tax2] [float] NULL ")
            ExecuteSQLQuery("UPDATE StockDbf SET Tax2=0 ")
            ExecuteSQLQuery("ALTER TABLE StockInvoiceRowItems ADD [Tax2] [float] NULL,[TaxAmount2] [float] NULL ")
            ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET Tax2=0,TaxAmount2=0 ")
            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD [taxtotal2] [float] NULL ")
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET taxtotal2=0 ")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=14")
            CompDetails.CompanyVersionNumber = 14
        End If
        If CompDetails.CompanyVersionNumber < 15 Then
            ExecuteSQLQuery("ALTER TABLE settings ADD [customPrint] [bit] NULL ")
            ExecuteSQLQuery("update settings set customPrint='False'")
            ExecuteSQLQuery("ALTER TABLE company ADD [CstNo] [nvarchar](50) NULL ")
            ExecuteSQLQuery("ALTER TABLE stockdbf ADD [cst] [float] NULL ")
            ExecuteSQLQuery("update stockdbf set cst=0")
            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD [cstamount] [float] NULL,	[VoucherType] [nvarchar](20) NULL ")
            ExecuteSQLQuery("update StockInvoiceDetails set cstamount=0, VoucherType='Tax Invoice'")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=15")
            CompDetails.CompanyVersionNumber = 15
        End If

        If CompDetails.CompanyVersionNumber < 16 Then

            ExecuteSQLQuery("ALTER TABLE stockdbf ADD [IsTaxInclude] [bit] NULL ")
            ExecuteSQLQuery("update stockdbf set istaxinclude='True'")
            ExecuteSQLQuery("CREATE TABLE [images] (	[ImageData] [image] NULL,	[Bcode] [nvarchar](80) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=16")
            Dim SqlConn2 As New SqlClient.SqlConnection
            Dim SQLFcmd12 As New SqlClient.SqlCommand
            Dim Value As Double = 1
            Try
                SqlConn2.ConnectionString = ConnectionStrinG
                SqlConn2.Open()
                SQLFcmd12.Connection = SqlConn2
                SQLFcmd12.CommandText = "Select stockimagepath,custbarcode from STOCKDBF where location=N'" & GetDefLocationName() & "'"
                SQLFcmd12.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = SQLFcmd12.ExecuteReader
                While Sreader.Read()
                    If Sreader("stockimagepath").ToString.Length > 0 Then
                        Try
                            If File.Exists(Sreader("stockimagepath")) = True Then
                                InsertImageIntoDatabase(Sreader("stockimagepath"), "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", Sreader("CUSTBARCODE"), "DELETE FROM IMAGES WHERE BCODE=N'" & Sreader("CUSTBARCODE") & "'")
                            End If
                        Catch ex As Exception
                            Dim txtpic As New PictureBox
                            txtpic.Image = My.Resources.NOPIC
                            Try
                                InsertImageIntoDatabase(txtpic.Image, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", Sreader("CUSTBARCODE"), "DELETE FROM IMAGES WHERE BCODE=N'" & Sreader("CUSTBARCODE") & "'")
                            Catch ex3 As Exception

                            End Try
                        End Try
                    Else
                        Dim txtpic As New PictureBox
                        txtpic.Image = My.Resources.NOPIC
                        Try
                            InsertImageIntoDatabase(txtpic.Image, "imagedata", "bcode", "INSERT INTO [images] ([ImageData] ,[Bcode])  VALUES (@IMAGEDATA,@BCODE) ", Sreader("CUSTBARCODE"), "DELETE FROM IMAGES WHERE BCODE=N'" & Sreader("CUSTBARCODE") & "'")
                        Catch ex As Exception

                        End Try
                    End If

                End While
                Sreader.Close()
                Sreader = Nothing
            Catch ex As Exception

            Finally
                SqlConn2.Close()
                SQLFcmd12.Connection = Nothing
                SqlConn2.Dispose()
            End Try

            ExecuteSQLQuery("ALTER TABLE PrintRecords ADD [decimals] [int] NULL,[supress] [int] NULL ")
            ExecuteSQLQuery("UPDATE PrintRecords SET decimals=2,supress=0 ")

            ExecuteSQLQuery("ALTER TABLE PrintingDataRowsItems ADD [slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL ")
            ExecuteSQLQuery("UPDATE PrintingDataRowsItems SET slnos='2',Tax2=0 ,TaxAmount2=1225.2,FreeQty=2,FreeQtyText='1bag' ,FreeMQty='2',FreeMQtyText='2 bags'")

            ExecuteSQLQuery("ALTER TABLE PrintDataDetails ADD [taxtotal2] [float] NULL,[cstamount] [float] NULL,[VoucherType] [nvarchar](20) NULL,[BillCurrency] [nvarchar](8) NULL")
            ExecuteSQLQuery("UPDATE PrintDataDetails SET taxtotal2=2,cstamount=0 ,VoucherType='si',BillCurrency='INR'")
            'PrintRecords
        End If

        If CompDetails.CompanyVersionNumber < 17 Then
            ExecuteSQLQuery("ALTER TABLE settings ADD [ZerotaxonPurchase] [bit] NULL ")
            ExecuteSQLQuery("ALTER TABLE settings ADD [IsAllowMultiSalesTax] [bit] NULL ")
            ExecuteSQLQuery("ALTER TABLE settings ADD [MRPisAsSalesPrice] [bit] NULL ")
            ExecuteSQLQuery("UPDATE settings set ZerotaxonPurchase=0")
            ExecuteSQLQuery("ALTER TABLE  StockInvoiceRowItems ADD [FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL")
            ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET FreeQty=0,FreeMQty=TOTALQTY,FreeQtyText='',FreeMQtyText=QTYTEXT ")

            ExecuteSQLQuery("ALTER TABLE EmpAttend ADD [EStratTime] [datetime] NULL,[EEndTime] [datetime] NULL,[EStatus] [nvarchar](4) NULL,[TotalworkingMin] [int] NULL")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=17")

        End If
        If CompDetails.CompanyVersionNumber < 18 Then
            ExecuteSQLQuery("ALTER TABLE EmpAttend ADD [TickCount] [float] NULL,[Narration] [nvarchar](100) NULL ")
            ExecuteSQLQuery("update empattend set TickCount=1")
            'Vehicle
            ExecuteSQLQuery("ALTER TABLE Documents ADD [isCheckOut] [bit] NULL ")
            ExecuteSQLQuery("update Documents set ischeckout=0")
            ExecuteSQLQuery("ALTER TABLE Vehicle ADD [isCheckOut] [bit] NULL ")
            ExecuteSQLQuery("update Vehicle set ischeckout=0")

            ExecuteSQLQuery("CREATE TABLE [roundingsettings] ([AllowinPOS] [bit] NULL, [AllowinSalesInvoice] [bit] NULL,[AllowinPurchase] [bit] NULL,[AllowinPurchaseRet] [bit] NULL,[AllowinSalesRet] [bit] NULL,[AllowinDNote] [bit] NULL,[AllowinGnote] [bit] NULL) ON [PRIMARY]")
            ExecuteSQLQuery("INSERT INTO [roundingsettings]([AllowinPOS],[AllowinSalesInvoice],[AllowinPurchase],[AllowinPurchaseRet],[AllowinSalesRet],[AllowinDNote],[AllowinGnote])     VALUES(0,0,0,0,0,0,0)")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=18")

        End If
        '
        If CompDetails.CompanyVersionNumber < 19 Then
            ExecuteSQLQuery("ALTER TABLE documentissues ADD [checkoutdate] [datetime] NULL ")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=19")
        End If

        If CompDetails.CompanyVersionNumber < 20 Then
            ExecuteSQLQuery(" CREATE TABLE [empmsgs]([EmpMsgType] [nvarchar](50) NULL,[EmpMsgtext] [nvarchar](max) NULL,[subject] [nvarchar](200) NULL) ON [PRIMARY] ")
            ExecuteSQLQuery("ALTER TABLE Employees ADD [leavesalaryduedays] [bigint] NULL,[airticketduedays] [bigint] NULL,[leavesalaryfrom] [bigint] NULL,	[airticketfrom] [bigint] NULL,[NotifyDays] [int] NULL ")
            ExecuteSQLQuery("ALTER TABLE settings ADD  [DefPaymentMethodInSales] [nvarchar](50) NULL,[DefPaymentMethodinPurchase] [nvarchar](50) NULL ")
            ExecuteSQLQuery("UPDATE settings SET DefPaymentMethodInSales='Credit',DefPaymentMethodinPurchase='Credit' ")
            ExecuteSQLQuery("ALTER TABLE company ADD  [dateformattext] [nvarchar](50) NULL")
            ExecuteSQLQuery("UPDATE company SET dateformattext='dd/MM/yyyy'")
            ExecuteSQLQuery("UPDATE Employees SET leavesalaryduedays=0,airticketduedays=0,NotifyDays=30,leavesalaryfrom=" & Today.Date.ToOADate & ",airticketfrom=" & Today.Date.ToOADate)

            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD [AdvancePayment] [float] NULL ")
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET AdvancePayment=0")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=20")
            Dim DR As New DataTable
            DR = SQLLoadGridData("select  schemename from printingsettings")
            If DR.Rows.Count > 0 Then
                For i As Integer = 0 To DR.Rows.Count - 1
                    Dim sqlstr As String = ""
                    sqlstr = "INSERT INTO [PrintFieldLabels] ([SchemeName],[Fieldname],[labletext],[DBField],[IsVisible],[ftop],[fleft],[width],[height],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[lTop],[lleft],[lwidth],[lheight],[lFontname],[lfontsize],[lfontstyle],[lfontcolor],[lalign],[sample],[DBType],[FieldType],[PrintText],[FormatType],[DatabaseValue],[IsLedgerValue],[decimals],[supress])     VALUES " _
                        & " ('" & DR.Rows(i).Item("schemename").ToString & "','CurrentBalance','CurrentBalance','CurrentBalance',0,20,20,20,20,'Microsoft Sans Serif',10,1,'Black','Left',120,120,120,120,'Microsoft Sans Serif',10,1,'Black','Left','CurrentBalance',0,0,'0 Dr',0,1,0,0,0) "
                    ExecuteSQLQuery(sqlstr)
                Next
            End If
        End If
        If CompDetails.CompanyVersionNumber < 21 Then
            ExecuteSQLQuery(" CREATE TABLE [Appointmentdb] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpName] [nvarchar](75) NULL,[AppID] [bigint] NULL,[DateStart] [datetime] NULL,[DateEnd] [datetime] NULL,[TextVal] [nvarchar](250) NULL,[Note] [nvarchar](250) NULL,[LedgerName] [nvarchar](75) NULL,[ColorR] [tinyint] NULL,[ColorG] [tinyint] NULL,[ColorB] [tinyint] NULL,[Imagepath] [nvarchar](250) NULL,[PatterStyle] [smallint] NULL,[PatterColorR] [tinyint] NULL,[PatterColorG] [tinyint] NULL,[PatterColorB] [tinyint] NULL,[IsConfirm] [bit] NULL,[IsOrderConfirm] [bit] NULL,[dateValue] [bigint] NULL,[IsLocked] [bit] NULL, CONSTRAINT [PK_Appointmentdb] PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]  ")
            ExecuteSQLQuery(" CREATE TABLE [AppointmentRows]([ID] [bigint] IDENTITY(1,1) NOT NULL,[Barcode] [nvarchar](18) NULL,[AppID] [bigint] NULL,[ServiceName] [nvarchar](75) NULL,[Size] [nvarchar](50) NULL,[Rate] [float] NULL,[Mins] [int] NULL, CONSTRAINT [PK_AppointmentRows] PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] ")
            ExecuteSQLQuery(" ALTER TABLE Duties  ADD [MealTime] [datetime] NULL,[MealDuration] [datetime] NULL,[breaktime1] [datetime] NULL,[breakDuration1] [datetime] NULL,[BreakTime2] [datetime] NULL,[BreakDuration2] [datetime] NULL,[MealTimeText] [nvarchar](50) NULL,[Break1Text] [nvarchar](50) NULL,[Break2Text] [nvarchar](50) NULL,[MealTimeColorR] [tinyint] NULL,[MealTimeColorG] [tinyint] NULL,[MealTimeColorB] [tinyint] NULL,[Break1Colorr] [tinyint] NULL,[Break1ColorG] [tinyint] NULL,[Break1ColorB] [tinyint] NULL,[Break2ColorR] [tinyint] NULL,[Break2ColorG] [tinyint] NULL,[Break2ColorB] [tinyint] NULL ")

            ExecuteSQLQuery("UPDATE DUTIES SET MealTime=GETDATE(),MealDuration=GETDATE(),breaktime1=GETDATE(),breakDuration1=GETDATE(),BreakTime2=GETDATE(),BreakDuration2=GETDATE(),MealTimeText='',Break1Text='',Break2Text='', MealTimeColorR=0, MealTimeColorG=0,MealTimeColorB=0,Break1Colorr=0,Break1ColorG=0,Break1ColorB=0,Break2ColorR=0,Break2ColorG=0,Break2ColorB=0 ")

            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=21")
        End If
        If CompDetails.CompanyVersionNumber < 23 Then
            ExecuteSQLQuery(" ALTER TABLE StockInvoiceRowItems  ADD [DiscountAmount1] [float] NULL,	[DiscountAmount2] [float] NULL")
            '
          
            ExecuteSQLQuery("UPDATE StockInvoiceRowItems SET DiscountAmount1=0,DiscountAmount2=disc2*TotalQty")

            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=23")
        End If
        If CompDetails.CompanyVersionNumber < 24 Then
            ExecuteSQLQuery(" ALTER TABLE PrintFieldLabels  ADD [Formulastr] [nvarchar](250) NULL")
            ExecuteSQLQuery(" ALTER TABLE PrintRecords  ADD [Formulastr] [nvarchar](250) NULL")
            ExecuteSQLQuery("UPDATE PrintFieldLabels set Formulastr=''")
            ExecuteSQLQuery("UPDATE PrintRecords set Formulastr=''")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=24")
        End If
        If CompDetails.CompanyVersionNumber < 25 Then
            ExecuteSQLQuery(" ALTER TABLE PrintingDataRowsItems  ADD [DiscountAmount1] [float] NULL,	[DiscountAmount2] [float] NULL")
            ExecuteSQLQuery("UPDATE PrintingDataRowsItems SET DiscountAmount1=10,DiscountAmount2=200")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=25")
        End If
        If CompDetails.CompanyVersionNumber < 26 Then
            ExecuteSQLQuery("ALTER TABLE StockBatch ALTER column [Barcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE StockDbf ALTER column [Barcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE StockJournalDbf ALTER column [Barcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE Employees ALTER column [Barcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE StockInvoiceRowItems ALTER column [Barcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE PrintingDataRowsItems ALTER column [Barcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE AppointmentRows ALTER column [Barcode] [nvarchar](40) NULL ")

            ExecuteSQLQuery("ALTER TABLE StockDbf ALTER column [CustBarcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE StockJournalDbf ALTER column [CustBarcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE StockInvoiceRowItems ALTER column [CustBarcode] [nvarchar](40) NULL ")
            ExecuteSQLQuery("ALTER TABLE PrintingDataRowsItems ALTER column [CustBarcode] [nvarchar](40) NULL ")


            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=26")
        End If
        If CompDetails.CompanyVersionNumber < 27 Then
            ExecuteSQLQuery("CREATE TABLE [barcodeprintsettings]([Schemename] [nvarchar](150) NULL,[PaperSize] [nvarchar](50) NULL,[lwidht] [float] NULL,[lheight] [float] NULL,[TopMargin] [float] NULL,[LeftMargin] [float] NULL,[HGap] [float] NULL,[Vgap] [float] NULL,[IsPrintItemCode] [bit] NULL,[IsPrintMRP] [bit] NULL,[IsPrintWRP] [bit] NULL,[Noofcolumns] [int] NULL,[IsPrintComp] [bit] NULL,[Currency] [nvarchar](50) NULL,[IsWithDecimal] [int] NULL,[LOGO] [image] NULL,[logowidth] [float] NULL,[logoheight] [float] NULL,[logoleft] [float] NULL,[logotop] [float] NULL,[IslogoEnable] [bit] NULL,[IsDefault] [bit] NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] ")
            ExecuteSQLQuery("CREATE TABLE [BarcodeFieldSettings]([Schemename] [nvarchar](150) NULL,[FiledName] [nvarchar](50) NULL,[Lwidth] [int] NULL,[LHeight] [int] NULL,[LTop] [int] NULL,[Lleft] [int] NULL,[DbName] [nvarchar](50) NULL,[LText] [nvarchar](50) NULL,[Fontname] [nvarchar](50) NULL,[fontsize] [smallint] NULL,[fontstyle] [smallint] NULL,[fontcolor] [nvarchar](50) NULL,[Align] [nvarchar](50) NULL,[IsVisible] [bit] NULL,[backcolor] [nvarchar](50) NULL) ON [PRIMARY]")
            ExecuteSQLQuery(" CREATE TABLE [printbarcodeList]([ID] [bigint] NULL,[Cmpname1] [nvarchar](75) NULL,[itemname1] [nvarchar](75) NULL,[MRP1] [nvarchar](50) NULL,[Price1] [nvarchar](50) NULL,[barcode1] [nvarchar](50) NULL,[fontname1] [nvarchar](150) NULL,[Cmpname2] [nvarchar](75) NULL,[itemname2] [nvarchar](75) NULL,[MRP2] [nvarchar](50) NULL,[Price2] [nvarchar](50) NULL,[barcode2] [nvarchar](50) NULL,[fontname2] [nvarchar](150) NULL,[Cmpname3] [nvarchar](75) NULL,[itemname3] [nvarchar](75) NULL,[MRP3] [nvarchar](50) NULL,[Price3] [nvarchar](50) NULL,[barcode3] [nvarchar](50) NULL,[fontname3] [nvarchar](150) NULL,[Cmpname4] [nvarchar](75) NULL,[itemname4] [nvarchar](75) NULL,[MRP4] [nvarchar](50) NULL,[Price4] [nvarchar](50) NULL,[barcode4] [nvarchar](50) NULL,[fontname4] [nvarchar](150) NULL,[Cmpname5] [nvarchar](75) NULL,[itemname5] [nvarchar](75) NULL,[MRP5] [nvarchar](50) NULL,[Price5] [nvarchar](50) NULL,[barcode5] [nvarchar](50) NULL,[fontname5] [nvarchar](150) NULL,[Cmpname6] [nvarchar](75) NULL,[itemname6] [nvarchar](75) NULL,[MRP6] [nvarchar](50) NULL,[Price6] [nvarchar](50) NULL,[barcode6] [nvarchar](50) NULL,[fontname6] [nvarchar](150) NULL,[Image1] [image] NULL,[Image2] [image] NULL,[Image3] [image] NULL,[Image4] [image] NULL,[Image5] [image] NULL,[Image6] [image] NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD  [customername] [nvarchar](140) NULL ")
            ExecuteSQLQuery("UPDATE StockInvoiceDetails SET customername='' where customername is null")
            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=27")
        End If
        If CompDetails.CompanyVersionNumber < 28 Then
            ExecuteSQLQuery("ALTER TABLE BarcodeFieldSettings ALTER COLUMN [Lwidth] [float] NULL")
            ExecuteSQLQuery("ALTER TABLE BarcodeFieldSettings ALTER COLUMN [LHeight] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE BarcodeFieldSettings ALTER COLUMN [LTop] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE BarcodeFieldSettings ALTER COLUMN [Lleft] [float] NULL ")


            ExecuteSQLQuery("ALTER TABLE barcodeprintlabels ALTER COLUMN [Lwidth] [float] NULL")
            ExecuteSQLQuery("ALTER TABLE barcodeprintlabels ALTER COLUMN [LHeight] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE barcodeprintlabels ALTER COLUMN [LTop] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE barcodeprintlabels ALTER COLUMN [Lleft] [float] NULL ")

            ExecuteSQLQuery("ALTER TABLE BarcodePrintSchemes ALTER COLUMN [Lwidth] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE BarcodePrintSchemes ALTER COLUMN [LHeight] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE BarcodePrintSchemes ALTER COLUMN [LTop] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE BarcodePrintSchemes ALTER COLUMN [Lleft] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE BarcodePrintSchemes ALTER COLUMN [LVgap] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE BarcodePrintSchemes ALTER COLUMN [LHgap] [float] NULL ")

            ExecuteSQLQuery("ALTER TABLE barcodePrintLines ALTER COLUMN [Lwidth] [float] NULL")
            ExecuteSQLQuery("ALTER TABLE barcodePrintLines ALTER COLUMN [LHeight] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE barcodePrintLines ALTER COLUMN [LTop] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE barcodePrintLines ALTER COLUMN [Lleft] [float] NULL ")



            ExecuteSQLQuery("ALTER TABLE barcodeprintimages ALTER COLUMN [imagewidth] [float] NULL")
            ExecuteSQLQuery("ALTER TABLE barcodeprintimages ALTER COLUMN [imageHeight] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE barcodeprintimages ALTER COLUMN [LTop] [float] NULL ")
            ExecuteSQLQuery("ALTER TABLE barcodeprintimages ALTER COLUMN [Lleft] [float] NULL ")

            ExecuteSQLQuery("UPDATE COMPANY SET Versionno=28")
        End If
        If CompDetails.CompanyVersionNumber < 29 Then
            ExecuteSQLQuery(" ALTER TABLE settings  ADD [IsAllowOnlyApprovedPurchaseenquiry] [bit] NULL,[IsAllowOnlyApprovedSalesenquiry] [bit] NULL ,[IsTrailData] [bit] NULL")
            ExecuteSQLQuery(" UPDATE settings SET IsAllowOnlyApprovedPurchaseenquiry=0,IsAllowOnlyApprovedSalesenquiry=0,IsTrailData=0")
            ExecuteSQLQuery(" ALTER TABLE StockInvoiceDetails ADD IsApproved [bit] NULL")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=29")
        End If
        If CompDetails.CompanyVersionNumber < 30 Then
            ExecuteSQLQuery("CREATE TABLE [StockTransferDetails] ([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[PriceList] [nvarchar](50) NULL,[SalesPerson] [nvarchar](75) NULL,[ProjectName] [nvarchar](75) NULL,[Area] [nvarchar](50) NULL,[LedgerName] [nvarchar](75) NULL,[LedgerAddress] [nvarchar](120) NULL,[IsCommit] [int] NULL,[IsDelete] [int] NULL,[IsPending] [int] NULL,[subtotal] [float] NULL,[grosstotal] [float] NULL,[discountper] [float] NULL,[nettotal] [float] NULL,[taxtotal] [float] NULL,[InvoiceTotal] [float] NULL,[AccountTotal] [float] NULL,[amountinwords] [nvarchar](250) NULL,[narration] [nvarchar](250) NULL,[InvoiceNo] [nvarchar](50) NULL,[InvoiceRef] [nvarchar](50) NULL,[GoodNo] [nvarchar](50) NULL,[GoodRef] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[CurrencyCon2] [float] NULL,[F1] [nvarchar](50) NULL,[F2] [nvarchar](50) NULL,[N1] [float] NULL,[N2] [float] NULL,[VoucherName] [nvarchar](50) NULL,[DelivaryDate] [datetime] NULL,[DelivaryDateValue] [bigint] NULL,[Additions] [float] NULL,[Deductions] [float] NULL,[PaymentMethod] [nvarchar](20) NULL,[PaymentLedger] [nvarchar](75) NULL,[PaymentDetails] [nvarchar](120) NULL,[AccountLedgerName] [nvarchar](75) NULL,[InvoiceType] [int] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[transtype] [nvarchar](30) NULL,[servicetaxtotal] [float] NULL,[roundoff] [float] NULL,[surcharge] [float] NULL,[BillCurrency] [nvarchar](8) NULL,[DiscPer] [float] NULL,[CDiscount] [float] NULL,[CouponName] [nvarchar](50) NULL,	[CDisCountPer] [float] NULL,[sinvoiceno] [nvarchar](50) NULL,	[sinvoicedate] [datetime] NULL,[taxtotal2] [float] NULL,[cstamount] [float] NULL,	[VoucherType] [nvarchar](20) NULL,[AdvancePayment] [float] NULL,CUSTOMERNAME NVARCHAR(100) NULL,[IsApproved] [bit] NULL ) ON [PRIMARY]  ")
            ExecuteSQLQuery("CREATE TABLE [StockTransferRowItems]([TransCode] [bigint] NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[QutoNo] [nvarchar](50) NULL,[QutoRef] [nvarchar](50) NULL,[OrderNo] [nvarchar](50) NULL,[OrderRef] [nvarchar](50) NULL,[DNoteno] [nvarchar](50) NULL,[DnoteRef] [nvarchar](50) NULL,[StoreName] [nvarchar](75) NULL,[Currency] [nvarchar](10) NULL,[StockName] [nvarchar](75) NULL,[StockCode] [nvarchar](50) NULL,[stockgroup] [nvarchar](75) NULL,[Barcode] [nvarchar](40) NULL,[StockSize] [nvarchar](25) NULL,[Location] [nvarchar](50) NULL,[description] [nvarchar](150) NULL,[BaseUnit] [nvarchar](75) NULL,[MainUnit] [nvarchar](50) NULL,[SubUnit] [nvarchar](50) NULL,[IsSimpleUnit] [int] NULL,[MainQty] [float] NULL,[TotalQty] [float] NULL,[SubUnitQty] [float] NULL,[QtyText] [nvarchar](50) NULL,[StockRate] [float] NULL,[Expiry] [datetime] NULL,[BatchNo] [nvarchar](50) NULL,[StockType] [int] NULL,[StockDisc] [float] NULL,[RatePer] [nvarchar](50) NULL,[UnitCon] [int] NULL,[CustBarcode] [nvarchar](40) NULL,[sno] [int] NULL,[StockAmount] [float] NULL,[Isdelete] [int] NULL,[QtyValues] [nvarchar](15) NULL,[VoucherName] [nvarchar](50) NULL,[CurrencyCon1] [float] NULL,[Tax] [float] NULL,[NetRate] [float] NULL,[origin] [nvarchar](50) NULL,[HScode] [nvarchar](50) NULL,[Utranscode] [bigint] NULL,[UsedQty] [float] NULL,[DeliveryNote] [bit] NULL,[allocateledger] [nvarchar](75) NULL,[PresetRate] [float] NULL,[N1] [float] NULL,[F1] [nvarchar](75) NULL,[IsDirect] [bit] NULL,[TaxAmount] [float] NULL,[disc2] [float] NULL,[transtype] [nvarchar](30) NULL,[Servicetax] [float] NULL,	[netStockAmount] [float] NULL,[mrp] [float] NULL,[packing] [nvarchar](50) NULL,[slnos] [nvarchar](max) NULL,[Tax2] [float] NULL,[TaxAmount2] [float] NULL,[FreeQty] [float] NULL,[FreeQtyText] [nvarchar](50) NULL,[FreeMQty] [float] NULL,[FreeMQtyText] [nvarchar](50) NULL,[mrprate] [float] NULL,[taxtype] [nvarchar](10) NULL,[DiscountAmount1] [float] NULL,	[DiscountAmount2] [float] NULL) ON [PRIMARY] ")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=30")
        End If
        If CompDetails.CompanyVersionNumber < 31 Then
            ExecuteSQLQuery(" ALTER TABLE BarcodeFieldSettings  ADD [Lcase] [nvarchar](50) NULL")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=31")
        End If
        '
        If CompDetails.CompanyVersionNumber < 32 Then
            ExecuteSQLQuery(" CREATE PROCEDURE [dbo].[UpdateBatchStockQty]	@Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@batchno nvarchar(50) AS BEGIN 		SET NOCOUNT ON;	declare @totalqty float;	DECLARE @MAINQTY FLOAT;	DECLARE @SUBQTY FLOAT;	DECLARE @TOTALQTYTEXT NVARCHAR(75);	DECLARE @CON float;	declare @mainunitname nvarchar(40);	declare @subunitname nvarchar(40);	declare @t1 bigint;	declare @t2 float;	SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS;	SELECT @mainunitname=SS.MainUnitName FROM (SELECT MainUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS;	SELECT @subunitname=SS.SubUnitName FROM (SELECT SubUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS;	select @totalqty=TT.TOT from (select (select sum(optotalqty) from STOCKBATCH where StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno )+isnull(sum(case when VoucherName in ('DP','PG','SR','SJIN') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from stockinvoicerowitems WHERE VoucherName IN ('PG','DP','SJIN','SJOUT','PR','POS','SD','SR') and  StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno and  Isdelete=0) AS TT;	IF (@CON=1 )	BEGIN	 update STOCKBATCH set TotalQty=@totalqty,BaseQty=@totalqty,QtyText=CONVERT(nvarchar(20),@totalqty)+' '+@mainunitname  where StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno;	end	else	begin		set @t1=cast(@totalqty as bigint)/cast(@con  as int);	set @t2= cast(@totalqty as bigint) % cast(@con as int);	set @t2=@totalqty -cast(@totalqty as bigint)+ @t2;	update STOCKBATCH set TotalQty=@totalqty,BaseQty=@t1,SubUnitQty=@t2,QtyText=convert(nvarchar(20),@t1)+ ' ' +@mainunitname+' ' + convert(nvarchar(20),@t2)+' ' +@subunitname  where StockCode=@code and Location=@loc and StockSize=@size AND BATCHNO=@batchno ;	end END ")
            ExecuteSQLQuery(" CREATE PROCEDURE [dbo].[UPDATEEMPLOYEESNAMES]	@NEWLEDGERNAME NVARCHAR(120),@OLDLEDGERNAME NVARCHAR(120) AS BEGIN 	SET NOCOUNT ON;       update Users set USERNAME=@NEWLEDGERNAME where USERNAME=@OLDLEDGERNAME           update EmpAttend set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME           update EmpLeaves set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME           update EmpSalaries set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME           update EmployeeAttendence set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME           update documentissues set EmpName=@NEWLEDGERNAME where EmpName=@OLDLEDGERNAME           update duties set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME           UPDATE CostCenterNames SET CostName=@NEWLEDGERNAME WHERE CostName=@OLDLEDGERNAME           UPDATE CostCenterBook SET CostCenterName=@NEWLEDGERNAME WHERE CostCenterName=@OLDLEDGERNAME           update payrollvoucherRowDetails set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME           update empsalaryincrements set EmpName=@NEWLEDGERNAME where empname=@OLDLEDGERNAME END  ")
            ExecuteSQLQuery(" CREATE PROCEDURE [dbo].[UPDATELEDGERNAMES] 	@NEWLEDGERNAME NVARCHAR(120),@OLDLEDGERNAME NVARCHAR(120) AS BEGIN		SET NOCOUNT ON;      UPDATE LEDGERBOOK SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME      UPDATE BILL2BILL SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME      UPDATE LEDGERBOOK SET AcLedger=@NEWLEDGERNAME WHERE AcLedger=@OLDLEDGERNAME      UPDATE DefLedgers SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME      UPDATE VoucherAccounts SET AccountName=@NEWLEDGERNAME WHERE AccountName=@OLDLEDGERNAME      UPDATE StockInvoiceDetails SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME      UPDATE StockInvoiceDetails SET PaymentLedger=@NEWLEDGERNAME WHERE PaymentLedger=@OLDLEDGERNAME      UPDATE StockInvoiceDetails SET AccountLedgerName=@NEWLEDGERNAME WHERE AccountLedgerName=@OLDLEDGERNAME      UPDATE StockInvoiceDetails SET allocateledger=@NEWLEDGERNAME WHERE allocateledger=@OLDLEDGERNAME      UPDATE Vehicle SET AcountLedgerName=@NEWLEDGERNAME WHERE AcountLedgerName=@OLDLEDGERNAME      UPDATE paytypes SET ledgername=@NEWLEDGERNAME WHERE ledgername=@OLDLEDGERNAME      UPDATE paytypes SET paymentledger=@NEWLEDGERNAME WHERE paymentledger=@OLDLEDGERNAME      UPDATE paysliptypes SET ledgername=@NEWLEDGERNAME WHERE ledgername=@OLDLEDGERNAME	  UPDATE CostCenterBook SET LedgerName=@NEWLEDGERNAME WHERE LedgerName=@OLDLEDGERNAME      UPDATE Vatclauses SET inputvatledger=@NEWLEDGERNAME WHERE inputvatledger=@OLDLEDGERNAME      UPDATE Vatclauses SET outputvatledger=@NEWLEDGERNAME WHERE outputvatledger=@OLDLEDGERNAME      UPDATE Vatclauses SET PurchaseLedger=@NEWLEDGERNAME WHERE PurchaseLedger=@OLDLEDGERNAME      UPDATE Vatclauses SET DebitNoteLedger=@NEWLEDGERNAME WHERE DebitNoteLedger=@OLDLEDGERNAME      UPDATE Vatclauses SET SalesLedger=@NEWLEDGERNAME WHERE SalesLedger=@OLDLEDGERNAME      UPDATE Vatclauses SET CreditLedger=@NEWLEDGERNAME WHERE CreditLedger=@OLDLEDGERNAME	  UPDATE payrollvoucherLedgers SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME      UPDATE PayRollVoucherPayMaster SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME	  UPDATE paysliptypes SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME      UPDATE chequeinfo SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME	END  ")
            ExecuteSQLQuery(" CREATE PROCEDURE [dbo].[UPDATESTOCKITEMSNAMES] 	@NEWSTOCKCODE NVARCHAR(120),@NEWSTOCKSIZE NVARCHAR(75),@OLDSTOCKCODE NVARCHAR(120),@OLDSTOCKSIZE NVARCHAR(75),@STOCKNAME NVARCHAR(120) AS BEGIN 		SET NOCOUNT ON;	        UPDATE STOCKDBF SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE            UPDATE StockBatch SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE            UPDATE StockJournalDbf SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE            UPDATE StockInvoiceRowItems SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE,STOCKNAME=@STOCKNAME  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE            UPDATE serialnumbermaster SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE            UPDATE stockserialnos SET stockcode=@NEWSTOCKCODE, stocksize=@NEWSTOCKSIZE  where  stockcode=@OLDSTOCKCODE and stocksize=@OLDSTOCKSIZE END  ")
            ExecuteSQLQuery("  CREATE PROCEDURE [dbo].[UpdateStockQty] 	@Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@batchno nvarchar(50) AS BEGIN			SET NOCOUNT ON;	declare @totalqty float;	DECLARE @MAINQTY FLOAT;	DECLARE @SUBQTY FLOAT;	DECLARE @TOTALQTYTEXT NVARCHAR(75);	DECLARE @CON float;	declare @mainunitname nvarchar(40);	declare @subunitname nvarchar(40);	declare @t1 bigint;	declare @t2 float;	SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS	SELECT @mainunitname=SS.MainUnitName FROM (SELECT MainUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS	SELECT @subunitname=SS.SubUnitName FROM (SELECT SubUnitName FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS	select @totalqty=TT.TOT from (select (select sum(optotalqty) from stockdbf where StockCode=@code and Location=@loc and StockSize=@size )+isnull(sum(case when VoucherName in ('DP','PG','SR','SJIN') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from stockinvoicerowitems WHERE VoucherName IN ('PG','DP','SJIN','SJOUT','PR','POS','SD','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT	IF (@CON=1 )	BEGIN	 update StockDbf set TotalQty=@totalqty,BaseQty=@totalqty,QtyText=CONVERT(nvarchar(20),@totalqty)+' '+@mainunitname  where StockCode=@code and Location=@loc and StockSize=@size 	end	else	begin		set @t1=cast(@totalqty as bigint)/cast(@con  as int);	set @t2= cast(@totalqty as bigint) % cast(@con as int);	set @t2=@totalqty -cast(@totalqty as bigint)+ @t2;	update StockDbf set TotalQty=@totalqty,BaseQty=@t1,SubUnitQty=@t2,QtyText=convert(nvarchar(20),@t1)+ ' ' +@mainunitname+' ' + convert(nvarchar(20),@t2)+' ' +@subunitname  where StockCode=@code and Location=@loc and StockSize=@size; 	end	END ")
            ExecuteSQLQuery(" CREATE PROCEDURE [dbo].[proInventoryCosting] @Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@IsUpdateAll  bit AS BEGIN		SET NOCOUNT ON;	Declare @CostingMethod nvarchar(70);	declare @avgtotqty float;	DECLARE @OPQTY FLOAT;	declare @avgtotvalue float;	DECLARE @OPvalue FLOAT;	declare @NetRate float;	if (@IsUpdateAll=1) 	begin	UPDATE stockdbf set stockrate=0,baseqty=0,totalqty=0,subunitqty=0,minqty=0 where stockcode=@code and stocksize=@size   AND LOCATION=@Loc and stocktype<>0;	end	select @CostingMethod= t1.costmethod from (select costmethod from stockdbf where stockcode=@code and stocksize=@size ) as t1;	if (len(@CostingMethod)=0)	begin	Set @CostingMethod='AVERAGE';	end		if (@CostingMethod='AVERAGE') 	begin	SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	select @avgtotqty=t2.tot  from (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;	SET @avgtotqty=@avgtotqty+@OPQTY;	SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;	SET @avgtotvalue=@avgtotvalue+@OPvalue;	If (@avgtotqty > 0)	begin		set @netrate=@avgtotvalue/@avgtotqty;	end	else     begin	     Set @netrate = 0;	 end     	 UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc    end     	END ")
            ExecuteSQLQuery(" CREATE TABLE [POSSettings] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[NewInvoiceAfterSave] [bit] NULL,[AllowPaymentMethod] [bit] NULL,[PrintInvoiceAfterSave] [bit] NULL,[defPrinterName] [nvarchar](250) NULL,[DirectPrint] [bit] NULL,[NoofCopies] [int] NULL,[AllowPriceAlter] [bit] NULL,[AllowDiscountAlter] [bit] NULL,[AllowNewItem] [bit] NULL,[ZeroTax] [bit] NULL,[osk] [bit] NULL,[DefaultPriceList] [nvarchar](50) NULL,[IsAllowTochangeDate] [bit] NULL,[IsAllowCreditSales] [bit] NULL,[IsAllowMultiCurrency] [bit] NULL,[IsItemsAsGridList] [bit] NULL,[CashLedger] [nvarchar](75) NULL,[CreditCardLedger] [nvarchar](75) NULL,[ChequeLedger] [nvarchar](75) NULL,[GiftCardLedger] [nvarchar](75) NULL, CONSTRAINT [PK_POSSettings] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] ")
            ExecuteSQLQuery(" INSERT INTO [dbo].[POSSettings] ([NewInvoiceAfterSave],[AllowPaymentMethod],[PrintInvoiceAfterSave],[defPrinterName],[DirectPrint],[NoofCopies],[AllowPriceAlter],[AllowDiscountAlter],[AllowNewItem],[ZeroTax],[osk],[DefaultPriceList],IsAllowTochangeDate,IsAllowCreditSales,IsAllowMultiCurrency,IsItemsAsGridList)     VALUES (1,0,1,'',0,1,1,1,1,0,0,'Wholesale',1,0,0,0) ")
            ExecuteSQLQuery(" CREATE TABLE [dbo].[PaymentMethodDetails](	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[Transcode] [bigint] NULL,	[Ttype] [nvarchar](50) NULL,	[Amount] [float] NULL, CONSTRAINT [PK_PaymentMethodDetails] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] ")
            ExecuteSQLQuery(" ALTER TABLE StockInvoiceDetails  ADD [BillType] [nvarchar](50) NULL,	[IsMultiPayment] [bit] NULL")
            ExecuteSQLQuery(" UPDATE StockInvoiceDetails SET BillType='',IsMultiPayment=0")
            ExecuteSQLQuery(" ALTER TABLE StockInvoiceDetails  ADD [CashReceived] [float] NULL,	[CashtoPay] [float] NULL ")
            ExecuteSQLQuery(" UPDATE StockInvoiceDetails SET CashReceived=0,CashtoPay=0 ")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=32")
        End If
        If CompDetails.CompanyVersionNumber < 33 Then

            ExecuteSQLQuery("CREATE TABLE [Counters] ([CounterID] [bigint] IDENTITY(1,1) NOT NULL,[CounterName] [nvarchar](50) NULL,	[CounterEmpName] [nvarchar](75) NULL,	[LocationName] [nvarchar](75) NULL, CONSTRAINT [PK_Counters] PRIMARY KEY CLUSTERED (	[CounterID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]")
            ExecuteSQLQuery("insert into counters  (countername,locationname)  select 1,locationname from stocklocations ")

            ExecuteSQLQuery(" ALTER TABLE LedgerBook  ADD [CounterID] [int] NULL ")
            ExecuteSQLQuery(" UPDATE LedgerBook SET CounterID=1")

            ExecuteSQLQuery(" ALTER TABLE Users  ADD [CounterID] [int] NULL ")
            ExecuteSQLQuery(" UPDATE Users SET CounterID=1")

            ExecuteSQLQuery(" ALTER TABLE StockInvoiceDetails  ADD [CounterID] [int] NULL ")
            ExecuteSQLQuery(" UPDATE StockInvoiceDetails SET CounterID=1")
            Dim tStr As String = ""
            tStr = "ALTER TABLE StockInvoiceRowItems ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockInvoiceRowItems ADD PRIMARY KEY(ID); ALTER TABLE AccountGroups ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE AccountGroups ADD PRIMARY KEY(ID); ALTER TABLE AccountGroupsList ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE AccountGroupsList ADD PRIMARY KEY(ID); ALTER TABLE Bill2Bill ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE Bill2Bill ADD PRIMARY KEY(ID); ALTER TABLE LedgerBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE LedgerBook ADD PRIMARY KEY(ID); ALTER TABLE ledgers ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE ledgers ADD PRIMARY KEY(ID); ALTER TABLE StockDbf ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockDbf ADD PRIMARY KEY(ID); ALTER TABLE StockBatch ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockBatch ADD PRIMARY KEY(ID); ALTER TABLE StockInvoiceDetails ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockInvoiceDetails ADD PRIMARY KEY(ID); ALTER TABLE StockTransferRowItems ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockTransferRowItems ADD PRIMARY KEY(ID); ALTER TABLE CostCenterBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE CostCenterBook ADD PRIMARY KEY(ID); ALTER TABLE couponmaster ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE couponmaster ADD PRIMARY KEY(ID); ALTER TABLE EmpAttend ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE EmpAttend ADD PRIMARY KEY(ID); ALTER TABLE images ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE images ADD PRIMARY KEY(ID); ALTER TABLE payrollVoucherMasterData ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE payrollVoucherMasterData ADD PRIMARY KEY(ID); ALTER TABLE payrollvoucherRowDetails ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE payrollvoucherRowDetails ADD PRIMARY KEY(ID); ALTER TABLE serialnumbermaster ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; " _
                & " ALTER TABLE serialnumbermaster ADD PRIMARY KEY(ID); ALTER TABLE stockserialnos ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE stockserialnos ADD PRIMARY KEY(ID); ALTER TABLE UserLogFile ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE UserLogFile ADD PRIMARY KEY(ID);"
            ExecuteSQLQuery(tStr)
            ExecuteSQLQuery("CREATE TABLE [CounterSalesCash] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[CounterID] [int] NULL,[LocationName] [nvarchar](75) NULL,[TransDate] [datetime] NULL,[TransDateValue] [bigint] NULL,[EmpName] [nvarchar](75) NULL,[Dr] [float] NULL,[Cr] [float] NULL,[Narrations] [nvarchar](250) NULL, CONSTRAINT [PK_CounterSales] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]")
            ExecuteSQLQuery("CREATE TABLE [CounterSalesDNotes]([ID] [bigint] IDENTITY(1,1) NOT NULL,[TransCode] [bigint] NOT NULL,[D1] [int] NULL,[D2] [int] NULL,[D3] [int] NULL,[D4] [int] NULL,[D5] [int] NULL,[D6] [int] NULL,[D7] [int] NULL,[D8] [int] NULL,[D9] [int] NULL) ON [PRIMARY]")


            tStr = " CREATE PROCEDURE [INSERTNEWSETTINGSLOC] 	@locname NVARCHAR(120) AS BEGIN 	SET NOCOUNT ON; INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SI',@locname);   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SO',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SQ',@locname)  ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SD',@locname)  ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SR',@locname);    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SV',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRV',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PI',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PO',@locname) ;  " _
                & " INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PQ',@locname);    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PG',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PR',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PV',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PVR',@locname)  ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'CON',@locname)  ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PAY',@locname) ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'REC',@locname) ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'JOUR',@locname) ;    INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'POS',@locname) ; " _
                & " INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'PAY',@locname)  ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SJ',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8B',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'F8D',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRF8',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRF8B',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'SRF8D',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'CashSales',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'CreditSales',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'Cashpurchase',@locname) ;   INSERT INTO [InvoiceSettings] (InvoiceNumber,InvoiceMethod,PrintonSave,eachnarration,N2,AllowDuplicate,VoucherName,location) VALUES (1,1,0,0,0,0,'creditpurchase',@locname) ;  END "
            ExecuteSQLQuery(tStr)

            tStr = " create PROCEDURE [UPDATELOCATIONNAMES] 	@NEWlocationName NVARCHAR(120),@OLDlocationName NVARCHAR(120) AS BEGIN 			SET NOCOUNT ON;update StockDbf set Location=@NEWlocationName where location=@OLDlocationName; update StockJournalDbf set Location=@NEWlocationName where location=@OLDlocationName; update StockBatch set Location=@NEWlocationName where location=@OLDlocationName; update Users set LocationName=@NEWlocationName where LocationName=@OLDlocationName;update Users set StoreName=@NEWlocationName where StoreName=@OLDlocationName; update StockInvoiceRowItems set Location=@NEWlocationName where location=@OLDlocationName; update logfile set Storename=@NEWlocationName where Storename=@OLDlocationName; update Bill2Bill set Storename=@NEWlocationName where Storename=@OLDlocationName; update LedgerBook set Storename=@NEWlocationName where Storename=@OLDlocationName; update ledgers set Storename=@NEWlocationName where Storename=@OLDlocationName; update StockDbf set Storename=@NEWlocationName where Storename=@OLDlocationName; update StockInvoiceDetails set Storename=@NEWlocationName where Storename=@OLDlocationName; update StockInvoiceRowItems set Storename=@NEWlocationName where Storename=@OLDlocationName;update InvoiceSettings set location=@NEWlocationName where location=@OLDlocationName;update Counters set LocationName=@NEWlocationName where LocationName=@OLDlocationName;update StockTransferRowItems set Location=@NEWlocationName where location=@OLDlocationName;  END "
            ExecuteSQLQuery(tStr)
            tStr = "ALTER PROCEDURE [UPDATELEDGERNAMES] 	@NEWLEDGERNAME NVARCHAR(120),@OLDLEDGERNAME NVARCHAR(120) AS BEGIN 	SET NOCOUNT ON; UPDATE LEDGERBOOK SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE BILL2BILL SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE LEDGERBOOK SET AcLedger=@NEWLEDGERNAME WHERE AcLedger=@OLDLEDGERNAME;UPDATE DefLedgers SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE VoucherAccounts SET AccountName=@NEWLEDGERNAME WHERE AccountName=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET PaymentLedger=@NEWLEDGERNAME WHERE PaymentLedger=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET AccountLedgerName=@NEWLEDGERNAME WHERE AccountLedgerName=@OLDLEDGERNAME;UPDATE StockInvoiceDetails SET allocateledger=@NEWLEDGERNAME WHERE allocateledger=@OLDLEDGERNAME;UPDATE Vehicle SET AcountLedgerName=@NEWLEDGERNAME WHERE AcountLedgerName=@OLDLEDGERNAME;UPDATE paytypes SET ledgername=@NEWLEDGERNAME WHERE ledgername=@OLDLEDGERNAME;UPDATE paytypes SET paymentledger=@NEWLEDGERNAME WHERE paymentledger=@OLDLEDGERNAME;UPDATE paysliptypes SET ledgername=@NEWLEDGERNAME WHERE ledgername=@OLDLEDGERNAME;UPDATE CostCenterBook SET LedgerName=@NEWLEDGERNAME WHERE LedgerName=@OLDLEDGERNAME;UPDATE Vatclauses SET inputvatledger=@NEWLEDGERNAME WHERE inputvatledger=@OLDLEDGERNAME;UPDATE Vatclauses SET outputvatledger=@NEWLEDGERNAME WHERE outputvatledger=@OLDLEDGERNAME;UPDATE Vatclauses SET PurchaseLedger=@NEWLEDGERNAME WHERE PurchaseLedger=@OLDLEDGERNAME;UPDATE Vatclauses SET DebitNoteLedger=@NEWLEDGERNAME WHERE DebitNoteLedger=@OLDLEDGERNAME;UPDATE Vatclauses SET SalesLedger=@NEWLEDGERNAME WHERE SalesLedger=@OLDLEDGERNAME;UPDATE Vatclauses SET CreditLedger=@NEWLEDGERNAME WHERE CreditLedger=@OLDLEDGERNAME; " _
                & " UPDATE payrollvoucherLedgers SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE PayRollVoucherPayMaster SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE paysliptypes SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE chequeinfo SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;UPDATE POSSettings SET CashLedger=@NEWLEDGERNAME WHERE CashLedger=@OLDLEDGERNAME;UPDATE POSSettings SET CreditCardLedger=@NEWLEDGERNAME WHERE CreditCardLedger=@OLDLEDGERNAME;UPDATE POSSettings SET ChequeLedger=@NEWLEDGERNAME WHERE ChequeLedger=@OLDLEDGERNAME;UPDATE POSSettings SET GiftCardLedger=@NEWLEDGERNAME WHERE GiftCardLedger=@OLDLEDGERNAME;UPDATE StockTransferDetails SET LEDGERNAME=@NEWLEDGERNAME WHERE LEDGERNAME=@OLDLEDGERNAME;  END "
            ExecuteSQLQuery(tStr)
            tStr = " ALTER PROCEDURE [dbo].[UPDATELOCATIONNAMES] 	@NEWlocationName NVARCHAR(120),@OLDlocationName NVARCHAR(120) AS BEGIN 			SET NOCOUNT ON; update StockDbf set Location=@NEWlocationName where location=@OLDlocationName;  update StockJournalDbf set Location=@NEWlocationName where location=@OLDlocationName;  update StockBatch set Location=@NEWlocationName where location=@OLDlocationName;  update Users set LocationName=@NEWlocationName where LocationName=@OLDlocationName; update Users set StoreName=@NEWlocationName where StoreName=@OLDlocationName;  update StockInvoiceRowItems set Location=@NEWlocationName where location=@OLDlocationName;  update logfile set Storename=@NEWlocationName where Storename=@OLDlocationName;  update Bill2Bill set Storename=@NEWlocationName where Storename=@OLDlocationName;  update LedgerBook set Storename=@NEWlocationName where Storename=@OLDlocationName;  update ledgers set Storename=@NEWlocationName where Storename=@OLDlocationName;  update StockDbf set Storename=@NEWlocationName where Storename=@OLDlocationName;  update StockInvoiceDetails set Storename=@NEWlocationName where Storename=@OLDlocationName;  update StockInvoiceRowItems set Storename=@NEWlocationName where Storename=@OLDlocationName; update InvoiceSettings set location=@NEWlocationName where location=@OLDlocationName; update Counters set LocationName=@NEWlocationName where LocationName=@OLDlocationName; update StockTransferRowItems set Location=@NEWlocationName where location=@OLDlocationName;  END"
            ExecuteSQLQuery(tStr)
            'ExecuteSQLQuery("ALTER TABLE StockInvoiceRowItems ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockInvoiceRowItems ADD PRIMARY KEY(ID); ALTER TABLE StockInvoiceDetails ADD [ID] [bigint] IDENTITY(1,1) NOT NULL; ALTER TABLE StockInvoiceDetails ADD PRIMARY KEY(ID);ALTER TABLE AccountGroups ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE AccountGroups ADD PRIMARY KEY(ID);ALTER TABLE AccountGroupsList ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE AccountGroupsList ADD PRIMARY KEY(ID);ALTER TABLE Bill2Bill ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE Bill2Bill ADD PRIMARY KEY(ID);ALTER TABLE CostCenterBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE CostCenterBook ADD PRIMARY KEY(ID);ALTER TABLE EmpAttend ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE EmpAttend ADD PRIMARY KEY(ID);ALTER TABLE Employees ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE Employees ADD PRIMARY KEY(ID);ALTER TABLE images ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE images ADD PRIMARY KEY(ID);ALTER TABLE LedgerBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE LedgerBook ADD PRIMARY KEY(ID);ALTER TABLE UserLogFile ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE UserLogFile ADD PRIMARY KEY(ID);ALTER TABLE StockDbf ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE StockDbf ADD PRIMARY KEY(ID);ALTER TABLE StockBatch ADD [ID] [bigint] IDENTITY(1,1) NOT NULL;ALTER TABLE StockBatch ADD PRIMARY KEY(ID);")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=33")
        End If
        If CompDetails.CompanyVersionNumber < 34 Then
            ExecuteSQLQuery("ALTER TABLE BarcodeFieldSettings  ADD [Rotate] [nvarchar](100) NULL  ")
            ExecuteSQLQuery("UPDATE BarcodeFieldSettings set Rotate='RotateNoneFlipNone' where FiledName='barcode'")
            ExecuteSQLQuery("ALTER TABLE barcodeprintsettings  ADD [BarcodeType] [nvarchar](75) NULL  ")
            ExecuteSQLQuery("ALTER TABLE printbarcodeList  ADD [BarcodeImage1] [image] NULL,	[BarcodeImage2] [image] NULL,	[BarcodeImage3] [image] NULL,	[BarcodeImage4] [image] NULL,	[BarcodeImage5] [image] NULL,	[BarcodeImage6] [image] NULL ")

            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=34")

        End If
        If CompDetails.CompanyVersionNumber < 35 Then
            ExecuteSQLQuery("ALTER TABLE barcodeprintlabels  ADD [BarcodeRotate] [nvarchar](100) NULL  ")
            ExecuteSQLQuery("UPDATE barcodeprintlabels set BarcodeRotate='RotateNoneFlipNone' where DbName='barcodeImage'")
            ExecuteSQLQuery("ALTER TABLE PRINTFIELDLABELS ALTER COLUMN  Formulastr NVARCHAR(500) ")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=35")

        End If
        '
        If CompDetails.CompanyVersionNumber < 36 Then
            ExecuteSQLQuery("DROP INDEX [AccountGroupsListindx] ON [dbo].[AccountGroupsList] WITH ( ONLINE = OFF )", False)
            Dim DT As New DataTable
            DT = SQLLoadGridData("SELECT 'ALTER TABLE [' + isnull(schema_name(syo.object_id), sysc.name) + '].[' +  syo.name     + '] ALTER COLUMN ' + syc.name + ' NVARCHAR(' + case syc.max_length when -1 then 'MAX'         ELSE convert(nvarchar(10),syc.max_length) end + ');' as col1  FROM sys.objects syo   JOIN sys.columns syc ON     syc.object_id= syo.object_id   JOIN sys.types syt ON     syt.system_type_id = syc.system_type_id    JOIN sys.schemas sysc ON    syo.schema_id=sysc.schema_id   WHERE      syt.name = 'varchar'     and syo.type='U' ")
            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    ExecuteSQLQuery(DT.Rows(i).Item(0), False)
                Next
            End If
             Dim str As String = ""
            str = " ALTER PROCEDURE [dbo].[proInventoryCosting] @Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@IsUpdateAll  bit  AS  BEGIN SET NOCOUNT ON; Declare @CostingMethod nvarchar(70); declare @avgtotqty float; DECLARE @OPQTY FLOAT; declare @avgtotvalue float; DECLARE @OPvalue FLOAT; declare @NetRate float;DECLARE @CON float;	DECLARE @CurQty float;	declare @SoldstockQty float;	if (@IsUpdateAll=1) begin UPDATE stockdbf set stockrate=0,baseqty=0,totalqty=0,subunitqty=0,minqty=0 where stockcode=@code and stocksize=@size   AND LOCATION=@Loc and stocktype<>0;  	end select @CostingMethod= t1.costmethod from (select costmethod from stockdbf where stockcode=@code and stocksize=@size ) as t1; " _
                & " if (len(@CostingMethod)=0) begin Set @CostingMethod='AVERAGE';	 end  if (@CostingMethod='AVERAGE') begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	 select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot  from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end  SET @avgtotqty=@avgtotqty+@OPQTY; SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;" _
                & " select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and  stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0)  begin set @netrate=@avgtotvalue/@avgtotqty;	 end	 else begin  SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;	  end  if (@netrate is not null)  begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end if (@CostingMethod='LAST PURCHASED') BEGIN SELECT @netrate =sss1.NETRATE from (SELECT MAX(STOCKRATE) AS NETRATE FROM STOCKINVOICEROWITEMS WHERE (TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE) FROM STOCKINVOICEROWITEMS AS TB " _
                & " WHERE (TB.VOUCHERNAME='PG' OR TB.VOUCHERNAME='DP')  AND TB.STOCKCODE=@code AND TB.STOCKSIZE=@size  AND TB.LOCATION=@Loc))  AND STOCKCODE=@code AND STOCKSIZE=@size  AND LOCATION=@Loc) as sss1 ; if (@netrate is not null) begin	 UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	 end	 END	 if (@CostingMethod='ZERO COST') BEGIN	 UPDATE stockdbf set stockrate=0 where stockcode=@code and stocksize=@size  AND LOCATION=@Loc;		 END   if (@CostingMethod='FIFO')  begin  SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS ; " _
                & " select @CurQty=ctb1.totalqty from(select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1; select @SoldstockQty=TT.TOT from (select isnull(sum(case when VoucherName in ('SD', 'POS','SJout') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from  stockinvoicerowitems WHERE VoucherName IN ('SD', 'POS','SJout','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT; if (@SoldstockQty<=0) begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot " _
                & " from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end SET @avgtotqty=@avgtotqty+@OPQTY;   SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR'))  and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0) begin	 set @netrate=@avgtotvalue/@avgtotqty; end else begin SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;		 end   if (@netrate is not null) begin " _
                & " UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	  end	 end  else  begin  DECLARE @YourTempTable TABLE (SNo  int,PQTY  float,RATE  float,TSOLD  float ,runtot  float,nocol float) ; INSERT INTO @YourTempTable SELECT  0 AS SNo, OpTotalQty AS PQTY, OpstockRate AS RATE, @SoldstockQty AS TSOLD , 0 as runtot,0 nocol  FROM STOCKDBF where STOCKCODE=@code AND STOCKSIZE=@size  AND  LOCATION=@loc UNION ALL SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo],  (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, StockRate AS RATE,@SoldstockQty  AS TSOLD , 0 as runtot,0 nocol   FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  stockcode=@code and stocksize=@size   AND LOCATION=@Loc; " _
                & " DECLARE @RunningTotal float;  SET @RunningTotal = 0.0;  UPDATE @YourTempTable SET @RunningTotal = runtot = @RunningTotal + PQTY, nocol=@RunningTotal-@SoldstockQty FROM @YourTempTable ;  select @CurQty=ctb1.totalqty from (select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1;    if (@CurQty<=0 )   begin   set @CurQty=1;    end   else   begin   set @CurQty=@CurQty/@CON;   end  select @NetRate=fintbl1.ntrate from (select sum(case when t=1 then nocol*rate/@CON else pqty*rate/@CON end)/@CurQty as ntrate from (select  ROW_NUMBER () OVER (ORDER BY SNO) as t, * from @YourTempTable where nocol>0 ) sqery33 ) fintbl1; if (@netrate is not null) begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end   end   END  "
            ExecuteSQLQuery(str, False)

            ExecuteSQLQuery("ALTER TABLE Employees ADD [isCheckOut] [bit] NULL ", False)
            ExecuteSQLQuery("update Employees set ischeckout=0")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=36")
        End If
        If CompDetails.CompanyVersionNumber < 37 Then
            Dim str As String = ""
            str = " ALTER PROCEDURE [dbo].[proInventoryCosting] @Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@IsUpdateAll  bit  AS  BEGIN SET NOCOUNT ON; Declare @CostingMethod nvarchar(70); declare @avgtotqty float; DECLARE @OPQTY FLOAT; declare @avgtotvalue float; DECLARE @OPvalue FLOAT; declare @NetRate float;DECLARE @CON float;	DECLARE @CurQty float;	declare @SoldstockQty float;	if (@IsUpdateAll=1) begin UPDATE stockdbf set stockrate=0,baseqty=0,totalqty=0,subunitqty=0,minqty=0 where stockcode=@code and stocksize=@size   AND LOCATION=@Loc and stocktype<>0;  	end select @CostingMethod= t1.costmethod from (select costmethod from stockdbf where stockcode=@code and stocksize=@size ) as t1; " _
                & " if (len(@CostingMethod)=0) begin Set @CostingMethod='AVERAGE';	 end  if (@CostingMethod='AVERAGE') begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	 select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot  from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end  SET @avgtotqty=@avgtotqty+@OPQTY; SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;" _
                & " select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and  stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0)  begin set @netrate=@avgtotvalue/@avgtotqty;	 end	 else begin  SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;	  end  if (@netrate is not null)  begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end if (@CostingMethod='LAST PURCHASED') BEGIN SELECT @netrate =sss1.NETRATE from (SELECT MAX(STOCKRATE) AS NETRATE FROM STOCKINVOICEROWITEMS WHERE (TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE) FROM STOCKINVOICEROWITEMS AS TB " _
                & " WHERE (TB.VOUCHERNAME='PG' OR TB.VOUCHERNAME='DP')  AND TB.STOCKCODE=@code AND TB.STOCKSIZE=@size  AND TB.LOCATION=@Loc))  AND STOCKCODE=@code AND STOCKSIZE=@size  AND LOCATION=@Loc) as sss1 ; if (@netrate is not null) begin	 UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	 end	 END	 if (@CostingMethod='ZERO COST') BEGIN	 UPDATE stockdbf set stockrate=0 where stockcode=@code and stocksize=@size  AND LOCATION=@Loc;		 END   if (@CostingMethod='FIFO')  begin  SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS ; " _
                & " select @CurQty=ctb1.totalqty from(select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1; select @SoldstockQty=TT.TOT from (select isnull(sum(case when VoucherName in ('SD', 'POS','SJout') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from  stockinvoicerowitems WHERE VoucherName IN ('SD', 'POS','SJout','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT; if (@SoldstockQty<=0) begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot " _
                & " from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end SET @avgtotqty=@avgtotqty+@OPQTY;   SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR'))  and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0) begin	 set @netrate=@avgtotvalue/@avgtotqty; end else begin SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;		 end   if (@netrate is not null) begin " _
                & " UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	  end	 end  else  begin  DECLARE @YourTempTable TABLE (SNo  int,PQTY  float,RATE  float,TSOLD  float ,runtot  float,nocol float) ; INSERT INTO @YourTempTable SELECT  0 AS SNo, OpTotalQty AS PQTY, OpstockRate AS RATE, @SoldstockQty AS TSOLD , 0 as runtot,0 nocol  FROM STOCKDBF where STOCKCODE=@code AND STOCKSIZE=@size  AND  LOCATION=@loc UNION ALL SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo],  (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, StockRate AS RATE,@SoldstockQty  AS TSOLD , 0 as runtot,0 nocol   FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  stockcode=@code and stocksize=@size   AND LOCATION=@Loc; " _
                & " DECLARE @RunningTotal float;  SET @RunningTotal = 0.0;  UPDATE @YourTempTable SET @RunningTotal = runtot = @RunningTotal + PQTY, nocol=@RunningTotal-@SoldstockQty FROM @YourTempTable ;  select @CurQty=ctb1.totalqty from (select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1;    if (@CurQty<=0 )   begin   set @CurQty=1;    end   else   begin   set @CurQty=@CurQty/@CON;   end  select @NetRate=fintbl1.ntrate from (select sum(case when t=1 then nocol*rate/@CON else pqty*rate/@CON end)/@CurQty as ntrate from (select  ROW_NUMBER () OVER (ORDER BY SNO) as t, * from @YourTempTable where nocol>0 ) sqery33 ) fintbl1; if (@netrate is not null) begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end   end   END  "
            ExecuteSQLQuery(str, False)

            ExecuteSQLQuery("ALTER TABLE PrintingSchemes ADD [NoofCopies] [int] NULL", False)
            ExecuteSQLQuery("UPDATE PrintingSchemes SET NoofCopies=1")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=37")
        End If
        If CompDetails.CompanyVersionNumber < 38 Then
            Me.Cursor = Cursors.WaitCursor
            Dim str As String = ""
            str = " ALTER PROCEDURE [dbo].[proInventoryCosting] @Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@IsUpdateAll  bit  AS  BEGIN SET NOCOUNT ON; Declare @CostingMethod nvarchar(70); declare @avgtotqty float; DECLARE @OPQTY FLOAT; declare @avgtotvalue float; DECLARE @OPvalue FLOAT; declare @NetRate float;DECLARE @CON float;	DECLARE @CurQty float;	declare @SoldstockQty float;	if (@IsUpdateAll=1) begin UPDATE stockdbf set stockrate=0,baseqty=0,totalqty=0,subunitqty=0,minqty=0 where stockcode=@code and stocksize=@size   AND LOCATION=@Loc and stocktype<>0;  	end select @CostingMethod= t1.costmethod from (select costmethod from stockdbf where stockcode=@code and stocksize=@size ) as t1; " _
                & " if (len(@CostingMethod)=0) begin Set @CostingMethod='AVERAGE';	 end  if (@CostingMethod='AVERAGE') begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	 select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot  from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end  SET @avgtotqty=@avgtotqty+@OPQTY; SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;" _
                & " select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and  stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0)  begin set @netrate=@avgtotvalue/@avgtotqty;	 end	 else begin  SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;	  end  if (@netrate is not null)  begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end if (@CostingMethod='LAST PURCHASED') BEGIN SELECT @netrate =sss1.NETRATE from (SELECT MAX(STOCKRATE) AS NETRATE FROM STOCKINVOICEROWITEMS WHERE (TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE) FROM STOCKINVOICEROWITEMS AS TB " _
                & " WHERE (TB.VOUCHERNAME='PG' OR TB.VOUCHERNAME='DP')  AND TB.STOCKCODE=@code AND TB.STOCKSIZE=@size  AND TB.LOCATION=@Loc))  AND STOCKCODE=@code AND STOCKSIZE=@size  AND LOCATION=@Loc) as sss1 ; if (@netrate is not null) begin	 UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	 end	 END	 if (@CostingMethod='ZERO COST') BEGIN	 UPDATE stockdbf set stockrate=0 where stockcode=@code and stocksize=@size  AND LOCATION=@Loc;		 END   if (@CostingMethod='FIFO')  begin  SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS ; " _
                & " select @CurQty=ctb1.totalqty from(select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1; select @SoldstockQty=TT.TOT from (select isnull(sum(case when VoucherName in ('SD', 'POS','SJout') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from  stockinvoicerowitems WHERE VoucherName IN ('SD', 'POS','SJout','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT; if (@SoldstockQty<=0) begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot " _
                & " from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end SET @avgtotqty=@avgtotqty+@OPQTY;   SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR'))  and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0) begin	 set @netrate=@avgtotvalue/@avgtotqty; end else begin SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;		 end   if (@netrate is not null) begin " _
                & " UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	  end	 end  else  begin  DECLARE @YourTempTable TABLE (SNo  int,PQTY  float,RATE  float,TSOLD  float ,runtot  float,nocol float) ; INSERT INTO @YourTempTable SELECT  0 AS SNo, OpTotalQty AS PQTY, OpstockRate AS RATE, @SoldstockQty AS TSOLD , 0 as runtot,0 nocol  FROM STOCKDBF where STOCKCODE=@code AND STOCKSIZE=@size  AND  LOCATION=@loc UNION ALL SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo],  (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, StockRate AS RATE,@SoldstockQty  AS TSOLD , 0 as runtot,0 nocol   FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  stockcode=@code and stocksize=@size   AND LOCATION=@Loc; " _
                & " DECLARE @RunningTotal float;  SET @RunningTotal = 0.0;  UPDATE @YourTempTable SET @RunningTotal = runtot = @RunningTotal + PQTY, nocol=@RunningTotal-@SoldstockQty FROM @YourTempTable ;  select @CurQty=ctb1.totalqty from (select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1;    if (@CurQty<=0 )   begin   set @CurQty=1;    end   else   begin   set @CurQty=@CurQty/@CON;   end  select @NetRate=fintbl1.ntrate from (select sum(case when t=1 then nocol*rate/@CON else pqty*rate/@CON end)/@CurQty as ntrate from (select  ROW_NUMBER () OVER (ORDER BY SNO) as t, * from @YourTempTable where nocol>0 ) sqery33 ) fintbl1; if (@netrate is not null) begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end   end   END  "
            ExecuteSQLQuery(str, False)

          
            ExecuteSQLQuery("ALTER TABLE PrintingSchemes ADD [NoofCopies] [int] NULL", False)
            ExecuteSQLQuery("UPDATE PrintingSchemes SET NoofCopies=1 where NoofCopies is null ")
            Me.Cursor = Cursors.WaitCursor
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=38")
        End If
        If CompDetails.CompanyVersionNumber < 39 Then
            ExecuteSQLQuery("DROP TABLE [dbo].[Discounts]", False)
            ExecuteSQLQuery(" CREATE TABLE [dbo].[Discounts]([ID] [bigint] IDENTITY(1,1) NOT NULL,[DiscountName] [nvarchar](50) NULL,[StockGroup] [nvarchar](75) NULL,[IsDiscPer] [bit] NULL,[DiscountPer] [float] NULL,[DateFrom] [datetime] NULL,[DateFromValue] [bigint] NULL,[DateTo] [datetime] NULL,[DateToValue] [bigint] NULL,[DiscountType] [nvarchar](50) NULL,[isActive] [bit] NULL, CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] ")
            ExecuteSQLQuery(" CREATE TABLE [dbo].[discountDetails](	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[DiscountID] [int] NULL,	[ItemID] [nvarchar](50) NULL, CONSTRAINT [PK_discountDetails] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] ", False)
            Dim str As String = ""
            str = " ALTER PROCEDURE [dbo].[proInventoryCosting] @Loc nvarchar(75),@code nvarchar(100),@size nvarchar(75),@IsUpdateAll  bit  AS  BEGIN SET NOCOUNT ON; Declare @CostingMethod nvarchar(70); declare @avgtotqty float; DECLARE @OPQTY FLOAT; declare @avgtotvalue float; DECLARE @OPvalue FLOAT; declare @NetRate float;DECLARE @CON float;	DECLARE @CurQty float;	declare @SoldstockQty float;	if (@IsUpdateAll=1) begin UPDATE stockdbf set stockrate=0,baseqty=0,totalqty=0,subunitqty=0,minqty=0 where stockcode=@code and stocksize=@size   AND LOCATION=@Loc and stocktype<>0;  	end select @CostingMethod= t1.costmethod from (select costmethod from stockdbf where stockcode=@code and stocksize=@size ) as t1; " _
                & " if (len(@CostingMethod)=0) begin Set @CostingMethod='AVERAGE';	 end  if (@CostingMethod='AVERAGE') begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;	 select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot  from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end  SET @avgtotqty=@avgtotqty+@OPQTY; SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11;" _
                & " select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and  stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0)  begin set @netrate=@avgtotvalue/@avgtotqty;	 end	 else begin  SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;	  end  if (@netrate is not null)  begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end if (@CostingMethod='LAST PURCHASED') BEGIN SELECT @netrate =sss1.NETRATE from (SELECT MAX(STOCKRATE) AS NETRATE FROM STOCKINVOICEROWITEMS WHERE (TRANSDATEVALUE=(SELECT MAX(TRANSDATEVALUE) FROM STOCKINVOICEROWITEMS AS TB " _
                & " WHERE (TB.VOUCHERNAME='PG' OR TB.VOUCHERNAME='DP')  AND TB.STOCKCODE=@code AND TB.STOCKSIZE=@size  AND TB.LOCATION=@Loc))  AND STOCKCODE=@code AND STOCKSIZE=@size  AND LOCATION=@Loc) as sss1 ; if (@netrate is not null) begin	 UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	 end	 END	 if (@CostingMethod='ZERO COST') BEGIN	 UPDATE stockdbf set stockrate=0 where stockcode=@code and stocksize=@size  AND LOCATION=@Loc;		 END   if (@CostingMethod='FIFO')  begin  SELECT @CON=SS.UnitConversion FROM (SELECT UnitConversion FROM STOCKUNITS WHERE UnitName=(select TOP 1 baseunit from stockdbf where StockCode=@code and Location=@loc and StockSize=@size)) AS SS ; " _
                & " select @CurQty=ctb1.totalqty from(select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1; select @SoldstockQty=TT.TOT from (select isnull(sum(case when VoucherName in ('SD', 'POS','SJout') THEN TOTALQTY ELSE -1*TotalQty END),0) AS TOT from  stockinvoicerowitems WHERE VoucherName IN ('SD', 'POS','SJout','SR') and  StockCode=@code and Location=@loc and StockSize=@size and Isdelete=0) AS TT; if (@SoldstockQty<=0) begin SELECT @OPQTY=T11.TOT FROM (select sum(optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotqty=t2.tot  from  (select sum(case when vouchername='PR' THEN totalqty/unitcon*-1 ELSE totalqty/unitcon END) as tot " _
                & " from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR')) and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2;  if (@avgtotqty is null) 	 begin 	 set @avgtotqty=0;	 end SET @avgtotqty=@avgtotqty+@OPQTY;   SELECT @OPvalue=T11.TOT FROM (select sum(opstockrate*optotalqty/unitcon) as tot from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS T11; select @avgtotvalue=t2.tot  from (select sum(case when vouchername='PR' THEN stockrate*totalqty/unitcon*-1 ELSE stockrate*totalqty/unitcon END) as tot from StockInvoiceRowItems where (vouchername in ('PG','SJin','DP','PR'))  and isdelete=0 and stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as t2; if (@avgtotvalue is null)   begin	set @avgtotvalue=0;  end SET @avgtotvalue=@avgtotvalue+@OPvalue; If (@avgtotqty > 0) begin	 set @netrate=@avgtotvalue/@avgtotqty; end else begin SELECT @netrate=KT.OPSTOCKRATE FROM (SELECT OPSTOCKRATE FROM STOCKDBF  where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) AS KT;		 end   if (@netrate is not null) begin " _
                & " UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;	  end	 end  else  begin  DECLARE @YourTempTable TABLE (SNo  int,PQTY  float,RATE  float,TSOLD  float ,runtot  float,nocol float) ; INSERT INTO @YourTempTable SELECT  0 AS SNo, OpTotalQty AS PQTY, OpstockRate AS RATE, @SoldstockQty AS TSOLD , 0 as runtot,0 nocol  FROM STOCKDBF where STOCKCODE=@code AND STOCKSIZE=@size  AND  LOCATION=@loc UNION ALL SELECT  ROW_NUMBER() OVER (ORDER BY TransDateValue,transcode) AS [SNo],  (CASE WHEN VOUCHERNAME IN ('PG','SJIn','DP') THEN TotalQty ELSE 0 - TotalQty END) AS PQTY, StockRate AS RATE,@SoldstockQty  AS TSOLD , 0 as runtot,0 nocol   FROM StockInvoiceRowItems AS T1  WHERE  (Isdelete = 0) AND (VoucherName IN ('PG', 'PR','SJin','DP')) AND  stockcode=@code and stocksize=@size   AND LOCATION=@Loc; " _
                & " DECLARE @RunningTotal float;  SET @RunningTotal = 0.0;  UPDATE @YourTempTable SET @RunningTotal = runtot = @RunningTotal + PQTY, nocol=@RunningTotal-@SoldstockQty FROM @YourTempTable ;  select @CurQty=ctb1.totalqty from (select totalqty from stockdbf where stockcode=@code and stocksize=@size   AND LOCATION=@Loc) as ctb1;    if (@CurQty<=0 )   begin   set @CurQty=1;    end   else   begin   set @CurQty=@CurQty/@CON;   end  select @NetRate=fintbl1.ntrate from (select sum(case when t=1 then nocol*rate/@CON else pqty*rate/@CON end)/@CurQty as ntrate from (select  ROW_NUMBER () OVER (ORDER BY SNO) as t, * from @YourTempTable where nocol>0 ) sqery33 ) fintbl1; if (@netrate is not null) begin UPDATE stockdbf set stockrate=@NetRate where stockcode=@code and stocksize=@size   AND LOCATION=@Loc;end end   end   END  "
            ExecuteSQLQuery(str, False)

            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=39")
        End If
        If CompDetails.CompanyVersionNumber < 40 Then
            ExecuteSQLQuery("CREATE TABLE [printbarcode] (itemname [nvarchar](120) null, barcode [nvarchar](50), rate float null,copies int null,f1  [nvarchar](75) null ,n1 float null )  ON [PRIMARY] ", False)
            If ExecuteSQLQuery(" ALTER TABLE StockInvoiceDetails  ADD [BillType] [nvarchar](50) NULL,	[IsMultiPayment] [bit] NULL", False) = False Then
                ExecuteSQLQuery(" UPDATE StockInvoiceDetails SET BillType='',IsMultiPayment=0")
            End If

            If ExecuteSQLQuery(" ALTER TABLE StockInvoiceDetails  ADD [CashReceived] [float] NULL,	[CashtoPay] [float] NULL ", False) = False Then
                ExecuteSQLQuery(" UPDATE StockInvoiceDetails SET CashReceived=0,CashtoPay=0 ")
            End If
            ExecuteSQLQuery(" CREATE TABLE [dbo].[PaymentMethodDetails](	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[Transcode] [bigint] NULL,	[Ttype] [nvarchar](50) NULL,	[Amount] [float] NULL, CONSTRAINT [PK_PaymentMethodDetails] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] ", False)
            ExecuteSQLQuery("CREATE TABLE [POSSettings] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[NewInvoiceAfterSave] [bit] NULL,[AllowPaymentMethod] [bit] NULL,[PrintInvoiceAfterSave] [bit] NULL,[defPrinterName] [nvarchar](250) NULL,[DirectPrint] [bit] NULL,[NoofCopies] [int] NULL,[AllowPriceAlter] [bit] NULL,[AllowDiscountAlter] [bit] NULL,[AllowNewItem] [bit] NULL,[ZeroTax] [bit] NULL,[osk] [bit] NULL,[DefaultPriceList] [nvarchar](50) NULL,[IsAllowTochangeDate] [bit] NULL,[IsAllowCreditSales] [bit] NULL,[IsAllowMultiCurrency] [bit] NULL,[IsItemsAsGridList] [bit] NULL,[CashLedger] [nvarchar](75) NULL,[CreditCardLedger] [nvarchar](75) NULL,[ChequeLedger] [nvarchar](75) NULL,[GiftCardLedger] [nvarchar](75) NULL, CONSTRAINT [PK_POSSettings] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] ", False)
            Dim tStr As String = ""
              ExecuteSQLQuery("ALTER TABLE StockInvoiceRowItems ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE StockInvoiceRowItems ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE AccountGroups ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE AccountGroups ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery(" ALTER TABLE AccountGroupsList ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE AccountGroupsList ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE Bill2Bill ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE Bill2Bill ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE LedgerBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE LedgerBook ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE ledgers ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE ledgers ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE StockDbf ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE StockDbf ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE StockBatch ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE StockBatch ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)
            ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD PRIMARY KEY(ID) ", False)
            ExecuteSQLQuery("ALTER TABLE StockTransferRowItems ADD [ID] [bigint] IDENTITY(1,1) NOT NULL ", False)

            ExecuteSQLQuery(" ALTER TABLE StockTransferRowItems ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE CostCenterBook ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE CostCenterBook ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE couponmaster ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)

            ExecuteSQLQuery("ALTER TABLE couponmaster ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE EmpAttend ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE EmpAttend ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE images ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE images ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE payrollVoucherMasterData ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE payrollVoucherMasterData ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE payrollvoucherRowDetails ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE payrollvoucherRowDetails ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE serialnumbermaster ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE serialnumbermaster ADD PRIMARY KEY(ID);  ", False)

            ExecuteSQLQuery("ALTER TABLE stockserialnos ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE stockserialnos ADD PRIMARY KEY(ID)", False)
            ExecuteSQLQuery("ALTER TABLE UserLogFile ADD [ID] [bigint] IDENTITY(1,1) NOT NULL", False)
            ExecuteSQLQuery("ALTER TABLE UserLogFile ADD PRIMARY KEY(ID)", False)

            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=40")
        End If
        If CompDetails.CompanyVersionNumber < 41 Then
            ExecuteSQLQuery("create PROCEDURE Pro_DayBrkReport  	@ledgername nvarchar(100), @sdate DATE,@edate date AS BEGIN 		SET NOCOUNT ON;    CREATE TABLE #TEMP4 (DT DATE); ;WITH rs AS ( SELECT @sdate dt 	UNION all SELECT DATEADD(d,1,dt)    FROM rs WHERE dt<@edate ) INSERT INTO #TEMP4 SELECT * FROM RS option (maxrecursion 32767); CREATE TABLE #T (DT DATE,NR NVARCHAR(120),DD FLOAT,CC FLOAT, DDCC FLOAT); INSERT INTO #T SELECT dt,'' as nr,isnull(sum(dr),0) as dd ,isnull(sum(cr),0) as cc ,isnull(sum(dr-cr),0) as ddcc FROM #TEMP4 left join ledgerbook on cast(ledgerbook.transdate as date)=#temp4.dt where (ledgername=@ledgername or ledgername is null) and (isdeleted=0 or isdeleted is null)   group by dt order by dd; declare @opbal float; select @opbal= st.tot from (select sum(dr-cr) as tot from LedgerBook where ledgername=@ledgername and isdeleted=0 and cast(transdate as date)<@sdate ) as st; if (@opbal is null) begin set @opbal=0; end if (@opbal>=0)  begin INSERT INTO #T (DT,NR,DD,CC,DDCC) VALUES (DATEADD(d,-1,@sdate),'Opening Balance',@opbal,0,@opbal); end else begin set @opbal=@opbal*-1; INSERT INTO #T (DT,NR,DD,CC,DDCC) VALUES (DATEADD(d,-1,@sdate),'Opening Balance',0,@opbal,@opbal); end   SELECT * , (SELECT case when SUM(DDCC)>=0 then CONVERT(nvarchar,cast(sum(DDCC) as money),1) +' Dr' else CONVERT(nvarchar,cast(sum(DDCC)*-1 as money),1) +' Cr' end FROM #T T1 WHERE T1.DT<=T2.DT) AS CLOSEBAL FROM #T T2 ORDER BY DT; END ", False)
            ExecuteSQLQuery("create PROCEDURE Pro_DayBrkMonthReport  	@ledgername nvarchar(100), @sdate DATE,@edate date AS BEGIN 		SET NOCOUNT ON;    CREATE TABLE #TEMP4 (DT DATE); ;WITH rs AS ( SELECT @sdate dt 	UNION all SELECT DATEADD(d,1,dt)    FROM rs WHERE dt<@edate ) INSERT INTO #TEMP4 SELECT * FROM RS option (maxrecursion 32767); CREATE TABLE #T (DT DATE,NR NVARCHAR(120),DD FLOAT,CC FLOAT, DDCC FLOAT); INSERT INTO #T SELECT dt,'' as nr,isnull(sum(dr),0) as dd ,isnull(sum(cr),0) as cc ,isnull(sum(dr-cr),0) as ddcc FROM #TEMP4 left join ledgerbook on cast(ledgerbook.transdate as date)=#temp4.dt where (ledgername=@ledgername or ledgername is null) and (isdeleted=0 or isdeleted is null)   group by dt order by dd; declare @opbal float; select @opbal= st.tot from (select sum(dr-cr) as tot from LedgerBook where ledgername=@ledgername and isdeleted=0 and cast(transdate as date)<@sdate ) as st; if (@opbal is null)  begin  set @opbal=0;  end    create table #temp5 (sn int,period  nvarchar(20),dd float,cc float,ddd float); insert into #temp5   SELECT ROW_NUMBER() OVER (ORDER BY year(dt)) as sn, (UPPER(left(DATENAME(MONTH,dt),3)) + '-' + CONVERT(varchar(30),year(dt))) AS [Period],SUM(dd) as dd, sum(cc) as cc,sum(dd-cc) as ddd FROM #T  GROUP BY year(dt),month(dt) ,DATENAME(MONTH,dt) ; 	if (@opbal>0)   begin  INSERT INTO #temp5 (sn,period,dd,cc,ddd ) VALUES (0,'Opening Balance',@opbal,0,@opbal);  end   else if (@opbal<0)   begin   set @opbal=@opbal*-1;  INSERT INTO #temp5 (sn,period,dd,cc,ddd ) VALUES (0,'Opening Balance',0,@opbal,@opbal);  end  	select sn as Sno,Period,dd as DrAmount,cc as CrAmount, (select case when sum(ddd)>=0 then CONVERT(nvarchar,cast(sum(ddd) as money),1)+ ' Dr' else CONVERT(nvarchar,cast(sum(ddd)*-1 as money),1)+' Cr' end  from #temp5 st2 where st2.sn<=st1.sn) as ClosingBalance from #temp5 st1 order by sn; END ", False)
            Me.Cursor = Cursors.WaitCursor

            Dim SqlConn As New SqlClient.SqlConnection
            Dim Sqlcmmd As New SqlClient.SqlCommand

            Try
                SqlConn.ConnectionString = ConnectionStrinG
                SqlConn.Open()
                Sqlcmmd.Connection = SqlConn
                Sqlcmmd.CommandText = "select * from stockdbf"
                Sqlcmmd.CommandType = CommandType.Text
                Dim Sreader As SqlClient.SqlDataReader
                Sreader = Sqlcmmd.ExecuteReader
                While Sreader.Read()
                    ExecuteSQLQuery("exec UpdateStockQty N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "',N''")
                    ExecuteSQLQuery("EXEC proInventoryCosting N'" & Sreader("location").ToString.Trim & "',N'" & Sreader("stockcode").ToString.Trim & "',N'" & Sreader("stocksize").ToString.Trim & "'," & UpdateQuantityForNon_StockAlso)
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

            Dim dt As New DataTable
          
            'update for batch wise details

            Dim dt2 As New DataTable
            dt2 = SQLLoadGridData("select * from stockbatch")
            If dt2.Rows.Count > 0 Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    ExecuteSQLQuery("exec UpdateBatchStockQty N'" & dt2.Rows(i).Item("location").ToString.Trim & "',N'" & dt2.Rows(i).Item("stockcode").ToString.Trim & "',N'" & dt2.Rows(i).Item("stocksize").ToString.Trim & "',N'" & dt2.Rows(i).Item("batchno").ToString.Trim & "'")
                Next
            End If
            Me.Cursor = Cursors.Default
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=41")
            CompDetails.CompanyVersionNumber = 41
        End If
        If CompDetails.CompanyVersionNumber < 42 Then

            ExecuteSQLQuery("ALTER TABLE barcodeprintlabels  ADD 	[IsComaSep] [bit] NULL")
            ExecuteSQLQuery("update barcodeprintlabels set IsComaSep=0")

            ExecuteSQLQuery("ALTER TABLE BarcodeFieldSettings  ADD 	[IsComaSep] [bit] NULL")
            ExecuteSQLQuery("update BarcodeFieldSettings set IsComaSep=0")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=42")
            CompDetails.CompanyVersionNumber = 42
        End If

        If CompDetails.CompanyVersionNumber < 43 Then
            ExecuteSQLQuery("CREATE TABLE [dbo].[barcodelist]( 	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[Pbarcode] [nvarchar](50) NULL,	[ABarcode] [nvarchar](50) NULL, CONSTRAINT [PK_barcodelist] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]")
            ExecuteSQLQuery("CREATE TABLE [dbo].[renewHistory]([ID] [bigint] IDENTITY(1,1) NOT NULL,[RenewDate] [datetime] NULL,[Username] [nvarchar](50) NULL,[RenewID] [bigint] NULL,[DateValue] [bigint] NULL, CONSTRAINT [PK_renewHistory] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]")
            ExecuteSQLQuery("CREATE TABLE [dbo].[EmpIds]( [ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpID] [nvarchar](50) NULL,[IDName] [nvarchar](50) NULL,[IDType] [nvarchar](50) NULL,[Expiry] [datetime] NULL,[Photo1] [image] NULL,[Photo2] [image] NULL,[Photo3] [image] NULL,[Description] [nvarchar](150) NULL,[IssuedBy] [nvarchar](75) NULL, CONSTRAINT [PK_EmpIds] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
            ExecuteSQLQuery(" CREATE TABLE [dbo].[Clients]( [ClientID] [int] IDENTITY(1,1) NOT NULL,[ClientName] [nvarchar](150) NULL,[Address] [nvarchar](150) NULL,[ContactNo1] [nvarchar](20) NULL,[ContactNo2] [nvarchar](20) NULL,[EmailID] [nvarchar](150) NULL,[Cotracttype] [nvarchar](50) NULL,[Period] [int] NULL,[ContactPerson] [nvarchar](75) NULL,[Description] [nvarchar](250) NULL, CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ClientID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] ")
            ExecuteSQLQuery("CREATE TABLE [dbo].[ClientSites]( 	[ID] [bigint] IDENTITY(1,1) NOT NULL,	[ClientID] [int] NULL,	[SiteID] [int] NULL, CONSTRAINT [PK_ClientSites] PRIMARY KEY CLUSTERED (	[ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]")
            ExecuteSQLQuery("CREATE TABLE [dbo].[Sites]([SiteID] [int] IDENTITY(1,1) NOT NULL,[SiteName] [nvarchar](75) NULL,[SiteAddress] [nvarchar](150) NULL,[ContactNo1] [nvarchar](20) NULL,[ContactNo2] [nvarchar](20) NULL,[Description] [nvarchar](250) NULL, CONSTRAINT [PK_Sites] PRIMARY KEY CLUSTERED ([SiteID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]")
            ExecuteSQLQuery(" CREATE TABLE [dbo].[Siteschedule]( [id] [bigint] IDENTITY(1,1) NOT NULL,[ClientID] [int] NULL,[EmpID] [nvarchar](50) NULL,[WorkType] [nvarchar](150) NULL,[Rate] [float] NULL,[Food] [bit] NULL,[Accommodation] [bit] NULL,[Transport] [bit] NULL,[StartDate] [datetime] NULL,[EndDate] [datetime] NULL,[StartDateValue] [bigint] NULL,[EndDateValue] [bigint] NULL, CONSTRAINT [PK_Siteschedule] PRIMARY KEY CLUSTERED ([id] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] ")

            ExecuteSQLQuery(" ALTER TABLE [dbo].[ClientSites]  WITH CHECK ADD  CONSTRAINT [FK_Clients_On_ClientSites22] FOREIGN KEY([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]);ALTER TABLE [dbo].[ClientSites] CHECK CONSTRAINT [FK_Clients_On_ClientSites22];ALTER TABLE [dbo].[ClientSites]  WITH CHECK ADD  CONSTRAINT [FK_Sites_On_ClientSites22] FOREIGN KEY([SiteID]) REFERENCES [dbo].[Sites] ([SiteID]);ALTER TABLE [dbo].[ClientSites] CHECK CONSTRAINT [FK_Sites_On_ClientSites22]  ")
            ExecuteSQLQuery("ALTER TABLE [dbo].[Siteschedule]  WITH CHECK ADD  CONSTRAINT [FK_Siteschedule_Clients] FOREIGN KEY([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]); ALTER TABLE [dbo].[Siteschedule] CHECK CONSTRAINT [FK_Siteschedule_Clients] ")
            CompDetails.CompanyVersionNumber = 43
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=43")
        End If

        If CompDetails.CompanyVersionNumber < 44 Then
            ExecuteSQLQuery("ALTER TABLE company  ADD 	[DecimalSymbol] [nvarchar](50) NULL")
            ExecuteSQLQuery("ALTER TABLE settings ADD  [DefPaymentMethodInSales] [nvarchar](50) NULL,[DefPaymentMethodinPurchase] [nvarchar](50) NULL ", False)
            ExecuteSQLQuery("UPDATE settings SET DefPaymentMethodInSales='Credit',DefPaymentMethodinPurchase='Credit' ", False)
                ExecuteSQLQuery("CREATE FUNCTION [dbo].[fnFindNumbertoWord](@Money AS money)     RETURNS VARCHAR(1024) AS BEGIN     DECLARE @Number as BIGINT     SET @Number = FLOOR(@Money)     DECLARE @Below20 TABLE (ID int identity(0,1), Word varchar(32))     DECLARE @Below100 TABLE (ID int identity(2,1), Word varchar(32))     INSERT @Below20 (Word) VALUES                ( 'Zero'), ('One'),( 'Two' ), ( 'Three'),               ( 'Four' ), ( 'Five' ), ( 'Six' ), ( 'Seven' ),               ( 'Eight'), ( 'Nine'), ( 'Ten'), ( 'Eleven' ),               ( 'Twelve' ), ( 'Thirteen' ), ( 'Fourteen'),               ( 'Fifteen' ), ('Sixteen' ), ( 'Seventeen'),               ('Eighteen' ), ( 'Nineteen' )       INSERT @Below100 VALUES ('Twenty'), ('Thirty'),('Forty'), ('Fifty'),                  ('Sixty'), ('Seventy'), ('Eighty'), ('Ninety') DECLARE @English varchar(1024) = (   SELECT Case      WHEN @Number = 0 THEN  ''     WHEN @Number BETWEEN 1 AND 19      THEN (SELECT Word FROM @Below20 WHERE ID=@Number)    WHEN @Number BETWEEN 20 AND 99    THEN  (SELECT Word FROM @Below100 WHERE ID=@Number/10)+ '-' +        dbo.fnFindNumbertoWord( @Number % 10)    WHEN @Number BETWEEN 100 AND 999      THEN  (dbo.fnFindNumbertoWord( @Number / 100))+' Hundred '+     dbo.fnFindNumbertoWord( @Number % 100)    WHEN @Number BETWEEN 1000 AND 999999      THEN  (dbo.fnFindNumbertoWord( @Number / 1000))+' Thousand '+     dbo.fnFindNumbertoWord( @Number % 1000)     WHEN @Number BETWEEN 1000000 AND 999999999      THEN  (dbo.fnFindNumbertoWord( @Number / 1000000))+' Million '+     dbo.fnFindNumbertoWord( @Number % 1000000)    ELSE ' INVALID INPUT' END) SELECT @English = RTRIM(@English) SELECT @English = RTRIM(LEFT(@English,len(@English)-1))         WHERE RIGHT(@English,1)='-'IF @@NestLevel = 1 BEGIN     SELECT @English = @English+' '     SELECT @English = @English END RETURN (@English) END ", False)
            ExecuteSQLQuery(" CREATE FUNCTION [dbo].[fnNumberToWord](@Money AS money)     RETURNS VARCHAR(1024) AS BEGIN    DECLARE @Number as BIGINT;	declare @str  as nvarchar(500);	declare @frnstr as nvarchar(20);	declare @endstr as nvarchar(20);	declare @nodec as int;	select @nodec=ss.noofdecimals from (select top 1 noofdecimals from company) as ss;	select @frnstr=ss.CurrencyName from (select top 1 CurrencyName from company) as ss;	select @endstr=ss.DecimalSymbol from (select top 1 DecimalSymbol from company) as ss;    SET @Number = FLOOR(@Money)	set @str=  dbo.fnFindNumbertoWord(@number)+ ' ' +@frnstr;	if @nodec=2 	begin	set @Number=convert(int,100*(@Money - @Number));	end	else	begin	set @Number=convert(int,1000*(@Money - @Number));	end		if @Number>0 	begin	set @str=@str + ' And ' + dbo.fnFindNumbertoWord(@number) + ' ' + @endstr;	end RETURN (@str) END   ")
            ExecuteSQLQuery("update company set DecimalSymbol=''")
            CompDetails.CompanyVersionNumber = 44







            ExecuteSQLQuery(" CREATE TABLE [empmsgs]([EmpMsgType] [nvarchar](50) NULL,[EmpMsgtext] [nvarchar](max) NULL,[subject] [nvarchar](200) NULL) ON [PRIMARY] ", False)
            If ExecuteSQLQuery("ALTER TABLE Employees ADD [leavesalaryduedays] [bigint] NULL,[airticketduedays] [bigint] NULL,[leavesalaryfrom] [bigint] NULL,	[airticketfrom] [bigint] NULL,[NotifyDays] [int] NULL ", False) = True Then
                ExecuteSQLQuery("UPDATE Employees SET leavesalaryduedays=0,airticketduedays=0,NotifyDays=30,leavesalaryfrom=" & Today.Date.ToOADate & ",airticketfrom=" & Today.Date.ToOADate)
            End If
            If ExecuteSQLQuery("ALTER TABLE settings ADD  [DefPaymentMethodInSales] [nvarchar](50) NULL,[DefPaymentMethodinPurchase] [nvarchar](50) NULL ", False) = True Then
                ExecuteSQLQuery("UPDATE settings SET DefPaymentMethodInSales='Credit',DefPaymentMethodinPurchase='Credit' ")
            End If

            If ExecuteSQLQuery("ALTER TABLE company ADD  [dateformattext] [nvarchar](50) NULL", False) = True Then
                ExecuteSQLQuery("UPDATE company SET dateformattext='dd/MM/yyyy'")
            End If



            If ExecuteSQLQuery("ALTER TABLE StockInvoiceDetails ADD [AdvancePayment] [float] NULL ", False) = True Then
                ExecuteSQLQuery("UPDATE StockInvoiceDetails SET AdvancePayment=0")
            End If
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=44")

        End If

        If CompDetails.CompanyVersionNumber < 45 Then
            ExecuteSQLQuery("ALTER TABLE Siteschedule ADD [RateType] [nvarchar](50) NULL,	[TotalHours] [float] NULL ,Sponsorship [nvarchar](100) NULL, [SiteID] [int] NULL ", False)
            ExecuteSQLQuery("UPDATE Siteschedule set RateType='Daily', TotalHours=0,Sponsorship='' ,SiteID=1")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=45")
        End If
        If CompDetails.CompanyVersionNumber < 46 Then
            ExecuteSQLQuery("ALTER TABLE EmpIds ADD [IssueDate] [datetime] NULL ", False)
            ExecuteSQLQuery("UPDATE EmpIds SET IssueDate=GETDATE()")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=46")
        End If
        If CompDetails.CompanyVersionNumber < 47 Then
            ExecuteSQLQuery("ALTER TABLE discountDetails ADD [IsDiscPer] [bit] NULL,	[DiscountPer] [float] NULL ", False)
            ExecuteSQLQuery("UPDATE discountDetails SET IsDiscPer=1,DiscountPer=0 ")
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=47")
        End If
        If CompDetails.CompanyVersionNumber < 48 Then
            ExecuteSQLQuery("CREATE TABLE [dbo].[EmpAdditionalInfo]([ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpID] [nvarchar](50) NULL,[Additional_name] [nvarchar](50) NULL,[Additional_description] [nvarchar](max) NULL, CONSTRAINT [PK_EmpAdditionalInfo] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] ")
            ExecuteSQLQuery(" CREATE TABLE [dbo].[EmpDocAttachments] ([ID] [bigint] IDENTITY(1,1) NOT NULL,[EmpID] [nvarchar](50) NULL,[DocAttach] [varbinary](max) NULL,[DocAttachFileName] [nvarchar](250) NULL,[DateofAttachment] [datetime] NULL,[DateofModified] [datetime] NULL,[DateofAccess] [datetime] NULL, CONSTRAINT [PK_EmpDocAttachments] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] ")
            Dim dt As New DataTable
            dt = SQLLoadGridData("select * from employees ")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("DocAdd1").ToString.Length > 0 Then
                        ExecuteSQLQuery("INSERT INTO EmpAdditionalInfo (EMPID,Additional_name,Additional_description) VALUES ('" & dt.Rows(i).Item("EmpID").ToString & "','Docadd1','" & dt.Rows(i).Item("DocAdd1") & "')")
                    End If
                    If dt.Rows(i).Item("DocAdd2").ToString.Length > 0 Then
                        ExecuteSQLQuery("INSERT INTO EmpAdditionalInfo (EMPID,Additional_name,Additional_description) VALUES ('" & dt.Rows(i).Item("EmpID").ToString & "','DocAdd2','" & dt.Rows(i).Item("DocAdd2") & "')")
                    End If

                    If dt.Rows(i).Item("DocAdd3").ToString.Length > 0 Then
                        ExecuteSQLQuery("INSERT INTO EmpAdditionalInfo (EMPID,Additional_name,Additional_description) VALUES ('" & dt.Rows(i).Item("EmpID").ToString & "','DocAdd3','" & dt.Rows(i).Item("DocAdd3") & "')")
                    End If
                    If dt.Rows(i).Item("DocAdd4").ToString.Length > 0 Then
                        ExecuteSQLQuery("INSERT INTO EmpAdditionalInfo (EMPID,Additional_name,Additional_description) VALUES ('" & dt.Rows(i).Item("EmpID").ToString & "','DocAdd4','" & dt.Rows(i).Item("DocAdd4") & "')")
                    End If

                  
                    If IsDBNull(dt.Rows(i).Item("DocAttach1")) = False Then
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand("INSERT INTO [dbo].[EmpDocAttachments] ([EmpID],[DocAttach],[DocAttachFileName],[DateofAttachment],[DateofModified],[DateofAccess])     VALUES (@EmpID,@DocAttach,@DocAttachFileName,@DateofAttachment,@DateofModified,@DateofAccess) ", MAINCON)
                        With DBF.Parameters
                            .AddWithValue("EmpID", dt.Rows(i).Item("EmpID").ToString)
                            .AddWithValue("DocAttach", dt.Rows(i).Item("DocAttach1"))
                            .AddWithValue("DocAttachFileName", dt.Rows(i).Item("DocAttachFileName1").ToString)
                            .AddWithValue("DateofAttachment", Now)
                            .AddWithValue("DateofModified", Now)
                            .AddWithValue("DateofAccess", Now)

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    End If

                    If IsDBNull(dt.Rows(i).Item("DocAttach2")) = False Then
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand("INSERT INTO [dbo].[EmpDocAttachments] ([EmpID],[DocAttach],[DocAttachFileName],[DateofAttachment],[DateofModified],[DateofAccess])     VALUES (@EmpID,@DocAttach,@DocAttachFileName,@DateofAttachment,@DateofModified,@DateofAccess) ", MAINCON)
                        With DBF.Parameters
                            .AddWithValue("EmpID", dt.Rows(i).Item("EmpID").ToString)
                            .AddWithValue("DocAttach", dt.Rows(i).Item("DocAttach2"))
                            .AddWithValue("DocAttachFileName", dt.Rows(i).Item("DocAttachFileName2").ToString)
                            .AddWithValue("DateofAttachment", Now)
                            .AddWithValue("DateofModified", Now)
                            .AddWithValue("DateofAccess", Now)

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    End If

                    If IsDBNull(dt.Rows(i).Item("DocAttach3")) = False Then
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand("INSERT INTO [dbo].[EmpDocAttachments] ([EmpID],[DocAttach],[DocAttachFileName],[DateofAttachment],[DateofModified],[DateofAccess])     VALUES (@EmpID,@DocAttach,@DocAttachFileName,@DateofAttachment,@DateofModified,@DateofAccess) ", MAINCON)
                        With DBF.Parameters
                            .AddWithValue("EmpID", dt.Rows(i).Item("EmpID").ToString)
                            .AddWithValue("DocAttach", dt.Rows(i).Item("DocAttach3"))
                            .AddWithValue("DocAttachFileName", dt.Rows(i).Item("DocAttachFileName3").ToString)
                            .AddWithValue("DateofAttachment", Now)
                            .AddWithValue("DateofModified", Now)
                            .AddWithValue("DateofAccess", Now)

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    End If
                    If IsDBNull(dt.Rows(i).Item("DocAttach4")) = False Then
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand("INSERT INTO [dbo].[EmpDocAttachments] ([EmpID],[DocAttach],[DocAttachFileName],[DateofAttachment],[DateofModified],[DateofAccess])     VALUES (@EmpID,@DocAttach,@DocAttachFileName,@DateofAttachment,@DateofModified,@DateofAccess) ", MAINCON)
                        With DBF.Parameters
                            .AddWithValue("EmpID", dt.Rows(i).Item("EmpID").ToString)
                            .AddWithValue("DocAttach", dt.Rows(i).Item("DocAttach4"))
                            .AddWithValue("DocAttachFileName", dt.Rows(i).Item("DocAttachFileName4").ToString)
                            .AddWithValue("DateofAttachment", Now)
                            .AddWithValue("DateofModified", Now)
                            .AddWithValue("DateofAccess", Now)

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    End If
                    If IsDBNull(dt.Rows(i).Item("DocAttach5")) = False Then
                        MAINCON.ConnectionString = ConnectionStrinG
                        MAINCON.Open()
                        Dim DBF As New SqlClient.SqlCommand("INSERT INTO [dbo].[EmpDocAttachments] ([EmpID],[DocAttach],[DocAttachFileName],[DateofAttachment],[DateofModified],[DateofAccess])     VALUES (@EmpID,@DocAttach,@DocAttachFileName,@DateofAttachment,@DateofModified,@DateofAccess) ", MAINCON)
                        With DBF.Parameters
                            .AddWithValue("EmpID", dt.Rows(i).Item("EmpID").ToString)
                            .AddWithValue("DocAttach", dt.Rows(i).Item("DocAttach5"))
                            .AddWithValue("DocAttachFileName", dt.Rows(i).Item("DocAttachFileName5").ToString)
                            .AddWithValue("DateofAttachment", Now)
                            .AddWithValue("DateofModified", Now)
                            .AddWithValue("DateofAccess", Now)

                        End With
                        DBF.ExecuteNonQuery()
                        DBF = Nothing
                        MAINCON.Close()
                    End If
                Next
            End If
            ExecuteSQLQuery(" UPDATE COMPANY SET Versionno=48")
        End If
    End Sub
    Sub CreateProjectCostCenters()
        Dim SqlConn As New SqlClient.SqlConnection

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            SQLFcmd.Connection = SqlConn
            SQLFcmd.CommandText = "Select distinct ProjectName from StockInvoiceDetails "
            SQLFcmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = SQLFcmd.ExecuteReader
            While Sreader.Read()
                If Sreader("projectname").ToString.Trim.Length > 0 Then


                    If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & Sreader("projectname").ToString.Trim & "'") = False Then
                        If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & Replace(Sreader("projectname").ToString.Trim, " ", "") & "'") = False Then
                            Dim Sqlstr As String = ""
                            Sqlstr = "INSERT INTO [projecttable]([ProjectName] ,[CatName] ,[f1])  VALUES (N'" & Sreader("projectname").ToString.Trim & "','*Primary','')"
                            ExecuteSQLQuery(Sqlstr)

                            Sqlstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                              & "VALUES(N'" & Sreader("projectname").ToString.Trim & "','*Primary',0,'Projects')"
                            ExecuteSQLQuery(Sqlstr)
                        Else
                            If SQLIsFieldExists("select costname from CostCenterNames where costname=N'" & Sreader("projectname").ToString.Trim & "1'") = False Then
                                Dim Sqlstr As String = ""
                                Sqlstr = "INSERT INTO [projecttable]([ProjectName] ,[CatName] ,[f1])  VALUES (N'" & Sreader("projectname").ToString.Trim & "1','*Primary','')"
                                ExecuteSQLQuery(Sqlstr)

                                Sqlstr = "INSERT INTO [CostCenterNames]([CostName],[costgroup],[n1],[f1])     " _
                                  & "VALUES(N'" & Sreader("projectname").ToString.Trim & "1','*Primary',0,'Projects')"
                                ExecuteSQLQuery(Sqlstr)
                                ExecuteSQLQuery("UPDATE StockInvoiceDetails SET PROJECTNAME=N'" & Sreader("projectname").ToString.Trim & "1' WHERE PROJECTNAME=N'" & Sreader("projectname").ToString.Trim & "'")
                            End If

                        End If
                    End If
                End If
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SQLFcmd.Connection = Nothing
        End Try

    End Sub
    Private Sub PayrollAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayrollAccountsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        PayrollLedgers.SuspendLayout()
        PayrollLedgers.MdiParent = Me
        PayrollLedgers.Dock = DockStyle.Fill
        PayrollLedgers.Show()
        PayrollLedgers.WindowState = FormWindowState.Maximized
        PayrollLedgers.BringToFront()
        PayrollLedgers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PhysicalStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhysicalStockToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockAdjustmentFrm.SuspendLayout()
        StockAdjustmentFrm.MdiParent = Me
        StockAdjustmentFrm.Dock = DockStyle.Fill
        StockAdjustmentFrm.Show()
        StockAdjustmentFrm.WindowState = FormWindowState.Maximized
        StockAdjustmentFrm.BringToFront()
        StockAdjustmentFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StockTransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockTransferToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockJournalbyLoc Is Nothing OrElse StockJournalbyLoc.IsDisposed Then
            StockJournalbyLoc = New StockTransferFrm()
            StockJournalbyLoc.SuspendLayout()
            StockJournalbyLoc.MdiParent = Me

            StockJournalbyLoc.BringToFront()
            StockJournalbyLoc.Dock = DockStyle.Fill
            StockJournalbyLoc.Show()
            StockJournalbyLoc.WindowState = FormWindowState.Maximized
        Else
            StockJournalbyLoc.MdiParent = Me
            StockJournalbyLoc.Dock = DockStyle.Fill
            StockJournalbyLoc.Show()
            StockJournalbyLoc.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub SalesOrdersTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrdersTransactionsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSOReportForm Is Nothing OrElse SalesSOReportForm.IsDisposed Then
            SalesSOReportForm = New SalesTransactionReports("SO")
            SalesSOReportForm.MdiParent = Me
            SalesSOReportForm.BringToFront()
            SalesSOReportForm.Dock = DockStyle.Fill
            SalesSOReportForm.Show()
            SalesSOReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSOReportForm.MdiParent = Me
            SalesSOReportForm.Dock = DockStyle.Fill
            SalesSOReportForm.Show()
            SalesSOReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CustomerBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerBalanceReportToolStripMenuItem.Click
        'CustomersBalanceForm
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If CustomersBalanceForm Is Nothing OrElse CustomersBalanceForm.IsDisposed Then
            CustomersBalanceForm = New LedgerTransactionsReportForm()
            CustomersBalanceForm.MdiParent = Me
            CustomersBalanceForm.BringToFront()
            CustomersBalanceForm.Dock = DockStyle.Fill
            CustomersBalanceForm.Show()
            CustomersBalanceForm.WindowState = FormWindowState.Maximized
        Else
            CustomersBalanceForm.MdiParent = Me
            CustomersBalanceForm.Dock = DockStyle.Fill
            CustomersBalanceForm.Show()
            CustomersBalanceForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CustomersMonthlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersMonthlyReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If CustomerBalaceReportFrom Is Nothing OrElse CustomerBalaceReportFrom.IsDisposed Then
            CustomerBalaceReportFrom = New LedgerBalanceSheetForm
            CustomerBalaceReportFrom.MdiParent = Me
            CustomerBalaceReportFrom.BringToFront()
            CustomerBalaceReportFrom.lblGroupWise.Visible = False
            CustomerBalaceReportFrom.TxtGroupName.Visible = False
            CustomerBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.CustomersAccounts
            CustomerBalaceReportFrom.Dock = DockStyle.Fill
            CustomerBalaceReportFrom.Show()
            CustomerBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            CustomerBalaceReportFrom.MdiParent = Me
            CustomerBalaceReportFrom.Dock = DockStyle.Fill
            CustomerBalaceReportFrom.Show()
            CustomerBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OverDueReceivablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverDueReceivablesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        OverdueReceivablesForm.SuspendLayout()
        OverdueReceivablesForm.MdiParent = Me
        OverdueReceivablesForm.Dock = DockStyle.Fill
        OverdueReceivablesForm.Show()
        OverdueReceivablesForm.WindowState = FormWindowState.Maximized
        OverdueReceivablesForm.BringToFront()
        OverdueReceivablesForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesDeliveriesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveriesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSDReportForm Is Nothing OrElse SalesSDReportForm.IsDisposed Then
            SalesSDReportForm = New SalesTransactionReports("SD")
            SalesSDReportForm.MdiParent = Me
            SalesSDReportForm.BringToFront()
            SalesSDReportForm.Dock = DockStyle.Fill
            SalesSDReportForm.Show()
            SalesSDReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSDReportForm.MdiParent = Me
            SalesSDReportForm.Dock = DockStyle.Fill
            SalesSDReportForm.Show()
            SalesSDReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SalesInvoicesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoicesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSIReportForm Is Nothing OrElse SalesSIReportForm.IsDisposed Then
            SalesSIReportForm = New SalesTransactionReports("SI")
            SalesSIReportForm.MdiParent = Me
            SalesSIReportForm.BringToFront()
            SalesSIReportForm.Dock = DockStyle.Fill
            SalesSIReportForm.Show()
            SalesSIReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSIReportForm.MdiParent = Me
            SalesSIReportForm.Dock = DockStyle.Fill
            SalesSIReportForm.Show()
            SalesSIReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub POSToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripMenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesPOSReportForm Is Nothing OrElse SalesPOSReportForm.IsDisposed Then
            SalesPOSReportForm = New SalesTransactionReports("POS")

            SalesPOSReportForm.MdiParent = Me
            SalesPOSReportForm.BringToFront()
            SalesPOSReportForm.Dock = DockStyle.Fill
            SalesPOSReportForm.Show()
            SalesPOSReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesPOSReportForm.MdiParent = Me
            SalesPOSReportForm.Dock = DockStyle.Fill
            SalesPOSReportForm.Show()
            SalesPOSReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SalesReturnInvoicesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnInvoicesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesSRReportForm Is Nothing OrElse SalesSRReportForm.IsDisposed Then
            SalesSRReportForm = New SalesTransactionReports("SR")
            SalesSRReportForm.MdiParent = Me
            SalesSRReportForm.BringToFront()
            SalesSRReportForm.Dock = DockStyle.Fill
            SalesSRReportForm.Show()
            SalesSRReportForm.WindowState = FormWindowState.Maximized
        Else
            SalesSRReportForm.MdiParent = Me
            SalesSRReportForm.Dock = DockStyle.Fill
            SalesSRReportForm.Show()
            SalesSRReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OutgoingStockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutgoingStockToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        OutgoiningStock.SuspendLayout()
        OutgoiningStock.MdiParent = Me
        OutgoiningStock.Dock = DockStyle.Fill
        OutgoiningStock.Show()
        OutgoiningStock.WindowState = FormWindowState.Maximized
        OutgoiningStock.BringToFront()
        OutgoiningStock.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SuppliersBalancesReportToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppliersBalancesReportToolStripMenuItem2.Click

        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SuppliersBalanceForm Is Nothing OrElse SuppliersBalanceForm.IsDisposed Then
            SuppliersBalanceForm = New LedgerTransactionsReportForm()
            SuppliersBalanceForm.MdiParent = Me
            SuppliersBalanceForm.BringToFront()
            SuppliersBalanceForm.Dock = DockStyle.Fill
            SuppliersBalanceForm.Show()
            SuppliersBalanceForm.WindowState = FormWindowState.Maximized
        Else
            SuppliersBalanceForm.MdiParent = Me
            SuppliersBalanceForm.Dock = DockStyle.Fill
            SuppliersBalanceForm.Show()
            SuppliersBalanceForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SuppliersMonthlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppliersMonthlyReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SupplierBalaceReportFrom Is Nothing OrElse SupplierBalaceReportFrom.IsDisposed Then
            SupplierBalaceReportFrom = New LedgerBalanceSheetForm()
            SupplierBalaceReportFrom.MdiParent = Me
            SupplierBalaceReportFrom.BringToFront()
            SupplierBalaceReportFrom.TxtHeading.Text = "SUPPLIERS BALANCE REPORT"
            SupplierBalaceReportFrom.lblGroupWise.Visible = False
            SupplierBalaceReportFrom.TxtGroupName.Visible = False
            SupplierBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.SuppliersAccounts
            SupplierBalaceReportFrom.Dock = DockStyle.Fill
            SupplierBalaceReportFrom.Show()
            SupplierBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            SupplierBalaceReportFrom.MdiParent = Me
            SupplierBalaceReportFrom.Dock = DockStyle.Fill
            SupplierBalaceReportFrom.Show()
            SupplierBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OverDuePayablesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverDuePayablesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        OverduePayableForm.SuspendLayout()
        OverduePayableForm.MdiParent = Me
        OverduePayableForm.Dock = DockStyle.Fill
        OverduePayableForm.Show()
        OverduePayableForm.WindowState = FormWindowState.Maximized
        OverduePayableForm.BringToFront()
        OverduePayableForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GoodsReceiptNotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoodsReceiptNotesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePGReportForm Is Nothing OrElse PurchasePGReportForm.IsDisposed Then
            PurchasePGReportForm = New PurchaseTransactionReports("PG")
            PurchasePGReportForm.MdiParent = Me
            PurchasePGReportForm.BringToFront()
            PurchasePGReportForm.Dock = DockStyle.Fill
            PurchasePGReportForm.Show()
            PurchasePGReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePGReportForm.MdiParent = Me
            PurchasePGReportForm.Dock = DockStyle.Fill
            PurchasePGReportForm.Show()
            PurchasePGReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PurchaseReturnsInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnsInvoicesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePIReportForm Is Nothing OrElse PurchasePIReportForm.IsDisposed Then
            PurchasePIReportForm = New PurchaseTransactionReports("PR")
            PurchasePIReportForm.MdiParent = Me
            PurchasePIReportForm.BringToFront()
            PurchasePIReportForm.Dock = DockStyle.Fill
            PurchasePIReportForm.Show()
            PurchasePIReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePIReportForm.MdiParent = Me
            PurchasePIReportForm.Dock = DockStyle.Fill
            PurchasePIReportForm.Show()
            PurchasePIReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub IncomingStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncomingStockToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        IncomingStock.SuspendLayout()
        IncomingStock.MdiParent = Me
        IncomingStock.Dock = DockStyle.Fill
        IncomingStock.Show()
        IncomingStock.WindowState = FormWindowState.Maximized
        IncomingStock.BringToFront()
        IncomingStock.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PurchaseInvoicesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoicesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchasePGReportForm Is Nothing OrElse PurchasePGReportForm.IsDisposed Then
            PurchasePGReportForm = New PurchaseTransactionReports("PI")
            PurchasePGReportForm.MdiParent = Me
            PurchasePGReportForm.BringToFront()
            PurchasePGReportForm.Dock = DockStyle.Fill
            PurchasePGReportForm.Show()
            PurchasePGReportForm.WindowState = FormWindowState.Maximized
        Else
            PurchasePGReportForm.MdiParent = Me
            PurchasePGReportForm.Dock = DockStyle.Fill
            PurchasePGReportForm.Show()
            PurchasePGReportForm.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SalesStatusReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesStatusReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SalesStatusReportFrm.SuspendLayout()
        SalesStatusReportFrm.MdiParent = Me
        SalesStatusReportFrm.Dock = DockStyle.Fill
        SalesStatusReportFrm.Show()
        SalesStatusReportFrm.WindowState = FormWindowState.Maximized
        SalesStatusReportFrm.BringToFront()
        SalesStatusReportFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub PayRollPrintingSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayRollPrintingSettingsToolStripMenuItem.Click, ToolStripMenuItem67.Click
        Payrollsettingsfrm.ShowDialog()
    End Sub



    Private Sub SalesCollectionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesCollectionReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SalesCollectionReport.SuspendLayout()
        SalesCollectionReport.MdiParent = Me
        SalesCollectionReport.Dock = DockStyle.Fill
        SalesCollectionReport.Show()
        SalesCollectionReport.WindowState = FormWindowState.Maximized
        SalesCollectionReport.BringToFront()
        SalesCollectionReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PaySlipsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaySlipsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        PaySlipForm.SuspendLayout()
        PaySlipForm.MdiParent = Me
        PaySlipForm.Dock = DockStyle.Fill
        PaySlipForm.Show()
        PaySlipForm.WindowState = FormWindowState.Maximized
        PaySlipForm.BringToFront()
        PaySlipForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MoonltyAttendenceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AttendenceSummeryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub StockAgingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAgingReportToolStripMenuItem.Click
        'Me.Cursor = Cursors.WaitCursor
        'StockAgingReportFrm.SuspendLayout()
        'StockAgingReportFrm.MdiParent = Me
        'StockAgingReportFrm.Dock = DockStyle.Fill
        'StockAgingReportFrm.Show()
        'StockAgingReportFrm.WindowState = FormWindowState.Maximized
        'StockAgingReportFrm.BringToFront()
        'StockAgingReportFrm.ResumeLayout()
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub CostCenterReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostCenterReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CostCenterReportForm.SuspendLayout()
        CostCenterReportForm.MdiParent = Me
        CostCenterReportForm.Dock = DockStyle.Fill
        CostCenterReportForm.Show()
        CostCenterReportForm.WindowState = FormWindowState.Maximized
        CostCenterReportForm.BringToFront()
        CostCenterReportForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AccountBalancesReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountBalancesReportToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If LedgersBalaceReportFrom Is Nothing OrElse LedgersBalaceReportFrom.IsDisposed Then
            LedgersBalaceReportFrom = New LedgerBalanceSheetForm()
            LedgersBalaceReportFrom.MdiParent = Me
            LedgersBalaceReportFrom.BringToFront()
            LedgersBalaceReportFrom.TxtGroupName.Text = AccountGroupNames.CashAccounts
            LedgersBalaceReportFrom.TxtHeading.Text = "CASH ACCOUNTS REPORT "
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.WindowState = FormWindowState.Maximized
        Else
            LedgersBalaceReportFrom.MdiParent = Me
            LedgersBalaceReportFrom.Dock = DockStyle.Fill
            LedgersBalaceReportFrom.Show()
            LedgersBalaceReportFrom.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub MonthlyAttendenceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyAttendenceReportToolStripMenuItem.Click
        If MyAppSettings.IsMrngEvngShiftDuty = True Then
            Me.Cursor = Cursors.WaitCursor
            MonthlyAttendenceReportFrm.SuspendLayout()
            MonthlyAttendenceReportFrm.MdiParent = Me
            MonthlyAttendenceReportFrm.Dock = DockStyle.Fill
            MonthlyAttendenceReportFrm.Show()
            MonthlyAttendenceReportFrm.WindowState = FormWindowState.Maximized
            MonthlyAttendenceReportFrm.BringToFront()
            MonthlyAttendenceReportFrm.ResumeLayout()
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.WaitCursor
            MonthlyAttendenceReprotFromForSingleShift.SuspendLayout()
            MonthlyAttendenceReprotFromForSingleShift.MdiParent = Me
            MonthlyAttendenceReprotFromForSingleShift.Dock = DockStyle.Fill
            MonthlyAttendenceReprotFromForSingleShift.Show()
            MonthlyAttendenceReprotFromForSingleShift.WindowState = FormWindowState.Maximized
            MonthlyAttendenceReprotFromForSingleShift.BringToFront()
            MonthlyAttendenceReprotFromForSingleShift.ResumeLayout()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub AttendenceSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendenceSummaryToolStripMenuItem.Click
        If MyAppSettings.IsMrngEvngShiftDuty = True Then
            Me.Cursor = Cursors.WaitCursor
            AttendenceSummaryFrm.SuspendLayout()
            AttendenceSummaryFrm.MdiParent = Me
            AttendenceSummaryFrm.Dock = DockStyle.Fill
            AttendenceSummaryFrm.Show()
            AttendenceSummaryFrm.WindowState = FormWindowState.Maximized
            AttendenceSummaryFrm.BringToFront()
            AttendenceSummaryFrm.ResumeLayout()
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.WaitCursor
            AtttendenceSummerFormForSingleShift.SuspendLayout()
            AtttendenceSummerFormForSingleShift.MdiParent = Me
            AtttendenceSummerFormForSingleShift.Dock = DockStyle.Fill
            AtttendenceSummerFormForSingleShift.Show()
            AtttendenceSummerFormForSingleShift.WindowState = FormWindowState.Maximized
            AtttendenceSummerFormForSingleShift.BringToFront()
            AtttendenceSummerFormForSingleShift.ResumeLayout()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub PrintBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBarcodeToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Barcodeprintingnewfrm.SuspendLayout()
        Barcodeprintingnewfrm.MdiParent = Me
        Barcodeprintingnewfrm.Dock = DockStyle.Fill
        Barcodeprintingnewfrm.Show()
        Barcodeprintingnewfrm.WindowState = FormWindowState.Maximized
        Barcodeprintingnewfrm.BringToFront()
        Barcodeprintingnewfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub




    Private Sub VATAccountsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VATAccountsToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        VATLedgers.SuspendLayout()
        VATLedgers.MdiParent = Me
        VATLedgers.Dock = DockStyle.Fill
        VATLedgers.Show()
        VATLedgers.WindowState = FormWindowState.Maximized
        VATLedgers.BringToFront()
        VATLedgers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub VATAccountsToolStripMenuItem1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles VATAccountsToolStripMenuItem1.MouseEnter

    End Sub




    Private Function LoadDatabaseLists() As Boolean
        Dim TempBS As New BindingSource
        CompaniesDatabaseLists.AllowUserToAddRows = False
        CompaniesDatabaseLists.AllowUserToDeleteRows = False
        CompaniesDatabaseLists.EditMode = DataGridViewEditMode.EditProgrammatically
        With CompaniesDatabaseLists
            ' TempBS.DataSource = SQLLoadGridData("SELECT NAME  FROM SYS.databases ")
            TempBS.DataSource = SQLLoadGridData("SELECT NAME AS [DBNAME], ' ' AS [CMPNAME] FROM SYS.databases WHERE NAME LIKE N'" & NewCompanyDBName & "%'")
            .AutoGenerateColumns = True
            .DataSource = TempBS
        End With
        If CompaniesDatabaseLists.Rows.Count = 0 Then
            Return False

        Else
            Dim TCN As String = ""
            TCN = ConnectionStrinG
            For i As Integer = 0 To CompaniesDatabaseLists.RowCount - 1
                ConnectionStrinG = TCN & " Initial Catalog=" & CompaniesDatabaseLists.Item("DBNAME", i).Value & ";"
                CompaniesDatabaseLists.Item("cmpname", i).Value = GETCompanyIDName("SELECT CompanyID AS TOT FROM company ", "TOT", "")

            Next
            ConnectionStrinG = TCN
            Return True
        End If
    End Function
    Public Function GETCompanyIDName(ByVal SQLStr As String, ByVal GetFieldName As String, Optional ByVal DefReturn As String = "") As String
        Dim Retvalue As String
        Dim SqlConn As New SqlClient.SqlConnection

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                If IsDBNull(TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim) = True Then
                    Retvalue = ""
                Else
                    Retvalue = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                End If

            Else
                Retvalue = DefReturn
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            'CompanyID
            ExecuteSQLQuery(" ALTER TABLE company ADD CompanyID [nvarchar](125) NULL")
            ExecuteSQLQuery("UPDATE COMPANY SET COMPANYID=N'" & GETSQLDbCmpName("SELECT companyname AS TOT FROM company ", "TOT", "") & "'")
            Retvalue = DefReturn
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try
        Return Retvalue
    End Function
    Public Function GETSQLDbCmpName(ByVal SQLStr As String, ByVal GetFieldName As String, Optional ByVal DefReturn As String = "") As String
        Dim Retvalue As String
        Dim SqlConn As New SqlClient.SqlConnection

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                If IsDBNull(TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim) = True Then
                    Retvalue = ""
                Else
                    Retvalue = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                End If
            Else
                Retvalue = DefReturn
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            Retvalue = DefReturn
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
        End Try
        Return Retvalue
    End Function
    Public Sub LoadCompaniesList(ByVal cob As IMSComboBox)
        cob.Items.Clear()
        For I As Integer = 0 To CompaniesDatabaseLists.RowCount - 1
            cob.Items.Add(CompaniesDatabaseLists.Item("CMPNAME", I).Value)
        Next

    End Sub
    Public Function GetCompanyDatabaseName(ByVal cmpname As String) As String
        Dim dBNAME As String = ""
        For I As Integer = 0 To CompaniesDatabaseLists.RowCount - 1
            If UCase(CompaniesDatabaseLists.Item("CMPNAME", I).Value) = UCase(cmpname) Then
                dBNAME = CompaniesDatabaseLists.Item("DBNAME", I).Value
                Exit For
            End If
        Next
        Return dBNAME
    End Function
    Public Function IsCompanyNameisExists(ByVal cmpname As String, Optional ByVal excludethisCmpname As String = "") As Boolean
        Dim Retvalue As Boolean = False
        If UCase(cmpname) = UCase(excludethisCmpname) Then
            Retvalue = False
        Else
            For I As Integer = 0 To CompaniesDatabaseLists.RowCount - 1
                If UCase(CompaniesDatabaseLists.Item("CMPNAME", I).Value) = UCase(cmpname) Then
                    Retvalue = True
                    Exit For
                End If
            Next
        End If

        Return Retvalue
    End Function

    Private Sub BalanceSheetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceSheetToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        AdvBalanceSheet.SuspendLayout()
        AdvBalanceSheet.MdiParent = Me
        AdvBalanceSheet.Dock = DockStyle.Fill
        AdvBalanceSheet.Show()
        AdvBalanceSheet.WindowState = FormWindowState.Maximized
        AdvBalanceSheet.BringToFront()
        AdvBalanceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RollPaperSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RollPaperSettingsToolStripMenuItem.Click, ToolStripMenuItem68.Click
        RollPaperPrintingSettingsForm.ShowDialog()
    End Sub



    Private Sub TestingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestingToolStripMenuItem.Click
        'tempform2.ShowDialog()
        ExportData.ShowDialog()
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        If FullScreenToolStripMenuItem.Text = "Full Screen" Then
            FullScreenToolStripMenuItem.Text = "Exit Full Screen"
            AppCompanyTitleBar.Visible = False
            AppMainBarContainer.Height = 1
            AppSideBarContainer.Width = 1
        Else
            FullScreenToolStripMenuItem.Text = "Full Screen"
            AppCompanyTitleBar.Visible = True
            AppMainBarContainer.Height = 66
            AppSideBarContainer.Width = 220

        End If
    End Sub

    Private Sub ExpiryStockItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryStockItemsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ExpiryStockForm.SuspendLayout()
        ExpiryStockForm.MdiParent = Me
        ExpiryStockForm.Dock = DockStyle.Fill
        ExpiryStockForm.Show()
        ExpiryStockForm.WindowState = FormWindowState.Maximized
        ExpiryStockForm.BringToFront()
        ExpiryStockForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub YearENDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearENDToolStripMenuItem.Click
        If My.Application.OpenForms.Count > 1 Then
            MsgBox("Please Close all forms to procced this process.....", MsgBoxStyle.Information)
            Exit Sub
        End If
        YearEnd.ShowDialog()
    End Sub



    Private Sub VATComputationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VATComputationToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VATComputation.SuspendLayout()
        VATComputation.MdiParent = Me
        VATComputation.Dock = DockStyle.Fill
        VATComputation.Show()
        VATComputation.WindowState = FormWindowState.Maximized
        VATComputation.BringToFront()
        VATComputation.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PurchaseVATReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseVATReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VATPurchaseRegister.SuspendLayout()
        VATPurchaseRegister.MdiParent = Me
        VATPurchaseRegister.Dock = DockStyle.Fill
        VATPurchaseRegister.Show()
        VATPurchaseRegister.WindowState = FormWindowState.Maximized
        VATPurchaseRegister.BringToFront()
        VATPurchaseRegister.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesVATReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesVATReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VATSalesRegister.SuspendLayout()
        VATSalesRegister.MdiParent = Me
        VATSalesRegister.Dock = DockStyle.Fill
        VATSalesRegister.Show()
        VATSalesRegister.WindowState = FormWindowState.Maximized
        VATSalesRegister.BringToFront()
        VATSalesRegister.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub BatchWiseStockDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchWiseStockDetailsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockBatchWiseDetails.SuspendLayout()
        StockBatchWiseDetails.MdiParent = Me
        StockBatchWiseDetails.Dock = DockStyle.Fill
        StockBatchWiseDetails.Show()
        StockBatchWiseDetails.WindowState = FormWindowState.Maximized
        StockBatchWiseDetails.BringToFront()
        StockBatchWiseDetails.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub





    Private Sub DailyProfitReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyProfitReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        DailyProfitReportITemwise.SuspendLayout()
        DailyProfitReportITemwise.MdiParent = Me
        DailyProfitReportITemwise.Dock = DockStyle.Fill
        DailyProfitReportITemwise.Show()
        DailyProfitReportITemwise.WindowState = FormWindowState.Maximized
        DailyProfitReportITemwise.BringToFront()
        DailyProfitReportITemwise.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ProfitSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitSummaryToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        profitreportsummary.SuspendLayout()
        profitreportsummary.MdiParent = Me
        profitreportsummary.Dock = DockStyle.Fill
        profitreportsummary.Show()
        profitreportsummary.WindowState = FormWindowState.Maximized
        profitreportsummary.BringToFront()
        profitreportsummary.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CurrentPeriodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentPeriodToolStripMenuItem.Click
        Dim frm As New ChangeCurrentPeriod
        frm.ShowDialog()
        frm.Dispose()
    End Sub




    Private Sub ProfitLossAcToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitLossAcToolStripMenuItem1.Click

    End Sub

    Private Sub LedgerAccountReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerAccountReportsToolStripMenuItem.Click

    End Sub

    Private Sub LowStockItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LowStockItemsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ReorderForm.SuspendLayout()
        ReorderForm.MdiParent = Me
        ReorderForm.Dock = DockStyle.Fill
        ReorderForm.Show()
        ReorderForm.WindowState = FormWindowState.Maximized
        ReorderForm.BringToFront()
        ReorderForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CurrentDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CurrentDateFrm.ShowDialog()
    End Sub

    Private Sub EmployeeIncrementsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeIncrementsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        empsalaryincrements.SuspendLayout()
        empsalaryincrements.MdiParent = Me
        empsalaryincrements.Dock = DockStyle.Fill
        empsalaryincrements.Show()
        empsalaryincrements.WindowState = FormWindowState.Maximized
        empsalaryincrements.BringToFront()
        empsalaryincrements.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DailyAbsentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyAbsentReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeDailyAbsentForm.SuspendLayout()
        EmployeeDailyAbsentForm.MdiParent = Me
        EmployeeDailyAbsentForm.Dock = DockStyle.Fill
        EmployeeDailyAbsentForm.Show()
        EmployeeDailyAbsentForm.WindowState = FormWindowState.Maximized
        EmployeeDailyAbsentForm.BringToFront()
        EmployeeDailyAbsentForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DailyPresentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyPresentReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeDailyPresentform.SuspendLayout()
        EmployeeDailyPresentform.MdiParent = Me
        EmployeeDailyPresentform.Dock = DockStyle.Fill
        EmployeeDailyPresentform.Show()
        EmployeeDailyPresentform.WindowState = FormWindowState.Maximized
        EmployeeDailyPresentform.BringToFront()
        EmployeeDailyPresentform.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MonthlyPresentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyPresentReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeMonthlyPresentAttendens.SuspendLayout()
        EmployeeMonthlyPresentAttendens.MdiParent = Me
        EmployeeMonthlyPresentAttendens.Dock = DockStyle.Fill
        EmployeeMonthlyPresentAttendens.Show()
        EmployeeMonthlyPresentAttendens.WindowState = FormWindowState.Maximized
        EmployeeMonthlyPresentAttendens.BringToFront()
        EmployeeMonthlyPresentAttendens.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MonthlyAbsentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyAbsentReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeMonthlyAbsentAttendsForm.SuspendLayout()
        EmployeeMonthlyAbsentAttendsForm.MdiParent = Me
        EmployeeMonthlyAbsentAttendsForm.Dock = DockStyle.Fill
        EmployeeMonthlyAbsentAttendsForm.Show()
        EmployeeMonthlyAbsentAttendsForm.WindowState = FormWindowState.Maximized
        EmployeeMonthlyAbsentAttendsForm.BringToFront()
        EmployeeMonthlyAbsentAttendsForm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DashBoardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DashBoardToolStripMenuItem.Click
        If IsUserAdmin = True Then
            Me.Cursor = Cursors.WaitCursor
            AdvDashBoardfrm.SuspendLayout()
            AdvDashBoardfrm.MdiParent = Me
            AdvDashBoardfrm.Dock = DockStyle.Fill
            AdvDashBoardfrm.Show()
            AdvDashBoardfrm.WindowState = FormWindowState.Maximized
            AdvDashBoardfrm.BringToFront()
            AdvDashBoardfrm.ResumeLayout()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SerialNumbersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialNumbersToolStripMenuItem.Click

    End Sub

    Private Sub SMSSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMSSettingsToolStripMenuItem.Click, ToolStripMenuItem71.Click
        Dim k As New SMSSettingForm
        k.ShowDialog()
    End Sub

    Private Sub BtnNotes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNotes.Click
        notesfrm.Show()
    End Sub

    Private Sub OtherSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherSettingsToolStripMenuItem.Click, ToolStripMenuItem69.Click
        ExportPrintSettings.ShowDialog()
    End Sub

    Private Sub StockJournalVoucherToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockJournalVoucherToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        StockJournalFrm.SuspendLayout()
        StockJournalFrm.MdiParent = Me
        StockJournalFrm.Dock = DockStyle.Fill
        StockJournalFrm.Show()
        StockJournalFrm.WindowState = FormWindowState.Maximized
        StockJournalFrm.BringToFront()
        StockJournalFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StockTransferByLocationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockTransferByLocationsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockJournalbyLoc Is Nothing OrElse StockJournalbyLoc.IsDisposed Then
            StockJournalbyLoc = New StockTransferFrm()
            StockJournalbyLoc.SuspendLayout()
            StockJournalbyLoc.MdiParent = Me

            StockJournalbyLoc.BringToFront()
            StockJournalbyLoc.Dock = DockStyle.Fill
            StockJournalbyLoc.Show()
            StockJournalbyLoc.WindowState = FormWindowState.Maximized
        Else
            StockJournalbyLoc.MdiParent = Me
            StockJournalbyLoc.Dock = DockStyle.Fill
            StockJournalbyLoc.Show()
            StockJournalbyLoc.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ChequeInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChequeInfoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        bankchequeInfo.SuspendLayout()
        bankchequeInfo.MdiParent = Me
        bankchequeInfo.Dock = DockStyle.Fill
        bankchequeInfo.Show()
        bankchequeInfo.WindowState = FormWindowState.Maximized
        bankchequeInfo.BringToFront()
        bankchequeInfo.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintMulitipleInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintMulitipleInvoicesToolStripMenuItem.Click
        Dim frm As New MultiSalesInvoices
        frm.WindowState = FormWindowState.Maximized
        frm.ShowDialog()
    End Sub

    Private Sub PrintMulitiplePurchaseInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintMulitiplePurchaseInvoicesToolStripMenuItem.Click
        Dim frm As New multiPurchaseInvoices
        frm.WindowState = FormWindowState.Maximized
        frm.ShowDialog()
    End Sub

    Private Sub CouponManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CouponManagementToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Coupons.SuspendLayout()
        Coupons.MdiParent = Me
        Coupons.Dock = DockStyle.Fill
        Coupons.Show()
        Coupons.WindowState = FormWindowState.Maximized
        Coupons.BringToFront()
        Coupons.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ChangeCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompanyToolStripMenuItem.Click
        If MsgBox("Do you want to Select the Company ?              ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'closing opened forms
            Dim tfrms As Integer = 0
            tfrms = My.Application.OpenForms.Count - 1
            For i As Integer = 0 To tfrms
                If My.Application.OpenForms(0).Equals(Me) = True Then
                    Try
                        My.Application.OpenForms(1).Close()
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        My.Application.OpenForms(0).Close()
                    Catch ex As Exception

                    End Try
                End If
            Next
            If My.Application.OpenForms.Count > 1 Then
                MsgBox("Please close all forms , then try again....")
                Exit Sub
            End If
            LoginIntoAPP(True)
        End If

    End Sub

    Private Sub DeleteCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCompanyToolStripMenuItem.Click
        DeleteCompany.ShowDialog()

    End Sub

    Private Sub SalesForm8DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesForm8DToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOSform8D Is Nothing OrElse SalesInvoiceFormPOSform8D.IsDisposed Then

            SalesInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("POS", , "Cash Sales")
            SalesInvoiceFormPOSform8D.MdiParent = Me
            SalesInvoiceFormPOSform8D.BringToFront()
            SalesInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8D.Show()
            SalesInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOSform8D.MdiParent = Me
            SalesInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8D.Show()
            SalesInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesForm8BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesForm8BToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOSform8b Is Nothing OrElse SalesInvoiceFormPOSform8b.IsDisposed Then

            SalesInvoiceFormPOSform8b = New SalesInvoiceAllFormControl("POS", , "Credit Sales")
            SalesInvoiceFormPOSform8b.MdiParent = Me
            SalesInvoiceFormPOSform8b.BringToFront()
            SalesInvoiceFormPOSform8b.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8b.Show()
            SalesInvoiceFormPOSform8b.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOSform8b.MdiParent = Me
            SalesInvoiceFormPOSform8b.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8b.Show()
            SalesInvoiceFormPOSform8b.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesForm8ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOSform8 Is Nothing OrElse SalesInvoiceFormPOSform8.IsDisposed Then

            SalesInvoiceFormPOSform8 = New SalesInvoiceAllFormControl("POS", , "Form-8")
            SalesInvoiceFormPOSform8.MdiParent = Me
            SalesInvoiceFormPOSform8.BringToFront()
            SalesInvoiceFormPOSform8.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8.Show()
            SalesInvoiceFormPOSform8.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOSform8.MdiParent = Me
            SalesInvoiceFormPOSform8.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8.Show()
            SalesInvoiceFormPOSform8.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VATAllSalesVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VATAllSalesVoucherToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VATAllSalesVouchers.SuspendLayout()
        VATAllSalesVouchers.MdiParent = Me
        VATAllSalesVouchers.Dock = DockStyle.Fill
        VATAllSalesVouchers.Show()
        VATAllSalesVouchers.WindowState = FormWindowState.Maximized
        VATAllSalesVouchers.BringToFront()
        VATAllSalesVouchers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LedgerDayWiseBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerDayWiseBalanceToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ledgerdaywisebalancereport.SuspendLayout()
        ledgerdaywisebalancereport.MdiParent = Me
        ledgerdaywisebalancereport.Dock = DockStyle.Fill
        ledgerdaywisebalancereport.Show()
        ledgerdaywisebalancereport.WindowState = FormWindowState.Maximized
        ledgerdaywisebalancereport.BringToFront()
        ledgerdaywisebalancereport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VATAllPurchaseVucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VATAllPurchaseVucherToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VATAllPurchaseVouchers.SuspendLayout()
        VATAllPurchaseVouchers.MdiParent = Me
        VATAllPurchaseVouchers.Dock = DockStyle.Fill
        VATAllPurchaseVouchers.Show()
        VATAllPurchaseVouchers.WindowState = FormWindowState.Maximized
        VATAllPurchaseVouchers.BringToFront()
        VATAllPurchaseVouchers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarcodeSettingsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeSettingsToolStripMenuItem1.Click
        Dim frm As New BarcodeSettingsFrm
        frm.ShowDialog()
    End Sub

    Private Sub SalesReturns8DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnsInvoiceFormPOSform8D Is Nothing OrElse SalesReturnsInvoiceFormPOSform8D.IsDisposed Then

            SalesReturnsInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("SR", , "Returns Cash Sales")
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesReturnsForm8BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnsInvoiceFormPOSform8D Is Nothing OrElse SalesReturnsInvoiceFormPOSform8D.IsDisposed Then

            SalesReturnsInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("SR", , "Returns Cash Sales")
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesReturnsForm8ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnsInvoiceFormPOSform8D Is Nothing OrElse SalesReturnsInvoiceFormPOSform8D.IsDisposed Then

            SalesReturnsInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("SR", , "Returns Cash Sales")
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ItemwiseQuantityReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemwiseQuantityReportToolStripMenuItem.Click
        ''
        Me.Cursor = Cursors.WaitCursor
        ItemwiseQuantityReportfrm.SuspendLayout()
        ItemwiseQuantityReportfrm.MdiParent = Me
        ItemwiseQuantityReportfrm.Dock = DockStyle.Fill
        ItemwiseQuantityReportfrm.Show()
        ItemwiseQuantityReportfrm.WindowState = FormWindowState.Maximized
        ItemwiseQuantityReportfrm.BringToFront()
        ItemwiseQuantityReportfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ItemwiseMovementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemwiseMovementReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ItemMovementbyLedgerwisefrm.SuspendLayout()
        ItemMovementbyLedgerwisefrm.MdiParent = Me
        ItemMovementbyLedgerwisefrm.Dock = DockStyle.Fill
        ItemMovementbyLedgerwisefrm.Show()
        ItemMovementbyLedgerwisefrm.WindowState = FormWindowState.Maximized
        ItemMovementbyLedgerwisefrm.BringToFront()
        ItemMovementbyLedgerwisefrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem42.Click
        Me.Cursor = Cursors.WaitCursor
        ItemMovementByLedgerWisePurchase.SuspendLayout()
        ItemMovementByLedgerWisePurchase.MdiParent = Me
        ItemMovementByLedgerWisePurchase.Dock = DockStyle.Fill
        ItemMovementByLedgerWisePurchase.Show()
        ItemMovementByLedgerWisePurchase.WindowState = FormWindowState.Maximized
        ItemMovementByLedgerWisePurchase.BringToFront()
        ItemMovementByLedgerWisePurchase.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem43.Click
        Me.Cursor = Cursors.WaitCursor
        ItemwiseQuantityPurchaseFrm.SuspendLayout()
        ItemwiseQuantityPurchaseFrm.MdiParent = Me
        ItemwiseQuantityPurchaseFrm.Dock = DockStyle.Fill
        ItemwiseQuantityPurchaseFrm.Show()
        ItemwiseQuantityPurchaseFrm.WindowState = FormWindowState.Maximized
        ItemwiseQuantityPurchaseFrm.BringToFront()
        ItemwiseQuantityPurchaseFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SerialNumbersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialNumbersToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        SerialNumberManagement.SuspendLayout()
        SerialNumberManagement.MdiParent = Me
        SerialNumberManagement.Dock = DockStyle.Fill
        SerialNumberManagement.Show()
        SerialNumberManagement.WindowState = FormWindowState.Maximized
        SerialNumberManagement.BringToFront()
        SerialNumberManagement.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CashPurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashPurchaseToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPI Is Nothing OrElse PurchaseInvoiceFormPI.IsDisposed Then
            PurchaseInvoiceFormPI = New PurchaseInvoiceAllFromControl("DP", "Cash Purchase")
            PurchaseInvoiceFormPI.MdiParent = Me
            PurchaseInvoiceFormPI.BringToFront()
            PurchaseInvoiceFormPI.Dock = DockStyle.Fill
            PurchaseInvoiceFormPI.Show()
            PurchaseInvoiceFormPI.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPI.MdiParent = Me
            PurchaseInvoiceFormPI.Dock = DockStyle.Fill
            PurchaseInvoiceFormPI.Show()
            PurchaseInvoiceFormPI.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CreditPurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditPurchaseToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPI Is Nothing OrElse PurchaseInvoiceFormPI.IsDisposed Then
            PurchaseInvoiceFormPI = New PurchaseInvoiceAllFromControl("DP", "Credit Purchase")
            PurchaseInvoiceFormPI.MdiParent = Me
            PurchaseInvoiceFormPI.BringToFront()
            PurchaseInvoiceFormPI.Dock = DockStyle.Fill
            PurchaseInvoiceFormPI.Show()
            PurchaseInvoiceFormPI.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPI.MdiParent = Me
            PurchaseInvoiceFormPI.Dock = DockStyle.Fill
            PurchaseInvoiceFormPI.Show()
            PurchaseInvoiceFormPI.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel3_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub AttendenceEntryDoubleShiftToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AttendenceEntryDoubleShiftToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmpAttendenceDoubleShiftEntry.SuspendLayout()
        EmpAttendenceDoubleShiftEntry.MdiParent = Me
        EmpAttendenceDoubleShiftEntry.Dock = DockStyle.Fill
        EmpAttendenceDoubleShiftEntry.Show()
        EmpAttendenceDoubleShiftEntry.WindowState = FormWindowState.Maximized
        EmpAttendenceDoubleShiftEntry.BringToFront()
        EmpAttendenceDoubleShiftEntry.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesRegisterInvoiceWiseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesRegisterInvoiceWiseToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SalesRegisterInvoiceWise.SuspendLayout()
        SalesRegisterInvoiceWise.MdiParent = Me
        SalesRegisterInvoiceWise.Dock = DockStyle.Fill
        SalesRegisterInvoiceWise.Show()
        SalesRegisterInvoiceWise.WindowState = FormWindowState.Maximized
        SalesRegisterInvoiceWise.BringToFront()
        SalesRegisterInvoiceWise.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RoundOffSettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RoundOffSettingsToolStripMenuItem.Click, ToolStripMenuItem61.Click
        Roundoffsettingsfrm.ShowDialog()
    End Sub

    Private Sub DocumentIssueToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DocumentIssueToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        DocumentIssuesfrm.SuspendLayout()
        DocumentIssuesfrm.MdiParent = Me
        DocumentIssuesfrm.Dock = DockStyle.Fill
        DocumentIssuesfrm.Show()
        DocumentIssuesfrm.WindowState = FormWindowState.Maximized
        DocumentIssuesfrm.BringToFront()
        DocumentIssuesfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CompanyDocsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CompanyDocsToolStripMenuItem1.Click

    End Sub

    Private Sub PendingDeliveryNotesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PendingDeliveryNotesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SalesDeliveryNotePendings.SuspendLayout()
        SalesDeliveryNotePendings.MdiParent = Me
        SalesDeliveryNotePendings.Dock = DockStyle.Fill
        SalesDeliveryNotePendings.Show()
        SalesDeliveryNotePendings.WindowState = FormWindowState.Maximized
        SalesDeliveryNotePendings.BringToFront()
        SalesDeliveryNotePendings.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem45_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem45.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOSform8D Is Nothing OrElse SalesInvoiceFormPOSform8D.IsDisposed Then

            SalesInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("POS", , "Form-8D")
            SalesInvoiceFormPOSform8D.MdiParent = Me
            SalesInvoiceFormPOSform8D.BringToFront()
            SalesInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8D.Show()
            SalesInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOSform8D.MdiParent = Me
            SalesInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8D.Show()
            SalesInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem46_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem46.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOSform8b Is Nothing OrElse SalesInvoiceFormPOSform8b.IsDisposed Then

            SalesInvoiceFormPOSform8b = New SalesInvoiceAllFormControl("POS", , "Form-8B")
            SalesInvoiceFormPOSform8b.MdiParent = Me
            SalesInvoiceFormPOSform8b.BringToFront()
            SalesInvoiceFormPOSform8b.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8b.Show()
            SalesInvoiceFormPOSform8b.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOSform8b.MdiParent = Me
            SalesInvoiceFormPOSform8b.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8b.Show()
            SalesInvoiceFormPOSform8b.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesForm8ToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles SalesForm8ToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOSform8 Is Nothing OrElse SalesInvoiceFormPOSform8.IsDisposed Then

            SalesInvoiceFormPOSform8 = New SalesInvoiceAllFormControl("POS", , "Form-8")
            SalesInvoiceFormPOSform8.MdiParent = Me
            SalesInvoiceFormPOSform8.BringToFront()
            SalesInvoiceFormPOSform8.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8.Show()
            SalesInvoiceFormPOSform8.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOSform8.MdiParent = Me
            SalesInvoiceFormPOSform8.Dock = DockStyle.Fill
            SalesInvoiceFormPOSform8.Show()
            SalesInvoiceFormPOSform8.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesReturns8DToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles SalesReturns8DToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnsInvoiceFormPOSform8D Is Nothing OrElse SalesReturnsInvoiceFormPOSform8D.IsDisposed Then

            SalesReturnsInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("SR", , "Returns Form-8D")
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesReturnsForm8BToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles SalesReturnsForm8BToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnsInvoiceFormPOSform8D Is Nothing OrElse SalesReturnsInvoiceFormPOSform8D.IsDisposed Then

            SalesReturnsInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("SR", , "Returns Form-8D")
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SalesReturnsForm8ToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles SalesReturnsForm8ToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesReturnsInvoiceFormPOSform8D Is Nothing OrElse SalesReturnsInvoiceFormPOSform8D.IsDisposed Then

            SalesReturnsInvoiceFormPOSform8D = New SalesInvoiceAllFormControl("SR", , "Returns Form-8D")
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.WindowState = FormWindowState.Maximized
        Else
            SalesReturnsInvoiceFormPOSform8D.MdiParent = Me
            SalesReturnsInvoiceFormPOSform8D.Dock = DockStyle.Fill
            SalesReturnsInvoiceFormPOSform8D.Show()
            SalesReturnsInvoiceFormPOSform8D.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReIndexDatabaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReIndexDatabaseToolStripMenuItem.Click
        If MsgBox("Do You want to Reindexes the Database ?      ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MainSqlConn.ConnectionString = ConnectionStrinG
            MainSqlConn.Open()
            Dim SQLFcmdtemp As New SqlClient.SqlCommand

            SQLFcmdtemp.Connection = MainSqlConn

            Try
                ' CREATE INDEXES





                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [AccountGroupsindx] ON [AccountGroups] (	[GroupName] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = " CREATE CLUSTERED INDEX [AccountGroupsListindx] ON [AccountGroupsList] (	[groupname] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) On [PRIMARY]"
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = " CREATE CLUSTERED INDEX [Bill2Billindx] ON [Bill2Bill] (	[LedgerName] ASC,	[TransCode] ASC,	[BillTransCode] ASC ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [CompanyLeavesindx] ON [CompanyLeaves] (	[LeaveName] ASC,	[FromDateValue] ASC ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = " CREATE CLUSTERED INDEX [CostCenterBookindx] ON [CostCenterBook] (	[LedgerName] ASC,	[TransCode] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = " CREATE CLUSTERED INDEX [couponmasterIndx] ON [couponmaster] (	[Cname] ASC,	[datefrom] ASC,	[dateto] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE NONCLUSTERED INDEX [Dutiesindx] ON [Duties] (	[EmpName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [Dutysettingsindx] ON [Dutysettings] (	[ShiftName] ASC,	[Timein] ASC,	[ShiftType] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [EmpAttendIndx] ON [EmpAttend] (	[EmpName] ASC,	[Transdatevalue] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [EmployeesIndx] ON [Employees] (	[EmpName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [EmpSalariesIndx] ON [EmpSalaries] (	[EmpName] ASC,	[FromDate] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = " CREATE CLUSTERED INDEX [imagesIndx] ON [images] (	[Bcode] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [LeavesIndx] ON [Leaves] (	[LeaveName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = " CREATE CLUSTERED INDEX [LedgerBookIndx] ON [LedgerBook] (	[LedgerName] ASC,	[TransCode] ASC,	[TransDateValue] ASC,	[InvoiceType] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [ledgersIndx] ON [ledgers] (	[LedgerName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [logfileIndx] ON [logfile] (	[StoreName] ASC,	[Transcode] ASC,	[vouchername] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = " CREATE CLUSTERED INDEX [serialnumbermasterIndx] ON [serialnumbermaster] (	[STOCKCODE] ASC,	[STOCKSIZE] ASC,	[SERIALNUMBER] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [StockBatchIndx] ON [StockBatch] (	[StockCode] ASC,	[StockSize] ASC,	[Location] ASC,	[BatchNo] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [StockDbfIndx] ON [StockDbf] (	[StockCode] ASC,	[Barcode] ASC,	[StockSize] ASC,	[Location] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [StockInvoiceDetailsIndx] ON [StockInvoiceDetails] (	[TransCode] ASC,	[LedgerName] ASC,	[VoucherName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [StockInvoiceRowItemsIndx] ON [StockInvoiceRowItems] (	[TransCode] ASC,	[StockCode] ASC,	[Location] ASC,	[VoucherName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [StockJournalDbfIndx] ON [StockJournalDbf] (	[Transcode] ASC,	[LocationFrom] ASC,	[LocationTo] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [StockunitsIndx] ON [Stockunits] (	[UnitName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()

                SQLFcmdtemp.CommandText = "CREATE CLUSTERED INDEX [VehicleIndx] ON [Vehicle] (	[VhType] ASC,	[VHID] ASC,	[VHName] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
                SQLFcmdtemp.CommandType = CommandType.Text
                SQLFcmdtemp.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            'REBUILD THE INDEXES
            SQLFcmdtemp.CommandText = " ALTER INDEX [AccountGroupsindx] ON [AccountGroups] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = " ALTER INDEX [AccountGroupsListindx] ON [AccountGroupsList] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [Bill2Billindx] ON [Bill2Bill] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [CompanyLeavesindx] ON [CompanyLeaves] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [CostCenterBookindx] ON [CostCenterBook] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [couponmasterIndx] ON [couponmaster] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [Dutiesindx] ON [Duties] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [Dutysettingsindx] ON [Dutysettings] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [EmpAttendIndx] ON [EmpAttend] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [EmployeesIndx] ON [Employees] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [EmpSalariesIndx] ON [EmpSalaries] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [imagesIndx] ON [images] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = " ALTER INDEX [LeavesIndx] ON [Leaves] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [LedgerBookIndx] ON [LedgerBook] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [ledgersIndx] ON [ledgers] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [logfileIndx] ON [logfile] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [serialnumbermasterIndx] ON [serialnumbermaster] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [StockBatchIndx] ON [StockBatch] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [StockDbfIndx] ON [StockDbf] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [StockInvoiceDetailsIndx] ON [StockInvoiceDetails] REBUILD     "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [StockInvoiceRowItemsIndx] ON [StockInvoiceRowItems] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [StockJournalDbfIndx] ON [StockJournalDbf] REBUILD"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [StockunitsIndx] ON [Stockunits] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [VehicleIndx] ON [Vehicle] REBUILD "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            'indexe reconzie
            SQLFcmdtemp.CommandText = " ALTER INDEX [AccountGroupsindx] ON [AccountGroups] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = " ALTER INDEX [AccountGroupsListindx] ON [AccountGroupsList] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [Bill2Billindx] ON [Bill2Bill] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [CompanyLeavesindx] ON [CompanyLeaves] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [CostCenterBookindx] ON [CostCenterBook] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [couponmasterIndx] ON [couponmaster] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [Dutiesindx] ON [Duties] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [Dutysettingsindx] ON [Dutysettings] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [EmpAttendIndx] ON [EmpAttend] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [EmployeesIndx] ON [Employees] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [EmpSalariesIndx] ON [EmpSalaries] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [imagesIndx] ON [images] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = " ALTER INDEX [LeavesIndx] ON [Leaves] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [LedgerBookIndx] ON [LedgerBook] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [ledgersIndx] ON [ledgers] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [logfileIndx] ON [logfile] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [serialnumbermasterIndx] ON [serialnumbermaster] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [StockBatchIndx] ON [StockBatch] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [StockDbfIndx] ON [StockDbf] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [StockInvoiceDetailsIndx] ON [StockInvoiceDetails] REORGANIZE     "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()

            SQLFcmdtemp.CommandText = "ALTER INDEX [StockInvoiceRowItemsIndx] ON [StockInvoiceRowItems] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = " ALTER INDEX [StockJournalDbfIndx] ON [StockJournalDbf] REORGANIZE"
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [StockunitsIndx] ON [Stockunits] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()


            SQLFcmdtemp.CommandText = "ALTER INDEX [VehicleIndx] ON [Vehicle] REORGANIZE "
            SQLFcmdtemp.CommandType = CommandType.Text
            SQLFcmdtemp.ExecuteNonQuery()
            MainSqlConn.Close()
        End If
    End Sub

    Private Sub InvoiceWiseProfitReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InvoiceWiseProfitReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        InvoiceWiseProfitReport.SuspendLayout()
        InvoiceWiseProfitReport.MdiParent = Me
        InvoiceWiseProfitReport.Dock = DockStyle.Fill
        InvoiceWiseProfitReport.Show()
        InvoiceWiseProfitReport.WindowState = FormWindowState.Maximized
        InvoiceWiseProfitReport.BringToFront()
        InvoiceWiseProfitReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

  

    Private Sub MonthlyAttendenceReportByDayWiseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MonthlyAttendenceReportByDayWiseToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Monthlyattreportdaywise.SuspendLayout()
        Monthlyattreportdaywise.MdiParent = Me
        Monthlyattreportdaywise.Dock = DockStyle.Fill
        Monthlyattreportdaywise.Show()
        Monthlyattreportdaywise.WindowState = FormWindowState.Maximized
        Monthlyattreportdaywise.BringToFront()
        Monthlyattreportdaywise.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintingSettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintingSettingsToolStripMenuItem.Click, ToolStripMenuItem62.Click

    End Sub

    Private Sub SheduleAppointmentsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SheduleAppointmentsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        AppointmentsDashBoard.SuspendLayout()
        AppointmentsDashBoard.MdiParent = Me
        AppointmentsDashBoard.Dock = DockStyle.Fill
        AppointmentsDashBoard.Show()
        AppointmentsDashBoard.WindowState = FormWindowState.Maximized
        AppointmentsDashBoard.BringToFront()
        AppointmentsDashBoard.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

   
    Private Sub PrintBarcodeFixedSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Barcodeprintingnewfrm.SuspendLayout()
        Barcodeprintingnewfrm.MdiParent = Me
        Barcodeprintingnewfrm.Dock = DockStyle.Fill
        Barcodeprintingnewfrm.Show()
        Barcodeprintingnewfrm.WindowState = FormWindowState.Maximized
        Barcodeprintingnewfrm.BringToFront()
        Barcodeprintingnewfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintBarcodeToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles PrintBarcodeToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        PrintBarcodeLabelfrm.SuspendLayout()
        PrintBarcodeLabelfrm.MdiParent = Me
        PrintBarcodeLabelfrm.Dock = DockStyle.Fill
        PrintBarcodeLabelfrm.Show()
        PrintBarcodeLabelfrm.WindowState = FormWindowState.Maximized
        PrintBarcodeLabelfrm.BringToFront()
        PrintBarcodeLabelfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ApprovePurchaseEnquiriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ApprovePurchaseEnquiriesToolStripMenuItem.Click
        'ApprovePurchaseEnquiriesfrm
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If ApprovePurchaseEnquirieSVAR Is Nothing OrElse ApprovePurchaseEnquirieSVAR.IsDisposed Then
            ApprovePurchaseEnquirieSVAR = New ApprovePurchaseEnquiriesfrm("PQ")
            ApprovePurchaseEnquirieSVAR.MdiParent = Me
            ApprovePurchaseEnquirieSVAR.BringToFront()
            ApprovePurchaseEnquirieSVAR.Dock = DockStyle.Fill
            ApprovePurchaseEnquirieSVAR.Show()
            ApprovePurchaseEnquirieSVAR.WindowState = FormWindowState.Maximized
        Else
            ApprovePurchaseEnquirieSVAR.MdiParent = Me
            ApprovePurchaseEnquirieSVAR.Dock = DockStyle.Fill
            ApprovePurchaseEnquirieSVAR.Show()
            ApprovePurchaseEnquirieSVAR.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub MaterialTransferRequestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MaterialTransferRequestToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Materialtransferrequestfrm.SuspendLayout()
        Materialtransferrequestfrm.MdiParent = Me
        Materialtransferrequestfrm.Dock = DockStyle.Fill
        Materialtransferrequestfrm.Show()
        Materialtransferrequestfrm.WindowState = FormWindowState.Maximized
        Materialtransferrequestfrm.BringToFront()
        Materialtransferrequestfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ApproveTransferRequestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ApproveTransferRequestToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        ApprovTransferRequestfrm.SuspendLayout()
        ApprovTransferRequestfrm.MdiParent = Me
        ApprovTransferRequestfrm.Dock = DockStyle.Fill
        ApprovTransferRequestfrm.Show()
        ApprovTransferRequestfrm.WindowState = FormWindowState.Maximized
        ApprovTransferRequestfrm.BringToFront()
        ApprovTransferRequestfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DiscountManagementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DiscountManagementToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        DiscountManagementfrm.SuspendLayout()
        DiscountManagementfrm.MdiParent = Me
        DiscountManagementfrm.Dock = DockStyle.Fill
        DiscountManagementfrm.Show()
        DiscountManagementfrm.WindowState = FormWindowState.Maximized
        DiscountManagementfrm.BringToFront()
        DiscountManagementfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub POSSettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles POSSettingsToolStripMenuItem.Click, ToolStripMenuItem58.Click
        Dim frm As New PosSettingfrm
        frm.ShowDialog()
    End Sub

   

    Private Sub CountersToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles CountersToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Countersfrm.SuspendLayout()
        Countersfrm.MdiParent = Me
        Countersfrm.Dock = DockStyle.Fill
        Countersfrm.Show()
        Countersfrm.WindowState = FormWindowState.Maximized
        Countersfrm.BringToFront()
        Countersfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CounterSalesReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CounterSalesReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        CounterSalesReportfrm.SuspendLayout()
        CounterSalesReportfrm.MdiParent = Me
        CounterSalesReportfrm.Dock = DockStyle.Fill
        CounterSalesReportfrm.Show()
        CounterSalesReportfrm.WindowState = FormWindowState.Maximized
        CounterSalesReportfrm.BringToFront()
        CounterSalesReportfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CounterSalesCashManagementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CounterSalesCashManagementToolStripMenuItem.Click

    End Sub

    Private Sub SalesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SalesToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        CounterSalesReportfrm.SuspendLayout()
        CounterSalesReportfrm.MdiParent = Me
        CounterSalesReportfrm.Dock = DockStyle.Fill
        CounterSalesReportfrm.Show()
        CounterSalesReportfrm.WindowState = FormWindowState.Maximized
        CounterSalesReportfrm.BringToFront()
        CounterSalesReportfrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SearchStockItemsToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles SearchStockItemsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        StockItemSearch.SuspendLayout()
        StockItemSearch.MdiParent = Me
        StockItemSearch.Dock = DockStyle.Fill
        StockItemSearch.Show()
        StockItemSearch.WindowState = FormWindowState.Maximized
        StockItemSearch.BringToFront()
        StockItemSearch.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShortcutKeysToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShortcutKeysToolStripMenuItem.Click
        SHORTCUTKEYFRM.ShowDialog()
    End Sub

    Private Sub POSInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles POSInvoiceToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOS Is Nothing OrElse SalesInvoiceFormPOS.IsDisposed Then

            SalesInvoiceFormPOS = New SalesInvoiceAllFormControl("POS", True)
            SalesInvoiceFormPOS.MdiParent = Me
            SalesInvoiceFormPOS.BringToFront()
            SalesInvoiceFormPOS.Dock = DockStyle.Fill
            SalesInvoiceFormPOS.Show()
            SalesInvoiceFormPOS.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOS.MdiParent = Me
            SalesInvoiceFormPOS.Dock = DockStyle.Fill
            SalesInvoiceFormPOS.Show()
            SalesInvoiceFormPOS.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DayBreakLedgerReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DayBreakLedgerReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        LedgerDayBreakReport.SuspendLayout()
        LedgerDayBreakReport.MdiParent = Me
        LedgerDayBreakReport.Dock = DockStyle.Fill
        LedgerDayBreakReport.Show()
        LedgerDayBreakReport.WindowState = FormWindowState.Maximized
        LedgerDayBreakReport.BringToFront()
        LedgerDayBreakReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LedgerMonthlyReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LedgerMonthlyReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        MonthlyLedgerReportFrm.SuspendLayout()
        MonthlyLedgerReportFrm.MdiParent = Me
        MonthlyLedgerReportFrm.Dock = DockStyle.Fill
        MonthlyLedgerReportFrm.Show()
        MonthlyLedgerReportFrm.WindowState = FormWindowState.Maximized
        MonthlyLedgerReportFrm.BringToFront()
        MonthlyLedgerReportFrm.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DailyInputVATSummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DailyInputVATSummaryToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VATSalesDailyReport.SuspendLayout()
        VATSalesDailyReport.MdiParent = Me
        VATSalesDailyReport.Dock = DockStyle.Fill
        VATSalesDailyReport.Show()
        VATSalesDailyReport.WindowState = FormWindowState.Maximized
        VATSalesDailyReport.BringToFront()
        VATSalesDailyReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DailyOutputVATSummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DailyOutputVATSummaryToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        VATPurchaseDailyReport.SuspendLayout()
        VATPurchaseDailyReport.MdiParent = Me
        VATPurchaseDailyReport.Dock = DockStyle.Fill
        VATPurchaseDailyReport.Show()
        VATPurchaseDailyReport.WindowState = FormWindowState.Maximized
        VATPurchaseDailyReport.BringToFront()
        VATPurchaseDailyReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AlternativeBarcodeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AlternativeBarcodeToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor
        FrmAssignMultipleBarcodes.SuspendLayout()
        FrmAssignMultipleBarcodes.MdiParent = Me
        FrmAssignMultipleBarcodes.Dock = DockStyle.Fill
        FrmAssignMultipleBarcodes.Show()
        FrmAssignMultipleBarcodes.WindowState = FormWindowState.Maximized
        FrmAssignMultipleBarcodes.BringToFront()
        FrmAssignMultipleBarcodes.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TaxesReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaxesReportToolStripMenuItem.Click

    End Sub

    Private Sub EmployeesIDMonitorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeesIDMonitorToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeAdditionalIDmonitor.SuspendLayout()
        EmployeeAdditionalIDmonitor.MdiParent = Me
        EmployeeAdditionalIDmonitor.Dock = DockStyle.Fill
        EmployeeAdditionalIDmonitor.Show()
        EmployeeAdditionalIDmonitor.WindowState = FormWindowState.Maximized
        EmployeeAdditionalIDmonitor.BringToFront()
        EmployeeAdditionalIDmonitor.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RenewalHistroyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenewalHistroyToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EmployeeIdHistroy.SuspendLayout()
        EmployeeIdHistroy.MdiParent = Me
        EmployeeIdHistroy.Dock = DockStyle.Fill
        EmployeeIdHistroy.Show()
        EmployeeIdHistroy.WindowState = FormWindowState.Maximized
        EmployeeIdHistroy.BringToFront()
        EmployeeIdHistroy.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SiteMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SiteMasterToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SiteMaster.SuspendLayout()
        SiteMaster.MdiParent = Me
        SiteMaster.Dock = DockStyle.Fill
        SiteMaster.Show()
        SiteMaster.WindowState = FormWindowState.Maximized
        SiteMaster.BringToFront()
        SiteMaster.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ClientMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClientMasterToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        frmClientMaster.SuspendLayout()
        frmClientMaster.MdiParent = Me
        frmClientMaster.Dock = DockStyle.Fill
        frmClientMaster.Show()
        frmClientMaster.WindowState = FormWindowState.Maximized
        frmClientMaster.BringToFront()
        frmClientMaster.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EmployeeSiteScheduleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeeSiteScheduleToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        frmEmployeeSiteschedule.SuspendLayout()
        frmEmployeeSiteschedule.MdiParent = Me
        frmEmployeeSiteschedule.Dock = DockStyle.Fill
        frmEmployeeSiteschedule.Show()
        frmEmployeeSiteschedule.WindowState = FormWindowState.Maximized
        frmEmployeeSiteschedule.BringToFront()
        frmEmployeeSiteschedule.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DirectPurchaseInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DirectPurchaseInvoiceToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If PurchaseInvoiceFormPI Is Nothing OrElse PurchaseInvoiceFormPI.IsDisposed Then
            PurchaseInvoiceFormPI = New PurchaseInvoiceAllFromControl("DP")
            PurchaseInvoiceFormPI.MdiParent = Me
            PurchaseInvoiceFormPI.BringToFront()
            PurchaseInvoiceFormPI.Dock = DockStyle.Fill
            PurchaseInvoiceFormPI.Show()
            PurchaseInvoiceFormPI.WindowState = FormWindowState.Maximized
        Else
            PurchaseInvoiceFormPI.MdiParent = Me
            PurchaseInvoiceFormPI.Dock = DockStyle.Fill
            PurchaseInvoiceFormPI.Show()
            PurchaseInvoiceFormPI.BringToFront()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SiteSheduleReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SiteSheduleReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        SheduleReport.SuspendLayout()
        SheduleReport.MdiParent = Me
        SheduleReport.Dock = DockStyle.Fill
        SheduleReport.Show()
        SheduleReport.WindowState = FormWindowState.Maximized
        SheduleReport.BringToFront()
        SheduleReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CashSalesReturnsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CashSalesReturnsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormSRCash Is Nothing OrElse SalesInvoiceFormSRCash.IsDisposed Then
            SalesInvoiceFormSRCash = New SalesInvoiceAllFormControl("SR", , , False)
            SalesInvoiceFormSRCash.MdiParent = Me
            SalesInvoiceFormSRCash.BringToFront()
            SalesInvoiceFormSRCash.Dock = DockStyle.Fill
            SalesInvoiceFormSRCash.Show()
            SalesInvoiceFormSRCash.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormSRCash.MdiParent = Me
            SalesInvoiceFormSRCash.Dock = DockStyle.Fill
            SalesInvoiceFormSRCash.Show()
            SalesInvoiceFormSRCash.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub InterBranchTransferToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InterBranchTransferToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If StockJournalIBT Is Nothing OrElse StockJournalIBT.IsDisposed Then
            StockJournalIBT = New StockTransferFrm(True)
            StockJournalIBT.SuspendLayout()
            StockJournalIBT.MdiParent = Me


            StockJournalIBT.Dock = DockStyle.Fill
            StockJournalIBT.WindowState = FormWindowState.Maximized
            StockJournalIBT.Show()
            StockJournalIBT.BringToFront()
        Else
            StockJournalIBT.MdiParent = Me
            StockJournalIBT.Dock = DockStyle.Fill
            StockJournalIBT.Show()
            StockJournalIBT.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ZeroTaxSalesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ZeroTaxSalesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        If SalesInvoiceFormPOSNotax Is Nothing OrElse SalesInvoiceFormPOSNotax.IsDisposed Then

            SalesInvoiceFormPOSNotax = New SalesInvoiceAllFormControl("POS", True, , , True)
            SalesInvoiceFormPOSNotax.MdiParent = Me
            SalesInvoiceFormPOSNotax.BringToFront()
            SalesInvoiceFormPOSNotax.Dock = DockStyle.Fill
            SalesInvoiceFormPOSNotax.Show()
            SalesInvoiceFormPOSNotax.WindowState = FormWindowState.Maximized
        Else
            SalesInvoiceFormPOSNotax.MdiParent = Me
            SalesInvoiceFormPOSNotax.Dock = DockStyle.Fill
            SalesInvoiceFormPOSNotax.Show()
            SalesInvoiceFormPOSNotax.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DaywiseSalesReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DaywiseSalesReportToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        DailySalesReport.SuspendLayout()
        DailySalesReport.MdiParent = Me
        DailySalesReport.Dock = DockStyle.Fill
        DailySalesReport.Show()
        DailySalesReport.WindowState = FormWindowState.Maximized
        DailySalesReport.BringToFront()
        DailySalesReport.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewToolStripMenuItem.Click

    End Sub
End Class
