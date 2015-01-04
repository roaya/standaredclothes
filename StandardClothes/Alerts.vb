Public Class Alerts

    Dim TblReorder, TblAlert, TblCards, TblCust, TblVen, TblEmpTasks, TblReq As New DataTable
    Dim rptWarning As New RptWarningBalance
    Dim rptReorder As New RptMaxOrder
    Dim RptCustPayments As New Report_Customers_Payments
    Dim rptVendPayments As New Report_Vendors_Payments

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            TblReorder.Rows.Clear()
            cmd.CommandText = "SELECT distinct Stock_name,Category_Name,Size_Name,Type_Name,Item_Name,barcode,Order_Balance,Balance  FROM Query_All_Items where Balance<=Order_Balance"
            da.SelectCommand = cmd
            da.Fill(TblReorder)
            DataGridViewReorder.DataSource = TblReorder
            DataGridViewReorder.Columns(0).HeaderText = "اسم المحل"
            DataGridViewReorder.Columns(1).HeaderText = "اسم البند"
            DataGridViewReorder.Columns(2).HeaderText = "المقاس"
            DataGridViewReorder.Columns(3).HeaderText = "اسم الفئة"
            DataGridViewReorder.Columns(4).HeaderText = "اسم الصنف"
            DataGridViewReorder.Columns(5).HeaderText = "الباركود"

            DataGridViewReorder.Columns(6).HeaderText = "حد اعادة الطلب"
            DataGridViewReorder.Columns(7).HeaderText = "الرصيد"
            'DataGridViewReorder.Columns(8).Visible = False
            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewVen.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = True

            TabControl1.SelectTab(0)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            TblAlert.Rows.Clear()
            cmd.CommandText = "SELECT distinct Stock_name,Category_Name,Size_Name,Type_Name,Item_Name,barcode,Alert_Balance,Balance  FROM Query_All_Items where Balance<=Alert_Balance"
            da.SelectCommand = cmd
            da.Fill(TblAlert)
            DataGridViewAlertBalance.DataSource = TblAlert
            DataGridViewAlertBalance.Columns(0).HeaderText = "اسم المحل"
            DataGridViewAlertBalance.Columns(1).HeaderText = "اسم البند"
            DataGridViewAlertBalance.Columns(2).HeaderText = "المقاس"
            DataGridViewAlertBalance.Columns(3).HeaderText = "اسم الفئة"
            DataGridViewAlertBalance.Columns(4).HeaderText = "اسم الصنف"
            DataGridViewAlertBalance.Columns(5).HeaderText = "الباركود"
            DataGridViewAlertBalance.Columns(6).HeaderText = "حد التحذير"
            DataGridViewAlertBalance.Columns(7).HeaderText = "الرصيد"
            'DataGridViewAlertBalance.Columns(8).Visible = False
            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewVen.Visible = False
            DataGridViewAlertBalance.Visible = True
            DataGridViewReorder.Visible = False

            TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            TblCards.Rows.Clear()
            cmd.CommandText = "select Card_Code as 'كود الكارت' , Expired_Date as 'تاريخ الانتهاء' , Card_Value as 'قيمة الكارت' from Discount_Cards where Expired_Date-getdate() <= 7 and Card_Status <> N'منتهي'"
            da.SelectCommand = cmd
            da.Fill(TblCards)
            DataGridViewCards.DataSource = TblCards


            DataGridViewCards.Visible = True
            DataGridViewTask.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewVen.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False

            TabControl1.SelectTab(5)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            TblCust.Rows.Clear()
            cmd.CommandText = "SELECT Pay_C_ID as 'sdsd',Bill_id as 'Bill_id',customer_id as 'customer_id', customer_name as 'اسم العميل',Bill_Date as 'التاريخ واجب الدفع',Payed_Date as 'تاريخ الدفع',Pay_Value as 'القيمة واجبة الدفع',Status as 'الحالة' ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo   FROM report_customers_payments where status = N'مجدولة' and Bill_Date-GETDATE() <= 7"
            da.SelectCommand = cmd
            da.Fill(TblCust)
            DataGridViewCust.DataSource = TblCust
            DataGridViewCust.Columns(0).Visible = False
            DataGridViewCust.Columns(1).Visible = False
            DataGridViewCust.Columns(2).Visible = False
            DataGridViewCust.Columns(8).Visible = False

            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewVen.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False
            DataGridViewCust.Visible = True

            TabControl1.SelectTab(2)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            TblVen.Rows.Clear()
            cmd.CommandText = "SELECT Pay_v_ID as 'sdsd',Bill_id as 'Bill_id',vendor_id as 'vendor_id',Vendor_Name as 'اسم المورد',Bill_Date as 'التاريخ واجب الدفع',Payed_Date as 'تاريخ الدفع',Pay_Value as 'القيمة واجبة الدفع',Status as 'الحالة' ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  FROM Report_Vendors_Payments where status = N'مجدولة' and Bill_Date-GETDATE() <= 7"
            da.SelectCommand = cmd
            da.Fill(TblVen)
            DataGridViewVen.DataSource = TblVen
            DataGridViewVen.Columns(0).Visible = False
            DataGridViewVen.Columns(1).Visible = False
            DataGridViewVen.Columns(2).Visible = False
            DataGridViewVen.Columns(8).Visible = False

            DataGridViewVen.Visible = True
            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False

            TabControl1.SelectTab(3)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            TblEmpTasks.Rows.Clear()
            cmd.CommandText = "SELECT Task_Code as 'كود المهمة',Employee_Name as 'الراسل',Title as 'عنوان المهمة',Task_Desc as 'الوصف',Task_Date as 'التاريخ' FROM Query_Employees_Tasks where approved=0 and To_Employee = " & EmpIDVar
            da.SelectCommand = cmd
            da.Fill(TblEmpTasks)
            DataGridViewTask.DataSource = TblEmpTasks


            DataGridViewTask.Visible = True
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewVen.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False


            TabControl1.SelectTab(6)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            cmd.CommandText = "select request_id as 'رقم الاذن', Request_Date as 'تاريخ الحجز',Request_Time as 'وقت الحجز',Expired_Date as 'تاريخ الانتهاء',Customer_Name as 'اسم العميل',Stock_Name as 'اسم المحل' from Report_Customers_Requests where Expired_Date-GETDATE() <= 7"
            da.SelectCommand = cmd
            da.Fill(TblReq)
            DataGridViewReq.DataSource = TblReq


            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewVen.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReq.Visible = True


            TabControl1.SelectTab(4)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            rptWarning.SetDataSource(TblAlert)
            rptWarning.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = rptWarning
            m.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            rptReorder.SetDataSource(TblReorder)
            rptReorder.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = rptReorder
            m.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If DataGridViewCust.Rows.Count > 0 Then
                MyDs.Tables("report_customers_payments").Rows.Clear()
                cmd.CommandText = "SELECT * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo   FROM report_customers_payments where status = N'مجدولة' and Bill_Date-GETDATE() <= 7"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_customers_payments"))
                RptCustPayments.SetDataSource(MyDs.Tables("report_customers_payments"))
                RptCustPayments.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustPayments
                m.ShowDialog()
            Else
                MsgBox("لا توجد بيانات")

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If DataGridViewVen.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor
                MyDs.Tables("report_Vendors_payments").Rows.Clear()
                cmd.CommandText = "SELECT * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo   FROM report_Vendors_payments where status = N'مجدولة' and Bill_Date-GETDATE() <= 7"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Vendors_payments"))
                rptVendPayments.SetDataSource(MyDs.Tables("report_Vendors_payments"))
                rptVendPayments.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = rptVendPayments
                m.ShowDialog()
            Else
                MsgBox("لا توجد بيانات")

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub
End Class