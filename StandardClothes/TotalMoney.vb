Public Class TotalMoney
    Dim tbl1 As New GeneralDataSet.StocksDataTable
    Dim tbltotal As New GeneralDataSet.Total_moneyDataTable
    Dim rpt As New RptTotalMoney

    Private Sub TotalMoney_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from stocks", tbl1)

        StockID.DataSource = tbl1
        StockID.DisplayMember = "stock_name"
        StockID.ValueMember = "stock_id"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

        
            Dim d1, d2 As Date

            d1 = CDate(date1.Text)
            d2 = CDate(date2.Text)

        If StockID.Text = "" Then
            MsgBox("من فضلك اختر اسم المخزن")
            StockID.Focus()
            Exit Sub
        Else
                cmd.CommandText = "select isnull(SUM(cash_value),0)  from sales_header where  bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                SalesCash.value = cmd.ExecuteScalar



                cmd.CommandText = "select sum (p.credit_value)  from sales_header p ,sales_Details d where p.Bill_ID=d.Bill_ID and  bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                SaleCredit.value = cmd.ExecuteScalar


                cmd.CommandText = "select isnull(SUM(expense_value),0)  from expenses_details where   expense_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                Expenses.value = cmd.ExecuteScalar

                cmd.CommandText = "select isnull(SUM(cash_value),0)  from return_c_header where  bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                CustomersCash.value = cmd.ExecuteScalar

                cmd.CommandText = "select isnull(SUM(credit_value),0)  from return_c_header where   bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                CustomersCredit.value = cmd.ExecuteScalar

                cmd.CommandText = "select isnull(SUM(cash_value),0)  from return_v_header where  bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                VendorsCash.value = cmd.ExecuteScalar

                cmd.CommandText = "select isnull(SUM(credit_value),0)  from return_v_header where  bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                VendorsCredit.Value = cmd.ExecuteScalar

                cmd.CommandText = "select isnull(SUM(cash_value),0)  from purchase_header where  bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                PurchaseCash.Value = cmd.ExecuteScalar



                cmd.CommandText = "select sum (p.credit_value)  from purchase_header p ,Purchase_Details d where p.Bill_ID=d.Bill_ID and   p.bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                PurchaseCredit.Value = cmd.ExecuteScalar

                cmd.CommandText = "select isnull(SUM(pay_value),0)  from customers_payments where status=N'مدفوعة' and Payed_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                customersPayments.Value = cmd.ExecuteScalar

                cmd.CommandText = "select isnull(SUM(pay_value),0)  from vendors_payments where status=N'مدفوعة' and  Payed_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                VendorsPayments.Value = cmd.ExecuteScalar

                TotalCash.Text = (SalesCash.Value + VendorsCash.Value + customersPayments.Value) - (CustomersCash.Value + Expenses.Value + PurchaseCash.Value + VendorsPayments.Value)
                'TotalCredit.Text = (SaleCredit.Value + VendorsCredit.Value) - (CustomersCredit.Value + PurchaseCredit.Value)
            End If
 Catch ex As Exception
            cls.MsgExclamation("من فضلك تاكد من التاريخ المدخل")
        End Try
    End Sub

   





    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim d1, d2 As Date
            MyDs.Tables("total_money").Rows.Clear()

            d1 = CDate(DATE1.Text)
            d2 = CDate(Date2.Text)

            cmd.CommandText = " select bill_date as date ,N'مبيعات' as type,isnull(SUM(cash_value),0) as cash ,isnull(SUM(credit_value),0) as credit ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from sales_header where bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'group by bill_date "
            da.Fill(MyDs.Tables("total_money"))

            cmd.CommandText = " select bill_date as date ,N'مشتريات' as type,isnull(SUM(-cash_value),0) as cash ,isnull(SUM(-credit_value),0) as credit ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from purchase_header where bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'group by bill_date "
            da.Fill(MyDs.Tables("total_money"))

            cmd.CommandText = " select bill_date as date ,N'مرتجع العملاء' as type,isnull(SUM(-cash_value),0) as cash ,isnull(SUM(-credit_value),0) as credit ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from return_c_header where bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'group by bill_date "
            da.Fill(MyDs.Tables("total_money"))

            cmd.CommandText = " select bill_date as date ,N'مرتجع الموردين' as type,isnull(SUM(cash_value),0) as cash ,isnull(SUM(credit_value),0) as credit ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from return_v_header where bill_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'group by bill_date "
            da.Fill(MyDs.Tables("total_money"))

            cmd.CommandText = " select expense_date as date ,N'المصروفات' as type,isnull(SUM(-expense_value),0) as cash ,0 as credit ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from expenses_details where expense_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'group by expense_date "
            da.Fill(MyDs.Tables("total_money"))

            cmd.CommandText = " select payed_date as date ,N'مدفوعات العملاء' as type,isnull(SUM(pay_value),0) as cash ,0 as credit ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from customers_payments where status=N'مدفوعة' and  payed_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'group by payed_date "
            da.Fill(MyDs.Tables("total_money"))

            cmd.CommandText = " select payed_date as date ,N'مدفوعات الموردين' as type,isnull(SUM(-pay_value),0) as cash ,0 as credit ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from vendors_payments where status=N'مدفوعة' and  payed_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'group by payed_date "
            da.Fill(MyDs.Tables("total_money"))
            Me.Cursor = Cursors.WaitCursor
            rpt.SetDataSource(MyDs.Tables("total_money"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            cls.MsgExclamation("من فضلك تاكد من التاريخ المدخل")
        End Try
    End Sub

End Class