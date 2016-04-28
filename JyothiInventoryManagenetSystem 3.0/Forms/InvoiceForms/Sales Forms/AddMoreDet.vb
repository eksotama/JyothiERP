Imports System.Windows.Forms

Public Class AddMoreDet
    Dim Det As New LedgerDetailsClass
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Det.buyersname = TxtBname.Text
        Det.buyeraddress = TxtBaddress.Text
        Det.buyertaxdetails = TxtBTax.Text
        Det.Despatchto = TxtDTo.Text
        Det.despatchaddress = TxtDaddress.Text
        Det.DespatchDestination = TxtDdestination.Text
        Det.DespatchThrough = TxtDthrough.Text
        Det.Despatchto = TxtDTo.Text
        Det.otherreference = TxtOtherRef.Text
        Det.paymentterm = TxtPaymentTerm.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Sub New(ByRef MoreDet As LedgerDetailsClass)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Det = MoreDet
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub AddMoreDet_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
        TxtBname.Focus()
    End Sub

    Private Sub AddMoreDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtBname.Text = Det.buyersname
        TxtBaddress.Text = Det.buyeraddress
        TxtBTax.Text = Det.buyertaxdetails
        TxtDTo.Text = Det.Despatchto
        TxtDaddress.Text = Det.despatchaddress
        TxtDdestination.Text = Det.DespatchDestination
        TxtDthrough.Text = Det.DespatchThrough
        TxtDTo.Text = Det.Despatchto
        TxtOtherRef.Text = Det.otherreference
        TxtPaymentTerm.Text = Det.paymentterm
    End Sub

End Class
