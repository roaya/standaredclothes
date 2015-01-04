Public Class Items

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceItems As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Items"
    Dim tbl1 As New GeneralDataSet.CategoriesDataTable
    Dim tbl2 As New GeneralDataSet.Items_TypesDataTable
    Dim tbl3 As New GeneralDataSet.Item_SizesDataTable
    Dim tbl4 As New GeneralDataSet.GenderDataTable
    Dim tbl5 As New GeneralDataSet.AgesDataTable
    Dim tbl6 As New GeneralDataSet.CorporationsDataTable

    Public SearchItemID As Integer = 0


    '-------------------------------

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            MasterField1.TextBox1.MaxLength = 50

            cls.RefreshData(TName)
            cls.RefreshData("select * from  Categories", tbl1)
            cls.RefreshData("select * from Items_Types", tbl2)
            cls.RefreshData("select * from  Item_Sizes", tbl3)
            cls.RefreshData(" select * from Gender", tbl4)
            cls.RefreshData("select * FROM  Ages", tbl5)
            cls.RefreshData("select * from  Corporations", tbl6)
            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.DataSource = B
            OrderByCombo.DisplayMember = "Logical_Name"
            OrderByCombo.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceItems, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords, MenuNew, MenuSave, MenuDelete, MenuSearch, MenuExit)
            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            Gcls.SetWTitle = "«·«’‰«›"
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BSourceItems, "Item_Name")
            BarCode.DataBindings.Add("Text", BSourceItems, "BarCode")
            SalePrice.DataBindings.Add("Value", BSourceItems, "Sale_Price")
            SaleTotalPrice.DataBindings.Add("Value", BSourceItems, "Sale_Total_Price")
            PurchasePrice.DataBindings.Add("Value", BSourceItems, "Purchase_Price")
            AlertBalance.DataBindings.Add("Value", BSourceItems, "Alert_Balance")
            OrderBalance.DataBindings.Add("Value", BSourceItems, "Order_Balance")
            'MinOrder.DataBindings.Add("Value", BSourceItems, "Min_Order")
            SeasonType.DataBindings.Add("Text", BSourceItems, "Season_Type")
            Photo.DataBindings.Add("backgroundImage", BSourceItems, "Photo", True)

            CategoryID.DataSource = tbl1
            CategoryID.DisplayMember = "Category_Name"
            CategoryID.ValueMember = "Category_ID"
            CategoryID.DataBindings.Add("SelectedValue", BSourceItems, "Category_ID")

            SizeID.DataSource = tbl3
            SizeID.DisplayMember = "Size_Name"
            SizeID.ValueMember = "Size_ID"
            SizeID.DataBindings.Add("SelectedValue", BSourceItems, "Size_ID")

            TypeID.DataSource = tbl2
            TypeID.DisplayMember = "Type_Name"
            TypeID.ValueMember = "Type_ID"
            TypeID.DataBindings.Add("SelectedValue", BSourceItems, "Type_ID")

            AgeID.DataSource = tbl5
            AgeID.DisplayMember = "Age_Desc"
            AgeID.ValueMember = "Age_ID"
            AgeID.DataBindings.Add("SelectedValue", BSourceItems, "Age_ID")

            CorporationID.DataSource = tbl6
            CorporationID.DisplayMember = "Corporation_Name"
            CorporationID.ValueMember = "Corporation_ID"
            CorporationID.DataBindings.Add("SelectedValue", BSourceItems, "Corporation_ID")

            GenderID.DataSource = tbl4
            GenderID.DisplayMember = "Gender_Name"
            GenderID.ValueMember = "Gender_ID"
            GenderID.DataBindings.Add("SelectedValue", BSourceItems, "Gender_ID")

            SSource = BSourceItems


            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Item_Name"

            B_EndLoad = True

            If SearchItemID <> 0 Then
                BSourceItems.Filter = "Item_ID = " & SearchItemID
            End If

            Me.Cursor = Cursors.Default



        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click
        Try
            Gcls.NewRecord()
            MasterField1.TextBox1.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click
        Try
            If MasterField1.TextBox1.Text = "" Then
                cls.MsgComplete()
                MasterField1.TextBox1.Focus()
                MasterField1.TextBox1.BackColor = Color.Red


            ElseIf BarCode.Text = "" Then
                cls.MsgComplete()
                BarCode.Focus()
                BarCode.BackColor = Color.Red

            ElseIf CategoryID.Text = "" Then
                cls.MsgComplete()
                CategoryID.Focus()

            ElseIf SizeID.Text = "" Then
                cls.MsgComplete()
                SizeID.Focus()

            ElseIf TypeID.Text = "" Then
                cls.MsgComplete()
                TypeID.Focus()

            ElseIf CorporationID.Text = "" Then
                cls.MsgComplete()
                CorporationID.Focus()

            ElseIf AgeID.Text = "" Then
                cls.MsgComplete()
                AgeID.Focus()

            ElseIf GenderID.Text = "" Then
                cls.MsgComplete()
                GenderID.Focus()

            ElseIf SeasonType.Text = "" Then
                cls.MsgComplete()
                SeasonType.Focus()

            Else
                Gcls.SaveRecord()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuDelete.Click
        Try
            Gcls.DeleteRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            Gcls.LastRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Try
            Gcls.NextRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        Try
            Gcls.PreviousRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirst.Click
        Try
            Gcls.FirstRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click, MenuSearch.Click
        Try
            Gcls.EditRecord()
            MasterField1.TextBox1.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    'Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CutData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CopyData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.PasteData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    Private Sub OrderByCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderByCombo.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                Gcls.SortData(BSourceItems, OrderByCombo.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Try
            Gcls.ExitForm()
            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Gcls.ReloadData()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelSerach.Click
        Try
            BSourceItems.RemoveFilter()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Gcls.BtnFile()
    End Sub

    Private Sub BtnData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnData.Click
        Gcls.BtnData()
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click
        Gcls.BtnHelp()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Dim Fpath As String = ""
l:
            OpenFileDialog1.Title = "«Œ — ’Ê—… ·⁄—÷Â« ⁄·Ì «·‰«›–…"
            OpenFileDialog1.Filter = "Image Files|*.JPG;*.JPEG;*.png;*.Gif;"
            If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
                If MsgBox("·„ Ì „ «Œ Ì«— «·’Ê—… Â·  —Ìœ «⁄«œ… «·«Œ Ì«— ø", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = DialogResult.Yes Then
                    GoTo l
                End If
            Else
                Fpath = OpenFileDialog1.FileName
            End If
            Photo.BackgroundImage = Image.FromFile(Fpath)
        Catch ex As Exception
            Dim s As String = ""
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Photo.BackgroundImage = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim M As New ItemSizes
        M.ShowDialog()

        cls.RefreshData("select * from  Item_Sizes", tbl3)
       
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim M As New ItemTypes
        M.ShowDialog()
        cls.RefreshData("select * from Items_Types", tbl2)
       
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim M As New Ages
        M.ShowDialog()
    

        cls.RefreshData("select * FROM  Ages", tbl5)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim M As New Corporations
        M.ShowDialog()
 
        cls.RefreshData("select * from  Corporations", tbl6)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New Stocks
        m.ShowDialog()
       
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New Categories
        m.ShowDialog()
        cls.RefreshData("select * from  Categories", tbl1)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New FirstBalanceStock
        m.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim M As New ItemsStocks
        M.ShowDialog()
    End Sub

    


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim m As New Gender
        m.ShowDialog()
      
        cls.RefreshData(" select * from Gender", tbl4)
       
    End Sub
    Private Sub barcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.GotFocus
        BarCode.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub barcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        BarCode.BackColor = Color.White
    End Sub
    Private Sub PurchasePrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PurchasePrice.GotFocus
        PurchasePrice.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub PurchasePrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PurchasePrice.Leave
        PurchasePrice.BackColor = Color.white
    End Sub
    Private Sub SalePrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SalePrice.GotFocus
        SalePrice.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub SalePrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SalePrice.Leave
        SalePrice.BackColor = Color.White
    End Sub

    Private Sub SaleTotalPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaleTotalPrice.GotFocus
        SaleTotalPrice.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub SaleTotalPrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaleTotalPrice.Leave
        SaleTotalPrice.BackColor = Color.White
    End Sub
    Private Sub AlertBalance_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlertBalance.GotFocus
        AlertBalance.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub AlertBalance_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlertBalance.Leave
        AlertBalance.BackColor = Color.White
    End Sub
    Private Sub OrderBalance_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderBalance.GotFocus
        OrderBalance.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub OrderBalance_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderBalance.Leave
        OrderBalance.BackColor = Color.White
    End Sub
End Class
