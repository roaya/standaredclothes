Public Class QueryEmpByJobDep
    Dim Rpt As New RptEmployees
    Dim t As New DataTable
    Dim tbl1 As New GeneralDataSet.JobsDataTable
    Dim tbl2 As New GeneralDataSet.DepartmentsDataTable

    Private Sub QueryEmpByJobDep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from jobs", tbl1)
            cls.RefreshData("select * from departments", tbl2)

            JobID.DataSource = tbl1
            JobID.DisplayMember = "Job_Title"
            JobID.ValueMember = "Job_ID"

            DepartmentID.DataSource = tbl2
            DepartmentID.DisplayMember = "Department_Name"
            DepartmentID.ValueMember = "Department_ID"
            DataGridView1.DataSource = MyDs.Tables("report_employees")
            DataGridView1.Columns(0).HeaderText = "اسم الاداره"
            DataGridView1.Columns(1).HeaderText = "الوظيفه"
            DataGridView1.Columns(2).HeaderText = "اسم الموظف"
            DataGridView1.Columns(3).HeaderText = "الكود"
            DataGridView1.Columns(4).HeaderText = "المرتب"
            DataGridView1.Columns(5).HeaderText = "تاريخ التعاقد"
            DataGridView1.Columns(6).HeaderText = "الموبيل"
            DataGridView1.Columns(7).HeaderText = "العنوان"
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(9).Visible = False
            DataGridView1.Columns(10).Visible = False
            DataGridView1.Columns(11).Visible = False
        Catch ex As Exception
            cls.WriteError(ex.Message, "Query Emp Job Dep")
        End Try
    End Sub

  

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub RadioJobID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioJobID.CheckedChanged
        If RadioJobID.Checked = True Then
            JobID.Enabled = True
            DepartmentID.Enabled = False
        End If
    End Sub

    Private Sub RadioDepID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDepID.CheckedChanged
        If RadioDepID.Checked = True Then
            DepartmentID.Enabled = True
            JobID.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            MyDs.Tables("report_employees").Rows.Clear()
            If RadioJobID.Checked = True Then
                If JobID.Text = "" Then
                    cls.MsgExclamation("اختر المسمي الوظيفي")

                    Exit Sub
                Else

                    cmd.CommandText = "select * from report_employees where job_id = " & JobID.SelectedValue

                End If
            ElseIf RadioDepID.Checked = True Then
                If DepartmentID.Text = "" Then
                    cls.MsgExclamation("اختر اسم الادارة")
                    Exit Sub
                Else
                    t.Rows.Clear()
                    cmd.CommandText = " select * from report_employees where  department_id = " & DepartmentID.SelectedValue

                End If
            End If
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_employees"))
            If MyDs.Tables("report_employees").Rows.Count > 0 Then

                DataGridView1.DataSource = MyDs.Tables("report_employees")

            Else
                MsgBox("لا توجد بيانات")
            End If
         
        Catch ex As Exception
            cls.WriteError(ex.Message, "Query Emp Job Dep")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
    Private Sub Button3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseMove
        Button3.BackgroundImage = My.Resources._end
        Button3.ForeColor = Color.White
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Rpt.SetDataSource(MyDs.Tables("report_employees"))
        CrystalReportViewer1.ReportSource = Rpt
        TabControl1.SelectTab(1)
    End Sub
End Class