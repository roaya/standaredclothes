Public Class QueryByEmployee
    Dim Gcls As GeneralSp.MasterForms
    Dim B_EndLoad As Boolean = False
    Dim ITEM_NAME As String
    Dim selformula As String
    Dim Query_Employee As New DataTable
    Dim d1, d2 As Date

    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Query_Employees"
    Private Sub QueryByEmployee_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataClear()
        DataLoad()
    End Sub
#Region "DataMethods"
    Private Sub DataClear()
        cmbJops.SelectedIndex = -1
        cmbEmployeeID.SelectedIndex = -1
        RadJop.Checked = False
        Query_Employee.Rows.Clear()
        RadEmpID.Checked = True
    End Sub
    Private Sub DataLoad()
        cmd.CommandText = "select Job_Title from Jobs"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            cmbJops.Items.Add(dr("Job_Title"))
        Loop
        dr.Close()
        cmd.CommandText = "select Employee_Name from Employees"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            cmbEmployeeID.Items.Add(dr("Employee_Name"))
        Loop
        dr.Close()
    End Sub

    Private Function DataValidate(errorMessage As String) As Boolean
        If cmbJops.SelectedIndex = -1 And
            cmbEmployeeID.SelectedIndex = -1 Then
            DataValidate = False
            errorMessage = "All required fields not been enterd data."
        Else
            DataValidate = True
            errorMessage = ""

        End If

    End Function

#End Region
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click


        choseForm()
        DataClear()
        cmd.CommandText = "" & selformula & ""
        da.SelectCommand = cmd
        If cmd.CommandText = "" Then MsgBox("رجاء ادخال البيانات الناقصه") : Exit Sub
        da.Fill(Query_Employee)
        If Query_Employee.Rows.Count > 0 Then
            TabControl1.SelectedTab = TabPage2
            DataGridView1.Refresh()
            DataGridView1.DataSource = Query_Employee
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(0).HeaderText = "كود الموظف"
            DataGridView1.Columns(1).HeaderText = "اسم الموظف"
            DataGridView1.Columns(2).HeaderText = "الوظيفة"
            DataGridView1.Columns(3).HeaderText = "العنوان"
            DataGridView1.Columns(4).HeaderText = "التليفون"
            DataGridView1.Columns(5).HeaderText = "المحمول"
            DataGridView1.Columns(6).HeaderText = "المرتب"
            DataGridView1.Columns(7).HeaderText = "تاريخ التعيين"
            DataGridView1.Columns(8).HeaderText = "المستوى التعليمى"
            DataGridView1.Columns(9).HeaderText = "البريد الالكترونى"
        Else
            MsgBox("لا توجد بيانات")
        End If

    End Sub

    Private Sub RadEmpID_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadEmpID.CheckedChanged
        If RadEmpID.Checked = True Then
            cmbEmployeeID.Enabled = True
        Else
            cmbEmployeeID.Enabled = False
            cmbEmployeeID.SelectedIndex = -1
        End If
        cmbJops.SelectedIndex = -1
        cmbJops.Enabled = False
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False

    End Sub

    Private Sub RadJop_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadJop.CheckedChanged
        If RadJop.Checked = True Then
            cmbJops.Enabled = True
        Else
            cmbJops.Enabled = False
            cmbJops.SelectedIndex = -1
        End If
        cmbEmployeeID.SelectedIndex = -1
        cmbEmployeeID.Enabled = False
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub RadHirdate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadHirdate.CheckedChanged
        If RadHirdate.Checked = True Then
            RadHirdate.Enabled = True
        Else
            cmbJops.Enabled = False
            cmbJops.SelectedIndex = -1
        End If
        cmbEmployeeID.SelectedIndex = -1
        cmbEmployeeID.Enabled = False
        cmbJops.SelectedIndex = -1
        cmbJops.Enabled = False
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
    End Sub
    Private Sub choseForm()
        selformula = ""
        If cmbEmployeeID.SelectedIndex <> -1 Then
            selformula = "select * from Query_Employees where Employee_Name=N'" & (cmbEmployeeID.Text) & "'"

        End If

        If cmbJops.SelectedIndex <> -1 Then
            selformula = "select * from Query_Employees where Job_Title=N'" & (cmbJops.Text) & "'"
        End If


        If RadHirdate.Checked = True Then
            d1 = DateTimePicker1.Text
            d2 = DateTimePicker2.Text

            selformula = "select * from Query_Employees where Hire_Date between '" & d1.ToString("MM/dd/yyyy") & "'  and   '" & d2.ToString("MM/dd/yyyy") & "'"

        End If
    End Sub
End Class