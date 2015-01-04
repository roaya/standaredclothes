Public Class VendorsPayments

   Dim B_EndLoad As Boolean = False
    Dim BeforePay, AfterPay As New DataTable
    Dim tbl1 As New GeneralDataSet.VendorsDataTable
    Dim tbl2 As New GeneralDataSet.Purchase_HeaderDataTable
    Dim c As Boolean = False
    Dim m As New ShowAllReports
    Dim TotalV As Double
    Dim D As Date

    Private Sub VendorsPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from vendors", tbl1)

            VendorID.ComboBox.DataSource = tbl1
            VendorID.ComboBox.DisplayMember = "vendor_name"
            VendorID.ComboBox.ValueMember = "vendor_ID"
            c = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Vendors Payments")
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If VendorID.ComboBox.Text = "" Then

            cls.MsgExclamation("«Œ — «”„ «·„Ê—œ")
            Exit Sub
        ElseIf BillID.ComboBox.Text = "" Then
            cls.MsgExclamation("«Œ — —ﬁ„ «·›« Ê—Â")
            Exit Sub
        Else
            FillData()

        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If DataGridViewNotPayed.SelectedRows.Count <= 0 Then
                cls.MsgCritical("·„ Ì „  ÕœÌœ «·œ›⁄… «·„—«œ ”œ«œÂ«")
            Else
                cmd.CommandText = "update Vendors_payments set status = N'„œ›Ê⁄…' , payed_date = getdate(),Shift_Detail_ID=" & CurrentShiftID & " where pay_V_id = " & DataGridViewNotPayed.SelectedRows(0).Cells(0).Value
                cmd.ExecuteNonQuery()
                FillData()
                cls.MsgInfo(" „ ”œ«œ «·œ›⁄… »‰Ã«Õ")
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Vendors Payments")
        End Try
    End Sub

    Sub FillData()
        BeforePay.Rows.Clear()
        cmd.CommandText = "SELECT Pay_V_ID as '—ﬁ„ «–‰ «·œ›⁄',bill_id as '—ﬁ„ «·›« Ê—Â',Bill_Date as ' «—ÌŒ «·œ›⁄…',Payed_Date as ' «—ÌŒ «·”œ«œ',Pay_Value as '«·ﬁÌ„… «·œ›⁄Â',Status as 'Õ«·… «·œ›⁄…' ,vendor_id , vendor_name FROM Report_Vendors_Payments where Status= N'„ÃœÊ·…' and bill_id = " & BillID.ComboBox.SelectedValue & " order by bill_date asc"
        da.SelectCommand = cmd
        da.Fill(BeforePay)
        DataGridViewNotPayed.DataSource = BeforePay
        DataGridViewNotPayed.Columns(3).Visible = False
        DataGridViewNotPayed.Columns(6).Visible = False
        DataGridViewNotPayed.Columns(7).Visible = False
        AfterPay.Rows.Clear()
        cmd.CommandText = "SELECT Pay_V_ID as '—ﬁ„ «–‰ «·œ›⁄',bill_id as '—ﬁ„ «·›« Ê—Â',Bill_Date as ' «—ÌŒ «·œ›⁄…',Payed_Date as ' «—ÌŒ «·”œ«œ',Pay_Value as '«·ﬁÌ„… «·„œ›Ê⁄…',Status as 'Õ«·… «·œ›⁄…' ,vendor_id , vendor_name FROM Report_Vendors_Payments where Status= N'„œ›Ê⁄…' and bill_id = " & BillID.ComboBox.SelectedValue & " order by payed_date desc"
        da.SelectCommand = cmd
        da.Fill(AfterPay)
        
        DataGridViewPayed.DataSource = AfterPay
        DataGridViewPayed.Columns(6).Visible = False
        DataGridViewPayed.Columns(7).Visible = False
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            If DataGridViewNotPayed.SelectedRows.Count <= 0 Then
                cls.MsgCritical("·„ Ì „  ÕœÌœ «·œ›⁄… «·„—«œ Õ–›Â«")
            Else
                If MsgBox("Â·  —Ìœ Õ–› «·œ›⁄… «·„Õœœ…", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, ProjectTitle) = MsgBoxResult.Yes Then
                    cmd.CommandText = "delete from Vendors_payments where pay_V_id = " & DataGridViewNotPayed.SelectedRows(0).Cells(0).Value
                    cmd.ExecuteNonQuery()
                    cls.MsgInfo(" „ Õ–› «·œ›⁄… »‰Ã«Õ")
                    FillData()
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Vendors Payments")
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub VendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorID.SelectedIndexChanged
        Try
            If c = True Then
                If VendorID.ComboBox.Text <> "" Then
                    cls.RefreshData("select distinct s.Bill_ID from purchase_header s , vendors_Payments c  where s.Bill_ID=c.bill_id and vendor_id=" & VendorID.ComboBox.SelectedValue, tbl2)

                    BillID.ComboBox.DataSource = tbl2
                    BillID.ComboBox.DisplayMember = "bill_id"
                    BillID.ComboBox.ValueMember = "bill_id"
                End If

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Vendors Payments")
        End Try
    End Sub

    Private Sub DataGridViewPayed_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewPayed.MouseDoubleClick
        Dim RptVPay As New CustVenPay
        MyDs.Tables("Report_Vendors_Payments").Rows.Clear()
        cmd.CommandText = "select pay_v_ID pay_ID,Vendor_Name CustVen,Payed_Date PayDate,Pay_Value PayValue,Bill_ID from Report_Vendors_Payments where Pay_v_ID = " & DataGridViewPayed.SelectedRows(0).Cells(0).Value
        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("Report_Vendors_Payments"))
        RptVPay.SetDataSource(MyDs.Tables("Report_Vendors_Payments"))
        RptVPay.SetParameterValue("Title", "„œ›Ê⁄«  «·„Ê—œÌ‰")
        RptVPay.SetParameterValue("vc", "«”„ «·„Ê—œ")
        m.CrystalReportViewer1.ReportSource = RptVPay
        m.ShowDialog()
    End Sub

    Private Sub PayValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayValue.Click

        If CurrentShiftID = 0 Then
            cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ…")
            Exit Sub
        End If


        If CashValue.Value = 0 Then
            cls.MsgExclamation("«·„»·€ «·„œŒ· ÌÃ» «‰ ÌﬂÊ‰ «ﬂ»— „‰ ’›—")
            Exit Sub
        End If
        TotalV = 0
        For i As Integer = 0 To BeforePay.Rows.Count - 1
            TotalV = TotalV + BeforePay.Rows(i).Item(4)
        Next
        If CashValue.Value > TotalV Then
            cls.MsgExclamation("«·„»·€ «·„œŒ· ·« ÌÃ» «‰ ÌﬂÊ‰ «ﬂ»— „‰ „Ã„Ê⁄ «·√ﬁ”«ÿ")
            Exit Sub
        End If
        TotalV = CashValue.Value

        For i As Integer = 0 To BeforePay.Rows.Count - 1
            If CashValue.Value > BeforePay.Rows(i).Item(4) Then
                D = BeforePay.Rows(i).Item(2)
                CashValue.Value = CashValue.Value - BeforePay.Rows(i).Item(4)
                cmd.CommandText = "delete from Vendors_payments where pay_v_id=" & BeforePay.Rows(i).Item(0)
                cmd.ExecuteNonQuery()
            ElseIf CashValue.Value = BeforePay.Rows(i).Item(4) Then
                cmd.CommandText = "update Vendors_payments set status = N'„œ›Ê⁄…' , payed_date = getdate(),shift_detail_id=" & CurrentShiftID & " where pay_v_id = " & BeforePay.Rows(i).Item(0)
                cmd.ExecuteNonQuery()
                FillData()
                cls.MsgInfo(" „ ”œ«œ «·œ›⁄… »‰Ã«Õ")
                Exit Sub
            Else
                cmd.CommandText = "Update Vendors_payments set pay_Value=pay_value-" & CashValue.Value & " where pay_v_id=" & BeforePay.Rows(i).Item(0)
                cmd.ExecuteNonQuery()
                CashValue.Value = 0
                cmd.CommandText = "insert into Vendors_payments(bill_date,Payed_Date,Pay_Value,Status,Bill_ID,Shift_Detail_ID) values('" & D.ToString("MM/dd/yyyy") & "',getdate()," & TotalV & ",N'„œ›Ê⁄…'," & BeforePay.Rows(i).Item(1) & "," & CurrentShiftID & ")"
                cmd.ExecuteNonQuery()

                FillData()
                cls.MsgInfo(" „ ”œ«œ «·œ›⁄… »‰Ã«Õ")
                Exit Sub
            End If
        Next
    End Sub
End Class
