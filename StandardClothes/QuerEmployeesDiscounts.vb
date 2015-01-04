
Public Class QuerEmployeesDiscounts
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.Discount_CategoriesDataTable

    Dim rpt As New RptEmployeesDiscounts
    Private Sub QuerEmployeesDiscounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.RefreshData("select * from employees", tbl1)
        cls.RefreshData("select * from discount_categories", tbl2)
        cmbEmployeeID.DataSource = tbl1
        cmbEmployeeID.DisplayMember = "employee_name"
        cmbEmployeeID.ValueMember = "employee_id"

        cmbCat.DataSource = tbl2
        cmbCat.DisplayMember = "category_name"
        cmbCat.ValueMember = "category_id"




        DataGridView1.DataSource = MyDs.Tables("query_employees_discounts")
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(0).HeaderText = "نوع الخصم"
        DataGridView1.Columns(1).HeaderText = "اسم الموظف"
        DataGridView1.Columns(2).HeaderText = "تاريخ الخصم"
        DataGridView1.Columns(3).HeaderText = "سبب الخصم"
        DataGridView1.Columns(4).HeaderText = "قيمة الخصم"
        'DataGridView1.Columns(5).HeaderText = "كود الموظف"
        'DataGridView1.Columns(6).HeaderText = "كود الخصم"
    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            MyDs.Tables("query_employees_discounts").Rows.Clear()

            Dim d1, d2 As Date
            d1 = CDate(DateTimePicker1.Text)
            d2 = CDate(DateTimePicker2.Text)
            If RadEmpID.Checked = True Then


                If cmbEmployeeID.Text = "" Then
                    MsgBox("برجاء اختيار الموظف")
                    cmbEmployeeID.Focus()
                    Exit Sub
                Else
                    cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from query_employees_discounts where employee_id =" & cmbEmployeeID.SelectedValue & " and discount_date between N'" & d1.ToString("MM/dd/yyyy") & "' and N'" & d2.ToString("MM/dd/yyyy") & "'"
                End If

            ElseIf RadJop.Checked = True Then
                If cmbCat.Text = "" Then
                    MsgBox("برجاء اختيار نوع الخصم")
                    cmbCat.Focus()
                    Exit Sub

                Else

                    cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo from query_employees_discounts where category_id =" & cmbCat.SelectedValue & " and discount_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

                End If

            Else
                cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from query_employees_discounts where discount_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

            End If
            da.Fill(MyDs.Tables("query_employees_discounts"))
            If MyDs.Tables("query_employees_discounts").Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor
                DataGridView1.DataSource = MyDs.Tables("query_employees_discounts")
                TabControl1.SelectTab(1)
                Me.Cursor = Cursors.Default
            Else

                MsgBox("لا توجد بيانات")
            End If

         
        Catch ex As Exception
            cls.WriteError(ex.Message, "Query Emp Discount")
        End Try


    End Sub

    Private Sub RadEmpID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEmpID.CheckedChanged
        If RadEmpID.Checked = True Then
            cmbEmployeeID.Enabled = True

            cmbCat.Enabled = False

        End If


    End Sub

    Private Sub RadJop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadJop.CheckedChanged
        If RadJop.Checked = True Then
            cmbEmployeeID.Enabled = False

            cmbCat.Enabled = True

        End If

    End Sub

    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radall.CheckedChanged
        If Radall.Checked = True Then
            cmbEmployeeID.Enabled = False

            cmbCat.Enabled = False

        End If

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        If MyDs.Tables("query_employees_discounts").Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            rpt.SetDataSource(MyDs.Tables("query_employees_discounts"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(2)
            Me.Cursor = Cursors.Default
        Else

            MsgBox("لا توجد بيانات")
        End If
       
    End Sub

    Private Sub Button3_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseMove
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black

    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black
    End Sub
End Class