Public Class QueryByVendor
    Dim Gcls As GeneralSp.MasterForms
    Dim B_EndLoad As Boolean = False
    Dim ITEM_NAME As String
    Dim selformula As String
    Dim QueryByVendo As New DataTable
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Query_Items_Vendors"
    Private Sub QueryByVendor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataClear()
        DataLoad()
        RadItem.Checked = True
    End Sub
#Region "DataMethods"
    Private Sub DataClear()
        cmbItemName.SelectedIndex = -1
        cmbVendorID.SelectedIndex = -1
        txtBarCode.Text = ""
        RadItem.Checked = False
        chkVendor.Checked = False
        RadBarCode.Checked = False
        QueryByVendo.Rows.Clear()
    End Sub
    Private Sub DataLoad()
        cmd.CommandText = "select item_name from items"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            cmbItemName.Items.Add(dr("Item_Name"))
        Loop
        dr.Close()
        cmd.CommandText = "select Vendor_Name from Vendors"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            cmbVendorID.Items.Add(dr("Vendor_Name"))
        Loop
        dr.Close()
    End Sub

    Private Function DataValidate(errorMessage As String) As Boolean
        If Trim(txtBarCode.Text) = "" And
            cmbItemName.SelectedIndex = -1 And
            cmbVendorID.SelectedIndex = -1 Then
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
        cmd.CommandText = "" & selformula & ""
        da.SelectCommand = cmd
        If cmd.CommandText = "" Then MsgBox("لا توجد بيانات") : Exit Sub
        DataClear()
        da.Fill(QueryByVendo)
        If QueryByVendo.Rows.Count > 0 Then
            TabControl1.SelectedTab = TabPage2
            DataGridView1.Refresh()
            DataGridView1.DataSource = QueryByVendo
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(0).HeaderText = "كود المورد"
            DataGridView1.Columns(1).HeaderText = "اسم المورد"
            DataGridView1.Columns(2).HeaderText = "كود الصنف"
            DataGridView1.Columns(3).HeaderText = "اسم الصنف"
            DataGridView1.Columns(4).HeaderText = "الباركود"
        Else
            MsgBox("لا توجد بيانات")
        End If
    End Sub

    Private Sub chkVendor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVendor.CheckedChanged
        If chkVendor.Checked = True Then
            cmbVendorID.Enabled = True
        Else
            cmbVendorID.Enabled = False
            cmbVendorID.SelectedIndex = -1
        End If

    End Sub

    Private Sub choseForm()
        selformula = ""
        If cmbItemName.SelectedIndex <> -1 Then
            If selformula = "" Then
                selformula = "select * from Query_Items_Vendors where Item_Name=N'" & (cmbItemName.Text) & "'"
            Else
                selformula = selformula & " and " & "Item_Name='" & (cmbItemName.Text) & "'"
            End If
        End If

        If cmbVendorID.SelectedIndex <> -1 Then
            If selformula = "" Then
                selformula = "select * from Query_Items_Vendors where Vendor_Name=N'" & (cmbVendorID.Text) & "'"
            Else
                selformula = selformula & " and " & "Vendor_Name='" & (cmbVendorID.Text) & "'"
            End If
        End If
        If Trim(txtBarCode.Text) <> "" Then
            If selformula = "" Then
                selformula = "select * from Query_Items_Vendors where Barcode='" & (txtBarCode.Text) & "'"
            Else
                selformula = selformula & " and " & "Barcode='" & (txtBarCode.Text) & "'"
            End If
        End If
    End Sub

    Private Sub RadBarCode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadBarCode.CheckedChanged
        If RadBarCode.Checked = True Then
            txtBarCode.Enabled = True
        Else
            txtBarCode.Enabled = False
            txtBarCode.Text = ""
        End If

    End Sub

    Private Sub RadItem_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadItem.CheckedChanged
        If RadItem.Checked = True Then
            cmbItemName.Enabled = True
        Else
            cmbItemName.Enabled = False
            cmbItemName.SelectedIndex = -1
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class