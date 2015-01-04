<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NetProfit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NetProfit))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblProfit = New System.Windows.Forms.Label()
        Me.ProfitNet = New System.Windows.Forms.Label()
        Me.ProfitReturnVendors = New System.Windows.Forms.Label()
        Me.ProfitSales = New System.Windows.Forms.Label()
        Me.TotalVendorPayments = New System.Windows.Forms.Label()
        Me.TotalReturnCustomers = New System.Windows.Forms.Label()
        Me.TotalPurchase = New System.Windows.Forms.Label()
        Me.TotalPaySalary = New System.Windows.Forms.Label()
        Me.TotalExpenses = New System.Windows.Forms.Label()
        Me.TotalAddedHours = New System.Windows.Forms.Label()
        Me.ProfitCustomerPayments = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(589, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معامل التقرير"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(513, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "من تاريخ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(228, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "الي تاريخ :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(307, 37)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeftLayout = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker1.TabIndex = 29
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(22, 37)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.RightToLeftLayout = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePicker2.TabIndex = 30
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.LblProfit)
        Me.GroupBox2.Controls.Add(Me.ProfitNet)
        Me.GroupBox2.Controls.Add(Me.ProfitReturnVendors)
        Me.GroupBox2.Controls.Add(Me.ProfitSales)
        Me.GroupBox2.Controls.Add(Me.TotalVendorPayments)
        Me.GroupBox2.Controls.Add(Me.TotalReturnCustomers)
        Me.GroupBox2.Controls.Add(Me.TotalPurchase)
        Me.GroupBox2.Controls.Add(Me.TotalPaySalary)
        Me.GroupBox2.Controls.Add(Me.TotalExpenses)
        Me.GroupBox2.Controls.Add(Me.TotalAddedHours)
        Me.GroupBox2.Controls.Add(Me.ProfitCustomerPayments)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(589, 376)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'LblProfit
        '
        Me.LblProfit.AutoSize = True
        Me.LblProfit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProfit.ForeColor = System.Drawing.Color.Black
        Me.LblProfit.Location = New System.Drawing.Point(293, 326)
        Me.LblProfit.Name = "LblProfit"
        Me.LblProfit.Size = New System.Drawing.Size(169, 17)
        Me.LblProfit.TabIndex = 87
        Me.LblProfit.Text = "صافي الربح المحقق عن الفترة :"
        '
        'ProfitNet
        '
        Me.ProfitNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProfitNet.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfitNet.ForeColor = System.Drawing.Color.Black
        Me.ProfitNet.Location = New System.Drawing.Point(154, 324)
        Me.ProfitNet.Name = "ProfitNet"
        Me.ProfitNet.Size = New System.Drawing.Size(133, 21)
        Me.ProfitNet.TabIndex = 86
        Me.ProfitNet.Text = "0"
        Me.ProfitNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProfitReturnVendors
        '
        Me.ProfitReturnVendors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProfitReturnVendors.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfitReturnVendors.ForeColor = System.Drawing.Color.Yellow
        Me.ProfitReturnVendors.Location = New System.Drawing.Point(45, 122)
        Me.ProfitReturnVendors.Name = "ProfitReturnVendors"
        Me.ProfitReturnVendors.Size = New System.Drawing.Size(116, 21)
        Me.ProfitReturnVendors.TabIndex = 85
        Me.ProfitReturnVendors.Text = "0"
        Me.ProfitReturnVendors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProfitSales
        '
        Me.ProfitSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProfitSales.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfitSales.ForeColor = System.Drawing.Color.Yellow
        Me.ProfitSales.Location = New System.Drawing.Point(45, 77)
        Me.ProfitSales.Name = "ProfitSales"
        Me.ProfitSales.Size = New System.Drawing.Size(116, 21)
        Me.ProfitSales.TabIndex = 84
        Me.ProfitSales.Text = "0"
        Me.ProfitSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalVendorPayments
        '
        Me.TotalVendorPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalVendorPayments.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalVendorPayments.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TotalVendorPayments.Location = New System.Drawing.Point(330, 32)
        Me.TotalVendorPayments.Name = "TotalVendorPayments"
        Me.TotalVendorPayments.Size = New System.Drawing.Size(116, 21)
        Me.TotalVendorPayments.TabIndex = 83
        Me.TotalVendorPayments.Text = "0"
        Me.TotalVendorPayments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalReturnCustomers
        '
        Me.TotalReturnCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalReturnCustomers.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalReturnCustomers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TotalReturnCustomers.Location = New System.Drawing.Point(330, 257)
        Me.TotalReturnCustomers.Name = "TotalReturnCustomers"
        Me.TotalReturnCustomers.Size = New System.Drawing.Size(116, 21)
        Me.TotalReturnCustomers.TabIndex = 82
        Me.TotalReturnCustomers.Text = "0"
        Me.TotalReturnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalPurchase
        '
        Me.TotalPurchase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalPurchase.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPurchase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TotalPurchase.Location = New System.Drawing.Point(330, 212)
        Me.TotalPurchase.Name = "TotalPurchase"
        Me.TotalPurchase.Size = New System.Drawing.Size(116, 21)
        Me.TotalPurchase.TabIndex = 81
        Me.TotalPurchase.Text = "0"
        Me.TotalPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalPaySalary
        '
        Me.TotalPaySalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalPaySalary.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPaySalary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TotalPaySalary.Location = New System.Drawing.Point(330, 167)
        Me.TotalPaySalary.Name = "TotalPaySalary"
        Me.TotalPaySalary.Size = New System.Drawing.Size(116, 21)
        Me.TotalPaySalary.TabIndex = 80
        Me.TotalPaySalary.Text = "0"
        Me.TotalPaySalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalExpenses
        '
        Me.TotalExpenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalExpenses.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalExpenses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TotalExpenses.Location = New System.Drawing.Point(330, 122)
        Me.TotalExpenses.Name = "TotalExpenses"
        Me.TotalExpenses.Size = New System.Drawing.Size(116, 21)
        Me.TotalExpenses.TabIndex = 79
        Me.TotalExpenses.Text = "0"
        Me.TotalExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalAddedHours
        '
        Me.TotalAddedHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalAddedHours.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalAddedHours.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TotalAddedHours.Location = New System.Drawing.Point(330, 77)
        Me.TotalAddedHours.Name = "TotalAddedHours"
        Me.TotalAddedHours.Size = New System.Drawing.Size(116, 21)
        Me.TotalAddedHours.TabIndex = 78
        Me.TotalAddedHours.Text = "0"
        Me.TotalAddedHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProfitCustomerPayments
        '
        Me.ProfitCustomerPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProfitCustomerPayments.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfitCustomerPayments.ForeColor = System.Drawing.Color.Yellow
        Me.ProfitCustomerPayments.Location = New System.Drawing.Point(45, 32)
        Me.ProfitCustomerPayments.Name = "ProfitCustomerPayments"
        Me.ProfitCustomerPayments.Size = New System.Drawing.Size(116, 21)
        Me.ProfitCustomerPayments.TabIndex = 77
        Me.ProfitCustomerPayments.Text = "0"
        Me.ProfitCustomerPayments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label12.Location = New System.Drawing.Point(167, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 17)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "مرتجع الموردين :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label11.Location = New System.Drawing.Point(169, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 17)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "اجمالي المبيعات :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Brown
        Me.Label10.Location = New System.Drawing.Point(449, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 17)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "مدفوعات المرتبات :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Brown
        Me.Label9.Location = New System.Drawing.Point(449, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 17)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "اجمالي المصروفات :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Brown
        Me.Label7.Location = New System.Drawing.Point(453, 215)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 17)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "اجمالي المشتريات :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Brown
        Me.Label6.Location = New System.Drawing.Point(469, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 17)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "مرتجع العملاء :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Brown
        Me.Label5.Location = New System.Drawing.Point(456, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 17)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "الساعات الاضافية :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label4.Location = New System.Drawing.Point(167, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 17)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "مدفوعات العملاء :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Brown
        Me.Label3.Location = New System.Drawing.Point(451, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "مدفوعات الموردين :"
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.BackgroundImage = CType(resources.GetObject("BtnExit.BackgroundImage"), System.Drawing.Image)
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(117, 515)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(117, 31)
        Me.BtnExit.TabIndex = 30
        Me.BtnExit.Text = "خروج"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnNew.BackgroundImage = CType(resources.GetObject("BtnNew.BackgroundImage"), System.Drawing.Image)
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.Location = New System.Drawing.Point(342, 515)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(117, 31)
        Me.BtnNew.TabIndex = 29
        Me.BtnNew.Text = "استعلام"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'NetProfit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(613, 558)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NetProfit"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اجمالي الربح المحقق خلال فترة محددة"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ProfitNet As System.Windows.Forms.Label
    Friend WithEvents ProfitReturnVendors As System.Windows.Forms.Label
    Friend WithEvents ProfitSales As System.Windows.Forms.Label
    Friend WithEvents TotalVendorPayments As System.Windows.Forms.Label
    Friend WithEvents TotalReturnCustomers As System.Windows.Forms.Label
    Friend WithEvents TotalPurchase As System.Windows.Forms.Label
    Friend WithEvents TotalPaySalary As System.Windows.Forms.Label
    Friend WithEvents TotalExpenses As System.Windows.Forms.Label
    Friend WithEvents TotalAddedHours As System.Windows.Forms.Label
    Friend WithEvents ProfitCustomerPayments As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblProfit As System.Windows.Forms.Label
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
End Class
