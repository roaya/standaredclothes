Public Class ReturnsVendors

    Dim TotalTemp As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Return_V_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate As Date
    Dim RptCustRet As New Report_Vendors_Returns
    Dim B_ID As Integer
    Dim tbl1 As New GeneralDataSet.VendorsDataTable
    Dim tbl2 As New GeneralDataSet.StocksDataTable
    Dim TblVenDetails As New GeneralDataSet.Return_V_DetailsDataTable
    Private tblpurchaseDetails As New GeneralDataSet.Purchase_DetailsDataTable
    Dim tbl3 As New GeneralDataSet.Purchase_HeaderDataTable
    Dim c As Boolean = False
    Dim p As New Size(675, 162)
    Dim m As Double
    Dim required As Double
    Dim total As Double
    Dim cmdhhb As New SqlClient.SqlCommandBuilder
    Dim dataadap As New SqlClient.SqlDataAdapter

#Region "Order_Subs"

    Sub AddItem()

        Try
            If Quantity.Value = 0 Then
                cls.MsgExclamation("«œŒ· «·⁄œœ")
            ElseIf DataGridView2.SelectedRows.Count <= 0 Then
                cls.MsgExclamation("√Œ — «·ﬂ„ÌÂ «·„—«œ «·’—› „‰Â«")
            Else


                For xx As Integer = 0 To DataGridView1.Rows.Count - 1

                    If DataGridView2.SelectedRows(0).Cells("Item_ID").Value = DataGridView1.Rows(xx).Cells("item_id").Value Then
                        If (DataGridView1.Rows(xx).Cells("quantity").Value + Quantity.Value) > DataGridView2.SelectedRows(0).Cells("quantity").Value Then
                            cls.MsgExclamation("·« Ì„ﬂ‰ «—Ã«⁄ ⁄œœ «ﬂ»— „‰ «·„ÊÃÊœ ›Ï «·›« Ê—Â")
                            Exit Sub

                        Else
                            TblVenDetails.Rows(xx).Item("Quantity") = TblVenDetails.Rows(xx).Item("Quantity") + Quantity.Value
                            TblVenDetails.Rows(xx).Item("Total_Item") = TblVenDetails.Rows(xx).Item("Quantity") * TblVenDetails.Rows(xx).Item("Price")
                            CalculateTotalBill()
                        End If
                        Exit Sub
                    End If
                Next




                r = TblVenDetails.NewRow
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
                TblVenDetails.Rows.Add(r)

                'If ProjectSettings.SrchNameOnRtnVenNrml = True Then
                '    RadioItemName.Checked = True
                '    ItemName.Focus()
                'Else
                '    RadioBarCode.Checked = True
                '    BarCode.Focus()
                'End If

                Quantity.Value = 0

                'DiscountTypeItem.Text = "·« ÌÊÃœ"

                Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Qty")
                'If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Sch") = "«·«”„" Then
                '    RadioItemName.Checked = True
                '    ItemName.Focus()
                'Else
                '    RadioBarCode.Checked = True
                '    BarCode.Focus()
            End If

            CalculateTotalBill()

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
               
                If DataGridView1.Rows.Count > 0 Then
                    If ReturnSome.Checked = True Then
                        TotalTemp = TblVenDetails.Compute("sum(total_item)", "bill_id=" & BillID.Text)
                        'CountRecords.Text = TblRetDetls.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)

                    ElseIf ReturnALL.Checked = True Then
                        TotalTemp = TblVenDetails.Compute("sum(total_item)", "bill_id=" & purchasebill.Text)

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
                    'CashValue.Value = 0
                    'CreditValue.Value = 0
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
            MyDs.Tables("Return_V_Header").Rows.Clear()
            TblVenDetails.Rows.Clear()
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
                TotalBill.Text = 0
                'DiscountValue.Value = 0
                'DiscountType.Text = "·« ÌÊÃœ"
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                'PayType.Text = "‰ﬁœÌ"
                'CashValue.Value = 0
                'CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                cls.RefreshData("SELECT distinct ph.BILL_ID FROM purchase_HEADER ph ,Purchase_Details pd  WHERE ph.bill_id=pd.Bill_ID and ph.Bill_ID NOT IN (select s.bill_id from purchase_header s,Return_v_Header r WHERE r.purchase_Bill_ID=s.Bill_ID )", tbl3)
                PurchaseBill.ComboBox.DataSource = tbl3
                PurchaseBill.ComboBox.ValueMember = "bill_id"
                PurchaseBill.ComboBox.DisplayMember = "bill_id"
                GroupHeader.Enabled = False
                GroupBox1.Enabled = False
                GroupBox5.Enabled = False
                MyDs.Tables("report_Simple_purchase").Rows.Clear()
                GroupItems.Enabled = False
                'DiscountTypeItem.Text = "·« ÌÊÃœ"
                'DiscountValueItem.Value = 0
                'DiscountValueItem.Enabled = False
                TotalTemp = 0
                CashValue.Value = 0
                CreditValue.Value = 0
                B_EndLoad = False
                TblVenDetails.Rows.Clear()
                payType.Enabled = False
                payType.Text = ""
                TotalSalBill.Text = "0"
                TotalSaleCash.Text = "0"
                TotalSalCredit.Text = "0"
                Total_Payed.Text = "0"
                Remain.Text = "0"
                CashValue.Value = 0
                CreditValue.Value = 0
                GroupBox6.Size = p
                Total_Payed.Visible = False
                Remain.Visible = False
                GeneralLabel5.Visible = False
                GeneralLabel18.Visible = False
                tblvendorsPyments.Rows.Clear()
            Else

              
                'CashValue.Value = 0
                'CreditValue.Value = 0
                BtnNew.Enabled = False
                BtnSave.Enabled = True
                BtnDelete.Enabled = True
                payType.Enabled = True

                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = True
                BillDate.Text = Now
                BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                TotalBill.Text = 0
                'DiscountValue.Value = 0
                'DiscountType.Text = "·« ÌÊÃœ"
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                'PayType.Text = "‰ﬁœÌ"
                'CashValue.Value = 0
                'CreditValue.Value = 0
                VendorID.Text = ""
                StockID.Text = ""
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = True
                GroupBox1.Enabled = True
                GroupBox5.Enabled = True
                GroupItems.Enabled = True
                'DiscountTypeItem.Text = "·« ÌÊÃœ"
                'DiscountValueItem.Value = 0
                'DiscountValueItem.Enabled = False
                TotalTemp = 0
                'If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Ven_Def_Sch") = "«·«”„" Then
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

    'Sub DiscountChangeTypes(ByVal IsGeneralDiscount As Boolean)
    '    If B_EndLoad = True Then
    '        If IsGeneralDiscount = True Then
    '            If DiscountType.Text = "‰”»… „∆ÊÌ…" Then
    '                DiscountValue.Enabled = True
    '                DiscountValue.Value = 0
    '                DiscountValue.Maximum = 100
    '            ElseIf DiscountType.Text = "„»·€ À«» " Then
    '                DiscountValue.Enabled = True
    '                DiscountValue.Maximum = 1000000
    '                DiscountValue.Value = 0
    '            Else
    '                DiscountValue.Enabled = False
    '                DiscountValue.Maximum = 0
    '                DiscountValue.Value = 0
    '            End If
    '            CalculateTotalBill()
    '            CalcPayType()
    '        Else

    '            If DiscountTypeItem.Text = "‰”»… „∆ÊÌ…" Then
    '                DiscountValueItem.Enabled = True
    '                DiscountValueItem.Value = 0
    '                DiscountValueItem.Maximum = 100
    '            ElseIf DiscountTypeItem.Text = "„»·€ À«» " Then
    '                DiscountValueItem.Enabled = True
    '                DiscountValueItem.Maximum = 1000000
    '                DiscountValueItem.Value = 0
    '            Else
    '                DiscountValueItem.Enabled = False
    '                DiscountValueItem.Maximum = 0
    '                DiscountValueItem.Value = 0
    '            End If

    '        End If
    '    End If
    'End Sub

    Sub Commit_Form()
        If VendorID.Text = "" Then
            cls.MsgExclamation("«Œ — «”„ «·„Ê—œ")
        ElseIf StockID.Text = "" Then
            cls.MsgExclamation("√œŒ· «”„ «·„Õ·")

        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")

        Else
            Try
                B_ID = BillID.Text

                CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & StockID.SelectedValue & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…")
                        Exit Sub
                    End If
                Next
               

                required = Remain.Text - CreditValue.Value
                If CreditValue.Value < Remain.Text Then
                   
                    If tblvendorsPyments.Rows.Count = 0 Then
                        cls.MsgExclamation("·„ Ì „ ÃœÊ·… „Ê«⁄Ìœ «·”œ«œ")
                        Exit Sub
                    Else

                        If tblvendorsPyments.Compute("Sum(Pay_Value)", "bill_id=" & PurchaseBill.ComboBox.SelectedValue & " and status='„ÃœÊ·…'") <> required Then
                            cls.MsgExclamation("·„ Ì „ ÃœÊ·… „Ê«⁄Ìœ «·”œ«œ")
                            Exit Sub


                        Else

                            tblvendorsPyments.AcceptChanges()

                            BSourceVenPayment.EndEdit()

                            cmdhhb.DataAdapter = da
                            dataadap.Update(tblvendorsPyments)

                            cmd.CommandText = "delete  from vendors_payments where status=N'„ÃœÊ·…' and bill_id=" & PurchaseBill.ComboBox.SelectedValue
                            cmd.ExecuteNonQuery()

                            Dim d2 As Date

                            For xx As Integer = 0 To tblvendorsPyments.Rows.Count - 1


                                d2 = tblvendorsPyments.Rows(xx).Item("bill_Date")
                                cmd.CommandText = "insert into vendors_payments (Bill_Date,Pay_Value,Status,bill_id) values('" & d2.ToString("MM/dd/yyyy") & "' ," & _
                              tblvendorsPyments.Rows(xx).Item("pay_value") & ",N'" & tblvendorsPyments.Rows(xx).Item("status") & "'," & _
                               tblvendorsPyments.Rows(xx).Item("bill_id") & ")"
                                cmd.ExecuteNonQuery()

                            Next

                        End If


                    End If




                Else


                    cmd.CommandText = "delete from vendors_payments where status=N'„ÃœÊ·…' and bill_id=" & PurchaseBill.ComboBox.SelectedValue
                    cmd.ExecuteNonQuery()

                End If

                    'If total <> required Then
                    '    cls.MsgExclamation("»—Ã«¡ «⁄«œÂ «·ÃœÊ·Â")
                    '    Exit Sub
                    'End If



                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Return_V_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & VendorID.SelectedValue & "," & _
        TotalBill.Text & "," & CashValue.Value & "," & CreditValue.Value & "," & EmpIDVar & ",N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.SelectedValue & ",N'" & payType.Text & "'," & PurchaseBill.ComboBox.SelectedValue & "," & CurrentShiftID
                cmd.ExecuteNonQuery()

                'CmdProHdr.ExecuteNonQuery()


                For i As Integer = 0 To DataGridView1.Rows.Count - 1


                    cmd.CommandText = "Exec Commit_Return_V_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & StockID.SelectedValue & "," & DataGridView1.Rows(i).Cells("Total_Item").Value
                    cmd.ExecuteNonQuery()

                    cls.Commit_Inv_Tran(BillID.Text, BDate, TotalBill.Text, DataGridView1.Rows(i).Cells("Item_ID").Value, DataGridView1.Rows(i).Cells("Quantity").Value, "„— Ã⁄ „Ê—œÌ‰", StockID.SelectedValue)

                Next

                'cls.MsgInfo(" „  «⁄«œÂ «·ÃœÊ·Â »‰Ã«Õ")


                da.Update(tblvendorsPyments)
                cls.RefreshData("select * from vendors_payments", tblvendorsPyments)



                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                    vre = False
                End If
                B_Edited = False
                Call ResetOrder(False)
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If


    End Sub
#End Region






    Private Sub ReturnsVendors_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If B_Edited = True Then

            Commit_Form()
        End If
    End Sub

    Private Sub ReturnsVendors_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("ÌÃ» Õ›Ÿ «·›« Ê—… «Ê Õ–›Â« «Ê·«")
        End If
    End Sub




    'Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
    '    Me.Close()
    'End Sub

    'Private Sub BtnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalculator.Click
    '    Shell("Calc.exe", AppWinStyle.NormalFocus)
    'End Sub

    'Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountTypeItem.TextChanged
    '    DiscountChangeTypes(False)
    'End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                TotalBill.Text = 0
                'TotalTemp.Text = 0

            Else
                Try
                    CalculateTotalBill()
                    'CalcPayType()

                Catch ex As Exception
                    cls.WriteError(ex.Message, TName)
                End Try

            End If

        End If
    End Sub

    Private Sub DataGridView1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Validated
        'DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
        CalculateTotalBill()
    End Sub


    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Commit_Form()

            MyDs.Tables("Report_Vendors_Returns").Rows.Clear()
            cmd.CommandText = "select * from Report_Vendors_Returns where bill_id = " & B_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Vendors_Returns"))
            RptCustRet.SetDataSource(MyDs.Tables("Report_Vendors_Returns"))
            RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = RptCustRet
            m.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ReturnsVendors_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim B As New BindingSource

            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"


            cls.RefreshData("select* from Vendors", tbl1)
            cls.RefreshData("select* from Stocks", tbl2)

            VendorID.DataSource = tbl1
            VendorID.DisplayMember = "Vendor_Name"
            VendorID.ValueMember = "Vendor_ID"

            StockID.DataSource = tbl2
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"


            cls.RefreshData("SELECT distinct ph.BILL_ID FROM purchase_HEADER ph ,Purchase_Details pd  WHERE ph.bill_id=pd.Bill_ID and ph.Bill_ID NOT IN (select s.bill_id from purchase_header s,Return_v_Header r WHERE r.purchase_Bill_ID=s.Bill_ID )", tbl3)
            PurchaseBill.ComboBox.DataSource = tbl3
            PurchaseBill.ComboBox.ValueMember = "bill_id"
            PurchaseBill.ComboBox.DisplayMember = "bill_id"

            DataGridView1.DataSource = TblVenDetails
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "«”„ «·’‰›"
            DataGridView1.Columns(4).HeaderText = "«·»«—ﬂÊœ"
            DataGridView1.Columns(5).HeaderText = "«·⁄œœ"
            DataGridView1.Columns(6).HeaderText = "”⁄— «·ÊÕœ…"
            DataGridView1.Columns(7).HeaderText = "«Ã„«·Ì «·’‰›"


            TblVenDetails.Rows.Clear()


            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 4
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"



            DataGridView2.DataSource = MyDs.Tables("report_Simple_purchase")
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
            GeneralLabel18.Visible = False
            GeneralLabel5.Visible = False
            GroupBox6.Size = p

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try

            If CurrentShiftID = 0 Then
                cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ…")
                Exit Sub
            End If

            MyDs.Tables("report_Simple_purchase").Rows.Clear()
            If PurchaseBill.Text = "" Then
                cls.MsgExclamation("„‰ ›÷·ﬂ «Œ — —ﬁ„ «·›« Ê—Â")
            Else

                New_Form()
                If c = True Then
                    cls.RefreshData("select * from purchase_header h , stocks s where h.stock_id=s.stock_id and h.bill_id=" & PurchaseBill.ComboBox.SelectedValue, tbl2)


                    cls.RefreshData("select * from purchase_header h , vendors v  where h.vendor_id=v.vendor_id and h.bill_id=" & PurchaseBill.ComboBox.SelectedValue, tbl1)
                    VendorID.DataSource = tbl1
                    VendorID.DisplayMember = "vendor_name"
                    VendorID.ValueMember = "vendor_id"

                    StockID.DataSource = tbl2
                    StockID.DisplayMember = "Stock_Name"
                    StockID.ValueMember = "Stock_ID"

                    cmd.CommandText = "Select * from report_Simple_purchase where bill_id=" & PurchaseBill.ComboBox.SelectedValue
                    da.Fill(MyDs.Tables("report_Simple_purchase"))
                    DataGridView2.DataSource = (MyDs.Tables("report_Simple_purchase"))
                    cmd.CommandText = "select Pay_type from purchase_header where  bill_id=" & PurchaseBill.ComboBox.SelectedValue
                    payType.Text = cmd.ExecuteScalar

                    If payType.Text = "‰ﬁœÌ" Then
                        CashValue.ReadOnly = True
                        CreditValue.ReadOnly = True
                        ReSchedule.Visible = False
                        Total_Payed.Visible = False
                        Remain.Visible = False
                        GeneralLabel18.Visible = False
                        GeneralLabel5.Visible = False
                        GroupBox6.Size = p

                    ElseIf payType.Text = "«Ã·" Then
                        ReSchedule.Enabled = True
                        CashValue.Enabled = False

                        Total_Payed.Visible = True
                        Remain.Visible = True
                        GeneralLabel18.Visible = True
                        GeneralLabel5.Visible = True
                        GroupBox6.Size = New Size(675, 225)
                    ElseIf payType.Text = "‰ﬁœÌ Ê «Ã·" Then
                        CashValue.Enabled = True
                        CreditValue.Enabled = True
                        CashValue.ReadOnly = False
                        CreditValue.ReadOnly = False
                        ReSchedule.Enabled = True

                        Total_Payed.Visible = True
                        Remain.Visible = True
                        GeneralLabel18.Visible = True
                        GeneralLabel5.Visible = True
                        GroupBox6.Size = New Size(675, 225)
                    End If

                    cmd.CommandText = "select total_bill from purchase_header where  bill_id=" & PurchaseBill.ComboBox.SelectedValue
                    TotalSalBill.Text = cmd.ExecuteScalar


                    cmd.CommandText = "select cash_value from purchase_header where  bill_id=" & PurchaseBill.ComboBox.SelectedValue
                    TotalSaleCash.Text = cmd.ExecuteScalar

                    cmd.CommandText = "select credit_value from purchase_header where  bill_id=" & PurchaseBill.ComboBox.SelectedValue
                    TotalSalCredit.Text = cmd.ExecuteScalar

                    cmd.CommandText = "select isnull(sum(pay_value),0) from vendors_payments where status=N'„ÃœÊ·…' and  bill_id =" & PurchaseBill.ComboBox.SelectedValue
                    Remain.Text = cmd.ExecuteScalar

                    cmd.CommandText = "select isnull(sum(pay_value),0) from vendors_payments where status=N'„œ›Ê⁄…' and  bill_id =" & PurchaseBill.ComboBox.SelectedValue
                    Total_Payed.Text = cmd.ExecuteScalar
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Commit_Form()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            MyDs.Tables("Return_V_Header").Rows.Clear()
            TblVenDetails.Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo(" „ Õ–› «·›« Ê—… »‰Ã«Õ")
            End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddItem()
        End If
    End Sub




    Private Sub BtnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DataGridView1.Rows.Count < 1 Then


                'MyDs.Tables("report_Simple_purchase").Rows.Clear()
                cmd.CommandText = "Select * from report_Simple_purchase where bill_id=" & PurchaseBill.ComboBox.SelectedValue
                da.Fill(TblVenDetails)
                DataGridView1.DataSource = TblVenDetails
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
    Sub New_Form()
        Try
            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            'DiscountValue.Enabled = False
            'CreditValue.Enabled = False
            TblVenDetails.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ReSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReSchedule.Click
        VendBill = PurchaseBill.ComboBox.SelectedValue
        Dim m As New vendorsReScheduling
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

    Private Sub GroupHeader_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader.Enter

    End Sub
End Class
