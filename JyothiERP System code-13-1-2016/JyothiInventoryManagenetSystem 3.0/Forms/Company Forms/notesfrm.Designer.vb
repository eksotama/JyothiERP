<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class notesfrm
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
        Me.TxtNotes = New System.Windows.Forms.RichTextBox()
        Me.BtnPre = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnNext = New JyothiPharmaERPSystem3.IMSButton()
        Me.TxtSearchBy = New JyothiPharmaERPSystem3.IMSNumericTextBox()
        Me.TxtDate = New JyothiPharmaERPSystem3.IMSDate()
        Me.TxtNoteID = New JyothiPharmaERPSystem3.IMSlabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnPrintAll = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnPrint = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnClose = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnDelete = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnNew = New JyothiPharmaERPSystem3.IMSButton()
        Me.BtnSave = New JyothiPharmaERPSystem3.IMSButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TxtNotes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnPre, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnNext, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtSearchBy, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtDate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtNoteID, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(665, 444)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TxtNotes
        '
        Me.TxtNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtNotes, 5)
        Me.TxtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtNotes.Location = New System.Drawing.Point(3, 29)
        Me.TxtNotes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtNotes.MaxLength = 99999
        Me.TxtNotes.Name = "TxtNotes"
        Me.TxtNotes.Size = New System.Drawing.Size(659, 376)
        Me.TxtNotes.TabIndex = 0
        Me.TxtNotes.Text = ""
        '
        'BtnPre
        '
        Me.BtnPre.AllowToolTip = True
        Me.BtnPre.BackgroundImage = Global.JyothiPharmaERPSystem3.My.Resources.Resources.arrow_98_48
        Me.BtnPre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPre.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPre.Location = New System.Drawing.Point(473, 2)
        Me.BtnPre.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnPre.Name = "BtnPre"
        Me.BtnPre.SetToolTip = ""
        Me.BtnPre.Size = New System.Drawing.Size(59, 23)
        Me.BtnPre.TabIndex = 1
        Me.BtnPre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPre.UseFunctionKeys = False
        Me.BtnPre.UseVisualStyleBackColor = True
        '
        'BtnNext
        '
        Me.BtnNext.AllowToolTip = True
        Me.BtnNext.BackgroundImage = Global.JyothiPharmaERPSystem3.My.Resources.Resources.arrow_33_48
        Me.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNext.Location = New System.Drawing.Point(603, 2)
        Me.BtnNext.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNext.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.SetToolTip = ""
        Me.BtnNext.Size = New System.Drawing.Size(59, 23)
        Me.BtnNext.TabIndex = 1
        Me.BtnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNext.UseFunctionKeys = False
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'TxtSearchBy
        '
        Me.TxtSearchBy.AllHelpText = True
        Me.TxtSearchBy.AllowDecimal = False
        Me.TxtSearchBy.AllowFormulas = False
        Me.TxtSearchBy.AllowForQty = True
        Me.TxtSearchBy.AllowNegative = False
        Me.TxtSearchBy.AllowPerSign = False
        Me.TxtSearchBy.AllowPlusSign = False
        Me.TxtSearchBy.AllowToolTip = True
        Me.TxtSearchBy.DecimalPlaces = CType(3, Short)
        Me.TxtSearchBy.ExitOnEscKey = True
        Me.TxtSearchBy.GFocusBackColor = System.Drawing.Color.Yellow
        Me.TxtSearchBy.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.TxtSearchBy.GotFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TxtSearchBy.HelpText = Nothing
        Me.TxtSearchBy.LFocusBackColor = System.Drawing.Color.White
        Me.TxtSearchBy.Location = New System.Drawing.Point(538, 2)
        Me.TxtSearchBy.LostFocusFontColor = System.Drawing.Color.Blue
        Me.TxtSearchBy.LostFocusFontSize = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtSearchBy.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSearchBy.Max = CType(100000000000000, Long)
        Me.TxtSearchBy.MaxLength = 12
        Me.TxtSearchBy.Min = CType(0, Long)
        Me.TxtSearchBy.Name = "TxtSearchBy"
        Me.TxtSearchBy.NextOnEnter = True
        Me.TxtSearchBy.SetToolTip = "Search by Note ID"
        Me.TxtSearchBy.Size = New System.Drawing.Size(54, 23)
        Me.TxtSearchBy.TabIndex = 3
        Me.TxtSearchBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSearchBy.ToolTip = "Search by Note ID"
        Me.TxtSearchBy.UseFunctionKeys = False
        Me.TxtSearchBy.UseUpDownArrowKeys = False
        '
        'TxtDate
        '
        Me.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtDate.Location = New System.Drawing.Point(183, 2)
        Me.TxtDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(284, 23)
        Me.TxtDate.TabIndex = 4
        '
        'TxtNoteID
        '
        Me.TxtNoteID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtNoteID.AutoSize = True
        Me.TxtNoteID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoteID.Location = New System.Drawing.Point(3, 0)
        Me.TxtNoteID.Name = "TxtNoteID"
        Me.TxtNoteID.Size = New System.Drawing.Size(68, 27)
        Me.TxtNoteID.TabIndex = 5
        Me.TxtNoteID.Text = "Note ID :"
        Me.TxtNoteID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 5)
        Me.Panel1.Controls.Add(Me.BtnPrintAll)
        Me.Panel1.Controls.Add(Me.BtnPrint)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnDelete)
        Me.Panel1.Controls.Add(Me.BtnNew)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 407)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(665, 37)
        Me.Panel1.TabIndex = 6
        '
        'BtnPrintAll
        '
        Me.BtnPrintAll.AllowToolTip = True
        Me.BtnPrintAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrintAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrintAll.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintAll.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrintAll.Location = New System.Drawing.Point(136, 2)
        Me.BtnPrintAll.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrintAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnPrintAll.Name = "BtnPrintAll"
        Me.BtnPrintAll.SetToolTip = ""
        Me.BtnPrintAll.Size = New System.Drawing.Size(74, 33)
        Me.BtnPrintAll.TabIndex = 2
        Me.BtnPrintAll.Text = "Print All"
        Me.BtnPrintAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrintAll.UseFunctionKeys = False
        Me.BtnPrintAll.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.AllowToolTip = True
        Me.BtnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnPrint.Location = New System.Drawing.Point(248, 2)
        Me.BtnPrint.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnPrint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.SetToolTip = ""
        Me.BtnPrint.Size = New System.Drawing.Size(74, 33)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnPrint.UseFunctionKeys = False
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.AllowToolTip = True
        Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnClose.Location = New System.Drawing.Point(24, 2)
        Me.BtnClose.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.SetToolTip = ""
        Me.BtnClose.Size = New System.Drawing.Size(74, 33)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseFunctionKeys = False
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.AllowToolTip = True
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnDelete.Location = New System.Drawing.Point(360, 2)
        Me.BtnDelete.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.SetToolTip = ""
        Me.BtnDelete.Size = New System.Drawing.Size(74, 33)
        Me.BtnDelete.TabIndex = 2
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseFunctionKeys = False
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.AllowToolTip = True
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnNew.Location = New System.Drawing.Point(472, 2)
        Me.BtnNew.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.SetToolTip = ""
        Me.BtnNew.Size = New System.Drawing.Size(74, 33)
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.Text = "New"
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNew.UseFunctionKeys = False
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.AllowToolTip = True
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.GotFocusFontColor = System.Drawing.Color.Maroon
        Me.BtnSave.Location = New System.Drawing.Point(584, 2)
        Me.BtnSave.LostFocusFontColor = System.Drawing.Color.Blue
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.SetToolTip = ""
        Me.BtnSave.Size = New System.Drawing.Size(74, 33)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Save"
        Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSave.UseFunctionKeys = False
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'notesfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(665, 444)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "notesfrm"
        Me.Text = "notesfrm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents BtnPre As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnNext As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnSave As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnClose As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnDelete As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents TxtSearchBy As JyothiPharmaERPSystem3.IMSNumericTextBox
    Friend WithEvents TxtDate As JyothiPharmaERPSystem3.IMSDate
    Friend WithEvents TxtNoteID As JyothiPharmaERPSystem3.IMSlabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnNew As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrintAll As JyothiPharmaERPSystem3.IMSButton
    Friend WithEvents BtnPrint As JyothiPharmaERPSystem3.IMSButton
End Class
