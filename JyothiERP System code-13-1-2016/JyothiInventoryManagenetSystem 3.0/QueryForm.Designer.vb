<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryForm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TxtSqlQuery = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtlist = New JyothiPharmaERPSystem3.IMSList()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.TxtCmpNames = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtExportPath = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.txtlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(285, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 54)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Check"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(50, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(193, 22)
        Me.TextBox1.TabIndex = 1
        '
        'TxtSqlQuery
        '
        Me.TxtSqlQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSqlQuery.Location = New System.Drawing.Point(50, 94)
        Me.TxtSqlQuery.Multiline = True
        Me.TxtSqlQuery.Name = "TxtSqlQuery"
        Me.TxtSqlQuery.Size = New System.Drawing.Size(575, 57)
        Me.TxtSqlQuery.TabIndex = 1
        Me.TxtSqlQuery.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(430, 157)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(141, 54)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Go"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(102, 157)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 54)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(556, 23)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "DisplyValue"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(556, 41)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(110, 20)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtlist)
        Me.Panel1.Location = New System.Drawing.Point(18, 226)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 237)
        Me.Panel1.TabIndex = 4
        '
        'txtlist
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlist.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.txtlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.txtlist.DefaultCellStyle = DataGridViewCellStyle4
        Me.txtlist.Location = New System.Drawing.Point(0, 0)
        Me.txtlist.Name = "txtlist"
        Me.txtlist.Size = New System.Drawing.Size(570, 237)
        Me.txtlist.TabIndex = 0
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(679, 23)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(69, 17)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "Disply list"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TxtCmpNames
        '
        Me.TxtCmpNames.FormattingEnabled = True
        Me.TxtCmpNames.Location = New System.Drawing.Point(779, 245)
        Me.TxtCmpNames.Name = "TxtCmpNames"
        Me.TxtCmpNames.Size = New System.Drawing.Size(268, 21)
        Me.TxtCmpNames.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(605, 249)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Selected The Company Name:"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources._1361187183_Open
        Me.Button4.Location = New System.Drawing.Point(914, 143)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(133, 46)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "Browse Location"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.Button5.Location = New System.Drawing.Point(787, 288)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(184, 46)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "Restore Now"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(634, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Import Path/Location"
        '
        'TxtExportPath
        '
        Me.TxtExportPath.BackColor = System.Drawing.Color.White
        Me.TxtExportPath.Location = New System.Drawing.Point(629, 143)
        Me.TxtExportPath.Multiline = True
        Me.TxtExportPath.Name = "TxtExportPath"
        Me.TxtExportPath.ReadOnly = True
        Me.TxtExportPath.Size = New System.Drawing.Size(268, 63)
        Me.TxtExportPath.TabIndex = 36
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Bakup files (*.Bak)|*.Bak"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Bakup files (*.Bak)|*.Bak"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(629, 369)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(133, 53)
        Me.Button6.TabIndex = 38
        Me.Button6.Text = "Rearange stock"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'QueryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 492)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtExportPath)
        Me.Controls.Add(Me.TxtCmpNames)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TxtSqlQuery)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "QueryForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "QueryForm"
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtSqlQuery As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtlist As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCmpNames As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtExportPath As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button6 As System.Windows.Forms.Button

End Class
