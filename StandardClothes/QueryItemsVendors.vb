Public Class QueryItemsVendors

    Private Sub QueryItemsVendors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.LoadList("Vendor_Name", "Vendors", VendorName, " Order by Vendor_Name")
        cls.LoadList("Item_Name", "Items", ItemName, " Order by Item_Name")

        DataGridView1.DataSource = MyDs.Tables("Query_Items_Vendors")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).HeaderText = "اسم الصنف"
        DataGridView1.Columns(1).HeaderText = "اسم المورد"
        DataGridView1.Columns(4).HeaderText = "الباركود"

    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        If ItemName.Text <> "" Then
            cmd.CommandText = "SELECT DBO.Check_Item_Name_Exists('" & ItemName.Text & "')"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgCritical("هذا الصنف غير موجود")
                ItemName.Focus()
            End If
        End If
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
    
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub RadioVendorName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioVendorName.CheckedChanged
        If RadioVendorName.Checked = True Then
            VendorName.Enabled = True
            ItemName.Enabled = False
        End If
    End Sub

    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            VendorName.Enabled = False
            ItemName.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioItemName.Checked = True Then
            If ItemName.Text = "" Then
                cls.MsgExclamation("أدخل اسم المحل")
            Else
                MyDs.Tables("Query_Items_Vendors").Rows.Clear()
                cmd.CommandText = "select * from Query_Items_Vendors where Item_Name = N'" & ItemName.Text & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Query_Items_Vendors"))

            End If
        ElseIf RadioVendorName.Checked = True Then
            If VendorName.Text = "" Then
                cls.MsgExclamation("أدخل اسم المحل")
            Else
                MyDs.Tables("Query_Items_Vendors").Rows.Clear()
                cmd.CommandText = "select * from Query_Items_Vendors where Vendor_Name = N'" & VendorName.Text & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Query_Items_Vendors"))

            End If
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