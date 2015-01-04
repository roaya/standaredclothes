Public Class ReturnsCustomers

    Dim TotalTemp As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Return_C_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate As Date
    Dim RptCustRet As New Report_Customers_Returns
    Dim B_ID As Integer
    Dim tbl1 As New GeneralDataSet.CustomersDataTable
    Dim tbl2 As New GeneralDataSet.StocksDataTable
    Dim TblRetDetls As New GeneralDataSet.Return_C_DetailsDataTable
    Dim tbl3 As New GeneralDataSet.Sales_HeaderDataTable
    Dim c As Boolean = False
    Private tblSalesDetails As New GeneralDataSet.Sales_DetailsDataTable
    Dim p As New Size(675, 162)
    Dim m As Double
    Dim required As Double
    Dim cmdhhb As New SqlClient.SqlCommandBuilder
    Dim dataadap As New SqlClient.SqlDataAdapter
#Region "Order_Subs"

    Sub AddItem()
        If Quantity.Value = 0 Then
            cls.MsgExclamation("«œŒ· «·⁄œœ")
        ElseIf DataGridView2.SelectedRows.Count <= 0 Then
            cls.MsgExclamation("√Œ — «·ﬂ„ÌÂ «·„—«œ «·’—› „‰Â«")
        Else
            Try
                For xx As Integer = 0 To DataGridView1.Rows.Count - 1

                    If DataGridView2.SelectedRows(0).Cells("Item_ID").Value = DataGridView1.Rows(xx).Cells("item_id").Value Then
                        If (DataGridView1.Rows(xx).Cells("quantity").Value + Quantity.Value) > DataGridView2.SelectedRows(0).Cells("quantity").Value Then
                            cls.MsgExclamation("·« Ì„ﬂ‰ «—Ã«⁄ ⁄œœ «ﬂ»— „‰ «·„ÊÃÊœ ›Ï «·›« Ê—Â")
                            Exit Sub

                        Else
                            TblRetDetls.Rows(xx).Item("Quantity") = TblRetDetls.Rows(xx).Item("Quantity") + Quantity.Value
                            TblRetDetls.Rows(xx).Item("Total_Item") = TblRetDetls.Rows(xx).Item("Quantity") * TblRetDetls.Rows(xx).Item("Price")
                            CalculateTotalBill()
                        End If
                        Exit Sub
                    End If
                Next
              


                r = TblRetDetls.NewRow
                r("Bill_ID") = BillID.Text
                r("Item_Name") = DataGridView2.SelectedRows(0).Cells("item_name").Value
                r("Item_ID") = DataGridView2.SelectedRows(0).Cells("item_id").Value
                r("Barcode") = DataGridView2.SelectedRows(0).Cells("barcode").Value
                r("Quantity") = Quantity.Value
                r("Price") = DataGridView2.SelectedRows(0).Cells("price").Value
                r("Total_Item") = DataGridView2.SelectedRows(0).Cells("price").Value * Quantity.Value
                If Quantity.Value > DataGridView2.SelectedRows(0).Cells("quantity").Value Then
                    cls.MsgExclamation("·« Ì„ﬂ‰ «—Ã«⁄ ⁄œœ «ﬂ»— „‰ «·„ÊÃÊœ ›Ï «·›« Ê—Â")
                    Quantity.Focus()
                    Exit Sub
                End If
                
                TblRetDetls.Rows.Add(r)

                Quantity.Value = 0



                Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Qty")
                'If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Sch") = "«·«”„" Then
                '    RadioItemName.Checked = True
                '    ItemName.Focus()
                'Else
                '    RadioBarCode.Checked = True
                '    BarCode.Focus()
                'End If

                CalculateTotalBill()
                'BarCode.Text = ""
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalculateTotalBill()

        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    If ReturnSome.Checked = True Then
                        TotalTemp = TblRetDetls.Compute("sum(total_item)", "bill_id=" & BillID.Text)


                    ElseIf ReturnALL.Checked = True Then
                        TotalTemp = TblRetDetls.Compute("sum(total_item)", "bill_id=" & SalBillID.Text)

                    Else
                        TotalTemp = 0
                        'CountRecords.Text = 0
                    End If

                 
                    TotalBill.Text = TotalTemp '- TotalDiscount
                    CalcPayType()
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalcPayType()
        If B_EndLoad = True Then
          

            Select Case PayType.Text


                Case "‰ﬁœÌ"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
                    CreditValue.ReadOnly = True
                    CashValue.ReadOnly = True
                Case "«Ã·"
                    CreditValue.Value = TotalBill.Text '- DTemp
                    CashValue.Value = 0
                    Cr_Value = CreditValue.Value
                    CashValue.Enabled = True
                    CashValue.ReadOnly = True

                    CreditValue.Enabled = True
                    CreditValue.ReadOnly = True
                Case "‰ﬁœÌ Ê «Ã·"
                    CashValue.ReadOnly = True
                    CreditValue.ReadOnly = True
                    CreditValue.Value = TotalBill.Text '- DTemp
                    If CreditValue.Value >= Remain.Text Then
                        CreditValue.Value = Remain.Text
                        CashValue.Value = TotalBill.Text - CreditValue.Value

                    End If
                    Cr_Value = CreditValue.Value

            End Select

            If CreditValue.Value > Remain.Text Then
                CashValue.Value = CreditValue.Value - Remain.Text
                CreditValue.Value = Remain.Text

            End If
          
        End If

    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        Try
            MyDs.Tables("Return_C_Header").Rows.Clear()
            TblRetDetls.Rows.Clear()

         
            If IsNew = False Then
                BillID.Text = 0
                'CashValue.Value = 0
                'CreditValue.Value = 0
                BtnNew.Enabled = True
                BtnSave.Enabled = False
                BtnDelete.Enabled = False
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = False
                BillDate.Text = Now
                BillTime.Text = ""
                cls.RefreshData("SELECT distinct ph.BILL_ID FROM sales_HEADER ph ,sales_Details pd  WHERE ph.bill_id=pd.Bill_ID and ph.Bill_ID NOT IN (select s.bill_id from sales_header s,Return_C_Header r WHERE r.Sal_Bill_ID=s.Bill_ID )", tbl3)
                SalBillID.ComboBox.DataSource = tbl3
                SalBillID.ComboBox.ValueMember = "bill_id"
                SalBillID.ComboBox.DisplayMember = "bill_id"
                TotalBill.Text = 0
                'DiscountValue.Value = 0
                'DiscountType.Text = "·« ÌÊÃœ"
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                'PayType.Text = "‰ﬁœÌ"
                'CashValue.Value = 0
                'CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                MyDs.Tables("report_Simple_sales").Rows.Clear()
                GroupHeader.Enabled = False
                GroupDetails.Enabled = False
                GroupItems.Enabled = False
                GroupAvailable.Enabled = False
                PayType.Enabled = False
                'DiscountTypeItem.Text = "·« ÌÊÃœ"
                'DiscountValueItem.Value = 0
                'DiscountValueItem.Enabled = False
                TotalTemp = 0
                B_EndLoad = False
                payType.Text = ""
                ReSchedule.Visible = False
                TotalSalBill.Text = "0"
                TotalSaleCash.Text = "0"
                TotalSalCredit.Text = "0"
                Total_Payed.Text = "0"
                Remain.Text = "0"
                CashValue.Value = 0
                CreditValue.Value = 0
                GroupBox5.Size = p
                Total_Payed.Visible = False
                Remain.Visible = False
                GeneralLabel15.Visible = False
                GeneralLabel16.Visible = False
                MyDs.Tables("customers_payments").Rows.Clear()
                tblCustomerPyments.Rows.Clear()
            Else

               
                'CashValue.Value = 0
                'CreditValue.Value = 0
                BtnNew.Enabled = False
                BtnSave.Enabled = True
                BtnDelete.Enabled = True
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = True
                BillDate.Text = Now
                BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                TotalBill.Text = 0
                'DiscountValue.Value = 0
                'DiscountType.Text = "·« ÌÊÃœ"
                EmployeeID.Text = EmpNameVar
                GroupAvailable.Enabled = True
                EmployeeID.Tag = EmpIDVar
                'PayType.Text = "‰ﬁœÌ"
                'CashValue.Value = 0
                'CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                PayType.Enabled = True
                GroupHeader.Enabled = True
                GroupDetails.Enabled = True
                GroupItems.Enabled = True
                'DiscountTypeItem.Text = "·« ÌÊÃœ"
                'DiscountValueItem.Value = 0
                'DiscountValueItem.Enabled = False
                TotalTemp = 0
                'If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Sch") = "«·«”„" Then
                '    RadioItemName.Checked = True
                '    ItemName.Focus()
                'Else
                '    RadioBarCode.Checked = True
                '    BarCode.Focus()
                'End If
                B_EndLoad = True


            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    

    Sub Commit_Form()
        If CustomerID.Text = "" Then
            cls.MsgExclamation("«Œ — «”„ «·⁄„Ì·")
        ElseIf StockID.Text = "" Then
            cls.MsgExclamation("√œŒ· «”„ «·„Õ·")
   
        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")

        Else
            Try
                B_ID = BillID.Text

                CalculateTotalBill()

                'For i As Integer = 0 To DataGridView1.Rows.Count - 1
                '    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & StockID.SelectedValue & ")"
                '    If cmd.ExecuteScalar = 1 Then
                '        cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…")
                '        Exit Sub
                '    End If
                'Next
              
                required = Remain.Text - CreditValue.Value
                If CreditValue.Value < Remain.Text Then
                    If tblCustomerPyments.Rows.Count = 0 Then
                        cls.MsgExclamation("·„ Ì „ ÃœÊ·… „Ê«⁄Ìœ «·”œ«œ")
                        Exit Sub

                    Else
                        If tblCustomerPyments.Compute("Sum(Pay_Value)", "bill_id=" & SalBillID.ComboBox.SelectedValue & " and status='„ÃœÊ·…'") <> required Then
                            cls.MsgExclamation("·„ Ì „ ÃœÊ·… „Ê«⁄Ìœ «·”œ«œ")
                            Exit Sub



                        Else

                            tblCustomerPyments.AcceptChanges()

                            BSourceVenPayment.EndEdit()

                            cmdhhb.DataAdapter = da
                            dataadap.Update(tblCustomerPyments)

                            Dim d2 As Date
                            cmd.CommandText = "delete  from customers_payments where status=N'„ÃœÊ·…' and bill_id=" & SalBillID.ComboBox.SelectedValue
                            cmd.ExecuteNonQuery()
                            For xx As Integer = 0 To tblCustomerPyments.Rows.Count - 1


                                d2 = tblCustomerPyments.Rows(xx).Item("bill_Date")
                                cmd.CommandText = "insert into customers_payments (Bill_Date,Pay_Value,Status,bill_id) values('" & d2.ToString("MM/dd/yyyy") & "' ," & _
                              tblCustomerPyments.Rows(xx).Item("pay_value") & ",N'" & tblCustomerPyments.Rows(xx).Item("status") & "'," & _
                               tblCustomerPyments.Rows(xx).Item("bill_id") & ")"
                                cmd.ExecuteNonQuery()

                            Next
                        End If

                    End If

                Else
                    cmd.CommandText = "delete from customers_payments where status=N'„ÃœÊ·…' and bill_id=" & SalBillID.ComboBox.SelectedValue
                    cmd.ExecuteNonQuery()



                End If

              

               

              






                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Return_C_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & customerID.SelectedValue & "," & _
        TotalBill.Text & "," & CashValue.Value & "," & CreditValue.Value & "," & EmpIDVar & ",N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.SelectedValue & ",N'" & payType.Text & "'," & SalBillID.ComboBox.SelectedValue & "," & CurrentShiftID
                cmd.ExecuteNonQuery()
                'CmdProHdr.Parameters(1).SqlValue = BillDate.Text
                'CmdProHdr.Parameters(2).SqlValue = BillTime.Text
                'CmdProHdr.Parameters(3).SqlValue = CustomerID.SelectedValue
                'CmdProHdr.Parameters(4).SqlValue = TotalBill.Text
                'CmdProHdr.Parameters(5).SqlValue = DiscountType.Text
                'CmdProHdr.Parameters(6).SqlValue = DiscountValue.Value
                'CmdProHdr.Parameters(7).SqlValue = EmpIDVar
                'CmdProHdr.Parameters(8).SqlValue = CashValue.Value
                'CmdProHdr.Parameters(9).SqlValue = CreditValue.Value
                'CmdProHdr.Parameters(10).SqlValue = PayType.Text
                'CmdProHdr.Parameters(11).SqlValue = Comments.TextBox1.Text
                'CmdProHdr.Parameters(12).SqlValue = PurFooter
                'CmdProHdr.Parameters(13).SqlValue = StockID.SelectedValue
                'CmdProHdr.ExecuteNonQuery()


                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    'CmdProDtl.Parameters(0).SqlValue =
                    'CmdProDtl.Parameters(1).SqlValue =
                    'CmdProDtl.Parameters(2).SqlValue =
                    'CmdProDtl.Parameters(3).SqlValue =
                    'CmdProDtl.Parameters(4).SqlValue =
                    'CmdProDtl.Parameters(5).SqlValue =
                    'CmdProDtl.Parameters(6).SqlValue =
                    'CmdProDtl.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Return_C_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & StockID.SelectedValue & "," & DataGridView1.Rows(i).Cells("Total_Item").Value
                    cmd.ExecuteNonQuery()

                    cls.Commit_Inv_Tran(BillID.Text, BDate, TotalBill.Text, DataGridView1.Rows(i).Cells("Item_ID").Value, DataGridView1.Rows(i).Cells("Quantity").Value, "„— Ã⁄ ⁄„·«¡", StockID.SelectedValue)

                Next



                da.Update(tblCustomerPyments)
                cls.RefreshData("select * from customers_payments", tblCustomerPyments)
                'cls.MsgInfo(" „  «⁄«œÂ «·ÃœÊ·Â »‰Ã«Õ")




                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                    re = False
                End If
                B_Edited = False
                Call ResetOrder(False)

            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try

        End If


    End Sub
#End Region

    Private Sub PurchaseOrderNormal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If B_Edited = True Then

            Commit_Form()
        End If
    End Sub

    Private Sub PurchaseOrderNormal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("ÌÃ» Õ›Ÿ «·›« Ê—… «Ê Õ–›Â« «Ê·«")
        End If

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try

            If CurrentShiftID = 0 Then
                cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ…")
                Exit Sub
            End If

            MyDs.Tables("report_Simple_sales").Rows.Clear()
            If SalBillID.Text = "" Then
                cls.MsgExclamation("„‰ ›÷·ﬂ «Œ — —ﬁ„ «·›« Ê—Â")
            Else

                New_Form()
                If c = True Then
                    cls.RefreshData("select * from sales_header h , stocks s where h.stock_id=s.stock_id and h.bill_id=" & SalBillID.ComboBox.SelectedValue, tbl2)


                    cls.RefreshData("select * from sales_header h , customers c where h.customer_id=c.customer_id and h.bill_id=" & SalBillID.ComboBox.SelectedValue, tbl1)
                    customerID.DataSource = tbl1
                    customerID.DisplayMember = "Customer_Name"
                    customerID.ValueMember = "Customer_ID"

                    StockID.DataSource = tbl2
                    StockID.DisplayMember = "Stock_Name"
                    StockID.ValueMember = "Stock_ID"

                    cmd.CommandText = "Select * from report_Simple_sales where bill_id=" & SalBillID.ComboBox.SelectedValue
                    da.Fill(MyDs.Tables("report_Simple_sales"))
                    DataGridView2.DataSource = (MyDs.Tables("report_Simple_sales"))
                    cmd.CommandText = "select Pay_type from sales_header where  bill_id=" & SalBillID.ComboBox.SelectedValue
                    payType.Text = cmd.ExecuteScalar

                    If payType.Text = "‰ﬁœÌ" Then
                        CashValue.ReadOnly = True
                        CreditValue.ReadOnly = True
                        ReSchedule.Visible = False
                        Total_Payed.Visible = False
                        Remain.Visible = False
                        GeneralLabel16.Visible = False
                        GeneralLabel15.Visible = False
                        GroupBox5.Size = p

                    ElseIf payType.Text = "«Ã·" Then
                        ReSchedule.Enabled = True
                        CashValue.Enabled = False

                        Total_Payed.Visible = True
                        Remain.Visible = True
                        GeneralLabel16.Visible = True
                        GeneralLabel15.Visible = True
                        GroupBox5.Size = New Size(675, 225)
                    ElseIf payType.Text = "‰ﬁœÌ Ê «Ã·" Then
                        CashValue.Enabled = True
                        CreditValue.Enabled = True
                        CashValue.ReadOnly = False
                        CreditValue.ReadOnly = False
                        ReSchedule.Enabled = True

                        Total_Payed.Visible = True
                        Remain.Visible = True
                        GeneralLabel16.Visible = True
                        GeneralLabel15.Visible = True
                        GroupBox5.Size = New Size(675, 225)
                    End If

                    cmd.CommandText = "select total_bill from sales_header where  bill_id=" & SalBillID.ComboBox.SelectedValue
                    TotalSalBill.Text = cmd.ExecuteScalar


                    cmd.CommandText = "select cash_value from sales_header where  bill_id=" & SalBillID.ComboBox.SelectedValue
                    TotalSaleCash.Text = cmd.ExecuteScalar

                    cmd.CommandText = "select credit_value from sales_header where  bill_id=" & SalBillID.ComboBox.SelectedValue
                    TotalSalCredit.Text = cmd.ExecuteScalar



                    cmd.CommandText = "select isnull(sum(pay_value),0) from customers_payments where status=N'„ÃœÊ·…' and  bill_id =" & SalBillID.ComboBox.SelectedValue
                    Remain.Text = cmd.ExecuteScalar

                    cmd.CommandText = "select isnull(sum(pay_value),0) from customers_payments where status=N'„œ›Ê⁄…' and  bill_id =" & SalBillID.ComboBox.SelectedValue
                    Total_Payed.Text = cmd.ExecuteScalar
                End If
                End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Commit_Form()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Delete_Bill()
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddItem()
        End If

    End Sub



    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                TotalBill.Text = 0
                'TotalTemp.Text = 0
                'CountRecords.Text = 0
            Else
                CalculateTotalBill()
                'CalcPayType()
                'CountRecords.Text = TblRetDetls.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
            End If
        End If

    End Sub

   


   

    Private Sub returncustomers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData("select * from Customers", tbl1)
            cls.RefreshData("select * from stocks", tbl2)

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
           

            CustomerID.DataSource = tbl1
            CustomerID.DisplayMember = "Customer_Name"
            CustomerID.ValueMember = "Customer_ID"

            StockID.DataSource = tbl2
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"

            cls.RefreshData("SELECT distinct ph.BILL_ID FROM sales_HEADER ph ,sales_Details pd  WHERE ph.bill_id=pd.Bill_ID and ph.Bill_ID not IN (select s.bill_id from sales_header s,Return_C_Header r WHERE r.Sal_Bill_ID=s.Bill_ID )", tbl3)
            SalBillID.ComboBox.DataSource = tbl3
            SalBillID.ComboBox.ValueMember = "bill_id"
            SalBillID.ComboBox.DisplayMember = "bill_id"


            DataGridView1.DataSource = TblRetDetls
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "«”„ «·’‰›"
            DataGridView1.Columns(4).HeaderText = "«·»«—ﬂÊœ"
            DataGridView1.Columns(5).HeaderText = "«·⁄œœ"
            DataGridView1.Columns(6).HeaderText = "”⁄— «·ÊÕœ…"
            DataGridView1.Columns(7).HeaderText = "«Ã„«·Ì «·’‰›"


            TblRetDetls.Rows.Clear()
            ' MyDs.Tables("Return_C_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 3
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"

            DataGridView2.DataSource = MyDs.Tables("report_simple_sales")
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(1).Visible = False

          
            DataGridView2.Columns(2).HeaderText = "«”„ «·’‰›"
            DataGridView2.Columns(3).HeaderText = "«·»«—ﬂÊœ"
            DataGridView2.Columns(4).HeaderText = "«·⁄œœ"
            DataGridView2.Columns(5).HeaderText = "«·”⁄—"

            DataGridView2.Columns(6).HeaderText = "«Ã„«·Ì «·’‰›"

            c = True
            Total_Payed.Visible = False
            Remain.Visible = False
            GeneralLabel16.Visible = False
            GeneralLabel15.Visible = False
            GroupBox5.Size = p

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("Calc.exe", AppWinStyle.NormalFocus)
    End Sub

    'Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountTypeItem.TextChanged
    '    DiscountChangeTypes(False)
    'End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
        CalculateTotalBill()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    

    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        Commit_Print()
    End Sub

    Private Sub BtnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New Customers
        m.ShowDialog()
    End Sub

 
    Private Sub MenuBtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuBtnNew.Click
        New_Form()
    End Sub

    Sub New_Form()
        Try
            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            'DiscountValue.Enabled = False
            'CreditValue.Enabled = False
            TblRetDetls.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub Commit_Print()
        Try
            Me.Cursor = Cursors.WaitCursor
            Commit_Form()

            MyDs.Tables("Report_Customers_Returns").Rows.Clear()
            cmd.CommandText = "select * from Report_Customers_Returns where bill_id = " & B_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Customers_Returns"))
            RptCustRet.SetDataSource(MyDs.Tables("Report_Customers_Returns"))

            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = RptCustRet
            m.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub Delete_Bill()
        If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            'MyDs.Tables("Return_C_Header").Rows.Clear()
            TblRetDetls.Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo(" „ Õ–› «·›« Ê—… »‰Ã«Õ")
            End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub MenuBtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuBtnSave.Click
        Commit_Form()
    End Sub

    Private Sub MenuBtnSavePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuBtnSavePrint.Click
        Commit_Print()
    End Sub

    Private Sub MenuBtnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuBtnExit.Click
        Delete_Bill()
    End Sub

   
    'Private Sub CustomerID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomerID.Leave
    '    If c = True Then
    '        If CustomerID.Text = "" Then
    '            cls.MsgExclamation("„‰ ›÷·ﬂ «Œ — «”„ «·⁄„Ì·")
    '        ElseIf StockID.Text = "" Then
    '            cls.MsgExclamation("„‰ ›÷·ﬂ «Œ — «”„ «·„Œ‰")
    '        Else
    '            cls.RefreshData("select bill_id from sales_header where customer_id=" & CustomerID.SelectedValue & "',and stock_id=" & StockID.SelectedValue, tbl3)
    '            SalBillID.DataSource = tbl3
    '            SalBillID.ValueMember = "bill_id"
    '            SalBillID.DisplayMember = "bill_id"
    '        End If

    '    End If
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DataGridView1.Rows.Count < 1 Then


                'MyDs.Tables("report_Simple_sales").Rows.Clear()
                cmd.CommandText = "Select * from report_Simple_sales where bill_id=" & SalBillID.ComboBox.SelectedValue
                da.Fill(TblRetDetls)
                DataGridView1.DataSource = TblRetDetls
                CalculateTotalBill()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ReturnALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnALL.CheckedChanged
        If ReturnALL.Checked = True Then
            Button1.Enabled = True
            Quantity.Enabled = False
        End If
    End Sub

    Private Sub ReturnSome_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnSome.CheckedChanged
        If ReturnSome.Checked = True Then
            Button1.Enabled = False
            Quantity.Enabled = True
        End If
    End Sub

    Private Sub ReSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReSchedule.Click
        Bill = SalBillID.ComboBox.SelectedValue
        Dim m As New ReScheduling
        m.ShowDialog()
    End Sub

    Private Sub CreditValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditValue.ValueChanged
        If CreditValue.Value < Remain.Text Then
            ReSchedule.Visible = True
            Cr_Value = CreditValue.Value
        Else
            ReSchedule.Visible = False
        End If
    End Sub
   

  
End Class