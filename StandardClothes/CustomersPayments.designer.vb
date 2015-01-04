<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomersPayments
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomersPayments))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.CustomerID = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.BillID = New System.Windows.Forms.ToolStripComboBox()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnHelp = New System.Windows.Forms.ToolStripButton()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.CashValue = New System.Windows.Forms.NumericUpDown()
        Me.PayValue = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridViewNotPayed = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridViewPayed = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        Me.ContentPanel.SuspendLayout()
        CType(Me.CashValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridViewNotPayed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridViewPayed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.CustomerID, Me.ToolStripLabel2, Me.BillID, Me.BtnNew, Me.ToolStripSeparator2, Me.BtnSave, Me.ToolStripSeparator3, Me.BtnDelete, Me.ToolStripSeparator5, Me.BtnExit, Me.ToolStripSeparator12, Me.BtnHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(958, 38)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(60, 35)
        Me.ToolStripLabel1.Text = "«”„ «·⁄„Ì· :"
        '
        'CustomerID
        '
        Me.CustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustomerID.AutoSize = False
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.Size = New System.Drawing.Size(150, 23)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(66, 35)
        Me.ToolStripLabel2.Text = "—ﬁ„ «·›« Ê—Â :"
        '
        'BillID
        '
        Me.BillID.Name = "BillID"
        Me.BillID.Size = New System.Drawing.Size(121, 38)
        '
        'BtnNew
        '
        Me.BtnNew.AutoSize = False
        Me.BtnNew.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.Image = Global.StandardClothes.My.Resources.Resources.View
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(150, 35)
        Me.BtnNew.Text = "«” ⁄·«„ ⁄‰ «·⁄„Ì·"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'BtnSave
        '
        Me.BtnSave.AutoSize = False
        Me.BtnSave.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Image = Global.StandardClothes.My.Resources.Resources.administrator_256
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(150, 35)
        Me.BtnSave.Text = "”œ«œ «·œ›⁄… «·„Õœœ…"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'BtnDelete
        '
        Me.BtnDelete.AutoSize = False
        Me.BtnDelete.BackgroundImage = Global.StandardClothes.My.Resources.Resources.delete_2_21
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(150, 35)
        Me.BtnDelete.Text = "Õ–›"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 38)
        '
        'BtnExit
        '
        Me.BtnExit.AutoSize = False
        Me.BtnExit.BackgroundImage = Global.StandardClothes.My.Resources.Resources.EXIT_2_22
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(150, 35)
        Me.BtnExit.Text = "Œ—ÊÃ"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 38)
        '
        'BtnHelp
        '
        Me.BtnHelp.AutoSize = False
        Me.BtnHelp.Image = Global.StandardClothes.My.Resources.Resources.Symbol_Help
        Me.BtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(150, 35)
        Me.BtnHelp.Text = "„”«⁄œ…"
        Me.BtnHelp.ToolTipText = "Help"
        Me.BtnHelp.Visible = False
        '
        'ContentPanel
        '
        Me.ContentPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContentPanel.Controls.Add(Me.CashValue)
        Me.ContentPanel.Controls.Add(Me.PayValue)
        Me.ContentPanel.Controls.Add(Me.GroupBox2)
        Me.ContentPanel.Controls.Add(Me.GroupBox1)
        Me.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentPanel.Location = New System.Drawing.Point(0, 38)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Size = New System.Drawing.Size(958, 582)
        Me.ContentPanel.TabIndex = 20
        '
        'CashValue
        '
        Me.CashValue.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.CashValue.Location = New System.Drawing.Point(601, 301)
        Me.CashValue.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.CashValue.Name = "CashValue"
        Me.CashValue.Size = New System.Drawing.Size(176, 25)
        Me.CashValue.TabIndex = 3
        Me.CashValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PayValue
        '
        Me.PayValue.Location = New System.Drawing.Point(783, 298)
        Me.PayValue.Name = "PayValue"
        Me.PayValue.Size = New System.Drawing.Size(148, 30)
        Me.PayValue.TabIndex = 2
        Me.PayValue.Text = "”œ«œ «·„»·€ «·„Õœœ"
        Me.PayValue.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridViewNotPayed)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 332)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(934, 241)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "œ›⁄«  ·„ Ì „ ”œ«œÂ«"
        '
        'DataGridViewNotPayed
        '
        Me.DataGridViewNotPayed.AllowUserToAddRows = False
        Me.DataGridViewNotPayed.AllowUserToDeleteRows = False
        Me.DataGridViewNotPayed.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridViewNotPayed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridViewNotPayed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewNotPayed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewNotPayed.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridViewNotPayed.Location = New System.Drawing.Point(3, 16)
        Me.DataGridViewNotPayed.Name = "DataGridViewNotPayed"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.DataGridViewNotPayed.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewNotPayed.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver
        Me.DataGridViewNotPayed.Size = New System.Drawing.Size(928, 222)
        Me.DataGridViewNotPayed.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridViewPayed)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(934, 275)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "œ›⁄«  „”œœ… „”»ﬁ«"
        '
        'DataGridViewPayed
        '
        Me.DataGridViewPayed.AllowUserToAddRows = False
        Me.DataGridViewPayed.AllowUserToDeleteRows = False
        Me.DataGridViewPayed.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridViewPayed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridViewPayed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPayed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewPayed.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridViewPayed.Location = New System.Drawing.Point(3, 16)
        Me.DataGridViewPayed.Name = "DataGridViewPayed"
        Me.DataGridViewPayed.ReadOnly = True
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.DataGridViewPayed.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewPayed.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver
        Me.DataGridViewPayed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewPayed.Size = New System.Drawing.Size(928, 256)
        Me.DataGridViewPayed.TabIndex = 1
        '
        'CustomersPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(958, 620)
        Me.Controls.Add(Me.ContentPanel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CustomersPayments"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "„œ›Ê⁄«  «·⁄„·«¡"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContentPanel.ResumeLayout(False)
        CType(Me.CashValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridViewNotPayed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridViewPayed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CustomerID As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewNotPayed As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewPayed As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BillID As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents PayValue As System.Windows.Forms.Button
    Friend WithEvents CashValue As System.Windows.Forms.NumericUpDown
End Class
