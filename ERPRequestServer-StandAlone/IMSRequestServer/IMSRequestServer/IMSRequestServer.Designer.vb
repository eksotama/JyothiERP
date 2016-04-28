<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMSServerForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMSServerForm))
        Me.JyothiERPServer = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TxtStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TxtReqlist = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TxtList = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.BtnRelese = New System.Windows.Forms.Button()
        Me.TxtLockList = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtErrorStatus = New System.Windows.Forms.TextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TxtReqlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.TxtLockList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'JyothiERPServer
        '
        Me.JyothiERPServer.BalloonTipText = "ERP Request Server "
        Me.JyothiERPServer.BalloonTipTitle = "ERP Request Server "
        Me.JyothiERPServer.Icon = CType(resources.GetObject("JyothiERPServer.Icon"), System.Drawing.Icon)
        Me.JyothiERPServer.Text = "ERP Request Server"
        Me.JyothiERPServer.Visible = True
        '
        'TxtStatus
        '
        Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.Location = New System.Drawing.Point(89, 9)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(645, 39)
        Me.TxtStatus.TabIndex = 1
        Me.TxtStatus.Text = "Idle"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(22, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(823, 369)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TxtReqlist)
        Me.TabPage1.Controls.Add(Me.TxtStatus)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(815, 343)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Request Monitor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TxtReqlist
        '
        Me.TxtReqlist.AllowUserToAddRows = False
        Me.TxtReqlist.AllowUserToDeleteRows = False
        Me.TxtReqlist.AllowUserToResizeRows = False
        Me.TxtReqlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtReqlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtReqlist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtReqlist.Location = New System.Drawing.Point(25, 40)
        Me.TxtReqlist.Name = "TxtReqlist"
        Me.TxtReqlist.Size = New System.Drawing.Size(760, 297)
        Me.TxtReqlist.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.TxtList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(815, 343)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "User Monitor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = Global.IMSRequestServer.My.Resources.Resources._stop
        Me.Button5.Location = New System.Drawing.Point(721, 148)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(91, 44)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Logout"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = Global.IMSRequestServer.My.Resources.Resources.refresh
        Me.Button4.Location = New System.Drawing.Point(721, 53)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 44)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Refresh"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxtList
        '
        Me.TxtList.AllowUserToAddRows = False
        Me.TxtList.AllowUserToDeleteRows = False
        Me.TxtList.AllowUserToResizeRows = False
        Me.TxtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtList.Location = New System.Drawing.Point(6, 6)
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(709, 331)
        Me.TxtList.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.BtnRelese)
        Me.TabPage3.Controls.Add(Me.TxtLockList)
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(815, 343)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "User Transactions"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'BtnRelese
        '
        Me.BtnRelese.Location = New System.Drawing.Point(703, 154)
        Me.BtnRelese.Name = "BtnRelese"
        Me.BtnRelese.Size = New System.Drawing.Size(98, 44)
        Me.BtnRelese.TabIndex = 4
        Me.BtnRelese.Text = "Release Lock"
        Me.BtnRelese.UseVisualStyleBackColor = True
        '
        'TxtLockList
        '
        Me.TxtLockList.AllowUserToAddRows = False
        Me.TxtLockList.AllowUserToDeleteRows = False
        Me.TxtLockList.AllowUserToResizeRows = False
        Me.TxtLockList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TxtLockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TxtLockList.Dock = System.Windows.Forms.DockStyle.Left
        Me.TxtLockList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TxtLockList.Location = New System.Drawing.Point(0, 0)
        Me.TxtLockList.MultiSelect = False
        Me.TxtLockList.Name = "TxtLockList"
        Me.TxtLockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TxtLockList.Size = New System.Drawing.Size(692, 343)
        Me.TxtLockList.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Image = Global.IMSRequestServer.My.Resources.Resources.refresh
        Me.Button3.Location = New System.Drawing.Point(703, 52)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 44)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Refresh"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtErrorStatus, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(829, 470)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 378)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(823, 49)
        Me.Panel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Image = Global.IMSRequestServer.My.Resources.Resources.alert24
        Me.Button1.Location = New System.Drawing.Point(297, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(167, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Shut Down Server"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtErrorStatus
        '
        Me.TxtErrorStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtErrorStatus.Location = New System.Drawing.Point(3, 433)
        Me.TxtErrorStatus.Multiline = True
        Me.TxtErrorStatus.Name = "TxtErrorStatus"
        Me.TxtErrorStatus.Size = New System.Drawing.Size(823, 34)
        Me.TxtErrorStatus.TabIndex = 4
        '
        'Timer2
        '
        Me.Timer2.Interval = 5090
        '
        'IMSServerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(829, 470)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMSServerForm"
        Me.ShowInTaskbar = False
        Me.Text = "ERP Request Server"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.TxtReqlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TxtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.TxtLockList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents JyothiERPServer As System.Windows.Forms.NotifyIcon
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TxtReqlist As System.Windows.Forms.DataGridView
    Friend WithEvents TxtLockList As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnRelese As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TxtErrorStatus As System.Windows.Forms.TextBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents TxtList As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button

End Class
