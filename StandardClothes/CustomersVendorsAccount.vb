Public Class CustomersVendorsAccount
    Dim TBlCust As New GeneralDataSet.CustomersDataTable
    Dim TBLVen As New GeneralDataSet.VendorsDataTable
    Dim FromD, ToD As Date
    Dim TblDetails As New GeneralDataSet.MasterRecordDataTable
    Dim m As New ShowAllReports
    Dim Rpt As New RptAccounts
    Dim Cash, Credit As Double
    Private Sub CustomersVendorsAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.RefreshData("select * from customers", TBlCust)
        cls.RefreshData("select * from vendors", TBLVen)

        Accounts.DataSource = TBlCust
        Accounts.DisplayMember = "Customer_Name"
        Accounts.ValueMember = "customer_id"

        AccountsDetails.DataSource = TblDetails


        AccountsDetails.Columns(0).HeaderText = "رقم المستند"
        AccountsDetails.Columns(1).HeaderText = "الوصف"
        AccountsDetails.Columns(2).HeaderText = "التاريخ"
        AccountsDetails.Columns(3).HeaderText = "دائن"
        AccountsDetails.Columns(4).HeaderText = "مدين"
        AccountsDetails.Columns(5).Visible = False

    End Sub

    Private Sub ByCust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByCust.CheckedChanged
        If ByCust.Checked = True Then
            Accounts.DataSource = TBlCust
            Accounts.DisplayMember = "Customer_Name"
            Accounts.ValueMember = "customer_id"
        Else
            Accounts.DataSource = TBLVen
            Accounts.DisplayMember = "vendor_Name"
            Accounts.ValueMember = "Vendor_id"
        End If
    End Sub

    Private Sub Check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check.Click
        TblDetails.Rows.Clear()
        FromD = Fromdate.Text
        ToD = Todate.Text

        If Accounts.SelectedValue = Nothing Then
            cls.MsgExclamation("برجاء ادخل اسم الحساب")
            Exit Sub
        End If

        If ByCust.Checked = True Then

            cmd.CommandText = "Select Bill_ID ID,N'رصيد أول المدة' Name,bill_Date TheDate,Credit_Value 'Out',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from sales_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and customer_ID=" & Accounts.SelectedValue & " and shift_Detail_id is null"
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مبيعات أجل' Name,bill_Date TheDate,Total_Bill 'Out',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from sales_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and customer_ID=" & Accounts.SelectedValue & " and shift_Detail_id is not null"
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مبيعات نقدي' Name,bill_Date TheDate,Cash_Value 'In',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from sales_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and customer_ID=" & Accounts.SelectedValue & " and shift_Detail_id is not null and cash_Value<>0"
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مرتجعات عملاء أجل' Name,bill_Date TheDate,Total_Bill 'IN',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Return_C_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and customer_ID=" & Accounts.SelectedValue
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مرتجعات عملاء نقدي' Name,bill_Date TheDate,Cash_Value OUT,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Return_C_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "'  and cash_Value<>0 and customer_ID=" & Accounts.SelectedValue
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Pay_C_ID ID,N'مدفوعات عملاء' Name,Payed_Date TheDate,Pay_Value 'IN',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Customers_Payments C,Sales_Header SH where SH.bill_ID=C.Bill_ID and Status=N'مدفوعة' and PAyed_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and sh.customer_ID=" & Accounts.SelectedValue
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            Type.Text = "حساب عملاء - " & Accounts.Text
            Type.Tag = "Customers"

        Else

            cmd.CommandText = "Select Bill_ID ID,N'رصيد أول المدة' Name,bill_Date TheDate,Credit_Value 'In',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Purchase_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and Vendor_ID=" & Accounts.SelectedValue & " and shift_Detail_id is null"
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مشتريات أجل' Name,bill_Date TheDate,Total_Bill 'In',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Purchase_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and Vendor_ID=" & Accounts.SelectedValue & " and shift_Detail_id is not null"
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مشتريات نقدي' Name,bill_Date TheDate,Cash_Value 'Out',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Purchase_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and Vendor_ID=" & Accounts.SelectedValue & " and shift_Detail_id is not null  and cash_Value<>0"
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مرتجعات موردين أجل' Name,bill_Date TheDate,Total_Bill 'Out',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Return_v_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and Vendor_ID=" & Accounts.SelectedValue
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Bill_ID ID,N'مرتجعات موردين نقدي' Name,bill_Date TheDate,Cash_Value 'In',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Return_v_Header where bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "'  and cash_Value<>0 and Vendor_ID=" & Accounts.SelectedValue
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            cmd.CommandText = "Select Pay_v_ID ID,N'مدفوعات موردين' Name,Payed_Date TheDate,Pay_Value 'OUT',(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from Vendors_Payments C,Purchase_Header SH where SH.bill_ID=C.Bill_ID and Status=N'مدفوعة' and PAyed_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "' and sh.vendor_ID=" & Accounts.SelectedValue
            da.SelectCommand = cmd
            da.Fill(TblDetails)

            Type.Text = "حساب موردين - " & Accounts.Text
            Type.Tag = "Vendors"
        End If

        Cash = 0
        Credit = 0

        For i As Integer = 0 To TblDetails.Rows.Count - 1

            If TblDetails.Rows(i).Item("In").ToString <> "" Then
                Cash = Cash + TblDetails.Rows(i).Item("in")
            End If
            If TblDetails.Rows(i).Item("out").ToString <> "" Then
                Credit = Credit + TblDetails.Rows(i).Item("out")
            End If
        Next
     

        If Type.Tag = "Customers" Then
            Total.Text = Credit - Cash
        Else
            Total.Text = Cash - Credit
        End If

        TblDetails.DefaultView.Sort = ("TheDate Asc, ID Asc")


    End Sub

    Private Sub Type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type.Click
        Try

            For i As Integer = 0 To AccountsDetails.Rows.Count - 1
                r = MyDs.Tables("MasterRecord").NewRow
                r(0) = AccountsDetails.Rows(i).Cells(0).Value
                r(1) = AccountsDetails.Rows(i).Cells(1).Value
                r(2) = AccountsDetails.Rows(i).Cells(2).Value
                r(3) = AccountsDetails.Rows(i).Cells(3).Value
                r(4) = AccountsDetails.Rows(i).Cells(4).Value
                r(5) = AccountsDetails.Rows(i).Cells(5).Value
                MyDs.Tables("MasterRecord").Rows.Add(r)
            Next
            Rpt.SetDataSource(MyDs.Tables("MasterRecord"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            Rpt.SetParameterValue("P_Type", Type.Text & " - ' " & FromD.ToString("dd/MM/yyyy") & " ' - ' " & ToD.ToString("dd/MM/yyyy") & " '")
            Rpt.SetParameterValue("P_Balance", Total.Text)
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()
        Catch
        End Try
    End Sub

    Private Sub AccountsDetails_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AccountsDetails.MouseDoubleClick
        If AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مبيعات أجل" Or AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مبيعات نقدي" Then
            Dim RptSales As New Report_Sales_Order()
            MyDs.Tables("Report_Sales_Order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from Report_Sales_Order where bill_id = " & AccountsDetails.SelectedRows(0).Cells("ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Sales_Order"))
            RptSales.SetDataSource(MyDs.Tables("Report_Sales_Order"))
            RptSales.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptSales
            m.ShowDialog()

        ElseIf AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مرتجعات عملاء أجل" Or AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مرتجعات عملاء نقدي" Then
            Dim RptCustRet As New Report_Customers_Returns
            MyDs.Tables("Report_Customers_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Customers_Returns where bill_id = " & AccountsDetails.SelectedRows(0).Cells("ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Customers_Returns"))
            RptCustRet.SetDataSource(MyDs.Tables("Report_Customers_Returns"))
            m.CrystalReportViewer1.ReportSource = RptCustRet
            m.ShowDialog()
        ElseIf AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مدفوعات عملاء" Then
            Dim RptCPay As New CustVenPay
            MyDs.Tables("Report_Customers_Payments").Rows.Clear()
            cmd.CommandText = "select pay_C_ID pay_ID,Customer_Name CustVen,Payed_Date PayDate,Pay_Value PayValue,Bill_ID from Report_Customers_Payments where Pay_C_ID = " & AccountsDetails.SelectedRows(0).Cells("ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Customers_Payments"))
            RptCPay.SetDataSource(MyDs.Tables("Report_Customers_Payments"))
            RptCPay.SetParameterValue("Title", "مدفوعات العملاء")
            RptCPay.SetParameterValue("vc", "اسم العميل")
            m.CrystalReportViewer1.ReportSource = RptCPay
            m.ShowDialog()
        ElseIf AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مشتريات أجل" Or AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مشتريات نقدي" Then
            Dim RptPur As New Report_Purchase_Order
            MyDs.Tables("Report_Purchase_Order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Purchase_Order where bill_id = " & AccountsDetails.SelectedRows(0).Cells("ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Purchase_Order"))
            RptPur.SetDataSource(MyDs.Tables("Report_Purchase_Order"))
            RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptPur
            m.ShowDialog()
        ElseIf AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مرتجعات موردين أجل" Or AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مرتجعات موردين نقدي" Then
            Dim RptVenRet As New RptVendorReturns
            MyDs.Tables("Report_Vendors_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Vendors_Returns where bill_id = " & AccountsDetails.SelectedRows(0).Cells("ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Vendors_Returns"))
            RptVenRet.SetDataSource(MyDs.Tables("Report_Vendors_Returns"))
            RptVenRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptVenRet
            m.ShowDialog()
        ElseIf AccountsDetails.SelectedRows(0).Cells("Name").Value.ToString = "مدفوعات موردين" Then
            Dim RptVPay As New CustVenPay
            MyDs.Tables("Report_Vendors_Payments").Rows.Clear()
            cmd.CommandText = "select pay_v_ID pay_ID,Vendor_Name CustVen,Payed_Date PayDate,Pay_Value PayValue,Bill_ID from Report_Vendors_Payments where Pay_v_ID = " & AccountsDetails.SelectedRows(0).Cells("ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Vendors_Payments"))
            RptVPay.SetDataSource(MyDs.Tables("Report_Vendors_Payments"))
            RptVPay.SetParameterValue("Title", "مدفوعات الموردين")
            RptVPay.SetParameterValue("vc", "اسم المورد")
            m.CrystalReportViewer1.ReportSource = RptVPay
            m.ShowDialog()
        End If
    End Sub
End Class