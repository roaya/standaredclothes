Public Class ReportSalesOrder

    Dim RptPur As New Report_Sales_Order
    Dim b As Boolean = False
    Dim RptChk As New CrystalDecisions.CrystalReports.Engine.ReportClass
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.CustomersDataTable
    Dim tbl3 As New GeneralDataSet.StocksDataTable

    Private Sub ReportSalesOrder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub

    Private Sub ReportPurchaseOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(" select * from Employees", tbl1)
            cls.RefreshData(" select * from Customers", tbl2)
            cls.RefreshData("  select * from Stocks", tbl3)

            ItemName.Items.Clear()
            cmd.CommandText = "select item_name from items"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ItemName.Items.Add(dr("Item_Name"))
            Loop
            dr.Close()

            StockID.DataSource = tbl3
            StockID.DisplayMember = "stock_Name"
            StockID.ValueMember = "stock_ID"

            EmployeeID.DataSource = tbl1
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"

            CustomerID.DataSource = tbl2
            CustomerID.DisplayMember = "Customer_Name"
            CustomerID.ValueMember = "Customer_ID"

            b = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub RadioCustomerID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCustomerID.CheckedChanged
        If RadioCustomerID.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = True
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = True
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioBarCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBarCode.CheckedChanged
        If RadioBarCode.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = True
            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub



    Private Sub RadioStockID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioStockID.CheckedChanged
        If RadioStockID.Checked = True Then
            StockID.Enabled = True
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioTotalBill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTotalBill.CheckedChanged
        If RadioTotalBill.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = True
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

   


    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If b = True Then
                cmd.CommandText = "select distinct Bill_ID from Report_Sales_Order where item_name = N'" & ItemName.Text & "'"
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub Barcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Barcode.Leave
        Try
            If b = True Then
                cmd.CommandText = "select distinct Bill_ID from Report_Sales_Order where barcode = '" & Barcode.Text & "'"
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub CustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select distinct sh.Bill_ID from Sales_Header sh ,Sales_Details sd where sh.Bill_ID=sd.Bill_ID and sh.Customer_id = " & CustomerID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select distinct sh.Bill_ID from Sales_Header sh ,Sales_Details sd where sh.Bill_ID=sd.Bill_ID and sh.employee_id = " & EmployeeID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub StockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select distinct sh.Bill_ID from Sales_Header sh ,Sales_Details sd where sh.Bill_ID=sd.Bill_ID and  sh.stock_id = " & StockID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub TotalBill_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TotalBill.Leave
        Try
            If b = True Then
                If TotalBill.Value > 0 Then
                    cmd.CommandText = "select distinct sh.Bill_ID from Sales_Header sh ,Sales_Details sd where sh.Bill_ID=sd.Bill_ID and  sh.total_bill > " & TotalBill.Value
                    BillID.Items.Clear()
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        BillID.Items.Add(dr("Bill_ID"))
                    Loop
                    dr.Close()
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub RadioDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDates.CheckedChanged
        If RadioDates.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.Leave
        Try
            Dim date1 As Date = CDate(DateTimePicker1.Text)
            Dim date2 As Date = CDate(DateTimePicker2.Text)
            cmd.CommandText = "select distinct bill_id from Report_Sales_Order where Bill_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("Bill_ID"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub RadioEmployeeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmployeeID.CheckedChanged
        If RadioEmployeeID.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = True
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If BillID.Text = "" Then
                cls.MsgExclamation("اختر رقم الفاتورة")
            Else
                Me.Cursor = Cursors.WaitCursor

                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Print_Type") = "طباعة عادية" Then

                    MyDs.Tables("Report_Sales_Order").Rows.Clear()
                    cmd.CommandText = "select * from Report_Sales_Order where bill_id = " & BillID.Text
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Report_Sales_Order"))
                    RptPur.SetDataSource(MyDs.Tables("Report_Sales_Order"))
                    RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                    Dim m As New ShowAllReports
                    m.CrystalReportViewer1.ReportSource = RptPur
                    m.ShowDialog()
                    Me.Cursor = Cursors.Default
                Else
                    MyDs.Tables("Report_Sales_Order").Rows.Clear()
                    cmd.CommandText = "SELECT dbo.Sales_Header.Bill_ID, dbo.Sales_Header.Bill_Date, dbo.Sales_Header.Bill_Time, dbo.Stocks.Stock_Name,dbo.Stocks.Logo, dbo.Customers.Customer_Name,dbo.Employees.Employee_Name, dbo.Sales_Header.Total_Bill, dbo.Sales_Header.Discount_Type, dbo.Sales_Header.Discount_Value,dbo.Sales_Header.Cash_Value, dbo.Sales_Header.Credit_Value, dbo.Sales_Header.Pay_Type, dbo.Sales_Header.Comments, dbo.Sales_Header.Footer," & _
        " dbo.Items.Item_Name, dbo.Items.Barcode, dbo.Sales_Details.Quantity, dbo.Sales_Details.Price, dbo.Sales_Details.Discount_Type AS Item_Discount_Type,dbo.Sales_Details.Discount_Value AS Item_Discount_Value, dbo.Periods.Period_Name, dbo.Sales_Header.Order_Type, dbo.Sales_Details.Total_Item, dbo.Items.Single_Price" & _
        " FROM dbo.Sales_Header INNER JOIN dbo.Sales_Details ON dbo.Sales_Header.Bill_ID = dbo.Sales_Details.Bill_ID INNER JOIN dbo.Items ON dbo.Sales_Details.Item_ID = dbo.Items.Item_ID INNER JOIN dbo.Customers ON dbo.Sales_Header.Customer_ID = dbo.Customers.Customer_ID INNER JOIN dbo.Employees ON dbo.Sales_Header.Employee_ID = dbo.Employees.Employee_ID INNER JOIN dbo.Periods ON dbo.Sales_Header.Period_ID = dbo.Periods.Period_ID INNER JOIN dbo.Stocks ON dbo.Sales_Header.Stock_ID = dbo.Stocks.Stock_ID and sales_header.bill_id = " & BillID.Text
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Report_Sales_Order"))
                    If (MyDs.Tables("App_Preferences").Rows(0).Item("Show_Cust_Price")) Then
                        RptChk = New RptSalBillSP
                    Else
                        RptChk = New RptSalBill
                    End If
                    RptChk.SetDataSource(MyDs.Tables("Report_Sales_Order"))
                    Dim m As New ShowAllReports
                    m.CrystalReportViewer1.ReportSource = RptChk
                    m.ShowDialog()
                    Me.Cursor = Cursors.Default

                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
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