<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportInventoryLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportInventoryLog))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Corporation = New System.Windows.Forms.ComboBox()
        Me.bycorporation = New System.Windows.Forms.RadioButton()
        Me.Category = New System.Windows.Forms.ComboBox()
        Me.bycat = New System.Windows.Forms.RadioButton()
        Me.Stock = New System.Windows.Forms.ComboBox()
        Me.bystock = New System.Windows.Forms.RadioButton()
        Me.Item = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bydate = New System.Windows.Forms.RadioButton()
        Me.ByItem = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(294, 497)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 39)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "استعلام"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(68, 497)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 39)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(41, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 430)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Corporation)
        Me.Panel2.Controls.Add(Me.bycorporation)
        Me.Panel2.Controls.Add(Me.Category)
        Me.Panel2.Controls.Add(Me.bycat)
        Me.Panel2.Controls.Add(Me.Stock)
        Me.Panel2.Controls.Add(Me.bystock)
        Me.Panel2.Controls.Add(Me.Item)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.bydate)
        Me.Panel2.Controls.Add(Me.ByItem)
        Me.Panel2.Location = New System.Drawing.Point(20, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(400, 383)
        Me.Panel2.TabIndex = 9
        '
        'Corporation
        '
        Me.Corporation.Enabled = False
        Me.Corporation.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Corporation.FormattingEnabled = True
        Me.Corporation.Location = New System.Drawing.Point(27, 162)
        Me.Corporation.Name = "Corporation"
        Me.Corporation.Size = New System.Drawing.Size(196, 26)
        Me.Corporation.TabIndex = 65
        '
        'bycorporation
        '
        Me.bycorporation.AutoSize = True
        Me.bycorporation.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.bycorporation.Location = New System.Drawing.Point(233, 164)
        Me.bycorporation.Name = "bycorporation"
        Me.bycorporation.Size = New System.Drawing.Size(146, 21)
        Me.bycorporation.TabIndex = 64
        Me.bycorporation.Text = "الفلترة باسم الشركة"
        Me.bycorporation.UseVisualStyleBackColor = True
        '
        'Category
        '
        Me.Category.Enabled = False
        Me.Category.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Category.FormattingEnabled = True
        Me.Category.Location = New System.Drawing.Point(27, 112)
        Me.Category.Name = "Category"
        Me.Category.Size = New System.Drawing.Size(196, 26)
        Me.Category.TabIndex = 63
        '
        'bycat
        '
        Me.bycat.AutoSize = True
        Me.bycat.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.bycat.Location = New System.Drawing.Point(251, 114)
        Me.bycat.Name = "bycat"
        Me.bycat.Size = New System.Drawing.Size(128, 21)
        Me.bycat.TabIndex = 62
        Me.bycat.Text = "الفلترة باسم البند"
        Me.bycat.UseVisualStyleBackColor = True
        '
        'Stock
        '
        Me.Stock.Enabled = False
        Me.Stock.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Stock.FormattingEnabled = True
        Me.Stock.Location = New System.Drawing.Point(27, 61)
        Me.Stock.Name = "Stock"
        Me.Stock.Size = New System.Drawing.Size(196, 26)
        Me.Stock.TabIndex = 61
        '
        'bystock
        '
        Me.bystock.AutoSize = True
        Me.bystock.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.bystock.Location = New System.Drawing.Point(235, 63)
        Me.bystock.Name = "bystock"
        Me.bystock.Size = New System.Drawing.Size(144, 21)
        Me.bystock.TabIndex = 60
        Me.bystock.Text = "الفلترة باسم المخزن"
        Me.bystock.UseVisualStyleBackColor = True
        '
        'Item
        '
        Me.Item.Enabled = False
        Me.Item.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Item.FormattingEnabled = True
        Me.Item.Location = New System.Drawing.Point(27, 13)
        Me.Item.Name = "Item"
        Me.Item.Size = New System.Drawing.Size(196, 26)
        Me.Item.TabIndex = 59
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(38, 246)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 112)
        Me.Panel1.TabIndex = 53
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(26, 74)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.RightToLeftLayout = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(196, 25)
        Me.DateTimePicker2.TabIndex = 4
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(26, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeftLayout = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(196, 25)
        Me.DateTimePicker1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(234, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "حتي تاريخ :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(242, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "من تاريخ :"
        '
        'bydate
        '
        Me.bydate.AutoSize = True
        Me.bydate.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.bydate.Location = New System.Drawing.Point(272, 206)
        Me.bydate.Name = "bydate"
        Me.bydate.Size = New System.Drawing.Size(107, 21)
        Me.bydate.TabIndex = 54
        Me.bydate.Text = "الفلترة بالتاريخ"
        Me.bydate.UseVisualStyleBackColor = True
        '
        'ByItem
        '
        Me.ByItem.AutoSize = True
        Me.ByItem.Checked = True
        Me.ByItem.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ByItem.Location = New System.Drawing.Point(240, 15)
        Me.ByItem.Name = "ByItem"
        Me.ByItem.Size = New System.Drawing.Size(139, 21)
        Me.ByItem.TabIndex = 52
        Me.ByItem.TabStop = True
        Me.ByItem.Text = "الفلترة باسم الصنف"
        Me.ByItem.UseVisualStyleBackColor = True
        '
        'FrmReportInventoryLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.Bigbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(528, 560)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmReportInventoryLog"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير حركة المخزن"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Item As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bydate As System.Windows.Forms.RadioButton
    Friend WithEvents ByItem As System.Windows.Forms.RadioButton
    Friend WithEvents Corporation As System.Windows.Forms.ComboBox
    Friend WithEvents bycorporation As System.Windows.Forms.RadioButton
    Friend WithEvents Category As System.Windows.Forms.ComboBox
    Friend WithEvents bycat As System.Windows.Forms.RadioButton
    Friend WithEvents Stock As System.Windows.Forms.ComboBox
    Friend WithEvents bystock As System.Windows.Forms.RadioButton
End Class
