Public Class ExpensesDetails

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceExpenses_Details As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Expenses_Details"
    '-------------------------------
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.Expenses_HeaderDataTable
    Public SearchExpenseDetailID As Integer = 0

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MasterField1.TextBox1.MaxLength = 50

            cls.RefreshData(TName)
            cls.RefreshData(" select * from Expenses_Header", tbl2)
            cls.RefreshData("select * from  Employees", tbl1)
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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceExpenses_Details, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords, MenuNew, MenuSave, MenuDelete, MenuSearch, MenuExit)
            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = " ›«’Ì· «·„’—Ê›« "
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BSourceExpenses_Details, "Expense_Name")
            ExpenseDesc.TextBox1.DataBindings.Add("Text", BSourceExpenses_Details, "Expense_Desc")
            ExpenseValue.DataBindings.Add("Value", BSourceExpenses_Details, "Expense_Value")
            ExpenseDate.DataBindings.Add("Text", BSourceExpenses_Details, "Expense_Date")

            EmployeeID.DataSource = tbl1
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"
            EmployeeID.DataBindings.Add("SelectedValue", BSourceExpenses_Details, "Employee_ID")

            ExpenseCategoryID.DataSource = tbl2
            ExpenseCategoryID.DisplayMember = "Expense_Category_Name"
            ExpenseCategoryID.ValueMember = "Expense_Category_ID"
            ExpenseCategoryID.DataBindings.Add("SelectedValue", BSourceExpenses_Details, "Expense_Category_ID")

            SSource = BSourceExpenses_Details

            'Select Case Exp_Type
            '    Case 1
            '        MyDs.Tables("Expenses_Details").Columns(1).DefaultValue = 1
            '    Case 2
            '        MyDs.Tables("Expenses_Details").Columns(1).DefaultValue = 2
            '    Case 3
            '        MyDs.Tables("Expenses_Details").Columns(1).DefaultValue = 3
            'End Select


            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Expense_Name"

            B_EndLoad = True

            If SearchExpenseDetailID <> 0 Then
                BSourceExpenses_Details.Filter = "Expense_Detail_ID = " & SearchExpenseDetailID
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click
        Try
            If CurrentShiftID = 0 Then
                cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ…")
                Exit Sub
            End If

            MyDs.Tables("Expenses_details").Columns("Expense_Date").DefaultValue = Now.ToString("dd/MM/yyyy")
            MyDs.Tables("Expenses_details").Columns("Shift_Detail_ID").DefaultValue = CurrentShiftID
            Gcls.NewRecord()
            MasterField1.TextBox1.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click
        Try


            If MasterField1.TextBox1.Text = "" Then
                cls.MsgComplete()
                MasterField1.TextBox1.Focus()
                MasterField1.TextBox1.BackColor = Color.Red
            ElseIf ExpenseCategoryID.Text = "" Then
                cls.MsgExclamation("«œŒ· »‰œ «·„’—Ê›« ")
                ExpenseCategoryID.Focus()
            ElseIf EmployeeID.Text = "" Then
                cls.MsgExclamation("«Œ — «”„ «·„ÊŸ›")
                EmployeeID.Focus()
            ElseIf ExpenseValue.Value = 0 Then
                cls.MsgExclamation("«œŒ· ﬁÌ„… «·„’—Ê›")
                ExpenseValue.Focus()
                ExpenseValue.BackColor = Color.Red

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
            MasterField1.TextBox1.Focus()
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
                Gcls.SortData(BSourceExpenses_Details, OrderByCombo.SelectedValue)
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
            BSourceExpenses_Details.RemoveFilter()
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
        Dim m As New Employees
        m.ShowDialog()
        cls.RefreshData("select * from  Employees", tbl1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New ExpensesMaster
        m.ShowDialog()
        cls.RefreshData(" select * from Expenses_Header", tbl2)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim m As New FrmReportExpenses
        m.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New QueryExpensesByPeriod
        m.ShowDialog()
    End Sub


    Private Sub ExpenseValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpenseValue.GotFocus
        ExpenseValue.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub ExpenseValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpenseValue.Leave
        ExpenseValue.BackColor = Color.White
    End Sub

End Class
