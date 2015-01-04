Public Class SalesOrderFilter


    Dim TotalTemp, TotalDiscount As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Sales_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate As Date
    Dim d As Date
    Dim RptPur As New Report_Sales_Order
    Dim B_ID As Integer
    Dim RptChk As New RptSalBill
    Dim tbl1 As New GeneralDataSet.CustomersDataTable

#Region "Order_Subs"

    Sub SetDefaultFilter()
        Select Case ProjectSettings.SalFilterDefaultFilter
            Case SalFilterEnum.FilterCategoryID
                RadioCategoryID.Checked = True
            Case SalFilterEnum.FilterCorporationID
                RadioCorporationID.Checked = True
            Case SalFilterEnum.FilterGenderID
                RadioGenderID.Checked = True
            Case SalFilterEnum.FilterSizeID
                RadioSizeID.Checked = True
            Case SalFilterEnum.FilterTypeID
                RadioSizeID.Checked = True
            Case SalFilterEnum.FilterCustomerID
                RadioSeason.Checked = True
        End Select
    End Sub


    Sub AddItem()
        Try
            If Quantity.Value = 0 Then
                cls.MsgExclamation("«œŒ· «·⁄œœ")
            ElseIf DiscountTypeItem.Text <> "·« ÌÊÃœ" And DiscountValueItem.Value = 0 Then
                cls.MsgExclamation("«œŒ· ‰”»… «·Œ’„ ··’‰› «·„Õœœ")
            ElseIf Price.Value = 0 Then
                cls.MsgExclamation("«œŒ· ”⁄— «·ÊÕœ…")
            ElseIf OrderType.Text = "" Then
                cls.MsgExclamation("√œŒ· ‰Ê⁄ «·›« Ê—…")
            ElseIf CustomerID.Text = "" Then
                cls.MsgExclamation("«Œ — «”„ «·⁄„Ì·")

            Else
                For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                    If MyDs.Tables("Sales_details").Compute("Count(Item_ID)", "Item_id=" & ItmID) > 0 Then
                        cls.MsgExclamation("Â–« «·’‰› „ÊÃÊœ „”»ﬁ« ›Ì «·›« Ê—… «·Õ«·Ì…")
                        Exit Sub
                    End If
                Next
                CustomerID.Enabled = False
                BtnNewCustomer.Enabled = False
                r = MyDs.Tables("Sales_Details").NewRow
                r("Bill_ID") = BillID.Text
                r("Item_Name") = ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("Quantity") = Quantity.Value
                r("Discount_Type") = DiscountTypeItem.Text
                r("Discount_Value") = DiscountValueItem.Value

                Select Case DiscountTypeItem.Text
                    Case "„»·€ À«» "
                        ItmPrc = Price.Value - DiscountValueItem.Value
                    Case "‰”»… „∆ÊÌ…"
                        ItmPrc = (Price.Value - (Price.Value * (DiscountValueItem.Value / 100)))
                    Case "·« ÌÊÃœ"
                        ItmPrc = Price.Value
                End Select
                r("Price") = Price.Value
                r("Total_Item") = ItmPrc * Quantity.Value
                MyDs.Tables("Sales_Details").Rows.Add(r)

                Select Case MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Filter")
                    Case "«”„ «·»‰œ"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterCategoryID
                    Case ("«·„ﬁ«”")
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterSizeID
                    Case "«·‘—ﬂ…"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterCorporationID
                    Case "«·›∆…"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterTypeID
                    Case "«·⁄„Ì·"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterCustomerID
                    Case "«·‰Ê⁄"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterGenderID
                End Select

                SetDefaultFilter()
                Quantity.Value = 0
                Price.Value = 0
                DiscountTypeItem.Text = "·« ÌÊÃœ"
                CalculateTotalBill()

                Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = MyDs.Tables("Sales_details").Compute("sum(total_item)", "bill_id=" & BillID.Text)
                    CountRecords.Text = MyDs.Tables("Sales_details").Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                    CountRecords.Text = 0
                End If
                If DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    TotalDiscount = (TotalTemp * DiscountValue.Value) / 100
                ElseIf DiscountType.Text = "·« ÌÊÃœ" Then
                    TotalDiscount = 0
                Else
                    TotalDiscount = DiscountValue.Value
                End If
                TotalBill.Text = TotalTemp - (TotalDiscount + CDbl(CardValue.Text))
                RemainingValue.Text = PayedValue.Value - CDbl(TotalBill.Text)
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalcPayType()
        Try
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
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        Try
            MyDs.Tables("Sales_Header").Rows.Clear()
            MyDs.Tables("Sales_Details").Rows.Clear()
            PeriodID.Tag = MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Period_ID")
            cmd.CommandText = "select period_name from periods where period_id = " & MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Period_ID")
            PeriodID.Text = cmd.ExecuteScalar
            StockID.Tag = ProjectSettings.CurrentStockID
            StockID.Text = ProjectSettings.CurrentStockName
            CardID.Tag = 0
            If IsNew = False Then
                BillID.Text = 0
                CashValue.Value = 0
                CreditValue.Value = 0
                BtnNew.Enabled = True
                BtnSave.Enabled = False
                BtnDelete.Enabled = False
                BtnExit.Enabled = True
                B_Edited = False
                'BtnSavePrint.Enabled = False
                BillDate.Text = Now
                BillTime.Text = ""
                TotalBill.Text = 0
                DiscountValue.Value = 0
                DiscountType.Text = "·« ÌÊÃœ"
                'EmployeeID.Text = EmpNameVar
                'EmployeeID.Tag = EmpIDVar
                PayType.Text = "‰ﬁœÌ"
                CashValue.Value = 0
                CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = False
                'GroupDetails.Enabled = False
                'GroupItems.Enabled = False
                DiscountTypeItem.Text = "·« ÌÊÃœ"
                DiscountValueItem.Value = 0
                DiscountValueItem.Enabled = False
                TotalTemp = 0
                B_EndLoad = False
                CardValue.Text = 0
            Else
                CustomerID.Enabled = True
                BtnNewCustomer.Enabled = True
                CashValue.Value = 0
                CreditValue.Value = 0
                BtnNew.Enabled = False
                BtnSave.Enabled = True
                BtnDelete.Enabled = True
                BtnExit.Enabled = True
                B_Edited = False
                'BtnSavePrint.Enabled = True
                BillDate.Text = Now
                BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                TotalBill.Text = 0
                DiscountValue.Value = 0
                DiscountType.Text = "·« ÌÊÃœ"
                'EmployeeID.Text = EmpNameVar
                'EmployeeID.Tag = EmpIDVar
                PayType.Text = "‰ﬁœÌ"
                CashValue.Value = 0
                CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = True
                'GroupDetails.Enabled = True
                'GroupItems.Enabled = True
                DiscountTypeItem.Text = "·« ÌÊÃœ"
                DiscountValueItem.Value = 0
                DiscountValueItem.Enabled = False
                TotalTemp = 0
                B_EndLoad = True

                CardValue.Text = 0
                cls.LoadList("Card_Code", "Discount_Cards", CardID, " where Card_Status <> N'„‰ ÂÌ'")

                Select Case MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Filter")
                    Case "«”„ «·»‰œ"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterCategoryID
                    Case ("«·„ﬁ«”")
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterSizeID
                    Case "«·‘—ﬂ…"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterCorporationID
                    Case "«·›∆…"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterTypeID
                    Case "«·⁄„Ì·"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterCustomerID
                    Case "«·‰Ê⁄"
                        ProjectSettings.SalFilterDefaultFilter = SalFilterEnum.FilterGenderID
                End Select

                SetDefaultFilter()

                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Edit_Emp_ID") = True Then
                    EmployeeID.Enabled = True
                Else
                    EmployeeID.SelectedValue = EmpIDVar
                    EmployeeID.Enabled = False
                End If

                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Edit_Date") = True Then
                    BillDate.Enabled = True
                Else
                    BillDate.Text = Now
                    BillDate.Enabled = False
                End If

                '-------------------------------------
                PayedValue.Value = 0
                RemainingValue.Text = 0
                '-------------------------------------

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub DiscountChangeTypes(ByVal IsGeneralDiscount As Boolean)
        Try
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
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub Commit_Form()

        cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
        If cmd.ExecuteScalar > 0 Then
            cls.MsgExclamation("—ﬁ„ «·›« Ê—… „” Œœ„ „”»ﬁ« √⁄œ ÷»ÿ «⁄œ«œ«  «·‰Ÿ«„")
            Exit Sub
        End If

        If (PayType.Text = "‰ﬁœÌ Ê «Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
            cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
        ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
            cls.MsgExclamation("ÌÃ» «‰   ”«ÊÌ ﬁÌ„… «·„œ›Ê⁄ „⁄ «Ã„«·Ì «·›« Ê—…")
        ElseIf CustomerID.Text = "" Then
            cls.MsgExclamation("«Œ — «”„ «·„Ê—œ")
        ElseIf PayType.Text = "" Then
            cls.MsgExclamation("«Œ — ÿ—Ìﬁ… «·œ›⁄")
        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")

        Else
            Try
                B_ID = BillID.Text
                CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & StockID.Tag & ")"
                    If cmd.ExecuteScalar = 1 Then
                        cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…")
                        Exit Sub
                    End If
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''
                If CreditValue.Value > 0 Then
                    cmd.CommandText = "SELECT DBO.Check_Credit_Limit(" & CustomerID.SelectedValue & "," & CreditValue.Value & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgCritical("·ﬁœ  ŒÿÌ Â–« «·⁄„Ì· Õ«Ã“ «·Õœ «·√ﬁ’Ì ··¬Ã·")
                        Exit Sub
                    End If
                End If

                If DiscountType.Text = "„»·€ À«» " Then
                    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",1)"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgCritical("·ﬁœ  ŒÿÌ Â–« «·⁄„Ì· «·Õœ «·√ﬁ’Ì ·‰”»… «·Œ’„")
                        Exit Sub
                    End If
                ElseIf DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",2)"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgCritical("·ﬁœ  ŒÿÌ Â–« «·⁄„Ì· «·Õœ «·√ﬁ’Ì ·‰”»… «·Œ’„")
                        Exit Sub
                    End If
                End If

                If MyDs.Tables("Sch_Payments").Rows.Count > 0 Then
                    For x As Integer = 0 To MyDs.Tables("Sch_Payments").Rows.Count - 1
                        d = MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Date")
                        cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Customer_ID") & " , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Value")
                        cmd.ExecuteNonQuery()
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Sales_Order_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmpIDVar & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.Tag & "," & PeriodID.Tag & ", N'" & OrderType.Text & "' , " & CardID.Tag
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

                    'cmd.CommandText = "Exec Commit_Sales_Order_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    '"," & StockID.Tag & "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    '"N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value
                    'cmd.ExecuteNonQuery()

                    cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE - " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.Tag
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO SALES_DETAILS(BILL_ID,ITEM_ID,QUANTITY,PRICE,DISCOUNT_TYPE,DISCOUNT_VALUE,Total_Item) VALUES (" & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & ")"
                    cmd.ExecuteNonQuery()

                Next
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

    Private Sub SalesOrderNormal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If B_Edited = True Then

            Commit_Form()
        End If
    End Sub

    Private Sub SalesOrderNormal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("ÌÃ» Õ›Ÿ «·›« Ê—… «Ê Õ–›Â« «Ê·«")
        End If

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            'EmployeeID.Tag = EmpIDVar
            'EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            DiscountValue.Enabled = False
            CreditValue.Enabled = False
            MyDs.Tables("Sales_Details").Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            OrderType.Text = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Ord_Type")

            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Commit_Form()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            MyDs.Tables("Sales_Header").Rows.Clear()
            MyDs.Tables("Sales_Details").Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo(" „ Õ–› «·›« Ê—… »‰Ã«Õ")
            End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown, Price.KeyDown
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
                CountRecords.Text = 0
            Else
                CalculateTotalBill()
                CalcPayType()
                CountRecords.Text = MyDs.Tables("Sales_details").Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
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
    End Sub

    Private Sub SalesOrderNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select* from customers", tbl1)
            cls.RefreshData("Employees")

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.ComboBox.DataSource = B
            OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            CustomerID.DataSource = tbl1
            CustomerID.DisplayMember = "Customer_Name"
            CustomerID.ValueMember = "Customer_ID"

            DataGridView1.DataSource = MyDs.Tables("Sales_Details")
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


            MyDs.Tables("Sales_Details").Rows.Clear()
            MyDs.Tables("Sales_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 2
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IsCustomerAdded = False
        Dim m As New Customers
        m.ShowDialog()
    End Sub


    Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountTypeItem.TextChanged
        DiscountChangeTypes(False)
    End Sub

    Private Sub CardID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardID.SelectedIndexChanged
        If B_EndLoad = True Then
            Try
                cmd.CommandText = "select Card_ID , card_value from Discount_Cards where card_code = N'" & CardID.Text & "'"
                dr = cmd.ExecuteReader
                If Not dr.Read = False Then
                    CardValue.Text = dr("Card_Value")
                    CardID.Tag = dr("Card_ID")
                End If
                dr.Close()
                CalculateTotalBill()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub RadioCategoryID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCategoryID.CheckedChanged
        If RadioCategoryID.Checked = True Then
            Try
                ComboCategoryID.Enabled = True
                ComboCorporationID.Enabled = False
                ComboGenderID.Enabled = False
                ComboSizeID.Enabled = False
                ComboTypeID.Enabled = False
                ComboSeason.Enabled = False
                ComboCategoryID.Items.Clear()
                cmd.CommandText = "select category_name from categories"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    ComboCategoryID.Items.Add(dr("Category_Name"))
                Loop
                dr.Close()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub


    Private Sub RadioSizeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSizeID.CheckedChanged
        If RadioSizeID.Checked = True Then
            Try
                ComboCategoryID.Enabled = False
                ComboCorporationID.Enabled = False
                ComboGenderID.Enabled = False
                ComboSizeID.Enabled = True
                ComboTypeID.Enabled = False
                ComboSeason.Enabled = False
                ComboSizeID.Items.Clear()
                cmd.CommandText = "select size_name from Item_Sizes"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    ComboSizeID.Items.Add(dr("size_Name"))
                Loop
                dr.Close()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub RadioCorporationID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCorporationID.CheckedChanged
        If RadioCorporationID.Checked = True Then
            Try
                ComboCategoryID.Enabled = False
                ComboCorporationID.Enabled = True
                ComboGenderID.Enabled = False
                ComboSizeID.Enabled = False
                ComboTypeID.Enabled = False
                ComboSeason.Enabled = False
                ComboCorporationID.Items.Clear()
                cmd.CommandText = "select corporation_name from corporations"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    ComboCorporationID.Items.Add(dr("corporation_Name"))
                Loop
                dr.Close()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub RadioTypeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTypeID.CheckedChanged
        If RadioTypeID.Checked = True Then
            Try
                ComboCategoryID.Enabled = False
                ComboCorporationID.Enabled = False
                ComboGenderID.Enabled = False
                ComboSizeID.Enabled = False
                ComboTypeID.Enabled = True
                ComboSeason.Enabled = False
                ComboTypeID.Items.Clear()
                cmd.CommandText = "select type_name from Items_Types"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    ComboTypeID.Items.Add(dr("type_name"))
                Loop
                dr.Close()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub RadioCustomerID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSeason.CheckedChanged
        If RadioSeason.Checked = True Then
            ComboCategoryID.Enabled = False
            ComboCorporationID.Enabled = False
            ComboGenderID.Enabled = False
            ComboSizeID.Enabled = False
            ComboTypeID.Enabled = False
            ComboSeason.Enabled = True
            'ComboSeason.Items.Clear()
            'cmd.CommandText = "select Customer_name from Customers"
            'dr = cmd.ExecuteReader
            'Do While Not dr.Read = False
            '    ComboSeason.Items.Add(dr("Customer_name"))
            'Loop
            'dr.Close()
        End If
    End Sub

    Private Sub RadioGenderID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGenderID.CheckedChanged
        If RadioGenderID.Checked = True Then
            Try
                ComboCategoryID.Enabled = False
                ComboCorporationID.Enabled = False
                ComboGenderID.Enabled = True
                ComboSizeID.Enabled = False
                ComboTypeID.Enabled = False
                ComboSeason.Enabled = False
                ComboGenderID.Items.Clear()
                cmd.CommandText = "select gender_name from gender"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    ComboGenderID.Items.Add(dr("gender_name"))
                Loop
                dr.Close()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub ComboCategoryID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCategoryID.Leave
        If ComboCategoryID.Text <> "" Then
            Try
                LstItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from Query_All_Items where category_name = N'" & ComboCategoryID.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    LstItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub ComboCorporationID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCorporationID.Leave
        Try
            If ComboCorporationID.Text <> "" Then
                LstItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from Query_All_Items where corporation_name = N'" & ComboCorporationID.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    LstItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ComboGenderID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboGenderID.Leave
        Try
            If ComboGenderID.Text <> "" Then
                LstItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from Query_All_Items where gender_name = N'" & ComboGenderID.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    LstItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ComboSizeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSizeID.Leave
        Try
            If ComboSizeID.Text <> "" Then
                LstItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from Query_All_Items where size_name = N'" & ComboSizeID.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    LstItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ComboTypeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboTypeID.Leave
        Try
            If ComboTypeID.Text <> "" Then
                LstItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from Query_All_Items where type_name = N'" & ComboTypeID.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    LstItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ComboCustomerID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSeason.Leave
        Try
            If ComboSeason.Text <> "" Then
                LstItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from Query_All_Items where Season_Type = N'" & ComboSeason.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    LstItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub LstItemName_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LstItemName.MouseDoubleClick
        Try
            cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & LstItemName.Text & "' , 'None' , " & StockID.Tag & ")"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
            Else
                cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,Barcode from items where item_name = N'" & LstItemName.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    If OrderType.Text = "Ã„·…" Then
                        Price.Value = dr("Sale_Total_Price")
                    Else
                        Price.Value = dr("Sale_Price")
                    End If
                    ItmName = LstItemName.Text
                    BarCde = dr("Barcode")
                    ItmID = dr("Item_ID")
                Loop
                dr.Close()
                Quantity.Value = 1
                AddItem()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub LstItemName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstItemName.SelectedIndexChanged
        Try
            cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & LstItemName.Text & "' , 'None' , " & StockID.Tag & ")"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
            Else
                cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,Barcode from items where item_name = N'" & LstItemName.Text & "'"
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    If OrderType.Text = "Ã„·…" Then
                        Price.Value = dr("Sale_Total_Price")
                    Else
                        Price.Value = dr("Sale_Price")
                    End If
                    ItmName = LstItemName.Text
                    BarCde = dr("Barcode")
                    ItmID = dr("Item_ID")
                Loop
                dr.Close()
                'Quantity.Value = 1
                'AddItem()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSchedule.Click
        Try
            Dim m As New PaymentSchedule
            If MyDs.Tables("Sch_Payments").Rows.Count > 0 Then
                For i As Integer = 0 To MyDs.Tables("Sch_Payments").Rows.Count - 1
                    Select Case i
                        Case 0
                            m.FirstDate.Text = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckFirstPayment.Checked = True
                            m.FirstPayment.Value = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 1
                            m.SecondDate.Text = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckSecondPayment.Checked = True
                            m.SecondPayment.Value = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 2
                            m.ThirdDate.Text = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckThirdPayment.Checked = True
                            m.ThirdPayment.Value = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 3
                            m.ForthDate.Text = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckForthPayment.Checked = True
                            m.ForthPayment.Value = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Value")
                        Case 4
                            m.FifthDate.Text = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Date")
                            m.CheckFifthPayment.Checked = True
                            m.FifthPayment.Value = MyDs.Tables("Sch_Payments").Rows(i).Item("Payment_Value")
                    End Select

                Next
            End If

            m.bill_id = BillID.Text
            m.TotalPayments.Text = CreditValue.Value
            m.ShowDialog()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        CommitPrint()
    End Sub

    Sub CommitPrint()
        Try

            cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("—ﬁ„ «·›« Ê—… „” Œœ„ „”»ﬁ« √⁄œ ÷»ÿ «⁄œ«œ«  «·‰Ÿ«„")
                Exit Sub
            End If

            If (PayType.Text = "‰ﬁœÌ Ê «Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
                cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄")
                'ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
                '    cls.MsgExclamation("ÌÃ» «‰   ”«ÊÌ ﬁÌ„… «·„œ›Ê⁄ „⁄ «Ã„«·Ì «·›« Ê—…")
            ElseIf CustomerID.Text = "" Then
                cls.MsgExclamation("«Œ — «”„ «·⁄„Ì·")
            ElseIf PayType.Text = "" Then
                cls.MsgExclamation("«Œ — ÿ—Ìﬁ… «·œ›⁄")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")

            Else

                B_ID = BillID.Text
                CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & StockID.Tag & ")"
                    If cmd.ExecuteScalar = 1 Then
                        cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…")
                        Exit Sub
                    End If
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''
                If CreditValue.Value > 0 Then
                    cmd.CommandText = "SELECT DBO.Check_Credit_Limit(" & CustomerID.SelectedValue & "," & CreditValue.Value & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgCritical("·ﬁœ  ŒÿÌ Â–« «·⁄„Ì· Õ«Ã“ «·Õœ «·√ﬁ’Ì ··¬Ã·")
                        Exit Sub
                    End If
                End If

                If DiscountType.Text = "„»·€ À«» " Then
                    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",1)"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgCritical("·ﬁœ  ŒÿÌ Â–« «·⁄„Ì· «·Õœ «·√ﬁ’Ì ·‰”»… «·Œ’„")
                        Exit Sub
                    End If
                ElseIf DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",2)"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgCritical("·ﬁœ  ŒÿÌ Â–« «·⁄„Ì· «·Õœ «·√ﬁ’Ì ·‰”»… «·Œ’„")
                        Exit Sub
                    End If
                End If

                If MyDs.Tables("Sch_Payments").Rows.Count > 0 Then
                    For x As Integer = 0 To MyDs.Tables("Sch_Payments").Rows.Count - 1
                        d = MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Date")
                        cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Customer_ID") & " , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Value")
                        cmd.ExecuteNonQuery()
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Sales_Order_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmpIDVar & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.Tag & "," & PeriodID.Tag & ", N'" & OrderType.Text & "' , " & CardID.Tag
                cmd.ExecuteNonQuery()



                For i As Integer = 0 To DataGridView1.Rows.Count - 1


                    cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE - " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.Tag
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO SALES_DETAILS(BILL_ID,ITEM_ID,QUANTITY,PRICE,DISCOUNT_TYPE,DISCOUNT_VALUE,Total_Item) VALUES (" & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & ")"
                    cmd.ExecuteNonQuery()
                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ ÊÃ«—Ì «·ÿ»«⁄…")
                End If
                B_Edited = False
                Call ResetOrder(False)

                Me.Cursor = Cursors.WaitCursor

                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Print_Type") = "ÿ»«⁄… ⁄«œÌ…" Then

                    MyDs.Tables("Report_Sales_Order").Rows.Clear()
                    cmd.CommandText = "select * from Report_Sales_Order where bill_id = " & B_ID
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Report_Sales_Order"))
                    RptPur.SetDataSource(MyDs.Tables("Report_Sales_Order"))

                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Before_Print") = False Then
                        RptPur.PrintToPrinter(1, True, 0, 0)
                    Else
                        Dim m As New ShowAllReports
                        m.CrystalReportViewer1.ReportSource = RptPur
                        m.ShowDialog()
                    End If

                    Me.Cursor = Cursors.Default

                Else
                    MyDs.Tables("Report_Sales_Order").Rows.Clear()
                    cmd.CommandText = "SELECT dbo.Sales_Header.Bill_ID, dbo.Sales_Header.Bill_Date, dbo.Sales_Header.Bill_Time, dbo.Stocks.Stock_Name,dbo.Stocks.Logo, dbo.Customers.Customer_Name,dbo.Employees.Employee_Name, dbo.Sales_Header.Total_Bill, dbo.Sales_Header.Discount_Type, dbo.Sales_Header.Discount_Value,dbo.Sales_Header.Cash_Value, dbo.Sales_Header.Credit_Value, dbo.Sales_Header.Pay_Type, dbo.Sales_Header.Comments, dbo.Sales_Header.Footer," & _
        " dbo.Items.Item_Name, dbo.Items.Barcode, dbo.Sales_Details.Quantity, dbo.Sales_Details.Price, dbo.Sales_Details.Discount_Type AS Item_Discount_Type,dbo.Sales_Details.Discount_Value AS Item_Discount_Value, dbo.Periods.Period_Name, dbo.Sales_Header.Order_Type, dbo.Sales_Details.Total_Item" & _
        " FROM dbo.Sales_Header INNER JOIN dbo.Sales_Details ON dbo.Sales_Header.Bill_ID = dbo.Sales_Details.Bill_ID INNER JOIN dbo.Items ON dbo.Sales_Details.Item_ID = dbo.Items.Item_ID INNER JOIN dbo.Customers ON dbo.Sales_Header.Customer_ID = dbo.Customers.Customer_ID INNER JOIN dbo.Employees ON dbo.Sales_Header.Employee_ID = dbo.Employees.Employee_ID INNER JOIN dbo.Periods ON dbo.Sales_Header.Period_ID = dbo.Periods.Period_ID INNER JOIN dbo.Stocks ON dbo.Sales_Header.Stock_ID = dbo.Stocks.Stock_ID and sales_header.bill_id = " & B_ID
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Report_Sales_Order"))
                    RptChk.SetDataSource(MyDs.Tables("Report_Sales_Order"))

                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Before_Print") = False Then
                        RptChk.PrintToPrinter(1, True, 0, 0)
                    Else
                        Dim m As New ShowAllReports
                        m.CrystalReportViewer1.ReportSource = RptChk
                        m.ShowDialog()
                    End If

                    Me.Cursor = Cursors.Default

                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub
End Class