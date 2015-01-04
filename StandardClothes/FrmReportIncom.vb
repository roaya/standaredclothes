Public Class FrmReportIncom

    Dim date1, date2 As Date
    Dim Tbl As New GeneralDataSet.Query_ShiftsDataTable
    Dim TblEmp As New GeneralDataSet.EmployeesDataTable
    Dim TblIncomeDtls As New DataTable
    Dim Shift, Employee As String
    Dim m As New ShowAllReports
    Dim Rpt As New RptIncome
    Dim Ty As String
    Dim T As New DataTable
    Dim Cat As String
    Dim Employ As Integer = 0

    Private Sub FrmReportIncome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", TblEmp)

        emp.DataSource = TblEmp
        emp.DisplayMember = "Employee_name"
        emp.ValueMember = "employee_id"

    End Sub

    Private Sub Check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check.Click
        date1 = FromDate.Text
        date2 = ToDate.Text



        If byemp.Checked = True Then
            cls.RefreshData("select * from query_shifts where start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and Employee_Name=N'" & emp.Text & "'", Tbl)
            Employ = emp.SelectedValue
        Else
            cls.RefreshData("select * from query_shifts where start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", Tbl)
            Employ = 0
        End If



        r = Tbl.NewRow
        r("Shift_Name") = "كل الورديات"
        r("Shift_Detail_ID") = 0
        Tbl.Rows.Add(r)

        Shifts.DataSource = Tbl
        Shifts.Columns(0).HeaderText = "اسم الورديه"
        Shifts.Columns(1).Visible = False
        Shifts.Columns(2).HeaderText = "الرصيد النهائي"
        Shifts.Columns(3).HeaderText = "تاريخ البدايه"
        Shifts.Columns(4).HeaderText = "تاريخ النهايه"
        Shifts.Columns(5).HeaderText = "وقت البدايه"
        Shifts.Columns(6).HeaderText = "وقت النهايه"
        Shifts.Columns(7).HeaderText = "اسم الموظف"
        Shifts.Columns(8).Visible = False
        Shifts.Columns(9).Visible = False



    End Sub

    Private Sub byemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byemp.CheckedChanged
        If byemp.Checked = True Then
            emp.Enabled = True
        Else
            emp.Enabled = False
        End If
    End Sub

    Private Sub Shifts_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Shifts.MouseDoubleClick
        Try
            Shift = Shifts.SelectedRows(0).Cells("Shift_Detail_ID").Value
            ShiftName.Text = Shifts.SelectedRows(0).Cells("Employee_Name").Value & " - " & Shifts.SelectedRows(0).Cells("Real_start_Time").Value & " - " & Shifts.SelectedRows(0).Cells("Real_End_Time").Value & " - "

            If Shifts.SelectedRows(0).Cells("Shift_Name").Value.ToString = "كل الورديات" Then
                Shift = "sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                ShiftName.Text = "كل الورديات من'" & date1.ToString("yyyy/MM/dd") & "'   الى   '" & date2.ToString("yyyy/MM/dd") & "'"
                If Employ <> 0 Then
                    cmd.CommandText = "select employee_Name from employees where employee_ID=" & Employ
                    ShiftName.Text = cmd.ExecuteScalar & " - " & ShiftName.Text
                End If
            Else
                Shift = "sh.shift_detail_id=" & Shift
            End If


            If Employ <> 0 Then
                Shift = Shift & " and Sh.employee_ID=" & Employ
                cmd.CommandText = "select employee_Name from employees where employee_ID=" & Employ
            End If


            MyDs.Tables("Income").Rows.Clear()


            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            cmd.CommandText = "select ISNULL(sum(Credit_Value),0) from sales_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r("Credit") = cmd.ExecuteScalar
            MyDs.Tables("income").Rows.Add(r)



            cmd.CommandText = "select ISNULL(sum(Cash_Value),0) from Return_V_Header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            cmd.CommandText = "select ISNULL(sum(Credit_Value),0) from Return_V_Header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r("Credit") = cmd.ExecuteScalar
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select Isnull(sum(Pay_Value),0) from customers_Payments r,Shifts_Details sh where r.shift_Detail_ID=sh.shift_Detail_ID and r.status=N'مدفوعة' and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مدفوعات عملاء"
            r("Credit") = 0
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            cmd.CommandText = "select ISNULL(sum(Credit_Value),0) from purchase_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r("Credit") = cmd.ExecuteScalar
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(Cash_Value),0) from Return_C_Header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            cmd.CommandText = "select ISNULL(sum(Credit_Value),0) from Return_C_Header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r("Credit") = cmd.ExecuteScalar
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select Isnull(sum(Pay_Value),0) from Vendors_Payments r,Shifts_Details sh where r.shift_Detail_ID=sh.shift_Detail_ID and r.status=N'مدفوعة' and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مدفوعات الموردين"
            r("Credit") = 0
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select Isnull(sum(Expense_Value),0) from Expenses_Details r,Shifts_Details sh where r.shift_Detail_ID=sh.shift_Detail_ID and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مصروفات"
            r("Credit") = 0
            MyDs.Tables("income").Rows.Add(r)



            Income.DataSource = MyDs.Tables("Income")
            Income.Columns(0).HeaderText = "النوع"
            Income.Columns(1).Visible = False
            Income.Columns(2).HeaderText = "النقدي"
            Income.Columns(3).HeaderText = "الآجل"
            Income.Columns(4).Visible = False

            r = (MyDs.Tables("Income").NewRow)
            r("In_value") = 0
            r("Credit") = 0
            For i As Integer = 0 To Income.Rows.Count - 1
                r("In_value") = r("In_Value") + Income.Rows(i).Cells("In_Value").Value
                r("Credit") = r("Credit") + Income.Rows(i).Cells("Credit").Value
            Next
            r("In_Name") = "الاجمالي"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


        Catch
            cls.ErrMsg()
        End Try
    End Sub


    Private Sub ShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowReport.Click

        MyDs.Tables("Income").Rows.RemoveAt(MyDs.Tables("Income").Rows.Count - 1)

        Rpt.SetDataSource(MyDs.Tables("Income"))
        Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        Rpt.SetParameterValue("Report_Type", ShiftName.Text)
        m.CrystalReportViewer1.ReportSource = Rpt
        m.ShowDialog()

        r = (MyDs.Tables("Income").NewRow)
        r("In_value") = 0
        r("Credit") = 0
        For i As Integer = 0 To Income.Rows.Count - 1
            r("In_value") = r("In_Value") + Income.Rows(i).Cells("In_Value").Value
            r("Credit") = r("Credit") + Income.Rows(i).Cells("Credit").Value
        Next
        r("In_Name") = "الاجمالي"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

    End Sub


    Private Sub Income_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Income.MouseDoubleClick
        Try
            T.Rows.Clear()
            T.Columns.Clear()

            If Income.SelectedRows(0).Cells("In_Name").Value.ToString = "المبيعات" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Bill_Date,Employee_Name,Customer_Name,Total_Bill,Cash_Value,Credit_Value from report_sales_header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "التاريخ"
                IncomeDetails.Columns(3).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(4).HeaderText = "اسم العميل"
                IncomeDetails.Columns(5).HeaderText = "الاجمالي"
                IncomeDetails.Columns(6).HeaderText = "المدفوع"
                IncomeDetails.Columns(7).HeaderText = "الأجل"


                Type.Text = "فواتير المبيعات"
                Ty = "Sales"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "المشتريات" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Bill_Date,Employee_Name,Vendor_Name,Total_Bill,Cash_Value,Credit_Value from report_purchase_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "التاريخ"
                IncomeDetails.Columns(3).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(4).HeaderText = "اسم المورد"
                IncomeDetails.Columns(5).HeaderText = "الاجمالي"
                IncomeDetails.Columns(6).HeaderText = "المدفوع"
                IncomeDetails.Columns(7).HeaderText = "الأجل"


                Type.Text = "فواتير المشتريات"
                Ty = "Purchase"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مرتجعات الموردين" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Employee_Name,Vendor_Name,Total_Bill,Cash_Value,Credit_Value from report_return_v_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(3).HeaderText = "اسم المورد"
                IncomeDetails.Columns(4).HeaderText = "الاجمالي"
                IncomeDetails.Columns(5).HeaderText = "النقدي"
                IncomeDetails.Columns(6).HeaderText = "الآجل"

                Type.Text = "فواتير مرتجعات الموردين"
                Ty = "ReturnV"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مرتجعات العملاء" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Employee_Name,Customer_Name,Total_Bill,Cash_Value,Credit_Value from report_return_c_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(3).HeaderText = "اسم العميل"
                IncomeDetails.Columns(4).HeaderText = "الاجمالي"
                IncomeDetails.Columns(5).HeaderText = "النقدي"
                IncomeDetails.Columns(6).HeaderText = "الآجل"


                Type.Text = "فواتير مرتجعات العملاء"
                Ty = "ReturnC"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مدفوعات الموردين" Then
                cls.RefreshData("Select Vendor_Name,pay_v_ID,CP.Bill_ID,s.Bill_Date,Payed_Date,Pay_Value from Vendors_Payments CP,Shifts_Details Sh,Vendors v,Purchase_Header s where V.VEndor_ID=s.Vendor_ID and s.bill_ID=cp.bill_ID and cp.shift_Detail_ID=sh.shift_Detail_ID and cp.status=N'مدفوعة' and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "اسم المورد"
                IncomeDetails.Columns(1).HeaderText = "رقم الدفع"
                IncomeDetails.Columns(2).HeaderText = "رقم الفاتورة"
                IncomeDetails.Columns(3).HeaderText = "تاريخ الفاتورة"
                IncomeDetails.Columns(4).HeaderText = "تاريخ الدفع"
                IncomeDetails.Columns(5).HeaderText = "القيمة"

                Type.Text = "مدفوعات الموردين"
                Ty = "VPay"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مدفوعات عملاء" Then
                cls.RefreshData("Select Customer_Name,pay_C_ID,CP.Bill_ID,s.Bill_Date,Payed_Date,Pay_Value from customers_Payments CP,Shifts_Details Sh,Customers c,Sales_Header s where c.customer_ID=s.customer_ID and s.bill_ID=cp.bill_ID and cp.shift_Detail_ID=sh.shift_Detail_ID and cp.status=N'مدفوعة' and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "اسم العميل"
                IncomeDetails.Columns(1).HeaderText = "رقم الدفع"
                IncomeDetails.Columns(2).HeaderText = "رقم الفاتورة"
                IncomeDetails.Columns(3).HeaderText = "تاريخ الفاتورة"
                IncomeDetails.Columns(4).HeaderText = "تاريخ الدفع"
                IncomeDetails.Columns(5).HeaderText = "القيمة"

                Type.Text = "مدفوعات العملاء"
                Ty = "CPay"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مصروفات" Then
                cls.RefreshData("select expense_Category_Name,Expense_Name,Expense_Value,Expense_Date,Employee_Name from expenses_Details ed,Expenses_Header ec,Employees e,shifts_Details sh where ed.expense_Category_ID=ec.expense_category_id and ed.employee_ID=e.employee_ID and sh.shift_Detail_ID=ed.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "بند المصروف"
                IncomeDetails.Columns(1).HeaderText = "اسم المصروف"
                IncomeDetails.Columns(2).HeaderText = "قيمة المصروف"
                IncomeDetails.Columns(3).HeaderText = "التاريخ"
                IncomeDetails.Columns(4).HeaderText = "الموظف"


                Type.Text = "المصروفات"
                Ty = "EXP"
            Else
                Type.Text = ""
            End If
        Catch
            cls.ErrMsg()
        End Try
    End Sub

    Private Sub IncomeDetails_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IncomeDetails.MouseDoubleClick
        If Ty = "Sales" Then
            Dim RptSales As New Report_Sales_Order()
            MyDs.Tables("Report_Sales_Order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from Report_Sales_Order where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Sales_Order"))
            RptSales.SetDataSource(MyDs.Tables("Report_Sales_Order"))
            RptSales.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptSales
            m.ShowDialog()

        ElseIf Ty = "Purchase" Then
            Dim RptPur As New Report_Purchase_Order
            MyDs.Tables("Report_Purchase_Order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Purchase_Order where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Purchase_Order"))
            RptPur.SetDataSource(MyDs.Tables("Report_Purchase_Order"))
            RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptPur
            m.ShowDialog()

        ElseIf Ty = "ReturnV" Then
            Dim RptVenRet As New RptVendorReturns
            MyDs.Tables("Report_Vendors_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Vendors_Returns where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Vendors_Returns"))
            RptVenRet.SetDataSource(MyDs.Tables("Report_Vendors_Returns"))
            RptVenRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptVenRet
            m.ShowDialog()

        ElseIf Ty = "ReturnC" Then
            Dim RptCustRet As New Report_Customers_Returns
            MyDs.Tables("Report_Customers_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Customers_Returns where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Customers_Returns"))
            RptCustRet.SetDataSource(MyDs.Tables("Report_Customers_Returns"))
            m.CrystalReportViewer1.ReportSource = RptCustRet
            m.ShowDialog()
        ElseIf Ty = "CPay" Then
            Dim RptCPay As New CustVenPay
            MyDs.Tables("Report_Customers_Payments").Rows.Clear()
            cmd.CommandText = "select pay_C_ID pay_ID,Customer_Name CustVen,Payed_Date PayDate,Pay_Value PayValue,Bill_ID from Report_Customers_Payments where Pay_C_ID = " & IncomeDetails.SelectedRows(0).Cells("Pay_C_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Customers_Payments"))
            RptCPay.SetDataSource(MyDs.Tables("Report_Customers_Payments"))
            RptCPay.SetParameterValue("Title", "مدفوعات العملاء")
            RptCPay.SetParameterValue("vc", "اسم العميل")
            m.CrystalReportViewer1.ReportSource = RptCPay
            m.ShowDialog()
        ElseIf Ty = "VPay" Then
            Dim RptVPay As New CustVenPay
            MyDs.Tables("Report_Vendors_Payments").Rows.Clear()
            cmd.CommandText = "select pay_v_ID pay_ID,Vendor_Name CustVen,Payed_Date PayDate,Pay_Value PayValue,Bill_ID from Report_Vendors_Payments where Pay_v_ID = " & IncomeDetails.SelectedRows(0).Cells("Pay_C_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Vendors_Payments"))
            RptVPay.SetDataSource(MyDs.Tables("Report_Vendors_Payments"))
            RptVPay.SetParameterValue("Title", "مدفوعات الموردين")
            RptVPay.SetParameterValue("vc", "اسم المورد")
            m.CrystalReportViewer1.ReportSource = RptVPay
            m.ShowDialog()


        End If

    End Sub



    Private Sub Type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type.Click
        If Ty = "Sales" Then
            Dim Rpt As New RptSales
            MyDs.Tables("Report_Sales_Header").Rows.Clear()
            cls.RefreshData("select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from report_sales_header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("Report_Sales_Header"))
            Rpt.SetDataSource(MyDs.Tables("Report_Sales_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        ElseIf Ty = "Purchase" Then
            Dim Rpt As New ReportPurchase
            MyDs.Tables("Report_Purchase_Header").Rows.Clear()
            cls.RefreshData("select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from report_purchase_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("Report_Purchase_Header"))
            Rpt.SetDataSource(MyDs.Tables("Report_Purchase_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        ElseIf Ty = "ReturnV" Then
            Dim Rpt As New Report_ReturnVHeader
            MyDs.Tables("report_return_v_Header").Rows.Clear()
            cls.RefreshData("select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from report_return_v_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("report_return_v_Header"))
            Rpt.SetDataSource(MyDs.Tables("report_return_v_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()


        ElseIf Ty = "ReturnC" Then
            Dim Rpt As New ReportReturnCHeader
            MyDs.Tables("report_return_c_Header").Rows.Clear()
            cls.RefreshData("select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from report_return_c_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("report_return_c_Header"))
            Rpt.SetDataSource(MyDs.Tables("report_return_c_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        ElseIf Ty = "CPay" Then
            Dim Rpt As New Report_Customers_Payments
            MyDs.Tables("Report_Customers_Payments").Clear()
            cls.RefreshData("select * from Report_Customers_Payments c,Customers_Payments s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and c.Pay_C_ID=s.Pay_C_ID and " & Shift, MyDs.Tables("Report_Customers_Payments"))
            Rpt.SetDataSource(MyDs.Tables("Report_Customers_Payments"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()
        ElseIf Ty = "VPay" Then
            Dim Rpt As New Report_Vendors_Payments
            MyDs.Tables("Report_Vendors_Payments").Clear()
            cls.RefreshData("select * from Report_Vendors_Payments c,Vendors_Payments s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and c.Pay_v_ID=s.Pay_v_ID and " & Shift, MyDs.Tables("Report_Vendors_Payments"))
            Rpt.SetDataSource(MyDs.Tables("Report_Vendors_Payments"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()
        ElseIf Ty = "EXP" Then
            Dim Rpt As New Report_Expenses
            MyDs.Tables("Report_Expenses").Clear()
            cls.RefreshData("select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from Report_Expenses c,Expenses_Details s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and c.Expense_Detail_ID=s.Expense_Detail_ID and " & Shift, MyDs.Tables("Report_Expenses"))
            Rpt.SetDataSource(MyDs.Tables("Report_Expenses"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()
        End If
    End Sub


End Class


