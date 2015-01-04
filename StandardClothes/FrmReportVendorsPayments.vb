Public Class FrmReportVendorsPayments
    Dim tbl1 As New GeneralDataSet.VendorsDataTable
    Dim rpt As New Report_Vendors_Payments
    Private Sub FrmReportVendorsPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cls.RefreshData("SELECT * FROM vendors", TBL1)



        VendorID.DataSource = TBL1
        VendorID.ValueMember = "vendor_id"
        VendorID.DisplayMember = "vendor_name"

    End Sub

    Private Sub RadAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadAll.CheckedChanged
        If RadAll.Checked = True Then
            VendorID.Enabled = False
        End If
    End Sub

    Private Sub Radvendor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radvendor.CheckedChanged
        If Radvendor.Checked = True Then
            VendorID.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim date1, date2 As Date
        date1 = CDate(DateTimePicker1.Text)
        date2 = CDate(DateTimePicker2.Text)

        MyDs.Tables("report_vendors_payments").Rows.Clear()
        Me.Cursor = Cursors.WaitCursor

        If RadAll.Checked = True Then
            cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from report_vendors_payments where payed_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

        ElseIf Radvendor.Checked = True Then
            If VendorID.Text = "" Then
                MsgBox("من فضلك اختر اسم المورد")
                Exit Sub
            Else
                cmd.CommandText = "select * ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from report_vendors_payments where vendor_id=" & VendorID.SelectedValue & "and payed_date between N'" & date1.ToString("MM/dd/yyyy") & "' and N'" & date2.ToString("MM/dd/yyyy") & "'"

            End If
        End If
        da.Fill(MyDs.Tables("report_vendors_payments"))
        If MyDs.Tables("report_vendors_payments").Rows.Count > 0 Then

            rpt.SetDataSource(MyDs.Tables("report_vendors_payments"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)
        Else
            MsgBox("لا توجد بيانات")
        End If
        Me.Cursor = Cursors.Default
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