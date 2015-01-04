Public Class ReScheduling
    Dim tname As String = "customers_payments"
    Dim tblCustomerPyments As New GeneralDataSet.Customers_PaymentsDataTable
    Dim BSourceCustPayment As New BindingSource
    Dim cmdb As New SqlClient.SqlCommandBuilder
    Private Sub ReScheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            tblCustomerPyments.Rows.Clear()


            DataGridView1.DataSource = BSourceCustPayment
            cls.RefreshData("select * from customers_payments", tblCustomerPyments)
            BSourceCustPayment.DataSource = tblCustomerPyments

            BSourceCustPayment.Filter = "bill_id=" & Bill
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).HeaderText = "تاريخ الدفعه"

            DataGridView1.Columns(2).HeaderText = "تاريخ السداد"
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).HeaderText = "رقم الفاتوره"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "قيمه الدفعه"
            DataGridView1.Columns(5).HeaderText = "حاله الدفعه"
            DataGridView1.Columns(5).ReadOnly = True
            cmd.CommandText = "select isnull(sum(pay_value),0) from customers_payments where status=N'مجدولة' and  bill_id =" & Bill
            Remain.Text = cmd.ExecuteScalar

            cmd.CommandText = "select isnull(sum(pay_value),0) from customers_payments where status=N'مدفوعة' and  bill_id =" & Bill
            Total_Payed.Text = cmd.ExecuteScalar


            cmd.CommandText = "select credit_value from sales_header where  bill_id=" & Bill
            TotalSalCredit.Text = cmd.ExecuteScalar

            Total_credit.Text = Cr_Value


            Required.Text = Remain.Text - Total_credit.Text

        Catch ex As Exception


            cls.WriteError(ex.Message, tname)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim total As Double


            total = tblCustomerPyments.Compute("sum(pay_value)", "bill_id=" & Bill & " and status='مجدولة'")


            If total <> Required.Text Then
                cls.MsgExclamation("عفوا يجب ان يتساوى اجمالى الاقساط مع قيمه الاجل")
            Else

                BSourceCustPayment.EndEdit()
                cmd.CommandText = "select * from " & tname
                cmdb.DataAdapter = da
                da.Update(tblCustomerPyments)
                cls.RefreshData("select * from customers_payments", tblCustomerPyments)
                cls.MsgInfo("تم حفظ التغييرات بنجاح")

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, tname)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tblCustomerPyments.Columns("bill_id").DefaultValue = Bill
        tblCustomerPyments.Columns("status").DefaultValue = "مجدولة"
        tblCustomerPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
        BSourceCustPayment.AddNew()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim total As Double
        Dim t As String = "مجدولة"
        Dim ts As String = "مدفوعة"
        t = tblCustomerPyments.Compute("sum(pay_value) ", "PAY_C_ID =18 ")
        'ts = tblCustomerPyments.Compute("sum(pay_value)", "bill_id=" & Bill)

    End Sub

   

    Private Sub ReScheduling_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim total As Double

        total = tblCustomerPyments.Compute("sum(pay_value)", "bill_id=" & Bill & " and status='مجدولة'")



        If total <> Required.Text Then
            cls.MsgExclamation("عفوا يجب ان يتساوى اجمالى الاقساط مع قيمه الاجل")
            e.Cancel = True
            Exit Sub

        End If

       

    End Sub

End Class