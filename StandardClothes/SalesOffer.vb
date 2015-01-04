Public Class SalesOffer

    Dim t As New DataTable
    Dim Stmt As String
    Dim b As Boolean = False
    Dim Rpt1 As New RptSalesOfferBySalesPrice
    Dim rpt2 As New RptSalesOfferBySalesTotal
    Dim rpt3 As New RptSalesOfferByAll


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To SourceList.Items.Count - 1
            DestinationList.Items.Add(SourceList.Items(0))
            SourceList.Items.RemoveAt(0)
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i As Integer
        For i = 0 To SourceList.SelectedIndices.Count - 1
            DestinationList.Items.Add(SourceList.Items(SourceList.SelectedIndices(0)))
            SourceList.Items.Remove(SourceList.Items(SourceList.SelectedIndices(0)))
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If DestinationList.SelectedItems.Count > 0 Then
            SourceList.Items.Add(DestinationList.SelectedItem)
            DestinationList.Items.RemoveAt(DestinationList.SelectedIndex)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SourceList.Items.AddRange(DestinationList.Items)
        DestinationList.Items.Clear()
    End Sub

    Private Sub ItemsVendors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("Customers")
            OfferCurrentDate.Text = Now.ToString("dd/MM/yyyy")
            CustomerID.DataSource = MyDs
            CustomerID.DisplayMember = "Customers.Customer_Name"
            CustomerID.ValueMember = "Customers.Customer_ID"
        Catch ex As Exception
            cls.WriteError(ex.Message, "Sales Offer")
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            b = False

            cls.ViewAll(TabControl1.TabPages(2))
            TabControl1.SelectTab(2)
            cls.HideAll(TabControl1.TabPages(1))

            Me.Cursor = Cursors.WaitCursor
            'T = New System.Threading.Thread(AddressOf RunWorker)
            'T.Start()
            t.Rows.Clear()
            t.Columns.Clear()

            If RadioSaleTotal.Checked = True Then

                Stmt = "select item_name,sale_total_price ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from items where item_name in ("

                If DestinationList.Items.Count <= 0 Then
                    cls.MsgExclamation("لا يوجد عناصر لعرضها في عرض الاسعار")
                Else
                    For i As Integer = 0 To DestinationList.Items.Count - 1
                        DestinationList.SetSelected(i, True)
                        'MsgBox(DestinationList.SelectedItem)
                        If b = False Then
                            Stmt = Stmt & " N'" & DestinationList.SelectedItem & "'"
                            b = True
                        Else
                            Stmt = Stmt & " , N'" & DestinationList.SelectedItem & "'"
                        End If
                    Next
                    Stmt = Stmt & " )"
                    b = False
                    'MsgBox(Stmt)
                    cmd.CommandText = Stmt
                    da.SelectCommand = cmd
                    t.Rows.Clear()
                    da.Fill(t)

                    DataGridView1.Visible = True
                    cls.ViewAll(TabControl1.TabPages(2))
                    cls.HideAll(TabControl1.TabPages(1))
                    TabControl1.SelectTab(2)

                    DataGridView1.DataSource = t
                    DataGridView1.Columns(0).HeaderText = "اسم الصنف"
                    DataGridView1.Columns(1).HeaderText = "سعر بيع الجملة"
                    DataGridView1.Columns(2).Visible = False
                End If


                '-------------------------------------------------------------
            ElseIf RadioSaleOne.Checked = True Then

                Stmt = "select item_name,sale_price ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from items where item_name in ("

                If DestinationList.Items.Count <= 0 Then
                    cls.MsgExclamation("لا يوجد عناصر لعرضها في عرض الاسعار")
                Else
                    For i As Integer = 0 To DestinationList.Items.Count - 1
                        DestinationList.SetSelected(i, True)
                        'MsgBox(DestinationList.SelectedItem)
                        If b = False Then
                            Stmt = Stmt & " N'" & DestinationList.SelectedItem & "'"
                            b = True
                        Else
                            Stmt = Stmt & " , N'" & DestinationList.SelectedItem & "'"
                        End If
                    Next
                    Stmt = Stmt & " )"
                    b = False
                    'MsgBox(Stmt)
                    cmd.CommandText = Stmt
                    da.SelectCommand = cmd
                    t.Rows.Clear()
                    da.Fill(t)

                    DataGridView1.Visible = True
                    cls.ViewAll(TabControl1.TabPages(2))
                    cls.HideAll(TabControl1.TabPages(1))
                    TabControl1.SelectTab(2)

                    DataGridView1.DataSource = t
                    DataGridView1.Columns(0).HeaderText = "اسم الصنف"
                    DataGridView1.Columns(1).HeaderText = "سعر بيع القطاعي"
                    DataGridView1.Columns(2).Visible = False
                End If



                '-------------------------------------------------------------------------

            ElseIf RadioSaleOneTotal.Checked = True Then
                Stmt = "select item_name,sale_price,Sale_Total_Price ,(select logo from stocks where stock_id =" & ProjectSettings.CurrentStockID & ")as logo  from items where item_name in ("

                If DestinationList.Items.Count <= 0 Then
                    cls.MsgExclamation("لا يوجد عناصر لعرضها في عرض الاسعار")
                Else
                    For i As Integer = 0 To DestinationList.Items.Count - 1
                        DestinationList.SetSelected(i, True)
                        'MsgBox(DestinationList.SelectedItem)
                        If b = False Then
                            Stmt = Stmt & " N'" & DestinationList.SelectedItem & "'"
                            b = True
                        Else
                            Stmt = Stmt & " , N'" & DestinationList.SelectedItem & "'"
                        End If
                    Next
                    Stmt = Stmt & " )"
                    b = False
                    'MsgBox(Stmt)
                    cmd.CommandText = Stmt
                    da.SelectCommand = cmd
                    t.Rows.Clear()
                    da.Fill(t)

                    DataGridView1.Visible = True
                    cls.ViewAll(TabControl1.TabPages(2))
                    cls.HideAll(TabControl1.TabPages(1))
                    TabControl1.SelectTab(2)

                    DataGridView1.DataSource = t
                    DataGridView1.Columns(0).HeaderText = "اسم الصنف"
                    DataGridView1.Columns(1).HeaderText = "سعر بيع القطاعي"
                    DataGridView1.Columns(2).HeaderText = "سعر بيع الجملة"
                    DataGridView1.Columns(3).Visible = False
                End If



            End If



            'T.Abort()
            Button10.Visible = True
            cls.MsgInfo("تم انشاء عرض الاسعار بنجاح")
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.ErrMsg()
        End Try
    End Sub

    'Sub RunWorker()
    '    ProgressBar1.Visible = True
    '    ' TabControl1.SelectTab(1)
    'End Sub

    'Sub RunWorkerBefore()
    '    BeforeBar.Visible = True
    '    ' TabControl1.SelectTab(1)
    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try
            'TB = New System.Threading.Thread(AddressOf RunWorkerBefore)
            'TB.Start()
            cmd.CommandText = "select item_name from items"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                SourceList.Items.Add(dr("Item_Name"))
            Loop
            dr.Close()
            cls.ViewAll(TabControl1.TabPages(1))
            TabControl1.SelectTab(1)
            cls.HideAll(TabControl1.TabPages(0))
            'TB.Abort()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Sales Offer")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
       
        DestinationList.Items.Clear()
        SourceList.Items.Clear()
        cls.ViewAll(TabControl1.TabPages(0))
        TabControl1.SelectTab(0)
        cls.HideAll(TabControl1.TabPages(1))


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

   
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If RadioSaleOne.Checked = True Then

            Me.Cursor = Cursors.WaitCursor
            Rpt1.SetDataSource(t)
            Rpt1.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            Dim m As New ShowAllReports

            m.CrystalReportViewer1.ReportSource = Rpt1
            m.ShowDialog()

            Me.Cursor = Cursors.Default

        ElseIf RadioSaleTotal.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            rpt2.SetDataSource(t)
            rpt2.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = rpt2
            m.ShowDialog()
            Me.Cursor = Cursors.Default

        Else
            Me.Cursor = Cursors.WaitCursor
            rpt3.SetDataSource(t)

            rpt3.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            Dim m As New ShowAllReports
            m.CrystalReportViewer1.ReportSource = rpt3
            m.ShowDialog()
            Me.Cursor = Cursors.Default




        End If
    End Sub
End Class