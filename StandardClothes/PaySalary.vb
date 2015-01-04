Public Class PaySalary

    Dim d1, d2 As Date
    Dim b As Boolean = False
    Dim SampleDate As Date
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable

    Private Sub PaySalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            cls.RefreshData(" select * from Employees", tbl1)
            cls.RefreshData("Pay_Salary")

            DataGridView1.DataSource = MyDs.Tables("Pay_Salary")
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "تاريخ الدفع"
            DataGridView1.Columns(3).HeaderText = "المرتب الاساسي"
            DataGridView1.Columns(4).HeaderText = "المكافأة"
            DataGridView1.Columns(5).HeaderText = "قيمة الخصم"
            DataGridView1.Columns(6).HeaderText = "صافي المرتب"
            DataGridView1.Columns(7).HeaderText = "ملاحظات"

            EmployeeID.DataSource = tbl1
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = ".Employee_ID"

            b = True

        Catch ex As Exception
            cls.WriteError(ex.Message, "Pay salary")
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click

        Try
            If b = True Then
                If Not EmployeeID.Text = "" Then
                    d1 = "01/" & PayMonth.Text
                    SampleDate = PayMonth.Text

                    d2 = Date.DaysInMonth(SampleDate.ToString("yyyy"), SampleDate.ToString("MM")) & "/" & PayMonth.Text

                    cmd.CommandText = "select isnull(sum(Salary),0) from Employees where Employee_ID = " & EmployeeID.SelectedValue
                    Salary.Text = cmd.ExecuteScalar()
                    cmd.CommandText = "select isnull(sum(reward_value),0) from Employees_rewards where employee_id = " & EmployeeID.SelectedValue & " and reward_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    EmpRewards.Text = cmd.ExecuteScalar
                    cmd.CommandText = "select isnull(sum(Discount_value),0) from Employees_Discounts where Employee_ID = " & EmployeeID.SelectedValue & " and discount_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    EmpDiscounts.Text = cmd.ExecuteScalar
                    NetSalary.Text = (CDbl(Salary.Text) + CDbl(EmpRewards.Text)) - CDbl(EmpDiscounts.Text)

                    MyDs.Tables("Pay_Salary").Rows.Clear()
                    cmd.CommandText = "select * from pay_salary where employee_id = " & EmployeeID.SelectedValue
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Pay_Salary"))
                Else
                    cls.MsgExclamation("أدخل اسم الموظف")
                End If


            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Pay Salary")
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            cmd.CommandText = "EXEC EMP_PAYMENTS " & EmployeeID.SelectedValue & "," & Salary.Text & "," & EmpRewards.Text & "," & EmpDiscounts.Text & "," & NetSalary.Text & ", '" & Notes.Text & "'"
            cmd.ExecuteNonQuery()
            MyDs.Tables("Pay_Salary").Rows.Clear()
            cls.MsgInfo("تم حفظ البيانات بنجاح")
        Catch ex As Exception
            cls.WriteError(ex.Message, "Pay Salary")
        End Try
    End Sub

   
    
   
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()


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
    Private Sub BtnSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.MouseLeave
        BtnSave.BackgroundImage = My.Resources.enter
        BtnSave.ForeColor = Color.Black
    End Sub

    Private Sub BtnSave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnSave.MouseMove
        BtnSave.BackgroundImage = My.Resources._end
        BtnSave.ForeColor = Color.White
    End Sub
End Class