Public Class FirstBalanceStock

    Dim B_EndLoad As Boolean = False
    Dim BSourceItemsStocks As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Items_Stocks"
    '-------------------------------
    Dim cmdb As New SqlClient.SqlCommandBuilder
    Public BSourceGenders As New BindingSource
    Dim tbl As New GeneralDataSet.StocksDataTable
    Dim tbl2 As New GeneralDataSet.CategoriesDataTable
    Dim tbl3 As New GeneralDataSet.CorporationsDataTable
    Dim tbl4 As New GeneralDataSet.Items_TypesDataTable



    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            'OrderByCombo.ComboBox.DataSource = B
            'OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            'OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            
            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            cls.RefreshData("select * from stocks", tbl)
            cls.RefreshData("select * from categories", tbl2)
            cls.RefreshData("select * from corporations", tbl3)
            cls.RefreshData("select * from items_types", tbl4)

            StockID.DataSource = tbl
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"

            CategoryID.DataSource = tbl2
            CategoryID.DisplayMember = "category_Name"
            CategoryID.ValueMember = "category_ID"


            TypeID.DataSource = tbl4
            TypeID.DisplayMember = "type_Name"
            TypeID.ValueMember = "type_ID"


            CorpID.DataSource = tbl3
            CorpID.DisplayMember = "corporation_Name"
            CorpID.ValueMember = "corporation_ID"


            BSourceItemsStocks.DataSource = MyDs
            BSourceItemsStocks.DataMember = "Items_Stocks"

            MyDs.Tables("Items_Stocks").Rows.Clear()

            DataGridView1.DataSource = BSourceItemsStocks
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "ÇÓã ÇáÕäÝ"
            DataGridView1.Columns(3).HeaderText = "ÇáÈÇÑßæÏ"
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).HeaderText = "ÇÓã ÇáãÍá"
            DataGridView1.Columns(6).HeaderText = "ÇáÑÕíÏ"

            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(5).ReadOnly = True
            '---------------------------
            'DataGridView1.DataSource = BSourceItemsStocks
            'DataGridView1.Columns(0).Visible = False
            'DataGridView1.Columns(8).Visible = False
            'DataGridView1.Columns(9).Visible = False
            'DataGridView1.Columns(10).Visible = False
            'DataGridView1.Columns(11).Visible = False
            'DataGridView1.Columns(12).Visible = False

            'DataGridView1.Columns(5).HeaderText = "ÇÓã ÇáÕäÝ"
            'DataGridView1.Columns(6).HeaderText = "ÇáÈÇÑßæÏ"

            'DataGridView1.Columns(1).HeaderText = "ÇÓã ÇáãÍá"
            'DataGridView1.Columns(7).HeaderText = "ÇáÑÕíÏ"
            'DataGridView1.Columns(2).HeaderText = "ÇáÈäÏ"
            'DataGridView1.Columns(3).HeaderText = "ÇáÝÆå"
            'DataGridView1.Columns(4).HeaderText = "ÇáÔÑßå"



            'DataGridView1.Columns(1).ReadOnly = True
            'DataGridView1.Columns(2).ReadOnly = True
            'DataGridView1.Columns(3).ReadOnly = True

            'DataGridView1.Columns(4).ReadOnly = True
            'DataGridView1.Columns(5).ReadOnly = True
            'DataGridView1.Columns(6).ReadOnly = True
            SSource = BSourceGenders

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            MyDs.Tables("Items_Stocks").Rows.Clear()
            If StockName.Checked = True Then
                If StockID.Text = "" Then
                    cls.MsgExclamation("ÃÏÎá ÇÓã ÇáãÍá")
                    Exit Sub
                Else

                    cmd.CommandText = "select serial_pk,item_id,item_name,barcode,stock_id,stock_name,balance from Query_Items_Stocks where stock_id = " & StockID.SelectedValue
                  
                End If

            ElseIf TypeName.Checked = True Then

                If TypeID.Text = "" Then
                    cls.MsgExclamation("ÃÏÎá ÇÓã ÇáÝÆå")
                    Exit Sub
                Else
                    cmd.CommandText = "select serial_pk,item_id,item_name,barcode,stock_id,stock_name,balance from Query_Items_Stocks where type_id = " & TypeID.SelectedValue


                End If

            ElseIf CategoryName.Checked = True Then
                If CategoryID.Text = "" Then
                    cls.MsgExclamation("ÃÏÎá ÇÓã ÇáÈäÏ")
                    Exit Sub
                Else
                    cmd.CommandText = "select serial_pk,item_id,item_name,barcode,stock_id,stock_name,balance from Query_Items_Stocks where category_id = " & CategoryID.SelectedValue

                End If

            ElseIf CorpName.Checked = True Then
                If CorpID.Text = "" Then
                    cls.MsgExclamation("ÃÏÎá ÇÓã ÇáÔÑßå")
                    Exit Sub
                Else
                    cmd.CommandText = "select serial_pk,item_id,item_name,barcode,stock_id,stock_name,balance from Query_Items_Stocks where corporation_id = " & CorpID.SelectedValue

                End If

            End If
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Items_Stocks"))






            If MyDs.Tables("Items_Stocks").Rows.Count > 0 Then
                BtnSave.Enabled = True
                'MenuSave.Enabled = True
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            BSourceItemsStocks.EndEdit()
            cmd.CommandText = "select * from " & TName
            cmdb.DataAdapter = da
            da.Update(MyDs.Tables(TName))
            BtnSave.Enabled = False
            'MenuSave.Enabled = False
            MyDs.Tables("Items_Stocks").Rows.Clear()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

   

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MoveLast()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MoveNext()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MovePrevious()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MoveFirst()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

   


    Private Sub BtnNew_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnNew.MouseMove
        BtnNew.BackgroundImage = My.Resources._end
        BtnNew.ForeColor = Color.White

    End Sub

    Private Sub btnexit_mouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnExit.MouseMove
        BtnExit.BackgroundImage = My.Resources._end
        BtnExit.ForeColor = Color.White
    End Sub

    Private Sub btnNew_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.MouseLeave
        BtnNew.BackgroundImage = My.Resources.enter
        BtnNew.ForeColor = Color.Black

    End Sub

    Private Sub BtnExit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.MouseLeave
        BtnExit.BackgroundImage = My.Resources.enter
        BtnExit.ForeColor = Color.Black
    End Sub
    Private Sub BtnSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.MouseLeave
        BtnSave.BackgroundImage = My.Resources.enter
        BtnSave.ForeColor = Color.Black
    End Sub

    Private Sub BtnSave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnSave.MouseMove
        BtnSave.BackgroundImage = My.Resources._end
        BtnSave.ForeColor = Color.White
    End Sub

    Private Sub BtnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()

    End Sub

    Private Sub StockName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockName.CheckedChanged
        If StockName.Checked = True Then
            StockID.Enabled = True
            CategoryID.Enabled = False
            CorpID.Enabled = False
            TypeID.Enabled = False

        End If
    End Sub

    Private Sub TypeName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeName.CheckedChanged
        If TypeName.Checked = True Then
            StockID.Enabled = False
            CategoryID.Enabled = False
            CorpID.Enabled = False
            TypeID.Enabled = True

        End If
    End Sub

    Private Sub CorpName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorpName.CheckedChanged
        If CorpName.Checked = True Then
            StockID.Enabled = False
            CategoryID.Enabled = False
            CorpID.Enabled = True
            TypeID.Enabled = False

        End If
    End Sub

    Private Sub CategoryName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryName.CheckedChanged
        If CategoryName.Checked = True Then
            StockID.Enabled = False
            CategoryID.Enabled = True
            CorpID.Enabled = False
            TypeID.Enabled = False

        End If
    End Sub
End Class
