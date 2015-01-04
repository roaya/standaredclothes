Public Class ReportCustomerRequest

    Dim b As Boolean = False
    Dim RptCustReq As New Report_Customers_Requests

    Private Sub ReportCustomerRequest_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub

    Private Sub ReportCustomerRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData("Employees")
            cls.RefreshData("Customers")
            cls.RefreshData("Stocks")

            ItemName.Items.Clear()
            cmd.CommandText = "select item_name from items"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ItemName.Items.Add(dr("Item_Name"))
            Loop
            dr.Close()

            StockID.DataSource = MyDs
            StockID.DisplayMember = "Stocks.stock_Name"
            StockID.ValueMember = "Stocks.stock_ID"

            EmployeeID.DataSource = MyDs
            EmployeeID.DisplayMember = "Employees.Employee_Name"
            EmployeeID.ValueMember = "Employees.Employee_ID"

            CustomerID.DataSource = MyDs
            CustomerID.DisplayMember = "Customers.Customer_Name"
            CustomerID.ValueMember = "Customers.Customer_ID"

            b = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub


    Private Sub RadioCustomerID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCustomerID.CheckedChanged
        If RadioCustomerID.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = True
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
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
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
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
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
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
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioExpired_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioExpired.CheckedChanged
        If RadioExpired.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            DateTimePicker3.Enabled = True
            DateTimePicker4.Enabled = True
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub


    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If b = True Then
                cmd.CommandText = "select distinct Request_ID from Report_Customers_Requests where item_name = N'" & ItemName.Text & "'"
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Request_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub

    Private Sub Barcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Barcode.Leave
        Try
            If b = True Then
                cmd.CommandText = "select distinct Request_ID from Report_Customers_Requests where barcode = '" & Barcode.Text & "'"
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Request_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub

    Private Sub CustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select distinct Request_ID from Request_Header where Customer_id = " & CustomerID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Request_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select distinct Request_ID from Request_Header where employee_id = " & EmployeeID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Request_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub

    Private Sub StockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select distinct Request_ID from Request_Header where stock_id = " & EmployeeID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Request_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub

    Private Sub RadioDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDates.CheckedChanged
        If RadioDates.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.Leave, DateTimePicker2.Leave
        Try
            Dim date1 As Date = CDate(DateTimePicker1.Text)
            Dim date2 As Date = CDate(DateTimePicker2.Text)
            cmd.CommandText = "select distinct Request_ID from Report_Customers_Requests where Bill_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("Request_ID"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub

    Private Sub RadioEmployeeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmployeeID.CheckedChanged
        If RadioEmployeeID.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = True
            CustomerID.Enabled = False
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub DateTimePicker3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker3.Leave, DateTimePicker4.Leave
        Try
            Dim date1 As Date = CDate(DateTimePicker3.Text)
            Dim date2 As Date = CDate(DateTimePicker4.Text)
            cmd.CommandText = "select distinct Request_ID from Report_Customers_Requests where Expired_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("Request_ID"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
        End Try
    End Sub

    
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If BillID.Text = "" Then
                cls.MsgExclamation("اختر رقم الفاتورة")
            Else
                MyDs.Tables("Report_Customers_Requests").Rows.Clear()
                cmd.CommandText = "select * from Report_Customers_Requests where Request_ID = " & BillID.Text
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Customers_Requests"))
                RptCustReq.SetDataSource(MyDs.Tables("Report_Customers_Requests"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustReq
                m.ShowDialog()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Cust Request")
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
End Class