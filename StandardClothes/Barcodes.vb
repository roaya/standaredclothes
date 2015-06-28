Public Class Barcodes

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceBarCodes As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "BarCodes"
    Dim Item As Object
    '-------------------------------
    Sub New(ByVal item As Object)
        Me.Item = item
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        BSourceBarCodes.RemoveFilter()
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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceBarCodes, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, Nothing, CountRecords, MenuNew, MenuSave, MenuDelete, MenuSearch, MenuExit)
            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            BSourceBarCodes.Filter = "Bar_Item_Id = " & Item

            CountRecords.Text = BSourceBarCodes.Count

            Gcls.SetWTitle = "«·»«—ﬂÊœ"
            Me.Text = Gcls.SetWTitle

            BarCode.DataBindings.Add("Text", BSourceBarCodes, "Bar_Code")

            SSource = BSourceBarCodes
        


            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Bar_Code"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click
        Try
            Gcls.NewRecord()
            CountRecords.Text = BSourceBarCodes.Count
            CType(BSourceBarCodes.Current, DataRowView).Item("bar_item_id") = Item
            BarCode.Focus()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click
        Try
           If BarCode.Text = "" Then
                cls.MsgComplete()
                BarCode.Focus()
                BarCode.BackColor = Color.Red
            Else
                Gcls.SaveRecord()
                BSourceBarCodes.Filter = "Bar_Item_Id = " & Item
                CountRecords.Text = BSourceBarCodes.Count
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuDelete.Click
        Try
            Gcls.DeleteRecord()
            BSourceBarCodes.Filter = "Bar_Item_Id = " & Item
            CountRecords.Text = BSourceBarCodes.Count
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
            'MasterField1.TextBox1.Focus()
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
                Gcls.SortData(BSourceBarCodes, OrderByCombo.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Try
            BSourceBarCodes.RemoveFilter()
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
            BSourceBarCodes.RemoveFilter()
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
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FirstBalanceStock
        m.ShowDialog()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim M As New Items
        M.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim M As New ItemsStocks
        M.ShowDialog()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New Categories
        m.ShowDialog()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New QueryByBarcode

        m.ShowDialog()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New QueryItemsStocks
        m.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim s As String
            s = InputBox("√œŒ· ﬂ·„… «·”—", ProjectTitle)
            If s = "" Or s <> "251" Or s Is Nothing Then
                cls.MsgExclamation("ﬂ·„… ”— Œ«ÿ∆Â")
            Else
                MyDs.Tables("Vu_Stock_Value").Rows.Clear()
                cmd.CommandText = "SELECT I.ITEM_NAME,SI.BALANCE,I.PURCHASE_PRICE,I.PURCHASE_PRICE*SI.BALANCE AS PUR_TOTAL,I.Sale_Price,I.Sale_Price*SI.Balance AS SAL_TOTAL," & _
        " I.Sale_Total_Price,I.Sale_Total_Price*SI.Balance AS SAL_ALL_TOTAL FROM Items I , Items_Stocks SI ," & _
        " Stocks S WHERE I.Item_ID=SI.Item_ID AND S.Stock_ID=SI.Stock_ID AND S.Stock_ID=" & ProjectSettings.CurrentStockID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Vu_Stock_Value"))
                'Rpt.SetDataSource(MyDs.Tables("Vu_Stock_Value"))
                'Dim m As New ShowAllReports
                'm.CrystalReportViewer1.ReportSource = Rpt

                'm.ShowDialog()

            End If
        Catch ex As Exception
            cls.WriteError("Œÿ√ ›Ì  ‘€Ì· «· ﬁ—Ì—", "Stock Balance")
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim M As New Stocks
        M.ShowDialog()

    End Sub
End Class
