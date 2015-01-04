Public Class QueryByBarcode

    Dim selformula As String
    Dim QueryAllItems As New DataTable
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Query_All_Items"
    Private Sub QueryByEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataClear()
        ' DataLoad()
    End Sub
#Region "DataMethods"
    Private Sub DataClear()

        QueryAllItems.Rows.Clear()

    End Sub
    'Private Sub DataLoad()
    '    cmbAgeID.DataSource = MyDs
    '    cmbAgeID.DisplayMember = "Ages.Age_Desc"
    '    cmbAgeID.ValueMember = "Ages.Age_ID"
    'End Sub

    Private Function DataValidate(ByVal errorMessage As String) As Boolean
        If TxtBarCode.Text = "" Then
            DataValidate = False
            errorMessage = "لا توجد بيانات."
        Else
            DataValidate = True
            errorMessage = ""

        End If

    End Function

#End Region
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'choseForm()
        DataClear()
        If TxtBarCode.Text = "" Then
            cls.MsgExclamation("أدخل الباركود")

        Else
            cmd.CommandText = "select Category_Name AS 'اسم البند',Item_Name AS 'اسم الصنف',Stock_Name AS 'اسم المحل',Purchase_Price AS 'سعر الشراء',Sale_Price AS 'سعر البيع',Sale_Total_Price AS 'سعر الجملة', Corporation_Name AS 'اسم الشركة',Gender_Name AS 'النوع',From_Age AS 'من سن',To_Age AS 'الي سن',Size_Name AS 'المقاس' FROM Query_All_Items where Barcode=N'" & TxtBarCode.Text & "'"
            da.SelectCommand = cmd
            da.Fill(QueryAllItems)
            DataGridView1.DataSource = QueryAllItems
            TabControl1.SelectTab(1)
        End If

        
        

    End Sub

    Private Sub choseForm()
        selformula = ""
        If TxtBarCode.Text <> "" Then
            selformula = "select Category_Name AS 'اسم البند',Item_Name AS 'اسم الصنف',Stock_Name AS 'اسم المحل',Purchase_Price AS 'سعر الشراء',Sale_Price AS 'سعر البيع',Sale_Total_Price AS 'سعر الجملة', Corporation_Name AS 'اسم الشركة',Gender_Name AS 'النوع',From_Age AS 'من سن',To_Age AS 'الي سن',Size_Name AS 'المقاس' FROM Query_All_Items where Barcode ='" & TxtBarCode.Text & "'"

        End If
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