<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadCurrencyExchangeRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadCurrencyExchangeRate))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.txtcurrate = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.67123!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(52, 67)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 34)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.Color.White
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_Button.Location = New System.Drawing.Point(28, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'txtcurrate
        '
        Me.txtcurrate.AllHelpText = True
        Me.txtcurrate.AllowDecimal = True
        Me.txtcurrate.AllowFormulas = False
        Me.txtcurrate.AllowForQty = True
        Me.txtcurrate.AllowNegative = False
        Me.txtcurrate.AllowPerSign = False
        Me.txtcurrate.AllowPlusSign = False
        Me.txtcurrate.AllowToolTip = True
        Me.txtcurrate.DecimalPlaces = CType(6, Short)
        Me.txtcurrate.ExitOnEscKey = True
        Me.txtcurrate.GFocusBackColor = System.Drawing.Color.Yellow
        Me.txtcurrate.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.txtcurrate.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtcurrate.HelpText = Nothing
        Me.txtcurrate.LFocusBackColor = System.Drawing.Color.White
        Me.txtcurrate.Location = New System.Drawing.Point(52, 30)
        Me.txtcurrate.LostFocusFontColor = System.Drawing.Color.Blue
        Me.txtcurrate.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtcurrate.Max = CType(10000, Long)
        Me.txtcurrate.MaxLength = 12
        Me.txtcurrate.Min = CType(0, Long)
        Me.txtcurrate.Name = "txtcurrate"
        Me.txtcurrate.NextOnEnter = True
        Me.txtcurrate.SetToolTip = Nothing
        Me.txtcurrate.Size = New System.Drawing.Size(169, 20)
        Me.txtcurrate.TabIndex = 1
        Me.txtcurrate.Text = "0"
        Me.txtcurrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtcurrate.ToolTip = Nothing
        Me.txtcurrate.UseFunctionKeys = False
        Me.txtcurrate.UseUpDownArrowKeys = False
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(49, 14)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(94, 13)
        Me.ImSlabel1.TabIndex = 2
        Me.ImSlabel1.Text = "Exchange Rate"
        '
        'ReadCurrencyExchangeRate
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(262, 103)
        Me.Controls.Add(Me.ImSlabel1)
        Me.Controls.Add(Me.txtcurrate)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadCurrencyExchangeRate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enter CurrencyExchange Rate"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents txtcurrate As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel

End Class
