﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportAdjustments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportAdjustments))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToStockID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FromStockID = New System.Windows.Forms.ComboBox()
        Me.Barcode = New System.Windows.Forms.TextBox()
        Me.ItemName = New System.Windows.Forms.ComboBox()
        Me.BillID = New System.Windows.Forms.ComboBox()
        Me.RadioStockName = New System.Windows.Forms.RadioButton()
        Me.RadioBarCode = New System.Windows.Forms.RadioButton()
        Me.RadioItemName = New System.Windows.Forms.RadioButton()
        Me.RadioToStockID = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ToStockID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.FromStockID)
        Me.GroupBox1.Controls.Add(Me.Barcode)
        Me.GroupBox1.Controls.Add(Me.ItemName)
        Me.GroupBox1.Controls.Add(Me.BillID)
        Me.GroupBox1.Controls.Add(Me.RadioStockName)
        Me.GroupBox1.Controls.Add(Me.RadioBarCode)
        Me.GroupBox1.Controls.Add(Me.RadioItemName)
        Me.GroupBox1.Controls.Add(Me.RadioToStockID)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 286)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'ToStockID
        '
        Me.ToStockID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToStockID.Enabled = False
        Me.ToStockID.FormattingEnabled = True
        Me.ToStockID.Location = New System.Drawing.Point(28, 37)
        Me.ToStockID.Name = "ToStockID"
        Me.ToStockID.Size = New System.Drawing.Size(261, 21)
        Me.ToStockID.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(290, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "رقم المستند :"
        '
        'FromStockID
        '
        Me.FromStockID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FromStockID.Enabled = False
        Me.FromStockID.FormattingEnabled = True
        Me.FromStockID.Location = New System.Drawing.Point(28, 166)
        Me.FromStockID.Name = "FromStockID"
        Me.FromStockID.Size = New System.Drawing.Size(261, 21)
        Me.FromStockID.TabIndex = 44
        '
        'Barcode
        '
        Me.Barcode.Enabled = False
        Me.Barcode.Location = New System.Drawing.Point(28, 123)
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Size = New System.Drawing.Size(261, 20)
        Me.Barcode.TabIndex = 43
        '
        'ItemName
        '
        Me.ItemName.Enabled = False
        Me.ItemName.FormattingEnabled = True
        Me.ItemName.Location = New System.Drawing.Point(28, 80)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(261, 21)
        Me.ItemName.TabIndex = 42
        '
        'BillID
        '
        Me.BillID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BillID.FormattingEnabled = True
        Me.BillID.Location = New System.Drawing.Point(168, 242)
        Me.BillID.Name = "BillID"
        Me.BillID.Size = New System.Drawing.Size(121, 21)
        Me.BillID.TabIndex = 41
        '
        'RadioStockName
        '
        Me.RadioStockName.Location = New System.Drawing.Point(290, 167)
        Me.RadioStockName.Name = "RadioStockName"
        Me.RadioStockName.Size = New System.Drawing.Size(137, 17)
        Me.RadioStockName.TabIndex = 40
        Me.RadioStockName.Text = "المحل المحول منه"
        Me.RadioStockName.UseVisualStyleBackColor = True
        '
        'RadioBarCode
        '
        Me.RadioBarCode.Location = New System.Drawing.Point(290, 124)
        Me.RadioBarCode.Name = "RadioBarCode"
        Me.RadioBarCode.Size = New System.Drawing.Size(137, 17)
        Me.RadioBarCode.TabIndex = 39
        Me.RadioBarCode.Text = "استعلام بالباركود"
        Me.RadioBarCode.UseVisualStyleBackColor = True
        '
        'RadioItemName
        '
        Me.RadioItemName.Location = New System.Drawing.Point(290, 81)
        Me.RadioItemName.Name = "RadioItemName"
        Me.RadioItemName.Size = New System.Drawing.Size(137, 17)
        Me.RadioItemName.TabIndex = 38
        Me.RadioItemName.Text = "استعلام باسم الصنف"
        Me.RadioItemName.UseVisualStyleBackColor = True
        '
        'RadioToStockID
        '
        Me.RadioToStockID.Checked = True
        Me.RadioToStockID.Location = New System.Drawing.Point(290, 38)
        Me.RadioToStockID.Name = "RadioToStockID"
        Me.RadioToStockID.Size = New System.Drawing.Size(137, 17)
        Me.RadioToStockID.TabIndex = 37
        Me.RadioToStockID.TabStop = True
        Me.RadioToStockID.Text = "المحل المحول اليه"
        Me.RadioToStockID.UseVisualStyleBackColor = True
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
        Me.Button1.Location = New System.Drawing.Point(325, 317)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 45)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.Button2.Location = New System.Drawing.Point(48, 317)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 45)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ReportAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(489, 381)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportAdjustments"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقارير تحويرت المخازن"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FromStockID As System.Windows.Forms.ComboBox
    Friend WithEvents Barcode As System.Windows.Forms.TextBox
    Friend WithEvents ItemName As System.Windows.Forms.ComboBox
    Friend WithEvents BillID As System.Windows.Forms.ComboBox
    Friend WithEvents RadioStockName As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBarCode As System.Windows.Forms.RadioButton
    Friend WithEvents RadioItemName As System.Windows.Forms.RadioButton
    Friend WithEvents RadioToStockID As System.Windows.Forms.RadioButton
    Friend WithEvents ToStockID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
