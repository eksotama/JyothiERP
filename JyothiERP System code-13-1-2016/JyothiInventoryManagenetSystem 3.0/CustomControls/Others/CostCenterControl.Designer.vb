<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CostCenterControl
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
        Me.Panel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtCostCatName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TxtTotal = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(71, 24)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(444, 16)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCostCatName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTotal, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(515, 76)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtCostCatName
        '
        Me.TxtCostCatName.AllowEmpty = False
        Me.TxtCostCatName.AllowOnlyListValues = True
        Me.TxtCostCatName.AllowToolTip = True
        Me.TxtCostCatName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCostCatName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCostCatName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtCostCatName, 3)
        Me.TxtCostCatName.FormattingEnabled = True
        Me.TxtCostCatName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCostCatName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCostCatName.IsAllowDigits = True
        Me.TxtCostCatName.IsAllowSpace = True
        Me.TxtCostCatName.IsAllowSplChars = True
        Me.TxtCostCatName.IsAllowToolTip = True
        Me.TxtCostCatName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCostCatName.Location = New System.Drawing.Point(0, 0)
        Me.TxtCostCatName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCostCatName.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtCostCatName.Name = "TxtCostCatName"
        Me.TxtCostCatName.SetToolTip = Nothing
        Me.TxtCostCatName.Size = New System.Drawing.Size(315, 21)
        Me.TxtCostCatName.Sorted = True
        Me.TxtCostCatName.SpecialCharList = "&-/@"
        Me.TxtCostCatName.TabIndex = 0
        Me.TxtCostCatName.UseFunctionKeys = False
        '
        'TxtTotal
        '
        Me.TxtTotal.AutoSize = True
        Me.TxtTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(74, 56)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(438, 20)
        Me.TxtTotal.TabIndex = 2
        Me.TxtTotal.Text = "0.000"
        Me.TxtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CostCenterControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CostCenterControl"
        Me.Size = New System.Drawing.Size(515, 76)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtCostCatName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents TxtTotal As JyothiPharmaERPSystem3.IMSlabel

End Class
