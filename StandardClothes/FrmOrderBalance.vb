Public Class FrmOrderBalance
    Dim tbl1 As New GeneralDataSet.StocksDataTable
    Dim tbl2 As New GeneralDataSet.CategoriesDataTable
    Dim rpt As New RptMaxOrder

    Private Sub FrmOrderBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from stocks", tbl1)
        cls.RefreshData("select * from categories", tbl2)
        StockID.DataSource = tbl1
        StockID.DisplayMember = "stock_name"
        StockID.ValueMember = "stock_Id"

        CategoryID.DataSource = tbl2
        CategoryID.DisplayMember = "category_name"
        CategoryID.ValueMember = "category_Id"
    End Sub

    Private Sub RadStocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadStocks.CheckedChanged
        If RadStocks.Checked = True Then
            StockID.Enabled = True
            CategoryID.Enabled = False
        End If
    End Sub

    Private Sub RadCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCategory.CheckedChanged
        If RadCategory.Checked = True Then
            StockID.Enabled = False
            CategoryID.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            MyDs.Tables("query_all_items").Rows.Clear()
            If txtBalance.Value = 0 Then
                cls.MsgExclamation("من فضلك ادخل قيمه")
                Exit Sub

            Else

                If RadStocks.Checked = True Then
                    If StockID.Text = "" Then
                        cls.MsgExclamation("من فضلك اختر اسم المخزن")
                        Exit Sub
                    Else
                        cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from  Query_All_items where stock_id =  " & StockID.SelectedValue & " and balance < " & txtBalance.Value

                    End If
                ElseIf RadCategory.Checked = True Then
                    If CategoryID.Text = "" Then
                        cls.MsgExclamation("من فضلك اختر اسم البند")
                        Exit Sub
                    Else
                        cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from  Query_All_items where category_id =  " & CategoryID.SelectedValue & " and balance < " & txtBalance.Value

                    End If

                End If
                da.Fill(MyDs.Tables("query_all_items"))

                If MyDs.Tables("query_all_items").Rows.Count = 0 Then
                    MsgBox("لا نوجد بيانات")
                    Exit Sub
                Else
                    Me.Cursor = Cursors.WaitCursor
                    rpt.SetDataSource(MyDs.Tables("query_all_items"))
                    rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                    CrystalReportViewer1.ReportSource = rpt
                    TabControl1.SelectTab(1)
                    Me.Cursor = Cursors.Default
                End If

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Items Stocks")
        End Try

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
End Class