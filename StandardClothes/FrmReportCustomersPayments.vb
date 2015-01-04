Public Class FrmReportcustomersPayments
    Dim tbl1 As New GeneralDataSet.CustomersDataTable
    Dim rpt As New Report_Customers_Payments
    Private Sub FrmReportcustomersPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cls.RefreshData("SELECT * FROM customers", TBL1)



        customerid.DataSource = TBL1
        CustomerID.ValueMember = "customer_id"
        CustomerID.DisplayMember = "customer_name"

    End Sub

    Private Sub RadAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadAll.CheckedChanged
        If RadAll.Checked = True Then
            customerid.Enabled = False
        End If
    End Sub

    Private Sub radcustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radcustomer.CheckedChanged
        If Radcustomer.Checked = True Then
            CustomerID.Enabled = True
        End If
    End Sub
    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

      
        Dim date1, date2 As Date
        date1 = CDate(DateTimePicker1.Text)
        date2 = CDate(DateTimePicker2.Text)

        MyDs.Tables("report_customers_payments").Rows.Clear()
        Me.Cursor = Cursors.WaitCursor

        If RadAll.Checked = True Then
            cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from report_customers_payments where payed_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

        ElseIf Radcustomer.Checked = True Then
            If CustomerID.Text = "" Then
                MsgBox("من فضلك اختر اسم العميل")
                Exit Sub
            Else
                cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from report_customers_payments where customer_id=" & CustomerID.SelectedValue & "and payed_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

            End If
        End If
        da.Fill(MyDs.Tables("report_customers_payments"))
        If MyDs.Tables("report_customers_payments").Rows.Count > 0 Then

            rpt.SetDataSource(MyDs.Tables("report_customers_payments"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)
        Else
            MsgBox("لا توجد بيانات")
        End If
        Me.Cursor = Cursors.Default

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
