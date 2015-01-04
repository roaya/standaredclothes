Public Class EmployeesDiscounts

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceEmployees_Discounts As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Employees_Discounts"
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.Discount_CategoriesDataTable
    '-------------------------------

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(TName)
            cls.RefreshData(" select * from Employees", tbl1)
            cls.RefreshData(" select * from Discount_Categories", tbl2)


            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.DataSource = B
            OrderByCombo.DisplayMember = "Logical_Name"
            OrderByCombo.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceEmployees_Discounts, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords, MenuNew, MenuSave, MenuDelete, MenuSearch, MenuExit)
            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            Gcls.SetWTitle = "Œ’Ê„«  «·„— »« "
            Me.Text = Gcls.SetWTitle

            DiscountDate.DataBindings.Add("Text", BSourceEmployees_Discounts, "Discount_Date")
            DiscountsValue.DataBindings.Add("Value", BSourceEmployees_Discounts, "Discount_Value")
            Reason.TextBox1.DataBindings.Add("Text", BSourceEmployees_Discounts, "Reason")

            CategoryID.DataSource = tbl2
            CategoryID.DisplayMember = "Category_Name"
            CategoryID.ValueMember = "Category_ID"
            CategoryID.DataBindings.Add("SelectedValue", BSourceEmployees_Discounts, "Category_ID")

            EmployeeID.DataSource = tbl1
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"
            EmployeeID.DataBindings.Add("SelectedValue", BSourceEmployees_Discounts, "Employee_ID")
            DataGridView1.DataSource = BSourceEmployees_Discounts
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = " «—ÌŒ «·Œ’„"
            DataGridView1.Columns(3).HeaderText = "”»» «·Œ’„"
            DataGridView1.Columns(4).HeaderText = "ﬁÌ„… «·Œ’„"
            DataGridView1.Columns(5).Visible = False
            SSource = BSourceEmployees_Discounts

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Expense_Category_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click
        Try
            MyDs.Tables("employees_discounts").Columns("discount_date").DefaultValue = Now.ToString("dd/MM/yyyy")
            Gcls.NewRecord()
            CategoryID.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click
        Try
            If CategoryID.Text = "" Then
                cls.MsgComplete()
                CategoryID.Focus()
                CategoryID.BackColor = Color.Red

            ElseIf EmployeeID.Text = "" Then
                cls.MsgComplete()
                EmployeeID.Focus()
                EmployeeID.BackColor = Color.Red

            ElseIf Reason.TextBox1.Text = "" Then
                cls.MsgComplete()
                Reason.TextBox1.Focus()
                Reason.TextBox1.BackColor = Color.Red
            ElseIf DiscountsValue.Value = 0 Then
                cls.MsgComplete()
                DiscountsValue.Focus()
                DiscountsValue.BackColor = Color.Red

            Else
                Gcls.SaveRecord()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuDelete.Click
        Try
            Gcls.DeleteRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            Gcls.LastRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Try
            Gcls.NextRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        Try
            Gcls.PreviousRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirst.Click
        Try
            Gcls.FirstRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click, MenuSearch.Click
        Try
            Gcls.EditRecord()
            CategoryID.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    'Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CutData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CopyData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.PasteData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    Private Sub OrderByCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderByCombo.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                Gcls.SortData(BSourceEmployees_Discounts, OrderByCombo.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Try
            Gcls.ExitForm()
            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Gcls.ReloadData()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelSerach.Click
        Try
            BSourceEmployees_Discounts.RemoveFilter()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Gcls.BtnFile()
    End Sub

    Private Sub BtnData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnData.Click
        Gcls.BtnData()
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click
        Gcls.BtnHelp()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New EmpAddedHours
        m.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New Employees
        m.ShowDialog()
        cls.RefreshData(" select * from Employees", tbl1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim m As New EmployeesRewards
        m.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New EmployeesTasks
        m.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New EmployeesVacations
        m.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim m As New DiscountCategories
        m.ShowDialog()
        cls.RefreshData(" select * from Discount_Categories", tbl2)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim m As New RewardsCategories
        m.ShowDialog()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim m As New AppUsers
        m.ShowDialog()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim m As New Attendance
        m.ShowDialog()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim m As New Jobs
        m.ShowDialog()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim m As New Departments
        m.ShowDialog()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim m As New PaySalary
        m.ShowDialog()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim m As New QueryByEmployee
        m.ShowDialog()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim m As New QueryEmployeesRewards
        m.ShowDialog()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim m As New QueryEmpByJobDep
        m.ShowDialog()
    End Sub


    Private Sub Reason_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reason.GotFocus
        Reason.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Reason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reason.Leave
        Reason.BackColor = Color.White
    End Sub

    Private Sub DiscountsValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountsValue.GotFocus
        DiscountsValue.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub DiscountsValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountsValue.Leave
        DiscountsValue.BackColor = Color.White
    End Sub
End Class
