<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodeShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarcodeShow))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Search = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LblPrice = New StandardClothes.GeneralLabel()
        Me.LblItemNAme = New StandardClothes.GeneralLabel()
        Me.LblBarcode = New StandardClothes.GeneralLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBarcode = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Search)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtBarcode)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(674, 282)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "استعلام باركود"
        '
        'Search
        '
        Me.Search.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter
        Me.Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Search.FlatAppearance.BorderSize = 0
        Me.Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Search.Location = New System.Drawing.Point(112, 40)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(131, 30)
        Me.Search.TabIndex = 1
        Me.Search.Text = "بحث"
        Me.Search.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LblPrice)
        Me.GroupBox3.Controls.Add(Me.LblItemNAme)
        Me.GroupBox3.Controls.Add(Me.LblBarcode)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 90)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(633, 170)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "التفاصيل"
        '
        'LblPrice
        '
        Me.LblPrice.BackColor = System.Drawing.SystemColors.Control
        Me.LblPrice.BackgroundImage = CType(resources.GetObject("LblPrice.BackgroundImage"), System.Drawing.Image)
        Me.LblPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblPrice.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrice.IsRequired = False
        Me.LblPrice.Location = New System.Drawing.Point(203, 118)
        Me.LblPrice.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LblPrice.Name = "LblPrice"
        Me.LblPrice.SetLabelTxt = Nothing
        Me.LblPrice.Size = New System.Drawing.Size(175, 30)
        Me.LblPrice.TabIndex = 5
        '
        'LblItemNAme
        '
        Me.LblItemNAme.BackColor = System.Drawing.SystemColors.Control
        Me.LblItemNAme.BackgroundImage = CType(resources.GetObject("LblItemNAme.BackgroundImage"), System.Drawing.Image)
        Me.LblItemNAme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblItemNAme.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblItemNAme.IsRequired = False
        Me.LblItemNAme.Location = New System.Drawing.Point(13, 50)
        Me.LblItemNAme.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LblItemNAme.Name = "LblItemNAme"
        Me.LblItemNAme.SetLabelTxt = Nothing
        Me.LblItemNAme.Size = New System.Drawing.Size(210, 30)
        Me.LblItemNAme.TabIndex = 4
        '
        'LblBarcode
        '
        Me.LblBarcode.BackColor = System.Drawing.SystemColors.Control
        Me.LblBarcode.BackgroundImage = CType(resources.GetObject("LblBarcode.BackgroundImage"), System.Drawing.Image)
        Me.LblBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblBarcode.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBarcode.IsRequired = False
        Me.LblBarcode.Location = New System.Drawing.Point(374, 50)
        Me.LblBarcode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LblBarcode.Name = "LblBarcode"
        Me.LblBarcode.SetLabelTxt = Nothing
        Me.LblBarcode.Size = New System.Drawing.Size(189, 30)
        Me.LblBarcode.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(384, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "السعر"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "اسم الصنف"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(570, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "الباركود"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(552, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "الباركود"
        '
        'TxtBarcode
        '
        Me.TxtBarcode.Location = New System.Drawing.Point(328, 42)
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Size = New System.Drawing.Size(218, 26)
        Me.TxtBarcode.TabIndex = 0
        '
        'BarcodeShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(710, 326)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "BarcodeShow"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "عرض الصنف"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LblPrice As StandardClothes.GeneralLabel
    Friend WithEvents LblItemNAme As StandardClothes.GeneralLabel
    Friend WithEvents LblBarcode As StandardClothes.GeneralLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBarcode As System.Windows.Forms.TextBox
End Class
