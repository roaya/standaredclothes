<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TotalMoney
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DATE1 = New System.Windows.Forms.DateTimePicker()
        Me.Date2 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.StockID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SaleCredit = New System.Windows.Forms.NumericUpDown()
        Me.SalesCash = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.VendorsCredit = New System.Windows.Forms.NumericUpDown()
        Me.VendorsCash = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CustomersCredit = New System.Windows.Forms.NumericUpDown()
        Me.CustomersCash = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Expenses = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TotalCash = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.PurchaseCredit = New System.Windows.Forms.NumericUpDown()
        Me.PurchaseCash = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.customersPayments = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.VendorsPayments = New System.Windows.Forms.NumericUpDown()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SaleCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.VendorsCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorsCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.CustomersCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Expenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PurchaseCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.customersPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.VendorsPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DATE1)
        Me.GroupBox1.Controls.Add(Me.Date2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.StockID)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(376, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 108)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معامل التقرير"
        '
        'DATE1
        '
        Me.DATE1.CalendarFont = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DATE1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DATE1.Location = New System.Drawing.Point(229, 77)
        Me.DATE1.Name = "DATE1"
        Me.DATE1.RightToLeftLayout = True
        Me.DATE1.Size = New System.Drawing.Size(167, 20)
        Me.DATE1.TabIndex = 12
        '
        'Date2
        '
        Me.Date2.CalendarFont = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date2.Location = New System.Drawing.Point(8, 77)
        Me.Date2.Name = "Date2"
        Me.Date2.RightToLeftLayout = True
        Me.Date2.Size = New System.Drawing.Size(167, 20)
        Me.Date2.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(181, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 18)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "الى :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(402, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 18)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "من :"
        '
        'StockID
        '
        Me.StockID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockID.FormattingEnabled = True
        Me.StockID.Location = New System.Drawing.Point(31, 28)
        Me.StockID.Name = "StockID"
        Me.StockID.Size = New System.Drawing.Size(274, 26)
        Me.StockID.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(311, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 18)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "اسم المخزن :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SaleCredit)
        Me.GroupBox2.Controls.Add(Me.SalesCash)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(753, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(377, 107)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "اجمالى المبيعات"
        '
        'SaleCredit
        '
        Me.SaleCredit.BackColor = System.Drawing.Color.White
        Me.SaleCredit.DecimalPlaces = 2
        Me.SaleCredit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaleCredit.Location = New System.Drawing.Point(57, 69)
        Me.SaleCredit.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.SaleCredit.Name = "SaleCredit"
        Me.SaleCredit.ReadOnly = True
        Me.SaleCredit.Size = New System.Drawing.Size(172, 26)
        Me.SaleCredit.TabIndex = 7
        Me.SaleCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SalesCash
        '
        Me.SalesCash.BackColor = System.Drawing.Color.White
        Me.SalesCash.DecimalPlaces = 2
        Me.SalesCash.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalesCash.Location = New System.Drawing.Point(57, 30)
        Me.SalesCash.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.SalesCash.Name = "SalesCash"
        Me.SalesCash.ReadOnly = True
        Me.SalesCash.Size = New System.Drawing.Size(172, 26)
        Me.SalesCash.TabIndex = 6
        Me.SalesCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(244, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "اجمالى الاجل :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(236, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "اجمالى النقدى :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.VendorsCredit)
        Me.GroupBox3.Controls.Add(Me.VendorsCash)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(354, 123)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(377, 106)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "مرتجع الموردين"
        '
        'VendorsCredit
        '
        Me.VendorsCredit.BackColor = System.Drawing.Color.White
        Me.VendorsCredit.DecimalPlaces = 2
        Me.VendorsCredit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VendorsCredit.Location = New System.Drawing.Point(55, 68)
        Me.VendorsCredit.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.VendorsCredit.Name = "VendorsCredit"
        Me.VendorsCredit.ReadOnly = True
        Me.VendorsCredit.Size = New System.Drawing.Size(172, 26)
        Me.VendorsCredit.TabIndex = 10
        Me.VendorsCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'VendorsCash
        '
        Me.VendorsCash.BackColor = System.Drawing.Color.White
        Me.VendorsCash.DecimalPlaces = 2
        Me.VendorsCash.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VendorsCash.Location = New System.Drawing.Point(55, 29)
        Me.VendorsCash.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.VendorsCash.Name = "VendorsCash"
        Me.VendorsCash.ReadOnly = True
        Me.VendorsCash.Size = New System.Drawing.Size(172, 26)
        Me.VendorsCash.TabIndex = 9
        Me.VendorsCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(242, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 18)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "اجمالى الاجل :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(234, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "اجمالى النقدى :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CustomersCredit)
        Me.GroupBox4.Controls.Add(Me.CustomersCash)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(354, 250)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(377, 106)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "مرتجع العملاء"
        '
        'CustomersCredit
        '
        Me.CustomersCredit.BackColor = System.Drawing.Color.White
        Me.CustomersCredit.DecimalPlaces = 2
        Me.CustomersCredit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomersCredit.Location = New System.Drawing.Point(55, 68)
        Me.CustomersCredit.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.CustomersCredit.Name = "CustomersCredit"
        Me.CustomersCredit.ReadOnly = True
        Me.CustomersCredit.Size = New System.Drawing.Size(172, 26)
        Me.CustomersCredit.TabIndex = 14
        Me.CustomersCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CustomersCash
        '
        Me.CustomersCash.BackColor = System.Drawing.Color.White
        Me.CustomersCash.DecimalPlaces = 2
        Me.CustomersCash.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomersCash.Location = New System.Drawing.Point(55, 28)
        Me.CustomersCash.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.CustomersCash.Name = "CustomersCash"
        Me.CustomersCash.ReadOnly = True
        Me.CustomersCash.Size = New System.Drawing.Size(172, 26)
        Me.CustomersCash.TabIndex = 13
        Me.CustomersCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(242, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 18)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "اجمالى الاجل :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(234, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 18)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "اجمالى النقدى :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Expenses)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(23, 373)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(316, 96)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "اجمالى المصروفات"
        '
        'Expenses
        '
        Me.Expenses.BackColor = System.Drawing.Color.White
        Me.Expenses.DecimalPlaces = 2
        Me.Expenses.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Expenses.Location = New System.Drawing.Point(54, 40)
        Me.Expenses.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.Expenses.Name = "Expenses"
        Me.Expenses.ReadOnly = True
        Me.Expenses.Size = New System.Drawing.Size(172, 26)
        Me.Expenses.TabIndex = 8
        Me.Expenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TotalCash)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(386, 413)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(377, 81)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "اجمالى الخزينه"
        '
        'TotalCash
        '
        Me.TotalCash.BackColor = System.Drawing.Color.Transparent
        Me.TotalCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TotalCash.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalCash.Location = New System.Drawing.Point(54, 38)
        Me.TotalCash.Name = "TotalCash"
        Me.TotalCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TotalCash.Size = New System.Drawing.Size(172, 20)
        Me.TotalCash.TabIndex = 96
        Me.TotalCash.Text = "0"
        Me.TotalCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(232, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 18)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "اجمالى النقدى :"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.PurchaseCredit)
        Me.GroupBox7.Controls.Add(Me.PurchaseCash)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(753, 242)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(377, 107)
        Me.GroupBox7.TabIndex = 8
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "اجمالى المشتريات"
        '
        'PurchaseCredit
        '
        Me.PurchaseCredit.BackColor = System.Drawing.Color.White
        Me.PurchaseCredit.DecimalPlaces = 2
        Me.PurchaseCredit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PurchaseCredit.Location = New System.Drawing.Point(57, 69)
        Me.PurchaseCredit.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.PurchaseCredit.Name = "PurchaseCredit"
        Me.PurchaseCredit.ReadOnly = True
        Me.PurchaseCredit.Size = New System.Drawing.Size(172, 26)
        Me.PurchaseCredit.TabIndex = 7
        Me.PurchaseCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PurchaseCash
        '
        Me.PurchaseCash.BackColor = System.Drawing.Color.White
        Me.PurchaseCash.DecimalPlaces = 2
        Me.PurchaseCash.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PurchaseCash.Location = New System.Drawing.Point(57, 30)
        Me.PurchaseCash.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.PurchaseCash.Name = "PurchaseCash"
        Me.PurchaseCash.ReadOnly = True
        Me.PurchaseCash.Size = New System.Drawing.Size(172, 26)
        Me.PurchaseCash.TabIndex = 6
        Me.PurchaseCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(244, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 18)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "اجمالى الاجل :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(236, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 18)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "اجمالى النقدى :"
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
        Me.Button1.Location = New System.Drawing.Point(136, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 31)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "استعلام"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.customersPayments)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(23, 123)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(316, 106)
        Me.GroupBox8.TabIndex = 9
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "مدفوعات العميل"
        '
        'customersPayments
        '
        Me.customersPayments.BackColor = System.Drawing.Color.White
        Me.customersPayments.DecimalPlaces = 2
        Me.customersPayments.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customersPayments.Location = New System.Drawing.Point(54, 47)
        Me.customersPayments.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.customersPayments.Name = "customersPayments"
        Me.customersPayments.ReadOnly = True
        Me.customersPayments.Size = New System.Drawing.Size(172, 26)
        Me.customersPayments.TabIndex = 8
        Me.customersPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.VendorsPayments)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(23, 250)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(316, 106)
        Me.GroupBox9.TabIndex = 10
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "مدفوعات المورد"
        '
        'VendorsPayments
        '
        Me.VendorsPayments.BackColor = System.Drawing.Color.White
        Me.VendorsPayments.DecimalPlaces = 2
        Me.VendorsPayments.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VendorsPayments.Location = New System.Drawing.Point(54, 47)
        Me.VendorsPayments.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.VendorsPayments.Name = "VendorsPayments"
        Me.VendorsPayments.ReadOnly = True
        Me.VendorsPayments.Size = New System.Drawing.Size(172, 26)
        Me.VendorsPayments.TabIndex = 8
        Me.VendorsPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.TabControl1.Size = New System.Drawing.Size(1156, 573)
        Me.TabControl1.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.GroupBox9)
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1148, 547)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معامل التقرير"
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
        Me.Button2.Location = New System.Drawing.Point(892, 446)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 31)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "طباعه"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CrystalReportViewer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1148, 547)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "طباعه التقرير"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1142, 541)
        Me.CrystalReportViewer1.TabIndex = 1
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TotalMoney
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1156, 573)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "TotalMoney"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.Text = "اجمالى الخزينه"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.SaleCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.VendorsCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorsCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.CustomersCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.Expenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.PurchaseCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.customersPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        CType(Me.VendorsPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents StockID As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DATE1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Date2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents SaleCredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents SalesCash As System.Windows.Forms.NumericUpDown
    Friend WithEvents VendorsCredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents VendorsCash As System.Windows.Forms.NumericUpDown
    Friend WithEvents CustomersCredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents CustomersCash As System.Windows.Forms.NumericUpDown
    Friend WithEvents Expenses As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents PurchaseCredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents PurchaseCash As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TotalCash As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents customersPayments As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents VendorsPayments As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
