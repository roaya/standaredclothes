Public Class Shifts_details
    ''''' Dim BSourceShiftsDetails As BindingSource

    Dim B_EndLoad As Boolean = False
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Shifts_Details"
    Dim t As New DataTable
    Dim T_Delivery, T_Takeaway, T_Sales, T_End_Money, T_Returns, T_Expenses, T_Purchase, T_Receive, T_Payment As Double
    Dim d As Date
    '-------------------------------
    Private Sub Shifts_Details_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Shiftsdetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData("Shifts")
            cls.RefreshData(TName)

            Me.Text = " ›«’Ì· «·Ê—œÌ…"


            ShiftID.DataSource = MyDs
            ShiftID.DisplayMember = "Shifts.Shift_Name"
            ShiftID.ValueMember = "Shifts.Shift_ID"

            cmd.CommandText = "select * from query_shifts where end_money is null order by end_date desc"
            da.SelectCommand = cmd
            da.Fill(t)
            DataGridView1.DataSource = t
            DataGridView1.Columns(0).HeaderText = "«”„ «·Ê—œÌÂ"
            DataGridView1.Columns(1).HeaderText = "—’Ìœ «·»œ«ÌÂ"
            DataGridView1.Columns(2).HeaderText = "—’Ìœ «·‰Â«ÌÂ"
            DataGridView1.Columns(3).HeaderText = " «—ÌŒ «·»œ«ÌÂ"
            DataGridView1.Columns(4).HeaderText = " «—ÌŒ «·‰Â«ÌÂ"
            DataGridView1.Columns(5).HeaderText = "Êﬁ  «·»œ«ÌÂ"
            DataGridView1.Columns(6).HeaderText = "Êﬁ  «·‰Â«ÌÂ"
            DataGridView1.Columns(7).HeaderText = "«”„ «·„ÊŸ›"
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(9).Visible = False



            RVal = "Shift_ID"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try

            If ShiftID.SelectedValue = Nothing Then
                cls.MsgExclamation("»—Ã«¡ «Œ Ì«— ‰Ê⁄ «·Ê—œÌÂ")
                Exit Sub
            End If
            If CurrentShiftId <> 0 Then
                cls.MsgExclamation("ÌÃ» «€·«ﬁ «·Ê—œÌÂ «·„› ÊÕÂ √Ê·«")
            Else





                cmd.CommandText = "select count(*) from shifts_details where end_date is null"
                If cmd.ExecuteNonQuery <= 0 Then

                    cmd.CommandText = "insert into shifts_details(shift_id,start_money,start_date,real_start_time,employee_id) values(" & ShiftID.SelectedValue & "," & StartMoney.Value & ", getdate() , '" & Now.ToLongTimeString & "' , " & EmpIDVar & ")"
                    cmd.ExecuteNonQuery()
                    t.Rows.Clear()
                    cmd.CommandText = "select * from query_shifts where end_money is null order by end_date desc"
                    da.SelectCommand = cmd
                    da.Fill(t)

                    cmd.CommandText = "select max(shift_detail_id) from shifts_details"
                    CurrentShiftId = cmd.ExecuteScalar
       

                    cls.MsgInfo(" „ › Õ «·Ê—œÌÂ «·ÃœÌœÂ »‰Ã«Õ")
                Else
                    cls.MsgCritical("»—Ã«¡ «€·«ﬁ «·Ê—œÌÂ «·„› ÊÕÂ √Ê·«")
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try

            If DataGridView1.SelectedRows.Count <= 0 Then
                cls.MsgExclamation("«Œ — «·Ê—œÌÂ «·„—«œ «€·«ﬁÂ«")
            Else
                '--------------------------------------------------


                cmd.CommandText = "select employee_id from shifts_Details where shift_detail_id=" & DataGridView1.SelectedRows(0).Cells("shift_detail_id").Value
                If EmpIDVar <> cmd.ExecuteScalar Then
                    cls.MsgExclamation("⁄›Ê« Â–Â «·Ê—œÌ… ·«  Œ’ﬂ Ê ·« Ì„ﬂ‰ﬂ «€·«ﬁ Ê—œÌ«  «·„ÊŸ›Ì‰ «·√Œ—Ì‰")
                    Exit Sub
                End If

                cmd.CommandText = "update shifts_details set end_date = getdate() , end_money = 0 , real_end_time = ' " & Now.ToLongTimeString & "' where shift_detail_id = " & CurrentShiftID
                cmd.ExecuteNonQuery()

                t.Rows.Clear()
                cmd.CommandText = "select * from query_shifts where end_money is null order by end_date desc"
                da.SelectCommand = cmd
                da.Fill(t)
                cls.MsgInfo(" „ «€·«ﬁ «·Ê—œÌÂ »‰Ã«Õ")
                INC = CurrentShiftID
                CurrentShiftID = 0
                Show_Report()
                Exit Sub
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public Sub Show_Report()

        MyDs.Tables("Income").Rows.Clear()

        cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & INC
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = cmd.ExecuteScalar
        r("In_Name") = "«·„»Ì⁄« "
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & INC
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = cmd.ExecuteScalar
        r("In_Name") = "„— Ã⁄«  «·„Ê—œÌ‰"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "select ISNULL(sum(pay_Value),0) from Customers_Payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & INC
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = cmd.ExecuteScalar
        r("In_Name") = "„œ›Ê⁄«  «·⁄„·«¡"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & INC
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = -cmd.ExecuteScalar
        r("In_Name") = "«·„‘ —Ì« "
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "select ISNULL(sum(cash_Value),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & INC
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = -cmd.ExecuteScalar
        r("In_Name") = "„— Ã⁄«  «·⁄„·«¡"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)


        cmd.CommandText = "select ISNULL(sum(pay_Value),0) from vendors_Payments r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & INC
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = -cmd.ExecuteScalar
        r("In_Name") = "„œ›Ê⁄«  «·„Ê—œÌ‰"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "select ISNULL(sum(Expense_Value),0) from expenses_details r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & INC
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = -cmd.ExecuteScalar
        r("In_Name") = "«·„’—Ê›« "
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)


        Dim Rpt As New RptIncome
        Dim M As New ShowAllReports

        rpt.SetDataSource(MyDs.Tables("income"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        cmd.CommandText = "select Shift_Name + ' - ' + Employee_Name + ' - ' + isnull(Real_Start_Time,'') + ' - ' + isnull(Real_End_Time  ,'') from query_shifts where shift_Detail_id=" & INC
        Rpt.SetParameterValue("Report_Type", "Ê—œÌÂ - " & cmd.ExecuteScalar)
        M.CrystalReportViewer1.ReportSource = Rpt
        M.ShowDialog()

    End Sub



End Class
