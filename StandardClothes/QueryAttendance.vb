Public Class QueryAttendance
    Dim rptattendance As New RptEmployeesAttendance
    Dim rptvacation As New RptEmployeesVacations
    Dim t_Vac, T_Att As New DataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            T_Att.Rows.Clear()
            t_Vac.Rows.Clear()
            If RadioAllEmployees.Checked = True Then
                cmd.CommandText = "select employee_name , from_date, to_date from Query_Employees_Vacation"
                da.SelectCommand = cmd
                da.Fill(t_Vac)

            ElseIf RadioEmployeeID.Checked = True Then
                cmd.CommandText = "select employee_name , from_date, to_date from Query_Employees_Vacation where employee_id = " & EmployeeID.SelectedValue
                da.SelectCommand = cmd
                da.Fill(t_Vac)

            End If

            If RadioAllEmployees.Checked = True Then
                cmd.CommandText = "select employee_name , attend_date, attend_time,attend_type from Query_Employees_Attendance order by attend_date"
                da.SelectCommand = cmd
                da.Fill(T_Att)

            ElseIf RadioEmployeeID.Checked = True Then
                cmd.CommandText = "select employee_name , attend_date, attend_time,attend_type from Query_Employees_Attendance where employee_id = " & EmployeeID.SelectedValue & " order by attend_date"
                da.SelectCommand = cmd
                da.Fill(T_Att)

            End If

            EmpVacationDataGridView.DataSource = t_Vac
            EmpVacationDataGridView.Columns(0).HeaderText = "اسم الموظف"
            EmpVacationDataGridView.Columns(1).HeaderText = "من تاريخ"
            EmpVacationDataGridView.Columns(2).HeaderText = "الي تاريخ"
            '=================================================================
            AttendDataGridView.DataSource = T_Att
            AttendDataGridView.Columns(0).HeaderText = "اسم الموظف"
            AttendDataGridView.Columns(1).HeaderText = "تاريخ التسجيل"
            AttendDataGridView.Columns(2).HeaderText = "وقت التسجيل"
            AttendDataGridView.Columns(3).HeaderText = "نوع التسجيل"

            TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Query Attendance")
        End Try
    End Sub

    Private Sub RadioEmployeeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmployeeID.CheckedChanged
        If RadioEmployeeID.Checked = True Then
            EmployeeID.Enabled = True
        Else
            EmployeeID.Enabled = False
        End If
    End Sub

    Private Sub QueryAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("Employees")
            EmployeeID.DataSource = MyDs
            EmployeeID.ValueMember = "employees.employee_id"
            EmployeeID.DisplayMember = "employees.employee_name"
        Catch ex As Exception
            cls.WriteError(ex.Message, "Query Attendance")
        End Try

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = Cursors.WaitCursor
        rptattendance.SetDataSource(T_Att)
        CrystalReportViewer1.ReportSource = rptattendance
        TabControl1.SelectTab(2)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = Cursors.WaitCursor
        rptvacation.SetDataSource(t_Vac)
        CrystalReportViewer2.ReportSource = rptvacation
        TabControl1.SelectTab(3)
        Me.Cursor = Cursors.Default
    End Sub
End Class