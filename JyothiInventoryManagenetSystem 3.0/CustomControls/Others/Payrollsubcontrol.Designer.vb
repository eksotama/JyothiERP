<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payrollsubcontrol
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
        Me.ImsComboBox1 = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Tb = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Tb, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ImsComboBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(736, 133)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ImsComboBox1
        '
        Me.ImsComboBox1.AllowEmpty = False
        Me.ImsComboBox1.AllowOnlyListValues = True
        Me.ImsComboBox1.AllowToolTip = True
        Me.ImsComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ImsComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ImsComboBox1.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.ImsComboBox1.FormattingEnabled = True
        Me.ImsComboBox1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.ImsComboBox1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsComboBox1.IsAllowDigits = True
        Me.ImsComboBox1.IsAllowSpace = True
        Me.ImsComboBox1.IsAllowSplChars = True
        Me.ImsComboBox1.IsAllowToolTip = True
        Me.ImsComboBox1.LFocusBackColor = System.Drawing.Color.White
        Me.ImsComboBox1.Location = New System.Drawing.Point(3, 3)
        Me.ImsComboBox1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsComboBox1.Name = "ImsComboBox1"
        Me.ImsComboBox1.Size = New System.Drawing.Size(322, 21)
        Me.ImsComboBox1.Sorted = True
        Me.ImsComboBox1.SpecialCharList = "&-/@"
        Me.ImsComboBox1.TabIndex = 0
        Me.ImsComboBox1.UseFunctionKeys = False
        '
        'Tb
        '
        Me.Tb.AutoScroll = True
        Me.Tb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tb.Location = New System.Drawing.Point(0, 28)
        Me.Tb.Margin = New System.Windows.Forms.Padding(0)
        Me.Tb.Name = "Tb"
        Me.Tb.Size = New System.Drawing.Size(736, 105)
        Me.Tb.TabIndex = 2
        '
        'Payrollsubcontrol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Name = "Payrollsubcontrol"
        Me.Size = New System.Drawing.Size(736, 133)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImsComboBox1 As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Tb As System.Windows.Forms.FlowLayoutPanel

End Class
