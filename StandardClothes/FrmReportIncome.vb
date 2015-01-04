Public Class FrmReportIncome

    Dim date1, date2 As Date
    Dim rpt As New RptIncome
    Dim TblEmp As New GeneralDataSet.EmployeesDataTable
    Dim TblShifts As New GeneralDataSet.Query_ShiftsDataTable
    Dim bsource As New BindingSource
    Dim ListType As String
    Dim The_Type As String
    Dim sh_Emp_ID As Integer
    Dim TBL As New DataTable
    Private Sub FrmReportIncome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", TblEmp)

        emp.DataSource = TblEmp
        emp.DisplayMember = "Employee_name"
        emp.ValueMember = "employee_id"

        If INC = 1 Then
            cmd.CommandText = "select replace(employee_name + ' (" & FromDate.Value.ToString("dd/MM/yyyy") & ")' + N' من ' +isnull( Real_Start_Time,' ') + N' الى ' + isnull(Real_End_Time,' '),'?','') as employee_name,shift_Detail_id from query_Shifts where shift_Detail_id=" & CurrentShiftId
            Type.Text = cmd.ExecuteScalar
            FromDate.Text = Today.AddDays(-1)
            ToDate.Text = Today
            The_Type = "shift"
            sh_Emp_ID = CurrentShiftId
            MyDs.Tables("Income").Rows.Clear()




            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftId
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(pay_Value),0) from Customers_Payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مدفوعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftId
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select ISNULL(sum(pay_Value),0) from vendors_Payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مدفوعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(Expense_Value),0) from expenses_details r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المصروفات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)





            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False


            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            DataGridView1.Columns("desc").Visible = False
            DataGridView1.Columns("in_value").HeaderText = "القيمة"

        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        date1 = CDate(FromDate.Text)
        date2 = CDate(ToDate.Text)
        MyDs.Tables("Income").Rows.Clear()

        If FromDate.Value = Nothing Then
            MsgBox("برجاء ادخل التاريخ المراد الاستعلام به")
            Exit Sub
        End If



        If byemp.Checked = True Then

            If emp.SelectedValue = Nothing Then
                MsgBox("برجاء ادخل اسم الموظف")
                Exit Sub
            End If
            The_Type = "emp"
            Type.Text = emp.Text
            sh_Emp_ID = emp.SelectedValue


            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(pay_Value),0) from customers_payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مدفوعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select ISNULL(sum(pay_Value),0) from vendors_payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مدفوعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(expense_Value),0) from expenses_Details r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المصروفات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)




            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False


            DataGridView1.Columns("in_name").Width = 400
            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            DataGridView1.Columns("desc").Visible = False
            DataGridView1.Columns("in_value").HeaderText = "القيمة"

        ElseIf ByShift.Checked = True Then

            If Shift.SelectedValue = Nothing Then
                MsgBox("برجاء ادخل الورديه")
                Exit Sub
            End If
            The_Type = "shift"
            Type.Text = Shift.Text
            sh_Emp_ID = Shift.SelectedValue



            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(pay_value),0) from customers_payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مدفوعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(pay_value),0) from vendors_payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مدفوعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(expense_Value),0) from expenses_details r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المصروفات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)





            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False

            DataGridView1.Columns("in_name").Width = 400
            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            DataGridView1.Columns("desc").Visible = False
            DataGridView1.Columns("in_value").HeaderText = "القيمة"




        Else

            The_Type = "normal"
            Type.Text = FromDate.Value.ToString("dd/MM/yyyy") & " الى " & ToDate.Value.ToString("dd/MM/yyyy")


            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(pay_value),0) from customers_payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مدفوعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select ISNULL(sum(pay_value),0) from vendors_payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مدفوعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select ISNULL(sum(expense_value),0) from expenses_details r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المصروفات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False

            DataGridView1.Columns("in_name").Width = 400
            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            DataGridView1.Columns("desc").Visible = False
            DataGridView1.Columns("in_value").HeaderText = "القيمة"



        End If




        Total.Text = MyDs.Tables("Income").Compute("sum(In_Value)", "")



    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        rpt.SetDataSource(MyDs.Tables("income"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        If The_Type = "emp" Then
            rpt.SetParameterValue("Report_Type", "موظف - " & emp.SelectedValue & " - " & FromDate.Value.ToString("dd/MM/yyyy") & " - " & ToDate.Value.ToString("dd/MM/yyyy"))
        ElseIf The_Type = "shift" Then
            rpt.SetParameterValue("Report_Type", "ورديه - " & Type.Text)
        Else
            rpt.SetParameterValue("Report_Type", "تاريخ - " & FromDate.Value.ToString("dd/MM/yyyy") & " - " & ToDate.Value.ToString("dd/MM/yyyy"))
        End If
        CrystalReportViewer1.ReportSource = rpt
        TabControl1.SelectTab(1)
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

    Private Sub Button5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseMove
        Button5.BackgroundImage = My.Resources._end
        Button5.ForeColor = Color.White
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        Button5.BackgroundImage = My.Resources.enter
        Button5.ForeColor = Color.Black
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Leave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.GotFocus
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub


    Private Sub ByEmp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If byemp.Enabled = True Then
            emp.Enabled = True
            FromDate.Enabled = False
            Shift.Enabled = False
            ByShift.Enabled = False
        End If
    End Sub





    Private Sub byemp_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byemp.CheckedChanged
        If byemp.Checked = True Then
            emp.Enabled = True
            Shift.Enabled = False
            ByShift.Checked = False
        Else
            emp.Enabled = False
        End If
    End Sub


    Private Sub ByShift_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByShift.CheckStateChanged
        If ByShift.Checked = True Then
            Shift.Enabled = True
            emp.Enabled = False
            byemp.Checked = False
        Else
            Shift.Enabled = False
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim The_ID As Integer
        Dim Type As String
        Dim tblbills As New GeneralDataSet.BillsDataTable
        Try
            The_ID = DataGridView1.SelectedRows(0).Cells("in_id").Value
        Catch
        End Try
        Type = DataGridView1.SelectedRows(0).Cells("desc").Value.ToString
        If Type = "-" Then
            Type = DataGridView1.SelectedRows(0).Cells("in_name").Value.ToString
        End If

        TBL.Columns.Clear()


        If The_Type = "normal" Then
            If Type = "المبيعات" Then
                cls.RefreshData("select * from query_Sales where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "sales"
                TT.Text = "فواتير المبيعات"

            ElseIf Type = "المشتريات" Then
                cls.RefreshData("select * from query_purchase where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "purchase"
                TT.Text = "فواتير المشتريات"

            ElseIf Type = "مرتجعات الموردين" Then
                cls.RefreshData("select * from query_return_Vendors where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "النقدي"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "ven_Ret"
                TT.Text = "فواتير مرتجعات الموردين"
            ElseIf Type = "مرتجعات العملاء" Then
                cls.RefreshData("select * from query_return_customers where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "النقدي"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "cust_ret"
                TT.Text = "فواتير مرتجعات العملاء"

            ElseIf Type = "مدفوعات الموردين" Then
                cls.RefreshData("select c.Bill_ID,cu.vendor_Name,Pay_Value from vendors_payments c,purchase_Header sh,vendors cu,Shifts_details S  where cu.vendor_id=sh.vendor_id and c.bill_id=sh.bill_id and s.shift_Detail_id=c.shift_Detail_id and s.start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "اسم المورد"
                Bills.Columns(2).HeaderText = "قيمة المدفوع"


                ListType = "Ven_Pay"
                TT.Text = "مدفوعات الموردين"

            ElseIf Type = "مدفوعات العملاء" Then
                cls.RefreshData("select c.Bill_ID,cu.customer_name,Pay_Value from customers_payments c,Sales_header sh,Customers cu,Shifts_details S  where cu.customer_id=sh.customer_id and c.bill_id=sh.bill_id and s.shift_Detail_id=c.shift_Detail_id and s.start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "اسم العميل"
                Bills.Columns(2).HeaderText = "قيمة المدفوع"

                ListType = "cust_Pay"
                TT.Text = "مدفوعات العملاء"

            ElseIf Type = "المصروفات" Then
                cls.RefreshData("select Ec.Expense_Category_Name,E.Expense_Name,Expense_Value,Employee_Name from Expenses_Header EC,Expenses_Details E,Employees Ee,Shifts_Details s where EC.Expense_Category_ID=E.Expense_Category_ID and E.Employee_ID=Ee.Employee_ID and E.Shift_Detail_ID=s.Shift_Detail_ID and s.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "اسم البند"
                Bills.Columns(1).HeaderText = "اسم المصروف"
                Bills.Columns(2).HeaderText = "قيمة المصروف"
                Bills.Columns(3).HeaderText = "اسم الموظف"

                ListType = "Exp"
                TT.Text = "المصروفات"
            End If

        ElseIf The_Type = "shift" Then


            If Type = "المبيعات" Then
                cls.RefreshData("select * from query_Sales where shift_Detail_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "sales"
                TT.Text = "فواتير المبيعات"

            ElseIf Type = "المشتريات" Then
                cls.RefreshData("select * from query_purchase where Shift_Detail_ID=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "purchase"
                TT.Text = "فواتير المشتريات"

            ElseIf Type = "مرتجعات الموردين" Then
                cls.RefreshData("select * from query_return_Vendors where shift_detail_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "النقدي"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "ven_Ret"
                TT.Text = "فواتير مرتجعات الموردين"

            ElseIf Type = "مرتجعات العملاء" Then

                cls.RefreshData("select * from query_return_customers where Shift_Detail_ID=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "النقدي"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "cust_ret"
                TT.Text = "فواتير مرتجعات العملاء"

            ElseIf Type = "مدفوعات الموردين" Then

                cls.RefreshData("select c.Bill_ID,cu.vendor_Name,Pay_Value from vendors_payments c,purchase_Header sh,vendors cu,Shifts_details S  where cu.vendor_id=sh.vendor_id and c.bill_id=sh.bill_id and s.shift_Detail_id=c.shift_Detail_id and s.Shift_Detail_ID=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "اسم المورد"
                Bills.Columns(2).HeaderText = "قيمة المدفوع"


                ListType = "Ven_Pay"
                TT.Text = "مدفوعات الموردين"

            ElseIf Type = "مدفوعات العملاء" Then
                cls.RefreshData("select c.Bill_ID,cu.customer_name,Pay_Value from customers_payments c,Sales_header sh,Customers cu,Shifts_details S  where cu.customer_id=sh.customer_id and c.bill_id=sh.bill_id and s.shift_Detail_id=c.shift_Detail_id and s.Shift_Detail_ID=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "اسم العميل"
                Bills.Columns(2).HeaderText = "قيمة المدفوع"

                ListType = "cust_Pay"
                TT.Text = "مدفوعات العملاء"

            ElseIf Type = "المصروفات" Then
                cls.RefreshData("select Ec.Expense_Category_Name,E.Expense_Name,Expense_Value,Employee_Name from Expenses_Header EC,Expenses_Details E,Employees Ee,Shifts_Details s where EC.Expense_Category_ID=E.Expense_Category_ID and E.Employee_ID=Ee.Employee_ID and E.Shift_Detail_ID=s.Shift_Detail_ID and s.shift_Detail_ID=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "اسم البند"
                Bills.Columns(1).HeaderText = "اسم المصروف"
                Bills.Columns(2).HeaderText = "قيمة المصروف"
                Bills.Columns(3).HeaderText = "اسم الموظف"

                ListType = "Exp"
                TT.Text = "المصروفات"
            End If


        ElseIf The_Type = "emp" Then


            If Type = "المبيعات" Then
                cls.RefreshData("select * from query_Sales where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and Employee_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "sales"
                TT.Text = "فواتير المبيعات"

            ElseIf Type = "المشتريات" Then
                cls.RefreshData("select * from query_purchase where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and employee_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "purchase"
                TT.Text = "فواتير المشتريات"

            ElseIf Type = "مرتجعات الموردين" Then
                cls.RefreshData("select * from query_return_Vendors where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and employee_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "النقدي"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "ven_Ret"
                TT.Text = "فواتير مرتجعات الموردين"
            ElseIf Type = "مرتجعات العملاء" Then
                cls.RefreshData("select * from query_return_customers where start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and employee_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "النقدي"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "cust_ret"
                TT.Text = "فواتير مرتجعات العملاء"

            ElseIf Type = "مدفوعات الموردين" Then
                cls.RefreshData("select c.Bill_ID,cu.vendor_Name,Pay_Value from vendors_payments c,purchase_Header sh,vendors cu,Shifts_details S  where cu.vendor_id=sh.vendor_id and c.bill_id=sh.bill_id and s.shift_Detail_id=c.shift_Detail_id and s.start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and s.employee_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "اسم المورد"
                Bills.Columns(2).HeaderText = "قيمة المدفوع"


                ListType = "Ven_Pay"
                TT.Text = "مدفوعات الموردين"

            ElseIf Type = "مدفوعات العملاء" Then
                cls.RefreshData("select c.Bill_ID,cu.customer_name,Pay_Value from customers_payments c,Sales_header sh,Customers cu,Shifts_details S  where cu.customer_id=sh.customer_id and c.bill_id=sh.bill_id and s.shift_Detail_id=c.shift_Detail_id and s.start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and s.employee_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "اسم العميل"
                Bills.Columns(2).HeaderText = "قيمة المدفوع"

                ListType = "cust_Pay"
                TT.Text = "مدفوعات العملاء"

            ElseIf Type = "المصروفات" Then
                cls.RefreshData("select Ec.Expense_Category_Name,E.Expense_Name,Expense_Value,Employee_Name from Expenses_Header EC,Expenses_Details E,Employees Ee,Shifts_Details s where EC.Expense_Category_ID=E.Expense_Category_ID and E.Employee_ID=Ee.Employee_ID and E.Shift_Detail_ID=s.Shift_Detail_ID and s.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and s.employee_id=" & sh_Emp_ID, TBL)
                Bills.DataSource = TBL
                Bills.Columns(0).HeaderText = "اسم البند"
                Bills.Columns(1).HeaderText = "اسم المصروف"
                Bills.Columns(2).HeaderText = "قيمة المصروف"
                Bills.Columns(3).HeaderText = "اسم الموظف"

                ListType = "Exp"
                TT.Text = "المصروفات"
            End If


        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If Bills.SelectedRows(0).Cells("bill_id").Value = Nothing Then
                Exit Sub
            End If
        Catch
            Exit Sub
        End Try

        If ListType = "sales" Then
            Dim rptpur As New Report_Sales_Order
            MyDs.Tables("Report_Sales_order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Sales_order where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Sales_order"))
            rptpur.SetDataSource(MyDs.Tables("Report_Sales_order"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)

        ElseIf ListType = "cust_Pay" Then
            Dim rptpur As New Report_Sales_Order
            MyDs.Tables("Report_Sales_order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Sales_order where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Sales_order"))
            rptpur.SetDataSource(MyDs.Tables("Report_Sales_order"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)


        ElseIf ListType = "purchase" Then
            Dim rptpur As New Report_Purchase_Order
            MyDs.Tables("report_purchase_order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_purchase_order where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_purchase_order"))
            rptpur.SetDataSource(MyDs.Tables("report_purchase_order"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)

        ElseIf ListType = "Ven_Pay" Then
            Dim rptpur As New Report_Purchase_Order
            MyDs.Tables("report_purchase_order").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_purchase_order where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_purchase_order"))
            rptpur.SetDataSource(MyDs.Tables("report_purchase_order"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)

        ElseIf ListType = "ven_Ret" Then
            Dim rptpur As New Report_Vendors_Returns
            MyDs.Tables("report_vendors_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_vendors_Returns where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_vendors_Returns"))
            rptpur.SetDataSource(MyDs.Tables("report_vendors_Returns"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)

        ElseIf ListType = "cust_ret" Then
            Dim rptpur As New Report_Customers_Returns
            MyDs.Tables("report_Customers_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_Customers_Returns where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_Customers_Returns"))
            rptpur.SetDataSource(MyDs.Tables("report_Customers_Returns"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)

        End If
    End Sub

    Private Sub Button13_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseMove
        Button3.BackgroundImage = My.Resources._end
        Button3.ForeColor = Color.White

    End Sub

    Private Sub Button4_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseMove
        Button4.BackgroundImage = My.Resources._end
        Button4.ForeColor = Color.White
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black

    End Sub

    Private Sub Button4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Button4.BackgroundImage = My.Resources.enter
        Button4.ForeColor = Color.Black
    End Sub


    Private Sub FromDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromDate.Leave
        Try
            date1 = CDate(FromDate.Text)
            cls.RefreshData("select Shift_Name + ' - ' + Employee_Name + ' - ' + isnull(Real_Start_Time,'') + ' - ' + isnull(Real_End_Time  ,'') Employee_Name,Shift_Detail_Id from query_shifts where start_date='" & date1.ToString("MM/dd/yyyy") & "'", TblShifts)
            Shift.DataSource = TblShifts
            Shift.DisplayMember = "employee_Name"
            Shift.ValueMember = "shift_Detail_id"
        Catch
        End Try
    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Rpt As New RptInventoryLog
        Dim m As New ShowAllReports

        MyDs.Tables("report_inventory_log").Rows.Clear()

        If The_Type = "normal" Then

            cmd.CommandText = "select * from report_inventory_log I,Sales_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'فاتورة مبيعات' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Return_C_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'مرتجع عملاء' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Purchase_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'فاتورة مشتريات' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Return_V_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'مرتجع موردين' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

        ElseIf The_Type = "shift" Then
            cmd.CommandText = "select * from report_inventory_log I,Sales_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'فاتورة مبيعات' and sh.Shift_detail_ID=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Return_C_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'مرتجع عملاء' and sh.Shift_detail_ID=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Purchase_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'فاتورة مشتريات' and sh.Shift_detail_ID=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Return_V_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'مرتجع موردين' and sh.Shift_detail_ID=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

        Else
            cmd.CommandText = "select * from report_inventory_log I,Sales_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'فاتورة مبيعات' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and sh.employee_id=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Return_C_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'مرتجع عملاء' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and sh.employee_id=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Purchase_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'فاتورة مشتريات' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and sh.employee_id=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

            cmd.CommandText = "select * from report_inventory_log I,Return_V_Header s,shifts_Details sh where s.bill_id=I.Doc_ID and sh.shift_Detail_id=s.shift_Detail_id and Doc_Type=N'مرتجع موردين' and sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and sh.employee_id=" & sh_Emp_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_inventory_log"))

        End If


        Rpt.SetDataSource(MyDs.Tables("report_inventory_log"))
        Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        m.CrystalReportViewer1.ReportSource = Rpt
        m.ShowDialog()

    End Sub
End Class
