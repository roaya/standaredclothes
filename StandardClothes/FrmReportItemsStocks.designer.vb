<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmreportitemsstocks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmreportitemsstocks))
        Me.Category = New System.Windows.Forms.ComboBox()
        Me.bystock = New System.Windows.Forms.RadioButton()
        Me.Item = New System.Windows.Forms.ComboBox()
        Me.bycat = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Stock = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Corporation = New System.Windows.Forms.ComboBox()
        Me.bycorporation = New System.Windows.Forms.RadioButton()
        Me.ByItem = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Button1.Location = New System.Drawing.Point(271, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 39)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "استعلام"
        Me.Button1.UseVisualStyleBackColor = False
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 261)
        Me.GroupBox1.TabIndex = 7
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
        Me.Panel2.Controls.Add(Me.ByItem)
        Me.Panel2.Location = New System.Drawing.Point(20, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(400, 211)
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
        Me.Button2.Location = New System.Drawing.Point(45, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 39)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmreportitemsstocks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(473, 327)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Name = "frmreportitemsstocks"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "تقرير أرصدة الأصناف بالمخزن"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Category As System.Windows.Forms.ComboBox
    Friend WithEvents bystock As System.Windows.Forms.RadioButton
    Friend WithEvents Item As System.Windows.Forms.ComboBox
    Friend WithEvents bycat As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Stock As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ByItem As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Corporation As System.Windows.Forms.ComboBox
    Friend WithEvents bycorporation As System.Windows.Forms.RadioButton
End Class
