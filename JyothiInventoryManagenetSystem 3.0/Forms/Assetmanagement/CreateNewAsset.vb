Imports System.Windows.Forms

Public Class CreateNewAsset
    Dim AssetName As String = ""
    Dim AssetNameTemp As String = ""
    Dim IsEditMode As Boolean = False
    Sub New(Optional ByVal V_AssetName As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        If V_AssetName.Length > 0 Then
            IsEditMode = True
            AssetName = V_AssetName
            BtnCreate.Text = "&Save"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub LoadDefs()
        TxtAssetID.Text = GetIDCode(EnumIDType.AssetID)
        If IsEditMode = True Then
            AssetNameTemp = AssetName
        Else
            AssetNameTemp = CurrentUserName & TxtAssetID.Text
        End If
        TxtAssetBarcode.Text = ReplaceZerosToBarcode("A" & "1000" & TxtAssetID.Text)
        TxtAssetName.Text = ""
        TxtDescr.Text = ""
        LoadDataIntoComboBox("Select Distinct store from assets ", TxtStoreName, "Store")
        LoadDataIntoComboBox("Select locationname from StockLocations ", TxtLocation, "locationname")
        LoadDataIntoComboBox("Select Distinct Manufacturer from assets ", TxtManufact, "Manufacturer")
        LoadDataIntoComboBox("Select Distinct brand from assets ", TxtBrand, "brand")
        LoadDataIntoComboBox("Select Distinct Model from assets ", TxtModel, "Model")
        LoadDataIntoComboBox("Select Distinct status from assets ", TxtAssetStatus, "status")
        LoadDataIntoComboBox("Select AssetGroupName  from assetgroups ", TxtAssetType, "AssetGroupName")
        If TxtAssetStatus.Items.Count = 0 Then
            TxtAssetStatus.Items.Add("In Use")
            TxtAssetStatus.Text = "In Use"
        End If
        LoadDataIntoComboBox("Select Distinct condition from assets ", txtCondition, "condition")
        If txtCondition.Items.Count = 0 Then
            txtCondition.Items.Add("Good")
            txtCondition.Text = "Good"
        End If
        TxtExpiry.Value = Today.AddYears(10)
        TxtNote.Text = ""
        TxtImage.BackgroundImage = Nothing
        LoadDataIntoComboBox("SELECT  LedgerName  from ledgers where (Accountgroup in (select subgroup from AccountGroupsList where groupname=N'" & AccountGroupNames.SuppliersAccounts & "'))", TxtVendorName, "LedgerName")
        TxtPurRate.Text = "0"
        TxtScrapValue.Text = "0"
        TxtYears.Text = "1"
        TxtpurchaseDate.Value = Today
        TxtServiceStartDate.Value = Today
        TxtWarrantyDate.Value = Today.AddYears(10)
        TxtDepRate.Text = "0"
        TxtDepreMethod.Text = "Custom"
        TxtDepList.Rows.Clear()
        TxtServiceList.Rows.Clear()
        TxtVhList.Rows.Clear()
        TxtAttachList.Rows.Clear()
        TxtNoteList.Rows.Clear()

    End Sub

    Private Sub CreateNewAsset_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub
    Private Sub CreateNewAsset_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub TxtDepreMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDepreMethod.SelectedIndexChanged

    End Sub

    Private Sub BtnEditNote_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditNote.Click

    End Sub

    Private Sub BtnNEWNote_Click(sender As System.Object, e As System.EventArgs) Handles BtnNEWNote.Click

    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click

    End Sub
End Class
