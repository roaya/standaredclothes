<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class simpleSalesOrderNormal
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(simpleSalesOrderNormal))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSavePrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnSavePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupDetails = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupItems = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GeneralLabel13 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel14 = New StandardClothes.GeneralLabel()
        Me.Quantity = New System.Windows.Forms.NumericUpDown()
        Me.Price = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ItemName = New System.Windows.Forms.ComboBox()
        Me.BarCode = New System.Windows.Forms.TextBox()
        Me.RadioBarcode = New System.Windows.Forms.RadioButton()
        Me.RadioItemName = New System.Windows.Forms.RadioButton()
        Me.GroupHeader = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GeneralLabel24 = New StandardClothes.GeneralLabel()
        Me.EmployeeID = New System.Windows.Forms.ComboBox()
        Me.DiscountTypeItem = New System.Windows.Forms.ComboBox()
        Me.GeneralLabel19 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel15 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel16 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel21 = New StandardClothes.GeneralLabel()
        Me.DiscountValueItem = New System.Windows.Forms.NumericUpDown()
        Me.StockID = New System.Windows.Forms.Label()
        Me.GeneralLabel7 = New StandardClothes.GeneralLabel()
        Me.PayType = New System.Windows.Forms.ComboBox()
        Me.GeneralLabel4 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel8 = New StandardClothes.GeneralLabel()
        Me.PeriodID = New System.Windows.Forms.Label()
        Me.OrderType = New System.Windows.Forms.ComboBox()
        Me.BtnNewCustomer = New System.Windows.Forms.Button()
        Me.CustomerID = New System.Windows.Forms.ComboBox()
        Me.DiscountValue = New System.Windows.Forms.NumericUpDown()
        Me.Comments = New StandardClothes.GeneralTextBox()
        Me.RemainingValue = New System.Windows.Forms.Label()
        Me.BtnSchedule = New System.Windows.Forms.Button()
        Me.GeneralLabel22 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel23 = New StandardClothes.GeneralLabel()
        Me.PayedValue = New System.Windows.Forms.NumericUpDown()
        Me.BillID = New System.Windows.Forms.Label()
        Me.TotalBill = New System.Windows.Forms.Label()
        Me.GeneralLabel5 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel9 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel20 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel17 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel10 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel6 = New StandardClothes.GeneralLabel()
        Me.CardID = New System.Windows.Forms.ComboBox()
        Me.CashValue = New System.Windows.Forms.NumericUpDown()
        Me.GeneralLabel18 = New StandardClothes.GeneralLabel()
        Me.DiscountType = New System.Windows.Forms.ComboBox()
        Me.GeneralLabel12 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel3 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel11 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel2 = New StandardClothes.GeneralLabel()
        Me.CardValue = New System.Windows.Forms.Label()
        Me.GeneralLabel1 = New StandardClothes.GeneralLabel()
        Me.BillDate = New System.Windows.Forms.DateTimePicker()
        Me.BillTime = New System.Windows.Forms.Label()
        Me.CreditValue = New System.Windows.Forms.NumericUpDown()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupDetails.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupItems.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Quantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Price, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupHeader.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DiscountValueItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiscountValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PayedValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CashValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContentPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNew, Me.ToolStripSeparator2, Me.BtnSave, Me.ToolStripSeparator1, Me.BtnSavePrint, Me.ToolStripSeparator3, Me.BtnDelete, Me.ToolStripSeparator5, Me.BtnExit, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(679, 38)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnNew
        '
        Me.BtnNew.AutoSize = False
        Me.BtnNew.BackgroundImage = Global.StandardClothes.My.Resources.Resources.without_texte_2_16
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(130, 35)
        Me.BtnNew.Text = "جديد  F2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'BtnSave
        '
        Me.BtnSave.AutoSize = False
        Me.BtnSave.BackgroundImage = Global.StandardClothes.My.Resources.Resources.save_2_18
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.Enabled = False
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(120, 35)
        Me.BtnSave.Text = "حفظ  F3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'BtnSavePrint
        '
        Me.BtnSavePrint.AutoSize = False
        Me.BtnSavePrint.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.BtnSavePrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSavePrint.Image = Global.StandardClothes.My.Resources.Resources.HP_Printer
        Me.BtnSavePrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSavePrint.Name = "BtnSavePrint"
        Me.BtnSavePrint.Size = New System.Drawing.Size(130, 35)
        Me.BtnSavePrint.Text = "حفظ و طباعة  F4"
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
        Me.BtnDelete.Size = New System.Drawing.Size(130, 35)
        Me.BtnDelete.Text = "حذف  F5"
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
        Me.BtnExit.Size = New System.Drawing.Size(130, 35)
        Me.BtnExit.Text = "خروج"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.BackgroundImage = Global.StandardClothes.My.Resources.Resources.save_2_18
        Me.ToolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(150, 35)
        Me.ToolStripButton1.Text = "الإجمالي F7"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1023, 24)
        Me.MenuStrip1.TabIndex = 24
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuBtnNew, Me.MenuBtnSave, Me.MenuBtnSavePrint, Me.MenuBtnExit, Me.MenuTotal})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(128, 20)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'MenuBtnNew
        '
        Me.MenuBtnNew.Name = "MenuBtnNew"
        Me.MenuBtnNew.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.MenuBtnNew.Size = New System.Drawing.Size(202, 22)
        Me.MenuBtnNew.Text = "Test"
        '
        'MenuBtnSave
        '
        Me.MenuBtnSave.Name = "MenuBtnSave"
        Me.MenuBtnSave.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.MenuBtnSave.Size = New System.Drawing.Size(202, 22)
        Me.MenuBtnSave.Text = "TestSave"
        '
        'MenuBtnSavePrint
        '
        Me.MenuBtnSavePrint.Name = "MenuBtnSavePrint"
        Me.MenuBtnSavePrint.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.MenuBtnSavePrint.Size = New System.Drawing.Size(202, 22)
        Me.MenuBtnSavePrint.Text = "TestSavePrint"
        '
        'MenuBtnExit
        '
        Me.MenuBtnExit.Name = "MenuBtnExit"
        Me.MenuBtnExit.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MenuBtnExit.Size = New System.Drawing.Size(202, 22)
        Me.MenuBtnExit.Text = "TestDelete"
        '
        'MenuTotal
        '
        Me.MenuTotal.Name = "MenuTotal"
        Me.MenuTotal.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.MenuTotal.Size = New System.Drawing.Size(202, 22)
        Me.MenuTotal.Text = "ToolStripMenuItem2"
        '
        'GroupDetails
        '
        Me.GroupDetails.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GroupDetails.Controls.Add(Me.Panel3)
        Me.GroupDetails.Enabled = False
        Me.GroupDetails.Location = New System.Drawing.Point(14, 309)
        Me.GroupDetails.Name = "GroupDetails"
        Me.GroupDetails.Size = New System.Drawing.Size(658, 184)
        Me.GroupDetails.TabIndex = 77
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(654, 180)
        Me.Panel3.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(652, 178)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupItems
        '
        Me.GroupItems.BackColor = System.Drawing.Color.Transparent
        Me.GroupItems.Controls.Add(Me.GroupBox3)
        Me.GroupItems.Controls.Add(Me.GroupBox2)
        Me.GroupItems.Enabled = False
        Me.GroupItems.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupItems.Location = New System.Drawing.Point(12, 157)
        Me.GroupItems.Name = "GroupItems"
        Me.GroupItems.Size = New System.Drawing.Size(659, 142)
        Me.GroupItems.TabIndex = 78
        Me.GroupItems.TabStop = False
        Me.GroupItems.Text = "البيانات العامة للأصناف"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GeneralLabel13)
        Me.GroupBox3.Controls.Add(Me.GeneralLabel14)
        Me.GroupBox3.Controls.Add(Me.Quantity)
        Me.GroupBox3.Controls.Add(Me.Price)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(266, 110)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "بيانات الأصناف المشتراة"
        '
        'GeneralLabel13
        '
        Me.GeneralLabel13.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel13.BackgroundImage = CType(resources.GetObject("GeneralLabel13.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel13.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel13.IsRequired = False
        Me.GeneralLabel13.Location = New System.Drawing.Point(141, 65)
        Me.GeneralLabel13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel13.Name = "GeneralLabel13"
        Me.GeneralLabel13.SetLabelTxt = "العدد :"
        Me.GeneralLabel13.Size = New System.Drawing.Size(113, 26)
        Me.GeneralLabel13.TabIndex = 71
        '
        'GeneralLabel14
        '
        Me.GeneralLabel14.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel14.BackgroundImage = CType(resources.GetObject("GeneralLabel14.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel14.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel14.IsRequired = False
        Me.GeneralLabel14.Location = New System.Drawing.Point(143, 34)
        Me.GeneralLabel14.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel14.Name = "GeneralLabel14"
        Me.GeneralLabel14.SetLabelTxt = "سعر الصنف :"
        Me.GeneralLabel14.Size = New System.Drawing.Size(112, 26)
        Me.GeneralLabel14.TabIndex = 70
        '
        'Quantity
        '
        Me.Quantity.DecimalPlaces = 5
        Me.Quantity.Location = New System.Drawing.Point(7, 65)
        Me.Quantity.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Size = New System.Drawing.Size(129, 26)
        Me.Quantity.TabIndex = 60
        Me.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Price
        '
        Me.Price.DecimalPlaces = 2
        Me.Price.Location = New System.Drawing.Point(7, 34)
        Me.Price.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.Price.Name = "Price"
        Me.Price.Size = New System.Drawing.Size(131, 26)
        Me.Price.TabIndex = 59
        Me.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ItemName)
        Me.GroupBox2.Controls.Add(Me.BarCode)
        Me.GroupBox2.Controls.Add(Me.RadioBarcode)
        Me.GroupBox2.Controls.Add(Me.RadioItemName)
        Me.GroupBox2.Location = New System.Drawing.Point(280, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(371, 110)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "الأصناف المختارة"
        '
        'ItemName
        '
        Me.ItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ItemName.DisplayMember = "item_name"
        Me.ItemName.Enabled = False
        Me.ItemName.FormattingEnabled = True
        Me.ItemName.Location = New System.Drawing.Point(18, 35)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(222, 26)
        Me.ItemName.TabIndex = 4
        Me.ItemName.ValueMember = "item_name"
        '
        'BarCode
        '
        Me.BarCode.Location = New System.Drawing.Point(18, 68)
        Me.BarCode.Name = "BarCode"
        Me.BarCode.Size = New System.Drawing.Size(222, 26)
        Me.BarCode.TabIndex = 3
        '
        'RadioBarcode
        '
        Me.RadioBarcode.AutoSize = True
        Me.RadioBarcode.Checked = True
        Me.RadioBarcode.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.RadioBarcode.Location = New System.Drawing.Point(255, 70)
        Me.RadioBarcode.Name = "RadioBarcode"
        Me.RadioBarcode.Size = New System.Drawing.Size(106, 22)
        Me.RadioBarcode.TabIndex = 1
        Me.RadioBarcode.TabStop = True
        Me.RadioBarcode.Text = "بحث بالباركود"
        Me.RadioBarcode.UseVisualStyleBackColor = True
        '
        'RadioItemName
        '
        Me.RadioItemName.AutoSize = True
        Me.RadioItemName.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.RadioItemName.Location = New System.Drawing.Point(260, 34)
        Me.RadioItemName.Name = "RadioItemName"
        Me.RadioItemName.Size = New System.Drawing.Size(101, 22)
        Me.RadioItemName.TabIndex = 0
        Me.RadioItemName.Text = "بحث بالاسم"
        Me.RadioItemName.UseVisualStyleBackColor = True
        '
        'GroupHeader
        '
        Me.GroupHeader.BackColor = System.Drawing.Color.Transparent
        Me.GroupHeader.Controls.Add(Me.GroupBox4)
        Me.GroupHeader.Controls.Add(Me.RemainingValue)
        Me.GroupHeader.Controls.Add(Me.BtnSchedule)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel22)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel23)
        Me.GroupHeader.Controls.Add(Me.PayedValue)
        Me.GroupHeader.Controls.Add(Me.BillID)
        Me.GroupHeader.Controls.Add(Me.TotalBill)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel5)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel9)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel20)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel17)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel10)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel6)
        Me.GroupHeader.Controls.Add(Me.CardID)
        Me.GroupHeader.Controls.Add(Me.CashValue)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel18)
        Me.GroupHeader.Controls.Add(Me.DiscountType)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel12)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel3)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel11)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel2)
        Me.GroupHeader.Controls.Add(Me.CardValue)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel1)
        Me.GroupHeader.Controls.Add(Me.BillDate)
        Me.GroupHeader.Controls.Add(Me.BillTime)
        Me.GroupHeader.Controls.Add(Me.CreditValue)
        Me.GroupHeader.Enabled = False
        Me.GroupHeader.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupHeader.Location = New System.Drawing.Point(12, 15)
        Me.GroupHeader.Name = "GroupHeader"
        Me.GroupHeader.Size = New System.Drawing.Size(659, 137)
        Me.GroupHeader.TabIndex = 79
        Me.GroupHeader.TabStop = False
        Me.GroupHeader.Text = "البيانات الأساسية"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GeneralLabel24)
        Me.GroupBox4.Controls.Add(Me.EmployeeID)
        Me.GroupBox4.Controls.Add(Me.DiscountTypeItem)
        Me.GroupBox4.Controls.Add(Me.GeneralLabel19)
        Me.GroupBox4.Controls.Add(Me.GeneralLabel15)
        Me.GroupBox4.Controls.Add(Me.GeneralLabel16)
        Me.GroupBox4.Controls.Add(Me.GeneralLabel21)
        Me.GroupBox4.Controls.Add(Me.DiscountValueItem)
        Me.GroupBox4.Controls.Add(Me.StockID)
        Me.GroupBox4.Controls.Add(Me.GeneralLabel7)
        Me.GroupBox4.Controls.Add(Me.PayType)
        Me.GroupBox4.Controls.Add(Me.GeneralLabel4)
        Me.GroupBox4.Controls.Add(Me.GeneralLabel8)
        Me.GroupBox4.Controls.Add(Me.PeriodID)
        Me.GroupBox4.Controls.Add(Me.OrderType)
        Me.GroupBox4.Controls.Add(Me.BtnNewCustomer)
        Me.GroupBox4.Controls.Add(Me.CustomerID)
        Me.GroupBox4.Controls.Add(Me.DiscountValue)
        Me.GroupBox4.Controls.Add(Me.Comments)
        Me.GroupBox4.Location = New System.Drawing.Point(34, 39)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(10, 67)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "بيانات الخصم"
        Me.GroupBox4.Visible = False
        '
        'GeneralLabel24
        '
        Me.GeneralLabel24.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel24.BackgroundImage = CType(resources.GetObject("GeneralLabel24.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel24.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel24.IsRequired = False
        Me.GeneralLabel24.Location = New System.Drawing.Point(85, 43)
        Me.GeneralLabel24.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel24.Name = "GeneralLabel24"
        Me.GeneralLabel24.SetLabelTxt = "تاريخ دفع الآجل :"
        Me.GeneralLabel24.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel24.TabIndex = 120
        Me.GeneralLabel24.Visible = False
        '
        'EmployeeID
        '
        Me.EmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmployeeID.FormattingEnabled = True
        Me.EmployeeID.Location = New System.Drawing.Point(16, 66)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Size = New System.Drawing.Size(10, 26)
        Me.EmployeeID.TabIndex = 24
        Me.EmployeeID.Visible = False
        '
        'DiscountTypeItem
        '
        Me.DiscountTypeItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DiscountTypeItem.FormattingEnabled = True
        Me.DiscountTypeItem.Items.AddRange(New Object() {"نسبة مئوية", "مبلغ ثابت", "لا يوجد"})
        Me.DiscountTypeItem.Location = New System.Drawing.Point(24, 66)
        Me.DiscountTypeItem.Name = "DiscountTypeItem"
        Me.DiscountTypeItem.Size = New System.Drawing.Size(144, 26)
        Me.DiscountTypeItem.TabIndex = 74
        '
        'GeneralLabel19
        '
        Me.GeneralLabel19.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel19.BackgroundImage = CType(resources.GetObject("GeneralLabel19.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel19.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel19.IsRequired = False
        Me.GeneralLabel19.Location = New System.Drawing.Point(17, 59)
        Me.GeneralLabel19.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel19.Name = "GeneralLabel19"
        Me.GeneralLabel19.SetLabelTxt = "نوع الفاتورة :"
        Me.GeneralLabel19.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel19.TabIndex = 107
        Me.GeneralLabel19.Visible = False
        '
        'GeneralLabel15
        '
        Me.GeneralLabel15.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel15.BackgroundImage = CType(resources.GetObject("GeneralLabel15.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel15.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel15.IsRequired = False
        Me.GeneralLabel15.Location = New System.Drawing.Point(174, 66)
        Me.GeneralLabel15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel15.Name = "GeneralLabel15"
        Me.GeneralLabel15.SetLabelTxt = "نوع الخصم :"
        Me.GeneralLabel15.Size = New System.Drawing.Size(127, 26)
        Me.GeneralLabel15.TabIndex = 73
        '
        'GeneralLabel16
        '
        Me.GeneralLabel16.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel16.BackgroundImage = CType(resources.GetObject("GeneralLabel16.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel16.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel16.IsRequired = False
        Me.GeneralLabel16.Location = New System.Drawing.Point(174, 35)
        Me.GeneralLabel16.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel16.Name = "GeneralLabel16"
        Me.GeneralLabel16.SetLabelTxt = "قيمة الخصم :"
        Me.GeneralLabel16.Size = New System.Drawing.Size(127, 26)
        Me.GeneralLabel16.TabIndex = 72
        '
        'GeneralLabel21
        '
        Me.GeneralLabel21.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel21.BackgroundImage = CType(resources.GetObject("GeneralLabel21.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel21.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel21.IsRequired = False
        Me.GeneralLabel21.Location = New System.Drawing.Point(103, 39)
        Me.GeneralLabel21.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel21.Name = "GeneralLabel21"
        Me.GeneralLabel21.SetLabelTxt = "قيمة الكوبون :"
        Me.GeneralLabel21.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel21.TabIndex = 112
        Me.GeneralLabel21.Visible = False
        '
        'DiscountValueItem
        '
        Me.DiscountValueItem.DecimalPlaces = 2
        Me.DiscountValueItem.Location = New System.Drawing.Point(24, 35)
        Me.DiscountValueItem.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.DiscountValueItem.Name = "DiscountValueItem"
        Me.DiscountValueItem.Size = New System.Drawing.Size(144, 26)
        Me.DiscountValueItem.TabIndex = 71
        Me.DiscountValueItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StockID
        '
        Me.StockID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StockID.ForeColor = System.Drawing.Color.Black
        Me.StockID.Location = New System.Drawing.Point(12, 68)
        Me.StockID.Name = "StockID"
        Me.StockID.Size = New System.Drawing.Size(10, 25)
        Me.StockID.TabIndex = 108
        Me.StockID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StockID.Visible = False
        '
        'GeneralLabel7
        '
        Me.GeneralLabel7.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel7.BackgroundImage = CType(resources.GetObject("GeneralLabel7.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel7.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel7.IsRequired = False
        Me.GeneralLabel7.Location = New System.Drawing.Point(23, 27)
        Me.GeneralLabel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel7.Name = "GeneralLabel7"
        Me.GeneralLabel7.SetLabelTxt = "ملاحظات :"
        Me.GeneralLabel7.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel7.TabIndex = 96
        Me.GeneralLabel7.Visible = False
        '
        'PayType
        '
        Me.PayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PayType.FormattingEnabled = True
        Me.PayType.Items.AddRange(New Object() {"نقدي", "اجل", "بشيك", "نقدي و اجل", "شيك و اجل"})
        Me.PayType.Location = New System.Drawing.Point(8, 19)
        Me.PayType.Name = "PayType"
        Me.PayType.Size = New System.Drawing.Size(10, 26)
        Me.PayType.TabIndex = 83
        Me.PayType.Visible = False
        '
        'GeneralLabel4
        '
        Me.GeneralLabel4.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel4.BackgroundImage = CType(resources.GetObject("GeneralLabel4.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel4.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel4.IsRequired = False
        Me.GeneralLabel4.Location = New System.Drawing.Point(14, 47)
        Me.GeneralLabel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel4.Name = "GeneralLabel4"
        Me.GeneralLabel4.SetLabelTxt = "اسم العميل :"
        Me.GeneralLabel4.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel4.TabIndex = 91
        '
        'GeneralLabel8
        '
        Me.GeneralLabel8.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel8.BackgroundImage = CType(resources.GetObject("GeneralLabel8.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel8.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel8.IsRequired = False
        Me.GeneralLabel8.Location = New System.Drawing.Point(8, 55)
        Me.GeneralLabel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel8.Name = "GeneralLabel8"
        Me.GeneralLabel8.SetLabelTxt = "اسم الموظف :"
        Me.GeneralLabel8.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel8.TabIndex = 95
        Me.GeneralLabel8.Visible = False
        '
        'PeriodID
        '
        Me.PeriodID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PeriodID.ForeColor = System.Drawing.Color.Black
        Me.PeriodID.Location = New System.Drawing.Point(6, 47)
        Me.PeriodID.Name = "PeriodID"
        Me.PeriodID.Size = New System.Drawing.Size(10, 25)
        Me.PeriodID.TabIndex = 105
        Me.PeriodID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PeriodID.Visible = False
        '
        'OrderType
        '
        Me.OrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OrderType.FormattingEnabled = True
        Me.OrderType.Items.AddRange(New Object() {"جملة", "قطاعي"})
        Me.OrderType.Location = New System.Drawing.Point(8, 55)
        Me.OrderType.Name = "OrderType"
        Me.OrderType.Size = New System.Drawing.Size(10, 26)
        Me.OrderType.TabIndex = 106
        Me.OrderType.Visible = False
        '
        'BtnNewCustomer
        '
        Me.BtnNewCustomer.BackgroundImage = Global.StandardClothes.My.Resources.Resources.group_add_256
        Me.BtnNewCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNewCustomer.Location = New System.Drawing.Point(6, 47)
        Me.BtnNewCustomer.Name = "BtnNewCustomer"
        Me.BtnNewCustomer.Size = New System.Drawing.Size(10, 26)
        Me.BtnNewCustomer.TabIndex = 21
        Me.BtnNewCustomer.UseVisualStyleBackColor = True
        '
        'CustomerID
        '
        Me.CustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CustomerID.FormattingEnabled = True
        Me.CustomerID.Location = New System.Drawing.Point(14, 59)
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.Size = New System.Drawing.Size(12, 26)
        Me.CustomerID.TabIndex = 81
        '
        'DiscountValue
        '
        Me.DiscountValue.DecimalPlaces = 2
        Me.DiscountValue.Location = New System.Drawing.Point(4, 35)
        Me.DiscountValue.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.DiscountValue.Name = "DiscountValue"
        Me.DiscountValue.Size = New System.Drawing.Size(13, 26)
        Me.DiscountValue.TabIndex = 82
        Me.DiscountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Comments
        '
        Me.Comments.IsEmail = False
        Me.Comments.IsNum = False
        Me.Comments.IsRequired = False
        Me.Comments.Location = New System.Drawing.Point(12, 24)
        Me.Comments.Margin = New System.Windows.Forms.Padding(2)
        Me.Comments.Name = "Comments"
        Me.Comments.SetLeaveColor = System.Drawing.Color.Red
        Me.Comments.Size = New System.Drawing.Size(10, 18)
        Me.Comments.TabIndex = 87
        Me.Comments.Visible = False
        '
        'RemainingValue
        '
        Me.RemainingValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RemainingValue.ForeColor = System.Drawing.Color.Black
        Me.RemainingValue.Location = New System.Drawing.Point(46, 96)
        Me.RemainingValue.Name = "RemainingValue"
        Me.RemainingValue.Size = New System.Drawing.Size(149, 25)
        Me.RemainingValue.TabIndex = 118
        Me.RemainingValue.Text = "0"
        Me.RemainingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSchedule
        '
        Me.BtnSchedule.Location = New System.Drawing.Point(35, 28)
        Me.BtnSchedule.Name = "BtnSchedule"
        Me.BtnSchedule.Size = New System.Drawing.Size(10, 13)
        Me.BtnSchedule.TabIndex = 121
        Me.BtnSchedule.Text = "جدولة مواعيد السداد"
        Me.BtnSchedule.UseVisualStyleBackColor = True
        Me.BtnSchedule.Visible = False
        '
        'GeneralLabel22
        '
        Me.GeneralLabel22.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel22.BackgroundImage = CType(resources.GetObject("GeneralLabel22.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel22.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel22.IsRequired = False
        Me.GeneralLabel22.Location = New System.Drawing.Point(202, 96)
        Me.GeneralLabel22.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel22.Name = "GeneralLabel22"
        Me.GeneralLabel22.SetLabelTxt = "المبلغ المتبقي :"
        Me.GeneralLabel22.Size = New System.Drawing.Size(132, 25)
        Me.GeneralLabel22.TabIndex = 117
        '
        'GeneralLabel23
        '
        Me.GeneralLabel23.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel23.BackgroundImage = CType(resources.GetObject("GeneralLabel23.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel23.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel23.IsRequired = False
        Me.GeneralLabel23.Location = New System.Drawing.Point(202, 64)
        Me.GeneralLabel23.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel23.Name = "GeneralLabel23"
        Me.GeneralLabel23.SetLabelTxt = "اجمالي المدفوع :"
        Me.GeneralLabel23.Size = New System.Drawing.Size(132, 25)
        Me.GeneralLabel23.TabIndex = 116
        '
        'PayedValue
        '
        Me.PayedValue.DecimalPlaces = 2
        Me.PayedValue.Location = New System.Drawing.Point(46, 65)
        Me.PayedValue.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.PayedValue.Name = "PayedValue"
        Me.PayedValue.Size = New System.Drawing.Size(149, 26)
        Me.PayedValue.TabIndex = 114
        Me.PayedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BillID
        '
        Me.BillID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BillID.Location = New System.Drawing.Point(352, 34)
        Me.BillID.Name = "BillID"
        Me.BillID.Size = New System.Drawing.Size(146, 25)
        Me.BillID.TabIndex = 101
        Me.BillID.Text = "0"
        Me.BillID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalBill
        '
        Me.TotalBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalBill.ForeColor = System.Drawing.Color.Black
        Me.TotalBill.Location = New System.Drawing.Point(46, 32)
        Me.TotalBill.Name = "TotalBill"
        Me.TotalBill.Size = New System.Drawing.Size(148, 25)
        Me.TotalBill.TabIndex = 100
        Me.TotalBill.Text = "0"
        Me.TotalBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GeneralLabel5
        '
        Me.GeneralLabel5.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel5.BackgroundImage = CType(resources.GetObject("GeneralLabel5.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel5.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel5.IsRequired = False
        Me.GeneralLabel5.Location = New System.Drawing.Point(51, 61)
        Me.GeneralLabel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel5.Name = "GeneralLabel5"
        Me.GeneralLabel5.SetLabelTxt = "قيمة الخصم :"
        Me.GeneralLabel5.Size = New System.Drawing.Size(10, 11)
        Me.GeneralLabel5.TabIndex = 92
        Me.GeneralLabel5.Visible = False
        '
        'GeneralLabel9
        '
        Me.GeneralLabel9.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel9.BackgroundImage = CType(resources.GetObject("GeneralLabel9.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel9.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel9.IsRequired = False
        Me.GeneralLabel9.Location = New System.Drawing.Point(202, 34)
        Me.GeneralLabel9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel9.Name = "GeneralLabel9"
        Me.GeneralLabel9.SetLabelTxt = "اجمالي الفاتورة :"
        Me.GeneralLabel9.Size = New System.Drawing.Size(132, 25)
        Me.GeneralLabel9.TabIndex = 94
        '
        'GeneralLabel20
        '
        Me.GeneralLabel20.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel20.BackgroundImage = CType(resources.GetObject("GeneralLabel20.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel20.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel20.IsRequired = False
        Me.GeneralLabel20.Location = New System.Drawing.Point(17, 60)
        Me.GeneralLabel20.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel20.Name = "GeneralLabel20"
        Me.GeneralLabel20.SetLabelTxt = "كوبون الخصم :"
        Me.GeneralLabel20.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel20.TabIndex = 110
        Me.GeneralLabel20.Visible = False
        '
        'GeneralLabel17
        '
        Me.GeneralLabel17.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel17.BackgroundImage = CType(resources.GetObject("GeneralLabel17.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel17.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel17.IsRequired = False
        Me.GeneralLabel17.Location = New System.Drawing.Point(9, 45)
        Me.GeneralLabel17.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel17.Name = "GeneralLabel17"
        Me.GeneralLabel17.SetLabelTxt = "اسم المحل :"
        Me.GeneralLabel17.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel17.TabIndex = 103
        Me.GeneralLabel17.Visible = False
        '
        'GeneralLabel10
        '
        Me.GeneralLabel10.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel10.BackgroundImage = CType(resources.GetObject("GeneralLabel10.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel10.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel10.IsRequired = False
        Me.GeneralLabel10.Location = New System.Drawing.Point(30, 94)
        Me.GeneralLabel10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel10.Name = "GeneralLabel10"
        Me.GeneralLabel10.SetLabelTxt = "قيمة الآجل :"
        Me.GeneralLabel10.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel10.TabIndex = 99
        Me.GeneralLabel10.Visible = False
        '
        'GeneralLabel6
        '
        Me.GeneralLabel6.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel6.BackgroundImage = CType(resources.GetObject("GeneralLabel6.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel6.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel6.IsRequired = False
        Me.GeneralLabel6.Location = New System.Drawing.Point(30, 61)
        Me.GeneralLabel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel6.Name = "GeneralLabel6"
        Me.GeneralLabel6.SetLabelTxt = "نوع الخصم :"
        Me.GeneralLabel6.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel6.TabIndex = 93
        Me.GeneralLabel6.Visible = False
        '
        'CardID
        '
        Me.CardID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CardID.FormattingEnabled = True
        Me.CardID.Location = New System.Drawing.Point(20, 70)
        Me.CardID.Name = "CardID"
        Me.CardID.Size = New System.Drawing.Size(13, 26)
        Me.CardID.TabIndex = 111
        Me.CardID.Visible = False
        '
        'CashValue
        '
        Me.CashValue.DecimalPlaces = 2
        Me.CashValue.Location = New System.Drawing.Point(0, 68)
        Me.CashValue.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.CashValue.Name = "CashValue"
        Me.CashValue.Size = New System.Drawing.Size(10, 26)
        Me.CashValue.TabIndex = 84
        Me.CashValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CashValue.Visible = False
        '
        'GeneralLabel18
        '
        Me.GeneralLabel18.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel18.BackgroundImage = CType(resources.GetObject("GeneralLabel18.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel18.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel18.IsRequired = False
        Me.GeneralLabel18.Location = New System.Drawing.Point(23, 43)
        Me.GeneralLabel18.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel18.Name = "GeneralLabel18"
        Me.GeneralLabel18.SetLabelTxt = "الوردية :"
        Me.GeneralLabel18.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel18.TabIndex = 104
        Me.GeneralLabel18.Visible = False
        '
        'DiscountType
        '
        Me.DiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DiscountType.FormattingEnabled = True
        Me.DiscountType.Items.AddRange(New Object() {"نسبة مئوية", "مبلغ ثابت", "لا يوجد"})
        Me.DiscountType.Location = New System.Drawing.Point(11, 56)
        Me.DiscountType.Name = "DiscountType"
        Me.DiscountType.Size = New System.Drawing.Size(13, 26)
        Me.DiscountType.TabIndex = 79
        Me.DiscountType.Visible = False
        '
        'GeneralLabel12
        '
        Me.GeneralLabel12.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel12.BackgroundImage = CType(resources.GetObject("GeneralLabel12.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel12.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel12.IsRequired = False
        Me.GeneralLabel12.Location = New System.Drawing.Point(17, 24)
        Me.GeneralLabel12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel12.Name = "GeneralLabel12"
        Me.GeneralLabel12.SetLabelTxt = "طريقة الدفع :"
        Me.GeneralLabel12.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel12.TabIndex = 97
        Me.GeneralLabel12.Visible = False
        '
        'GeneralLabel3
        '
        Me.GeneralLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel3.BackgroundImage = CType(resources.GetObject("GeneralLabel3.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel3.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel3.IsRequired = False
        Me.GeneralLabel3.Location = New System.Drawing.Point(508, 97)
        Me.GeneralLabel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel3.Name = "GeneralLabel3"
        Me.GeneralLabel3.SetLabelTxt = "وقت الفاتورة :"
        Me.GeneralLabel3.Size = New System.Drawing.Size(133, 25)
        Me.GeneralLabel3.TabIndex = 90
        '
        'GeneralLabel11
        '
        Me.GeneralLabel11.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel11.BackgroundImage = CType(resources.GetObject("GeneralLabel11.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel11.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel11.IsRequired = False
        Me.GeneralLabel11.Location = New System.Drawing.Point(-10, 51)
        Me.GeneralLabel11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel11.Name = "GeneralLabel11"
        Me.GeneralLabel11.SetLabelTxt = "قيمة النقدي :"
        Me.GeneralLabel11.Size = New System.Drawing.Size(10, 25)
        Me.GeneralLabel11.TabIndex = 98
        Me.GeneralLabel11.Visible = False
        '
        'GeneralLabel2
        '
        Me.GeneralLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel2.BackgroundImage = CType(resources.GetObject("GeneralLabel2.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel2.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel2.IsRequired = False
        Me.GeneralLabel2.Location = New System.Drawing.Point(508, 66)
        Me.GeneralLabel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel2.Name = "GeneralLabel2"
        Me.GeneralLabel2.SetLabelTxt = "تاريخ الفاتورة :"
        Me.GeneralLabel2.Size = New System.Drawing.Size(133, 25)
        Me.GeneralLabel2.TabIndex = 89
        '
        'CardValue
        '
        Me.CardValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CardValue.ForeColor = System.Drawing.Color.Black
        Me.CardValue.Location = New System.Drawing.Point(34, 68)
        Me.CardValue.Name = "CardValue"
        Me.CardValue.Size = New System.Drawing.Size(10, 25)
        Me.CardValue.TabIndex = 113
        Me.CardValue.Text = "0"
        Me.CardValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CardValue.Visible = False
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel1.BackgroundImage = CType(resources.GetObject("GeneralLabel1.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel1.IsRequired = False
        Me.GeneralLabel1.Location = New System.Drawing.Point(508, 34)
        Me.GeneralLabel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.SetLabelTxt = "رقم الفاتورة :"
        Me.GeneralLabel1.Size = New System.Drawing.Size(133, 25)
        Me.GeneralLabel1.TabIndex = 88
        '
        'BillDate
        '
        Me.BillDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.BillDate.Location = New System.Drawing.Point(352, 66)
        Me.BillDate.Name = "BillDate"
        Me.BillDate.RightToLeftLayout = True
        Me.BillDate.Size = New System.Drawing.Size(146, 26)
        Me.BillDate.TabIndex = 77
        '
        'BillTime
        '
        Me.BillTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BillTime.ForeColor = System.Drawing.Color.Black
        Me.BillTime.Location = New System.Drawing.Point(352, 98)
        Me.BillTime.Name = "BillTime"
        Me.BillTime.Size = New System.Drawing.Size(146, 25)
        Me.BillTime.TabIndex = 78
        Me.BillTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CreditValue
        '
        Me.CreditValue.DecimalPlaces = 2
        Me.CreditValue.Location = New System.Drawing.Point(30, 43)
        Me.CreditValue.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.CreditValue.Name = "CreditValue"
        Me.CreditValue.Size = New System.Drawing.Size(10, 26)
        Me.CreditValue.TabIndex = 85
        Me.CreditValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CreditValue.Visible = False
        '
        'ContentPanel
        '
        Me.ContentPanel.AutoScroll = True
        Me.ContentPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContentPanel.Controls.Add(Me.GroupHeader)
        Me.ContentPanel.Controls.Add(Me.GroupItems)
        Me.ContentPanel.Controls.Add(Me.GroupDetails)
        Me.ContentPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ContentPanel.Location = New System.Drawing.Point(0, 38)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Size = New System.Drawing.Size(679, 522)
        Me.ContentPanel.TabIndex = 23
        '
        'simpleSalesOrderNormal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(679, 545)
        Me.Controls.Add(Me.ContentPanel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(0, 95)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "simpleSalesOrderNormal"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "فواتير المبيعات - الطريقة العادية"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupDetails.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupItems.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Quantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Price, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupHeader.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DiscountValueItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiscountValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PayedValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CashValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContentPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSavePrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnSavePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupDetails As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupItems As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GeneralLabel13 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel14 As StandardClothes.GeneralLabel
    Friend WithEvents Quantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Price As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ItemName As System.Windows.Forms.ComboBox
    Friend WithEvents BarCode As System.Windows.Forms.TextBox
    Friend WithEvents RadioBarcode As System.Windows.Forms.RadioButton
    Friend WithEvents RadioItemName As System.Windows.Forms.RadioButton
    Friend WithEvents GroupHeader As System.Windows.Forms.GroupBox
    Friend WithEvents RemainingValue As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel22 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel23 As StandardClothes.GeneralLabel
    Friend WithEvents PayedValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents BillID As System.Windows.Forms.Label
    Friend WithEvents TotalBill As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel9 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel3 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel2 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel1 As StandardClothes.GeneralLabel
    Friend WithEvents BillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents BillTime As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GeneralLabel24 As StandardClothes.GeneralLabel
    Friend WithEvents BtnSchedule As System.Windows.Forms.Button
    Friend WithEvents EmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents DiscountTypeItem As System.Windows.Forms.ComboBox
    Friend WithEvents GeneralLabel19 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel15 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel16 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel5 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel21 As StandardClothes.GeneralLabel
    Friend WithEvents DiscountValueItem As System.Windows.Forms.NumericUpDown
    Friend WithEvents StockID As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel17 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel20 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel7 As StandardClothes.GeneralLabel
    Friend WithEvents PayType As System.Windows.Forms.ComboBox
    Friend WithEvents CardValue As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel12 As StandardClothes.GeneralLabel
    Friend WithEvents CashValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents GeneralLabel10 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel4 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel6 As StandardClothes.GeneralLabel
    Friend WithEvents CreditValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents GeneralLabel8 As StandardClothes.GeneralLabel
    Friend WithEvents CardID As System.Windows.Forms.ComboBox
    Friend WithEvents GeneralLabel18 As StandardClothes.GeneralLabel
    Friend WithEvents PeriodID As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel11 As StandardClothes.GeneralLabel
    Friend WithEvents OrderType As System.Windows.Forms.ComboBox
    Friend WithEvents BtnNewCustomer As System.Windows.Forms.Button
    Friend WithEvents DiscountType As System.Windows.Forms.ComboBox
    Friend WithEvents CustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents DiscountValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Comments As StandardClothes.GeneralTextBox
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuTotal As System.Windows.Forms.ToolStripMenuItem
End Class
