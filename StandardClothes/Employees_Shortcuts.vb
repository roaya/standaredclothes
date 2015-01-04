Public Class Employees_Shortcuts

    ' Dim T As System.Threading.Thread
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To SourceList.Items.Count - 1
            DestinationList.Items.Add(SourceList.Items(0))
            SourceList.Items.RemoveAt(0)
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i As Integer
        For i = 0 To SourceList.SelectedIndices.Count - 1
            DestinationList.Items.Add(SourceList.Items(SourceList.SelectedIndices(0)))
            SourceList.Items.Remove(SourceList.Items(SourceList.SelectedIndices(0)))
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If DestinationList.SelectedItems.Count > 0 Then
            SourceList.Items.Add(DestinationList.SelectedItem)
            DestinationList.Items.RemoveAt(DestinationList.SelectedIndex)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SourceList.Items.AddRange(DestinationList.Items)
        DestinationList.Items.Clear()
    End Sub

    Private Sub ItemsVendors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("employees")

            EmployeeID.DataSource = MyDs
            EmployeeID.DisplayMember = "employees.employee_Name"
            EmployeeID.ValueMember = "employees.employee_Id"
        Catch ex As Exception
            cls.WriteError(ex.Message, "Employees Shortcuts")
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            BarAfter.Visible = True
            TxtAfter.Visible = True

            cls.ViewAll(TabControl1.TabPages(2))
            TabControl1.SelectTab(2)
            cls.HideAll(TabControl1.TabPages(1))
            Me.Cursor = Cursors.WaitCursor
            '  T.Start()
            cmd.CommandText = "delete from employees_shortcuts where employee_id=" & EmployeeID.SelectedValue
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To DestinationList.Items.Count - 1
                DestinationList.SetSelected(i, True)
                cmd.CommandText = "insert into employees_shortcuts (Form_Name,employee_id) values(N'" & DestinationList.SelectedItem & "' , " & EmployeeID.SelectedValue & ")"
                cmd.ExecuteNonQuery()
            Next
            ' T.Abort()
            Me.Cursor = Cursors.Default
            cls.MsgInfo("تم تحديث الاختصارات للموظف بنجاح")

            Button10.Enabled = True
            BarAfter.Visible = False
            TxtAfter.Visible = False
        Catch ex As Exception
            cls.WriteError(ex.Message, "Employees Shortcuts")
        End Try
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            'BeforeBar.Visible = True
            'BeforeTxt.Visible = True
            'TB = New System.Threading.Thread(AddressOf RunWorkerBefore)
            'TB.Start()
            cmd.CommandText = "select Form_Name from employees_Shortcuts where employee_id=" & EmployeeID.SelectedValue
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                DestinationList.Items.Add(dr("Form_Name"))
                SourceList.Items.Remove(dr("Form_Name"))
            Loop
            dr.Close()
            cls.ViewAll(TabControl1.TabPages(1))
            TabControl1.SelectTab(1)
            cls.HideAll(TabControl1.TabPages(0))
            'TB.Abort()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Employees Shortcuts")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click

        BarAfter.Visible = False
        TxtAfter.Visible = False
        DestinationList.Items.Clear()
        SourceList.Items.Clear()
        cls.ViewAll(TabControl1.TabPages(0))
        TabControl1.SelectTab(0)
        cls.HideAll(TabControl1.TabPages(1))

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Close()
    End Sub
End Class