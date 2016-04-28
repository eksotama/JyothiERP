<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMSDropBox
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsTextBox1 = New JyothiPharmaERPSystem3.IMSTextBox()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImsButton1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsTextBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsButton2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(370, 134)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Location = New System.Drawing.Point(0, 0)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(341, 24)
        Me.ImsButton1.TabIndex = 0
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = True
        '
        'ImsTextBox1
        '
        Me.ImsTextBox1.AllowToolTip = True
        Me.ImsTextBox1.CharcterCase = JyothiPharmaERPSystem3.IMSTextBox.ChangCaseValues.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.ImsTextBox1, 2)
        Me.ImsTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsTextBox1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.ImsTextBox1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsTextBox1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ImsTextBox1.IsAllowDigits = True
        Me.ImsTextBox1.IsAllowSpace = True
        Me.ImsTextBox1.IsAllowSplChars = True
        Me.ImsTextBox1.LFocusBackColor = System.Drawing.Color.White
        Me.ImsTextBox1.Location = New System.Drawing.Point(0, 24)
        Me.ImsTextBox1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsTextBox1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.ImsTextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsTextBox1.MaxLength = 250
        Me.ImsTextBox1.Multiline = True
        Me.ImsTextBox1.Name = "ImsTextBox1"
        Me.ImsTextBox1.Size = New System.Drawing.Size(370, 110)
        Me.ImsTextBox1.SpecialCharList = "&-/@"
        Me.ImsTextBox1.TabIndex = 1
        Me.ImsTextBox1.UseFunctionKeys = False
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.DownE
        Me.ImsButton2.Location = New System.Drawing.Point(341, 0)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(29, 24)
        Me.ImsButton2.TabIndex = 0
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = True
        '
        'IMSDropBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "IMSDropBox"
        Me.Size = New System.Drawing.Size(370, 134)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsTextBox1 As JyothiPharmaERPSystem3.IMSTextBox
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton

End Class
