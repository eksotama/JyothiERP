<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeCurrentPeriod
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
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.UserLabel4 = New UserLabel.UserLabel()
        Me.UserLabel2 = New UserLabel.UserLabel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.UserLabel1 = New UserLabel.UserLabel()
        Me.TxtDateStart = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtDateEnd = New JyothiPharmaERPSystem3.IMSDate()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.close32
        Me.Cancel_Button.Location = New System.Drawing.Point(18, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(140, 43)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'UserLabel4
        '
        Me.UserLabel4.AutoSize = True
        Me.UserLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Location = New System.Drawing.Point(12, 48)
        Me.UserLabel4.Name = "UserLabel4"
        Me.UserLabel4.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel4.Size = New System.Drawing.Size(71, 15)
        Me.UserLabel4.TabIndex = 16
        Me.UserLabel4.Text = "Start Date"
        Me.UserLabel4.TextEnglishCode = Nothing
        '
        'UserLabel2
        '
        Me.UserLabel2.BackColor = System.Drawing.Color.Green
        Me.UserLabel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UserLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.ForeColor = System.Drawing.Color.White
        Me.UserLabel2.Location = New System.Drawing.Point(0, 0)
        Me.UserLabel2.Name = "UserLabel2"
        Me.UserLabel2.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel2.Size = New System.Drawing.Size(421, 24)
        Me.UserLabel2.TabIndex = 15
        Me.UserLabel2.Text = "CURRENT PERIOD"
        Me.UserLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.UserLabel2.TextEnglishCode = Nothing
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = Global.JyothiPharmaERPSystem3.My.Resources.Resources.success32
        Me.OK_Button.Location = New System.Drawing.Point(195, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(140, 43)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(34, 117)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(354, 49)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'UserLabel1
        '
        Me.UserLabel1.AutoSize = True
        Me.UserLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Location = New System.Drawing.Point(12, 79)
        Me.UserLabel1.Name = "UserLabel1"
        Me.UserLabel1.SetEnglishFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel1.Size = New System.Drawing.Size(66, 15)
        Me.UserLabel1.TabIndex = 16
        Me.UserLabel1.Text = "End Date"
        Me.UserLabel1.TextEnglishCode = Nothing
        '
        'TxtDateStart
        '
        Me.TxtDateStart.Location = New System.Drawing.Point(127, 48)
        Me.TxtDateStart.Name = "TxtDateStart"
        Me.TxtDateStart.Size = New System.Drawing.Size(200, 20)
        Me.TxtDateStart.TabIndex = 0
        '
        'TxtDateEnd
        '
        Me.TxtDateEnd.Location = New System.Drawing.Point(127, 79)
        Me.TxtDateEnd.Name = "TxtDateEnd"
        Me.TxtDateEnd.Size = New System.Drawing.Size(200, 20)
        Me.TxtDateEnd.TabIndex = 1
        '
        'ChangeCurrentPeriod
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(421, 178)
        Me.Controls.Add(Me.TxtDateEnd)
        Me.Controls.Add(Me.TxtDateStart)
        Me.Controls.Add(Me.UserLabel1)
        Me.Controls.Add(Me.UserLabel4)
        Me.Controls.Add(Me.UserLabel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangeCurrentPeriod"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ChangeCurrentPeriod"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents UserLabel4 As UserLabel.UserLabel
    Friend WithEvents UserLabel2 As UserLabel.UserLabel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UserLabel1 As UserLabel.UserLabel
    Friend WithEvents TxtDateStart As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtDateEnd As JyothiPharmaERPSystem3.IMSDate

End Class
