Public Class QueryAllItem2
    
    Dim QueryAllItems As New GeneralDataSet.Query_All_ItemsDataTable
    '-------------------------------
    'Set The Data Table Name
    Dim tblstock As New GeneralDataSet.StocksDataTable
    Dim tblcategory As New GeneralDataSet.CategoriesDataTable
    Dim tblcorporation As New GeneralDataSet.CorporationsDataTable
    Dim tbltypes As New GeneralDataSet.Items_TypesDataTable
    Dim tblitems As New GeneralDataSet.ItemsDataTable
    Private Sub QueryByEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from stocks", tblstock)
        cls.RefreshData("select * from categories", tblcategory)
        cls.RefreshData("select * from corporations", tblcorporation)
        cls.RefreshData("select * from items_types", tbltypes)
        cls.RefreshData("select * from items", tblitems)

        CmbStockID.DataSource = tblstock
        CmbStockID.DisplayMember = "stock_name"
        CmbStockID.ValueMember = "stock_id"

        CmbCategory.DataSource = tblcategory
        CmbCategory.DisplayMember = "category_name"
        CmbCategory.ValueMember = "category_id"


        cmbType.DataSource = tbltypes
        cmbType.DisplayMember = "type_name"
        cmbType.ValueMember = "type_id"

        CmbCorporation.DataSource = tblcorporation
        CmbCorporation.DisplayMember = "corporation_name"
        CmbCorporation.ValueMember = "corporation_id"

        CmbItem.DataSource = tblitems
        CmbItem.DisplayMember = "item_name"
        CmbItem.ValueMember = "item_id"



        DataGridView1.DataSource = MyDs.Tables("Query_All_Items")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False
        DataGridView1.Columns(10).Visible = False
        DataGridView1.Columns(11).Visible = False

        DataGridView1.Columns(12).Visible = False
        DataGridView1.Columns(13).Visible = False
        DataGridView1.Columns(14).Visible = False
        DataGridView1.Columns(16).Visible = False
        DataGridView1.Columns(17).Visible = False
        DataGridView1.Columns(18).Visible = False
        DataGridView1.Columns(19).Visible = False


     
        DataGridView1.Columns(20).Visible = False


        DataGridView1.Columns(28).Visible = False
        DataGridView1.Columns(29).Visible = False
        DataGridView1.Columns(30).Visible = False
        DataGridView1.Columns(33).Visible = False
        DataGridView1.Columns(31).Visible = False
        DataGridView1.Columns(35).Visible = False


        DataGridView1.Columns(3).HeaderText = "البند"
        DataGridView1.Columns(5).HeaderText = "الشركه"

        DataGridView1.Columns(9).HeaderText = "النوع"

        DataGridView1.Columns(15).HeaderText = "المقاس"

        DataGridView1.Columns(7).HeaderText = "الفئه"
        DataGridView1.Columns(1).HeaderText = "اسم المخزن"
        DataGridView1.Columns(21).HeaderText = "اسم الصنف"
        DataGridView1.Columns(22).HeaderText = "الباركود"

        DataGridView1.Columns(23).HeaderText = "سعر الشراء"
        DataGridView1.Columns(24).HeaderText = "سعر البيع"
        DataGridView1.Columns(26).HeaderText = "حدالتحذير"
        DataGridView1.Columns(27).HeaderText = "اعاده الطلب"

        DataGridView1.Columns(32).HeaderText = "الرصيد"
        DataGridView1.Columns(34).HeaderText = "اسم المورد"

        DataGridView1.Columns(25).HeaderText = "سعر الجمله"
        DataGridView1.Columns(16).HeaderText = "اللون"

        DataGridView1.Columns(17).HeaderText = "الموديل"

        DataGridView1.Columns(18).HeaderText = "بلد المنشأ"
        DataGridView1.Columns(19).HeaderText = "الماده الخام"










    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyDs.Tables("Query_All_Items").Rows.Clear()
        Try
            If RadStock.Checked = True Then

                If CmbStockID.Text = "" Then
                    cls.MsgExclamation("أدخل اسم المخزن")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_All_Items where stock_id=" & CmbStockID.SelectedValue


                End If


            ElseIf RadCategory.Checked = True Then

                If CmbCategory.Text = "" Then
                    cls.MsgExclamation("أدخل اسم البند")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_All_Items where category_id=" & CmbCategory.SelectedValue


                End If

            ElseIf RadCorporation.Checked = True Then

                If CmbCorporation.Text = "" Then
                    cls.MsgExclamation("أدخل اسم الشركه")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_All_Items where Corporation_id=" & CmbCorporation.SelectedValue
                End If

            ElseIf RadType.Checked = True Then

                If cmbType.Text = "" Then
                    cls.MsgExclamation("أدخل الفئه")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_All_Items where type_id=" & cmbType.SelectedValue
                End If
            ElseIf RadItemName.Checked = True Then

                If CmbItem.Text = "" Then
                    cls.MsgExclamation("أدخل اسم الصنف")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_All_Items where item_id=" & CmbItem.SelectedValue


                End If
            Else

                If TxtBarcode.Text = "" Then
                    cls.MsgExclamation("أدخل الباركود")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_All_Items where barcode =N'" & TxtBarcode.Text & "'"


                End If

            End If
            da.Fill(MyDs.Tables("Query_All_Items"))

            If MyDs.Tables("Query_All_Items").Rows.Count > 0 Then

                DataGridView1.DataSource = MyDs.Tables("Query_All_Items")
                TabControl1.SelectTab(1)
            Else
                MsgBox("لا توجد بيانات")
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, "Q by Item name")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub RadStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadStock.CheckedChanged
        If RadStock.Checked = True Then
            CmbStockID.Enabled = True
            CmbCategory.Enabled = False
            CmbCorporation.Enabled = False
            CmbItem.Enabled = False
            TxtBarcode.Enabled = False
            cmbType.Enabled = False
        End If
    End Sub

    Private Sub RadCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCategory.CheckedChanged
        If RadCategory.Checked = True Then
            CmbStockID.Enabled = False
            CmbCategory.Enabled = True
            CmbCorporation.Enabled = False
            CmbItem.Enabled = False
            TxtBarcode.Enabled = False
            cmbType.Enabled = False
        End If
    End Sub

    Private Sub RadCorporation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCorporation.CheckedChanged
        If RadCorporation.Checked = True Then
            CmbStockID.Enabled = False
            CmbCategory.Enabled = False
            CmbCorporation.Enabled = True
            CmbItem.Enabled = False
            TxtBarcode.Enabled = False
            cmbType.Enabled = False
        End If
    End Sub

    Private Sub RadType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadType.CheckedChanged
        If RadType.Checked = True Then
            CmbStockID.Enabled = False
            CmbCategory.Enabled = False
            CmbCorporation.Enabled = False
            CmbItem.Enabled = False
            TxtBarcode.Enabled = False
            cmbType.Enabled = True
        End If
    End Sub

    Private Sub RadItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadItemName.CheckedChanged
        If RadItemName.Checked = True Then
            CmbStockID.Enabled = False
            CmbCategory.Enabled = False
            CmbCorporation.Enabled = False
            CmbItem.Enabled = True
            TxtBarcode.Enabled = False
            cmbType.Enabled = False
        End If
    End Sub

    Private Sub RadBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBarcode.CheckedChanged
        If RadBarcode.Checked = True Then
            CmbStockID.Enabled = False
            CmbCategory.Enabled = False
            CmbCorporation.Enabled = False
            CmbItem.Enabled = False
            TxtBarcode.Enabled = True
            cmbType.Enabled = False
        End If
    End Sub
End Class