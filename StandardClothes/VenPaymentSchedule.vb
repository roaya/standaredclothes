Public Class VenPaymentSchedule

    Friend billID As Integer
    Dim d As Date

    Private Sub CheckFirstPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFirstPayment.CheckedChanged
        If CheckFirstPayment.Checked = True Then
            FirstPayment.Enabled = True
            FirstDate.Enabled = True
            SecondPayment.Enabled = False
            SecondDate.Enabled = False
            ThirdPayment.Enabled = False
            ThirdDate.Enabled = False
            ForthPayment.Enabled = False
            ForthDate.Enabled = False
            FifthPayment.Enabled = False
            FifthDate.Enabled = False
        End If
        FirstPayment.Value = 0
        SecondPayment.Value = 0
        ThirdPayment.Value = 0
        ForthPayment.Value = 0
        FifthPayment.Value = 0
    End Sub

    Private Sub CheckSecondPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSecondPayment.CheckedChanged
        If CheckSecondPayment.Checked = True Then
            'FirstPayment.Enabled = True
            'FirstDate.Enabled = True
            SecondPayment.Enabled = True
            SecondDate.Enabled = True
            ThirdPayment.Enabled = False
            ThirdDate.Enabled = False
            ForthPayment.Enabled = False
            ForthDate.Enabled = False
            FifthPayment.Enabled = False
            FifthDate.Enabled = False
        End If
        'FirstPayment.Value = 0
        SecondPayment.Value = 0
        ThirdPayment.Value = 0
        ForthPayment.Value = 0
        FifthPayment.Value = 0
    End Sub

    Private Sub CheckThirdPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckThirdPayment.CheckedChanged
        If CheckThirdPayment.Checked = True Then
            'FirstPayment.Enabled = True
            'FirstDate.Enabled = True
            'SecondPayment.Enabled = False
            'SecondDate.Enabled = False
            ThirdPayment.Enabled = True
            ThirdDate.Enabled = True
            ForthPayment.Enabled = False
            ForthDate.Enabled = False
            FifthPayment.Enabled = False
            FifthDate.Enabled = False
        End If
        'FirstPayment.Value = 0
        ' SecondPayment.Value = 0
        ThirdPayment.Value = 0
        ForthPayment.Value = 0
        FifthPayment.Value = 0
    End Sub

    Private Sub CheckForthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForthPayment.CheckedChanged
        If CheckForthPayment.Checked = True Then
            'FirstPayment.Enabled = True
            'FirstDate.Enabled = True
            'SecondPayment.Enabled = False
            'SecondDate.Enabled = False
            'ThirdPayment.Enabled = False
            'ThirdDate.Enabled = False
            ForthPayment.Enabled = True
            ForthDate.Enabled = True
            FifthPayment.Enabled = False
            FifthDate.Enabled = False
        End If
        ' FirstPayment.Value = 0
        ' SecondPayment.Value = 0
        ' ThirdPayment.Value = 0
        ForthPayment.Value = 0
        FifthPayment.Value = 0
    End Sub

    Private Sub CheckFifthPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFifthPayment.CheckedChanged
        If CheckForthPayment.Checked = True Then
            'FirstPayment.Enabled = True
            'FirstDate.Enabled = True
            'SecondPayment.Enabled = False
            'SecondDate.Enabled = False
            'ThirdPayment.Enabled = False
            'ThirdDate.Enabled = False
            'ForthPayment.Enabled = True
            'ForthDate.Enabled = True
            FifthPayment.Enabled = True
            FifthDate.Enabled = True
        End If
        '  FirstPayment.Value = 0
        '  SecondPayment.Value = 0
        '  ThirdPayment.Value = 0
        '   ForthPayment.Value = 0
        FifthPayment.Value = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            
            If FirstPayment.Value + SecondPayment.Value + ThirdPayment.Value + ForthPayment.Value + FifthPayment.Value <> CDbl(TotalPayments.Text) Then
                cls.MsgCritical("القيم المجدولة يجب ان تتساوي مع اجمالي قيمة الآجل")
            ElseIf CheckFirstPayment.Checked = True And FirstPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة")
            ElseIf CheckSecondPayment.Checked = True And SecondPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة")
            ElseIf CheckThirdPayment.Checked = True And ThirdPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة")
            ElseIf CheckForthPayment.Checked = True And ForthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة")
            ElseIf CheckFifthPayment.Checked = True And FifthPayment.Value = 0 Then
                cls.MsgCritical("ادخل قيمة الدفعة المحددة")
            Else
                MyDs.Tables("Ven_Sch_Payments").Rows.Clear()

                If CheckFirstPayment.Checked = True Then
                    d = FirstDate.Text
                    r = MyDs.Tables("Ven_Sch_Payments").NewRow
                    r("Payment_Date") = FirstDate.Text '.ToString("MM/dd/yyyy")
                    r("bill_id") = billID
                    r("Payment_Value") = FirstPayment.Value
                    MyDs.Tables("Ven_Sch_Payments").Rows.Add(r)

                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & billid & " , " & FirstPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckSecondPayment.Checked = True Then
                    d = SecondDate.Text
                    r = MyDs.Tables("Ven_Sch_Payments").NewRow
                    r("Payment_Date") = SecondDate.Text 'd.ToString("MM/dd/yyyy")
                    r("bill_id") = billID
                    r("Payment_Value") = SecondPayment.Value
                    MyDs.Tables("Ven_Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & billid & " , " & SecondPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckThirdPayment.Checked = True Then
                    d = ThirdDate.Text
                    r = MyDs.Tables("Ven_Sch_Payments").NewRow
                    r("Payment_Date") = ThirdDate.Text 'd.ToString("MM/dd/yyyy")
                    r("bill_id") = billID
                    r("Payment_Value") = ThirdPayment.Value
                    MyDs.Tables("Ven_Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & billid & " , " & ThirdPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckForthPayment.Checked = True Then
                    d = ForthDate.Text
                    r = MyDs.Tables("Ven_Sch_Payments").NewRow
                    r("Payment_Date") = ForthDate.Text 'd.ToString("MM/dd/yyyy")
                    r("bill_id") = billID
                    r("Payment_Value") = ForthPayment.Value
                    MyDs.Tables("Ven_Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & billid & " , " & ForthPayment.Value
                    'cmd.ExecuteNonQuery()
                End If

                If CheckFifthPayment.Checked = True Then
                    d = FifthDate.Text
                    r = MyDs.Tables("Ven_Sch_Payments").NewRow
                    r("Payment_Date") = FifthDate.Text 'd.ToString("MM/dd/yyyy")
                    r("bill_id") = billID
                    r("Payment_Value") = FifthPayment.Value
                    MyDs.Tables("Ven_Sch_Payments").Rows.Add(r)
                    'cmd.CommandText = "exec Customer_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & billid & " , " & FifthPayment.Value
                    'cmd.ExecuteNonQuery()
                End If
                cls.MsgInfo("تم جدولة مواعيد الدفع بنجاح")
                Me.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Ven Payment Sch")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MyDs.Tables("Ven_Sch_Payments").Rows.Clear()
        cls.MsgInfo("تم الغاء الدفعات المجدولة بنجاح")
        Me.Close()
    End Sub

    Private Sub VenPaymentSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If venFirst = True Then
            TotalPayments.Text = VenFBalance
            billID = venBillFirstBalance
        End If
    End Sub
End Class