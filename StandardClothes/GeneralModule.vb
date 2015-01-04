Module GeneralModule

    Public Run_Form As New Form
    Public s As Boolean = True
    Public cn As New SqlClient.SqlConnection
    Public ProjectTitle As String = "»—‰«„Ã «œ«—… «·„—«ﬂ“ «· Ã«—ÌÂ"
    Public cmd As New SqlClient.SqlCommand
    Public r As DataRow
    Public dr As SqlClient.SqlDataReader
    Public da As New SqlClient.SqlDataAdapter
    'Public cmdb As New SqlClient.SqlCommandBuilder
    Public MyDs As New GeneralDataSet
    Public cls As New GeneralSp.GeneralClass
    Public VenFBalance As Double
    Public custFBalance As Double
    Public CurID, seqid As New SqlClient.SqlParameter
    Public venBillFirstBalance, custBillFirstBalance As Integer
    Public EmpIDVar As Integer = 1
    Public EmpNameVar As String = "Hosam"
    Public UserNameVar As String = "Admin"
    Public Cr_Value As Double
    Public RVal As String
    Public SSource As New BindingSource
    Public Bill As Integer
    Public VendBill As Integer
    Public FilterDetails As Boolean = False
    Public DSource As New BindingSource
    Public re, vre As Boolean
    Public SlideShowTbl As New DataTable
    Public venFirst As Boolean
    Public custFirst As Boolean
    Public tblvendorsPyments As New GeneralDataSet.Vendors_PaymentsDataTable
    Public BSourceVenPayment As New BindingSource



    Public INC As Integer = 0
    Public CurrentShiftID As Integer = 0

    Public tblCustomerPyments As New GeneralDataSet.Customers_PaymentsDataTable
    Public BSourceCustPayment As New BindingSource

    Public p1 As New Size(172, 30)
    Public fnt1 As New System.Drawing.Font("tahoma", 9)

    Public p As New Size(172, 60)
    Public fnt As New System.Drawing.Font("tahoma", 11)




    '--------------------------------
    Public RptDB As String = "StandardClothes"
    Public RptSerName As String = "VS2010"
    Public RptUsr As String = "Sa"
    Public RptPwd As String = "pass@word1"
    '--------------------------------


    Public IsVendorAdded As Boolean = True
    Public IsCustomerAdded As Boolean = True
    Public LogTbl As New DataTable, ShowLogReport As Boolean

#Region "Setting"
    Public PurFooter As String = ""
    Structure StructSettings
        'Dim ShowSaveMsg As Boolean
        'Dim ActivePRDID As Integer
        'Dim ActivePRDName As String
        Dim CurrentStockID As Integer
        Dim CurrentStockName As String
        Dim SrchNameOnRtnVenNrml As Boolean
#Region "PO Settings"
        '        'Dim SrchNameOnPONrml As Boolean
        Dim POFilterDefaultFilter As POFilterEnum
#End Region

#Region "SalesOrder Settings"
        'Dim SrchNameOnSalesOrderNrml As Boolean
        Dim SalFilterDefaultFilter As SalFilterEnum
#End Region

#Region "General"
        Dim Gen_Print_Barcode As Integer
        Dim Gen_Print_Type As String
#End Region

    End Structure


    Enum POFilterEnum
        FilterSizeID = 1
        FilterCategoryID = 2
        FilterGenderID = 3
        FilterVendorID = 4
        FilterCorporationID = 5
        FilterTypeID = 6
    End Enum

    Enum SalFilterEnum
        FilterSizeID = 1
        FilterCategoryID = 2
        FilterGenderID = 3
        FilterCustomerID = 4
        FilterCorporationID = 5
        FilterTypeID = 6
    End Enum

    Public ProjectSettings As StructSettings

    Public IsTrial As Boolean = False

#End Region

End Module
