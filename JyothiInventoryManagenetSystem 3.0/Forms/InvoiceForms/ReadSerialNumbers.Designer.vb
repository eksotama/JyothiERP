<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadSerialNumbers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadSerialNumbers))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtHead = New JyothiPharmaERPSystem3.IMSlabel()
        Me.ImSlabel1 = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.btnok = New JyothiPharmaERPSystem3.IMSButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SerialRowControl1 = New JyothiPharmaERPSystem3.SerialRowControl()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(336, 511)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtHead)
        Me.Panel1.Controls.Add(Me.ImSlabel1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 50)
        Me.Panel1.TabIndex = 1
        '
        'TxtHead
        '
        Me.TxtHead.AutoSize = True
        Me.TxtHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHead.Location = New System.Drawing.Point(3, 22)
        Me.TxtHead.Name = "TxtHead"
        Me.TxtHead.Size = New System.Drawing.Size(0, 13)
        Me.TxtHead.TabIndex = 0
        '
        'ImSlabel1
        '
        Me.ImSlabel1.AutoSize = True
        Me.ImSlabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImSlabel1.Location = New System.Drawing.Point(3, 6)
        Me.ImSlabel1.Name = "ImSlabel1"
        Me.ImSlabel1.Size = New System.Drawing.Size(197, 13)
        Me.ImSlabel1.TabIndex = 0
        Me.ImSlabel1.Text = "Enter or Select Serial Number For"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnok)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 464)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 47)
        Me.Panel2.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.AllowToolTip = True
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(25, 5)
        Me.btnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnClose.Name = "btnClose"
        Me.btnClose.SetToolTip = ""
        Me.btnClose.Size = New System.Drawing.Size(142, 37)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Cancel"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseFunctionKeys = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnok
        '
        Me.btnok.AllowToolTip = True
        Me.btnok.BackColor = System.Drawing.Color.White
        Me.btnok.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.btnok.Image = CType(resources.GetObject("btnok.Image"), System.Drawing.Image)
        Me.btnok.Location = New System.Drawing.Point(176, 5)
        Me.btnok.LostFocusFontColor = System.Drawing.Color.Blue
        Me.btnok.Name = "btnok"
        Me.btnok.SetToolTip = ""
        Me.btnok.Size = New System.Drawing.Size(140, 37)
        Me.btnok.TabIndex = 0
        Me.btnok.Text = "OK"
        Me.btnok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnok.UseFunctionKeys = False
        Me.btnok.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.SerialRowControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 59)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(330, 402)
        Me.Panel3.TabIndex = 3
        '
        'SerialRowControl1
        '
        Me.SerialRowControl1.AutoScroll = True
        Me.SerialRowControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SerialRowControl1.Location = New System.Drawing.Point(0, 0)
        Me.SerialRowControl1.Name = "SerialRowControl1"
        Me.SerialRowControl1.Size = New System.Drawing.Size(330, 402)
        Me.SerialRowControl1.TabIndex = 0
        '
        'ReadSerialNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 511)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadSerialNumbers"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Serial Numbers Info"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents btnok As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtHead As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents ImSlabel1 As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SerialRowControl1 As JyothiPharmaERPSystem3.SerialRowControl

End Class
