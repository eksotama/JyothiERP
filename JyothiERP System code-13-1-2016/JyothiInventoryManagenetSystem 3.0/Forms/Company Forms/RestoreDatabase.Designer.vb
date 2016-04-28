<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RestoreDatabase
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BtnRestore = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Lbl = New JyothiPharmaERPSystem3.IMSlabel()
        Me.btnRestoreFromAnotherDB = New System.Windows.Forms.Button()
        Me.TxtRunningDatabaseName = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TxtCmpNames = New System.Windows.Forms.ComboBox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtExportPath = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ImsHeadingLabel1 = New JyothiPharmaERPSystem3.IMSHeadingLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Enabled = False
        Me.ProgressBar1.Location = New System.Drawing.Point(159, 125)
        Me.ProgressBar1.MarqueeAnimationSpeed = 10
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(382, 23)
        Me.ProgressBar1.TabIndex = 28
        '
        'BtnRestore
        '
        Me.BtnRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRestore.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.BtnRestore.Location = New System.Drawing.Point(427, 224)
        Me.BtnRestore.Name = "BtnRestore"
        Me.BtnRestore.Size = New System.Drawing.Size(182, 46)
        Me.BtnRestore.TabIndex = 26
        Me.BtnRestore.Text = "Restore"
        Me.BtnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRestore.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Bakup files (*.Bak)|*.Bak"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Bakup files (*.Bak)|*.Bak"
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.JyothiPharmaERPSystem3.My.Resources.Resources.restore_database
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(30, 75)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 78)
        Me.Panel1.TabIndex = 31
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.BtnClose.Location = New System.Drawing.Point(30, 224)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(138, 46)
        Me.BtnClose.TabIndex = 27
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.Button1.Location = New System.Drawing.Point(346, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 46)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Select Backup File"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(625, 312)
        Me.TabControl1.TabIndex = 33
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.ProgressBar1)
        Me.TabPage1.Controls.Add(Me.BtnClose)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Lbl)
        Me.TabPage1.Controls.Add(Me.btnRestoreFromAnotherDB)
        Me.TabPage1.Controls.Add(Me.BtnRestore)
        Me.TabPage1.Controls.Add(Me.TxtRunningDatabaseName)
        Me.TabPage1.Controls.Add(Me.ImSlabel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(617, 286)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Restore from Backup File"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Lbl
        '
        Me.Lbl.AutoSize = True
        Me.Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl.Location = New System.Drawing.Point(156, 109)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(28, 13)
        Me.Lbl.TabIndex = 30
        Me.Lbl.Text = "Idel"
        '
        'btnRestoreFromAnotherDB
        '
        Me.btnRestoreFromAnotherDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestoreFromAnotherDB.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.btnRestoreFromAnotherDB.Location = New System.Drawing.Point(223, 224)
        Me.btnRestoreFromAnotherDB.Name = "btnRestoreFromAnotherDB"
        Me.btnRestoreFromAnotherDB.Size = New System.Drawing.Size(177, 46)
        Me.btnRestoreFromAnotherDB.TabIndex = 26
        Me.btnRestoreFromAnotherDB.Text = "Restore From Different DB"
        Me.btnRestoreFromAnotherDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRestoreFromAnotherDB.UseVisualStyleBackColor = True
        '
        'TxtRunningDatabaseName
        '
        Me.TxtRunningDatabaseName.AutoSize = True
        Me.TxtRunningDatabaseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRunningDatabaseName.Location = New System.Drawing.Point(158, 82)
        Me.TxtRunningDatabaseName.Name = "TxtRunningDatabaseName"
        Me.TxtRunningDatabaseName.Size = New System.Drawing.Size(203, 13)
        Me.TxtRunningDatabaseName.TabIndex = 30
        Me.TxtRunningDatabaseName.Text = "Present Company Database Name:"
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(158, 151)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(0, 13)
        Me.ImSlabel1.TabIndex = 29
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TxtCmpNames)
        Me.TabPage2.Controls.Add(Me.ProgressBar2)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.TxtExportPath)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(617, 286)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Restore from Export Files"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TxtCmpNames
        '
        Me.TxtCmpNames.FormattingEnabled = True
        Me.TxtCmpNames.Location = New System.Drawing.Point(194, 132)
        Me.TxtCmpNames.Name = "TxtCmpNames"
        Me.TxtCmpNames.Size = New System.Drawing.Size(268, 21)
        Me.TxtCmpNames.TabIndex = 31
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Enabled = False
        Me.ProgressBar2.Location = New System.Drawing.Point(3, 243)
        Me.ProgressBar2.MarqueeAnimationSpeed = 10
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(586, 23)
        Me.ProgressBar2.TabIndex = 30
        Me.ProgressBar2.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Selected The Company Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Import Path/Location"
        '
        'TxtExportPath
        '
        Me.TxtExportPath.BackColor = System.Drawing.Color.White
        Me.TxtExportPath.Location = New System.Drawing.Point(15, 31)
        Me.TxtExportPath.Multiline = True
        Me.TxtExportPath.Name = "TxtExportPath"
        Me.TxtExportPath.ReadOnly = True
        Me.TxtExportPath.Size = New System.Drawing.Size(435, 63)
        Me.TxtExportPath.TabIndex = 28
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361187183_Open
        Me.Button3.Location = New System.Drawing.Point(456, 31)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(133, 46)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "Browse Location"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.Button2.Location = New System.Drawing.Point(202, 175)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 46)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Restore Now"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ImsHeadingLabel1
        '
        Me.ImsHeadingLabel1.BackColor = System.Drawing.Color.Green
        Me.ImsHeadingLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImsHeadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImsHeadingLabel1.ForeColor = System.Drawing.Color.White
        Me.ImsHeadingLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ImsHeadingLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsHeadingLabel1.Name = "ImsHeadingLabel1"
        Me.ImsHeadingLabel1.Size = New System.Drawing.Size(630, 25)
        Me.ImsHeadingLabel1.TabIndex = 32
        Me.ImsHeadingLabel1.Text = "RESTORE COMPANY DATA"
        Me.ImsHeadingLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RestoreDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 352)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ImsHeadingLabel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RestoreDatabase"
        Me.Text = "RestoreDatabase"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnRestore As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImsHeadingLabel1 As JyothiPharmaERPSystem3.IMSHeadingLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Lbl As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TxtRunningDatabaseName As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtExportPath As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TxtCmpNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnRestoreFromAnotherDB As System.Windows.Forms.Button
End Class
