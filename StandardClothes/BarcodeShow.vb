Public Class BarcodeShow

   

    Private Sub TxtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cmd.CommandText = "select count(*) from items where barcode =N'" & TxtBarcode.Text & "'"
                If cmd.ExecuteScalar = 0 Then

                    cls.MsgExclamation("باركود غير صحيح")
                    Exit Sub
                End If

                cmd.CommandText = "select barcode from items where barcode =N'" & TxtBarcode.Text & "'"
                LblBarcode.Label1.Text = cmd.ExecuteScalar
                cmd.CommandText = "select item_name from items where barcode =N'" & TxtBarcode.Text & "'"
                LblItemNAme.Label1.Text = cmd.ExecuteScalar
                cmd.CommandText = "select price from items where barcode =N'" & TxtBarcode.Text & "'"
                LblPrice.Label1.Text = cmd.ExecuteScalar

                TxtBarcode.Text = ""
                TxtBarcode.Focus()
            End If
        Catch ex As Exception
            Dim m As Integer
        End Try

    End Sub
End Class