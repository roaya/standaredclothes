Public Class vendorsReScheduling
    Dim tname As String = "vendors_payments"
    ' Dim tblvendorsPyments As New GeneralDataSet.Vendors_PaymentsDataTable

    Dim cmdb As New SqlClient.SqlCommandBuilder

    Private Sub ReScheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            'tblvendorsPyments.Rows.Clear()



            DataGridView1.DataSource = BSourceVenPayment
            If vre = False Then

                cls.RefreshData("select * from vendors_payments where bill_id=" & VendBill, tblvendorsPyments)
            End If
            BSourceVenPayment.DataSource = tblvendorsPyments
            
            BSourceVenPayment.Filter = "bill_id=" & VendBill
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).HeaderText = "تاريخ الدفعه"

            DataGridView1.Columns(2).HeaderText = "تاريخ السداد"
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).HeaderText = "رقم الفاتوره"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "قيمه الدفعه"
            DataGridView1.Columns(5).HeaderText = "حاله الدفعه"
            DataGridView1.Columns(5).ReadOnly = True
            cmd.CommandText = "select isnull(sum(pay_value),0) from vendors_payments where status=N'مجدولة' and  bill_id =" & VendBill
            Remain.Text = cmd.ExecuteScalar

            cmd.CommandText = "select isnull(sum(pay_value),0) from vendors_payments where status=N'مدفوعة' and  bill_id =" & VendBill
            Total_Payed.Text = cmd.ExecuteScalar


            cmd.CommandText = "select credit_value from purchase_header where  bill_id=" & VendBill
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


            total = tblvendorsPyments.Compute("sum(pay_value)", "bill_id=" & VendBill & " and status='مجدولة'")


            If total <> Required.Text Then
                cls.MsgExclamation("عفوا يجب ان يتساوى اجمالى الاقساط مع قيمه الاجل")
            Else
                tblvendorsPyments.AcceptChanges()
                BSourceVenPayment.EndEdit()

                cls.MsgInfo("تمت الجدوله بنجاح")
                vre = True
                Me.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, tname)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tblvendorsPyments.Columns("bill_id").DefaultValue = VendBill
        tblvendorsPyments.Columns("status").DefaultValue = "مجدولة"
        tblvendorsPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
        tblvendorsPyments.Columns("pay_value").DefaultValue = 0
        BSourceVenPayment.AddNew()
    End Sub

   



    Private Sub ReScheduling_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim total As Double

        total = tblvendorsPyments.Compute("sum(pay_value)", "bill_id=" & VendBill & " and status='مجدولة'")



        If total <> Required.Text Then
            cls.MsgExclamation("عفوا يجب ان يتساوى اجمالى الاقساط مع قيمه الاجل")
            e.Cancel = True
            Exit Sub

        End If



    End Sub

End Class