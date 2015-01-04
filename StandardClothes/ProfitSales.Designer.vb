<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfitSales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfitSales))
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TotalIncome = New System.Windows.Forms.Label()
        Me.TotalSale = New System.Windows.Forms.Label()
        Me.TotalCost = New System.Windows.Forms.Label()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.BtnExit.Location = New System.Drawing.Point(45, 324)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnExit.Size = New System.Drawing.Size(89, 27)
        Me.BtnExit.TabIndex = 4
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
        Me.BtnNew.Location = New System.Drawing.Point(204, 324)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnNew.Size = New System.Drawing.Size(89, 27)
        Me.BtnNew.TabIndex = 3
        Me.BtnNew.Text = "عرض"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(230, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "من تاريخ :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TotalIncome)
        Me.GroupBox1.Controls.Add(Me.TotalSale)
        Me.GroupBox1.Controls.Add(Me.TotalCost)
        Me.GroupBox1.Controls.Add(Me.ToDate)
        Me.GroupBox1.Controls.Add(Me.FromDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(322, 295)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ربح البيع"
        '
        'TotalIncome
        '
        Me.TotalIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalIncome.Location = New System.Drawing.Point(52, 245)
        Me.TotalIncome.Name = "TotalIncome"
        Me.TotalIncome.Size = New System.Drawing.Size(135, 26)
        Me.TotalIncome.TabIndex = 13
        '
        'TotalSale
        '
        Me.TotalSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalSale.Location = New System.Drawing.Point(52, 195)
        Me.TotalSale.Name = "TotalSale"
        Me.TotalSale.Size = New System.Drawing.Size(135, 26)
        Me.TotalSale.TabIndex = 12
        '
        'TotalCost
        '
        Me.TotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalCost.Location = New System.Drawing.Point(52, 148)
        Me.TotalCost.Name = "TotalCost"
        Me.TotalCost.Size = New System.Drawing.Size(135, 26)
        Me.TotalCost.TabIndex = 11
        '
        'ToDate
        '
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(52, 91)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.RightToLeftLayout = True
        Me.ToDate.Size = New System.Drawing.Size(172, 26)
        Me.ToDate.TabIndex = 10
        '
        'FromDate
        '
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(52, 41)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.RightToLeftLayout = True
        Me.FromDate.Size = New System.Drawing.Size(172, 26)
        Me.FromDate.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(193, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 18)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "اجمالي ربح البيع :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(192, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "اجمالي المبيعات :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(199, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "اجمالي التكلفه :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "الي تاريخ :"
        '
        'ProfitSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(346, 363)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnNew)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "ProfitSales"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ربح البيع"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TotalIncome As System.Windows.Forms.Label
    Friend WithEvents TotalSale As System.Windows.Forms.Label
    Friend WithEvents TotalCost As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
