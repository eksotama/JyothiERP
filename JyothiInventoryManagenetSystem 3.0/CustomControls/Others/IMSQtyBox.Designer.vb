<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMSQtyBox
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
        Me.TxtLbl2 = New System.Windows.Forms.Label()
        Me.TxtLbl1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtQty1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtQty2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtLbl2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtLbl1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(166, 40)
        Me.TableLayoutPanel1.TabIndex = 1
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
        Me.TxtQty1.DecimalPlaces = CType(3, Short)
        Me.TxtQty1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty1.ExitOnEscKey = True
        Me.TxtQty1.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtQty1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtQty1.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtQty1.HelpText = Nothing
        Me.TxtQty1.LFocusBackColor = System.Drawing.Color.White
        Me.TxtQty1.Location = New System.Drawing.Point(3, 18)
        Me.TxtQty1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtQty1.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtQty1.Max = CType(100000000000000, Long)
        Me.TxtQty1.MaxLength = 12
        Me.TxtQty1.Min = CType(0, Long)
        Me.TxtQty1.Name = "TxtQty1"
        Me.TxtQty1.NextOnEnter = True
        Me.TxtQty1.SetToolTip = Nothing
        Me.TxtQty1.Size = New System.Drawing.Size(77, 20)
        Me.TxtQty1.TabIndex = 0
        Me.TxtQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtQty1.ToolTip = Nothing
        Me.TxtQty1.UseFunctionKeys = False
        Me.TxtQty1.UseUpDownArrowKeys = False
        '
        'TxtQty2
        '
        Me.TxtQty2.AllHelpText = True
        Me.TxtQty2.AllowDecimal = True
        Me.TxtQty2.AllowFormulas = False
        Me.TxtQty2.AllowForQty = True
        Me.TxtQty2.AllowNegative = False
        Me.TxtQty2.AllowPerSign = False
        Me.TxtQty2.AllowPlusSign = False
        Me.TxtQty2.AllowToolTip = True
        Me.TxtQty2.DecimalPlaces = CType(3, Short)
        Me.TxtQty2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty2.ExitOnEscKey = True
        Me.TxtQty2.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtQty2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtQty2.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtQty2.HelpText = Nothing
        Me.TxtQty2.LFocusBackColor = System.Drawing.Color.White
        Me.TxtQty2.Location = New System.Drawing.Point(86, 18)
        Me.TxtQty2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtQty2.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.2!)
        Me.TxtQty2.Max = CType(100000000000000, Long)
        Me.TxtQty2.MaxLength = 12
        Me.TxtQty2.Min = CType(0, Long)
        Me.TxtQty2.Name = "TxtQty2"
        Me.TxtQty2.NextOnEnter = True
        Me.TxtQty2.SetToolTip = Nothing
        Me.TxtQty2.Size = New System.Drawing.Size(77, 20)
        Me.TxtQty2.TabIndex = 0
        Me.TxtQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtQty2.ToolTip = Nothing
        Me.TxtQty2.UseFunctionKeys = False
        Me.TxtQty2.UseUpDownArrowKeys = False
        '
        'TxtLbl2
        '
        Me.TxtLbl2.AutoSize = True
        Me.TxtLbl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLbl2.Location = New System.Drawing.Point(86, 0)
        Me.TxtLbl2.Name = "TxtLbl2"
        Me.TxtLbl2.Size = New System.Drawing.Size(77, 15)
        Me.TxtLbl2.TabIndex = 1
        Me.TxtLbl2.Text = "Qty"
        Me.TxtLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtLbl1
        '
        Me.TxtLbl1.AutoSize = True
        Me.TxtLbl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLbl1.Location = New System.Drawing.Point(3, 0)
        Me.TxtLbl1.Name = "TxtLbl1"
        Me.TxtLbl1.Size = New System.Drawing.Size(77, 15)
        Me.TxtLbl1.TabIndex = 1
        Me.TxtLbl1.Text = "Qty"
        Me.TxtLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IMSQtyBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "IMSQtyBox"
        Me.Size = New System.Drawing.Size(166, 40)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtQty1 As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtQty2 As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtLbl2 As System.Windows.Forms.Label
    Friend WithEvents TxtLbl1 As System.Windows.Forms.Label

End Class
