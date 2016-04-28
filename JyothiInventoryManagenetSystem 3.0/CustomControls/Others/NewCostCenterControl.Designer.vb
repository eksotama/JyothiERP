<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewCostCenterControl
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
        Me.Panel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TxtTotal = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TxtCostCatName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTotal, 1, ErpDecimalPlaces)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtCostCatName, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(508, 85)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(71, 24)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(437, 45)
        Me.Panel1.TabIndex = 1
        '
        'TxtTotal
        '
        Me.TxtTotal.AutoSize = True
        Me.TxtTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(74, 69)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(431, 16)
        Me.TxtTotal.TabIndex = 2
        Me.TxtTotal.Text = "0.000"
        Me.TxtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtCostCatName
        '
        Me.TxtCostCatName.AllowEmpty = True
        Me.TxtCostCatName.AllowOnlyListValues = False
        Me.TxtCostCatName.AllowToolTip = True
        Me.TxtCostCatName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCostCatName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtCostCatName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtCostCatName.FormattingEnabled = True
        Me.TxtCostCatName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtCostCatName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtCostCatName.IsAllowDigits = True
        Me.TxtCostCatName.IsAllowSpace = True
        Me.TxtCostCatName.IsAllowSplChars = True
        Me.TxtCostCatName.IsAllowToolTip = True
        Me.TxtCostCatName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtCostCatName.Location = New System.Drawing.Point(3, 3)
        Me.TxtCostCatName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtCostCatName.Name = "TxtCostCatName"
        Me.TxtCostCatName.Size = New System.Drawing.Size(65, 21)
        Me.TxtCostCatName.Sorted = True
        Me.TxtCostCatName.SpecialCharList = "&-/@"
        Me.TxtCostCatName.TabIndex = 3
        Me.TxtCostCatName.UseFunctionKeys = False
        '
        'NewCostCenterControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "NewCostCenterControl"
        Me.Size = New System.Drawing.Size(508, 85)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TxtTotal As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents TxtCostCatName As JyothiPharmaERPSystem3.IMSComboBox

End Class
