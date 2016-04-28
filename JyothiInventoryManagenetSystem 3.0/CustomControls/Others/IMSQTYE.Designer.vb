<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMSQTYE
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
        Me.TxtQty1 = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtQty2 = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtQty1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtQty2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(114, 23)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TxtQty1
        '
        Me.TxtQty1.AllHelpText = True
        Me.TxtQty1.AllowDecimal = False
        Me.TxtQty1.AllowFormulas = False
        Me.TxtQty1.AllowForQty = True
        Me.TxtQty1.AllowNegative = False
        Me.TxtQty1.AllowPerSign = False
        Me.TxtQty1.AllowPlusSign = False
        Me.TxtQty1.AllowToolTip = True
        Me.TxtQty1.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.TxtQty1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty1.ExitOnEscKey = True
        Me.TxtQty1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtQty1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtQty1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtQty1.HelpText = Nothing
        Me.TxtQty1.LFocusBackColor = System.Drawing.Color.White
        Me.TxtQty1.Location = New System.Drawing.Point(3, 0)
        Me.TxtQty1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtQty1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtQty1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.TxtQty1.Max = CType(100000000000000, Long)
        Me.TxtQty1.MaxLength = 12
        Me.TxtQty1.Min = CType(0, Long)
        Me.TxtQty1.Name = "TxtQty1"
        Me.TxtQty1.NextOnEnter = True
        Me.TxtQty1.Size = New System.Drawing.Size(51, 20)
        Me.TxtQty1.TabIndex = 0
        Me.TxtQty1.Text = "0"
        Me.TxtQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtQty1.ToolTip = Nothing
        Me.TxtQty1.UseFunctionKeys = False
        Me.TxtQty1.UseUpDownArrowKeys = False
        '
        'TxtQty2
        '
        Me.TxtQty2.AllHelpText = True
        Me.TxtQty2.AllowDecimal = False
        Me.TxtQty2.AllowFormulas = False
        Me.TxtQty2.AllowForQty = True
        Me.TxtQty2.AllowNegative = False
        Me.TxtQty2.AllowPerSign = False
        Me.TxtQty2.AllowPlusSign = False
        Me.TxtQty2.AllowToolTip = True
        Me.TxtQty2.DecimalPlaces = CType(ErpDecimalPlaces, Short)
        Me.TxtQty2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty2.ExitOnEscKey = True
        Me.TxtQty2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtQty2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtQty2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtQty2.HelpText = Nothing
        Me.TxtQty2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtQty2.Location = New System.Drawing.Point(60, 0)
        Me.TxtQty2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtQty2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtQty2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.TxtQty2.Max = CType(100000000000000, Long)
        Me.TxtQty2.MaxLength = 12
        Me.TxtQty2.Min = CType(0, Long)
        Me.TxtQty2.Name = "TxtQty2"
        Me.TxtQty2.NextOnEnter = True
        Me.TxtQty2.Size = New System.Drawing.Size(51, 20)
        Me.TxtQty2.TabIndex = 0
        Me.TxtQty2.Text = "0"
        Me.TxtQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtQty2.ToolTip = Nothing
        Me.TxtQty2.UseFunctionKeys = False
        Me.TxtQty2.UseUpDownArrowKeys = False
        '
        'IMSQTYE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "IMSQTYE"
        Me.Size = New System.Drawing.Size(114, 23)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtQty1 As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtQty2 As JyothiPharmaERPSystem3.IMSNumericTextBox

End Class
