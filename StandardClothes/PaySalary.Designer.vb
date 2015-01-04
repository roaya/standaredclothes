<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaySalary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaySalary))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Notes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NetSalary = New System.Windows.Forms.Label()
        Me.EmpDiscounts = New System.Windows.Forms.Label()
        Me.EmpRewards = New System.Windows.Forms.Label()
        Me.Salary = New System.Windows.Forms.Label()
        Me.GroupDetails = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.EmployeeID = New System.Windows.Forms.ComboBox()
        Me.PayMonth = New System.Windows.Forms.DateTimePicker()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupDetails.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Notes)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NetSalary)
        Me.GroupBox1.Controls.Add(Me.EmpDiscounts)
        Me.GroupBox1.Controls.Add(Me.EmpRewards)
        Me.GroupBox1.Controls.Add(Me.Salary)
        Me.GroupBox1.Controls.Add(Me.GroupDetails)
        Me.GroupBox1.Controls.Add(Me.EmployeeID)
        Me.GroupBox1.Controls.Add(Me.PayMonth)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(922, 340)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Notes
        '
        Me.Notes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes.Location = New System.Drawing.Point(574, 262)
        Me.Notes.Multiline = True
        Me.Notes.Name = "Notes"
        Me.Notes.Size = New System.Drawing.Size(327, 62)
        Me.Notes.TabIndex = 105
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(785, 201)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(131, 18)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "صافى المرتب :"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(785, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(131, 18)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "ملاحظات :"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(785, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(131, 18)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "اجمالى الخصومات :"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(785, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(131, 18)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "اجمالى المكافئات :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(785, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(131, 18)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "المرتب الاساسى :"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(802, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(114, 18)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "تاريخ الدفع :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(816, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(100, 18)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "اسم الموظف :"
        '
        'NetSalary
        '
        Me.NetSalary.BackColor = System.Drawing.Color.Transparent
        Me.NetSalary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.NetSalary.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NetSalary.Location = New System.Drawing.Point(574, 201)
        Me.NetSalary.Name = "NetSalary"
        Me.NetSalary.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NetSalary.Size = New System.Drawing.Size(200, 20)
        Me.NetSalary.TabIndex = 97
        Me.NetSalary.Text = "0"
        Me.NetSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EmpDiscounts
        '
        Me.EmpDiscounts.BackColor = System.Drawing.Color.Transparent
        Me.EmpDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EmpDiscounts.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpDiscounts.Location = New System.Drawing.Point(574, 164)
        Me.EmpDiscounts.Name = "EmpDiscounts"
        Me.EmpDiscounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EmpDiscounts.Size = New System.Drawing.Size(200, 20)
        Me.EmpDiscounts.TabIndex = 96
        Me.EmpDiscounts.Text = "0"
        Me.EmpDiscounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EmpRewards
        '
        Me.EmpRewards.BackColor = System.Drawing.Color.Transparent
        Me.EmpRewards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EmpRewards.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpRewards.Location = New System.Drawing.Point(574, 127)
        Me.EmpRewards.Name = "EmpRewards"
        Me.EmpRewards.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EmpRewards.Size = New System.Drawing.Size(200, 20)
        Me.EmpRewards.TabIndex = 95
        Me.EmpRewards.Text = "0"
        Me.EmpRewards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Salary
        '
        Me.Salary.BackColor = System.Drawing.Color.Transparent
        Me.Salary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Salary.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Salary.Location = New System.Drawing.Point(574, 92)
        Me.Salary.Name = "Salary"
        Me.Salary.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Salary.Size = New System.Drawing.Size(200, 20)
        Me.Salary.TabIndex = 94
        Me.Salary.Text = "0"
        Me.Salary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupDetails
        '
        Me.GroupDetails.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GroupDetails.Controls.Add(Me.Panel3)
        Me.GroupDetails.Enabled = False
        Me.GroupDetails.Location = New System.Drawing.Point(22, 16)
        Me.GroupDetails.Name = "GroupDetails"
        Me.GroupDetails.Size = New System.Drawing.Size(539, 311)
        Me.GroupDetails.TabIndex = 93
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(535, 307)
        Me.Panel3.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver
        Me.DataGridView1.Size = New System.Drawing.Size(533, 305)
        Me.DataGridView1.TabIndex = 0
        '
        'EmployeeID
        '
        Me.EmployeeID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmployeeID.FormattingEnabled = True
        Me.EmployeeID.Location = New System.Drawing.Point(574, 16)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EmployeeID.Size = New System.Drawing.Size(202, 26)
        Me.EmployeeID.TabIndex = 90
        '
        'PayMonth
        '
        Me.PayMonth.CustomFormat = "MM/yyyy"
        Me.PayMonth.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PayMonth.Location = New System.Drawing.Point(574, 53)
        Me.PayMonth.Name = "PayMonth"
        Me.PayMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.PayMonth.RightToLeftLayout = True
        Me.PayMonth.Size = New System.Drawing.Size(200, 26)
        Me.PayMonth.TabIndex = 85
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(411, 371)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(117, 31)
        Me.BtnSave.TabIndex = 32
        Me.BtnSave.Text = "حفظ"
        Me.BtnSave.UseVisualStyleBackColor = False
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
        Me.BtnExit.Location = New System.Drawing.Point(224, 371)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(117, 31)
        Me.BtnExit.TabIndex = 31
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
        Me.BtnNew.Location = New System.Drawing.Point(593, 371)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(117, 31)
        Me.BtnNew.TabIndex = 30
        Me.BtnNew.Text = "استعلام"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'PaySalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(934, 424)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PaySalary"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مرتبات الموظفين"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupDetails.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Notes As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NetSalary As System.Windows.Forms.Label
    Friend WithEvents EmpDiscounts As System.Windows.Forms.Label
    Friend WithEvents EmpRewards As System.Windows.Forms.Label
    Friend WithEvents Salary As System.Windows.Forms.Label
    Friend WithEvents GroupDetails As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents EmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents PayMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
End Class
