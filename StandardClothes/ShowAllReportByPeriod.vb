Public Class ShowAllReportByPeriod


    Dim date1, date2 As Date

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            date1 = DateTimePicker1.Text
            date2 = DateTimePicker2.Text

            MyDs.Tables("Most_Sales_Emp_All").Clear()

            cmd.CommandText = "SELECT E.EMPLOYEE_Name, ISNULL(SUM(D.Total_Item),0) AS TOTAL_SALES FROM dbo.EMPLOYEES AS E,dbo.Sales_Details AS D ,dbo.Sales_Header AS H where E.EMPLOYEE_ID=H.EMPLOYEE_ID and D.Bill_ID = H.Bill_ID and h.bill_date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' GROUP BY E.EMPLOYEE_Name"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Sales_Emp_All"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostSalesEmpAll
            rpt.SetDataSource(MyDs.Tables("Most_Sales_Emp_All"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.ShowDialog()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Show All Rpt by Period")
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Me.Close()
    End Sub
End Class
