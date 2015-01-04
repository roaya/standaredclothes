<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryAllItem2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryAllItem2))
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtBarcode = New System.Windows.Forms.TextBox()
        Me.CmbItem = New System.Windows.Forms.ComboBox()
        Me.CmbStockID = New System.Windows.Forms.ComboBox()
        Me.RadCorporation = New System.Windows.Forms.RadioButton()
        Me.RadStock = New System.Windows.Forms.RadioButton()
        Me.RadType = New System.Windows.Forms.RadioButton()
        Me.RadBarcode = New System.Windows.Forms.RadioButton()
        Me.RadCategory = New System.Windows.Forms.RadioButton()
        Me.RadItemName = New System.Windows.Forms.RadioButton()
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.CmbCorporation = New System.Windows.Forms.ComboBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1368, 730)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "نتيجة التقرير"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1362, 724)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1368, 730)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(385, 453)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(139, 36)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(622, 453)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 36)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtBarcode)
        Me.GroupBox1.Controls.Add(Me.CmbItem)
        Me.GroupBox1.Controls.Add(Me.CmbStockID)
        Me.GroupBox1.Controls.Add(Me.RadCorporation)
        Me.GroupBox1.Controls.Add(Me.RadStock)
        Me.GroupBox1.Controls.Add(Me.RadType)
        Me.GroupBox1.Controls.Add(Me.RadBarcode)
        Me.GroupBox1.Controls.Add(Me.RadCategory)
        Me.GroupBox1.Controls.Add(Me.RadItemName)
        Me.GroupBox1.Controls.Add(Me.CmbCategory)
        Me.GroupBox1.Controls.Add(Me.CmbCorporation)
        Me.GroupBox1.Controls.Add(Me.cmbType)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(324, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(486, 308)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'TxtBarcode
        '
        Me.TxtBarcode.Enabled = False
        Me.TxtBarcode.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBarcode.Location = New System.Drawing.Point(61, 256)
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Size = New System.Drawing.Size(244, 26)
        Me.TxtBarcode.TabIndex = 15
        '
        'CmbItem
        '
        Me.CmbItem.Enabled = False
        Me.CmbItem.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(61, 213)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(244, 26)
        Me.CmbItem.TabIndex = 14
        '
        'CmbStockID
        '
        Me.CmbStockID.Enabled = False
        Me.CmbStockID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbStockID.FormattingEnabled = True
        Me.CmbStockID.Location = New System.Drawing.Point(61, 41)
        Me.CmbStockID.Name = "CmbStockID"
        Me.CmbStockID.Size = New System.Drawing.Size(244, 26)
        Me.CmbStockID.TabIndex = 13
        '
        'RadCorporation
        '
        Me.RadCorporation.AutoSize = True
        Me.RadCorporation.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCorporation.Location = New System.Drawing.Point(354, 129)
        Me.RadCorporation.Name = "RadCorporation"
        Me.RadCorporation.Size = New System.Drawing.Size(72, 22)
        Me.RadCorporation.TabIndex = 12
        Me.RadCorporation.Text = "الشركه"
        Me.RadCorporation.UseVisualStyleBackColor = True
        '
        'RadStock
        '
        Me.RadStock.AutoSize = True
        Me.RadStock.Checked = True
        Me.RadStock.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadStock.Location = New System.Drawing.Point(357, 43)
        Me.RadStock.Name = "RadStock"
        Me.RadStock.Size = New System.Drawing.Size(69, 22)
        Me.RadStock.TabIndex = 11
        Me.RadStock.TabStop = True
        Me.RadStock.Text = "المخزن"
        Me.RadStock.UseVisualStyleBackColor = True
        '
        'RadType
        '
        Me.RadType.AutoSize = True
        Me.RadType.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadType.Location = New System.Drawing.Point(370, 172)
        Me.RadType.Name = "RadType"
        Me.RadType.Size = New System.Drawing.Size(56, 22)
        Me.RadType.TabIndex = 10
        Me.RadType.Text = "الفئه"
        Me.RadType.UseVisualStyleBackColor = True
        '
        'RadBarcode
        '
        Me.RadBarcode.AutoSize = True
        Me.RadBarcode.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadBarcode.Location = New System.Drawing.Point(357, 258)
        Me.RadBarcode.Name = "RadBarcode"
        Me.RadBarcode.Size = New System.Drawing.Size(69, 22)
        Me.RadBarcode.TabIndex = 9
        Me.RadBarcode.Text = "الباركود"
        Me.RadBarcode.UseVisualStyleBackColor = True
        '
        'RadCategory
        '
        Me.RadCategory.AutoSize = True
        Me.RadCategory.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCategory.Location = New System.Drawing.Point(374, 86)
        Me.RadCategory.Name = "RadCategory"
        Me.RadCategory.Size = New System.Drawing.Size(52, 22)
        Me.RadCategory.TabIndex = 8
        Me.RadCategory.Text = "البند"
        Me.RadCategory.UseVisualStyleBackColor = True
        '
        'RadItemName
        '
        Me.RadItemName.AutoSize = True
        Me.RadItemName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadItemName.Location = New System.Drawing.Point(326, 215)
        Me.RadItemName.Name = "RadItemName"
        Me.RadItemName.Size = New System.Drawing.Size(100, 22)
        Me.RadItemName.TabIndex = 7
        Me.RadItemName.Text = "اسم الصنف"
        Me.RadItemName.UseVisualStyleBackColor = True
        '
        'CmbCategory
        '
        Me.CmbCategory.Enabled = False
        Me.CmbCategory.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(61, 84)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(244, 26)
        Me.CmbCategory.TabIndex = 6
        '
        'CmbCorporation
        '
        Me.CmbCorporation.Enabled = False
        Me.CmbCorporation.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCorporation.FormattingEnabled = True
        Me.CmbCorporation.Location = New System.Drawing.Point(61, 127)
        Me.CmbCorporation.Name = "CmbCorporation"
        Me.CmbCorporation.Size = New System.Drawing.Size(244, 26)
        Me.CmbCorporation.TabIndex = 5
        '
        'cmbType
        '
        Me.cmbType.Enabled = False
        Me.cmbType.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(61, 170)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(244, 26)
        Me.cmbType.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1376, 756)
        Me.TabControl1.TabIndex = 2
        '
        'QueryAllItem2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1376, 756)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QueryAllItem2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "عرض بيانات الصنف بالاسم"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents CmbStockID As System.Windows.Forms.ComboBox
    Friend WithEvents RadCorporation As System.Windows.Forms.RadioButton
    Friend WithEvents RadStock As System.Windows.Forms.RadioButton
    Friend WithEvents RadType As System.Windows.Forms.RadioButton
    Friend WithEvents RadBarcode As System.Windows.Forms.RadioButton
    Friend WithEvents RadCategory As System.Windows.Forms.RadioButton
    Friend WithEvents RadItemName As System.Windows.Forms.RadioButton
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCorporation As System.Windows.Forms.ComboBox
End Class
