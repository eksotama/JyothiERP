<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebcamImage
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
        Me.components = New System.ComponentModel.Container()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.cmbCamera = New System.Windows.Forms.ComboBox()
        Me.lblCamera = New System.Windows.Forms.Label()
        Me.picFeed = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(308, 270)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(127, 38)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'picPreview
        '
        Me.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPreview.Location = New System.Drawing.Point(308, 39)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(276, 216)
        Me.picPreview.TabIndex = 10
        Me.picPreview.TabStop = False
        '
        'btnCapture
        '
        Me.btnCapture.Location = New System.Drawing.Point(95, 270)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(129, 38)
        Me.btnCapture.TabIndex = 9
        Me.btnCapture.Text = "Mark Image"
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'cmbCamera
        '
        Me.cmbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCamera.FormattingEnabled = True
        Me.cmbCamera.Location = New System.Drawing.Point(95, 12)
        Me.cmbCamera.Name = "cmbCamera"
        Me.cmbCamera.Size = New System.Drawing.Size(193, 21)
        Me.cmbCamera.TabIndex = 8
        '
        'lblCamera
        '
        Me.lblCamera.AutoSize = True
        Me.lblCamera.Location = New System.Drawing.Point(12, 15)
        Me.lblCamera.Name = "lblCamera"
        Me.lblCamera.Size = New System.Drawing.Size(76, 13)
        Me.lblCamera.TabIndex = 7
        Me.lblCamera.Text = "Select Camera"
        '
        'picFeed
        '
        Me.picFeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFeed.Location = New System.Drawing.Point(12, 39)
        Me.picFeed.Name = "picFeed"
        Me.picFeed.Size = New System.Drawing.Size(276, 216)
        Me.picFeed.TabIndex = 6
        Me.picFeed.TabStop = False
        '
        'Timer1
        '
        '
        'WebcamImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 320)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.picPreview)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.cmbCamera)
        Me.Controls.Add(Me.lblCamera)
        Me.Controls.Add(Me.picFeed)
        Me.Name = "WebcamImage"
        Me.Text = "WebcamImage"
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents picPreview As System.Windows.Forms.PictureBox
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents btnCapture As System.Windows.Forms.Button
    Private WithEvents cmbCamera As System.Windows.Forms.ComboBox
    Private WithEvents lblCamera As System.Windows.Forms.Label
    Private WithEvents picFeed As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
