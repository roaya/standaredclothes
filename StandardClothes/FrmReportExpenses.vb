Public Class FrmReportExpenses
    Dim TBL1 As New GeneralDataSet.Expenses_DetailsDataTable
    Dim TBL2 As New GeneralDataSet.Expenses_HeaderDataTable
    Dim tbl3 As New GeneralDataSet.EmployeesDataTable
    Dim rpt As New Report_Expenses

    Private Sub FrmReportExpenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.RefreshData("SELECT * FROM employees", tbl3)
        cls.RefreshData("SELECT * FROM EXPENSES_DETAILS", TBL1)
        cls.RefreshData("SELECT * FROM Expenses_Header", TBL2)


        ExpenseID.DataSource = TBL1
        ExpenseID.ValueMember = "expense_detail_id"
        ExpenseID.DisplayMember = "expense_name"

        CATEGORYID.DataSource = TBL2
        categoryid.ValueMember = "expense_category_id"
        categoryid.DisplayMember = "expense_category_name"

        EmployeeID.DataSource = tbl3
        EmployeeID.ValueMember = "employee_id"
        EmployeeID.DisplayMember = "employee_name"
    End Sub

    Private Sub RadAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadAll.CheckedChanged
        If RadAll.Checked = True Then
            ExpenseID.Enabled = False
            CATEGORYID.Enabled = False
            EmployeeID.Enabled = False

        End If
    End Sub

    
    Private Sub RadCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCategory.CheckedChanged
        If RadCategory.Checked = True Then
            ExpenseID.Enabled = False
            CATEGORYID.Enabled = True
            EmployeeID.Enabled = False

        End If
    End Sub

    
    Private Sub RadExpense_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadExpense.CheckedChanged
        If RadExpense.Checked = True Then
            ExpenseID.Enabled = True
            CATEGORYID.Enabled = False
            EmployeeID.Enabled = False
        End If
    End Sub

    Private Sub RadEmp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEmp.CheckedChanged
        If RadEmp.Checked = True Then
            ExpenseID.Enabled = False
            CATEGORYID.Enabled = False
            EmployeeID.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim date1, date2 As Date
        date1 = CDate(DateTimePicker1.Text)
        date2 = CDate(DateTimePicker2.Text)

        MyDs.Tables("report_expenses").Rows.Clear()
        Me.Cursor = Cursors.WaitCursor

        If RadAll.Checked = True Then
            cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from report_expenses where expense_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

        ElseIf RadCategory.Checked = True Then
            If CATEGORYID.Text = "" Then
                MsgBox("من فضلك اختر بند المصروف")
                Exit Sub
            Else
                cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from report_expenses where expense_category_id=" & categoryid.SelectedValue & "and expense_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

            End If

        ElseIf RadExpense.Checked = True Then
            If ExpenseID.Text = "" Then
                MsgBox("من فضلك اختر اسم المصروف")
                Exit Sub
            Else
                cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from report_expenses where expense_detail_id=" & ExpenseID.SelectedValue & "and expense_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

            End If

        ElseIf RadEmp.Checked = True Then
            If EmployeeID.Text = "" Then
                MsgBox("من فضلك اختر اسم الموظف")
                Exit Sub
            Else
                cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from report_expenses where employee_id=" & EmployeeID.SelectedValue & "and expense_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

            End If
        End If
        da.Fill(MyDs.Tables("report_expenses"))
        If MyDs.Tables("report_expenses").Rows.Count > 0 Then

            rpt.SetDataSource(MyDs.Tables("report_expenses"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)
        Else
            MsgBox("لا توجد بيانات")
        End If
        Me.Cursor = Cursors.Default

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