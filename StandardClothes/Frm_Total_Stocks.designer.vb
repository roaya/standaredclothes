<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Total_Stocks
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GrdSearch = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.EmployeeID = New System.Windows.Forms.ComboBox()
        Me.RadempID = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Date2 = New System.Windows.Forms.DateTimePicker()
        Me.Date1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VendorID = New System.Windows.Forms.ComboBox()
        Me.CustomerID = New System.Windows.Forms.ComboBox()
        Me.Stock_ID = New System.Windows.Forms.ComboBox()
        Me.RadVendorID = New System.Windows.Forms.RadioButton()
        Me.RadCustomerID = New System.Windows.Forms.RadioButton()
        Me.RadStockID = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadEmp = New System.Windows.Forms.RadioButton()
        Me.vendors = New System.Windows.Forms.RadioButton()
        Me.customers = New System.Windows.Forms.RadioButton()
        Me.stocks = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GrdSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(5, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(767, 631)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox4.Location = New System.Drawing.Point(12, 397)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(737, 228)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "نتائج البحث"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 19)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Size = New System.Drawing.Size(731, 206)
        Me.DataGridView1.TabIndex = 2
        Me.DataGridView1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.GrdSearch)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox3.Location = New System.Drawing.Point(12, 164)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(737, 227)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "نتائج البحث"
        '
        'GrdSearch
        '
        Me.GrdSearch.AllowUserToAddRows = False
        Me.GrdSearch.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GrdSearch.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GrdSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GrdSearch.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GrdSearch.ColumnHeadersHeight = 33
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdSearch.DefaultCellStyle = DataGridViewCellStyle8
        Me.GrdSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdSearch.Location = New System.Drawing.Point(3, 19)
        Me.GrdSearch.MultiSelect = False
        Me.GrdSearch.Name = "GrdSearch"
        Me.GrdSearch.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdSearch.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GrdSearch.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GrdSearch.Size = New System.Drawing.Size(731, 205)
        Me.GrdSearch.TabIndex = 1
        Me.GrdSearch.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.EmployeeID)
        Me.GroupBox2.Controls.Add(Me.RadempID)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.VendorID)
        Me.GroupBox2.Controls.Add(Me.CustomerID)
        Me.GroupBox2.Controls.Add(Me.Stock_ID)
        Me.GroupBox2.Controls.Add(Me.RadVendorID)
        Me.GroupBox2.Controls.Add(Me.RadCustomerID)
        Me.GroupBox2.Controls.Add(Me.RadStockID)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(737, 155)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "معاملات البحث"
        '
        'EmployeeID
        '
        Me.EmployeeID.FormattingEnabled = True
        Me.EmployeeID.Location = New System.Drawing.Point(361, 37)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Size = New System.Drawing.Size(229, 26)
        Me.EmployeeID.TabIndex = 9
        Me.EmployeeID.TabStop = False
        Me.EmployeeID.Visible = False
        '
        'RadempID
        '
        Me.RadempID.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadempID.Location = New System.Drawing.Point(596, 37)
        Me.RadempID.Name = "RadempID"
        Me.RadempID.Size = New System.Drawing.Size(118, 23)
        Me.RadempID.TabIndex = 8
        Me.RadempID.Text = "اسم الموظف"
        Me.RadempID.UseVisualStyleBackColor = True
        Me.RadempID.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(24, 103)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(131, 31)
        Me.Button3.TabIndex = 7
        Me.Button3.TabStop = False
        Me.Button3.Text = "استعلام"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Date2)
        Me.GroupBox5.Controls.Add(Me.Date1)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Location = New System.Drawing.Point(168, 71)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(545, 73)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        '
        'Date2
        '
        Me.Date2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date2.Location = New System.Drawing.Point(43, 30)
        Me.Date2.Name = "Date2"
        Me.Date2.RightToLeftLayout = True
        Me.Date2.Size = New System.Drawing.Size(185, 26)
        Me.Date2.TabIndex = 3
        '
        'Date1
        '
        Me.Date1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date1.Location = New System.Drawing.Point(286, 30)
        Me.Date1.Name = "Date1"
        Me.Date1.RightToLeftLayout = True
        Me.Date1.Size = New System.Drawing.Size(185, 26)
        Me.Date1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(234, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "الى"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(477, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "من"
        '
        'VendorID
        '
        Me.VendorID.FormattingEnabled = True
        Me.VendorID.Location = New System.Drawing.Point(360, 37)
        Me.VendorID.Name = "VendorID"
        Me.VendorID.Size = New System.Drawing.Size(229, 26)
        Me.VendorID.TabIndex = 5
        Me.VendorID.TabStop = False
        Me.VendorID.Visible = False
        '
        'CustomerID
        '
        Me.CustomerID.FormattingEnabled = True
        Me.CustomerID.Location = New System.Drawing.Point(360, 37)
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.Size = New System.Drawing.Size(229, 26)
        Me.CustomerID.TabIndex = 4
        Me.CustomerID.TabStop = False
        Me.CustomerID.Visible = False
        '
        'Stock_ID
        '
        Me.Stock_ID.FormattingEnabled = True
        Me.Stock_ID.Location = New System.Drawing.Point(361, 37)
        Me.Stock_ID.Name = "Stock_ID"
        Me.Stock_ID.Size = New System.Drawing.Size(229, 26)
        Me.Stock_ID.TabIndex = 3
        Me.Stock_ID.TabStop = False
        '
        'RadVendorID
        '
        Me.RadVendorID.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadVendorID.Location = New System.Drawing.Point(596, 37)
        Me.RadVendorID.Name = "RadVendorID"
        Me.RadVendorID.Size = New System.Drawing.Size(118, 23)
        Me.RadVendorID.TabIndex = 2
        Me.RadVendorID.Text = "اسم المورد"
        Me.RadVendorID.UseVisualStyleBackColor = True
        Me.RadVendorID.Visible = False
        '
        'RadCustomerID
        '
        Me.RadCustomerID.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCustomerID.Location = New System.Drawing.Point(595, 37)
        Me.RadCustomerID.Name = "RadCustomerID"
        Me.RadCustomerID.Size = New System.Drawing.Size(118, 23)
        Me.RadCustomerID.TabIndex = 1
        Me.RadCustomerID.Text = "اسم العميل"
        Me.RadCustomerID.UseVisualStyleBackColor = True
        Me.RadCustomerID.Visible = False
        '
        'RadStockID
        '
        Me.RadStockID.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadStockID.Location = New System.Drawing.Point(595, 37)
        Me.RadStockID.Name = "RadStockID"
        Me.RadStockID.Size = New System.Drawing.Size(118, 23)
        Me.RadStockID.TabIndex = 0
        Me.RadStockID.Text = "اسم المخزن"
        Me.RadStockID.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadEmp)
        Me.GroupBox1.Controls.Add(Me.vendors)
        Me.GroupBox1.Controls.Add(Me.customers)
        Me.GroupBox1.Controls.Add(Me.stocks)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(778, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(144, 192)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات البحث"
        '
        'RadEmp
        '
        Me.RadEmp.AutoSize = True
        Me.RadEmp.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadEmp.Location = New System.Drawing.Point(33, 143)
        Me.RadEmp.Name = "RadEmp"
        Me.RadEmp.Size = New System.Drawing.Size(79, 23)
        Me.RadEmp.TabIndex = 9
        Me.RadEmp.Text = "موظفين"
        Me.RadEmp.UseVisualStyleBackColor = True
        '
        'vendors
        '
        Me.vendors.AutoSize = True
        Me.vendors.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vendors.Location = New System.Drawing.Point(41, 109)
        Me.vendors.Name = "vendors"
        Me.vendors.Size = New System.Drawing.Size(71, 23)
        Me.vendors.TabIndex = 8
        Me.vendors.Text = "موردين"
        Me.vendors.UseVisualStyleBackColor = True
        '
        'customers
        '
        Me.customers.AutoSize = True
        Me.customers.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customers.Location = New System.Drawing.Point(49, 74)
        Me.customers.Name = "customers"
        Me.customers.Size = New System.Drawing.Size(63, 23)
        Me.customers.TabIndex = 7
        Me.customers.Text = "عملاء"
        Me.customers.UseVisualStyleBackColor = True
        '
        'stocks
        '
        Me.stocks.AutoSize = True
        Me.stocks.Checked = True
        Me.stocks.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stocks.Location = New System.Drawing.Point(44, 37)
        Me.stocks.Name = "stocks"
        Me.stocks.Size = New System.Drawing.Size(68, 23)
        Me.stocks.TabIndex = 6
        Me.stocks.TabStop = True
        Me.stocks.Text = "مخازن"
        Me.stocks.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(815, 281)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.TabStop = False
        Me.Button1.Text = "طباعه 1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(815, 522)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.TabStop = False
        Me.Button2.Text = "طباعه 2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Frm_Total_Stocks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(936, 654)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Total_Stocks"
        Me.ShowIcon = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GrdSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Date2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Date1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents VendorID As System.Windows.Forms.ComboBox
    Friend WithEvents CustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Stock_ID As System.Windows.Forms.ComboBox
    Friend WithEvents RadVendorID As System.Windows.Forms.RadioButton
    Friend WithEvents RadCustomerID As System.Windows.Forms.RadioButton
    Friend WithEvents RadStockID As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents vendors As System.Windows.Forms.RadioButton
    Friend WithEvents customers As System.Windows.Forms.RadioButton
    Friend WithEvents stocks As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GrdSearch As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents EmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents RadempID As System.Windows.Forms.RadioButton
    Friend WithEvents RadEmp As System.Windows.Forms.RadioButton
End Class
