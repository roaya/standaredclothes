Public Class simpleSalesOrderNormal

    Dim TotalTemp, TotalDiscount As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    'Dim GetQtyFromBarcode As Boolean
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
    Private TblCustomers As New GeneralDataSet.CustomersDataTable
    Private TblSalesDetails As New GeneralDataSet.Sales_DetailsDataTable
    Dim tbl1 As New GeneralDataSet.CustomersDataTable
    Dim tbl2 As New GeneralDataSet.EmployeesDataTable

#Region "Order_Subs"

    Sub AddItem()
        If Quantity.Value = 0 Then
            cls.MsgExclamation("ادخل العدد")
        ElseIf DiscountTypeItem.Text <> "لا يوجد" And DiscountValueItem.Value = 0 Then
            cls.MsgExclamation("ادخل نسبة الخصم للصنف المحدد")
        ElseIf Price.Value = 0 Then
            cls.MsgExclamation("ادخل سعر الوحدة")
        ElseIf OrderType.Text = "" Then
            cls.MsgExclamation("أدخل نوع الفاتورة")
        ElseIf CustomerID.Text = "" Then
            cls.MsgExclamation("اختر اسم العميل")
        Else
            Try
                For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                    If TblSalesDetails.Rows(xx).Item("Item_ID") = ItmID Then
                        TblSalesDetails.Rows(xx).Item("Quantity") = TblSalesDetails.Rows(xx).Item("Quantity") + Quantity.Value
                        TblSalesDetails.Rows(xx).Item("Total_Item") = TblSalesDetails.Rows(xx).Item("Quantity") * TblSalesDetails.Rows(xx).Item("Price")

                        Select Case TblSalesDetails.Rows(xx).Item("Discount_Type")
                            Case "مبلغ ثابت"
                                ItmPrc = TblSalesDetails.Rows(xx).Item("Price") - TblSalesDetails.Rows(xx).Item("Discount_Value")
                            Case "نسبة مئوية"
                                ItmPrc = (TblSalesDetails.Rows(xx).Item("Price") - (TblSalesDetails.Rows(xx).Item("Price") * (TblSalesDetails.Rows(xx).Item("Discount_Value") / 100)))
                            Case "لا يوجد"
                                ItmPrc = Price.Value
                        End Select
                        TblSalesDetails.Rows(xx).Item("Price") = Price.Value
                        TblSalesDetails.Rows(xx).Item("Total_Item") = ItmPrc * TblSalesDetails.Rows(xx).Item("Quantity")

                        If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "الاسم" Then
                            RadioItemName.Checked = True
                            ItemName.Focus()
                        Else
                            RadioBarcode.Checked = True
                            BarCode.Focus()
                        End If

                        Quantity.Value = 0
                        Price.Value = 0
                        DiscountTypeItem.Text = "لا يوجد"

                        'CalculateTotalBill()

                        Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
                        BarCode.Text = ""

                        Select Case PayType.Text
                            Case "نقدي"
                                CashValue.Value = TotalBill.Text
                            Case "اجل"
                                CreditValue.Value = TotalBill.Text
                            Case "بشيك"
                                CashValue.Value = TotalBill.Text
                        End Select

                        Exit Sub
                    End If
                Next

                OrderType.Enabled = False
                CustomerID.Enabled = False
                BtnNewCustomer.Enabled = False
                r = TblSalesDetails.NewRow
                r("Bill_ID") = BillID.Text
                r("Item_Name") = ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("Quantity") = Quantity.Value
                r("Discount_Type") = DiscountTypeItem.Text
                r("Discount_Value") = DiscountValueItem.Value

                Select Case DiscountTypeItem.Text
                    Case "مبلغ ثابت"
                        ItmPrc = Price.Value - DiscountValueItem.Value
                    Case "نسبة مئوية"
                        ItmPrc = (Price.Value - (Price.Value * (DiscountValueItem.Value / 100)))
                    Case "لا يوجد"
                        ItmPrc = Price.Value
                End Select
                r("Price") = Price.Value
                r("Total_Item") = ItmPrc * Quantity.Value
                TblSalesDetails.Rows.Add(r)

                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "الاسم" Then
                    RadioItemName.Checked = True
                    ItemName.Focus()
                Else
                    RadioBarcode.Checked = True
                    BarCode.Focus()
                End If

                Quantity.Value = 0
                Price.Value = 0
                DiscountTypeItem.Text = "لا يوجد"

                CalculateTotalBill()

                Quantity.Value = 0 'MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
                BarCode.Text = ""

                Select Case PayType.Text
                    Case "نقدي"
                        CashValue.Value = TotalBill.Text
                    Case "اجل"
                        CreditValue.Value = TotalBill.Text
                    Case "بشيك"
                        CashValue.Value = TotalBill.Text
                End Select

            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = TblSalesDetails.Compute("sum(total_item)", "bill_id=" & BillID.Text)
                    '' CountRecords.Text = TblSalesDetails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                    ''  CountRecords.Text = 0
                End If
                If DiscountType.Text = "نسبة مئوية" Then
                    TotalDiscount = (TotalTemp * DiscountValue.Value) / 100
                ElseIf DiscountType.Text = "لا يوجد" Then
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

    Sub ResetOrder(ByVal IsNew As Boolean)
        Try
            MyDs.Tables("Sales_Header").Rows.Clear()
            TblSalesDetails.Rows.Clear()
            MyDs.Tables("Sch_Payments").Rows.Clear()
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
                GroupDetails.Enabled = False
                GroupItems.Enabled = False
                DiscountTypeItem.Text = "لا يوجد"
                DiscountValueItem.Value = 0
                DiscountValueItem.Enabled = False
                TotalTemp = 0
                B_EndLoad = False
                CardValue.Text = 0
            Else
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
                GroupDetails.Enabled = True
                GroupItems.Enabled = True
                DiscountTypeItem.Text = "لا يوجد"
                DiscountValueItem.Value = 0
                DiscountValueItem.Enabled = False
                TotalTemp = 0
                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "الاسم" Then
                    RadioItemName.Checked = True
                    ItemName.Focus()
                Else
                    RadioBarcode.Checked = True
                    BarCode.Focus()
                End If

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
                cls.LoadList("Card_Code", "Discount_Cards", CardID, " where Card_Status <> N'منتهي'")
                B_EndLoad = True

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
                CalculateTotalBill()
                CalcPayType()
            Else

                If DiscountTypeItem.Text = "نسبة مئوية" Then
                    DiscountValueItem.Enabled = True
                    DiscountValueItem.Value = 0
                    DiscountValueItem.Maximum = 100
                ElseIf DiscountTypeItem.Text = "مبلغ ثابت" Then
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

    Sub Commit_Form()
        Try

            cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("رقم الفاتورة مستخدم مسبقا أعد ضبط اعدادات النظام")
                Exit Sub
            End If

            CashValue.Value = TotalBill.Text

            If (PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
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


                '---------------------------------------
                ' '' '' ''If PayType.Text = "اجل" Or PayType.Text = "شيك و اجل" Or PayType.Text = "نقدي و اجل" Then
                ' '' '' ''    If MyDs.Tables("Sch_Payments").Compute("Count(Payment_Value)", "Customer_ID>0") > 0 Then
                ' '' '' ''        If MyDs.Tables("Sch_Payments").Compute("Sum(Payment_Value)", "Customer_ID>0") <> CreditValue.Value Then
                ' '' '' ''            cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                ' '' '' ''            Exit Sub
                ' '' '' ''        End If
                ' '' '' ''    Else
                ' '' '' ''        cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                ' '' '' ''        Exit Sub
                ' '' '' ''    End If
                ' '' '' ''End If
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

                CalculateTotalBill()
                '''''''''''''''''''''''''''''''''''''''''''''''''
                ' '' '' ''If CreditValue.Value > 0 Then
                ' '' '' ''    cmd.CommandText = "SELECT DBO.Check_Credit_Limit(" & CustomerID.SelectedValue & "," & CreditValue.Value & ")"
                ' '' '' ''    If cmd.ExecuteScalar = 0 Then
                ' '' '' ''        cls.MsgCritical("لقد تخطي هذا العميل حاجز الحد الأقصي للآجل")
                ' '' '' ''        Exit Sub
                ' '' '' ''    End If
                ' '' '' ''End If

                ''If DiscountType.Text = "مبلغ ثابت" Then
                ''    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",1)"
                ''    If cmd.ExecuteScalar = 0 Then
                ''        cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لنسبة الخصم")
                ''        Exit Sub
                ''    End If
                ''ElseIf DiscountType.Text = "نسبة مئوية" Then
                ''    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",2)"
                ''    If cmd.ExecuteScalar = 0 Then
                ''        cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لنسبة الخصم")
                ''        Exit Sub
                ''    End If
                ''End If

                ' '' '' '' ''If MyDs.Tables("Sch_Payments").Rows.Count > 0 Then
                ' '' '' '' ''    For x As Integer = 0 To MyDs.Tables("Sch_Payments").Rows.Count - 1
                ' '' '' '' ''        d = MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Date")
                ' '' '' '' ''        cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Customer_ID") & " , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Value")
                ' '' '' '' ''        cmd.ExecuteNonQuery()
                ' '' '' '' ''    Next
                ' '' '' '' ''End If
                '''''''''''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text

                cmd.CommandText = "Exec Commit_Sales_Order_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmployeeID.SelectedValue & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
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

                    cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE - " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.Tag
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO SALES_DETAILS(BILL_ID,ITEM_ID,QUANTITY,PRICE,DISCOUNT_TYPE,DISCOUNT_VALUE,Total_Item) VALUES (" & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & ")"
                    cmd.ExecuteNonQuery()

                    cls.Commit_Inv_Tran(BillID.Text, BDate, TotalBill.Text, DataGridView1.Rows(i).Cells("Item_ID").Value, DataGridView1.Rows(i).Cells("Quantity").Value, "فاتورة مبيعات", StockID.Tag)

                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo("تم حفظ الفاتورة بنجاح")
                End If
                B_Edited = False
                Call ResetOrder(False)

            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
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
            cls.MsgExclamation("يجب حفظ الفاتورة او حذفها اولا")
        End If

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        New_Form()
    End Sub

    Sub New_Form()
        Try
            'EmployeeID.Tag = EmpIDVar
            'EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            DiscountValue.Enabled = False
            CreditValue.Enabled = False
            TblSalesDetails.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True
            If B_EndLoad = True Then
                cmd.CommandText = "select distinct item_name from Query_Items_Stocks where stock_id = " & ProjectSettings.CurrentStockID
                Dim items As New DataTable()
                da.SelectCommand = cmd
                da.Fill(items)
                ItemName.DataSource = items

            End If

            If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "الاسم" Then
                RadioItemName.Checked = True
                ItemName.Focus()
            Else
                RadioBarcode.Checked = True
                BarCode.Focus()
            End If
            OrderType.Text = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Ord_Type")

            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Commit_Form()
    End Sub

    Sub Delete_Form()
        If MsgBox("هل تريد حذف السجل الحالي", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            MyDs.Tables("Sales_Header").Rows.Clear()
            TblSalesDetails.Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo("تم حذف الفاتورة بنجاح")
            End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuBtnDelete.Click
        Delete_Form()
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
                'TotalTemp.Text = 0
                '' CountRecords.Text = 0
            Else
                CalculateTotalBill()
                CalcPayType()
                ''  CountRecords.Text = TblSalesDetails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
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
                Case "مبلغ ثابت"
                    DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value - DataGridView1.Rows(RowID).Cells("Discount_Value").Value
                Case "نسبة مئوية"
                    DataGridView1.Rows(RowID).Cells("Price").Value = (DataGridView1.Rows(RowID).Cells("Price").Value - (DataGridView1.Rows(RowID).Cells("Price").Value * (DataGridView1.Rows(RowID).Cells("Discount_Value").Value / 100)))
                Case "لا يوجد"
                    DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value
            End Select
            DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value

        End If
        CalculateTotalBill()
    End Sub

    Private Sub ItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If ItemName.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.Tag & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                        ItemName.Focus()
                    Else
                        cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                        dr = cmd.ExecuteReader
                        Do While Not dr.Read = False
                            If OrderType.Text = "جملة" Then
                                Price.Value = dr("Sale_Total_Price")
                            Else
                                Price.Value = dr("Sale_Price")
                            End If
                            ItmName = ItemName.Text
                            BarCde = dr("Barcode")
                            ItmID = dr("Item_ID")
                        Loop
                        dr.Close()
                        Quantity.Value = 1
                        AddItem()
                    End If
                Else
                    cls.MsgExclamation("ادخل اسم الصنف")
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        If ItemName.Text <> "" Then
            Try
                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.Tag & ")"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                    ItemName.Focus()
                Else
                    cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        If OrderType.Text = "جملة" Then
                            Price.Value = dr("Sale_Total_Price")
                        Else
                            Price.Value = dr("Sale_Price")
                        End If
                        ItmName = ItemName.Text
                        BarCde = dr("Barcode")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()

                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

Private Sub BarCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If BarCode.Text <> "" Then

                    Dim itemId As Object = chkItem(BarCode.Text)
                    If (itemId <> Nothing) Then
                        cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,item_name from items where item_ID = N'" & itemId & "'"
                        dr = cmd.ExecuteReader
                        Do While Not dr.Read = False
                            If OrderType.Text = "جملة" Then
                                Price.Value = dr("Sale_Total_Price")
                            Else
                                Price.Value = dr("Sale_Price")
                            End If
                            ItmName = dr("Item_Name")
                            ItmID = dr("Item_ID")
                        Loop
                        dr.Close()

                        AddItem()
                    End If
                Else
                    cls.MsgExclamation("ادخل كود الصنف")
                End If

            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try
            If BarCode.Text <> "" Then
                Dim itemId As Object = chkItem(BarCode.Text)
                If (itemId <> Nothing) Then
                    cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,item_Name from items where item_Id = N'" & itemId & "'"
                    dr = cmd.ExecuteReader

                    Do While Not dr.Read = False
                        If OrderType.Text = "جملة" Then
                            Price.Value = dr("Sale_Total_Price")
                        Else
                            Price.Value = dr("Sale_Price")
                        End If
                        BarCde = BarCode.Text
                        ItmName = dr("Item_Name")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                End If

            Else
                cls.MsgExclamation("ادخل كود الصنف")
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
    'Private Sub CustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerID.SelectedIndexChanged
    '    If B_EndLoad = True And IsCustomerAdded = True Then
    '        cmd.CommandText = "select item_name from Query_Items_Customers where Customer_id = " & CustomerID.SelectedValue
    '        dr = cmd.ExecuteReader
    '        Do While Not dr.Read = False
    '            ItemName.Items.Add(dr("Item_Name"))
    '        Loop
    '        dr.Close()
    '    End If
    'End Sub

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

    Private Sub SalesOrderNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            cls.RefreshData("select * from Customers", tbl1)
            cls.RefreshData("select * from employees", tbl2)

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            ''         OrderByCombo.ComboBox.DataSource = B
            ''     OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            ''   OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            CustomerID.DataSource = tbl1
            CustomerID.DisplayMember = "Customer_Name"
            CustomerID.ValueMember = "Customer_ID"

            EmployeeID.DataSource = tbl2
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"



            DataGridView1.DataSource = TblSalesDetails
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
            DataGridView1.Columns(7).Visible = False
            DataGridView1.Columns(8).HeaderText = "قيمة الخصم عن الصنف الواحد"
            DataGridView1.Columns(8).ReadOnly = True
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(9).HeaderText = "اجمالي الصنف"
            DataGridView1.Columns(9).ReadOnly = True


            TblSalesDetails.Rows.Clear()
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


            'CmdProHdr.CommandType = CommandType.StoredProcedure
            'CmdProHdr.Connection = cn
            'CmdProDtl.CommandType = CommandType.StoredProcedure
            'CmdProDtl.Connection = cn

            'Dim PHdr, PDtl As SqlClient.SqlParameterCollection
            'PHdr.Add("B_ID", SqlDbType.Int)
            'PHdr.Add("B_DATE", SqlDbType.DateTime)
            'PHdr.Add("B_TIME", SqlDbType.NVarChar, 15)
            'PHdr.Add("V_ID", SqlDbType.Int)
            'PHdr.Add("STK_ID", SqlDbType.Int)
            'PHdr.Add("T_BILL", SqlDbType.Decimal, 18.0)
            'PHdr.Add("D_TYPE", SqlDbType.NVarChar)
            'PHdr.Add("D_VALUE", SqlDbType.Decimal, 18.0)
            'PHdr.Add("EMP_ID", SqlDbType.Int)
            'PHdr.Add("CSH_VAL", SqlDbType.Decimal, 18.0)
            'PHdr.Add("CRE_VALUE", SqlDbType.Decimal, 18.0)
            'PHdr.Add("P_TYPE", SqlDbType.NVarChar)
            'PHdr.Add("COMM", SqlDbType.NVarChar)
            'PHdr.Add("FOOT", SqlDbType.NVarChar)
            'CmdProHdr.Parameters.Add(PHdr)
            'CmdProHdr.CommandText = "Commit_Sales_Order_Header"
            '-----------------------------------
            'PDtl.Add("ITM_ID", SqlDbType.Int)
            'PDtl.Add("QTY", SqlDbType.Decimal, 18.0)
            'PDtl.Add("STK_ID", SqlDbType.Int)
            'PDtl.Add("B_ID", SqlDbType.Int)
            'PDtl.Add("PRC", SqlDbType.Decimal, 18.0)
            'PDtl.Add("D_TYPE", SqlDbType.NVarChar)
            'PDtl.Add("D_VALUE", SqlDbType.Decimal, 18.0)
            'CmdProDtl.Parameters.Add(PDtl)
            'CmdProDtl.CommandText = "Commit_Sales_Order_Details"




        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuBtnExit.Click
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

    Private Sub PayedValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayedValue.Validated
        CalculateTotalBill()
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

    Private Sub BtnSavePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        CommitPrint()
    End Sub

    Sub CommitPrint()
        Try

            cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("رقم الفاتورة مستخدم مسبقا أعد ضبط اعدادات النظام")
                Exit Sub
            End If

            CashValue.Value = TotalBill.Text

            If (PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
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


                '---------------------------------------
                '' '' '' '' ''If PayType.Text = "اجل" Or PayType.Text = "شيك و اجل" Or PayType.Text = "نقدي و اجل" Then
                '' '' '' '' ''    If MyDs.Tables("Sch_Payments").Compute("Count(Payment_Value)", "Customer_ID>0") > 0 Then
                '' '' '' '' ''        If MyDs.Tables("Sch_Payments").Compute("Sum(Payment_Value)", "Customer_ID>0") <> CreditValue.Value Then
                '' '' '' '' ''            cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                '' '' '' '' ''            Exit Sub
                '' '' '' '' ''        End If
                '' '' '' '' ''    Else
                '' '' '' '' ''        cls.MsgExclamation("لم يتم جدولة مواعيد السداد")
                '' '' '' '' ''        Exit Sub
                '' '' '' '' ''    End If
                '' '' '' '' ''End If
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

                CalculateTotalBill()
                '''''''''''''''''''''''''''''''''''''''''''''''''
                '' '' '' ''If CreditValue.Value > 0 Then
                '' '' '' ''    cmd.CommandText = "SELECT DBO.Check_Credit_Limit(" & CustomerID.SelectedValue & "," & CreditValue.Value & ")"
                '' '' '' ''    If cmd.ExecuteScalar = 0 Then
                '' '' '' ''        cls.MsgCritical("لقد تخطي هذا العميل حاجز الحد الأقصي للآجل")
                '' '' '' ''        Exit Sub
                '' '' '' ''    End If
                '' '' '' ''End If

                ''If DiscountType.Text = "مبلغ ثابت" Then
                ''    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",1)"
                ''    If cmd.ExecuteScalar = 0 Then
                ''        cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لنسبة الخصم")
                ''        Exit Sub
                ''    End If
                ''ElseIf DiscountType.Text = "نسبة مئوية" Then
                ''    cmd.CommandText = "SELECT DBO.Check_Max_Discount(" & CustomerID.SelectedValue & "," & DiscountValue.Value & ",2)"
                ''    If cmd.ExecuteScalar = 0 Then
                ''        cls.MsgCritical("لقد تخطي هذا العميل الحد الأقصي لنسبة الخصم")
                ''        Exit Sub
                ''    End If
                ''End If

                ' '' '' '' ''If MyDs.Tables("Sch_Payments").Rows.Count > 0 Then
                ' '' '' '' ''    For x As Integer = 0 To MyDs.Tables("Sch_Payments").Rows.Count - 1
                ' '' '' '' ''        d = MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Date")
                ' '' '' '' ''        cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Customer_ID") & " , " & MyDs.Tables("Sch_Payments").Rows(x).Item("Payment_Value")
                ' '' '' '' ''        cmd.ExecuteNonQuery()
                ' '' '' '' ''    Next
                ' '' '' '' ''End If
                '''''''''''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text

                cmd.CommandText = "Exec Commit_Sales_Order_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmployeeID.SelectedValue & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
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
                    cls.MsgInfo("تم حفظ الفاتورة بنجاح وجاري الطباعة")
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

    Private Sub MenuBtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBtnNew.Click
        New_Form()
    End Sub

    Private Sub MenuBtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBtnSave.Click
        Commit_Form()
    End Sub

    Private Sub MenuBtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBtnSavePrint.Click
        CommitPrint()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click, MenuTotal.Click
        PayedValue.Focus()
        PayedValue.Select(0, PayedValue.Text.Length)
    End Sub

    Private Sub PayedValue_ValueChanged(sender As Object, e As EventArgs) Handles PayedValue.ValueChanged
        CalculateTotalBill()
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
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
        Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")

        Dim itemId As Object = Nothing
        If barcode.Length < MyDs.Tables("App_Preferences").Rows(0).Item("Start_From") Then
            itemId = getItem(barcode)
        Else
            itemId = getItem(barcode.Substring(0, MyDs.Tables("App_Preferences").Rows(0).Item("Start_From")))
            If (itemId = Nothing) Then
                itemId = getItem(barcode)
            Else
                barcode = barcode.Substring(0, MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"))
                Quantity.Value = CDbl(barcode.Substring(MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"), (barcode.Length - MyDs.Tables("App_Preferences").Rows(0).Item("Start_From")) - 1)) / 1000
            End If
        End If
        If (itemId <> Nothing) Then
            cmd.CommandText = "select dbo.Is_Item_Attached(" & itemId & " , 'None' , 'None' , " & StockID.Tag & ")"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
            End If
        Else
            cls.MsgExclamation("هذا الكود غير مسجل")
        End If
        Return itemId

    End Function
End Class