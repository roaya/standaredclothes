﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPurchaseOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPurchaseOrder))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioDates = New System.Windows.Forms.RadioButton()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.TotalBill = New System.Windows.Forms.NumericUpDown()
        Me.RadioTotalBill = New System.Windows.Forms.RadioButton()
        Me.StockID = New System.Windows.Forms.ComboBox()
        Me.RadioStockID = New System.Windows.Forms.RadioButton()
        Me.VendorID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmployeeID = New System.Windows.Forms.ComboBox()
        Me.Barcode = New System.Windows.Forms.TextBox()
        Me.ItemName = New System.Windows.Forms.ComboBox()
        Me.BillID = New System.Windows.Forms.ComboBox()
        Me.RadioEmployeeID = New System.Windows.Forms.RadioButton()
        Me.RadioBarCode = New System.Windows.Forms.RadioButton()
        Me.RadioItemName = New System.Windows.Forms.RadioButton()
        Me.RadioVendorID = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TotalBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.RadioDates)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.TotalBill)
        Me.GroupBox1.Controls.Add(Me.RadioTotalBill)
        Me.GroupBox1.Controls.Add(Me.StockID)
        Me.GroupBox1.Controls.Add(Me.RadioStockID)
        Me.GroupBox1.Controls.Add(Me.VendorID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.EmployeeID)
        Me.GroupBox1.Controls.Add(Me.Barcode)
        Me.GroupBox1.Controls.Add(Me.ItemName)
        Me.GroupBox1.Controls.Add(Me.BillID)
        Me.GroupBox1.Controls.Add(Me.RadioEmployeeID)
        Me.GroupBox1.Controls.Add(Me.RadioBarCode)
        Me.GroupBox1.Controls.Add(Me.RadioItemName)
        Me.GroupBox1.Controls.Add(Me.RadioVendorID)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 426)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 311)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "الي :"
        '
        'RadioDates
        '
        Me.RadioDates.Location = New System.Drawing.Point(290, 307)
        Me.RadioDates.Name = "RadioDates"
        Me.RadioDates.Size = New System.Drawing.Size(137, 17)
        Me.RadioDates.TabIndex = 53
        Me.RadioDates.Text = "بين تاريخين"
        Me.RadioDates.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(181, 307)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePicker1.TabIndex = 52
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(28, 307)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePicker2.TabIndex = 51
        '
        'TotalBill
        '
        Me.TotalBill.DecimalPlaces = 2
        Me.TotalBill.Location = New System.Drawing.Point(28, 261)
        Me.TotalBill.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.TotalBill.Name = "TotalBill"
        Me.TotalBill.Size = New System.Drawing.Size(261, 20)
        Me.TotalBill.TabIndex = 50
        Me.TotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RadioTotalBill
        '
        Me.RadioTotalBill.Location = New System.Drawing.Point(290, 261)
        Me.RadioTotalBill.Name = "RadioTotalBill"
        Me.RadioTotalBill.Size = New System.Drawing.Size(137, 17)
        Me.RadioTotalBill.TabIndex = 49
        Me.RadioTotalBill.Text = "اجمالي الفاتورة أكبر من"
        Me.RadioTotalBill.UseVisualStyleBackColor = True
        '
        'StockID
        '
        Me.StockID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StockID.Enabled = False
        Me.StockID.FormattingEnabled = True
        Me.StockID.Location = New System.Drawing.Point(28, 216)
        Me.StockID.Name = "StockID"
        Me.StockID.Size = New System.Drawing.Size(261, 21)
        Me.StockID.TabIndex = 48
        '
        'RadioStockID
        '
        Me.RadioStockID.Location = New System.Drawing.Point(290, 217)
        Me.RadioStockID.Name = "RadioStockID"
        Me.RadioStockID.Size = New System.Drawing.Size(137, 17)
        Me.RadioStockID.TabIndex = 47
        Me.RadioStockID.Text = "اسم المحل"
        Me.RadioStockID.UseVisualStyleBackColor = True
        '
        'VendorID
        '
        Me.VendorID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VendorID.Enabled = False
        Me.VendorID.FormattingEnabled = True
        Me.VendorID.Location = New System.Drawing.Point(28, 37)
        Me.VendorID.Name = "VendorID"
        Me.VendorID.Size = New System.Drawing.Size(261, 21)
        Me.VendorID.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(357, 377)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "رقم المستند :"
        '
        'EmployeeID
        '
        Me.EmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmployeeID.Enabled = False
        Me.EmployeeID.FormattingEnabled = True
        Me.EmployeeID.Location = New System.Drawing.Point(28, 171)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Size = New System.Drawing.Size(261, 21)
        Me.EmployeeID.TabIndex = 44
        '
        'Barcode
        '
        Me.Barcode.Enabled = False
        Me.Barcode.Location = New System.Drawing.Point(28, 127)
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Size = New System.Drawing.Size(261, 20)
        Me.Barcode.TabIndex = 43
        '
        'ItemName
        '
        Me.ItemName.Enabled = False
        Me.ItemName.FormattingEnabled = True
        Me.ItemName.Location = New System.Drawing.Point(28, 82)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(261, 21)
        Me.ItemName.TabIndex = 42
        '
        'BillID
        '
        Me.BillID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BillID.FormattingEnabled = True
        Me.BillID.Location = New System.Drawing.Point(127, 374)
        Me.BillID.Name = "BillID"
        Me.BillID.Size = New System.Drawing.Size(162, 21)
        Me.BillID.TabIndex = 41
        '
        'RadioEmployeeID
        '
        Me.RadioEmployeeID.Location = New System.Drawing.Point(290, 172)
        Me.RadioEmployeeID.Name = "RadioEmployeeID"
        Me.RadioEmployeeID.Size = New System.Drawing.Size(137, 17)
        Me.RadioEmployeeID.TabIndex = 40
        Me.RadioEmployeeID.Text = "اسم الموظف"
        Me.RadioEmployeeID.UseVisualStyleBackColor = True
        '
        'RadioBarCode
        '
        Me.RadioBarCode.Location = New System.Drawing.Point(290, 128)
        Me.RadioBarCode.Name = "RadioBarCode"
        Me.RadioBarCode.Size = New System.Drawing.Size(137, 17)
        Me.RadioBarCode.TabIndex = 39
        Me.RadioBarCode.Text = "استعلام بالباركود"
        Me.RadioBarCode.UseVisualStyleBackColor = True
        '
        'RadioItemName
        '
        Me.RadioItemName.Location = New System.Drawing.Point(290, 83)
        Me.RadioItemName.Name = "RadioItemName"
        Me.RadioItemName.Size = New System.Drawing.Size(137, 17)
        Me.RadioItemName.TabIndex = 38
        Me.RadioItemName.Text = "استعلام باسم الصنف"
        Me.RadioItemName.UseVisualStyleBackColor = True
        '
        'RadioVendorID
        '
        Me.RadioVendorID.Checked = True
        Me.RadioVendorID.Location = New System.Drawing.Point(290, 38)
        Me.RadioVendorID.Name = "RadioVendorID"
        Me.RadioVendorID.Size = New System.Drawing.Size(137, 17)
        Me.RadioVendorID.TabIndex = 37
        Me.RadioVendorID.TabStop = True
        Me.RadioVendorID.Text = "اسم المورد"
        Me.RadioVendorID.UseVisualStyleBackColor = True
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
        Me.Button1.Location = New System.Drawing.Point(308, 453)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 45)
        Me.Button1.TabIndex = 51
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
        Me.Button2.Location = New System.Drawing.Point(31, 453)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 45)
        Me.Button2.TabIndex = 50
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ReportPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(483, 511)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportPurchaseOrder"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقارير فواتير المشتريات"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TotalBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents VendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents Barcode As System.Windows.Forms.TextBox
    Friend WithEvents ItemName As System.Windows.Forms.ComboBox
    Friend WithEvents BillID As System.Windows.Forms.ComboBox
    Friend WithEvents RadioEmployeeID As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBarCode As System.Windows.Forms.RadioButton
    Friend WithEvents RadioItemName As System.Windows.Forms.RadioButton
    Friend WithEvents RadioVendorID As System.Windows.Forms.RadioButton
    Friend WithEvents TotalBill As System.Windows.Forms.NumericUpDown
    Friend WithEvents RadioTotalBill As System.Windows.Forms.RadioButton
    Friend WithEvents StockID As System.Windows.Forms.ComboBox
    Friend WithEvents RadioStockID As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioDates As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
