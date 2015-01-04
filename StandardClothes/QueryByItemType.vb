Public Class QueryByItemType


    Dim selformula As String
    Dim QueryAllItems As New DataTable
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Query_All_Items"
    Private Sub QueryByEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataClear()
        DataLoad()
    End Sub
#Region "DataMethods"
    Private Sub DataClear()

        QueryAllItems.Rows.Clear()

    End Sub
    Private Sub DataLoad()
        cls.LoadList("Type_Name", "Items_Types", cmbTypeID)
    End Sub

    Private Function DataValidate(ByVal errorMessage As String) As Boolean
        If cmbTypeID.SelectedIndex = -1 Then
            DataValidate = False
            errorMessage = "لا توجد بيانات."
        Else
            DataValidate = True
            errorMessage = ""

        End If

    End Function

#End Region
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        choseForm()
        DataClear()
        cmd.CommandText = "" & selformula & ""
        If cmd.CommandText = "" Then cls.MsgExclamation("لا توجد بيانات") : Exit Sub
        da.SelectCommand = cmd
        da.Fill(QueryAllItems)

        DataGridView1.DataSource = QueryAllItems
        If QueryAllItems.Rows.Count > 0 Then
            TabControl1.SelectedTab = TabPage2

        Else
            cls.MsgExclamation("لا توجد بيانات")
        End If

    End Sub

    Private Sub choseForm()
        selformula = ""
        If cmbTypeID.SelectedIndex <> -1 Then
            selformula = "select Category_Name AS 'اسم البند',Item_Name AS 'اسم الصنف',Stock_Name AS 'اسم المحل',Purchase_Price AS 'سعر الشراء',Sale_Price AS 'سعر البيع',Sale_Total_Price AS 'سعر الجملة', Corporation_Name AS 'اسم الشركة',Gender_Name AS 'النوع',From_Age AS 'من سن',To_Age AS 'الي سن',Size_Name AS 'المقاس' FROM Query_All_Items where Type_Name =N'" & (cmbTypeID.Text) & "'"


        End If
    End Sub


   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class