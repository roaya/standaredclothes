Public Class FrmReportVendorsPayments
    Dim tbl1 As New GeneralDataSet.VendorsDataTable
    Dim rpt As New Report_Customers_Payments
    Private Sub FrmReportVendorsPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cls.RefreshData("SELECT * FROM vendors", TBL1)



        VendorID.DataSource = TBL1
        VendorID.ValueMember = "expense_detail_id"
        VendorID.DisplayMember = "expense_name"

    End Sub

    Private Sub RadAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadAll.CheckedChanged
        If RadAll.Checked = True Then
            VendorID.Enabled = False
        End If
    End Sub

    Private Sub Radvendor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Radvendor.Checked = True Then
            VendorID.Enabled = True
        End If
    End Sub
End Class