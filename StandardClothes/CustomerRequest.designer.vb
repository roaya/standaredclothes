<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerRequest))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSavePrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.GroupHeader = New System.Windows.Forms.GroupBox()
        Me.CustomerID = New System.Windows.Forms.ComboBox()
        Me.GeneralLabel5 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel4 = New StandardClothes.GeneralLabel()
        Me.ExpiredDate = New System.Windows.Forms.DateTimePicker()
        Me.GeneralLabel17 = New StandardClothes.GeneralLabel()
        Me.StockID = New System.Windows.Forms.ComboBox()
        Me.BillID = New System.Windows.Forms.Label()
        Me.GeneralLabel7 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel8 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel3 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel2 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel1 = New StandardClothes.GeneralLabel()
        Me.Comments = New StandardClothes.GeneralTextBox()
        Me.EmployeeID = New System.Windows.Forms.Label()
        Me.BillDate = New System.Windows.Forms.DateTimePicker()
        Me.BillTime = New System.Windows.Forms.Label()
        Me.GroupItems = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GeneralLabel13 = New StandardClothes.GeneralLabel()
        Me.Quantity = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ItemName = New System.Windows.Forms.ComboBox()
        Me.BarCode = New System.Windows.Forms.TextBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupDetails = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnSavePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBtnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NavigationBar = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.OrderByCombo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CountRecords = New System.Windows.Forms.ToolStripLabel()
        Me.FromStockID = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.ContentPanel.SuspendLayout()
        Me.GroupHeader.SuspendLayout()
        Me.GroupItems.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Quantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupDetails.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNew, Me.ToolStripSeparator2, Me.BtnSave, Me.ToolStripSeparator1, Me.BtnSavePrint, Me.ToolStripSeparator3, Me.BtnDelete, Me.BtnExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(1015, 35)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnNew
        '
        Me.BtnNew.AutoSize = False
        Me.BtnNew.BackgroundImage = Global.StandardClothes.My.Resources.Resources.without_texte_2_16
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(150, 35)
        Me.BtnNew.Text = "جديد  F2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
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
        Me.BtnSave.Size = New System.Drawing.Size(150, 35)
        Me.BtnSave.Text = "حفظ  F3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
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
        Me.BtnSavePrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnSavePrint.Size = New System.Drawing.Size(150, 35)
        Me.BtnSavePrint.Text = "حفظ و طباعة  F4"
        Me.BtnSavePrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
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
        Me.BtnDelete.Text = "حذف  F5"
        '
        'BtnExit
        '
        Me.BtnExit.AutoSize = False
        Me.BtnExit.BackgroundImage = Global.StandardClothes.My.Resources.Resources.EXIT_2_22
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(150, 35)
        Me.BtnExit.Text = "خروج"
        '
        'ContentPanel
        '
        Me.ContentPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContentPanel.Controls.Add(Me.GroupHeader)
        Me.ContentPanel.Controls.Add(Me.GroupItems)
        Me.ContentPanel.Controls.Add(Me.GroupDetails)
        Me.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentPanel.Location = New System.Drawing.Point(0, 35)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContentPanel.Size = New System.Drawing.Size(1015, 642)
        Me.ContentPanel.TabIndex = 24
        '
        'GroupHeader
        '
        Me.GroupHeader.BackColor = System.Drawing.Color.Transparent
        Me.GroupHeader.Controls.Add(Me.CustomerID)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel5)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel4)
        Me.GroupHeader.Controls.Add(Me.ExpiredDate)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel17)
        Me.GroupHeader.Controls.Add(Me.StockID)
        Me.GroupHeader.Controls.Add(Me.BillID)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel7)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel8)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel3)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel2)
        Me.GroupHeader.Controls.Add(Me.GeneralLabel1)
        Me.GroupHeader.Controls.Add(Me.Comments)
        Me.GroupHeader.Controls.Add(Me.EmployeeID)
        Me.GroupHeader.Controls.Add(Me.BillDate)
        Me.GroupHeader.Controls.Add(Me.BillTime)
        Me.GroupHeader.Enabled = False
        Me.GroupHeader.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupHeader.Location = New System.Drawing.Point(14, 16)
        Me.GroupHeader.Name = "GroupHeader"
        Me.GroupHeader.Size = New System.Drawing.Size(984, 138)
        Me.GroupHeader.TabIndex = 79
        Me.GroupHeader.TabStop = False
        Me.GroupHeader.Text = "البيانات الأساسية"
        '
        'CustomerID
        '
        Me.CustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CustomerID.FormattingEnabled = True
        Me.CustomerID.Location = New System.Drawing.Point(673, 101)
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.Size = New System.Drawing.Size(168, 26)
        Me.CustomerID.TabIndex = 108
        '
        'GeneralLabel5
        '
        Me.GeneralLabel5.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel5.BackgroundImage = CType(resources.GetObject("GeneralLabel5.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel5.IsRequired = True
        Me.GeneralLabel5.Location = New System.Drawing.Point(847, 100)
        Me.GeneralLabel5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel5.Name = "GeneralLabel5"
        Me.GeneralLabel5.SetLabelTxt = "اسم العميل :"
        Me.GeneralLabel5.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel5.TabIndex = 107
        '
        'GeneralLabel4
        '
        Me.GeneralLabel4.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel4.BackgroundImage = CType(resources.GetObject("GeneralLabel4.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel4.IsRequired = False
        Me.GeneralLabel4.Location = New System.Drawing.Point(527, 100)
        Me.GeneralLabel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel4.Name = "GeneralLabel4"
        Me.GeneralLabel4.SetLabelTxt = "تاريخ الانتهاء :"
        Me.GeneralLabel4.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel4.TabIndex = 105
        '
        'ExpiredDate
        '
        Me.ExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ExpiredDate.Location = New System.Drawing.Point(354, 100)
        Me.ExpiredDate.Name = "ExpiredDate"
        Me.ExpiredDate.RightToLeftLayout = True
        Me.ExpiredDate.Size = New System.Drawing.Size(167, 26)
        Me.ExpiredDate.TabIndex = 104
        '
        'GeneralLabel17
        '
        Me.GeneralLabel17.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel17.BackgroundImage = CType(resources.GetObject("GeneralLabel17.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel17.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel17.IsRequired = True
        Me.GeneralLabel17.Location = New System.Drawing.Point(847, 66)
        Me.GeneralLabel17.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel17.Name = "GeneralLabel17"
        Me.GeneralLabel17.SetLabelTxt = "من المحل :"
        Me.GeneralLabel17.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel17.TabIndex = 103
        '
        'StockID
        '
        Me.StockID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StockID.FormattingEnabled = True
        Me.StockID.Location = New System.Drawing.Point(674, 66)
        Me.StockID.Name = "StockID"
        Me.StockID.Size = New System.Drawing.Size(167, 26)
        Me.StockID.TabIndex = 102
        '
        'BillID
        '
        Me.BillID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BillID.Location = New System.Drawing.Point(674, 32)
        Me.BillID.Name = "BillID"
        Me.BillID.Size = New System.Drawing.Size(167, 26)
        Me.BillID.TabIndex = 101
        Me.BillID.Text = "0"
        Me.BillID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GeneralLabel7
        '
        Me.GeneralLabel7.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel7.BackgroundImage = CType(resources.GetObject("GeneralLabel7.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel7.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel7.IsRequired = False
        Me.GeneralLabel7.Location = New System.Drawing.Point(195, 66)
        Me.GeneralLabel7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel7.Name = "GeneralLabel7"
        Me.GeneralLabel7.SetLabelTxt = "ملاحظات :"
        Me.GeneralLabel7.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel7.TabIndex = 96
        '
        'GeneralLabel8
        '
        Me.GeneralLabel8.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel8.BackgroundImage = CType(resources.GetObject("GeneralLabel8.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel8.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel8.IsRequired = False
        Me.GeneralLabel8.Location = New System.Drawing.Point(195, 32)
        Me.GeneralLabel8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel8.Name = "GeneralLabel8"
        Me.GeneralLabel8.SetLabelTxt = "اسم الموظف :"
        Me.GeneralLabel8.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel8.TabIndex = 95
        '
        'GeneralLabel3
        '
        Me.GeneralLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel3.BackgroundImage = CType(resources.GetObject("GeneralLabel3.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel3.IsRequired = False
        Me.GeneralLabel3.Location = New System.Drawing.Point(527, 66)
        Me.GeneralLabel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel3.Name = "GeneralLabel3"
        Me.GeneralLabel3.SetLabelTxt = "وقت الفاتورة :"
        Me.GeneralLabel3.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel3.TabIndex = 90
        '
        'GeneralLabel2
        '
        Me.GeneralLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel2.BackgroundImage = CType(resources.GetObject("GeneralLabel2.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel2.IsRequired = False
        Me.GeneralLabel2.Location = New System.Drawing.Point(527, 32)
        Me.GeneralLabel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel2.Name = "GeneralLabel2"
        Me.GeneralLabel2.SetLabelTxt = "تاريخ الفاتورة :"
        Me.GeneralLabel2.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel2.TabIndex = 89
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralLabel1.BackgroundImage = CType(resources.GetObject("GeneralLabel1.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel1.IsRequired = False
        Me.GeneralLabel1.Location = New System.Drawing.Point(847, 32)
        Me.GeneralLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.SetLabelTxt = "رقم الفاتورة :"
        Me.GeneralLabel1.Size = New System.Drawing.Size(115, 26)
        Me.GeneralLabel1.TabIndex = 88
        '
        'Comments
        '
        Me.Comments.IsEmail = False
        Me.Comments.IsNum = False
        Me.Comments.IsRequired = False
        Me.Comments.Location = New System.Drawing.Point(22, 66)
        Me.Comments.Name = "Comments"
        Me.Comments.SetLeaveColor = System.Drawing.Color.Red
        Me.Comments.Size = New System.Drawing.Size(168, 26)
        Me.Comments.TabIndex = 87
        '
        'EmployeeID
        '
        Me.EmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EmployeeID.ForeColor = System.Drawing.Color.Black
        Me.EmployeeID.Location = New System.Drawing.Point(22, 32)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Size = New System.Drawing.Size(167, 26)
        Me.EmployeeID.TabIndex = 80
        Me.EmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BillDate
        '
        Me.BillDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.BillDate.Location = New System.Drawing.Point(354, 32)
        Me.BillDate.Name = "BillDate"
        Me.BillDate.RightToLeftLayout = True
        Me.BillDate.Size = New System.Drawing.Size(167, 26)
        Me.BillDate.TabIndex = 77
        '
        'BillTime
        '
        Me.BillTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BillTime.ForeColor = System.Drawing.Color.Black
        Me.BillTime.Location = New System.Drawing.Point(354, 66)
        Me.BillTime.Name = "BillTime"
        Me.BillTime.Size = New System.Drawing.Size(167, 26)
        Me.BillTime.TabIndex = 78
        Me.BillTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupItems
        '
        Me.GroupItems.BackColor = System.Drawing.Color.Transparent
        Me.GroupItems.Controls.Add(Me.GroupBox3)
        Me.GroupItems.Controls.Add(Me.GroupBox2)
        Me.GroupItems.Enabled = False
        Me.GroupItems.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupItems.Location = New System.Drawing.Point(14, 160)
        Me.GroupItems.Name = "GroupItems"
        Me.GroupItems.Size = New System.Drawing.Size(984, 154)
        Me.GroupItems.TabIndex = 78
        Me.GroupItems.TabStop = False
        Me.GroupItems.Text = "البيانات العامة للأصناف"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GeneralLabel13)
        Me.GroupBox3.Controls.Add(Me.Quantity)
        Me.GroupBox3.Location = New System.Drawing.Point(187, 25)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(293, 110)
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
        Me.GeneralLabel13.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel13.IsRequired = False
        Me.GeneralLabel13.Location = New System.Drawing.Point(185, 51)
        Me.GeneralLabel13.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GeneralLabel13.Name = "GeneralLabel13"
        Me.GeneralLabel13.SetLabelTxt = "العدد :"
        Me.GeneralLabel13.Size = New System.Drawing.Size(83, 26)
        Me.GeneralLabel13.TabIndex = 71
        '
        'Quantity
        '
        Me.Quantity.Location = New System.Drawing.Point(25, 51)
        Me.Quantity.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Size = New System.Drawing.Size(156, 26)
        Me.Quantity.TabIndex = 60
        Me.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ItemName)
        Me.GroupBox2.Controls.Add(Me.BarCode)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Location = New System.Drawing.Point(505, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(361, 110)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "الأصناف المختارة"
        '
        'ItemName
        '
        Me.ItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ItemName.Enabled = False
        Me.ItemName.FormattingEnabled = True
        Me.ItemName.Location = New System.Drawing.Point(33, 36)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(183, 26)
        Me.ItemName.TabIndex = 4
        '
        'BarCode
        '
        Me.BarCode.Location = New System.Drawing.Point(33, 69)
        Me.BarCode.Name = "BarCode"
        Me.BarCode.Size = New System.Drawing.Size(183, 26)
        Me.BarCode.TabIndex = 3
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(222, 72)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(106, 22)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "بحث بالباركود"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(225, 36)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(101, 22)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "بحث بالاسم"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupDetails
        '
        Me.GroupDetails.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GroupDetails.Controls.Add(Me.Panel3)
        Me.GroupDetails.Enabled = False
        Me.GroupDetails.Location = New System.Drawing.Point(14, 321)
        Me.GroupDetails.Name = "GroupDetails"
        Me.GroupDetails.Size = New System.Drawing.Size(984, 282)
        Me.GroupDetails.TabIndex = 77
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.MenuStrip1)
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(980, 278)
        Me.Panel3.TabIndex = 20
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(978, 24)
        Me.MenuStrip1.TabIndex = 25
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuBtnNew, Me.MenuBtnSave, Me.MenuBtnSavePrint, Me.MenuBtnExit})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(128, 20)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'MenuBtnNew
        '
        Me.MenuBtnNew.Name = "MenuBtnNew"
        Me.MenuBtnNew.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.MenuBtnNew.Size = New System.Drawing.Size(164, 22)
        Me.MenuBtnNew.Text = "Test"
        '
        'MenuBtnSave
        '
        Me.MenuBtnSave.Name = "MenuBtnSave"
        Me.MenuBtnSave.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.MenuBtnSave.Size = New System.Drawing.Size(164, 22)
        Me.MenuBtnSave.Text = "TestSave"
        '
        'MenuBtnSavePrint
        '
        Me.MenuBtnSavePrint.Name = "MenuBtnSavePrint"
        Me.MenuBtnSavePrint.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.MenuBtnSavePrint.Size = New System.Drawing.Size(164, 22)
        Me.MenuBtnSavePrint.Text = "TestSavePrint"
        '
        'MenuBtnExit
        '
        Me.MenuBtnExit.Name = "MenuBtnExit"
        Me.MenuBtnExit.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MenuBtnExit.Size = New System.Drawing.Size(164, 22)
        Me.MenuBtnExit.Text = "TestDelete"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver
        Me.DataGridView1.Size = New System.Drawing.Size(978, 276)
        Me.DataGridView1.TabIndex = 0
        '
        'NavigationBar
        '
        Me.NavigationBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.NavigationBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.NavigationBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.OrderByCombo, Me.ToolStripSeparator9, Me.ToolStripLabel2, Me.CountRecords})
        Me.NavigationBar.Location = New System.Drawing.Point(0, 652)
        Me.NavigationBar.Name = "NavigationBar"
        Me.NavigationBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NavigationBar.Size = New System.Drawing.Size(1015, 25)
        Me.NavigationBar.TabIndex = 25
        Me.NavigationBar.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(39, 22)
        Me.ToolStripLabel1.Text = "الترتيب"
        '
        'OrderByCombo
        '
        Me.OrderByCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OrderByCombo.Name = "OrderByCombo"
        Me.OrderByCombo.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = Global.StandardClothes.My.Resources.Resources.rar_256
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripLabel2.Text = "عدد السجلات :"
        '
        'CountRecords
        '
        Me.CountRecords.Name = "CountRecords"
        Me.CountRecords.Size = New System.Drawing.Size(13, 22)
        Me.CountRecords.Text = "0"
        '
        'FromStockID
        '
        Me.FromStockID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FromStockID.FormattingEnabled = True
        Me.FromStockID.Location = New System.Drawing.Point(690, 54)
        Me.FromStockID.Name = "FromStockID"
        Me.FromStockID.Size = New System.Drawing.Size(167, 21)
        Me.FromStockID.TabIndex = 102
        '
        'CustomerRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1015, 677)
        Me.Controls.Add(Me.NavigationBar)
        Me.Controls.Add(Me.ContentPanel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CustomerRequest"
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اذن حجز عميل"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContentPanel.ResumeLayout(False)
        Me.GroupHeader.ResumeLayout(False)
        Me.GroupItems.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Quantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupDetails.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationBar.ResumeLayout(False)
        Me.NavigationBar.PerformLayout()
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
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents GroupHeader As System.Windows.Forms.GroupBox
    Friend WithEvents GeneralLabel17 As StandardClothes.GeneralLabel
    Friend WithEvents StockID As System.Windows.Forms.ComboBox
    Friend WithEvents BillID As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel7 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel8 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel3 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel2 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel1 As StandardClothes.GeneralLabel
    Friend WithEvents Comments As StandardClothes.GeneralTextBox
    Friend WithEvents EmployeeID As System.Windows.Forms.Label
    Friend WithEvents BillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents BillTime As System.Windows.Forms.Label
    Friend WithEvents GroupItems As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GeneralLabel13 As StandardClothes.GeneralLabel
    Friend WithEvents Quantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ItemName As System.Windows.Forms.ComboBox
    Friend WithEvents BarCode As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupDetails As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GeneralLabel5 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel4 As StandardClothes.GeneralLabel
    Friend WithEvents ExpiredDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents NavigationBar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents OrderByCombo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CountRecords As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents FromStockID As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnSavePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBtnExit As System.Windows.Forms.ToolStripMenuItem
End Class
