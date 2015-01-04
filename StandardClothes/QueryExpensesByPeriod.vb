Public Class QueryExpensesByPeriod

    'Dim RptExpenses As New Report_Expenses
    Dim t As New DataTable
    Dim d1, d2 As Date

    Private Sub QueryExpensesByPeriod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CategoryID.Items.Clear()
        cmd.CommandText = "select Expense_Category_Name from Expenses_Header"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            CategoryID.Items.Add(dr("Expense_Category_Name"))
        Loop
        dr.Close()

        cls.LoadList("Expense_Name", "Expenses_Details", ExpenseName)
        cls.LoadList("Employee_Name", "Employees", EmployeeName)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = DateTimePicker1.Text
        d2 = DateTimePicker2.Text

        If RadioExpenseCategory.Checked = True And CheckByPeriod.Checked = False Then
            Me.Cursor = Cursors.WaitCursor
            t.Rows.Clear()
            cmd.CommandText = "SELECT Expense_Category_Name AS '«”„ »‰œ«·„’—Ê›« ' , Expense_Name AS '«”„ «·„’—Ê›' , Expense_Value AS 'ﬁÌ„ Â' , Expense_Date AS ' «—ÌŒ «·„’—Ê›' , Employee_Name AS '«”„ «·„”∆Ê·' FROM Report_Expenses where Expense_Category_Name = N'" & CategoryID.Text & "' ORDER BY Expense_Category_Name"
            da.Fill(t)
            DataGridView1.DataSource = t
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
        ElseIf RadioExpenseCategory.Checked = True And CheckByPeriod.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            t.Rows.Clear()
            cmd.CommandText = "SELECT Expense_Category_Name AS '«”„ »‰œ«·„’—Ê›« ' , Expense_Name AS '«”„ «·„’—Ê›' , Expense_Value AS 'ﬁÌ„ Â' , Expense_Date AS ' «—ÌŒ «·„’—Ê›' , Employee_Name AS '«”„ «·„”∆Ê·' FROM Report_Expenses where Expense_Category_Name = N'" & CategoryID.Text & "' and expense_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' ORDER BY Expense_Category_Name"
            da.Fill(t)
            DataGridView1.DataSource = t
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If RadioExpenseName.Checked = True And CheckByPeriod.Checked = False Then
            Me.Cursor = Cursors.WaitCursor
            t.Rows.Clear()
            cmd.CommandText = "SELECT Expense_Category_Name AS '«”„ »‰œ«·„’—Ê›« ' , Expense_Name AS '«”„ «·„’—Ê›' , Expense_Value AS 'ﬁÌ„ Â' , Expense_Date AS ' «—ÌŒ «·„’—Ê›' , Employee_Name AS '«”„ «·„”∆Ê·' FROM Report_Expenses where Expense_Name = N'" & ExpenseName.Text & "' ORDER BY Expense_Category_Name"
            da.Fill(t)
            DataGridView1.DataSource = t
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
        ElseIf RadioExpenseName.Checked = True And CheckByPeriod.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            t.Rows.Clear()
            cmd.CommandText = "SELECT Expense_Category_Name AS '«”„ »‰œ«·„’—Ê›« ' , Expense_Name AS '«”„ «·„’—Ê›' , Expense_Value AS 'ﬁÌ„ Â' , Expense_Date AS ' «—ÌŒ «·„’—Ê›' , Employee_Name AS '«”„ «·„”∆Ê·' FROM Report_Expenses where Expense_Name = N'" & ExpenseName.Text & "' and expense_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' ORDER BY Expense_Category_Name"
            da.Fill(t)
            DataGridView1.DataSource = t
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If RadioEmployeeName.Checked = True And CheckByPeriod.Checked = False Then
            Me.Cursor = Cursors.WaitCursor
            t.Rows.Clear()
            cmd.CommandText = "SELECT Expense_Category_Name AS '«”„ »‰œ«·„’—Ê›« ' , Expense_Name AS '«”„ «·„’—Ê›' , Expense_Value AS 'ﬁÌ„ Â' , Expense_Date AS ' «—ÌŒ «·„’—Ê›' , Employee_Name AS '«”„ «·„”∆Ê·' FROM Report_Expenses where Employee_Name = N'" & EmployeeName.Text & "' ORDER BY Expense_Category_Name"
            da.Fill(t)
            DataGridView1.DataSource = t
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
        ElseIf RadioEmployeeName.Checked = True And CheckByPeriod.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            t.Rows.Clear()
            cmd.CommandText = "SELECT Expense_Category_Name AS '«”„ »‰œ«·„’—Ê›« ' , Expense_Name AS '«”„ «·„’—Ê›' , Expense_Value AS 'ﬁÌ„ Â' , Expense_Date AS ' «—ÌŒ «·„’—Ê›' , Employee_Name AS '«”„ «·„”∆Ê·' FROM Report_Expenses where Employee_Name = N'" & EmployeeName.Text & "' and expense_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' ORDER BY Expense_Category_Name"
            da.Fill(t)
            DataGridView1.DataSource = t
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
        End If


    End Sub

    Private Sub RadioExpenseCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioExpenseCategory.CheckedChanged
        If RadioExpenseCategory.Checked = True Then
            CategoryID.Enabled = True
            EmployeeName.Enabled = False
            ExpenseName.Enabled = False
            'You should disable other fields and enable only the checked
        End If
    End Sub

    Private Sub RadioEmployeeName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmployeeName.CheckedChanged
        If RadioEmployeeName.Checked = True Then
            CategoryID.Enabled = False
            EmployeeName.Enabled = True
            ExpenseName.Enabled = False
            'You should disable other fields and enable only the checked
        End If
    End Sub

    Private Sub RadioExpenseName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioExpenseName.CheckedChanged
        If RadioExpenseName.Checked = True Then
            CategoryID.Enabled = False
            EmployeeName.Enabled = False
            ExpenseName.Enabled = True
            'You should disable other fields and enable only the checked
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

    
End Class