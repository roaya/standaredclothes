<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeesRewards
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeesRewards))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContentPanel = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.CategoryID = New System.Windows.Forms.ComboBox()
        Me.GeneralLabel5 = New StandardClothes.GeneralLabel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GeneralLabel4 = New StandardClothes.GeneralLabel()
        Me.RewardValue = New System.Windows.Forms.NumericUpDown()
        Me.GeneralLabel3 = New StandardClothes.GeneralLabel()
        Me.RewardDate = New System.Windows.Forms.DateTimePicker()
        Me.EmployeeID = New System.Windows.Forms.ComboBox()
        Me.Reason = New StandardClothes.GeneralTextBox()
        Me.GeneralLabel1 = New StandardClothes.GeneralLabel()
        Me.GeneralLabel2 = New StandardClothes.GeneralLabel()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLast = New System.Windows.Forms.Button()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.OrderByCombo = New System.Windows.Forms.ComboBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.BtnPrevious = New System.Windows.Forms.Button()
        Me.BtnFirst = New System.Windows.Forms.Button()
        Me.CountRecords = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.BtnFile = New System.Windows.Forms.Button()
        Me.BtnData = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.BtnReload = New System.Windows.Forms.Button()
        Me.BtnCancelSerach = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuAllCommands = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentPanel.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RewardValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContentPanel
        '
        Me.ContentPanel.BackColor = System.Drawing.Color.Transparent
        Me.ContentPanel.BackgroundImage = Global.StandardClothes.My.Resources.Resources.conatin_box_03
        Me.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContentPanel.Controls.Add(Me.TabControl1)
        Me.ContentPanel.Controls.Add(Me.CategoryID)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel5)
        Me.ContentPanel.Controls.Add(Me.DataGridView1)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel4)
        Me.ContentPanel.Controls.Add(Me.RewardValue)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel3)
        Me.ContentPanel.Controls.Add(Me.RewardDate)
        Me.ContentPanel.Controls.Add(Me.EmployeeID)
        Me.ContentPanel.Controls.Add(Me.Reason)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel1)
        Me.ContentPanel.Controls.Add(Me.GeneralLabel2)
        Me.ContentPanel.Location = New System.Drawing.Point(12, 76)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Size = New System.Drawing.Size(732, 444)
        Me.ContentPanel.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(90, 18)
        Me.TabControl1.Location = New System.Drawing.Point(34, 22)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(223, 402)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 96
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.Button12)
        Me.TabPage1.Controls.Add(Me.Button11)
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.Button7)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(215, 376)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "«·‰Ê«›–"
        '
        'Button12
        '
        Me.Button12.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button12.FlatAppearance.BorderSize = 0
        Me.Button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button12.ForeColor = System.Drawing.Color.White
        Me.Button12.Location = New System.Drawing.Point(3, 311)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(209, 28)
        Me.Button12.TabIndex = 54
        Me.Button12.TabStop = False
        Me.Button12.Text = "œ›⁄ «·„— »« "
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button11.ForeColor = System.Drawing.Color.White
        Me.Button11.Location = New System.Drawing.Point(3, 283)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(209, 28)
        Me.Button11.TabIndex = 53
        Me.Button11.TabStop = False
        Me.Button11.Text = "«·«œ«—« "
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Location = New System.Drawing.Point(3, 255)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(209, 28)
        Me.Button10.TabIndex = 52
        Me.Button10.TabStop = False
        Me.Button10.Text = "«·ÊŸ«∆›"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Location = New System.Drawing.Point(3, 227)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(209, 28)
        Me.Button9.TabIndex = 51
        Me.Button9.TabStop = False
        Me.Button9.Text = "«·Õ÷Ê— Ê «·«‰’—«›"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(3, 199)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(209, 28)
        Me.Button8.TabIndex = 50
        Me.Button8.TabStop = False
        Me.Button8.Text = "»Ì«‰«  «·„” Œœ„Ì‰"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(3, 171)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(209, 28)
        Me.Button7.TabIndex = 49
        Me.Button7.TabStop = False
        Me.Button7.Text = "»‰Êœ «·„ﬂ«›¬ "
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(3, 143)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(209, 28)
        Me.Button6.TabIndex = 48
        Me.Button6.TabStop = False
        Me.Button6.Text = "»‰Êœ «·Œ’Ê„« "
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(3, 115)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(209, 28)
        Me.Button5.TabIndex = 47
        Me.Button5.TabStop = False
        Me.Button5.Text = "√Ã«“«  «·„ÊŸ›Ì‰"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(3, 87)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(209, 28)
        Me.Button4.TabIndex = 46
        Me.Button4.TabStop = False
        Me.Button4.Text = "„Â„«  «·„ÊŸ›Ì‰"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(3, 59)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(209, 28)
        Me.Button3.TabIndex = 45
        Me.Button3.TabStop = False
        Me.Button3.Text = "«·„ÊŸ›Ì‰"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(3, 31)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(209, 28)
        Me.Button2.TabIndex = 44
        Me.Button2.TabStop = False
        Me.Button2.Text = "Œ’Ê„«  «·„ÊŸ›Ì‰"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(209, 28)
        Me.Button1.TabIndex = 43
        Me.Button1.TabStop = False
        Me.Button1.Text = "«·”«⁄«  «·«÷«›Ì…"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.Button15)
        Me.TabPage2.Controls.Add(Me.Button14)
        Me.TabPage2.Controls.Add(Me.Button13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(215, 376)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "«· ﬁ«—Ì—"
        '
        'Button15
        '
        Me.Button15.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button15.FlatAppearance.BorderSize = 0
        Me.Button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button15.ForeColor = System.Drawing.Color.White
        Me.Button15.Location = New System.Drawing.Point(0, 56)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(215, 28)
        Me.Button15.TabIndex = 46
        Me.Button15.TabStop = False
        Me.Button15.Text = "«·«” ⁄·«„ »«·ÊŸÌ›… Ê «·«œ«—…"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button14.FlatAppearance.BorderSize = 0
        Me.Button14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button14.ForeColor = System.Drawing.Color.White
        Me.Button14.Location = New System.Drawing.Point(0, 28)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(215, 28)
        Me.Button14.TabIndex = 45
        Me.Button14.TabStop = False
        Me.Button14.Text = "«” ⁄·«„ ⁄‰ „ﬂ«›¬  «·„ÊŸ›Ì‰"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.BackgroundImage = Global.StandardClothes.My.Resources.Resources.aaa
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button13.FlatAppearance.BorderSize = 0
        Me.Button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button13.ForeColor = System.Drawing.Color.White
        Me.Button13.Location = New System.Drawing.Point(0, 0)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(215, 28)
        Me.Button13.TabIndex = 44
        Me.Button13.TabStop = False
        Me.Button13.Text = "«” ⁄·«„ ⁄«„ ⁄‰ «·„ÊŸ›"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'CategoryID
        '
        Me.CategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CategoryID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoryID.FormattingEnabled = True
        Me.CategoryID.Location = New System.Drawing.Point(277, 36)
        Me.CategoryID.Name = "CategoryID"
        Me.CategoryID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CategoryID.Size = New System.Drawing.Size(283, 26)
        Me.CategoryID.TabIndex = 1
        '
        'GeneralLabel5
        '
        Me.GeneralLabel5.BackColor = System.Drawing.Color.Transparent
        Me.GeneralLabel5.BackgroundImage = CType(resources.GetObject("GeneralLabel5.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel5.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel5.IsRequired = True
        Me.GeneralLabel5.Location = New System.Drawing.Point(567, 36)
        Me.GeneralLabel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel5.Name = "GeneralLabel5"
        Me.GeneralLabel5.SetLabelTxt = "»‰œ «·„ﬂ«›√Â :"
        Me.GeneralLabel5.Size = New System.Drawing.Size(131, 26)
        Me.GeneralLabel5.TabIndex = 55
        Me.GeneralLabel5.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.DataGridView1.Location = New System.Drawing.Point(277, 204)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Size = New System.Drawing.Size(421, 212)
        Me.DataGridView1.TabIndex = 50
        Me.DataGridView1.TabStop = False
        '
        'GeneralLabel4
        '
        Me.GeneralLabel4.BackColor = System.Drawing.Color.Transparent
        Me.GeneralLabel4.BackgroundImage = CType(resources.GetObject("GeneralLabel4.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel4.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel4.IsRequired = True
        Me.GeneralLabel4.Location = New System.Drawing.Point(567, 172)
        Me.GeneralLabel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel4.Name = "GeneralLabel4"
        Me.GeneralLabel4.SetLabelTxt = "ﬁÌ„… «·„ﬂ«›√… :"
        Me.GeneralLabel4.Size = New System.Drawing.Size(131, 26)
        Me.GeneralLabel4.TabIndex = 53
        Me.GeneralLabel4.TabStop = False
        '
        'RewardValue
        '
        Me.RewardValue.DecimalPlaces = 2
        Me.RewardValue.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RewardValue.Location = New System.Drawing.Point(277, 172)
        Me.RewardValue.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.RewardValue.Name = "RewardValue"
        Me.RewardValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RewardValue.Size = New System.Drawing.Size(283, 26)
        Me.RewardValue.TabIndex = 5
        Me.RewardValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GeneralLabel3
        '
        Me.GeneralLabel3.BackColor = System.Drawing.Color.Transparent
        Me.GeneralLabel3.BackgroundImage = CType(resources.GetObject("GeneralLabel3.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel3.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel3.IsRequired = False
        Me.GeneralLabel3.Location = New System.Drawing.Point(567, 138)
        Me.GeneralLabel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel3.Name = "GeneralLabel3"
        Me.GeneralLabel3.SetLabelTxt = " «—ÌŒ «·„ﬂ«›√… :"
        Me.GeneralLabel3.Size = New System.Drawing.Size(131, 25)
        Me.GeneralLabel3.TabIndex = 52
        Me.GeneralLabel3.TabStop = False
        '
        'RewardDate
        '
        Me.RewardDate.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RewardDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.RewardDate.Location = New System.Drawing.Point(277, 138)
        Me.RewardDate.Name = "RewardDate"
        Me.RewardDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RewardDate.RightToLeftLayout = True
        Me.RewardDate.Size = New System.Drawing.Size(283, 26)
        Me.RewardDate.TabIndex = 4
        '
        'EmployeeID
        '
        Me.EmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmployeeID.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmployeeID.FormattingEnabled = True
        Me.EmployeeID.Location = New System.Drawing.Point(277, 69)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EmployeeID.Size = New System.Drawing.Size(283, 26)
        Me.EmployeeID.TabIndex = 2
        '
        'Reason
        '
        Me.Reason.BackColor = System.Drawing.Color.Transparent
        Me.Reason.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reason.IsEmail = False
        Me.Reason.IsNum = False
        Me.Reason.IsRequired = False
        Me.Reason.Location = New System.Drawing.Point(277, 104)
        Me.Reason.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Reason.Name = "Reason"
        Me.Reason.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Reason.SetLeaveColor = System.Drawing.Color.Red
        Me.Reason.Size = New System.Drawing.Size(283, 26)
        Me.Reason.TabIndex = 3
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BackColor = System.Drawing.Color.Transparent
        Me.GeneralLabel1.BackgroundImage = CType(resources.GetObject("GeneralLabel1.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel1.IsRequired = True
        Me.GeneralLabel1.Location = New System.Drawing.Point(567, 70)
        Me.GeneralLabel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.SetLabelTxt = "«”„ «·„ÊŸ› :"
        Me.GeneralLabel1.Size = New System.Drawing.Size(131, 25)
        Me.GeneralLabel1.TabIndex = 51
        Me.GeneralLabel1.TabStop = False
        '
        'GeneralLabel2
        '
        Me.GeneralLabel2.BackColor = System.Drawing.Color.Transparent
        Me.GeneralLabel2.BackgroundImage = CType(resources.GetObject("GeneralLabel2.BackgroundImage"), System.Drawing.Image)
        Me.GeneralLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralLabel2.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel2.IsRequired = True
        Me.GeneralLabel2.Location = New System.Drawing.Point(567, 103)
        Me.GeneralLabel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GeneralLabel2.Name = "GeneralLabel2"
        Me.GeneralLabel2.SetLabelTxt = "«·”»» :"
        Me.GeneralLabel2.Size = New System.Drawing.Size(131, 27)
        Me.GeneralLabel2.TabIndex = 48
        Me.GeneralLabel2.TabStop = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.BackgroundImage = Global.StandardClothes.My.Resources.Resources.exit_22
        Me.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(727, 346)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnExit.Size = New System.Drawing.Size(151, 57)
        Me.BtnExit.TabIndex = 82
        Me.BtnExit.TabStop = False
        Me.BtnExit.Text = "Œ—ÊÃ F6"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnSearch
        '
        Me.BtnSearch.BackColor = System.Drawing.Color.Transparent
        Me.BtnSearch.BackgroundImage = Global.StandardClothes.My.Resources.Resources.edit_1_19
        Me.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSearch.FlatAppearance.BorderSize = 0
        Me.BtnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(727, 220)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnSearch.Size = New System.Drawing.Size(151, 57)
        Me.BtnSearch.TabIndex = 81
        Me.BtnSearch.TabStop = False
        Me.BtnSearch.Text = " ⁄œÌ· F4"
        Me.BtnSearch.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = Global.StandardClothes.My.Resources.Resources.save_18_18
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(727, 157)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnSave.Size = New System.Drawing.Size(151, 57)
        Me.BtnSave.TabIndex = 80
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "Õ›Ÿ F3"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnNew.BackgroundImage = Global.StandardClothes.My.Resources.Resources.without_text_16
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.Location = New System.Drawing.Point(727, 94)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnNew.Size = New System.Drawing.Size(151, 57)
        Me.BtnNew.TabIndex = 79
        Me.BtnNew.TabStop = False
        Me.BtnNew.Text = "ÃœÌœ F2"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.BackgroundImage = Global.StandardClothes.My.Resources.Resources.delete_1_21
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Location = New System.Drawing.Point(727, 283)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnDelete.Size = New System.Drawing.Size(151, 57)
        Me.BtnDelete.TabIndex = 96
        Me.BtnDelete.TabStop = False
        Me.BtnDelete.Text = "Õ–› F5"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(136, 527)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(111, 19)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "⁄œœ «·”Ã·«  :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnLast
        '
        Me.BtnLast.BackColor = System.Drawing.Color.Transparent
        Me.BtnLast.BackgroundImage = Global.StandardClothes.My.Resources.Resources.master_16
        Me.BtnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnLast.FlatAppearance.BorderSize = 0
        Me.BtnLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLast.Location = New System.Drawing.Point(271, 530)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(16, 16)
        Me.BtnLast.TabIndex = 102
        Me.BtnLast.TabStop = False
        Me.BtnLast.Text = "œŒÊ·"
        Me.BtnLast.UseVisualStyleBackColor = False
        '
        'BtnNext
        '
        Me.BtnNext.BackColor = System.Drawing.Color.Transparent
        Me.BtnNext.BackgroundImage = Global.StandardClothes.My.Resources.Resources.master_18
        Me.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNext.FlatAppearance.BorderSize = 0
        Me.BtnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.Location = New System.Drawing.Point(305, 530)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(16, 16)
        Me.BtnNext.TabIndex = 101
        Me.BtnNext.TabStop = False
        Me.BtnNext.Text = "œŒÊ·"
        Me.BtnNext.UseVisualStyleBackColor = False
        '
        'OrderByCombo
        '
        Me.OrderByCombo.BackColor = System.Drawing.Color.Gainsboro
        Me.OrderByCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OrderByCombo.FormattingEnabled = True
        Me.OrderByCombo.Location = New System.Drawing.Point(334, 529)
        Me.OrderByCombo.Name = "OrderByCombo"
        Me.OrderByCombo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.OrderByCombo.Size = New System.Drawing.Size(151, 21)
        Me.OrderByCombo.TabIndex = 100
        Me.OrderByCombo.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.ForeColor = System.Drawing.Color.White
        Me.UsernameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsernameLabel.Location = New System.Drawing.Point(491, 527)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(56, 19)
        Me.UsernameLabel.TabIndex = 99
        Me.UsernameLabel.Text = "«· — Ì»"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnPrevious
        '
        Me.BtnPrevious.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrevious.BackgroundImage = Global.StandardClothes.My.Resources.Resources.master_18_copy
        Me.BtnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrevious.FlatAppearance.BorderSize = 0
        Me.BtnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrevious.Location = New System.Drawing.Point(553, 530)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(16, 16)
        Me.BtnPrevious.TabIndex = 98
        Me.BtnPrevious.TabStop = False
        Me.BtnPrevious.Text = "œŒÊ·"
        Me.BtnPrevious.UseVisualStyleBackColor = False
        '
        'BtnFirst
        '
        Me.BtnFirst.BackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.BackgroundImage = Global.StandardClothes.My.Resources.Resources.master_16_copy
        Me.BtnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFirst.FlatAppearance.BorderSize = 0
        Me.BtnFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFirst.Location = New System.Drawing.Point(587, 530)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(16, 16)
        Me.BtnFirst.TabIndex = 97
        Me.BtnFirst.TabStop = False
        Me.BtnFirst.Text = "œŒÊ·"
        Me.BtnFirst.UseVisualStyleBackColor = False
        '
        'CountRecords
        '
        Me.CountRecords.BackColor = System.Drawing.Color.Transparent
        Me.CountRecords.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountRecords.ForeColor = System.Drawing.Color.White
        Me.CountRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CountRecords.Location = New System.Drawing.Point(80, 526)
        Me.CountRecords.Name = "CountRecords"
        Me.CountRecords.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CountRecords.Size = New System.Drawing.Size(59, 19)
        Me.CountRecords.TabIndex = 104
        Me.CountRecords.Text = "0"
        Me.CountRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(37, 5)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(119, 64)
        Me.PictureBox5.TabIndex = 97
        Me.PictureBox5.TabStop = False
        '
        'BtnFile
        '
        Me.BtnFile.BackColor = System.Drawing.Color.Transparent
        Me.BtnFile.BackgroundImage = Global.StandardClothes.My.Resources.Resources.master_09Selected
        Me.BtnFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFile.FlatAppearance.BorderSize = 0
        Me.BtnFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFile.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFile.Location = New System.Drawing.Point(561, 12)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(126, 57)
        Me.BtnFile.TabIndex = 105
        Me.BtnFile.TabStop = False
        Me.BtnFile.UseVisualStyleBackColor = False
        '
        'BtnData
        '
        Me.BtnData.BackColor = System.Drawing.Color.Transparent
        Me.BtnData.BackgroundImage = Global.StandardClothes.My.Resources.Resources.master_05
        Me.BtnData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnData.FlatAppearance.BorderSize = 0
        Me.BtnData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnData.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnData.Location = New System.Drawing.Point(426, 12)
        Me.BtnData.Name = "BtnData"
        Me.BtnData.Size = New System.Drawing.Size(126, 57)
        Me.BtnData.TabIndex = 106
        Me.BtnData.TabStop = False
        Me.BtnData.UseVisualStyleBackColor = False
        '
        'BtnHelp
        '
        Me.BtnHelp.BackColor = System.Drawing.Color.Transparent
        Me.BtnHelp.BackgroundImage = Global.StandardClothes.My.Resources.Resources.master_03
        Me.BtnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnHelp.FlatAppearance.BorderSize = 0
        Me.BtnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnHelp.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHelp.Location = New System.Drawing.Point(291, 12)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(126, 57)
        Me.BtnHelp.TabIndex = 107
        Me.BtnHelp.TabStop = False
        Me.BtnHelp.UseVisualStyleBackColor = False
        '
        'BtnReload
        '
        Me.BtnReload.BackColor = System.Drawing.Color.Transparent
        Me.BtnReload.BackgroundImage = Global.StandardClothes.My.Resources.Resources.without_texte_2_16
        Me.BtnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnReload.FlatAppearance.BorderSize = 0
        Me.BtnReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReload.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReload.Location = New System.Drawing.Point(727, 94)
        Me.BtnReload.Name = "BtnReload"
        Me.BtnReload.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnReload.Size = New System.Drawing.Size(151, 57)
        Me.BtnReload.TabIndex = 108
        Me.BtnReload.TabStop = False
        Me.BtnReload.Text = " Õ„Ì·"
        Me.BtnReload.UseVisualStyleBackColor = False
        Me.BtnReload.Visible = False
        '
        'BtnCancelSerach
        '
        Me.BtnCancelSerach.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancelSerach.BackgroundImage = Global.StandardClothes.My.Resources.Resources.save_2_18
        Me.BtnCancelSerach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCancelSerach.FlatAppearance.BorderSize = 0
        Me.BtnCancelSerach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnCancelSerach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnCancelSerach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelSerach.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelSerach.Location = New System.Drawing.Point(727, 157)
        Me.BtnCancelSerach.Name = "BtnCancelSerach"
        Me.BtnCancelSerach.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnCancelSerach.Size = New System.Drawing.Size(151, 57)
        Me.BtnCancelSerach.TabIndex = 109
        Me.BtnCancelSerach.TabStop = False
        Me.BtnCancelSerach.Text = "»ÕÀ ⁄«„"
        Me.BtnCancelSerach.UseVisualStyleBackColor = False
        Me.BtnCancelSerach.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAllCommands})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(913, 24)
        Me.MenuStrip1.TabIndex = 743
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'MenuAllCommands
        '
        Me.MenuAllCommands.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuNew, Me.MenuSave, Me.MenuSearch, Me.MenuDelete, Me.MenuExit})
        Me.MenuAllCommands.Name = "MenuAllCommands"
        Me.MenuAllCommands.Size = New System.Drawing.Size(84, 20)
        Me.MenuAllCommands.Text = "AllComands"
        '
        'MenuNew
        '
        Me.MenuNew.Name = "MenuNew"
        Me.MenuNew.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.MenuNew.Size = New System.Drawing.Size(126, 22)
        Me.MenuNew.Text = "New"
        '
        'MenuSave
        '
        Me.MenuSave.Name = "MenuSave"
        Me.MenuSave.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.MenuSave.Size = New System.Drawing.Size(126, 22)
        Me.MenuSave.Text = "Save"
        '
        'MenuSearch
        '
        Me.MenuSearch.Name = "MenuSearch"
        Me.MenuSearch.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.MenuSearch.Size = New System.Drawing.Size(126, 22)
        Me.MenuSearch.Text = "Edit"
        '
        'MenuDelete
        '
        Me.MenuDelete.Name = "MenuDelete"
        Me.MenuDelete.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MenuDelete.Size = New System.Drawing.Size(126, 22)
        Me.MenuDelete.Text = "Delete"
        '
        'MenuExit
        '
        Me.MenuExit.Name = "MenuExit"
        Me.MenuExit.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.MenuExit.Size = New System.Drawing.Size(126, 22)
        Me.MenuExit.Text = "Exit"
        '
        'EmployeesRewards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.StandardClothes.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(913, 561)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ContentPanel)
        Me.Controls.Add(Me.BtnCancelSerach)
        Me.Controls.Add(Me.BtnReload)
        Me.Controls.Add(Me.BtnHelp)
        Me.Controls.Add(Me.BtnData)
        Me.Controls.Add(Me.BtnFile)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.CountRecords)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLast)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.OrderByCombo)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.BtnPrevious)
        Me.Controls.Add(Me.BtnFirst)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnNew)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EmployeesRewards"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "«·„œÌ‰…"
        Me.ContentPanel.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RewardValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnLast As System.Windows.Forms.Button
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents OrderByCombo As System.Windows.Forms.ComboBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents BtnPrevious As System.Windows.Forms.Button
    Friend WithEvents BtnFirst As System.Windows.Forms.Button
    Friend WithEvents CountRecords As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnFile As System.Windows.Forms.Button
    Friend WithEvents BtnData As System.Windows.Forms.Button
    Friend WithEvents BtnHelp As System.Windows.Forms.Button
    Friend WithEvents BtnReload As System.Windows.Forms.Button
    Friend WithEvents BtnCancelSerach As System.Windows.Forms.Button
    Friend WithEvents CategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents GeneralLabel5 As StandardClothes.GeneralLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GeneralLabel4 As StandardClothes.GeneralLabel
    Friend WithEvents RewardValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents GeneralLabel3 As StandardClothes.GeneralLabel
    Friend WithEvents RewardDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents EmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents Reason As StandardClothes.GeneralTextBox
    Friend WithEvents GeneralLabel1 As StandardClothes.GeneralLabel
    Friend WithEvents GeneralLabel2 As StandardClothes.GeneralLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuAllCommands As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuExit As System.Windows.Forms.ToolStripMenuItem
End Class
