Public Class FirstBalanceVendors

    Dim B_EndLoad As Boolean = False
    Dim BSourceVendorsBalance As New BindingSource
    Dim BSourceVendorsSchedule As New BindingSource
    Dim BSourceVenPayment As New BindingSource
    Dim cmdPo As New SqlClient.SqlCommand
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Vendors_first_Balance"
    '-------------------------------
    Dim cmdb As New SqlClient.SqlCommandBuilder
    Dim tblvendorsPyments As New GeneralDataSet.Vendors_PaymentsDataTable
    Dim B_Edited As Boolean
    Dim tbl As New GeneralDataSet.VendorsDataTable
    Dim tblPurchase As New GeneralDataSet.Purchase_HeaderDataTable
    Dim b, d, ch As Boolean
    Dim a As Integer
    'Dim status As String



    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            'OrderByCombo.ComboBox.DataSource = B
            'OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            'OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            cmdPo.CommandType = CommandType.StoredProcedure
            cmdPo.Connection = cn
            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 1
            cmdPo.Parameters.Add(seqid)
            cmdPo.Parameters.Add(CurID)
            cmdPo.CommandText = "UPDATE_SEQ"
            BtnNew.Enabled = False
            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            cls.RefreshData("select * from Vendors", tbl)
           

            DataGridView1.DataSource = BSourceVenPayment
          
            BSourceVenPayment.DataSource = tblvendorsPyments

            VendorID.DataSource = tbl
            VendorID.DisplayMember = "vendor_Name"
            VendorID.ValueMember = "vendor_ID"

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).HeaderText = " «—ÌŒ «·œ›⁄Â"

            DataGridView1.Columns(2).HeaderText = " «—ÌŒ «·”œ«œ"
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).HeaderText = "—ﬁ„ «·›« Ê—Â"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "ﬁÌ„Â «·œ›⁄Â"
            DataGridView1.Columns(5).HeaderText = "Õ«·Â «·œ›⁄Â"
            DataGridView1.Columns(5).ReadOnly = True

     
            SSource = BSourceVendorsBalance

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

   

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If DataGridView1.Rows.Count = 0 Then
                cls.MsgExclamation("„‰ ›÷·ﬂ «œŒ· »Ì«‰«  ")
                Exit Sub
            Else
                If DataGridView1.Rows.Count > 0 Then
                    For xx As Integer = 0 To DataGridView1.Rows.Count - 1

                        If DataGridView1.Rows(xx).Cells("pay_value").Value = 0 Then
                            cls.MsgExclamation("„‰ ›÷·ﬂ «œŒ· ﬁÌ„Â ··œ›⁄Â")
                            Exit Sub
                        End If
                    Next
                End If
                Dim total As Double
                total = tblvendorsPyments.Compute("sum(pay_value)", "bill_id=" & DataGridView1.Rows(0).Cells("Bill_id").Value & " and status='„ÃœÊ·…'")


                If total <> Value.Value Then
                    cls.MsgExclamation("⁄›Ê« ÌÃ» «‰ Ì ”«ÊÏ «Ã„«·Ï «·«ﬁ”«ÿ „⁄ ﬁÌ„Â «·«Ã·")
                    Exit Sub
                End If
                Dim d2 As Date
                If b = True Then


                    tblvendorsPyments.AcceptChanges()
                    BSourceVenPayment.EndEdit()
                    cmd.CommandText = "select * from vendors_payments "
                    cmdb.DataAdapter = da
                    da.Update(tblvendorsPyments)
                    cmd.CommandText = "delete  from vendors_payments where status=N'„ÃœÊ·…' and bill_id=" & tblvendorsPyments.Rows(0).Item("bill_id")
                    cmd.ExecuteNonQuery()
                    For xx As Integer = 0 To tblvendorsPyments.Rows.Count - 1

                        If tblvendorsPyments.Rows(xx).Item("status") = "„ÃœÊ·…" Then


                            d2 = tblvendorsPyments.Rows(xx).Item("bill_Date")
                            cmd.CommandText = "insert into vendors_payments (Bill_Date,Pay_Value,Status,bill_id) values('" & d2.ToString("MM/dd/yyyy") & "' ," & _
                          tblvendorsPyments.Rows(xx).Item("pay_value") & ",N'" & tblvendorsPyments.Rows(xx).Item("status") & "'," & _
                           tblvendorsPyments.Rows(xx).Item("bill_id") & ")"
                            cmd.ExecuteNonQuery()
                        End If
                    Next


                    MyDs.Tables("vendors_payments").Rows.Clear()

                    cmd.CommandText = "update Vendors_First_Balance  set first_balance = " & Value.Value & " where vendor_id=" & VendorID.SelectedValue
                    cmd.ExecuteNonQuery()
                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                        cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                    End If
                Else


                    Dim d As Date
                    cmd.CommandText = "insert into Purchase_header (Bill_id,bill_date,Bill_time,vendor_id,stock_id,credit_Value,Total_Bill,Pay_type) values ( " & _
                        venBillFirstBalance & ",N'" & Now.ToString("MM/dd/yyyy") & "',N'" & Now.Hour & ":" & Now.Minute & ":" & Now.Second & "'," & VendorID.SelectedValue & "," & ProjectSettings.CurrentStockID & "," & Value.Value & "," & Value.Value & ",N'«Ã·')"
                    cmd.ExecuteNonQuery()


                    tblvendorsPyments.AcceptChanges()
                    BSourceVenPayment.EndEdit()
                    cmd.CommandText = "select * from  vendors_payments"
                    cmdb.DataAdapter = da
                    da.Update(MyDs.Tables("vendors_payments"))



                    For xx As Integer = 0 To tblvendorsPyments.Rows.Count - 1


                        d2 = tblvendorsPyments.Rows(xx).Item("bill_Date")
                        cmd.CommandText = "insert into vendors_payments (Bill_Date,Pay_Value,Status,bill_id) values('" & d2.ToString("MM/dd/yyyy") & "' ," & _
                      tblvendorsPyments.Rows(xx).Item("pay_value") & ",N'" & tblvendorsPyments.Rows(xx).Item("status") & "'," & _
                       tblvendorsPyments.Rows(xx).Item("bill_id") & ")"
                        cmd.ExecuteNonQuery()

                    Next
                    MyDs.Tables("vendors_payments").Rows.Clear()
                    'If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
                    '    For x As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
                    '        d = MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Date")
                    '        cmd.CommandText = "exec Vendor_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("bill_id") & " , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Value")
                    '        cmd.ExecuteNonQuery()
                    '    Next
                    'End If
                    cmd.CommandText = "insert into Vendors_First_Balance values (" & VendorID.SelectedValue & "," & Value.Value & ")"
                    cmd.ExecuteNonQuery()
                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                        cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                    End If

                End If
                MyDs.Tables("vendors_payments").Rows.Clear()
                tblvendorsPyments.Rows.Clear()
                BtnQuery.Enabled = True
                BtnNew.Enabled = False
                Value.Value = 0
                BtnSave.Enabled = False
                VendorID.Enabled = True
                BtnDelete.Enabled = False
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


  
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If Value.Value = 0 Then
    '        cls.MsgExclamation("„‰ ›÷·ﬂ «œŒ· ﬁÌ„Â «·—’Ìœ «·«›  «ÕÏ")
    '        Value.Focus()
    '        Exit Sub
    '    End If
    '    cmdPro.ExecuteNonQuery()
    '    venBillFirstBalance = CurID.Value
    '    VenFBalance = Value.Value
    '    venFirst = True

    '    Dim m As New VenPaymentSchedule
    '    m.ShowDialog()
    '    BtnSave.Enabled = True
    'End Sub

    Private Sub BtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuery.Click
        Status.Items.Clear()


        Try
            cls.RefreshData("select distinct vp.pay_v_id,vp.bill_date,vp.pay_value,vp.status,vp.bill_id  from Vendors_Payments vp ,Vendors v ,Purchase_Header p ,purchase_details d where  p.Bill_ID =vp.bill_id and p.Vendor_ID=v.Vendor_ID and p.Bill_ID not in (select d.Bill_ID from Purchase_Details d) and v.Vendor_ID= " & VendorID.SelectedValue, tblvendorsPyments)
            cmd.CommandText = "select first_balance  from vendors_first_balance where Vendor_ID= " & VendorID.SelectedValue
            Value.Value = cmd.ExecuteScalar
            BtnSave.Enabled = True
            If DataGridView1.Rows.Count > 0 Then
                b = True

                cmd.CommandText = "select distinct vp.status from Vendors_Payments vp ,Vendors v ,Purchase_Header p ,purchase_details d where  p.Bill_ID =vp.bill_id and p.Vendor_ID=v.Vendor_ID and p.Bill_ID not in (select d.Bill_ID from Purchase_Details d) and v.Vendor_ID= " & VendorID.SelectedValue

                dr = cmd.ExecuteReader
                Do While dr.Read = True
                    Status.Items.Add(dr("status"))


                Loop
                dr.Close()

                For xx As Integer = 0 To Status.Items.Count - 1
                    If Status.Items.Contains("„ÃœÊ·…") Then
                        ch = True

                    End If
                Next
                If ch = True Then
                    BtnSave.Enabled = True

                Else
                    BtnSave.Enabled = False

                End If

            Else


                b = False
                cmdPo.ExecuteNonQuery()
                venBillFirstBalance = CurID.Value

            End If

            BtnNew.Enabled = True
            If DataGridView1.Rows.Count > 0 Then
                BtnDelete.Enabled = True
            Else
                BtnDelete.Enabled = False

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            If b = True Then
                If DataGridView1.Rows.Count > 0 Then
                    If d = True Then
                        tblvendorsPyments.Columns("bill_id").DefaultValue = a
                    Else
                        tblvendorsPyments.Columns("bill_id").DefaultValue = tblvendorsPyments.Rows(0).Item("bill_id")

                    End If

                    tblvendorsPyments.Columns("bill_id").DefaultValue = tblvendorsPyments.Rows(0).Item("bill_id")
                    tblvendorsPyments.Columns("status").DefaultValue = "„ÃœÊ·…"
                    tblvendorsPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
                    tblvendorsPyments.Columns("pay_value").DefaultValue = 0
                    BSourceVenPayment.AddNew()


                Else
                    cmd.CommandText = "select distinct vp.bill_id  from Vendors_Payments vp ,Vendors v ,Purchase_Header p ,purchase_details d where  p.Bill_ID =vp.bill_id and p.Vendor_ID=v.Vendor_ID and p.Bill_ID not in (select d.Bill_ID from Purchase_Details d) and v.Vendor_ID= " & VendorID.SelectedValue
                    a = cmd.ExecuteScalar
                    tblvendorsPyments.Columns("bill_id").DefaultValue = a
                    tblvendorsPyments.Columns("status").DefaultValue = "„ÃœÊ·…"
                    tblvendorsPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
                    tblvendorsPyments.Columns("pay_value").DefaultValue = 0
                    BSourceVenPayment.AddNew()
                    DataGridView1.Columns(1).ReadOnly = False

                End If
            Else

                If Value.Value = 0 Then
                    cls.MsgExclamation(" „‰ ›÷·ﬂ «œŒ· ﬁÌ„Â «·—’Ìœ «·«›  «ÕÏ À„ ÃœÌœ")
                    Exit Sub
                End If

                tblvendorsPyments.Columns("bill_id").DefaultValue = venBillFirstBalance
                tblvendorsPyments.Columns("status").DefaultValue = "„ÃœÊ·…"
                tblvendorsPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
                tblvendorsPyments.Columns("pay_value").DefaultValue = 0
                BSourceVenPayment.AddNew()
                DataGridView1.Columns(1).ReadOnly = False
            End If
            BtnQuery.Enabled = True
            '  BtnNew.Enabled = False

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


   

    Private Sub BtnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
        venFirst = False

    End Sub
    Private Sub Btnnew_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.MouseLeave
        BtnNew.BackgroundImage = My.Resources.enter
        BtnNew.ForeColor = Color.Black
    End Sub

    Private Sub BtnNew_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnNew.MouseMove
        BtnNew.BackgroundImage = My.Resources._end
        BtnNew.ForeColor = Color.White
    End Sub

    Private Sub DataGridView1_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        If DataGridView1.Rows.Count > 0 Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False

        End If
    End Sub

   
    Private Sub FirstBalanceVendors_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cmdPo.Parameters.Clear()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            cmd.CommandText = "delete from vendors_payments where status='„ÃœÊ·…' and bill_id = " & tblvendorsPyments.Rows(0).Item("bill_id")
            cmd.ExecuteNonQuery()
            'cmd.CommandText = "delete from Vendors_First_Balance where Vendor_id=" & VendorID.SelectedValue
            'cmd.ExecuteNonQuery()
            Value.Value = False
            MyDs.Tables("vendors_payments").Rows.Clear()
            tblvendorsPyments.Rows.Clear()
            cls.MsgInfo(" „ Õ–› »Ì«‰«  «·”Ã· «·Õ«·Ì")
            'b = False
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
    Private Sub BtnQuery_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnQuery.MouseMove
        BtnQuery.BackgroundImage = My.Resources._end
        BtnQuery.ForeColor = Color.White

    End Sub

    Private Sub btnexit_mouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnExit.MouseMove
        BtnExit.BackgroundImage = My.Resources._end
        BtnExit.ForeColor = Color.White
    End Sub

    Private Sub BtnQuery_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuery.MouseLeave
        BtnQuery.BackgroundImage = My.Resources.enter
        BtnQuery.ForeColor = Color.Black

    End Sub

    Private Sub BtnExit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.MouseLeave
        BtnExit.BackgroundImage = My.Resources.enter
        BtnExit.ForeColor = Color.Black
    End Sub
    Private Sub BtnSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.MouseLeave
        BtnSave.BackgroundImage = My.Resources.enter
        BtnSave.ForeColor = Color.Black
    End Sub

    Private Sub BtnSave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnSave.MouseMove
        BtnSave.BackgroundImage = My.Resources._end
        BtnSave.ForeColor = Color.White
    End Sub
    Private Sub Btndelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.MouseLeave
        BtnDelete.BackgroundImage = My.Resources.enter
        BtnDelete.ForeColor = Color.Black
    End Sub

    Private Sub btndelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnDelete.MouseMove
        BtnDelete.BackgroundImage = My.Resources._end
        BtnDelete.ForeColor = Color.White
    End Sub
End Class
