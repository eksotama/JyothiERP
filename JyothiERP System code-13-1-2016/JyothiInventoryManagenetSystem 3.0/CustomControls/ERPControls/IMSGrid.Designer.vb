<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMSGrid
    Inherits JyothiPharmaERPSystem3.IMSList

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IMSGrid
        '
        Me.AllowDrop = True
        Me.AllowUserToAddRows = False
        Me.AllowUserToResizeRows = False
        Me.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.MultiSelect = False
        Me.RowHeadersWidth = 33
        Me.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
