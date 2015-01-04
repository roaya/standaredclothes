Public Class ProfitSales

    Dim d1, d2 As Date

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            d1 = FromDate.Text
            d2 = ToDate.Text

            cmd.CommandText = "SELECT SUM(D.TOTAL_ITEM) FROM Items I,Sales_Header H,Sales_Details D WHERE H.Bill_ID=D.Bill_ID AND I.Item_ID=D.Item_ID and H.Bill_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalSale.Text = cmd.ExecuteScalar

            cmd.CommandText = "SELECT SUM(D.QUANTITY * I.PURCHASE_PRICE) FROM Items I,Sales_Header H,Sales_Details D WHERE H.Bill_ID=D.Bill_ID AND I.Item_ID=D.Item_ID and H.Bill_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            TotalCost.Text = cmd.ExecuteScalar

            TotalIncome.Text = TotalSale.Text - TotalCost.Text
        Catch ex As Exception
            cls.WriteError(ex.Message, "Profit Sales")
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
