<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppointmentsDashBoard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppointmentsDashBoard))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CalanderControl1 = New JyothiPharmaERPSystem3.CalanderControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtShiftName = New JyothiPharmaERPSystem3.IMSComboBox()
        Me.ImsButton3 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton4 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton2 = New JyothiPharmaERPSystem3.IMSButton()
        Me.ImsButton1 = New JyothiPharmaERPSystem3.IMSButton()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TxtDashBoardDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CalanderControl1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(931, 530)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CalanderControl1
        '
        Me.CalanderControl1.CalEndDate = New Date(2014, 12, 24, 0, 0, 0, 0)
        Me.CalanderControl1.CalEndTimeForRows = New Date(2014, 12, 12, 20, 0, 0, 0)
        Me.CalanderControl1.CalStartDate = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.CalanderControl1.CalStartTimeForRows = New Date(2014, 12, 12, 9, 0, 0, 0)
        Me.CalanderControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CalanderControl1.IsShowEmployeeImages = False
        Me.CalanderControl1.Location = New System.Drawing.Point(219, 3)
        Me.CalanderControl1.Name = "CalanderControl1"
        Me.TableLayoutPanel1.SetRowSpan(Me.CalanderControl1, 2)
        Me.CalanderControl1.SetCaladerColumwidht = 200
        Me.CalanderControl1.setDateFormatString = "dd MMMM yyyy"
        Me.CalanderControl1.Size = New System.Drawing.Size(709, 524)
        Me.CalanderControl1.TabIndex = 0
        Me.CalanderControl1.TimeScaleValues = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtShiftName)
        Me.Panel1.Controls.Add(Me.ImsButton3)
        Me.Panel1.Controls.Add(Me.ImsButton4)
        Me.Panel1.Controls.Add(Me.ImsButton2)
        Me.Panel1.Controls.Add(Me.ImsButton1)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.TxtDashBoardDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 2)
        Me.Panel1.Size = New System.Drawing.Size(210, 524)
        Me.Panel1.TabIndex = 1
        '
        'TxtShiftName
        '
        Me.TxtShiftName.AllowEmpty = True
        Me.TxtShiftName.AllowOnlyListValues = True
        Me.TxtShiftName.AllowToolTip = True
        Me.TxtShiftName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtShiftName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TxtShiftName.CharcterCase = JyothiPharmaERPSystem3.IMSComboBox.ChangCaseValues.Title
        Me.TxtShiftName.FormattingEnabled = True
        Me.TxtShiftName.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtShiftName.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtShiftName.IsAdvanceSearchWindow = False
        Me.TxtShiftName.IsAllowDigits = True
        Me.TxtShiftName.IsAllowSpace = True
        Me.TxtShiftName.IsAllowSplChars = True
        Me.TxtShiftName.IsAllowToolTip = True
        Me.TxtShiftName.LFocusBackColor = System.Drawing.Color.White
        Me.TxtShiftName.Location = New System.Drawing.Point(13, 125)
        Me.TxtShiftName.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtShiftName.Name = "TxtShiftName"
        Me.TxtShiftName.SetToolTip = Nothing
        Me.TxtShiftName.Size = New System.Drawing.Size(179, 21)
        Me.TxtShiftName.Sorted = True
        Me.TxtShiftName.SpecialCharList = "&-/@"
        Me.TxtShiftName.TabIndex = 6
        Me.TxtShiftName.UseFunctionKeys = False
        '
        'ImsButton3
        '
        Me.ImsButton3.AllowToolTip = True
        Me.ImsButton3.BackColor = System.Drawing.Color.White
        Me.ImsButton3.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton3.Image = CType(resources.GetObject("ImsButton3.Image"), System.Drawing.Image)
        Me.ImsButton3.Location = New System.Drawing.Point(9, 186)
        Me.ImsButton3.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton3.Name = "ImsButton3"
        Me.ImsButton3.SetToolTip = ""
        Me.ImsButton3.Size = New System.Drawing.Size(194, 41)
        Me.ImsButton3.TabIndex = 5
        Me.ImsButton3.Text = "New Appointment"
        Me.ImsButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton3.UseFunctionKeys = False
        Me.ImsButton3.UseVisualStyleBackColor = False
        '
        'ImsButton4
        '
        Me.ImsButton4.AllowToolTip = True
        Me.ImsButton4.BackColor = System.Drawing.Color.White
        Me.ImsButton4.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton4.Image = CType(resources.GetObject("ImsButton4.Image"), System.Drawing.Image)
        Me.ImsButton4.Location = New System.Drawing.Point(9, 310)
        Me.ImsButton4.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton4.Name = "ImsButton4"
        Me.ImsButton4.SetToolTip = ""
        Me.ImsButton4.Size = New System.Drawing.Size(194, 46)
        Me.ImsButton4.TabIndex = 5
        Me.ImsButton4.Text = "APPOINTMENT REPORTS"
        Me.ImsButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton4.UseFunctionKeys = False
        Me.ImsButton4.UseVisualStyleBackColor = False
        '
        'ImsButton2
        '
        Me.ImsButton2.AllowToolTip = True
        Me.ImsButton2.BackColor = System.Drawing.Color.White
        Me.ImsButton2.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton2.Image = CType(resources.GetObject("ImsButton2.Image"), System.Drawing.Image)
        Me.ImsButton2.Location = New System.Drawing.Point(9, 249)
        Me.ImsButton2.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton2.Name = "ImsButton2"
        Me.ImsButton2.SetToolTip = ""
        Me.ImsButton2.Size = New System.Drawing.Size(194, 46)
        Me.ImsButton2.TabIndex = 5
        Me.ImsButton2.Text = "DAILY REPORT"
        Me.ImsButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton2.UseFunctionKeys = False
        Me.ImsButton2.UseVisualStyleBackColor = False
        '
        'ImsButton1
        '
        Me.ImsButton1.AllowToolTip = True
        Me.ImsButton1.BackColor = System.Drawing.Color.White
        Me.ImsButton1.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.ImsButton1.Image = CType(resources.GetObject("ImsButton1.Image"), System.Drawing.Image)
        Me.ImsButton1.Location = New System.Drawing.Point(9, 387)
        Me.ImsButton1.LostFocusFontColor = System.Drawing.Color.Blue
        Me.ImsButton1.Name = "ImsButton1"
        Me.ImsButton1.SetToolTip = ""
        Me.ImsButton1.Size = New System.Drawing.Size(194, 46)
        Me.ImsButton1.TabIndex = 5
        Me.ImsButton1.Text = "Close"
        Me.ImsButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ImsButton1.UseFunctionKeys = False
        Me.ImsButton1.UseVisualStyleBackColor = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(13, 11)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(114, 17)
        Me.CheckBox2.TabIndex = 4
        Me.CheckBox2.Text = "Verical Layout?"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(13, 34)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(165, 17)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Show Employee Pictures"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TxtDashBoardDate
        '
        Me.TxtDashBoardDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDashBoardDate.Location = New System.Drawing.Point(13, 70)
        Me.TxtDashBoardDate.Name = "TxtDashBoardDate"
        Me.TxtDashBoardDate.Size = New System.Drawing.Size(132, 20)
        Me.TxtDashBoardDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Shift Duty Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Appointment Dashboard by Date :"
        '
        'AppointmentsDashBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(931, 530)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AppointmentsDashBoard"
        Me.Text = "Appointments DashBoard"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CalanderControl1 As JyothiPharmaERPSystem3.CalanderControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtDashBoardDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ImsButton3 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton1 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtShiftName As JyothiPharmaERPSystem3.IMSComboBox
    Friend WithEvents ImsButton2 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents ImsButton4 As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
End Class
