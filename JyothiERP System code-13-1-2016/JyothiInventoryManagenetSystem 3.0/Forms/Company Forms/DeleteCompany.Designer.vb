<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeleteCompany
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.clist = New JyothiPharmaERPSystem3.IMSList()
        Me.tcmpname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tdbname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.clist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.clist, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnDelete, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnClose, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(590, 405)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'clist
        '
        Me.clist.AllowUserToAddRows = False
        Me.clist.AllowUserToDeleteRows = False
        Me.clist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.clist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.clist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tcmpname, Me.tdbname})
        Me.TableLayoutPanel1.SetColumnSpan(Me.clist, 2)
        Me.clist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clist.Location = New System.Drawing.Point(3, 35)
        Me.clist.MultiSelect = False
        Me.clist.Name = "clist"
        Me.clist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.clist.Size = New System.Drawing.Size(584, 317)
        Me.clist.TabIndex = 0
        '
        'tcmpname
        '
        Me.tcmpname.HeaderText = "Company Name"
        Me.tcmpname.Name = "tcmpname"
        '
        'tdbname
        '
        Me.tdbname.HeaderText = "DbName"
        Me.tdbname.Name = "tdbname"
        Me.tdbname.Visible = False
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Location = New System.Drawing.Point(298, 358)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(289, 44)
        Me.BtnDelete.TabIndex = 1
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Location = New System.Drawing.Point(3, 358)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(289, 44)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'DeleteCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 405)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DeleteCompany"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DeleteCompany"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.clist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents clist As JyothiPharmaERPSystem3.IMSList
    Friend WithEvents tcmpname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdbname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton

End Class
