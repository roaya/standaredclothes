Public Class Ages

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceAges As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Ages"
    '-------------------------------
    Dim Rpt As New Report_Stock_Balance

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(TName)

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.DataSource = B
            OrderByCombo.DisplayMember = "Logical_Name"
            OrderByCombo.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceAges, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords, MenuNew, MenuSave, MenuDelete, MenuSearch, MenuExit)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------


            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "��������� �������"
            Me.Text = Gcls.SetWTitle

            'GenderID.DataSource = MyDs
            'GenderID.DisplayMember = "Gender.Gender_Name"
            'GenderID.ValueMember = "Gender.Gender_ID"
            'GenderID.DataBindings.Add("SelectedValue", BSourceAges, "Gender_ID")
            TxtAgeDesc.TextBox1.DataBindings.Add("Text", BSourceAges, "Age_Desc")
            FromAge.DataBindings.Add("Value", BSourceAges, "From_Age")
            ToAge.DataBindings.Add("Value", BSourceAges, "To_Age")

            SSource = BSourceAges

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_ID"

            B_EndLoad = True


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click
        Try
            Gcls.NewRecord()
            txtagedesc.TextBox1.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click
        Try
            If txtagedesc.TextBox1.Text = "" Then
                cls.MsgComplete()
                txtagedesc.TextBox1.Focus()
                txtagedesc.TextBox1.BackColor = Color.Red
            ElseIf fromage.Value <= 0 Or toage.Value <= 0 Then
                cls.MsgComplete()
            Else
                Gcls.SaveRecord()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuDelete.Click
        Try
            Gcls.DeleteRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            Gcls.LastRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Try
            Gcls.NextRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        Try
            Gcls.PreviousRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirst.Click
        Try
            Gcls.FirstRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click, MenuSearch.Click
        Try
            Gcls.EditRecord()
            txtagedesc.TextBox1.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    'Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CutData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CopyData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.PasteData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    Private Sub OrderByCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderByCombo.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                Gcls.SortData(BSourceAges, OrderByCombo.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Try
            Gcls.ExitForm()
            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Gcls.ReloadData()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelSerach.Click
        Try
            BSourceAges.RemoveFilter()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Gcls.BtnFile()
    End Sub

    Private Sub BtnData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnData.Click
        Gcls.BtnData()
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click
        Gcls.BtnHelp()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New FirstBalanceStock
        m.ShowDialog()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim M As New Items
        M.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim M As New ItemsStocks
        M.ShowDialog()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New Categories
        m.ShowDialog()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim m As New QueryByBarcode

        m.ShowDialog()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim m As New QueryItemsStocks
        m.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim s As String
            s = InputBox("���� ���� ����", ProjectTitle)
            If s = "" Or s <> "251" Or s Is Nothing Then
                cls.MsgExclamation("���� �� �����")
            Else
                MyDs.Tables("Vu_Stock_Value").Rows.Clear()
                cmd.CommandText = "SELECT I.ITEM_NAME,SI.BALANCE,I.PURCHASE_PRICE,I.PURCHASE_PRICE*SI.BALANCE AS PUR_TOTAL,I.Sale_Price,I.Sale_Price*SI.Balance AS SAL_TOTAL," & _
        " I.Sale_Total_Price,I.Sale_Total_Price*SI.Balance AS SAL_ALL_TOTAL FROM Items I , Items_Stocks SI ," & _
        " Stocks S WHERE I.Item_ID=SI.Item_ID AND S.Stock_ID=SI.Stock_ID AND S.Stock_ID=" & ProjectSettings.CurrentStockID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Vu_Stock_Value"))
                Rpt.SetDataSource(MyDs.Tables("Vu_Stock_Value"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = Rpt

                m.ShowDialog()

            End If
        Catch ex As Exception
            cls.WriteError("��� �� ����� �������", "Stock Balance")
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim M As New Stocks
        M.ShowDialog()

    End Sub
    Private Sub fromage_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fromage.GotFocus
        fromage.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub fromage_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fromage.Leave
        fromage.BackColor = Color.White
    End Sub
    Private Sub toage_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles toage.GotFocus
        toage.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub PurchasePrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles toage.Leave
        toage.BackColor = Color.White
    End Sub

End Class
