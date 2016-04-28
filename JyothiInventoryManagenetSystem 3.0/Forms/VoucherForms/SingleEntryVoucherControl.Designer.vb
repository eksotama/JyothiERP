<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SingleEntryVoucherControl
    Inherits System.Windows.Forms.UserControl

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
        Me.Tb = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'Tb
        '
        Me.Tb.AutoScroll = True
        Me.Tb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tb.Location = New System.Drawing.Point(0, 0)
        Me.Tb.Name = "Tb"
        Me.Tb.Size = New System.Drawing.Size(616, 249)
        Me.Tb.TabIndex = 2
        '
        'SingleEntryVoucherControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Tb)
        Me.Name = "SingleEntryVoucherControl"
        Me.Size = New System.Drawing.Size(616, 249)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tb As System.Windows.Forms.FlowLayoutPanel

End Class
