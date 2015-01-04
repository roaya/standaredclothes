<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vendorsReScheduling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vendorsReScheduling))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Required = New System.Windows.Forms.Label()
        Me.GeneralLabel18 = New StandardClothes.GeneralLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Remain = New System.Windows.Forms.Label()
        Me.GeneralLabel4 = New StandardClothes.GeneralLabel()
        Me.TotalSalCredit = New System.Windows.Forms.Label()
        Me.GeneralLabel3 = New StandardClothes.GeneralLabel()
        Me.Total_Payed = New System.Windows.Forms.Label()
        Me.GeneralLabel2 = New StandardClothes.GeneralLabel()
        Me.Total_credit = New System.Windows.Forms.Label()
        Me.GeneralLabel1 = New StandardClothes.GeneralLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Required
        '
        Me.Required.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Required.ForeColor = System.Drawing.Color.Black
        Me.Required.Location = New System.Drawing.Point(125, 162)
        Me.Required.Name = "Required"
        Me.Required.Size = New System.Drawing.Size(143, 28)
        Me.Required.TabIndex = 109
        Me.Required.Text = "0"
        Me.Required.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GeneralLabel18
        '
        Me.GeneralLabel18.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel18.BackgroundImage = CType(resources.GetObject("GeneralLabel18.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel18.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel18.IsRequired = True
        Me.GeneralLabel18.Location = New System.Drawing.Point(274, 161)
        Me.GeneralLabel18.Name = "GeneralLabel18"
        Me.GeneralLabel18.SetLabelTxt = "القيمة المراد جدولتها :"
        Me.GeneralLabel18.Size = New System.Drawing.Size(171, 31)
        Me.GeneralLabel18.TabIndex = 108
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Location = New System.Drawing.Point(18, 198)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(511, 306)
        Me.Panel1.TabIndex = 110
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.ColumnHeadersHeight = 27
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Size = New System.Drawing.Size(511, 306)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Remain)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel4)
        Me.GroupBox1.Controls.Add(Me.TotalSalCredit)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel3)
        Me.GroupBox1.Controls.Add(Me.Total_Payed)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(602, 101)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        '
        'Remain
        '
        Me.Remain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Remain.ForeColor = System.Drawing.Color.Black
        Me.Remain.Location = New System.Drawing.Point(15, 67)
        Me.Remain.Name = "Remain"
        Me.Remain.Size = New System.Drawing.Size(124, 28)
        Me.Remain.TabIndex = 117
        Me.Remain.Text = "0"
        Me.Remain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GeneralLabel4
        '
        Me.GeneralLabel4.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel4.BackgroundImage = CType(resources.GetObject("GeneralLabel4.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel4.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel4.IsRequired = False
        Me.GeneralLabel4.Location = New System.Drawing.Point(145, 67)
        Me.GeneralLabel4.Name = "GeneralLabel4"
        Me.GeneralLabel4.SetLabelTxt = "الدفعات المتبقيه :"
        Me.GeneralLabel4.Size = New System.Drawing.Size(145, 28)
        Me.GeneralLabel4.TabIndex = 116
        '
        'TotalSalCredit
        '
        Me.TotalSalCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalSalCredit.ForeColor = System.Drawing.Color.Black
        Me.TotalSalCredit.Location = New System.Drawing.Point(308, 44)
        Me.TotalSalCredit.Name = "TotalSalCredit"
        Me.TotalSalCredit.Size = New System.Drawing.Size(115, 28)
        Me.TotalSalCredit.TabIndex = 115
        Me.TotalSalCredit.Text = "0"
        Me.TotalSalCredit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GeneralLabel3
        '
        Me.GeneralLabel3.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel3.BackgroundImage = CType(resources.GetObject("GeneralLabel3.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel3.IsRequired = False
        Me.GeneralLabel3.Location = New System.Drawing.Point(429, 44)
        Me.GeneralLabel3.Name = "GeneralLabel3"
        Me.GeneralLabel3.SetLabelTxt = "اجمالى اجل المبيعات :"
        Me.GeneralLabel3.Size = New System.Drawing.Size(167, 28)
        Me.GeneralLabel3.TabIndex = 114
        '
        'Total_Payed
        '
        Me.Total_Payed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Total_Payed.ForeColor = System.Drawing.Color.Black
        Me.Total_Payed.Location = New System.Drawing.Point(15, 19)
        Me.Total_Payed.Name = "Total_Payed"
        Me.Total_Payed.Size = New System.Drawing.Size(124, 28)
        Me.Total_Payed.TabIndex = 113
        Me.Total_Payed.Text = "0"
        Me.Total_Payed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GeneralLabel2
        '
        Me.GeneralLabel2.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel2.BackgroundImage = CType(resources.GetObject("GeneralLabel2.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel2.IsRequired = False
        Me.GeneralLabel2.Location = New System.Drawing.Point(145, 19)
        Me.GeneralLabel2.Name = "GeneralLabel2"
        Me.GeneralLabel2.SetLabelTxt = "الدفعات المسدد :"
        Me.GeneralLabel2.Size = New System.Drawing.Size(145, 28)
        Me.GeneralLabel2.TabIndex = 112
        '
        'Total_credit
        '
        Me.Total_credit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Total_credit.ForeColor = System.Drawing.Color.Black
        Me.Total_credit.Location = New System.Drawing.Point(125, 126)
        Me.Total_credit.Name = "Total_credit"
        Me.Total_credit.Size = New System.Drawing.Size(143, 28)
        Me.Total_credit.TabIndex = 111
        Me.Total_credit.Text = "0"
        Me.Total_credit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel1.BackgroundImage = CType(resources.GetObject("GeneralLabel1.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel1.IsRequired = False
        Me.GeneralLabel1.Location = New System.Drawing.Point(274, 126)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.SetLabelTxt = "اجمالى أجل المرتجع:"
        Me.GeneralLabel1.Size = New System.Drawing.Size(171, 28)
        Me.GeneralLabel1.TabIndex = 110
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(335, 510)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 28)
        Me.Button1.TabIndex = 112
        Me.Button1.Text = "حفظ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(123, 510)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 28)
        Me.Button2.TabIndex = 113
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.StandardClothes.My.Resources.Resources.Symbol_Add
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(12, 136)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 42)
        Me.Button3.TabIndex = 114
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ReScheduling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(626, 547)
        Me.Controls.Add(Me.Required)
        Me.Controls.Add(Me.GeneralLabel18)
        Me.Controls.Add(Me.Total_credit)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GeneralLabel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ReScheduling"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "إعاده الجدوله"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Required As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel18 As StandardClothes.GeneralLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Total_Payed As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel2 As StandardClothes.GeneralLabel
    Friend WithEvents Total_credit As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel1 As StandardClothes.GeneralLabel
    Friend WithEvents TotalSalCredit As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel3 As StandardClothes.GeneralLabel
    Friend WithEvents Remain As System.Windows.Forms.Label
    Friend WithEvents GeneralLabel4 As StandardClothes.GeneralLabel
End Class
