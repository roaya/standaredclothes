Public Class SalesOrderButtons

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
    Dim RptChk As New RptSalBill
    Dim B_ID As Integer
    Dim tbl1 As New GeneralDataSet.CustomersDataTable
    Dim tbl2 As New GeneralDataSet.EmployeesDataTable
    Private TblSalesDetails As New GeneralDataSet.Sales_DetailsDataTable
    Private TblQStocks As New GeneralDataSet.Query_Items_StocksDataTable
    Dim Vu As New DataView(TblQStocks)

#Region "Order_Subs"

    Sub AddItem(ByVal sender As System.Object, ByVal e As EventArgs)
        ItmID = CType(sender, Button).Tag

        
            If OrderType.Text = "جملة" Then
                cmd.CommandText = "select sale_total_price from items where item_id=" & ItmID
            Else
                cmd.CommandText = "select sale_price from items where item_id=" & ItmID
            End If
            ItmPrc = cmd.ExecuteScalar
            cmd.CommandText = "select barcode from items where item_id=" & ItmID
            BarCde = cmd.ExecuteScalar
            cmd.CommandText = "Select item_name from items where item_id= " & ItmID
            ItmName = cmd.ExecuteScalar

        If EmployeeID.SelectedValue = Nothing Then
            cls.MsgExclamation("ادخل اسم الموظف")
        ElseIf OrderType.Text = "" Then
            cls.MsgExclamation("أدخل نوع الفاتورة")
        ElseIf CustomerID.Text = "" Then
            cls.MsgExclamation("اختر اسم العميل")

        Else
            Try
                For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(xx).Cells("item_id").Value = ItmID Then
                        DataGridView1.Rows(xx).Cells("quantity").Value = DataGridView1.Rows(xx).Cells("quantity").Value + 1

                        Calc_Total_Items()
                        CalculateTotalBill()

                        Select Case PayType.Text
                            Case "نقدي"
                                CashValue.Value = TotalBill.Text
                            Case "اجل"
                                CreditValue.Value = TotalBill.Text
                            Case "بشيك"
                                CashValue.Value = TotalBill.Text
                        End Select

                        DataGridView1.Rows(xx).Selected = True
                        Quantity.Focus()
                        Quantity.Select(0, 1000)
                        Exit Sub
                    End If
                Next

                OrderType.Enabled = False
                CustomerID.Enabled = False
                BtnNewCustomer.Enabled = False
                r = MyDs.Tables("sales_details").NewRow
                r("Bill_ID") = BillID.Text
                r("Item_Name") = ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("Quantity") = 1
                r("Discount_Type") = "لا يوجد"
                r("Discount_Value") = 0

                r("Price") = ItmPrc
                r("Total_Item") = ItmPrc
                MyDs.Tables("sales_details").Rows.Add(r)


                Calc_Total_Items()
                CalculateTotalBill()



                Select Case PayType.Text
                    Case "نقدي"
                        CashValue.Value = TotalBill.Text
                    Case "اجل"
                        CreditValue.Value = TotalBill.Text
                    Case "بشيك"
                        CashValue.Value = TotalBill.Text
                End Select

                DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
                Quantity.Focus()
                Quantity.Select(0, 1000)
                'Quantity.Focus()

            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = MyDs.Tables("sales_details").Compute("sum(total_item)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                End If
                If DiscountType.Text = "نسبة مئوية" Then

                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("عفو لا يمكن اعطاء خصم 100%")
                        DiscountValue.Focus()


                        Exit Sub
                    Else
                        TotalDiscount = (TotalTemp * DiscountValue.Value) / 100

                    End If

                ElseIf DiscountType.Text = "لا يوجد" Then
                    TotalDiscount = 0
                Else
                    TotalDiscount = DiscountValue.Value
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("عفو الخصم لا يمكن ان يتساوى او يزيد عن اجمالى الفاتوره")
                        DiscountValue.Focus()
                        Exit Sub
                    End If
                End If
                TotalBill.Text = TotalTemp - (TotalDiscount + CDbl(CardValue.Text))
                RemainingValue.Text = PayedValue.Value - CDbl(TotalBill.Text)
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalcPayType()
        If B_EndLoad = True Then
            Select Case DiscountType.Text
                Case "مبلغ ثابت"
                    DTemp = DiscountValue.Value
                Case "نسبة مئوية"
                    DTemp = DiscountValue.Value * CDbl(TotalBill.Text)
                Case "لا يوجد"
                    DTemp = 0
            End Select

            Select Case PayType.Text


                Case "نقدي"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "اجل"
                    CreditValue.Value = TotalBill.Text '- DTemp
                    CashValue.Value = 0
                    CashValue.Enabled = False
                    CreditValue.Enabled = True
                Case "بشيك"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "نقدي و اجل"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
                Case "شيك و اجل"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
            End Select
        End If

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

                    cmd.CommandText = "select count(*) from items_Stocks where balance>0 and item_id=" & Vu.Item(x).Item("Item_id") & " and stock_id=" & Vu.Item(x).Item("Stock_id")
                    If cmd.ExecuteScalar > 0 Then
                        Dim b As New Button
                        b.Size = p
                        b.Font = fnt

                        b.Text = Vu.Item(x).Item("Item_Name")
                        b.Tag = Vu.Item(x).Item("Item_ID")
                        b.Name = "Btn" & Vu.Item(x).Item("Item_ID")
                        AddHandler b.Click, AddressOf AddItem
                        FC.Controls.Add(b)
                    ElseIf MyDs.Tables("Categories").Rows(i).Item("Category_ID") <> 1 Then
                        Dim b As New Button
                        b.Size = p
                        b.Font = fnt
                        b.Text = Vu.Item(x).Item("Item_Name")
                        b.Tag = Vu.Item(x).Item("Item_ID")
                        b.Name = "Btn" & Vu.Item(x).Item("Item_ID")
                        AddHandler b.Click, AddressOf AddItem
                        FC.Controls.Add(b)
                    End If
                Next

                TabAllItems.TabPages.Add(TP)
            Next

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        'Try
        MyDs.Tables("Sales_Header").Rows.Clear()
        TblSalesDetails.Rows.Clear()
        MyDs.Tables("Sch_Payments").Rows.Clear()
        PeriodID.Tag = MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Period_ID")
        cmd.CommandText = "select period_name from periods where period_id = " & MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Period_ID")
        PeriodID.Text = cmd.ExecuteScalar
        StockID.Tag = MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Stk_ID")
        cmd.CommandText = "select stock_name from stocks where stock_id=" & MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Stk_ID")
        StockID.Text = cmd.ExecuteScalar

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
            'BillDate.Text = Now
            BillTime.Text = ""
            TotalBill.Text = 0
            DiscountValue.Value = 0
            DiscountType.Text = "لا يوجد"
            'EmployeeID.Text = EmpNameVar
            'EmployeeID.Tag = EmpIDVar
            PayType.Text = "نقدي"
            CashValue.Value = 0
            CreditValue.Value = 0
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = False
            'GroupItems.Enabled = False
            'DiscountTypeItem.Text = "لا يوجد"
            'DiscountValueItem.Value = 0
            'DiscountValueItem.Enabled = False
            TotalTemp = 0
            B_EndLoad = False
            CardValue.Text = 0
        Else
            cls.RefreshData("select * from query_items_stocks where stock_id = " & StockID.Tag, TblQStocks)
            AddButtons()
            CustomerID.Enabled = True
            OrderType.Enabled = True
            BtnNewCustomer.Enabled = True
            CashValue.Value = 0
            CreditValue.Value = 0
            BtnNew.Enabled = False
            BtnSave.Enabled = True
            BtnDelete.Enabled = True
            BtnExit.Enabled = True
            B_Edited = False
            BtnSavePrint.Enabled = True
            'BillDate.Text = Now
            BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
            TotalBill.Text = 0
            DiscountValue.Value = 0
            DiscountType.Text = "لا يوجد"
            'EmployeeID.Text = EmpNameVar
            'EmployeeID.Tag = EmpIDVar
            PayType.Text = "نقدي"
            CashValue.Value = 0
            CreditValue.Value = 0
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = True
            'GroupItems.Enabled = True
            'DiscountTypeItem.Text = "لا يوجد"
            'DiscountValueItem.Value = 0
            'DiscountValueItem.Enabled = False
            TotalTemp = 0

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

            CardValue.Text = 0
            B_EndLoad = True

            '-------------------------------------
            PayedValue.Value = 0
            RemainingValue.Text = 0
            '-------------------------------------

        End If
        'Catch ex As Exception
        '    cls.WriteError(ex.Message, TName)
        'End Try
    End Sub

     Sub DiscountChangeTypes(ByVal IsGeneralDiscount As Boolean)
        If B_EndLoad = True Then
            If IsGeneralDiscount = True Then
                If DiscountType.Text = "نسبة مئوية" Then
                    DiscountValue.Enabled = True
                    DiscountValue.Value = 0
                    DiscountValue.Maximum = 100
                ElseIf DiscountType.Text = "مبلغ ثابت" Then
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

                'If DiscountTypeItem.Text = "نسبة مئوية" Then
                '    DiscountValueItem.Enabled = True
                '    DiscountValueItem.Value = 0
                '    DiscountValueItem.Maximum = 100
                'ElseIf DiscountTypeItem.Text = "مبلغ ثابت" Then
                '    DiscountValueItem.Enabled = True
                '    DiscountValueItem.Maximum = 1000000
                '    DiscountValueItem.Value = 0
                'Else
                '    DiscountValueItem.Enabled = False
                '    DiscountValueItem.Maximum = 0
                '    DiscountValueItem.Value = 0
                'End If

            End If
        End If
    End Sub

    Sub Commit_Form()

        Try
            CalculateTotalBill()

            cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("رقم الفاتورة مستخدم مسبقا أعد ضبط اعدادات النظام")
                Exit Sub
            End If


            If PayType.Text = "نقدي" Then
                PayedValue.Value = 0
                CashValue.Value = 0
                CashValue.Value = TotalBill.Text
                PayedValue.Value = TotalBill.Text
            End If




            If (PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
                cls.MsgExclamation("ادخل قيمة المدفوع و قيمة الاجل")
            ElseIf PayType.Text = "نقدي" And CashValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع")
            ElseIf PayType.Text = "اجل" And (CreditValue.Value = 0 Or PayedValue.Value <> 0) Then
                cls.MsgExclamation("ادخل قيمة المدفوع")
            ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
                cls.MsgExclamation("يجب ان تتساوي قيمة المدفوع مع اجمالي الفاتورة")
            ElseIf CustomerID.SelectedValue = Nothing Then
                cls.MsgExclamation("اختر اسم العميل")
            ElseIf PayType.Text = "" Then
                cls.MsgExclamation("اختر طريقة الدفع")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("لا يوجد اصناف في الفاتورة")

            Else

                B_ID = BillID.Text
                Calc_Total_Items()
                CalculateTotalBill()

                '---------------------------------------
                If PayType.Text = "اجل" Or PayType.Text = "شيك و اجل" Or PayType.Text = "نقدي و اجل" Then


                    cmd.CommandText = "select cl.Max_Credit_Limit from Customers c,Customer_Levels cl  where cl.Level_ID = c.Level_ID and c.Customer_ID= " & CustomerID.SelectedValue

                    If CreditValue.Value > cmd.ExecuteScalar Then
                        cls.MsgCritical("عفو مبلغ الاجل يتخطى مبلغ الاجل المخصص للعميل ")
                        Exit Sub
                    Else
                        If CreditValue.Value > 0 Then

                            cmd.CommandText = "SELECT DBO.Check_Credit_Limit(" & CustomerID.SelectedValue & "," & CreditValue.Value & ")"
                            If cmd.ExecuteScalar = 0 Then
                                cls.MsgCritical("عفوا مبلغ الاجل يزيد عن المبلغ الاجل المتبقى للعميل")

                                Exit Sub

                            End If
                        End If

             

                        End If

                End If

                ''''''''''''''''''''''''''''''''''''''''
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    Select Case DataGridView1.Rows(i).Cells("Discount_Type").Value
                        Case "مبلغ ثابت"
                            DataGridView1.Rows(i).Cells("Price").Value = DataGridView1.Rows(i).Cells("Price").Value - DataGridView1.Rows(i).Cells("Discount_Value").Value
                        Case "نسبة مئوية"
                            DataGridView1.Rows(i).Cells("Price").Value = (DataGridView1.Rows(i).Cells("Price").Value - (DataGridView1.Rows(i).Cells("Price").Value * (DataGridView1.Rows(i).Cells("Discount_Value").Value / 100)))
                        Case "لا يوجد"
                            DataGridView1.Rows(i).Cells("Price").Value = DataGridView1.Rows(i).Cells("Price").Value
                    End Select
                    DataGridView1.Rows(i).Cells("Total_Item").Value = DataGridView1.Rows(i).Cells("Price").Value * DataGridView1.Rows(i).Cells("Quantity").Value

                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & StockID.Tag & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("الرصيد الحالي من " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " لايكفي الكمية المنصرفة")
                        Exit Sub
                    End If
                Next

                Calc_Total_Items()
                CalculateTotalBill()
                '''''''''''''''''''''''''''''''''''''''''''''''''
                'If CreditValue.Value > 0 Then

                '    cmd.CommandText = "SELECT DBO.Check_Credit_Limit(" & CustomerID.SelectedValue & "," & CreditValue.Value & ")"
                '    If cmd.ExecuteScalar = 0 Then
                '        cls.MsgCritical("لقد تخطي هذا العميل حاجز الحد الأقصي للآجل")
                '        Exit Sub
                '    End If
                'End If

                If DiscountType.Text = "مبلغ ثابت" Then
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("عفو الخصم لا يمكن ان يتساوى او يزيد عن اجمالى الفاتوره")
                        DiscountValue.Focus()
                        Exit Sub


                    Else
                        cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",1)"
                        If cmd.ExecuteScalar = 0 Then
                            cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لمبلغ الخصم")
                            DiscountValue.Focus()
                            Exit Sub
                        End If
                    End If

                ElseIf DiscountType.Text = "نسبة مئوية" Then
                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("عفو لا يمكن اعطاء خصم 100%")
                        DiscountValue.Focus()

                        Exit Sub
                    Else
                        cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",2)"
                        If cmd.ExecuteScalar = 0 Then
                            cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لنسبة الخصم")

                            Exit Sub
                        End If
                    End If

                End If


                If PayType.Text = "اجل" Or PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل" Then
                    If MyDs.Tables("Sch_Payments").Compute("Count(Payment_Value)", "bill_id>0") > 0 Then
                        If MyDs.Tables("Sch_Payments").Compute("Sum(Payment_Value)", "bill_id>0") <> CreditValue.Value Then
                            cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                            Exit Sub
                        End If
                    Else
                        cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                        Exit Sub
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text

                cmd.CommandText = "Exec Commit_Sales_Order_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmployeeID.SelectedValue & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.Tag & "," & PeriodID.Tag & ", N'" & OrderType.Text & "' , N'" & card.Text & "'," & CurrentShiftID
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

                    cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE - " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.Tag
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO SALES_DETAILS(BILL_ID,ITEM_ID,QUANTITY,PRICE,DISCOUNT_TYPE,DISCOUNT_VALUE,Total_Item) VALUES (" & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & ")"
                    cmd.ExecuteNonQuery()

                    cls.Commit_Inv_Tran(BillID.Text, BDate, TotalBill.Text, DataGridView1.Rows(i).Cells("Item_ID").Value, DataGridView1.Rows(i).Cells("Quantity").Value, "فاتورة مبيعات", StockID.Tag)

                Next
                If MyDs.Tables("Sch_Payments").Rows.Count > 0 Then
                    For x As Integer = 0 To MyDs.Tables("Sch_Payments").Rows.Count - 1
                        d = MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Date")
                        cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Sch_Payments").Rows(x).Item("bill_ID") & " , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Value")
                        cmd.ExecuteNonQuery()
                    Next
                End If
             
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo("تم حفظ الفاتورة بنجاح")
                TabAllItems.Enabled = False
                MyDs.Tables("Sales_Details").Rows.Clear()
            End If
            B_Edited = False
            Call ResetOrder(False)
            DataGridView1.Enabled = False
            Panel1.Enabled = False
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub
#End Region
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click


        If CurrentShiftID = 0 Then
            cls.MsgExclamation("برجاء قم بفتح وردية")
            Exit Sub
        End If

        'Me.Cursor = Cursors.WaitCursor
        'Try
        'EmployeeID.Tag = EmpIDVar
        'EmployeeID.Text = EmpNameVar
        cmdPro.ExecuteNonQuery()
        BillID.Text = CurID.Value
        DiscountValue.Enabled = False
        CreditValue.Enabled = False
        TabAllItems.Enabled = True
        EmployeeID.SelectedValue = EmpIDVar
        MyDs.Tables("Sales_Details").Columns("Bill_ID").DefaultValue = BillID.Text
        ResetOrder(True)
        B_Edited = True
        Panel1.Enabled = True
        DataGridView1.Enabled = True
        cmd.CommandText = "select Sal_Def_Ord_Type from app_preferences"
        OrderType.Text = cmd.ExecuteScalar

        Discount_Value.Value = 0
        Discount_Type.Text = "لا يوجد"
        Price.Value = 0
        Quantity.Value = 0

        'Catch ex As Exception
        '    cls.WriteError(ex.Message, TName)
        'End Try
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click

        Commit_Form()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuDelete.Click
        If MsgBox("هل تريد حذف السجل الحالي", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            MyDs.Tables("Sales_Header").Rows.Clear()
            MyDs.Tables("Sales_Details").Rows.Clear()

            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                DataGridView1.Enabled = False
                cls.MsgInfo("تم حذف الفاتورة بنجاح")
                TabAllItems.Enabled = False
            End If
            B_Edited = False
            Call ResetOrder(False)
            Panel1.Enabled = False
        End If
    End Sub

    'Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        AddItem()
    '    End If

    'End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count <= 0 Then
                    TotalBill.Text = 0
                    'TotalTemp.Text = 0
                Else
                    Calc_Total_Items()
                    CalculateTotalBill()
                    CalcPayType()
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
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

    Private Sub CardID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If B_EndLoad = True Then
            Try
                cmd.CommandText = "select Card_ID , card_value from Discount_Cards where card_code = N'" & card.Text & "'"
                dr = cmd.ExecuteReader
                If Not dr.Read = False Then
                    CardValue.Text = dr("Card_Value")
                    CardValue.Text = dr("Card_ID")
                End If
                dr.Close()
                Calc_Total_Items()
                CalculateTotalBill()
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub PayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayType.SelectedIndexChanged
        CalcPayType()

    End Sub

    Private Sub DataGridView1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles DataGridView1.Validated

        If DataGridView1.Rows.Count <> 0 Then
            Select Case DataGridView1.Rows(RowID).Cells("Discount_Type").Value
                Case "مبلغ ثابت"
                    DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value - DataGridView1.Rows(RowID).Cells("Discount_Value").Value
                Case "نسبة مئوية"
                    DataGridView1.Rows(RowID).Cells("Price").Value = (DataGridView1.Rows(RowID).Cells("Price").Value - (DataGridView1.Rows(RowID).Cells("Price").Value * (DataGridView1.Rows(RowID).Cells("Discount_Value").Value / 100)))
                Case "لا يوجد"
                    DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value
            End Select
            DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
        End If
    End Sub




    Private Sub DoDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

        'cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & CType(sender, Button).Text & "' , 'None' , " & StockID.Tag & ")"
        'If cmd.ExecuteScalar = 0 Then
        '    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
        'Else
        '    cmd.CommandText = "select Sale_Price,Barcode from items where item_id =" & CType(sender, Button).Tag
        '    dr = cmd.ExecuteReader
        '    Do While Not dr.Read = False
        '        Price.Value = dr("Sale_Price")
        '        BarCde = dr("Barcode")
        '    Loop
        '    dr.Close()
        '    ItmName = CType(sender, Button).Text
        '    ItmID = CType(sender, Button).Tag
        '    Quantity.Value = 1
        '    AddItem()
        '    MsgBox("")
        'End If

    End Sub

    Private Sub DoClick(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            ItmID = CType(sender, Button).Tag
            If OrderType.Text = "جملة" Then
                cmd.CommandText = "select sale_total_price from items where item_id=" & ItmID
            Else
                cmd.CommandText = "select sale_price from items where item_id=" & ItmID
            End If
            ItmPrc = cmd.ExecuteScalar
            cmd.CommandText = "select barcode from items where item_id=" & ItmID
            BarCde = cmd.ExecuteScalar
            cmd.CommandText = "Select ItmName from items where item_id= " & ItmID
            ItmName = cmd.ExecuteScalar

            r = TblSalesDetails.NewRow


            If CType(sender, Button).Text <> "" Then
                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & CType(sender, Button).Text & "' , 'None' , " & StockID.Tag & ")"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                Else
                    cmd.CommandText = "select Sale_Total_Price,Sale_Price,Barcode from items where item_id = " & CType(sender, Button).Tag
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        If OrderType.Text = "جملة" Then
                            ItmPrc = dr("Sale_Total_Price")
                        Else
                            ItmPrc = dr("Sale_Price")
                        End If

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

    'Private Sub SalesOrderNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
    '    Try
    '        Dim B As New BindingSource
    '        B.DataSource = MyDs
    '        B.DataMember = "Table_Columns"
    '        B.Filter = "Table_ID ='" & TName & "'"
    '        OrderByCombo.ComboBox.DataSource = B
    '        OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
    '        OrderByCombo.ComboBox.ValueMember = "Physical_Name"

    '        CustomerID.DataSource = MyDs
    '        CustomerID.DisplayMember = "Customers.Customer_Name"
    '        CustomerID.ValueMember = "Customers.Customer_ID"





    '        DataGridView1.DataSource = MyDs.Tables("Sales_Details")
    '        DataGridView1.Columns(0).Visible = False
    '        DataGridView1.Columns(1).Visible = False
    '        DataGridView1.Columns(2).Visible = False
    '        DataGridView1.Columns(3).HeaderText = "اسم الصنف"
    '        DataGridView1.Columns(3).ReadOnly = True
    '        DataGridView1.Columns(4).HeaderText = "الباركود"
    '        DataGridView1.Columns(4).ReadOnly = True
    '        DataGridView1.Columns(5).HeaderText = "العدد"
    '        DataGridView1.Columns(6).HeaderText = "سعر الوحدة"
    '        DataGridView1.Columns(7).HeaderText = "نوع الخصم"
    '        DataGridView1.Columns(7).ReadOnly = True
    '        DataGridView1.Columns(8).HeaderText = "قيمة الخصم عن الصنف الواحد"
    '        DataGridView1.Columns(8).ReadOnly = True
    '        DataGridView1.Columns(9).HeaderText = "اجمالي الصنف"
    '        DataGridView1.Columns(9).ReadOnly = True


    '        MyDs.Tables("Sales_Details").Rows.Clear()
    '        MyDs.Tables("Sales_Header").Rows.Clear()

    '        cmdPro.CommandType = CommandType.StoredProcedure
    '        cmdPro.Connection = cn


    '        CurID.DbType = DbType.Int32
    '        CurID.ParameterName = "CURR_ID"
    '        CurID.Direction = ParameterDirection.Output
    '        SeqID.DbType = DbType.Int32
    '        SeqID.ParameterName = "S_ID"
    '        SeqID.Direction = ParameterDirection.Input
    '        SeqID.Value = 2
    '        cmdPro.Parameters.Add(SeqID)
    '        cmdPro.Parameters.Add(CurID)
    '        cmdPro.CommandText = "UPDATE_SEQ"


    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("Calc.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewCustomer.Click
        IsCustomerAdded = False
        Dim m As New Customers
        m.ShowDialog()
    End Sub


    Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        DiscountChangeTypes(False)
    End Sub


    Private Sub SalesOrderButtons_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from customers", tbl1)
            cls.RefreshData("Employees")


            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
        

            CustomerID.DataSource = tbl1
            CustomerID.DisplayMember = "Customer_Name"
            CustomerID.ValueMember = "Customer_ID"

            EmployeeID.DataSource = MyDs
            EmployeeID.DisplayMember = "employees.employee_name"
            EmployeeID.ValueMember = "employees.employee_id"



            DataGridView1.DataSource = MyDs.Tables("Sales_Details")
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "اسم الصنف"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "الباركود"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).HeaderText = "العدد"
            DataGridView1.Columns(6).HeaderText = "سعر الوحدة"
            DataGridView1.Columns(7).HeaderText = "نوع الخصم"
            DataGridView1.Columns(7).ReadOnly = True
            DataGridView1.Columns(8).HeaderText = "قيمة الخصم عن الصنف الواحد"
            DataGridView1.Columns(8).ReadOnly = True
            DataGridView1.Columns(9).HeaderText = "اجمالي الصنف"
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
            SeqID.Value = 1
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"
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

    Private Sub PayedValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayedValue.Validated
        Calc_Total_Items()
        CalculateTotalBill()
    End Sub

    Private Sub BtnSavePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click, SAvePrint.Click
        CommitPrint()
    End Sub

    Sub CommitPrint()
        Try

            CalculateTotalBill()

            cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("رقم الفاتورة مستخدم مسبقا أعد ضبط اعدادات النظام")
                Exit Sub
            End If

            If PayType.Text = "نقدي" Then
                PayedValue.Value = 0
                CashValue.Value = 0
                CashValue.Value = TotalBill.Text
                PayedValue.Value = TotalBill.Text
            End If


            If (PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
                cls.MsgExclamation("ادخل قيمة المدفوع")
            ElseIf PayType.Text = "نقدي" And CashValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع")
            ElseIf PayType.Text = "اجل" And (CreditValue.Value = 0 Or PayedValue.Value <> 0) Then
                cls.MsgExclamation("ادخل قيمة المدفوع")
            ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
                cls.MsgExclamation("يجب ان تتساوي قيمة المدفوع مع اجمالي الفاتورة")
            ElseIf CustomerID.Text = "" Then
                cls.MsgExclamation("اختر اسم العميل")
            ElseIf PayType.Text = "" Then
                cls.MsgExclamation("اختر طريقة الدفع")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("لا يوجد اصناف في الفاتورة")

            Else


                B_ID = BillID.Text
                Calc_Total_Items()
                CalculateTotalBill()

                '---------------------------------------
                If PayType.Text = "اجل" Or PayType.Text = "شيك و اجل" Or PayType.Text = "نقدي و اجل" Then

                    cmd.CommandText = "select cl.Max_Credit_Limit from Customers c,Customer_Levels cl  where cl.Level_ID = c.Level_ID and c.Customer_ID= " & CustomerID.SelectedValue

                    If CreditValue.Value > cmd.ExecuteScalar Then
                        cls.MsgCritical("عفو مبلغ الاجل يتخطى مبلغ الاجل المخصص للعميل ")
                        Exit Sub
                    Else
                        If CreditValue.Value > 0 Then

                            cmd.CommandText = "SELECT DBO.Check_Credit_Limit(" & CustomerID.SelectedValue & "," & CreditValue.Value & ")"
                            If cmd.ExecuteScalar = 0 Then
                                cls.MsgCritical("عفوا مبلغ الاجل يزيد عن المبلغ الاجل المتبقى للعميل")
                                Exit Sub
                            End If
                        End If

                        If PayType.Text = "اجل" Or PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل" Then
                            If MyDs.Tables("Sch_Payments").Compute("Count(Payment_Value)", "bill_id>0") > 0 Then
                                If MyDs.Tables("Sch_Payments").Compute("Sum(Payment_Value)", "bill_id>0") <> CreditValue.Value Then
                                    cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                                    Exit Sub
                                End If
                            Else
                                cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                ''''''''''''''''''''''''''''''''''''''''

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    Select Case DataGridView1.Rows(i).Cells("Discount_Type").Value
                        Case "مبلغ ثابت"
                            DataGridView1.Rows(i).Cells("Price").Value = DataGridView1.Rows(i).Cells("Price").Value - DataGridView1.Rows(i).Cells("Discount_Value").Value
                        Case "نسبة مئوية"
                            DataGridView1.Rows(i).Cells("Price").Value = (DataGridView1.Rows(i).Cells("Price").Value - (DataGridView1.Rows(i).Cells("Price").Value * (DataGridView1.Rows(i).Cells("Discount_Value").Value / 100)))
                        Case "لا يوجد"
                            DataGridView1.Rows(i).Cells("Price").Value = DataGridView1.Rows(i).Cells("Price").Value
                    End Select
                    DataGridView1.Rows(i).Cells("Total_Item").Value = DataGridView1.Rows(i).Cells("Price").Value * DataGridView1.Rows(i).Cells("Quantity").Value

                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & StockID.Tag & ")"
                    If cmd.ExecuteScalar = 1 Then
                        cls.MsgExclamation("الرصيد الحالي من " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " لايكفي الكمية المنصرفة")
                        Exit Sub
                    End If
                Next

                Calc_Total_Items()
                CalculateTotalBill()
                '''''''''''''''''''''''''''''''''''''''''''''''''
                If DiscountType.Text = "مبلغ ثابت" Then
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("عفو الخصم لا يمكن ان يتساوى او يزيد عن اجمالى الفاتوره")
                        DiscountValue.Focus()
                        Exit Sub


                    Else
                        cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",1)"
                        If cmd.ExecuteScalar = 0 Then
                            cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لمبلغ الخصم")
                            DiscountValue.Focus()
                            Exit Sub
                        End If
                    End If

                ElseIf DiscountType.Text = "نسبة مئوية" Then
                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("عفو لا يمكن اعطاء خصم 100%")
                        DiscountValue.Focus()

                        Exit Sub
                    Else
                        cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",2)"
                        If cmd.ExecuteScalar = 0 Then
                            cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لنسبة الخصم")
                            DiscountValue.Focus()
                            Exit Sub
                        End If
                    End If

                End If

                If PayType.Text = "اجل" Or PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل" Then
                    If MyDs.Tables("Sch_Payments").Compute("Count(Payment_Value)", "bill_id>0") > 0 Then
                        If MyDs.Tables("Sch_Payments").Compute("Sum(Payment_Value)", "bill_id>0") <> CreditValue.Value Then
                            cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                            Exit Sub
                        End If
                    Else
                        cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                        Exit Sub
                    End If
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text

                cmd.CommandText = "Exec Commit_Sales_Order_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmployeeID.SelectedValue & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.Tag & "," & PeriodID.Tag & ", N'" & OrderType.Text & "' , N'" & card.Text & "'," & CurrentShiftID
                cmd.ExecuteNonQuery()



                For i As Integer = 0 To DataGridView1.Rows.Count - 1


                    cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE - " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.Tag
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO SALES_DETAILS(BILL_ID,ITEM_ID,QUANTITY,PRICE,DISCOUNT_TYPE,DISCOUNT_VALUE,Total_Item) VALUES (" & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & ")"
                    cmd.ExecuteNonQuery()

                    cls.Commit_Inv_Tran(BillID.Text, BDate, TotalBill.Text, DataGridView1.Rows(i).Cells("Item_ID").Value, DataGridView1.Rows(i).Cells("Quantity").Value, "فاتورة مبيعات", StockID.Tag)

                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo("تم حفظ الفاتورة بنجاح وجاري الطباعة")
                    TabAllItems.Enabled = False
                    MyDs.Tables("Sales_Details").Rows.Clear()
                End If
                B_Edited = False
                Call ResetOrder(False)

                Me.Cursor = Cursors.WaitCursor

                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Print_Type") = "طباعة عادية" Then

                    MyDs.Tables("Report_Sales_Order").Rows.Clear()
                    cmd.CommandText = "select * from Report_Sales_Order where bill_id = " & B_ID
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Report_Sales_Order"))
                    RptPur.SetDataSource(MyDs.Tables("Report_Sales_Order"))
                    RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

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
            Panel1.Enabled = False
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub

    Private Sub Card_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles card.Leave
        Try
            Dim x As Integer
            Dim CardExpired As Date = Nothing
            cmd.CommandText = "select card_status from discount_cards where card_code= N'" & card.Text & "'"
            If cmd.ExecuteScalar = "منتهي" Then
                cls.MsgExclamation("عفو هذا الكارت مستخدم من قبل")
                card.Text = ""
                DiscountType.Focus()
                Exit Sub
            End If


            cmd.CommandText = "select expired_date from discount_cards where card_code= N'" & card.Text & "'"

            CardExpired = cmd.ExecuteScalar
            If CardExpired = Nothing Then
                cls.MsgExclamation("رقم كارت غير صحيح")
                card.Text = ""
                Exit Sub
            Else

                If CardExpired < Now.ToString("dd/MM/yyyy") Then
                    cls.MsgExclamation("عفو هذا الكارت منتهى الصلاحيه")
                    card.Text = ""
                    DiscountType.Focus()
                    Exit Sub

                End If
            End If

            cmd.CommandText = "select card_value from discount_cards where card_code= N'" & card.Text & "'"
            x = cmd.ExecuteScalar
            If x > TotalTemp Then
                cls.MsgExclamation("عفو قيمه خصم الكوبون تزيد عن اجمالى الفاتوره")
                card.Text = ""
                DiscountType.Focus()
                Exit Sub
            Else

                CardValue.Text = cmd.ExecuteScalar
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If GroupHeader.Tag = 1 Then
            GroupHeader.Tag = 0
            GroupHeader.Visible = False
            ToolStripButton1.Text = "اظهار الشيك"
        Else
            GroupHeader.Tag = 1
            GroupHeader.Visible = True
            ToolStripButton1.Text = "اخفاء الشيك"
        End If
    End Sub

    Private Sub Discount_Value_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Discount_Value.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Discount_Type.Text = "" Then
                cls.MsgExclamation("برجاء اختيار نوع الخصم")
                Exit Sub
            End If

            If Discount_Value.Value <= 0 And Discount_Type.Text <> "لا يوجد" Then
                cls.MsgExclamation("عفوا لا يمكن للخصم ان يكون مساوي لصفر ")
                Exit Sub
            End If

            Try
                If Discount_Type.Text = "لا يوجد" Then
                    DataGridView1.SelectedRows(0).Cells("discount_Type").Value = Discount_Type.Text
                    DataGridView1.SelectedRows(0).Cells("discount_value").Value = 0
                    DataGridView1.SelectedRows(0).Cells("total_item").Value = DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("Quantity").Value
                ElseIf Discount_Type.Text = "نسبة مئوية" Then
                    If Discount_Value.Value >= 100 Then
                        cls.MsgExclamation("عفوا لا يمكن للخصم ان يكون 100 " & "%")
                        Exit Sub
                    End If

                    DataGridView1.SelectedRows(0).Cells("discount_Type").Value = Discount_Type.Text
                    DataGridView1.SelectedRows(0).Cells("discount_value").Value = Discount_Value.Value
                    DataGridView1.SelectedRows(0).Cells("total_item").Value = DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value - (DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value * Discount_Value.Value / 100)
                Else

                    If Discount_Value.Value >= DataGridView1.SelectedRows(0).Cells(6).Value Then
                        cls.MsgExclamation("عفوا لا يمكن للخصم ان يكون مساوي لسعر الصنف ")
                        Exit Sub
                    End If

                    DataGridView1.SelectedRows(0).Cells("discount_Type").Value = Discount_Type.Text
                    DataGridView1.SelectedRows(0).Cells("discount_value").Value = Discount_Value.Value
                    DataGridView1.SelectedRows(0).Cells("total_item").Value = (DataGridView1.SelectedRows(0).Cells("Price").Value - DataGridView1.SelectedRows(0).Cells("Discount_Value").Value) * DataGridView1.SelectedRows(0).Cells("quantity").Value
                End If

            Catch
                cls.MsgExclamation("برجاء اختيار الصنف ")
            End Try

            Calc_Total_Items()
            CalculateTotalBill()
        End If
    End Sub

    Private Sub Price_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Price.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Price.Value <= 0 Then
                    cls.MsgExclamation("برجاء ادخال سعر صحيح")
                    Exit Sub
                End If
                DataGridView1.SelectedRows(0).Cells("price").Value = Price.Value
                Calc_Total_Items()
                CalculateTotalBill()
            End If
        Catch
            cls.MsgExclamation("برجاء اختيار الصنف ")
        End Try
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Quantity.Value <= 0 Then
                    cls.MsgExclamation("برجاء ادخال كميه اكبر من صفر")
                    Exit Sub
                End If
                DataGridView1.SelectedRows(0).Cells("discount_Type").Value = "لا يوجد"
                DataGridView1.SelectedRows(0).Cells("discount_value").Value = 0
                DataGridView1.SelectedRows(0).Cells("quantity").Value = Quantity.Value
                DataGridView1.SelectedRows(0).Cells("total_item").Value = DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value
                Calc_Total_Items()
                CalculateTotalBill()
            End If
        Catch
            cls.MsgExclamation("برجاء اختيار الصنف ")
        End Try
    End Sub

    Private Sub Calc_Total_Items()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells("discount_Type").Value = "لا يوجد" Then
                DataGridView1.Rows(i).Cells("total_item").Value = DataGridView1.Rows(i).Cells("Price").Value * DataGridView1.Rows(i).Cells("quantity").Value
            ElseIf DataGridView1.SelectedRows(0).Cells("discount_Type").Value = "نسبة مئوية" Then
                DataGridView1.SelectedRows(0).Cells("total_item").Value = DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value - (DataGridView1.SelectedRows(0).Cells("Price").Value * DataGridView1.SelectedRows(0).Cells("quantity").Value * Discount_Value.Value / 100)
            Else
                DataGridView1.Rows(i).Cells("total_item").Value = (DataGridView1.Rows(i).Cells("Price").Value - DataGridView1.Rows(i).Cells("Discount_Value").Value) * DataGridView1.Rows(i).Cells("quantity").Value
            End If
        Next


    End Sub
End Class
