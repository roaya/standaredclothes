Public Class officialVacations

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceEmployeesVacations As New BindingSource
    Dim i As Integer
    '-------------------------------
    Dim TblEmp As New GeneralDataSet.EmployeesDataTable
    Dim TName As String = "Employees_Vacations"



    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(TName)
            cls.RefreshData(TblEmp, "Employees")


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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceEmployeesVacations, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords, MenuNew, MenuSave, MenuDelete, MenuSearch, MenuExit)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "√Ã«“«  «·„ÊŸ›Ì‰"
            Me.Text = Gcls.SetWTitle

            EmployeeID.DataSource = TblEmp
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"
            'EmployeeID.DataBindings.Add("SelectedValue", BSourceEmployeesVacations, "Employee_ID")

            'FromDate.DataBindings.Add("Text", BSourceEmployeesVacations, "From_Date")
            'ToDate.DataBindings.Add("Text", BSourceEmployeesVacations, "To_Date")

            'SSource = BSourceEmployeesVacations

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            MyDs.Tables("Employees_vacations").Columns("from_date").DefaultValue = Now.ToString("dd/MM/yyyy")
            MyDs.Tables("Employees_vacations").Columns("to_date").DefaultValue = Now.ToString("dd/MM/yyyy")

            Gcls.NewRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            'If EmployeeID.Text = "" Then
            '    cls.MsgComplete()
            'Else


            'End If
            Dim d1, d2 As Date
            d1 = CDate(FromDate.Text)
            d2 = CDate(ToDate.Text)

            Dim result As String

            If FromDate.Text > ToDate.Text Then
                cls.MsgExclamation("⁄›Ê« ÌÃ» «‰ ÌﬂÊ‰  «—ÌŒ «‰ Â«¡ «·«Ã«“Â «ﬂ»— „‰ «Ê Ì”«ÊÏ  «—ÌŒ «·»œ√")
                Exit Sub
            End If
            result = MessageBox.Show("·« Ì„ﬂ‰  ⁄œÌ· Â–« «·«Ã«“Â ›Ì„« »⁄œ «Ê «· —«Ã⁄ ⁄‰Â« Â·  —Ìœ «·«” „—«—øø", " «·«Ã«“«  «·—”„ÌÂ", MessageBoxButtons.YesNo)
            If result = vbYes Then
                For i = 0 To TblEmp.Rows.Count - 1
                    cmd.CommandText = "insert into employees_vacations values (" & TblEmp.Rows(i).Item("employee_id") & ",N'" & d1.ToString("MM/dd/yyyy") & "',N'" & d2.ToString("MM/dd/yyyy") & "')"
                    cmd.ExecuteNonQuery()
                Next
                cls.MsgInfo(" „ Õ›Ÿ «· €ÌÌ—«  »‰Ã«Õ")
                FromDate.Enabled = False
                ToDate.Enabled = False
                BtnNew.Enabled = True
                BtnSave.Enabled = False
                BtnExit.Enabled = True
            End If

        Catch ex As Exception

            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
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

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Gcls.EditRecord()
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
                Gcls.SortData(BSourceEmployeesVacations, OrderByCombo.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
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
            BSourceEmployeesVacations.RemoveFilter()
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
End Class