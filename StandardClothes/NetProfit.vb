Public Class NetProfit

    Dim d1, d2 As Date

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            d1 = DateTimePicker1.Text
            d2 = DateTimePicker2.Text

            cmd.CommandText = "SELECT ISNULL(SUM(PAY_VALUE),0) FROM Vendors_Payments WHERE Payed_Date  between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalVendorPayments.Text = cmd.ExecuteScalar
            cmd.CommandText = "SELECT ISNULL(SUM(REWARD_VALUE),0) FROM Employees_Added_Hours WHERE Hours_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalAddedHours.Text = cmd.ExecuteScalar
            cmd.CommandText = "SELECT ISNULL(SUM(EXPENSE_VALUE),0) FROM Expenses_Details WHERE EXPENSE_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalExpenses.Text = cmd.ExecuteScalar
            cmd.CommandText = "SELECT ISNULL(SUM(NET_SALARY),0) FROM PAY_SALARY WHERE PAY_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalPaySalary.Text = cmd.ExecuteScalar
            cmd.CommandText = "SELECT ISNULL(SUM(Cash_Value),0) FROM Purchase_Header  WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalPurchase.Text = cmd.ExecuteScalar
            cmd.CommandText = "SELECT ISNULL(SUM(Total_Bill),0) FROM return_c_Header  WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalReturnCustomers.Text = cmd.ExecuteScalar

            cmd.CommandText = "SELECT ISNULL(SUM(Cash_Value),0) FROM Sales_Header  WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            ProfitSales.Text = cmd.ExecuteScalar
            cmd.CommandText = "SELECT ISNULL(SUM(Total_Bill),0) FROM return_v_Header  WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            ProfitReturnVendors.Text = cmd.ExecuteScalar
            cmd.CommandText = "SELECT ISNULL(SUM(PAY_VALUE),0) FROM Customers_Payments WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            ProfitCustomerPayments.Text = cmd.ExecuteScalar

            ProfitNet.Text = (CDbl(ProfitCustomerPayments.Text) + CDbl(ProfitReturnVendors.Text) + CDbl(ProfitSales.Text)) - (CDbl(TotalAddedHours.Text) + CDbl(TotalExpenses.Text) + CDbl(TotalPaySalary.Text) + CDbl(TotalPurchase.Text) + CDbl(TotalReturnCustomers.Text) + CDbl(TotalVendorPayments.Text))
            If CDbl(ProfitNet.Text) >= 0 Then
                ProfitNet.ForeColor = Color.Blue
                LblProfit.BackColor = Color.Blue
            Else
                ProfitNet.ForeColor = Color.Red
                LblProfit.BackColor = Color.Red
            End If

        Catch ex As Exception

        End Try
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
End Class