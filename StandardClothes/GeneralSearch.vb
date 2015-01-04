Public Class GeneralSearch

    Dim STable As New GeneralDataSet.SearchTableDataTable
    Dim DtlTbl As New DataTable

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        STable.Rows.Clear()
        DtlTbl.Rows.Clear()
        DtlTbl.Columns.Clear()
        Try

        
        If e.KeyCode = Keys.Enter And TxtSearch.Text <> "" Then
            cmd.CommandText = "select customer_id as ColID,N'عملاء' as ColType,customer_name as ColName,N'البيانات الشخصيه للعميل' as ColDesc from customers where customer_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Vendor_id as ColID,N'موردين' as ColType,Vendor_name as ColName,N'البيانات الشخصيه للمورد' as ColDesc from Vendors where Vendor_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات التفصيليه للأصناف' as ColDesc from Items where Item_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات التفصيليه للأصناف' as ColDesc from Items where barcode like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Employee_id as ColID,N'بيانات العاملين' as ColType,Employee_name as ColName,N'بيانات التفصيليه للعاملين' as ColDesc from employees where employee_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Expense_Detail_ID as ColID,N'المصروفات' as ColType,Expense_name as ColName,N'تفاصيل المصروفات' as ColDesc from Expenses_Details where Expense_Name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Expense_Category_ID as ColID,N'بنود المصروفات' as ColType,Expense_Category_name as ColName,N'بيانات بنود المصروفات' as ColDesc from Expenses_Header where Expense_Category_Name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Stock_ID as ColID,N'المحلات' as ColType,Stock_Name as ColName,N'بيانات المحلات' as ColDesc from Stocks where Stock_Name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Category_id as ColID,N'بنود المخزن' as ColType,Category_name as ColName,N'بيانات بنود المخزن' as ColDesc from categories where Category_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select corporation_id as ColID,N'الشركات' as ColType,corporation_name as ColName,N'بيانات الشركات التفصيليه' as ColDesc from corporations where corporation_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Type_ID as ColID,N'الفئات' as ColType,Type_name as ColName,N'بيانات فئات الأصناف' as ColDesc from Items_Types where Type_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Gender_ID as ColID,N'النوع' as ColType,Gender_name as ColName,N'النوع' as ColDesc from Gender where Gender_name like N'%" & TxtSearch.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            'cmd.CommandText = "select distinct item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات الأصناف بالشركات' as ColDesc from dbo.Query_All_Items where Corporation_Name like N'%" & TxtSearch.Text & "%'"
            'da.SelectCommand = cmd
            'da.Fill(STable)
            ''------------------------------------------
            'cmd.CommandText = "select distinct item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات الأصناف بالنوع' as ColDesc from dbo.Query_All_Items where Gender_Name like N'%" & TxtSearch.Text & "%'"
            'da.SelectCommand = cmd
            'da.Fill(STable)
            ''------------------------------------------
            'cmd.CommandText = "select distinct item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات الأصناف بالمقاس' as ColDesc from dbo.Query_All_Items where Size_Name like N'%" & TxtSearch.Text & "%'"
            'da.SelectCommand = cmd
            'da.Fill(STable)
            ''------------------------------------------
            'cmd.CommandText = "select distinct item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات الأصناف بالفئه' as ColDesc from dbo.Query_All_Items where Type_Name like N'%" & TxtSearch.Text & "%'"
            'da.SelectCommand = cmd
                'da.Fill(STable)
            End If
                Catch ex As Exception
            Dim S As String
        End Try

    End Sub

    Private Sub GeneralSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GrdSearch.DataSource = STable
        GrdSearch.Columns(0).Visible = False
        GrdSearch.Columns(1).HeaderText = "نوع البيانات"
        GrdSearch.Columns(2).HeaderText = "البيان التوضيحي"
        GrdSearch.Columns(3).HeaderText = "وصف البيانات"
        GrdSearchDetails.DataSource = DtlTbl
    End Sub

    Private Sub GrdSearch_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdSearch.RowHeaderMouseDoubleClick

        DtlTbl.Rows.Clear()
        DtlTbl.Columns.Clear()
        Try

       
        Select Case GrdSearch.SelectedRows(0).Cells("ColType").Value
            Case "عملاء"
                cmd.CommandText = "select customer_id , customer_name as N'اسم العميل', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from customers where customer_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "موردين"
                cmd.CommandText = "select vendor_id , vendor_name as N'اسم المورد', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from vendors where vendor_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بيانات العاملين"
                cmd.CommandText = "select employee_id , employee_name as N'اسم الموظف', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from employees where employee_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود المصروفات"
                cmd.CommandText = "select Expense_Detail_id , Expense_name as N'اسم المصروف', Expense_Value as N'قيمة المصروف', Expense_Date as N'تاريخ المصروف' from Expenses_Details where Expense_Category_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بيانات الأصناف"
                cmd.CommandText = "select distinct item_id , Stock_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله',Balance as N'الرصيد' from Query_All_Items where item_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "المحلات"
                cmd.CommandText = "select distinct item_id ,Stock_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله',Balance as N'الرصيد' from Query_All_Items where stock_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود المخزن"
                cmd.CommandText = "select distinct item_id ,Stock_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله',Balance as N'الرصيد' from Query_All_Items where category_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الشركات"
                cmd.CommandText = "select distinct item_id ,Stock_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله',Balance as N'الرصيد' from Query_All_Items where corporation_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الفئات"
                cmd.CommandText = "select distinct item_id ,Stock_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله',Balance as N'الرصيد' from Query_All_Items where Type_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
        End Select

        da.SelectCommand = cmd
        da.Fill(DtlTbl)
            GrdSearchDetails.Columns(0).Visible = False
        Catch ex As Exception
            Dim M As Integer
        End Try
    End Sub

    Private Sub GrdSearchDetails_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdSearchDetails.RowHeaderMouseDoubleClick

        Try
            Select Case GrdSearchDetails.SelectedRows(0).Cells(0).OwningColumn.Name
                Case "customer_id"
                    Dim m As New Customers
                    m.SearchCustomerID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "vendor_id"
                    Dim m As New Vendors
                    m.SearchvendorID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "employee_id"
                    Dim m As New Employees
                    m.SearchEmployeeID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "Expense_Detail_id"
                    Dim m As New ExpensesDetails
                    m.SearchExpenseDetailID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "item_id"
                    Dim m As New Items
                    m.SearchItemID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
            End Select
        Catch ex As Exception
            Dim M As Integer
        End Try
    End Sub

  
 
End Class