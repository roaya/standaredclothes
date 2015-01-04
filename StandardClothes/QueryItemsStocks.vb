Public Class QueryItemsStocks

    Dim tblstock As New GeneralDataSet.StocksDataTable
    Dim tblcategory As New GeneralDataSet.CategoriesDataTable
    Dim tblcorporation As New GeneralDataSet.CorporationsDataTable
    Dim tbltypes As New GeneralDataSet.Items_TypesDataTable
    Dim tblitems As New GeneralDataSet.ItemsDataTable

    Private Sub QueryItemsStocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        DataGridView1.DataSource = MyDs.Tables("Query_Items_Stocks")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).HeaderText = "«”„ «·„Œ“‰"
        DataGridView1.Columns(3).HeaderText = "«·»‰œ"
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(4).HeaderText = "«·›∆Â"
        DataGridView1.Columns(5).HeaderText = "«·‘—ﬂÂ"
        DataGridView1.Columns(7).HeaderText = "«”„ «·’‰›"
        DataGridView1.Columns(8).HeaderText = "«·»«—ﬂÊœ"
        DataGridView1.Columns(9).HeaderText = "«·—’Ìœ"
        DataGridView1.Columns(10).Visible = False
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(12).Visible = False
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MyDs.Tables("Query_Items_Stocks").Rows.Clear()
        Try
            If RadStock.Checked = True Then

                If CmbStockID.Text = "" Then
                    cls.MsgExclamation("√œŒ· «”„ «·„Œ“‰")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_Items_Stocks where stock_id=" & CmbStockID.SelectedValue


                End If


            ElseIf RadCategory.Checked = True Then

                If CmbCategory.Text = "" Then
                    cls.MsgExclamation("√œŒ· «”„ «·»‰œ")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_Items_Stocks where category_id=" & CmbCategory.SelectedValue


                End If

            ElseIf RadCorporation.Checked = True Then

                If CmbCorporation.Text = "" Then
                    cls.MsgExclamation("√œŒ· «”„ «·‘—ﬂÂ")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_Items_Stocks where Corporation_id=" & CmbCorporation.SelectedValue
                End If

            ElseIf RadType.Checked = True Then

                If cmbType.Text = "" Then
                    cls.MsgExclamation("√œŒ· «·›∆Â")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_Items_Stocks where type_id=" & cmbType.SelectedValue
                End If
            ElseIf RadItemName.Checked = True Then

                If CmbItem.Text = "" Then
                    cls.MsgExclamation("√œŒ· «”„ «·’‰›")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_Items_Stocks where item_id=" & CmbItem.SelectedValue


                End If
            Else

                If TxtBarcode.Text = "" Then
                    cls.MsgExclamation("√œŒ· «·»«—ﬂÊœ")
                    Exit Sub
                Else
                    cmd.CommandText = "select * FROM Query_Items_Stocks where barcode =N'" & TxtBarcode.Text & "'"


                End If

            End If
            da.Fill(MyDs.Tables("Query_Items_Stocks"))

            If MyDs.Tables("Query_Items_Stocks").Rows.Count > 0 Then

                DataGridView1.DataSource = MyDs.Tables("Query_Items_Stocks")
                TabControl1.SelectTab(1)
            Else
                MsgBox("·«  ÊÃœ »Ì«‰« ")
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