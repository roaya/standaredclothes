Public Class Adjustments

    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Adjustment_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate As Date
    Dim FStkID, TStkID As Integer
    Dim RptAdj As New Report_Adjustments
    Dim tbl As New GeneralDataSet.Adjustment_DetailsDataTable
    Dim B_ID As Integer

#Region "Order_Subs"


    Sub AddItem()
        Try
            If Quantity.Value = 0 Then
                cls.MsgExclamation("«œŒ· «·⁄œœ")
                Exit Sub
            ElseIf FromStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· „‰Â")
                Exit Sub
            ElseIf ToStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· «·ÌÂ")
                Exit Sub
            ElseIf FromStockID.Text = ToStockID.Text Then
                cls.MsgExclamation("·« Ì„ﬂ‰ ‰ﬁ· «·«’‰«› «·Ì ‰›” „‰›– «·»Ì⁄")
                Exit Sub
            End If
            'cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & FStkID & ")"
            'If cmd.ExecuteScalar = 0 Then
            '    cls.MsgExclamation("Â–« «·’‰› €Ì— „— »ÿ »«·„‰›– «·„ÕÊ· „‰Â")
            '    Exit Sub
            'End If

            'cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & TStkID & ")"
            'If cmd.ExecuteScalar = 0 Then
            '    cls.MsgExclamation("Â–« «·’‰› €Ì— „— »ÿ »«·„‰›– «·„ÕÊ· «·ÌÂ")
            '    Exit Sub
            'End If


            'For xx As Integer = 0 To DataGridView1.Rows.Count - 1
            '    Iftbl.Compute("Count(Item_ID)", "Item_id=" & ItmID) > 0 Then
            '        cls.MsgExclamation("Â–« «·’‰› „ÊÃÊœ „”»ﬁ« ›Ì «·›« Ê—… «·Õ«·Ì…")
            '        Exit Sub
            '    End If
            'Next

            For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                If tbl.Rows(xx).Item("Item_ID") = ItmID Then
                    tbl.Rows(xx).Item("Quantity") = tbl.Rows(xx).Item("Quantity") + Quantity.Value

                    CalculateTotalBill()
                    BarCode.Text = ""
                    Exit Sub
                End If
            Next
            FromStockID.Enabled = False
            ToStockID.Enabled = False
            r = tbl.NewRow
            r("Adjustment_ID") = BillID.Text
            r("Item_Name") = ItmName
            r("Item_ID") = ItmID
            r("Barcode") = BarCde
            r("Quantity") = Quantity.Value
            tbl.Rows.Add(r)
            If ProjectSettings.SrchNameOnRtnVenNrml = True Then
                RadioButton1.Checked = True
                ItemName.Focus()
            Else
                RadioButton2.Checked = True
                BarCode.Focus()
            End If
            Quantity.Value = 0
            CalculateTotalBill()
            FromStockID.Enabled = False
            ToStockID.Enabled = False
            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Adj_Def_Qty")
            If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Ven_Def_Sch") = "«·«”„" Then
                RadioButton1.Checked = True
                ItemName.Focus()
                ItemName.Text = ""
            Else
                RadioButton2.Checked = True
                BarCode.Focus()
                BarCode.Text = ""
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    CountRecords.Text = tbl.Compute("Count(Item_ID)", "Adjustment_ID=" & BillID.Text)
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
            MyDs.Tables("Adjustment_Header").Rows.Clear()
            tbl.Rows.Clear()
            If IsNew = False Then
                BillID.Text = 0
                BtnNew.Enabled = True
                BtnSave.Enabled = False
                BtnDelete.Enabled = False
                BtnExit.Enabled = True
                B_Edited = False
                FromStockID.Enabled = True
                ToStockID.Enabled = True
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
                FStkID = 0
            Else
                FromStockID.Enabled = True
                ToStockID.Enabled = True
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
                FStkID = 0
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub Commit_Form()
        Try
            If FromStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· „‰Â")
            ElseIf ToStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· «·ÌÂ")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…")
            Else
                B_ID = BillID.Text

                CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & FStkID & ")"
                    If cmd.ExecuteScalar = 0 Then

                        cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…")
                        Exit Sub
                    End If
                Next

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Adjustment_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & _
                "' , N'" & Comments.TextBox1.Text & "'," & FStkID & "," & TStkID & "," & EmpIDVar
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1

                    cmd.CommandText = "Exec Commit_Adjustment_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & FStkID & "," & TStkID & "," & BillID.Text
                    cmd.ExecuteNonQuery()
                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·«–‰ »‰Ã«Õ")
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
            tbl.Columns("Adjustment_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            If MyDs.Tables("App_Preferences").Rows(0).Item("Adj_Def_Sch") = "«·«”„" Then
                RadioButton1.Checked = True
                ItemName.Focus()
            Else
                RadioButton2.Checked = True
                BarCode.Focus()
            End If
            Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Adj_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuBtnSave.Click
        Commit_Form()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuBtnExit.Click
        If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            MyDs.Tables("Adjustment_Header").Rows.Clear()
            tbl.Rows.Clear()
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

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                CountRecords.Text = 0
            Else
                CalculateTotalBill()
                CountRecords.Text = tbl.Compute("Count(Item_ID)", "Adjustment_ID=" & BillID.Text)
            End If
        End If

    End Sub



    Private Sub Adjustments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("ÌÃ» Õ›Ÿ «·«–‰ «Ê Õ–›Â «Ê·«")
        End If
    End Sub

    Private Sub Adjustments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ' cls.SetGrant(MenuItemsStocks, "‰«›–… —»ÿ «·√’‰«› »«·„Õ·« ")

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.ComboBox.DataSource = B
            OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            cmd.CommandText = "select Stock_Name from stocks"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                FromStockID.Items.Add(dr("Stock_Name"))
            Loop
            dr.Close()

            cmd.CommandText = "select Stock_Name from stocks"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ToStockID.Items.Add(dr("Stock_Name"))
            Loop
            dr.Close()


            DataGridView1.DataSource = tbl
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "«”„ «·’‰›"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "«·»«—ﬂÊœ"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).HeaderText = "«·⁄œœ"



            tbl.Rows.Clear()
            MyDs.Tables("Adjustment_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 7
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"

            cls.RefreshData("Stocks")

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

    
    Private Sub FromStockID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FromStockID.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                cmd.CommandText = "select stock_id from stocks where stock_name = N'" & FromStockID.Text & "'"
                FStkID = cmd.ExecuteScalar

                ItemName.Items.Clear()
                cmd.CommandText = "select item_name from Query_Items_Stocks where stock_id = " & FStkID
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

    Private Sub ToStockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToStockID.SelectedIndexChanged
        Try
            cmd.CommandText = "select stock_id from stocks where stock_name = N'" & ToStockID.Text & "'"
            TStkID = cmd.ExecuteScalar
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try

            If BarCode.Text <> "" Then
                If FromStockID.Text = "" Or FStkID = 0 Then
                    cls.MsgExclamation("«œŒ· «”„ „‰›– «·»Ì⁄ «·„ÕÊ· „‰Â")
                Else
                    cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & TStkID & ")"
                    If cmd.ExecuteScalar = 0 And BarCode.Text <> "" Then
                        cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                        BarCode.Focus()
                        Exit Sub
                    End If
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
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If B_EndLoad = True Then

                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & TStkID & ")"
                If cmd.ExecuteScalar = 0 And ItemName.Text <> "" Then
                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                    ItemName.Focus()
                Else
                    cmd.CommandText = "select Item_ID,barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader

                    Do While Not dr.Read = False
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

    
    Private Sub MenuItemsStocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ItemsStocks
        m.ShowDialog()
    End Sub

    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Commit_Form()
            MyDs.Tables("Report_Adjustments").Rows.Clear()
            cmd.CommandText = "select * from Report_Adjustments where Adjustment_id = " & B_ID
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Adjustments"))

            RptAdj.SetDataSource(MyDs.Tables("Report_Adjustments"))
            RptAdj.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = RptAdj
            m.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
    Private Sub ItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
        If e.KeyCode = Keys.Enter Then

            Try
                If ItemName.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & TStkID & ")"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                        ItemName.Focus()
                    Else
                        cmd.CommandText = "select sale_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
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
                    cls.MsgExclamation("«œŒ· «”„ «·’‰›")
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
                    BarCde = BarCode.Text
                    cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & TStkID & ")"
                    If BarCde.Length < MyDs.Tables("App_Preferences").Rows(0).Item("Start_From") Then
                        cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' ,  " & TStkID & ")"
                        If cmd.ExecuteScalar = 0 Then
                            cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                            Exit Sub
                        End If
                    Else
                        cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCde.Substring(0, MyDs.Tables("App_Preferences").Rows(0).Item("Start_From")) & "' , " & TStkID & ")"
                        If cmd.ExecuteScalar = 0 Then
                            cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' ,  " & TStkID & ")"
                            If cmd.ExecuteScalar = 0 Then
                                cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·")
                                Exit Sub
                            End If
                        Else
                            BarCde = BarCde.Substring(0, MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"))
                            Quantity.Value = CDbl(BarCode.Text.Substring(MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"), BarCode.Text.Length - MyDs.Tables("App_Preferences").Rows(0).Item("Start_From"))) / 1000
                        End If
                    End If

                    cmd.CommandText = "select sale_price,Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"
                    dr = cmd.ExecuteReader

                    Do While Not dr.Read = False

                        BarCde = BarCode.Text
                        ItmName = dr("Item_Name")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                    AddItem()
                Else
                    cls.MsgExclamation("«œŒ· ﬂÊœ «·’‰›")
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

   
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ItemName.Enabled = True
            BarCode.Enabled = False
            ItemName.Text = ""
            BarCode.Text = ""
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ItemName.Enabled = False
            BarCode.Enabled = True
            ItemName.Text = ""
            BarCode.Text = ""
        End If
    End Sub
End Class