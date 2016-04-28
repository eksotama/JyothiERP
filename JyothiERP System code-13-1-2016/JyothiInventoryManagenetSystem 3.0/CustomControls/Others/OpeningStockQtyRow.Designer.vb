<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningStockQtyRow
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
        Me.TxtQty = New JyothiPharmaERPSystem3.IMSQTYE()
        Me.TxtLocation = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.56009!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.67574!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtQty, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtLocation, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(339, 31)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TxtQty
        '
        Me.TxtQty.AutoSize = True
        Me.TxtQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtQty.Location = New System.Drawing.Point(205, 3)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(131, 25)
        Me.TxtQty.TabIndex = 1
        Me.TxtQty.VisibleLabels = True
        '
        'TxtLocation
        '
        Me.TxtLocation.AllowEmpty = True
        Me.TxtLocation.AllowOnlyListValues = True
        Me.TxtLocation.AllowToolTip = True
        Me.TxtLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtLocation.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TxtLocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtLocation.FormattingEnabled = True
        Me.TxtLocation.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtLocation.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtLocation.IsAdvanceSearchWindow = False
        Me.TxtLocation.IsAllowDigits = True
        Me.TxtLocation.IsAllowSpace = False
        Me.TxtLocation.IsAllowSplChars = True
        Me.TxtLocation.IsAllowToolTip = True
        Me.TxtLocation.LFocusBackColor = System.Drawing.Color.White
        Me.TxtLocation.Location = New System.Drawing.Point(3, 3)
        Me.TxtLocation.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.SetToolTip = Nothing
        Me.TxtLocation.Size = New System.Drawing.Size(196, 21)
        Me.TxtLocation.Sorted = True
        Me.TxtLocation.SpecialCharList = "&-/@"
        Me.TxtLocation.TabIndex = 0
        Me.TxtLocation.UseFunctionKeys = False
        '
        'OpeningStockQtyRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "OpeningStockQtyRow"
        Me.Size = New System.Drawing.Size(339, 31)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtQty As JyothiPharmaERPSystem3.IMSQTYE
    Friend WithEvents TxtLocation As JyothiPharmaERPSystem3.IMSComboBox

End Class
