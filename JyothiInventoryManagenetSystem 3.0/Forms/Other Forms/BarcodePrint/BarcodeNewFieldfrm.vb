Imports System.Windows.Forms

Public Class BarcodeNewFieldfrm
    Dim Schname As String = ""
    Sub New(ByVal schemename As String)

        ' This call is required by the designer.
        InitializeComponent()
        Schname = schemename
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtfname.Text.Length = 0 Then
            MsgBox("Please enter the Field Name              ", MsgBoxStyle.Information)
            txtfname.Focus()
            Exit Sub
        End If
        If SQLIsFieldExists("SELECT TOP 1 1 from   barcodeprintlabels where schemename=N'" & Schname & "' and DbName=N'" & txtfname.Text & "'") = True Then
            MsgBox("The Filed Name is already exists...              ", MsgBoxStyle.Information)
            txtfname.Focus()
            Exit Sub
        End If
        If MsgBox("Do you want to create  ?                       ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqlistr As String = ""
            sqlistr = "INSERT INTO [barcodeprintlabels]([Schemename],[Lwidth],[LHeight],[LTop],[Lleft],[DbName],[LText],[Fontname],[fontsize],[fontstyle],[fontcolor],[Align],[IsVisible],[backcolor],[Rotate],[IsDbFiled])     VALUES " _
                   & "(N'" & Schname & "',0,0,0,0,N'" & txtfname.Text & "','','Arial',9,0,'Black','Left',0,'null',0,0 )"
            ExecuteSQLQuery(sqlistr)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Exit Sub
        End If
      

      
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BarcodeNewFieldfrm_Activated(sender As Object, e As System.EventArgs) Handles Me.Shown
        ERPInitializeObjects(Me)
    End Sub

    Private Sub BarcodeNewFieldfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
