<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomersVendorsAccount
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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ByVen = New System.Windows.Forms.RadioButton()
        Me.ByCust = New System.Windows.Forms.RadioButton()
        Me.Accounts = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Fromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Todate = New System.Windows.Forms.DateTimePicker()
        Me.Check = New System.Windows.Forms.Button()
        Me.AccountsDetails = New System.Windows.Forms.DataGridView()
        Me.Type = New System.Windows.Forms.Button()
        Me.Total = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.AccountsDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Label1.Location = New System.Drawing.Point(223, 11)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(66, 17)
        Label1.TabIndex = 5
        Label1.Text = "من تاريخ :"
        '
        'Label3
        '
        Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Label3.Location = New System.Drawing.Point(182, 586)
        Label3.Name = "Label3"
        Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Label3.Size = New System.Drawing.Size(97, 17)
        Label3.TabIndex = 7
        Label3.Text = "رصيد الحساب :"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Label4.Location = New System.Drawing.Point(264, 90)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(95, 17)
        Label4.TabIndex = 7
        Label4.Text = "اسم الحساب :"
        '
        'ByVen
        '
        Me.ByVen.AutoSize = True
        Me.ByVen.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ByVen.Location = New System.Drawing.Point(212, 57)
        Me.ByVen.Name = "ByVen"
        Me.ByVen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ByVen.Size = New System.Drawing.Size(132, 22)
        Me.ByVen.TabIndex = 57
        Me.ByVen.Text = "حسابات الموردين"
        Me.ByVen.UseVisualStyleBackColor = True
        '
        'ByCust
        '
        Me.ByCust.AutoSize = True
        Me.ByCust.Checked = True
        Me.ByCust.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ByCust.Location = New System.Drawing.Point(222, 19)
        Me.ByCust.Name = "ByCust"
        Me.ByCust.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ByCust.Size = New System.Drawing.Size(122, 22)
        Me.ByCust.TabIndex = 58
        Me.ByCust.TabStop = True
        Me.ByCust.Text = "حسابات العملاء"
        Me.ByCust.UseVisualStyleBackColor = True
        '
        'Accounts
        '
        Me.Accounts.FormattingEnabled = True
        Me.Accounts.Location = New System.Drawing.Point(26, 89)
        Me.Accounts.Name = "Accounts"
        Me.Accounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Accounts.Size = New System.Drawing.Size(229, 21)
        Me.Accounts.TabIndex = 59
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Label4)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Check)
        Me.GroupBox1.Controls.Add(Me.Accounts)
        Me.GroupBox1.Controls.Add(Me.ByCust)
        Me.GroupBox1.Controls.Add(Me.ByVen)
        Me.GroupBox1.Location = New System.Drawing.Point(283, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(385, 207)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Fromdate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Todate)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Location = New System.Drawing.Point(53, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(301, 72)
        Me.Panel1.TabIndex = 63
        '
        'Fromdate
        '
        Me.Fromdate.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fromdate.Location = New System.Drawing.Point(7, 7)
        Me.Fromdate.Name = "Fromdate"
        Me.Fromdate.RightToLeftLayout = True
        Me.Fromdate.Size = New System.Drawing.Size(196, 24)
        Me.Fromdate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(215, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "حتي تاريخ :"
        '
        'Todate
        '
        Me.Todate.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Todate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Todate.Location = New System.Drawing.Point(7, 39)
        Me.Todate.Name = "Todate"
        Me.Todate.RightToLeftLayout = True
        Me.Todate.Size = New System.Drawing.Size(196, 24)
        Me.Todate.TabIndex = 4
        '
        'Check
        '
        Me.Check.BackColor = System.Drawing.Color.Silver
        Me.Check.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Check.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Check.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Check.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Check.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check.Location = New System.Drawing.Point(30, 19)
        Me.Check.Name = "Check"
        Me.Check.Size = New System.Drawing.Size(128, 60)
        Me.Check.TabIndex = 62
        Me.Check.Text = "استعلام"
        Me.Check.UseVisualStyleBackColor = False
        '
        'AccountsDetails
        '
        Me.AccountsDetails.AllowUserToAddRows = False
        Me.AccountsDetails.AllowUserToDeleteRows = False
        Me.AccountsDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountsDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.AccountsDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AccountsDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.AccountsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AccountsDetails.DefaultCellStyle = DataGridViewCellStyle2
        Me.AccountsDetails.Location = New System.Drawing.Point(12, 256)
        Me.AccountsDetails.Name = "AccountsDetails"
        Me.AccountsDetails.ReadOnly = True
        Me.AccountsDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AccountsDetails.RowHeadersVisible = False
        Me.AccountsDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.AccountsDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AccountsDetails.Size = New System.Drawing.Size(656, 320)
        Me.AccountsDetails.TabIndex = 61
        '
        'Type
        '
        Me.Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Type.Location = New System.Drawing.Point(12, 227)
        Me.Type.Name = "Type"
        Me.Type.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Type.Size = New System.Drawing.Size(656, 23)
        Me.Type.TabIndex = 62
        Me.Type.UseVisualStyleBackColor = True
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Total.Location = New System.Drawing.Point(15, 583)
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(151, 23)
        Me.Total.TabIndex = 63
        Me.Total.Text = "0"
        Me.Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomersVendorsAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(680, 618)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.Type)
        Me.Controls.Add(Me.AccountsDetails)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CustomersVendorsAccount"
        Me.Text = "تفاصيل الحسابات"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AccountsDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ByVen As System.Windows.Forms.RadioButton
    Friend WithEvents ByCust As System.Windows.Forms.RadioButton
    Friend WithEvents Accounts As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AccountsDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Check As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Type As System.Windows.Forms.Button
    Friend WithEvents Total As System.Windows.Forms.Label
End Class
