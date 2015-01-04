<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aaa
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
        Me.TxtAgeDesc = New StandardClothes.GeneralTextBox()
        Me.GeneralLabel3 = New StandardClothes.GeneralLabel()
        Me.FromAge = New System.Windows.Forms.NumericUpDown()
        Me.ToAge = New System.Windows.Forms.NumericUpDown()
        Me.GeneralLabel1 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel2 = New StandardClothes.GeneralLabel()
        CType(Me.FromAge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToAge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtAgeDesc
        '
        Me.TxtAgeDesc.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAgeDesc.IsEmail = False
        Me.TxtAgeDesc.IsNum = False
        Me.TxtAgeDesc.IsRequired = False
        Me.TxtAgeDesc.Location = New System.Drawing.Point(185, 131)
        Me.TxtAgeDesc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtAgeDesc.Name = "TxtAgeDesc"
        Me.TxtAgeDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAgeDesc.SetLeaveColor = System.Drawing.Color.Red
        Me.TxtAgeDesc.Size = New System.Drawing.Size(283, 28)
        Me.TxtAgeDesc.TabIndex = 11
        '
        'GeneralLabel3
        '
        Me.GeneralLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel3.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel3.IsRequired = True
        Me.GeneralLabel3.Location = New System.Drawing.Point(474, 242)
        Me.GeneralLabel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel3.Name = "GeneralLabel3"
        Me.GeneralLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GeneralLabel3.SetLabelTxt = "الي عمر :"
        Me.GeneralLabel3.Size = New System.Drawing.Size(75, 27)
        Me.GeneralLabel3.TabIndex = 16
        '
        'FromAge
        '
        Me.FromAge.DecimalPlaces = 2
        Me.FromAge.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromAge.Location = New System.Drawing.Point(185, 187)
        Me.FromAge.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.FromAge.Name = "FromAge"
        Me.FromAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FromAge.Size = New System.Drawing.Size(283, 26)
        Me.FromAge.TabIndex = 12
        Me.FromAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToAge
        '
        Me.ToAge.DecimalPlaces = 2
        Me.ToAge.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToAge.Location = New System.Drawing.Point(185, 243)
        Me.ToAge.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.ToAge.Name = "ToAge"
        Me.ToAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToAge.Size = New System.Drawing.Size(283, 26)
        Me.ToAge.TabIndex = 13
        Me.ToAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel1.IsRequired = True
        Me.GeneralLabel1.Location = New System.Drawing.Point(476, 131)
        Me.GeneralLabel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GeneralLabel1.SetLabelTxt = "الفئة العمرية :"
        Me.GeneralLabel1.Size = New System.Drawing.Size(75, 27)
        Me.GeneralLabel1.TabIndex = 15
        '
        'GeneralLabel2
        '
        Me.GeneralLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel2.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel2.IsRequired = True
        Me.GeneralLabel2.Location = New System.Drawing.Point(474, 187)
        Me.GeneralLabel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel2.Name = "GeneralLabel2"
        Me.GeneralLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GeneralLabel2.SetLabelTxt = "من عمر :"
        Me.GeneralLabel2.Size = New System.Drawing.Size(75, 27)
        Me.GeneralLabel2.TabIndex = 14
        '
        'aaa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 449)
        Me.Controls.Add(Me.TxtAgeDesc)
        Me.Controls.Add(Me.GeneralLabel3)
        Me.Controls.Add(Me.FromAge)
        Me.Controls.Add(Me.ToAge)
        Me.Controls.Add(Me.GeneralLabel1)
        Me.Controls.Add(Me.GeneralLabel2)
        Me.Name = "aaa"
        Me.Text = "aaa"
        CType(Me.FromAge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToAge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtAgeDesc As StandardClothes.GeneralTextBox
    Friend WithEvents GeneralLabel3 As StandardClothes.GeneralLabel
    Friend WithEvents FromAge As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToAge As System.Windows.Forms.NumericUpDown
    Friend WithEvents GeneralLabel1 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel2 As StandardClothes.GeneralLabel
End Class
