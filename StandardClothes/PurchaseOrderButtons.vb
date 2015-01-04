Public Class PurchaseOrderButtons
    Dim TotalTemp, TotalDiscount As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Purchase_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate As Date
    Dim d As Date
    Dim B_ID As Integer
    Dim RptPur As New Report_Purchase_Order
    Dim tbl1 As New GeneralDataSet.StocksDataTable
    Dim tbl2 As New GeneralDataSet.VendorsDataTable
    Private TblQStocks As New GeneralDataSet.Query_Items_StocksDataTable
    Dim Vu As New DataView(TblQStocks)
#Region "Order_Subs"

    Sub AddItem(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            ItmID = CType(sender, Button).Tag
            cmd.CommandText = "select barcode from items where item_id=" & ItmID
            BarCde = cmd.ExecuteScalar
            cmd.CommandText = "select item_Name from items where item_id=" & ItmID
            ItmName = cmd.ExecuteScalar

            For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(xx).Cells("item_id").Value = ItmID Then
                    DataGridView1.Rows(xx).Cells("quantity").Value = DataGridView1.Rows(xx).Cells("quantity").Value + 1

                    Select Case PayType.Text
                        Case "‰ﬁœÌ"
                            CashValue.Value = TotalBill.Text
                        Case "«Ã·"
                            CreditValue.Value = TotalBill.Text
                        Case "»‘Ìﬂ"
                            CashValue.Value = TotalBill.Text
                    End Select

                    Calc_Total_Items()
                    CalculateTotalBill()
                    DataGridView1.Rows(xx).Selected = True
                    Quantity.Focus()
                    Quantity.Select(0, 1000)
                    Exit Sub
                End If
            Next

            VendorID.Enabled = False
            BtnNewVendor.Enabled = False
            r = MyDs.Tables("Purchase_Details").NewRow
            r("Bill_ID") = BillID.Text
            r("Item_Name") = ItmName
            r("Item_ID") = ItmID
            r("Barcode") = BarCde
            r("Quantity") = 1
            r("Discount_Type") = "·« ÌÊÃœ"
            r("Discount_Value") = 0

            Select Case DiscountTypeItem.Text
                Case "„»·€ À«» "
                    ItmPrc = Price.Value - DiscountValueItem.Value
                Case "‰”»… „∆ÊÌ…"
                    ItmPrc = (Price.Value - (Price.Value * (DiscountValueItem.Value / 100)))
                Case "·« ÌÊÃœ"
                    ItmPrc = Price.Value
            End Select
            cmd.CommandText = "select purchase_price from Items where item_id=" & ItmID
            r("Price") = cmd.ExecuteScalar
            r("Total_Item") = cmd.ExecuteScalar
            MyDs.Tables("Purchase_Details").Rows.Add(r)

            Quantity.Value = 0
            Price.Value = 0
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            Calc_Total_Items()
            CalculateTotalBill()

            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Qty")

            DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
            Quantity.Focus()
            Quantity.Select(0, 1000)
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
    Private Sub AddButtons()
        Try
            TabAllItems.TabPages.Clear()
            cls.RefreshData("Categories", " Category_Name ")
            For i As Integer = 0 To MyDs.Tables("Categories").Rows.Count - 1
                Dim TP As New TabPage
                Dim FC As New FlowLayoutPanel
                TP.Controls.Add(FC)
                FC.Dock = DockStyle.Fill

                TP.Text = MyDs.Tables("Categories").Rows(i).Item("Category_Name")
                FC.AutoScroll = True
                Vu.RowFilter = "Category_ID = " & MyDs.Tables("Categories").Rows(i).Item("Category_ID")
                Vu.Sort = " Item_Name "

                For x As Integer = 0 To Vu.Count - 1
                    Dim b As New Button
                    b.Size = p
                    b.Font = fnt
                    b.Text = Vu.Item(x).Item("Item_Name")
                    b.Tag = Vu.Item(x).Item("Item_ID")
                    b.Name = "Btn" & Vu.Item(x).Item("Item_ID")
                    AddHandler b.Click, AddressOf AddItem
                    FC.Controls.Add(b)
                Next

                TabAllItems.TabPages.Add(TP)
            Next

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub
    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = MyDs.Tables("Purchase_details").Compute("sum(total_item)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                End If
                If DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("⁄›Ê ·« Ì„ﬂ‰ «⁄ÿ«¡ Œ’„ 100%")
                        DiscountValue.Focus()
                        Exit Sub
                    Else
                        TotalDiscount = (TotalTemp * DiscountValue.Value) / 100

                    End If

                ElseIf DiscountType.Text = "·« ÌÊÃœ" Then
                    TotalDiscount = 0
                Else
                    TotalDiscount = DiscountValue.Value
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("⁄›Ê «·Œ’„ ·« Ì„ﬂ‰ «‰ Ì ”«ÊÏ «Ê Ì“Ìœ ⁄‰ «Ã„«·Ï «·›« Ê—Â")
                        DiscountValue.Focus()
                        Exit Sub
                    End If
                End If
                TotalBill.Text = TotalTemp - TotalDiscount
                RemainingValue.Text = PayedValue.Value - CDbl(TotalBill.Text)

            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalcPayType()
        If B_EndLoad = True Then
            Select Case DiscountType.Text
                Case "„»·€ À«» "
                    DTemp = DiscountValue.Value
                Case "‰”»… „∆ÊÌ…"
                    DTemp = DiscountValue.Value * CDbl(TotalBill.Text)
                Case "·« ÌÊÃœ"
                    DTemp = 0
            End Select

            Select Case PayType.Text


                Case "‰ﬁœÌ"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "«Ã·"
                    CreditValue.Value = TotalBill.Text '- DTemp
                    CashValue.Value = 0
                    CashValue.Enabled = False
                    CreditValue.Enabled = True
                Case "»‘Ìﬂ"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "‰ﬁœÌ Ê «Ã·"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
                Case "‘Ìﬂ Ê «Ã·"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
            End Select
        End If

    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        MyDs.Tables("Purchase_Header").Rows.Clear()
        MyDs.Tables("Purchase_Details").Rows.Clear()
        If IsNew = False Then
            BillID.Text = 0
            CashValue.Value = 0
            CreditValue.Value = 0
            BtnNew.Enabled = True
            BtnSave.Enabled = False
            BtnDelete.Enabled = False
            BtnExit.Enabled = True
            B_Edited = False
            BtnSavePrint.Enabled = False
            BillDate.Text = Now
            BillTime.Text = ""
            TotalBill.Text = 0
            DiscountValue.Value = 0
            DiscountType.Text = "·« ÌÊÃœ"
            EmployeeID.Text = EmpNameVar
            EmployeeID.Tag = EmpIDVar
            PayType.Text = "‰ﬁœÌ"
            CashValue.Value = 0
            CreditValue.Value = 0
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = False
            TabAllItems.Enabled = False
            GroupItems.Enabled = False
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            TotalTemp = 0
            B_EndLoad = False
        Else
            TabAllItems.Controls.Clear()
            VendorID.Enabled = True
            BtnNewVendor.Enabled = True
            CashValue.Value = 0
            CreditValue.Value = 0
            BtnNew.Enabled = False
            BtnSave.Enabled = True
            BtnDelete.Enabled = True
            BtnExit.Enabled = True
            B_Edited = False
            BtnSavePrint.Enabled = True
            BillDate.Text = Now
            BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
            TotalBill.Text = 0
            DiscountValue.Value = 0
            DiscountType.Text = "·« ÌÊÃœ"
            EmployeeID.Text = EmpNameVar
            EmployeeID.Tag = EmpIDVar
            PayType.Text = "‰ﬁœÌ"
            CashValue.Value = 0
            CreditValue.Value = 0
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = True
            TabAllItems.Enabled = True
            GroupItems.Enabled = True
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            TotalTemp = 0
            '-------------------------------------
            PayedValue.Value = 0
            RemainingValue.Text = 0
            '-------------------------------------
            'If ProjectSettings.SrchNameOnPONrml = True Then
            '    RadioItemName.Checked = True
            '    ItemName.Focus()
            'Else
            '    RadioBarcode.Checked = True
            '    BarCode.Focus()
            'End If
            B_EndLoad = True

        End If
    End Sub

    Sub DiscountChangeTypes(ByVal IsGeneralDiscount As Boolean)
        If B_EndLoad = True Then
            If IsGeneralDiscount = True Then
                If DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    DiscountValue.Enabled = True
                    DiscountValue.Value = 0
                    DiscountValue.Maximum = 100
                ElseIf DiscountType.Text = "„»·€ À«» " Then
                    DiscountValue.Enabled = True
                    DiscountValue.Maximum = 1000000
                    DiscountValue.Value = 0
                Else
                    DiscountValue.Enabled = False
                    DiscountValue.Maximum = 0
                    DiscountValue.Value = 0
                End If
                Calc_Total_Items()
                CalculateTotalBill()
                CalcPayType()
            Else

            End If
        End If
    End Sub

    Sub Commit_Form()
        Try
            CalculateTotalBill()

            cmd.CommandText = "select count(*) from purchase_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("—ﬁ„ «·›« Ê—… „” Œœ„ „”»ﬁ« √⁄œ ÷»ÿ «⁄œ«œ«  «·‰Ÿ«„")
                Exit Sub
            End If

            If PayType.Text = "‰ﬁœÌ" Then
                PayedValue.Value = 0
                CashValue.Value = 0
                CashValue.Value = TotalBill.Text
                PayedValue.Value = TotalBill.Text
            End If


            If (PayType.Text = "‰ﬁœÌ Ê «Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
                cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
            ElseIf PayType.Text = "‰ﬁœÌ" And CashValue.Value = 0 Then
                cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
            ElseIf PayType.Text = "«Ã·" And (CreditValue.Value = 0 Or PayedValue.Value <> 0) Then
                cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
            ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
                cls.MsgExclamation("ÌÃ» «‰   ”«ÊÌ ﬁÌ„… «·„œ›Ê⁄ „⁄ «Ã„«·Ì «·›« Ê—…")
            ElseIf VendorID.Text = "" Then
                cls.MsgExclamation("«Œ — «”„ «·⁄„Ì·")
            ElseIf PayType.Text = "" Then
                cls.MsgExclamation("«Œ — ÿ—Ìﬁ… «·œ›⁄")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")

            Else
                B_ID = BillID.Text
                Calc_Total_Items()
                CalculateTotalBill()

                ''''''''''''''''''''''''''''''''''''''''
                If PayType.Text = "«Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·" Or PayType.Text = "‰ﬁœÌ Ê «Ã·" Then
                    If MyDs.Tables("Ven_Sch_Payments").Compute("Count(Payment_Value)", "bill_id>0") > 0 Then
                        If MyDs.Tables("Ven_Sch_Payments").Compute("Sum(Payment_Value)", "bill_id>0") <> CreditValue.Value Then
                            cls.MsgExclamation("·„ Ì „ ÃœÊ·… „Ê«⁄Ìœ «·”œ«œ")
                            Exit Sub
                        End If
                    Else
                        cls.MsgExclamation("·„ Ì „ ÃœÊ·… „Ê«⁄Ìœ «·”œ«œ")
                        Exit Sub
                    End If
                End If




                If DiscountType.Text = "„»·€ À«» " Then
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("⁄›Ê «·Œ’„ ·« Ì„ﬂ‰ «‰ Ì ”«ÊÏ «Ê Ì“Ìœ ⁄‰ «Ã„«·Ï «·›« Ê—Â")
                        DiscountValue.Focus()
                        Exit Sub
                    End If

                ElseIf DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("⁄›Ê ·« Ì„ﬂ‰ «⁄ÿ«¡ Œ’„ 100%")
                        DiscountValue.Focus()
                        Exit Sub

                    End If

                End If


                ''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Purchase_Order_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & VendorID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmpIDVar & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.SelectedValue & "," & CurrentShiftID
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1


                    'cmd.CommandText = "Exec Commit_Purchase_Order_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    '"," & StockID.SelectedValue & "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    '"N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value
                    'cmd.ExecuteNonQuery()

                    cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE + " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.SelectedValue
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO Purchase_DETAILS(BILL_ID,ITEM_ID,QUANTITY,PRICE,DISCOUNT_TYPE,DISCOUNT_VALUE,Total_Item) VALUES (" & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & ")"
                    cmd.ExecuteNonQuery()

                    cls.Commit_Inv_Tran(BillID.Text, BDate, TotalBill.Text, DataGridView1.Rows(i).Cells("Item_ID").Value, DataGridView1.Rows(i).Cells("Quantity").Value, "›« Ê—… „‘ —Ì« ", StockID.SelectedValue)

                Next

                If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
                    For x As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
                        d = MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Date")
                        cmd.CommandText = "exec Vendor_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("bill_ID") & " , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Value")
                        cmd.ExecuteNonQuery()
                    Next
                End If


                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                End If
                B_Edited = False
                Call ResetOrder(False)
                TabAllItems.Enabled = False
                DataGridView1.Enabled = False
                GroupItems.Enabled = False
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

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

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click
        Try

            If CurrentShiftID = 0 Then
                cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ…")
                Exit Sub
            End If

            DataGridView1.Enabled = True
            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            DiscountValue.Enabled = False
            CreditValue.Enabled = False
            MyDs.Tables("Purchase_Details").Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            TabAllItems.Enabled = True
            DataGridView1.Enabled = True
            GroupItems.Enabled = True
            StockID.SelectedValue = MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Stk_ID")
            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Qty")

            DiscountValueItem.Value = 0
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            Price.Value = 0
            Quantity.Value = 0

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click
        Commit_Form()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuDelete.Click
        If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            MyDs.Tables("Purchase_Header").Rows.Clear()
            MyDs.Tables("Purchase_Details").Rows.Clear()
            DataGridView1.Enabled = False
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                TabAllItems.Enabled = False
                DataGridView1.Enabled = False
                GroupItems.Enabled = False
                cls.MsgInfo(" „ Õ–› «·›« Ê—… »‰Ã«Õ")
            End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
   

    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                TotalBill.Text = 0
                'TotalTemp.Text = 0
            Else
                Calc_Total_Items()
                CalculateTotalBill()
                CalcPayType()
            End If
        End If

    End Sub

    Private Sub DiscountValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountValue.Leave
        If DataGridView1.Rows.Count > 0 Then
            Calc_Total_Items()
            CalculateTotalBill()
        End If

    End Sub

    Private Sub DiscountType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountType.SelectedIndexChanged
        DiscountChangeTypes(True)
    End Sub

    Private Sub PayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayType.SelectedIndexChanged
        CalcPayType()

    End Sub



    Private Sub VendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorID.SelectedIndexChanged
        Try
            cls.RefreshData("select * from query_items_stocks where item_id in(select item_id from items_Vendors where vendor_id=" & VendorID.SelectedValue & ")", TblQStocks)
            AddButtons()
        Catch
        End Try
    End Sub

 

    Private Sub DoClick(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            If CType(sender, Button).Text <> "" Then
                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & CType(sender, Button).Text & "' , 'None' , " & StockID.SelectedValue & ")"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                Else
                    cmd.CommandText = "select Purchase_price,Barcode from items where item_id = " & CType(sender, Button).Tag
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        Price.Value = dr("Purchase_Price")
                        BarCde = dr("Barcode")
                    Loop
                    dr.Close()
                    ItmName = CType(sender, Button).Text
                    ItmID = CType(sender, Button).Tag
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub PurchaseOrderNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from  Stocks", tbl1)
            cls.RefreshData(" select * from Vendors", tbl2)

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"


            VendorID.DataSource = tbl2
            VendorID.DisplayMember = "Vendor_Name"
            VendorID.ValueMember = "Vendor_ID"

            StockID.DataSource = tbl1
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"



            DataGridView1.DataSource = MyDs.Tables("Purchase_Details")
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "«”„ «·’‰›"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "«·»«—ﬂÊœ"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).HeaderText = "«·⁄œœ"
            DataGridView1.Columns(6).HeaderText = "”⁄— «·ÊÕœ…"
            DataGridView1.Columns(7).HeaderText = "‰Ê⁄ «·Œ’„"
            DataGridView1.Columns(7).ReadOnly = True
            DataGridView1.Columns(8).HeaderText = "ﬁÌ„… «·Œ’„ ⁄‰ «·’‰› «·Ê«Õœ"
            DataGridView1.Columns(8).ReadOnly = True
            DataGridView1.Columns(9).HeaderText = "«Ã„«·Ì «·’‰›"
            DataGridView1.Columns(9).ReadOnly = True

            MyDs.Tables("Purchase_Details").Rows.Clear()
            MyDs.Tables("Purchase_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 1
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"




        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("Calc.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewVendor.Click
        IsVendorAdded = False
        Dim m As New Vendors
        m.ShowDialog()
    End Sub


    Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        DiscountChangeTypes(False)
    End Sub

    Private Sub BtnSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSchedule.Click
        Try
            Dim m As New VenPaymentSchedule
            If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
                For i As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
                    Select Case i
                        Case 0
                            m.FirstDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckFirstPayment.Checked = True
                            m.FirstPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 1
                            m.SecondDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckSecondPayment.Checked = True
                            m.SecondPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 2
                            m.ThirdDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckThirdPayment.Checked = True
                            m.ThirdPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 3
                            m.ForthDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckForthPayment.Checked = True
                            m.ForthPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 4
                            m.FifthDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckFifthPayment.Checked = True
                            m.FifthPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
                    End Select

                Next
            End If

            m.billID = BillID.Text
            m.TotalPayments.Text = CreditValue.Value
            m.ShowDialog()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click, SAvePrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Commit_Form()
            MyDs.Tables("Report_Purchase_Order").Rows.Clear()
            cmd.CommandText = "select * from Report_Purchase_Order where bill_id = " & B_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Purchase_Order"))
            RptPur.SetDataSource(MyDs.Tables("Report_Purchase_Order"))
            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = RptPur
            m.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub PayedValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayedValue.Validated
        Calc_Total_Items()
        CalculateTotalBill()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If GroupHeader.Tag = 1 Then
            GroupHeader.Tag = 0
            GroupHeader.Visible = False
            ToolStripButton1.Text = "«ŸÂ«— «·‘Ìﬂ"
        Else
            GroupHeader.Tag = 1
            GroupHeader.Visible = True
            ToolStripButton1.Text = "«Œ›«¡ «·‘Ìﬂ"
        End If
    End Sub


    Private Sub DataGridView1_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        StockID.Enabled = False
    End Sub

    Private Sub DataGridView1_RowsRemoved_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If DataGridView1.Rows.Count = 0 Then
            StockID.Enabled = True
        End If
    End Sub

    Private Sub Quantity_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            DataGridView1.SelectedRows(0).Cells("quantity").Value = Quantity.Value
            Calc_Total_Items()
            CalculateTotalBill()
        End If
    End Sub

    Private Sub Price_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Price.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Price.Value <= 0 Then
                cls.MsgExclamation("⁄›Ê« ”⁄— «·’‰› ·« Ì„ﬂ‰ «‰ Ì”«ÊÌ ’›—«")
                Exit Sub
            End If
            DataGridView1.SelectedRows(0).Cells("price").Value = Price.Value
            Calc_Total_Items()
            CalculateTotalBill()
        End If
    End Sub

    Private Sub DiscountValueItem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DiscountValueItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DiscountTypeItem.Text = "" Then
                cls.MsgExclamation("»—Ã«¡ «Œ Ì«— ‰Ê⁄ «·Œ’„")
                Exit Sub
            End If

            If DiscountValueItem.Value <= 0 And DiscountTypeItem.Text <> "·« ÌÊÃœ" Then
                cls.MsgExclamation("⁄›Ê« ·« Ì„ﬂ‰ ··Œ’„ «‰ ÌﬂÊ‰ „”«ÊÌ ·’›— ")
                Exit Sub
            End If

            Try
                If DiscountTypeItem.Text = "·« ÌÊÃœ" Then

                    DataGridView1.SelectedRows(0).Cells("discount_Type").Value = DiscountTypeItem.Text
                    DataGridView1.SelectedRows(0).Cells("discount_value").Value = 0
                    DataGridView1.SelectedRows(0).Cells("total_item").Value = DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("Quantity").Value

                ElseIf DiscountTypeItem.Text = "‰”»… „∆ÊÌ…" Then
                    If DiscountValueItem.Value >= 100 Then
                        cls.MsgExclamation("⁄›Ê« ·« Ì„ﬂ‰ ··Œ’„ «‰ ÌﬂÊ‰ 100 " & "%")
                        Exit Sub
                    End If

                    DataGridView1.SelectedRows(0).Cells("discount_Type").Value = DiscountTypeItem.Text
                    DataGridView1.SelectedRows(0).Cells("discount_value").Value = DiscountValueItem.Value
                    DataGridView1.SelectedRows(0).Cells("total_item").Value = DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value - (DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value * DiscountValueItem.Value / 100)
                Else

                    If DiscountValueItem.Value >= DataGridView1.SelectedRows(0).Cells(6).Value Then
                        cls.MsgExclamation("⁄›Ê« ·« Ì„ﬂ‰ ··Œ’„ «‰ ÌﬂÊ‰ „”«ÊÌ ·”⁄— «·’‰› ")
                        Exit Sub
                    End If

                    DataGridView1.SelectedRows(0).Cells("discount_Type").Value = DiscountTypeItem.Text
                    DataGridView1.SelectedRows(0).Cells("discount_value").Value = DiscountValueItem.Value
                    DataGridView1.SelectedRows(0).Cells("total_item").Value = (DataGridView1.SelectedRows(0).Cells("Price").Value - DataGridView1.SelectedRows(0).Cells("Discount_Value").Value) * DataGridView1.SelectedRows(0).Cells("quantity").Value
                End If

            Catch
                cls.MsgExclamation("»—Ã«¡ «Œ Ì«— «·’‰› ")
            End Try

            Calc_Total_Items()
            CalculateTotalBill()
        End If
    End Sub


    Private Sub Calc_Total_Items()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells("discount_Type").Value = "·« ÌÊÃœ" Then
                DataGridView1.Rows(i).Cells("total_item").Value = DataGridView1.Rows(i).Cells("Price").Value * DataGridView1.Rows(i).Cells("quantity").Value
            ElseIf DataGridView1.SelectedRows(0).Cells("discount_Type").Value = "‰”»… „∆ÊÌ…" Then
                DataGridView1.SelectedRows(0).Cells("total_item").Value = DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value - (DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value * DiscountValueItem.Value / 100)
            Else
                DataGridView1.Rows(i).Cells("total_item").Value = (DataGridView1.Rows(i).Cells("Price").Value - DataGridView1.Rows(i).Cells("Discount_Value").Value) * DataGridView1.Rows(i).Cells("quantity").Value
            End If
        Next


    End Sub

End Class