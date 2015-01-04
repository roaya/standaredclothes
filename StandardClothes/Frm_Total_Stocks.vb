Public Class Frm_Total_Stocks
    Dim rptSal As New Report_Sales_Order
    Dim RptPur As New Report_Purchase_Order
    Dim rptstocks As New RptTotalStocksSales
    Dim rptcustomer As New RptTotalCustomersSales
    Dim rptvendors As New RptTotalVendorsPurchase
    Dim rptemployees As New RptTotalEmployeesSales

    Dim rptstockdetails As New RptTotalStocksSalesDetials
    Dim rptcustomerdetails As New RptTotaCustomersSalesDetials
    Dim rptemployeessales As New RptTotalEmployeesSalesDetails
    Dim rptvendorspurchase As New RptTotalVendorsPurchaseDetials
    Dim tbl1 As New GeneralDataSet.StocksDataTable

    Dim tbl2 As New GeneralDataSet.VendorsDataTable
    Dim d1, d2 As Date
    Dim tbl3 As New GeneralDataSet.CustomersDataTable
    Dim tbl4 As New GeneralDataSet.EmployeesDataTable
    Dim b As Boolean = False
    Dim s As Integer

    Private Sub Frm_Total_Stocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.RefreshData("select * from stocks", tbl1)
        cls.RefreshData("select * from customers", tbl3)
        cls.RefreshData("select * from vendors", tbl2)
        cls.RefreshData("select * from employees", tbl4)

        Stock_ID.DataSource = tbl1
        Stock_ID.DisplayMember = "stock_name"
        Stock_ID.ValueMember = "stock_id"

        CustomerID.DataSource = tbl3
        CustomerID.DisplayMember = "customer_name"
        CustomerID.ValueMember = "customer_id"


        VendorID.DataSource = tbl2
        VendorID.DisplayMember = "vendor_name"
        VendorID.ValueMember = "vendor_id"

        EmployeeID.DataSource = tbl4
        EmployeeID.DisplayMember = "employee_name"
        EmployeeID.ValueMember = "employee_id"


        GrdSearch.DataSource = MyDs.Tables("report_total_stocks_sales")
        GrdSearch.Columns(0).HeaderText = "اسم المخزن"
        GrdSearch.Columns(1).HeaderText = "تاريخ الفاتوره"
        GrdSearch.Columns(2).HeaderText = "عدد الفواتير"
        GrdSearch.Columns(3).HeaderText = "اجمالى الاصناف"
        GrdSearch.Columns(4).HeaderText = "اجمالى الفواتير"
        GrdSearch.Columns(5).Visible = False
        GrdSearch.Columns(6).Visible = False

        DataGridView1.DataSource = MyDs.Tables("report_total_stocks_sales_details")
        DataGridView1.Columns(0).HeaderText = "اسم المخزن"
        DataGridView1.Columns(1).HeaderText = "تاريخ الفاتوره"
        DataGridView1.Columns(2).HeaderText = "رقم الفاتوره"
        DataGridView1.Columns(3).HeaderText = "اجمالى الاصناف"
        DataGridView1.Columns(4).HeaderText = "نوع الخصم"
        DataGridView1.Columns(5).HeaderText = "قيمه الخصم"
        DataGridView1.Columns(6).HeaderText = "اجمالى النقدى"
        DataGridView1.Columns(7).HeaderText = "اجمالى الاجل"


        DataGridView1.Columns(8).HeaderText = "اجمالى الفاتوره"
        DataGridView1.Columns(9).Visible = False
        DataGridView1.Columns(10).Visible = False

        b = True


    End Sub


    Private Sub stocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Stocks.CheckedChanged
        If stocks.Checked = True Then
            If b = True Then


                GrdSearch.DataSource = MyDs.Tables("report_total_stocks_sales")
                GrdSearch.Columns(0).HeaderText = "اسم المخزن"
                GrdSearch.Columns(1).HeaderText = "تاريخ الفاتوره"
                GrdSearch.Columns(2).HeaderText = "عدد الفواتير"
                GrdSearch.Columns(3).HeaderText = "اجمالى الاصناف"
                GrdSearch.Columns(4).HeaderText = "اجمالى الفواتير"
                GrdSearch.Columns(5).Visible = False
                GrdSearch.Columns(6).Visible = False

                DataGridView1.DataSource = MyDs.Tables("report_total_stocks_sales_details")
                DataGridView1.Columns(0).HeaderText = "اسم المخزن"
                DataGridView1.Columns(1).HeaderText = "تاريخ الفاتوره"
                DataGridView1.Columns(2).HeaderText = "رقم الفاتوره"
                DataGridView1.Columns(3).HeaderText = "اجمالى الاصناف"
                DataGridView1.Columns(4).HeaderText = "نوع الخصم"
                DataGridView1.Columns(5).HeaderText = "قيمه الخصم"
                DataGridView1.Columns(6).HeaderText = "اجمالى النقدى"
                DataGridView1.Columns(7).HeaderText = "اجمالى الاجل"


                DataGridView1.Columns(8).HeaderText = "اجمالى الفاتوره"
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False

            End If
            RadStockID.Checked = True
            RadCustomerID.Visible = False
            CustomerID.Visible = False
            RadVendorID.Visible = False
            VendorID.Visible = False
            RadStockID.Visible = True
            Stock_ID.Visible = True
            RadempID.Checked = False
            RadempID.Visible = False
            EmployeeID.Visible = False
            s = 1
            MyDs.Tables("report_total_stocks_sales").Rows.Clear()
            MyDs.Tables("report_total_customers_sales").Rows.Clear()
            MyDs.Tables("report_total_vendors_purchase").Rows.Clear()
            MyDs.Tables("report_total_stocks_sales_details").Rows.Clear()
            MyDs.Tables("report_total_CUSTOMERS_sales_details").Rows.Clear()
            MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS").Rows.Clear()
            MyDs.Tables("report_total_employees_sales").Rows.Clear()
            MyDs.Tables("report_total_employees_sales_details").Rows.Clear()

        End If
    End Sub

    Private Sub customers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Customers.CheckedChanged
        If customers.Checked = True Then
            GrdSearch.DataSource = MyDs.Tables("report_total_customers_sales")

            GrdSearch.Columns(0).HeaderText = "اسم العميل"
            GrdSearch.Columns(1).HeaderText = "التاريخ"
            GrdSearch.Columns(2).HeaderText = "عدد الفواتير"
            GrdSearch.Columns(3).HeaderText = "اجمالى الاصناف"
            GrdSearch.Columns(4).HeaderText = "اجمالى الفواتير"
            GrdSearch.Columns(5).Visible = False
            GrdSearch.Columns(6).Visible = False

            DataGridView1.DataSource = MyDs.Tables("report_total_CUSTOMERS_sales_details")
            DataGridView1.Columns(0).HeaderText = "اسم العميل"
            DataGridView1.Columns(1).HeaderText = "تاريخ الفاتوره"
            DataGridView1.Columns(2).HeaderText = "رقم الفاتوره"
            DataGridView1.Columns(3).HeaderText = "اجمالى الاصناف"
            DataGridView1.Columns(4).HeaderText = "نوع الخصم"
            DataGridView1.Columns(5).HeaderText = "قيمه الخصم"
            DataGridView1.Columns(6).HeaderText = "اجمالى النقدى"
            DataGridView1.Columns(7).HeaderText = "اجمالى الاجل"


            DataGridView1.Columns(8).HeaderText = "اجمالى الفاتوره"
            DataGridView1.Columns(9).Visible = False
            DataGridView1.Columns(10).Visible = False


            RadempID.Checked = False
            RadempID.Visible = False
            EmployeeID.Visible = False
            RadCustomerID.Checked = True
            'RadCustomerID.Location = New Point(606, 34)
            'CustomerID.Location = New Point(374, 34)
            RadCustomerID.Visible = True
            CustomerID.Visible = True
            RadVendorID.Visible = False
            VendorID.Visible = False
            RadStockID.Visible = False
            Stock_ID.Visible = False
            s = 2
            MyDs.Tables("report_total_stocks_sales").Rows.Clear()
            MyDs.Tables("report_total_customers_sales").Rows.Clear()
            MyDs.Tables("report_total_vendors_purchase").Rows.Clear()
            MyDs.Tables("report_total_stocks_sales_details").Rows.Clear()
            MyDs.Tables("report_total_CUSTOMERS_sales_details").Rows.Clear()
            MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS").Rows.Clear()
            MyDs.Tables("report_total_employees_sales").Rows.Clear()
            MyDs.Tables("report_total_employees_sales_details").Rows.Clear()

        End If


    End Sub

    Private Sub vendors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Vendors.CheckedChanged
        If vendors.Checked = True Then
            GrdSearch.DataSource = MyDs.Tables("report_total_vendors_purchase")

            GrdSearch.Columns(0).HeaderText = "اسم المورد"
            GrdSearch.Columns(1).HeaderText = "التاريخ"
            GrdSearch.Columns(2).HeaderText = "عدد الفواتير"
            GrdSearch.Columns(3).HeaderText = "اجمالى الاصناف"
            GrdSearch.Columns(4).HeaderText = "اجمالى الفواتير"
            GrdSearch.Columns(5).Visible = False
            GrdSearch.Columns(6).Visible = False

            DataGridView1.DataSource = MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS")
            DataGridView1.Columns(0).HeaderText = "اسم المورد"
            DataGridView1.Columns(1).HeaderText = "تاريخ الفاتوره"
            DataGridView1.Columns(2).HeaderText = "رقم الفاتوره"
            DataGridView1.Columns(3).HeaderText = "اجمالى الاصناف"
            DataGridView1.Columns(4).HeaderText = "نوع الخصم"
            DataGridView1.Columns(5).HeaderText = "قيمه الخصم"
            DataGridView1.Columns(6).HeaderText = "اجمالى النقدى"
            DataGridView1.Columns(7).HeaderText = "اجمالى الاجل"


            DataGridView1.Columns(8).HeaderText = "اجمالى الفاتوره"
            DataGridView1.Columns(9).Visible = False
            DataGridView1.Columns(10).Visible = False

            RadVendorID.Checked = True
            RadempID.Checked = False
            RadempID.Visible = False
            EmployeeID.Visible = False
            'RadVendorID.Location = New Point(606, 34)
            'VendorID.Location = New Point(374, 34)
            RadVendorID.Visible = True
            VendorID.Visible = True
            RadCustomerID.Visible = False
            CustomerID.Visible = False
            RadStockID.Visible = False
            Stock_ID.Visible = False
            s = 3
            MyDs.Tables("report_total_stocks_sales").Rows.Clear()
            MyDs.Tables("report_total_customers_sales").Rows.Clear()
            MyDs.Tables("report_total_vendors_purchase").Rows.Clear()
            MyDs.Tables("report_total_stocks_sales_details").Rows.Clear()
            MyDs.Tables("report_total_CUSTOMERS_sales_details").Rows.Clear()
            MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS").Rows.Clear()
            MyDs.Tables("report_total_employees_sales").Rows.Clear()
            MyDs.Tables("report_total_employees_sales_details").Rows.Clear()

        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try

            Dim d1, d2 As Date
            d1 = CDate(Date1.Text)
            d2 = CDate(Date2.Text)

            MyDs.Tables("report_total_stocks_sales").Rows.Clear()
            MyDs.Tables("report_total_customers_sales").Rows.Clear()
            MyDs.Tables("report_total_vendors_purchase").Rows.Clear()
            MyDs.Tables("report_total_stocks_sales_details").Rows.Clear()
            MyDs.Tables("report_total_CUSTOMERS_sales_details").Rows.Clear()
            MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS").Rows.Clear()
            MyDs.Tables("report_total_employees_sales").Rows.Clear()
            MyDs.Tables("report_total_employees_sales_details").Rows.Clear()

            If RadStockID.Checked = True Then
                If Stock_ID.Text = "" Then
                    MsgBox("من فضلك اختر اسم المخزن")
                    Exit Sub
                Else
                    cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_stocks_sales where stock_id =" & Stock_ID.SelectedValue & "and bill_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    da.Fill(MyDs.Tables("report_total_stocks_sales"))
                    GrdSearch.DataSource = MyDs.Tables("report_total_stocks_sales")
                End If

            ElseIf RadCustomerID.Checked = True Then

                If CustomerID.Text = "" Then
                    MsgBox("من فضلك اختر اسم العميل")
                    Exit Sub
                Else
                    cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_customers_sales where customer_id =" & CustomerID.SelectedValue & "and bill_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    da.Fill(MyDs.Tables("report_total_customers_sales"))
                    GrdSearch.DataSource = MyDs.Tables("report_total_customers_sales")
                End If


            ElseIf RadVendorID.Checked = True Then

                If VendorID.Text = "" Then
                    MsgBox("من فضلك اختر اسم المورد")
                    Exit Sub
                Else
                    cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_vendors_purchase where vendor_id =" & VendorID.SelectedValue & "and bill_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    da.Fill(MyDs.Tables("report_total_vendors_purchase"))
                    GrdSearch.DataSource = MyDs.Tables("report_total_vendors_purchase")
                End If

            ElseIf RadEmp.Checked = True Then

                If EmployeeID.Text = "" Then
                    MsgBox("من فضلك اختر اسم الموظف")
                    Exit Sub
                Else
                    cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_employees_sales where employee_id =" & EmployeeID.SelectedValue & "and bill_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    da.Fill(MyDs.Tables("report_total_employees_sales"))

                    GrdSearch.DataSource = MyDs.Tables("report_total_employees_sales")
                    GrdSearch.Columns(6).Visible = False
                End If

            End If
        Catch ex As Exception
            Dim m As String
        End Try
    End Sub


    Private Sub GrdSearch_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdSearch.RowHeaderMouseDoubleClick

        Try


            MyDs.Tables("report_total_stocks_sales_details").Rows.Clear()
            MyDs.Tables("report_total_CUSTOMERS_sales_details").Rows.Clear()
            MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS").Rows.Clear()

            MyDs.Tables("report_total_employees_sales_details").Rows.Clear()



            Dim search As Date

            search = GrdSearch.SelectedRows(0).Cells(1).Value

            If s = 1 Then
                cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_stocks_sales_details where stock_id =" & Stock_ID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "'  order by bill_id"
                da.Fill(MyDs.Tables("report_total_stocks_sales_details"))
                DATAGRIDVIEW1.DataSource = MyDs.Tables("report_total_stocks_sales_details")


                Exit Sub
            ElseIf s = 2 Then
                cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_CUSTOMERS_sales_details where CUSTOMER_ID =" & CustomerID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "' order by bill_id"
                da.Fill(MyDs.Tables("report_total_CUSTOMERS_sales_details"))
                DATAGRIDVIEW1.DataSource = MyDs.Tables("report_total_CUSTOMERS_sales_details")

                Exit Sub
            ElseIf s = 3 Then

                cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_VENDORS_PURCHASE_DETAILS where VENDOR_ID =" & VendorID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "' order by bill_id"
                da.Fill(MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS"))
                DATAGRIDVIEW1.DataSource = MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS")

                Exit Sub




            ElseIf s = 4 Then

                cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_employees_sales_DETAILS where employee_id =" & EmployeeID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "' order by bill_id"
                da.Fill(MyDs.Tables("report_total_employees_sales_DETAILS"))
                DataGridView1.DataSource = MyDs.Tables("report_total_employees_sales_DETAILS")

                Exit Sub



            End If
        Catch ex As Exception
            Dim m As String
        End Try
    End Sub




    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try


            Me.Cursor = Cursors.WaitCursor

            'MyDs.Tables("report_total_stocks_sales").Rows.Clear()
            'MyDs.Tables("report_total_customers_sales").Rows.Clear()
            'MyDs.Tables("report_total_customers_sales").Rows.Clear()


            If s = 1 Then

                d1 = CDate(Date1.Text)
                d2 = CDate(Date2.Text)

                'cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_stocks_sales where stock_id =" & Stock_ID.SelectedValue & "and bill_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by bill_date"
                'da.Fill(MyDs.Tables("report_total_stocks_sales"))
                rptstocks.SetDataSource(MyDs.Tables("report_total_stocks_sales"))
                rptstocks.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptstocks
                m.ShowDialog()


            ElseIf s = 2 Then
                'cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_customers_sales where customer_id =" & CustomerID.SelectedValue & "and bill_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by bill_date"
                'da.Fill(MyDs.Tables("report_total_customers_sales"))
                rptcustomer.SetDataSource(MyDs.Tables("report_total_customers_sales"))
                rptcustomer.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptcustomer
                m.ShowDialog()

            ElseIf s = 3 Then
                'cmd.CommandText = " select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_total_vendors_purchase where vendor_id =" & VendorID.SelectedValue & "and bill_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by bill_date"
                'da.Fill(MyDs.Tables("report_total_vendors_purchase"))

                rptvendors.SetDataSource(MyDs.Tables("report_total_vendors_purchase"))
                rptvendors.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))



                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptemployees
                m.ShowDialog()
            ElseIf s = 4 Then
                rptemployees.SetDataSource(MyDs.Tables("report_total_employees_sales"))
                rptemployees.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))



                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptemployees
                m.ShowDialog()
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Dim x As Integer
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            'MyDs.Tables("report_total_stocks_sales_details").Rows.Clear()
            'MyDs.Tables("report_total_CUSTOMERS_sales_details").Rows.Clear()
            'MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS").Rows.Clear()

            'Dim search As Date

            'search = GrdSearch.SelectedRows(0).Cells(1).Value

            Me.Cursor = Cursors.WaitCursor

            If s = 1 Then
                ''cmd.CommandText = " select * from report_total_stocks_sales_details where stock_id =" & Stock_ID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "'"
                ''da.Fill(MyDs.Tables("report_total_stocks_sales_details"))
                rptstockdetails.SetDataSource(MyDs.Tables("report_total_stocks_sales_details"))
                rptstockdetails.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptstockdetails
                m.ShowDialog()


            ElseIf s = 2 Then
                'cmd.CommandText = " select * from report_total_CUSTOMERS_sales_details where CUSTOMER_ID =" & CustomerID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "'"
                'da.Fill(MyDs.Tables("report_total_CUSTOMERS_sales_details"))
                rptcustomerdetails.SetDataSource(MyDs.Tables("report_total_CUSTOMERS_sales_details"))
                rptcustomerdetails.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptcustomerdetails
                m.ShowDialog()


            ElseIf s = 3 Then

                'cmd.CommandText = " select * from report_total_VENDORS_PURCHASE_DETAILS where VENDOR_ID =" & VendorID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "'"
                'da.Fill(MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS"))


                rptvendorspurchase.SetDataSource(MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS"))
                rptvendorspurchase.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptvendorspurchase
                m.ShowDialog()

            ElseIf s = 4 Then

                'cmd.CommandText = " select * from report_total_VENDORS_PURCHASE_DETAILS where VENDOR_ID =" & VendorID.SelectedValue & "and bill_date  ='" & search.ToString("MM/dd/yyyy") & "'"
                'da.Fill(MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS"))


                rptemployeessales.SetDataSource(MyDs.Tables("report_total_employees_sales_DETAILS"))
                rptemployeessales.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptemployeessales
                m.ShowDialog()


            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Dim x As Integer
        End Try
    End Sub
    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick

        Try


            Me.Cursor = Cursors.WaitCursor
            MyDs.Tables("Report_Sales_Order").Rows.Clear()
            MyDs.Tables("Report_Purchase_Order").Rows.Clear()



            Dim BillID As Integer

            If s = 1 Or s = 2 Or s = 4 Then

                BillID = DataGridView1.SelectedRows(0).Cells(2).Value
                cmd.CommandText = "select * from Report_Sales_Order where bill_id = " & BillID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Sales_Order"))
                rptSal.SetDataSource(MyDs.Tables("Report_Sales_Order"))
                rptSal.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptSal
                m.ShowDialog()

            ElseIf s = 3 Then

                BillID = DataGridView1.SelectedRows(0).Cells(2).Value

                cmd.CommandText = "select * from Report_Purchase_Order where bill_id = " & BillID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Purchase_Order"))

                RptPur.SetDataSource(MyDs.Tables("Report_Purchase_Order"))
                RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptPur
                m.ShowDialog()
                'ElseIf s = 4 Then

                '    BillID = DataGridView1.SelectedRows(0).Cells(2).Value

                '    cmd.CommandText = "select * from Report_Sales_Order where bill_id = " & BillID
                '    da.SelectCommand = cmd
                '    da.Fill(MyDs.Tables("Report_Sales_Order"))

                '    RptPur.SetDataSource(MyDs.Tables("Report_Sales_Order"))
                '    RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                '    Dim m As New ShowAllReports
                '    m.CrystalReportViewer1.ReportSource = RptPur
                '    m.ShowDialog()
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Dim x As Integer
        End Try
    End Sub


    Private Sub RadEmp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEmp.CheckedChanged
        Try
            If RadEmp.Checked = True Then



                GrdSearch.DataSource = MyDs.Tables("report_total_employees_sales")
                GrdSearch.Columns(0).HeaderText = "اسم الموظف"
                GrdSearch.Columns(1).HeaderText = "تاريخ الفاتوره"
                GrdSearch.Columns(2).HeaderText = "عدد الفواتير"
                GrdSearch.Columns(3).HeaderText = "اجمالى الاصناف"
                GrdSearch.Columns(4).HeaderText = "اجمالى الفواتير"
                GrdSearch.Columns(5).Visible = False
                'GrdSearch.Columns(6).Visible = False

                DataGridView1.DataSource = MyDs.Tables("report_total_employees_sales_details")
                DataGridView1.Columns(0).HeaderText = "اسم الموظف"
                DataGridView1.Columns(1).HeaderText = "تاريخ الفاتوره"
                DataGridView1.Columns(2).HeaderText = "رقم الفاتوره"
                DataGridView1.Columns(3).HeaderText = "اجمالى الاصناف"
                DataGridView1.Columns(4).HeaderText = "نوع الخصم"
                DataGridView1.Columns(5).HeaderText = "قيمه الخصم"
                DataGridView1.Columns(6).HeaderText = "اجمالى النقدى"
                DataGridView1.Columns(7).HeaderText = "اجمالى الاجل"


                DataGridView1.Columns(8).HeaderText = "اجمالى الفاتوره"
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                'DataGridView1.Columns(6).Visible = False



                RadCustomerID.Checked = False
                RadempID.Checked = True
                RadempID.Visible = True
                EmployeeID.Visible = True
                'RadempID.Location = New Point(607, 34)
                'EmployeeID.Location = New Point(374, 34)
                RadCustomerID.Visible = False
                CustomerID.Visible = False
                RadVendorID.Visible = False
                VendorID.Visible = False
                RadStockID.Visible = False
                Stock_ID.Visible = False
                s = 4
                MyDs.Tables("report_total_stocks_sales").Rows.Clear()
                MyDs.Tables("report_total_customers_sales").Rows.Clear()
                MyDs.Tables("report_total_vendors_purchase").Rows.Clear()
                MyDs.Tables("report_total_stocks_sales_details").Rows.Clear()
                MyDs.Tables("report_total_CUSTOMERS_sales_details").Rows.Clear()
                MyDs.Tables("report_total_VENDORS_PURCHASE_DETAILS").Rows.Clear()
                MyDs.Tables("report_total_employees_sales").Rows.Clear()
                MyDs.Tables("report_total_employees_sales_details").Rows.Clear()
            End If
        Catch ex As Exception
            Dim x As Integer
        End Try
    End Sub

End Class