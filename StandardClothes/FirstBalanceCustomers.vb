Public Class FirstBalancecustomers

    Dim B_EndLoad As Boolean = False
    Dim BSourceVendorsBalance As New BindingSource
    Dim BSourceVendorsSchedule As New BindingSource
    Dim cmdPro As New SqlClient.SqlCommand
    Dim BSourcecustPayment As New BindingSource
    Dim b, ch As Boolean
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "customers_first_Balance"
    '-------------------------------
    Dim cmdb As New SqlClient.SqlCommandBuilder
    Dim tblcustPyments As New GeneralDataSet.Customers_PaymentsDataTable
    Dim d As Boolean = False
    Dim a As Integer
    Dim tbl As New GeneralDataSet.CustomersDataTable



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
            BtnNew.Enabled = False
            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn
            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            seqid.DbType = DbType.Int32
            seqid.ParameterName = "S_ID"
            seqid.Direction = ParameterDirection.Input
            seqid.Value = 2
            cmdPro.Parameters.Add(seqid)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
         
            cls.RefreshData("select * from customers", tbl)

            DataGridView1.DataSource = BSourcecustPayment

            BSourcecustPayment.DataSource = tblcustPyments
            CustomerID.DataSource = tbl
            CustomerID.DisplayMember = "customer_Name"
            CustomerID.ValueMember = "customer_ID"
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).HeaderText = " «—ÌŒ «·œ›⁄Â"

            DataGridView1.Columns(2).HeaderText = " «—ÌŒ «·”œ«œ"
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).HeaderText = "—ﬁ„ «·›« Ê—Â"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "ﬁÌ„Â «·œ›⁄Â"
            DataGridView1.Columns(5).HeaderText = "Õ«·Â «·œ›⁄Â"
            DataGridView1.Columns(5).ReadOnly = True
            SSource = BSourcecustPayment

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
                total = tblcustPyments.Compute("sum(pay_value)", "bill_id=" & DataGridView1.Rows(0).Cells("Bill_id").Value & " and status='„ÃœÊ·…'")


                If total <> Value.Value Then
                    cls.MsgExclamation("⁄›Ê« ÌÃ» «‰ Ì ”«ÊÏ «Ã„«·Ï «·«ﬁ”«ÿ „⁄ ﬁÌ„Â «·«Ã·")
                    Exit Sub
                End If
                Dim d2 As Date
                If b = True Then

                    tblcustPyments.AcceptChanges()
                    BSourcecustPayment.EndEdit()
                    cmd.CommandText = "select * from customers_payments "
                    cmdb.DataAdapter = da
                    da.Update(tblcustPyments)
                    cmd.CommandText = "delete  from customers_payments where status=N'„ÃœÊ·…' and bill_id=" & tblcustPyments.Rows(0).Item("bill_id")
                    cmd.ExecuteNonQuery()
                    For xx As Integer = 0 To tblcustPyments.Rows.Count - 1


                        If tblcustPyments.Rows(xx).Item("status") = "„ÃœÊ·…" Then


                            d2 = tblcustPyments.Rows(xx).Item("bill_Date")
                            cmd.CommandText = "insert into customers_payments (Bill_Date,Pay_Value,Status,bill_id) values('" & d2.ToString("MM/dd/yyyy") & "' ," & _
                          tblcustPyments.Rows(xx).Item("pay_value") & ",N'" & tblcustPyments.Rows(xx).Item("status") & "'," & _
                           tblcustPyments.Rows(xx).Item("bill_id") & ")"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    MyDs.Tables("customers_payments").Rows.Clear()

                    cmd.CommandText = "update customers_First_Balance  set first_balance = " & Value.Value & " where customer_id=" & CustomerID.SelectedValue
                    cmd.ExecuteNonQuery()
                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                        cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                    End If
                Else


                    Dim d As Date
                    cmd.CommandText = "insert into sales_header (Bill_id,bill_date,Bill_time,customer_id,stock_id,credit_Value,Total_Bill,Pay_type) values ( " & _
                       custBillFirstBalance & ",N'" & Now.ToString("MM/dd/yyyy") & "',N'" & Now.Hour & ":" & Now.Minute & ":" & Now.Second & "'," & CustomerID.SelectedValue & "," & ProjectSettings.CurrentStockID & "," & Value.Value & "," & Value.Value & ",N'«Ã·')"
                    cmd.ExecuteNonQuery()


                    tblcustPyments.AcceptChanges()
                    BSourcecustPayment.EndEdit()
                    cmd.CommandText = "select * from  customers_payments"
                    cmdb.DataAdapter = da
                    da.Update(MyDs.Tables("customers_payments"))



                    For xx As Integer = 0 To tblcustPyments.Rows.Count - 1


                        d2 = tblcustPyments.Rows(xx).Item("bill_Date")
                        cmd.CommandText = "insert into customers_payments (Bill_Date,Pay_Value,Status,bill_id) values('" & d2.ToString("MM/dd/yyyy") & "' ," & _
                      tblcustPyments.Rows(xx).Item("pay_value") & ",N'" & tblcustPyments.Rows(xx).Item("status") & "'," & _
                       tblcustPyments.Rows(xx).Item("bill_id") & ")"
                        cmd.ExecuteNonQuery()

                    Next
                    MyDs.Tables("customers_payments").Rows.Clear()
                    'If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
                    '    For x As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
                    '        d = MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Date")
                    '        cmd.CommandText = "exec Vendor_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("bill_id") & " , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Value")
                    '        cmd.ExecuteNonQuery()
                    '    Next
                    'End If
                    cmd.CommandText = "insert into customers_First_Balance values (" & CustomerID.SelectedValue & "," & Value.Value & ")"
                    cmd.ExecuteNonQuery()
                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                        cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                    End If

                End If
                MyDs.Tables("customers_payments").Rows.Clear()
                tblcustPyments.Rows.Clear()
                btnquery.Enabled = True
                BtnNew.Enabled = False
                Value.Value = 0
                BtnSave.Enabled = False
                CustomerID.Enabled = True
                BtnDelete.Enabled = False
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

              
    End Sub




    

    Private Sub btnquery_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnquery.MouseMove
        btnquery.BackgroundImage = My.Resources._end
        btnquery.ForeColor = Color.White

    End Sub

    Private Sub btnexit_mouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnExit.MouseMove
        BtnExit.BackgroundImage = My.Resources._end
        BtnExit.ForeColor = Color.White
    End Sub

    Private Sub btnquery_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquery.MouseLeave
        btnquery.BackgroundImage = My.Resources.enter
        btnquery.ForeColor = Color.Black

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

    Private Sub BtnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()

    End Sub


    Private Sub BtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquery.Click
        Try
            Status.Items.Clear()

            cls.RefreshData("select distinct vp.pay_c_id,vp.bill_date,vp.pay_value,vp.status,vp.bill_id  from customers_Payments vp ,customers v ,sales_Header p ,sales_details d where  p.Bill_ID =vp.bill_id and p.customer_ID=v.customer_ID and p.Bill_ID not in (select d.Bill_ID from sales_Details d) and v.customer_ID= " & CustomerID.SelectedValue, tblcustPyments)

            cmd.CommandText = "select first_balance  from customers_first_balance where customer_ID= " & CustomerID.SelectedValue
            Value.Value = cmd.ExecuteScalar
            BtnSave.Enabled = True

            If DataGridView1.Rows.Count > 0 Then
                b = True
                cmd.CommandText = "select distinct vp.status from customers_Payments vp ,customers v ,sales_Header p ,sales_details d where  p.Bill_ID =vp.bill_id and p.customer_ID=v.customer_ID and p.Bill_ID not in (select d.Bill_ID from sales_Details d) and v.customer_id= " & CustomerID.SelectedValue

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
                cmdPro.ExecuteNonQuery()
                custBillFirstBalance = CurID.Value
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
                        tblcustPyments.Columns("bill_id").DefaultValue = a
                    Else
                        tblcustPyments.Columns("bill_id").DefaultValue = tblcustPyments.Rows(0).Item("bill_id")

                    End If
                    tblcustPyments.Columns("status").DefaultValue = "„ÃœÊ·…"
                    tblcustPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
                    tblcustPyments.Columns("pay_value").DefaultValue = 0
                    BSourcecustPayment.AddNew()

                Else
                    cmd.CommandText = "select distinct vp.bill_id  from customers_Payments vp ,customers v ,sales_Header p ,sales_details d where  p.Bill_ID =vp.bill_id and p.customer_ID=v.customer_ID and p.Bill_ID not in (select d.Bill_ID from sales_Details d) and v.customer_ID= " & CustomerID.SelectedValue
                    a = cmd.ExecuteScalar
                    tblcustPyments.Columns("bill_id").DefaultValue = a
                    tblcustPyments.Columns("status").DefaultValue = "„ÃœÊ·…"
                    tblcustPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
                    tblcustPyments.Columns("pay_value").DefaultValue = 0
                    BSourcecustPayment.AddNew()
                    DataGridView1.Columns(1).ReadOnly = False
                    d = True
                End If

                Else

                    If Value.Value = 0 Then
                        cls.MsgExclamation(" „‰ ›÷·ﬂ «œŒ· ﬁÌ„Â «·—’Ìœ «·«›  «ÕÏ À„ ÃœÌœ")
                        Exit Sub
                    End If

                    tblcustPyments.Columns("bill_id").DefaultValue = custBillFirstBalance
                    tblcustPyments.Columns("status").DefaultValue = "„ÃœÊ·…"
                    tblcustPyments.Columns("bill_date").DefaultValue = Now.ToString("dd/MM/yyyy")
                    tblcustPyments.Columns("pay_value").DefaultValue = 0
                    BSourcecustPayment.AddNew()
                    DataGridView1.Columns(1).ReadOnly = False
                End If
            btnquery.Enabled = True
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
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


    'Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
    '    Try
    '        cmd.CommandText = "delete from vendors_payments where status='„ÃœÊ·…' and bill_id = " & tblvendorsPyments.Rows(0).Item("bill_id")
    '        cmd.ExecuteNonQuery()
    '        'cmd.CommandText = "delete from Vendors_First_Balance where Vendor_id=" & VendorID.SelectedValue
    '        'cmd.ExecuteNonQuery()
    '        Value.Value = False
    '        MyDs.Tables("vendors_payments").Rows.Clear()
    '        tblvendorsPyments.Rows.Clear()
    '        cls.MsgInfo(" „ Õ–› »Ì«‰«  «·”Ã· «·Õ«·Ì")
    '        'b = False
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try



    Private Sub FirstBalancecustomers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cmdPro.Parameters.Clear()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            cmd.CommandText = "delete from Customers_payments where status='„ÃœÊ·…' and bill_id = " & tblcustPyments.Rows(0).Item("bill_id")
            cmd.ExecuteNonQuery()
            'cmd.CommandText = "delete from Vendors_First_Balance where Vendor_id=" & VendorID.SelectedValue
            'cmd.ExecuteNonQuery()
            Value.Value = False
            MyDs.Tables("Customers_payments").Rows.Clear()
            tblcustPyments.Rows.Clear()
            cls.MsgInfo(" „ Õ–› »Ì«‰«  «·”Ã· «·Õ«·Ì")
            'b = False
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

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
