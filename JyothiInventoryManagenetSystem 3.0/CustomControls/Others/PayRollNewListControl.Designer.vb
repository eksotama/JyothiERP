<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayRollNewListControl
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
        Me.TxtEmployeeNames = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.Panel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TxtTotal = New JyothiPharmaERPSystem3.IMSlabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtEmployeeNames, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTotal, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(865, 45)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TxtEmployeeNames
        '
        Me.TxtEmployeeNames.AllowEmpty = False
        Me.TxtEmployeeNames.AllowOnlyListValues = True
        Me.TxtEmployeeNames.AllowToolTip = True
        Me.TxtEmployeeNames.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtEmployeeNames.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtEmployeeNames.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtEmployeeNames, 2)
        Me.TxtEmployeeNames.FormattingEnabled = True
        Me.TxtEmployeeNames.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtEmployeeNames.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtEmployeeNames.IsAllowDigits = True
        Me.TxtEmployeeNames.IsAllowSpace = True
        Me.TxtEmployeeNames.IsAllowSplChars = True
        Me.TxtEmployeeNames.IsAllowToolTip = True
        Me.TxtEmployeeNames.LFocusBackColor = System.Drawing.Color.White
        Me.TxtEmployeeNames.Location = New System.Drawing.Point(0, 0)
        Me.TxtEmployeeNames.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtEmployeeNames.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtEmployeeNames.Name = "TxtEmployeeNames"
        Me.TxtEmployeeNames.Size = New System.Drawing.Size(409, 21)
        Me.TxtEmployeeNames.Sorted = True
        Me.TxtEmployeeNames.SpecialCharList = "&-/@"
        Me.TxtEmployeeNames.TabIndex = 0
        Me.TxtEmployeeNames.UseFunctionKeys = False
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(41, 21)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 24)
        Me.Panel1.TabIndex = 1
        '
        'TxtTotal
        '
        Me.TxtTotal.AutoSize = True
        Me.TxtTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(685, 0)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(177, 21)
        Me.TxtTotal.TabIndex = 2
        Me.TxtTotal.Text = "0.000"
        Me.TxtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PayRollNewListControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PayRollNewListControl"
        Me.Size = New System.Drawing.Size(865, 45)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtEmployeeNames As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TxtTotal As JyothiPharmaERPSystem3.IMSlabel

End Class
