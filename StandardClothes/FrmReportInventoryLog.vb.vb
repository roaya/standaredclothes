Public Class FrmReportInventoryLog

    Dim RptCustRet As New RptInventoryLog
    Dim b As Boolean = False
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.ItemsDataTable
    Dim tbl3 As New GeneralDataSet.StocksDataTable

    Dim tbl5 As New GeneralDataSet.CategoriesDataTable
    Dim tbl6 As New GeneralDataSet.CorporationsDataTable
    Dim tbl7 As New GeneralDataSet.StocksDataTable

    Private Sub ReportVenReturns_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub

    Private Sub ReportCusReturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData("select * from items", tbl2)
            cls.RefreshData("select * from stocks", tbl7)
            cls.RefreshData("select * from corporations", tbl6)
            cls.RefreshData("select * from categories", tbl5)

            Item.DataSource = tbl2
            Item.DisplayMember = "item_name"
            Item.ValueMember = "item_ID"


            Stock.DataSource = tbl7
            Stock.DisplayMember = "stock_name"
            Stock.ValueMember = "stock_id"


            Corporation.DataSource = tbl6
            Corporation.DisplayMember = "corporation_name"
            Corporation.ValueMember = "corporation_id"

            Category.DataSource = tbl5
            Category.DisplayMember = "category_name"
            Category.ValueMember = "category_id"

            b = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ByItem.Checked = True Then
                If Item.Text = "" Then
                    cls.MsgExclamation("برجاء قم بادخال اسم الصنف")
                    Exit Sub
                End If

                MyDs.Tables("report_inventory_log").Rows.Clear()
                cmd.CommandText = "select * from report_inventory_log where item_id = " & Item.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetDataSource(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustRet
                m.ShowDialog()
            ElseIf bystock.Checked = True Then
                If Stock.Text = "" Then
                    cls.MsgExclamation("برجاء قم بادخال اسم المخزن")
                    Exit Sub
                End If

                MyDs.Tables("report_inventory_log").Rows.Clear()
                cmd.CommandText = "select * from report_inventory_log where stock_id = " & Stock.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetDataSource(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustRet
                m.ShowDialog()
            ElseIf bycat.Checked = True Then
                If Category.Text = "" Then
                    cls.MsgExclamation("برجاء قم بادخال اسم البند")
                    Exit Sub
                End If

                MyDs.Tables("report_inventory_log").Rows.Clear()
                cmd.CommandText = "select * from report_inventory_log where category_id = " & Category.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetDataSource(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustRet
                m.ShowDialog()
            ElseIf bycorporation.Checked = True Then
                If Corporation.Text = "" Then
                    cls.MsgExclamation("برجاء قم بادخال اسم الشركة")
                    Exit Sub
                End If

                MyDs.Tables("report_inventory_log").Rows.Clear()
                cmd.CommandText = "select * from report_inventory_log where corporation_id = " & Corporation.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetDataSource(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustRet
                m.ShowDialog()
            Else
                If DateTimePicker1.Value = Nothing Or DateTimePicker2.Value = Nothing Then
                    cls.MsgExclamation("برجاء قم بادخال الفترة")
                    Exit Sub
                End If
                Dim f_d As Date = DateTimePicker1.Value
                Dim t_d As Date = DateTimePicker2.Value

                MyDs.Tables("report_inventory_log").Rows.Clear()
                cmd.CommandText = "select * from report_inventory_log where doc_date between '" & f_d.ToString("MM/dd/yyyy") & "' and '" & t_d.ToString("MM/dd/yyyy") & "' "
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetDataSource(MyDs.Tables("report_inventory_log"))
                RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustRet
                m.ShowDialog()

            End If
        Catch ex As Exception
            cls.MsgCritical("برجاء التأكد من المدخل")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub bydate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bydate.CheckedChanged
        If bydate.Checked = True Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
            Item.Enabled = False
            Stock.Enabled = False
            Category.Enabled = False
            Corporation.Enabled = False
        End If
    End Sub

    Private Sub byitem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByItem.CheckedChanged
        If ByItem.Checked = True Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            Item.Enabled = True
            Stock.Enabled = False
            Category.Enabled = False
            Corporation.Enabled = False
        End If
    End Sub

    Private Sub bystock_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bystock.CheckedChanged
        If bystock.Checked = True Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            Item.Enabled = False
            Stock.Enabled = True
            Category.Enabled = False
            Corporation.Enabled = False
        End If
    End Sub

    Private Sub bycat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycat.CheckedChanged
        If bycat.Checked = True Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            Item.Enabled = False
            Stock.Enabled = False
            Category.Enabled = True
            Corporation.Enabled = False
        End If
    End Sub

    Private Sub bycorporation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycorporation.CheckedChanged
        If bycorporation.Checked = True Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            Item.Enabled = False
            Stock.Enabled = False
            Category.Enabled = False
            Corporation.Enabled = True
        End If
    End Sub
End Class