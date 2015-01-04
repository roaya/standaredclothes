Public Class CustomerRequest


    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Request_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate, EDate As Date
    Dim StkID As Integer
    Dim B_ID As Integer
    Dim RptCustReq As New Report_Customers_Requests
    Dim TblRequestDetails As New GeneralDataSet.Request_DetailsDataTable


#Region "Order_Subs"


    Sub AddItem()

        If Quantity.Value = 0 Then
            cls.MsgExclamation("ادخل العدد")
            Exit Sub
        ElseIf StockID.Text = "" Then
            cls.MsgExclamation("ادخل اسم المخزن")
            Exit Sub
        Else
            Try

                For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                    If TblRequestDetails.Rows(xx).Item("Item_ID") = ItmID Then
                        TblRequestDetails.Rows(xx).Item("Quantity") = TblRequestDetails.Rows(xx).Item("Quantity") + Quantity.Value
                        CalculateTotalBill()
                        BarCode.Text = ""
                        Exit Sub
                    End If
                Next


                CustomerID.Enabled = False
                StockID.Enabled = False

                r = TblRequestDetails.NewRow
                r("request_id") = BillID.Text
                r("Item_Name") = ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("Quantity") = Quantity.Value

                TblRequestDetails.Rows.Add(r)

                If ProjectSettings.SrchNameOnRtnVenNrml = True Then
                    RadioButton1.Checked = True
                    ItemName.Focus()
                Else
                    RadioButton2.Checked = True
                    BarCode.Focus()
                End If

                Quantity.Value = 0

                'DiscountTypeItem.Text = "لا يوجد"

                Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Qty")
                If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Cus_Def_Sch") = "الاسم" Then
                    RadioButton1.Checked = True
                    ItemName.Focus()
                    ItemName.Text = ""
                Else
                    RadioButton2.Checked = True
                    BarCode.Focus()
                    BarCode.Text = ""
                End If

                CalculateTotalBill()
                BarCode.Text = ""
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If


    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    CountRecords.Text = TblRequestDetails.Compute("Count(Item_ID)", "Request_ID=" & BillID.Text)
                Else
                    CountRecords.Text = 0
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        Try
            MyDs.Tables("Request_Header").Rows.Clear()
            MyDs.Tables("Request_Details").Rows.Clear()
            If IsNew = False Then
                BillID.Text = 0
                BtnNew.Enabled = True
                BtnSave.Enabled = False
                BtnDelete.Enabled = False
                BtnExit.Enabled = True
                B_Edited = False
                StockID.Enabled = True
                BtnSavePrint.Enabled = False
                BillDate.Text = Now
                BillTime.Text = ""
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = False
                GroupDetails.Enabled = False
                GroupItems.Enabled = False
                B_EndLoad = False
                StkID = 0
                TblRequestDetails.Rows.Clear()
                ItemName.Text = ""
                BarCode.Text = ""
            Else
                StockID.Enabled = True
                BtnNew.Enabled = False
                BtnSave.Enabled = True
                BtnDelete.Enabled = True
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = True
                BillDate.Text = Now
                BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = True
                GroupDetails.Enabled = True
                GroupItems.Enabled = True
                B_EndLoad = True
                StkID = 0
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub Commit_Form()
        Try
            If StockID.Text = "" Then
                cls.MsgExclamation("ادخل اسم المحل")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("لا يوجد اصناف في الفاتورة")
            ElseIf CustomerID.Text = "" Then
                cls.MsgExclamation("أدخل اسم العميل")
            Else
                B_ID = BillID.Text

                CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & StkID & ")"
                    If cmd.ExecuteScalar = 1 Then
                        cls.MsgExclamation("الرصيد الحالي من " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " لايكفي الكمية المنصرفة")
                        Exit Sub
                    End If
                Next

                BDate = BillDate.Text
                EDate = ExpiredDate.Text
                cmd.CommandText = "Exec Commit_Request_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & _
                "' , N'" & Comments.TextBox1.Text & "'," & StkID & ", '" & EDate.ToString("MM/dd/yyyy") & "' ," & CustomerID.SelectedValue & "," & EmpIDVar
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1

                    cmd.CommandText = "Exec Commit_Request_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & StkID & "," & BillID.Text
                    cmd.ExecuteNonQuery()
                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo("تم حفظ الاذن بنجاح")
                End If
                B_Edited = False
                Call ResetOrder(False)

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub
#End Region

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuBtnNew.Click
        Try
            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            MyDs.Tables("Request_Details").Columns("Request_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Req_Cus_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuBtnSave.Click
        Commit_Form()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuBtnExit.Click

        If MsgBox("هل تريد حذف السجل الحالي", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            MyDs.Tables("Request_Header").Rows.Clear()
            MyDs.Tables("Request_Details").Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo("تم حذف الفاتورة بنجاح")
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

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                CountRecords.Text = 0
            Else
                CalculateTotalBill()
                CountRecords.Text = TblRequestDetails.Compute("Count(Item_ID)", "Request_ID=" & BillID.Text)
            End If
        End If

    End Sub



    Private Sub Requests_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("يجب حفظ الاذن او حذفه اولا")
        End If
    End Sub

    Private Sub Requests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("Stocks")
            cls.RefreshData("Customers")
            CustomerID.DataSource = MyDs
            CustomerID.DisplayMember = "Customers.Customer_Name"
            CustomerID.ValueMember = "Customers.Customer_ID"

            StockID.DataSource = MyDs
            StockID.DisplayMember = "Stocks.Stock_Name"
            StockID.ValueMember = "Stocks.Stock_ID"

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.ComboBox.DataSource = B
            OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            OrderByCombo.ComboBox.ValueMember = "Physical_Name"



            DataGridView1.DataSource = TblRequestDetails
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "اسم الصنف"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "الباركود"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).HeaderText = "العدد"

            TblRequestDetails.Rows.Clear()

            MyDs.Tables("Request_Details").Rows.Clear()
            MyDs.Tables("Request_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 5
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


    Private Sub FromStockID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                cmd.CommandText = "select stock_id from stocks where stock_name = N'" & StockID.Text & "'"
                StkID = cmd.ExecuteScalar

                ItemName.Items.Clear()
                cmd.CommandText = "select item_name from Query_Items_Stocks where stock_id = " & StkID
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    ItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    'Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
    '    Try
    '        If BarCode.Text <> "" Then
    '            If StockID.Text = "" Or StkID = 0 Then
    '                cls.MsgExclamation("ادخل اسم منفذ البيع المحول منه")
    '            Else
    '                cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & StkID & ")"
    '                If cmd.ExecuteScalar = 0 Then
    '                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
    '                    BarCode.Focus()
    '                    Exit Sub
    '                End If
    '            End If
    '        End If

    '        cmd.CommandText = "select Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"

    '        dr = cmd.ExecuteReader
    '        Do While Not dr.Read = False
    '            BarCde = BarCode.Text
    '            ItmName = dr("Item_Name")
    '            ItmID = dr("Item_ID")
    '        Loop
    '        dr.Close()
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
    '    Try
    '        If B_EndLoad = True Then
    '            cmd.CommandText = "select Item_ID,barcode from items where item_name = N'" & ItemName.Text & "'"
    '            dr = cmd.ExecuteReader

    '            Do While Not dr.Read = False
    '                ItmName = ItemName.Text
    '                BarCde = dr("Barcode")
    '                ItmID = dr("Item_ID")
    '            Loop
    '            dr.Close()
    '        End If
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    
    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click, MenuBtnSavePrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Commit_Form()
            MyDs.Tables("Report_Customers_Requests").Rows.Clear()
            cmd.CommandText = "select * from Report_Customers_Requests where Request_ID = " & B_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Customers_Requests"))
            RptCustReq.SetDataSource(MyDs.Tables("Report_Customers_Requests"))
            RptCustReq.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = RptCustReq
            m.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ItemName.Enabled = True
            BarCode.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ItemName.Enabled = False
            BarCode.Enabled = True
        End If
    End Sub

    Private Sub BarCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If BarCode.Text <> "" Then
                    BarCde = BarCode.Text
                    cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & StockID.SelectedValue & ")"
                    If BarCde.Length < MyDs.Tables("App_Preferences").Rows(0).Item("Start_From") Then
                        cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & StockID.SelectedValue & ")"
                        If cmd.ExecuteScalar = 0 Then
                            cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                            Exit Sub
                        End If
                    Else
                        cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCde.Substring(0, MyDs.Tables("App_Preferences").Rows(0).Item("Start_From")) & "' , " & StockID.Tag & ")"
                        If cmd.ExecuteScalar = 0 Then
                            cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & StockID.SelectedValue & ")"
                            If cmd.ExecuteScalar = 0 Then
                                cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                                Exit Sub
                            End If
                        Else
                            BarCde = BarCde.Substring(0, MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"))
                            Quantity.Value = CDbl(BarCode.Text.Substring(MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"), BarCode.Text.Length - MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"))) / 1000
                        End If
                    End If

                    cmd.CommandText = "select Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"
                    dr = cmd.ExecuteReader

                    Do While Not dr.Read = False

                        BarCde = BarCode.Text
                        ItmName = dr("Item_Name")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                    AddItem()
                Else
                    cls.MsgExclamation("ادخل كود الصنف")
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub ItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
        If e.KeyCode = Keys.Enter Then

            Try
                If ItemName.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.SelectedValue & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                        ItemName.Focus()
                    Else
                        cmd.CommandText = "select Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                        dr = cmd.ExecuteReader
                        Do While Not dr.Read = False

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
                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.SelectedValue & ")"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                    ItemName.Focus()
                Else
                    cmd.CommandText = "select Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False

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
    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try
            If BarCode.Text <> "" Then

                cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & StockID.SelectedValue & ")"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل")
                    BarCode.Focus()
                    Exit Sub
                End If
                'cmd.CommandText = "select dbo.Checked_Vendor_Items(" & CustomerID.SelectedValue & ",0,'" & BarCode.Text & "')"
                'If cmd.ExecuteScalar = 0 Then
                '    cls.MsgExclamation("هذا الصنف غير مرتبط بهذا المورد")
                '    Exit Sub
                'End If
            End If

            cmd.CommandText = "select Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"
            dr = cmd.ExecuteReader

            Do While Not dr.Read = False

                BarCde = BarCode.Text
                ItmName = dr("Item_Name")
                ItmID = dr("Item_ID")
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

   
End Class
