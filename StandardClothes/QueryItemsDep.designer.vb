<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryItemsDep
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryItemsDep))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.StockID = New System.Windows.Forms.ComboBox()
        Me.Barcode = New System.Windows.Forms.TextBox()
        Me.ItemName = New System.Windows.Forms.ComboBox()
        Me.BillID = New System.Windows.Forms.ComboBox()
        Me.RadioStockName = New System.Windows.Forms.RadioButton()
        Me.RadioBarCode = New System.Windows.Forms.RadioButton()
        Me.RadioItemName = New System.Windows.Forms.RadioButton()
        Me.RadioBillID = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(20, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel1.Controls.Add(Me.StockID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Barcode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ItemName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BillID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadioStockName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadioBarCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadioItemName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadioBillID)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Panel1MinSize = 30
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(816, 467)
        Me.SplitContainer1.SplitterDistance = 138
        Me.SplitContainer1.SplitterIncrement = 8
        Me.SplitContainer1.TabIndex = 32
        '
        'StockID
        '
        Me.StockID.Enabled = False
        Me.StockID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockID.FormattingEnabled = True
        Me.StockID.Location = New System.Drawing.Point(32, 34)
        Me.StockID.Name = "StockID"
        Me.StockID.Size = New System.Drawing.Size(222, 26)
        Me.StockID.TabIndex = 36
        '
        'Barcode
        '
        Me.Barcode.Enabled = False
        Me.Barcode.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode.Location = New System.Drawing.Point(32, 83)
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Size = New System.Drawing.Size(222, 26)
        Me.Barcode.TabIndex = 35
        '
        'ItemName
        '
        Me.ItemName.Enabled = False
        Me.ItemName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemName.FormattingEnabled = True
        Me.ItemName.Location = New System.Drawing.Point(426, 81)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(243, 26)
        Me.ItemName.TabIndex = 34
        '
        'BillID
        '
        Me.BillID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BillID.FormattingEnabled = True
        Me.BillID.Location = New System.Drawing.Point(548, 38)
        Me.BillID.Name = "BillID"
        Me.BillID.Size = New System.Drawing.Size(121, 26)
        Me.BillID.TabIndex = 33
        '
        'RadioStockName
        '
        Me.RadioStockName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioStockName.Location = New System.Drawing.Point(260, 38)
        Me.RadioStockName.Name = "RadioStockName"
        Me.RadioStockName.Size = New System.Drawing.Size(119, 23)
        Me.RadioStockName.TabIndex = 3
        Me.RadioStockName.Text = "اسم المحل"
        Me.RadioStockName.UseVisualStyleBackColor = True
        '
        'RadioBarCode
        '
        Me.RadioBarCode.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBarCode.Location = New System.Drawing.Point(260, 84)
        Me.RadioBarCode.Name = "RadioBarCode"
        Me.RadioBarCode.Size = New System.Drawing.Size(119, 23)
        Me.RadioBarCode.TabIndex = 2
        Me.RadioBarCode.Text = "الباركود"
        Me.RadioBarCode.UseVisualStyleBackColor = True
        '
        'RadioItemName
        '
        Me.RadioItemName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioItemName.Location = New System.Drawing.Point(676, 83)
        Me.RadioItemName.Name = "RadioItemName"
        Me.RadioItemName.Size = New System.Drawing.Size(115, 23)
        Me.RadioItemName.TabIndex = 1
        Me.RadioItemName.Text = "اسم الصنف"
        Me.RadioItemName.UseVisualStyleBackColor = True
        '
        'RadioBillID
        '
        Me.RadioBillID.Checked = True
        Me.RadioBillID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBillID.Location = New System.Drawing.Point(675, 41)
        Me.RadioBillID.Name = "RadioBillID"
        Me.RadioBillID.Size = New System.Drawing.Size(116, 23)
        Me.RadioBillID.TabIndex = 0
        Me.RadioBillID.TabStop = True
        Me.RadioBillID.Text = "رقم المستند"
        Me.RadioBillID.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver
        Me.DataGridView1.Size = New System.Drawing.Size(814, 323)
        Me.DataGridView1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(105, 489)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 31)
        Me.Button2.TabIndex = 43
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(651, 489)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 31)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'QueryItemsDep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(856, 527)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QueryItemsDep"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الاستعلام عن الأصناف المهلكة"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadioStockName As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBarCode As System.Windows.Forms.RadioButton
    Friend WithEvents RadioItemName As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBillID As System.Windows.Forms.RadioButton
    Friend WithEvents StockID As System.Windows.Forms.ComboBox
    Friend WithEvents Barcode As System.Windows.Forms.TextBox
    Friend WithEvents ItemName As System.Windows.Forms.ComboBox
    Friend WithEvents BillID As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
