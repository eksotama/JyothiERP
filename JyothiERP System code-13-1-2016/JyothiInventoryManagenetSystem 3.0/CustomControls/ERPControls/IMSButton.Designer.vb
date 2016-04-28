<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMSButton
    Inherits System.Windows.Forms.Button

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
        Me.components = New System.ComponentModel.Container()
        Me.TxtToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'TxtToolTip
        '
        Me.TxtToolTip.AutomaticDelay = 1000
        Me.TxtToolTip.IsBalloon = True
        Me.TxtToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TxtToolTip.ToolTipTitle = "Help"
        '
        'IMSButton
        '

        Me.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtToolTip As System.Windows.Forms.ToolTip

End Class
