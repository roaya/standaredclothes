Public Class Report_Items_Prices
    Dim Tbl As New DataTable
    Dim FromD, ToD As Date

    Private Sub Report_Items_Prices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FromD = DateTimePicker1.Text
        ToD = DateTimePicker2.Text

        cls.RefreshData("select Item_Name,Price,Sale_Price,Discount_Type,Discount_Value,employee_Name from Report_Items_Prices where price<>sale_price or discount_value>0 and bill_Date between '" & FromD.ToString("MM/dd/yyyy") & "' and '" & ToD.ToString("MM/dd/yyyy") & "'", Tbl)
        DataGridView1.DataSource = Tbl

        DataGridView1.Columns(0).HeaderText = "اسم الصنف"
        DataGridView1.Columns(1).HeaderText = "سعر البيع"
        DataGridView1.Columns(2).HeaderText = "سعر الصنف"
        DataGridView1.Columns(3).HeaderText = "نوع الخصم"
        DataGridView1.Columns(4).HeaderText = "قيمة الخصم"
        DataGridView1.Columns(5).HeaderText = "اسم الموظف"
    End Sub
End Class