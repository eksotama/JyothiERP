<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dummy
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
        Me.CostCenterMultiControl1 = New JyothiPharmaERPSystem3.CostCenterMultiControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CostCenterMultiControl1
        '
        Me.CostCenterMultiControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CostCenterMultiControl1.Location = New System.Drawing.Point(0, 0)
        Me.CostCenterMultiControl1.Name = "CostCenterMultiControl1"
        Me.CostCenterMultiControl1.Size = New System.Drawing.Size(538, 520)
        Me.CostCenterMultiControl1.TabIndex = 0
        Me.CostCenterMultiControl1.TotalCostValue = 0.0R
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(164, 499)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.Salary2
        Me.Button2.Location = New System.Drawing.Point(73, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(299, 71)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dummy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 520)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CostCenterMultiControl1)
        Me.Name = "dummy"
        Me.Text = "dummy"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CostCenterMultiControl1 As JyothiPharmaERPSystem3.CostCenterMultiControl
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
