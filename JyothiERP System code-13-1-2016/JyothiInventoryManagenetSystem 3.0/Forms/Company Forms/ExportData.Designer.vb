<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.path = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(146, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(219, 60)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(266, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 31)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Export To"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'path
        '
        Me.path.AutoSize = True
        Me.path.Location = New System.Drawing.Point(26, 25)
        Me.path.Name = "path"
        Me.path.Size = New System.Drawing.Size(0, 13)
        Me.path.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(146, 172)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(219, 60)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "IMPORT"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ExportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 244)
        Me.Controls.Add(Me.path)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Name = "ExportData"
        Me.Text = "ExportData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents path As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
