<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayrollNewPrimaryCostControl
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
        Me.TxtPrimaryCostCentreName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Panel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TxtTotal = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtPrimaryCostCentreName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTotal, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(936, 45)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TxtPrimaryCostCentreName
        '
        Me.TxtPrimaryCostCentreName.AllowEmpty = False
        Me.TxtPrimaryCostCentreName.AllowOnlyListValues = True
        Me.TxtPrimaryCostCentreName.AllowToolTip = True
        Me.TxtPrimaryCostCentreName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtPrimaryCostCentreName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtPrimaryCostCentreName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtPrimaryCostCentreName, 2)
        Me.TxtPrimaryCostCentreName.FormattingEnabled = True
        Me.TxtPrimaryCostCentreName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtPrimaryCostCentreName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtPrimaryCostCentreName.IsAllowDigits = True
        Me.TxtPrimaryCostCentreName.IsAllowSpace = True
        Me.TxtPrimaryCostCentreName.IsAllowSplChars = True
        Me.TxtPrimaryCostCentreName.IsAllowToolTip = True
        Me.TxtPrimaryCostCentreName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtPrimaryCostCentreName.Location = New System.Drawing.Point(0, 0)
        Me.TxtPrimaryCostCentreName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtPrimaryCostCentreName.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtPrimaryCostCentreName.Name = "TxtPrimaryCostCentreName"
        Me.TxtPrimaryCostCentreName.SetToolTip = "Press Alt+C, To Create New "
        Me.TxtPrimaryCostCentreName.Size = New System.Drawing.Size(409, 21)
        Me.TxtPrimaryCostCentreName.Sorted = True
        Me.TxtPrimaryCostCentreName.SpecialCharList = "&-/@"
        Me.TxtPrimaryCostCentreName.TabIndex = 0
        Me.TxtPrimaryCostCentreName.UseFunctionKeys = False
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(36, 21)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 24)
        Me.Panel1.TabIndex = 1
        '
        'TxtTotal
        '
        Me.TxtTotal.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTotal, ErpDecimalPlaces)
        Me.TxtTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(616, 0)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(317, 21)
        Me.TxtTotal.TabIndex = 2
        Me.TxtTotal.Text = "0.000"
        Me.TxtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PayrollNewPrimaryCostControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PayrollNewPrimaryCostControl"
        Me.Size = New System.Drawing.Size(936, 45)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtPrimaryCostCentreName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TxtTotal As JyothiPharmaERPSystem3.IMSlabel

End Class
