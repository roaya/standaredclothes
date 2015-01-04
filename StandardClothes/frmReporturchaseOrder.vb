Public Class frmReportPurchaseOrder
    Dim Gcls As GeneralSp.MasterForms
    Dim B_EndLoad As Boolean = False
    Dim ITEM_NAME As String
    Dim selformula As String
    Dim ReportPurchaseItemTable As New DataTable
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "ReportPurchaseItemTable"
    Dim RptExpenses As New Report_Purchase_Order
    Private Sub QueryByEmployee_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataClear()
        DataLoad()
        RadVenID.Checked = True
    End Sub
#Region "DataMethods"
    Private Sub DataClear()
        cmbCat.SelectedIndex = -1
        cmbItem.SelectedIndex = -1
        CmbVendor.SelectedIndex = -1
        RadItem.Checked = True
        RadDate.Checked = False
        RadType.Checked = False
        RadVenID.Checked = False
        ReportPurchaseItemTable.Rows.Clear()
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        RadDate.Enabled = True
    End Sub
    Private Sub DataLoad()
        cmd.CommandText = "select Category_Name from Rewards_Categories"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            cmbCat.Items.Add(dr("Category_Name"))
        Loop
        dr.Close()
        cmd.CommandText = "select Item_Name from Items"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            cmbItem.Items.Add(dr("Item_Name"))
        Loop
        dr.Close()
        cmd.CommandText = "select Vendor_Name from Vendors"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            CmbVendor.Items.Add(dr("Vendor_Name"))
        Loop
        dr.Close()
    End Sub

    Private Function DataValidate(errorMessage As String) As Boolean
        If cmbCat.SelectedIndex = -1 And
           CmbVendor.SelectedIndex = -1 Then
            DataValidate = False
            errorMessage = "لا توجد بيانات."
        Else
            DataValidate = True
            errorMessage = ""

        End If

    End Function

#End Region
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        choseForm()
        DataClear()
        Me.Cursor = Cursors.WaitCursor
        cmd.CommandText = "" & selformula & ""
        da.SelectCommand = cmd
        If cmd.CommandText = "" Then MsgBox("لا توجد بيانات") : Exit Sub
        da.Fill(ReportPurchaseItemTable)
        If ReportPurchaseItemTable.Rows.Count > 0 Then

            RptExpenses.SetDataSource(MyDs.Tables("ReportPurchaseItemTable"))
            'VU.RowFilter = "bill_id =" & BillID.Text
            'CrystalReportViewer1.SelectionFormula = ""
            CrystalReportViewer1.ReportSource = RptExpenses
            TabControl1.SelectTab(1)

            Me.Cursor = Cursors.Default
        Else
            MsgBox("لا توجد بيانات")
        End If

    End Sub
    Private Sub choseForm()
        selformula = ""
        If CmbVendor.SelectedIndex <> -1 Then
            selformula = "select * from Report_Purchase_Order where Vendor_Name=N'" & (CmbVendor.Text) & "'"

        End If

        If cmbCat.SelectedIndex <> -1 Then
            selformula = "select * from Report_Purchase_Order where Category_Name=N'" & (cmbCat.Text) & "'"
        End If

        If cmbItem.SelectedIndex <> -1 Then
            selformula = "select * from Report_Purchase_Order where Item_Name=N'" & (cmbItem.Text) & "'"
        End If

        If RadDate.Checked = True Then
            Dim date1 As Date = CDate(DateTimePicker1.Text)
            Dim date2 As Date = CDate(DateTimePicker2.Text)
            selformula = "select * from Report_Purchase_Order where Bill_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
        End If
    End Sub

    Private Sub RadType_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadType.CheckedChanged
        If RadType.Checked = True Then
            cmbCat.Enabled = True
        Else
            cmbCat.Enabled = False
            cmbCat.SelectedIndex = -1
        End If


    End Sub

    Private Sub RadItem_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadItem.CheckedChanged
        If RadItem.Checked = True Then
            cmbItem.Enabled = True
        Else
            cmbItem.Enabled = False
            cmbItem.SelectedIndex = -1
        End If
    End Sub

    Private Sub RadVenID_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadVenID.CheckedChanged
        If RadVenID.Checked = True Then
            CmbVendor.Enabled = True
        Else
            CmbVendor.Enabled = False
            CmbVendor.SelectedIndex = -1
        End If

    End Sub

    Private Sub RadDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadDate.CheckedChanged
        If RadDate.Checked = True Then
            RadDate.Enabled = True
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False

        End If
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
End Class
