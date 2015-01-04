Public Class QueryItemsByStock


    Private Sub QueryItemsStocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MyDs.Tables("Items_Stocks").Rows.Clear()

            ItemName.Items.Clear()
            cmd.CommandText = "select item_name from items"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ItemName.Items.Add(dr("Item_Name"))
            Loop
            dr.Close()

            DataGridView1.DataSource = MyDs.Tables("Items_Stocks")
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "اسم الصنف"
            DataGridView1.Columns(3).HeaderText = "الباركود"
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).HeaderText = "اسم المحل"
            DataGridView1.Columns(6).HeaderText = "الرصيد"
        Catch ex As Exception
            cls.WriteError(ex.Message, "Qry Itms by Stks")
        End Try
    End Sub

 

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ItemName.Text = "" Then
                cls.MsgExclamation("أدخل اسم الصنف")
            Else
                cmd.CommandText = "SELECT DBO.Check_Item_Name_Exists(N'" & itemname.Text & "')"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgCritical("هذا الصنف غير موجود")
                Else
                    MyDs.Tables("Items_Stocks").Rows.Clear()
                    cmd.CommandText = "select  serial_pk,item_id,item_name,barcode,stock_id,stock_name,balance from Query_Items_Stocks where Item_Name = N'" & itemname.Text & "'"
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Items_Stocks"))
                    DataGridView1.DataSource = MyDs.Tables("Items_Stocks")
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Qry Itms by Stks")
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
End Class