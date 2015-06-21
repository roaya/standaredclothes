Public Class PurchaseOrderNormal

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
    Dim tblPurchase As New GeneralDataSet.Purchase_DetailsDataTable

#Region "Order_Subs"

    Sub AddItem()
        Try
            If Quantity.Value = 0 Then
                cls.MsgExclamation("«œŒ· «·⁄œœ")
            ElseIf DiscountTypeItem.Text <> "·« ÌÊÃœ" And DiscountValueItem.Value = 0 Then
                cls.MsgExclamation("«œŒ· ‰”»… «·Œ’„ ··’‰› «·„Õœœ")
            ElseIf Price.Value = 0 Then
                cls.MsgExclamation("«œŒ· ”⁄— «·ÊÕœ…")
            Else
                For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                    If tblPurchase.Rows(xx).Item("Item_ID") = ItmID Then
                        tblPurchase.Rows(xx).Item("Quantity") = tblPurchase.Rows(xx).Item("Quantity") + Quantity.Value
                        tblPurchase.Rows(xx).Item("Total_Item") = tblPurchase.Rows(xx).Item("Quantity") * tblPurchase.Rows(xx).Item("Price")
                        Select Case tblPurchase.Rows(xx).Item("Discount_Type")
                            Case "„»·€ À«» "
                                ItmPrc = tblPurchase.Rows(xx).Item("Price") - tblPurchase.Rows(xx).Item("Discount_Value")
                            Case "‰”»… „∆ÊÌ…"
                                ItmPrc = (tblPurchase.Rows(xx).Item("Price") - (tblPurchase.Rows(xx).Item("Price") * (tblPurchase.Rows(xx).Item("Discount_Value") / 100)))
                            Case "·« ÌÊÃœ"
                                ItmPrc = Price.Value
                        End Select
                        tblPurchase.Rows(xx).Item("Price") = Price.Value
                        tblPurchase.Rows(xx).Item("Total_Item") = ItmPrc * tblPurchase.Rows(xx).Item("Quantity")

                        If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "«·«”„" Then
                            RadioItemName.Checked = True
                            ItemName.Focus()
                        Else
                            RadioBarcode.Checked = True
                            BarCode.Focus()
                        End If

                        Quantity.Value = 0
                        Price.Value = 0
                        DiscountTypeItem.Text = "·« ÌÊÃœ"

                        CalculateTotalBill()

                        Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
                        BarCode.Text = ""

                        Select Case PayType.Text
                            Case "‰ﬁœÌ"
                                CashValue.Value = TotalBill.Text
                            Case "«Ã·"
                                CreditValue.Value = TotalBill.Text
                            Case "»‘Ìﬂ"
                                CashValue.Value = TotalBill.Text
                        End Select

                        Exit Sub
                    End If
                Next
                VendorID.Enabled = False
                BtnNewVendor.Enabled = False
                r = tblPurchase.NewRow
                r("Bill_ID") = BillID.Text
                r("Item_Name") = ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("Quantity") = Quantity.Value
                r("Discount_Type") = DiscountTypeItem.Text
                r("Discount_Value") = DiscountValueItem.Value

                Select Case DiscountTypeItem.Text
                    Case "„»·€ À«» "
                        If DiscountValueItem.Value >= Price.Value Then
                            cls.MsgExclamation("⁄›Ê «·Œ’„ ·« Ì„ﬂ‰ «‰ Ì ”«ÊÏ «Ê Ì“Ìœ ⁄‰ ”⁄— «·’‰›")
                            DiscountValueItem.Focus()

                            Exit Sub
                        Else
                            ItmPrc = Price.Value - DiscountValueItem.Value
                        End If
                    Case "‰”»… „∆ÊÌ…"
                        If DiscountValueItem.Value = 100 Then
                            cls.MsgExclamation("⁄›Ê ·« Ì„ﬂ‰ «⁄ÿ«¡ Œ’„ 100%")
                            DiscountValueItem.Focus()


                            Exit Sub
                        Else
                            ItmPrc = (Price.Value - (Price.Value * (DiscountValueItem.Value / 100)))
                        End If
                    Case "·« ÌÊÃœ"
                        ItmPrc = Price.Value
                End Select
                r("Price") = Price.Value
                r("Total_Item") = ItmPrc * Quantity.Value
                tblPurchase.Rows.Add(r)

                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "«·«”„" Then
                    RadioItemName.Checked = True
                    ItemName.Focus()
                Else
                    RadioBarcode.Checked = True
                    BarCode.Focus()
                End If

                Quantity.Value = 0
                Price.Value = 0
                DiscountTypeItem.Text = "·« ÌÊÃœ"

                CalculateTotalBill()

                Quantity.Value = 0 'MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
                BarCode.Text = ""

                Select Case PayType.Text
                    Case "‰ﬁœÌ"
                        CashValue.Value = TotalBill.Text
                    Case "«Ã·"
                        CreditValue.Value = TotalBill.Text
                    Case "»‘Ìﬂ"
                        CashValue.Value = TotalBill.Text
                End Select
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = tblPurchase.Compute("sum(total_item)", "bill_id=" & BillID.Text)
                    CountRecords.Text = tblPurchase.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                    CountRecords.Text = 0
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
        tblPurchase.Rows.Clear()
        MyDs.Tables("Ven_Sch_Payments").Rows.Clear()
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
            GroupDetails.Enabled = False
            GroupItems.Enabled = False
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            DiscountValueItem.Value = 0
            DiscountValueItem.Enabled = False
            TotalTemp = 0
            BarCode.Text = ""
            ItemName.Text = ""
            B_EndLoad = False
        Else
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
            GroupDetails.Enabled = True
            GroupItems.Enabled = True
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            DiscountValueItem.Value = 0
            DiscountValueItem.Enabled = False
            TotalTemp = 0
            '-------------------------------------
            PayedValue.Value = 0
            RemainingValue.Text = 0
            '-------------------------------------
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
                CalculateTotalBill()
                CalcPayType()
            Else

                If DiscountTypeItem.Text = "‰”»… „∆ÊÌ…" Then
                    DiscountValueItem.Enabled = True
                    DiscountValueItem.Value = 0
                    DiscountValueItem.Maximum = 100
                ElseIf DiscountTypeItem.Text = "„»·€ À«» " Then
                    DiscountValueItem.Enabled = True
                    DiscountValueItem.Maximum = 1000000
                    DiscountValueItem.Value = 0
                Else
                    DiscountValueItem.Enabled = False
                    DiscountValueItem.Maximum = 0
                    DiscountValueItem.Value = 0
                End If

            End If
        End If
    End Sub

    Function CheckCredit() As Boolean
        If PayType.Text = "«Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·" Or PayType.Text = "‰ﬁœÌ Ê «Ã·" Then
            If MyDs.Tables("Ven_Sch_Payments").Compute("Sum(Payment_Value)", "Vendor_ID>0") <> CreditValue.Value Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Sub Commit_Form()
        cmd.CommandText = "select count(*) from purchase_header where bill_id = " & BillID.Text
        If cmd.ExecuteScalar > 0 Then
            cls.MsgExclamation("—ﬁ„ «·›« Ê—… „” Œœ„ „”»ﬁ« √⁄œ ÷»ÿ «⁄œ«œ«  «·‰Ÿ«„")
            Exit Sub
        End If

        If (PayType.Text = "‰ﬁœÌ Ê «Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
            cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
        ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
            cls.MsgExclamation("ÌÃ» «‰   ”«ÊÌ ﬁÌ„… «·„œ›Ê⁄ „⁄ «Ã„«·Ì «·›« Ê—…")

        ElseIf PayedValue.Value = 0 Then
            cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
        ElseIf PayedValue.Value < TotalBill.Text Then
            cls.MsgExclamation("ÌÃ» «‰ ·« Ìﬁ· «Ã„«·Ï «·„œ›Ê⁄ ⁄‰ «Ã„«·Ï «·›« Ê—Â")
        ElseIf VendorID.Text = "" Then
            cls.MsgExclamation("«Œ — «”„ «·„Ê—œ")
        ElseIf PayType.Text = "" Then
            cls.MsgExclamation("«Œ — ÿ—Ìﬁ… «·œ›⁄")
        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")
        Else
            Try
                B_ID = BillID.Text
                CalculateTotalBill()

                '---------------------------------------
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
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If


    End Sub
#End Region

    Private Sub PurchaseOrderNormal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If B_Edited = True Then

            Commit_Form()
        End If
    End Sub

    Private Sub PurchaseOrderNormal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            DiscountValue.Enabled = False
            CreditValue.Enabled = False
            tblPurchase.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            Fill_Items()
            B_Edited = True

            StockID.SelectedValue = MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Stk_ID")
            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Qty")
            If MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Sch") = "«·«”„" Then
                RadioItemName.Checked = True
                ItemName.Focus()
            Else
                RadioBarcode.Checked = True
                BarCode.Focus()
            End If
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
            tblPurchase.Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo(" „ Õ–› «·›« Ê—… »‰Ã«Õ")
            End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown, Price.KeyDown, DiscountTypeItem.KeyDown, DiscountValueItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddItem()
        End If

    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                TotalBill.Text = 0
                'TotalTemp.Text = 0
                CountRecords.Text = 0
            Else
                CalculateTotalBill()
                CalcPayType()
                CountRecords.Text = tblPurchase.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
            End If
        End If

    End Sub

    Private Sub DiscountValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountValue.Leave
        If DataGridView1.Rows.Count > 0 Then
            CalculateTotalBill()
        End If

    End Sub

    Private Sub DiscountType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountType.SelectedIndexChanged
        DiscountChangeTypes(True)
    End Sub

    Private Sub PayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayType.SelectedIndexChanged
        CalcPayType()

    End Sub

    Private Sub DataGridView1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Validated
        Try
            If DataGridView1.Rows.Count <> 0 Then
                Select Case DataGridView1.Rows(RowID).Cells("Discount_Type").Value
                    Case "„»·€ À«» "
                        DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value - DataGridView1.Rows(RowID).Cells("Discount_Value").Value
                    Case "‰”»… „∆ÊÌ…"
                        DataGridView1.Rows(RowID).Cells("Price").Value = (DataGridView1.Rows(RowID).Cells("Price").Value - (DataGridView1.Rows(RowID).Cells("Price").Value * (DataGridView1.Rows(RowID).Cells("Discount_Value").Value / 100)))
                    Case "·« ÌÊÃœ"
                        DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value
                End Select
                DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If ItemName.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.SelectedValue & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                    Else
                        cmd.CommandText = "select Purchase_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                        dr = cmd.ExecuteReader
                        Do While Not dr.Read = False
                            Price.Value = dr("Purchase_Price")
                            ItmName = ItemName.Text
                            BarCde = dr("Barcode")
                            ItmID = dr("Item_ID")
                        Loop
                        dr.Close()
                        Quantity.Value = 1
                        AddItem()
                    End If
                Else
                    cls.MsgExclamation("«œŒ· «”„ «·’‰›")
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If ItemName.Text <> "" Then
                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.SelectedValue & ")"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                    ItemName.Focus()
                    Exit Sub
                Else
                    cmd.CommandText = "select Purchase_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        Price.Value = dr("Purchase_Price")
                        ItmName = ItemName.Text
                        BarCde = dr("Barcode")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()

                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BarCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If BarCode.Text <> "" Then
                    Dim itemId As Object = chkItem(BarCode.Text)

                    If itemId <> Nothing Then
                        cmd.CommandText = "select Purchase_price,Item_ID,item_name from items where Item_ID = N'" & itemId & "'"
                        dr = cmd.ExecuteReader
                        Do While Not dr.Read = False
                            Price.Value = dr("Purchase_Price")
                            BarCde = BarCode.Text
                            ItmName = dr("Item_Name")
                            ItmID = dr("Item_ID")
                        Loop
                        dr.Close()
                        Quantity.Value = 1
                        AddItem()
                    End If
                Else
                    cls.MsgExclamation("«œŒ· ﬂÊœ «·’‰›")
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try
            If BarCode.Text <> "" Then
                Dim itemId As Object = chkItem(BarCode.Text)

                If itemId <> Nothing Then
                    cmd.CommandText = "select Purchase_price,Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"
                    dr = cmd.ExecuteReader

                    Do While Not dr.Read = False
                        Price.Value = dr("Purchase_Price")
                        BarCde = BarCode.Text
                        ItmName = dr("Item_Name")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                End If
            Else
                cls.MsgExclamation("«œŒ· ﬂÊœ «·’‰›")
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub VendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorID.SelectedIndexChanged
        Fill_Items()
    End Sub
    Private Sub Fill_Items()
        Try
            If B_EndLoad = True And IsVendorAdded = True Then
                cmd.CommandText = "select item_name from Query_Items_Vendors where vendor_id = " & VendorID.SelectedValue
                Dim items As New DataTable()
                da.SelectCommand = cmd
                da.Fill(items)
                ItemName.DataSource = items
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            BarCode.Enabled = False
            ItemName.Enabled = True
            ItemName.Text = ""
            BarCode.Text = ""
        End If
    End Sub

    Private Sub RadioBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBarcode.CheckedChanged
        If RadioBarcode.Checked = True Then
            BarCode.Enabled = True
            ItemName.Enabled = False
            ItemName.Text = ""
            BarCode.Text = ""
        End If
    End Sub


    Private Sub PurchaseOrderNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from Stocks", tbl1)
            cls.RefreshData("select * from Vendors", tbl2)

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.ComboBox.DataSource = B
            OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            VendorID.DataSource = tbl2
            VendorID.DisplayMember = "Vendor_Name"
            VendorID.ValueMember = "Vendor_ID"

            StockID.DataSource = tbl1
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"


            DataGridView1.DataSource = tblPurchase
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


            tblPurchase.Rows.Clear()
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

    Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountTypeItem.TextChanged
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

    Private Sub BtnSavePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click, SAvePrint.Click
        Try


            '==========================================================

            cmd.CommandText = "select count(*) from purchase_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("—ﬁ„ «·›« Ê—… „” Œœ„ „”»ﬁ« √⁄œ ÷»ÿ «⁄œ«œ«  «·‰Ÿ«„")
                Exit Sub
            End If

            If (PayType.Text = "‰ﬁœÌ Ê «Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
                cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
            ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
                cls.MsgExclamation("ÌÃ» «‰   ”«ÊÌ ﬁÌ„… «·„œ›Ê⁄ „⁄ «Ã„«·Ì «·›« Ê—…")


            ElseIf PayedValue.Value = 0 Then
                cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
            ElseIf PayedValue.Value < TotalBill.Text Then
                cls.MsgExclamation("ÌÃ» «‰ ·« Ìﬁ· «Ã„«·Ï «·„œ›Ê⁄ ⁄‰ «Ã„«·Ï «·›« Ê—Â")
            ElseIf VendorID.Text = "" Then
                cls.MsgExclamation("«Œ — «”„ «·„Ê—œ")
            ElseIf PayType.Text = "" Then
                cls.MsgExclamation("«Œ — ÿ—Ìﬁ… «·œ›⁄")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")
            Else

                B_ID = BillID.Text
                CalculateTotalBill()

                '---------------------------------------
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
                        Exit Sub
                        DiscountValue.Focus()
                    End If

                End If
                ''''''''''''''''''''''''''''''''''''''''

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



                    If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
                        For x As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
                            d = MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Date")
                            cmd.CommandText = "exec Vendor_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("bill_ID") & " , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Value")
                            cmd.ExecuteNonQuery()
                        Next
                    End If
                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
                End If
                B_Edited = False
                Call ResetOrder(False)

                Me.Cursor = Cursors.WaitCursor
                MyDs.Tables("Report_Purchase_Order").Rows.Clear()
                cmd.CommandText = "select * from Report_Purchase_Order where bill_id = " & B_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Purchase_Order"))
                RptPur.SetDataSource(MyDs.Tables("Report_Purchase_Order"))
                RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptPur
                m.ShowDialog()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

        '==========================================================



    End Sub

    Private Sub PayedValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayedValue.Validated
        CalculateTotalBill()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click, MenuTotal.Click
        PayedValue.Focus()
        PayedValue.Select(0, PayedValue.Text.Length)
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            If DataGridView1.Rows.Count <> 0 Then
                Select Case DataGridView1.Rows(RowID).Cells("Discount_Type").Value
                    Case "„»·€ À«» "
                        DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value - DataGridView1.Rows(RowID).Cells("Discount_Value").Value
                    Case "‰”»… „∆ÊÌ…"
                        DataGridView1.Rows(RowID).Cells("Price").Value = (DataGridView1.Rows(RowID).Cells("Price").Value - (DataGridView1.Rows(RowID).Cells("Price").Value * (DataGridView1.Rows(RowID).Cells("Discount_Value").Value / 100)))
                    Case "·« ÌÊÃœ"
                        DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value
                End Select
                DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
                CalculateTotalBill()

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub PayedValue_ValueChanged(sender As Object, e As EventArgs) Handles PayedValue.ValueChanged
        CalculateTotalBill()
    End Sub
    Private Function getItem(barcode As String) As Object
        cmd.CommandText = "select item_id from items where barcode = '" & barcode & "'"
        Dim itemid As Object = cmd.ExecuteScalar()
        If itemid <> Nothing Then
            Return itemid
        Else
            cmd.CommandText = "select bar_item_id from barcodes where bar_code = '" & barcode & "'"
            itemid = cmd.ExecuteScalar()
            If itemid <> Nothing Then
                Return itemid
            Else
                Return ""
            End If
        End If
    End Function

    Private Function chkItem(barcode As String) As Object
        Dim itemId As Object = Nothing
        itemId = getItem(barcode)
        If (itemId <> Nothing) Then
            cmd.CommandText = "select dbo.Is_Item_Attached(" & itemId & " , 'None' , 'None' , " & StockID.Tag & ")"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
            End If
            cmd.CommandText = "select dbo.Checked_Vendor_Items(" & VendorID.SelectedValue & "," & itemId & ",'Noue')"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgExclamation("Â–« «·’‰› €Ì— „— »ÿ »Â–« «·„Ê—œ")
            End If
        Else
            cls.MsgExclamation("Â–« «·ﬂÊœ €Ì— „”Ã·")
        End If
        Return itemId

    End Function
End Class
