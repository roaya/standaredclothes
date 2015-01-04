Public Class QueryByExpenses
    Dim t As New DataTable
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Private Sub QueryByExpenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", tbl1)
        EmployeeID.DataSource = tbl1
        EmployeeID.DisplayMember = "Employee_name"
        EmployeeID.ValueMember = "employee_id"
        DataGridView1.Columns(0).HeaderText = ""
    End Sub

    Sub s()

        cmd.CommandText = "select * from Query_Employees_Discounts where employee_id = " & EmployeeID.SelectedValue
        da.SelectCommand = cmd
        da.Fill(t)
        DataGridView1.DataSource = t

    End Sub

   
End Class